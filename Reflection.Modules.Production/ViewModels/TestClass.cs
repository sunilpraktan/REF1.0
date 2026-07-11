
////TDS Start
//using Reflection.Presentation.ViewModel;
//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using Reflection.WebServices.Gateway;
//using Reflection.Presentation.Core.Services;
//using Reflection.Presentation.Core.Windows;
//using System.Windows.Data;
//using GalaSoft.MvvmLight.Command;
//using System.Collections.ObjectModel;
//using Reflection.Presentation.Services;
//using Reflection.BusinessEntity;
//using Reflection.ReportingServices;
//using System.Collections.Specialized;
//using System.Threading.Tasks;
//using Reflection.BusinessEntity.Production;

//namespace Reflection.Modules.Production.ViewModels
//{
//    public class ENG_T004VM //: WindowViewModel<ENG_T004>, INotifyPropertyChanged
//    {
//        #region . Variable Declaration .

//        bool isNewRecord = true;

//        WebServiceRepository<ENG_T004> repository = new WebServiceRepository<ENG_T004>();
//        WebServiceRepository<MultipleContext_ENG_T004> repository_MC = new WebServiceRepository<MultipleContext_ENG_T004>();
//        WebServiceRepository<MultipleContext_ENG_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_ENG_T004>();

//        ObjectSerializationService obj = new ObjectSerializationService();

//        private MultipleContext_ENG_T004 _MC = new MultipleContext_ENG_T004();
//        public MultipleContext_ENG_T004 MC
//        {
//            get { return _MC; }
//            set
//            {
//                if (_MC != value)
//                {
//                    _MC = value; RaisePropertyChanged("MC");
//                }
//            }
//        }

//        private MultipleContext_ENG_T004 _MCTemp = new MultipleContext_ENG_T004();
//        public MultipleContext_ENG_T004 MCTemp
//        {
//            get { return _MCTemp; }
//            set
//            {
//                if (_MCTemp != value)
//                {
//                    _MCTemp = value; RaisePropertyChanged("MCTemp");
//                }
//            }
//        }

//        //private ENG_T004 _MasterEntity;
//        //public ENG_T004 MasterEntity
//        //{
//        //    get
//        //    {
//        //        return _MasterEntity;
//        //    }
//        //    set
//        //    {
//        //        if (_MasterEntity != value)
//        //        {
//        //            _MasterEntity = value;
//        //            RaisePropertyChanged(nameof(MasterEntity));
//        //            value.BeginEdit();
//        //        }
//        //    }
//        //}

//        private ObservableCollection<ENG_T004_A> _ParaDetailEntity;
//        public ObservableCollection<ENG_T004_A> ParaDetailEntity
//        {
//            get { return _ParaDetailEntity; }
//            set
//            {
//                if (_ParaDetailEntity != value)
//                {
//                    _ParaDetailEntity = value; RaisePropertyChanged("ParaDetailEntity");
//                }
//            }
//        }

//        private ObservableCollection<ENG_T004_B> _ControlParaDetailEntity;
//        public ObservableCollection<ENG_T004_B> ControlParaDetailEntity
//        {
//            get { return _ControlParaDetailEntity; }
//            set
//            {
//                if (_ControlParaDetailEntity != value)
//                {
//                    _ControlParaDetailEntity = value; RaisePropertyChanged("ControlParaDetailEntity");
//                }
//            }
//        }

//        #endregion
//        #region . List .
//        #endregion
//        #region . ICollection .
//        private ICollectionView _ItemCollection;
//        public ICollectionView ItemCollection
//        {
//            get { return _ItemCollection; }
//            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
//        }

//        private ICollectionView _MachineCollection;
//        public ICollectionView MachineCollection
//        {
//            get { return _MachineCollection; }
//            set
//            {
//                _MachineCollection = value;
//                RaisePropertyChanged("MachineCollection");
//            }
//        }

//        private ICollectionView _InkCollection;
//        public ICollectionView InkCollection
//        {
//            get { return _InkCollection; }
//            set
//            {
//                _InkCollection = value;
//                RaisePropertyChanged("InkCollection");
//            }
//        }

//        private ICollectionView _ILDCollection;
//        public ICollectionView ILDCollection
//        {
//            get { return _ILDCollection; }
//            set
//            {
//                _ILDCollection = value;
//                RaisePropertyChanged("ILDCollection");
//            }
//        }

//        private ICollectionView _UomCollection;
//        public ICollectionView UomCollection
//        {
//            get { return _UomCollection; }
//            set { _UomCollection = value; RaisePropertyChanged("UomCollection"); }
//        }


//        #endregion
//        #region . StringList .

//        List<string> _StringListMachine;
//        public List<string> StringListMachine
//        {
//            get { return _StringListMachine; }
//            set
//            {
//                if (_StringListMachine != value)
//                {
//                    _StringListMachine = value;
//                }
//            }
//        }

//        private List<string> _StringListItem;
//        public List<string> StringListItem
//        {
//            get { return _StringListItem; }
//            set
//            {
//                if (_StringListItem != value)
//                {
//                    _StringListItem = value;
//                }
//            }
//        }

//        private List<string> _stringListUOM;
//        public List<string> StringListUOM
//        {
//            get { return _stringListUOM; }
//            set
//            {
//                if (_stringListUOM != value)
//                {
//                    _stringListUOM = value;
//                }
//            }
//        }

//        private List<string> _StringListInk;
//        public List<string> StringListInk
//        {
//            get { return _StringListInk; }
//            set
//            {
//                if (_StringListInk != value)
//                {
//                    _StringListInk = value;
//                }
//            }
//        }

//        private List<string> _StringListILD;
//        public List<string> StringListILD
//        {
//            get { return _StringListILD; }
//            set
//            {
//                if (_StringListILD != value)
//                {
//                    _StringListILD = value;
//                }
//            }
//        }

