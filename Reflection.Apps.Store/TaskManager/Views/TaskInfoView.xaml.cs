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
using Reflection.Presentation.Windows.Controls;
using System.IO;
using Microsoft.Win32;

namespace Reflection.Apps.Store.TaskManager
{
    /// <summary>
    /// Interaction logic for TaskInfoView.xaml
    /// </summary>
    public partial class TaskInfoView : WindowElement
    {
        public TaskInfoView()
        {
            InitializeComponent();
            this.DataContext = new TaskInfo_VM();
         
        }
        private void dgPopupAssignTo_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupAssignTo.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
       
             private void DgPopUpUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupAssignTo.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
       
                 private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupAssignTo.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void CmbTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try  
            {
                if (CmbTaskType.SelectedItem.ToString() == "One Time")
                {
                    CmbTaskFreq.IsEnabled = false;
                    txtFreqNo.IsEnabled = false;
                    txtDayFreq.IsEnabled = false;
                    TpTriggerTime.IsEnabled = false;
                    DtCloseDate.IsEnabled = false;
                }
                else if (CmbTaskType.SelectedItem.ToString() == "Recurring")
                {
                    CmbTaskFreq.IsEnabled = true;
                    txtFreqNo.IsEnabled = true;
                    txtDayFreq.IsEnabled = true;
                    TpTriggerTime.IsEnabled = true;
                    DtCloseDate.IsEnabled = true;
                }
            }
            catch
            {

            }
        }

        #region "DependencyProperty"

        //public static readonly DependencyProperty TaskIdProperty =
        //  DependencyProperty.Register("id", typeof(int?), typeof(TaskInfoView),
        //  new PropertyMetadata(0));

        //public int? id
        //{
        //    get { return GetValue(TaskIdProperty) as int?; }
        //    set
        //    {
        //        SetValue(TaskIdProperty, value);
        //    }
        //}
        //public static readonly DependencyProperty TaskDescProperty =
        //DependencyProperty.Register("task_desc", typeof(string), typeof(TaskInfoView),
        //new PropertyMetadata(string.Empty));
        //public string task_desc
        //{
        //    get { return GetValue(TaskDescProperty) as string; }
        //    set
        //    {
        //        SetValue(TaskDescProperty, value);
        //    }
        //}
        #endregion
    }
}
