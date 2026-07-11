using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Navigation;
using System;
using System.Runtime.Serialization;
using System.Windows.Input;


namespace Reflection.Presentation.Windows.SiteMaps
{
    /// <summary>
    /// Command based sitemap node
    /// </summary>
    public sealed class CommandSiteMapNode : MessageBase
        
    {
        #region · Fields ·
        public string NavigateTo { get; set; }

        private RelayCommand executeCommand;

        public RelayCommand ExecuteCommand
        {
            get
            {
                if (this.executeCommand == null)
                {
                    this.executeCommand = new RelayCommand(() => Execute());
                }

                return this.executeCommand;
            }
        }

        /// <summary>
        /// Gets the execute command.
        /// </summary>
        /// <value>The execute command.</value>
        //[IgnoreDataMember]
        //public ICommand ExecuteCommand
        //{
        //    get
        //    {
        //        //if (!this.HasChildNodes && !String.IsNullOrWhiteSpace(this.Url))
        //        //{
        //        //    this.executeCommand = new RelayCommand(() => Execute());
        //        //}

        //        return this.executeCommand;
        //    }
        //}

        #endregion

        
        #region · Constructors ·

        public CommandSiteMapNode()
            : base()
        {
        }

        #endregion

        #region · Overriden Methods ·
        private void Execute()
        {
            //Logger.Debug("Ejecución de un acceso directo ({0})", this.Target);
            var msg = new NavigateToView() { ViewName = NavigateTo };
            Messenger.Default.Send<NavigateToView>(new NavigateToView() { ViewName = NavigateTo });
            //this.GetService<INavigationService>().Navigate(this.Target, 10, 20, "BBB");
            //this.GetService<INavigationService>().Navigate(this.Target, 10, 20, "BBB");
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return null;
        }

        #endregion
    }
}
