using System.Collections.Generic;
using System.Configuration;
using Reflection.Presentation.Core.Widgets;

namespace Reflection.Presentation.Core.Configuration
{
    public interface IWidgetConfigurationService
    {
        #region · Methods ·

        IEnumerable<IWidget> GetWidgets();

        T GetWidgetConfigurationSection<T>(string sectionName)
            where T : ConfigurationSection;

        #endregion
    }
}
