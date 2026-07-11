using System.ComponentModel;
using Reflection.Presentation.ViewModel;

namespace Reflection.Shell.Model
{
    public sealed class UserLogin
        : ObservableObject, IDataErrorInfo
    {
        #region · Fields ·

        private string userId;
        private string password;
        private int workYear;

        #endregion

        #region · IDataErrorInfo Members ·

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get { return null; }
        }

        #endregion

        #region · Properties ·

        public string UserId
        {
            get { return this.userId; }
            set
            {
                if (this.userId != value)
                {
                    this.userId = value;
                    this.NotifyPropertyChanged(() => UserId);
                }
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.NotifyPropertyChanged(() => Password);
                }
            }
        }

        public int WorkYear
        {
            get { return this.workYear; }
            set
            {
                if (this.workYear != value)
                {
                    this.workYear = value;
                    this.NotifyPropertyChanged(() => WorkYear);
                }
            }
        }

        #endregion

        #region · Constructors ·

        public UserLogin()
        {
        }

        #endregion
    }
}
