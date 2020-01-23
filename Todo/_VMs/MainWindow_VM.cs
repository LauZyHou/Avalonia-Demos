using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Services;
using System.Reactive.Linq;
using Todo._Ms;

namespace Todo._VMs
{
    // 因为TodoList放在主窗体里,所以在主窗体的VM中要集成TodoList的VM
    public class MainWindow_VM : ViewModelBase
    {
        #region 字段

        private ViewModelBase content;

        #endregion 字段

        #region 构造器

        // 在构造时从DataBase里取TodoList的VM
        public MainWindow_VM(Database db)
        {
            Content = TodoListVM = new TodoList_VM(db.GetItems());
        }

        #endregion 构造器

        #region 属性

        // 待办列表项的VM
        public TodoList_VM TodoListVM { get; }

        // 用于MainWindow绑定可变的Content(点击Add时候不再显示列表而是显示添加视图)
        public ViewModelBase Content
        {
            get => content;
            /*
             每次属性更改值时都触发更改通知
             Avalonia的绑定系统需要更改通知
             以便知道何时响应属性更改来更新用户界面。
            */
            // 这是ReactiveUI的通知方式
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        #endregion 属性

        #region 方法

        // 点击添加按钮时执行此方法
        public void AddItem()
        {
            // 创建AddItem的VM
            AddItem_VM vm = new AddItem_VM();

            /*
             Observable.Merge合并任意数量的Obervable对象的输出
             (这里ReactiveCommand本身就是Observable的)
             并将它们合并为单个Observable流
             因为它们正在合并到单个流中，所以它们必须是同一类型
             可以看下在AddItem_VM两个命令的定义，返回类型一个是TodoItem一个是Unit(也就是void)
             这里把Cancel的空转为空的TodoItem，类型就一样了
             */
            Observable.Merge(
                vm.Ok,
                vm.Cancel.Select(_ => (TodoItem)null)
                )
                .Take(1) // 因为只对按下"Ok"或"Cancel"的情况的第一次感兴趣,这里表示只取观察序列的第一个值
                .Subscribe( // 订阅观察结果
                    // 这两个命令产生的返回值是TodoItem或者null
                    model =>
                    {
                        // 如果不是null,也就是按下了Ok,那么要添加进展示的列表中
                        if (model != null)
                        {
                            TodoListVM.Items.Add(model);
                        }
                        // 不论是Ok还是Cancel,都要返回到显示列表的视图
                        Content = TodoListVM;
                    }
                );

            // 将内容换成AddItem的VM,以去显示一个添加页
            Content = vm;
        }

        #endregion 方法
    }
}
