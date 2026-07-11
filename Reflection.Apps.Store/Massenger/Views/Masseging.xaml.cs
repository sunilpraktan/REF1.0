using Reflection.Apps.Store.Massenger.ViewModels;
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

namespace Reflection.Apps.Store.Massenger
{
    /// <summary>
    /// Interaction logic for Massenging.xaml
    /// </summary>
    public partial class Masseging : WindowElement
    {
        public Masseging()
        {
            InitializeComponent();
            //DataTemplate dataTemplate = FindResource("PersonDataTemplate") as DataTemplate;
            this.DataContext = new Masseging_VM();
        }

        private void btnreply_Click(object sender, RoutedEventArgs e)
        {
            //foreach (var chld in FindVisualChildren<Rectangle>(this))
            //{
            //    if (chld.Name == "popup")
            //    {
                    
            //    }
            //}
        }
        private void btnComposeMsg_Click(object sender, RoutedEventArgs e)
        {
            CLEAR();
            this.popupComposeMsg.IsOpen = !this.popupComposeMsg.IsOpen;
        }
        private void CLEAR()
        {  
            if (MCFollower != null) { MCFollower.SelectedItems = null; MCFollower.Text = ""; MCFollower.Tag = ""; }
            if (MCPartyFollo != null) { MCPartyFollo.SelectedItems = null; MCPartyFollo.Text = ""; MCPartyFollo.Tag = ""; }
            rtb.Text = "";
            txtsub2.Text = ""; 
            
        }
        private void DockPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            //TopMenuAreatop.Visibility = Visibility.Collapsed;
            //TopMenuArea.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TopMenuAreatop.Visibility = Visibility.Collapsed;
            TopMenuArea.Visibility = Visibility.Visible;
        }
        //To find children elements:
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
