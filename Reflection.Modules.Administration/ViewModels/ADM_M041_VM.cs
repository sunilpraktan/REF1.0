using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System.Windows.Data;
using Reflection.Presentation.ViewModel;
using System.ComponentModel;
using Reflection.BusinessEntity;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections;
using Reflection.BusinessEntity.Admin;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M041_VM : WorkspaceViewModel<ADM_M041>
    {
        #region AutoSuggest Textbox Declaration Region

        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }

        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "item_group_code")
                    { ASDefault = ASIGCode; }
                    else if (SourceName == "incoterms")
                    { ASDefault = ASIncoterms; }
                    else if (SourceName == "currency")
                    { ASDefault = ASCurrency; }
                    else if (SourceName == "local_currency")
                    { ASDefault = ASLocalCurrency; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUnit; }
                    else if (SourceName == "wt_unit")
                    { ASDefault = ASWtUnit; }
                }
            }
        }

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

        private AutoSuggestTextViewModel<dynamic> _ASLicType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLicType
        {
            get { return _ASLicType; }
            set
            {
                if (_ASLicType != value)
                {
                    _ASLicType = value; RaisePropertyChanged("ASLicType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLicCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLicCat
        {
            get { return _ASLicCat; }
            set
            {
                if (_ASLicCat != value)
                {
                    _ASLicCat = value; RaisePropertyChanged("ASLicCat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASIGCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIGCode
        {
            get { return _ASIGCode; }
            set
            {
                if (_ASIGCode != value)
                {
                    _ASIGCode = value; RaisePropertyChanged("ASIGCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASIncoterms { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIncoterms
        {
            get { return _ASIncoterms; }
            set
            {
                if (_ASIncoterms != value)
                {
                    _ASIncoterms = value; RaisePropertyChanged("ASIncoterms");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCurrency
        {
            get { return _ASCurrency; }
            set
            {
                if (_ASCurrency != value)
                {
                    _ASCurrency = value; RaisePropertyChanged("ASCurrency");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocalCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocalCurrency
        {
            get { return _ASLocalCurrency; }
            set
            {
                if (_ASLocalCurrency != value)
                {
                    _ASLocalCurrency = value; RaisePropertyChanged("ASLocalCurrency");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWtUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWtUnit { get; set; }

        #endregion

        #region Declaration

        bool NewRecord = true;
        WebServiceRepository<ADM_M041> repository = new WebServiceRepository<ADM_M041>();
        WebServiceRepository<MultipleContext_ADM_M041> repository_MC = new WebServiceRepository<MultipleContext_ADM_M041>();
        WebServiceRepository<MultipleContext_ADM_M041> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M041>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_ADM_M041 _MC = new MultipleContext_ADM_M041();
        public MultipleContext_ADM_M041 MC
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

        private MultipleContext_ADM_M041 _MCTemp = new MultipleContext_ADM_M041();
        public MultipleContext_ADM_M041 MCTemp
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

        private ADM_M041 _MasterEntity;
        public ADM_M041 MasterEntity
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

        private ObservableCollection<ADM_M041_C> _ItemsEntity;
        public ObservableCollection<ADM_M041_C> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    RaisePropertyChanged(nameof(ItemsEntity));
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

        private List<ADM_M041Flip> _FlipGridData;
        public List<ADM_M041Flip> FlipGridData
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

        private List<ADM_M002> _Companys;
        public List<ADM_M002> Companys
        {
            get { return _Companys; }
            set
            {
                if (_Companys != value)
                {
                    _Companys = value;
                    RaisePropertyChanged("Companys");
                }
            }
        }

        private string _visibility1;
        public string visibility1
        {
            get { return _visibility1; }
            set
            {
                if (_visibility1 != value)
                {
                    _visibility1 = value;
                    RaisePropertyChanged("visibility1");
                }
            }
        }

        private string _visibility2;
        public string visibility2
        {
            get { return _visibility2; }
            set
            {
                if (_visibility2 != value)
                {
                    _visibility2 = value;
                    RaisePropertyChanged("visibility2");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");

                }
            }
        }


        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLicenseType { get; private set; }
        public RelayCommand<object> cmdSionNo { get; private set; }
        public RelayCommand<object> cmdCompany { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand BankDetailsChangedCommand { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand BondDetailsChangedCommand { get; private set; }
        public RelayCommand<object> CmdItemGroupCode { get; private set; }
        public RelayCommand<object> CmdIncoterms { get; private set; }
        public RelayCommand<object> CmdCurrency { get; private set; }
        public RelayCommand<object> CmdLocalCurrency { get; private set; }
        public RelayCommand<object> CmdUnit { get; private set; }
        public RelayCommand<object> CmdWtUnit { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        #endregion

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        private ICollectionView _LicenseTypeCollection;
        public ICollectionView LicenseTypeCollection
        {
            get { return _LicenseTypeCollection; }
            set { _LicenseTypeCollection = value; RaisePropertyChanged("LicenseTypeCollection"); }
        }
        private ICollectionView _SionNoCollection;
        public ICollectionView SionNoCollection
        {
            get { return _SionNoCollection; }
            set { _SionNoCollection = value; RaisePropertyChanged("SionNoCollection"); }
        }
        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }
        #endregion

        #region . StringList .       
        private List<string> _StringListLicenseType;
        public List<string> StringListLicenseType
        {
            get { return _StringListLicenseType; }
            set
            {
                if (_StringListLicenseType != value)
                {
                    _StringListLicenseType = value;
                }
            }
        }
        private List<string> _StringListSionNo;
        public List<string> StringListSionNo
        {
            get { return _StringListSionNo; }
            set
            {
                if (_StringListSionNo != value)
                {
                    _StringListSionNo = value;
                }
            }
        }
        private List<string> _StringListCompany;
        public List<string> StringListCompany
        {
            get { return _StringListCompany; }
            set
            {
                if (_StringListCompany != value)
                {
                    _StringListCompany = value;
                }
            }
        }
        #endregion

        #region Constructor
        public ADM_M041_VM() : base()
        {
            MasterEntity = new ADM_M041();
            ItemsEntity = new ObservableCollection<ADM_M041_C>();
            FlipGridData = new List<ADM_M041Flip>();
            MasterEntity.ValidateAsync().Wait();
            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdLicenseType = new RelayCommand<object>(items => { if (items == null) { return; } InsertLicenseType(items); });
            cmdSionNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertSionNo(items); });
            cmdCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            BankDetailsChangedCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonAselectionChanged(); });
            BondDetailsChangedCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonBselectionChanged(); });
            CmdItemGroupCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemGroupCode(cmdPara, true, true, true); });
            CmdIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara, true, true, true); });
            CmdCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCurrency(cmdPara, true, true, true); });
            CmdLocalCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocalCurrency(cmdPara, true, true, true); });
            CmdUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnit(cmdPara, true, true, true); });
            CmdWtUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWeightUnit(cmdPara, true, true, true); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
            LoadInitialData();
        }
        #endregion

        #region User Defined Methods

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndex].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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
        private void RadioButtonAselectionChanged()
        {
            visibility1 = "Visible";
            visibility2 = "Collapsed";
        }
        private void RadioButtonBselectionChanged()
        {
            visibility1 = "Collapsed";
            visibility2 = "Visible";
        }
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.add_date = DateTime.Now;
            MasterEntity.edit_by = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.t_status = "Draft";
        }

        private void SetValues()
        {
            if (MasterEntity.ButtonAIsChecked == true)
            {
                MasterEntity.bgb_details = "Bank Guarantee";
            }
            else
            {

                MasterEntity.bgb_details = "Bond Details";
            }
        }
        private void InsertItemGroupCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            //try
            //{
            //    string Request = "";
            //    ADM_M022_B_P POPUPEntityObject = null;
            //    dgSelectedIndex = dgSelectedIndex;
            //    #region Command Parameter Read Section
            //    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            try
            //            { POPUPEntityObject = MC.ItemGroupMaster.Where(x => x.item_group_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
            //            catch (Exception ex) { }
            //        }
            //    }
            //    else if (InputValue != null)
            //    {
            //        if (((IEnumerable)InputValue).Cast<ADM_M022_B_P>().Count() > 0)
            //        {
            //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_B_P>().ToList()[0];
            //        }
            //    }
            //    #endregion

            //    if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            //    {
            //        if (dgSelectedIndex != -1)
            //        {
            //            var InputValueIfExists = ItemsEntity.Where(X => X.item_group_code == POPUPEntityObject.item_group_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
            //            int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.item_group_code == POPUPEntityObject.item_group_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

            //            if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
            //            {
            //                if (id == 0 && (AllowDuplicate == true))
            //                {

            //                    ItemsEntity.Add(new ADM_M041_C()
            //                    {
            //                        id = 0,
            //                        location_Id = AppSessionState.location_Id,
            //                        comp_code = AppSessionState.comp_code,
            //                        add_by = AppSessionState.UserID,
            //                        t_status = "Draft",
            //                        active = true,
            //                        item_group_code = POPUPEntityObject.item_group_code,
            //                        prod_desc = POPUPEntityObject.prod_desc,
            //                    });

            //                }
            //                else
            //                {
            //                   item_group_code = POPUPEntityObject.item_group_code,
            //                  prod_desc = POPUPEntityObject.prod_desc,
            //                   active = true,
            //                }

            //            }
            //        }
            //    }
            //    #region Clear Empty Row
            //    ADM_M041_C newObj = new ADM_M041_C();
            //    for (int i = ItemsEntity.Count - 1; i >= 0; i--)
            //    {
            //        bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
            //        if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
            //        {
            //            ItemsEntity.RemoveAt(i);
            //            if (ItemsEntity.Count == 0)
            //            {
            //                ItemsEntity.Add(newObj);
            //            }
            //        }
            //    }
            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();
            //}

            string Request = "";
            ADM_M022_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemGroupMaster.Where(x => x.item_group_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_B_P>().ToList()[0];
                }

            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.item_group_code == POPUPEntityObject.item_group_code).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.item_group_code == POPUPEntityObject.item_group_code).FirstOrDefault());
                //Insert
                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndex)
                {
                    ItemsEntity.Add(new ADM_M041_C()
                    {
                        id = 0,
                        active = true,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        t_status = "Draft",
                        item_group_code = POPUPEntityObject.item_group_code,
                        prod_desc = POPUPEntityObject.prod_desc,
                        

                    });
                }
                //update
                else if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
                {
                    if (ItemsEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndex].item_group_code = POPUPEntityObject.item_group_code;
                        ItemsEntity[dgSelectedIndex].prod_desc = POPUPEntityObject.prod_desc;
                        ItemsEntity[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                        ItemsEntity[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                        ItemsEntity[dgSelectedIndex].add_by = AppSessionState.UserID;
                        ItemsEntity[dgSelectedIndex].active = true;
                        ItemsEntity[dgSelectedIndex].t_status = "Draft";
                    }
                    else if (ItemsEntity[dgSelectedIndex].item_group_code != POPUPEntityObject.item_group_code)
                    {
                        ItemsEntity[dgSelectedIndex].item_group_code = "";
                        ItemsEntity[dgSelectedIndex].prod_desc = "";
                    }
                }

            }
        }
        private void InsertIncoterms(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M044_P POPUPEntityObject = null;
            //Command Parameter Read section
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.Incoterms.Where(x => x.incoterms.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M044_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M044_P>().ToList()[0];
                }
            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.incoterms == POPUPEntityObject.incoterms).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.incoterms == POPUPEntityObject.incoterms).FirstOrDefault());
                if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
                {
                    if (ItemsEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndex].incoterms = POPUPEntityObject.incoterms;
                    }
                    else if (ItemsEntity[dgSelectedIndex].incoterms != POPUPEntityObject.incoterms)
                    {
                        ItemsEntity[dgSelectedIndex].incoterms = POPUPEntityObject.incoterms;
                    }
                }
            }
        }
        private void InsertCurrency(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M037_P POPUPEntityObject = null;
            //Command Parameter Read section
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.Currency.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M037_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }
            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.currency == POPUPEntityObject.curr_code).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.currency == POPUPEntityObject.curr_code).FirstOrDefault());
                if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
                {
                    if (ItemsEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndex].currency = POPUPEntityObject.curr_code;
                    }
                    else if (ItemsEntity[dgSelectedIndex].currency != POPUPEntityObject.curr_code)
                    {
                        ItemsEntity[dgSelectedIndex].currency = POPUPEntityObject.curr_code;
                    }
                }
            }
        }
        private void InsertLocalCurrency(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M037_P POPUPEntityObject = null;
            //Command Parameter Read section
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.Currency.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M037_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }
            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.local_currency == POPUPEntityObject.curr_code).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.local_currency == POPUPEntityObject.curr_code).FirstOrDefault());
                if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
                {
                    if (ItemsEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndex].local_currency = POPUPEntityObject.curr_code;
                    }
                    else if (ItemsEntity[dgSelectedIndex].local_currency != POPUPEntityObject.curr_code)
                    {
                        ItemsEntity[dgSelectedIndex].local_currency = POPUPEntityObject.curr_code;
                    }
                }
            }
        }
        private void InsertUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            //Command Parameter Read section
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.UnitMaster.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());
                if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
                {
                    if (ItemsEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                    }
                    else if (ItemsEntity[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                    {
                        ItemsEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                    }
                }
            }
        }
        private void InsertWeightUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            //Command Parameter Read section
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.UnitMaster.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.wt_unit == POPUPEntityObject.unit_code).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.wt_unit == POPUPEntityObject.unit_code).FirstOrDefault());
                if (dgSelectedIndex >= 0 && ItemsEntity.Count > dgSelectedIndex)
                {
                    if (ItemsEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndex].wt_unit = POPUPEntityObject.unit_code;
                    }
                    else if (ItemsEntity[dgSelectedIndex].wt_unit != POPUPEntityObject.unit_code)
                    {
                        ItemsEntity[dgSelectedIndex].wt_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ADM_M041Flip ParameterEntityObject = null;
            MasterEntity = new ADM_M041();


            if (((IEnumerable)ParameterObject).Cast<ADM_M041Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M041Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.lic_cod;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M041>(MCTemp, Request, "LicenseMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                ItemsEntity = MCTemp.ItemsEntity;
                if (MasterEntity.bgb_details == "Bank Guarantee")
                {
                    MasterEntity.ButtonAIsChecked = true;
                    MasterEntity.ButtonBIsChecked = false;
                }
                else if (MasterEntity.bgb_details == "Bond Details")
                {
                    MasterEntity.ButtonAIsChecked = false;
                    MasterEntity.ButtonBIsChecked = true;
                }
            }
            SelectedTabControlIndex = 0;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_ADM_M041_C != null)
            {
                ItemsEntity.Clear();
                ItemsEntity = (ObservableCollection<ADM_M041_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M041_C, MC.ItemsEntity);
            }
            else if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.FlipGridData = (List<ADM_M041Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.FlipGridData);
                FlipGridData.Add(MC.FlipGridData[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("lic_cod", ListSortDirection.Descending));
            }
        }
        private void InsertLicenseType(object InputValue)
        {
            string Request = "";
            ADM_M041_A POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.LicenseType.Where(x => x.licn_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M041_A>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_A>().ToList()[0];
                    }
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.lic_type = POPUPEntityObject.licn_type;
            }
        }
        private void InsertSionNo(object InputValue)
        {
            string Request = "";
            ADM_M041_B_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SionNo.Where(x => x.sion_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M041_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_B_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.sion_no = POPUPEntityObject.sion_no;

            }
        }
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = Companys.Where(x => x.CompName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                    }
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.comp_code = POPUPEntityObject.comp_code;
                MasterEntity.CompName = POPUPEntityObject.CompName;
            }
        }
        private bool Validation()
        {

            if (MasterEntity.lic_desc == null || MasterEntity.lic_desc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter License No...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.lic_type == null || MasterEntity.lic_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter License Type...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M041>(MC, Request, "LicenseMaster", "Administration", "LoadInitialData", 0, "");

                #region AutoSuggest LoadInitial Data

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_A)x).licn_type);
                TheFilter = (o, prefix) => ((ADM_M041_A)o).licn_type.ToLower().Contains(prefix);
                ASLicType = new AutoSuggestTextViewModel<dynamic>(MC.LicenseType, TheFilter, SuggestedValue, "licn_type", true);
                ASLicType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_D_P)x).lic_cat_code);
                TheFilter = (o, prefix) => ((ADM_M041_D_P)o).lic_cat_code.ToLower().Contains(prefix) || ((ADM_M041_D_P)o).lic_cat_desc.ToLower().Contains(prefix);
                ASLicCat = new AutoSuggestTextViewModel<dynamic>(MC.LicenseCatMaster, TheFilter, SuggestedValue, "lic_cat_code", true);
                ASLicCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_B_P)x).item_group_code);
                TheFilter = (o, prefix) => ((ADM_M022_B_P)o).item_group_code.ToLower().Contains(prefix) || ((ADM_M022_B_P)o).item_group_desc.ToLower().Contains(prefix) || ((ADM_M022_B_P)o).prod_desc.ToLower().Contains(prefix);
                ASIGCode = new AutoSuggestTextViewModel<dynamic>(MC.ItemGroupMaster, TheFilter, SuggestedValue, "item_group_code", "item_group_code", true);
                ASIGCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => ((ADM_M044_P)o).incoterms.ToLower().Contains(prefix) || ((ADM_M044_P)o).inco_desc.ToLower().Contains(prefix);
                ASIncoterms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASIncoterms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => ((ADM_M037_P)o).curr_code.ToLower().Contains(prefix) || ((ADM_M037_P)o).curr_name.ToLower().Contains(prefix);
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currency, TheFilter, SuggestedValue, "currency", "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => ((ADM_M037_P)o).curr_code.ToLower().Contains(prefix) || ((ADM_M037_P)o).curr_name.ToLower().Contains(prefix);
                ASLocalCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currency, TheFilter, SuggestedValue, "local_currency", "curr_code", true);
                ASLocalCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix);
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix);
                ASWtUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "wt_unit", "unit_code", true);
                ASWtUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                FlipGridData = MC.FlipGridData.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);

                LicenseTypeCollection = CollectionViewSource.GetDefaultView(MC.LicenseType);
                LicenseTypeCollection.Filter = new Predicate<object>(Filter_License);
                StringListLicenseType = MC.LicenseType.Select(x => x.licn_type.ToString()).ToList();

                SionNoCollection = CollectionViewSource.GetDefaultView(MC.SionNo);
                SionNoCollection.Filter = new Predicate<object>(Filter_SionNo);
                StringListSionNo = MC.SionNo.Select(x => x.sion_no.ToString()).ToList();

                Companys = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(Companys.ToList());
                CompanyCollection.Filter = new Predicate<object>(Filter_Company);
                StringListCompany = Companys.Select(x => x.CompName.ToString()).ToList();

                DefaultValues();
                MasterEntity.ButtonAIsChecked = true;
                MasterEntity.ButtonBIsChecked = false;

                if (MasterEntity.ButtonAIsChecked == true)
                {
                    visibility1 = "Visible";
                    visibility2 = "Collapsed";
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

        #region CommandAction
        protected override void OnCreateAction(InquiryActionResult<ADM_M041> result)
        {
            NewRecord = true;
            MasterEntity = new ADM_M041();
            ItemsEntity = new ObservableCollection<ADM_M041_C>();
            DefaultValues();
            MasterEntity.ButtonAIsChecked = true;
            MasterEntity.ButtonBIsChecked = false;


        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M041> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ADM_M041> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M041> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M041> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M041> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M041> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M041> result)
        {
            try
            {
                if (Validation() == true)
                {
                    SetValues();
                    MasterEntity.edit_by = AppSessionState.UserID;
                    MasterEntity.XmlDataDocument_ADM_M041_C = obj.ObjectToXML(ItemsEntity);
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M041>(MasterEntity, "LicenseMaster", "Administration");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M041>(MasterEntity, "LicenseMaster", "Administration");
                    }

                    if (MasterEntity.bgb_details == "Bank Guarantee")
                    {
                        MasterEntity.ButtonAIsChecked = true;
                        MasterEntity.ButtonBIsChecked = false;
                    }
                    else if (MasterEntity.bgb_details == "Bond Details")
                    {
                        MasterEntity.ButtonBIsChecked = true;
                        MasterEntity.ButtonAIsChecked = false;
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.lic_cod != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.lic_cod != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }

                    NewRecord = false;

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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M041> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M041> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M041> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M041> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M041> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters
        #region Filter For Flip Grid Data
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as ADM_M041Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.lic_cod != null && data.lic_cod.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.lic_desc != null && data.lic_desc.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.lic_type != null && data.lic_type.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.sion_no != null && data.sion_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.registration_port != null && data.registration_port.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.bgb_no != null && data.bgb_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.bgb_amt != null && data.bgb_amt.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.bgb_register_at != null && data.bgb_register_at.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filter For License Type
        private string _FilterStringLicenseType;
        public string FilterStringLicenseType
        {
            get { return _FilterStringLicenseType; }
            set
            {
                _FilterStringLicenseType = value;
                RaisePropertyChanged("FilterStringLicenseType");
                Filter_LicenseType();
            }
        }
        private void Filter_LicenseType()
        {
            if (_LicenseTypeCollection != null)
            {
                _LicenseTypeCollection.Refresh();
            }
        }
        public bool Filter_License(object obj)
        {
            var data = obj as ADM_M041_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringLicenseType))
                {
                    return (data.licn_type != null && data.licn_type.ToString().ToLower().Contains(_FilterStringLicenseType.ToLower())) ||
                           (data.licn_desc != null && data.licn_desc.ToString().ToLower().Contains(_FilterStringLicenseType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filter For Sion No
        private string _FilterStringSionNo;
        public string FilterStringSionNo
        {
            get { return _FilterStringSionNo; }
            set
            {
                _FilterStringSionNo = value;
                RaisePropertyChanged("FilterStringSionNo");
                Filter_SionNo();
            }
        }
        private void Filter_SionNo()
        {
            if (_SionNoCollection != null)
            {
                _SionNoCollection.Refresh();
            }
        }
        public bool Filter_SionNo(object obj)
        {
            var data = obj as ADM_M041_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringSionNo))
                {
                    return (data.sion_no != null && data.sion_no.ToString().ToLower().Contains(_FilterStringSionNo.ToLower())) ||
                           (data.sion_desc != null && data.sion_desc.ToString().ToLower().Contains(_FilterStringSionNo.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Filter For Company
        private string _FilterStringCompany;
        public string FilterStringCompany
        {
            get { return _FilterStringCompany; }
            set
            {
                _FilterStringCompany = value;
                RaisePropertyChanged("FilterStringCompany");
                Filter_Company();
            }
        }
        private void Filter_Company()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        public bool Filter_Company(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringCompany))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FilterStringCompany.ToLower())) ||
                           (data.CompName != null && data.CompName.ToString().ToLower().Contains(_FilterStringCompany.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion
        #endregion

    }
}
