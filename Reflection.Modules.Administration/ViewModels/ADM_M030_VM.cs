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
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.Collections.Specialized;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M030_VM : WorkspaceViewModel<ADM_M030>
    {
        bool isNewRecord = true;
        WebServiceRepository<ADM_M030> repository = new WebServiceRepository<ADM_M030>();
        WebServiceRepository<MultipleContext_ADM_M030> repository_MC = new WebServiceRepository<MultipleContext_ADM_M030>();
        WebServiceRepository<MultipleContext_ADM_M030> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M030>();
       
        #region ICollections
        
        private ICollectionView _ParamCollection;
        public ICollectionView ParamCollection
        {
            get { return _ParamCollection; }
            set { _ParamCollection = value; RaisePropertyChanged("ParamCollection"); }
        }
        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set { _UnitCollection = value; RaisePropertyChanged("UnitCollection"); }
        }
        #endregion

        #region Relay commands Declaration
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CmdAddUnit{ get; private set; }
        public RelayCommand<object> CmdAddParameter{ get; private set; }
        #endregion

        #region StringLists

        List<string> _StringListParameter;
        public List<string> StringListParameter
        {
            get { return _StringListParameter; }
            set
            {
                if (_StringListParameter != value)
                {
                    _StringListParameter = value;
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

        #region Declaration

        private ObservableCollection<ADM_M030> _dataGridCollection;
        public ObservableCollection<ADM_M030> DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
                DataGridCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMaster);
                RaisePropertyChanged("DataGridCollection");
            }
        }

        private int _dgSelectedIndexMaster;
        public int dgSelectedIndexMaster
        {
            get { return _dgSelectedIndexMaster; }
            set
            {
                if (_dgSelectedIndexMaster != value)
                {
                    _dgSelectedIndexMaster = value;
                    RaisePropertyChanged("dgSelectedIndexMaster");
                }
            }
        }

        private ADM_M030 _MasterEntity;
        public ADM_M030 MasterEntity
        {
            get
            {
                this.ErrorExist = _MasterEntity.HasErrors;
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        MultipleContext_ADM_M030 _MC = new MultipleContext_ADM_M030();
        public MultipleContext_ADM_M030 MC
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

        #endregion

        #region User Defined Functions
        public ADM_M030_VM() : base()
        {                       
            MasterEntity = new ADM_M030();
            DataGridCollection = new ObservableCollection<ADM_M030>();            
            MasterEntity.ValidateAsync().Wait();
            DataGridCollection.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMaster);

            cmdDeleteDataGridRowItem = new RelayCommand<object>( items =>{if (items == null){return;} DeleteDataGridRow(items);});
            CmdAddUnit = new RelayCommand<object>(items =>{if (items == null){ return;} InsertUnit(items, true, true, true);});
            CmdAddParameter = new RelayCommand<object>(items =>{ if (items == null) { return; } InsertParameter(items); });

            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id;            
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M030>(MC, Request, "ParameterValueMaster", "Administration", "LoadInitialData", 0, "");
               
                ParamCollection = CollectionViewSource.GetDefaultView(MC.ParamList);
                ParamCollection.Filter = new Predicate<object>(FilterParam);
                StringListParameter = MC.ParamList.Select(x => x.para_name.ToString()).ToList();

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
                UnitCollection.Filter = new Predicate<object>(FilterUnit);
                StringListUnit = MC.UnitList.Select(x => x.unit_code.ToString()).ToList();

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
        private void InsertUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                
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
                
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DataGridCollection.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DataGridCollection.IndexOf(DataGridCollection.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DataGridCollection.Count == dgSelectedIndexMaster)
                    {
                        DataGridCollection.Add(new ADM_M030()
                        {                                                     
                            unit_code = POPUPEntityObject.unit_code,
                            location_Id = AppSessionState.location_Id, 
                            active = true,                                                  
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                        });
                    }
                    else if (dgSelectedIndexMaster >= 0 && DataGridCollection.Count > dgSelectedIndexMaster) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            DataGridCollection[dgSelectedIndexMaster].unit_code = POPUPEntityObject.unit_code;
                            DataGridCollection[dgSelectedIndexMaster].location_Id = AppSessionState.location_Id;
                            DataGridCollection[dgSelectedIndexMaster].add_by = AppSessionState.UserID;
                            DataGridCollection[dgSelectedIndexMaster].editby = AppSessionState.UserID;
                            DataGridCollection[dgSelectedIndexMaster].active = true;
                        }
                        else if (DataGridCollection[dgSelectedIndexMaster].unit_code != POPUPEntityObject.unit_code)
                        {
                            DataGridCollection[dgSelectedIndexMaster].unit_code = POPUPEntityObject.unit_code;
                            DataGridCollection[dgSelectedIndexMaster].location_Id = AppSessionState.location_Id;
                            DataGridCollection[dgSelectedIndexMaster].add_by = AppSessionState.UserID;
                            DataGridCollection[dgSelectedIndexMaster].editby = AppSessionState.UserID;
                            DataGridCollection[dgSelectedIndexMaster].active = true;
                        }
                    }
                    
                }
                #region Clear Empty Row
                ADM_M030 newObj = new ADM_M030();
                for (int i = DataGridCollection.Count - 1; i >= 0; i--)
                {
                    bool xx = DataGridCollection[i].ComparePropertiesTo(newObj);
                    if (DataGridCollection[i].ComparePropertiesTo(newObj) == true && DataGridCollection.Count > 1)
                    {
                        DataGridCollection.RemoveAt(i);
                        if (DataGridCollection.Count == 0)
                        {
                            DataGridCollection.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertParameter(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M031_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ParamList.Where(x => x.para_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M031_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M031_P>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.para_code = POPUPEntityObject.para_code;
                    MasterEntity.para_name = POPUPEntityObject.para_name;

                    var ParameterList = (from o in MC.ParameterValue
                                         where o.para_code == MasterEntity.para_code
                                         select o).ToList();

                    DataGridCollection = new ObservableCollection<ADM_M030>(ParameterList);

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
        private void DeleteDataGridRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DataGridCollection.Count > i)
                {
                    DataGridCollection.RemoveAt(i);
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

        private void CollectionChangedNotifyForMaster(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ADM_M030 item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ADM_M030 item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ADM_M030 item in e.NewItems)
                {
                    //Added items
                    item.para_code = MasterEntity.para_code;
                    item.para_name = MasterEntity.para_name;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (DataGridCollection.Count > dgSelectedIndexMaster && dgSelectedIndexMaster >= 0)
            {
                this.ErrorExist = false; 
            }            
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (DataGridCollection.Count > dgSelectedIndexMaster && dgSelectedIndexMaster >= 0)
            {
                this.ErrorExist = DataGridCollection[dgSelectedIndexMaster].HasErrors;
            }            
        }

        #endregion

        #region Abstract Command Actions
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {               
                if (MasterEntity.XmlDataDocument_ADM_M030 != null)
                {
                    MC.ParameterValue = (List<ADM_M030>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M030, MC.ParameterValue);                                                      
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M030> result)
        {
            try
            {
                DefaultValues();
                ObjectSerializationService obj = new ObjectSerializationService();
                MasterEntity.XmlDataDocument_ADM_M030 = obj.ObjectToXML(DataGridCollection);
                string para_code = MasterEntity.para_code;
                string para_name = MasterEntity.para_name;
                this.MasterEntity.EndEdit();
                if (isNewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<ADM_M030>(MasterEntity, "ParameterValueMaster", "Administration");                   
                }
                else if (isNewRecord == false)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<ADM_M030>(MasterEntity, "ParameterValueMaster", "Administration");
                }

                SetBusinessEntitiesAfterLoad("Save", "");
                DataGridCollection = new ObservableCollection<ADM_M030>();
                var ParameterList = (from o in MC.ParameterValue
                                     where o.para_code == para_code
                                     select o).ToList();

                DataGridCollection = new ObservableCollection<ADM_M030>(ParameterList);
                MasterEntity.para_name = para_name;
                MasterEntity.para_code = para_code;

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
        private void DefaultValues()
        {
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.location_Id;
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M030> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M030();
            DataGridCollection = new ObservableCollection<ADM_M030>();
            MasterEntity.ValidateAsync().Wait();            
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M030> result)
        {
            try
            {
                if (MasterEntity.value_code != null)
                {
                    this.MasterEntity.CancelEdit();
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Save Changes";
                    showMessageService.Text = String.Format("This record will delete forever",this.Title);
                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        string response = repository.Delete(MasterEntity.value_code, "ParameterValueMaster", "Administration");                                               
                        MasterEntity = new ADM_M030();
                        isNewRecord = true;
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M030> result)
        {
            this.MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M030> result)
        {
            
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M030> result)
        {
            
            MasterEntity = MasterEntity;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M030> result)
        {
            MasterEntity = MasterEntity;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M030> result)
        {
            MasterEntity = MasterEntity;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Filters For Param

        private string _filterStringParam;      
        public string FilterStringParam
        {
            get { return _filterStringParam; }
            set
            {
                _filterStringParam = value;
                RaisePropertyChanged("FilterStringParam");
                FilterCollectionParam();
            }
        }
        private void FilterCollectionParam()
        {
            if (_ParamCollection != null)
            {
                _ParamCollection.Refresh();
            }
        }
        public bool FilterParam(object obj)
        {
            var data = obj as ADM_M031_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParam))
                {
                    return (data.para_code != null && data.para_code.ToString().ToLower().Contains(_filterStringParam.ToLower())) ||
                           (data.para_name != null && data.para_name.ToString().ToLower().Contains(_filterStringParam.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter for unit

        private string _filterStringUnit;
        public string FilterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("FilterStringUnit");
                FilterCollectionUnit();
            }
        }
        private void FilterCollectionUnit()
        {
            if (_UnitCollection != null)
            {
                _UnitCollection.Refresh();
            }
        }
        public bool FilterUnit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion

        #endregion


    }

}