//        #endregion
//        #region . Relay Command Declaration .
//        public RelayCommand<object> cmdInsertItem { get; private set; }
//        public RelayCommand<object> cmdInsertMachine { get; private set; }
//        public RelayCommand<object> cmdInsertUnit { get; private set; }
//        public RelayCommand<object> cmdInsertInk { get; private set; }
//        public RelayCommand<object> cmdInsertIld { get; private set; }
//        #endregion
//        #region . Constructor .
//        public ENG_T004VM() : base()
//        {
//            //MasterEntity = new ENG_T004();
//            //ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
//            //ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();

//            #region .Relay Command Initialisation .
//            cmdInsertItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
//            cmdInsertInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
//            cmdInsertIld = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
//            cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnit(cmdPara); });
//            cmdInsertMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
//            #endregion

//            // LoadInitialData();
//        }
//        //private void LoadInitialData()
//        //{
//        //    try
//        //    {

//        //        MasterEntity.doc_cat = "TS";
//        //        string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
//        //        MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MC, Request, "Bill Of Material", "Production", "LoadInitialData", 0, "");

//        //        ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemMaster.ToList());
//        //        ItemCollection.Filter = new Predicate<object>(Filter_ItemMasterCollection);
//        //        StringListItem = MC.ItemMaster.Select(x => x.ItemCode).ToList();

//        //        MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList.ToList());
//        //        MachineCollection.Filter = new Predicate<object>(Filter_Machine);
//        //        StringListMachine = MC.MachineMasterDetails.Select(x => x.machinecode).ToList();

//        //        UomCollection = CollectionViewSource.GetDefaultView(MC.UnitMaster.ToList());
//        //        UomCollection.Filter = new Predicate<object>(Filter_Uom);
//        //        StringListUOM = MC.UnitMaster.Select(x => x.unit_code).ToList();

//        //        InkCollection = CollectionViewSource.GetDefaultView(MC.InkMaster.ToList());
//        //        InkCollection.Filter = new Predicate<object>(Filter_InkMasterCollection);
//        //        StringListInk = MC.InkMaster.Select(x => x.ink).ToList();

//        //        ILDCollection = CollectionViewSource.GetDefaultView(MC.ILDMaster.ToList());
//        //        ILDCollection.Filter = new Predicate<object>(Filter_ILDMasterCollection);
//        //        StringListILD = MC.ILDMaster.Select(x => x.ild).ToList();

//        //        DefaultValues();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//        //        showMessageService.ButtonSetup = DialogButton.Ok;
//        //        showMessageService.Caption = "Message";
//        //        showMessageService.Text = String.Format(ex.Message, this.Title);
//        //        showMessageService.ShowMessage();
//        //    }
//        //}
//        #endregion
//        #region . User Defined Function .
//        private void DefaultValues()
//        {
//            MasterEntity.doc_cat = "TS";
//            MasterEntity.doc_type = "TS";
//            MasterEntity.location_Id = AppSessionState.location_Id;
//            MasterEntity.comp_code = AppSessionState.comp_code;
//            MasterEntity.add_by = AppSessionState.UserID;
//            MasterEntity.editby = AppSessionState.UserID;
//            MasterEntity.t_status = "Draft";
//            MasterEntity.doc_date = DateTime.Now;
//            MasterEntity.active = true;

//        }
//        private void InsertUnit(object InputValue)
//        {
//            string Request = "";
//            ADM_M038_B_P POPUPEntityObject = null;
//            try
//            {
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        try
//                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
//                        catch (Exception ex)
//                        {
//                        }
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
//                }
//            }
//            catch (Exception ex) { }

//            if (POPUPEntityObject != null)
//            {
//                MasterEntity.unit_code = POPUPEntityObject.unit_code;
//            }
//        }
//        private void InsertInk(object InputValue)
//        {
//            string Request = "";
//            ZADM_M006_P POPUPEntityObject = null;
//            try
//            {
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        try
//                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
//                        catch (Exception ex)
//                        {
//                        }
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
//                }
//            }
//            catch (Exception ex) { }

//            if (POPUPEntityObject != null)
//            {
//                MasterEntity.ink = POPUPEntityObject.ink;
//            }
//        }
//        private void InsertIld(object InputValue)
//        {
//            string Request = "";
//            ZADM_M007_P POPUPEntityObject = null;
//            try
//            {
//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        try
//                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
//                        catch (Exception ex)
//                        {
//                        }
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
//                }
//            }
//            catch (Exception ex) { }

//            if (POPUPEntityObject != null)
//            {
//                MasterEntity.ild = POPUPEntityObject.ild;
//            }
//        }
//        private void InsertMachine(object InputValue)
//        {
//            string Request = "";
//            ZADM_M013_P POPUPEntityObject = null;

//            #region Command Parameter Read Section
//            try
//            {

//                if (InputValue.GetType() == typeof(string) && InputValue != null)
//                {
//                    Request = InputValue.ToString();
//                    if (Request.Length > 0)
//                    {
//                        try
//                        { POPUPEntityObject = MC.MachineMasterDetails.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
//                        catch (Exception ex) { }
//                    }
//                }
//                else if (InputValue != null)
//                {
//                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
//                }
//            }
//            catch (Exception ex) { }

//            #endregion
//            if (POPUPEntityObject != null)
//            {
//                MasterEntity.MachineCode = POPUPEntityObject.machinecode;
//                MasterEntity.machine_id = POPUPEntityObject.machine_id;
//            }

//        }
//        private bool Validation()
//        {
//            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format("Please Select Item Code");
//                showMessageService.ShowMessage();
//                return false;
//            }
//            if (MasterEntity.unit_code == null || MasterEntity.unit_code == "")
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
//                showMessageService.ShowMessage();
//                return false;
//            }
//            return true;
//        }
//        #endregion
//        #region .INotifyPropertyChanged Interface Implementation .

//        public event PropertyChangedEventHandler PropertyChanged;
//        protected void RaisePropertyChanged(string propertyName) =>
//        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
//        #endregion
//        #region . Abstract Methods .

