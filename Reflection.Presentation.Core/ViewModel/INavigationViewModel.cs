
using GalaSoft.MvvmLight.Command;


namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for navigation viewmodel implementations
    /// </summary>
    public interface INavigationViewModel
        : IClosableViewModel
    {
        #region · Commands ·

        /// <summary>
        /// Gets the open new window command
        /// </summary>
        RelayCommand NewWindowCommand
        {
            get;
        }

        /// <summary>
        /// Gets the restore window command.
        /// </summary>
        /// <value>The restore window command.</value>
        RelayCommand RestoreCommand
        {
            get;
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the navigation route
        /// </summary>
        string NavigationRoute
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating wheter the viewmodel has available relations
        /// </summary>
        bool HasRelations
        {
            get;
        }

        #endregion
    }
}
