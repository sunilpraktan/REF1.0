using System;
using Reflection.Presentation.Core.Navigation;
using Reflection.Presentation.Core.ViewModel;
using Reflection.Presentation.Core.VirtualDesktops;
using NLog;
using GalaSoft.MvvmLight.Command;


namespace Reflection.Presentation.ViewModel
{
    /// <summary>
    /// base class for navigation based viewmodel iumplementations
    /// </summary>
    public abstract class NavigationViewModel
        : ClosableViewModel, INavigationViewModel
    {
        #region · Logger ·

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region · Fields ·

        #region · Commands ·

        private RelayCommand newWindowCommand;
        private RelayCommand restoreCommand;

        #endregion

        #endregion

        #region · INavigationViewModel Commands ·

        /// <summary>
        /// Gets the open new window command
        /// </summary>
        public RelayCommand NewWindowCommand
        {
            get
            {
                if (this.newWindowCommand == null)
                {
                    this.newWindowCommand = new RelayCommand
                    (
                        () => OnOpenNewWindow(),
                        () => CanOpenNewWindow()
                    );
                }

                return this.newWindowCommand;
            }
        }

        /// <summary>
        /// Gets the restore command
        /// </summary>
        public RelayCommand RestoreCommand
        {
            get
            {
                if (this.restoreCommand == null)
                {
                    this.restoreCommand = new RelayCommand
                    (
                        () => OnRestore(),
                        () => CanRestore()
                    );
                }

                return this.restoreCommand;
            }
        }

        #endregion

        #region · INavigationViewModel Properties ·

        /// <summary>
        /// Gets the navigation route
        /// </summary>
        public virtual string NavigationRoute
        {
            get { return String.Empty; }
        }

        /// <summary>
        /// Gets a value indicating if the viewmodel has available relations
        /// </summary>
        public virtual bool HasRelations
        {
            get { return false; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationViewModel"/> class.
        /// </summary>
        protected NavigationViewModel()
            : base()
        {
        }

        #endregion

        #region · Methods ·

        public override void Close()
        {
            this.newWindowCommand = null;
            this.restoreCommand = null;

            base.Close();
        }

        #endregion

        #region · Navigation Methods ·

        /// <summary>
        /// Performs the navigation to the given target
        /// </summary>
        /// <param name="target"></param>
        protected void Navigate(string target)
        {
            
        }

       
        /// <summary>
        /// Performs the navigation to the given target
        /// </summary>
        /// <param name="target"></param>
        protected void Navigate(string target, params object[] args)
        {
            
        }

        

        #endregion

        #region · ISupportNavigationLifecycle Members ·

       

        

        #endregion

        #region · ISupportNavigationState Members ·

        

        #endregion

        #region · Command Actions ·

        protected virtual bool CanOpenNewWindow()
        {
            return !String.IsNullOrEmpty(this.NavigationRoute);
        }

        protected virtual void OnOpenNewWindow()
        {
            Logger.Debug("Abrir una nueva ventana '{0}'", this.GetType());

            this.GetService<INavigationService>().Navigate(this.NavigationRoute);
        }

        protected virtual bool CanRestore()
        {
            return true;
        }

        protected virtual void OnRestore()
        {
            Logger.Debug("Restaurar ventana '{0}'", this.GetType());

            this.GetService<IVirtualDesktopManager>().Restore(this.Id);
        }

        #endregion

        #region · Protected Methods ·

        /// <summary>
        /// Called when closing.
        /// </summary>
        /// <param name="confirmCallback">The confirm callback.</param>
        protected virtual void OnClosing(Action<bool> confirmCallback)
        {
            confirmCallback(false);
        }

        

        #endregion
    }
}