//        protected override void OnSaveAction(InquiryActionResult<ENG_T001> result)
//        {
//            try
//            {
//                if (Validation() == true)
//                {
//                    MasterEntity.XmlDataDocument_ENG_T004_A = obj.ObjectToXML(ItemsEntity);

//                    this.MasterEntity.EndEdit();
//                    if (isNewRecord == true)
//                    {
//                        MasterEntity = repository.SaveWithReturnDomainObject < ENG_T004(MasterEntity, "TDS", "Production");
//                    }


//                    else if (isNewRecord == false)
//                    {
//                        MasterEntity = repository.UpdateWithReturnDomainObject<ENG_T004>(MasterEntity, "TDS", "Production");
//                    }
//                    parameter = false;
//                    SetBusinessEntitiesAfterLoad("Save", "");
//                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                    showMessageService.ButtonSetup = DialogButton.Ok;
//                    showMessageService.Caption = "Message";
//                    showMessageService.Text = String.Format("Data Saved Successfully");
//                    showMessageService.ShowMessage();

//                    isNewRecord = false;
//                }
//            }
//            catch (Exception ex)
//            {
//                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//                showMessageService.ButtonSetup = DialogButton.Ok;
//                showMessageService.Caption = "Message";
//                showMessageService.Text = String.Format(ex.Message, this.Title);
//                showMessageService.ShowMessage();
//            }
//        }
//        protected override void OnCreateAction(InquiryActionResult<ENG_T004> result)
//        {
//            isNewRecord = true;
//            MasterEntity = new ENG_T004();
//            MC.ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
//            MC.ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();
//            MasterEntity.ValidateAsync().Wait();
//            ParaDetailEntity.Clear();
//            //// FlipDataGridCollection.Refresh();

//            DefaultValues();
//        }
//        protected override void OnRemoveAction(InquiryActionResult<ENG_T004> result)
//        {
//            throw new NotImplementedException();
//        }
//        protected override void OnDiscardAction(InquiryActionResult<ENG_T004> result)
//        {
//            throw new NotImplementedException();
//        }
//        protected override void OnPrintAction(InquiryActionResult<ENG_T004> result)
//        {
//            throw new NotImplementedException();
//        }
//        protected override void OnFlipAction(InquiryActionResult<ENG_T004> result)
//        {
//            throw new NotImplementedException();
//        }
//        protected override void OnHelpAction(InquiryActionResult<ENG_T004> result)
//        {
//            throw new NotImplementedException();
//        }
//        protected override void OnFevoriteAction(InquiryActionResult<ENG_T004> result)
//        {
//            throw new NotImplementedException();
//        }
//        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
//        {
//            if (MasterEntity.XmlDataDocument_ENG_T004_A != null)
//            {
//                MC.ParaDetailEntity = (ObservableCollection<ENG_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T004_A, MC.ParaDetailEntity);
//                ParaDetailEntity.Clear();
//                ParaDetailEntity = MC.ParaDetailEntity;
//            }
//            else
//            {
//                MC.ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
//            }
//            if (MasterEntity.XmlDataDocument_ENG_T004_B != null)
//            {
//                MC.ControlParaDetailEntity = (ObservableCollection<ENG_T004_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T004_B, MC.ControlParaDetailEntity);
//                ControlParaDetailEntity.Clear();
//                ControlParaDetailEntity = MC.ControlParaDetailEntity;
//            }
//            else
//            {
//                MC.ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();
//            }
//        }
//        #endregion
//        #region . Filters .

//        #region . Machine .
//        private string _filterString_Machine;
//        public string filterString_Machine
//        {
//            get { return _filterString_Machine; }
//            set
//            {
//                _filterString_Machine = value;
//                RaisePropertyChanged("filterString_Machine");
//                FilterCollection_Machine();
//            }
//        }
//        private void FilterCollection_Machine()
//        {
//            if (MachineCollection != null)
//            {
//                MachineCollection.Refresh();
//            }
//        }
//        public bool Filter_Machine(object obj)
//        {
//            var data = obj as ZADM_M013_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_Machine))
//                {
//                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }
//        #endregion

//        #region . ItemCode .
//        private string _filterString_ItemMasterCollection;
//        public string FilterString_ItemMasterCollection
//        {
//            get { return _filterString_ItemMasterCollection; }
//            set
//            {
//                _filterString_ItemMasterCollection = value;
//                RaisePropertyChanged("FilterString_ItemMasterCollection");
//                FilterCollection_ItemMasterCollection();
//            }
//        }
//        private void FilterCollection_ItemMasterCollection()
//        {
//            if (_ItemCollection != null)
//            {
//                _ItemCollection.Refresh();
//            }
//        }
//        public bool Filter_ItemMasterCollection(object obj)
//        {
//            var data = obj as ADM_M022_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_ItemMasterCollection))
//                {
//                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemMasterCollection.ToLower())) ||
//                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemMasterCollection.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }
//        #endregion

//        #region . Ink .
//        private string _filterString_InkMasterCollection;
//        public string FilterString_InkMasterCollection
//        {
//            get { return _filterString_InkMasterCollection; }
//            set
//            {
//                _filterString_InkMasterCollection = value;
//                RaisePropertyChanged("FilterString_InkMasterCollection");
//                FilterCollection_InkMasterCollection();
//            }
//        }
//        private void FilterCollection_InkMasterCollection()
//        {
//            if (_InkCollection != null)
//            {
//                _InkCollection.Refresh();
//            }
//        }
//        public bool Filter_InkMasterCollection(object obj)
//        {
//            var data = obj as ZADM_M006_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_InkMasterCollection))
//                {
//                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_InkMasterCollection.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }
//        #endregion

//        #region . ILD .
//        private string _filterString_ILDMasterCollection;
//        public string FilterString_ILDMasterCollection
//        {
//            get { return _filterString_ILDMasterCollection; }
//            set
//            {
//                _filterString_ILDMasterCollection = value;
//                RaisePropertyChanged("FilterString_ILDMasterCollection");
//                FilterCollection_ILDMasterCollection();
//            }
//        }
//        private void FilterCollection_ILDMasterCollection()
//        {
//            if (_ILDCollection != null)
//            {
//                _ILDCollection.Refresh();
//            }
//        }
//        public bool Filter_ILDMasterCollection(object obj)
//        {
//            var data = obj as ZADM_M007_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(_filterString_ILDMasterCollection))
//                {
//                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_ILDMasterCollection.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }
//        #endregion

