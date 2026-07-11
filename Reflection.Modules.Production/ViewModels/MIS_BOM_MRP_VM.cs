using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Production;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.WebServices.Gateway;
using Reflection.ReportingServices;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections;
using System.Collections.ObjectModel;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    public class MIS_BOM_MRP_VM : WorkspaceViewModel<MIS_BOM_MRPEntity>
    {
        #region Variables Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool blNew = true;
        WebServiceRepository<List<Rpt_BillOfMaterial>> repository = new WebServiceRepository<List<Rpt_BillOfMaterial>>();
        WebServiceRepository<MM_T003> repository_indent = new WebServiceRepository<MM_T003>();
        WebServiceRepository<PUR_T001_A> repository_Req = new WebServiceRepository<PUR_T001_A>();
        WebServiceRepository<MultipleContextMIS_BOM_MRP> repository_MC = new WebServiceRepository<MultipleContextMIS_BOM_MRP>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMIS_BOM_MRP _MC = new MultipleContextMIS_BOM_MRP();
        public MultipleContextMIS_BOM_MRP MC
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



        private MIS_BOM_MRPEntity _ReportParameters;
        public MIS_BOM_MRPEntity ReportParameters
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

        private List<Rpt_BillOfMaterial> _dsReport;
        public List<Rpt_BillOfMaterial> dsReport
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

        //private List<Rpt_BillOfMaterial> _Rpt_Bom;
        //public List<Rpt_BillOfMaterial> Rpt_Bom
        //{
        //    get { return _Rpt_Bom; }
        //    set
        //    {
        //        if (_Rpt_Bom != value)
        //        {
        //            _Rpt_Bom = value;
        //            RaisePropertyChanged("Rpt_Bom");
        //        }
        //    }
        //}

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

        private ObservableCollection<MM_T003_A> _ItemsEntity;
        public ObservableCollection<MM_T003_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private MM_T003 _MasterEntityIndent;
        public MM_T003 MasterEntityIndent
        {
            get { return _MasterEntityIndent; }
            set
            {
                if (_MasterEntityIndent != value)
                {
                    _MasterEntityIndent = value; RaisePropertyChanged("MasterEntityIndent");

                }
            }
        }

        private PUR_T001_A _MasterEntityRequisition;
        public PUR_T001_A MasterEntityRequisition
        {
            get { return _MasterEntityRequisition; }
            set
            {
                if (_MasterEntityRequisition != value)
                {
                    _MasterEntityRequisition = value; RaisePropertyChanged("MasterEntityRequisition");

                }
            }
        }

        private ObservableCollection<PUR_T001_B> _ItemsEntity1;
        public ObservableCollection<PUR_T001_B> ItemsEntity1
        {
            get { return _ItemsEntity1; }
            set
            {
                if (_ItemsEntity1 != value)
                {
                    _ItemsEntity1 = value; RaisePropertyChanged("ItemsEntity1");
                }
            }
        }

        private bool _MakeItDisable = true;
        public bool MakeItDisable
        {
            get { return _MakeItDisable; }
            set
            {
                if (_MakeItDisable != value)
                {
                    _MakeItDisable = value; RaisePropertyChanged("MakeItDisable");
                }
            }
        }

        private bool _MakeItDisable1 = true;
        public bool MakeItDisable1
        {
            get { return _MakeItDisable1; }
            set
            {
                if (_MakeItDisable1 != value)
                {
                    _MakeItDisable1 = value; RaisePropertyChanged("MakeItDisable1");
                }
            }
        }
        #endregion

        #region ICollection
        private ICollectionView _BOMCollection;
        public ICollectionView BOMCollection
        {
            get { return _BOMCollection; }
            set { _BOMCollection = value; RaisePropertyChanged("BOMCollection"); }
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

        private ICollectionView _UnitCodeCollection;
        public ICollectionView UnitCodeCollection
        {
            get { return _UnitCodeCollection; }
            set { _UnitCodeCollection = value; RaisePropertyChanged("UnitCodeCollection"); }
        }
        #endregion

        #region StringList Variables

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

        private List<string> _strListBOM;
        public List<string> strListBOM
        {
            get { return _strListBOM; }
            set
            {
                if (_strListBOM != value)
                {
                    _strListBOM = value;
                }
            }
        }

        List<string> _strListUnit;
        public List<string> StringListUnit
        {
            get { return _strListUnit; }
            set
            {
                if (_strListUnit != value)
                {
                    _strListUnit = value;
                }
            }
        }


        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdBOM { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand CMDIndent { get; private set; }
        public RelayCommand CMDRequisition { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor
        public MIS_BOM_MRP_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_BOM_MRP();
            ReportParameters = new MIS_BOM_MRPEntity();
            _dsReport = new List<Rpt_BillOfMaterial>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "BOM MRP Report");
            MakeItDisable = true;
            MakeItDisable1 = true;

            
            DefaultValues();
            LoadInitialData();

        }
        public MIS_BOM_MRP_VM(string ts_code,string doc_no)
           : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_BOM_MRP();
            ReportParameters = new MIS_BOM_MRPEntity();
            _dsReport = new List<Rpt_BillOfMaterial>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "BOM MRP Report");
            MakeItDisable = true;
            MakeItDisable1 = true;


            DefaultValues();
            LoadInitialData();

        }


        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_BOM_MRP>(MC, Request, "MIS_BOM_MRP", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                cmdBOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertBOM(items); });
                cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnitCode(items); });
                CommandReport = new RelayCommand(DisplayReport);
                CMDIndent = new RelayCommand(Indent);
                CMDRequisition = new RelayCommand(Requisition);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                BOMCollection = CollectionViewSource.GetDefaultView(MC.BOMList.ToList());
                BOMCollection.Filter = new Predicate<object>(FilterBOM);
                strListBOM = MC.BOMList.Select(x => x.doc_no).ToList();

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();
               
                UnitCodeCollection  = CollectionViewSource.GetDefaultView(MC.UnitList.ToList());
                UnitCodeCollection.Filter = new Predicate<object>(FilterUnit);
                StringListUnit = MC.UnitList.Select(x => x.unit_code).ToList();
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
            ReportParameters.client = AppSessionState.client;
            ReportParameters.location_Id = AppSessionState.location_Id;
            ReportParameters.ts_code = ts_code_vm;
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            // LocalVariable = aCC_T001.PartyId;
            //this.ErrorExist = aCC_T001.HasErrors;
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

                else
                {
                    if (ReportParameters.qty != null || ReportParameters.qty.ToString() != "")
                    {


                        if (ReportParameters.doc_no == null) { ReportParameters.doc_no = "All"; }

                        string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + ReportParameters.qty + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.unit_code;
                        dsReport = repository.GetDataWithReturnDomainObject<List<Rpt_BillOfMaterial>>(dsReport, RequestParameter, "MIS_BOM_MRP", "Production", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                        objDataSource[2] = Result;

                        objDataSourceName[0] = "dsRpt_BillOfMaterial";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");
                        Calculations();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Quantity");
                        showMessageService.ShowMessage();
                    }
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
        private void Calculations()
        {
            foreach (var item in dsReport)
            {

                var tempShort = ((item.current_stock + item.po_qty) - item.res_stock);
                if (tempShort > item.Quantity)
                {
                    item.req_qty = Convert.ToDecimal(0.0);
                }
                else
                {
                    item.req_qty = (((item.current_stock + item.po_qty) - item.res_stock) - item.Quantity);
                    decimal Tempreq_qty = Convert.ToDecimal(item.req_qty);
                    item.req_qty = Math.Abs(Tempreq_qty);
                }

            }

        }
        private void Indent()
        {
            try
            {
                if (dsReport.Count > 0)
                {
                    List<Rpt_BillOfMaterial> Rpt_Bom = new List<Rpt_BillOfMaterial>();
                    MasterEntityIndent = new MM_T003();
                    ItemsEntity = new ObservableCollection<MM_T003_A>();

                    foreach (var item in dsReport)
                    {
                        if (item.Quantity < item.current_stock && item.current_stock >= 0)
                        {
                            Rpt_Bom.Add(item);

                            ItemsEntity.Add(new MM_T003_A()
                            {
                                id = 0,
                                doc_cat = "IO",
                                doc_type = "IO",
                                active = "1",
                                t_status = "01",
                                location_id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                item_code = item.ChildItem,
                                item_name = item.ItemCode,
                                qty = item.Quantity,
                                unit_code = item.unit_code,

                            });

                        }
                        else if (item.Quantity > item.current_stock && item.current_stock >= 0)
                        {
                            Rpt_Bom.Add(item);
                            ItemsEntity.Add(new MM_T003_A()
                            {
                                id = 0,
                                doc_cat = "IO",
                                doc_type = "IO",
                                active = "1",
                                t_status = "01",
                                location_id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                item_code = item.ChildItem,
                                item_name = item.ItemCode,
                                qty = item.Quantity,
                                unit_code = item.unit_code,

                            });
                        }
                    }

                    MasterEntityIndent.doc_type = "IO";
                    MasterEntityIndent.doc_cat = "IO";
                    MasterEntityIndent.req_type = "Standard";
                    MasterEntityIndent.pr_code = "4";
                    MasterEntityIndent.doc_date = DateTime.Now;
                    MasterEntityIndent.emp_id = AppSessionState.EmpId;
                    MasterEntityIndent.dept_code = "10";
                    MasterEntityIndent.t_status = "01";
                    MasterEntityIndent.deadline = DateTime.Now;
                    MasterEntityIndent.active = "1";
                    MasterEntityIndent.bom_no = ReportParameters.doc_no;
                    MasterEntityIndent.location_id = AppSessionState.location_Id;
                    MasterEntityIndent.comp_code = AppSessionState.comp_code;

                    MasterEntityIndent.XDOC_A = obj.ObjectToXML(ItemsEntity);
                    this.MasterEntityIndent.EndEdit();
                    MasterEntityIndent = repository_indent.SaveWithReturnDomainObject<MM_T003>(MasterEntityIndent, "IndentOrder", "SCM");

                    if (MasterEntityIndent.doc_no != " " || MasterEntityIndent.doc_no != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Indent Order Created For :{0}", MasterEntityIndent.doc_no);
                        showMessageService.ShowMessage();
                    }
                    MakeItDisable = false;
                }

                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Check Report First Then Click On Indent Button");
                    showMessageService.ShowMessage();
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
        private void Requisition()
        {
            try
            {
                if (dsReport.Count > 0)
                {
                    List<Rpt_BillOfMaterial> Rpt_Bom = new List<Rpt_BillOfMaterial>();
                    MasterEntityRequisition = new PUR_T001_A();
                    ItemsEntity1 = new ObservableCollection<PUR_T001_B>();

                    foreach (var item in dsReport)
                    {
                        if (item.req_qty != 0 && item.current_stock < item.Quantity)
                        {
                            Rpt_Bom.Add(item);
                        }
                    }

                    MasterEntityRequisition.doc_type = "RQ";
                    MasterEntityRequisition.doc_cat = "RQ";
                    //MasterEntityRequisition.priority = 4;
                    MasterEntityRequisition.req_type = "Standard";
                    MasterEntityRequisition.t_status = "Draft";
                    MasterEntityRequisition.date_start = System.DateTime.Now;
                    MasterEntityRequisition.deadline = System.DateTime.Now;
                    MasterEntityRequisition.EmpId = AppSessionState.EmpId;
                    MasterEntityRequisition.active = true;
                    MasterEntityRequisition.add_by = AppSessionState.UserID;
                    MasterEntityRequisition.editby = AppSessionState.UserID;
                    MasterEntityRequisition.add_date = System.DateTime.Now;
                    MasterEntityRequisition.edit_date = System.DateTime.Now;
                    MasterEntityRequisition.comp_code = AppSessionState.comp_code;
                    MasterEntityRequisition.location_Id = AppSessionState.location_Id;
                    MasterEntityRequisition.po_code = AppSessionState.po_code;
                    MasterEntityRequisition.pg_code = AppSessionState.pg_code;

                    for (int i = 0; i < Rpt_Bom.Count; i++)
                    {
                        ItemsEntity1.Add(new PUR_T001_B()
                        {
                            id = 0,
                            active = true,
                            t_status = "Draft",
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            add_date = System.DateTime.Now,
                            edit_date = System.DateTime.Now,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            ItemCode = Rpt_Bom[i].ChildItem,
                            description = Rpt_Bom[i].ItemCode,
                            qty = Rpt_Bom[i].req_qty,
                            unit_code = Rpt_Bom[i].unit_code,
                            po_code = AppSessionState.po_code,
                            pg_code = AppSessionState.pg_code,

                        });
                    }

                    MasterEntityRequisition.XmlDataDocument_PUR_T001_B = obj.ObjectToXML(ItemsEntity1);
                    this.MasterEntityRequisition.EndEdit();
                    MasterEntityRequisition = repository_Req.SaveWithReturnDomainObject<PUR_T001_A>(MasterEntityRequisition, "PurchaseRequisition", "Procurement");

                    if (MasterEntityRequisition.req_no != " " || MasterEntityRequisition.req_no != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Purchase Requisition Created For:{0}", MasterEntityRequisition.req_no);
                        showMessageService.ShowMessage();
                    }
                    MakeItDisable1 = false;

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Check Report First Then Click Requisition Button");
                    showMessageService.ShowMessage();
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
                result.Add("prepare_by", AppSessionState.Name);
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("ItemName", ReportParameters.ItemName);
                result.Add("ItemCode", ReportParameters.ItemCode);


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
                returnReportName = "BillOfMaterialMRP.rdlc";
            }

            return returnReportName;
        }

        private void InsertBOM(object InputValue)
        {
            string Request = "";
            ENG_T001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BOMList.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.doc_no = POPUPEntityObject.doc_no;
                ReportParameters.ItemName = POPUPEntityObject.ItemName;
                ReportParameters.ItemCode = POPUPEntityObject.ItemCode;
                MakeItDisable = true;
                MakeItDisable1 = true;
                if(dsReport != null )
                {
                    dsReport.Clear();
                   // ItemsEntity.Clear();
                }
                
                
            }


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
        private void InsertUnitCode(object InputValue)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.unit_code = POPUPEntityObject.unit_code;
                ReportParameters.unit_name = POPUPEntityObject.unit_name;
              
                MakeItDisable = true;
                MakeItDisable1 = true;
                if (dsReport != null)
                {
                    dsReport.Clear();
                    // ItemsEntity.Clear();
                }


            }


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
                    Request = ReportParameters.client + "!@" + ReportParameters.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Filter

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


        private string _filterStringBOM;
        public string filterStringBOM
        {
            get { return _filterStringBOM; }
            set
            {
                _filterStringBOM = value;
                RaisePropertyChanged("filterStringBOM");
                Filter_BOM();
            }
        }
        private void Filter_BOM()
        {
            if (_BOMCollection != null)
            {
                _BOMCollection.Refresh();
            }
        }
        public bool FilterBOM(object obj)
        {
            var data = obj as ENG_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringBOM))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterStringBOM.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringBOM.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringBOM.ToLower()));

                }
                return true;
            }
            return false;
        }


        private string _filterStringUnit;
        public string filterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("filterStringUnit");
                Filter_Unit();
            }
        }
        private void Filter_Unit()
        {
            if (_UnitCodeCollection != null)
            {
                _UnitCodeCollection.Refresh();
            }
        }
        public bool FilterUnit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower())) ||
                           (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()));       
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
        protected override void OnCreateAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_BOM_MRPEntity> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
