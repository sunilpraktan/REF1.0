using System.Windows.Input;

namespace Reflection.Presentation.Services
{
    public static class TokenizedTextBoxCommands
    {
        private static RoutedCommand _deleteCommand = new RoutedCommand();

        public static RoutedCommand Delete
        {
            get
            {
                return _deleteCommand;
            }
        }
    }
}
