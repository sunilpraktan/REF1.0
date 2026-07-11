using GalaSoft.MvvmLight.Command;
using Reflection.ReportingServices;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.SCM;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MIS_SCM_VM : WorkspaceViewModel<MIS_SCM_Entity>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<MIS_SCM_Rpt>> repository = new WebServiceRepository<List<MIS_SCM_Rpt>>();
        WebServiceRepository<MultipleContextMISReports4> repository_MC = new WebServiceRepository<MultipleContextMISReports4>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        MultipleContextMISReports4 _MC = new MultipleContextMISReports4();
        public MultipleContextMISReports4 MC
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

        private MIS_SCM_Entity _ReportParameters;
        public MIS_SCM_Entity ReportParameters
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


        private Dictionary<string, object> _unitDictionaryParent;
        public Dictionary<string, object> UnitDictionaryParent
        {
            get { return _unitDictionaryParent; }
            set
            {
                if (_unitDictionaryParent != value)
                {
                    _unitDictionaryParent = value;
                    RaisePropertyChanged("UnitDictionaryParent");
                }
            }
        }


        private Dictionary<string, object> _DocCatDictionary;
        public Dictionary<string, object> DocCatDictionary
        {
            get { return _DocCatDictionary; }
            set
            {
                if (_DocCatDictionary != value)
                {
                    _DocCatDictionary = value;
                    RaisePropertyChanged("DocCatDictionary");
                }
            }
        }

        private Dictionary<string, object> _StatusDictionary;
        public Dictionary<string, object> StatusDictionary
        {
            get { return _StatusDictionary; }
            set
            {
                if (_StatusDictionary != value)
                {
                    _StatusDictionary = value;
                    RaisePropertyChanged("StatusDictionary");
                }
            }
        }

        private List<MIS_SCM_Rpt> _dsReport;
        public List<MIS_SCM_Rpt> dsReport
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

        #endregion

        #region ICollection
        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }
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
        
        private ICollectionView _DeliveryCollection;
        public ICollectionView DeliveryCollection
        {
            get { return _DeliveryCollection; }
            set { _DeliveryCollection = value; RaisePropertyChanged("DeliveryCollection"); }
        }
        private ICollectionView _StatusCollection;
        public ICollectionView StatusCollection
        {
            get { return _StatusCollection; }
            set { _StatusCollection = value; RaisePropertyChanged("StatusCollection"); }
        }
        #endregion

        #region StringList Variables
        List<string> _stringListParty;
        public List<string> StringListParty
        {
            get { return _stringListParty; }
            set
            {
                if (_stringListParty != value)
                {
                    _stringListParty = value;
                }
            }
        }
        List<string> _stringListItems;
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
        private List<string> _srtListCompany;
        public List<string> StringListCompany
        {
            get { return _srtListCompany; }
            set
            {
                if (_srtListCompany != value)
                {
                    _srtListCompany = value;
                }
            }
        }
        List<string> _strListPlant;
        public List<string> StringListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                }
            }
        }

        List<string> _StringListDelivery;
        public List<string> StringListDelivery
        {
            get { return _StringListDelivery; }
            set
            {
                if (_StringListDelivery != value)
                {
                    _StringListDelivery = value;
                }
            }
        }

        private List<string> _strListEmp;
        public List<string> StrListEmp
        {
            get { return _strListEmp; }
            set
            {
                if (_strListEmp != value)
                {
                    _strListEmp = value;
                }
            }
        }

        private List<ADM_M038_B_P> _strListUnit;
        public List<ADM_M038_B_P> StrListUnit
        {
            get { return _strListUnit; }
            set
            {
                if (_strListUnit != value)
                {
                    _strListUnit = value;
                    RaisePropertyChanged("StrListUnit");
                }
            }
        }

        //private void RaisePropertyChanged(string v)
        //{
        //    throw new NotImplementedException();
        //}

        private List<SYS_M010_P> _strListDocCat;
        public List<SYS_M010_P> StrListDocCat
        {
            get { return _strListDocCat; }
            set
            {
                if (_strListDocCat != value)
                {
                    _strListDocCat = value;
                    RaisePropertyChanged("StrListDocCat");
                }
            }
        }
        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdEmp { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdRecPlantChange { get; private set; }
        public RelayCommand<object> cmdDeliveryChange { get; private set; }
        public RelayCommand<object> CmdInsertStatus { get; private set; }
        #endregion

        #region Constructor
        public MIS_SCM_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContextMISReports4();
            ReportParameters = new MIS_SCM_Entity();
            _dsReport = new List<MIS_SCM_Rpt>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Delivery Note");
            ItemsDictionary.Add("R002", "Delivery Note Plant To Plant");
            ItemsDictionary.Add("R003", "Pending Returnable Challan");
            ItemsDictionary.Add("R004", "Returnable Challan");
            ItemsDictionary.Add("R005", "Consumption Report Against Sales Order");

            StatusDictionary = new Dictionary<string, object>();
            //StatusDictionary.Add("004", "Open");
            //StatusDictionary.Add("003", "Closed");
            //StatusDictionary.Add("001", "Draft");


            cmdEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdRecPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertRecPlant(items); });
            cmdDeliveryChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertDelivery(items); });
            CommandReport = new RelayCommand(DisplayReport);
            CmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
            // SelectionChangedCommandgodown = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedGodown(items); });

            LoadInitialData();
            DefaultValues();
        }
        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports4>(MC, Request, "MIS_SCM", "SCM", "LoadAll", 0, "");

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList.ToList());
                EmployeeCollection.Filter = new Predicate<object>(FilterEmp);
                StrListEmp = MC.EmployeeList.Select(x => x.EmpId).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyDetails);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                //StringListParty = MC.partyDetails.Select(x => x.PartyId).ToList();

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode).ToList();

                var UnitListParent = (from o in MC.UnitDetails
                                      where o.unit_code != null
                                      select o).ToList();
                _strListUnit = UnitListParent;
                UnitDictionaryParent = _strListUnit.ToDictionary(X => X.unit_code.ToString(), X => (object)X.unit_code);

                var DocCatList = (from o in MC.DocCatDetails
                                  where o.doc_cat != null
                                  select o).ToList();
                _strListDocCat = DocCatList;
                DocCatDictionary = _strListDocCat.ToDictionary(X => X.doc_cat.ToString(), X => (object)X.dcat_name);

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                DeliveryCollection = CollectionViewSource.GetDefaultView(MC.DeliveryTyList);
                DeliveryCollection.Filter = new Predicate<object>(FilterDelivery);
                StringListDelivery = MC.DeliveryTyList.Select(x => x.del_desc).ToList();

                StatusCollection = CollectionViewSource.GetDefaultView(MC.StatusDetails);
                StatusCollection.Filter = new Predicate<object>(FilterStatus);

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
            ReportParameters.comp_code = AppSessionState.comp_code;
            //ReportParameters.fin_year = AppSessionState.FinYear;
            ReportParameters.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            
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

                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.doc_cat + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.delivery_type + "!@" + ReportParameters.unit_code + "!@" + ReportParameters.t_status + "!@" + ReportParameters.rec_plant;
                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_SCM_Rpt>>(dsReport, RequestParameter, "MIS_SCM", "SCM", "", 0, RequestParameter);
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsMIS_SCM_Rpt", "\\MIS\\SCM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
                result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
                result.Add("ItemCode", ReportParameters.ItemCode);
                result.Add("PartyId", ReportParameters.PartyId);
                result.Add("PartyNm", ReportParameters.PartyNm);
                result.Add("doc_type", ReportParameters.doc_type);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportNm", ReportParameters.ReportName);
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("ItemName", ReportParameters.ItemName);
                result.Add("dcat_name", ReportParameters.dcat_name);

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
            {
                returnReportName = "RptDeliveryNote.rdlc";
            }
            else if (ReportCode == "R002")
            {
                returnReportName = "DeliveryNoteP2P.rdlc";
            }
            else if (ReportCode == "R003")
            {
                returnReportName = "ReturnableChallen.rdlc";
            }
            else if (ReportCode == "R004")
            {
                returnReportName = "ReturnableChallenList.rdlc";
            }
            else if (ReportCode == "R005")
            {
                returnReportName = "ConsumptionReportAgainstSo.rdlc";
            }
            return returnReportName;
        }
        

        private void InsertEmp(object InputValue)
        {
            try
            {
                string stringEmp = "";
                string stringEmpNm = "";
                ReportParameters.EmpId = "";
                foreach (ADM_M024_P temp in MC.EmployeeList)
                {
                    if (temp.Select == true)
                    {
                        stringEmp = stringEmp + "," + temp.EmpId;
                        stringEmpNm = stringEmpNm + "," + temp.EmpName;
                    }
                }
                ReportParameters.EmpId = stringEmp.ToString().TrimStart(new char[] { ',' });
                ReportParameters.EmpName = stringEmpNm.ToString().TrimStart(new char[] { ',' });

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
        

        private void InsertDelivery(object InputValue)
        {

            string stringDelivertType = "";
            string stringDeliveryDesc = "";
            ReportParameters.PartyId = "";
            foreach (SYS_M005_P temp in MC.DeliveryTyList)
            {
                if (temp.Select == true)
                {
                    stringDelivertType = stringDelivertType + "," + temp.delivery_type;
                    stringDeliveryDesc = stringDeliveryDesc + "," + temp.del_desc;
                }
            }
            ReportParameters.delivery_type = stringDelivertType.ToString().TrimStart(new char[] { ',' });
            ReportParameters.del_desc = stringDeliveryDesc.ToString().TrimStart(new char[] { ',' });

        }

        private void InsertStatus(object InputValue)
        {

            string stringStatus = "";
            //string stringStatusNm = "";

            ReportParameters.ItemCode = "";
            foreach (MM_T001 temp in MC.StatusDetails)
            {
                if (temp.Select == true)
                {
                    stringStatus = stringStatus + "," + temp.t_status;
                    //stringStatusNm = stringStatusNm + "," + temp.t_display;

                }
            }
            ReportParameters.t_status = stringStatus.ToString().TrimStart(new char[] { ',' });
            //ReportParameters. = stringStatusNm.ToString().TrimStart(new char[] { ',' });

        }


        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParameters.PartyId = "";
            foreach (ADM_M028_P temp in MC.partyDetails)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParameters.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParameters.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

        }  

        private void InsertItem(object InputValue)
        {

            string stringItems = "";
            string stringItemsNm = "";

            ReportParameters.ItemCode = "";
            foreach (ADM_M022_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.ItemCode;
                    stringItemsNm = stringItemsNm + "," + temp.ItemName;

                }
            }
            ReportParameters.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });
            ReportParameters.ItemName = stringItemsNm.ToString().TrimStart(new char[] { ',' });

        }

        private void InsertCompany(object InputValue)
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
 

        private void InsertPlant(object InputValue)
        {
            string stringLocation = "";
            string stringLocationNm = "";

            ReportParameters.location_Id = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringLocation = stringLocation + "," + temp.location_Id;
                    stringLocationNm = stringLocationNm + "," + temp.LoctnNm;

                }
            }
            ReportParameters.location_Id = stringLocation.ToString().TrimStart(new char[] { ',' });
            ReportParameters.LoctnNm = stringLocationNm.ToString().TrimStart(new char[] { ',' });


        }
        private void InsertRecPlant(object InputValue)
        {
            string stringRecLocation = "";
            string stringRecLocationNm = "";

            ReportParameters.rec_plant = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringRecLocation = stringRecLocation + "," + temp.location_Id;
                    stringRecLocationNm = stringRecLocationNm + "," + temp.LoctnNm;

                }
            }
            ReportParameters.rec_plant = stringRecLocation.ToString().TrimStart(new char[] { ',' });
            ReportParameters.rec_plantNm = stringRecLocationNm.ToString().TrimStart(new char[] { ',' });


        }

        #endregion

        #region . Filter .


        #region filterEmployee
        public bool FilterEmp(object obj)
        {
            var data = obj as ADM_M024_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmp))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmp.ToLower()) ||
                        data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterStringEmp.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringEmp;
        public string filterStringEmp
        {
            get { return _filterStringEmp; }
            set
            {
                _filterStringEmp = value;
                RaisePropertyChanged("filterStringEmp");
                FilterCollectionEmp();
            }
        }
        private void FilterCollectionEmp()
        {
            if (_EmployeeCollection != null)
            {
                _EmployeeCollection.Refresh();
            }
        }
        #endregion

        private string _filterString_party;
        public string FilterString_party
        {
            get { return _filterString_party; }
            set
            {
                _filterString_party = value;
                RaisePropertyChanged("FilterString_party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower())));
                }
                return true;
            }
            return false;
        }

        #region Filter Delivery Type
        private string _filterString_Delivery;
        public string FilterString_Delivery
        {
            get { return _filterString_Delivery; }
            set
            {
                _filterString_Delivery = value;
                RaisePropertyChanged("FilterString_Delivery");
                FilterCollectionDelivery();
            }
        }
        private void FilterCollectionDelivery()
        {
            if (_DeliveryCollection != null)
            {
                _DeliveryCollection.Refresh();
            }
        }
        public bool FilterDelivery(object obj)
        {
            var data = obj as SYS_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Delivery))
                {
                    return (data.delivery_type != null && data.delivery_type.ToString().ToLower().Contains(_filterString_Delivery.ToLower()) ||
                        (data.del_desc!= null && data.del_desc.ToString().ToLower().Contains(_filterString_Delivery.ToLower())));
                }
                return true;
            }
            return false;
        }

        #endregion
        private string _filterString_Status;
        public string FilterString_Status
        {
            get { return _filterString_Status; }
            set
            {
                _filterString_Status = value;
                RaisePropertyChanged("FilterString_Status");
                FilterCollectionStatus();
            }
        }
        private void FilterCollectionStatus()
        {
            if (_StatusCollection != null)
            {
                _StatusCollection.Refresh();
            }
        }
        public bool FilterStatus(object obj)
        {
            var data = obj as MM_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Status))
                {
                    return (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_Status.ToLower()) ||
                            (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_Status.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }


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

        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollectionCompany();
            }
        }
        private void FilterCollectionCompany()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Company))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_Company.ToLower()) ||
                            (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_Company.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }


        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_Item");
                filterPlantCollection();
            }
        }
        private void filterPlantCollection()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_plant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_plant.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_plant.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_SCM_Entity> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_SCM_Entity> result)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
