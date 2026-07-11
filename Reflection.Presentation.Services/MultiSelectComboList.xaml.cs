using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Presentation.Services
{
    /// <summary>
    /// Interaction logic for MultiSelectComboList.xaml
    /// </summary>
    public partial class MultiSelectComboList : UserControl
    {
        private ObservableCollection<Node> _nodeList;
        public MultiSelectComboList()
        {
            InitializeComponent();
            _nodeList = new ObservableCollection<Node>();
        }

        #region Dependency Properties

        public static readonly DependencyProperty ItemsSourceProperty =
             DependencyProperty.Register("ItemsSource", typeof(Dictionary<string, object>), typeof(MultiSelectComboList), new FrameworkPropertyMetadata(null,
        new PropertyChangedCallback(MultiSelectComboList.OnItemsSourceChanged)));

        public static readonly DependencyProperty SelectedItemsProperty =
         DependencyProperty.Register("SelectedItems", typeof(Dictionary<string, object>), typeof(MultiSelectComboList), new FrameworkPropertyMetadata(null,
     new PropertyChangedCallback(MultiSelectComboList.OnSelectedItemsChanged)));

        public static readonly DependencyProperty TextProperty =
           DependencyProperty.Register("Text", typeof(string), typeof(MultiSelectComboList), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty DefaultTextProperty =
            DependencyProperty.Register("DefaultText", typeof(string), typeof(MultiSelectComboList), new UIPropertyMetadata(string.Empty));

        public static readonly DependencyProperty CommandProperty
= DependencyProperty.Register("Command",
                                    typeof(ICommand), typeof(MultiSelectComboList));


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public Dictionary<string, object> ItemsSource
        {
            get { return (Dictionary<string, object>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public Dictionary<string, object> SelectedItems
        {
            get { return (Dictionary<string, object>)GetValue(SelectedItemsProperty); }
            set
            {
                SetValue(SelectedItemsProperty, value);
            }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string DefaultText
        {
            get { return (string)GetValue(DefaultTextProperty); }
            set { SetValue(DefaultTextProperty, value); }
        }
        #endregion

        #region Events
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboList control = (MultiSelectComboList)d;
            control.DisplayInControl();
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MultiSelectComboList control = (MultiSelectComboList)d;
            control.SelectNodes();
            control.SetText();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox clickedBox = (CheckBox)sender;

            if (clickedBox.Content == "All")
            {
                if (clickedBox.IsChecked.Value)
                {
                    foreach (Node node in _nodeList)
                    {
                        node.IsSelected = true;
                    }
                }
                else
                {
                    foreach (Node node in _nodeList)
                    {
                        node.IsSelected = false;
                    }
                }

            }
            else
            {
                int _selectedCount = 0;
                foreach (Node s in _nodeList)
                {
                    if (s.IsSelected && s.TitleValue.ToString() != "All")
                        _selectedCount++;
                }
                //if (_selectedCount == _nodeList.Count - 1)
                //    _nodeList.FirstOrDefault(i => i.TitleValue.ToString() == "All").IsSelected = true;
                //else
                //    _nodeList.FirstOrDefault(i => i.TitleValue.ToString() == "All").IsSelected = false;
            }
            SetSelectedItems();
            SetText();

        }
        #endregion
        
        #region Methods
        private void SelectNodes()
        {
            if (SelectedItems != null)
            {
                foreach (KeyValuePair<string, object> keyValue in SelectedItems)
                {
                    Node node = _nodeList.FirstOrDefault(i => i.Title == keyValue.Key);
                    if (node != null)
                        node.IsSelected = true;
                }
            }
        }
        private void SetSelectedItems()
        {
            if (SelectedItems == null)
                SelectedItems = new Dictionary<string, object>();
            SelectedItems.Clear();
            foreach (Node node in _nodeList)
            {
                if (node.IsSelected && node.TitleValue != "All")
                {
                    if (this.ItemsSource.Count > 0)

                        SelectedItems.Add(node.Title, this.ItemsSource[node.Title]);
                }
            }
        }
        private void DisplayInControl()
        {
            _nodeList.Clear();
            //if (this.ItemsSource.Count > 0)
            //_nodeList.Add(new Node("All", "All"));
            if (this.ItemsSource != null)
            {
                foreach (KeyValuePair<string, object> keyValue in this.ItemsSource)
                {
                    Node node = new Node(keyValue.Key, keyValue.Value);
                    _nodeList.Add(node);
                }
                MultiSelectCombo.ItemsSource = _nodeList;
            }
        }
        private void SetText()
        {
            if (this.SelectedItems != null)
            {
                StringBuilder displayText = new StringBuilder();
                StringBuilder displayTag = new StringBuilder();
                foreach (Node s in _nodeList)
                {
                    if (s.IsSelected == true && s.Title == "All")
                    {
                        displayText = new StringBuilder();
                        displayText.Append("All");
                        break;
                    }
                    else if (s.IsSelected == true && s.TitleValue != "All")
                    {
                        displayText.Append(s.TitleValue);
                        displayText.Append(',');
                        displayTag.Append(s.Title);
                        displayTag.Append(',');
                    }
                }
                this.Text = displayText.ToString().TrimEnd(new char[] { ',' });
                this.Tag = displayTag.ToString().TrimEnd(new char[] { ',' });
            }
            // set DefaultText if nothing else selected
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = this.DefaultText;
            }
        }


        #endregion
    }

    public class Node : INotifyPropertyChanged
    {

        private string _title;
        private object _titleValue;
        private bool _isSelected;
        #region ctor
        public Node(string title, object titleValue)
        {
            Title = title;
            TitleValue = titleValue;
        }
        public Node(string title)
        {
            Title = title;
        }
        #endregion

        #region Properties
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public object TitleValue
        {
            get
            {
                return _titleValue;
            }
            set
            {
                _titleValue = value;
                NotifyPropertyChanged("TitleValue");
            }
        }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
