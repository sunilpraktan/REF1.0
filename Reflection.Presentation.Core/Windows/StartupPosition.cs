using System;

namespace Reflection.Presentation.Core.Windows
{
    /// <summary>
    /// Specifies the position that a <see cref="Reflection.Presentation.Core.Windows.IDesktopElement"/> 
    /// will be shown in when it is first opened. 
    /// </summary>
    [Serializable]
    public enum StartupPosition
    {
        /// <summary>
        /// The startup location of a <see cref="Reflection.Presentation.Core.Windows.IDesktopElement"/> 
        /// is the center of the parent control that owns it.
        /// </summary>
        CenterParent,
        /// <summary>
        /// The startup location of a <see cref="Reflection.Presentation.Core.Windows.IDesktopElement"/> 
        /// is set from code, or defers to the default Windows location.
        /// </summary>
        Manual,
        /// <summary>
        /// The startup location of a <see cref="Reflection.Presentation.Core.Windows.IDesktopElement"/> 
        /// is the center of the screen that contains the mouse cursor.
        /// </summary>
        WindowsDefaultLocation
    }
}
