using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Production;
using Reflection.Presentation.Common;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.ReportingServices;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Modules.Production.ViewModels
{
    class MIS_PDI_Entry_VM : WindowViewModel<MIS_PDI_Entity>, INotifyPropertyChanged
    {
        #region Declaration

        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_PDI_Entry> repository_MC = new WebServiceRepository<MultipleContext_MIS_PDI_Entry>();
        ObjectSerializationService obj = new ObjectSerializationService();
        //Report Repository
        WebServiceRepository<List<Rpt_MIS_PDI_Entry>> repository = new WebServiceRepository<List<Rpt_MIS_PDI_Entry>>();
        MultipleContext_MIS_PDI_Entry _MC = new MultipleContext_MIS_PDI_Entry();
        public MultipleContext_MIS_PDI_Entry MC
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

        private MIS_PDI_Entity _ReportParametersEntity;
        public MIS_PDI_Entity ReportParametersEntity
        {
            get
            {

                return _ReportParametersEntity;
            }
            set
            {
                _ReportParametersEntity = value;
                RaisePropertyChanged("ReportParametersEntity");
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

        private List<Rpt_MIS_PDI_Entry> _dsReport;
        public List<Rpt_MIS_PDI_Entry> dsReport
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

        private Dictionary<string, object> _PartyDictionary;
        public Dictionary<string, object> PartyDictionary
        {
            get { return _PartyDictionary; }
            set
            {
                if (_PartyDictionary != value)
                {
                    _PartyDictionary = value;
                    RaisePropertyChanged("PartyDictionary");
                }
            }
        }

        private Dictionary<string, object> _PartyDictionaryParent;
        public Dictionary<string, object> PartyDictionaryParent
        {
            get { return _PartyDictionaryParent; }
            set
            {
                if (_PartyDictionaryParent != value)
                {
                    _PartyDictionaryParent = value;
                    RaisePropertyChanged("PartyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _compDictionaryParent;
        public Dictionary<string, object> CompDictionaryParent
        {
            get { return _compDictionaryParent; }
            set
            {
                if (_compDictionaryParent != value)
                {
                    _compDictionaryParent = value;
                    RaisePropertyChanged("CompDictionaryParent");
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

        private Dictionary<string, object> _ILDDictionaryParent;
        public Dictionary<string, object> ILDDictionaryParent
        {
            get { return _ILDDictionaryParent; }
            set
            {
                if (_ILDDictionaryParent != value)
                {
                    _ILDDictionaryParent = value;
                    RaisePropertyChanged("ILDDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _InkDictionaryParent;
        public Dictionary<string, object> InkDictionaryParent
        {
            get { return _InkDictionaryParent; }
            set
            {
                if (_InkDictionaryParent != value)
                {
                    _InkDictionaryParent = value;
                    RaisePropertyChanged("InkDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _ShiftDictionaryParent;
        public Dictionary<string, object> ShiftDictionaryParent
        {
            get { return _ShiftDictionaryParent; }
            set
            {
                if (_ShiftDictionaryParent != value)
                {
                    _ShiftDictionaryParent = value;
                    RaisePropertyChanged("ShiftDictionaryParent");
                }
            }
        }

        #endregion

        #region ICollection

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollevtion"); }
        }

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }

        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set
            {
                _CompanyCollection = value;
                RaisePropertyChanged("CompanyCollection");
            }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }

        #endregion

        #region StringList Variables
        private List<string> _stringListParty;
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

        private List<string> _strListPlant;
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

        private List<ADM_M002> _strListCompany;
        public List<ADM_M002> StrListCompany
        {
            get { return _strListCompany; }
            set
            {
                if (_strListCompany != value)
                {
                    _strListCompany = value;
                    RaisePropertyChanged("StrListCompany");
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

        private List<string> _stringListMachine;
        public List<string> StringListMachine
        {
            get { return _stringListMachine; }
            set
            {
                if (_stringListMachine != value)
                {
                    _stringListMachine = value;
                }
            }
        }

        private List<ZADM_M007_P> _strListILD;
        public List<ZADM_M007_P> strListILD
        {
            get { return _strListILD; }
            set
            {
                if (_strListILD != value)
                {
                    _strListILD = value;
                    RaisePropertyChanged("strListILD");
                }
            }
        }

        private List<ZADM_M006_P> _strListInk;
        public List<ZADM_M006_P> strListInk
        {
            get { return _strListInk; }
            set
            {
                if (_strListInk != value)
                {
                    _strListInk = value;
                    RaisePropertyChanged("_strListInk");
                }
            }
        }

        private List<ADM_M042_P> _strListShift;
        public List<ADM_M042_P> strListShift
        {
            get { return _strListShift; }
            set
            {
                if (_strListShift != value)
                {
                    _strListShift = value;
                    RaisePropertyChanged("strListShift");
                }
            }
        }

        #endregion

        #region RelayCommands      
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand CommandForClearData { get; private set; }
        public RelayCommand<object> cmdMachine { get; private set; }
        public RelayCommand<object> cmdPlant { get; private set; }



        #endregion

        #region Constructor
        public MIS_PDI_Entry_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_PDI_Entry();
            ReportParametersEntity = new MIS_PDI_Entity();
            _dsReport = new List<Rpt_MIS_PDI_Entry>();
            ReportItemsDictionary = new Dictionary<string, string>();

            ReportItemsDictionary.Add("R001", "Item Wise Production");
            
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
            cmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            CommandForClearData = new RelayCommand(ClearData);

            cmdReport = new RelayCommand(DisplayReport);
            DefaultValues();
            LoadInitialData();

        }


        #endregion  foreach (int element in fibarray)

        #region User Defined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_PDI_Entry>(MC, Request, "MIS_PDI_Entry", "Production", "LoadAll", 0, "");


                //Load Data on Party
                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(FilterParty);


               //Company
                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                // Plant or Location
                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                //machine code

                //var machineListParent = (from o in MC.machineDetails
                //                         where o.machine_id.ToString() != null
                //                         select o).ToList();
                //_strListMachine = machineListParent;
                //machineDictionaryParent = _strListMachine.ToDictionary(X => X.machine_id.ToString(), X => (object)X.machinecode);

                var LocWiseMachine = (from o in MC.machineDetails
                                      where o.location_Id == ReportParametersEntity.location_Id
                                      select o).ToList();
                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.machineDetails.Select(x => x.machinecode.ToString()).ToList();

                
                //ILD
                var ILDListParent = (from o in MC.ILDDetails
                                     where o.ild != null
                                     select o).ToList();
                _strListILD = ILDListParent;
                ILDDictionaryParent = _strListILD.ToDictionary(X => X.ild.ToString(), X => (object)X.ild);

                //Ink
                var InkListParent = (from o in MC.InkDetails
                                     where o.ink.ToString() != null
                                     select o).ToList();
                _strListInk = InkListParent;
                InkDictionaryParent = _strListInk.ToDictionary(X => X.ink.ToString(), X => (object)X.ink);

                //Shift
                var ShiftListParent = (from o in MC.ShiftDetails
                                       where o.shift != null
                                       select o).ToList();
                _strListShift = ShiftListParent;
                ShiftDictionaryParent = _strListShift.ToDictionary(X => X.shift.ToString(), X => (object)X.shift);


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

            ReportParametersEntity.comp_code = AppSessionState.comp_code;
            ReportParametersEntity.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(0);
            ReportParametersEntity.ToDate = DateTime.Now;
        }
        private void ClearData()
        {
            try
            {
                ReportParametersEntity = new MIS_PDI_Entity();
                DefaultValues();
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
        private void DisplayReport()
        {
            CursorControl.SetBusyState();

            try
            {
                if (ReportParametersEntity.ReportCode.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParametersEntity.ReportCode.ToString() != "")
                {
                    if (ReportParametersEntity.PartyId == null) { ReportParametersEntity.PartyId = "All"; }
                    if (ReportParametersEntity.PartyNm == null) { ReportParametersEntity.PartyNm = "All"; }
                    if (ReportParametersEntity.ItemCode == null) { ReportParametersEntity.ItemCode = "All"; }
                    if (ReportParametersEntity.ItemName == null) { ReportParametersEntity.ItemName = "All"; }
                    if (ReportParametersEntity.ild == null) { ReportParametersEntity.ild = "All"; }
                    if (ReportParametersEntity.ink == null) { ReportParametersEntity.ink = "All"; }
                    if (ReportParametersEntity.shift == null) { ReportParametersEntity.shift = "All"; }
                    if (ReportParametersEntity.machine_id == null) { ReportParametersEntity.machine_id = 0; }
                    if (ReportParametersEntity.machinecode == null) { ReportParametersEntity.machinecode = "All"; }
                    
                }
                
                    
                    if (ReportParametersEntity.ReportCode != null)
                    {
                        string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy")  + "!@" + ReportParametersEntity.shift + "!@" + ReportParametersEntity.machinecode  + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink ;


                        dsReport = repository.GetDataWithReturnDomainObject<List<Rpt_MIS_PDI_Entry>>(dsReport, RequestParameter, "MIS_PDI_Entry", "Production", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                        objDataSource[2] = Result;


                        objDataSourceName[0] = "dsRpt_MIS_PDI_Entry";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");

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
                result.Add("PartyId", ReportParametersEntity.PartyId);
                result.Add("PartyNm", ReportParametersEntity.PartyNm);
                result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                result.Add("location_Id", ReportParametersEntity.location_Id);
                result.Add("comp_code", ReportParametersEntity.comp_code);
                result.Add("ink", ReportParametersEntity.ink);
                result.Add("ild", ReportParametersEntity.ild);
                result.Add("ReportName", ReportParametersEntity.ReportName);
                result.Add("machinecode", ReportParametersEntity.machinecode);
                result.Add("shift", ReportParametersEntity.shift);
                
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
                returnReportName = "ProductionReport.rdlc";
            }
            
            return returnReportName;
        }
        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParametersEntity.PartyId = "";
            foreach (ADM_M028_P temp in MC.PartyMaster)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParametersEntity.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

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

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParametersEntity.comp_code = POPUPEntityObject.comp_code;
                    ReportParametersEntity.CompName = POPUPEntityObject.CompName;
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
        private void InsertMachine(object InputValue)
        {

            string stringMachineCode = "";
            ReportParametersEntity.machinecode = "";
            foreach (ZADM_M013_P temp in MC.machineDetails)
            {
                if (temp.Select == true)
                {
                    stringMachineCode = stringMachineCode + "," + temp.machinecode;
                }
            }
            ReportParametersEntity.machinecode = stringMachineCode.ToString().TrimStart(new char[] { ',' });
        }
        private void InsertParty(object items, bool blNew, object sender)
        {
            throw new NotImplementedException();
        }
        private void InsertPlant(object InputValue)
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

                ReportParametersEntity.location_Id = POPUPEntityObject.location_Id;

                var LocWiseMachine = (from o in MC.machineDetails
                                      where o.location_Id == ReportParametersEntity.location_Id
                                      select o).ToList();


                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                MachineCollection.Refresh();
            }

        }
        #endregion

        #region Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region . Filter .
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

        
        private string _filterStringMachine;
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
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
                RaisePropertyChanged("FilterString_Company");
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

        #region Command Action
        protected override void OnCreateAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_PDI_Entity> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
