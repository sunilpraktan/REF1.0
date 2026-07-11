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
    /// Interaction logic for GoodsReceiptNote2.xaml
    /// </summary>
    public partial class GoodsReceiptNote2 : WindowElement
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public GoodsReceiptNote2(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new MM_T001_GRN_VM2(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public GoodsReceiptNote2(string ts_code,string doc_no)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new MM_T001_GRN_VM2(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
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
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_local)
            {
                popTR_Mode.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != status_popup)
            {
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void dgmovtype_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmovtype.UnselectAll();
                dgrefdoctype.UnselectAll();
                dgrefdocno.UnselectAll();
                dgsupplier.UnselectAll();
                dgtransporter.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgsaleorgnisation.UnselectAll();
            dgPurchaseGroup.UnselectAll();
        }
        
    }
}