//        #region . Unit .
//        private string _filterStringUom;
//        public string filterStringUom
//        {
//            get { return _filterStringUom; }
//            set
//            {
//                _filterStringUom = value;
//                RaisePropertyChanged("filterStringUom");
//                Filter_UomCollection();
//            }
//        }
//        private void Filter_UomCollection()
//        {
//            if (_UomCollection != null)
//            {
//                _UomCollection.Refresh();
//            }
//        }
//        public bool Filter_Uom(object obj)
//        {
//            var data = obj as ADM_M038_B_P;
//            if (data != null)
//            {
//                if (!string.IsNullOrEmpty(filterStringUom))
//                {
//                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUom.ToLower())) ||
//                           (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUom.ToLower()));
//                }
//                return true;
//            }
//            return false;
//        }
//        #endregion

//        #endregion
//    }
//}

////TDS END


////        using System;
////        using System.Collections;
////        using System.Collections.Generic;
////        using System.ComponentModel;
////        using System.Linq;
////        using System.Text;
////        using System.Threading.Tasks;
////        using Reflection.WebServices.Gateway;
////        using Reflection.Presentation.Core.Services;
////        using Reflection.Presentation.Core.Windows;
////        using System.Windows.Data;
////        using GalaSoft.MvvmLight.Command;
////        using System.Collections.ObjectModel;
////        using System.Windows;
////        using Reflection.Presentation.Services;
////        using Reflection.Presentation.ViewModel;
////        using Reflection.BusinessEntity;
////        using Reflection.ReportingServices;
////        using Reflection.BusinessEntity.Production;

////        namespace Reflection.Modules.Production.ViewModels
////{
//    //public class EPR_T004_VM2 : WindowViewModel<EPR_T004_A>, INotifyPropertyChanged
//    //{
//    //    bool blNew = true;
//    //    private int _dgSelectedIndex;
//    //    public int dgSelectedIndex
//    //    {
//    //        get
//    //        {
//    //            return _dgSelectedIndex;
//    //        }
//    //        set
//    //        {
//    //            if (_dgSelectedIndex != value)
//    //            {
//    //                _dgSelectedIndex = value;
//    //                RaisePropertychanged("dgSelectedIndex");
//    //            }
//    //        }
//    //    }
//    //    private int _dgSelectedIndex1;
//    //    public int dgSelectedIndex1
//    //    {
//    //        get
//    //        {
//    //            return _dgSelectedIndex1;
//    //        }
//    //        set
//    //        {
//    //            if (_dgSelectedIndex1 != value)
//    //            {
//    //                _dgSelectedIndex1 = value;
//    //                RaisePropertychanged("dgSelectedIndex1");
//    //            }
//    //        }
//    //    }
//    //    private int _dgSelectedIndex_groupby;
//    //    public int dgSelectedIndex_groupby
//    //    {
//    //        get
//    //        {
//    //            return _dgSelectedIndex_groupby;
//    //        }
//    //        set
//    //        {
//    //            if (_dgSelectedIndex_groupby != value)
//    //            {
//    //                _dgSelectedIndex_groupby = value;
//    //                RaisePropertychanged("dgSelectedIndex_groupby");
//    //            }
//    //        }
//    //    }
//    //    private int _dgSelectedItemIndex;
//    //    public int dgSelectedItemIndex
//    //    {
//    //        get
//    //        {
//    //            return _dgSelectedItemIndex;
//    //        }
//    //        set
//    //        {
//    //            if (_dgSelectedItemIndex != value)
//    //            {
//    //                _dgSelectedItemIndex = value;
//    //                RaisePropertychanged("dgSelectedItemIndex");
//    //                if (EPR_T004_BDetail.Count() > 0)
//    //                {
//    //                    if (EPR_T004_CDetailAll.Count() > 0)
//    //                    {
//    //                        var selectedItemSoList = EPR_T004_CDetailAll.Where(X => X.item_code == EPR_T004_BDetail[_dgSelectedItemIndex].item_code);
//    //                        EPR_T004_CDetail = new ObservableCollection<EPR_T004_C>(selectedItemSoList);
//    //                    }
//    //                }
//    //            }
//    //        }
//    //    }



//    //    WebServiceRepository<EPR_T004_A> repository = new WebServiceRepository<EPR_T004_A>();
//    //    WebServiceRepository<MultipleContext_EPR_T004> repositoryM = new WebServiceRepository<MultipleContext_EPR_T004>();


//    //    private EPR_T004_A _SelectedEPR_T004;
//    //    public EPR_T004_A SelectedEPR_T004
//    //    {
//    //        get { return _SelectedEPR_T004; }
//    //        set
//    //        {
//    //            if (_SelectedEPR_T004 != value)
//    //            {
//    //                _SelectedEPR_T004 = value;
//    //                RaisePropertychanged("SelectedEPR_T004");
//    //            }
//    //        }
//    //    }
//    //    MultipleContext_EPR_T004 _MC = new MultipleContext_EPR_T004();
//    //    public MultipleContext_EPR_T004 MC
//    //    {
//    //        get { return _MC; }
//    //        set
//    //        {
//    //            if (_MC != value)
//    //            {
//    //                _MC = value;

//    //                RaisePropertychanged("MC");
//    //            }
//    //        }
//    //    }
//    //    MultipleContext_EPR_T004 _MCtemp = new MultipleContext_EPR_T004();
//    //    public MultipleContext_EPR_T004 MCtemp
//    //    {
//    //        get { return _MCtemp; }
//    //        set
//    //        {
//    //            if (_MCtemp != value)
//    //            {
//    //                _MCtemp = value;

