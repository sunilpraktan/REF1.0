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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T001_ILD_VM : WorkspaceViewModel<EPR_T001_New>
    {
     
        bool isNewRecord = true;
        WebServiceRepository<EPR_T001_New> repository = new WebServiceRepository<EPR_T001_New>();
        WebServiceRepository<MultipleContext_EPR_T001_Conv> repository_MC = new WebServiceRepository<MultipleContext_EPR_T001_Conv>();
        WebServiceRepository<MultipleContext_EPR_T001_Conv> repository_MCTemp = new WebServiceRepository<MultipleContext_EPR_T001_Conv>();
        
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_EPR_T001_Conv _MC = new MultipleContext_EPR_T001_Conv();
        public MultipleContext_EPR_T001_Conv MC
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

        private MultipleContext_EPR_T001_Conv _MCTemp = new MultipleContext_EPR_T001_Conv();
        public MultipleContext_EPR_T001_Conv MCTemp
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

        private EPR_T001_New _MasterEntity;
        public EPR_T001_New MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private EPR_T001_New _MasterEntityTemp;
        public EPR_T001_New MasterEntityTemp
        {
            get { return _MasterEntityTemp; }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }



        // adding new property

        private List<EPR_T001_New> _SelectedList;
        public List<EPR_T001_New> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }



        private static ObservableCollection<EPR_T001_New> _ItemDetails = new ObservableCollection<EPR_T001_New>();
        public ObservableCollection<EPR_T001_New> ItemDetails
        {
            get { return _ItemDetails; }
            set
            {
                if (_ItemDetails != value)
                {
                    _ItemDetails = value;
                    RaisePropertyChanged("ItemDetails");
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

        List<ZADM_M013_P> _MachineList = new List<ZADM_M013_P>();
        public List<ZADM_M013_P> MachineList
        {
            get { return _MachineList; }
            set
            {
                if (_MachineList != value)
                {
                    _MachineList = value;

                    RaisePropertyChanged("DefectList");
                }
            }
        }
        #endregion

        #region ICollectionView
        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set { _MachineCollection = value; RaisePropertyChanged("MachineCollection"); }
        }

        private ICollectionView _WireMakeCollection;
        public ICollectionView WireMakeCollection
        {
            get { return _WireMakeCollection; }
            set { _WireMakeCollection = value; RaisePropertyChanged("WireMakeCollection"); }
        }

        private ICollectionView _BallMakeCollection;
        public ICollectionView BallMakeCollection
        {
            get { return _BallMakeCollection; }
            set { _BallMakeCollection = value; RaisePropertyChanged("BallMakeCollection"); }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set { _ShiftCollection = value; RaisePropertyChanged("ShiftCollection"); }
        }
        //private ICollectionView _PackingUnitCollection;
        //public ICollectionView PackingUnitCollection
        //{
        //    get { return _PackingUnitCollection; }
        //    set { _PackingUnitCollection = value;RaisePropertyChanged("PackingUnitCollection");}
        //}
        private ICollectionView _PkgUnitCollection;
        public ICollectionView PkgUnitCollection
        {
            get { return _PkgUnitCollection; }
            set{ _PkgUnitCollection = value; RaisePropertyChanged("PkgUnitCollection");}
        }
        #endregion

        #region StringList
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

        List<string> _StringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _StringListWireMake; }
            set
            {
                if (_StringListWireMake != value)
                {
                    _StringListWireMake = value;
                }
            }
        }

        List<string> _StringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _StringListBallMake; }
            set
            {
                if (_StringListBallMake != value)
                {
                    _StringListBallMake = value;
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
        #endregion

        #region Filters
        #region Filters For Machine
        private string _filterStringMachine;
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For WireMake

        private string _filterStringWireMake;
        public string FilterStringWireMake
        {
            get { return _filterStringWireMake; }
            set
            {
                _filterStringWireMake = value;
                RaisePropertyChanged("FilterStringWireMake");
                FilterCollectionWireMake();
            }
        }
        private void FilterCollectionWireMake()
        {
            if (_WireMakeCollection != null)
            {
                _WireMakeCollection.Refresh();
            }
        }
        public bool WireMakeFilter(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireMake))
                {
                    return ((data.Make != null) && data.Make.ToLower().Contains(_filterStringWireMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallMake
        private string _filterStringBallMake;
        private void FilterCollectionBallMake()
        {
            if (_BallMakeCollection != null)
            {
                _BallMakeCollection.Refresh();
            }
        }
        public string FilterStringBallMake
        {
            get { return _filterStringBallMake; }
            set
            {
                _filterStringBallMake = value;
                RaisePropertyChanged("FilterStringBallMake");
                FilterCollectionBallMake();
            }
        }
        public bool BallMakeFilter(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringBallMake))
                {
                    return ((data.Make != null) && data.Make.ToLower().Contains(_filterStringBallMake.ToLower()) ||
                            (data.MakeCode != null) && data.MakeCode.ToString().Contains(_filterStringBallMake.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters for Shift
        private string _filterStringShift;
        private void FilterCollectionShift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public string FilterStringShift
        {
            get { return _filterStringShift; }
            set
            {
                _filterStringShift = value;
                RaisePropertyChanged("FilterStringShift");
                FilterCollectionShift();
            }
        }
        public bool ShiftFilter(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringShift))
                {
                    return ((data.shift != null) && data.shift.ToLower().Contains(_filterStringBallMake.ToLower()) 
                   );
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Pkg Unit

        private string _filterString_PkgUnit;
        public string FilterString_PkgUnit
        {
            get { return _filterString_PkgUnit; }
            set
            {
                _filterString_PkgUnit = value;
                RaisePropertyChanged("FilterString_PkgUnit");
                FilterCollection_PkgUnit();
            }
        }
        private void FilterCollection_PkgUnit()
        {
            if (_PkgUnitCollection != null)
            {
                _PkgUnitCollection.Refresh();
            }
        }
        public bool Filter_PkgUnit(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PkgUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_PkgUnit.ToLower()) ||
                        data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_PkgUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdAddMachine { get; private set; }
        public RelayCommand<object> CmdAddBallMake { get; private set; }
        public RelayCommand<object> CmdAddWireMake { get; private set; }
        public RelayCommand<object> CmdAddShift { get; private set; }
        public RelayCommand LoadCurrentMachine { get; private set; }
        public RelayCommand CmdForCancelMachine { get; private set; }
        public RelayCommand CmdForStopMachine { get; private set; }
        public RelayCommand<object> CommandPkgUnit { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor
        public EPR_T001_ILD_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T001_New();
            MasterEntityTemp = new EPR_T001_New();
         
            MC = new MultipleContext_EPR_T001_Conv();
            MCTemp = new MultipleContext_EPR_T001_Conv();

            
            LoadInitialData();
            ItemDetails = new ObservableCollection<EPR_T001_New>();// 
        }
        public EPR_T001_ILD_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new EPR_T001_New();
            MasterEntityTemp = new EPR_T001_New();

            MC = new MultipleContext_EPR_T001_Conv();
            MCTemp = new MultipleContext_EPR_T001_Conv();


            LoadInitialData();
            ItemDetails = new ObservableCollection<EPR_T001_New>();// 
        }
        private void LoadInitialData()
        {
            try
            {
                
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MC, Request, "ConversionNote2", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdAddMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara, true, true, true); });
                CmdAddBallMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara, true, true, true); });
                CmdAddWireMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara, true, true, true); });
                CmdAddShift = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertShift(cmdPara, true, true, true); });
                LoadCurrentMachine = new RelayCommand(LoadILD);
                CommandPkgUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPkgUOM(cmdPara, false, true, true); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.MachineList.Select(x => x.machinecode.ToString()).ToList();

                WireMakeCollection = CollectionViewSource.GetDefaultView(MC.WireMakeList);
                WireMakeCollection.Filter = new Predicate<object>(WireMakeFilter);
                StringListWireMake = MC.WireMakeList.Select(x => x.Make.ToString()).ToList();
                             
                BallMakeCollection = CollectionViewSource.GetDefaultView(MC.BallMakeList);
                BallMakeCollection.Filter = new Predicate<object>(BallMakeFilter);
                StringListBallMake = MC.BallMakeList.Select(x => x.Make.ToString()).ToList();

                ShiftCollection = CollectionViewSource.GetDefaultView(MC.Shift);
                ShiftCollection.Filter = new Predicate<object>(ShiftFilter);
                StringListShift = MC.BallTypeList.Select(x => x.ball_type.ToString()).ToList();

                //PackingUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);

                PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
                PkgUnitCollection.Filter = new Predicate<object>(Filter_PkgUnit);

                //DefaultValues();

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

        #region Relay Command Implementation
        private void InsertMachine(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M013_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemDetails.Where(x => x.machinecode == POPUPEntityObject.machinecode).FirstOrDefault();
                    var IndexOfExistValue = ItemDetails.IndexOf(ItemDetails.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && ItemDetails.Count > dgSelectedIndex)
                    {
                        if (ItemDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                            
                        }
                        else if (ItemDetails[dgSelectedIndex].machinecode != POPUPEntityObject.machinecode)
                        {
                            ItemDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T001_New newObj = new EPR_T001_New();
                for (int i = ItemDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetails[i].ComparePropertiesTo(newObj);
                    if (ItemDetails[i].ComparePropertiesTo(newObj) == true && ItemDetails.Count > 1)
                    {
                        ItemDetails.RemoveAt(i);
                        if (ItemDetails.Count == 0)
                        {
                            ItemDetails.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertBallMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M032_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemDetails.Where(x => x.ball_make == POPUPEntityObject.Make).FirstOrDefault();
                    var IndexOfExistValue = ItemDetails.IndexOf(ItemDetails.Where(X => X.ball_make == POPUPEntityObject.Make).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && ItemDetails.Count > dgSelectedIndex)
                    {
                        if (ItemDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetails[dgSelectedIndex].ball_make = POPUPEntityObject.Make;
                        }
                        else if (ItemDetails[dgSelectedIndex].ball_make != POPUPEntityObject.Make)
                        {
                            ItemDetails[dgSelectedIndex].ball_make = POPUPEntityObject.Make;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T001_New newObj = new EPR_T001_New();
                for (int i = ItemDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetails[i].ComparePropertiesTo(newObj);
                    if (ItemDetails[i].ComparePropertiesTo(newObj) == true && ItemDetails.Count > 1)
                    {
                        ItemDetails.RemoveAt(i);
                        if (ItemDetails.Count == 0)
                        {
                            ItemDetails.Add(newObj);
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
        private void InsertWireMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemDetails.Where(x => x.machinecode == POPUPEntityObject.machinecode).FirstOrDefault();
                    var IndexOfExistValue = ItemDetails.IndexOf(ItemDetails.Where(X => X.unit_code == POPUPEntityObject.machinecode).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && ItemDetails.Count > dgSelectedIndex)
                    {
                        if (ItemDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                        }
                        else if (ItemDetails[dgSelectedIndex].machinecode != POPUPEntityObject.machinecode)
                        {
                            ItemDetails[dgSelectedIndex].unit_code = POPUPEntityObject.machinecode;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T001_New newObj = new EPR_T001_New();
                for (int i = ItemDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetails[i].ComparePropertiesTo(newObj);
                    if (ItemDetails[i].ComparePropertiesTo(newObj) == true && ItemDetails.Count > 1)
                    {
                        ItemDetails.RemoveAt(i);
                        if (ItemDetails.Count == 0)
                        {
                            ItemDetails.Add(newObj);
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
        private void InsertShift(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemDetails.Where(x => x.machinecode == POPUPEntityObject.machinecode).FirstOrDefault();
                    var IndexOfExistValue = ItemDetails.IndexOf(ItemDetails.Where(X => X.unit_code == POPUPEntityObject.machinecode).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && ItemDetails.Count > dgSelectedIndex)
                    {
                        if (ItemDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                        }
                        else if (ItemDetails[dgSelectedIndex].machinecode != POPUPEntityObject.machinecode)
                        {
                            ItemDetails[dgSelectedIndex].unit_code = POPUPEntityObject.machinecode;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T001_New newObj = new EPR_T001_New();
                for (int i = ItemDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetails[i].ComparePropertiesTo(newObj);
                    if (ItemDetails[i].ComparePropertiesTo(newObj) == true && ItemDetails.Count > 1)
                    {
                        ItemDetails.RemoveAt(i);
                        if (ItemDetails.Count == 0)
                        {
                            ItemDetails.Add(newObj);
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
        private void LoadILD()
        {

            try
            {
                SelectedList = new List<EPR_T001_New>();
                MasterEntity.location_Id = Convert.ToString(AppSessionState.location_Id);
                MasterEntity.start_dt = DateTime.Now.Date;
                string request;
                request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.machine_id + "!@" + MasterEntity.machinecode;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, "MM_T001_A_Data", "ILDChart2", "Production", "Load", 0, request);
                SelectedList = MCTemp.ILDChart2;

                if (SelectedList != null)
                {
                    ItemDetails = new ObservableCollection<EPR_T001_New>(SelectedList);

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
        private void InsertPkgUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M017_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.PkgUnitList.Where(x => x.pkgunit.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M017_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemDetails.Where(x => x.pack_style == POPUPEntityObject.id).FirstOrDefault();
                    var IndexOfExistValue = ItemDetails.IndexOf(ItemDetails.Where(X => X.pack_style == POPUPEntityObject.id).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && ItemDetails.Count > dgSelectedIndex)
                    {
                        if (ItemDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemDetails[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                            ItemDetails[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                            ItemDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemDetails[dgSelectedIndex].id != POPUPEntityObject.id)
                        {
                            ItemDetails[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                            ItemDetails[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                            ItemDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T001_New newObj = new EPR_T001_New();
                for (int i = ItemDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDetails[i].ComparePropertiesTo(newObj);
                    if (ItemDetails[i].ComparePropertiesTo(newObj) == true && ItemDetails.Count > 1)
                    {
                        ItemDetails.RemoveAt(i);
                        if (ItemDetails.Count == 0)
                        {
                            ItemDetails.Add(newObj);
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                  
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

        #region AbstractMethods
        protected override void OnCreateAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {

        }

        protected override void OnSaveAction(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
