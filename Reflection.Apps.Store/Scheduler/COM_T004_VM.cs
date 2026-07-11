using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity.ProjectManagement;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.Communication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.BusinessEntity;

namespace Reflection.Apps.Store.Scheduler
{
    public class COM_T004_VM : WorkspaceViewModel<COM_T004>
    {
        bool isNewRecord = true;
        WebServiceRepository<COM_T004> repository = new WebServiceRepository<COM_T004>();
        WebServiceRepository<MultipleContext_COM_T004> repository_MC = new WebServiceRepository<MultipleContext_COM_T004>();
        WebServiceRepository<MultipleContext_COM_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_COM_T004>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations

        private MultipleContext_COM_T004 _MC;
        public MultipleContext_COM_T004 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_COM_T004 _MCTemp;
        public MultipleContext_COM_T004 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_COM_T004 _MCTemp1;
        public MultipleContext_COM_T004 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }
       
        private COM_T004 _ScheduleEntity;
        public COM_T004 ScheduleEntity
        {
            get { return _ScheduleEntity; }
            set
            {
                if (_ScheduleEntity != value)
                {
                    _ScheduleEntity = value;
                    RaisePropertyChanged("ScheduleEntity");
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

        private string _Daily;
        public string Daily
        {
            get { return _Daily; }
            set
            {
                if (Daily != value)
                {
                    _Daily = value;
                    RaisePropertyChanged("Daily");
                }
            }
        }

        private string _Weekly;
        public string Weekly
        {
            get { return _Weekly; }
            set
            {
                if (Weekly != value)
                {
                    _Weekly = value;
                    RaisePropertyChanged("Weekly");
                }
            }
        }

        private string _Monthly;
        public string Monthly
        {
            get { return _Monthly; }
            set
            {
                if (Monthly != value)
                {
                    _Monthly = value;
                    RaisePropertyChanged("Monthly");
                }
            }
        }


        private bool _MonthDay;
        public bool MonthDay
        {
            get { return _MonthDay; }
            set
            {
                if (MonthDay != value)
                {
                    _MonthDay = value;
                    RaisePropertyChanged("MonthDay");
                }
            }
        }

        private bool _Month1;
        public bool Month1
        {
            get { return _Month1; }
            set
            {
                if (Month1 != value)
                {
                    _Month1 = value;
                    RaisePropertyChanged("Month1");
                }
            }
        }

        private bool _TheWk;
        public bool TheWk
        {
            get { return _TheWk; }
            set
            {
                if (TheWk != value)
                {
                    _TheWk = value;
                    RaisePropertyChanged("TheWk");
                }
            }
        }

        private bool _TheDay;
        public bool TheDay
        {
            get { return _TheDay; }
            set
            {
                if (TheDay != value)
                {
                    _TheDay = value;
                    RaisePropertyChanged("TheDay");
                }
            }
        }

        private bool _Month2;
        public bool Month2
        {
            get { return _Month2; }
            set
            {
                if (Month2 != value)
                {
                    _Month2 = value;
                    RaisePropertyChanged("Month2");
                }
            }
        }


        private bool _Occurs_Once_Tm;
        public bool Occurs_Once_Tm
        {
            get { return _Occurs_Once_Tm; }
            set
            {
                if (Occurs_Once_Tm != value)
                {
                    _Occurs_Once_Tm = value;
                    RaisePropertyChanged("Occurs_Once_Tm");
                }
            }
        }

        private bool _Occurs_Every_Int;
        public bool Occurs_Every_Int
        {
            get { return _Occurs_Every_Int; }
            set
            {
                if (Occurs_Every_Int != value)
                {
                    _Occurs_Every_Int = value;
                    RaisePropertyChanged("Occurs_Every_Int");
                }
            }
        }

        private bool _Occurs_Every_Var;
        public bool Occurs_Every_Var
        {
            get { return _Occurs_Every_Var; }
            set
            {
                if (Occurs_Every_Var != value)
                {
                    _Occurs_Every_Var = value;
                    RaisePropertyChanged("Occurs_Every_Var");
                }
            }
        }

        private bool _Start_Tm;
        public bool Start_Tm
        {
            get { return _Start_Tm; }
            set
            {
                if (Start_Tm != value)
                {
                    _Start_Tm = value;
                    RaisePropertyChanged("Start_Tm");
                }
            }
        }

        private bool _End_Tm;
        public bool End_Tm
        {
            get { return _End_Tm; }
            set
            {
                if (End_Tm != value)
                {
                    _End_Tm = value;
                    RaisePropertyChanged("End_Tm");
                }
            }
        }


        private bool _End_Date;
        public bool End_Date
        {
            get { return _End_Date; }
            set
            {
                if (End_Date != value)
                {
                    _End_Date = value;
                    RaisePropertyChanged("End_Date");
                }
            }
        }

        #endregion

        #region ICollectionView         

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

        //#region Relay Commands Declaration
        //public RelayCommand<Boolean> DayChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<Boolean> TheChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<Boolean> OccurrsOnceAtChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<Boolean> OccursEveryChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<Boolean> EndDtChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //public RelayCommand<Boolean> NoEndDtChangedCommand
        //{
        //    get;
        //    private set;
        //}
        //#endregion

        #region Event Handler 
        #region Model Entity Updated for Daily Weekly Monthly Combo Box
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (sender.ToString() == "occurs")
            {
                FilterTest();
            }
        }
        private void FilterTest()
        {
            if (ScheduleEntity.occurs == "Daily")
            {
                Daily = "Visible";
                Weekly = "Collapsed";
                Monthly = "Collapsed";

                //ScheduleEntity.recurs_every = null;
                ScheduleEntity.wk_day = null;                
                TempWeekDayDictionary.Clear();
                ScheduleEntity.month_day = null;
                ScheduleEntity.month = null;
                ScheduleEntity.the_wk = null;
                ScheduleEntity.the_day = null;
            }
            else if (ScheduleEntity.occurs == "Weekly")
            {
                Daily = "Collapsed";
                Weekly = "Visible";
                Monthly = "Collapsed";

                //ScheduleEntity.recurs_every = null;
                ScheduleEntity.month_day = null;
                ScheduleEntity.month = null;
                ScheduleEntity.the_wk = null;
                ScheduleEntity.the_day = null;
            }

            else if (ScheduleEntity.occurs == "Monthly")
            {
                Daily = "Collapsed";
                Weekly = "Collapsed";
                Monthly = "Visible";

                ScheduleEntity.recurs_every = null;
                ScheduleEntity.wk_day = null;
                TempWeekDayDictionary.Clear();
            }
        }
        #endregion
        #region Model Entity Radio Button
        void ModelUpdated_Radio1(object sender, EventArgs e)
        {
            if (sender.ToString() == "day")
            {
                FilterTest1();
            }
        }
        private void FilterTest1()
        {
            if (ScheduleEntity.day == true)
            {
                MonthDay = true;
                Month1 = true;
                TheWk = false;
                TheDay = false;
                Month2 = false;

                ScheduleEntity.the_wk = null;
                ScheduleEntity.the_day = null;
                //ScheduleEntity.month = null;
            }
            else if (ScheduleEntity.the == true)
            {
                TheWk = true;
                TheDay = true;
                Month2 = true;
                MonthDay = false;
                Month1 = false;

                ScheduleEntity.month_day = null;
                //ScheduleEntity.month = null;
            }
        }

        void ModelUpdated_Radio2(object sender, EventArgs e)
        {
            if (sender.ToString() == "occurs_once_at")
            {
                FilterTest2();
            }
        }
        private void FilterTest2()
        {
            if (ScheduleEntity.occurs_once_at == true)
            {
                Occurs_Once_Tm = true;
                Occurs_Every_Int = false;
                Occurs_Every_Var = false;
                Start_Tm = false;
                End_Tm = false;

                ScheduleEntity.occurs_every_int = null;
                ScheduleEntity.occurs_every_var = null;
                ScheduleEntity.start_tm = null;
                ScheduleEntity.end_tm = null;

            }
            else if (ScheduleEntity.occurs_every == true )
            {
                Occurs_Once_Tm = false;
                Occurs_Every_Int = true;
                Occurs_Every_Var = true;
                Start_Tm = true;
                End_Tm = true;

                ScheduleEntity.occurs_once_tm = null;
            }
        }

        void ModelUpdated_Radio3(object sender, EventArgs e)
        {
            if (sender.ToString() == "end_dt" )
            {
                FilterTest3();
            }
        }
        private void FilterTest3()
        {
            if (ScheduleEntity.end_dt == true)
            {
                End_Date = true;                
            }
            else if (ScheduleEntity.no_end_dt == true)
            {
                End_Date = false;

                ScheduleEntity.end_date = null;
            }
        }
        #endregion
        #endregion

        #region Dictionaries
        private Dictionary<string, object> _WeekDayDictionary;
        public Dictionary<string, object> WeekDayDictionary
        {
            get { return _WeekDayDictionary; }
            set
            {
                if (_WeekDayDictionary != value)
                {
                    _WeekDayDictionary = value;
                    RaisePropertyChanged("WeekDayDictionary");
                }
            }
        }


        private Dictionary<string, object> _TempWeekDayDictionary;
        public Dictionary<string, object> TempWeekDayDictionary
        {
            get { return _TempWeekDayDictionary; }
            set
            {
                if (_TempWeekDayDictionary != value)
                {
                    _TempWeekDayDictionary = value;
                    RaisePropertyChanged("TempWeekDayDictionary");
                }
            }
        }

        private Dictionary<string, object> _SelectedItems;
        public Dictionary<string, object> SelectedItems
        {
            get
            {
                return _SelectedItems;
            }
            set
            {
                _SelectedItems = value;
                RaisePropertyChanged("SelectedItems");
            }
        }
        #endregion

        #region Constructor
        public COM_T004_VM() : base()
        {                  
            ScheduleEntity = new COM_T004();
            MC = new MultipleContext_COM_T004();
            MCTemp = new MultipleContext_COM_T004();
            MCTemp1 = new MultipleContext_COM_T004();

            TempWeekDayDictionary = new Dictionary<string, object>();
            WeekDayDictionary = new Dictionary<string, object>();

            WeekDayDictionary.Add("M,Tue,W,Thu,F,Sat,Sun", "All");
            WeekDayDictionary.Add("M", "Monday");
            WeekDayDictionary.Add("Tue", "Tuesday");
            WeekDayDictionary.Add("W", "Wednesday");
            WeekDayDictionary.Add("Thu", "Thursday");
            WeekDayDictionary.Add("F", "Friday");
            WeekDayDictionary.Add("Sat", "Saturday");
            WeekDayDictionary.Add("Sun", "Sunday");

            COM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            COM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Radio1);
            COM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Radio2);           
            COM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Radio3);

