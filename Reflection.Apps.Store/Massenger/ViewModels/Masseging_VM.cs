using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Reflection.Apps.Store.Massenger.ViewModels
{
    public class Masseging_VM : WindowViewModel<COM_T002>, INotifyPropertyChanged
    {
        WebServiceRepository<List<Msg_LoadAll_Result>> repository = new WebServiceRepository<List<Msg_LoadAll_Result>>();
        WebServiceRepository<MultipleContext_Masseging> repositoryCM = new WebServiceRepository<MultipleContext_Masseging>();
        WebServiceRepository<Msg_LoadAll_Result> repositoryC = new WebServiceRepository<Msg_LoadAll_Result>();
        string is_Selected = "";
        #region "         "
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
        MultipleContext_Masseging _MC = new MultipleContext_Masseging();
        public MultipleContext_Masseging MC
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

        public ObservableCollection<Msg_LoadAll_Result> _FilteredMassegeList = new ObservableCollection<Msg_LoadAll_Result>();
        public ObservableCollection<Msg_LoadAll_Result> FilteredMassegeList
        {
            get
            {
                return _FilteredMassegeList;
            }
            set
            {
                if (_FilteredMassegeList != value)
                {
                    _FilteredMassegeList = value;
                    RaisePropertyChanged("FilteredMassegeList");
                }
            }
        }
        public List<ADM_M024_PopUp_FollowerListToadd> _FollowerUserListToadd=new List<ADM_M024_PopUp_FollowerListToadd>();
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

        public List<ADM_M024_PopUp_FollowerListToadd> _FollowerPartyListToadd=new List<ADM_M024_PopUp_FollowerListToadd>();
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
        private COM_T002_A _Selected_ComposeMessage = new COM_T002_A();
        public COM_T002_A Selected_ComposeMessage
        {
            get { return _Selected_ComposeMessage; }
            set
            {
                if (_Selected_ComposeMessage != value)
                {
                    _Selected_ComposeMessage = value;

                    RaisePropertyChanged("Selected_ComposeMessage");
                }
            }
        }
        private COM_T002_A _Selected_ReplyMessage = new COM_T002_A();
        public COM_T002_A Selected_ReplyMessage
        {
            get { return _Selected_ReplyMessage; }
            set
            {
                if (_Selected_ReplyMessage != value)
                {
                    _Selected_ReplyMessage = value;

                    RaisePropertyChanged("Selected_ReplyMessage");
                }
            }
        }
    
        private List<COM_T002_A> _Selected_Temp = new List<COM_T002_A>();
        public List<COM_T002_A> Selected_Temp
        {
            get { return _Selected_Temp; }
            set
            {
                if (_Selected_Temp != value)
                {
                    _Selected_Temp = value;

                    RaisePropertyChanged("Selected_Temp");
                }
            }
        }       

        #endregion

        #region "Relay Command"
        public RelayCommand InboxCommand{ get; private set; }
        public RelayCommand TomeCommand { get; private set; }
        public RelayCommand ArchiveCommand{ get; private set; }
        public RelayCommand CommandToComposeMassege { get; private set; }
        public RelayCommand<int> MarkStarred { get; private set; }
        public RelayCommand<int> MarkInbox { get; private set; }
        public RelayCommand<int> replyCommand { get; private set; }

        #endregion
        public Masseging_VM() : base()
        {
            FilteredMassegeList = new ObservableCollection<Msg_LoadAll_Result>();
            MC.MessagesList = new ObservableCollection<Msg_LoadAll_Result>();
            FollowerUserListToadd = new List<ADM_M024_PopUp_FollowerListToadd>();
            FollowerPartyListToadd = new List<ADM_M024_PopUp_FollowerListToadd>();
            Selected_ComposeMessage = new COM_T002_A();
            Selected_ReplyMessage = new COM_T002_A();

            InboxCommand = new RelayCommand(() => InboxData());
            TomeCommand = new RelayCommand(() => TomeData());
            ArchiveCommand = new RelayCommand(() => ArchiveData());
            CommandToComposeMassege = new RelayCommand(()=>ComposeMassege());
            MarkStarred = new RelayCommand<int>( data => { AddToDoList(data); } );
            MarkInbox = new RelayCommand<int>(data => { AddToInbox(data); });
            replyCommand = new RelayCommand<int>(data => { sendReply(data); });

            LoadInitialData();            
            
         }      
        private void InboxData()
        {
            ObjectSerializationService objSerialization = new ObjectSerializationService();   
            MultipleContext_Masseging MCTemp = new MultipleContext_Masseging();
            Msg_LoadAll_Result obj = new Msg_LoadAll_Result();

            obj.follower_id = AppSessionState.UserID;
            string str = objSerialization.ObjectToXML(obj);
            MCTemp = repositoryCM.GetDataWithReturnDomainObject<MultipleContext_Masseging>(MCTemp, str, "Masseging", "Communication", "LoadInboxDetails", 0, "");
            //select distinct messages
            var distinctItems = MCTemp.MessagesList.GroupBy(x => x.id).Select(y => y.First());
            MCTemp.MessagesList = new ObservableCollection<Msg_LoadAll_Result>(distinctItems);

            var result = MCTemp.MessagesList.ToList();
            result.ForEach(x => x.msg_read = false);            
            FilteredMassegeList = new ObservableCollection<Msg_LoadAll_Result>(result);
            is_Selected = "inbox";
        }
        private void ArchiveData()
        {
            ObjectSerializationService objSerialization = new ObjectSerializationService();
            MultipleContext_Masseging MCTemp = new MultipleContext_Masseging();
            Msg_LoadAll_Result obj = new Msg_LoadAll_Result();

            obj.follower_id = AppSessionState.UserID;
            string str = objSerialization.ObjectToXML(obj);
            MCTemp = repositoryCM.GetDataWithReturnDomainObject<MultipleContext_Masseging>(MCTemp, str, "Masseging", "Communication", "LoadArchiveDetails", 0, "");
            //select distinct messages
            var distinctItems = MCTemp.MessagesList.GroupBy(x => x.id).Select(y => y.First());
            MCTemp.MessagesList = new ObservableCollection<Msg_LoadAll_Result>(distinctItems);

            FilteredMassegeList = (ObservableCollection<Msg_LoadAll_Result>)MCTemp.MessagesList;
            is_Selected = "archive";
        }
        private void TomeData()
        {
            ObjectSerializationService objSerialization = new ObjectSerializationService();
            MultipleContext_Masseging MCTemp = new MultipleContext_Masseging();
            Msg_LoadAll_Result obj = new Msg_LoadAll_Result();

            obj.follower_id = AppSessionState.UserID;
            string str = objSerialization.ObjectToXML(obj);
            MCTemp = repositoryCM.GetDataWithReturnDomainObject<MultipleContext_Masseging>(MCTemp, str, "Masseging", "Communication", "LoadTomeDetails", 0, "");

            var result = MCTemp.MessagesList.ToList();
            result.ForEach(x => x.msg_read = false);
            FilteredMassegeList = new ObservableCollection<Msg_LoadAll_Result>(result);
            is_Selected = "tome";
        }
        private void LoadInitialData()
        {
            try
            {
                ObjectSerializationService objSerialization = new ObjectSerializationService();   
                Msg_LoadAll_Result obj = new Msg_LoadAll_Result();

                obj.follower_id =AppSessionState.UserID ;                
                string str = objSerialization.ObjectToXML(obj);

                MC = repositoryCM.GetDataWithReturnDomainObject<MultipleContext_Masseging>(MC, str, "Masseging", "Communication", "LoadAll", 0, "");
                var result = MC.MessagesList.ToList();
                result.ForEach(x => x.msg_read = false);
                FilteredMassegeList = new ObservableCollection<Msg_LoadAll_Result>(result);

                if(MC.FollowerListToadd!=null)
                { 
                    var temp_data1 = (from data1 in MC.FollowerListToadd where data1.type == "user" select data1).ToList();                
                    FollowerUserListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data1.ToList();
                    var temp_data2 = (from data1 in MC.FollowerListToadd where data1.type == "party" select data1).ToList();
                    FollowerPartyListToadd = (List<ADM_M024_PopUp_FollowerListToadd>)temp_data2.ToList();

                    userList = new Dictionary<string, object>();
                    userList.Clear();
                    if (FollowerUserListToadd != null)
                    { userList = FollowerUserListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }

                    partyList = new Dictionary<string, object>();
                    partyList.Clear();
                    if (FollowerPartyListToadd != null)
                    { partyList = FollowerPartyListToadd.ToDictionary(X => X.id.ToString(), X => (object)X.name); }
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
        private void ComposeMassege()
        {
            try
            {              
                    if ((Selected_ComposeMessage.user_id != null || Selected_ComposeMessage.party_id != null) && (Selected_ComposeMessage.doc_id != null || Selected_ComposeMessage.doc_id != 0))
                    {                       
                        Selected_ComposeMessage.msg_category = "Email";
                        Selected_ComposeMessage.author_id = AppSessionState.UserID;
                        Selected_ComposeMessage.add_by = AppSessionState.UserID.ToString();
                        MultipleContext_Masseging MCtemp = new MultipleContext_Masseging();
                        Selected_Temp = new List<COM_T002_A>();
                        MCtemp.compose_or_reply = "compose";
                        //Selected_ComposeMessage.user_id = Selected_ComposeMessage.user_id + ',' + AppSessionState.UserID;
                        Selected_Temp.Add(Selected_ComposeMessage);
                        MCtemp.Composed_or_RplyMassege = Selected_Temp;                        
                        MCtemp = repositoryCM.SaveWithReturnDomainObject<MultipleContext_Masseging>(MCtemp, "Masseging", "Communication");
                        getMailstring(Selected_ComposeMessage);
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
        private void getMailstring(COM_T002_A obj)
        {
            int i = 0;
            string str_mail = "";
            if (obj.user_id != "" && obj.user_id != null)
            {
                foreach (var temp in obj.user_id.Split(','))
                {
                    var mail = FollowerUserListToadd.Where(x => x.id.ToString() == temp).FirstOrDefault();
                    if ((str_mail == "") && (mail.email_id != null && mail.email_id != "")) { str_mail = mail.email_id; }
                    else { if (mail.email_id != null && mail.email_id != "") { str_mail = str_mail + "," + mail.email_id; } }
                    i++;
                }
                if (obj.party_id != "" && obj.party_id != null)
                {
                    foreach (var temp in obj.party_id.Split(','))
                    {
                        var mail = FollowerPartyListToadd.Where(x => x.id.ToString() == temp).FirstOrDefault();
                        if ((str_mail == "") && (mail.email_id != null && mail.email_id != "")) { str_mail = mail.email_id; }
                        else { if (mail.email_id != null && mail.email_id != "") { str_mail = str_mail + "," + mail.email_id; } }
                    }
                }
            }
            else
            {
                if (obj.party_id != "" && obj.party_id != null)
                {
                    foreach (var temp in obj.party_id.Split(','))
                    {
                        var mail = FollowerPartyListToadd.Where(x => x.id.ToString() == temp).FirstOrDefault();
                        if ((str_mail) == "" && (mail.email_id != null && mail.email_id != "")) { str_mail = mail.email_id; }
                        else { if (mail.email_id != null && mail.email_id != "") { str_mail = str_mail + "," + mail.email_id; } }
                    }
                }
            }
            //string str_mail = getMailstring();
            //str_mail = "";
            //Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, "gcharushila@gmail.com", str_mail, str_mail, "Good Morning", "Hello", ""); 
            Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, AppSessionState.MailAccount.MailID, str_mail, str_mail, obj.subject, obj.msg_body, "");
        }
        private void AddToDoList(int msgid)
        {
            if (msgid != 0)
            {
                Msg_LoadAll_Result msg = new Msg_LoadAll_Result();
                var data = (from d in FilteredMassegeList  where d.id == msgid select d).FirstOrDefault();
                var index = FilteredMassegeList.IndexOf(FilteredMassegeList.Where(X => X.id == msgid).FirstOrDefault());
                msg = (Msg_LoadAll_Result)data;
                msg.follower_id = AppSessionState.UserID;
                msg.starred = !(msg.starred);

                msg = repositoryC.UpdateWithReturnDomainObject<Msg_LoadAll_Result>(msg, "Masseging", "Communication");
                if(msg!=null)
                {
                    Msg_LoadAll_Result remove_msg = new Msg_LoadAll_Result();
                    remove_msg = FilteredMassegeList[index];
                    if (is_Selected == "inbox" || is_Selected == "tome")
                    {
                        FilteredMassegeList.Remove(remove_msg);
                    }
                }               
            }
        }
        private void AddToInbox(int msgid)
        {
            if (msgid != 0)
            {
                Msg_LoadAll_Result msg = new Msg_LoadAll_Result();

                var data = (from d in FilteredMassegeList where d.id == msgid select d).FirstOrDefault();
                var index = FilteredMassegeList.IndexOf(FilteredMassegeList.Where(X => X.id == msgid).FirstOrDefault());
                msg = (Msg_LoadAll_Result)data;
                msg.follower_id = AppSessionState.UserID;               
                msg.msg_read = !(msg.msg_read);                
                msg = repositoryC.UpdateWithReturnDomainObject<Msg_LoadAll_Result>(msg, "Masseging", "Communication");
                if (msg != null)
                {

                    Msg_LoadAll_Result remove_msg = new Msg_LoadAll_Result();
                    remove_msg = FilteredMassegeList[index];

                    //ObservableCollection<Msg_LoadAll_Result> temp = new ObservableCollection<Msg_LoadAll_Result>();
                    //FilteredMassegeList.Remove(remove_msg);
                    //temp = (ObservableCollection<Msg_LoadAll_Result>)FilteredMassegeList;
                    //FilteredMassegeList = temp;
                    if (is_Selected == "inbox" || is_Selected == "tome")
                    {
                        FilteredMassegeList.Remove(remove_msg);
                    }                    
                }
                //FilteredMassegeList[index].msg_read = msg.msg_read;
            }
        }
        private string AddExistingFollower(COM_T002_A obj,string  existing_users)
        {
            List<string> arr_user = new List<string>();
            List<string> arr_user_exist = new List<string>();
            string str = "";
              if ((obj.user_id != null))
                {
                    if ((obj.user_id != ""))
                    {
                        arr_user = obj.user_id.Split(',').ToList();
                    }
                }
              if ((existing_users != null))
              {
                  if ((existing_users != ""))
                  {
                      arr_user_exist = existing_users.Split(',').ToList();
                  }
              }
              if (arr_user_exist != null)
              {
                  foreach (var temp in arr_user)
                  {
                      foreach (var exist in arr_user_exist)
                      {
                          if (exist != temp)
                          {
                              str = temp + "," + str;
                              break;
                          }
                      }
                  }
              }
              if (existing_users=="")
              {
                 // obj.user_id = arr_user.ToString();
              }
              else
              {
                  obj.user_id = str + existing_users;
              }
              
            if (obj.user_id.Remove(obj.user_id.Length - 1) == "," || obj.user_id!="")
            {
                obj.user_id = Selected_ReplyMessage.user_id.Remove(obj.user_id.Length - 1);
            }
            return obj.user_id;
        }
        private void sendReply(int msgid)
        {
            if ((Selected_ReplyMessage.user_id != null || Selected_ReplyMessage.party_id != null) && (Selected_ReplyMessage.doc_id != null || Selected_ReplyMessage.doc_id != 0))
            {

                Selected_ReplyMessage.user_id = AddExistingFollower(Selected_ReplyMessage, (from d in FilteredMassegeList where d.id == msgid select d.sent_to_id).FirstOrDefault());
                Selected_ReplyMessage.msg_category = "Email";
                Selected_ReplyMessage.author_id = AppSessionState.UserID;
                Selected_ReplyMessage.add_by = AppSessionState.UserID.ToString();
                Selected_ReplyMessage.doc_id = (from d in FilteredMassegeList where d.id == msgid select d.doc_id).FirstOrDefault();
                Selected_ReplyMessage.doc_name = (from d in FilteredMassegeList where d.id == msgid select d.doc_name).FirstOrDefault();
                Selected_ReplyMessage.doc_type = (from d in FilteredMassegeList where d.id == msgid select d.doc_type).FirstOrDefault();

                MultipleContext_Masseging MCtemp = new MultipleContext_Masseging();
                Selected_Temp = new List<COM_T002_A>();
                MCtemp.compose_or_reply = "reply";
                //Selected_ComposeMessage.user_id = Selected_ComposeMessage.user_id + ',' + AppSessionState.UserID;
                Selected_Temp.Add(Selected_ReplyMessage);
                MCtemp.Composed_or_RplyMassege = Selected_Temp;
                MCtemp = repositoryCM.SaveWithReturnDomainObject<MultipleContext_Masseging>(MCtemp, "Masseging", "Communication");
                getMailstring(Selected_ReplyMessage);
            }       
        }

        #region Methods

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<COM_T002> result)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
              
            }

        }
        protected override void OnCreateAction(InquiryActionResult<COM_T002> result)
        {
        }
        protected override void OnRemoveAction(InquiryActionResult<COM_T002> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<COM_T002> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<COM_T002> result)
        {
            
        }
        protected override void OnFlipAction(InquiryActionResult<COM_T002> result)
        {
          
        }
        protected override void OnHelpAction(InquiryActionResult<COM_T002> result)
        {
        
        }

        protected override void OnPrintAction(InquiryActionResult<COM_T002> result)
        {
           
        }

        protected override void OnRefreshCommand(InquiryActionResult<COM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<COM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<COM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<COM_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<COM_T002> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
