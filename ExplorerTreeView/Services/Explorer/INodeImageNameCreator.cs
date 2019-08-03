using ExplorerTreeView.Models;

namespace ExplorerTreeView.Services
{
    public interface INodeImageNameCreator
    {
        string GetName(IBaseNode node);
    }
}