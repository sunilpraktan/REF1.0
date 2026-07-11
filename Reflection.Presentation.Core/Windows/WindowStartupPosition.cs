using System;


namespace Reflection.Presentation.Core.Windows
{
    /// <summary>
    /// Specifies the position that a Window will be shown in when it is first opened. 
    /// Used by the <see cref="IWindow.WindowStartupLocation"/> property.
    /// </summary>
    [Serializable]
    public enum WindowStartupPosition
    {
        /// <summary>
        /// The startup location of a <see cref="CReflectionhronos.Presentation.Windows.Core.IWindow"/> 
        /// is the center of the parent control that owns it.
        /// </summary>
        CenterParent,
        /// <summary>
        /// The startup location of a <see cref="Reflection.Presentation.Windows.Core.IWindow"/> 
        /// is set from code, or defers to the default Windows location.
        /// </summary>
        Manual,
        /// <summary>
        /// The startup location of a <see cref="Reflection.Presentation.Windows.Core.IWindow"/> 
        /// is the center of the screen that contains the mouse cursor.
        /// </summary>
        WindowsDefaultLocation
    }
}
