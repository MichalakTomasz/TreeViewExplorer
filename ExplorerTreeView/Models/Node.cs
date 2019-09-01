using System.Collections.Generic;
using System.Linq;

namespace ExplorerTreeView
{
    public class Node
    {
        public Node(string filesFilter = null)
            => FilesFilter = filesFilter;

        public string Path { get; set; }

        public IEnumerable<string> FoldersNames
        {
            get
            {
                if (!FileService.IsFile(Path) && DirectoriesService.Exist(Path))
                    return DirectoriesService.GetFolders(Path);
                return Enumerable.Empty<string>();
            }
        }

        public IEnumerable<string> FoldersFullPath
        {
            get
            {
                if (!FileService.IsFile(Path) && DirectoriesService.Exist(Path))
                    return DirectoriesService.GetFolders(Path, fullPath:true);
                return Enumerable.Empty<string>();
            }
        }

        public IEnumerable<string> FilesNames
        {
            get
            {
                if (!FileService.IsFile(Path) && DirectoriesService.Exist(Path))
                {
                    if (!string.IsNullOrWhiteSpace(FilesFilter))
                        return FileService.GetFiles(Path, FilesFilter);
                    else
                        return FileService.GetFiles(Path);
                }
                return Enumerable.Empty<string>();
            }
        }

        public IEnumerable<string> FilesFullPath
        {
            get
            {
                if (!FileService.IsFile(Path) && DirectoriesService.Exist(Path))
                {
                    if (!string.IsNullOrWhiteSpace(FilesFilter))
                        return FileService.GetFiles(Path, FilesFilter, fullPath:true);
                    else
                        return FileService.GetFiles(Path, fullPath:true);
                }
                return Enumerable.Empty<string>();
            }
        }

        private string FilesFilter { get; }
    }

}
