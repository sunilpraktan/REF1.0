using System.Collections;

namespace Reflection.Presentation.Controls.AutoSuggestTextBox.Core
{
    public interface ISelector
    {
        IEnumerable Select(object filter);
    }
}
