using ExplorerTreeView.Models;

namespace ExplorerTreeView.Services
{
    public class NodeTextCreator 
        : INodeTextCreator
    {
        #region Constructor

        public NodeTextCreator(
            IUserNameService userNameService,
            IDriveService driveService,
            IDirectoriesService directoriesService,
            IFileService fileService)
        {
            UserNameService = userNameService;
            DriveService = driveService;
            DirectoriesService = directoriesService;
            FileService = fileService;
        }

        #endregion//Constructor

        #region Methods

        public string GetText(IBaseNode node)
        {
            switch (node.NodeType)
            {
                case NodeType.Root:
                    return $"Komputer: {UserNameService.LoggedUser}"; ;
                case NodeType.Drive:
                    var letter = (node as IDriveNode).Letter;
                    var label = DriveService.GetLabel(letter);
                    return label.Length == 0 ? $"({letter})":
                        $"{DriveService.GetLabel(letter)} ({letter})";
                case NodeType.Folder:
                    var folderNode = node as IFolderNode;
                    return DirectoriesService.GetFolderName(folderNode.Path);
                case NodeType.File:
                    var fileNode = node as IFileNode;
                    return FileService.GetFileName(fileNode.Path);
                default:
                    return "";
            }
        }

        #endregion//Methods

        #region Properties

        private IUserNameService UserNameService { get; }
        private IDriveService DriveService { get; }
        private IDirectoriesService DirectoriesService { get; }
        private IFileService FileService { get; }

        #endregion//Properties
    }
}
