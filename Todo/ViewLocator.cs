using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Todo._VMs;

namespace Todo
{
    // 在MainWindow的xaml中直接指定其Content绑定为MainWindowVM中集成的TodoListVM,但是TodoListVM的样式从哪来?
    // 这就是这个类所做的事情
    // 这个类用于将ViewModel映射到相应的View类中去,以在使用ViewModel时候能够搜索到对应的视图是哪个类
    // 这是一个数据模板
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        // 获取到类的全名,将其中的"_VM"替换为"_V"
        public IControl Build(object data)
        {
            var name = data.GetType().FullName.Replace("_VM", "_V");
            var type = Type.GetType(name);

            // 如果匹配成功就创建相应View的对象然后将对象返回
            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        // 匹配那些继承自ViewModelBase的类,当匹配到这些类时要执行上面的Build方法
        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}