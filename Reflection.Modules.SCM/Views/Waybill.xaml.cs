using GalaSoft.MvvmLight.Messaging;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Waybill.xaml
    /// </summary>
    public partial class Waybill : WindowElement
    {
        public Waybill(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new GEN_T009_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster1.SelectionChanged += TabControl_SelectionChanged;
        }
        public Waybill(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new GEN_T009_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster1.SelectionChanged += TabControl_SelectionChanged;
        }
        private bool isManualEditCommit;


        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                int x = grid.Items.Count;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "GEN_T009_VM")
            {
                _popupStstus.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("GEN_T009_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void dgselected_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgsotype.UnselectAll();
                //dgPopupParty.UnselectAll();
                //dgpayer.UnselectAll();
                //dgReferance.UnselectAll();
                //dgplant.UnselectAll();
                //dgPopupCurrency.UnselectAll();
                //dgPayterms.UnselectAll();
                //dgsaleorgnisation.UnselectAll();
                //dgSalesGroup.UnselectAll();
                //dgcostcentre.UnselectAll();
                //dgjournal.UnselectAll();
                //dgSalesPerson.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}