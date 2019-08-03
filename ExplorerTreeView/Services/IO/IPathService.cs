using ExplorerTreeView.Models;

namespace ExplorerTreeView.Services
{
    public interface IPathService
    {
        string GetPath(IPath node);
    }
}