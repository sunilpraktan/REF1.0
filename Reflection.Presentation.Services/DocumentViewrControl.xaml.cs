using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// Interaction logic for DocumentViewrControl.xaml
    /// </summary>
    public partial class DocumentViewrControl : UserControl
    {
        public DocumentViewrControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add a photo.  
        /// If the photo name exists, append (#) to the file name.
        /// If the file is not supported inform the user.
        /// </summary>
        private void AddDocument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DocumentListBox_Drop(object sender, DragEventArgs e)
        {
            //// Retrieve the dropped files
            //string[] fileNames = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            //// Get the files that is supported and add them to the photos for the person
            //foreach (string fileName in fileNames)
            //{

            //    // Handles photo files
            //    if (IsPhotoFileSupported(fileName))
            //    {
            //        Photo photo = new Photo(fileName);

            //        // Make the first photo added the person's avatar
            //        if (person.Photos.Count == 0)
            //        {
            //            //  photo.IsAvatar = true;  //turned this off as I found it became more a hinderance than a help, especially when dragging mulitple files, I may not want the first file to be the primary.
            //            PhotosListBox.SelectedIndex = 0;
            //        }

            //        // Associate the photo with the person.
            //        person.Photos.Add(photo);

            //        // Setter for property change notification
            //        person.Avatar = "";
            //    }
            //    else
            //    {
            //        //File not supported, warn user
            //        MessageBox.Show(Properties.Resources.NotSupportedExtension1 + Path.GetExtension(fileName) + " " + Properties.Resources.NotSupportedExtension2 + " " + Properties.Resources.UnsupportedPhotoMessage, Properties.Resources.Unsupported, MessageBoxButton.OK, MessageBoxImage.Error);
            //    }
            //}
            //person.OnPropertyChanged("HasPhoto");
            //// Mark the event as handled, so the control's native Drop handler is not called.
            //e.Handled = true;
        }

        private void DocumentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox photosListBox = sender as ListBox;
            if (photosListBox.SelectedIndex != -1)
            {
                // Get the path to the selected photo
                String path = photosListBox.SelectedItem.ToString();

                // Make sure that the file exists
                FileInfo fi = new FileInfo(path);
                if (fi.Exists)
                    SetDisplayPhoto(path);

            }
            else
            {
                // Clear the display photo
                DisplayPhoto.Source = null;//new BitmapImage();

                // Hide the photos and tags

                TagsStackPanel.Visibility = Visibility.Hidden;

                //Clear tags and caption
                TagsListBox.ItemsSource = null;
                CaptionTextBlock.Text = string.Empty;
                CaptionTextBlock.ToolTip = null; ;
            }
        }

        private void DocumentListBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SetDisplayPhoto(String path)
        {

            //This code must be used to create the bitmap
            //otherwise the program locks the image.
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.DecodePixelHeight = 280;  //max height of photo in viewer
            bitmap.UriSource = new Uri(path);
            bitmap.EndInit();

            DisplayPhoto.Source = bitmap;

            // Make sure the photo supports meta data before retrieving and displaying it
            if (HasMetaData(path))
            {
                // Extract the photo's metadata
                BitmapMetadata metadata = (BitmapMetadata)BitmapFrame.Create(new Uri(path)).Metadata;

                // Display the photo's tags
                if (metadata.Keywords != null)
                {
                    TagsStackPanel.Visibility = Visibility.Visible;
                    TagsListBox.ItemsSource = metadata.Keywords;
                }
                else
                {
                    TagsStackPanel.Visibility = Visibility.Hidden;
                    TagsListBox.ItemsSource = null;
                }

                // Display the photo's comment
                if (metadata.Title != null)
                {
                    CaptionTextBlock.Visibility = Visibility.Visible;
                    CaptionTextBlock.Text = metadata.Title;
                    CaptionTextBlock.ToolTip = metadata.Title;  //displays the full title if the title won't fit in the box
                }
                else
                {
                    CaptionTextBlock.Visibility = Visibility.Hidden;
                    CaptionTextBlock.Text = string.Empty;
                    CaptionTextBlock.ToolTip = null;
                }
            }
            else
            {
                // Clear tags and caption
                TagsStackPanel.Visibility = Visibility.Hidden;
                TagsListBox.ItemsSource = null;
                CaptionTextBlock.Text = string.Empty;
                CaptionTextBlock.ToolTip = null;
            }
        }
        private static bool HasMetaData(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName);

            if (string.Compare(extension, ".jpg", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".jpeg", true, CultureInfo.InvariantCulture) == 0)
                return true;

            return false;
        }


        #region Utility Functions

        
        /// <summary>
        /// Determines if an image file is supported based on its extension.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static bool IsPhotoFileSupported(string fileName)
        {
            string extension = System.IO.Path.GetExtension(fileName);

            if (string.Compare(extension, ".jpg", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".jpeg", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".png", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".gif", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".tiff", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".tif", true, CultureInfo.InvariantCulture) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Determines if an attachment file is supported based on its extension.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static bool IsAttachmentFileSupported(string fileName)
        {

            string extension = System.IO.Path.GetExtension(fileName);

            // Only allow certain file types
            if (string.Compare(extension, ".docx", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".xlsx", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".pptx", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".odt", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".ods", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".odp", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".doc", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".xls", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".ppt", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".txt", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".htm", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".html", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".pdf", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".xps", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".rtf", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".kml", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".kmz", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".jpg", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".jpeg", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".png", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".gif", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".tiff", true, CultureInfo.InvariantCulture) == 0 ||
                string.Compare(extension, ".tif", true, CultureInfo.InvariantCulture) == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Replaces spaces and { } in file names which break relative paths
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        internal static string ReplaceEncodedCharacters(string fileName)
        {
            fileName = fileName.Replace(" ", string.Empty);
            fileName = fileName = fileName.Replace("{", string.Empty);
            fileName = fileName.Replace("}", string.Empty);
            return fileName;
        }

        /// <summary>
        /// Converts string to date time object using DateTime.TryParse.  
        /// Also accepts just the year for dates. 1977 = 1/1/1977.
        /// </summary>
        internal static DateTime StringToDate(string dateString)
        {

            //Append first month and day if just the year was entered.
            if (dateString.Length == 4)
                dateString = "1/1/" + dateString;

            DateTime date;
            DateTime.TryParse(dateString, out date);

            return date;
        }


        /// <summary>
        /// Converts a DateTime to a short string.  If DateTime is null, returns an empty string.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static string DateToString(DateTime? date)
        {

            if (date == null)
                return string.Empty;
            else
                return date.Value.ToShortDateString();

        }

        /// <summary>
        /// Clean up all temp files when program terminates or starts.
        /// </summary>
        private static void CleanUpTempDirectory()
        {
            //string appLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            //        App.ApplicationFolderName);
            //appLocation = Path.Combine(appLocation, App.AppDataFolderName);

            //try
            //{
            //    // Creates the working directory
            //    if (Directory.Exists(appLocation))
            //        Directory.Delete(appLocation, true);
            //    Directory.CreateDirectory(appLocation);
            //}
            //catch
            //{
            //    // Could not create the working directory
            //}
        }

        /// <summary>
        /// Create the working directory the first time the program runs
        /// </summary>
        private static void CreateWorkingDirectory()
        {
            //// Full path to the document file location.
            //string location = Path.Combine(Environment.GetFolderPath(
            //    Environment.SpecialFolder.MyDocuments), ApplicationFolderName);

            //// Return right away if the data file already exist.
            //if (Directory.Exists(location))
            //    return;

            //try
            //{
            //    // Creates the working directory
            //    Directory.CreateDirectory(location);
            //}
            //catch
            //{
            //    // Could not create the working directory
            //}
        }

        /// <summary>
        /// Save the list of recent files to disk.
        /// </summary>
        public static void SaveRecentFiles()
        {
            //XmlSerializer ser = new XmlSerializer(typeof(StringCollection));
            //using (TextWriter writer = new StreamWriter(RecentFilesFilePath))
            //{
            //    ser.Serialize(writer, recentFiles);
            //}
        }

        /// <summary>
        /// Load the list of recent files from disk.
        /// </summary>
        public static void LoadRecentFiles()
        {
            //if (File.Exists(RecentFilesFilePath))
            //{
            //    // Load the Recent Files from disk
            //    XmlSerializer ser = new XmlSerializer(typeof(StringCollection));
            //    using (TextReader reader = new StreamReader(RecentFilesFilePath))
            //    {
            //        recentFiles = (StringCollection)ser.Deserialize(reader);
            //    }

            //    // Remove files from the Recent Files list that no longer exists.
            //    for (int i = 0; i < recentFiles.Count; i++)
            //    {
            //        if (!File.Exists(recentFiles[i]))
            //            recentFiles.RemoveAt(i);
            //    }

            //    // Only keep the 5 most recent files, trim the rest.
            //    while (recentFiles.Count > NumberOfRecentFiles)
            //        recentFiles.RemoveAt(NumberOfRecentFiles);

            //}
        }




        #endregion
    }
}
