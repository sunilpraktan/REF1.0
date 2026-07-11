using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity.Admin;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0016_VM : WorkspaceViewModel<ADM_M028_H>
    {
        bool isNewRecord = true;
        WebServiceRepository<ADM_M028_H> repository = new WebServiceRepository<ADM_M028_H>();
        WebServiceRepository<MultipleContext_ADM_M028_H> repository_MC = new WebServiceRepository<MultipleContext_ADM_M028_H>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0016_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASPartyID { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPartyID
        {
            get { return _ASPartyID; }
            set
            {
                if (_ASPartyID != value)
                {
                    _ASPartyID = value;
                    RaisePropertyChanged("ASPartyID");
                }
            }
        }
        #endregion

        #region Declarations  
        private MultipleContext_ADM_M028_H _MC;
        public MultipleContext_ADM_M028_H MC
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

        private MultipleContext_ADM_M028_H _MCTemp;
        public MultipleContext_ADM_M028_H MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }


        private ADM_M028_H _MasterEntity;
        public ADM_M028_H MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }
        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M028_H> _Party_Collection;
        public ObservableCollection<ADM_M028_H> Party_Collection
        {
            get { return _Party_Collection; }
            set
            {
                if (_Party_Collection != value)
                {
                    _Party_Collection = value;
                    RaisePropertyChanged("Party_Collection");
                }
            }
        }

        private ICollectionView _Party_Collection1;
        public ICollectionView Party_Collection1
        {
            get { return _Party_Collection1; }
            set
            {
                if (_Party_Collection1 != value)
                {
                    _Party_Collection1 = value;
                    RaisePropertyChanged("Party_Collection1");
                }
            }
        }

        private List<ADM_M028_H> _SelectedList;
        public List<ADM_M028_H> SelectedList
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

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return _SelectedTabControlIndex;
            }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> CmdPartyID { get; private set; }
        public RelayCommand<object> CmdLoadDocByDocNumber { get; private set; }

        #endregion

        #region  Constructor

        public SDM_M0016_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M028_H();
            Party_Collection = new ObservableCollection<ADM_M028_H>();

            MC = new MultipleContext_ADM_M028_H();
            MCTemp = new MultipleContext_ADM_M028_H();

            CmdPartyID = new RelayCommand<object>(items => { if (items == null) { return; } Insert_PartyID(items); });
            CmdLoadDocByDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            LoadinitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadinitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M028_H>(MC, Request, "PartyCondition", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                Party_Collection = MC.PartyConList;
                SelectedList = Party_Collection.ToList();

                Party_Collection1 = CollectionViewSource.GetDefaultView(MC.PartyConList);
                Party_Collection1.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPartyID = new AutoSuggestTextViewModel<dynamic>(MC.PartyIDList, TheFilter, SuggestedValue, "PartyId", true);
                ASPartyID.AutoSuggestVM.IsEmptyValueAllowed = true;

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
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
        }

        private bool Validation()
        {
            if (MasterEntity.tc_code == null || MasterEntity.tc_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter TC Code", MasterEntity.tc_code);
                showMessageService.ShowMessage();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                ADM_M028_H ParameterEntityObject = null;

                if (((IEnumerable)ParameterObject).Cast<ADM_M028_H>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M028_H>().ToList()[0];

                    if (MC.PartyConList.Count > 0)
                    {
                        MasterEntity = ParameterEntityObject;
                    }
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

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
                    Party_Collection.Add(MasterEntity);
                    Party_Collection1 = CollectionViewSource.GetDefaultView(Party_Collection);
                    Party_Collection1.Refresh();
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

        private void Insert_PartyID(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.PartyIDList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M028_H> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M028_H();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M028_H> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M028_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M028_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M028_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M028_H> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M028_H> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M028_H> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M028_H> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M028_H> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M028_H> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M028_H> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M028_H> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M028_H>(MasterEntity, "PartyCondition", "Administration");

                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M028_H>(MasterEntity, "PartyCondition", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
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
        #endregion

        #region Filters

        private string _filterString;
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                if (_filterString != value)
                {
                    _filterString = value;
                    RaisePropertyChanged("FilterString");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_Party_Collection1 != null)
            {
                _Party_Collection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M028_H;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {

                    return (data.tc_code != null && data.tc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sequence_code != null && data.sequence_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }



        #endregion
    }
}
