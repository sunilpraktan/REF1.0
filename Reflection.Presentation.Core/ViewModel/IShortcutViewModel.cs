using GalaSoft.MvvmLight.Command;

namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for shortcut viewmodel implementations
    /// </summary>
    public interface IShortcutViewModel
        : IClosableViewModel
    {
        #region · Commands ·

        /// <summary>
        /// Gets the open command
        /// </summary>
        RelayCommand OpenCommand
        {
            get;
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets the shortcut target
        /// </summary>
        string Target
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the shortcut navigation parameters
        /// </summary>
        string Parameters
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the shortcut icon style
        /// </summary>
        string IconStyle
        {
            get;
            set;
        }

        #endregion
    }
}
