using ExplorerTreeView;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Demo.ViewModel
{
    public class DemoViewModel: INotifyPropertyChanged
    {
        private ICommand _nodeClickCommand;
        public ICommand NodeClickCommand
        {
            get
            {
                if (_nodeClickCommand == null)
                {
                    _nodeClickCommand = new NodeClickCom();
                }
                return _nodeClickCommand;
            }
        }
        private Node _nodes;
        public Node Nodes
        {
            get => _nodes;
            set
            {
                _nodes = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
