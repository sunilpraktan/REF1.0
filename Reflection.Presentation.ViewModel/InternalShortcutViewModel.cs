using System;
using Reflection.Presentation.Core.Navigation;
using NLog;

namespace Reflection.Presentation.ViewModel
{
    /// <summary>
    /// Internal shortcut viewmodel class
    /// </summary>
    public sealed class InternalShortcutViewModel
        : ShortcutViewModel
    {
        #region · Logger ·

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region · Consts ·

        private static readonly string DefaultIconStyle = "WindowIconStyle";

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets the shortcut icon style.
        /// </summary>
        /// <value>The icon style.</value>
        public override string IconStyle
        {
            get
            {
                if (String.IsNullOrWhiteSpace(base.IconStyle))
                {
                    return DefaultIconStyle;
                }

                return base.IconStyle;
            }
            set { base.IconStyle = value; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="InternalShortcutViewModel"/> class.
        /// </summary>
        public InternalShortcutViewModel()
            : base()
        {
        }

        #endregion

        #region · Command Execution ·

        /// <summary>
        /// Called when the <see cref="OpenCommand"/>  is executed.
        /// </summary>
        protected override void OnOpen()
        {
            Logger.Debug("Ejecución de un acceso directo ({0})", this.Target);

            //this.GetService<INavigationService>().Navigate(this.Target, 10, 20, "BBB");
            this.GetService<INavigationService>().Navigate(this.Target, 10, 20, "BBB");
        }

        #endregion
    }
}
