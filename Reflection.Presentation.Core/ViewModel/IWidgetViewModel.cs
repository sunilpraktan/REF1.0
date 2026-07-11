
namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for widget viewmodel implementations
    /// </summary>
    public interface IWidgetViewModel
        : IClosableViewModel
    {
        #region · Properties ·

        /// <summary>
        /// Gets the widget description
        /// </summary>
        string Description
        {
            get;
        }

        #endregion
    }
}
