using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.Production.ViewModels
{
    public class ECRM_T003_A_VM_PROD_2 : WorkspaceViewModel<ECRM_T003_A_New>
    {
        #region Declaration
        bool isNewRecord = true;
        WebServiceRepository<ECRM_T003_A_New> repository = new WebServiceRepository<ECRM_T003_A_New>();
        WebServiceRepository<MultipleContext_ECRM_T003> repository_MC = new WebServiceRepository<MultipleContext_ECRM_T003>();
        WebServiceRepository<MultipleContext_ECRM_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_ECRM_T003>();

        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                }
            }
        }

        private MultipleContext_ECRM_T003 _MC = new MultipleContext_ECRM_T003();
        public MultipleContext_ECRM_T003 MC
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

        private MultipleContext_ECRM_T003 _MCTemp = new MultipleContext_ECRM_T003();
        public MultipleContext_ECRM_T003 MCTemp
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

        private ECRM_T003_A_New _MasterEntity;
        public ECRM_T003_A_New MasterEntity
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

        private ObservableCollection<ECRM_T003_B_New> _ItemsEntity;
        public ObservableCollection<ECRM_T003_B_New> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private List<ECRM_T003_AFlip> _FlipGridData;
        public List<ECRM_T003_AFlip> FlipGridData
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

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
                }
            }
        }
        #endregion

        #region Model Entity Updated
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "" || sender.ToString() == "")
            {

            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            if (sender.ToString() == "watstb")
            {
                Calwaclgc();
            }
            if (sender.ToString() == "refilno" || sender.ToString() == "wbtsta" || sender.ToString() == "waclgc" || sender.ToString() == "active")//|| sender.ToString() == "watstb")
            {
                CalGooping();
            }
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/

        }
        private void Calwaclgc()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].wbtsta >= ItemsEntity[dgSelectedIndexItem].waclgc && ItemsEntity[dgSelectedIndexItem].watstb >= ItemsEntity[dgSelectedIndexItem].waclgc)
                {
                    if (ItemsEntity[dgSelectedIndexItem].watstb <= ItemsEntity[dgSelectedIndexItem].wbtsta)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].wbtsta >= ItemsEntity[dgSelectedIndexItem].waclgc && ItemsEntity[dgSelectedIndexItem].watstb >= ItemsEntity[dgSelectedIndexItem].waclgc)
                        {
                            ItemsEntity[dgSelectedIndexItem].waclgc = ItemsEntity[dgSelectedIndexItem].watstb;
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text = String.Format("B Weight Should Be Less than A Weight", this.Title);
                        showMessageService.ShowMessage();
                        ItemsEntity[dgSelectedIndexItem].watstb = 0;
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
        private void CalGooping()
        {
            try
            {
                if (ItemsEntity.Count > 0)
                {

                    IList<ECRM_T003_B_New> DistinctRefilNo = (from o in ItemsEntity where o.refilno == ItemsEntity[dgSelectedIndexItem].refilno select o).ToList();

                    if (DistinctRefilNo.Count() <= 1)
                    {
                        if (WtCompare() == true)
                        {
                            MasterEntity.amxild = ItemsEntity.Max(X => X.ild);
                            MasterEntity.amnild = ItemsEntity.Min(X => X.ild);
                            MasterEntity.aavild = ItemsEntity.Average(X => X.ild);
                            MasterEntity.aavgoo = ItemsEntity.Average(X => X.gooping);
                            MasterEntity.tavgoo = ItemsEntity.Sum(X => X.gooping);
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Refill No Should not be Duplicate", this.Title);
                        showMessageService.ShowMessage();
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
        private bool WtCompare()
        {
            try
            {
                if (MasterEntity.lotno == null || MasterEntity.lotno == "" || MasterEntity.shift == null || MasterEntity.shift == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Lot No. and Shift...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (ItemsEntity[dgSelectedIndexItem].wbtsta > 3)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Weight";
                    showMessageService.Text = String.Format("A Weight Should Be Less than 3", this.Title);
                    showMessageService.ShowMessage();
                    ItemsEntity[dgSelectedIndexItem].wbtsta = 0;
                    return false;
                }
                else if (ItemsEntity[dgSelectedIndexItem].watstb > 3)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Weight";
                    showMessageService.Text = String.Format("B Weight Should Be Less than 3", this.Title);
                    showMessageService.ShowMessage();
                    ItemsEntity[dgSelectedIndexItem].watstb = 0;
                    return false;
                }
                else if (ItemsEntity[dgSelectedIndexItem].watstb > ItemsEntity[dgSelectedIndexItem].wbtsta)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Weight";
                    showMessageService.Text = String.Format("B Weight Should be Less than A Weight", this.Title);
                    showMessageService.ShowMessage();
                    ItemsEntity[dgSelectedIndexItem].watstb = 0;
                    return false;
                }
                else if (ItemsEntity[dgSelectedIndexItem].waclgc > ItemsEntity[dgSelectedIndexItem].wbtsta)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Weight";
                    showMessageService.Text = String.Format("C Weight Should be Less than A Weight", this.Title);
                    showMessageService.ShowMessage();
                    ItemsEntity[dgSelectedIndexItem].waclgc = 0;
                    return false;
                }
                else if (ItemsEntity[dgSelectedIndexItem].waclgc > ItemsEntity[dgSelectedIndexItem].watstb)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Weight";
                    showMessageService.Text = String.Format("C Weight Should be Less than B Weight", this.Title);
                    showMessageService.ShowMessage();
                    ItemsEntity[dgSelectedIndexItem].waclgc = 0;
                    return false;
                }
                RowCalculation();
                return true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
                return false;
            }
        }
        private void RowCalculation()
        {
            //calculate gooping, actual gooping, target gooping
            try
            {
                decimal gooping;
                decimal mulfact;

                int MType = Convert.ToInt32(MasterEntity.tm);

                if (MType == 200)
                {
                    mulfact = Convert.ToDecimal(0.5);
                }
                else if (MType == 100)
                {
                    mulfact = 1;
                }
                else if (MType == 50)
                {
                    mulfact = 2;
                }
                else
                {
                    mulfact = 4;
                }
                // Calculate respective ild and Gooping...            
                ItemsEntity[dgSelectedIndexItem].ild = (Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].wbtsta) - Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].watstb)) * Convert.ToDecimal(1000) * Convert.ToDecimal(mulfact);

                decimal weight = (Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].wbtsta) - Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].waclgc));

                if (weight == 0 || weight == Convert.ToDecimal(0.0))
                {
                    gooping = 0;
                }
                else
                {
                    gooping = (Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].watstb) - Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].waclgc)) / (weight) * 100;
                }

                ItemsEntity[dgSelectedIndexItem].gooping = Math.Round(gooping, 6);

            }
            catch (Exception ex)
            {

            }
        }

        #endregion    

        #region Collection
        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set { _DataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _ConvLotCollection;// ConvLot Collection
        public ICollectionView ConvLotCollection
        {
            get { return _ConvLotCollection; }
            set
            {
                _ConvLotCollection = value;
                RaisePropertyChanged("ConvLotCollection");
            }
        }
        private ICollectionView _MachineCollection;// Machine Collection
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }
        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }
        private ICollectionView _ILDCollection;
        public ICollectionView ILDCollection
        {
            get { return _ILDCollection; }
            set { _ILDCollection = value; RaisePropertyChanged("ILDCollection"); }
        }
        private ICollectionView _ModelsCollection;
        public ICollectionView ModelsCollection
        {
            get { return _ModelsCollection; }
            set { _ModelsCollection = value; RaisePropertyChanged("ModelsCollection"); }
        }
        private ICollectionView _INKCollection;
        public ICollectionView INKCollection
        {
            get { return _INKCollection; }
            set { _INKCollection = value; RaisePropertyChanged("INKCollection"); }
        }
        private ICollectionView _DefectCollection;
        public ICollectionView DefectCollection
        {
            get { return _DefectCollection; }
            set { _DefectCollection = value; RaisePropertyChanged("DefectCollection"); }
        }
        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set { _ShiftCollection = value; RaisePropertyChanged("ShiftCollection"); }
        }
        private ICollectionView _OperatorCollection;
        public ICollectionView OperatorCollection
        {
            get { return _OperatorCollection; }
            set
            {
                _OperatorCollection = value;
                RaisePropertyChanged("OperatorCollection");
            }
        }
        private ICollectionView _TestTypeCollection;
        public ICollectionView TestTypeCollection
        {
            get { return _TestTypeCollection; }
            set { _TestTypeCollection = value; RaisePropertyChanged("TestTypeCollection"); }
        }

        private ICollectionView _BatchCollection;
        public ICollectionView BatchCollection
        {
            get { return _BatchCollection; }
            set { _BatchCollection = value; RaisePropertyChanged("BatchCollection"); }
        }
        #endregion

        #region StringList
        List<string> _StringListConvLot;
        public List<string> StringListConvLot
        {
            get { return _StringListConvLot; }
            set
            {
                if (_StringListConvLot != value)
                {
                    _StringListConvLot = value;
                }
            }
        }
        List<string> _StringListMachine;
        public List<string> StringListMachine
        {
            get { return _StringListMachine; }
            set
            {
                if (_StringListMachine != value)
                {
                    _StringListMachine = value;
                }
            }
        }
        List<string> _StringListItem;
        public List<string> StringListItem
        {
            get { return _StringListItem; }
            set
            {
                if (_StringListItem != value)
                {
                    _StringListItem = value;
                }
            }
        }

        List<string> _StringListILD;
        public List<string> StringListILD
        {
            get { return _StringListILD; }
            set
            {
                if (_StringListILD != value)
                {
                    _StringListILD = value;
                }
            }
        }
        List<string> _StringListModels;
        public List<string> StringListModels
        {
            get { return _StringListModels; }
            set
            {
                if (_StringListModels != value)
                {
                    _StringListModels = value;
                }
            }
        }
        List<string> _StringListINK;
        public List<string> StringListINK
        {
            get { return _StringListINK; }
            set
            {
                if (_StringListINK != value)
                {
                    _StringListINK = value;
                }
            }
        }
        List<string> _StringListDefect;
        public List<string> StringListDefect
        {
            get { return _StringListDefect; }
            set
            {
                if (_StringListDefect != value)
                {
                    _StringListDefect = value;
                }
            }
        }
        List<string> _StringListShift;
        public List<string> StringListShift
        {
            get { return _StringListShift; }
            set
            {
                if (_StringListShift != value)
                {
                    _StringListShift = value;
                }
            }
        }
        List<string> _StringListOperator;
        public List<string> StringListOperator
        {
            get { return _StringListOperator; }
            set
            {
                if (_StringListOperator != value)
                {
                    _StringListOperator = value;
                }
            }
        }

        List<string> _StringListTestType;
        public List<string> StringListTestType
        {
            get { return _StringListTestType; }
            set
            {
                if (_StringListTestType != value)
                {
                    _StringListTestType = value;
                }
            }
        }

        private List<string> _StringListBatch;
        public List<string> StringListBatch
        {
            get { return _StringListBatch; }
            set
            {
                if (_StringListBatch != value)
                {
                    _StringListBatch = value;
                }
            }
        }
        #endregion

        #region Filters
        #region Filters For BF
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter();
            }
        }
        private void Filter()
        {
            if (_DataGridCollection != null)
            {
                _DataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ECRM_T003_AFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.wtno != null && data.wtno.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters for Machines
        private string _FilterStringMachineCode;
        public string FilterStringMachineCode
        {
            get { return _FilterStringMachineCode; }
            set
            {
                _FilterStringMachineCode = value;
                RaisePropertyChanged("FilterStringMachineCode");
                Filter_MachineCode();
            }
        }
        private void Filter_MachineCode()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool Filter_MachineCode(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMachineCode))
                {
                    return (data.machine_id.ToString() != null && data.machine_id.ToString().ToLower().Contains(_FilterStringMachineCode.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringMachineCode.ToLower())) ||
                           (data.machinesrno != null && data.machinesrno.ToString().ToLower().Contains(_FilterStringMachineCode.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Items

        private string _FilterStringItemList;
        public string FilterStringItemList
        {
            get { return _FilterStringItemList; }
            set
            {
                _FilterStringItemList = value;
                RaisePropertyChanged("FilterStringItemList");
                Filter_ItemList();
            }
        }
        private void Filter_ItemList()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_ItemList(object obj)
        {
            var data = obj as ADM_M022_P_ESSEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringItemList))
                {
                    return (data.ItemCode.ToString() != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringItemList.ToLower())) ||
                           (data.Description != null && data.Description.ToString().ToLower().Contains(_FilterStringItemList.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringItemList.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters for INK
        private string _FilterStringINK;
        public string FilterStringINK
        {
            get { return _FilterStringINK; }
            set
            {
                _FilterStringINK = value;
                RaisePropertyChanged("FilterStringINK");
                Filter_INK();
            }
        }
        private void Filter_INK()
        {
            if (_INKCollection != null)
            {
                _INKCollection.Refresh();
            }
        }
        public bool Filter_INK(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringINK))
                {
                    return (data.ink_id.ToString() != null && data.ink_id.ToString().ToLower().Contains(_FilterStringINK.ToLower())) ||
                           (data.ink != null && data.ink.ToString().ToLower().Contains(_FilterStringINK.ToLower())) ||
                           (data.desc != null && data.desc.ToString().ToLower().Contains(_FilterStringINK.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For MOdels
        private string _FilterStringModels;
        public string FilterStringModels
        {
            get { return _FilterStringModels; }
            set
            {
                _FilterStringModels = value;
                RaisePropertyChanged("FilterStringModels");
                Filter_Models();
            }
        }
        private void Filter_Models()
        {
            if (_ModelsCollection != null)
            {
                _ModelsCollection.Refresh();
            }
        }
        public bool Filter_Models(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringModels))
                {
                    return (data.model_id.ToString() != null && data.model_id.ToString().ToLower().Contains(_FilterStringModels.ToLower())) ||
                           (data.modelno != null && data.modelno.ToString().ToLower().Contains(_FilterStringModels.ToLower())) ||
                           (data.basicmodel != null && data.basicmodel.ToString().ToLower().Contains(_FilterStringModels.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Shift
        private string _FilterStringShift;
        public string FilterStringShift
        {
            get { return _FilterStringShift; }
            set
            {
                _FilterStringShift = value;
                RaisePropertyChanged("FilterStringShift");
                Filter_Shift();
            }
        }
        private void Filter_Shift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public bool Filter_Shift(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringModels))
                {
                    return (data.shift.ToString() != null && data.shift.ToString().ToLower().Contains(_FilterStringModels.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For ILD
        private string _filterStringILD;
        private void FilterCollectionILD()
        {
            if (_ILDCollection != null)
            {
                _ILDCollection.Refresh();
            }
        }
        public string FilterStringILD
        {
            get { return _filterStringILD; }
            set
            {
                _filterStringILD = value;
                RaisePropertyChanged("FilterStringILD");
                FilterCollectionILD();
            }
        }
        public bool ILDFilter(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD))
                {
                    return ((data.ild != null) && data.ild.ToLower().Contains(_filterStringILD.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Defect
        private string _filterStringDefect;
        private void FilterCollectionDefect()
        {
            if (_DefectCollection != null)
            {
                _DefectCollection.Refresh();
            }
        }
        public string FilterStringDefect
        {
            get { return _filterStringDefect; }
            set
            {
                _filterStringDefect = value;
                RaisePropertyChanged("FilterStringDefect");
                FilterCollectionDefect();
            }
        }
        public bool DefectFilter(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDefect))
                {
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringDefect.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Operator
        private string _filterStringOperator;
        private void FilterCollectionOperator()
        {
            if (_OperatorCollection != null)
            {
                _OperatorCollection.Refresh();
            }
        }
        public string FilterStringOperator
        {
            get { return _filterStringOperator; }
            set
            {
                _filterStringOperator = value;
                RaisePropertyChanged("FilterStringOperator");
                FilterCollectionOperator();
            }
        }
        public bool OperatorFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringOperator))
                {
                    return ((data.EmpId != null) && data.EmpId.ToLower().Contains(_filterStringOperator.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For TestType
        private string _filterStringTestType;
        private void FilterCollectionTestType()
        {
            if (_TestTypeCollection != null)
            {
                _TestTypeCollection.Refresh();
            }
        }
        public string FilterStringTestType
        {
            get { return _filterStringTestType; }
            set
            {
                _filterStringTestType = value;
                RaisePropertyChanged("FilterStringTestType");
                FilterCollectionTestType();
            }
        }
        public bool TestTypeFilter(object obj)
        {
            var data = obj as ECRM_T003_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTestType))
                {
                    return ((data.test_code != null) && data.test_code.ToLower().Contains(_filterStringTestType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Batch
        private string _FilterStringBatch;
        public string FilterStringBatch
        {
            get { return _FilterStringBatch; }
            set
            {
                _FilterStringBatch = value;
                RaisePropertyChanged("FilterStringBatch");
                Filter_Batch();
            }
        }
        private void Filter_Batch()
        {
            if (_BatchCollection != null)
            {
                _BatchCollection.Refresh();
            }
        }
        public bool Filter_Batch(object obj)
        {
            var data = obj as PPC_T003_Batch;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringBatch))
                {
                    return ((data.batch_no != null) && data.batch_no.ToLower().Contains(_FilterStringBatch.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdAddConvLot { get; private set; }
        public RelayCommand<object> CmdAddMachine { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddILDChart { get; private set; }
        public RelayCommand<object> CmdAddModels { get; private set; }
        public RelayCommand<object> CmdAddInk { get; private set; }
        public RelayCommand<object> CmdAddDefect { get; private set; }
        public RelayCommand<object> CmdAddShift { get; private set; }
        public RelayCommand<object> CmdAddTestType { get; private set; }
        public RelayCommand<object> CmdAddOperator { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddBatch { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public ECRM_T003_A_VM_PROD_2(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ECRM_T003_A_New();
            ItemsEntity = new ObservableCollection<ECRM_T003_B_New>();
            FlipGridData = new List<ECRM_T003_AFlip>();
            MC = new MultipleContext_ECRM_T003();
            MCTemp = new MultipleContext_ECRM_T003();
            MasterEntity.ValidateAsync().Wait();

            ECRM_T003_A_New.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ECRM_T003_B_New.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);

            
            LoadInitialData();

        }
        public ECRM_T003_A_VM_PROD_2(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ECRM_T003_A_New();
            ItemsEntity = new ObservableCollection<ECRM_T003_B_New>();
            FlipGridData = new List<ECRM_T003_AFlip>();
            MC = new MultipleContext_ECRM_T003();
            MCTemp = new MultipleContext_ECRM_T003();
            MasterEntity.ValidateAsync().Wait();

            ECRM_T003_A_New.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ECRM_T003_B_New.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);


            LoadInitialData();

        }
        private void ECRM_T003_A_New_ModelEntityUpdated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "WT";
                MasterEntity.doc_type = "WT";

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003>(MC, Request, "WritingTest2", "CRM", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdAddConvLot = new RelayCommand<object>(items => { if (items == null) { return; } InsertConvLot(items); });
                CmdAddMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
                CmdAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CmdAddILDChart = new RelayCommand<object>(items => { if (items == null) { return; } InsertILD(items); });
                CmdAddModels = new RelayCommand<object>(items => { if (items == null) { return; } InsertModels(items); });
                CmdAddInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertInk(items); });
                CmdAddDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefect(cmdPara, true, true, true); });
                CmdAddShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                CmdAddOperator = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperator(items); });
                CmdAddTestType = new RelayCommand<object>(items => { if (items == null) { return; } InsertTestType(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdAddBatch = new RelayCommand<object>(items => { if (items == null) { return; } InsertBatch(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                //ConvLotCollection = CollectionViewSource.GetDefaultView(MC.MasterEntity);
                //ConvLotCollection.Filter = new Predicate<object>(ConvLotFilter);
                //StringListConvLot = MC.MasterEntity.Select(x => x.machinecode).ToList();

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineCodeList);
                MachineCollection.Filter = new Predicate<object>(Filter_MachineCode);
                StringListMachine = MC.MachineCodeList.Select(x => x.machinecode).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_ItemList);
                StringListItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                ILDCollection = CollectionViewSource.GetDefaultView(MC.ILD);
                ILDCollection.Filter = new Predicate<object>(ILDFilter);
                StringListILD = MC.ILD.Select(x => x.ild).ToList();

                ModelsCollection = CollectionViewSource.GetDefaultView(MC.Models);
                ModelsCollection.Filter = new Predicate<object>(Filter_Models);
                StringListModels = MC.Models.Select(x => x.modelno).ToList();

                INKCollection = CollectionViewSource.GetDefaultView(MC.INK);
                INKCollection.Filter = new Predicate<object>(Filter_INK);
                StringListINK = MC.INK.Select(x => x.ink).ToList();

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectList.ToList());
                DefectCollection.Filter = new Predicate<object>(DefectFilter);
                StringListDefect = MC.DefectList.Select(x => x.dfctdsc).ToList();

                ShiftCollection = CollectionViewSource.GetDefaultView(MC.Shift);
                ShiftCollection.Filter = new Predicate<object>(Filter_Shift);
                StringListShift = MC.Shift.Select(x => x.shift).ToList();

                OperatorCollection = CollectionViewSource.GetDefaultView(MC.EmpList.ToList());
                OperatorCollection.Filter = new Predicate<object>(OperatorFilter);
                StringListOperator = MC.EmpList.Select(x => x.EmpId).ToList();

                TestTypeCollection = CollectionViewSource.GetDefaultView(MC.TestType.ToList());
                TestTypeCollection.Filter = new Predicate<object>(TestTypeFilter);
                StringListTestType = MC.TestType.Select(x => x.test_code).ToList();

                BatchCollection = CollectionViewSource.GetDefaultView(MC.BatchDetails.ToList());
                BatchCollection.Filter = new Predicate<object>(Filter_Batch);
                //StringListBatch = MC.BatchDetails.Select(x => x.batch_no).ToList();

                DefaultValues();
            }
            catch (Exception ex)
            {
            }
        }
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.doc_cat = "WT";
            MasterEntity.doc_type = "WT";
            MasterEntity.t_status = "004";
            MasterEntity.timeto = DateTime.Now.ToString("HH:mm");
            MasterEntity.tm = 25;
            MasterEntity.tmp = "25";
            MasterEntity.humdt = "55%";
            MasterEntity.prddt = DateTime.Now;
            MasterEntity.Fromdate = DateTime.Now;
            MasterEntity.ToDate = DateTime.Now;
            MasterEntity.wtdt = DateTime.Now;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private void InsertConvLot(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            EPR_T001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            //POPUPEntityObject = MC.MasterEntity.Where(x => x.Conv_lot.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.Conv_lot = POPUPEntityObject.Conv_lot.ToString();

            }
        }
        private void InsertMachine(object InputValue)
        {
            string Request = "";

            ZADM_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.MachineCodeList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.machinecode = POPUPEntityObject.machinecode;
                MasterEntity.mchn_id = POPUPEntityObject.machine_id;
            }
        }
        private void InsertILD(object InputValue)
        {
            string Request = "";

            ZADM_M007_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ILD.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
            }
        }
        private void InsertDefect(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M016_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DefectList.Where(x => x.dfctdsc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.defects == POPUPEntityObject.dfctdsc).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.defects == POPUPEntityObject.dfctdsc).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new ECRM_T003_B_New()
                        {
                            id = 0,
                            defects = POPUPEntityObject.dfctdsc,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemsEntity[dgSelectedIndexItem].defects = POPUPEntityObject.dfctdsc;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].defects != POPUPEntityObject.dfctdsc)
                        {
                            ItemsEntity[dgSelectedIndexItem].defects = POPUPEntityObject.dfctdsc;
                        }
                    }
                }
                #region Clear Empty Row
                ECRM_T003_B_New newObj = new ECRM_T003_B_New();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
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
        private void InsertOperator(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.EmpList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.EmpId = POPUPEntityObject.EmpId;
                MasterEntity.EmpNm = POPUPEntityObject.EmpLName;

            }
        }
        private void InsertTestType(object InputValue)
        {
            string Request = "";
            ECRM_T003_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.TestType.Where(x => x.test_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T003_C_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.test_code = POPUPEntityObject.test_code;

            }
        }
        private void InsertShift(object InputValue)
        {
            string Request = "";
            ADM_M042_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.Shift.Where(x => x.shift.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M042_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.shift = POPUPEntityObject.shift;

            }
        }
        private void InsertItem(object InputValue)
        {
            string Request = "";
            ADM_M022_P_ESSEM POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ItemList.Where(x => x.ItemName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P_ESSEM>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P_ESSEM>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.prdct_code = POPUPEntityObject.prdct_code;
                MasterEntity.itemname = POPUPEntityObject.ItemName;

            }
        }
        private void InsertModels(object InputValue)
        {
            string Request = "";
            ZADM_M009_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.Models.Where(x => x.modelno.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.modlno = POPUPEntityObject.modelno;

            }
        }
        private void InsertInk(object InputValue)
        {
            string Request = "";
            ZADM_M006_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.INK.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.ink = POPUPEntityObject.ink;
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            ECRM_T003_AFlip ParameterEntityObject = null;
            MasterEntity = new ECRM_T003_A_New();

            if (((IEnumerable)ParameterObject).Cast<ZCRM_T004Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ECRM_T003_AFlip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.wtno;
                isNewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003>(MC, Request, "WritingTestForProduction", "Production", "LoadInitialData", 0, "");

                SetBusinessEntitiesAfterLoad("Save", "");
                MasterEntity.ts_code = ts_code_vm;
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_ECRM_T003_B != null && ParameterOption1 == "Save")
            {
                MC.ItemEntity = (ObservableCollection<ECRM_T003_B_New>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T003_B, MC.ItemEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemEntity;
            }
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<ECRM_T003_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                DataGridCollection.Refresh();
            }
        }
        private bool Validation()
        {
            return true;
        }
        private void InsertBatch(object InputValue)
        {
            try
            {
                string Request = "";
                PPC_T003_Batch POPUPEntityObject = null;
                barcode = InputValue.ToString();
                #region Command Parameter Read Section
                if (barcode.Length > 12)
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            var InputValueIfExists = MC.BatchDetails.Where(X => X.batch_no == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity
                            if (InputValueIfExists != null)
                            {
                                POPUPEntityObject = MC.BatchDetails.Where(x => (x.batch_no ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Invalid Barcode.\n  Please Scan Valid Barcode", this.Title);
                                showMessageService.ShowMessage();

                            }
                            MasterEntity.batch_no = "";
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<PPC_T003_Batch>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T003_Batch>().ToList()[0];
                        }
                    }
                    if (POPUPEntityObject != null)
                    {
                        MasterEntity.batch_no = POPUPEntityObject.batch_no;
                        MasterEntity.machinecode = POPUPEntityObject.machinecode;
                        MasterEntity.shift = POPUPEntityObject.shift1;
                        MasterEntity.EmpId = POPUPEntityObject.shift_incharge;
                        MasterEntity.EmpNm = POPUPEntityObject.ShiftInchargeName;
                        MasterEntity.prdct_code = POPUPEntityObject.ItemCode;
                        MasterEntity.itemname = POPUPEntityObject.ItemName;
                        //MasterEntity.conversion_no = POPUPEntityObject.conversion_no.ToString();
                    }
                }
            }
            #endregion

            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

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

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ECRM_T003_A_New> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_ECRM_T003_B = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T003_A_New>(MasterEntity, "WritingTestForProduction2", "Production");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ECRM_T003_A_New>(MasterEntity, "WritingTestForProduction2", "Production");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

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
        protected override void OnCreateAction(InquiryActionResult<ECRM_T003_A_New> result)
        {
            isNewRecord = true;
            MasterEntity = new ECRM_T003_A_New();
            MC.ItemEntity = new ObservableCollection<ECRM_T003_B_New>();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            DataGridCollection.Refresh();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
