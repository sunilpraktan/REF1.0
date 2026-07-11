using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.ObjectModel;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0013_VM : WorkspaceViewModel<SYS_M025>
    {
        bool isNewRecord = true;
        WebServiceRepository<SYS_M025> repository = new WebServiceRepository<SYS_M025>();
        WebServiceRepository<MultipleContext_SYS_M025> repository_MC = new WebServiceRepository<MultipleContext_SYS_M025>();
        WebServiceRepository<MultipleContext_SYS_M025> repository_MCTemp = new WebServiceRepository<MultipleContext_SYS_M025>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ADM_M0013_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDocument { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocument
        {
            get { return _ASDocument; }
            set
            {
                if (_ASDocument != value)
                {
                    _ASDocument = value; RaisePropertyChanged("ASDocument");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTname { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTname
        {
            get { return _ASTname; }
            set
            {
                if (_ASTname != value)
                {
                    _ASTname = value; RaisePropertyChanged("ASTname");
                }
            }
        }

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdDocument { get; private set; }

        public RelayCommand<object> CmdTName { get; private set; }

        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }


        #endregion

        #region Declarations       

        private MultipleContext_SYS_M025 _MC;
        public MultipleContext_SYS_M025 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }




        private SYS_M025 _MasterEntity;
        public SYS_M025 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }
        private ObservableCollection<SYS_M025> _STCollection;
        public ObservableCollection<SYS_M025> STCollection
        {
            get { return _STCollection; }
            set
            {
                if (_STCollection != value)
                {
                    _STCollection = value;
                    RaisePropertyChanged("STCollection");
                }
            }
        }

        private ICollectionView _STCollection1;
        public ICollectionView STCollection1
        {
            get { return _STCollection1; }
            set
            {
                if (_STCollection1 != value)
                {
                    _STCollection1 = value;
                    RaisePropertyChanged("STCollection1");
                }
            }
        }

        private List<SYS_M025> _SelectedList;
        public List<SYS_M025> SelectedList
        {
            get
            {
                return _SelectedList;
            }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }



        #endregion
        #region Constructor
        public ADM_M0013_VM(string ts_code) : base()
        {
            MasterEntity = new SYS_M025();
            MC = new MultipleContext_SYS_M025();



            CmdDocument = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocument(items); });
            CmdTName = new RelayCommand<object>(items => { if (items == null) { return; } InsertTName(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });


            LoadInitialData();

        }

        #endregion
        #region User Defined Methods
        private void DefaultValues()
        {

            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;



        }

        private bool Validation()
        {
            if (MasterEntity.t_status == null || MasterEntity.t_status == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Status", MasterEntity.t_status);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.t_name == null || MasterEntity.t_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Name", MasterEntity.t_name);
                showMessageService.ShowMessage();
                return false;
            }

            else
            {
                return true;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SYS_M025>(MC, Request, "StatusMaster", "Administration", "LoadInitialData", 0, "");

                STCollection = MC.Statuslist;
                SelectedList = STCollection.ToList();

                STCollection1 = CollectionViewSource.GetDefaultView(MC.Statuslist);
                STCollection1.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002_P)x).doc_type ?? "");
                TheFilter = (o, prefix) => (((SYS_M002_P)o).doc_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M002_P)o).doc_cat ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDocument = new AutoSuggestTextViewModel<dynamic>(MC.Documentlist, TheFilter, SuggestedValue, "doc_type", true);
                ASDocument.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status ?? "");
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M0013)o).t_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTname = new AutoSuggestTextViewModel<dynamic>(MC.Tlist, TheFilter, SuggestedValue, "t_status", true);
                ASTname.AutoSuggestVM.IsEmptyValueAllowed = true;




                DefaultValues();
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {

                SYS_M025 ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<SYS_M025>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SYS_M025>().ToList()[0];

                    if (MC.Statuslist.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                }


            }
            catch { }

        }
        private void InsertDocument(object InputValue)
        {
            string Request = "";
            SYS_M002_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Documentlist.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_M002_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.doc_desc_user = POPUPEntityObject.doc_desc_user;

                }
            }
            catch (Exception ex) { }
        }

        private void InsertTName(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.Tlist.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_name = POPUPEntityObject.t_name;
                    MasterEntity.t_display = POPUPEntityObject.t_name;

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
        #endregion

        #region Abstract Command Actions
        string strReturn = "";

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<SYS_M025> result)
        {
            try
            {
                if (Validation() == true)
                {

                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<SYS_M025>>(MasterEntity, "StatusMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<List<SYS_M025>>(MasterEntity, "StatusMaster", "Administration");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.t_status != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.t_status != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();

                    }
                    isNewRecord = false;
                    var msg = new NotificationMessage("ADM_M0013_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity != null)
                {

                    STCollection.Add(MasterEntity);

                    STCollection1 = CollectionViewSource.GetDefaultView(STCollection);
                    STCollection1.Refresh();


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




        protected override void OnCreateAction(InquiryActionResult<SYS_M025> result)
        {
            MasterEntity = new SYS_M025();

            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<SYS_M025> result)
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Filters

        #region Filters For DataGrid   

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (STCollection1 != null)
            {
                _STCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as SYS_M025;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString.ToLower()) || (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString.ToLower())));


                }
                return true;
            }
            return false;
        }




        #endregion
        #endregion



    }
}
