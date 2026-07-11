using System;
using Reflection.Presentation.Core.Windows;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for workspace viewmodel implementations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IWorkspaceViewModel<TEntity>
        : IWindowViewModel, IEntityViewModel<TEntity>, INavigationViewModel, IBookmarkViewModel where TEntity : class, new()
    {
        #region · Events ·
        
        /// <summary>
        /// Occurs when the view mode has changed
        /// </summary>
        event EventHandler ViewModeChanged;

        #endregion

        #region · Commands ·

        /// <summary>
        /// Gets the add new command
        /// </summary>
        RelayCommand AddNewCommand
        {
            get;
        }

        /// <summary>
        /// Gets the delete command
        /// </summary>
        RelayCommand DeleteCommand
        {
            get;
        }

        /// <summary>
        /// Gets the discard changes command
        /// </summary>
        RelayCommand DiscardCommand
        {
            get;
        }

        /// <summary>
        /// Gets the edit command
        /// </summary>
        RelayCommand EditCommand
        {
            get;
        }

        /// <summary>
        /// Gets the save changes command
        /// </summary>
        RelayCommand SaveCommand
        {
            get;
        }

        /// <summary>
        /// Gets the print command
        /// </summary>
        //RelayCommand PrintCommand
        //{
        //    get;
        //}

        /// <summary>
        /// Gets the print preview command
        /// </summary>
        RelayCommand PrintPreviewCommand
        {
            get;
        }

        /// <summary>
        /// Gets the show form help command
        /// </summary>
        RelayCommand ShowFormHelpCommand
        {
            get;
        }

        /// <summary>
        /// Gets the show zoom window command
        /// </summary>
        RelayCommand ShowZoomWindowCommand
        {
            get;
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets a value indicating whether the zoom window is shown
        /// </summary>
        bool ShowZoomWindow
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the zoom level
        /// </summary>
        double ZoomLevel
        {
            get;
            set;
        }

        #endregion
    }
}
