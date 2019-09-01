using ExplorerTreeView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private IEnumerable<string> _files;
        public IEnumerable<string> Files
        {
            get => _files;
            set
            {
                _files = value;
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
