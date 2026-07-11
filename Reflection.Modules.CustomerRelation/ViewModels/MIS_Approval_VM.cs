using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections;
using Reflection.Presentation.Services;
using System.Data;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class MIS_Approval_VM : WorkspaceViewModel<Approval>
    {

        #region Declaration

        bool blNew = true;
        WebServiceRepository<List<Approval>> repository = new WebServiceRepository<List<Approval>>();
        ObjectSerializationService obj = new ObjectSerializationService();


        private List<Approval> _dsReport;
        public List<Approval> dsReport
        {
            get { return _dsReport; }
            set
            {
                if (_dsReport != value)
                {
                    _dsReport = value;


                    RaisePropertyChanged("dsReport");

                }
            }
        }

        private List<Approval> _dsDepartment;
        public List<Approval> dsDepartment
        {
            get { return _dsDepartment; }
            set
            {
                if (_dsDepartment != value)
                {
                    _dsDepartment = value;


                    RaisePropertyChanged("dsDepartment");

                }
            }
        }

        private MISReportParameter _ReportParameters;
        public MISReportParameter ReportParameters
        {
            get
            {

                return _ReportParameters;
            }
            set
            {
                _ReportParameters = value;
                RaisePropertyChanged("ReportParameters");
            }
        }

        public List<ADM_M002> _ObjComp = new List<ADM_M002>();
        private List<ADM_M002> ObjComp
        {
            get { return _ObjComp; }
            set
            {
                if (_ObjComp != value)
                {
                    _ObjComp = value;
                }
            }
        }

        public List<ADM_M003> _ObjPlant = new List<ADM_M003>();
        private List<ADM_M003> ObjPlant
        {
            get { return _ObjPlant; }
            set
            {
                if (_ObjPlant != value)
                {
                    _ObjPlant = value;
                }
            }
        }
        //public List<Approval> _ObjDepartment = new List<Approval>();
        //private List<Approval> ObjDepartment
        //{
        //    get { return _ObjDepartment; }
        //    set
        //    {
        //        if (_ObjDepartment != value)
        //        {
        //            _ObjDepartment = value;
        //        }
        //    }
        //}
        private Dictionary<string, string> _itemsDictionary;
        public Dictionary<string, string> ItemsDictionary
        {
            get { return _itemsDictionary; }
            set
            {
                if (_itemsDictionary != value)
                {
                    _itemsDictionary = value;
                    RaisePropertyChanged("ItemsDictionary");
                }
            }
        }

        #endregion

        #region ICollection


        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }
        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }
        private ICollectionView _DepartmentCollection;
        public ICollectionView DepartmentCollection
        {
            get { return _DepartmentCollection; }
            set { _DepartmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }
        }
        #endregion
        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdCompany { get; private set; }
        public RelayCommand<object> cmdLocation { get; private set; }
        public RelayCommand<object> cmdDepartment { get; private set; }
        #endregion

        #region Constructor
        public MIS_Approval_VM()
            : base()
        {
            CursorControl.SetBusyState();
            ReportParameters = new MISReportParameter();
            dsReport = new List<Approval>();
            dsDepartment = new List<Approval>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Pending Approvals");
            ItemsDictionary.Add("R002", "Pending Inspections");

            CommandReport = new RelayCommand(DisplayReport);
            cmdCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
            cmdDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items); });
            LoadInitialData();
            DefaultValues();
        }
        #endregion

        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string RequestParameter = "LoadInitialData" + "!@" + ReportParameters.ReportCode + "!@" + "" + "!@" + "" + "!@" + ReportParameters.Location_Id + "!@" + ReportParameters.comp_code + "!@" + "" + "!@" + "" + "!@" + "" + "!@" + ReportParameters.t_status;
                dsDepartment = repository.GetDataWithReturnDomainObject<List<Approval>>(dsDepartment, RequestParameter, "MIS_Approval", "CRM", "", 0, RequestParameter);


                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());

                DepartmentCollection = CollectionViewSource.GetDefaultView(dsDepartment);
            }
            catch (Exception ex)
            {
            }
        }

        private void DefaultValues()
        {
            ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.Location_Id = AppSessionState.location_Id;
        }

        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                if (ReportParameters.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }
                if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + "" + "!@" + "" + "!@" + ReportParameters.Location_Id + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.doc_cat + "!@" + "" + "!@" + "" + "!@" + ReportParameters.t_status;
                    dsReport = repository.GetDataWithReturnDomainObject<List<Approval>>(dsReport, RequestParameter, "MIS_Approval", "CRM", "", 0, RequestParameter);
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsPendingApprovals", "\\MIS\\CRM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
        private void InsertCompany(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M002 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = ObjComp.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.comp_code = POPUPEntityObject.comp_code;
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
        private void InsertLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = ObjPlant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.Location_Id = POPUPEntityObject.location_Id;
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
        private void InsertDepartment(object InputValue)
        {
            try
            {
                string Request = "";
                Approval POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = dsDepartment.Where(x => x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Approval>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.doc_cat = POPUPEntityObject.doc_cat;
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("ReportName", ReportParameters.ReportName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            { returnReportName = "PendingApprovals.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "PendingApprovals.rdlc"; }

            return returnReportName;
        }



        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<Approval> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<Approval> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<Approval> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<Approval> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<Approval> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<Approval> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<Approval> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<Approval> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


}
