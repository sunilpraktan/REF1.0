

namespace Reflection.Presentation.Core.Navigation
{
    /// <summary>
    /// Interface for view navigation services
    /// </summary>
    public interface INavigationService
    {
        #region · Methods ·

        /// <summary>
        /// Performs the navigation to the given target
        /// </summary>
        /// <param name="target"></param>
        void Navigate(string target);

       

        /// <summary>
        /// Performs the navigation to the given target
        /// </summary>
        /// <param name="target"></param>
        void Navigate(string target, params object[] args);

        

        #endregion
    }
}
