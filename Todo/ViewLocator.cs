using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Todo._VMs;

namespace Todo
{
    // ��MainWindow��xaml��ֱ��ָ����Content��ΪMainWindowVM�м��ɵ�TodoListVM,����TodoListVM����ʽ������?
    // ��������������������
    // ��������ڽ�ViewModelӳ�䵽��Ӧ��View����ȥ,����ʹ��ViewModelʱ���ܹ���������Ӧ����ͼ���ĸ���
    // ����һ������ģ��
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        // ��ȡ�����ȫ��,�����е�"_VM"�滻Ϊ"_V"
        public IControl Build(object data)
        {
            var name = data.GetType().FullName.Replace("_VM", "_V");
            var type = Type.GetType(name);

            // ���ƥ��ɹ��ʹ�����ӦView�Ķ���Ȼ�󽫶��󷵻�
            if (type != null)
            {
                return (Control)Activator.CreateInstance(type);
            }
            else
            {
                return new TextBlock { Text = "Not Found: " + name };
            }
        }

        // ƥ����Щ�̳���ViewModelBase����,��ƥ�䵽��Щ��ʱҪִ�������Build����
        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}