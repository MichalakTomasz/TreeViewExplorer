using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ExplorerTreeView.Models
{
    public interface IChild
    {
        IEnumerable<IBaseNode> Items { get; set; }
    }
}
