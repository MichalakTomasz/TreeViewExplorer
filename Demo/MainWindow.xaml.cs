using System.Windows;

namespace Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExplorerTreeView_NodeLeftButtonMouseClick(object sender, ExplorerTreeView.NodeMouseClickEventArgs e)
        {
            var eventArgs = e;
        }
    }
}
