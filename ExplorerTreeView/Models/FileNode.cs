using ExplorerTreeView.Services;
using System.Collections.Generic;

namespace ExplorerTreeView.Models
{
    public class FileNode
        : IFileNode
    {
        #region Constructor

        public FileNode() { }

        public FileNode(
            string text,
            IPathService pathService,
            INodeImageNameCreator nodeImageNameCreator,
            IBaseNode parent)
        {
            NodeType = NodeType.File;
            Text = text;
            SubPath = Text;
            Parent = parent;
            Path = pathService.GetPath(this);
            ImageName = nodeImageNameCreator.GetName(this);
        }

        #endregion//Constructor

        #region Properties

        public NodeType NodeType { get; }
        public string Path { get; }
        public string SubPath { get; }
        public string Text { get; }
        public IBaseNode Parent { get; }
        public string ImageName { get; }


        public bool IsExpanded { get; set; } = false;
        public IEnumerable<IBaseNode> Items { get; set; }
        #endregion//Properties
    }
}
