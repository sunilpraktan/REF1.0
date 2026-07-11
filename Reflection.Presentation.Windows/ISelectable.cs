using System;

namespace Reflection.Presentation.Windows
{
    /// <summary>
    /// Common interface for items that can be selected
    /// on the <see cref="Desktop"/>; used by <see cref="DesktopItem"/>
    /// </summary>
    public interface ISelectable
    {
        #region · Properties ·

        Guid ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the item is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        bool IsSelected
        {
            get;
            set;
        }

        #endregion
    }
}