            //DayChangedCommand = new RelayCommand<bool>(DayChangeUpdate);
            //TheChangedCommand = new RelayCommand<bool>(TheChangeUpdate);
            //OccurrsOnceAtChangedCommand = new RelayCommand<bool>(OccursOnceAtChangeUpdate);
            //OccursEveryChangedCommand = new RelayCommand<bool>(OccursEveryChangeUpdate);
            //EndDtChangedCommand = new RelayCommand<bool>(EndDtChangeUpdate);
            //NoEndDtChangedCommand = new RelayCommand<bool>(NoEndDtChangeUpdate);

            LoadInitialData();
            SelectedItems = new Dictionary<string, object>();            
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_COM_T004>(MC, Request, "JobSchedular", "Communication", "LoadInitialData", 0, "");
                
                if(MC.ScheduleEntity.Count > 0)
                {
                    ScheduleEntity = MC.ScheduleEntity[0];
                }

                FilterTest();
                FilterTest1();
                FilterTest2();
                FilterTest3();

                DefaultValues();
                GetcheckedItemsInMultiCombo();

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

        private void GetcheckedItemsInMultiCombo()
        {

            if (ScheduleEntity.wk_day != null)
            {
                object temp;
                string week_day = ScheduleEntity.wk_day;
                List<string> strList = new List<string>();
                foreach (string s in week_day.Split(','))
                {
                    strList.Add(s);
                }

                if (strList != null)
                {
                    foreach (string k in strList)
                    {
                        if (WeekDayDictionary.ContainsKey(k))
                        {
                            temp = WeekDayDictionary[k];

                            TempWeekDayDictionary.Add(k, temp);
                        }
                    }
                }
            }

        }

