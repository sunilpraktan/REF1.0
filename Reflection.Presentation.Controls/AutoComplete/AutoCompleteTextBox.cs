using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;

namespace Reflection.Presentation.Controls
{
    public class AutoCompleteTextBox : TextBox
    {

        private TextBox TXT_SEARCHINPUT;//For user input
        private Popup PUP_AC;// For AutoCompleteList Popup
        private DataGrid DG_AC;// DataGrid To Display List Of Filtered Items

        public static readonly DependencyProperty GetSelectedValuesCommandProperty = DependencyProperty.Register("GetSelectedValuesCommand", typeof(ICommand), typeof(AutoCompleteTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(AutoCompleteTextBox), new PropertyMetadata(null));
        public static readonly DependencyProperty AutoCompleteModeProperty = DependencyProperty.Register("AutoCompleteMode", typeof(string), typeof(AutoCompleteTextBox)); // Design input style as per requirement of charactristics type in Classification like TextBox, Dropdown list, Check Box with Extended/Multiple value selection, option button etc.... Single: Single selection , Multiple: Multiple selection
        public static readonly DependencyProperty AutoCompleteColumnsProperty = DependencyProperty.Register("AutoCompleteColumns", typeof(ObservableCollection<DataGridColumn>), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompleteItemSourceProperty = DependencyProperty.Register("AutoCompleteItemSource", typeof(IEnumerable<object>), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(object), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompletePlacementDependencyProperty = DependencyProperty.Register("AutoCompletePlacement", typeof(PlacementMode), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompletePlacementTargetDependencyProperty = DependencyProperty.Register("AutoCompletePlacementTarget", typeof(UIElement), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompleteHorizontalOffsetDependencyProperty = DependencyProperty.Register("AutoCompleteHorizontalOffset", typeof(double), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompleteVerticalOffsetDependencyProperty = DependencyProperty.Register("AutoCompleteVerticalOffset", typeof(double), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompleteWidthDependencyProperty = DependencyProperty.Register("AutoCompleteWidth", typeof(double), typeof(AutoCompleteTextBox));
        public static readonly DependencyProperty AutoCompleteHeightDependencyProperty = DependencyProperty.Register("AutoCompleteHeight", typeof(double), typeof(AutoCompleteTextBox));

        public ICommand GetSelectedValuesCommand
        {
            get { return (ICommand)GetValue(GetSelectedValuesCommandProperty); }
            set { SetValue(GetSelectedValuesCommandProperty, value); }
        }
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public string AutoCompleteMode
        {
            get
            {
                return (string)GetValue(AutoCompleteModeProperty);
            }
            set
            {
                SetValue(AutoCompleteModeProperty, value);
            }
        }
        public ObservableCollection<DataGridColumn> AutoCompleteColumns
        {
            get
            {
                return (ObservableCollection<DataGridColumn>)GetValue(AutoCompleteColumnsProperty);
            }
            set
            {
                SetValue(AutoCompleteColumnsProperty, value);
            }
        }
        public IEnumerable<object> AutoCompleteItemSource
        {
            get
            {
                return (IEnumerable<object>)GetValue(AutoCompleteItemSourceProperty);
            }
            set
            {
                SetValue(AutoCompleteItemSourceProperty, value);
            }
        }
        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);

                if (value != null && AutoCompleteMode != "Extended")
                {
                    TXT_SEARCHINPUT.Text = value.ToString();
                    TXT_SEARCHINPUT.Select(TXT_SEARCHINPUT.Text.Length, 0);
                }
                //if(!string.IsNullOrWhiteSpace(TXT_SEARCHINPUT.Text))
                //{
                //    SetValue(SelectedItemProperty, TXT_SEARCHINPUT.Text);
                //}

                if (this.OnSelectedItemChange != null)
                    this.OnSelectedItemChange.Invoke(this, new EventArgs());
            }
        }
        public PlacementMode AutoCompletePlacement
        {
            get
            {
                return (PlacementMode)GetValue(AutoCompletePlacementDependencyProperty);
            }
            set
            {
                SetValue(AutoCompletePlacementDependencyProperty, value);
            }
        }
        public UIElement AutoCompletePlacementTarget
        {
            get
            {
                return (UIElement)GetValue(AutoCompletePlacementTargetDependencyProperty);
            }
            set
            {
                SetValue(AutoCompletePlacementTargetDependencyProperty, value);
            }
        }
        public double AutoCompleteHorizontalOffset
        {
            get { return (double)GetValue(AutoCompleteHorizontalOffsetDependencyProperty); }
            set { SetValue(AutoCompleteHorizontalOffsetDependencyProperty, value); }
        }
        public double AutoCompleteVerticalOffset
        {
            get { return (double)GetValue(AutoCompleteVerticalOffsetDependencyProperty); }
            set { SetValue(AutoCompleteVerticalOffsetDependencyProperty, value); }
        }
        public double AutoCompleteWidth
        {
            get { return (double)GetValue(AutoCompleteWidthDependencyProperty); }
            set
            {
                SetValue(AutoCompleteWidthDependencyProperty, value);
            }
        }
        public double AutoCompleteHeight
        {
            get { return (double)GetValue(AutoCompleteHeightDependencyProperty); }
            set
            {
                SetValue(AutoCompleteHeightDependencyProperty, value);
            }
        }

        // allows programmer to filter records as per input
        public event TextChangedEventHandler OnTextChange;
        // to perform operation on ItemSelection Changed
        public event EventHandler OnSelectedItemChange;

        //public ICommand cmdGetSelectedValues { get; }
        public RelayCommand<object> cmdGetSelectedValues { get; private set; }
        public AutoCompleteTextBox()
        {
            AutoCompleteColumns = new ObservableCollection<DataGridColumn>();
            //cmdGetSelectedValues = new RelayCommand<object>(GetSelectedValues);
            cmdGetSelectedValues = new RelayCommand<object>(items => { if (items == null) { return; } GetSelectedValues(items); });
            //// Added for Filter function
            columnFilters = new Dictionary<string, string>();
            propertyCache = new Dictionary<string, PropertyInfo>();
            IsFilteringCaseSensitive = false;
        }

        private void GetSelectedValues(object Parameter)
        {
            string strTemp = "";
            foreach (var item in AutoCompleteItemSource)
            {
                object IndexcolumnValue = GetValueByColumnName(item, "selected");
                object columnValue = item;
                if (IndexcolumnValue.ToString().ToLower() == "true")
                {
                    strTemp = (strTemp.ToString() ?? "") + "," + (columnValue.ToString() ?? "");
                }
            }
            foreach (var item in DG_AC.SelectedItems)
            {
                strTemp = (strTemp.ToString() ?? "") + "," + (item.ToString() ?? "");
            }
            strTemp = this.SelectedItem + strTemp;// This will append to previous exist values.
            strTemp = (strTemp.ToString() ?? "").TrimStart(',');
            strTemp = UIServices.RemoveDuplicates(strTemp);
            this.SelectedItem = strTemp;
            TXT_SEARCHINPUT.Text = this.SelectedItem.ToString();
            PUP_AC.IsOpen = false;
        }
        static object GetValueByColumnName(object obj, string columnName)
        {
            Type type = obj.GetType();
            PropertyInfo property = type.GetProperty(columnName);

            if (property != null)
            {
                return property.GetValue(obj);
            }

            return null;
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            TXT_SEARCHINPUT = this.Template.FindName("TXT_SEARCHINPUT", this) as TextBox;
            TXT_SEARCHINPUT.TextChanged += TXT_SEARCHINPUT_TextChanged;
            TXT_SEARCHINPUT.PreviewKeyDown += TXT_SEARCHINPUT_PreviewKeyDown;
            //TXT_SEARCHINPUT.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(TXT_SEARCHINPUT_GotKeyboardFocus); // New added by sunil on 27-07-2022 for opup opn as soon as cursor set on TextBox.
            TXT_SEARCHINPUT.PreviewLostKeyboardFocus += HandlePreviewLostKeyboardFocus;
            //TXT_SEARCHINPUT.PreviewMouseDown += TextTokensControl_PreviewMouseDown;

            PUP_AC = this.Template.FindName("PUP_AC", this) as Popup;

            DG_AC = this.Template.FindName("DG_AC", this) as DataGrid;
            DG_AC.MouseLeftButtonUp += DG_AC_MouseLeftButtonUp;
            foreach (DataGridColumn column in AutoCompleteColumns)
            {
                if (column.Visibility != Visibility.Collapsed)
                {
                    DG_AC.Columns.Add(column);
                }
            }
        }

        //Select Item From List On Mouse Click
        private void DG_AC_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = DG_AC.SelectedItem;

            //this.SelectedItem = item; NOTE : Commented on 15-07-2023 and added below condition
            if (AutoCompleteMode != "Extended")
            {
                this.SelectedItem = item;
            }

            //TXT_SEARCHINPUT.Text = item.ToString();
            if (item == null && DG_AC.Items.Count > 0)
            {
                this.SelectedItem = null;
                return;
            }
            
            if (PUP_AC.IsOpen)
            {
                if (AutoCompleteMode != "Extended")
                {
                    this.SelectedItem = item;
                    //TXT_SEARCHINPUT.Text = this.SelectedItem.ToString();
                    PUP_AC.IsOpen = false;
                }
            }
        }

        // Navigatse through Items using Up/Down keyboard keys and select item on Enter key
        private void TXT_SEARCHINPUT_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Down)
            {
                if (DG_AC.Items.Count > 0)
                {
                    int SelectedIndex = DG_AC.SelectedIndex;
                    if (SelectedIndex < DG_AC.Items.Count)
                        DG_AC.SelectedIndex++;
                }
            }
            else if (e.Key == System.Windows.Input.Key.Up)
            {
                if (DG_AC.Items.Count > 0)
                {
                    int SelectedIndex = DG_AC.SelectedIndex;
                    if (SelectedIndex > 0)
                        DG_AC.SelectedIndex--;
                }
            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
                var item = DG_AC.SelectedItem;
                //TXT_SEARCHINPUT.Text = this.SelectedItem.ToString();
                if (item == null && DG_AC.Items.Count > 0)
                {
                    //this.SelectedItem = null; // NOTE: Commented on 26-07-2023 because if enter , it set null to existing old value also
                    if (PUP_AC.IsOpen) // NOTE: added by sunil to exit when enter and free text inserted, actually when free text is being added, popup should automatically closed if free text allowed. Not required this logic on both function 1) TXT_SEARCHINPUT_TextChanged 2) TXT_SEARCHINPUT_PreviewKeyDown. remove either one if other is perfect
                    {
                        if (AutoCompleteMode != "Extended")
                        {
                            PUP_AC.IsOpen = false;
                        }
                    }
                    return;
                }

                if (PUP_AC.IsOpen)
                {
                    if (AutoCompleteMode != "Extended")
                    {
                        this.SelectedItem = item;
                        PUP_AC.IsOpen = false;
                    }
                    else
                    {
                        GetSelectedValues(DG_AC.SelectedItems);
                    }
                }
                

            }
        }

        //Displays AutoComplete Pupup On User Input And Fire Event  'OnTextChange' to filter records
        private void TXT_SEARCHINPUT_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (SelectedItem != null && SelectedItem.ToString() != TXT_SEARCHINPUT.Text)
            //    this.SelectedItem = null;
            ////else if (!string.IsNullOrWhiteSpace(TXT_SEARCHINPUT.Text))
            ////    this.SelectedItem = TXT_SEARCHINPUT.Text;

            if (string.IsNullOrEmpty(TXT_SEARCHINPUT.Text))
            {
                if (AutoCompleteMode != "Extended")
               {
                    PUP_AC.IsOpen = false;
                }
            }
            else
            {
                if (DG_AC.Items.Count > 0 && TXT_SEARCHINPUT.IsKeyboardFocused)
                {
                    PUP_AC.IsOpen = true;
                }
            }

            //if (SelectedItem == null && PUP_AC.IsOpen) // NOTE: added by sunil to exit when enter and free text inserted, actually when free text is being added, popup should automatically closed if free text allowed. Not required this logic on both function 1) TXT_SEARCHINPUT_TextChanged 2) TXT_SEARCHINPUT_PreviewKeyDown. remove either one if other is perfect
            //{
            //    if (AutoCompleteMode != "Extended")
            //{
            //    PUP_AC.IsOpen = false;
            //}
            //}
            foreach (DataGridColumn column in DG_AC.Columns)
            {
                //string ColumnPath = ((System.Windows.Data.Binding)((System.Windows.Controls.DataGridBoundColumn)column).Binding).Path.Path.ToString(); //  Commeted this line because it is shifted to UIServices.GetBindingPath method.
                string ColumnPath = UIServices.GetBindingPath(column);
                /*if (column.Header != null)*/
                if (ColumnPath != null)
                {
                    //columnFilters[column.Header.ToString()] = TXT_SEARCHINPUT.Text;
                    columnFilters[ColumnPath] = TXT_SEARCHINPUT.Text;
                }
            }
            ApplyFilters();
            
            if (DG_AC.Items.Count > 0 && TXT_SEARCHINPUT.IsKeyboardFocused==true)// && TXT_SEARCHINPUT.IsFocused==true // If record exists in grid then only go to this elase do not open popup for 0 row and it means input is by user not by popup.
            {
                PUP_AC.IsOpen = true;
            }
            else // keep popup close if user input instead of popup selection.
            {
                if (AutoCompleteMode != "Extended")
                {
                    PUP_AC.IsOpen = false;
                }
            }
            if (this.OnTextChange != null)
                this.OnTextChange.Invoke(sender, e);
        }

