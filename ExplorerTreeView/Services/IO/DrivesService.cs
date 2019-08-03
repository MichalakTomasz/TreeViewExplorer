using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ExplorerTreeView.Services
{
    public class DrivesService :
        IDrivesService
    {
        public IEnumerable<string> DriveNames
            => DriveInfo.GetDrives()
            .Select(s => s.Name.Substring(0, 1))
            .ToList();

        public int GetDrivesCount() 
            => DriveInfo.GetDrives().Count();
    }
}
