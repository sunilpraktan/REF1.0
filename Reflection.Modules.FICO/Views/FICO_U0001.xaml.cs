using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.ADM;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Services;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_U0001.xaml
    /// </summary>
    public partial class FICO_U0001 : UserControl
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        private UserControl _UC_OBJ = new UserControl();
        public UserControl UC_OBJ
        {
            get { return _UC_OBJ; }
            set
            {
                if (_UC_OBJ != value)
                {
                    _UC_OBJ = value; RaisePropertyChanged("UC_OBJ");

                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            //ValidateAsync(); NOTE: Temparary Commented
            //bool msg = this.HasErrors; NOTE: Temparary Commented
        }

        public FICO_U0001(string ts_code)
        {
            
            ts_code_vm = ts_code;
            InitializeComponent();

            ADM_S0001 OBH_MODULE = AppSessionState.MODULE_LIST.Where(x => x.module_code == "POS").FirstOrDefault();
            if (OBH_MODULE != null)
            {
                if (OBH_MODULE.active == "1")
                {
                    LoadPaymentControl();
                    this.DataContext = new FICO_T002_VM_POS(ts_code, "SI");
                    Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
                }
            }
        }
        public FICO_U0001(string ts_code, string doc_no)
        {
            ts_code_vm = ts_code;
            InitializeComponent();

            ADM_S0001 OBH_MODULE = AppSessionState.MODULE_LIST.Where(x => x.module_code == "POS").FirstOrDefault();
            if (OBH_MODULE != null)
            {
                if (OBH_MODULE.active == "1")
                {
                    LoadPaymentControl();
                    this.DataContext = new FICO_T002_VM_POS(ts_code, "SI", doc_no);
                    Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
                }
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "POS2")
            {
                //popup_AccountingGroup.IsOpen = false;

            }
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
        private void LoadPaymentControl()
        {
            UC_OBJ = new Reflection.Modules.FICO.Views.FICO_U0002("FI06");
            ccPaymentControl.Content = UC_OBJ;
            //UC_OBJ.DataContext = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
            //UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T005();
            //UC_OBJ.DataContext = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
        }
        //private void btnCustomer_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (Mouse.OverrideCursor == null)
        //        {
        //            CursorControl.SetBusyState();

        //            AppSessionState.ViewTitle = "New Account";
        //            AppSessionState.TransactionCode = "SD101";

        //            string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.SDM.dll"); // this one is path option
        //            Assembly assembly = Assembly.LoadFile(path1);
        //            Type type = assembly.GetType("Reflection.Modules.SDM.Views.SDM_M0021");
        //            if (type != null)
        //            {
        //                dynamic instance = Activator.CreateInstance(type, AppSessionState.TransactionCode);
        //                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
        //            }
        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}
    }
}
