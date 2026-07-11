
using System;

namespace Reflection.Presentation.Core.Navigation
{
    public sealed class NavigatedInfo
    {
        #region · Fields ·

        private string title;
        private Guid windowId;

        #endregion

        #region · Properties ·

       
        public string Title
        {
            get { return this.title; }
        }

        public Guid Id
        {
            get { return this.windowId; }
        }

        #endregion

        #region · Constructors ·

        

        #endregion
    }
}
