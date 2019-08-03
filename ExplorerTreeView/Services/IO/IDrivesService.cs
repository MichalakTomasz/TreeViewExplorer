using System.Collections.Generic;

namespace ExplorerTreeView.Services
{
    public interface IDrivesService
    {
        IEnumerable<string> DriveNames { get; }
        int GetDrivesCount();
    }
}