        private void DefaultValues()
        {    
            if(ScheduleEntity.sch_no == null )
            {
                ScheduleEntity.location_Id = AppSessionState.location_Id;
                ScheduleEntity.comp_code = AppSessionState.comp_code;
                ScheduleEntity.add_by = AppSessionState.UserID;
                ScheduleEntity.edit_by = AppSessionState.UserID;                
                ScheduleEntity.active = true;
                ScheduleEntity.doc_cat = "DC";
                ScheduleEntity.doc_type = "DC";
                ScheduleEntity.user_source1 = AppSessionState.UserSource1;
                ScheduleEntity.user_source2 = AppSessionState.UserSource2;
                ScheduleEntity.start_date = DateTime.Now;
                ScheduleEntity.day = true;
                ScheduleEntity.the = false;
                ScheduleEntity.occurs_once_at = true;
                ScheduleEntity.occurs_every = false;
                ScheduleEntity.end_dt = true;
                ScheduleEntity.no_end_dt = false;
                Daily = "Collapsed";
                Weekly = "Collapsed";
                Monthly = "Collapsed";
            }       
            

            //ScheduleEntity.ButtonDayIsChecked = true;
            //if (ScheduleEntity.ButtonDayIsChecked == true)
            //{
            //    ScheduleEntity.doc_type = "DC";
            //    DayChangeUpdate(true);
            //}

            //ScheduleEntity.ButtonOccurrsOnceAtIsChecked = true;
            //if (ScheduleEntity.ButtonOccurrsOnceAtIsChecked == true)
            //{
            //    ScheduleEntity.doc_type = "DC";
            //    OccursOnceAtChangeUpdate(true);
            //}

            //ScheduleEntity.ButtonEndDtIsChecked = true;
            //if (ScheduleEntity.ButtonEndDtIsChecked == true)
            //{
            //    ScheduleEntity.doc_type = "DC";
            //    EndDtChangeUpdate(true);
            //}
                       
        }       
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (ScheduleEntity != null && MC.ScheduleEntity.Count > 0)
                {
                    //ScheduleEntity.Clear();
                    //MC.ScheduleEntity = (List<COM_T004>)obj.XMLToObject(ScheduleEntity, MC.ScheduleEntity);

                    ScheduleEntity = MC.ScheduleEntity[0];
                }
                else
                {
                    MC.ScheduleEntity = new List<COM_T004>();
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
        private bool Validation()
        {
            

            return true;
        }       
        //private void DayChangeUpdate(bool check)
        //{
        //    if (ScheduleEntity.day == true)
        //    {
                              
        //    }
        //}
        //private void TheChangeUpdate(bool check)
        //{
        //    if (ScheduleEntity.the == true)
        //    {
                
        //    }
        //}
        //private void OccursOnceAtChangeUpdate(bool check)
        //{
        //    if (ScheduleEntity.occurs_once_at == true)
        //    {                
            
        //    }
        //}
        //private void OccursEveryChangeUpdate(bool check)
        //{
        //    if (ScheduleEntity.occurs_every == true)
        //    {
               
        //    }
        //}
        //private void EndDtChangeUpdate(bool check)
        //{
        //    if (ScheduleEntity.ButtonEndDtIsChecked == true)
        //    {
           
        //    }
        //}
        //private void NoEndDtChangeUpdate(bool check)
        //{
        //    if (ScheduleEntity.no_end_dt == true)
        //    {
                
        //    }
        //}

        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<COM_T004> result)
        {
            try
            {               
                if (Validation() == true)
                {
                    this.ScheduleEntity.EndEdit();

                    string xyz = string.Join(",", TempWeekDayDictionary.Select(kvp => kvp.Key));

                    ScheduleEntity.wk_day = xyz;
                    ScheduleEntity = repository.SaveWithReturnDomainObject<COM_T004>(ScheduleEntity, "JobSchedular", "Communication");

                    if (ScheduleEntity != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
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
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnCreateAction(InquiryActionResult<COM_T004> result)
        {
            isNewRecord = true;           
            ScheduleEntity = new COM_T004();
            DefaultValues();
            TempWeekDayDictionary.Clear();
            WeekDayDictionary.Clear();
        }
        protected override void OnRemoveAction(InquiryActionResult<COM_T004> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<COM_T004> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<COM_T004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<COM_T004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<COM_T004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<COM_T004> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<COM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<COM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<COM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<COM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<COM_T004> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
