using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Reflection.Apps.Store.TaskManager;
using Reflection.Presentation.Services;

using System.Collections.ObjectModel;
using Reflection.BusinessEntity;

namespace Reflection.Apps.Store.TaskManager
{
    public class TaskInfo_VM :  INotifyPropertyChanged
    {
        bool blNew = true;
        WebServiceRepository<Task> repository = new WebServiceRepository<Task>();
        WebServiceRepository<MultipleContext_Task> repository_M = new WebServiceRepository<MultipleContext_Task>();
        private ICollectionView _dataGridCollection;
      

        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertychanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region ICollection view

        private ICollectionView _salesCollection;
        public ICollectionView salesCollection
        {
            get { return _salesCollection; }
            set { _salesCollection = value; RaisePropertychanged("salesCollection"); }
        }

        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertychanged("PartyCollection"); }
        }

        private ICollectionView _assignByCollection;
        public ICollectionView assignByCollection
        {
            get { return _assignByCollection; }
            set { _assignByCollection = value; RaisePropertychanged("assignByCollection"); }
        }
        private ICollectionView _assignToCollection;
        public ICollectionView assignToCollection
        {
            get { return _assignToCollection; }
            set { _assignToCollection = value; RaisePropertychanged("assignToCollection"); }
        }


        #endregion

        #region Relay Commands

        //public RelayCommand<object> SelectionChangedCommandAssignTo
        //{
        //    get;
        //    private set;
        //}
        public RelayCommand<object> CommandParty { get; private set; }
        public RelayCommand<object> CommandAssignBy { get; private set; }
        public RelayCommand<object> CommandAssignTo { get; private set; }
        public RelayCommand<object> CommandSales { get; private set; }
        #endregion
        #region StringList Variables


        private List<string> _srtListParty;
        public List<string> StringListParty
        {
            get { return _srtListParty; }
            set
            {
                if (_srtListParty != value)
                {
                    _srtListParty = value;
                }
            }
        }
        private List<string> _strListAssignBy;
        public List<string> StringListAssignBy
        {
            get { return _strListAssignBy; }
            set
            {
                if (_strListAssignBy != value)
                {
                    _strListAssignBy = value;
                }
            }
        }

        private List<string> _strListAssignTo;
        public List<string> StringListAssignTo
        {
            get { return _strListAssignTo; }
            set
            {
                if (_strListAssignTo != value)
                {
                    _strListAssignTo = value;
                }
            }
        }

        private List<string> _strListSales;
        public List<string> StringListSales
        {
            get { return _strListSales; }
            set
            {
                if (_strListSales != value)
                {
                    _strListSales = value;
                }
            }
        }

        #endregion
        #region List Entity Object

        private List<Task> _SelectedList;
        public List<Task> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertychanged("SelectedList");
                }
            }
        }

        private MultipleContext_Task _MC = new MultipleContext_Task();
        public MultipleContext_Task MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertychanged("MC");
                }
            }
        }
        #endregion

        #region Entity Object

        private DraftTask _Task;
        public DraftTask Task
        {
            get
            {
              
                return _Task;
            }
            set
            {
                if (_Task != value)
                {
                    _Task = value;
                    RaisePropertychanged("SelectedTask");
                   
                }
            }
        }

        #endregion

        #region Constructor
        public TaskInfo_VM() : base()
        {
            SelectedList = new List<Task>();
            Task = new DraftTask();
            //SelectedTask.ValidateAsync().Wait();
        
            CommandParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });

            CommandAssignBy = new RelayCommand<object>(items => { if (items == null) { return; } InsertAssignBy(items); });

            CommandAssignTo = new RelayCommand<object>(items => { if (items == null) { return; } InsertAssignTo(items); });

            CommandSales = new RelayCommand<object>(items => { if (items == null) { return; } InsertSales(items); });

            //SelectionChangedCommandAssignTo=new RelayCommand<object>(items => { if (items == null) { return; } AssignTo(items); });


            LoadInitialData();
        }
        private void InsertParty(object InputValue)
        {
            //ADM_M028_PopUp.
            string Request = "";
            string RequestParameterData = "";
            ADM_M028_P POPUPEntityObject = null;
            //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            {

                Task.referring_party = POPUPEntityObject.PartyId;
                Task.referring_partyNm = POPUPEntityObject.PartyNm;

            }

        }
        private void InsertAssignBy(object InputValue)
        {
            string Request = "";
            ADM_M010_PopUp POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UserMaster_1.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M010_PopUp>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                Task.assign_by = POPUPEntityObject.EmpId;
                Task.assign_by_name = POPUPEntityObject.EmpName;

            }
        }
       
        private void InsertAssignTo(object InputValue)
        {
            string Request = "";
            ADM_M010_PopUp POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UserMaster_1.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M010_PopUp>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                Task.assign_to = POPUPEntityObject.EmpId;
                Task.AssignToUser = POPUPEntityObject.EmpName;

            }
        }


        private void InsertSales(object InputValue)
        {
            string Request = "";
            SEL_T001_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SalesInquiry.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                Task.sono = POPUPEntityObject.sono;
                Task.s_status = POPUPEntityObject.t_status;


            }
        }

        //private void AssignTo(Object AssignToList)
        //{
        //    IList list = AssignToList as IList;
        //    List<ADM_M010_PopUp> SelectedAssignToTemp = list.Cast<ADM_M010_PopUp>().ToList();
        //    if (SelectedAssignToTemp.Count > 0)
        //    //{
        //    //    SelectedTask.assign_to = SelectedAssignToTemp[0].EmpId;
        //    //    SelectedTask.AssignToUser = SelectedAssignToTemp[0].EmpName;
        //    }
        //}

        //private void GetSelectedList(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<Task> tSelectedItemsList = list.Cast<Task>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        Task = (Task)tSelectedItemsList[0];
        //        blNew = false;
        //    }
        //}
      
        private void LoadInitialData()
        {

            try
            {
                MultipleContext_Task MC = new MultipleContext_Task();
                MC = repository_M.GetDataWithReturnDomainObject<MultipleContext_Task>(MC, "Task_Data", "TaskManager", "Communication", "", 0, "");
                SelectedList = MC.taskData;

                salesCollection = CollectionViewSource.GetDefaultView(MC.SalesInquiry);
                salesCollection.Filter = new Predicate<object>(Filter_Sales);
                StringListSales = MC.SalesInquiry.Select(x => x.sono).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(Filter_Party);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                assignToCollection = CollectionViewSource.GetDefaultView(MC.UserMaster_1.ToList());
                assignToCollection.Filter = new Predicate<object>(Filter_AssignBy);
                StringListAssignBy = MC.UserMaster_1.Select(x => x.EmpId).ToList();

                assignByCollection = CollectionViewSource.GetDefaultView(MC.UserMaster_1.ToList());
                assignByCollection.Filter = new Predicate<object>(Filter_AssignTo);
                StringListAssignTo = MC.UserMaster_1.Select(x => x.EmpId).ToList();

               

                //CollectionAssignToList = CollectionViewSource.GetDefaultView(MC.UserMaster_1);
                //CollectionAssignToList.Filter = new Predicate<object>(FilterAssignTo);
                //DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                //DataGridCollection.Filter = new Predicate<object>(Filter);
                //Defualt();
                //Task.act_date = System.DateTime.Now;
                //TaskDAL user = new TaskDAL();
                //user.DataGridCollection
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
        #endregion
        public void Default()
        {

        }

        #region Filter

        public bool Filter_AssignTo(object obj)
        {
            var data = obj as ADM_M010_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringAssignTo))
                {
                   return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringAssignTo.ToLower()))||
                           (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringAssignTo.ToLower()));
                  
                }
                return true;
            }
            return false;
        }
        private string _filterStringAssignTo;
        public string FilterStringAssignTo
        {
            get { return _filterStringAssignTo; }
            set
            {
                _filterStringAssignTo = value;
                RaisePropertychanged("FilterStringAssignTo");
                FilterCollectionAssignTo();
            }
        }
        private void FilterCollectionAssignTo()
        {
            if (_assignToCollection != null)
            {
                _assignToCollection.Refresh();
            }
        }

       
      
        public bool Filter_AssignBy(object obj)
        {
            var data = obj as ADM_M010_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringAssignBy))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringAssignBy.ToLower())) ||
                      (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringAssignBy.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringAssignBy;
        public string FilterStringAssignby
        {
            get { return _filterStringAssignBy; }
            set
            {
                _filterStringAssignBy = value;
                RaisePropertychanged("FilterStringAssignby");
                FilterCollectionAssignBy();
            }
        }
        private void FilterCollectionAssignBy()
        {
            if (_assignByCollection != null)
            {
                _assignByCollection.Refresh();
            }
        }

        public bool Filter_Party(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParty))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringParty.ToLower()))||
                      (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringParty.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringParty;
        public string FilterString_Party
        {
            get { return _filterStringParty; }
            set
            {
                _filterStringParty = value;
                RaisePropertychanged("FilterString_Party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }

        public bool Filter_Sales(object obj)
        {
            var data = obj as SEL_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSales))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_filterStringSales.ToLower()))||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_filterStringSales.ToLower()))||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterStringSales.ToLower()))||
                           (data.buyer_name != null && data.buyer_name.ToString().ToLower().Contains(_filterStringSales.ToLower()));

                }
                return true;
            }
            return false;
        }
        private string _filterStringSales;
        public string FilterString_Sales
        {
            get { return _filterStringSales; }
            set
            {
                _filterStringSales = value;
                RaisePropertychanged("FilterStringSales");
                FilterCollectionSales();
            }
        }
        private void FilterCollectionSales()
        {
            if (_salesCollection != null)
            {
                _salesCollection.Refresh();
            }
        }

        #endregion
    }
}
