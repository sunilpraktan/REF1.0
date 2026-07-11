using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Admin;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ZADM_M027_VM : WorkspaceViewModel<ZADM_M027>
    {
        bool isNewRecord = true;
        WebServiceRepository<ZADM_M027> repository = new WebServiceRepository<ZADM_M027>();
        WebServiceRepository<MultipleContext_ZADM_M027> repository_MC = new WebServiceRepository<MultipleContext_ZADM_M027>();
        WebServiceRepository<MultipleContext_ZADM_M027> repository_MCTemp = new WebServiceRepository<MultipleContext_ZADM_M027>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration

       

        private ZADM_M027 _masterEntity;
        public ZADM_M027 masterEntity
        {
            get
            {
                return _masterEntity;
            }
            set
            {
                if (_masterEntity != value)
                {
                    _masterEntity = value;
                    RaisePropertyChanged(nameof(masterEntity));
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<ZADM_M027> _MasterEntity;
        public ObservableCollection<ZADM_M027> MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    MasterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMaster);
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<ZADM_M027_A> _ItemEntity;
        public ObservableCollection<ZADM_M027_A> ItemEntity
        {
            get { return _ItemEntity; }
            set
            {
                if (_ItemEntity != value)
                {
                    _ItemEntity = value;
                    ItemEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemEntity");
                }
            }
        }

        private int _dgSelectedIndexMaster;
        public int dgSelectedIndexMaster
        {
            get
            {
                return _dgSelectedIndexMaster;
            }
            set
            {
                if (_dgSelectedIndexMaster != value)
                {
                    _dgSelectedIndexMaster = value;
                    RaisePropertyChanged("dgSelectedIndexMaster");
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

        MultipleContext_ZADM_M027 _MC = new MultipleContext_ZADM_M027();
        public MultipleContext_ZADM_M027 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

        MultipleContext_ZADM_M027 _MCTemp = new MultipleContext_ZADM_M027();
        public MultipleContext_ZADM_M027 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private List<ZADM_M027Flip> _FlipGridData;
        public List<ZADM_M027Flip> FlipGridData
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

        #region ICollection

        private ICollectionView _dataGridCollection;// BF COllection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
                RaisePropertyChanged("DataGridCollection");
            }
        }

        private ICollectionView _wireSizeCollection;
        public ICollectionView WireSizeCollection
        {
            get { return _wireSizeCollection; }
            set
            {
                _wireSizeCollection = value;
                RaisePropertyChanged("WireSizeCollection");
            }
        }

        private ICollectionView _wireTypeCollection;
        public ICollectionView WireTypeCollection
        {
            get { return _wireTypeCollection; }
            set
            {
                _wireTypeCollection = value;
                RaisePropertyChanged("WireTypeCollection");
            }
        }

        private ICollectionView _ballTypeCollection;
        public ICollectionView BallTypeCollection
        {
            get { return _ballTypeCollection; }
            set
            {
                _ballTypeCollection = value;
                RaisePropertyChanged("BallTypeCollection");
            }
        }

        private ICollectionView _totalLenCollection;
        public ICollectionView TotalLenCollection
        {
            get { return _totalLenCollection; }
            set
            {
                _totalLenCollection = value;
                RaisePropertyChanged("TotalLenCollection");
            }
        }

        private ICollectionView _unitListCollection;
        public ICollectionView UnitListCollection
        {
            get { return _unitListCollection; }
            set
            {
                _unitListCollection = value;
                RaisePropertyChanged("UnitListCollection");
            }
        }

        private ICollectionView _dateCollection;
        public ICollectionView DateCollection
        {
            get { return _dateCollection; }
            set
            {
                _dateCollection = value;
                RaisePropertyChanged("DateCollection");
            }
        }
        #endregion

        #region StringLists

        List<string> _StringListWireSize;
        public List<string> StringListWireSize
        {
            get { return _StringListWireSize; }
            set
            {
                if (_StringListWireSize != value)
                {
                    _StringListWireSize = value;
                }
            }
        }

        List<string> _StringListWireType;
        public List<string> StringListWireType
        {
            get { return _StringListWireType; }
            set
            {
                if (_StringListWireType != value)
                {
                    _StringListWireType = value;
                }
            }
        }

        List<string> _StringListBallType;
        public List<string> StringListBallType
        {
            get { return _StringListBallType; }
            set
            {
                if (_StringListBallType != value)
                {
                    _StringListBallType = value;
                }
            }
        }

        List<string> _StringListTipLen;
        public List<string> StringListTipLen
        {
            get { return _StringListTipLen; }
            set
            {
                if (_StringListTipLen != value)
                {
                    _StringListTipLen = value;
                }
            }
        }

        List<string> _StringListUOM;
        public List<string> StringListUOM
        {
            get { return _StringListUOM; }
            set
            {
                if (_StringListUOM != value)
                {
                    _StringListUOM = value;
                }
            }
        }

        List<string> _StringListDate;
        public List<string> StringListDate
        {
            get { return _StringListDate; }
            set
            {
                if (_StringListDate != value)
                {
                    _StringListDate = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdAddDate { get; private set; }
        public RelayCommand<object> CmdAddWireSize { get; private set; }
        public RelayCommand<object> CmdAddWireType { get; private set; }
        public RelayCommand<object> CmdAddBallType { get; private set; }
        public RelayCommand<object> CmdAddTotalLen { get; private set; }
        public RelayCommand<object> CmdAddUnitList { get; private set; }
        public RelayCommand<object> CmdAddItemBallType { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowMaster { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CmdAddSelectedDate { get; private set; }
        #endregion

        #region Constructor

        public ZADM_M027_VM() : base()
        {
            MasterEntity = new ObservableCollection<ZADM_M027>();
            ItemEntity = new ObservableCollection<ZADM_M027_A>();
            MC = new MultipleContext_ZADM_M027();
            MCTemp = new MultipleContext_ZADM_M027();
            masterEntity = new ZADM_M027();

            CmdAddWireSize = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireSize(cmdPara, true, true, true); });
            CmdAddWireType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireType(cmdPara, true, true, true); });
            CmdAddBallType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallType(cmdPara, true, true, true); });
            CmdAddTotalLen = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTotalLen(cmdPara, true, true, true); });
            CmdAddUnitList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnitList(cmdPara, true, true, true); });
            CmdAddItemBallType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemBallType(cmdPara, true, true, true); });
            cmdDeleteDataGridRowMaster = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowMaster(cmdPara); });
            cmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowItem(cmdPara); });
            CmdAddDate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDate(cmdPara); });
            CmdAddSelectedDate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedDate(cmdPara); });

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZADM_M027>(MC, Request, "RateMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                WireSizeCollection = CollectionViewSource.GetDefaultView(MC.WireSizeList);
                WireSizeCollection.Filter = new Predicate<object>(WireSizeFilter);
                StringListWireSize = MC.WireSizeList.Select(x => x.wire_size.ToString()).ToList();

                WireTypeCollection = CollectionViewSource.GetDefaultView(MC.WireTypeList);
                WireTypeCollection.Filter = new Predicate<object>(WireTypeFilter);
                StringListWireType = MC.WireTypeList.Select(x => x.wire_type.ToString()).ToList();

                BallTypeCollection = CollectionViewSource.GetDefaultView(MC.BallTypeList);
                BallTypeCollection.Filter = new Predicate<object>(BallTypeFilter);
                StringListBallType = MC.BallTypeList.Select(x => x.ball_type.ToString()).ToList();

                TotalLenCollection = CollectionViewSource.GetDefaultView(MC.TotalLenList);
                TotalLenCollection.Filter = new Predicate<object>(TipLenFilter);
                StringListTipLen = MC.TotalLenList.Select(x => x.total_len.ToString()).ToList();

                UnitListCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
                UnitListCollection.Filter = new Predicate<object>(UnitFilter);
                StringListUOM = MC.UnitList.Select(x => x.unit_code.ToString()).ToList();

                DateCollection = CollectionViewSource.GetDefaultView(MC.DateList);
                DateCollection.SortDescriptions.Add(new SortDescription("post_year", ListSortDirection.Descending));
                DateCollection.Filter = new Predicate<object>(DateFilter);
                StringListDate = MC.DateList.Select(x => x.short_desc.ToString()).ToList();

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

        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            masterEntity.revised_date = DateTime.Now;
        }
        private void InsertWireSize(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireSizeList.Where(x => x.wire_size.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                    {
                        var InputValueIfExists = MasterEntity.Where(X => X.wire_size == POPUPEntityObject.wire_size).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.wire_size == POPUPEntityObject.wire_size).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEntity.Count == dgSelectedIndexMaster)
                        {
                            MasterEntity.Add(new ZADM_M027()
                            {
                                id = 0,
                                active = true,
                                wire_size = POPUPEntityObject.wire_size,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                t_status = "Draft",
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                fin_year = masterEntity.fin_year,
                                posting_period = masterEntity.posting_period
                            });
                        }
                        else if (dgSelectedIndexMaster >= 0 && MasterEntity.Count > dgSelectedIndexMaster) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (MasterEntity[dgSelectedIndexMaster].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                MasterEntity[dgSelectedIndexMaster].wire_size = POPUPEntityObject.wire_size;
                                MasterEntity[dgSelectedIndexMaster].active = true;
                                MasterEntity[dgSelectedIndexMaster].location_Id = AppSessionState.location_Id;
                                MasterEntity[dgSelectedIndexMaster].comp_code = AppSessionState.comp_code;
                                MasterEntity[dgSelectedIndexMaster].t_status = "Draft";
                                MasterEntity[dgSelectedIndexMaster].add_by = AppSessionState.UserID;
                                MasterEntity[dgSelectedIndexMaster].editby = AppSessionState.UserID;
                                MasterEntity[dgSelectedIndexMaster].fin_year = masterEntity.fin_year;
                                MasterEntity[dgSelectedIndexMaster].posting_period = masterEntity.posting_period;
                            }
                            else if (MasterEntity[dgSelectedIndexMaster].wire_size != POPUPEntityObject.wire_size)
                            {
                                MasterEntity[dgSelectedIndexMaster].wire_size = POPUPEntityObject.wire_size;
                                MasterEntity[dgSelectedIndexMaster].location_Id = AppSessionState.location_Id;
                                MasterEntity[dgSelectedIndexMaster].comp_code = AppSessionState.comp_code;
                                MasterEntity[dgSelectedIndexMaster].t_status = "Draft";
                                MasterEntity[dgSelectedIndexMaster].add_by = AppSessionState.UserID;
                                MasterEntity[dgSelectedIndexMaster].editby = AppSessionState.UserID;
                                MasterEntity[dgSelectedIndexMaster].fin_year = masterEntity.fin_year;
                                MasterEntity[dgSelectedIndexMaster].posting_period = masterEntity.posting_period;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Date...");
                        showMessageService.ShowMessage();
                    }
                    #region Clear Empty Row
                    ZADM_M027 newObj = new ZADM_M027();
                    for (int i = MasterEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                        if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                        {
                            MasterEntity.RemoveAt(i);
                            if (MasterEntity.Count == 0)
                            {
                                MasterEntity.Add(newObj);
                            }
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertWireType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M004_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireTypeList.Where(x => x.wire_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                    {
                        var InputValueIfExists = MasterEntity.Where(X => X.wire_type == POPUPEntityObject.wire_type).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.wire_type == POPUPEntityObject.wire_type).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEntity.Count == dgSelectedIndexMaster)
                        {
                            MasterEntity.Add(new ZADM_M027()
                            {
                                id = 0,
                                active = true,
                                wire_type = POPUPEntityObject.wire_type,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                t_status = "Draft",
                                posting_period = "10",
                                fin_year = "16-17",
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID
                            });
                        }
                        else if (dgSelectedIndexMaster >= 0 && MasterEntity.Count > dgSelectedIndexMaster) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (MasterEntity[dgSelectedIndexMaster].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                MasterEntity[dgSelectedIndexMaster].wire_type = POPUPEntityObject.wire_type;
                            }
                            else if (MasterEntity[dgSelectedIndexMaster].wire_type != POPUPEntityObject.wire_type)
                            {
                                MasterEntity[dgSelectedIndexMaster].wire_type = POPUPEntityObject.wire_type;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Date...");
                        showMessageService.ShowMessage();
                    }
                }

                #region Clear Empty Row
                ZADM_M027 newObj = new ZADM_M027();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertBallType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallTypeList.Where(x => x.ball_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                    {
                        var InputValueIfExists = MasterEntity.Where(X => X.ball_type == POPUPEntityObject.ball_type).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_type == POPUPEntityObject.ball_type).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEntity.Count == dgSelectedIndexMaster)
                        {
                            MasterEntity.Add(new ZADM_M027()
                            {
                                id = 0,
                                active = true,
                                ball_type = POPUPEntityObject.ball_type,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                t_status = "Draft",
                                posting_period = "10",
                                fin_year = "16-17",
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID
                            });
                        }
                        else if (dgSelectedIndexMaster >= 0 && MasterEntity.Count > dgSelectedIndexMaster) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (MasterEntity[dgSelectedIndexMaster].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                MasterEntity[dgSelectedIndexMaster].ball_type = POPUPEntityObject.ball_type;
                            }
                            else if (MasterEntity[dgSelectedIndexMaster].ball_type != POPUPEntityObject.ball_type)
                            {
                                MasterEntity[dgSelectedIndexMaster].ball_type = POPUPEntityObject.ball_type;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Date...");
                        showMessageService.ShowMessage();
                    }
                }
                #region Clear Empty Row
                ZADM_M027 newObj = new ZADM_M027();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

            }
        }
        private void InsertTotalLen(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M008_P POPUPEntityObject = null;
                dgSelectedIndexMaster = dgSelectedIndexMaster;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TotalLenList.Where(x => x.total_len.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M008_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M008_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                    {
                        var InputValueIfExists = MasterEntity.Where(X => X.total_len == POPUPEntityObject.total_len).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.total_len == POPUPEntityObject.total_len).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEntity.Count == dgSelectedIndexMaster)
                        {
                            MasterEntity.Add(new ZADM_M027()
                            {
                                id = 0,
                                active = true,
                                total_len = POPUPEntityObject.total_len,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                t_status = "Draft",
                                posting_period = "10",
                                fin_year = "16-17",
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID
                            });
                        }
                        else if (dgSelectedIndexMaster >= 0 && MasterEntity.Count > dgSelectedIndexMaster) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (MasterEntity[dgSelectedIndexMaster].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                MasterEntity[dgSelectedIndexMaster].total_len = POPUPEntityObject.total_len;
                            }
                            else if (MasterEntity[dgSelectedIndexMaster].total_len != POPUPEntityObject.total_len)
                            {
                                MasterEntity[dgSelectedIndexMaster].total_len = POPUPEntityObject.total_len;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Date...");
                        showMessageService.ShowMessage();
                    }
                }
                #region Clear Empty Row
                ZADM_M027 newObj = new ZADM_M027();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

            }
        }
        private void InsertUnitList(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexMaster = dgSelectedIndexMaster;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                    {
                        var InputValueIfExists = MasterEntity.Where(X => X.rate_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.rate_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEntity.Count == dgSelectedIndexMaster)
                        {
                            MasterEntity.Add(new ZADM_M027()
                            {
                                id = 0,
                                active = true,
                                rate_unit = POPUPEntityObject.unit_code,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                t_status = "Draft",
                                posting_period = "10",
                                fin_year = "16-17",
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                            });
                        }
                        else if (dgSelectedIndexMaster >= 0 && MasterEntity.Count > dgSelectedIndexMaster) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (MasterEntity[dgSelectedIndexMaster].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                MasterEntity[dgSelectedIndexMaster].rate_unit = POPUPEntityObject.unit_code;
                            }
                            else if (MasterEntity[dgSelectedIndexMaster].rate_unit != POPUPEntityObject.unit_code)
                            {
                                MasterEntity[dgSelectedIndexMaster].rate_unit = POPUPEntityObject.unit_code;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Date...");
                        showMessageService.ShowMessage();
                    }
                }
                #region Clear Empty Row
                ZADM_M027 newObj = new ZADM_M027();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

            }
        }
        private void InsertItemBallType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.BallTypeList.Where(x => x.ball_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                    {
                        var InputValueIfExists = ItemEntity.Where(X => X.ball_type == POPUPEntityObject.ball_type).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = ItemEntity.IndexOf(ItemEntity.Where(X => X.ball_type == POPUPEntityObject.ball_type).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemEntity.Count == dgSelectedIndexItem)
                        {
                            ItemEntity.Add(new ZADM_M027_A()
                            {
                                id = 0,
                                active = true,
                                ball_type = POPUPEntityObject.ball_type,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                t_status = "Draft",
                                posting_period = masterEntity.posting_period,
                                fin_year = masterEntity.fin_year,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID
                            });
                        }
                        else if (dgSelectedIndexItem >= 0 && ItemEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (ItemEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                ItemEntity[dgSelectedIndexItem].ball_type = POPUPEntityObject.ball_type;
                                ItemEntity[dgSelectedIndexItem].active = true;
                                ItemEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                                ItemEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                                ItemEntity[dgSelectedIndexItem].t_status = "Draft";
                                ItemEntity[dgSelectedIndexItem].posting_period = masterEntity.posting_period;
                                ItemEntity[dgSelectedIndexItem].fin_year = masterEntity.fin_year;
                                ItemEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                                ItemEntity[dgSelectedIndexItem].editby = AppSessionState.UserID;
                            }
                            else if (ItemEntity[dgSelectedIndexItem].ball_type != POPUPEntityObject.ball_type)
                            {
                                ItemEntity[dgSelectedIndexItem].ball_type = POPUPEntityObject.ball_type;
                                ItemEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                                ItemEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                                ItemEntity[dgSelectedIndexItem].t_status = "Draft";
                                ItemEntity[dgSelectedIndexItem].posting_period = masterEntity.posting_period;
                                ItemEntity[dgSelectedIndexItem].fin_year = masterEntity.fin_year;
                                ItemEntity[dgSelectedIndexItem].editby = AppSessionState.UserID;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Date...");
                        showMessageService.ShowMessage();
                    }
                }
                #region Clear Empty Row
                ZADM_M027_A newObj = new ZADM_M027_A();
                for (int i = ItemEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemEntity[i].ComparePropertiesTo(newObj);
                    if (ItemEntity[i].ComparePropertiesTo(newObj) == true && ItemEntity.Count > 1)
                    {
                        ItemEntity.RemoveAt(i);
                        if (ItemEntity.Count == 0)
                        {
                            ItemEntity.Add(newObj);
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {

            }
        }
        private void InsertDate(object InputValue)
        {
            string Request = "";
            ACC_M001A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DateList.Where(x => x.short_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    masterEntity.monthyear = POPUPEntityObject.short_desc + '-' + POPUPEntityObject.calender_year;

                    // Regular month fields
                    masterEntity.month = POPUPEntityObject.short_desc;
                    masterEntity.year = POPUPEntityObject.calender_year.ToString();
                    masterEntity.post_mon = POPUPEntityObject.post_mon;

                    // Fin year fields
                    masterEntity.post_year = POPUPEntityObject.post_year;
                    masterEntity.fin_year = POPUPEntityObject.fin_year;
                    masterEntity.posting_period = POPUPEntityObject.posting_period;

                    string request = "LoadDataByMonthAndYear" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + masterEntity.posting_period + "!@" + masterEntity.fin_year;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M027>(MC, request, "RateMaster", "Administration", "LoadDataByMonthAndYear", 0, "");

                    MasterEntity = MCTemp.MasterEntity;
                    ItemEntity = MCTemp.ItemEntity;
                    if (MasterEntity.Count > 0)
                    {
                        masterEntity = MasterEntity[0];
                    }
                    //masterEntity.calender_year = POPUPEntityObject.calender_year;

                    isNewRecord = false;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertSelectedDate(object InputValue)
        {
            if (InputValue != null)
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DateList.Where(x => x.short_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                    if (POPUPEntityObject != null)
                    {
                        if (masterEntity.monthyear != null && masterEntity.monthyear != "")
                        {
                            masterEntity.s_monthyear = POPUPEntityObject.short_desc + '-' + POPUPEntityObject.calender_year;

                            masterEntity.s_month = POPUPEntityObject.short_desc;
                            masterEntity.s_year = POPUPEntityObject.calender_year.ToString();
                            masterEntity.s_post_mon = POPUPEntityObject.post_mon;

                            masterEntity.s_post_year = POPUPEntityObject.post_year;

                            if ((Convert.ToInt32(masterEntity.post_year) > Convert.ToInt32(POPUPEntityObject.post_year) || Convert.ToInt32(masterEntity.post_year) >= Convert.ToInt32(POPUPEntityObject.post_year)) && Convert.ToInt32(masterEntity.posting_period) > Convert.ToInt32(POPUPEntityObject.posting_period))
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Please Select Valid Date...");
                                showMessageService.ShowMessage();
                                masterEntity.s_monthyear = null;
                            }
                            else
                            {
                                masterEntity.fin_year = POPUPEntityObject.fin_year;
                                masterEntity.posting_period = POPUPEntityObject.posting_period;

                                isNewRecord = true;

                                foreach (var item in MasterEntity)
                                {
                                    item.id = 0;
                                    item.month = POPUPEntityObject.short_desc;
                                    item.year = POPUPEntityObject.calender_year.ToString();
                                    item.revised_date = masterEntity.revised_date;
                                    item.fin_year = POPUPEntityObject.fin_year;
                                    item.posting_period = POPUPEntityObject.posting_period;
                                    item.post_mon = POPUPEntityObject.post_mon;
                                    item.post_year = POPUPEntityObject.post_year;
                                }
                                foreach (var item in ItemEntity)
                                {
                                    item.id = 0;
                                    item.month = POPUPEntityObject.short_desc;
                                    item.year = POPUPEntityObject.calender_year.ToString();
                                    item.revised_date = masterEntity.revised_date;
                                    item.fin_year = POPUPEntityObject.fin_year;
                                    item.posting_period = POPUPEntityObject.posting_period;
                                    item.post_mon = POPUPEntityObject.post_mon;
                                    item.post_year = POPUPEntityObject.post_year;
                                }
                            }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please Select Date...");
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
            else
            {
                if (((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList().Count > 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format(masterEntity.monthyear + " does not have any Records");
                    showMessageService.ShowMessage();
                }
            }
        }
        private bool Validation()
        {
            foreach (var item in MasterEntity)
            {
                if (item.wire_size == null || item.wire_size.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Wire Size...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (item.wire_type == null || item.wire_type.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Wire Type...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (item.ball_type == null || item.ball_type.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Ball Type...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (item.total_len == null || item.total_len.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Tip Length...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
            }
            foreach (var item in ItemEntity)
            {
                if (item.ball_type == null || item.ball_type.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Ball Type...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (item.dia_from == null || item.dia_from.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Ball Diameter range...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (item.dia_to == null || item.dia_to.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter Ball Diameter range...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (item.price == null || item.price.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Enter price for ball type..." + item.ball_type.ToString() , this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
            }
            if (masterEntity.revised_date == null || masterEntity.revised_date.ToString() == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Select Revised Date...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (masterEntity.XmlDataDocument_ZADM_M027 != null)
                {
                    MasterEntity.Clear();
                    MasterEntity = (ObservableCollection<ZADM_M027>)new ObjectSerializationService().XMLToObject(masterEntity.XmlDataDocument_ZADM_M027, MC.MasterEntity);
                    if (MasterEntity.Count > 0)
                    {
                        masterEntity.monthyear = MasterEntity[0].monthyear;
                        // Regular month fields
                        masterEntity.month = MasterEntity[0].month;
                        masterEntity.year = MasterEntity[0].year.ToString();
                        masterEntity.post_mon = MasterEntity[0].post_mon;
                        // Fin year fields
                        masterEntity.post_year = MasterEntity[0].post_year;
                        masterEntity.fin_year = MasterEntity[0].fin_year;
                        masterEntity.posting_period = MasterEntity[0].posting_period;
                    }
                }
                else
                {
                    MasterEntity = new ObservableCollection<ZADM_M027>();
                }
                if (masterEntity.XmlDataDocument_ZADM_M027_A != null)
                {
                    ItemEntity.Clear();
                    ItemEntity = (ObservableCollection<ZADM_M027_A>)new ObjectSerializationService().XMLToObject(masterEntity.XmlDataDocument_ZADM_M027_A, MC.ItemEntity);
                    if (ItemEntity.Count > 0 && masterEntity.monthyear == null)
                    {
                        masterEntity.monthyear = ItemEntity[0].month .ToString() + "-" + ItemEntity[0].year.ToString();
                        // Regular month fields
                        masterEntity.month = ItemEntity[0].month;
                        masterEntity.year = ItemEntity[0].year.ToString();
                        masterEntity.post_mon = ItemEntity[0].post_mon;
                        // Fin year fields
                        masterEntity.post_year = ItemEntity[0].post_year;
                        masterEntity.fin_year = ItemEntity[0].fin_year;
                        masterEntity.posting_period = ItemEntity[0].posting_period;
                    }
                }
                else
                {
                    ItemEntity = new ObservableCollection<ZADM_M027_A>();
                }
                //if (masterEntity.XmlDataDocument_ZADM_M027FLIP != null && isNewRecord == true && ParameterOption1 == "Save")
                //{
                //    MC.DocumentDataFlipGrid = (List<ZADM_M027Flip>)new ObjectSerializationService().XMLToObject(masterEntity.XmlDataDocument_ZADM_M027FLIP, MC.DocumentDataFlipGrid);
                //    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                //    DataGridCollection.Refresh();
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
        private void DeleteDataGridRowMaster(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (MasterEntity[i].active == false)
                {
                    if (MasterEntity.Count > i)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Delete Changes";
                        showMessageService.Text =
                            String.Format(
                                "This record will be Deleted forever {0}",
                                    this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            string request = "Master" + "!@" + MasterEntity[i].id;
                            //repository_MCTemp.Delete(request, "RateMaster", "Administration");
                            MasterEntity.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please deactivate the Record..");
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
        private void DeleteDataGridRowItem(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemEntity[i].active == false)
                {
                    if (ItemEntity.Count > i)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Delete Changes";
                        showMessageService.Text =
                            String.Format(
                                "This record will be Deleted forever {0}",
                                    this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            string request = "Item" + "!@" + ItemEntity[i].id;
                            //repository_MCTemp.Delete(request, "RateMaster", "Administration");
                            ItemEntity.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please deactivate the Record..");
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
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemEntity[dgSelectedIndexItem].HasErrors;
            }
            if (MasterEntity.Count > dgSelectedIndexMaster && dgSelectedIndexMaster >= 0)
            {
                this.ErrorExist = MasterEntity[dgSelectedIndexMaster].HasErrors;
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ItemEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
            if (MasterEntity.Count > dgSelectedIndexMaster && dgSelectedIndexMaster >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        // item Collection changed
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ZADM_M027_A item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ZADM_M027_A item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ZADM_M027_A item in e.NewItems)
                {
                    //Added items
                    item.year = masterEntity.year;
                    item.month = masterEntity.month;
                    item.revised_date = masterEntity.revised_date;
                    item.post_year = masterEntity.post_year;
                    item.post_mon = masterEntity.post_mon;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }
        // master Collection changed
        private void CollectionChangedNotifyForMaster(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ZADM_M027 item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ZADM_M027 item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ZADM_M027 item in e.NewItems)
                {
                    //Added items
                    item.year = masterEntity.year;
                    item.month = masterEntity.month;
                    item.revised_date = masterEntity.revised_date;
                    item.post_year = masterEntity.post_year;
                    item.post_mon = masterEntity.post_mon;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }

        #endregion

        #region Abstarct Functions
        protected override void OnSaveAction(InquiryActionResult<ZADM_M027> result)
        {
            try
            {
                if (Validation() == true)
                {
                    masterEntity.XmlDataDocument_ZADM_M027 = obj.ObjectToXML(MasterEntity);
                    masterEntity.XmlDataDocument_ZADM_M027_A = obj.ObjectToXML(ItemEntity);

                    this.masterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        masterEntity = repository.SaveWithReturnDomainObject<ZADM_M027>(masterEntity, "RateMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        masterEntity = repository.UpdateWithReturnDomainObject<ZADM_M027>(masterEntity, "RateMaster", "Administration");
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

        protected override void OnCreateAction(InquiryActionResult<ZADM_M027> result)
        {
            isNewRecord = true;
            MasterEntity = new ObservableCollection<ZADM_M027>();
            ItemEntity = new ObservableCollection<ZADM_M027_A>();
            masterEntity = new ZADM_M027();
            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<ZADM_M027> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<ZADM_M027> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ZADM_M027> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M027> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M027> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M027> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M027> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M027> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M027> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ZADM_M027> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M027> result)
        {

        }
        #endregion

        #region Filters

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
            var data = obj as ZADM_M027Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.month != null && data.month.ToString().ToLower().Contains(_filterString.ToLower())) ||
                            (data.id.ToString() != null && data.id.ToString().Contains(_filterString)) ||
                           (data.year != null && data.year.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        //Filter For WireSize
        private string _filterStringWireSize;
        public string FilterStringWireSize
        {
            get { return _filterStringWireSize; }
            set
            {
                _filterStringWireSize = value;
                RaisePropertyChanged("FilterStringWireSize");
                FilterCollectionWireSize();
            }
        }
        private void FilterCollectionWireSize()
        {
            if (_wireSizeCollection != null)
            {
                _wireSizeCollection.Refresh();
            }
        }
        public bool WireSizeFilter(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireSize))
                {
                    return ((data.wire_size.ToString() != null) && data.wire_size.ToString().Contains(_filterStringWireSize));
                }
                return true;
            }
            return false;
        }

        // Filter For WireType
        private string _filterStringWireType;
        public string FilterStringWireType
        {
            get { return _filterStringWireType; }
            set
            {
                _filterStringWireType = value;
                RaisePropertyChanged("FilterStringWireType");
                FilterCollectionWireType();
            }
        }
        private void FilterCollectionWireType()
        {
            if (_wireTypeCollection != null)
            {
                _wireTypeCollection.Refresh();
            }
        }
        public bool WireTypeFilter(object obj)
        {
            var data = obj as ZADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireType))
                {
                    return ((data.wire_type != null) && data.wire_type.ToLower().Contains(_filterStringWireType.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter For Ball Type
        private string _filterStringBallType;
        public string FilterStringBallType
        {
            get { return _filterStringBallType; }
            set
            {
                _filterStringBallType = value;
                RaisePropertyChanged("FilterStringBallType");
                FilterCollectionBallType();
            }
        }
        private void FilterCollectionBallType()
        {
            if (_ballTypeCollection != null)
            {
                _ballTypeCollection.Refresh();
            }
        }
        public bool BallTypeFilter(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallType))
                {
                    return ((data.ball_type != null) && data.ball_type.ToLower().Contains(_filterStringBallType.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter For Tip Len
        private string _filterStringTotalLen;
        public string FilterStringTotalLen
        {
            get { return _filterStringTotalLen; }
            set
            {
                _filterStringTotalLen = value;
                RaisePropertyChanged("FilterStringTotalLen");
                FilterCollectionTotalLen();
            }
        }
        private void FilterCollectionTotalLen()
        {
            if (_totalLenCollection != null)
            {
                _totalLenCollection.Refresh();
            }
        }
        public bool TipLenFilter(object obj)
        {
            var data = obj as ZADM_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTotalLen))
                {
                    return ((data.total_len != null) && data.total_len.ToLower().Contains(_filterStringTotalLen.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter For Unit
        private string _filterStringUOM;

        private void FilterCollectionUOM()
        {
            if (_unitListCollection != null)
            {
                _unitListCollection.Refresh();
            }
        }
        public string FilterStringUOM
        {
            get { return _filterStringUOM; }
            set
            {
                _filterStringUOM = value;
                RaisePropertyChanged("FilterStringUOM");
                FilterCollectionUOM();
            }
        }
        public bool UnitFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUOM))
                {
                    return ((data.unit_code != null) && data.unit_code.ToLower().Contains(_filterStringUOM.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filters For date
        private string _filterStringDate;
        public string FilterStringDate
        {
            get { return _filterStringDate; }
            set
            {
                _filterStringDate = value;
                RaisePropertyChanged("FilterStringDate");
                FilterCollectionDate();
            }
        }
        private void FilterCollectionDate()
        {
            if (_dateCollection != null)
            {
                _dateCollection.Refresh();
            }
        }
        public bool DateFilter(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDate))
                {
                    return (data.short_desc != null && data.short_desc.ToLower().Contains(_filterStringDate.ToLower()))
                           || (data.calender_year.ToString() != null && data.calender_year.ToString().Contains(_filterStringDate));
                }
                return true;
            }
            return false;
        }

        

        #endregion
    }
}