        //private void TXT_SEARCHINPUT_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    if (PUP_AC.IsOpen == false)
        //    {
        ////        if (AutoCompleteMode != "Extended")
        //        {
        //            PUP_AC.IsOpen = false;
        //        }
        //    }
        //}

        #region Filter Section

        //================= Filter Section Start =================================================================================================

        /// <summary>
        /// This dictionary will have a list of all applied filters
        /// </summary>
        private Dictionary<string, string> columnFilters;
        
    /// <summary>
    /// Cache with properties for better performance
    /// </summary>
    private Dictionary<string, PropertyInfo> propertyCache;
       
    /// <summary>
    /// Case sensitive filtering
    /// </summary>
    public static DependencyProperty IsFilteringCaseSensitiveProperty =
    DependencyProperty.Register("IsFilteringCaseSensitive", typeof(bool), typeof(AutoCompleteTextBox), new PropertyMetadata(true));

    /// <summary>
    /// Case sensitive filtering
    /// </summary>
    public bool IsFilteringCaseSensitive
    {
        get { return (bool)(GetValue(IsFilteringCaseSensitiveProperty)); }
        set { SetValue(IsFilteringCaseSensitiveProperty, value); }
    }
        
    /// <summary>
    /// Apply the filters
    /// </summary>
    /// <param name="border"></param>
    private void ApplyFilters()
    {
        // Get the view
        ICollectionView view = CollectionViewSource.GetDefaultView(DG_AC.ItemsSource);

        if (view != null)
        {
            // Create a filter
            view.Filter = delegate (object item)
            {
                // Show the current object
                bool show = false;
                // Loop filters
                foreach (KeyValuePair<string, string> filter in columnFilters)
                {
                    if (string.IsNullOrWhiteSpace(filter.Value.Trim()))
                    {
                        show = true;
                        break;
                    }
                    object property = GetPropertyValue(item, filter.Key);
                    if (property != null)
                    {
                        // Check if the current column contains a filter
                        bool containsFilter = false;
                        //if (IsFilteringCaseSensitive)
                        //    containsFilter = property.ToString().Contains(filter.Value.Trim());
                        //else
                        //    containsFilter = property.ToString().ToLower().Contains(filter.Value.Trim().ToLower());
                        containsFilter = SearchWordsInList(property.ToString().ToLower(), filter.Value.Trim(), IsFilteringCaseSensitive);
                        //containsFilter = ((property != null) || property.ToString().ToLower().Contains(filter.Value.Trim().ToLower()));

                        //Do the necessary things if the filter is not correct
                        if (containsFilter)
                        {
                            show = true;
                            break;
                        }
                    }
                }
            // Return if it's visible or not
            return show;
        };
                
        }
    }

