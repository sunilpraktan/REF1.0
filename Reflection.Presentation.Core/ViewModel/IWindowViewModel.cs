using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Windows;


namespace Reflection.Presentation.Core.ViewModel
{
    public interface IWindowViewModel
        : INavigationViewModel
    {
        #region · Commands ·

        /// <summary>
        /// Gets the inquiry data command
        /// </summary>
        //RelayCommand InquiryCommand
        //{
        //    get;
        //}
        RelayCommand CreateDataCommand
        {
            get;
        }
        RelayCommand SaveDataCommand
        {
            get;
        }
        RelayCommand RemoveDataCommand
        {
            get;
        }
        RelayCommand DiscardCommand
        {
            get;
        }
        RelayCommand PrintCommand
        {
            get;
        }
        RelayCommand FlipCommand
        {
            get;
        }
        RelayCommand HelpCommand
        {
            get;
        }
        RelayCommand FevoriteCommand
        {
            get;
        }
        RelayCommand RefreshCommand
        {
            get;
        }
        RelayCommand LedgerViewCommand
        {
            get;
        }
        RelayCommand ValidateCommand
        {
            get;
        }
        RelayCommand TraceCommand
        {
            get;
        }
        RelayCommand MailCommand
        {
            get;
        }
        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets the <see cref="Reflection.Presentation.Core.Windows.ViewModeType"/>
        /// </summary>
        ViewModeType ViewMode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the status message text
        /// </summary>
        string StatusMessage
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the notification message text
        /// </summary>
        string NotificationMessage
        {
            get;
            set;
        }

        #endregion
    }
}
