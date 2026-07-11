using System;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Controls;
using System.Windows.Data;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.Generic;
using Reflection.ReportingServices;
using System.Linq;
using Reflection.Presentation.Common;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_R01_VM : WorkspaceViewModel<MM_T001>
    {
        #region Variables Declaration
        public string ts_code_vm { get; set; }
        WebServiceRepository<STD_MC_BE> repository_MC = new WebServiceRepository<STD_MC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private STD_MC_BE _MC = new STD_MC_BE();
        public STD_MC_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private STD_MC_BE _MC_Temp = new STD_MC_BE();
        public STD_MC_BE MC_Temp
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


        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                _REQ_PARA_OBJ = value;
                RaisePropertyChanged("REQ_PARA_OBJ");
            }
        }

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_R01_VM));
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
        public RelayCommand<object> cmdPrint { get; private set; }
        #endregion
        public MM_R01_VM(string ts_code) : base()
        {
            MC = new STD_MC_BE();
            MC_Temp = new STD_MC_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Materail Trace Report");
            ItemsDictionary.Add("R002", "Pending Goods Receipt for Orders"); // NOTE: SHift this report to proper Screen.
            cmdGenerateReport = new RelayCommand<object>(items => { if (items == null) { return; } DisplayReport(items); });
            cmdPrint = new RelayCommand<object>(items => { if (items == null) { return; } PrintReport(items); });
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_LOCATION.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "MIS_STD_MM_1", "SCM", " ", 0, "");

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                //TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                //ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                var Plant = (from o in (List<ADM_M003>)AppSessionState.ADM_M003_List where o.comp_code == AppSessionState.OBJ_COMPANY.comp_code select o);
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(Plant, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                TheFilter = (o, prefix) => (((STD_ITEM)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
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
                if (REQ_PARA_OBJ == null)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Report Type"); sms.ShowMessage();
                }

                else
                {
                    if (REQ_PARA_OBJ != null)
                    {

                        string RequestParameter = "Report" + "!@" + AppSessionState.client + "!@" + REQ_PARA_OBJ.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + REQ_PARA_OBJ.report_code + "!@" + REQ_PARA_OBJ.item_code + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                        MC_Temp = repository_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_Temp, RequestParameter, "MIS_STD_MM_1", "SCM", " ", 0, "");

                        if (MC_Temp.STD_MIS_LIST.Count <= 0)
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("No record found", this.Title); sms.ShowMessage();
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("No record found", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void PrintReport(object tem)
        {
            try
            {
                if (MC_Temp.STD_MIS_LIST != null)
                {
                    if (MC_Temp.STD_MIS_LIST.Count > 0)
                    {

                        object[] objDataSource = new object[1];
                        string[] objDataSourceName = new string[1];

                        objDataSource[0] = MC_Temp.STD_MIS_LIST;
                        objDataSourceName[0] = "dsSTD_MIS_LIST";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\SCM\\" + GetReportFile(REQ_PARA_OBJ.report_code), getParametersList(), "");
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("No record found", this.Title); sms.ShowMessage();
                    }
                }
                else
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("No record found", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            { returnReportName = "WIP_Stock.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "PPC_ProductionSummury.rdlc"; }


            return returnReportName;
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (REQ_PARA_OBJ.report_code == "R004")
                {
                    result.Add("FromDate", Convert.ToString(REQ_PARA_OBJ.from_date));
                    result.Add("ToDate", Convert.ToString(REQ_PARA_OBJ.to_date));
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();

            }
            return result;
        }
        #region Abstract Classes Implementation
        protected override void OnDocumentAction()
        {

        }

        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
        }

        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
