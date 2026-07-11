using System.ComponentModel;

namespace Reflection.Presentation.Core.ViewModel
{
    /// <summary>
    /// Interface for entity viewmodel implementations
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityViewModel<TEntity> :
        INotifyDataErrorInfo where TEntity : class, new()
    {
        #region · Properties ·

        /// <summary>
        /// Gets a value indicating wheter this instance is valid
        /// </summary>
        bool IsValid
        {
            get;
        }

        /// <summary>
        /// Gets a value indicating wheter this instance has changes
        /// </summary>
        bool HasChanges
        {
            get;
        }

        #endregion
    }
}
