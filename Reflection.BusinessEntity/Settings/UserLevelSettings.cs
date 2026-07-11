using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Settings
{
    public class UserLevelSettings : ObjectBase
    {
        
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _UserId;
        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; RaisePropertyChanged("UserId"); }
        }

        private string _theme_code;
        public string theme_code
        {
            get { return _theme_code; }
            set { _theme_code = value; RaisePropertyChanged("theme_code"); }
        }

        private string _theme_name;
        public string theme_name
        {
            get { return _theme_name; }
            set { _theme_name = value; RaisePropertyChanged("theme_name"); }
        }

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        private byte[] _desktop_file;
        public byte[] desktop_file
        {
            get { return _desktop_file; }
            set { _desktop_file = value; RaisePropertyChanged("desktop_file"); }
        }
        private string _cmd_code;
        public string cmd_code
        {
            get { return _cmd_code; }
            set { _cmd_code = value; RaisePropertyChanged("cmd_code"); }
        }

        private string _old_password;
        public string old_password
        {
            get { return _old_password; }
            set { _old_password = value; RaisePropertyChanged("old_password"); }
        }
        private string _new_password;
        public string new_password
        {
            get { return _new_password; }
            set { _new_password = value; RaisePropertyChanged("new_password"); }
        }
        private string _conf_password;
        public string conf_password
        {
            get { return _conf_password; }
            set { _conf_password = value; RaisePropertyChanged("conf_password"); }
        }

        // Scalars
        private string _theme_title;
        public string theme_title
        {
            get { return _theme_title; }
            set { _theme_title = value; RaisePropertyChanged("theme_title"); }
        }

        private string _lang_desc;
        public string lang_desc
        {
            get { return _lang_desc; }
            set { _lang_desc = value; RaisePropertyChanged("lang_desc"); }
        }
        private string _cmd_name;
        public string cmd_name
        {
            get { return _cmd_name; }
            set { _cmd_name = value; RaisePropertyChanged("cmd_name"); }
        }
        public string XmlDataDocument_SYS_C005 { get; set; }
        public string XmlDataDocument_SET_M005 { get; set; }
    }
    public class MultipleContext_UserLevelSettings
    {
        public List<SYS_C001_P> Themes { get; set; }
        public List<SYS_C002> Language { get; set; }
        public List<SYS_C007> DateFormats { get; set; }
        public List<SYS_C005> SettingEntity { get; set; }
        public List<SYS_C006> RoundUpMethod { get; set; }
        public List<SYS_C011> DocCategory { get; set; }
        public List<SYS_D001> DocumentField { get; set; }
        public List<UserLevelSettings> MasterEntity { get; set; }
        public ObservableCollection<SYS_C005> DocumentEntity { get; set; }
        public List<SYS_AUTH> AUTH_LIST { get; set; }
    }
}
