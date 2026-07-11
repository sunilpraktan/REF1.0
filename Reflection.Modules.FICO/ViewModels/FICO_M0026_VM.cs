using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
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
using System.Windows;
using System.Windows.Data;
using Reflection.BusinessEntity.Admin;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.FICO.ViewModels
{
    class FICO_M0026_VM : WorkspaceViewModel<ADM_M041_B>
    {
        bool isNewRecord = true;

        #region Declaration
        //bool NewRecord = true;
        WebServiceRepository<ADM_M041_B> repository = new WebServiceRepository<ADM_M041_B>();
        WebServiceRepository<MultipleContext_ADM_M041_B> repository_MC = new WebServiceRepository<MultipleContext_ADM_M041_B>();
        WebServiceRepository<MultipleContext_ADM_M041_B> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M041_B>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_ADM_M041_B _MCTemp = new MultipleContext_ADM_M041_B();
        public MultipleContext_ADM_M041_B MCTemp
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
        private ADM_M041_B _MasterEntity;
        public ADM_M041_B MasterEntity
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

        private List<ADM_M041_B_Flip> _FlipGridData;
        public List<ADM_M041_B_Flip> FlipGridData
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

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get { return _dgSelectedIndexItem; }
            set
            {
                _dgSelectedIndexItem = value;
                RaisePropertyChanged("dgSelectedIndexItem");
            }
        }

        private MultipleContext_ADM_M041_B _MC;
        public MultipleContext_ADM_M041_B MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        #endregion

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_M0026_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWireDia { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWireDia
        {
            get { return _ASWireDia; }
            set
            {
                if (_ASWireDia != value)
                {
                    _ASWireDia = value; RaisePropertyChanged("ASWireDia");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWireSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWireSize
        {
            get { return _ASWireSize; }
            set
            {
                if (_ASWireSize != value)
                {
                    _ASWireSize = value; RaisePropertyChanged("ASWireSize");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWireType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWireType
        {
            get { return _ASWireType; }
            set
            {
                if (_ASWireType != value)
                {
                    _ASWireType = value; RaisePropertyChanged("ASWireType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBallDia { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBallDia
        {
            get { return _ASBallDia; }
            set
            {
                if (_ASBallDia != value)
                {
                    _ASBallDia = value; RaisePropertyChanged("ASBallDia");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBallType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBallType
        {
            get { return _ASBallType; }
            set
            {
                if (_ASBallType != value)
                {
                    _ASBallType = value; RaisePropertyChanged("ASBallType");
                }
            }
        }



        #endregion

        #region ICollectionView

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _WireDiaCollection;
        public ICollectionView WireDiaCollection
        {
            get { return _WireDiaCollection; }
            set { _WireDiaCollection = value; RaisePropertyChanged("WireDiaCollection"); }
        }

        private ICollectionView _WireTypeCollection;
        public ICollectionView WireTypeCollection
        {
            get { return _WireTypeCollection; }
            set { _WireTypeCollection = value; RaisePropertyChanged("WireTypeCollection"); }
        }

        private ICollectionView _BallDiaCollection;
        public ICollectionView BallDiaCollection
        {
            get { return _BallDiaCollection; }
            set { _BallDiaCollection = value; RaisePropertyChanged("BallDiaCollection"); }
        }
        private ICollectionView _BallTypeCollection;
        public ICollectionView BallTypeCollection
        {
            get { return _BallTypeCollection; }
            set { _BallTypeCollection = value; RaisePropertyChanged("BallTypeCollection"); }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddWireDia { get; private set; }
        public RelayCommand<object> CmdAddWireType { get; private set; }
        public RelayCommand<object> CmdAddBallDia { get; private set; }
        public RelayCommand<object> CmdAddBallType { get; private set; }

        #endregion      

        #region Constructor
        public FICO_M0026_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M041_B();
            MC = new MultipleContext_ADM_M041_B();
            MCTemp = new MultipleContext_ADM_M041_B();
            FlipGridData = new List<ADM_M041_B_Flip>();


            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdAddWireDia = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWiredia(cmdPara); });
            CmdAddWireType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireType(cmdPara); });
            CmdAddBallDia = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallDia(cmdPara); });
            CmdAddBallType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallType(cmdPara); });

            LoadInitialData();
        }
        private void InsertBallType(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallType.Where(x => x.ball_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                // if (POPUPEntityObject != null)
                // {
                //     MasterEntity.imp_ball_type= POPUPEntityObject.ball_type.ToString();
                //     //MasterEntity.imp_wire_type = POPUPEntityObject.wire_size;
                //     //MasterEntity.ContInfoId = POPUPEntityObject.id;
                //     //MasterEntity.cont_per_name = POPUPEntityObject.PersonName;
                //}
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
        private void InsertBallDia(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallDia.Where(x => x.ball_dia.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

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
        private void InsertWireType(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.WireType.Where(x => x.wire_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null)
                //{
                //    MasterEntity.imp_wire_type = POPUPEntityObject.wire_type.ToString();
                //    //MasterEntity.imp_wire_type = POPUPEntityObject.wire_size;
                //    //MasterEntity.ContInfoId = POPUPEntityObject.id;
                //    //MasterEntity.cont_per_name = POPUPEntityObject.PersonName;
                //}
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
        private void InsertWiredia(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.WireDia.Where(x => x.wire_size.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

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

        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "Open";
            MasterEntity.client = AppSessionState.client;
        }


        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M041_B>(MC, Request, "Sion_Master", "Administration", "LoadInitialData", 0, "");

                #region AutoSuggest Initialisation

                FlipGridData = MC.FlipGridData;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M003_P)x).wire_size.ToString());
                TheFilter = (o, prefix) => ((ZADM_M003_P)o).wire_size.ToString().ToLower().Contains(prefix);
                ASWireDia = new AutoSuggestTextViewModel<dynamic>(MC.WireDia, TheFilter, SuggestedValue, "WireDia", true);
                ASWireDia.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M003_P)x).wire_size.ToString());
                TheFilter = (o, prefix) => ((ZADM_M003_P)o).wire_size.ToString().ToLower().Contains(prefix);
                ASWireSize = new AutoSuggestTextViewModel<dynamic>(MC.WireDia, TheFilter, SuggestedValue, "WireSize", true);
                ASWireSize.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M004_P)x).wire_type);
                TheFilter = (o, prefix) => ((ZADM_M004_P)o).wire_type.ToLower().Contains(prefix);
                ASWireType = new AutoSuggestTextViewModel<dynamic>(MC.WireType, TheFilter, SuggestedValue, "WireType", true);
                ASWireType.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASWireType.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M001_P)x).ball_dia.ToString());
                TheFilter = (o, prefix) => ((ZADM_M001_P)o).ball_dia.ToString().ToLower().Contains(prefix);
                ASBallDia = new AutoSuggestTextViewModel<dynamic>(MC.BallDia, TheFilter, SuggestedValue, "BallDia", true);
                ASBallDia.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M002_P)x).ball_type);
                TheFilter = (o, prefix) => ((ZADM_M002_P)o).ball_type.ToLower().Contains(prefix);
                ASBallType = new AutoSuggestTextViewModel<dynamic>(MC.BallType, TheFilter, SuggestedValue, "BallType", true);
                ASBallType.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                DefaultValues();
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
            string Request = "";
            MasterEntity = new ADM_M041_B();
            ADM_M041_B_Flip ParameterEntityObject = null;

            try
            {
                if (((IEnumerable)ParameterObject).Cast<ADM_M041_B_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M041_B_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + ParameterEntityObject.id;
                    //Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.id;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M041_B>(MCTemp, Request, "Sion_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                    isNewRecord = false;
                }
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }

                SetBusinessEntitiesAfterLoad("Save", "");
                SelectedTabControlIndex = 0;

                var msg = new NotificationMessage("ADM_M041_B_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
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

        private void SetPopupSuggestionDataAfterLoad()
        {
            ASWireSize.AutoSuggestVM.Suggestion = MC.WireDia.Find(x => x.wire_size.ToString() == MasterEntity.imp_wire_dia);
            ASWireDia.AutoSuggestVM.Suggestion = MC.WireDia.Find(x => x.wire_size.ToString() == MasterEntity.exp_wire_dia);
            ASWireType.AutoSuggestVM.Suggestion = MC.WireType.Find(x => x.wire_type == MasterEntity.imp_wire_type);
            ASBallDia.AutoSuggestVM.Suggestion = MC.BallDia.Find(x => x.ball_dia.ToString() == MasterEntity.imp_ball_dia);
            ASBallType.AutoSuggestVM.Suggestion = MC.BallType.Find(x => x.ball_type == MasterEntity.imp_ball_type);


        }

        #endregion

        #region BF Filter
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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M041_B_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.sion_no != null && data.sion_no.ToLower().Contains(_filterString.ToLower()) ||
                            data.sion_desc.ToString() != null && data.sion_desc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.imp_wire_type != null && data.imp_wire_type.ToLower().Contains(_filterString.ToLower()) ||
                            data.imp_wire_dia != null && data.imp_wire_dia.ToLower().Contains(_filterString.ToLower()) ||
                            data.imp_ball_type != null && data.imp_ball_type.ToLower().Contains(_filterString.ToLower()) ||
                            data.imp_ball_dia != null && data.imp_ball_dia.ToLower().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Abstract Methods
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M041_B> result)
        {
            MasterEntity = new ADM_M041_B();
            DefaultValues();
            isNewRecord = true;

        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M041_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M041_B> result)
        {
            try
            {
                MasterEntity.XmlDataDocument_ADM_M041_B = obj.ObjectToXML(MasterEntity);
                this.MasterEntity.EndEdit();

                if (isNewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<ADM_M041_B>(MasterEntity, "Sion_Master", "Administration");
                }
                else if (isNewRecord == false)
                {
                    MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M041_B>(MasterEntity, "Sion_Master", "Administration");
                }


                if (MasterEntity.sion_no != null && isNewRecord == true)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MasterEntity.sion_no != null && isNewRecord == false)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                    showMessageService.ShowMessage();
                }

                SetBusinessEntitiesAfterLoad("Save", "");
                isNewRecord = false;

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
                if (MasterEntity.XmlDataDocument_ADM_M041_B_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.FlipGridData = (List<ADM_M041_B_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M041_B_Flip, MC.FlipGridData);
                    FlipGridData.Add(MC.FlipGridData[0]);
                    DataGridCollection.Refresh();
                    // FlipGridData.SortDescription.Add(new SortDescription("id", ListSortDirection.Descending));
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
    }
}

