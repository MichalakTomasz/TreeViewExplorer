using System.ComponentModel;

namespace ExplorerTreeView.Models
{
    public interface IRootNode :
        IBaseNode, 
        IChild, 
        IExpandable,
        INotifyPropertyChanged
    {}
}
