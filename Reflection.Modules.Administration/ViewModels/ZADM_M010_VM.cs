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
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ZADM_M010_VM : WorkspaceViewModel<ZADM_M010>
    {
        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ZADM_M010_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
       
        private AutoSuggestTextViewModel<dynamic> _ASUnitCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnitCode
        {
            get { return _ASUnitCode; }
            set
            {
                if (_ASUnitCode != value)
                {
                    _ASUnitCode = value; RaisePropertyChanged("ASUnitCode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_TestType { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TestType
        {
            get { return _AS_TestType; }
            set
            {
                if (_AS_TestType != value)
                {
                    _AS_TestType = value; RaisePropertyChanged("AS_TestType");
                }
            }
        }
        #endregion

        #region . Declaration .
        bool isNewRecord = true;

        WebServiceRepository<ZADM_M010> repository = new WebServiceRepository<ZADM_M010>();
        WebServiceRepository<MultipleContext_ZADM_M010> repository_MC = new WebServiceRepository<MultipleContext_ZADM_M010>();
        WebServiceRepository<MultipleContext_ZADM_M010> repository_MCTemp = new WebServiceRepository<MultipleContext_ZADM_M010>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ZADM_M010 _MC = new MultipleContext_ZADM_M010();
        public MultipleContext_ZADM_M010 MC
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

        private MultipleContext_ZADM_M010 _MCTemp = new MultipleContext_ZADM_M010();
        public MultipleContext_ZADM_M010 MCTemp
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

        private ZADM_M010 _MasterEntity;
        public ZADM_M010 MasterEntity
        {
            get { return _MasterEntity; }
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

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
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

        #region . StringList .
        private List<ZADM_M010_Flip> _FlipGridData;
        public List<ZADM_M010_Flip> FlipGridData
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

        private List<string> _StringListBackFlipData;
        public List<string> StringListBackFlipData
        {
            get { return _StringListBackFlipData; }
            set
            {
                if (_StringListBackFlipData != value)
                {
                    _StringListBackFlipData = value;
                }
            }
        }

        private List<string> _StringListModel;
        public List<string> StringListModel
        {
            get { return _StringListModel; }
            set
            {
                if (_StringListModel != value)
                {
                    _StringListModel = value;
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

        List<string> _StringListBallDia;
        public List<string> StringListBallDia
        {
            get { return _StringListBallDia; }
            set
            {
                if (_StringListBallDia != value)
                {
                    _StringListBallDia = value;
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

        List<string> _StringListTipLength;
        public List<string> StringListTipLength
        {
            get { return _StringListTipLength; }
            set
            {
                if (_StringListTipLength != value)
                {
                    _StringListTipLength = value;
                }
            }
        }

        private List<string> _StringListInk;
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

        private List<string> _StringListILD;
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

        #endregion

        #region . ICollection .
        private ICollectionView _BackFlipCollection;
        public ICollectionView BackFlipCollection
        {
            get { return _BackFlipCollection; }
            set { _BackFlipCollection = value; RaisePropertyChanged("BackFlipCollection"); }
        }

        private ICollectionView _ModelCollection;
        public ICollectionView ModelCollection
        {
            get { return _ModelCollection; }
            set { _ModelCollection = value; RaisePropertyChanged("ModelCollection"); }
        }

        private ICollectionView _WireTypeCollection;
        public ICollectionView WireTypeCollection
        {
            get { return _WireTypeCollection; }
            set
            {
                _WireTypeCollection = value;
                RaisePropertyChanged("WireTypeCollection");
            }
        }

        private ICollectionView _WireSizeCollection;
        public ICollectionView WireSizeCollection
        {
            get { return _WireSizeCollection; }
            set
            {
                _WireSizeCollection = value;
                RaisePropertyChanged("WireSizeCollection");
            }
        }

        private ICollectionView _BallDiaCollection;
        public ICollectionView BallDiaCollection
        {
            get { return _BallDiaCollection; }
            set
            {
                _BallDiaCollection = value;
                RaisePropertyChanged("BallDiaCollection");
            }
        }

        private ICollectionView _BallTypeCollection;
        public ICollectionView BallTypeCollection
        {
            get { return _BallTypeCollection; }
            set
            {
                _BallTypeCollection = value;
                RaisePropertyChanged("BallTypeCollection");
            }
        }

        private ICollectionView _TipLengthCollection;
        public ICollectionView TipLengthCollection
        {
            get { return _TipLengthCollection; }
            set { _TipLengthCollection = value; RaisePropertyChanged("TipLengthCollection");  }
        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set
            {
                _InkCollection = value;
                RaisePropertyChanged("InkCollection");
            }
        }

        private ICollectionView _ILDCollection;
        public ICollectionView ILDCollection
        {
            get { return _ILDCollection; }
            set
            {
                _ILDCollection = value;
                RaisePropertyChanged("ILDCollection");
            }
        }
        #endregion

        #region . Relay Command Declaration .

        public RelayCommand<object> cmdInsertModel { get; private set; }
        public RelayCommand<object> cmdInsertWireType { get; private set; }
        public RelayCommand<object> cmdInsertWireSize { get; private set; }
        public RelayCommand<object> cmdInsertBallDia { get; private set; }
        public RelayCommand<object> cmdInsertBallType { get; private set; }
        public RelayCommand<object> cmdInsertTipLength { get; private set; }
        public RelayCommand<object> cmdInsertInk { get; private set; }
        public RelayCommand<object> cmdInsertILD { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdCreateProdNm { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddTestType { get; private set; }
        #endregion

        #region . Constructor .
        public ZADM_M010_VM() : base()
        {
            MasterEntity = new ZADM_M010();
            FlipGridData = new List<ZADM_M010_Flip>();

            #region . Relay Command Initialisation .
            cmdInsertModel = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertModel(cmdPara); });
            cmdInsertWireType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireType(cmdPara); });
            cmdInsertWireSize = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireSize(cmdPara); });
            cmdInsertBallDia = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallDia(cmdPara); });
            cmdInsertBallType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallType(cmdPara); });
            cmdInsertTipLength = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTipLength(cmdPara); });
            cmdInsertInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });         
            cmdInsertILD = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdAddTestType = new RelayCommand<object>(items => { if (items == null) { return; } InsertTestType(items); });
            cmdCreateProdNm = new GalaSoft.MvvmLight.Command.RelayCommand(() => { CreateProdNm();});
            MoveFlag = true;
            LoadInitialData();
            #endregion
        }
        #endregion
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData";// + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZADM_M010>(MC, Request, "FinishGoodMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.BackflipData.ToList();
                BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackFlipCollection.Filter = new Predicate<object>(Filter_BackFlip);

                //Unit Code
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix) || ((ADM_M038_B_P)o).unit_name.ToLower().Contains(prefix);
                ASUnitCode = new AutoSuggestTextViewModel<dynamic>(MC.UnitCodeList, TheFilter, SuggestedValue, "unit_code", true);
                ASUnitCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T003_C_P)x).test_code);
                TheFilter = (o, prefix) => (((ECRM_T003_C_P)o).test_code ?? "").ToLower().Contains(prefix.ToLower()) || (((ECRM_T003_C_P)o).test_desc ?? "").ToLower().Contains(prefix.ToLower());
                AS_TestType = new AutoSuggestTextViewModel<dynamic>(MC.TestType, TheFilter, SuggestedValue, "test_code", true);
                AS_TestType.AutoSuggestVM.IsEmptyValueAllowed = true;

                ModelCollection = CollectionViewSource.GetDefaultView(MC.ModelList);
                ModelCollection.Filter = new Predicate<object>(Filter_Model);
                StringListModel = MC.ModelList.Select(x => x.model_id.ToString()).ToList();

                WireTypeCollection = CollectionViewSource.GetDefaultView(MC.WireTypeList);
                WireTypeCollection.Filter = new Predicate<object>(Filter_WireTypeCollection);
                StringListWireType = MC.WireTypeList.Select(x => x.wire_type).ToList();

                WireSizeCollection = CollectionViewSource.GetDefaultView(MC.WireSizeList);
                WireSizeCollection.Filter = new Predicate<object>(Filter_WireSize);
                StringListWireSize = MC.WireSizeList.Select(x => x.wire_size_id.ToString()).ToList();

                BallDiaCollection = CollectionViewSource.GetDefaultView(MC.BallDiameterList);
                BallDiaCollection.Filter = new Predicate<object>(Filter_BallDia);
                StringListBallDia = MC.BallDiameterList.Select(x => x.ball_dia_id.ToString()).ToList();

                BallTypeCollection = CollectionViewSource.GetDefaultView(MC.BallTypeList);
                BallTypeCollection.Filter = new Predicate<object>(Filter_BallType);
                StringListBallType = MC.BallTypeList.Select(x => x.ball_type).ToList();

                TipLengthCollection = CollectionViewSource.GetDefaultView(MC.TipLengthList);
                TipLengthCollection.Filter = new Predicate<object>(Filter_TipType);
                StringListTipLength = MC.TipLengthList.Select(x => x.total_len).ToList();

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);
                StringListInk = MC.InkList.Select(x => x.ink).ToList();

                ILDCollection = CollectionViewSource.GetDefaultView(MC.IldList);
                ILDCollection.Filter = new Predicate<object>(Filter_ILD);
                StringListILD = MC.IldList.Select(x => x.ild).ToList();

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
        private void DefaultValues()
        {          
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.location_Id;
            
        }

        #region . User Defined Function .

        private void InsertModel(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M009_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ModelList.Where(x => x.modelno.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M009_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList()[0];
                    }
                 
                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.model_id = POPUPEntityObject.model_id;
                    MasterEntity.modelno = POPUPEntityObject.modelno;

                    MasterEntity.prodnm = MasterEntity.modelno + "/" + MasterEntity.wire_type + "/" + MasterEntity.ball_dia + "/" + MasterEntity.ball_type + "/" + MasterEntity.tip_type;
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
        private void InsertWireType(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireTypeList.Where(x => x.wire_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.wire_type_id = POPUPEntityObject.wire_type_id;
                    MasterEntity.wire_type = POPUPEntityObject.wire_type;

                    MasterEntity.prodnm = MasterEntity.modelno + "/" + MasterEntity.wire_type + "/" + MasterEntity.ball_dia + "/" + MasterEntity.ball_type + "/" + MasterEntity.tip_type;
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
        private void InsertWireSize(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireSizeList.Where(x => x.wire_size_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.wire_size_id = POPUPEntityObject.wire_size_id;
                    MasterEntity.wire_size = POPUPEntityObject.wire_size;

                    MasterEntity.prodnm = MasterEntity.modelno + "/" + MasterEntity.wire_type + "/" + MasterEntity.ball_dia + "/" + MasterEntity.ball_type + "/" + MasterEntity.tip_type;
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
        private void InsertBallDia(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallDiameterList.Where(x => x.Ball_dia.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ball_dia_id = POPUPEntityObject.ball_dia_id;
                    MasterEntity.ball_dia = POPUPEntityObject.Ball_dia;

                    MasterEntity.prodnm = MasterEntity.modelno + "/" + MasterEntity.wire_type + "/" + MasterEntity.ball_dia + "/" + MasterEntity.ball_type + "/" + MasterEntity.tip_type;
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
        private void InsertBallType(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallTypeList.Where(x => x.ball_type.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M002_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ball_type_id = POPUPEntityObject.ball_type_id;
                    MasterEntity.ball_type = POPUPEntityObject.ball_type;

                    MasterEntity.prodnm = MasterEntity.modelno + "/" + MasterEntity.wire_type + "/" + MasterEntity.ball_dia + "/" + MasterEntity.ball_type + "/" + MasterEntity.tip_type;
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
        private void InsertTipLength(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M008_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TipLengthList.Where(x => x.total_len.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M008_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M008_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.tot_len_id = POPUPEntityObject.tot_len_id;
                    MasterEntity.total_len = POPUPEntityObject.total_len;
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
        private void InsertInk(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                #region Command Parameter Read Section
               
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.InkList.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                        }
                      
                    }
               

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ink_id = POPUPEntityObject.ink_id;
                    MasterEntity.ink = POPUPEntityObject.ink;                   
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
        private void InsertIld(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.IldList.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                    }
                  
                }


                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ild_id = POPUPEntityObject.ild_id;
                    MasterEntity.ild = POPUPEntityObject.ild;
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
        private void CreateProdNm()
        {
            try
            {  
                  MasterEntity.prodnm = MasterEntity.modelno + "/" + MasterEntity.wire_type + "/" + MasterEntity.ball_dia + "/" + MasterEntity.ball_type + "/" + MasterEntity.tip_type;                
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
              ZADM_M010_Flip   ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ZADM_M010_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZADM_M010_Flip>().ToList()[0];
                        isNewRecord = false;

                        string Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.ItemCode;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M010>(MC, Request, "FinishGoodMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");


                        MasterEntity = MCTemp.MasterEntity[0];
                        SelectedTabControlIndex = 0;
                        MoveFlag = false;

                        AttachmentCollection = MC.AttachmentList;

                        if (MC.AttachmentList != null)
                        {
                            AttachmentCollection = MC.AttachmentList;
                        }
                        else
                        {
                            MC.AttachmentList = new List<COM_T003>();
                        }
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
        private void InsertTestType(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
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
        #endregion

        protected override void OnCreateAction(InquiryActionResult<ZADM_M010> result)
        {
            isNewRecord = true;
            MasterEntity = new ZADM_M010();
            DefaultValues();
            MoveFlag = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M010> result)
        {
           
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M010> result)
        {
           
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M010> result)
        {
           
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M010> result)
        {
           
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M010> result)
        {
           
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M010> result)
        {
           
        }
        protected override void OnSaveAction(InquiryActionResult<ZADM_M010> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ZADM_M010>(MasterEntity, "FinishGoodMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity.editby = AppSessionState.UserID;
                        MasterEntity = repository.UpdateWithReturnDomainObject<ZADM_M010>(MasterEntity, "FinishGoodMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.ItemCode != null || MasterEntity.ItemCode.ToString() == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Can Not Saved Please Try Again");
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                    MoveFlag = false;
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
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackflipData = (List<ZADM_M010_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackflipData);
                FlipGridData.Add(MC.BackflipData[0]);
                BackFlipCollection.Refresh();
                BackFlipCollection.SortDescriptions.Add(new SortDescription("ItemCode", ListSortDirection.Descending));
            }
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.ItemCode.ToString()))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M010> result)
        {
            throw new NotImplementedException();
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.modelno == null || MasterEntity.modelno == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Model");
                    showMessageService.ShowMessage();
                    return false;
                }
               else if (MasterEntity.wire_type == null || MasterEntity.wire_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter wire type");
                    showMessageService.ShowMessage();
                    return false;
                }
               else if (MasterEntity.wire_size == null || MasterEntity.wire_size.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter wire size type");
                    showMessageService.ShowMessage();
                    return false;
                }
               //else if (MasterEntity.ball_dia == null || MasterEntity.ball_dia.ToString() == "")
               // {
               //     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
               //     showMessageService.ButtonSetup = DialogButton.Ok;
               //     showMessageService.Caption = "Message";
               //     showMessageService.Text = String.Format("Please Enter Ball diameter");
               //     showMessageService.ShowMessage();
               //     return false;
               // }
               //else if (MasterEntity.ball_type == null || MasterEntity.ball_type.ToString() == "")
               // {
               //     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
               //     showMessageService.ButtonSetup = DialogButton.Ok;
               //     showMessageService.Caption = "Message";
               //     showMessageService.Text = String.Format("Please Enter Ball type");
               //     showMessageService.ShowMessage();
               //     return false;
               // }
               //else if (MasterEntity.tip_type == null || MasterEntity.tip_type.ToString() == "")
               // {
               //     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
               //     showMessageService.ButtonSetup = DialogButton.Ok;
               //     showMessageService.Caption = "Message";
               //     showMessageService.Text = String.Format("Please Enter Tip Type");
               //     showMessageService.ShowMessage();
               //     return false;
               // }
               else if (MasterEntity.prodnm == null || MasterEntity.prodnm == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Product name");
                    showMessageService.ShowMessage();
                    return false;
                }
               //else if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
               // {
               //     IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
               //     showMessageService.ButtonSetup = DialogButton.Ok;
               //     showMessageService.Caption = "Message";
               //     showMessageService.Text = String.Format("Please Enter ItemCode");
               //     showMessageService.ShowMessage();
               //     return false;
               // }
               

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return true;
        }
       
        #region . Filters .

        #region . BackFlip .
        private string _filterStringBackFlip;
        public string filterStringBackFlip
        {
            get { return _filterStringBackFlip; }
            set
            {
                _filterStringBackFlip = value;
                RaisePropertyChanged("filterStringBackFlip");
                Filter_BackFlip();
            }
        }
        private void Filter_BackFlip()
        {
            if (BackFlipCollection != null)
            {
                BackFlipCollection.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as ZADM_M010_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBackFlip))
                {
                    return (data.model_id != null && data.model_id.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()))   ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()))   ||
                           (data.prodnm != null && data.prodnm.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()))       ||
                           (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.ball_dia != null && data.ball_dia.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()))   ||
                           (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                           (data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Model .
        private string _filterStringModel;
        public string filterStringModel
        {
            get { return _filterStringModel; }
            set
            {
                _filterStringModel = value;
                RaisePropertyChanged("filterStringModel");
                Filter_ModelCollection();
            }
        }
        private void Filter_ModelCollection()
        {
            if (ModelCollection != null)
            {
                ModelCollection.Refresh();
            }
        }
        public bool Filter_Model(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringModel))
                {
                    return (data.model_id.ToString() != null && data.model_id.ToString().ToLower().Contains(_filterStringModel.ToLower())) ||
                           (data.modeldesc != null && data.modeldesc.ToString().ToLower().Contains(_filterStringModel.ToLower())) ||
                           (data.modelno != null && data.modelno.ToString().ToLower().Contains(_filterStringModel.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . WireType .
        private string _filterString_WireTypeCollection;
        public string filterString_WireTypeCollection
        {
            get { return _filterString_WireTypeCollection; }
            set
            {
                _filterString_WireTypeCollection = value;
                RaisePropertyChanged("filterString_WireTypeCollection");
                FilterCollection_WireTypeCollection();
            }
        }
        private void FilterCollection_WireTypeCollection()
        {
            if (WireTypeCollection != null)
            {
                WireTypeCollection.Refresh();
            }
        }
        public bool Filter_WireTypeCollection(object obj)
        {
            var data = obj as ZADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireTypeCollection))
                {
                    return (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterString_WireTypeCollection.ToLower())) ||
                           (data.wire_type_id != null && data.wire_type_id.ToString().ToLower().Contains(_filterString_WireTypeCollection.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .WireSize .
        private string _filterString_WireSize;
        public string filterString_WireSize
        {
            get { return _filterString_WireSize; }
            set
            {
                _filterString_WireSize = value;
                RaisePropertyChanged("filterString_WireSize");
                FilterCollection_WireSize();
            }
        }
        private void FilterCollection_WireSize()
        {
            if (WireSizeCollection != null)
            {
                WireSizeCollection.Refresh();
            }
        }
        public bool Filter_WireSize(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireSize))
                {
                    return (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_filterString_WireSize.ToLower())) ||
                           (data.wire_size_id != null && data.wire_size_id.ToString().ToLower().Contains(_filterString_WireSize.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .BallDia .
        private string _filterString_BallDia;
        public string filterString_BallDia
        {
            get { return _filterString_BallDia; }
            set
            {
                _filterString_BallDia = value;
                RaisePropertyChanged("filterString_BallDia");
                FilterCollection_BallDia();
            }
        }
        private void FilterCollection_BallDia()
        {
            if (BallDiaCollection != null)
            {
                BallDiaCollection.Refresh();
            }
        }
        public bool Filter_BallDia(object obj)
        {
            var data = obj as ZADM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallDia))
                {
                    return (data.Ball_dia != null && data.Ball_dia.ToString().ToLower().Contains(_filterString_BallDia.ToLower())) ||
                           (data.ball_dia_id != null && data.ball_dia_id.ToString().ToLower().Contains(_filterString_BallDia.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .BallType .
        private string _filterString_BallType;
        public string filterString_BallType
        {
            get { return _filterString_BallType; }
            set
            {
                _filterString_BallType = value;
                RaisePropertyChanged("filterString_BallType");
                FilterCollection_BallType();
            }
        }
        private void FilterCollection_BallType()
        {
            if (BallTypeCollection != null)
            {
                BallTypeCollection.Refresh();
            }
        }
        public bool Filter_BallType(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallType))
                {
                    return (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterString_BallType.ToLower())) ||
                           (data.ball_type_id != null && data.ball_type_id.ToString().ToLower().Contains(_filterString_BallType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . TipType .
        private string _filterString_TipLength;
        public string filterString_TipLength
        {
            get { return _filterString_TipLength; }
            set
            {
                _filterString_TipLength = value;
                RaisePropertyChanged("filterString_TipLength");
                FilterCollection_TipLength();
            }
        }
        private void FilterCollection_TipLength()
        {
            if (TipLengthCollection != null)
            {
                TipLengthCollection.Refresh();
            }
        }
        public bool Filter_TipType(object obj)
        {
            var data = obj as ZADM_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_TipLength))
                {
                    return (data.total_len != null && data.total_len.ToString().ToLower().Contains(_filterString_TipLength.ToLower())) ||
                           (data.tot_len_id != null && data.tot_len_id.ToString().ToLower().Contains(_filterString_TipLength.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Ink .
        private string _filterString_Ink;
        public string FilterString_Ink
        {
            get { return _filterString_Ink; }
            set
            {
                _filterString_Ink = value;
                RaisePropertyChanged("FilterString_Ink");
                FilterCollection_Ink();
            }
        }
        private void FilterCollection_Ink()
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
                if (!string.IsNullOrEmpty(_filterString_Ink))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink.ToLower())) ||
                           (data.ink_id != null && data.ink_id.ToString().ToLower().Contains(_filterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ILD .
        private string _filterString_ILD;
        public string FilterString_ILD
        {
            get { return _filterString_ILD; }
            set
            {
                _filterString_ILD = value;
                RaisePropertyChanged("FilterString_ILD");
                FilterCollection_ILD();
            }
        }
        private void FilterCollection_ILD()
        {
            if (_ILDCollection != null)
            {
                _ILDCollection.Refresh();
            }
        }
        public bool Filter_ILD(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ILD))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_ILD.ToLower())) ||
                           (data.ild_id != null && data.ild_id.ToString().ToLower().Contains(_filterString_ILD.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion

        #endregion


    }
}
