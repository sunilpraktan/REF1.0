using System;
using GalaSoft.MvvmLight.Command;

namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for closable ViewModel implementations
    /// </summary>
    public interface IClosableViewModel
        : IObservableObject
    {
        #region · Commands ·

        /// <summary>
        /// Gets the close command
        /// </summary>
        RelayCommand CloseCommand
        {
            get;
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the viewmodel identifier
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// Gets or sets the viewmodel title
        /// </summary>
        string Title
        {
            get;
            set;
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Closes the viewmodel
        /// </summary>
        void Close();

        #endregion
    }
}
