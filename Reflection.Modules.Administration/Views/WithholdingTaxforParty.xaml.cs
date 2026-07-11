using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for WithholdingTaxforParty.xaml
    /// </summary>
    public partial class WithholdingTaxforParty : WindowElement
    {
        
        public WithholdingTaxforParty()
        {
            InitializeComponent();
            this.DataContext = new ADM_M028_I_VM();
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public WithholdingTaxforParty(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M028_I_VM();
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public WithholdingTaxforParty(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M028_I_VM();
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }


        //private void Btn_SelectRows(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    List<ADM_M028_I_Flip> itemsource = ((System.Windows.Data.CollectionView)DataLV.ItemsSource).SourceCollection as List<ADM_M028_I_Flip>;

        //    int cnt = 0;
        //    foreach (ADM_M028_I_Flip item in itemsource)
        //    {
        //        if (item.Check == true)
        //        {
        //            DocumentDataFlipGrid.Add(item);
        //            cnt++;

        //        }

        //    }

        //    var msg = new NotificationMessage(DocumentDataFlipGrid, "Add Contact");
        //    Messenger.Default.Send<NotificationMessage>(msg);
        //    //this.Close();

        //    var msg2 = new NotificationMessage(DocumentDataFlipGrid, "Add Single Contact");
        //    Messenger.Default.Send<NotificationMessage>(msg2);
        //    this.Close();


        //}

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
            if (msg.Notification == "ADM_M028_I_VM")
            {
                popup_PartyId.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ADM_M028_I_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_PartyId)
            {
                var msg = new NotificationMessage("ADM_M028_I_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }



    }
}
