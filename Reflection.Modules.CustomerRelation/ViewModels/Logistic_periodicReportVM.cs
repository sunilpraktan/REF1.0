using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.IO;


namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class Logistic_periodicReportVM //: WindowViewModel<Logistic_periodicReport>, INotifyPropertyChanged
    {
        //#region
        //bool blNew = true;
        //WebServiceRepository<Logistic_periodicReport> repository = new WebServiceRepository<Logistic_periodicReport>();
        //WebServiceRepository<MultipleContextLogistic_periodicReport> repository_MC = new WebServiceRepository<MultipleContextLogistic_periodicReport>();
        //MultipleContextLogistic_periodicReport _MC = new MultipleContextLogistic_periodicReport();
        //Logistic_periodicReport aCC_T001 = new Logistic_periodicReport();
        //public MultipleContextLogistic_periodicReport MC
        //{
        //    get { return _MC; }
        //    set
        //    {
        //        if (_MC != value)
        //        {
        //            _MC = value;

        //            RaisePropertychanged("MC");
        //        }
        //    }
        //}


        //MultipleContextLogistic_periodicReport MC_temp = new MultipleContextLogistic_periodicReport();

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void RaisePropertychanged(string propertyname)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        //    }
        //}


        //private Dictionary<string, object> _items;

        //public Dictionary<string, object> Items
        //{
        //    get { return _items; }
        //    set
        //    {
        //        if (_items != value)
        //        {
        //            _items = value;
        //            RaisePropertychanged("Items");
        //        }
        //    }
        //}

        //private ObservableCollection<Logistic_periodicReport> _dgReportMaster;
        //public ObservableCollection<Logistic_periodicReport> dgReportMaster
        //{
        //    get { return _dgReportMaster; }
        //    set
        //    {
        //        if (_dgReportMaster != value)
        //        {
        //            _dgReportMaster = value;


        //            RaisePropertychanged("dgReportMaster");

        //        }
        //    }
        //}

        //private Logistic_periodicReport _SelectedParameter;
        //public Logistic_periodicReport SelectedParameter
        //{
        //    get
        //    {

        //        return _SelectedParameter;
        //    }
        //    set
        //    {
        //        if (_SelectedParameter != value)
        //        {
        //            _SelectedParameter = value;
        //            //this.ErrorExist = _SelectedZCRM_T002_A.HasErrors;
        //            RaisePropertychanged("SelectedParameter");

        //        }
        //    }
        //}
        //public RelayCommand<IList> SelectionChangedCommandgodown
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<IList> SelectionChangedCommandParty
        //{
        //    get;
        //    private set;
        //}
        //private ICollectionView _partyCollection;
        //public ICollectionView PartyCollection
        //{
        //    get { return _partyCollection; }
        //    set { _partyCollection = value; RaisePropertychanged("PartyCollection"); }
        //}

        //private ICollectionView _GodownCollection;
        //public ICollectionView GodownCollection
        //{
        //    get { return _GodownCollection; }
        //    set { _GodownCollection = value; RaisePropertychanged("GodownCollection"); }
        //}
        //private PeriodicReportMaster _SelectedLogistic_periodicReport;
        //public PeriodicReportMaster SelectedLogistic_periodicReport
        //{
        //    get
        //    {

        //        return _SelectedLogistic_periodicReport;
        //    }
        //    set
        //    {
        //        if (_SelectedLogistic_periodicReport != value)
        //        {
        //            _SelectedLogistic_periodicReport = value;
        //            //this.ErrorExist = _SelectedZCRM_T002_A.HasErrors;
        //            RaisePropertychanged("SelectedLogistic_periodicReport");

        //        }
        //    }
        //}

        //#endregion
        //#region ICollection
        //private ICollectionView _dataGridCollection;
        //public ICollectionView DataGridCollection
        //{
        //    get { return _dataGridCollection; }
        //    set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        //}


        //#endregion

        //# region RelayCommands
        //private RelayCommand _ReportCommand;
        //public RelayCommand ReportCommand
        //{
        //    get;
        //    private set;
        //}


        //private RelayCommand _ExportCommand;
        //public RelayCommand ExportCommand
        //{
        //    get;
        //    private set;
        //}

        //#endregion

        //#region Constructor
        //public Logistic_periodicReportVM()
        //    : base()
        //{
        //    SelectionChangedCommandParty = new RelayCommand<IList>(
        //  items =>
        //  {
        //      if (items == null)
        //      {
        //          return;
        //      }
        //      GetSelectedParty(items);

        //  });

        //    SelectionChangedCommandgodown = new RelayCommand<IList>(
        //items =>
        //{
        //    if (items == null)
        //    {
        //        return;
        //    }
        //    GetSelectedGodown(items);

        //});


        //    dgReportMaster = new ObservableCollection<Logistic_periodicReport>();
        //    SelectedParameter = new Logistic_periodicReport();
        //   // SelectedLogistic_periodicReport = new periodicReportParameter();
        //    ReportCommand = new RelayCommand(Load);
        //    ExportCommand = new RelayCommand(Export);
        //    LoadInitialData();
        //    SelectedLogistic_periodicReport.FromDate = DateTime.Now;
        //    SelectedLogistic_periodicReport.Todate = DateTime.Now;
        //}
        //#endregion

        //private void GetSelectedParty(IList partyList)
        //{

        //    IList list = partyList as IList;
        //    List<ADM_M028_PopUp_Report> Selectedpartylist = list.Cast<ADM_M028_PopUp_Report>().ToList();
        //    if (Selectedpartylist.Count > 0)
        //    {
        //        //SelectedParameter.supplier_id = Selectedpartylist[0].id;
        //        SelectedParameter.Customer = Selectedpartylist[0].PartyNm;

        //    }
        //}
        //private void GetSelectedGodown(IList partyList)
        //{

        //    IList list = partyList as IList;
        //    List<ADM_M003_PopUpwarehouse> Selectedpartylist = list.Cast<ADM_M003_PopUpwarehouse>().ToList();
        //    if (Selectedpartylist.Count > 0)
        //    {
        //        SelectedParameter.warehouse_id = Selectedpartylist[0].warehouse_id;
        //        SelectedParameter.Godown = Selectedpartylist[0].Warehouse_Name;

        //    }
        //}
        //private Dictionary<string, string> getParametersList()
        //{
        //    Dictionary<string, string> result = new Dictionary<string, string>();
        //    result.Add("FromDate", Convert.ToString(SelectedLogistic_periodicReport.FromDate));
        //    result.Add("ToDate", Convert.ToString(SelectedLogistic_periodicReport.Todate));
        //    return result;
        //}

        //private Dictionary<string, string> getParametersList1()
        //{
        //    Dictionary<string, string> result = new Dictionary<string, string>();

        //    return result;
        //}
        //private void LoadInitialData()
        //{

        //    MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextLogistic_periodicReport>(MC, "Logistic_periodicReport_Data", "Logistic_periodicReport", "CRM", "Logistic_periodicPartyData", 0, "");
        //    PartyCollection = CollectionViewSource.GetDefaultView(MC.partyDetails);
        //    PartyCollection.Filter = new Predicate<object>(FilterParty);

        //    GodownCollection = CollectionViewSource.GetDefaultView(MC.LocationDetails);
        //    GodownCollection.Filter = new Predicate<object>(FilterGodown);




        //}



      
        //private void Load()
        //{


        //    if(SelectedParameter.supplier_id==null)
        //    {
        //        SelectedParameter.supplier_id = 0;
        //    }
        //    if (SelectedParameter.warehouse_id == null)
        //    {
        //        SelectedParameter.warehouse_id = 0;
        //    }
        //    string request1 = Convert.ToDateTime(SelectedLogistic_periodicReport.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SelectedLogistic_periodicReport.Todate).ToString("MM/dd/yyyy") + "!@" + SelectedParameter.supplier_id + "!@" + AppSessionState.comp_code + "!@" + SelectedParameter.warehouse_id + "!@" + AppSessionState.location_Id;

        //    MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextLogistic_periodicReport>(MC, "Logistic_periodicReport_Data", "Logistic_periodicReport", "CRM", "Logistic_periodicReport", 0, request1);
            

        //    List<Logistic_periodicReport> POCollection = new List<Logistic_periodicReport>();
        //    ObjectSerializationService objSerialization = new ObjectSerializationService();
        //    string request = objSerialization.ObjectToXML(dgReportMaster);
        //    POCollection = (List<Logistic_periodicReport>)objSerialization.XMLToObject(request, POCollection);
        //    object objDS = dgReportMaster;
        //    ReportManager ReportManager = new ReportingServices.ReportManager();
        //    if (SelectedLogistic_periodicReport.ReportType.ToString() == "Stock Transfer From SPPL To Godown")
        //    {
        //        objDS = MC.PeriodicReportMaster;
        //        ReportManager.DisplayReport(objDS, "dslogisticdata", "\\Admin\\StockTransferFromSPPLtoGodown.rdlc", getParametersList());
        //    }
        //    else if (SelectedLogistic_periodicReport.ReportType.ToString() == "Stock Transfer From Godown To Party")
        //    {
        //        objDS = MC.PeriodicReportGodownToPartyMaster;
        //        ReportManager.DisplayReport(objDS, "dslogisticdata", "\\Admin\\StockTransferFromGodownToParty.rdlc", getParametersList());
        //    }
        //    else if (SelectedLogistic_periodicReport.ReportType.ToString() == "Itemwise Current Stock")
        //    {
        //        objDS = MC.ItemStock;
        //        ReportManager.DisplayReport(objDS, "dslogisticdata", "\\Admin\\ItemWiseStock.rdlc", getParametersList1());
        //    }


        //}
        //private string _filterString_party;
        //public string FilterString_party
        //{
        //    get { return _filterString_party; }
        //    set
        //    {
        //        _filterString_party = value;
        //        RaisePropertychanged("FilterString_party");
        //        FilterCollectionParty();
        //    }
        //}
        //private void FilterCollectionParty()
        //{
        //    if (_partyCollection != null)
        //    {
        //        _partyCollection.Refresh();
        //    }
        //}
        //public bool FilterParty(object obj)
        //{
        //    var data = obj as ADM_M028_PopUp_Report;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString_party))
        //        {
        //            return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower())||
        //                (data.EmailId != null && data.EmailId.ToString().ToLower().Contains(_filterString_party.ToLower())));
        //        }
        //        return true;
        //    }
        //    return false;
        //}


        //private string _filterString_godown;
        //public string FilterString_godown
        //{
        //    get { return _filterString_godown; }
        //    set
        //    {
        //        _filterString_godown = value;
        //        RaisePropertychanged("FilterString_godown");
        //        FilterCollectiongodown();
        //    }
        //}
        //private void FilterCollectiongodown()
        //{
        //    if (_GodownCollection != null)
        //    {
        //        _GodownCollection.Refresh();
        //    }
        //}
        //public bool FilterGodown(object obj)
        //{
        //    var data = obj as ADM_M003_PopUpwarehouse;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterString_godown))
        //        {
        //            return (data.Warehouse_Name != null && data.Warehouse_Name.ToString().ToLower().Contains(_filterString_party.ToLower()));
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        //protected override void OnSaveAction(InquiryActionResult<Logistic_periodicReport> result)
        //{
        //    try
        //    {



        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        //protected override void OnCreateAction(InquiryActionResult<Logistic_periodicReport> result)
        //{

        //}
        //protected override void OnRemoveAction(InquiryActionResult<Logistic_periodicReport> result)
        //{

        //}
        //protected override void OnDiscardAction(InquiryActionResult<Logistic_periodicReport> result)
        //{

        //}
        //protected override void OnFevoriteAction(InquiryActionResult<Logistic_periodicReport> result)
        //{

        //}
        //protected override void OnFlipAction(InquiryActionResult<Logistic_periodicReport> result)
        //{

        //}
        //protected override void OnHelpAction(InquiryActionResult<Logistic_periodicReport> result)
        //{
        //}
        //protected override void OnPrintAction(InquiryActionResult<Logistic_periodicReport> result)
        //{

          

        //}
        ////protected override void OnExportAction(InquiryActionResult<Logistic_periodicReport> result)
        ////{
        ////    try
        ////    {
        ////        List<Logistic_periodicReport> Export_List = new List<Logistic_periodicReport>();
        ////        foreach (var o in DataGridCollection)
        ////        {
        ////            Logistic_periodicReport Data = o as Logistic_periodicReport;
        ////            Export_List.Add(Data);
        ////        }

        ////        //--------------------------------------

        ////        ExportToExcel<Logistic_periodicReport, List<Logistic_periodicReport>> export = new ExportToExcel<Logistic_periodicReport, List<Logistic_periodicReport>>();
        ////        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        ////        export.dataToPrint = (List<Logistic_periodicReport>)view.SourceCollection;

        ////        export.GenerateReport();
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        ////        showMessageService.ButtonSetup = DialogButton.Ok;
        ////        showMessageService.Caption = "Message";
        ////        showMessageService.Text = String.Format(ex.Message, this.Title);
        ////        showMessageService.ShowMessage();
        ////    }

        ////}

        //private void Export()
        //{
        //    string request1 = Convert.ToDateTime(SelectedLogistic_periodicReport.FromDate).ToString("MM/dd/yyyy") + "!@" +Convert.ToDateTime(SelectedLogistic_periodicReport.Todate).ToString("MM/dd/yyyy")  + "!@" + SelectedParameter.supplier_id + "!@" + AppSessionState.location_Id + "!@" + SelectedParameter.warehouse_id;

        //    MC_temp = repository_MC.GetDataWithReturnDomainObject<MultipleContextLogistic_periodicReport>(MC, "Logistic_periodicReport_Data", "Logistic_periodicReport", "CRM", "Logistic_periodicReport", 0, request1);            

        //    ReportManager ReportManager = new ReportingServices.ReportManager();
        //    var MailID = (from o in MC.partyDetails
        //                  //where o.PartyId == SelectedParameter.supplier_id
        //                  select o).ToList();

        //    string str_mail = MailID[0].EmailId;

           
        //    //AppSessionState.MailAccount.MailID = MailID[0].EmailId;
        //    {

        //        //ReportManager.SendReport(str_mail, MC_temp.PeriodicReportGodownToPartyMaster, "dslogisticdata", "\\Admin\\StockTransferFromGodownToParty.rdlc", getParametersList());
        //        //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        //showMessageService.ButtonSetup = DialogButton.Ok;
        //        //showMessageService.Caption = "Message";
        //        //showMessageService.Text = String.Format("Mail Send Successfully", this.Title);
        //        //showMessageService.ShowMessage();
        //    }
         
        //    //ReportDataSource rds = new ReportDataSource("dslogisticdata", MC.PeriodicReportGodownToPartyMaster);          
        //    //Warning[] warnings;
        //    //string[] streamIds;
        //    //string mimeType = string.Empty;
        //    //string encoding = string.Empty;
        //    //string extension = string.Empty;

        //    //// Setup the report viewer object and get the array of bytes
        //    //ReportViewer viewer = new ReportViewer();
        //    //viewer.ProcessingMode = ProcessingMode.Local;
        //    //viewer.LocalReport.ReportPath = "\\Admin\\StockTransferFromGodownToParty.rdlc";
        //    //viewer.LocalReport.DataSources.Add(rds); // Add datasource here

        //    //string filename = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "StockTransferFromGodownToParty.PDF");

        //    //byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        //    //using (FileStream fs = File.Create(filename))
        //    //{
        //    //    fs.Write(bytes, 0, bytes.Length);
        //    //    fs.Close();
        //    //}
        //    //string str_mail = "";
        //    // var MailID = (from o in  MC.partyDetails
        //    //                                         where o.id == SelectedParameter.supplier_id
        //    //                                         select o).ToList();

        //    // //AppSessionState.MailAccount.MailID = MailID[0].EmailId;    

        //    //Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, AppSessionState.MailAccount.MailID, str_mail, str_mail, "Wearhouse Stock Statement", "<h1>Stock Update!</h1><p>Dear Sir!</p><p>This is the updated statement of stock available for you at our Wearhouse. </p><p>-M/s. Shweta Printpack Pvt. Ltd. </p>", filename); 


        //}
       


    }

}

