using System;
using Reflection.Presentation.Core.Widgets;

namespace Reflection.Presentation.Widgets
{
    /// <summary>
    /// Navigator Widget Definition
    /// </summary>
    public sealed class NavigatorWidget
        : IWidget
    {
        #region · Properties ·

        /// <summary>
        /// Gets the widget title
        /// </summary>
        /// <value></value>
        public string Title
        {
            get { return "Navigator"; }
        }

        /// <summary>
        /// Gets the widget description
        /// </summary>
        /// <value></value>
        public string Description
        {
            get { return "Browse and search application functions"; }
        }

        /// <summary>
        /// Gets the widget group
        /// </summary>
        /// <value></value>
        public string Group
        {
            get { return "System"; }
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
            return new NavigatorWidgetView();
        }

        #endregion
    }
}
