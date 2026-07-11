using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reflection.Presentation.DragAndDrop
{
    public interface IDataDropObject
    {
        #region · Methods ·

        object GetData();

        #endregion
    }
}
