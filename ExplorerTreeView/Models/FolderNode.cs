using ExplorerTreeView.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExplorerTreeView.Models
{
    public class FolderNode
        : IFolderNode
    {
        #region Constructor

        public FolderNode() {}

        public FolderNode(
            string text,
            IPathService pathService,
            INodeImageNameCreator nodeImageNameCreator,
            IExplorerService explorerService,
            IBaseNode parent)
        {
            Text = text;
            SubPath = Text;
            NodeType = NodeType.Folder;
            Parent = parent;
            ImageName = nodeImageNameCreator.GetName(this);
            Path = pathService.GetPath(this);
            Items = explorerService.CreateEmptyFolderNode(Path);
        }

        #endregion//Constructor

        #region Properties

        public string Text { get; }
        public NodeType NodeType { get; }
        public string Path { get; }
        public string SubPath { get; }
        public IBaseNode Parent { get; }
        public IEnumerable<IBaseNode> Items { get; set; }
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
        public string ImageName { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion//Properies
    }
}
