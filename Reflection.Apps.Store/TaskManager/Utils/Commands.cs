using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Apps.Store.TaskManager
{
    public static class Commands
    {
        public static RoutedUICommand Cancel { get { return s_cancelCommand; } }

        public static void MapCommand(ICommand source, RoutedCommand target, UIElement element)
        {
            //Util.RequireNotNull(source, "source");
            //Util.RequireNotNull(target, "target");
            //Util.RequireNotNull(element, "element");

            var binding = new CommandBinding(target,
                (sender, args) => { source.Execute(args.Parameter); },
                (sender, args) => { args.CanExecute = source.CanExecute(args.Parameter); }
            );

            element.CommandBindings.Add(binding);

            source.CanExecuteChanged += (sender, args) =>
            {
                target.CanExecute(null, element);
            };
        }

        private static readonly RoutedUICommand s_cancelCommand = new RoutedUICommand("Cancel", "Cancel", typeof(Commands));

    }
}
