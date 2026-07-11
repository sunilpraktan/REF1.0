using Reflection.Modules.SCM.ViewModels;
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
using System.IO;
using Microsoft.Win32;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Description for Stock_Journal.
    /// </summary>
    public partial class Stock_Journal : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the Stock_Journal class.
        /// </summary>
        public Stock_Journal()
        {
            InitializeComponent();
            this.DataContext = new MM_M007_VM();  
        }

        private void cboTrnsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string text = (e.AddedItems[0] as ComboBoxItem).Content as string;

            if (SE.IsSelected)//(text == "Stock Enter")
            {
                txttoLocation.Visibility = System.Windows.Visibility.Hidden;
                stktolocation.Visibility = System.Windows.Visibility.Hidden; 
            }
            if (SR.IsSelected)
            {
                txttoLocation.Visibility = System.Windows.Visibility.Hidden;
                stktolocation.Visibility = System.Windows.Visibility.Hidden;
            }
            if (SM.IsSelected)
            {
                txttoLocation.Visibility = System.Windows.Visibility.Visible;
                stktolocation.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void dgPopUpProdct1_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpProdct1.UnselectAll();
                dgPopUpProdct.UnselectAll();
                //dgParameters.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        // #region "DependencyProperty"


        //public static readonly DependencyProperty SourceLocProperty =
        //DependencyProperty.Register("SourceLoc", typeof(string), typeof(Stock_Journal),
        //new PropertyMetadata(string.Empty));
        // public string SourceLoc
        // {
        //     get { return GetValue(SourceLocProperty) as string; }
        //     set
        //     {
        //         SetValue(SourceLocProperty, value);
        //     }
        // }
        // #endregion
        
    }
}