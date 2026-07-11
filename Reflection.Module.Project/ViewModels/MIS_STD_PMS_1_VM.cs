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

namespace Reflection.Module.Project.ViewModels
{
    public class MIS_STD_PMS_1_VM : WorkspaceViewModel<STD_REQ_PARA_BE>
    {
        #region Variables Declaration
        public string ts_code_vm { get; set; }
        WebServiceRepository<STD_REQ_PARA_BE> repository = new WebServiceRepository<STD_REQ_PARA_BE>();
        WebServiceRepository<MC_PMS_OLD_BE> repository_MC = new WebServiceRepository<MC_PMS_OLD_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_PMS_OLD_BE _MC = new MC_PMS_OLD_BE();
        public MC_PMS_OLD_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }

        private MC_PMS_OLD_BE _MC_Temp = new MC_PMS_OLD_BE();
        public MC_PMS_OLD_BE MC_Temp
        {
            get { return _MC_Temp; }
            set { if (_MC_Temp != value) { _MC_Temp = value; RaisePropertyChanged("MC_Temp"); } }
        }
        private STD_REQ_PARA_BE _REQ_PARA_OBJ = new STD_REQ_PARA_BE();
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get { return _REQ_PARA_OBJ; }
            set { if (_REQ_PARA_OBJ != value) { _REQ_PARA_OBJ = value; RaisePropertyChanged("REQ_PARA_OBJ"); } }
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
        
        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MIS_STD_PMS_1_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASOrder { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrder
        {
            get { return _ASOrder; }
            set
            {
                if (_ASOrder != value)
                {
                    _ASOrder = value; RaisePropertyChanged("ASOrder");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASProject { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProject
        {
            get { return _ASProject; }
            set
            {
                if (_ASProject != value)
                {
                    _ASProject = value; RaisePropertyChanged("ASProject");
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
        private AutoSuggestTextViewModel<dynamic> _ASSalesGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesGroup
        {
            get { return _ASSalesGroup; }
            set
            {
                if (_ASSalesGroup != value)
                {
                    _ASSalesGroup = value; RaisePropertyChanged("ASSalesGroup");
                }
            }
        }
        #endregion

        #region RelayCommands  
        public RelayCommand<object> cmdGenerateReport { get; private set; }
        #endregion
        public MIS_STD_PMS_1_VM(string ts_code) : base()
        {
            MC = new MC_PMS_OLD_BE();
            MC_Temp = new MC_PMS_OLD_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Project Details");
            ItemsDictionary.Add("R002", "Project Summury");
            ItemsDictionary.Add("R003", "Project Procurement List");
            ItemsDictionary.Add("R004", "Project Details2");
            cmdGenerateReport = new RelayCommand<object>(items => { if (items == null) { return; } DisplayReport(items); });
            DefaultValues();
            LoadInitialData();
        }
        private void DefaultValues()
        {
            REQ_PARA_OBJ.comp_code = AppSessionState.comp_code;
            REQ_PARA_OBJ.location_id = AppSessionState.location_Id;
            REQ_PARA_OBJ.from_date = DateTime.Now.AddMonths(-1);
            REQ_PARA_OBJ.to_date = DateTime.Now;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client.ToString() + "!@" + (REQ_PARA_OBJ.comp_code ?? "").ToString() + "!@" + (REQ_PARA_OBJ.location_id ?? "") + "!@" + (REQ_PARA_OBJ.doc_no ?? "") + "!@" + (REQ_PARA_OBJ.ref_doc ?? "");
                MC = repository_MC.GetDataWithReturnDomainObject<MC_PMS_OLD_BE>(MC, Request, "MIS_PMS", "PM", " ", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOrder = new AutoSuggestTextViewModel<dynamic>(MC.Order, TheFilter, SuggestedValue, "m_operator", true);
                ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true; ASOrder.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_P)x).project_id);
                TheFilter = (o, prefix) => (((PRO_T001_P)o).project_id ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_T001_P)o).project_name ?? "").ToLower().Contains(prefix.ToLower());
                ASProject = new AutoSuggestTextViewModel<dynamic>(MC.Project, TheFilter, SuggestedValue, "project_id", true);
                ASProject.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                var Plant = (from o in (List<ADM_M003>)AppSessionState.ADM_M003_List where o.comp_code == AppSessionState.comp_code select o);
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(Plant, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(MC.SalesGroup, TheFilter, SuggestedValue, "sg_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                //TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "unit_code", true);
                //ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;



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
                if (REQ_PARA_OBJ.rpt_code == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                else
                {
                    if (REQ_PARA_OBJ.rpt_code != null)
                    {
                        CursorControl.SetBusyState();
                        string RequestParameter = "Report" + "!@" + AppSessionState.client + "!@" + REQ_PARA_OBJ.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + REQ_PARA_OBJ.rpt_code + "!@" + REQ_PARA_OBJ.doc_no + "!@" + REQ_PARA_OBJ.ref_doc + "!@" + REQ_PARA_OBJ.unit_code + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + REQ_PARA_OBJ.sg_code;
                        MC_Temp = repository_MC.GetDataWithReturnDomainObject<MC_PMS_OLD_BE>(MC_Temp, RequestParameter, "MIS_PMS", "PM", " ", 0, "");

                        object[] objDataSource = new object[5];
                        string[] objDataSourceName = new string[5];

                        objDataSource[0] = MC_Temp.STD_MIS_BE_OBJ;
                        objDataSourceName[0] = "ds_STD_MIS_BE";
                        objDataSource[1] = MC_Temp.ProjectInfo;
                        objDataSourceName[1] = "dsProjectInfo";
                        objDataSource[2] = MC_Temp.ProcurementInfo;
                        objDataSourceName[2] = "dsPurchaseInfo";
                        objDataSource[3] = MC_Temp.ConsumptionInfo;
                        objDataSourceName[3] = "dsConsumptionInfo";
                        objDataSource[4] = MC_Temp.ExpensesInfo;
                        objDataSourceName[4] = "dsExpensesInfo";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\PMS\\" + GetReportFile(REQ_PARA_OBJ.rpt_code), getParametersList(), "");
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
            { returnReportName = "Project_Details.rdlc"; REQ_PARA_OBJ.report_name = "Project Details"; }
            else if (ReportCode == "R002")
            { returnReportName = "Project_Summury.rdlc"; REQ_PARA_OBJ.report_name = "Project Summury"; }
            else if (ReportCode == "R003")
            { returnReportName = "Project_Status.rdlc"; REQ_PARA_OBJ.report_name = "Project List"; }
            else if (ReportCode == "R004")
            { returnReportName = "Project_Details2.rdlc"; REQ_PARA_OBJ.report_name = "Project Details2"; }

            return returnReportName;
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (REQ_PARA_OBJ.rpt_code == "R001" || REQ_PARA_OBJ.rpt_code == "R002")
                {
                    //result.Add("FromDate", Convert.ToString(REQ_PARA_OBJ.from_date));
                    //result.Add("ToDate", Convert.ToString(REQ_PARA_OBJ.to_date));
                    result.Add("ReportName", Convert.ToString(REQ_PARA_OBJ.report_name));
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

        protected override void OnSaveAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnCreateAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {
        }

        protected override void OnRemoveAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<STD_REQ_PARA_BE> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<STD_REQ_PARA_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<STD_REQ_PARA_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<STD_REQ_PARA_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<STD_REQ_PARA_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<STD_REQ_PARA_BE> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
