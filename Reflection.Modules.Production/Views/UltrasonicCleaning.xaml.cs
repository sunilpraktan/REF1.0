using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for UltrasonicCleaning.xaml
    /// </summary>
    public partial class UltrasonicCleaning : WindowElement
    {
        public UltrasonicCleaning(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PPC_T003VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public UltrasonicCleaning(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PPC_T003VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        private void DgPopUpUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupMach.UnselectAll();
                dgPopuprefdocno.UnselectAll();
                dgrefdoctp.UnselectAll();
                dgPopuprefdocno.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PPC_T003VM")
            {
                popuprefdoctp.IsOpen = false;
                Refdocno_popup.IsOpen = false;
                ShiftPopup.IsOpen = false;
                EmployeePopup.IsOpen = false;
                OperatorPopup.IsOpen = false;
                UnitPopup.IsOpen = false;
                shift1popup.IsOpen = false;
                _popup_status.IsOpen = false;
                _popupGrade.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("PPC_T003VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