//    //                RaisePropertychanged("MCtemp");
//    //            }
//    //        }
//    //    }

//    //    private ObservableCollection<soListForPlan> _machineDetail;
//    //    public ObservableCollection<soListForPlan> machineDetail
//    //    {
//    //        get { return _machineDetail; }
//    //        set
//    //        {
//    //            if (_machineDetail != value)
//    //            {
//    //                _machineDetail = value;

//    //                RaisePropertychanged("machineDetail");
//    //            }
//    //        }
//    //    }
//    //    private ObservableCollection<soListForPlan> _selectedMAchineSoDetail;
//    //    public ObservableCollection<soListForPlan> selectedMAchineSoDetail
//    //    {
//    //        get { return _selectedMAchineSoDetail; }
//    //        set
//    //        {
//    //            if (_selectedMAchineSoDetail != value)
//    //            {
//    //                _selectedMAchineSoDetail = value;

//    //                RaisePropertychanged("selectedMAchineSoDetail");
//    //            }
//    //        }
//    //    }
//    //    private ObservableCollection<soListForPlan> _groupBySelectedItem;
//    //    public ObservableCollection<soListForPlan> groupBySelectedItem
//    //    {
//    //        get { return _groupBySelectedItem; }
//    //        set
//    //        {
//    //            if (_groupBySelectedItem != value)
//    //            {
//    //                _groupBySelectedItem = value;

//    //                RaisePropertychanged("groupBySelectedItem");
//    //            }
//    //        }
//    //    }
//    //    private ObservableCollection<EPR_T004_B> _EPR_T004_BDetail;
//    //    public ObservableCollection<EPR_T004_B> EPR_T004_BDetail
//    //    {
//    //        get { return _EPR_T004_BDetail; }
//    //        set
//    //        {
//    //            if (_EPR_T004_BDetail != value)
//    //            {
//    //                _EPR_T004_BDetail = value;

//    //                RaisePropertychanged("EPR_T004_BDetail");
//    //            }
//    //        }
//    //    }

//    //    private ObservableCollection<EPR_T004_C> _EPR_T004_CDetailAll;
//    //    public ObservableCollection<EPR_T004_C> EPR_T004_CDetailAll
//    //    {
//    //        get { return _EPR_T004_CDetailAll; }
//    //        set
//    //        {
//    //            if (_EPR_T004_CDetailAll != value)
//    //            {
//    //                _EPR_T004_CDetailAll = value;

//    //                RaisePropertychanged("EPR_T004_CDetailAll");
//    //            }
//    //        }
//    //    }

//    //    private ObservableCollection<EPR_T004_C> _EPR_T004_CDetail;
//    //    public ObservableCollection<EPR_T004_C> EPR_T004_CDetail
//    //    {
//    //        get { return _EPR_T004_CDetail; }
//    //        set
//    //        {
//    //            if (_EPR_T004_CDetail != value)
//    //            {
//    //                _EPR_T004_CDetail = value;

//    //                RaisePropertychanged("EPR_T004_CDetail");
//    //            }
//    //        }
//    //    }

//    //    private ObservableCollection<soListForPlan> _selectedItemGroupByList;
//    //    public ObservableCollection<soListForPlan> selectedItemGroupByList
//    //    {
//    //        get { return _selectedItemGroupByList; }
//    //        set
//    //        {
//    //            if (_selectedItemGroupByList != value)
//    //            {
//    //                _selectedItemGroupByList = value;

//    //                RaisePropertychanged("selectedItemGroupByList");
//    //            }
//    //        }
//    //    }

//    //    private ICollectionView _SOCollection;
//    //    public ICollectionView SOCollection
//    //    {
//    //        get { return _SOCollection; }
//    //        set { _SOCollection = value; RaisePropertychanged("SOCollection"); }
//    //    }

//    //    private ICollectionView _DataCollection;
//    //    public ICollectionView DataCollection
//    //    {
//    //        get { return _DataCollection; }
//    //        set { _DataCollection = value; RaisePropertychanged("DataCollection"); }
//    //    }

//    //    private ICollectionView _CollectionModel;
//    //    public ICollectionView CollectionModel
//    //    {
//    //        get { return _CollectionModel; }
//    //        set { _CollectionModel = value; RaisePropertychanged("CollectionModel"); }
//    //    }
//    //    public RelayCommand getCurrentMachineClickCommand
//    //    {
//    //        get;
//    //        private set;
//    //    }
//    //    public RelayCommand<IList> getAllSODetailClickCommand
//    //    {
//    //        get;
//    //        private set;
//    //    }
//    //    public RelayCommand AddCommand
//    //    {
//    //        get;
//    //        private set;
//    //    }
//    //    public RelayCommand groupByItemClickCommand
//    //    {
//    //        get;
//    //        private set;
//    //    }
//    //    public RelayCommand<IList> getPalnDetailCommand
//    //    {
//    //        get;
//    //        private set;
//    //    }



//    //    #region Methods
//    //    public event PropertyChangedEventHandler PropertyChanged;
//    //    public void RaisePropertychanged(string propertyName)
//    //    {
//    //        take a copy to prevent thread issues
//    //       PropertyChangedEventHandler handler = PropertyChanged;
//    //        if (handler != null)
//    //        {
//    //            handler(this, new PropertyChangedEventArgs(propertyName));
//    //        }
//    //    }
//    //    public RelayCommand<IList> SelectionChangedCommandModel
//    //    {
//    //        get;
//    //        private set;
//    //    }
//    //    #endregion

//    //    #region . Constructor .
//    //    public EPR_T004_VM2() : base()
//    //    {
//    //        SelectedEPR_T004 = new EPR_T004_A();
//    //        MC.soDetailList = new ObservableCollection<soListForPlan>();
//    //        MC.machineDetailForProdList = new ObservableCollection<soListForPlan>();
//    //        machineDetail = new ObservableCollection<soListForPlan>();
//    //        selectedMAchineSoDetail = new ObservableCollection<soListForPlan>();
//    //        EPR_T004_BDetail = new ObservableCollection<EPR_T004_B>();
//    //        EPR_T004_CDetailAll = new ObservableCollection<EPR_T004_C>();
//    //        groupBySelectedItem = new ObservableCollection<soListForPlan>();
//    //        selectedItemGroupByList = new ObservableCollection<soListForPlan>();
//    //        EPR_T004_CDetail = new ObservableCollection<EPR_T004_C>();

