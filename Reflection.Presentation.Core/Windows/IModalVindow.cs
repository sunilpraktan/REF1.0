using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Reflection.Presentation.Core.Windows
{
    /// <summary>
    /// Interface for modal window implementations
    /// </summary>
    public interface IModalVindow
        : IWindow
    {
        #region · Properties ·

        /// <summary>
        /// Gets or sets the <see cref="Reflection.Presentation.Core.Windows.DialogResult"/>
        /// </summary>
        DialogResult DialogResult
        {
            get;
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Shows the window as a modal dialog
        /// </summary>
        /// <returns></returns>
        DialogResult ShowDialog();

        #endregion
    }
}
