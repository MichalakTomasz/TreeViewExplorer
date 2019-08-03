using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeView.Models
{
    public interface IBaseNode
    {
        NodeType NodeType { get; }
        string Text { get; }
        string ImageName { get; }
    }
}