//    //        getCurrentMachineClickCommand = new RelayCommand(() => getCurrentMachine());
//    //        getAllSODetailClickCommand = new RelayCommand<IList>((items) => { if (items == null) { return; } getAllSODetail(items); });
//    //        SelectionChangedCommandModel = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedModel(items); });
//    //        AddCommand = new RelayCommand(() => AddSelectedData());
//    //        groupByItemClickCommand = new RelayCommand(() => groupByItemData());
//    //        getPalnDetailCommand = new RelayCommand<IList>((items) => { if (items == null) { return; } getPlanDetail(items); });

//    //        LoadInitialData();
//    //    }

//    //    private void getPlanDetail(IList items)
//    //    {
//    //        try
//    //        {
//    //            IList list = items as IList;
//    //            List<EPR_T004_A> tSelectedPOList = list.Cast<EPR_T004_A>().ToList();
//    //            if (tSelectedPOList.Count > 0)
//    //            {
//    //                MCtemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCtemp, tSelectedPOList[0].plan_no, "ProductionPlanning", "Production", "getPlanDetails", 0, AppSessionState.location_Id);

//    //                if (MCtemp.productionPlanc.Count() > 0)
//    //                {
//    //                    SelectedEPR_T004.plan_date = tSelectedPOList[0].plan_date;
//    //                    SelectedEPR_T004.plan_no = tSelectedPOList[0].plan_no;

//    //                    SelectedEPR_T004.machine_no = MCtemp.productionPlanc[0].machine_no;

//    //                    EPR_T004_CDetailAll = new ObservableCollection<EPR_T004_C>(MCtemp.productionPlanc);
//    //                    EPR_T004_BDetail = new ObservableCollection<EPR_T004_B>(MCtemp.productionPlanB);
//    //                    if (EPR_T004_BDetail.Count() > 0)
//    //                    {
//    //                        if (EPR_T004_CDetailAll.Count() > 0)
//    //                        {
//    //                            var selectedItemSoList = EPR_T004_CDetailAll.Where(X => X.item_code == EPR_T004_BDetail[0].item_code);
//    //                            EPR_T004_CDetail = new ObservableCollection<EPR_T004_C>(selectedItemSoList);
//    //                        }
//    //                    }
//    //                }
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //            / <summary>
//    //            / get selecdted item group wise
//    //            / </summary>
//    //            private void groupByItemData()
//    //    {
//    //        try
//    //        {
//    //            if (MC.soDetailList.Count() > 0)
//    //            {
//    //                selectedItemGroupByList = new ObservableCollection<soListForPlan>();
//    //                foreach (var item1 in MC.soDetailList)
//    //                {
//    //                    if (item1.Select == true)
//    //                    {
//    //                        selectedItemGroupByList.Add(item1);
//    //                    }
//    //                }

//    //                List<soListForPlan> result = selectedItemGroupByList
//    //                            .GroupBy(l => new { l.ItemCode, l.ball_make, l.wire_make })
//    //                            .Select(cl => new soListForPlan
//    //                            {
//    //                                ItemCode = cl.First().ItemCode,
//    //                                ball_make = cl.First().ball_make,
//    //                                wire_make = cl.First().wire_make,
//    //                                quantity = cl.Sum(c => c.quantity),
//    //                                model_no = cl.First().model_no,
//    //                                model_id = cl.First().model_id,
//    //                                uom_name = cl.First().uom_name,
//    //                                uom = cl.First().uom,
//    //                                machine_id = cl.First().machine_id,
//    //                                machine_no = cl.First().machine_no,
//    //                            }).ToList();

//    //                groupBySelectedItem = new ObservableCollection<soListForPlan>(result); ;
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //    public bool validate()
//    //    {
//    //        int i = 0;
//    //        if (SelectedEPR_T004.machine_no == null)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format("Please Select Machine", this.Title);
//    //            showMessageService.ShowMessage();
//    //            i = 1;
//    //        }
//    //        if (i == 0)
//    //        {
//    //            if (MC.soDetailList.Count() == 0)
//    //            {
//    //                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //                showMessageService.ButtonSetup = DialogButton.Ok;
//    //                showMessageService.Caption = "Message";
//    //                showMessageService.Text = String.Format("Please Select Machine", this.Title);
//    //                showMessageService.ShowMessage();
//    //            }
//    //        }
//    //        if (i == 1)
//    //        {
//    //            return false;
//    //        }
//    //        else
//    //        {
//    //            return true;
//    //        }
//    //    }
//    //    private void AddSelectedData()
//    //    {
//    //        try
//    //        {
//    //            string wire_make = "";
//    //            string ball_make = "";

//    //            decimal qty = 0;
//    //            if (validate() == true)
//    //            {
//    //                if (SelectedEPR_T004.machine_no == "") { }
//    //                else
//    //                {
//    //                    if (selectedItemGroupByList.Count() > 0)
//    //                    {
//    //                        foreach (var item in MC.soDetailList)
//    //                        {
//    //                            if (item.Select == true && item.ItemCode == MC.soDetailList[dgSelectedIndex1].ItemCode)
//    //                            {
//    //                                int xx = EPR_T004_CDetailAll.IndexOf(EPR_T004_CDetailAll.Where(o => o.so_no == item.sono && o.item_code == item.ItemCode && o.sku == item.stocking_unit).FirstOrDefault());
//    //                                var qq = EPR_T004_CDetailAll.Where(X => X.so_no == item.sono && X.item_code == item.ItemCode && X.sku == item.stocking_unit);
//    //                                if (xx == -1)
//    //                                {
//    //                                    int cnt = (from o in EPR_T004_CDetail where o.item_code == item.ItemCode select o).Count();
//    //                                    qty = (decimal)qty + (decimal)item.quantity;
//    //                                    EPR_T004_CDetailAll.Add(new EPR_T004_C() { so_no = item.sono, qty = item.quantity, uom = item.uom, uom_name = item.uom_name, item_code = item.ItemCode, machine_no = SelectedEPR_T004.machine_no, sku = item.stocking_unit });
//    //                                }
//    //                                else if (xx != -1)
//    //                                {
//    //                                    qty = (decimal)qty + (decimal)item.quantity;
//    //                                    EPR_T004_CDetailAll[xx].qty = qty;
//    //                                }
//    //                            }
//    //                        }

