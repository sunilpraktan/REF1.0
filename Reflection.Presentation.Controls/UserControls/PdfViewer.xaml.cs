using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Presentation.Controls
{
    /// <summary>
    /// Interaction logic for PdfViewer.xaml
    /// </summary>
    public partial class PdfViewer : UserControl
    {
        public PdfViewer()
        {
            InitializeComponent();
            _winFormPdfHost = pdfHost.Child as WinFormPdfHost;
        }



        public string PdfPath
        {
            get { return (string)GetValue(PdfPathProperty); }
            set { SetValue(PdfPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PdfPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PdfPathProperty =
            DependencyProperty.Register("PdfPath", typeof(string), typeof(PdfViewer), new UIPropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null)
            {
                var fileInfo = new FileInfo(e.NewValue.ToString());

                if (fileInfo.Extension.ToLower() != ".pdf")
                    return;

                ((PdfViewer)d).LoadFile(e.NewValue.ToString());
            }
        }

        public bool ShowToolBar
        {
            get { return _showToolBar; }
            set
            {
                _showToolBar = value;
                _winFormPdfHost.SetShowToolBar(_showToolBar);
            }
        }

        public void LoadFile(string path)
        {
            _pdfPath = path;
            _winFormPdfHost.LoadFile(path);
        }

        private string _pdfPath;
        private bool _showToolBar;
        private readonly WinFormPdfHost _winFormPdfHost;
    }
}
