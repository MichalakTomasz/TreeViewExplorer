using System.IO;

namespace ExplorerTreeView.Services
{
    public class DriveService 
        : IDriveService
    {
        public string GetLabel(string driveLetter)
        {
            var drive = new DriveInfo(driveLetter);
            return drive.IsReady ? drive.VolumeLabel : "";
        }
        
        public Models.DriveType GetDriveType(string driveLetter)
        {
            var drives = new DriveInfo(driveLetter);
            switch (drives.DriveType)
            {
                case DriveType.Unknown:
                    return Models.DriveType.Unknown;
                case DriveType.NoRootDirectory:
                    return Models.DriveType.Unknown;
                case DriveType.Removable:
                    return Models.DriveType.Hdd;
                case DriveType.Fixed:
                    return Models.DriveType.Hdd;
                case DriveType.Network:
                    return Models.DriveType.Unknown;
                case DriveType.CDRom:
                    return Models.DriveType.CdRom;
                case DriveType.Ram:
                    return Models.DriveType.Unknown;
                default:
                    return Models.DriveType.Unknown;
            }
        }

        public bool Exist(string path)
        {
            return Directory.Exists(path);
        }
    }
}
