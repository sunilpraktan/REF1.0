using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel;


namespace Reflection.Presentation.ViewModel
{
    /// <summary>
    /// Provides a base class for Applications to inherit from. 
    /// </summary>
    public abstract class ViewModelBase
        : ObservableObject
    {
        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        protected ViewModelBase()
            : base()
        {
        }

        #endregion

        #region · Protected Methods ·

        /// <summary>
        /// Gets the requested service instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        protected TService GetService<TService>() where TService : class
        {
            return SimpleIoc.Default.GetInstance<TService>();
        }

        /// <summary>
        /// Gets the requested view service.
        /// </summary>
        /// <typeparam name="TViewService">The type of the view service.</typeparam>
        /// <returns></returns>
        protected TViewService GetViewService<TViewService>() where TViewService : class
        {
            return SimpleIoc.Default.GetInstance<TViewService>();
        }

        #endregion
    }
}
