using GalaSoft.MvvmLight.Command;

namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for ViewModels that supports bookmarking
    /// </summary>
    public interface IBookmarkViewModel
    {
        #region · Commands ·

        /// <summary>
        /// Gets the bookmark current command
        /// </summary>
        RelayCommand BookmarkCurrentCommand
        {
            get;
        }

        /// <summary>
        /// Gets the clear bookmarks command
        /// </summary>
        RelayCommand ClearBookmarksCommand
        {
            get;
        }

        /// <summary>
        /// Gets the organize bookmarks command
        /// </summary>
        RelayCommand OrganizeBookmarksCommand
        {
            get;
        }

        /// <summary>
        /// Gets the create shortcut command
        /// </summary>
        RelayCommand CreateShortcutCommand
        {
            get;
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets a value indicating if there are available bookmarks
        /// </summary>
        bool HasBookMarks
        {
            get;
        }

        #endregion
    }
}
