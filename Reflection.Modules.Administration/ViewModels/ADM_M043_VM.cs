using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M043_VM : WorkspaceViewModel<ADM_M043>
    {
        WebServiceRepository<ADM_M043> repository = new WebServiceRepository<ADM_M043>();
        WebServiceRepository<MultipleContext_ADM_M043> repository_MC_ADM_M043 = new WebServiceRepository<MultipleContext_ADM_M043>();
        bool blNew = true;
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ADM_M043_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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
       
       
        private AutoSuggestTextViewModel<dynamic> _ASORG { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASORG
        {
            get { return _ASORG; }
            set
            {
                if (_ASORG != value)
                {
                    _ASORG = value; RaisePropertyChanged("ASORG");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDepartment { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDepartment
        {
            get { return _ASDepartment; }
            set
            {
                if (_ASDepartment != value)
                {
                    _ASDepartment = value; RaisePropertyChanged("ASDepartment");
                }
            }
        }
        
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
                    if (SourceName == "dept_code")
                    { ASDefault = ASDepartment; }
                    else if (SourceName == "org_code")
                    { ASDefault = ASORG; }
                }
            }
        }
        #endregion

        MultipleContext_ADM_M043 _MC_ADM_M043 = new MultipleContext_ADM_M043();

        MultipleContext_ADM_M043 MCtemp = new MultipleContext_ADM_M043();

        public MultipleContext_ADM_M043 MC_ADM_M043
        {
            get { return _MC_ADM_M043; }
            set
            {
                if (_MC_ADM_M043 != value)
                {
                    _MC_ADM_M043 = value;

                    RaisePropertyChanged("MC_ADM_M043");
                }
            }
        }

        private ObservableCollection<ADM_M043_A> _dgdetail;
        public ObservableCollection<ADM_M043_A> dgdetail
        {
            get
            { return _dgdetail; }
            set
            {
                if (_dgdetail != value)
                {
                    _dgdetail = value;

                    RaisePropertyChanged("dgdetail");
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

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }
        #region . ADM_M043 .

        private List<ADM_M043> _SelectedList;
        public List<ADM_M043> SelectedList
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

        private ADM_M043 _SelectedADM_M043;

        public ADM_M043 SelectedADM_M043
        {
            get
            {
                this.ErrorExist = _SelectedADM_M043.HasErrors;
                return _SelectedADM_M043;
            }
            set
            {
                if (_SelectedADM_M043 != value)
                {
                    _SelectedADM_M043 = value;
                    RaisePropertyChanged("SelectedADM_M043");
                      value.BeginEdit();
                }
            }
        }

        #endregion

        #region . relay commands .

        public RelayCommand<object> SelectedChangedCommandCompany
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectedChangedCommandDocCat
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectedChangedCommandDocType
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectedChangedCommandPlant
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectedChangedCommandTransaction
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandApprover
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectedChangedCommandUom
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        #endregion

        #region . ICollectionView .

        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }
        private ICollectionView _DocCatCollection;
        public ICollectionView DocCatCollection
        {
            get { return _DocCatCollection; }
            set { _DocCatCollection = value;RaisePropertyChanged("DocCatCollection"); }
        }
        private ICollectionView _DocTypeCollection;
        public ICollectionView DocTypeCollection
        {
            get { return _DocTypeCollection; }
            set { _DocTypeCollection = value; RaisePropertyChanged("DocTypeCollection"); }
        }
        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }

        private ICollectionView _TransactionCollection;
        public ICollectionView TransactionCollection
        {
            get { return _TransactionCollection; }
            set { _TransactionCollection = value; RaisePropertyChanged("TransactionCollection"); }
        }

        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        private ICollectionView _UomCollection;
        public ICollectionView UomCollection
        {
            get { return _UomCollection; }
            set { _UomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        private ICollectionView _WorkFlowCollection;
        public ICollectionView WorkFlowCollection
        {
            get { return _WorkFlowCollection; }
            set { _WorkFlowCollection = value; RaisePropertyChanged("WorkFlowCollection"); }
        }

        private List<NotificationData> _NotificationDataCollection;
        public List<NotificationData> NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set
            {
                if (_NotificationDataCollection != value)
                {
                    _NotificationDataCollection = value;
                    RaisePropertyChanged("NotificationDataCollection");
                }
            }
        }
        #endregion

        private List<string> _StrListPlant;
        public List<string> StringListPlant
        {
            get { return _StrListPlant; }
            set
            {
                if (_StrListPlant != value)
                {
                    _StrListPlant = value;
                }
            }
        }
        private List<string> _StrListComp;
        public List<string> StringListComp
        {
            get { return _StrListComp; }
            set
            {
                if (_StrListComp != value)
                {
                    _StrListComp = value;
                }
            }
        }

        #region . Constructor .

        public ADM_M043_VM(): base()
        {
            SelectedList = new List<ADM_M043>();
            SelectedADM_M043 = new ADM_M043();
            NotificationDataCollection = new List<NotificationData>();
            SelectedADM_M043.ValidateAsync().Wait();

            dgdetail = new ObservableCollection<ADM_M043_A>();

            SelectedChangedCommandCompany = new RelayCommand<object>(cmdPara => {if (cmdPara == null) {return;}GetSelectedCompany(cmdPara, true, true, true);});
            SelectedChangedCommandPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } GetSelectedPlantDetails(cmdPara, true, true, true); });

            SelectedChangedCommandDocCat = new RelayCommand<IList>(
               items =>
               {


                   if (items == null)
                   {
                       return;

                   }
                   GetSelectedDocCat(items);
               });

            SelectedChangedCommandDocType = new RelayCommand<IList>(
               items =>
               {


                   if (items == null)
                   {
                       return;

                   }
                   GetSelectedDocType(items);
               });

            SelectedChangedCommandTransaction = new RelayCommand<IList>(

            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedTransactionDetails(items);
            });

            SelectionChangedCommandApprover = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedApprover(items);
            });

            SelectedChangedCommandUom = new RelayCommand<IList>(

            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedUomDetails(items);
            });

            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            LoadInitialData();
        }
        #endregion

        #region . User Defined Functions .

        private void LoadInitialData()
        {
            try
            {
                MC_ADM_M043 = repository_MC_ADM_M043.GetDataWithReturnDomainObject<MultipleContext_ADM_M043>(MC_ADM_M043, "ADM_M043_Data", "WorkFlowMaster", "Administration", "LoadAll", 0, "");
                SelectedList = MC_ADM_M043.workflowlist;

                #region Autosuggest

                


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).dept_code);
                TheFilter = (o, prefix) => (((ADM_M025_P)o).dept_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M025_P)o).DeptName ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC_ADM_M043.Departments, TheFilter, SuggestedValue, "dept_code", "dept_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ORG_Data)x).org_code);
                TheFilter = (o, prefix) => (((ORG_Data)o).org_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ORG_Data)o).org_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASORG = new AutoSuggestTextViewModel<dynamic>(MC_ADM_M043.OrgData, TheFilter, SuggestedValue, "org_code", "org_code", true);
                ASORG.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).dept_code);
                TheFilter = (o, prefix) => (((ADM_M025_P)o).dept_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M025_P)o).DeptName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDepartment = new AutoSuggestTextViewModel<dynamic>(MC_ADM_M043.Departments, TheFilter, SuggestedValue, "dept_code", "dept_code", true);
                ASDepartment.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDepartment.AutoSuggestVM.IsFreeTextAllowed = false;

                
                #endregion

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.employeelist.ToList());
                EmployeeCollection.Filter = new Predicate<object>(Filterapprover);

                UomCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.uomlist.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUnit);

                CompanyCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.companylist.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListComp = MC_ADM_M043.companylist.Select(x => x.CompName).ToList();

                DocCatCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.categorymaster.ToList());
                DocCatCollection.Filter = new Predicate<object>(FilterDocCat);

                

                //DocTypeCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.categoryTypemaster.ToList());
                //DocTypeCollection.Filter = new Predicate<object>(FilterDocType);

                PlantCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.plantlist.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = MC_ADM_M043.plantlist.Select(x => x.LoctnNm).ToList();

                TransactionCollection = CollectionViewSource.GetDefaultView(MC_ADM_M043.transactionlist.ToList());
                TransactionCollection.Filter = new Predicate<object>(FilterTransaction);

                WorkFlowCollection = CollectionViewSource.GetDefaultView(SelectedList);
                WorkFlowCollection.Filter = new Predicate<object>(FilterWorkflow);

            

                DefaultValue();

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

        private void GetSelectedApprover(IList Employeelist)
        {
            IList list = Employeelist as IList;
            List<ADM_M024_P> GetSelectedEmpTemp = list.Cast<ADM_M024_P>().ToList();

            if (GetSelectedEmpTemp.Count > 0)
            {
                if (dgdetail.Count > 0 && dgSelectedIndex != -1 && dgdetail.Count > dgSelectedIndex)
                {
                    dgdetail[dgSelectedIndex].approver_id = GetSelectedEmpTemp[0].EmpId;
                    dgdetail[dgSelectedIndex].approvernm = GetSelectedEmpTemp[0].EmpName;
                    dgdetail[dgSelectedIndex].UserId = GetSelectedEmpTemp[0].UserId;
                }
            }
        }
        private void GetSelectedUomDetails(IList Uomlist)
        {
            IList list = Uomlist as IList;
            List<ADM_M038_B_P> GetSelectedUomDetailsTemp = list.Cast<ADM_M038_B_P>().ToList();

            if (GetSelectedUomDetailsTemp.Count > 0) //&& matdgSelectedIndex!=-1)
            {
                if (dgdetail.Count > 0 && dgSelectedIndex != -1 && dgdetail.Count > dgSelectedIndex)// matdgSelectedIndex)
                {
                    dgdetail[dgSelectedIndex].unit_name = GetSelectedUomDetailsTemp[0].unit_name;
                    dgdetail[dgSelectedIndex].unit_code = GetSelectedUomDetailsTemp[0].unit_code;
                }
            }
        }
        private void GetSelectedCompany(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M002_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC_ADM_M043.companylist.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M002_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {


                    var InputValueIfExists = dgdetail.Where(x => x.authorise_comp == POPUPEntityObject.comp_code).FirstOrDefault();
                    int IndexOfExistValue = dgdetail.IndexOf(dgdetail.Where(X => X.authorise_comp == POPUPEntityObject.comp_code).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgdetail.Count == dgSelectedIndex)
                    {
                        dgdetail.Add(new ADM_M043_A()
                        {
                            id = 0,
                            authorise_comp = POPUPEntityObject.comp_code,
                            authorise_compNm = POPUPEntityObject.CompName,
                        });

                    }
                    else if (dgSelectedIndex >= 0 && dgdetail.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgdetail[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            dgdetail[dgSelectedIndex].authorise_comp = POPUPEntityObject.comp_code;
                            dgdetail[dgSelectedIndex].authorise_compNm = POPUPEntityObject.CompName;
                        }

                        else if (dgdetail[dgSelectedIndex].authorise_comp != POPUPEntityObject.comp_code)
                        {
                            dgdetail[dgSelectedIndex].authorise_comp = POPUPEntityObject.comp_code;
                            dgdetail[dgSelectedIndex].authorise_compNm = POPUPEntityObject.CompName;
                        }
                    }

                }  
                #region Clear Empty Row
                ADM_M043_A newObj = new ADM_M043_A();
                for (int i = dgdetail.Count - 1; i >= 0; i--)
                {
                    bool xx = dgdetail[i].ComparePropertiesTo(newObj);
                    if (dgdetail[i].ComparePropertiesTo(newObj) == true && dgdetail.Count > 1)
                    {
                        dgdetail.RemoveAt(i);
                        if (dgdetail.Count == 0)
                        {
                            dgdetail.Add(newObj);
                        }
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
        private void GetSelectedPlantDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC_ADM_M043.plantlist.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                       
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgdetail.Where(x => x.authorise_location == POPUPEntityObject.location_Id).FirstOrDefault();
                    int IndexOfExistValue = dgdetail.IndexOf(dgdetail.Where(X => X.authorise_location == POPUPEntityObject.location_Id).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgdetail.Count == dgSelectedIndex)
                    {
                        dgdetail.Add(new ADM_M043_A()
                        {
                        
                            authorise_location = POPUPEntityObject.location_Id,
                            authorise_locNm = POPUPEntityObject.LoctnNm,
                        });

                    }
                    else if (dgSelectedIndex >= 0 && dgdetail.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgdetail[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            dgdetail[dgSelectedIndex].authorise_location = POPUPEntityObject.location_Id;
                            dgdetail[dgSelectedIndex].authorise_locNm = POPUPEntityObject.LoctnNm;
                        }

                        else if (dgdetail[dgSelectedIndex].authorise_comp != POPUPEntityObject.comp_code)
                        {
                            dgdetail[dgSelectedIndex].authorise_location = POPUPEntityObject.location_Id;
                            dgdetail[dgSelectedIndex].authorise_locNm = POPUPEntityObject.LoctnNm;
                        }
                    }
                }
                #region Clear Empty Row
                ADM_M043_A newObj = new ADM_M043_A();
                for (int i = dgdetail.Count - 1; i >= 0; i--)
                {
                    bool xx = dgdetail[i].ComparePropertiesTo(newObj);
                    if (dgdetail[i].ComparePropertiesTo(newObj) == true && dgdetail.Count > 1)
                    {
                        dgdetail.RemoveAt(i);
                        if (dgdetail.Count == 0)
                        {
                            dgdetail.Add(newObj);
                        }
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


      
        //private void GetSelectedCompany(IList Companylist)
        //{
        //    IList list = Companylist as IList;
        //    List<ADM_M002_P> GetSelectedCompanyTemp = list.Cast<ADM_M002_P>().ToList();

        //    if (GetSelectedCompanyTemp.Count > 0)
        //    {
        //        SelectedADM_M043.comp_code = GetSelectedCompanyTemp[0].comp_code;
        //        SelectedADM_M043.CompName = GetSelectedCompanyTemp[0].CompName;
        //    }
        //}

        private void GetSelectedDocCat(IList DocCatList)
        {
            IList list = DocCatList as IList;
            List<SYS_M001_P> GetSelectedDocCat = list.Cast<SYS_M001_P>().ToList();

            if (GetSelectedDocCat.Count > 0)
            {
                SelectedADM_M043.ref_doc_cat = GetSelectedDocCat[0].doc_cat;

                var doctype = (from o in MC_ADM_M043.categoryTypemaster
                                    where o.doc_cat == SelectedADM_M043.ref_doc_cat
                               select o).ToList();
                if (doctype.Count == 1)
                {
                    SelectedADM_M043.ref_doc_type = doctype[0].doc_type;
                }
                else
                {
                    DocTypeCollection = CollectionViewSource.GetDefaultView(doctype.ToList());
                    DocTypeCollection.Filter = new Predicate<object>(FilterDocType);
                    DocTypeCollection.Refresh();
                }
             
            }

        }

        private void GetSelectedDocType(IList DocCatList)
        {
            IList list = DocCatList as IList;
            List<SYS_M002_P> GetSelectedDocType = list.Cast<SYS_M002_P>().ToList();

            if (GetSelectedDocType.Count > 0)
            {
                SelectedADM_M043.ref_doc_type = GetSelectedDocType[0].doc_cat;

            }
        }


        //private void GetSelectedPlantDetails(IList PlantList)
        //{
        //    IList list = PlantList as IList;
        //    List<ADM_M003_P> GetSelectedPlantTemp = list.Cast<ADM_M003_P>().ToList();

        //    if (GetSelectedPlantTemp.Count > 0)
        //    {

        //        SelectedADM_M043.location_Id = GetSelectedPlantTemp[0].location_Id;
        //        SelectedADM_M043.LoctnNm = GetSelectedPlantTemp[0].LoctnNm;
        //    }
        //}
        private void GetSelectedTransactionDetails(IList TransactionList)
        {
            IList list = TransactionList as IList;
            List<ADM_M008B_P> GetSelectedTransactionTemp = list.Cast<ADM_M008B_P>().ToList();

            if (GetSelectedTransactionTemp.Count > 0)
            {
                SelectedADM_M043.transaction_id = GetSelectedTransactionTemp[0].TranCode;
                SelectedADM_M043.TranName = GetSelectedTransactionTemp[0].TranName;
            }

        }
        private void GetSelectedList(IList WorkFlowList)
        {
            IList list = WorkFlowList as IList;
            List<ADM_M043> GetSelectedWorkFlowListTemp = list.Cast<ADM_M043>().ToList();

            if (GetSelectedWorkFlowListTemp.Count > 0)
            {
                SelectedADM_M043 = (ADM_M043)GetSelectedWorkFlowListTemp[0];
                blNew = false;

                MCtemp = repository_MC_ADM_M043.GetDataWithReturnDomainObject<MultipleContext_ADM_M043>(MCtemp, "", "WorkFlowMaster", "Administration", "WorkFlow_Details", 0, SelectedADM_M043.workflow_id);
                SelectedTabControlIndex = 0;
                dgdetail = MCtemp.detailslist;
            }           
        }

     
        #endregion

        private bool Validation()
        {

            foreach (var item in dgdetail)
            {
                //if (item.level_no==0 || item.access_field==null||item.approvernm==null||item.authority==null||item.field_value==0||item.roperator==null||item.unit_name==null)
                //{
                //    return false;
                //}
                if (item.level_no == 0 || item.access_field == null || item.approvernm == null || item.authority == null || item.unit_name == null)
                {
                    return false;
                }
            }

            if (SelectedADM_M043.ref_doc_cat == null || SelectedADM_M043.ref_doc_cat == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Document Category");
                showMessageService.ShowMessage();
                return false;
            }
            return true;

        }

        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<ADM_M043> result)
        {
            if (Validation()==true)
            {
                try
                {

                    SelectedADM_M043.active = true;
                    SelectedADM_M043.add_by = AppSessionState.UserID;
                   
                    SelectedADM_M043.editby = AppSessionState.UserID;

                    ObjectSerializationService objSer = new ObjectSerializationService();
                    SelectedADM_M043.XmlDataDocument_ADM_M043_A = objSer.ObjectToXML(dgdetail);

                    if (blNew == true)
                    {
                        SelectedADM_M043 = repository.SaveWithReturnDomainObject<ADM_M043>(SelectedADM_M043, "WorkFlowMaster", "Administration");
                        SelectedList.Add(SelectedADM_M043);
                       this.SelectedADM_M043.EndEdit();

                       blNew = false;
                    }
                    else if (blNew == false)
                    {
                        SelectedADM_M043 = repository.UpdateWithReturnDomainObject<ADM_M043>(SelectedADM_M043, "WorkFlowMaster", "Administration");
                        this.SelectedADM_M043.EndEdit();
                    }

                    if (SelectedADM_M043.XmlDataDocument_ADM_M043_A != null)
                    {
                        MC_ADM_M043.detailslist = (ObservableCollection<ADM_M043_A>)new ObjectSerializationService().XMLToObject(SelectedADM_M043.XmlDataDocument_ADM_M043_A, MC_ADM_M043.detailslist);
                    }
                    else
                    {
                        MC_ADM_M043.detailslist = new ObservableCollection<ADM_M043_A>();
                    }
                    dgdetail = MC_ADM_M043.detailslist;

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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("All Fields In Item Details Are Required");
                showMessageService.ShowMessage();

            }
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M043> result)
        {
            blNew = true;
            SelectedADM_M043 = new ADM_M043();

            dgdetail = new ObservableCollection<ADM_M043_A>();

            SelectedADM_M043.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M043> result)
        {
            if (_SelectedADM_M043.workflow_id != null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.YesNo;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text = String.Format("This record will delete forever '{0}'", this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Yes)
                {
                    this.SelectedADM_M043.CancelEdit();
                    string response = repository.Delete(SelectedADM_M043.workflow_id, "WorkFlowMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M043);

                    WorkFlowCollection.Refresh();
                    SelectedADM_M043 = new ADM_M043();
                    dgdetail = new ObservableCollection<ADM_M043_A>();
                }
            }
            blNew = true;

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M043> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M043> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M043> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M043> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M043> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M043> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M043> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M043> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M043> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M043> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        public void DefaultValue()
        {

            SelectedADM_M043.location_Id = AppSessionState.location_Id;
            SelectedADM_M043.comp_code = AppSessionState.comp_code;
            SelectedADM_M043.doc_type = "WF";
            SelectedADM_M043.doc_cat = "WF";
            SelectedADM_M043.active = true;
            SelectedADM_M043.client = AppSessionState.client;
        }

        #endregion

        #region Filter Company

        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringcompany))
                {
                    return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterStringcompany.ToLower()))||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterStringcompany.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringcompany;
        public string filterStringcompany
        {
            get { return _filterStringcompany; }
            set
            {
                _filterStringcompany = value;
                RaisePropertyChanged("filterStringcompany");
                FilterCollectioncompany();
            }
        }
        private void FilterCollectioncompany()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        #endregion

        #region filterDocCat

        public bool FilterDocCat(object obj)
        {
            var data = obj as SYS_M001_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDocCat))
                {
                    return (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterStringDocCat.ToLower()))||
                        (data.dcat_name != null && data.dcat_name.ToString().ToLower().Contains(_filterStringDocCat.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringDocCat;
        public string filterStringDocCat
        {
            get { return _filterStringDocCat; }
            set
            {
                _filterStringcompany = value;
                RaisePropertyChanged("filterStringDocCat");
                FilterCollectionDocCat();
            }
        }
        private void FilterCollectionDocCat()
        {
            if (_DocCatCollection != null)
            {
                _DocCatCollection.Refresh();
            }
        }

        public bool FilterDocType(object obj)
        {
            var data = obj as SYS_M002_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDocType))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterStringDocCat.ToLower())) ||
                        (data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_filterStringDocCat.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringDocType;
        public string filterStringDocType
        {
            get { return _filterStringDocType; }
            set
            {
                _filterStringcompany = value;
                RaisePropertyChanged("filterStringDocCat");
                FilterCollectionDocType();
            }
        }
        private void FilterCollectionDocType()
        {
            if (_DocTypeCollection != null)
            {
                _DocTypeCollection.Refresh();
            }
        }



        #endregion


        #region filterplant
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringPlant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringPlant;
        public string filterStringPlant
        {
            get { return _filterStringPlant; }
            set
            {
                _filterStringPlant = value;
                RaisePropertyChanged("FilterStringPlant");
                FilterCollectionPlant();
            }
        }
        private void FilterCollectionPlant()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
            }
        }
        #endregion

        #region Filter Transaction

        public bool FilterTransaction(object obj)
        {
            var data = obj as ADM_M008B_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTransaction))
                {
                    return (data.TranName != null && data.TranName.ToString().ToLower().Contains(_filterStringTransaction.ToLower()))||
                        (data.TranCode != null && data.TranCode.ToString().ToLower().Contains(_filterStringTransaction.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringTransaction;
        public string filterStringTransaction
        {
            get { return _filterStringTransaction; }
            set
            {
                _filterStringTransaction = value;
                RaisePropertyChanged("filterStringTransaction");
                FilterCollectionTransaction();
            }
        }
        private void FilterCollectionTransaction()
        {
            if (_TransactionCollection != null)
            {
                _TransactionCollection.Refresh();
            }
        }
        #endregion 

        #region Filter Approver
        public bool Filterapprover(object obj)
        {
            var data = obj as ADM_M024_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringapprover))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringapprover.ToLower())
                        || data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringapprover));
                }
                return true;
            }
            return false;
        }
        private string _filterStringapprover;
        public string filterStringapprover
        {
            get { return _filterStringapprover; }
            set
            {
                _filterStringapprover = value;
                RaisePropertyChanged("filterStringapprover");
                FilterCollectionapprover();
            }
        }
        private void FilterCollectionapprover()
        {
            if (_EmployeeCollection != null)
            {
                _EmployeeCollection.Refresh();
            }
        }
        #endregion

        #region Filter UnitOfMeasure
        public bool FilterUnit(object obj)
        {
            var data = obj as ADM_M038_B_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUnit))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUnit.ToLower()))||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringUnit;
        public string filterStringUnit
        {
            get { return _filterStringUnit; }
            set
            {
                _filterStringUnit = value;
                RaisePropertyChanged("filterStringUnit");
                FilterStringUnit();
            }
        }
        private void FilterStringUnit()
        {
            if (_UomCollection != null)
            {
                _UomCollection.Refresh();
            }
        }
        #endregion

        #region Filter WorkFlow BackFlip
        public bool FilterWorkflow(object obj)
        {
            var data = obj as ADM_M043;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWorkflow))
                {
                    return (data.workflow_id != null && data.workflow_id.ToString().ToLower().Contains(_filterStringWorkflow.ToLower())
                        || data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterStringWorkflow.ToLower())
                        || data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringWorkflow.ToLower())
                        || data.TranName != null && data.TranName.ToString().ToLower().Contains(_filterStringWorkflow.ToLower())
                        || data.create_date != null && data.create_date.ToString().ToLower().Contains(_filterStringWorkflow.ToLower())
                        || data.remark != null && data.remark.ToString().ToLower().Contains(_filterStringWorkflow.ToLower()));                  
                }
                return true;
            }
            return false;
        }

        private string _filterStringWorkflow;
        public string filterStringWorkflow
        {
            get { return _filterStringWorkflow; }
            set
            {
                _filterStringWorkflow = value;
                RaisePropertyChanged("filterStringWorkflow");
                FilterStringWorkflow();
            }
        }
        private void FilterStringWorkflow()
        {
            if (_WorkFlowCollection != null)
            {
                _WorkFlowCollection.Refresh();
            }
        }

        
        #endregion
    }
}
