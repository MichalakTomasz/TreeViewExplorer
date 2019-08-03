namespace ExplorerTreeView.Services
{
    public interface IDriveService
    {
        string GetLabel(string driveLetter);
        Models.DriveType GetDriveType(string driveLetter);
        bool Exist(string driveLetter);
    }
}