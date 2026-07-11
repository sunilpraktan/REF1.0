using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.Core;
using System.Linq;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;

namespace Reflection.Presentation.Controls
{
    public class AutoSuggestTextViewModel<TDomainObject> : AutoSuggestTextViewModelBase<TDomainObject>
    {
        //This Constructor for Single TextBox Control
        public AutoSuggestTextViewModel(TDomainObject domainObj, Func<object, string, bool> TheFilter, IValueConverter SuggestedValue, string PopupGridColumn, bool AutoCompleteOn) : base(domainObj, TheFilter, SuggestedValue, PopupGridColumn, AutoCompleteOn)
        {
        }

        //This Constructor for DataGrid TextBox Control
        public AutoSuggestTextViewModel(TDomainObject domainObj, Func<object, string, bool> TheFilter, IValueConverter SuggestedValue, string MainGridColumn, string PopupGridColumn, bool AutoCompleteOn) : base(domainObj, TheFilter, SuggestedValue, MainGridColumn, PopupGridColumn, AutoCompleteOn)
        {
            AutoSuggestVM.AddValueChanged(AutoSuggestViewModel.SuggestionProperty, delegate
            {
                if (SelectedObjectValue == null || _selectedValueChanging) return;

                if (AutoSuggestVM.Suggestion == null)
                {
                    SelectedObjectValue.GetType().GetProperty(DataGridKeyColumName).SetValue(SelectedObjectValue, null, null);
                }
                else
                 {
                    var DomainObject = (dynamic)AutoSuggestVM.Suggestion;
                    SelectedObjectValue.GetType().GetProperty(DataGridKeyColumName).SetValue(SelectedObjectValue, DomainObject.GetType().GetProperty(PopupKeyColumName).GetValue(DomainObject, null).ToString(), null);
                }
            });
        }

        private bool _selectedValueChanging;
        #region Selected Value
        public static readonly DependencyProperty SelectedObjectValueProperty = Reflection.Presentation.Controls.AutoSuggestTextBox.Core.ViewModel.RegisterProperty<dynamic, AutoSuggestTextViewModel<dynamic>>("SelectedObjectValue", null,
            (d, e) =>
                {
                if (e.NewValue != null)
                {
                    var PopupObjectValue = (dynamic)e.NewValue;
                    var ObjectVM = (AutoSuggestTextViewModel<dynamic>)d;
                    ObjectVM._selectedValueChanging = true;
                        //ObjectVM.AutoSuggestVM.Suggestion = ObjectVM.DomainObjectCollection.FirstOrDefault(x => (x.GetType().GetProperty(ObjectVM.PopupKeyColumName).GetValue(x, null) as string) == (PopupObjectValue.GetType().GetProperty(ObjectVM.DataGridKeyColumName).GetValue(PopupObjectValue, null) as string));
                        try
                        {
                            ObjectVM.AutoSuggestVM.Suggestion = ObjectVM.DomainObjectCollection.First(x => (x.GetType().GetProperty(ObjectVM.PopupKeyColumName).GetValue(x, null) as string) == (PopupObjectValue.GetType().GetProperty(ObjectVM.DataGridKeyColumName).GetValue(PopupObjectValue, null) as string));
                        }
                        catch(Exception ex)
                        {
                            ObjectVM.AutoSuggestVM.Suggestion = null;
                        }
                        ObjectVM._selectedValueChanging = false;
                }
            });
        public dynamic SelectedObjectValue { get { return (dynamic)GetValue(SelectedObjectValueProperty); } set { SetValue(SelectedObjectValueProperty, value); } }
        #endregion
    }

}
