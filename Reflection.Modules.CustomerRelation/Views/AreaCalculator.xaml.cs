using System;
using System.Linq;
using Reflection.Presentation.Windows.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using Reflection.Presentation.Services;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.Generic;
using Reflection.WebServices.Gateway;
using GalaSoft.MvvmLight.Command;
using System.Windows.Data;
using System.Collections;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.CustomerRelation;
using System.Windows;
using Reflection.ReportingServices;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using GalaSoft.MvvmLight.Ioc;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for AreaCalculator.xaml
    /// </summary>
    public partial class AreaCalculator : WindowElement, INotifyPropertyChanged
    {

        #region Variable Declaration


      
        bool isNewRecord = true;

        WebServiceRepository<ZADM_M025> repository = new WebServiceRepository<ZADM_M025>();
        WebServiceRepository<MultipleContext_ZADM_M025> repository_MC = new WebServiceRepository<MultipleContext_ZADM_M025>();
        WebServiceRepository<MultipleContext_ZADM_M025> repository_MCTemp = new WebServiceRepository<MultipleContext_ZADM_M025>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ZADM_M025 _MC = new MultipleContext_ZADM_M025();
        public MultipleContext_ZADM_M025 MC
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

        private MultipleContext_ZADM_M025 _MCTemp = new MultipleContext_ZADM_M025();
        public MultipleContext_ZADM_M025 MCTemp
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
        private List<ZADM_M025_Flip> _FlipGridData;
        // Flip DataGrid Data Source
        public List<ZADM_M025_Flip> FlipGridData
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



        private ObservableCollection<ZADM_M025_A> _AreaEntity;
        public ObservableCollection<ZADM_M025_A> AreaEntity
        {
            get
            {
                return _AreaEntity;
            }
            set
            {
                if (_AreaEntity != value)
                {
                    _AreaEntity = value;
                    AreaEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForarea);
                    RaisePropertyChanged("AreaEntity");
                }
            }
        }


        private ZADM_M025 _MasterEntity;
        public ZADM_M025 MasterEntity
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
        private ZADM_M025_Flip _BackFlipEntity;
        public ZADM_M025_Flip BackFlipEntity
        {
            get
            {
                return _BackFlipEntity;
            }
            set
            {
                if (_BackFlipEntity != value)
                {
                    _BackFlipEntity = value;
                    RaisePropertyChanged(nameof(BackFlipEntity));
                   
                }
            }
        }



        private int _dgSelectedIndexarea;
        public int dgSelectedIndexarea
        {
            get
            {
                return _dgSelectedIndexarea;
            }
            set
            {
                if (_dgSelectedIndexarea != value)
                {
                    _dgSelectedIndexarea = value;
                    RaisePropertyChanged("dgSelectedIndexarea");
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

        private List<ADM_M001_A_P> _SalesOrganisationList;
        public List<ADM_M001_A_P> SalesOrganisationList
        {
            get
            {
                return _SalesOrganisationList;
            }
            set
            {
                _SalesOrganisationList = value;
                RaisePropertyChanged("SalesOrganisationList");
            }
        }

        private List<ADM_M001_H_P> _SalesGroupList;
        public List<ADM_M001_H_P> SalesGroupList
        {
            get
            {
                return _SalesGroupList;
            }
            set
            {
                _SalesGroupList = value;
                RaisePropertyChanged("SalesGroupList");
            }
        }

        //Flip Grid Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        //ItemListForPopup
        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }

        //Location Collection

        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }

        private ICollectionView _sales_orgCollection;
        public ICollectionView Salse_OrgCollection
        {
            get { return _sales_orgCollection; }
            set
            {
                _sales_orgCollection = value;
                RaisePropertyChanged("Salse_OrgCollection");
            }
        }

        private ICollectionView _salse_GroupCollection;
        public ICollectionView Salse_GroupCollection
        {
            get { return _salse_GroupCollection; }
            set
            {
                _salse_GroupCollection = value;
                RaisePropertyChanged("Salse_GroupCollection");
            }
        }

        //string List Declaration
        private List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }
        //string list location

        private List<string> _stringListLocation;
        public List<string> StringListLocation
        {
            get { return _stringListLocation; }
            set
            {
                if (_stringListLocation != value)
                {
                    _stringListLocation = value;
                }
            }
        }

        private List<string> _strListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _strListSalesOrg; }
            set
            {
                if (_strListSalesOrg != value)
                {
                    _strListSalesOrg = value;
                }
            }
        }

        private List<string> _strListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _strListSalesGroup; }
            set
            {
                if (_strListSalesGroup != value)
                {
                    _strListSalesGroup = value;
                }
            }
        }
        #endregion Variable Declaration
        #region Relay Command
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdLocation { get; private set; }
        public RelayCommand<object> cmdItem { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }

        #endregion End Relay Command

        public AreaCalculator(string ts_code)
        {
            InitializeComponent();
            ZADM_M025_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Area);
            AreaEntity = new ObservableCollection<ZADM_M025_A>();
            MC.AreaEntity = new ObservableCollection<ZADM_M025_A>();
            MasterEntity = new ZADM_M025();
            MC = new MultipleContext_ZADM_M025();
            MCTemp = new MultipleContext_ZADM_M025();
            obj = new ObjectSerializationService();
            BackFlipEntity = new ZADM_M025_Flip();
            FlipGridData = new List<ZADM_M025_Flip>();
            if (AreaEntity.Count == 0)
            {
                AreaEntity.Add(new ZADM_M025_A()
                {
                    panna = 51,
                    unit_code = "Sq.Feet",
                    extraheight = 4

                });
            }
            LoadInitialData();

            cmdDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDatagridRow(items); });
            CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items); });
            cmdItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
            cmdLocation=new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });
            CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
            CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });

        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {

            if (MasterEntity.XmlDataDocumentZADM_M025_A != null)
            {

                AreaEntity = (ObservableCollection<ZADM_M025_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocumentZADM_M025_A, MC.AreaEntity);

            }
            else
            {
                MC.AreaEntity = new ObservableCollection<ZADM_M025_A>();
            }

           if (MasterEntity.BackFlipEntity != null)
            {
                MC.BackFlipEntity = (List<ZADM_M025_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.BackFlipEntity, MC.BackFlipEntity);
                FlipGridData.Add(MC.BackFlipEntity[0]);
              
                _FlipDataGridCollection.Refresh();

            }

 }
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "AC";
            MasterEntity.doc_type = "AC";
            if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
            {
                MasterEntity.location_Id = AppSessionState.location_Id;
            }
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.doc_date = System.DateTime.Now;
           
      }
         private void LoadInitialData()
         {
            try
            {
                MasterEntity.doc_cat = "AC";
                MasterEntity.doc_type = "AC";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat+"!@"+AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZADM_M025>(MC, Request, "AreaCalculation", "CRM", "LoadAll", 0, "");
              
                FlipGridData = MC.BackFlipEntity.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                LocationCollection = CollectionViewSource.GetDefaultView(MC.LocationMaster);
                LocationCollection.Filter=new Predicate<object>(Filter_Location);
                StringListLocation = MC.LocationMaster.Select(x=>x.LoctnNm).ToList();


                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        MasterEntity.so_code = SalesOrganisationList[0].so_code;
                        MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        MasterEntity.sg_code = SalesGroupList[0].sg_code;
                        MasterEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    MasterEntity.sg_code = "";
                }


                DefaultValues();


            }
            catch (Exception ex)
            {

            }

        }
        private void LoadDocumentByDocumentNumber(object ParameterObject)
        {
            try
            {
                string RequestParameterData = "";
                string Request = "";
                string ParametersStringValue = "";
                ZADM_M025_Flip ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ZADM_M025_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZADM_M025_Flip>().ToList()[0];
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                      
                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M025>(MCTemp, Request, "AreaCalculation", "CRM", "LoadDocumentWithDocumentNumber", 0, "");

                if (MCTemp.AreaEntity != null)
                {
                   AreaEntity.Clear();
                   
                    AreaEntity= MCTemp.AreaEntity;
                }
                else
                {
                    MCTemp.AreaEntity = new ObservableCollection<ZADM_M025_A>();
                }
                if (MCTemp.MasterEntity!= null)
                {
                    
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                isNewRecord = false;
                SelectedTabControlIndex = 0;

            }
            catch (Exception ex)
            {
                
            }
        }
        private void DeleteDatagridRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (AreaEntity.Count > i && AreaEntity[dgSelectedIndexarea].id == 0)
                {
                    AreaEntity.RemoveAt(i);

                }
            }
            catch (Exception ex)
            {
                
            }
        }

        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
            
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = AreaEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = AreaEntity.IndexOf(AreaEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && AreaEntity.Count == dgSelectedIndexarea)
                    {
                        AreaEntity.Add(new ZADM_M025_A()
                        {
                           
                            ItemCode = POPUPEntityObject.ItemCode,
                            ItemName=POPUPEntityObject.ItemName
                           
                        });
                    }
                    else if (dgSelectedIndexarea >= 0 && AreaEntity.Count > dgSelectedIndexarea) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (AreaEntity[dgSelectedIndexarea].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            AreaEntity[dgSelectedIndexarea].ItemCode = POPUPEntityObject.ItemCode;
                            AreaEntity[dgSelectedIndexarea].ItemName = POPUPEntityObject.ItemName;
                          
                        }
                        else if (AreaEntity[dgSelectedIndexarea].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            AreaEntity[dgSelectedIndexarea].ItemCode = "";
                            AreaEntity[dgSelectedIndexarea].ItemName = "";
                        }
                    }
                }
                #region Clear Empty Row
                ZADM_M025_A newObj = new ZADM_M025_A();
                for (int i = AreaEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = AreaEntity[i].ComparePropertiesTo(newObj);
                    if (AreaEntity[i].ComparePropertiesTo(newObj) == true && AreaEntity.Count > 1)
                    {
                        AreaEntity.RemoveAt(i);
                        if (AreaEntity.Count == 0)
                        {
                            AreaEntity.Add(newObj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
            #endregion
        }
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_code = POPUPEntityObject.so_code;                    
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
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sg_code = POPUPEntityObject.sg_code;
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


        private void InsertLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.LocationMaster.Where(x => x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;
                    


                }
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

        #region event handler
        void ModelUpdated_Area(object sender, EventArgs e)
        {

            //This will get called when the property of an object inside the collection changes
            if (sender.ToString() == "Height" || sender.ToString() == "width" || sender.ToString() == "unit_code" || sender.ToString() == "extraheight" || sender.ToString() == "panna" || sender.ToString() == "bal_piece_height")
            {
                AreaCalculation(true);
            }


        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "height" || e.PropertyName == "width" || e.PropertyName == "unit_code")
            {
                //AreaCalculation(true);
            }

        }
        private void CollectionChangedNotifyForarea(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ZADM_M025_A item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ZADM_M025_A item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add && AreaEntity.Count > 0)
            {
                foreach (ZADM_M025_A item in e.NewItems)
                {
                    //Adde items Schedules Default Values from Items Entity


                    item.panna = 51;
                    item.unit_code = "Sq.Feet";
                    item.extraheight = 4;

                }
            }

            if (e.Action == NotifyCollectionChangedAction.Replace)
            {

            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {

            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
            }
        }

        #endregion event handler

        #region INotifyPropertyChanged Interface Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        #endregion

        private void AreaCalculation(bool Calculate)
        {
            try
            {
                if (Calculate == true)
                {

                    decimal? TotalRoundUp = 0;
                    decimal? Total1 = 0;
                    decimal? Total2 = 0;
                    decimal? Total3 = 0;
                    decimal? Total4 = 0;


                    if (AreaEntity.Count > 0 && dgSelectedIndexarea != -1)
                    {
                        if (AreaEntity[dgSelectedIndexarea].unit_code == "Sq.Feet")
                        {
                            AreaEntity[dgSelectedIndexarea].pannavalue = AreaEntity[dgSelectedIndexarea].width / AreaEntity[dgSelectedIndexarea].panna;
                            AreaEntity[dgSelectedIndexarea].roundup = Math.Ceiling(Convert.ToDecimal(AreaEntity[dgSelectedIndexarea].pannavalue));
                            AreaEntity[dgSelectedIndexarea].totalwidth = AreaEntity[dgSelectedIndexarea].panna * AreaEntity[dgSelectedIndexarea].roundup;
                            AreaEntity[dgSelectedIndexarea].totalheight = AreaEntity[dgSelectedIndexarea].height + AreaEntity[dgSelectedIndexarea].extraheight;
                            Total1 = AreaEntity[dgSelectedIndexarea].totalwidth * AreaEntity[dgSelectedIndexarea].totalheight;
                            AreaEntity[dgSelectedIndexarea].totalwastage = Total1 / 144;
                            AreaEntity[dgSelectedIndexarea].totalactualarea = (AreaEntity[dgSelectedIndexarea].height * AreaEntity[dgSelectedIndexarea].width) / 144;

                            MasterEntity.sumtotalarea = AreaEntity.Sum(item => item.totalactualarea);
                            MasterEntity.sumtotalwaste = AreaEntity.Sum(item => item.totalwastage);

                            AreaEntity[dgSelectedIndexarea].total_bal_piece = AreaEntity[dgSelectedIndexarea].bal_piece_width * AreaEntity[dgSelectedIndexarea].bal_piece_height;

                        }
                        else if (AreaEntity[dgSelectedIndexarea].unit_code == "Sq.Mtr")
                        {
                            //AreaEntity[dgSelectedIndexarea].pannavalue = AreaEntity[dgSelectedIndexarea].width / AreaEntity[dgSelectedIndexarea].panna;
                            //AreaEntity[dgSelectedIndexarea].roundup = Math.Ceiling(Convert.ToDecimal(AreaEntity[dgSelectedIndexarea].pannavalue));
                            //AreaEntity[dgSelectedIndexarea].totalwidth = AreaEntity[dgSelectedIndexarea].panna * AreaEntity[dgSelectedIndexarea].roundup;
                            //AreaEntity[dgSelectedIndexarea].totalheight = AreaEntity[dgSelectedIndexarea].height + AreaEntity[dgSelectedIndexarea].extraheight;
                            //Total1 = AreaEntity[dgSelectedIndexarea].totalwidth * AreaEntity[dgSelectedIndexarea].totalheight;
                            //AreaEntity[dgSelectedIndexarea].totalwastage = Total1 / Convert.ToDecimal(10.76);
                            //AreaEntity[dgSelectedIndexarea].totalactualarea = (AreaEntity[dgSelectedIndexarea].height * AreaEntity[dgSelectedIndexarea].width) / Convert.ToDecimal(10.76);




                            AreaEntity[dgSelectedIndexarea].pannavalue = AreaEntity[dgSelectedIndexarea].width / AreaEntity[dgSelectedIndexarea].panna;
                            AreaEntity[dgSelectedIndexarea].roundup = Math.Ceiling(Convert.ToDecimal(AreaEntity[dgSelectedIndexarea].pannavalue));
                            AreaEntity[dgSelectedIndexarea].totalwidth = AreaEntity[dgSelectedIndexarea].panna * AreaEntity[dgSelectedIndexarea].roundup;
                            AreaEntity[dgSelectedIndexarea].totalheight = AreaEntity[dgSelectedIndexarea].height + AreaEntity[dgSelectedIndexarea].extraheight;
                            Total1 = AreaEntity[dgSelectedIndexarea].width * AreaEntity[dgSelectedIndexarea].height;
                            Total2= Total1 / 144;
                            Total3 = AreaEntity[dgSelectedIndexarea].totalwidth * AreaEntity[dgSelectedIndexarea].totalheight;
                            Total4 = Total3 / 144;
                            AreaEntity[dgSelectedIndexarea].totalwastage = Total4 / Convert.ToDecimal(10.76);
                            AreaEntity[dgSelectedIndexarea].totalactualarea = Total2 / Convert.ToDecimal(10.76); /*(AreaEntity[dgSelectedIndexarea].height * AreaEntity[dgSelectedIndexarea].width) / Convert.ToDecimal(10.76);*/

                            MasterEntity.sumtotalarea = AreaEntity.Sum(item => item.totalactualarea);
                            MasterEntity.sumtotalwaste = AreaEntity.Sum(item => item.totalwastage);
                            AreaEntity[dgSelectedIndexarea].total_bal_piece = AreaEntity[dgSelectedIndexarea].bal_piece_width * AreaEntity[dgSelectedIndexarea].bal_piece_height;
                        }
                    }
                }
            }
            catch (Exception ex)
            {  
                
            }


        }
        private void Save_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {
                DefaultValues();
                MasterEntity.XmlDataDocumentZADM_M025_A = obj.ObjectToXML(AreaEntity);
               this.MasterEntity.EndEdit();
                if (isNewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<ZADM_M025>(MasterEntity, "AreaCalculation", "CRM");

                }
                else if (isNewRecord == false)
                {
                    MasterEntity = repository.UpdateWithReturnDomainObject<ZADM_M025>(MasterEntity, "AreaCalculation", "CRM");


                }
                SetBusinessEntitiesAfterLoad("Save", "");
                isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 

            }
            catch (Exception ex)
            {
               
            }

         }
        private void Create_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                MasterEntity = new ZADM_M025();
                AreaEntity = new ObservableCollection<ZADM_M025_A>();
                isNewRecord = true;
                DefaultValues();
                CheckBox1.IsChecked = false;
                CheckBox2.IsChecked = false;
                MCTemp = new MultipleContext_ZADM_M025();              
            }
            catch (Exception ex)
            {

            }
        }
        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (MasterEntity.doc_no != null)
                {

                        this.MasterEntity.EndEdit();
                        string response = repository.Delete(MasterEntity.doc_no, "AreaCalculation", "CRM");

                        MasterEntity = new ZADM_M025();
                        AreaEntity = new ObservableCollection<ZADM_M025_A>();
                        _FlipDataGridCollection.Refresh();

                         MessageBox.Show("Record Deleted Succesfully");

                }


                isNewRecord = true;
                DefaultValues();
            }
            catch (Exception ex)
            {

            }
        }
        private void Print_Click(object sender, System.Windows.RoutedEventArgs e)
        {

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.MasterEntity;
                objDataSource[3] = MCTemp.AreaEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsZADM_M025";
                objDataSourceName[3] = "dsZADM_M025_A";

            if (MCTemp.MasterEntity !=null && MCTemp.AreaEntity!=null)
            {
                if (CheckBox1.IsChecked == true || CheckBox2.IsChecked == true)
                {
                    if (CheckBox1.IsChecked == true && CheckBox2.IsChecked == false)
                    {
                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\Measurement_Sheet1.rdlc", "Area");
                    }
                    else if (CheckBox2.IsChecked == true && CheckBox1.IsChecked == false)
                    {
                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\Measurement_Sheet2.rdlc", "Area1");
                    }
                    else if (CheckBox1.IsChecked == true && CheckBox2.IsChecked == true)
                    {
                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\Measurement_Sheet.rdlc", "Area2");
                    }

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Check AtLeast One CheckBox", this.Title);
                    showMessageService.ShowMessage();

                }
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Load Data...", this.Title);
                showMessageService.ShowMessage();

            }
        }
        protected TViewService GetViewService<TViewService>() where TViewService : class
        {
            return SimpleIoc.Default.GetInstance<TViewService>();
        }


        #region Filter String

        private string _filterString_SalesOrg;
        public string FilterString_SalesOrg
        {
            get { return _filterString_SalesOrg; }
            set
            {
                _filterString_SalesOrg = value;
                RaisePropertyChanged("FilterString_SalesOrg");
                FilterCollection_SalesOrg();
            }
        }
        private void FilterCollection_SalesOrg()
        {
            if (_sales_orgCollection != null)
            {
                _sales_orgCollection.Refresh();
            }
        }
        public bool Filter_SalesOrg(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesOrg))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesGroup;
        public string FilterString_SalesGroup
        {
            get { return _filterString_SalesGroup; }
            set
            {
                _filterString_SalesGroup = value;
                RaisePropertyChanged("FilterString_SalesGroup");
                FilterCollection_SalesGroup();
            }
        }
        private void FilterCollection_SalesGroup()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesGroup(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesGroup))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower())) ||
                       (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as ZADM_M025_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.width != null && data.width.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.height != null && data.height.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.add_by != null && data.add_by.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sumtotalarea != null && data.sumtotalarea.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sumtotalwaste != null && data.sumtotalwaste.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()))||
                        (data.totalactualarea != null && data.totalactualarea.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.totalwastage != null && data.totalwastage.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                 }
                return true;
            }
            return false;
        }

        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemsListPopup))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                          
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _FilterString_Location;
        public string FilterString_Location
        {
            get { return _FilterString_Location; }
            set
            {
                _FilterString_Location = value;
                RaisePropertyChanged("FilterString_Location");
                FilterCollection_Location();
            }
        }
        private void FilterCollection_Location()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }
        }
        public bool Filter_Location(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Location))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_FilterString_Location.ToLower())) ||
                        (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_FilterString_Location.ToLower()));
                        
                      
                }
                return true;
            }
            return false;
        }


        #endregion Filter String
    }

    public class ZADM_M025_A:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _doc_no;
        private Nullable<decimal> _width;
        private Nullable<decimal> _height;
        private Nullable<int> _panna;
        private Nullable<decimal> _pannavalue;
        private Nullable<decimal> _roundup;
        private Nullable<decimal> _totalwidth;
        private Nullable<decimal> _extraheight;
        private Nullable<decimal> _totalheight;
        private Nullable<decimal> _totalactualarea;
        private Nullable<decimal> _totalwastage;
        private string _unit_code;
        private string _area_name;
        private string _ItemCode;
        private string _ItemName;

        private Nullable<decimal> _bal_piece_width;
        private Nullable<decimal> _bal_piece_height;
        private Nullable<decimal> _total_bal_piece;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
            }
        }
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
            }
        }
        public Nullable<decimal> width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value; RaisePropertyChanged("width", ModelEntityUpdated);
            }
        }
        public Nullable<decimal> totalheight
        {
            get
            {
                return _totalheight;
            }

            set
            {
                _totalheight = value; RaisePropertyChanged("totalheight", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value; RaisePropertyChanged("Height", ModelEntityUpdated);
            }
        }

        public Nullable<int> panna
        {
            get
            {
                return _panna;
            }

            set
            {
                _panna = value; RaisePropertyChanged("panna", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> pannavalue
        {
            get
            {
                return _pannavalue;
            }

            set
            {
                _pannavalue = value; RaisePropertyChanged("Pannavalue", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> roundup
        {
            get
            {
                return _roundup;
            }

            set
            {
                _roundup = value; RaisePropertyChanged("roundup", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> totalwidth
        {
            get
            {
                return _totalwidth;
            }

            set
            {
                _totalwidth = value; RaisePropertyChanged("totalwidth", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> extraheight
        {
            get
            {
                return _extraheight;
            }

            set
            {
                _extraheight = value; RaisePropertyChanged("extraheight", ModelEntityUpdated);
            }
        }

         public Nullable<decimal> totalactualarea
        {
            get
            {
                return _totalactualarea;
            }

            set
            {
                _totalactualarea = value; RaisePropertyChanged("totalactualarea", ModelEntityUpdated);
            }
        }

        public Nullable<decimal> totalwastage
        {
            get
            {
                return _totalwastage;
            }

            set
            {
                _totalwastage = value; RaisePropertyChanged("totalwastage", ModelEntityUpdated);
            }
        }

        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code", ModelEntityUpdated);
            }
        }

        public string area_name
        {
            get
            {
                return _area_name;
            }

            set
            {
                _area_name = value; RaisePropertyChanged("area_name", ModelEntityUpdated);
            }
        }

        public string ItemCode
        {
            get
            {
                return _ItemCode;
            }

            set
            {
                _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
            }
        }

        public string ItemName
        {
            get
            {
                return _ItemName;
            }

            set
            {
                _ItemName = value; RaisePropertyChanged("ItemName", ModelEntityUpdated);
            }
        }

        public decimal? bal_piece_width
        {
            get
            {
                return _bal_piece_width;
            }

            set
            {
                _bal_piece_width = value; RaisePropertyChanged("bal_piece_width", ModelEntityUpdated);
            }
        }

        public decimal? bal_piece_height
        {
            get
            {
                return _bal_piece_height;
            }

            set
            {
                _bal_piece_height = value; RaisePropertyChanged("bal_piece_height", ModelEntityUpdated);
            }
        }

        public decimal? total_bal_piece
        {
            get
            {
                return _total_bal_piece;
            }

            set
            {
                _total_bal_piece = value; RaisePropertyChanged("total_bal_piece", ModelEntityUpdated);
            }
        }
    }
    public class ZADM_M025 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _doc_no;
        private System.DateTime _doc_date;
        private Nullable<decimal> _sumtotalarea;
        private Nullable<decimal> _sumtotalwaste;
        private System.DateTime _add_date;
        private Nullable<DateTime> _edit_date;
        private string _doc_cat;
        private string _doc_type;
        private string _add_by;
        private string _editby;
        private string _location_Id;
        private string _comp_code;
        private string _cust_name;
        private string _site_name;
        private string _po_no;
        private Nullable<DateTime> _po_date;
        private string _approved_by;
        private string _mes_taken_by;
        private string _mobile_no;
        private string _email_id;
        private string _designation;
        private string _remark;
        private string _LoctnNm;
        private string _so_code;
        private string _sg_code;
        //scalar
        private string _sg_name;
        private string _sales_org;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
            }
        }
        public string doc_no
        {
            get
            {
                return _doc_no;
            }

            set
            {
                _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
            }
        }
        public System.DateTime doc_date
        {
            get
            {
                return _doc_date;

            }
            set
            {
                _doc_date = value;RaisePropertyChanged("doc_date",ModelEntityUpdated);
            }


        }
        public Nullable<decimal> sumtotalarea
        {
            get
            {
                return _sumtotalarea;
            }

            set
            {
                _sumtotalarea = value; RaisePropertyChanged("sumtotalarea", ModelEntityUpdated);
            }
        }
        public Nullable<decimal> sumtotalwaste
        {
            get
            {
                return _sumtotalwaste;
            }

            set
            {
                _sumtotalwaste = value; RaisePropertyChanged("sumtotalwaste", ModelEntityUpdated);
            }
        }
        public string doc_cat
        {
            get
            {
                return _doc_cat;
            }

            set
            {
                _doc_cat = value; RaisePropertyChanged("doc_cat", ModelEntityUpdated);
            }
        }
        public string doc_type
        {
            get
            {
                return _doc_type;
            }

            set
            {
                _doc_type = value; RaisePropertyChanged("doc_type", ModelEntityUpdated);
            }
        }
        public string add_by
        {
            get
            {
                return _add_by;
            }

            set
            {
                _add_by = value; RaisePropertyChanged("add_by", ModelEntityUpdated);
            }
        }
        public string editby
        {
            get
            {
                return _editby;
            }

            set
            {
                _editby = value; RaisePropertyChanged("editby", ModelEntityUpdated);
            }
        }

        public System.DateTime add_date
        {

            get
            {
                return _add_date;
            }
            set
            {
                _add_date = value; RaisePropertyChanged("add_date", ModelEntityUpdated);
            }
        }
        public Nullable<DateTime> edit_date
        {

            get
            {
                return _edit_date;
            }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date", ModelEntityUpdated);
            }
        }
        public string location_Id
        {

            get
            {
                return _location_Id;
            }
            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
            }
        }
        public string comp_code
        {

            get
            {
                return _comp_code;
            }
            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
            }
        }

        public string XmlDataDocumentZADM_M025_A{get;set;}
        public string BackFlipEntity { get; set; }

        public string cust_name
        {
            get
            {
                return _cust_name;
            }

            set
            {
                _cust_name = value; RaisePropertyChanged("cust_name", ModelEntityUpdated);
            }
        }

        public string site_name
        {
            get
            {
                return _site_name;
            }

            set
            {
                _site_name = value; RaisePropertyChanged("site_name", ModelEntityUpdated);
            }
        }

        public string po_no
        {
            get
            {
                return _po_no;
            }

            set
            {
                _po_no = value; RaisePropertyChanged("po_no", ModelEntityUpdated);
            }
        }

        public DateTime? po_date
        {
            get
            {
                return _po_date;
            }

            set
            {
                _po_date = value; RaisePropertyChanged("po_date", ModelEntityUpdated);
            }
        }

        public string approved_by
        {
            get
            {
                return _approved_by;
            }

            set
            {
                _approved_by = value; RaisePropertyChanged("approved_by", ModelEntityUpdated);
            }
        }

        public string mes_taken_by
        {
            get
            {
                return _mes_taken_by;
            }

            set
            {
                _mes_taken_by = value; RaisePropertyChanged("mes_taken_by", ModelEntityUpdated);
            }
        }

        public string mobile_no
        {
            get
            {
                return _mobile_no;
            }

            set
            {
                _mobile_no = value; RaisePropertyChanged("mobile_no", ModelEntityUpdated);
            }
        }

        public string email_id
        {
            get
            {
                return _email_id;
            }

            set
            {
                _email_id = value; RaisePropertyChanged("email_id", ModelEntityUpdated);
            }
        }

        public string designation
        {
            get
            {
                return _designation;
            }

            set
            {
                _designation = value; RaisePropertyChanged("designation", ModelEntityUpdated);
            }
        }

        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value; RaisePropertyChanged("remark", ModelEntityUpdated);
            }
        }

        public string LoctnNm
        {
            get
            {
                return _LoctnNm;
            }

            set
            {
                _LoctnNm = value; RaisePropertyChanged("LoctnNm", ModelEntityUpdated);
            }
        }
        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
            }
        }
        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
            }
        }
        public string sales_org
        {
            get
            {
                return _sales_org;
            }

            set
            {
                _sales_org = value; RaisePropertyChanged("sales_org", ModelEntityUpdated);
            }
        }
        public string sg_name
        {
            get
            {
                return _sg_name;
            }

            set
            {
                _sg_name = value; RaisePropertyChanged("sg_name", ModelEntityUpdated);
            }
        }

    }
    public class ZADM_M025_Flip
    {
        public int id { get; set; }
        public string doc_no { get; set; }
        public System.DateTime doc_date { get; set; }
        public string doc_cat { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public Nullable<decimal> width { get; set; }
        public Nullable<decimal> height { get; set; }
        public Nullable<int> panna { get; set; }
        public Nullable<decimal> pannavalue { get; set; }
        public Nullable<decimal> totalactualarea { get; set; }
        public Nullable<decimal> totalwastage { get; set; }
        public Nullable<decimal> sumtotalarea { get; set; }
        public Nullable<decimal> sumtotalwaste { get; set; }
        public string unit_code { get; set; }

  }
    public class MultipleContext_ZADM_M025
    {
        public List<ZADM_M025> MasterEntity { get; set; }
        public ObservableCollection<ZADM_M025_A> AreaEntity { get; set; }
        public List<ZADM_M025_Flip> BackFlipEntity { get; set; }
        public List<ADM_M022_P> ItemListPopup { get; set; }
        public List<ADM_M003_P> LocationMaster { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }

    }

}
