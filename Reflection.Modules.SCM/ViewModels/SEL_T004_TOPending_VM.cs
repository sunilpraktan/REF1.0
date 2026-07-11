using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace Reflection.Modules.SCM.ViewModels
{
    public class SEL_T004_TOPending_VM : WorkspaceViewModel<SEL_T004>
    {
        bool isNewRecord = true;
        public string ref_doc_cat { get; set; }
        public string ref_doc_list { get; set; }
        public string ref_party_code { get; set; }
        WebServiceRepository<SEL_T004> repository = new WebServiceRepository<SEL_T004>();
        WebServiceRepository<string> repositoryStatus = new WebServiceRepository<string>();
        WebServiceRepository<MultipleContext_SEL_T004> repository_MC = new WebServiceRepository<MultipleContext_SEL_T004>();
        WebServiceRepository<MultipleContext_SEL_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T004>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<LOG_T001_A> repositoryDN = new WebServiceRepository<LOG_T001_A>();
        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_SEL_T004 _MC = new MultipleContext_SEL_T004();
        public MultipleContext_SEL_T004 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");
                }
            }
        }
        private SEL_T004 _MasterEntity;
        public SEL_T004 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }
        private List<SEL_T004Flip> _FlipGridData;
        public List<SEL_T004Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }
       
        #endregion

        #region ICollection for Popup Control
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandCreateDeliveryNote { get; private set; }
        public RelayCommand<object> RefreshData { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdCollectReferenceDocuments { get; private set; }
        #endregion

        #region Constructor
        public SEL_T004_TOPending_VM(string ts_code): base()
        {
            this.ts_code_vm = ts_code;
            FlipGridData = new List<SEL_T004Flip>();
            
            LoadInitialData();
        }
        public SEL_T004_TOPending_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            FlipGridData = new List<SEL_T004Flip>();

            LoadInitialData();
        }
        #endregion

        #region LoadIntialData
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialDataPending" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + AppSessionState.client + "!@" + ' ';
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MC, Request, "TransferOrder", "CRM", "LoadAll", 0, Request);

                #region Command Initialisation
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandCreateDeliveryNote = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Create_DeliveryNote(cmdPara, "FlipGridReference"); });
                RefreshData = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } RefreshOrderInfo(cmdPara, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdCollectReferenceDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CollectReferenceDocuments(cmdPara); });

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Relay Command Implementation
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                SEL_T004Flip ParameterEntityObject = null;
                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList()[0];
                    }
                }
                if (ParameterEntityObject.screen_namespace != null && ParameterEntityObject.screen_namespace != "" && ParameterEntityObject.screen_class_path != null && ParameterEntityObject.screen_class_path != "")
                {
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ParameterEntityObject.screen_namespace);
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType(ParameterEntityObject.screen_class_path);
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, ParameterEntityObject.doc_no, ParameterEntityObject.ts_code, ParameterEntityObject.ts_name_display);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        private void CollectReferenceDocuments(object InputValue)
        {
            try
            {
                SEL_T004Flip POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocumentDataFlipGrid.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T004Flip>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T004Flip>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    ref_doc_list = "";
                    var ref_doc_filtered = from o in MC.DocumentDataFlipGrid
                                           where o.party_code == POPUPEntityObject.party_code
                                               && o.party_code_ship == POPUPEntityObject.party_code_ship
                                               && o.comp_code == POPUPEntityObject.comp_code
                                               && o.so_code == POPUPEntityObject.so_code
                                               && o.curr_code == POPUPEntityObject.curr_code
                                               && o.doc_cat == POPUPEntityObject.doc_cat
                                               && o.ref_doc_cat == POPUPEntityObject.ref_doc_cat
                                               && o.pterm == POPUPEntityObject.pterm
                                               && o.incoterm == POPUPEntityObject.incoterm
                                               && o.ctry_code == POPUPEntityObject.ctry_code
                                           select o;
                    foreach (var item in ref_doc_filtered)
                    {
                        if (item.selected == true)
                        {
                            ref_doc_list = ref_doc_list + "," + item.doc_no;
                            ref_doc_cat = item.ref_doc_cat;
                            ref_party_code = item.party_code_ship;
                        }
                    }
                    ref_doc_list = ref_doc_list.ToString().TrimStart(new char[] { ',' });

                    if (ref_doc_list != "")
                    {
                        FlipGridData = ref_doc_filtered.ToList();
                        FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                        FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                    }
                    else
                    {
                        FlipGridData = MC.DocumentDataFlipGrid.ToList();
                        FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                        FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                    }
                }
            }
            catch (Exception Ex) { }
        }
        #endregion

        #region Create Delivery Function

        private void Create_DeliveryNote(object ParameterObject, string ParameterReference)
        {
            try
            {
                SEL_T004Flip ParameterEntityObject = null;
                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList()[0];
                    }
                }
                if (ParameterEntityObject.screen_namespace != null && ParameterEntityObject.screen_namespace != "" && ParameterEntityObject.screen_class_path != null && ParameterEntityObject.screen_class_path != "")
                {
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ParameterEntityObject.screen_namespace2);
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType(ParameterEntityObject.screen_class_path2);
                    if (type != null && !string.IsNullOrWhiteSpace(ref_doc_list))
                    {
                        //ParameterEntityObject.doc_no
                        ref_doc_list = ref_doc_list + "!@" + ref_doc_cat + "!@" + ref_party_code;
                        dynamic instance = Activator.CreateInstance(type, ref_doc_list, ParameterEntityObject.ts_code2, ParameterEntityObject.ts_name_display2);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Select Dispatch Order", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch(Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void RefreshOrderInfo(object ParameterObject, string ParameterReference)
        {
            LoadInitialData();
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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



        #region Abstract Method
        protected override void OnSaveAction(InquiryActionResult<SEL_T004> result)
        {
        }
        protected override void OnDocumentAction()
        {
        }
        protected override void OnCreateAction(InquiryActionResult<SEL_T004> result)
        {
        }
        protected override void OnRemoveAction(InquiryActionResult<SEL_T004> result)
        {
            
        }
        protected override void OnDiscardAction(InquiryActionResult<SEL_T004> result)
        {
            
        }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as SEL_T004Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.shipping_mode_name != null && data.shipping_mode_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.transportar_name != null && data.transportar_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.shipping_location != null && data.shipping_location.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.dispatch_date != null && data.dispatch_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
