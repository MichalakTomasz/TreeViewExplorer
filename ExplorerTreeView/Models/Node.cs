using System.Collections.Generic;
using System.Linq;

namespace ExplorerTreeView
{
    public class Node
    {
        internal Node(string filesFilter = null)
            => FilesFilter = filesFilter;

        public string Path { get; set; }
        public IEnumerable<string> Folders
        {
            get
            {
                if (!FileService.IsFile(Path) && DirectoriesService.Exist(Path))
                    return DirectoriesService.GetFolders(Path);
                return Enumerable.Empty<string>();
            }
        }
        public IEnumerable<string> Files
        {
            get
            {
                if (!FileService.IsFile(Path) && DirectoriesService.Exist(Path))
                {
                    if (!string.IsNullOrWhiteSpace(FilesFilter))
                    {
                        return FileService.GetFiles(Path, FilesFilter);
                    }
                    else return FileService.GetFiles(Path);
                }
                return Enumerable.Empty<string>();
            }
        }
        private string FilesFilter { get; }
    }

}
