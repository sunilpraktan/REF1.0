using Reflection.Presentation.Controls.AutoSuggestTextBox.Core;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Presentation.Controls
{
    public static class SelectorFactory
    {
        public static ISelector GetDefaultSelector(IValueConverter suggestionToStringConverter, IEnumerable suggestionsSource)
        {
            return new AutoSuggestViewModel.DefaultSelector(suggestionToStringConverter, suggestionsSource);
        }

        public static ISelector GetDefaultSelector(Func<object, string, bool> suggestionToStringConverter, IEnumerable suggestionsSource)
        {
            return new AutoSuggestViewModel.DefaultSelector(suggestionToStringConverter, suggestionsSource);
        }

    }
}
