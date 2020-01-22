using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Services;

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

        // 点击添加按钮时,将内容视图换成AddItem的视图
        public void AddItem()
        {
            Content = new AddItem_VM();
        }

        #endregion 方法
    }
}
