using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExplorerTreeView.Services;

namespace ExplorerTreeView.Models
{
    public class DriveNode
        : IDriveNode
    {
        #region Constructor

        public DriveNode() { }

        public DriveNode(
            string letter,
            IDriveService driveService,
            IPathService pathService,
            INodeTextCreator nodeTextCreator,
            INodeImageNameCreator nodeImageNameCreator,
            IExplorerService explorerService,
            IBaseNode parent)
        {
            NodeType = NodeType.Drive;
            Letter = letter;
            Parent = parent;
            DriveType = driveService.GetDriveType(Letter);
            Path = pathService.GetPath(this);
            SubPath = letter;
            ImageName = nodeImageNameCreator.GetName(this);
            Text = nodeTextCreator.GetText(this);
            Items = explorerService.CreateEmptyFolderNode(Path);
        }

        #endregion

        #region Properties

        public NodeType NodeType { get; }
        public DriveType DriveType { get; }
        public string Path { get; }
        public string SubPath { get; }
        public string Text { get; }
        public string Letter { get; }
        public IBaseNode Parent { get; }
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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion//Properties
    }
}
  