    private void ApplyFiltersOrg()
    {
        // Get the view
        ICollectionView view = CollectionViewSource.GetDefaultView(DG_AC.ItemsSource);

        if (view != null)
        {
            // Create a filter
            view.Filter = delegate (object item)
            {
                // Show the current object
                bool show = false;
                // Loop filters
                foreach (KeyValuePair<string, string> filter in columnFilters)
                {
                    if (string.IsNullOrWhiteSpace(filter.Value.Trim()))
                    {
                        show = true;
                        break;
                    }
                    object property = GetPropertyValue(item, filter.Key);
                    if (property != null)
                    {
                        // Check if the current column contains a filter
                        bool containsFilter = false;
                        if (IsFilteringCaseSensitive)
                            containsFilter = property.ToString().Contains(filter.Value.Trim());
                        else
                            containsFilter = property.ToString().ToLower().Contains(filter.Value.Trim().ToLower());
                        //containsFilter = ((property != null) || property.ToString().ToLower().Contains(filter.Value.Trim().ToLower()));

                        //Do the necessary things if the filter is not correct
                        if (containsFilter)
                        {
                            show = true;
                            break;
                        }
                    }
                }
                // Return if it's visible or not
                return show;
            };

        }
    }

    /// <summary>
    /// Get the value of a property
    /// </summary>
    /// <param name="item"></param>
    /// <param name="property"></param>
    /// <returns></returns>
    private object GetPropertyValue(object item, string property)
    {
        // No value
        object value = null;

