using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
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

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for CalibrationDues.xaml
    /// </summary>
    public partial class CalibrationDues : WindowElement
    {
        public CalibrationDues()
        {
            InitializeComponent();
            this.DataContext = new QMS_DUES_VM();
        }
        public CalibrationDues(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new QMS_DUES_VM(ts_code);
        }
        public CalibrationDues(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new QMS_DUES_VM(ts_code, doc_no);
        }

        #region Custom Date Format

        public static readonly DependencyProperty CustomFormat = DependencyProperty.Register("CustomDate", typeof(string), typeof(CalibrationDues),
            new FrameworkPropertyMetadata(null, OnFormatChnged));

        public string CustomDate
        {
            get
            {
                return this.GetValue(CustomFormat) as string;
            }
            set
            {
                this.SetValue(CustomFormat, value);
            }
        }
        private static void OnFormatChnged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlock _this = (d as TextBlock);
            if (_this == null)
                return;

            _this.Text = string.Format(Presentation.Resources.Properties.Settings1.Default.DateFormat, _this.Text);
        }
        
        #endregion
    }
}
