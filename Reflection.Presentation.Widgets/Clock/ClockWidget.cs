using System;
using Reflection.Presentation.Core.Widgets;

namespace Reflection.Presentation.Widgets
{
    /// <summary>
    /// Clock widget definition
    /// </summary>
    public sealed class ClockWidget
        : IWidget
    {
        #region · Properties ·

        /// <summary>
        /// Gets the widget title
        /// </summary>
        /// <value></value>
        public string Title
        {
            get { return "Digital Clock"; }
        }

        /// <summary>
        /// Gets the widget description
        /// </summary>
        /// <value></value>
        public string Description
        {
            get { return "Digital Clock"; }
        }

        /// <summary>
        /// Gets the widget group
        /// </summary>
        /// <value></value>
        public string Group
        {
            get { return "Tools"; }
        }

        /// <summary>
        /// Gets the widget icon style
        /// </summary>
        /// <value></value>
        public string IconStyle
        {
            get { return String.Empty; }
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Creates the widget view
        /// </summary>
        /// <returns></returns>
        public System.Windows.FrameworkElement CreateView()
        {
            return new ClockWidgetView();
        }

        #endregion
    }
}
