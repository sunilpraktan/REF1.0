using System;
using System.Windows.Controls;

namespace Reflection.Presentation.Core.Windows
{
    /// <summary>
    /// Interface for desktop element implementations
    /// </summary>
    public interface IDesktopElement
    {
        #region · Properties ·

        /// <summary>
        /// Gets the element identifier
        /// </summary>
        Guid Id
        {
            get;
        }

        /// <summary>
        /// Gets the element parent
        /// </summary>
        Panel Parent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the element can be dragged
        /// </summary>
        bool CanDrag
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the element can be resized
        /// </summary>
        bool CanResize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the element <see cref="Reflection.Presentation.Core.Windows.StartupPosition"/>
        /// </summary>
        StartupPosition StartupLocation
        {
            get;
            set;
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Activates the element
        /// </summary>
        void Activate();

        #endregion
    }
}
