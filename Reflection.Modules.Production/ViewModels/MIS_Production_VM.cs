using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using System.Data;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.Production;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    class MIS_Production_VM: WorkspaceViewModel<MIS_PRO_Entity>
    {
        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool blNew = true;

        WebServiceRepository<MultipleContext_MIS_Production> repository_MC = new WebServiceRepository<MultipleContext_MIS_Production>();
        ObjectSerializationService obj = new ObjectSerializationService();
        // WebServiceRepository<List<MIS_SCM_ReportEntity>> repository = new WebServiceRepository<List<MIS_SCM_ReportEntity>>();

        MultipleContext_MIS_Production _MC = new MultipleContext_MIS_Production();
        public MultipleContext_MIS_Production MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }
        private MIS_PRO_Entity _MasterEntity;
        public MIS_PRO_Entity MasterEntity
        {
            get
            {

                return _MasterEntity;
            }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }


        //private List<MIS_SCM_ReportEntity> _dsReport;
        //public List<MIS_SCM_ReportEntity> dsReport
        //{
        //    get { return _dsReport; }
        //    set
        //    {
        //        if (_dsReport != value)
        //        {
        //            _dsReport = value;


        //            RaisePropertyChanged("dsReport");

        //        }
        //    }
        //}

        #endregion
     
        #region Dictionary
        private Dictionary<string, string> _ReportItemsDictionary;
        public Dictionary<string, string> ReportItemsDictionary
        {
            get { return _ReportItemsDictionary; }
            set
            {
                if (_ReportItemsDictionary != value)
                {
                    _ReportItemsDictionary = value;
                    RaisePropertyChanged("ReportItemsDictionary");
                }
            }
        }

        private Dictionary<string, object> _plantDictionaryParent;
        public Dictionary<string, object> PlantDictionaryParent
        {
            get { return _plantDictionaryParent; }
            set
            {
                if (_plantDictionaryParent != value)
                {
                    _plantDictionaryParent = value;
                    RaisePropertyChanged("PlantDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _machineDictionaryParent;
        public Dictionary<string, object> machineDictionaryParent
        {
            get { return _machineDictionaryParent; }
            set
            {
                if (_machineDictionaryParent != value)
                {
                    _machineDictionaryParent = value;
                    RaisePropertyChanged("machineDictionaryParent");
                }
            }
        }

        #endregion

        #region ICollection

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }

        #endregion

        #region StringList Variables
  

        private List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }
  
        private List<ADM_M003> _strListPlant;
        public List<ADM_M003> StrListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                    RaisePropertyChanged("StrListPlant");
                }
            }
        }

        private List<ZADM_M013_P> _strListMachine;
        public List<ZADM_M013_P> StrListMachine
        {
            get { return _strListMachine; }
            set
            {
                if (_strListMachine != value)
                {
                    _strListMachine = value;
                    RaisePropertyChanged("StrListMachine");
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

        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public MIS_Production_VM(string ts_code)
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_Production();
            MasterEntity = new MIS_PRO_Entity();
           // _dsReport = new List<MIS_SCM_ReportEntity>();
            ReportItemsDictionary = new Dictionary<string, string>();
            ReportItemsDictionary.Add("R001", "Production Entry");
            
            LoadInitialData();
            DefaultValues();
        }


     
        #endregion

        #region UserDefined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_Production>(MC, Request, "MIS_Production_Reports", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CommandReport = new RelayCommand(DisplayReport);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion
                //items
                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);

                //machine code
                var machineListParent = (from o in MC.machineDetails
                                         where o.machine_id.ToString() != null
                                         select o).ToList();
                _strListMachine = machineListParent;
                machineDictionaryParent = _strListMachine.ToDictionary(X => X.machine_id.ToString(), X => (object)X.machinecode);
               
                //Location
                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var PlantListParent = (from o in ObjPlant
                                       where o.location_Id != null
                                       select o).ToList();
                _strListPlant = PlantListParent;
                PlantDictionaryParent = _strListPlant.ToDictionary(X => X.location_Id.ToString(), X => (object)X.LoctnNm);

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

            MasterEntity.ItemCode = "";
            MasterEntity.ItemName = "";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.ReportCode = "";
            MasterEntity.ReportName = "";          
            MasterEntity.machinecode = "";
            MasterEntity.t_status = "";
            MasterEntity.ts_code = ts_code_vm;
         
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FromDate = lastDayLastMonth.AddDays(0);
            MasterEntity.ToDate = DateTime.Now;
        }
        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                //if (MasterEntity.ReportCode.ToString() != "")
                //{
                //    string RequestParameter = "Report" + "!@" + MasterEntity.ReportCode + "!@" + MasterEntity.ItemCode + "!@" + AppSessionState.location_Id + "!@" + Convert.ToDateTime(MasterEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.t_status + "!@" + MasterEntity.machinecode;
                //    // dsReport = repository.GetDataWithReturnDomainObject<List<MIS_SCM_ReportEntity>>(dsReport, RequestParameter, "MIS_Production_Reports", "Production", "", 0, "");

                //    ReportManager ReportManager = new ReportManager();
                //    ReportManager.DisplayReport(dsReport, "dsMIS_SCM_ReportEntity", "\\MIS\\SCM\\" + GetReportFile(MasterEntity.ReportCode), getParametersList());
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("FromDate", Convert.ToString(MasterEntity.FromDate));
                result.Add("ToDate", Convert.ToString(MasterEntity.ToDate));
                result.Add("ItemCode", MasterEntity.ItemCode);         
                result.Add("t_status", MasterEntity.t_status);
                result.Add("ReportName", MasterEntity.ReportName);             
                result.Add("location_Id", MasterEntity.location_Id);
                result.Add("ItemName", MasterEntity.ItemName);               
                result.Add("machine_id", MasterEntity.machine_id.ToString());
                result.Add("machinecode", MasterEntity.machinecode);            

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
            { returnReportName = "MaterialIssue.rdlc"; }
       


            return returnReportName;
        }    
        private void InsertItem(object InputValue)
        {

            string stringItems = "";
            MasterEntity.ItemCode = "";
            foreach (ADM_M022_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.ItemCode;
                }
            }
            MasterEntity.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
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
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region . Filter .

        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollectionItem();
            }
        }
        private void FilterCollectionItem()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public bool FilterItem(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                            (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        #endregion


        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_PRO_Entity> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_PRO_Entity> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_PRO_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_PRO_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_PRO_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_PRO_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_PRO_Entity> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
