using System;
using System.Collections.Generic;

namespace ExplorerTreeView
{
    public class NodeMouseClickEventArgs : EventArgs
    {
        public NodeMouseClickEventArgs(Node node)
        {
            Path = node.Path;
            Files = node.FilesNames;
            Folders = node.FoldersNames;
        }

        public string Path { get; }
        public IEnumerable<string> Files { get; }
        public IEnumerable<string> Folders { get; }
    }
}