        // Get property  from cache
        PropertyInfo pi = null;
        if (propertyCache.ContainsKey(property))
            pi = propertyCache[property];
        else
        {
            pi = item.GetType().GetProperty(property);
            propertyCache.Add(property, pi);
        }

        // If we have a valid property, get the value
        if (pi != null)
            value = pi.GetValue(item, null);

        // Done
        return value;
    }

    static bool SearchWordsInList(string inputList, string searchWords, bool IsFilteringCaseSensitive)
    {
        bool ReturenValue = true;
        List<string> SearchWordslist = new List<string>(searchWords.Split(',',' '));

        foreach (string word in SearchWordslist)
        {
            if (IsFilteringCaseSensitive)
                ReturenValue = inputList.ToString().Contains(word) ;
            else
                ReturenValue = inputList.ToString().ToLower().Contains(word.Trim().ToLower());

            if (ReturenValue)
            {
                return ReturenValue;
            }
        }

        return ReturenValue;
    }

    //================= Filter Section End =================================================================================================

    #endregion

    // NOTE: added this on 09/07/2023 from AutiSuggestControl to new popup control.
    #region keep Focus on TextBox while using popup grid

    // This event is added to prevent shifting Keyboard Focus to Popup Grid from TextBox while selection of 
    // values from grid. without this function focust shift to DataGridCell and call InsertFunction in VM 
    // without selected values. also create complications is server trip exists then it loss focus 
    // permanantly and need to reselect values again.// This Function Prevent Autosuggest LostFocus when 
    // Focus shift from TextBox to Popup Grid. 
    private void HandlePreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
    {
        try
        {
                

            if (e.OldFocus != null && e.NewFocus != null)
            {
                //===========================================================================
                // Prevent Tab index freeze at popup attached textBox. thi blck of code identify the Datagrid and if next 
                // focus is on popup grid then only this code should execute to prevent focus shifting while selecting value 
                // from dropdown list of popup datagrid.
                string dgName = "";
                var elementWithFocus = e.NewFocus;
                    
                if (elementWithFocus.GetType().Name == "DataGridCell")
                {
                    DataGridColumn result = ((DataGridCell)elementWithFocus).Column;
                    PropertyInfo propertyInfo = result.GetType().GetProperty("DataGridOwner", BindingFlags.Instance | BindingFlags.NonPublic);
                    DataGrid dgObj = propertyInfo.GetValue(result, null) as DataGrid;
                    dgName = dgObj.Name;

                    if (dgObj.Name == "DG_AC")
                    {
                        if (e.NewFocus is TextBox)
                        {
                            // Allow focus to shift to the TextBox
                            return;
                        }
                        // Prevent focus from shifting to the popup
                        e.Handled = true;
                    }
                    // NOTE: we can remove following commented code.
                    //if (((e.OldFocus.GetType()).Name ?? "") == "TextBox" && ((e.NewFocus.GetType()).Name ?? "") == "DataGridCell" && dgName == "DG_AC" && dgObj.SelectedItem != null && dgObj.Name == "DG_AC")
                    //{
                    //    //e.Handled = true;
                            
                    //    TXT_SEARCHINPUT.CaretIndex = TXT_SEARCHINPUT.Text.Length;
                    //    TXT_SEARCHINPUT.Select(TXT_SEARCHINPUT.Text.Length, 0);
                    //    TXT_SEARCHINPUT.Focus();
                    //    e.Handled = true;
                    //    //TXT_SEARCHINPUT.Text = dgObj.SelectedItem.ToString();
                    //    //this.SelectedItem = dgObj.SelectedItem;
                    //}
                }
                //NOTE: All above code except inner most if condition need to removed and use simple logic to get DataGrid Name of next focus. we need this code only for popup DataGrid. need solution without using reflection namespace.
                //============================================================================

            }
        }
        catch (Exception ex) { }
    }

    #endregion
    }
}