//    //                        if (machineDetail.Count() > 0)
//    //                        {
//    //                            wire_make = machineDetail[dgSelectedIndex].wire_make;
//    //                            ball_make = machineDetail[dgSelectedIndex].wire_make;
//    //                        }

//    //                        item table entry
//    //                                int x = EPR_T004_BDetail.IndexOf(EPR_T004_BDetail.Where(xx => xx.item_code == MC.soDetailList[dgSelectedIndex1].ItemCode).FirstOrDefault());//xx.machine_no == SelectedEPR_T004.machine_no &&
//    //                        var q = EPR_T004_BDetail.Where(X => X.item_code == MC.soDetailList[dgSelectedIndex1].ItemCode);//X.machine_no == SelectedEPR_T004.machine_no &&

//    //                        if (x == -1)
//    //                        {
//    //                            if (EPR_T004_BDetail.Count() == 0)
//    //                            {
//    //                                EPR_T004_BDetail = new ObservableCollection<EPR_T004_B>();
//    //                            }
//    //                            int cnt = (from o in EPR_T004_BDetail where o.item_code == MC.soDetailList[dgSelectedIndex1].ItemCode select o).Count();
//    //                            EPR_T004_BDetail.Add(new EPR_T004_B()
//    //                            {
//    //                                machine_no = SelectedEPR_T004.machine_no
//    //                                ,
//    //                                sales_order_no = MC.soDetailList[dgSelectedIndex1].sono
//    //                                ,
//    //                                item_code = MC.soDetailList[dgSelectedIndex1].ItemCode
//    //                                ,
//    //                                plan_qty = qty
//    //                                ,
//    //                                para1 = MC.soDetailList[dgSelectedIndex1].model_id
//    //                                ,
//    //                                para1_modelnm = MC.soDetailList[dgSelectedIndex1].model_no
//    //                                ,
//    //                                sku = MC.soDetailList[dgSelectedIndex1].stocking_unit
//    //                                ,
//    //                                uom = MC.soDetailList[dgSelectedIndex1].uom
//    //                                ,
//    //                                uom_name = MC.soDetailList[dgSelectedIndex1].uom_name
//    //                                ,
//    //                                para6 = MC.soDetailList[dgSelectedIndex1].ild
//    //                                ,
//    //                                para7 = MC.soDetailList[dgSelectedIndex1].ink
//    //                                ,
//    //                                para8 = wire_make
//    //                                ,
//    //                                para9 = ball_make
//    //                                ,
//    //                                plant = MC.soDetailList[dgSelectedIndex1].plant_id
//    //                                ,
//    //                                company = MC.soDetailList[dgSelectedIndex1].company_id
//    //                            });
//    //                        }
//    //                        else if (x != -1)
//    //                        {
//    //                            EPR_T004_BDetail[x].plan_qty = qty;
//    //                        }

//    //                        SHOW SELECTED ITEM SO LIST
//    //                        var selectedItemSoList = EPR_T004_CDetailAll.Where(X => X.item_code == MC.soDetailList[dgSelectedIndex1].ItemCode);
//    //                        EPR_T004_CDetail = new ObservableCollection<EPR_T004_C>(selectedItemSoList);
//    //                    }
//    //                }
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //    private void GetSelectedModel(IList items)
//    //    {
//    //        try
//    //        {
//    //            IList list = items as IList;
//    //            List<ZADM_M013_PopUp> SelectedModelTemp = list.Cast<ZADM_M013_PopUp>().ToList();

//    //            if (SelectedModelTemp.Count > 0)
//    //            {
//    //                SelectedEPR_T004.machine_no = SelectedModelTemp[0].machinecode;
//    //                SelectedEPR_T004.machine_name = SelectedModelTemp[0].machinecode;
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //    private void getAllSODetail(IList items)
//    //    {
//    //        try
//    //        {
//    //            if (machineDetail.Count() > 0)
//    //            {
//    //                IList list = items as IList;
//    //                List<soListForPlan> tSelectedList = list.Cast<soListForPlan>().ToList();
//    //                selectedMAchineSoDetail = new ObservableCollection<soListForPlan>();

//    //                if (dgSelectedIndex >= 0)
//    //                {
//    //                    if (machineDetail.Count() > 0)
//    //                    {
//    //                        MCtemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCtemp, machineDetail[dgSelectedIndex].machine_id.ToString() + '@' + machineDetail[dgSelectedIndex].ItemCode.ToString(), "ProductionPlanning", "Production", "getSO_ONMachin", 0, AppSessionState.location_Id);
//    //                        selectedMAchineSoDetail = MCtemp.machineSoDetailList;
//    //                    }
//    //                }
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //            / <summary>
//    //            / Returns Group by selected Items and get current machin status
//    //            / </summary>
//    //            private void getCurrentMachine()
//    //    {
//    //        try
//    //        {
//    //            machineDetail = new ObservableCollection<soListForPlan>();
//    //            if (dgSelectedIndex_groupby >= 0)
//    //            {
//    //                if (groupBySelectedItem.Count() > 0)
//    //                {
//    //                    MCtemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCtemp, groupBySelectedItem[dgSelectedIndex_groupby].ItemCode.ToString(), "ProductionPlanning", "Production", "GetCurrentMachine", 0, AppSessionState.location_Id);
//    //                    MC.machineDetailForProdList = MCtemp.machineDetailForProdList;
//    //                    machineDetail = MCtemp.machineDetailForProdList;
//    //                }
//    //            }
//    //            else if (dgSelectedIndex1 >= 0)
//    //            {
//    //                MCtemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCtemp, MC.soDetailList[dgSelectedIndex1].ItemCode.ToString(), "ProductionPlanning", "Production", "GetCurrentMachine", 0, AppSessionState.location_Id);
//    //                MC.machineDetailForProdList = MCtemp.machineDetailForProdList;
//    //                machineDetail = MCtemp.machineDetailForProdList;
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //    #endregion

