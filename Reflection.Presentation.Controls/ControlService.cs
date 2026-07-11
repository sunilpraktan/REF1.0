using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reflection.Presentation.Controls
{
    class ControlService
    {
    }

    // DataGrid Cell keyboard focus set on Edit when focus shift on it.
    public class TakeFocusAction : TriggerAction<UIElement>
    {
        protected override void Invoke(object parameter)
        {
            AssociatedObject.Focus();
        }
    }
}
