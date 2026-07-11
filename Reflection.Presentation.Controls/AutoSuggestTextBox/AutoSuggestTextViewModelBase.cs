using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace Reflection.Presentation.Controls
{
    public abstract class AutoSuggestTextViewModelBase<TDomainObject> : DependencyObject
    {
        public AutoSuggestViewModel AutoSuggestVM { get; protected set; }
        public IEnumerable<TDomainObject> DomainObjectCollection { get; set; }
        public string PopupKeyColumName { get; protected set; }
        public string DataGridKeyColumName { get; protected set; }

        protected AutoSuggestTextViewModelBase(TDomainObject DomainObject, Func<object, string, bool> TheFilter, IValueConverter SuggestedValue, string PopUpKeyColumn, bool AutoCompleteOn)
        {
            PopupKeyColumName = PopUpKeyColumn;
            DomainObjectCollection = (IEnumerable<TDomainObject>)DomainObject;
            var styleModel = AutoSuggestControlStyleViewModel.CreateDefaultInstance();
            styleModel.IsAutoCompleteOn = AutoCompleteOn;
            var selector = SelectorFactory.GetDefaultSelector(TheFilter, (IEnumerable)DomainObject);
            AutoSuggestVM = new AutoSuggestViewModel(selector, SuggestedValue, SuggestedValue, styleModel);
            AutoSuggestVM.Separators = new[] { ";" };
            AutoSuggestVM.FreeTextToSuggestionConverter = FreeTextToSuggestionConverter;
        }
        protected AutoSuggestTextViewModelBase(TDomainObject DomainObject, Func<object, string, bool> TheFilter, IValueConverter SuggestedValue, string DataGridKeyColumn, string PopUpKeyColumn, bool AutoCompleteOn)
        {
            PopupKeyColumName = PopUpKeyColumn;
            DataGridKeyColumName = DataGridKeyColumn;
            DomainObjectCollection = (IEnumerable<TDomainObject>)DomainObject;
            var styleModel = AutoSuggestControlStyleViewModel.CreateDefaultInstance();
            styleModel.IsAutoCompleteOn = AutoCompleteOn;
            var selector = SelectorFactory.GetDefaultSelector(TheFilter, (IEnumerable)DomainObject);
            AutoSuggestVM = new AutoSuggestViewModel(selector, SuggestedValue, SuggestedValue, styleModel);
            AutoSuggestVM.Separators = new[] { ";" };
            AutoSuggestVM.FreeTextToSuggestionConverter = FreeTextToSuggestionConverter;
        }

        #region Delay
        public static readonly DependencyProperty DelayProperty = Reflection.Presentation.Controls.AutoSuggestTextBox.Core.ViewModel.RegisterProperty<string, AutoSuggestTextViewModelBase<TDomainObject>>("Delay", "0",
            (d, e) =>
            {
                var autoSuggestConsumerVM = d as AutoSuggestTextViewModelBase<TDomainObject>;
                if (autoSuggestConsumerVM != null)
                {
                    var vLong = 0;
                    if (e.NewValue != null && Int32.TryParse(e.NewValue.ToString(), out vLong))
                        autoSuggestConsumerVM.AutoSuggestVM.Delay = new TimeSpan(0, 0, 0, 0, vLong);
                }
            }
            , (d, v) =>
            {
                var vStr = v as string;
                var vLong = 0;
                if (vStr.IsNullOrWhiteSpace() || !Int32.TryParse(vStr, out vLong))
                    return "0";
                return v;
            });
        public string Delay { get { return (string)GetValue(DelayProperty); } set { SetValue(DelayProperty, value); } }
        #endregion
        #region Free Text To Suggestion Converter
        private bool FreeTextToSuggestionConverter(string filterInput, out object suggestion)
        {
            suggestion = filterInput;
            if (!filterInput.IsNullOrWhiteSpace())
                suggestion = InvokeNew(filterInput, DomainObjectCollection);

            return suggestion != null;
        }
        public dynamic InvokeNew(string name, IEnumerable<TDomainObject> DomainObject)
        {
            dynamic EntityObject = DomainObject.FirstOrNull();
            EntityObject.GetType().GetProperty(PopupKeyColumName).SetValue(EntityObject, name, null);
            if (EntityObject != null)
            {
                return EntityObject;
            }
            return null;
        }
        #endregion
    }
}
