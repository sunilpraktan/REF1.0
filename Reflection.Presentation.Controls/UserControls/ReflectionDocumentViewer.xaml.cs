using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using Reflection.BusinessEntity;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for DocumentViewer.xaml
    /// </summary>
    public partial class ReflectionDocumentViewer : UserControl
    {
        public DocumentViewerPayload CustomNot
        {
            get { return (DocumentViewerPayload)GetValue(DocumentIdProperty); }
            set { SetValue(DocumentIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomNotification.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DocumentIdProperty =
            DependencyProperty.Register("CustomNotification", typeof(DocumentViewerPayload), typeof(ReflectionDocumentViewer));

        static bool isRegistered = false;
        public ReflectionDocumentViewer(DocumentViewerPayload testProp)
        {
            try
            {
                InitializeComponent();
                this.DataContext = new DocumentViewerViewModel(testProp);
                var vm = (DocumentViewerViewModel)DataContext;

                Loaded += (sender, args) =>
                {
                    Messenger.Default.Register<NotificationMessage>(this, FileValidationMessage);
                    if (!isRegistered)
                    {
                        Messenger.Default.Register<NotificationMessageAction<string>>(this, (message) => NotificationMessageActionHandler(message));
                        isRegistered = true;
                    }
                    //Messenger.Default.Register<NotificationMessageAction<string>>(this, (message) => NotificationMessageActionHandler(message));
                };
                Unloaded += (sender, args) =>
                {
                    Messenger.Default.Unregister<NotificationMessage>(this, (mesage) => { });
                    Messenger.Default.Unregister<NotificationMessageAction<string>>(this, (mesage) => { });
                    vm.Cleanup();
                };
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void FileValidationMessage(NotificationMessage obj)
        {
            try
            {
                if (obj.Sender != null)
                {
                    MessageBox.Show(obj.Notification, obj.Sender.ToString(),
                            MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            Grid.SetColumn(pnlRighttDock, 0);
            Grid.SetColumnSpan(pnlRighttDock, 2);
            Thickness margin = pnlRighttDock.Margin;
            margin.Left = 50;
            pnlRighttDock.Margin = margin;
        }

        private void NotificationMessageActionHandler(NotificationMessageAction<string> message)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = @"Image files (*.bmp, *.jpg, *.jpeg, *.png)|*.bmp;*.jpg;*.JPEG;*.png; 
                |Word files (*.doc, *.docx)|*.doc;*.docx;
                |Excel files (*.xls, *.xlsx)|*.xls;*.xlsx;
                |PowerPoint files (*.ppt, *.pptx)|*.ppt;*.pptx
                |PDF files (*.pdf)|*.pdf;
                |Zip files (*.zip)|*.zip;
                |Rar files (*.rar)|*.rar;";
            ofd.DefaultExt = ".jpeg";

            if (ofd.ShowDialog() == true)
            {
                message.Execute(ofd.FileName);
            }
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            Grid.SetColumn(pnlRighttDock, 1);
            //Grid.SetColumnSpan(pnlRighttDock, 2);
            Thickness margin = pnlRighttDock.Margin;
            margin = new Thickness(5, 5, 5, 0);
            pnlRighttDock.Margin = margin;
        }
    }
}
