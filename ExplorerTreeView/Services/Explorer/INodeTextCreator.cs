using ExplorerTreeView.Models;

namespace ExplorerTreeView.Services
{
    public interface INodeTextCreator
    {
        string GetText(IBaseNode explorerNode);
    }
}