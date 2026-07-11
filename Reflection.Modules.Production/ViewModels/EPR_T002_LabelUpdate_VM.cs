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
    class EPR_T002_LabelUpdate_VM : WorkspaceViewModel<EPR_T002>
    {
        #region Variable Declaration
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<List<EPR_T002>> repository = new WebServiceRepository<List<EPR_T002>>();
        WebServiceRepository<MultipleContext_EPR_T002> repositoryM = new WebServiceRepository<MultipleContext_EPR_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_EPR_T002 _MC = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MC
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

        private MultipleContext_EPR_T002 _MCTemp = new MultipleContext_EPR_T002();
        public MultipleContext_EPR_T002 MCTemp
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

        private DateTime? _Date;
        public DateTime? Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    RaisePropertyChanged("Date");
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

        private ObservableCollection<EPR_T002> _MasterEntity;
        //Data source for Items DataGrid
        public ObservableCollection<EPR_T002> MasterEntity
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
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private List<EPR_T002> _TobeSaveEntity = new List<EPR_T002>();
        //Data source for Items DataGrid
        public List<EPR_T002> TobeSaveEntity
        {
            get
            {
                return _TobeSaveEntity;
            }
            set
            {
                if (_TobeSaveEntity != value)
                {
                    _TobeSaveEntity = value;
                    RaisePropertyChanged("TobeSaveEntity");
                }
            }
        }

        private string _ProductionEntry;
        public string ProductionEntry
        {
            get
            {
                return _ProductionEntry;
            }
            set
            {
                if (_ProductionEntry != value)
                {
                    _ProductionEntry = value;
                    RaisePropertyChanged("ProductionEntry");
                }
            }
        }

        private string _machine_id;
        public string machine_id
        {
            get
            {
                return _machine_id;
            }
            set
            {
                if (_machine_id != value)
                {
                    _machine_id = value;
                    RaisePropertyChanged("machine_id");
                }
            }
        }

        private string _machinecode;
        public string machinecode
        {
            get
            {
                return _machinecode;
            }
            set
            {
                if (_machinecode != value)
                {
                    _machinecode = value;
                    RaisePropertyChanged("machinecode");
                }
            }
        }
        #endregion

        #region StringList

        private List<string> _stringListInk;
        public List<string> StringListInk
        {
            get { return _stringListInk; }
            set
            {
                if (_stringListInk != value)
                {
                    _stringListInk = value;
                }
            }
        }

        private List<string> _stringListIld;
        public List<string> StringListIld
        {
            get { return _stringListIld; }
            set
            {
                if (_stringListIld != value)
                {
                    _stringListIld = value;
                }
            }
        }

        private List<string> _stringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _stringListWireMake; }
            set
            {
                if (_stringListWireMake != value)
                {
                    _stringListWireMake = value;
                }
            }
        }

        private List<string> _stringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _stringListBallMake; }
            set
            {
                if (_stringListBallMake != value)
                {
                    _stringListBallMake = value;
                }
            }
        }
        #endregion

        #region ICollections For Popup
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

        private ICollectionView _IldCollection;
        public ICollectionView IldCollection
        {
            get { return _IldCollection; }
            set
            {
                _IldCollection = value;
                RaisePropertyChanged("IldCollection");
            }
        }

        private ICollectionView _CustomerProductCollection;
        public ICollectionView CustomerProductCollection
        {
            get { return _CustomerProductCollection; }
            set
            {
                _CustomerProductCollection = value;
                RaisePropertyChanged("CustomerProductCollection");
            }
        }

        private ICollectionView _BallMakeCollection;
        public ICollectionView BallMakeCollection
        {
            get { return _BallMakeCollection; }
            set
            {
                _BallMakeCollection = value;
                RaisePropertyChanged("BallMakeCollection");
            }
        }

        private ICollectionView _WireMakeCollection;
        public ICollectionView WireMakeCollection
        {
            get { return _WireMakeCollection; }
            set
            {
                _WireMakeCollection = value;
                RaisePropertyChanged("WireMakeCollection");
            }
        }

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }

        #endregion

        #region Relay Commands
        public RelayCommand<object> cmdInsertInk { get; private set; }
        public RelayCommand<object> cmdInsertIld { get; private set; }
        public RelayCommand<IList> cmdMachine { get; private set; }
        public RelayCommand<object> CommandCustomerProduct { get; private set; }
        public RelayCommand<object> CommandBallMake { get; private set; }
        public RelayCommand<object> CommandWireMake { get; private set; }
        public RelayCommand cmdLoadLabelGenMaster { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public EPR_T002_LabelUpdate_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MasterEntity = new ObservableCollection<EPR_T002>();

            Date = DateTime.Now;



            LoadInitialData();
        }
        public EPR_T002_LabelUpdate_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MasterEntity = new ObservableCollection<EPR_T002>();
            Date = DateTime.Now;

            LoadInitialData();
        }
        #endregion

        #region UserDefinedFunctions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialDataForLabelUpdate" + "!@" + AppSessionState.location_Id;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                cmdInsertInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara, false, true, true); });
                cmdInsertIld = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara, false, true, true); });
                cmdMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
                CommandCustomerProduct = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerProduct(cmdPara, false, true, true); });
                CommandBallMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara, false, true, true); });
                CommandWireMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara, false, true, true); });
                cmdLoadLabelGenMaster = new RelayCommand(() => { LoadLabelGenerationMaster(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);
                StringListInk = MC.InkList.Select(x => x.ink).ToList();

                IldCollection = CollectionViewSource.GetDefaultView(MC.IldList);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);
                StringListIld = MC.IldList.Select(x => x.ild).ToList();

                CustomerProductCollection = CollectionViewSource.GetDefaultView(MC.CustomerProductList);
                CustomerProductCollection.Filter = new Predicate<object>(Filter_CustProduct);

                BallMakeCollection = CollectionViewSource.GetDefaultView(MC.BallMakeList);
                BallMakeCollection.Filter = new Predicate<object>(Filter_BallMake);
                StringListBallMake = MC.BallMakeList.Select(x => x.Make).ToList();

                WireMakeCollection = CollectionViewSource.GetDefaultView(MC.WireMakeList);
                WireMakeCollection.Filter = new Predicate<object>(Filter_WireMake);
                StringListWireMake = MC.WireMakeList.Select(x => x.Make).ToList();

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
                MachineCollection.Filter = new Predicate<object>(Filter_Machine);

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
        private void LoadLabelGenerationMaster()
        {
            try
            {
                if (Date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Production Date ", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    bool? prod_entry = null;
                    string doc_type = null;

                    if (ProductionEntry == null || ProductionEntry == "Done and Undone")
                    {
                        ProductionEntry = "Done and Undone";
                        // doc_type = "All";
                    }
                    else
                    {
                        doc_type = "LG";
                        prod_entry = true;
                    }

                    //if (machine_id == null || machine_id == 0)
                    //{
                    //    machine_id = 0;
                    //}

                    //if (machinecode == null || machinecode == "")
                    //{
                    //    machinecode = "All";
                    //}

                    string Request = "LoadLabelGenMaster" + "!@" + Date + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + doc_type + "!@" + prod_entry + "!@" + machine_id + "!@" + machinecode;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                    foreach (var o in MCTemp.LabelGenerationList)
                    {
                        int IndexOfExistRow = MasterEntity.IndexOf(MasterEntity.Where(X => X.doc_no == o.doc_no).FirstOrDefault());

                        if (IndexOfExistRow == -1)
                        {
                            o.editby = AppSessionState.UserID;

                            MasterEntity.Add(o);
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
        private void InsertInk(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.InkList.Where(x => x.ink.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ink_id == POPUPEntityObject.ink_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ink_id == POPUPEntityObject.ink_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].ink_id = POPUPEntityObject.ink_id;
                            MasterEntity[dgSelectedIndex].Ink = POPUPEntityObject.ink;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.ink_id)
                        {
                            MasterEntity[dgSelectedIndex].ink_id = POPUPEntityObject.ink_id;
                            MasterEntity[dgSelectedIndex].Ink = POPUPEntityObject.ink;
                        }
                    }
                }

                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertIld(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.IldList.Where(x => x.ild.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ild_id == POPUPEntityObject.ild_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ild_id == POPUPEntityObject.ild_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].ild_id = POPUPEntityObject.ild_id;
                            MasterEntity[dgSelectedIndex].Ild = POPUPEntityObject.ild;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.ild_id)
                        {
                            MasterEntity[dgSelectedIndex].ild_id = POPUPEntityObject.ild_id;
                            MasterEntity[dgSelectedIndex].Ild = POPUPEntityObject.ild;
                        }
                    }
                }

                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertMachine(IList InputValue)
        {
            string stringmachine_id = "";
            string stringmachinecode = "";
            machinecode = "";
            foreach (ZADM_M013_P temp in MC.MachineList)
            {
                if (temp.Select == true)
                {
                    stringmachine_id = stringmachine_id + "," + temp.machine_id;
                    stringmachinecode = stringmachinecode + "," + temp.machinecode;
                }
            }
            machine_id = stringmachine_id.ToString().TrimStart(new char[] { ',' });
            machinecode = stringmachinecode.ToString().TrimStart(new char[] { ',' });

            //IList list = InputValue as IList;
            //List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

            //if (GetSelectedMachine.Count > 0)
            //{
            //    machine_id = GetSelectedMachine[0].machine_id;
            //    machinecode = GetSelectedMachine[0].machinecode;
            //}
        }
        private void InsertCustomerProduct(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M020_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CustomerProductList.Where(x => x.CustomerProductName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M020_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M020_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.CustomerProductName == POPUPEntityObject.CustomerProductName).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.CustomerProductName == POPUPEntityObject.CustomerProductName).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].CustomerProductName = POPUPEntityObject.CustomerProductName;
                            //scalar name to be mapped
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.id)
                        {
                            MasterEntity[dgSelectedIndex].CustomerProductName = POPUPEntityObject.CustomerProductName;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
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

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void InsertBallMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M032_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].ball_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].BallMake = POPUPEntityObject.Make;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.MakeCode)
                        {
                            MasterEntity[dgSelectedIndex].ball_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].BallMake = POPUPEntityObject.Make;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
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
                ADM_M032_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].wire_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].WireMake = POPUPEntityObject.Make;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.MakeCode)
                        {
                            MasterEntity[dgSelectedIndex].wire_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].WireMake = POPUPEntityObject.Make;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
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

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private bool Validations()
        {
            string Message = "";
            int flag = 0;
            foreach (var o in MasterEntity)
            {
                Message = "Following Fields Are Compulsory For All Checked Rows Please Check Row Index {0}";
                flag = 0;

                if (o.check == true)
                {
                    if (o.ink_id == null || o.ink_id == 0)
                    {
                        Message += "\n =>Ink Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.ild_id == null || o.ild_id == 0)
                    {
                        Message += "\n =>Ild Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.ball_make == null || o.ball_make == 0)
                    {
                        Message += "\n =>Please select Ball Make ";
                        flag = 1;
                    }
                    if (o.wire_make == null || o.wire_make == 0)
                    {
                        Message += "\n =>Please select Wire Make ";
                        flag = 1;
                    }
                    if (o.blank_wt == null || o.blank_wt == 0)
                    {
                        Message += "\n =>Please Enter Avg Blank Weight ";
                        flag = 1;
                    }

                    if (flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation";
                        showMessageService.Text = string.Format(Message, MasterEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
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
                    Request = InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region CommandActions
        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                TobeSaveEntity = new List<EPR_T002>();
                int count = MasterEntity.Count(x => x.check == true);

                if (count > 0)
                {
                    foreach (var o in MasterEntity)  //First Selected Rows Will be Added To New Collection
                    {
                        if (o.check == true)
                        {
                            TobeSaveEntity.Add(o);
                        }
                    }

                    string reader = repository.Update<List<EPR_T002>>(TobeSaveEntity, "LabelUpdate", "Production");

                    int intreader = Convert.ToInt32(reader);

                    if (intreader > 0) // intreader is always greater than 0 if data is saved
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Saved Successfully", this.Title);
                        showMessageService.ShowMessage();

                        foreach (var o in TobeSaveEntity)
                        {
                            for (int i = MasterEntity.Count - 1; i >= 0; i--)
                            {
                                MasterEntity.Remove(o);
                            }
                        }
                    }

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Rows Which You Want to Update", this.Title);
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            isNewRecord = true;

            MasterEntity = new ObservableCollection<EPR_T002>();
            Date = DateTime.Now;
            ProductionEntry = null;
            machine_id = null;
            machinecode = null;

        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters
        #region Ink
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
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Ild
        private string _filterString_Ild;
        public string FilterString_Ild
        {
            get { return _filterString_Ild; }
            set
            {
                _filterString_Ild = value;
                RaisePropertyChanged("FilterString_Ild");
                FilterCollection_Ild();
            }
        }
        private void FilterCollection_Ild()
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
                if (!string.IsNullOrEmpty(_filterString_Ild))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_Ild.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_Ild.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Machine

        private string _filterString_Machine;
        public string FilterString_Machine
        {
            get { return _filterString_Machine; }
            set
            {
                _filterString_Machine = value;
                RaisePropertyChanged("FilterString_Machine");
                FilterCollection_Machine();
            }
        }
        private void FilterCollection_Machine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool Filter_Machine(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Machine))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Customer Production

        private string _filterString_CustProduct;
        public string FilterString_CustProduct
        {
            get { return _filterString_CustProduct; }
            set
            {
                _filterString_CustProduct = value;
                RaisePropertyChanged("FilterString_CustProduct");
                FilterCollection_CustProduct();
            }
        }
        private void FilterCollection_CustProduct()
        {
            if (_CustomerProductCollection != null)
            {
                _CustomerProductCollection.Refresh();
            }
        }
        public bool Filter_CustProduct(object obj)
        {
            var data = obj as ZADM_M020_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_CustProduct))
                {
                    return (data.CustomerProductName != null && data.CustomerProductName.ToString().ToLower().Contains(_filterString_CustProduct.ToLower()) ||
                        data.ProductName != null && data.ProductName.ToString().ToLower().Contains(_filterString_CustProduct.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ball Make

        private string _filterString_BallMake;
        public string FilterString_BallMake
        {
            get { return _filterString_BallMake; }
            set
            {
                _filterString_BallMake = value;
                RaisePropertyChanged("FilterString_BallMake");
                FilterCollection_BallMake();
            }
        }
        private void FilterCollection_BallMake()
        {
            if (_BallMakeCollection != null)
            {
                _BallMakeCollection.Refresh();
            }
        }
        public bool Filter_BallMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallMake))
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_BallMake.ToLower()) ||
                        data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_BallMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Wire Make

        private string _filterString_WireMake;
        public string FilterString_WireMake
        {
            get { return _filterString_WireMake; }
            set
            {
                _filterString_WireMake = value;
                RaisePropertyChanged("FilterString_WireMake");
                FilterCollection_WireMake();
            }
        }
        private void FilterCollection_WireMake()
        {
            if (_WireMakeCollection != null)
            {
                _WireMakeCollection.Refresh();
            }
        }
        public bool Filter_WireMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireMake))
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_WireMake.ToLower()) ||
                        data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_WireMake.ToLower()));
                }
                return true;
            }
            return false;
        }



        #endregion
        #endregion
    }
}
