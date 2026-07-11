using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PopUpWindowSingle.xaml
    /// </summary>
    public partial class PopUpWindowSingle : UserControl
    {
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(PopUpWindowSingle), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnFilePathPropertyChanged)));

        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }
        static void OnFilePathPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var obj = o as PopUpWindowSingle;
            if (obj == null)
                return;
        }

        public static readonly DependencyProperty DataFilterProperty = DependencyProperty.Register
        (
                "DataFilter",
                typeof(string),
                typeof(PopUpWindowSingle),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnDataFilterPropertyChanged))
        );

        private static void OnDataFilterPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            PopUpWindowSingle myUserControl = dependencyObject as PopUpWindowSingle;
            myUserControl.RaisePropertyChanged("DataFilter");
            myUserControl.OnDataFilterPropertyChanged(e);
        }
        private void OnDataFilterPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (this.OnDataFilterChanged != null)
                this.OnDataFilterChanged(this, e);
        }
        //public static void OnDataFilterPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        //{
        //    var sl = sender as PopUpWindowSingle;
        //    if (sl != null)
        //        sl.RaiseDataFilterChangedEvent(e);
        //}

        private void RaiseDataFilterChangedEvent(DependencyPropertyChangedEventArgs e)
        {
            if (this.OnDataFilterChanged != null)
                this.OnDataFilterChanged(this, e);
        }
        public event PropertyChangedCallback OnDataFilterChanged;
        public string DataFilter
        {
            get { return (string)GetValue(DataFilterProperty); }
            set { SetValue(DataFilterProperty, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public static readonly DependencyProperty CommandProperty
      = DependencyProperty.Register("Command",
                                           typeof(ICommand), typeof(PopUpWindowSingle));
        //shortened        
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public PopUpWindowSingle()
        {
            InitializeComponent();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgSingelPopup.UnselectAll();
                //Command = null;
            }
            catch(Exception ex)
            {}
            e.Handled = true;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
