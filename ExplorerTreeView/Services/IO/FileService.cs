using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace ExplorerTreeView.Services
{
    public class FileService 
        : IFileService
    {
        public IEnumerable<string> GetFiles(string path, string filesFilter = null)
        {
            try
            {
                if (new DriveInfo(path).IsReady)
                {
                    if (string.IsNullOrWhiteSpace(filesFilter))
                    {
                        return new DirectoryInfo(path)
                        .EnumerateFiles()
                        .Where(d => (d.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                        .Select(f => f.Name)
                        .ToList();
                    }
                    else
                    {
                        var extensionArray = filesFilter.Split('|');
                        var files = new DirectoryInfo(path).EnumerateFiles();
                        return files
                        .Join(extensionArray, f => f.Extension, e => e, (f, e) => f)
                        .Where(d => (d.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                        .Select(f => f.Name)
                        .ToList();
                    }
                }
                return Enumerable.Empty<string>();
            }
            catch (DirectoryNotFoundException)
            {
                return Enumerable.Empty<string>();
            }
            catch (SecurityException)
            {
                return Enumerable.Empty<string>();
            }
        }

        public int GetFilesCount(string path)
        {
            try
            {
                if (new DriveInfo(path).IsReady)
                {
                    return new DirectoryInfo(path)
                    .EnumerateFiles()
                    .Where(d => (d.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
                    .Count();
                }
                else return 0;
            }
            catch (DirectoryNotFoundException)
            {
                return 0;
            }
            catch (UnauthorizedAccessException)
            {
                return 0;
            }
            catch (SecurityException)
            {
                return 0;
            }
        }

        public string GetExtension(string path)
        {
            try
            {
                return new FileInfo(path).Extension;
            }
            catch (DirectoryNotFoundException)
            {
                return string.Empty;
            }
            catch (UnauthorizedAccessException)
            {
                return string.Empty;
            }
            catch (SecurityException)
            {
                return string.Empty;
            }
        }

        public bool Exist(string path)
        {
            return File.Exists(path);
        }

        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        public bool IsFile(string path)
        {
            if (File.Exists(path)) return true;
            else return false;
        }
        
        public BitmapSource GetIconFromFilePath(string path)
        {
            var icon = System.Drawing.Icon.ExtractAssociatedIcon(path);
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
