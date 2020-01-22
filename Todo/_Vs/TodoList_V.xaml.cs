using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo._Vs
{
    public class TodoList_V : UserControl
    {
        public TodoList_V()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
