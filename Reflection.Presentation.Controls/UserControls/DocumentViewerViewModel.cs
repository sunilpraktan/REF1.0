using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
//using NLog;
using Reflection.BusinessEntity;
using Reflection.Presentation.DragAndDrop;
using Reflection.Presentation.Services;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Handlers;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Reflection.Presentation.Controls
{
    public class DocumentViewerViewModel : ViewModelBase, IDragDropHandler
    {
        #region Readonly and Constant Fields

        public const string WelcomeTitlePropertyName = "WelcomeTitle";
        public const string OpenPopupBtnTextPropertyName = "OpenPopupBtnText";
        public const string StatusPropertyName = "Status";
        public const string DocViewerVisibilityPropertyName = "DocViewerVisibility";
        public const string ImageViewerVisibilityPropertyName = "ImageViewerVisibility";
        public const string PdfViewerVisibilityPropertyName = "PdfViewerVisibility";
        public const string SelectedFilePropertyName = "SelectedFile";
        public const string ListBoxBackgroundColorPropertyName = "ListBoxBackgroundColor";
        //public const string ApiBaseUrl = "http://local.reflection.com/";
        //public const string ApiBaseUrl = "http://documents.praktan.com/";
        public const string ApiBaseUrl = "http://localhost/DocUploadService/";

        #endregion Readonly and Constant Fields

        #region Private Fields

        private DocumentViewerPayload _customData;
        private string _userId;
        private string _welcomeTitle = string.Empty;
        private string _openPopupBtnText;
        private string _status;
        private Visibility _docViewerVisibility;
        private Visibility _imageViewerVisibility;
        private Visibility _pdfViewerVisibility;
        private COM_T003 _selectedFile;
        private SolidColorBrush _listBoxBackgroundColor;
        private bool _showBigThumbnails;
        private ObservableCollection<COM_T003> _FileList = new ObservableCollection<COM_T003>();
        private List<COM_T003> _FileListObj = new List<COM_T003>();
        private System.Windows.Xps.Packaging.XpsDocument xpsDoc;

        #endregion Private Fields

        #region Properties

        public string DocumentNumber
        {
            get { return CustomData.DocumentNumber; }
        }
        public string Row_ID
        {
            get { return CustomData.Row_ID; }
        }
        public DocumentViewerPayload CustomData
        {
            get { return _customData; }
            set { _customData = value; }
        }
        public string UserId
        {
            get { return _userId; }
            private set { _userId = value; }
        }
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                if (_welcomeTitle == value)
                {
                    return;
                }

                _welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }
        public string OpenPopupBtnText
        {
            get { return _openPopupBtnText; }
            set
            {
                if (_openPopupBtnText == value)
                {
                    return;
                }
                _openPopupBtnText = value;
                RaisePropertyChanged(OpenPopupBtnTextPropertyName);
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged(StatusPropertyName);
            }
        }
        public Visibility DocViewerVisibility
        {
            get { return _docViewerVisibility; }
            set
            {
                _docViewerVisibility = value;
                RaisePropertyChanged(DocViewerVisibilityPropertyName);
            }
        }
        public Visibility ImageViewerVisibility
        {
            get { return _imageViewerVisibility; }
            set
            {
                _imageViewerVisibility = value;
                RaisePropertyChanged(ImageViewerVisibilityPropertyName);
            }
        }
        public Visibility PdfViewerVisibility
        {
            get { return _pdfViewerVisibility; }
            set
            {
                _pdfViewerVisibility = value;
                RaisePropertyChanged(PdfViewerVisibilityPropertyName);
            }
        }
        public COM_T003 SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                _selectedFile = value;
                RaisePropertyChanged(SelectedFilePropertyName);
            }
        }
        public SolidColorBrush ListBoxBackgroundColor
        {
            get { return _listBoxBackgroundColor; }
            set
            {
                _listBoxBackgroundColor = value;
                RaisePropertyChanged(ListBoxBackgroundColorPropertyName);
            }
        }
        public bool ShowBigThumbnails
        {
            get { return _showBigThumbnails; }
            set
            {
                _showBigThumbnails = value;
                RaisePropertyChanged("ShowBigThumbnails");
            }
        }
        public ObservableCollection<COM_T003> FileList
        {
            get
            {
                return _FileList;
            }
            set
            {
                _FileList = value;
            }
        }
        private ProgressBar ProgressIndicator { get; set; }

        #endregion Properties

        #region Commands

        public ICommand OpenPopupCommand { get; private set; }

        public RelayCommand<DocumentViewer> SelectedItemChangedCommand { get; private set; }

        public RelayCommand<DockPanel> ExpandCommand { get; private set; }
        public RelayCommand<Expander> CollapseCommand { get; private set; }
        public RelayCommand<DockPanel> CollapseCompleteCommand { get; private set; }

        public RelayCommand ChangeListBoxStyleCommand { get; private set; }

        public RelayCommand<ProgressBar> UploadCommand { get; private set; }

        public RelayCommand DeleteCommand { get; private set; }

        public ICommand OpenFileDialogCommand { get; private set; }

        #endregion Commands

        #region Constructor

        public DocumentViewerViewModel(DocumentViewerPayload customNotification)
        {
            CustomData = customNotification;

            if (!IsInDesignMode)
            {
                GetFileData();
                UserId = AppSessionState.UserID;
                _FileList.CollectionChanged += _files_CollectionChanged;
                WelcomeTitle = "Document Uploader";
                OpenPopupBtnText = "Open Doc Uploader";
                OpenPopupCommand = new RelayCommand<object>(OpenPopup);
                UploadCommand = new RelayCommand<ProgressBar>(Upload, CanUpload);
                OpenFileDialogCommand = new RelayCommand(OpenFileDialog);
                SelectedItemChangedCommand = new RelayCommand<DocumentViewer>(SelectedItemChanged);
                ExpandCommand = new RelayCommand<DockPanel>(Expanded);
                CollapseCommand = new RelayCommand<Expander>(Collapsed);
                CollapseCompleteCommand = new RelayCommand<DockPanel>(CollapseCompleted);
                ListBoxBackgroundColor = new SolidColorBrush(Color.FromRgb(155, 155, 155));
                ChangeListBoxStyleCommand = new RelayCommand(ChangeListBoxStyle);
                DeleteCommand = new RelayCommand(Delete, CanDelete);

                DocViewerVisibility = Visibility.Collapsed;
                ImageViewerVisibility = Visibility.Collapsed;
                PdfViewerVisibility = Visibility.Collapsed;
            }
        }

        #endregion Constructor

        #region Drag Drop

        public bool CanDrop(IDataObject dropObject, IEnumerable dropTarget)
        {
            try
            {
                ListBoxBackgroundColor = new SolidColorBrush(Color.FromRgb(226, 226, 226));
                if (dropObject.GetFormats().Length > 5)
                {
                    var fileInfo = FileObjectInfo(((string[])(dropObject.GetData("FileDrop")))[0]);

                    if (ValidateFile(fileInfo))
                        return true;
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            { return false; }
        }

        public void OnDrop(IDataObject dropObject, IEnumerable dropTarget)
        {
            try
            {
                //FileList.Add(new COM_T003(FileList.Count + 1, ((string[])(dropObject.GetData("FileDrop")))[0]));
                COM_T003 obj = new COM_T003();
                obj.Index = FileList.Count + 1;
                obj.FilePath = ((string[])(dropObject.GetData("FileDrop")))[0];
                FileList.Add(obj);
                SavePreviewInCache(((string[])(dropObject.GetData("FileDrop")))[0]);
            }
            catch (Exception ex)
            { }
        }

        #endregion Drag Drop

        #region Private Methods

        private bool CanDelete()
        {
            return SelectedFile == null ? false : true;
        }
        private async void Delete()
        {
            try
            {
                var filePath = SelectedFile.NewFileName;
                //var tempFilepath = filePath + (IsSpecialFile(SelectedFile.FilePath) ? ".xps" : Path.GetExtension(SelectedFile.FilePath));

                if (SelectedFile.IsUploaded)
                {
                    if (SelectedFile.id != 0)
                    {
                        string response = repository2.DeleteFiles(SelectedFile.id.ToString(), DocumentNumber, "", SelectedFile.FilePath, CustomData.client, CustomData.comp_code);
                    }
                    #region old code

                    //using (var client = new HttpClient())
                    //{
                    //    client.BaseAddress = new Uri(ApiBaseUrl);
                    //    client.DefaultRequestHeaders.Accept.Clear();

                    //    using (HttpResponseMessage response = await client.DeleteAsync("api/uploading?filePath=" + DocumentNumber + "/" + filePath))
                    //    {
                    //        if (response.IsSuccessStatusCode)
                    //        {
                    //            DeleteTempFile(tempFilepath);
                    //        }
                    //        else
                    //        {
                    //            ShowMessage("File not found", "File not found on server.");
                    //        }
                    //    }
                    //}
                    #endregion
                }
                FileList.Remove(FileList.Where(f => f.Index == SelectedFile.Index).First());
                filePath = System.Environment.CurrentDirectory + "\\temp\\" + CustomData.client + "\\" + CustomData.comp_code + "\\" + SelectedFile.FilePath;
                //if (File.Exists(filePath))
                //{
                //    File.Delete(filePath);
                //}
            }
            catch (Exception ex)
            { }
        }
        //private bool DeleteTempFile(string filePath)
        //{
        //    try
        //    {
        //        var deleted = false;

        //        //filePath = System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + DocumentNumber + "\\" + filePath);
        //        //filePath = System.Environment.CurrentDirectory + "\\temp\\" + DocumentNumber + "\\" + filePath;
        //        if (deleted == false)
        //        {
        //            FileList.Remove(FileList.Where(f => f.Index == SelectedFile.Index).First());
        //            if (File.Exists(filePath))
        //            {
        //                File.Delete(filePath);
        //            }
        //            deleted = true;
        //        }

        //        SelectedFile = null;
        //        return deleted;
        //    }
        //    catch (Exception ex)
        //    { return false; }
        //}
        private void ChangeListBoxStyle()
        {
            ShowBigThumbnails = !ShowBigThumbnails;
        }
        private void CollapseCompleted(DockPanel pnlRighttDock)
        {
            Grid.SetColumn(pnlRighttDock, 0);
            Grid.SetColumnSpan(pnlRighttDock, 2);
            Thickness margin = pnlRighttDock.Margin;
            margin.Left = 50;
            pnlRighttDock.Margin = margin;
        }
        private void Collapsed(Expander expander)
        {
            var r = expander.Template.FindName("ExpandSite", expander) as UIElement;
            r.Visibility = System.Windows.Visibility.Visible;

            var sb1 = (Storyboard)expander.FindResource("sbCollapse");
            sb1.Begin();
        }
        private void Expanded(DockPanel pnlRighttDock)
        {
            if (pnlRighttDock != null)
            {
                Grid.SetColumn(pnlRighttDock, 1);
                Grid.SetColumnSpan(pnlRighttDock, 1);
                Thickness margin = pnlRighttDock.Margin;
                margin.Left = 5;
                pnlRighttDock.Margin = margin;
            }
        }
        private void SelectedItemChanged(DocumentViewer docViewer)
        {
            try
            {
                if (SelectedFile == null)
                {
                    DocViewerVisibility = Visibility.Collapsed;
                    ImageViewerVisibility = Visibility.Collapsed;
                    PdfViewerVisibility = Visibility.Collapsed;
                    return;
                }
                switch (FileObjectInfo(SelectedFile.FilePath).Extension.ToLower())
                {
                    case ".doc":
                    case ".docx":
                    case ".xls":
                    case ".xlsx":
                    case ".ppt":
                    case ".pptx":
                        DocViewerVisibility = Visibility.Visible;
                        ImageViewerVisibility = Visibility.Collapsed;
                        PdfViewerVisibility = Visibility.Collapsed;
                        OpenOfficeFilePreview(docViewer);
                        break;

                    case ".pdf":
                        DocViewerVisibility = Visibility.Collapsed;
                        ImageViewerVisibility = Visibility.Collapsed;
                        PdfViewerVisibility = Visibility.Visible;
                        break;

                    default:
                        DocViewerVisibility = Visibility.Collapsed;
                        ImageViewerVisibility = Visibility.Visible;
                        PdfViewerVisibility = Visibility.Collapsed;
                        break;
                }
                DeleteCommand.RaiseCanExecuteChanged();
            }
            catch (Exception ex)
            { }
        }
        private void _files_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UploadCommand.RaiseCanExecuteChanged();
            UpdateStatus();
        }
        private bool CanUpload(ProgressBar arg)
        {
            return FileList.Any(f => !f.IsUploaded) && !string.IsNullOrEmpty(DocumentNumber);
        }
        private void OpenPopup(object pnl)
        {
            var resourceDictionary = new ResourceDictionary()
            {
                Source = new Uri("../Skins/Theme.xaml", UriKind.Relative)
            };
            Storyboard sb = new Storyboard();
            if (OpenPopupBtnText == "Open Doc Uploader")
            {
                sb = resourceDictionary["sbShowRightMenu"] as Storyboard;
                OpenPopupBtnText = "Close Doc Uploader";
            }
            else
            {
                OpenPopupBtnText = "Open Doc Uploader";

                sb = resourceDictionary["sbHideRightMenu"] as Storyboard;
            }
            sb.Begin((Border)pnl);
        }
        private void UploadOrg(object progressIndicator)
        {
            if (string.IsNullOrEmpty(DocumentNumber))
            {
                return;
            }
            SelectedFile = null;
            ProgressIndicator = (ProgressBar)progressIndicator;
            ProgressMessageHandler progress = new ProgressMessageHandler();
            progress.HttpSendProgress += new EventHandler<HttpProgressEventArgs>(HttpSendProgress);
            Status = "Upload Started";

            HttpRequestMessage message = new HttpRequestMessage();
            MultipartFormDataContent content = new MultipartFormDataContent();

            try
            {
                var filesToBeUploaded = FileList.Where(f => !f.IsUploaded).Count();
                foreach (var file in FileList.Where(f => !f.IsUploaded))
                {
                    FileStream filestream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 8, true);
                    string fileName = System.IO.Path.GetFileName(file.FilePath);
                    content.Add(new StreamContent(filestream), file.Index.ToString(), file.NewFileName ?? fileName);
                }

                message.Method = HttpMethod.Post;
                message.Content = content;
                //message.RequestUri = new Uri("http://vitaljob.in/DocUploadService/api/uploading/");
                message.RequestUri = new Uri(ApiBaseUrl + "api/uploading/");
                message.Headers.Add("OrderId", DocumentNumber.ToString());

                var client = HttpClientFactory.Create(progress);
                client.DefaultRequestHeaders.Add("X-UserId", UserId.ToString());

                client.SendAsync(message).ContinueWith(task =>
                {
                    if (task.Result.IsSuccessStatusCode)
                    {
                        Status = String.Format("Uploading {0} files", FileList.Count());
                        var response = task.Result.Content.ReadAsStringAsync();
                        dynamic json = JsonConvert.DeserializeObject<List<FileObject>>(response.Result);

                        foreach (var item in json)
                        {
                            var listitem = _FileList.FirstOrDefault(i => i.Index == item.Index && !i.IsUploaded);

                            Application.Current.Dispatcher.Invoke(
                                DispatcherPriority.Normal, (Action)delegate ()
                                {
                                    FileList.Remove(listitem);
                                });

                            Application.Current.Dispatcher.Invoke(
                                DispatcherPriority.Normal, (Action)delegate ()
                                {
                                    FileList.Add(new COM_T003() { Index = item.Index, FilePath = item.FilePath, IsUploaded = true });
                                });
                        }
                        Status = String.Format("{0} files uploaded succesfuly!", filesToBeUploaded);
                    }
                    else
                    {
                        Status = "Sorry there has been an error";
                    }
                });
            }
            catch (Exception)
            {
                //Handle exceptions - file not found, access denied, no internet connection, threading issues etc etc
            }
        }
        private void OpenFileDialogCallback(string selectedFile)
        {
            //var fileInfo = FileObjectInfo(selectedFile);

            //if (ValidateFile(fileInfo))
            //{
            //    FileList.Add(new COM_T003(FileList.Count, fileInfo.FullName));
            //    SavePreviewInCache(fileInfo.FullName);
            //}
        }
        private void OpenFileDialog()
        {
            var message = new NotificationMessageAction<string>("Load New Files", OpenFileDialogCallback);
            Messenger.Default.Send(message);
        }
        private void UpdateStatus()
        {
            Status = string.Format("Total {0} file(s).", FileList.Where(f => !f.IsUploaded).Count());
        }
        private bool IsValidFileFormat(string filePath)
        {
            switch (FileObjectInfo(filePath).Extension.ToLower())
            {
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                case ".pdf":
                case ".zip":
                case ".rar":
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    return true;

                default: return false;
            }
        }
        private void HttpSendProgress(object sender, HttpProgressEventArgs e)
        {
            try
            {
                HttpRequestMessage request = sender as HttpRequestMessage;
                ProgressIndicator.Dispatcher.BeginInvoke(
                        DispatcherPriority.Normal, new DispatcherOperationCallback(delegate
                        {
                            ProgressIndicator.Value = e.ProgressPercentage;
                            return null;
                        }), null);
            }
            catch (Exception ex)
            { }
        }
        private void OpenOfficeFilePreview(DocumentViewer docViewer)
        {
            try
            {
                if (SelectedFile == null)
                    return;
                //Directory.EnumerateFiles(System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\"), "*.xps").ToList().ForEach(x => File.Delete(x));
                var fileInfo = FileObjectInfo(SelectedFile.NewFileName ?? SelectedFile.FilePath);
                var xpsFilePath = "";

                string filename = fileInfo.Name;
                //xpsFilePath = System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + DocumentNumber + "\\") + fileInfo.Name + ".xps";
                if (string.IsNullOrWhiteSpace(Row_ID) == false)
                {
                    xpsFilePath = System.Environment.CurrentDirectory + "\\temp\\" + CustomData.client + "\\" + CustomData.comp_code + "\\" + DocumentNumber + "\\" + Row_ID + "\\" + fileInfo.Name + ".xps";
                }
                else
                {
                    xpsFilePath = System.Environment.CurrentDirectory + "\\temp\\" + CustomData.client + "\\" + CustomData.comp_code + "\\" + DocumentNumber + "\\" + fileInfo.Name + ".xps";
                }
                if (File.Exists(xpsFilePath))
                {
                    xpsDoc = new System.Windows.Xps.Packaging.XpsDocument(xpsFilePath, FileAccess.Read, System.IO.Packaging.CompressionOption.SuperFast);
                    docViewer.Document = xpsDoc.GetFixedDocumentSequence();
                    xpsDoc.Close();
                }
            }
            catch (Exception ex)
            { }
        }
        private void SavePreviewInCache(string filePath)
        {
            try
            {
                //Application.Current.Dispatcher.InvokeAsync(() =>
                ////DispatcherPriority.Normal, (Action)delegate()
                //{
                var fileInfo = FileObjectInfo(filePath);
                var xpsFilePath = "";
                string filename = fileInfo.Name;

                //xpsFilePath = GetUniqueFilePath(System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + DocumentNumber + "\\")
                //    + fileInfo.Name);
                if (string.IsNullOrWhiteSpace(Row_ID) == false)
                {
                    xpsFilePath = GetUniqueFilePath(System.Environment.CurrentDirectory + "\\temp\\" + CustomData.client + "\\" + CustomData.comp_code + "\\" + DocumentNumber + "\\" + Row_ID + "\\" + fileInfo.Name);
                }
                else
                {
                    xpsFilePath = GetUniqueFilePath(System.Environment.CurrentDirectory + "\\temp\\" + CustomData.client + "\\" + CustomData.comp_code + "\\" + DocumentNumber + "\\" + fileInfo.Name);
                }


                if (!Directory.Exists(Path.GetDirectoryName(xpsFilePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(xpsFilePath));
                }
                if (xpsFilePath.EndsWith(".xps"))
                {
                    var convertResults = OfficeToXps.ConvertToXps(filePath, ref xpsFilePath);
                }
                else
                {
                    File.Copy(filePath, xpsFilePath);
                }
                foreach (var fileObject in FileList)
                {
                    if (fileObject.Index == FileList.Count)
                    {
                        fileObject.NewFileName = xpsFilePath.EndsWith(".xps") ? Path.GetFileNameWithoutExtension(xpsFilePath) : Path.GetFileName(xpsFilePath);
                    }
                }
                //var fileToUpdate = this.FileList.Where(f => f.Index == FileList.Count - 1).First();
                //fileToUpdate.NewFileName = xpsFilePath.EndsWith(".xps") ? Path.GetFileNameWithoutExtension(xpsFilePath) : Path.GetFileName(xpsFilePath);
                //});
            }
            catch (Exception ex)
            {
                //Logger.Debug("Document Viewer cloased ({0})", this.WindowState);
            }
        }
        private static string GetUniqueFilePath(string filepath)
        {
            try
            {
                bool isSpecial = IsSpecialFile(filepath);

                if (File.Exists(isSpecial ? filepath + ".xps" : filepath))
                {
                    string folder = Path.GetDirectoryName(filepath);
                    string filename = Path.GetFileNameWithoutExtension(isSpecial ? filepath.Replace(".xps", "") : filepath);
                    string extension = Path.GetExtension(filepath.Replace(".xps", ""));
                    int number = 1;

                    Match regex = Regex.Match(filepath, @"(.+) \((\d+)\)\.\w+");

                    if (regex.Success)
                    {
                        filename = regex.Groups[1].Value;
                        number = int.Parse(regex.Groups[2].Value);
                    }
                    do
                    {
                        number++;
                        filepath = Path.Combine(folder, string.Format("{0}_({1}){2}", filename, number, extension));
                    }
                    while (File.Exists(isSpecial ? filepath + ".xps" : filepath));
                }

                return isSpecial ? filepath + ".xps" : filepath;
            }
            catch (Exception ex)
            { return null; }
        }
        private static FileInfo FileObjectInfo(string path)
        {
            return new FileInfo(path);
        }
        private async void GetFileData()
        {
            try
            {
                /*Task<List<FileObject>> task = Task.Run(() =>
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ApiBaseUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.GetAsync("api/uploading/" + DocumentNumber).Result;
                        var taskResponse = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode)
                        {
                            client.Dispose();
                            return JsonConvert.DeserializeObject<List<FileObject>>(taskResponse);
                        }
                        client.Dispose();
                        return null;
                    }
                });*/

                List<COM_T003> files = CustomData.DocumentList
                            .OrderBy(x => x.id)
                            .GroupBy(x => x.file_index)
                            .Select(group => new { Group = group, Count = group.Count() })
                            .SelectMany(groupWithCount => groupWithCount.Group.Select(b => b)
                            .Zip(Enumerable.Range(1, groupWithCount.Count), (j, i) => new COM_T003 { Index = i, FilePath = j.url, IsUploaded = true, NewFileName = j.file_name, id = j.id, doc_no = j.doc_no, client = j.client, comp_code = j.comp_code })).ToList();

                //List<FileObject> files = new List<FileObject>();
                /*foreach (var document in CustomData.DocumentList)
                {
                    files.Add(new FileObject() {
                        FilePath = document.url,
                        Index = 
                    });
                }*/
                if (files == null)
                    return;
                //if (files.Any())
                //{
                //    //Files = new ObservableCollection<FileObject>(files);
                //    files.ForEach(f =>
                //    {
                //        FileList.Add(f);
                //        var isSpecialFile = IsSpecialFile(f.FilePath);
                //        var tempFilePath = isSpecialFile ? System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + f.FilePath) + ".xps"
                //            : System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + f.FilePath);

                //        if (!Directory.Exists(Path.GetDirectoryName(tempFilePath)))
                //        {
                //            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
                //        }

                //        if (!File.Exists(tempFilePath))
                //        {
                //            DownloadFile(f.file_name, tempFilePath);
                //        }
                //        //if (!Directory.Exists(tempFilePath))
                //        //{
                //        //    if (isSpecialFile)
                //        //    {
                //        //        var tempPath = tempFilePath.Replace(".xps", "");
                //        //        var convertResults = OfficeToXps.ConvertToXps(tempPath, ref tempFilePath);
                //        //        File.Delete(tempFilePath);
                //        //    }
                //        //}
                //    });
                //}

                if (files.Any())
                {
                    //Files = new ObservableCollection<FileObject>(files);
                    //files.ForEach(f =>
                    foreach (var f in files)
                    {
                        FileList.Add(f);
                        var isSpecialFile = IsSpecialFile(f.FilePath);
                        //var tempFilePath = isSpecialFile ? System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + f.FilePath) + ".xps"
                        //    : System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + f.FilePath);
                        var tempFilePath = isSpecialFile ? System.Environment.CurrentDirectory + "\\temp\\" + AppSessionState.client + "\\" + f.comp_code + "\\" + f.FilePath + ".xps"
                           : System.Environment.CurrentDirectory + "\\temp\\" + AppSessionState.client + "\\" + f.comp_code + "\\" + f.FilePath;

                        if (!Directory.Exists(Path.GetDirectoryName(tempFilePath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
                        }

                        if (!File.Exists(tempFilePath))
                        {
                            DownloadFile(f.NewFileName, tempFilePath);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private async static void DownloadFileOrg(string fileName, string filePath)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ApiBaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //HttpResponseMessage response = client.GetAsync("api/uploading?filePath=" + fileName).Result;
                    using (HttpResponseMessage response = await client.GetAsync("api/uploading?filePath=" + fileName, HttpCompletionOption.ResponseHeadersRead))
                    {
                        var isSpecialFile = IsSpecialFile(fileName);

                        if (isSpecialFile)
                        {
                            filePath = filePath.Replace(".xps", "");
                        }
                        if (response.IsSuccessStatusCode)
                        {
                            client.Dispose();
                            try
                            {
                                using (FileStream DestinationStream = new FileStream(filePath, FileMode.CreateNew))
                                {
                                    await response.Content.CopyToAsync(DestinationStream).ContinueWith(
                                   (copyTask) =>
                                   {
                                       DestinationStream.Close();
                                       if (isSpecialFile)
                                       {
                                           if (!Directory.Exists(filePath))
                                           {
                                               if (isSpecialFile)
                                               {
                                                   var refFilePath = filePath + ".xps";
                                                   var convertResults = OfficeToXps.ConvertToXps(filePath, ref refFilePath);
                                                   File.Delete(filePath);
                                               }
                                           }
                                       }
                                   });//.ContinueWith((t1) => { MessageBox.Show("Operation Completed!", "Success"); });
                                }
                            }
                            catch
                            {
                            }
                        }
                        client.Dispose();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void RemoveUnUsedFiles(string filePath)
        {
            try
            {
                //var fileList = FileList.ToList();
                var usedFiles = FileList.Where(f => f.IsUploaded).Select(f => (IsSpecialFile(f.FilePath) ? filePath + "\\" + Path.GetFileName(f.FilePath + ".xps")
                    : filePath + "\\" + Path.GetFileName(f.FilePath))).ToList();
                var unUsedFileNames = FileList.Where(f => !f.IsUploaded).Select(f => f.NewFileName).ToList();
                var filesInDirectory = Directory.GetFiles(filePath, string.Join(",", unUsedFileNames)).Select(path => Path.GetFileName(path)).ToList();
                var filesInDirectoryNew = Directory.GetFiles(filePath).Except(usedFiles).ToList();//.Select(path => Path.GetFileName(path)).ToList();
                if (filesInDirectoryNew.Any())
                {
                    filesInDirectoryNew.ForEach(f =>
                    {
                        File.Delete(f);
                    });
                }
            }
            catch (Exception ex)
            { }

        }
        private static bool IsSpecialFile(string filePath)
        {
            bool isSpecial = false;
            switch (FileObjectInfo(filePath).Extension.ToLower())
            {
                case ".doc":
                case ".docx":
                case ".xls":
                case ".xlsx":
                case ".ppt":
                case ".pptx":
                    //case ".pdf":
                    isSpecial = true;
                    //filepath = filepath + ".xps";
                    break;
            }
            return isSpecial;
        }
        private bool ValidateFile(FileInfo fileInfo)
        {
            List<string> fileExtentions = new List<string>() { ".bmp", ".jpg", ".jpeg", ".png", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".pdf", ".zip", ".rar" };
            NotificationMessage msg = null;
            if (!fileExtentions.Contains(fileInfo.Extension.ToLower()))
            {
                msg = new NotificationMessage("File Type Not Supported", "Supported file types are:" +
                    Environment.NewLine + "Images (bmp, jpg, jpeg, png)," +
                    Environment.NewLine + "Word (doc, docx)," +
                    Environment.NewLine + "Excel (xls, xlsx)," +
                    Environment.NewLine + "PowerPoint (ppt, pptx), " +
                    Environment.NewLine + "PDF, ZIP, RAR.");
                MessengerInstance.Send(msg);
                return false;
            }
            if (fileInfo.Length > Convert.ToInt32(ConfigurationManager.AppSettings["MaxContentLength"]))
            {
                msg = new NotificationMessage("File Size Violation", string.Format("File size too large. Supported max file size is {0} MB.",
                    ((Convert.ToInt32(ConfigurationManager.AppSettings["MaxContentLength"]) / 1024) / 1024).ToString()));
                MessengerInstance.Send(msg);
                return false;
            }
            return true;
        }
        private void ShowMessage(string title, string messageContent)
        {
            try
            {
                NotificationMessage msg = new NotificationMessage(title, messageContent);
                MessengerInstance.Send(msg);
            }
            catch (Exception ex)
            { }
        }
        #endregion Private Methods

        #region Public Methods
        public override void Cleanup()
        {
            try
            {
                //var filePath = System.Environment.CurrentDirectory.Replace("\\bin\\Debug", "\\temp\\" + DocumentNumber);
                var filePath = System.Environment.CurrentDirectory + "\\temp\\" + CustomData.client + "\\" + CustomData.comp_code + "\\" + DocumentNumber;
                RemoveUnUsedFiles(filePath);
                //base.Cleanup();
            }
            catch (Exception ex)
            { }
        }
        #endregion



        /////////////////////////////////////// By Sunil
        WebServiceRepository<COM_T003> repository = new WebServiceRepository<COM_T003>();
        WebServiceRepository<List<COM_T003>> repository2 = new WebServiceRepository<List<COM_T003>>();

        private void Upload(object progressIndicator)
        {
            if (string.IsNullOrEmpty(DocumentNumber))
            {
                return;
            }
            SelectedFile = null;
            ProgressIndicator = (ProgressBar)progressIndicator;
            ProgressMessageHandler progress = new ProgressMessageHandler();
            progress.HttpSendProgress += new EventHandler<HttpProgressEventArgs>(HttpSendProgress);
            Status = "Upload Started";

            HttpRequestMessage message = new HttpRequestMessage();
            MultipartFormDataContent content = new MultipartFormDataContent();

            try
            {
                var filesToBeUploaded = FileList.Where(f => !f.IsUploaded).Count();
                foreach (var file in FileList.Where(f => !f.IsUploaded))
                {
                    List<COM_T003> FileListObject = new List<COM_T003>();
                    FileStream filestream = new FileStream(file.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 8, true);
                    string fileName = System.IO.Path.GetFileName(file.FilePath);
                    byte[] RequestData = ReflectionComprassion.CompressByteData(File.ReadAllBytes(file.FilePath));
                    List<COM_T003> FileListObject2 = null;
                    if (string.IsNullOrWhiteSpace(Row_ID) == false)
                    {
                        FileListObject2 = repository2.UploadFiles<List<COM_T003>>(_FileListObj, RequestData, fileName, DocumentNumber + ',' + Row_ID, file.FilePath, CustomData.client, CustomData.comp_code);
                    }
                    else
                    {
                        FileListObject2 = repository2.UploadFiles<List<COM_T003>>(_FileListObj, RequestData, fileName, DocumentNumber, file.FilePath, CustomData.client, CustomData.comp_code);
                    }


                }



                var client = HttpClientFactory.Create(progress);
                client.DefaultRequestHeaders.Add("X-UserId", UserId.ToString());

                client.SendAsync(message).ContinueWith(task =>
                {
                    if (task.Result.IsSuccessStatusCode)
                    {
                        Status = String.Format("Uploading {0} files", FileList.Count());
                        var response = task.Result.Content.ReadAsStringAsync();
                        dynamic json = JsonConvert.DeserializeObject<List<FileObject>>(response.Result);

                        foreach (var item in json)
                        {
                            var listitem = _FileList.FirstOrDefault(i => i.Index == item.Index && !i.IsUploaded);

                            Application.Current.Dispatcher.Invoke(
                                DispatcherPriority.Normal, (Action)delegate ()
                                {
                                    FileList.Remove(listitem);
                                });

                            Application.Current.Dispatcher.Invoke(
                                DispatcherPriority.Normal, (Action)delegate ()
                                {
                                    FileList.Add(new COM_T003() { Index = item.Index, FilePath = item.FilePath, IsUploaded = true });
                                });
                        }
                        Status = String.Format("{0} files uploaded succesfuly!", filesToBeUploaded);
                    }
                    else
                    {
                        Status = "Sorry there has been an error";
                    }
                });
            }
            catch (Exception ex)
            {
                //Handle exceptions - file not found, access denied, no internet connection, threading issues etc etc             
                MessageBox.Show(ex.Message);
            }
        }

        private void DownloadFile(string fileName, string filePath)
        {
            //using (var client = new HttpClient())
            //{
            try
            {
                byte[] byteReturnValue;
                if (string.IsNullOrWhiteSpace(Row_ID) == false)
                {
                    byteReturnValue = repository2.DownloadFile(fileName, DocumentNumber + "\\" + Row_ID, filePath, CustomData.client, CustomData.comp_code);
                }
                else
                {
                    byteReturnValue = repository2.DownloadFile(fileName, DocumentNumber, filePath, CustomData.client, CustomData.comp_code);
                }
                //byte[] byteReturnValue = repository2.DownloadFile(fileName, DocumentNumber, filePath);
                MemoryStream stream = new MemoryStream(byteReturnValue);
                var fileStream = new FileStream(filePath.Replace(".xps", ""), FileMode.CreateNew, FileAccess.ReadWrite);
                stream.CopyTo(fileStream);
                fileStream.Dispose();

                var isSpecialFile = IsSpecialFile(fileName);

                if (isSpecialFile)
                {
                    filePath = filePath.Replace(".xps", "");
                }
                try
                {
                    //using (FileStream DestinationStream = new FileStream(filePath, FileMode.CreateNew))
                    //{
                    //    DestinationStream.Close();
                    if (isSpecialFile)
                    {
                        if (!Directory.Exists(filePath))
                        {
                            if (isSpecialFile)
                            {
                                var refFilePath = filePath + ".xps";
                                var convertResults = OfficeToXps.ConvertToXps(filePath, ref refFilePath);
                                File.Delete(filePath);
                            }
                        }
                    }
                    //}
                }
                catch
                {
                }
            }
            catch
            {
            }
            //}
        }

    }
}
