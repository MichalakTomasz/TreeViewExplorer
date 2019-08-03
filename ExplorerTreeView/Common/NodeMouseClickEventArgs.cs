using ExplorerTreeView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeView.Common
{
    public class NodeMouseClickEventArgs : EventArgs
    {
        public NodeMouseClickEventArgs(Node node)
        {
            Path = node.Path;
            Files = node.Files;
            Folders = node.Folders;
        }

        public string Path { get; }
        public IEnumerable<string> Files { get; }
        public IEnumerable<string> Folders { get; }
    }
}
