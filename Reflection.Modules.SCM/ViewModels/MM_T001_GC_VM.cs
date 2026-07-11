using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.ReportingServices;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_GC_VM : WorkspaceViewModel<MM_T001>
    {
        #region Declaration

        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MC = new WebServiceRepository<MC_MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MCTemp = new WebServiceRepository<MC_MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_Temp = new WebServiceRepository<MC_MM_T001>();

        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MC_MM_T001 _MC = new MC_MM_T001();
        public MC_MM_T001 MC
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

        private MC_MM_T001 _MCTemp = new MC_MM_T001();
        public MC_MM_T001 MCTemp
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

        private MC_MM_T001 _Temp = new MC_MM_T001();
        public MC_MM_T001 Temp
        {
            get { return _Temp; }
            set
            {
                if (_Temp != value)
                {
                    _Temp = value; RaisePropertyChanged("Temp");
                }
            }
        }

        private MM_T001 _MasterEntity;
        public MM_T001 MasterEntity
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

        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
                }
            }
        }

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }

        private bool _PostDateEditable;
        public bool PostDateEditable
        {
            get { return _PostDateEditable; }
            set { _PostDateEditable = value; RaisePropertyChanged("PostDateEditable"); }
        }

        private bool _GridEditable;
        public bool GridEditable
        {
            get { return _GridEditable; }
            set
            {
                if (_GridEditable != value)
                {
                    _GridEditable = value;
                    RaisePropertyChanged("GridEditable");
                }
            }
        }

        private ObservableCollection<MM_T001_A> _ItemsEntity;
        public ObservableCollection<MM_T001_A> ItemsEntity
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

        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }
        string store_location;
        #endregion

        #region List
        private List<MM_T001Flip> _FlipGridData;
        public List<MM_T001Flip> FlipGridData
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
        private int _ParadgSelectedIndex;
        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
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

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _MovementTypeCollection;
        public ICollectionView MovementTypeCollection
        {
            get { return _MovementTypeCollection; }
            set { _MovementTypeCollection = value; RaisePropertyChanged("MovementTypeCollection"); }

        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set { _InkCollection = value; RaisePropertyChanged("InkCollection"); }
        }

        private ICollectionView _IldCollection;
        public ICollectionView IldCollection
        {
            get { return _IldCollection; }
            set { _IldCollection = value; RaisePropertyChanged("IldCollection"); }
        }

        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set { _GradeCollection = value; RaisePropertyChanged("GradeCollection"); }
        }

        private ICollectionView _SourceItemCollection;
        public ICollectionView SourceItemCollection
        {
            get { return _SourceItemCollection; }
            set { _SourceItemCollection = value; RaisePropertyChanged("SourceItemCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }

        private ICollectionView _ParaValueCollection;
        public ICollectionView ParaValueCollection
        {
            get { return _ParaValueCollection; }
            set { _ParaValueCollection = value; RaisePropertyChanged("ParaValueCollection"); }
        }

        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set { _UnitCollection = value; RaisePropertyChanged("UnitCollection"); }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region StringList
        List<string> _StringListMovementType;
        public List<string> StringListMovementType
        {
            get { return _StringListMovementType; }
            set
            {
                if (_StringListMovementType != value)
                {
                    _StringListMovementType = value;
                }
            }
        }

        List<string> _StringListInk;
        public List<string> StringListInk
        {
            get { return _StringListInk; }
            set
            {
                if (_StringListInk != value)
                {
                    _StringListInk = value;
                }
            }
        }

        List<string> _StringListIld;
        public List<string> StringListIld
        {
            get { return _StringListIld; }
            set
            {
                if (_StringListIld != value)
                {
                    _StringListIld = value;
                }
            }
        }

        List<string> _StringListGrade;
        public List<string> StringListGrade
        {
            get { return _StringListGrade; }
            set
            {
                if (_StringListGrade != value)
                {
                    _StringListGrade = value;
                }
            }
        }

        List<string> _StringListSourceItem;
        public List<string> StringListSourceItem
        {
            get { return _StringListSourceItem; }
            set
            {
                if (_StringListSourceItem != value)
                {
                    _StringListSourceItem = value;
                }
            }
        }

        List<string> _StringListUnit;
        public List<string> StringListUnit
        {
            get { return _StringListUnit; }
            set
            {
                if (_StringListUnit != value)
                {
                    _StringListUnit = value;
                }
            }
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdAddMovementType { get; private set; }
        public RelayCommand<object> CmdAddGCSourceInk { get; private set; }
        public RelayCommand<object> CmdAddGCSourceIld { get; private set; }
        public RelayCommand<object> CmdAddGCSourceGrade { get; private set; }
        public RelayCommand<object> CmdAddGCDestinationGrade { get; private set; }
        public RelayCommand<object> CmdAddGCSourceItem { get; private set; }
        public RelayCommand<object> CmdAddGCSourceUnit { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRow { get; private set; }
        public RelayCommand<object> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand<IList> cmdselectionchangeforParameter { get; private set; }
        public RelayCommand CmdLoadFromDateToDate { get; private set; }
        public RelayCommand CmdRowChange { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public MM_T001_GC_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            parameter = false; PostDateEditable = true; GridEditable = true;
            MasterEntity = new MM_T001();
            MasterEntity.mov_tp = "125";
            FlipGridData = new List<MM_T001Flip>();

            ItemsEntity = new ObservableCollection<MM_T001_A>();
           
            LoadInitialData();
        }
        public MM_T001_GC_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            parameter = false; PostDateEditable = true; GridEditable = true;
            MasterEntity = new MM_T001();
            MasterEntity.mov_tp = "125";
            FlipGridData = new List<MM_T001Flip>();

            ItemsEntity = new ObservableCollection<MM_T001_A>();

            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                DefaultValues();
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "ProductConversion_Essem", "SCM", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdAddMovementType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
                CmdAddGCSourceInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertGCSourceInk(items, true, true, true); });
                CmdAddGCSourceIld = new RelayCommand<object>(items => { if (items == null) { return; } InsertGCSourceIld(items, true, true, true); });
                CmdAddGCSourceGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertGCSourceGrade(items, true, true, true); });
                CmdAddGCDestinationGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertGCDestinationGrade(items, true, true, true); });
                CmdAddGCSourceItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertGCSourceItem(items, true, true, true); });
                CmdAddGCSourceUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertGCSourceUnit(items, true, true, true); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdDeleteDataGridRow = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow(items); });
                CmdLoadFromDateToDate = new RelayCommand(Load);
                CmdRowChange = new RelayCommand(SelectionChanged);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);

                MovementTypeCollection = CollectionViewSource.GetDefaultView(MC.MovementDetails);
                MovementTypeCollection.Filter = new Predicate<object>(Filter_MovementType);
                StringListMovementType = MC.MovementDetails.Select(x => x.mov_tp.ToString()).ToList();

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkDetails);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);
                StringListInk = MC.InkDetails.Select(x => x.ink.ToString()).ToList();

                IldCollection = CollectionViewSource.GetDefaultView(MC.IldDetails);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);
                StringListIld = MC.IldDetails.Select(x => x.ild.ToString()).ToList();

                GradeCollection = CollectionViewSource.GetDefaultView(MC.GradeDetails);
                GradeCollection.Filter = new Predicate<object>(Filter_Grade);
                StringListGrade = MC.GradeDetails.Select(x => x.grade_code.ToString()).ToList();

                SourceItemCollection = CollectionViewSource.GetDefaultView(MC.SourceItemDetails);
                SourceItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListSourceItem = MC.SourceItemDetails.Select(x => x.ItemCode.ToString()).ToList();

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UOMDetails);
                UnitCollection.Filter = new Predicate<object>(Filter_Unit);
                StringListUnit = MC.UOMDetails.Select(x => x.unit_code.ToString()).ToList();

                //if (StoreLocList.Count == 1)
                //{
                //    store_location = StoreLocList[0].store_code;
                //}
                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                store_location = (from o in StoreLocList
                                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
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
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "PC";
            MasterEntity.doc_type = "PC";
            MasterEntity.doc_code = "PC";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.dept_code = AppSessionState.dept_code;
            MasterEntity.t_status = "001";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private void SelectionChanged()
        {
            try
            {
                if (dgSelectedIndexItem != -1 && dgSelectedIndexItem < ItemsEntity.Count && ItemsEntity.Count > 0)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0)
                    {
                        GridEditable = true;
                    }
                    else
                    {
                        GridEditable = false;
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
        private void InsertMovementType(object InputValue)
        {
            string Request = "";
            MM_M004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MovementDetails.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.mov_tp = POPUPEntityObject.mov_tp;
                MasterEntity.mov_name = POPUPEntityObject.mov_name;
            }
        }
        private void InsertGCSourceInk(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.InkDetails.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.para1 == POPUPEntityObject.ink).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para1 == POPUPEntityObject.ink).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                        ItemsEntity[dgSelectedIndexItem].para3 = POPUPEntityObject.ink;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].para1 != POPUPEntityObject.ink)
                    {
                        ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                        ItemsEntity[dgSelectedIndexItem].para3 = POPUPEntityObject.ink;
                    }
                }
            }
        }
        private void InsertGCSourceIld(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.IldDetails.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                var InputValueIfExists = ItemsEntity.Where(X => X.para2 == POPUPEntityObject.ild).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para2 == POPUPEntityObject.ild).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.show_ild;
                        ItemsEntity[dgSelectedIndexItem].para4 = POPUPEntityObject.show_ild;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].para2 != POPUPEntityObject.ild)
                    {
                        ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.show_ild;
                        ItemsEntity[dgSelectedIndexItem].para4 = POPUPEntityObject.show_ild;
                    }
                }
            }
        }
        private void InsertGCSourceGrade(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M045_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GradeDetails.Where(x => x.grade_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M045_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.user_source1 == POPUPEntityObject.grade_code).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.user_source1 == POPUPEntityObject.grade_code).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].user_source1 = POPUPEntityObject.grade_code;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].user_source1 != POPUPEntityObject.grade_code)
                    {
                        ItemsEntity[dgSelectedIndexItem].user_source1 = POPUPEntityObject.grade_code;
                    }
                }
            }
        }
        private void InsertGCDestinationGrade(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M045_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GradeDetails.Where(x => x.grade_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M045_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.para5 == POPUPEntityObject.grade_code).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para5 == POPUPEntityObject.grade_code).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.grade_code;

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].para5 != POPUPEntityObject.grade_code)
                    {
                        ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.grade_code;
                    }
                }
            }
        }
        private void InsertGCSourceItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_POPUP POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SourceItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_POPUP>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                //Insert
                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new MM_T001_A()
                    {
                        //id = 0,
                        ItemCode = POPUPEntityObject.ItemCode,
                        ItemNm = POPUPEntityObject.ItemName,
                        unit_code = POPUPEntityObject.unit_code,
                        SubCatCode = POPUPEntityObject.SubCatCode,
                        StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                        para1 = POPUPEntityObject.ink,
                        para2 = POPUPEntityObject.ild,
                        user_source1 = POPUPEntityObject.Grade,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        client =AppSessionState.client,
                        add_by = AppSessionState.UserID,
                        debcr_ind = "D",
                        posting_period = "1",
                        fin_year = "16-17",
                        line_id = 0,
                        active = true,
                        store_code = store_location,
                        ri_item = POPUPEntityObject.ItemCode,
                        ri_unit_cd = POPUPEntityObject.unit_code,
                        para3 = POPUPEntityObject.ink,
                        para4 = POPUPEntityObject.ild,
                    });
                }
                //update
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].ItemNm = POPUPEntityObject.ItemName;
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                        ItemsEntity[dgSelectedIndexItem].StockUnt = POPUPEntityObject.StockUnt;
                        ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                        ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.ild;
                        ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                        ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                        ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                        ItemsEntity[dgSelectedIndexItem].ri_item = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].fin_year = "16-17";
                        ItemsEntity[dgSelectedIndexItem].posting_period = "1";
                        ItemsEntity[dgSelectedIndexItem].line_id = 0;
                        ItemsEntity[dgSelectedIndexItem].active = true;
                        ItemsEntity[dgSelectedIndexItem].debcr_ind = "D";
                        ItemsEntity[dgSelectedIndexItem].store_code = store_location;
                        ItemsEntity[dgSelectedIndexItem].client = AppSessionState.client;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                        ItemsEntity[dgSelectedIndexItem].ItemNm = "";
                        ItemsEntity[dgSelectedIndexItem].ri_item = "";
                    }
                }

            }
        }
        private void InsertGCSourceUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        ItemsEntity[dgSelectedIndexItem].unit_Name = POPUPEntityObject.unit_name;
                        ItemsEntity[dgSelectedIndexItem].ri_unit_cd = POPUPEntityObject.unit_code;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                    {
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        ItemsEntity[dgSelectedIndexItem].unit_Name = POPUPEntityObject.unit_name;
                        ItemsEntity[dgSelectedIndexItem].ri_unit_cd = POPUPEntityObject.unit_code;
                    }
                }
            }
        }
        private void DeleteDataGridRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            MM_T001Flip ParameterEntityObject = null;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            if (((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList()[0];
                PostDateEditable = false;
                GridEditable = false;
                NewRecord = false;
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "ProductConversion_Essem", "SCM", "LoadDocumentByDocumentNumber", 0, "");
                MasterEntity = MCTemp.MasterEntity[0];
                ItemsEntity = MCTemp.ItemsEntity;
                MasterEntity.ts_code = ts_code_vm;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");
                AttachmentCollection = MCTemp.AttachmentData;
                if (MCTemp.AttachmentData != null)
                {
                    AttachmentCollection = MCTemp.AttachmentData;
                }
                else
                {
                    MCTemp.AttachmentData = new List<COM_T003>();
                }
            }
        }
        private void Load()
        {
            if (MasterEntity.From_Date != null && MasterEntity.ToDate != null)
            {
                string Request = "LoadFromDateToDate" + "!@" + Convert.ToDateTime(MasterEntity.From_Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "ProductConversion_Essem", "SCM", "", 0, "");
                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Date....", this.Title);
                showMessageService.ShowMessage();
            }
        }
        private bool Validation()
        {
            if (MasterEntity.mov_tp == null || MasterEntity.mov_tp == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Movement Type");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.post_date == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Posting Date");
                showMessageService.ShowMessage();
                return false;
            }

            if (ItemsEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Item For Conversion");
                showMessageService.ShowMessage();
                return false;
            }

            else
            {
                GenerateSku();
                GenerateSku2();
                #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .

                foreach (var o in ItemsEntity)
                {
                    int flag = 0;
                    if (o.id == 0 && o.active == true)
                    {
                        foreach (var p in ItemsEntity)
                        {
                            if (o.ItemCode == p.ItemCode && o.sku == p.sku && p.active == true)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                    if (o.ItemCode != null && o.ItemCode != "")
                    {
                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.user_source1 == null || o.user_source1 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Grade");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para1 == null || o.para1 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Ink");
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.para2 == null || o.para2 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Ild");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para5 == null || o.para5 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Grade To which you want to Convert");
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.user_source1 == o.para5)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Source Grade And Destination Grade Must be Different \n Please select another Destination Grade");
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                }

                #endregion
            }
            return true;
        }
        private void GenerateSku()
        {
            string Grade = "";
            string Ink = "";
            string Ild = "";
            foreach (var o in ItemsEntity)
            {
                if (o.id == 0 && o.StockUnt==true)
                {
                    Grade = "";
                    Ink = "";
                    Ild = "";
                    if (o.user_source1 != null && o.user_source1 != "" && o.para1 != null && o.para1 != "" && o.para2 != null && o.para2 != "")
                    {
                        Grade = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.user_source1.Trim() && X.para_code == "1004").Select(x => x.value_code).FirstOrDefault();

                        Ink = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para1.Trim() && X.para_code == "1005").Select(x => x.value_code).FirstOrDefault();
                        Ild = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para2.Trim() && X.para_code == "1006").Select(x => x.value_code).FirstOrDefault();

                        o.sku = Grade + "/" + Ink + "/" + Ild;
                        o.sku_desc = "Grade:" + o.user_source1 + "\t" + "Ink:" + o.para1 + "\t" + "Ild:" + o.para2;
                    }
                }
            }
        }
        private void GenerateSku2()
        {
            string Grade = "";
            string Ink = "";
            string Ild = "";
            foreach (var o in ItemsEntity)
            {
                if (o.id == 0 && o.StockUnt == true)
                {
                    Grade = "";
                    Ink = "";
                    Ild = "";
                    if (o.para5 != null && o.para5 != "" && o.para3 != null && o.para3 != "" && o.para4 != null && o.para4 != "")
                    {
                        Grade = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para5.Trim() && X.para_code == "1004").Select(x => x.value_code).FirstOrDefault();
                        Ink = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para3.Trim() && X.para_code == "1005").Select(x => x.value_code).FirstOrDefault();
                        Ild = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para4.Trim() && X.para_code == "1006").Select(x => x.value_code).FirstOrDefault();
                        o.ri_sku = Grade + "/" + Ink + "/" + Ild;
                    }
                }

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
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
           
            NewRecord = true;
            parameter = false;
            PostDateEditable = true;
            GridEditable = true;
            MasterEntity = new MM_T001();
            MasterEntity.mov_tp = "125";
            MC.ItemsEntity = new ObservableCollection<MM_T001_A>();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            FlipDataGridCollection.Refresh();
            DefaultValues();
            MasterEntity.post_date = DateTime.Now;
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {
            MasterEntity.CancelEdit();
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
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
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        {
           
        }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
           
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        {
           
        }
        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                string Request = "LoadDocumentByDocumentNumber" + "!@" + MasterEntity.doc_no;
                Temp = repository_Temp.GetDataWithReturnDomainObject<MC_MM_T001>(Temp, Request, "ProductConversion_Essem", "SCM", Request, 0, "");

                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];

                objDataSource[0] = Temp.MasterEntity;
                objDataSource[1] = Temp.ItemsEntity;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[2] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[3] = Result;

                objDataSourceName[0] = "dsMasterData";
                objDataSourceName[1] = "dsItemData";
                objDataSourceName[2] = "dsCompany";
                objDataSourceName[3] = "dsLocation";
                
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\GradeConversion.rdlc", getParametersList(), "");
            }
            catch (Exception ex)
            {
            }
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
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
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        { 
        }
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                ObjectSerializationService obj = new ObjectSerializationService();

                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_MM_T001_A = obj.ObjectToXML(ItemsEntity);
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "ProductConversion_Essem", "SCM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "ProductConversion_Essem", "SCM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    PostDateEditable = false;
                    GridEditable = false;
                    if (MasterEntity.doc_no != null && MasterEntity.doc_no != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();

                        NewRecord = false;
                        parameter = false;
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_T001_A != null)
            {
                MC.ItemsEntity = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_A, MC.ItemsEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemsEntity;
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<MM_T001_A>();
            }

            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<MM_T001Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
            }
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
            var data = obj as MM_T001Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Movement Type
        private string _FilterStringMovementType;
        public string FilterStringMovementType
        {
            get { return _FilterStringMovementType; }
            set
            {
                _FilterStringMovementType = value;
                RaisePropertyChanged("FilterStringMovementType");
                Filter_MovementType();
            }
        }
        private void Filter_MovementType()
        {
            if (_MovementTypeCollection != null)
            {
                _MovementTypeCollection.Refresh();
            }
        }
        public bool Filter_MovementType(object obj)
        {
            var data = obj as MM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMovementType))
                {
                    return (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_FilterStringMovementType.ToLower())) ||
                           (data.mov_tp_name != null && data.mov_tp_name.ToString().ToLower().Contains(_FilterStringMovementType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Ink Data

        private string _FilterStringInk;
        public string FilterStringInk
        {
            get { return _FilterStringInk; }
            set
            {
                _FilterStringInk = value;
                RaisePropertyChanged("FilterStringInk");
                Filter_Ink();
            }
        }
        private void Filter_Ink()
        {
            if (_InkCollection != null)
            {
                _InkCollection.Refresh();
            }
        }
        public bool Filter_Ink(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringInk))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_FilterStringInk.ToLower())) ||
                           (data.desc != null && data.desc.ToString().ToLower().Contains(_FilterStringInk.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Ild
        private string _FilterStringIld;
        public string FilterStringIld
        {
            get { return _FilterStringIld; }
            set
            {
                _FilterStringIld = value;
                RaisePropertyChanged("FilterStringIld");
                Filter_Ild();
            }
        }
        private void Filter_Ild()
        {
            if (_IldCollection != null)
            {
                _IldCollection.Refresh();
            }
        }
        public bool Filter_Ild(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringIld))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_FilterStringIld.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Grade
        private string _FilterStringGrade;
        public string FilterStringGrade
        {
            get { return _FilterStringGrade; }
            set
            {
                _FilterStringGrade = value;
                RaisePropertyChanged("FilterStringGrade");
                Filter_Grade();
            }
        }
        private void Filter_Grade()
        {
            if (_GradeCollection != null)
            {
                _GradeCollection.Refresh();
            }
        }
        public bool Filter_Grade(object obj)
        {
            var data = obj as ADM_M045_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringGrade))
                {
                    return (data.grade_code != null && data.grade_code.ToString().ToLower().Contains(_FilterStringGrade.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter Source Item
        private string _FilterStringSourceItem;
        public string FilterStringSourceItem
        {
            get { return _FilterStringSourceItem; }
            set
            {
                _FilterStringSourceItem = value;
                RaisePropertyChanged("FilterStringSourceItem");
                Filter_Item();
            }
        }
        private void Filter_Item()
        {
            if (_SourceItemCollection != null)
            {
                _SourceItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringSourceItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(FilterStringSourceItem.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(FilterStringSourceItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Unit

        private string _FilterStringUnit;
        public string FilterStringUnit
        {
            get { return _FilterStringUnit; }
            set
            {
                _FilterStringUnit = value;
                RaisePropertyChanged("FilterStringUnit");
                Filter_Unit();
            }
        }
        private void Filter_Unit()
        {
            if (_UnitCollection != null)
            {
                _UnitCollection.Refresh();
            }
        }
        public bool Filter_Unit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterStringUnit.ToLower())) ||
                        (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_FilterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #endregion



       




    }
}
