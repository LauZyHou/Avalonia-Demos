using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Todo._Vs
{
    public class AddItem_V : UserControl
    {
        public AddItem_V()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
