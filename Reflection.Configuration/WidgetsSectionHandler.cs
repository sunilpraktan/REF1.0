using System.Configuration;

namespace Reflection.Configuration
{
    /// <summary>
    /// Widget configuration section handler
    /// </summary>
    public sealed class WidgetsSectionHandler
        : ConfigurationSection
    {
        #region · Properties ·

        /// <summary>
        /// Gets the list of configured widgets.
        /// </summary>
        /// <value>The desktops.</value>
        [ConfigurationProperty("widgets", IsDefaultCollection = true)]
        public WidgetConfigurationElementCollection Widgets
        {
            get
            {
                return (WidgetConfigurationElementCollection)base["widgets"];
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetsSectionHandler"/> class.
        /// </summary>
        public WidgetsSectionHandler()
        {
        }

        #endregion
    }
}
