using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.CustomerRelation;
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
using Reflection.ReportingServices;
using System.Windows.Data;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.Production;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class MIS_STD_PPC_1_VM : WorkspaceViewModel<EPR_T002>
    {
        #region Variables Declaration
        public string ts_code_vm { get; set; }
        WebServiceRepository<EPR_T002> repository = new WebServiceRepository<EPR_T002>();
        WebServiceRepository<MultipleContext_EPR_T002> repository_MC = new WebServiceRepository<MultipleContext_EPR_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_EPR_T002 _MC = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MultipleContext_EPR_T002 _MC_Temp = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MC_Temp
        {
            get { return _MC_Temp; }
            set { if (_MC_Temp != value) { _MC_Temp = value; RaisePropertyChanged("MC_Temp"); } }
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
        private EPR_T002 _MasterEntity;
        public EPR_T002 MasterEntity
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
        private List<EPR_T002> _dsReport;
        public List<EPR_T002> dsReport
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
        private string _ReportCode;
        public string ReportCode
        {
            get
            {
                return _ReportCode;
            }
            set
            {
                _ReportCode = value;
                RaisePropertyChanged("ReportCode");
            }
        }
        private string _ReportName;
        public string ReportName
        {
            get
            {
                return _ReportName;
            }
            set
            {
                _ReportName = value;
                RaisePropertyChanged("ReportName");
            }
        }
        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MIS_STD_PPC_1_VM));
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
                    _ASCompany = value; RaisePropertyChanged("ASCompany");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASOperations { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOperations
        {
            get { return _ASOperations; }
            set
            {
                if (_ASOperations != value)
                {
                    _ASOperations = value; RaisePropertyChanged("ASOperations");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWorkCenters { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWorkCenters
        {
            get { return _ASWorkCenters; }
            set
            {
                if (_ASWorkCenters != value)
                {
                    _ASWorkCenters = value; RaisePropertyChanged("ASWorkCenters");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASShiftIncharge { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShiftIncharge
        {
            get { return _ASShiftIncharge; }
            set
            {
                if (_ASShiftIncharge != value)
                {
                    _ASShiftIncharge = value; RaisePropertyChanged("ASShiftIncharge");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASShift { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShift
        {
            get { return _ASShift; }
            set
            {
                if (_ASShift != value)
                {
                    _ASShift = value; RaisePropertyChanged("ASShift");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASUOM; }
            set
            {
                if (_ASUOM != value)
                {
                    _ASUOM = value; RaisePropertyChanged("ASUOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASOperator { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOperator
        {
            get { return _ASOperator; }
            set
            {
                if (_ASOperator != value)
                {
                    _ASOperator = value; RaisePropertyChanged("ASOperator");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASInputType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInputType
        {
            get { return _ASInputType; }
            set
            {
                if (_ASInputType != value)
                {
                    _ASInputType = value; RaisePropertyChanged("ASInputType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRecordType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRecordType
        {
            get { return _ASRecordType; }
            set
            {
                if (_ASRecordType != value)
                {
                    _ASRecordType = value; RaisePropertyChanged("ASRecordType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVarReason { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVarReason
        {
            get { return _ASVarReason; }
            set
            {
                if (_ASVarReason != value)
                {
                    _ASVarReason = value; RaisePropertyChanged("ASVarReason");
                }
            }
        }

        private List<ConfirmationTypes> ConfirmationTypesList;
        #endregion

        #region RelayCommands  
        public RelayCommand<object> cmdGenerateReport { get; private set; }
        #endregion
        public MIS_STD_PPC_1_VM(string ts_code) : base()
        {
            MC = new MultipleContext_EPR_T002();
            MC_Temp = new MultipleContext_EPR_T002();
            dsReport = new List<EPR_T002>();
            MasterEntity = new EPR_T002();
            ConfirmationTypesList = new List<ConfirmationTypes>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "WIP Stock Status");
            ItemsDictionary.Add("R002", "Production Summury");
            ItemsDictionary.Add("R003", "Work Center Wise Production");
            ItemsDictionary.Add("R004", "Operation Wise Production");
            ItemsDictionary.Add("R005", "Item Wise Production");
            ItemsDictionary.Add("R006", "Shift Wise Production");
            ItemsDictionary.Add("R007", "Operator Wise W/O Item W/o WC Production Summury");
            ItemsDictionary.Add("R008", "Operator, Work Center Wise Production Summury");
            ItemsDictionary.Add("R009", "Operator, Work Center, Item Wise Production Summury");
            ItemsDictionary.Add("R011", "Operator, Item Wise Production");
            ItemsDictionary.Add("R012", "Production Entry Details");
            ItemsDictionary.Add("R010", "Work Center Efficiency");
            ItemsDictionary.Add("R015", "Operation Wise Efficiency");
            ItemsDictionary.Add("R013", "WIP Stage Wise Production");
            ItemsDictionary.Add("R014", "WIP Pending Operations");
            ItemsDictionary.Add("R016", "Work Center, Operation Wise Summury with Resion");
            ItemsDictionary.Add("R017", "Operator, Operation Wise Summury with Resion");
            cmdGenerateReport = new RelayCommand<object>(items => { if (items == null) { return; } DisplayReport(items); });

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "MIS_STD_PPC_1", "Production", " ", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001)x).wc_code);
                TheFilter = (o, prefix) => (((PPC_M001)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001)o).wc_short_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWorkCenters = new AutoSuggestTextViewModel<dynamic>(MC.WorkCenterList, TheFilter, SuggestedValue, "wc_code", true);
                ASWorkCenters.AutoSuggestVM.IsEmptyValueAllowed = true; ASWorkCenters.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001)x).wc_code);
                TheFilter = (o, prefix) => (((PPC_M001)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001)o).wc_short_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWorkCenters = new AutoSuggestTextViewModel<dynamic>(MC.WorkCenterList, TheFilter, SuggestedValue, "wc_code", true);
                ASWorkCenters.AutoSuggestVM.IsEmptyValueAllowed = true; ASWorkCenters.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASShiftIncharge = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "shift_incharge", true);
                ASShiftIncharge.AutoSuggestVM.IsEmptyValueAllowed = true; ASShiftIncharge.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.ShiftList, TheFilter, SuggestedValue, "shift", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true; ASShift.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOperator = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeList, TheFilter, SuggestedValue, "m_operator", true);
                ASOperator.AutoSuggestVM.IsEmptyValueAllowed = true; ASOperator.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((OperationList)x).operation_no);
                TheFilter = (o, prefix) => (((OperationList)o).operation_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((OperationList)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOperations = new AutoSuggestTextViewModel<dynamic>(MC.OperationsList, TheFilter, SuggestedValue, "operation_no", true);
                ASOperations.AutoSuggestVM.IsEmptyValueAllowed = true; ASOperator.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M052)x).record_type);
                TheFilter = (o, prefix) => (((SYS_M052)o).record_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M052)o).type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRecordType = new AutoSuggestTextViewModel<dynamic>(MC.RecordTypeList, TheFilter, SuggestedValue, "record_type", true);
                ASRecordType.AutoSuggestVM.IsEmptyValueAllowed = true; ASRecordType.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M003)x).var_reson);
                TheFilter = (o, prefix) => (((PPC_M003)o).var_reson ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M003)o).reson_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASVarReason = new AutoSuggestTextViewModel<dynamic>(MC.VarReasonList, TheFilter, SuggestedValue, "var_reason", true);
                ASVarReason.AutoSuggestVM.IsEmptyValueAllowed = true; ASVarReason.AutoSuggestVM.IsFreeTextAllowed = false;

                ConfirmationTypesList.Add(new ConfirmationTypes { conf_type = "P", conf_desc = "Partial Execution" });
                ConfirmationTypesList.Add(new ConfirmationTypes { conf_type = "F", conf_desc = "Final Execution" });
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASInputType = new AutoSuggestTextViewModel<dynamic>(ConfirmationTypesList, TheFilter, SuggestedValue, "conf_type", true);
                ASInputType.AutoSuggestVM.IsEmptyValueAllowed = true; ASInputType.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                var Plant = (from o in (List<ADM_M003>)AppSessionState.ADM_M003_List where o.comp_code == AppSessionState.comp_code select o);
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(Plant, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;


            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DisplayReport(object tem)
        {
            try
            {
                CursorControl.SetBusyState();
                if (ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                else
                {
                    if (ReportCode != null)
                    {
                        string RequestParameter = "Report" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + ReportCode + "!@" + MasterEntity.conf_type + "!@" + MasterEntity.record_type + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.operation_no + "!@" + MasterEntity.wc_code + "!@" + MasterEntity.shift + "!@" + MasterEntity.shift_incharge + "!@" + MasterEntity.m_operator + "!@" + MasterEntity.var_reson + "!@" + MasterEntity.unit_code + "!@" + Convert.ToDateTime(MasterEntity.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.to_date).ToString("MM/dd/yyyy");
                        MC_Temp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC_Temp, RequestParameter, "MIS_STD_PPC_1", "Production", " ", 0, "");

                        object[] objDataSource = new object[1];
                        string[] objDataSourceName = new string[1];

                        objDataSource[0] = MC_Temp.MIS_STD_PPC_1_LIST;

                        objDataSourceName[0] = "dsMIS_STD_PPC_1";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportCode), getParametersList(), "");
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
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            { returnReportName = "WIP_Stock.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "PPC_ProductionSummury.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "PPC_WorckCenterProductionSummary.rdlc"; }
            else if (ReportCode == "R004")
            { returnReportName = "PPC_ProductionSummuryOperationCT.rdlc"; }
            else if (ReportCode == "R005")
            { returnReportName = "PPC_ProductionSummuryItemWise.rdlc"; }
            else if (ReportCode == "R006")
            { returnReportName = "PPC_ProductionSummuryShiftwise.rdlc"; }
            else if (ReportCode == "R007")
            { returnReportName = "PE_OperatorWiseWOItemWCSummary.rdlc"; }
            else if (ReportCode == "R008")
            { returnReportName = "PE_OperatorWCWiseSummary.rdlc"; }
            else if (ReportCode == "R009")
            { returnReportName = "PE_OperatorWCItemWiseSummary.rdlc"; }
            else if (ReportCode == "R010")
            { returnReportName = "PPC_WC_Efficiency.rdlc"; }
            else if (ReportCode == "R011")
            { returnReportName = "PE_OperatorWiseDailySummary.rdlc"; }
            else if (ReportCode == "R012")
            { returnReportName = "PPC_ProductionExecution.rdlc"; }
            else if (ReportCode == "R013")
            { returnReportName = "PPC_WIP_ProductionSummury.rdlc"; }
            else if (ReportCode == "R014")
            { returnReportName = "PPC_WIP_Pending_Operations.rdlc"; }
            else if (ReportCode == "R015")
            { returnReportName = "PPC_WC_Efficiency_OP_Wise.rdlc"; }
            else if (ReportCode == "R016")
            { returnReportName = "PPC_OP_WC_Summury.rdlc"; }
            else if (ReportCode == "R017")
            { returnReportName = "PPC_OP_OPR_Summury.rdlc"; }


            return returnReportName;
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (ReportCode == "R004" || ReportCode == "R016" || ReportCode == "R017")
                {
                    result.Add("FromDate", Convert.ToString(MasterEntity.from_date));
                    result.Add("ToDate", Convert.ToString(MasterEntity.to_date));
                }
                //result.Add("ItemCode", ReportParameters.ItemCode);
                //result.Add("PartyId", ReportParameters.PartyId);
                //result.Add("PartyNm", ReportParameters.PartyNm);
                //result.Add("doc_type", ReportParameters.doc_type);
                //result.Add("doc_cat", ReportParameters.doc_cat);
                //result.Add("t_status", ReportParameters.t_status);
                //result.Add("ReportNm", ReportParameters.ReportName);
                //result.Add("doc_no", ReportParameters.doc_no);
                //result.Add("comp_code", ReportParameters.comp_code);
                //result.Add("Location_Id", ReportParameters.Location_Id);
                //result.Add("ItemName", ReportParameters.ItemName);
                //result.Add("sg_name", ReportParameters.sg_name);
                //result.Add("sales_org", ReportParameters.sales_org);

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
        #region Abstract Classes Implementation
        protected override void OnDocumentAction()
        {

        }

        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
        }

        protected override void OnRemoveAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<EPR_T002> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
