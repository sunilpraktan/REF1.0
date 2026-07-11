using System;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Core.ViewModel;

namespace Reflection.Presentation.ViewModel
{
    /// <summary>
    /// Base class for entity viewmodel implementations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class EntityViewModel<TEntity>
        : ViewModelBase, IEntityViewModel<TEntity> where TEntity : class, IDataErrorInfo, new()
    {
        #region · Fields ·

        private TEntity entity;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        #endregion

        #region · IEntityViewModel<TEntity> Properties ·

        /// <summary>
        /// Gets the entity model instance
        /// </summary>
        public TEntity Entity
        {
            get { return this.entity; }
        }

        /// <summary>
        /// Gets value indicating whether this instance is valid
        /// </summary>
        public virtual bool IsValid
        {
            get { return String.IsNullOrEmpty(this.Error); }
        }

        /// <summary>
        /// Gets value indicating whether this instance has changes
        /// </summary>
        public virtual bool HasChanges
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <value>
        /// An error message indicating what is wrong with this object. The default is
        /// an empty string ("").
        /// </value>
        public virtual string Error
        {
            get
            {
                if (this.Entity != null)
                {
                    return this.Entity.Error;
                }

                return null;
            }
        }

        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="columnName">The name of the property whose error message to get.</param>
        /// <value>The error message for the property. The default is an empty string ("").</value>
        public virtual string this[string columnName]
        {
            get
            {
                if (this.Entity != null)
                {
                    return this.Entity[columnName];
                }

                return null;
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityViewModel"/> class
        /// </summary>
        protected EntityViewModel()
            : base()
        {
            this.entity = new TEntity();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityViewModel"/> class
        /// with the given entity model
        /// </summary>
        /// <param name="entity"></param>
        protected EntityViewModel(TEntity entity)
            : this()
        {
            this.entity = entity;
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
