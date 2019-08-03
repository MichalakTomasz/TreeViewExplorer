using ExplorerTreeView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
