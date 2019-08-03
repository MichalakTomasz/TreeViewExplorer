using ExplorerTreeView.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExplorerTreeView.Models
{
    public class RootNode
        : IRootNode
    {
        #region Constructor

        public RootNode(
            INodeTextCreator nodeTextCreator, 
            INodeImageNameCreator nodeImageNameCreator,
            IExplorerService explorerService)
        {
            NodeType = NodeType.Root;
            Text = nodeTextCreator.GetText(this);
            ImageName = nodeImageNameCreator.GetName(this);
            Items = explorerService.CreateEmptyDriveNode();
        }

        #endregion//Constructor

        #region Properties

        public NodeType NodeType { get; }
        public IBaseNode Parent { get; }
        public string Text { get; }
        public IEnumerable<IBaseNode> Items { get; set; }
        public string ImageName { get; }
        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion//Properties

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
