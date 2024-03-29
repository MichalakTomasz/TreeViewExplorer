﻿using System.Collections.Generic;

namespace ExplorerTreeView.Services
{
    public interface IDirectoriesService
    {
        IEnumerable<string> GetFolders(string path);
        bool Exist(string path);
        string GetFolderName(string path);
        int GetFoldersCount(string path);
    }
}
