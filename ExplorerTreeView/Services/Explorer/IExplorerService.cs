using ExplorerTreeView.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExplorerTreeView.Services
{
    public interface IExplorerService
        : IFilesVisibility
    {
        void RefreshNode(IBaseNode node);
        IEnumerable<IBaseNode> CreateEmptyDriveNode();
        IEnumerable<IBaseNode> CreateEmptyFolderNode(string path);
        IRootNode RootNode { get; }
        void ExpandPath(string path);
        string FilesFilter { get; set; }
    }
}