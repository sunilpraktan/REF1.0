using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace Reflection.Presentation.Services.ViewModel
{
    public class COM_T002_VM : WorkspaceViewModel<COM_T002_A>, INotifyPropertyChanged
    {
       
        WebServiceRepository<COM_T002_A> repository_M = new WebServiceRepository<COM_T002_A>();
        WebServiceRepository<Multiple_Complex_COM_T002> repository_MC = new WebServiceRepository<Multiple_Complex_COM_T002>();
        private string _filterFollower;
        private string _follower_cnt;
        public string follower_cnt
        {
            get { return _follower_cnt; }
            set { 
                    if(_follower_cnt != value )
                    {
                        _follower_cnt = value;
                        RaisePropertyChanged("follower_cnt");
                    }
                }
        }
        private int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set
            {
                if (_ParentID != value)
                {
                    _ParentID = value;
                    RaisePropertyChanged("ParentID");
                }
            }
        }
        private string _party_id;
        public string party_id { get { return _party_id; } set { _party_id = value; RaisePropertyChanged("party_id"); } }
        private string _user_id;
        public string user_id { get { return _user_id; } set { _user_id = value; RaisePropertyChanged("user_id"); } }

        private COM_T002_A _SelectedMessage = new COM_T002_A();
        public COM_T002_A SelectedMessage
        {
            get { return _SelectedMessage; }
            set
            {
                if (_SelectedMessage != value)
                {
                    _SelectedMessage = value;

                    RaisePropertyChanged("SelectedMessage");
                }
            }
        }

        private COM_T002_A _Selected_NewFollowerMessage = new COM_T002_A();
        public COM_T002_A Selected_NewFollowerMessage
        {
            get { return _Selected_NewFollowerMessage; }
            set
            {
                if (_Selected_NewFollowerMessage != value)
                {
                    _Selected_NewFollowerMessage = value;

                    RaisePropertyChanged("Selected_NewFollowerMessage");
                }
            }
        }

        Multiple_Complex_COM_T002 MC = new Multiple_Complex_COM_T002();

        #region "Dictionary"

        private Dictionary<string, object> _userList;
        private Dictionary<string, object> _selected_userList;
        public Dictionary<string, object> userList
        {
            get { return _userList; }
            set
            {
                if (_userList != value)
                {
                    _userList = value;
                    RaisePropertyChanged("userList");
                }
            }
        }
        public Dictionary<string, object> selected_userList
        {
            get
            {
                return _selected_userList;
            }
            set
            {
                _selected_userList = value;
                NotifyPropertyChanged("selected_userList");
            }
        }

        private Dictionary<string, object> _partyList;
        private Dictionary<string, object> _selected_partyList;
        public Dictionary<string, object> partyList
        {
            get { return _partyList; }
            set
            {
                if (_partyList != value)
                {
                    _partyList = value;
                    RaisePropertyChanged("partyList");
                }
            }
        }
        public Dictionary<string, object> selected_partyList
        {
            get
            {
                return _selected_partyList;
            }
            set
            {
                _selected_partyList = value;
                NotifyPropertyChanged("selected_partyList");
            }
        }

        #endregion      
      
        #region "List and ObservableCollection"

        private List<COM_T002_A> _Selected_NewFollowerMessage1 = new List<COM_T002_A>();
        public List<COM_T002_A> Selected_NewFollowerMessage1
        {
            get { return _Selected_NewFollowerMessage1; }
            set
            {
                if (_Selected_NewFollowerMessage1 != value)
                {
                    _Selected_NewFollowerMessage1 = value;

                    RaisePropertyChanged("Selected_NewFollowerMessage1");
                }
            }
        }


        private List<ADM_M024_PopUp_FollowerListToadd> _FollowerUserListToadd;
        public List<ADM_M024_PopUp_FollowerListToadd> FollowerUserListToadd
        {
            get { return _FollowerUserListToadd; }
            set
            {
                if (_FollowerUserListToadd != value)
                {
                    _FollowerUserListToadd = value;
                    RaisePropertyChanged("FollowerUserListToadd");
                }
            }
        }


        private List<ADM_M024_PopUp_FollowerListToadd> _FollowerPartyListToadd;
        public List<ADM_M024_PopUp_FollowerListToadd> FollowerPartyListToadd
        {
            get { return _FollowerPartyListToadd; }
            set
            {
                if (_FollowerPartyListToadd != value)
                {
                    _FollowerPartyListToadd = value;
                    RaisePropertyChanged("FollowerPartyListToadd");
                }
            }
        }

        public List<COM_T002_A> MessageData { get; set; }


        //private ObservableCollection<COM_T002_A_PopUp> _docMessageData;
        //public ObservableCollection<COM_T002_A_PopUp> docMessageData
        //{
        //    get { return _docMessageData; }
        //    set { _docMessageData = value; RaisePropertyChanged("docMessageData"); }
        //}


        //private ObservableCollection<COM_T002_B_PopUp> _docFollowersData;
        //public ObservableCollection<COM_T002_B_PopUp> docFollowersData
        //{
        //    get { return _docFollowersData; }
        //    set { _docFollowersData = value; RaisePropertyChanged("docFollowersData"); }
        //}

        #endregion

        #region       

        private ICollectionView _MessageCollection;
        public ICollectionView MessageCollection
        {
            get { return _MessageCollection; }
            set { _MessageCollection = value; RaisePropertyChanged("MessageCollection"); }
        }

        private ICollectionView _FollowerCollection;
        public ICollectionView FollowerCollection
        {
            get { return _FollowerCollection; }
            set
            {
                if (_FollowerCollection != value)
                {
                    _FollowerCollection = value;
                    RaisePropertyChanged("FollowerCollection");
                }
            }
        }

        #endregion

        #region "RelayCommand"

        public RelayCommand<int> LoadData
        {
            get;
            private set;
        }
        public RelayCommand<object> SendMessage { get; private set; }
        public RelayCommand<object> CommandToAddFollower { get; private set; }

        #endregion       
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            //ValidateAsync();
        }

        public COM_T002_VM() : base()
        {
            follower_cnt = "0 Follower";
            //docFollowersData = new ObservableCollection<COM_T002_B_PopUp>();
            //docMessageData = new ObservableCollection<COM_T002_A_PopUp>();
            SelectedMessage = new COM_T002_A();
            Selected_NewFollowerMessage=new COM_T002_A();
            FollowerUserListToadd = new List<ADM_M024_PopUp_FollowerListToadd>();
            FollowerPartyListToadd = new List<ADM_M024_PopUp_FollowerListToadd>();
            SendMessage = new RelayCommand<object>(
                doc_id =>
                {
                    if (doc_id == null)
                    { return; }
                    SendMessageData(doc_id);
                });
            CommandToAddFollower = new RelayCommand<object>(
                doc_id=>
                {
                    if(doc_id == null)
                    { return; }
                    AddSelecdtedFollower(doc_id);
                });

            LoadData = new RelayCommand<int>(
              id =>
              {
                  if (id == null)
                  {
                      return;
                  }
                  CheckParentID(id);
              });

            GetMessageData();
            GetFollowersData();

            //userList = new Dictionary<string, object>();
            //selected_userList = new Dictionary<string, object>();
            //userList.Clear();
            //if (FollowerUserListToadd != null)
            //{ userList = FollowerUserListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }

            //partyList = new Dictionary<string, object>();
            //selected_partyList = new Dictionary<string, object>();
            //partyList.Clear();
            //if (FollowerPartyListToadd != null)
            //{ partyList = FollowerPartyListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }
        }
        private void CheckParentID(int id)
        {
            
        }

        #region "User Defined Function"      
        private void GetMessageData()
        {
            MC = repository_MC.GetDataWithReturnDomainObject<Multiple_Complex_COM_T002>(MC, "COM_T002_A_Data", "LoggingControl", "LoggingControl", "", 0, "");

            //var temp_data = (from data in MC.FollowerListToadd where data.type == "user" select data).ToList();
            //FollowerUserListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data.ToList();
            //var temp_data1 = (from data in MC.FollowerListToadd where data.type == "party" select data).ToList();
            //FollowerPartyListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data1.ToList();

            //docMessageData = MC.documentMessagesList;
            //docFollowersData = MC.documentFollowersList;

           // follower_cnt = docFollowersData.Count().ToString() + " Follower";
        }
        private void GetFollowersData()
        {
            //FollowersData = new ObservableCollection<GetFollowers_Result>();
            //ObjectSerializationService objSer = new ObjectSerializationService();
            //SRTestWCF.Service1Client proxy = new Service1Client();
            //string strMessage = proxy.GetData("1", "Followers");
            //FollowersData = (ObservableCollection<GetFollowers_Result>)objSer.XMLToObject(strMessage, FollowersData);
        }
        private void SendMessageData(object doc_data)
        {
            List<string> str = doc_data.ToString().Split('/').ToList<string>();
            try
            {
                SelectedMessage.doc_id = Convert.ToInt32(str[0]);
                SelectedMessage.doc_type = str[1];
                SelectedMessage.doc_name = str[2];

                SelectedMessage.msg_category = "Comment";
                //Pending change : datatype of author_id to string
                //SelectedMessage.author_id = AppSessionState.UserID;
                if ((SelectedMessage.user_id != null || SelectedMessage.party_id != null) && (SelectedMessage.doc_id != null || SelectedMessage.doc_id != 0))
                {
                   // SelectedMessage = repository_M.SaveWithReturnDomainObject<COM_T002_A>(SelectedMessage, "LoggingControl", "LoggingControl");

                    Multiple_Complex_COM_T002 MCTemp = new Multiple_Complex_COM_T002();

                    Selected_NewFollowerMessage1.Add(SelectedMessage);
                    MCTemp.followersMessagesList = Selected_NewFollowerMessage1;
                    
                    MCTemp = repository_MC.SaveWithReturnDomainObject<Multiple_Complex_COM_T002>(MCTemp, "LoggingControl", "LoggingControl");

                    foreach (var item in MCTemp.documentFollowersList)
                    {
                        MC.documentFollowersList.Add(item);
                    }         

                    
                }
                //SelectedMessage = new COM_T002_A();
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
        private void AddSelecdtedFollower(object doc_data)
        {    
            List<string> str = doc_data.ToString().Split('/').ToList<string>();
            try
            {
                Selected_NewFollowerMessage.doc_id = Convert.ToInt32(str[0]);
                Selected_NewFollowerMessage.doc_type = str[1];
                Selected_NewFollowerMessage.doc_name = str[2];

                Selected_NewFollowerMessage.msg_category = "Email";
                //Pending change : datatype of author_id to string
                // Selected_NewFollowerMessage.author_id = AppSessionState.UserID;   

                if ((Selected_NewFollowerMessage.user_id != null || Selected_NewFollowerMessage.party_id != null) && (Selected_NewFollowerMessage.doc_id!=null || Selected_NewFollowerMessage.doc_id!=0))
                {
                    Multiple_Complex_COM_T002 MCTemp = new Multiple_Complex_COM_T002();

                    Selected_NewFollowerMessage1.Add(Selected_NewFollowerMessage);
                    MCTemp.followersMessagesList = Selected_NewFollowerMessage1;

                    MCTemp = repository_MC.SaveWithReturnDomainObject<Multiple_Complex_COM_T002>(MCTemp, "LoggingControl", "LoggingControl");

                    foreach (var item in MCTemp.documentFollowersList)
                    {
                        MC.documentFollowersList.Add(item);
                    }                  
                }
                   //follower_cnt = docFollowersData.Count().ToString() + " Follower";
                    Selected_NewFollowerMessage = new COM_T002_A();                
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

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<COM_T002_A> result)
        {
            //try
            //{
            //    this.SelectedACC_T001_A.EndEdit();
            //    SelectedACC_T001_A.add_by = AppSessionState.UserID;

            //    ObjectSerializationService obj = new ObjectSerializationService();
            //    SelectedACC_T001_A.xdoc_ACC_T001_A = obj.ObjectToXML(dginvMaster);


            //    if (blNew == true)
            //    {
            //        SelectedACC_T001_A = repository.SaveWithReturnDomainObject<ACC_T001>(SelectedACC_T001_A, "AutoSalesInvoice", "CRM");
            //        SelectedList.Add(SelectedACC_T001_A);

            //        blNew = false;
            //    }
            //    else if (blNew == false)
            //    {
            //        SelectedACC_T001_A = repository.UpdateWithReturnDomainObject<ACC_T001>(SelectedACC_T001_A, "AutoSalesInvoice", "CRM");
            //    }
            //    if (SelectedACC_T001_A.xdoc_ACC_T001_A != null)
            //    {
            //        MC.InvoiceDetails = (ObservableCollection<ACC_T001B>)new ObjectSerializationService().XMLToObject(SelectedACC_T001_A.xdoc_ACC_T001_A, MC.InvoiceDetails);
            //        dginvItems = (ObservableCollection<ACC_T001B>)obj.XMLToObject(SelectedACC_T001_A.xdoc_ACC_T001_A, dginvItems);
            //    }
            //    else
            //    {
            //        MC.InvoiceDetails = new ObservableCollection<ACC_T001B>();
            //        dginvItems = new ObservableCollection<ACC_T001B>();
            //    }

            //    _dataGridCollection.Refresh();
            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();
            //}
        }
        protected override void OnCreateAction(InquiryActionResult<COM_T002_A> result)
        {
            //blNew = true;
            //SelectedACC_T001_A = new ACC_T001();
            //MC.InvoiceMaster = new ObservableCollection<ACC_T001>();
            //dginvMaster = new ObservableCollection<ACC_T001>();
            //MC.InvoiceDetails = new ObservableCollection<ACC_T001B>();
            //dginvItems = new ObservableCollection<ACC_T001B>();
            //_dataGridCollection.Refresh();
            //foreach (var listItem in MC.itemMaster.ToList())
            //    listItem.Select = false;
            //SelectedACC_T001_A.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<COM_T002_A> result)
        {
            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //showMessageService.ButtonSetup = DialogButton.Ok;
            //showMessageService.Caption = "Delete Changes";
            //showMessageService.Text =
            //    String.Format(
            //        "This record will be Deleted forever '{0}'",
            //            this.Title);

            //if (showMessageService.ShowMessage() == DialogResult.Ok)
            //{
            //    this.SelectedACC_T001_A.EndEdit();
            //    string response = repository.Delete(SelectedACC_T001_A.id, "PurchaseOrder", "CRM");
            //    SelectedList.Remove(SelectedACC_T001_A);
            //    SelectedACC_T001_A = new ACC_T001();
            //    dginvItems = new ObservableCollection<ACC_T001B>();
            //    _dataGridCollection.Refresh();
            //}
        }
        protected override void OnDiscardAction(InquiryActionResult<COM_T002_A> result)
        {
            //SelectedACC_T001_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<COM_T002_A> result)
        {
            //SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<COM_T002_A> result)
        {
            //SelectedList = SelectedList;
            //SelectedACC_T001_A = SelectedACC_T001_A;
        }
        protected override void OnHelpAction(InquiryActionResult<COM_T002_A> result)
        {
            //SelectedList = SelectedList;
            //SelectedACC_T001_A = SelectedACC_T001_A;
        }
        protected override void OnPrintAction(InquiryActionResult<COM_T002_A> result)
        {
            //SelectedList = SelectedList;
            //SelectedACC_T001_A = SelectedACC_T001_A;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<COM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<COM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<COM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<COM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<COM_T002_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region
        public string FilterFollower
        {
            get { return _filterFollower; }
            set
            {
                _filterFollower = value;
                RaisePropertyChanged("FilterFollower");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_FollowerCollection != null)
            {
                _FollowerCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M024_PopUp_FollowerListToadd;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterFollower))
                {
                    return (data.name != null && data.name.ToString().ToLower().Contains(_filterFollower.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}

