using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0005_VM : WorkspaceViewModel<ADM_M018>
    {
        #region AutoSuggest TextBox Declaration Region 

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_M0005_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASAccountCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccountCat
        {
            get { return _ASAccountCat; }
            set
            {
                if (_ASAccountCat != value)
                {
                    _ASAccountCat = value; RaisePropertyChanged("ASAccountCat");
                }
            }
        }

        #endregion

        #region Declaration

        bool NewRecord = true;
        WebServiceRepository<ADM_M018> repository = new WebServiceRepository<ADM_M018>();
        WebServiceRepository<MultipleContext_ADM_M018> repository_MC = new WebServiceRepository<MultipleContext_ADM_M018>();
        WebServiceRepository<MultipleContext_ADM_M018> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M018>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ADM_M018 _MC = new MultipleContext_ADM_M018();
        public MultipleContext_ADM_M018 MC
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
        private MultipleContext_ADM_M018 _MCTemp = new MultipleContext_ADM_M018();
        public MultipleContext_ADM_M018 MCTemp
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

        private ADM_M018 _MasterEntity;
        public ADM_M018 MasterEntity
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

        #endregion

        #region List
        private List<ADM_M018> _CategoryViewList;
        public List<ADM_M018> CategoryViewList
        {
            get { return _CategoryViewList; }
            set
            {
                if (_CategoryViewList != value)
                {
                    _CategoryViewList = value;
                    RaisePropertyChanged("PhaseViewList");
                }
            }
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> cmdInsertAccountCategory { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }

        #endregion

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        #endregion

        #region Constructor
        public MM_M0005_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M018();
            CategoryViewList = new List<ADM_M018>();
            MasterEntity.ValidateAsync().Wait();

            #region Command Initialisation

            cmdInsertAccountCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccountCategory(cmdPara); });
            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNo(cmdPara, "FlipGridReference"); });

            #endregion
            LoadInitialData();
        }
        #endregion

        #region User Defined Methods

        private void LoadDocumentByDocumentNo(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ADM_M018 ParameterEntityObject = null;
                MasterEntity = new ADM_M018();


                if (((IEnumerable)ParameterObject).Cast<ADM_M018>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M018>().ToList()[0];

                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.CatCode;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M018>(MCTemp, Request, "CategoryMaster", "Administration", "LoadDocumentByDocumentNumber", 0, MasterEntity.CatCode);

                    MasterEntity = MCTemp.MasterList[0];

                    NewRecord = false;
                    SelectedTabControlIndex = 0;

                    var msg = new NotificationMessage("MM_M0005_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }

                // Account Category List
                ASAccountCat.AutoSuggestVM.Suggestion = MC.AccountCategoryList.Find(x => x.acc_cat == MasterEntity.acc_cat);
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
                if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.MasterList = (List<ADM_M018>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.MasterList);
                    CategoryViewList.Add(MC.MasterList[0]);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("CatCode", ListSortDirection.Descending));
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
        private bool Validation()
        {
            if (MasterEntity.CatCode == null || MasterEntity.CatCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Category Code");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.CatName == null || MasterEntity.CatName == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Category Name");
                showMessageService.ShowMessage();
                return false;
            }
            //else if (MasterEntity.acc_cat == null || MasterEntity.acc_cat == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Account Category");
            //    showMessageService.ShowMessage();
            //    return false;
            //} 
            return true;
        }
        private void InsertAccountCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_K POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountCategoryList.Where(x => x.acc_cat.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_K>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_K>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.acc_cat = POPUPEntityObject.acc_cat;
                    MasterEntity.short_name = POPUPEntityObject.short_name;
                    MasterEntity.cat_desc = POPUPEntityObject.cat_desc;
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
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M018>(MC, Request, "CategoryMaster", "Administration", "LoadAll", 0, "");

                #region AutoSuggest Initialisation

                //Account Category
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_K)x).acc_cat);
                TheFilter = (o, prefix) => (((ACC_M003_K)o).acc_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_K)o).cat_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ACC_M003_K)o).short_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASAccountCat = new AutoSuggestTextViewModel<dynamic>(MC.AccountCategoryList, TheFilter, SuggestedValue, "value_class", true);
                ASAccountCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                CategoryViewList = MC.MasterList.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(CategoryViewList);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_CategoryGridData);

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
        protected override void OnSaveAction(InquiryActionResult<ADM_M018> result)
        {
            try
            {
                ObjectSerializationService objser = new ObjectSerializationService();
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;

                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity.add_by = AppSessionState.UserID;
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M018>(MasterEntity, "CategoryMaster", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity.editby = AppSessionState.UserID;
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M018>(MasterEntity, "CategoryMaster", "Administration");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M018> result)
        {
            try
            {
                NewRecord = true;
                MasterEntity = new ADM_M018();
                MasterEntity.ValidateAsync().Wait();
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
        protected override void OnRemoveAction(InquiryActionResult<ADM_M018> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M018> result)
        {
            //MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M018> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M018> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M018> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M018> result)
        {

        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M018> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M018> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filter Phases
        public bool Filter_CategoryGridData(object obj)
        {
            var data = obj as ADM_M018;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCategory))
                {
                    return (data.acc_cat != null && data.acc_cat.ToString().ToLower().Contains(_filterStringCategory.ToLower()) ||
                            data.cat_desc != null && data.cat_desc.ToString().ToLower().Contains(_filterStringCategory.ToLower()) ||
                            data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterStringCategory.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringCategory;
        public string filterStringCategory
        {
            get { return _filterStringCategory; }
            set
            {
                _filterStringCategory = value;
                RaisePropertyChanged("filterStringCategory");
                FilterStringCategory();
            }
        }
        private void FilterStringCategory()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }


        #endregion
    }
}