//    //    #region . User Defined Function . 
//    //    private void LoadInitialData()
//    //    {
//    //        try
//    //        {
//    //            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "", "ProductionPlanning", "Production", "LOADALL", 0, AppSessionState.location_Id);

//    //            SOCollection = CollectionViewSource.GetDefaultView(MC.soDetailList);

//    //            CollectionModel = CollectionViewSource.GetDefaultView(MC.MachineList);
//    //            CollectionModel.Filter = new Predicate<object>(FilterModel);

//    //            DataCollection = CollectionViewSource.GetDefaultView(MC.productionPlanA);
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }
//    //    }
//    //    #endregion

//    //    #region · Command Actions ·

//    //    protected override void OnSaveAction(InquiryActionResult<EPR_T004_A> result)
//    //    {
//    //        try
//    //        {
//    //            ObjectSerializationService obj = new ObjectSerializationService();
//    //            SelectedEPR_T004.location_Id = AppSessionState.location_Id;
//    //            SelectedEPR_T004.comp_code = (AppSessionState.comp_code);

//    //            SelectedEPR_T004.XmlDataDocument_EPR_T004_B = obj.ObjectToXML(EPR_T004_BDetail);
//    //            SelectedEPR_T004.XmlDataDocument_EPR_T004_C = obj.ObjectToXML(EPR_T004_CDetailAll);

//    //            if (blNew == true)
//    //            {
//    //                SelectedEPR_T004 = repository.SaveWithReturnDomainObject<PUR_T002_A>(SelectedEPR_T004, "ProductionPlanning", "Production");
//    //                MC.productionPlanA.Add(SelectedEPR_T004);
//    //                _DataCollection.Refresh();
//    //                blNew = false;
//    //            }
//    //            else if (blNew == false)
//    //            {
//    //                SelectedEPR_T004 = repository.UpdateWithReturnDomainObject<PUR_T002_A>(SelectedEPR_T004, "ProductionPlanning", "Production");
//    //            }
//    //        }
//    //        catch (Exception ex)
//    //        {
//    //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
//    //            showMessageService.ButtonSetup = DialogButton.Ok;
//    //            showMessageService.Caption = "Message";
//    //            showMessageService.Text = String.Format(ex.Message, this.Title);
//    //            showMessageService.ShowMessage();
//    //        }

//    //    }
//    //    protected override void OnCreateAction(InquiryActionResult<EPR_T004_A> result)
//    //    {
//    //        foreach (var item in MC.soDetailList)
//    //            item.Select = false;
//    //        SelectedEPR_T004 = new EPR_T004_A();
//    //        MC.soDetailList = new ObservableCollection<soListForPlan>();
//    //        MC.machineDetailForProdList = new ObservableCollection<soListForPlan>();
//    //        machineDetail = new ObservableCollection<soListForPlan>();
//    //        selectedMAchineSoDetail = new ObservableCollection<soListForPlan>();
//    //        EPR_T004_BDetail = new ObservableCollection<EPR_T004_B>();
//    //        EPR_T004_CDetail = new ObservableCollection<EPR_T004_C>();
//    //        groupBySelectedItem = new ObservableCollection<soListForPlan>();
//    //        selectedItemGroupByList = new ObservableCollection<soListForPlan>();
//    //    }
//    //    protected override void OnRemoveAction(InquiryActionResult<EPR_T004_A> result)
//    //    {

//    //    }
//    //    protected override void OnDiscardAction(InquiryActionResult<EPR_T004_A> result)
//    //    {
//    //        SelectedEPR_T001.CancelEdit();
//    //    }
//    //    protected override void OnFevoriteAction(InquiryActionResult<EPR_T004_A> result)
//    //    {
//    //        SelectedList = SelectedList;
//    //    }
//    //    protected override void OnFlipAction(InquiryActionResult<EPR_T004_A> result)
//    //    {
//    //        SelectedList = SelectedList;
//    //        SelectedEPR_T001 = SelectedEPR_T001;
//    //    }
//    //    protected override void OnHelpAction(InquiryActionResult<EPR_T004_A> result)
//    //    {
//    //        SelectedList = SelectedList;
//    //        SelectedEPR_T001 = SelectedEPR_T001;
//    //    }
//    //    protected override void OnPrintAction(InquiryActionResult<EPR_T004_A> result)
//    //    {

//    //    }

//    //    #endregion

//    //    #region Filters
//    //    private string _filterStringModel;
//    //    private void FilterCollectionModel()
//    //    {
//    //        if (_CollectionModel != null)
//    //        {
//    //            _CollectionModel.Refresh();
//    //        }
//    //    }
//    //    public string FilterStringModel
//    //    {
//    //        get { return _filterStringModel; }
//    //        set
//    //        {
//    //            _filterStringModel = value;
//    //            RaisePropertychanged("FilterStringModel");
//    //            FilterCollectionModel();
//    //        }
//    //    }
//    //    public bool FilterModel(object obj)
//    //    {
//    //        -   
//    //           var data = obj as ZADM_M013_PopUp;
//    //        if (data != null)
//    //        {
//    //            if (!string.IsNullOrEmpty(_filterStringModel))
//    //            {
//    //                return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringModel.ToLower()));
//    //            }
//    //            return true;
//    //        }
//    //        return false;
//    //    }

//    //    #endregion
//    //}
//}

