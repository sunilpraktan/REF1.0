using Reflection.Presentation.Core.VirtualDesktops;

namespace Reflection.Presentation.Windows
{
    /// <summary>
    /// Actived desktop changed payload
    /// </summary>
    public sealed class ActiveDesktopChangedInfo
    {
        #region · Fields ·

        private IVirtualDesktop newActiveDesktop;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the new active desktop.
        /// </summary>
        /// <value>The new active desktop.</value>
        public IVirtualDesktop NewActiveDesktop
        {
            get { return this.newActiveDesktop; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="ActiveDesktopChangedInfo"/> class.
        /// </summary>
        /// <param name="newActiveDesktop">The new active desktop.</param>
        public ActiveDesktopChangedInfo(IVirtualDesktop newActiveDesktop)
        {
            this.newActiveDesktop = newActiveDesktop;
        }

        #endregion
    }
}
