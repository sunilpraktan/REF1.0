using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Common;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_DUES_VM : WorkspaceViewModel<QMS_T002>
    {
        WebServiceRepository<MultipleContext_QMS_T002> repository_MC = new WebServiceRepository<MultipleContext_QMS_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration
        private QMS_T002 _MasterEntity;
        public QMS_T002 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private MultipleContext_QMS_T002 _MC;
        public MultipleContext_QMS_T002 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_T002 _MCTemp;
        public MultipleContext_QMS_T002 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdLoadFromDateToDate { get; private set; }
        public RelayCommand<object> CmdViewDocument { get; private set; }
        public RelayCommand<object> CmdViewCalibration { get; private set; }
        public RelayCommand<object> CmdLoadByStatus { get; private set; }

        #endregion

        #region Constructor
        public QMS_DUES_VM() : base()
        {
            CursorControl.SetBusyState();
            MasterEntity = new QMS_T002();
            MC = new MultipleContext_QMS_T002();
            MCTemp = new MultipleContext_QMS_T002();
            LoadInitialData();
        }
        public QMS_DUES_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            MasterEntity = new QMS_T002();
            MC = new MultipleContext_QMS_T002();
            MCTemp = new MultipleContext_QMS_T002();
            LoadInitialData();
        }
        public QMS_DUES_VM(string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            MasterEntity = new QMS_T002();
            MC = new MultipleContext_QMS_T002();
            MCTemp = new MultipleContext_QMS_T002();
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                CursorControl.SetBusyState();
                CmdLoadFromDateToDate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadFromDateToDate(cmdPara); });
                CmdViewDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewDocument(cmdPara); });
                CmdViewCalibration = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewCalibration(cmdPara); });
                CmdLoadByStatus = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadByStatus(cmdPara); });


                string Request = "LoadInitialDataForDue" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T002>(MC, Request, "ServiceRequest", "QMS", "LoadInitialData", 0, "");

                DefaultValues();

                DataGridCollection = CollectionViewSource.GetDefaultView(from o in MC.DocumentDataGrid where o.t_status == MasterEntity.t_status select o);
                DataGridCollection.Filter = new Predicate<object>(Filter);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            MasterEntity.FromDate = DateTime.Now;
            MasterEntity.ToDate = DateTime.Now;
            MasterEntity.t_status = "Approved";
        }
        private void LoadFromDateToDate(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadFromDateToDateForDue" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(MasterEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.t_status;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T002>(MCTemp, Request, "ServiceRequest", "QMS", "LoadInitialData", 0, "");

                MC.DocumentDataGrid = MCTemp.DocumentDataGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(MC.DocumentDataGrid);
                DataGridCollection.Filter = new Predicate<object>(Filter);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void ViewDocument(object InputValue)
        {
            try
            {
                //    CursorControl.SetBusyState();
                //    QMS_T002 POPUPEntityObject = null;
                //    ADM_AUTH userAuth = new ADM_AUTH();
                //    if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T002>().Count() > 0)
                //    {
                //        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T002>().ToList()[0];
                //        POPUPEntityObject.TranCode = MC.DocTypeInfo.Where(x => x.doc_type == "RF" && x.doc_cat == "RF").Select(x => x.TranCode).FirstOrDefault();
                //    }

                //    var docdetails = AppSessionState.(ADM_AUTH)ADM_AUTH_OBJ.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                //    userAuth = docdetails;
                //    AppSessionState.UserAuthSingle = userAuth;
                //    AppSessionState.ViewTitle = userAuth.DisTitl;
                //    AppSessionState.TransValue = POPUPEntityObject.ref_doc_no;
                //    AppSessionState.TransValueType = POPUPEntityObject.ref_doc_no;
                //    AppSessionState.TransParameter = "No";
                //    AppSessionState.ViewOtherRecordAllowed = false;
                //    AppSessionState.TransId = userAuth.id.ToString();
                //    AppSessionState.TransactionCode = userAuth.TranCode;

                //    if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //    {
                //        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.Nspace);
                //        Assembly assembly = Assembly.LoadFile(path1);
                //        Type type = assembly.GetType(userAuth.ClsFileName);
                //        if (type != null)
                //        {
                //            dynamic instance = Activator.CreateInstance(type);
                //            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                //        }
                //    }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void ViewCalibration(object InputValue)
        {
            try
            {
                //CursorControl.SetBusyState();
                //QMS_T002 POPUPEntityObject = null;
                //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                //if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T002>().Count() > 0)
                //{
                //    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T002>().ToList()[0];
                //    POPUPEntityObject.TranCode = MC.DocTypeInfo.Where(x => x.doc_type == "CC" && x.doc_cat == "CC").Select(x => x.TranCode).FirstOrDefault();
                //}

                //var docdetails = AppSessionState.(List<ADM_AUTH>)ADM_AUTH_OBJ.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                //userAuth = docdetails;
                //AppSessionState.UserAuthSingle = userAuth;
                //AppSessionState.ViewTitle = userAuth.DisTitl;
                //AppSessionState.TransValue = POPUPEntityObject.ref_doc_no + "!@" + POPUPEntityObject.test_code;
                //AppSessionState.TransValueType = POPUPEntityObject.barcode;
                //AppSessionState.TransParameter = "FromDue";
                //AppSessionState.ViewOtherRecordAllowed = true;
                //AppSessionState.TransId = userAuth.id.ToString();
                //AppSessionState.TransactionCode = userAuth.TranCode;

                //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //{
                //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.Nspace);
                //    Assembly assembly = Assembly.LoadFile(path1);
                //    Type type = assembly.GetType(userAuth.ClsFileName);
                //    if (type != null)
                //    {
                //        dynamic instance = Activator.CreateInstance(type);
                //        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                //    }
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void LoadByStatus(object InputValue)
        {
            try
            {
                if (((IEnumerable)InputValue).Cast<String>().Count() > 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(from o in MC.DocumentDataGrid where o.t_status == MasterEntity.t_status select o);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        #endregion

        #region Filters For DataGrid
        private string _filterString;
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as QMS_T002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.serv_type != null && data.serv_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.inst_name != null && data.inst_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.barcode != null && data.barcode.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_T002> result)
        {
            LoadInitialData();
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_T002> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
