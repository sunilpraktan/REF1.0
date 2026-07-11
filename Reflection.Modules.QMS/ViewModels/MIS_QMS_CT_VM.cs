using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using Reflection.ReportingServices;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class MIS_QMS_CT_VM : WorkspaceViewModel<MIS_QMS_CTReport>
    {
        #region Variables Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool blNew = true;
        WebServiceRepository<List<RptMISInspection>> repository = new WebServiceRepository<List<RptMISInspection>>();
        WebServiceRepository<MultipleContextMIS_QMS_CT> repository_MC = new WebServiceRepository<MultipleContextMIS_QMS_CT>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContextMIS_QMS_CT _MC = new MultipleContextMIS_QMS_CT();
        public MultipleContextMIS_QMS_CT MC
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

        private MIS_QMS_CTReport _ReportParameters;
        public MIS_QMS_CTReport ReportParameters
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

        private List<RptMISInspection> _dsReport;
        public List<RptMISInspection> dsReport
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

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MIS_QMS_CT_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParty
        {
            get { return _ASParty; }
            set
            {
                if (_ASParty != value)
                {
                    _ASParty = value; RaisePropertyChanged("ASParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInstrument { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInstrument
        {
            get { return _ASInstrument; }
            set
            {
                if (_ASInstrument != value)
                {
                    _ASInstrument = value; RaisePropertyChanged("ASInstrument");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTest { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTest
        {
            get { return _ASTest; }
            set
            {
                if (_ASTest != value)
                {
                    _ASTest = value; RaisePropertyChanged("ASTest");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLab { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLab
        {
            get { return _ASLab; }
            set
            {
                if (_ASLab != value)
                {
                    _ASLab = value; RaisePropertyChanged("ASLab");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInspType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInspType
        {
            get { return _ASInspType; }
            set
            {
                if (_ASInspType != value)
                {
                    _ASInspType = value; RaisePropertyChanged("ASInspType");
                }
            }
        }

        #endregion

        #region RelayCommands  
        public RelayCommand<object> CmdReport { get; private set; }
        public RelayCommand<object> cmdEmp { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }

        #endregion

        #region Constructor
        public MIS_QMS_CT_VM() : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_QMS_CT();
            ReportParameters = new MIS_QMS_CTReport();
            dsReport = new List<RptMISInspection>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Due List/Calender");
            ItemsDictionary.Add("R002", "OverDues");
            ItemsDictionary.Add("R003", "Inspection History");
            LoadInitialData();
            DefaultValues();
        }
        public MIS_QMS_CT_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_QMS_CT();
            ReportParameters = new MIS_QMS_CTReport();
            dsReport = new List<RptMISInspection>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Due List/Calender");
            ItemsDictionary.Add("R002", "OverDues");
            ItemsDictionary.Add("R003", "Inspection History");
            LoadInitialData();
            DefaultValues();
        }
        public MIS_QMS_CT_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_QMS_CT();
            ReportParameters = new MIS_QMS_CTReport();
            dsReport = new List<RptMISInspection>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Due List/Calender");
            ItemsDictionary.Add("R002", "OverDues");
            ItemsDictionary.Add("R003", "Inspection History");
            LoadInitialData();
            DefaultValues();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                CmdReport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DisplayReport(); });

                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_QMS_CT>(MC, Request, "MIS_QMS_CTReport", "QMS", "LoadInitialData", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm ?? "");
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToLower());
                ASParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                ASParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToLower()) || (((QMS_M003_P)o).inst_name ?? "").ToLower().Contains(prefix.ToLower());
                ASInstrument = new AutoSuggestTextViewModel<dynamic>(MC.Instrument, TheFilter, SuggestedValue, "inst_name", true);
                ASInstrument.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009Flip)x).test_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M009Flip)o).test_code ?? "").ToLower().Contains(prefix.ToLower()) || (((QMS_M009Flip)o).test_name ?? "").ToLower().Contains(prefix.ToLower());
                ASTest = new AutoSuggestTextViewModel<dynamic>(MC.TestCode, TheFilter, SuggestedValue, "test_name", true);
                ASTest.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_B_P)x).lab_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_B_P)o).lab_name ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M003_B_P)o).lab_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLab = new AutoSuggestTextViewModel<dynamic>(MC.Laboratory, TheFilter, SuggestedValue, "lab_name", true);
                ASLab.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M013_P)x).insp_type_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M013_P)o).insp_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M013_P)o).insp_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInspType = new AutoSuggestTextViewModel<dynamic>(MC.InspType, TheFilter, SuggestedValue, "insp_type_name", true);
                ASInspType.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            ReportParameters.t_status = "";
            ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.doc_cat = "";
            ReportParameters.doc_no = "";
            ReportParameters.location_Id = AppSessionState.location_Id;
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(-30);
            ReportParameters.ToDate = DateTime.Now;
        }
        private void DisplayReport()
        {
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
                    
                    if (ReportParameters.ReportCode != null)
                    {
                        if (ReportParameters.lab_code == null) { ReportParameters.lab_code = "All"; }
                        if (ReportParameters.PartyId == null) { ReportParameters.PartyId = "All"; }
                        if (ReportParameters.inst_code == null) { ReportParameters.inst_code = "All"; }
                        if (ReportParameters.inst_type == null) { ReportParameters.inst_type = "All"; }
                        if (ReportParameters.test_code == null) { ReportParameters.test_code = "All"; }
                        if (ReportParameters.insp_type == null) { ReportParameters.insp_type = "All"; }

                        string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.inst_code + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.location_Id + "!@" + ReportParameters.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.insp_type + "!@" + ReportParameters.test_code + "!@" + ReportParameters.inst_type + "!@" + ReportParameters.lab_code ;
                        dsReport = repository.GetDataWithReturnDomainObject<List<RptMISInspection>>(dsReport, RequestParameter, "MIS_QMS_CTReport", "QMS", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                        objDataSource[2] = Result;

                        objDataSourceName[0] = "dsRptMISInspection";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\QMS\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");

                        var msg = new NotificationMessage("MIS_QMS_CT_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
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
                returnReportName = "InspCalender.rdlc";
            }
            else if (ReportCode == "R002")
            {
                returnReportName = "InspectionOverDues.rdlc";
            }
            else if (ReportCode == "R003")
            {
                returnReportName = "InspectionHistory.rdlc";
            }
            return returnReportName;
        }

        #endregion

        #region Abstract Classes Implementation
        protected override void OnDocumentAction()
        {
            
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnCreateAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            ReportParameters = new MIS_QMS_CTReport();
            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_QMS_CTReport> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
