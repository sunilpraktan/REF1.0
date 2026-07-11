using System;
using Reflection.Presentation.ViewModel;

namespace Reflection.Presentation.Widgets
{
    /// <summary>
    /// Calendar Widget View Model
    /// </summary>
    public sealed class CalendarWidgetViewModel
        : WidgetViewModel
    {
        #region · Properties ·

        /// <summary>
        /// Gets the current selected date
        /// </summary>
        public DateTime SelectedDate
        {
            get;
            set;
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarWidget"/> class
        /// </summary>
        public CalendarWidgetViewModel()
            : base()
        {
        }

        #endregion
    }
}
