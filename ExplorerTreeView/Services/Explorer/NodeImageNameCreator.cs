using ExplorerTreeView.Models;

namespace ExplorerTreeView.Services
{
    public class NodeImageNameCreator : INodeImageNameCreator
    {
        #region Constructor

        public NodeImageNameCreator(IDriveService driveService)
        {
            DriveService = driveService;
        }

        #endregion//Constructor

        #region Methods

        public string GetName(IBaseNode explorerNode)
        {
            switch (explorerNode.NodeType)
            {
                case NodeType.Root:
                    return NodeType.Root.ToString();
                case NodeType.Drive:
                    var letter = (explorerNode as IDriveNode).Letter;
                    return DriveService.GetDriveType(letter).ToString();
                case NodeType.Folder:
                    return explorerNode.NodeType.ToString();
                case NodeType.File:
                    var path = (explorerNode as IFileNode).Path;
                    return path;
                default:
                    return "";
            }
        }

        #endregion//Methods
        
        #region Properties

        private IDriveService DriveService { get; }

        #endregion//Properties

    }
}
