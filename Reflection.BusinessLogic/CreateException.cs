using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessLogic
{
    /// <summary>
    /// Represents errors that can occur when executing the CreateCustomer class.
    /// </summary>
    [Serializable]
    public class CreateException : Exception
    {
        #region Members

        private int errorCode;

        #endregion

        #region Properties

        /// <summary>
        /// Error code.
        /// </summary>
        public int ErrorCode
        {
            get { return this.errorCode; }
            set { this.errorCode = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CreateException()
            : base()
        {
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CreateException(int errorCode)
            : base()
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CreateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CreateException(int errorCode, string message)
            : base(message)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CreateException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        public CreateException(int errorCode, string message, Exception inner)
            : base(message, inner)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Creates a new instance of this class.
        /// </summary>
        protected CreateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns specific information about the exception for serialization purposes.
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            base.GetObjectData(info, context);
            info.AddValue("ErrorCode", this.errorCode);
        }

        #endregion
    }
}
