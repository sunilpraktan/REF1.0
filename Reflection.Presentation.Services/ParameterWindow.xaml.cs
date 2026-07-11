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
    /// Interaction logic for ParameterWindow.xaml
    /// </summary>
    public partial class ParameterWindow : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty ItemCategoryProperty =
           DependencyProperty.Register("ItemCategory", typeof(string), typeof(ParameterWindow), new FrameworkPropertyMetadata(string.Empty, new PropertyChangedCallback(OnItemCategoryPropertyChanged)));

        public string ItemCategory
        {
            get { return (string)GetValue(ItemCategoryProperty); }
            set { SetValue(ItemCategoryProperty, value); }
        }
        static void OnItemCategoryPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var obj = o as ParameterWindow;
            if (obj == null)
                return;
        }
        public static readonly DependencyProperty DataFilterProperty = DependencyProperty.Register
        (
                "DataFilter",
                typeof(string),
                typeof(ParameterWindow),
                new PropertyMetadata(string.Empty, new PropertyChangedCallback(OnDataFilterPropertyChanged))
        );
        private static void OnDataFilterPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            ParameterWindow myUserControl = dependencyObject as ParameterWindow;
            myUserControl.RaisePropertyChanged("DataFilter");
            myUserControl.OnDataFilterPropertyChanged(e);
        }
        private void OnDataFilterPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (this.OnDataFilterChanged != null)
                this.OnDataFilterChanged(this, e);
        }        
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
        public ParameterWindow()
        {
            InitializeComponent();
        }
    }
}
