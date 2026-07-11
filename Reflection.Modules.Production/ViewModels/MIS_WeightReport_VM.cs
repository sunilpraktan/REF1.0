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
using Reflection.BusinessEntity.Production;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    class MIS_WeightReport_VM : WorkspaceViewModel<MIS_Pro_PeriodicEntity>
    {
        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_Pro_PeriodicEntity> repository_MC = new WebServiceRepository<MultipleContext_MIS_Pro_PeriodicEntity>();
        ObjectSerializationService obj = new ObjectSerializationService();
        //Report Repository
        WebServiceRepository<List<Rpt_MIS_Periodic1>> repository = new WebServiceRepository<List<Rpt_MIS_Periodic1>>();
        MultipleContext_MIS_Pro_PeriodicEntity _MC = new MultipleContext_MIS_Pro_PeriodicEntity();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MIS_WeightReport_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompany
        {
            get { return _ASCompany; }
            set
            {
                if (_ASCompany != value)
                {
                    _ASCompany = value;
                    RaisePropertyChanged("ASCompany");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value;
                    RaisePropertyChanged("ASLocation");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASavgweight { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASavgweight
        {
            get { return _ASavgweight; }
            set
            {
                if (_ASavgweight != value)
                {
                    _ASavgweight = value;
                    RaisePropertyChanged("ASavgweight");
                }
            }
        }
        #endregion


        #region Declarations   
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public MultipleContext_MIS_Pro_PeriodicEntity MC
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

        private MIS_Pro_PeriodicEntity _ReportParametersEntity;
        public MIS_Pro_PeriodicEntity ReportParametersEntity
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

        private List<Rpt_MIS_Periodic1> _dsReport;
        public List<Rpt_MIS_Periodic1> dsReport
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


        #region Relay Commands Declaration
        public RelayCommand<object> CmdCompany { get; private set; }
        public RelayCommand<object> CmdLocation { get; private set; }

        public RelayCommand<object> Cmdavgwwight { get; private set; }
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion


        #region
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
        #endregion


        #region Constructor
        public MIS_WeightReport_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_Pro_PeriodicEntity();
            ReportParametersEntity = new MIS_Pro_PeriodicEntity();
            _dsReport = new List<Rpt_MIS_Periodic1>();
            ReportItemsDictionary = new Dictionary<string, string>();

            ReportItemsDictionary.Add("R028", "Average Blanks Weight");
            ReportItemsDictionary.Add("R027", "Average Weight Finish Goods");
            ReportItemsDictionary.Add("R033", "Tip Length Report");


            DefaultValues();
            LoadInitialData();

        }

        #endregion


        #region User Defined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_Pro_PeriodicEntity>(MC, Request, "MIS_Pro_Periodics", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                CmdLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                Cmdavgwwight = new RelayCommand<object>(items => { if (items == null) { return; } InsertAvgWeght(items); });
                cmdReport = new RelayCommand(DisplayReport);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_P)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002_P)o).comp_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>(MC.CompanyList, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003_P)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(MC.LoacationList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZSCM_T001_A_P)x).average_wt_no);
                TheFilter = (o, prefix) => (((ZSCM_T001_A_P)o).average_wt_no ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASavgweight = new AutoSuggestTextViewModel<dynamic>(MC.AvgWeightList, TheFilter, SuggestedValue, "average_wt_no", true);
                ASavgweight.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            //ReportParametersEntity.fin_year = AppSessionState.FinYear;
            ReportParametersEntity.location_Id = AppSessionState.location_Id;
            ReportParametersEntity.ts_code = ts_code_vm;
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(0);
            ReportParametersEntity.ToDate = DateTime.Now;
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
                if (ReportParametersEntity.ReportCode.ToString() != "")
                {
                    if (ReportParametersEntity.PartyId == null) { ReportParametersEntity.PartyId = "All"; }
                    if (ReportParametersEntity.PartyNm == null) { ReportParametersEntity.PartyNm = "All"; }
                    if (ReportParametersEntity.ItemCode == null) { ReportParametersEntity.ItemCode = "All"; }
                    if (ReportParametersEntity.ItemName == null) { ReportParametersEntity.ItemName = "All"; }
                    if (ReportParametersEntity.EmpId == null) { ReportParametersEntity.EmpId = "All"; }
                    if (ReportParametersEntity.CatCode == null) { ReportParametersEntity.CatCode = "All"; }
                    if (ReportParametersEntity.CatName == null) { ReportParametersEntity.CatName = "All"; }
                    if (ReportParametersEntity.SubCatCode == null) { ReportParametersEntity.SubCatCode = "All"; }
                    if (ReportParametersEntity.ItemTypeCd == null) { ReportParametersEntity.ItemTypeCd = "All"; }
                    if (ReportParametersEntity.SubItemTpCd == null) { ReportParametersEntity.SubItemTpCd = "All"; }
                    if (ReportParametersEntity.TipType == null) { ReportParametersEntity.TipType = "All"; }
                    if (ReportParametersEntity.grade_code == null) { ReportParametersEntity.grade_code = "All"; }
                    if (ReportParametersEntity.local_export == null) { ReportParametersEntity.local_export = "All"; }
                    if (ReportParametersEntity.description == null) { ReportParametersEntity.description = "All"; }
                    if (ReportParametersEntity.wire_type == null) { ReportParametersEntity.wire_type = "All"; }
                    if (ReportParametersEntity.ball_type == null) { ReportParametersEntity.ball_type = "All"; }
                    if (ReportParametersEntity.ild == null) { ReportParametersEntity.ild = "All"; }
                    if (ReportParametersEntity.ink == null) { ReportParametersEntity.ink = "All"; }
                    if (ReportParametersEntity.SalesAccount == null) { ReportParametersEntity.SalesAccount = "All"; }
                    if (ReportParametersEntity.Blank == null) { ReportParametersEntity.Blank = "All"; }
                    if (ReportParametersEntity.shift == null) { ReportParametersEntity.shift = "All"; }
                    if (ReportParametersEntity.machine_id == null) { ReportParametersEntity.machine_id = 0; }
                    //if (ReportParametersEntity.unit_code == null) { ReportParametersEntity.unit_code = "All"; }
                    if (ReportParametersEntity.machinecode == null) { ReportParametersEntity.machinecode = "All"; }
                    if (ReportParametersEntity.mctype == null) { ReportParametersEntity.mctype = "All"; }

                }
                if (ReportParametersEntity.comp_code == null || ReportParametersEntity.comp_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Company Code is Required");
                    showMessageService.ShowMessage();
                }
                else
                {
                    ReportParametersEntity = ReportParametersEntity;
                    if (ReportParametersEntity.ReportCode.ToString() != "")
                    {
                        ReportParametersEntity.Month = Convert.ToString(System.DateTime.Now.ToString("MMMM"));

                        string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.TipType + "!@" + ReportParametersEntity.unit_code + "!@" + ReportParametersEntity.shift + "!@" + ReportParametersEntity.machinecode + "!@" + ReportParametersEntity.wire_type + "!@" + ReportParametersEntity.ball_type + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink + "!@" + ReportParametersEntity.Blank + "!@" + ReportParametersEntity.mctype + "!@" + ReportParametersEntity.grade_code + "!@" + ReportParametersEntity.id;

                        dsReport = repository.GetDataWithReturnDomainObject<List<Rpt_MIS_Periodic1>>(dsReport, RequestParameter, "MIS_Pro_Periodics", "Production", "", 0, RequestParameter);

                        object[] objDataSource = new object[4];
                        string[] objDataSourceName = new string[4];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                        objDataSource[2] = Result;

                        objDataSource[3] = dsReport;

                        objDataSourceName[0] = "dsRpt_MIS_Periodic1";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";
                        objDataSourceName[3] = "AvgBlnkWt_DS";

                        if (ReportParametersEntity.ReportCode.ToString() == "R027")
                        {
                            ReportManager ReportManager = new ReportManager();

                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");
                        }
                        else
                        {
                            ReportManager ReportManager = new ReportManager();

                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Store\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");
                           // ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Store\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");
                        }
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                result.Add("location_Id", ReportParametersEntity.location_Id);
                result.Add("comp_code", ReportParametersEntity.comp_code);
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
            if (ReportCode == "R028")
            { returnReportName = "AvgBlankWtReport.rdlc"; }
            else if (ReportCode == "R027")
            { returnReportName = "AverageWeightReport.rdlc"; }
            else if (ReportCode == "R033")
            { returnReportName = "TipLength.rdlc"; }
            return returnReportName;
        }

        private void InsertCompany(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M002_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.CompanyList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_P>().ToList()[0];
                    }

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
                #endregion

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
                ADM_M003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.LoacationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        ReportParametersEntity.location_Id = POPUPEntityObject.location_Id;
                        ReportParametersEntity.LoctnNm = POPUPEntityObject.LoctnNm;
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
                #endregion

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

        private void InsertAvgWeght(object InputValue)
        {
            try
            {
                string Request = "";
                ZSCM_T001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.AvgWeightList.Where(x => x.average_wt_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZSCM_T001_A_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {
                        ReportParametersEntity.id = POPUPEntityObject.id;
                        ReportParametersEntity.average_wt_no = POPUPEntityObject.average_wt_no;

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
                #endregion

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
                    Request = ReportParametersEntity.client + "!@" + ReportParametersEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        #endregion       









        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
