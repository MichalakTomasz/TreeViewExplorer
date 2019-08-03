using ExplorerTreeView.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeView.Models
{
    public class Node
    {
        public Node(IDirectoriesService directoriesService, IFileService fileService, string filesFilter = null)
        {
            DirectoriesService = directoriesService;
            FileService = fileService;
            Path = string.Empty;
            FilesFilter = filesFilter;
        }

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

        private IFileService FileService { get; }
        private IDirectoriesService DirectoriesService { get; }
        private string FilesFilter { get; }
    }

}
