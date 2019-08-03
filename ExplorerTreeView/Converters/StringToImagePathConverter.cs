using ExplorerTreeView.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace ExplorerTreeView.Converters
{
    public class StringToImagePathConverter :
        IValueConverter
    {
        public StringToImagePathConverter(IFileService fileService)
        {
            FileService = fileService;
        }

        private IFileService FileService { get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Root":
                    return GetImageFromName(value.ToString());
                case "Hdd":
                    return GetImageFromName(value.ToString());
                case "CdRom":
                    return GetImageFromName(value.ToString());
                case "Folder":
                    return GetImageFromName(value.ToString());
                default:
                    return GetImageFromPath(value.ToString());
            }
        }

        private BitmapImage GetImageFromName(string name)
        {
            return name.Substring(0, 1) != "." ? new BitmapImage(new Uri($"Images/{name.ToString()}.ico", UriKind.Relative))
                : new BitmapImage(new Uri($"Images/File.ico", UriKind.Relative));
        }

        private BitmapSource GetImageFromPath(string path)
        {
            var extension = FileService.GetExtension(path);
            BitmapSource resourceImage = (BitmapSource)Application.Current.TryFindResource(extension);
            if (resourceImage == null)
            {
                var image = FileService.GetIconFromFilePath(path);
                Application.Current.Resources.Add(extension, image);
                return image;
            }
            else return resourceImage;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}