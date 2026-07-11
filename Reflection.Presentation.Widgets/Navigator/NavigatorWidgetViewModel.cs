using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Reflection.Extensions;
using Reflection.Presentation.Core.Navigation;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Navigation;
using Reflection.Presentation.Services;
using System.Data;
using System.ComponentModel;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity;

namespace Reflection.Presentation.Widgets
{
    /// <summary>
    /// Navigator Widget ViewModel
    /// </summary>
    /// <remarks>
    /// http://www.codeproject.com/KB/WPF/TreeViewWithViewModel.aspx
    /// </remarks>
    public sealed class NavigatorWidgetViewModel
        : WidgetViewModel, INotifyPropertyChanged
    {
        #region · Fields ·
        List<SYS_AUTH> _ItemsData = new List<SYS_AUTH>();
        public List<SYS_AUTH> ItemsData
        {
            get { return _ItemsData; }
            set
            {
                if (_ItemsData != value)
                {
                    _ItemsData = value;

                    RaisePropertyChanged("ItemsData");
                }
            }
        }
        DataSet _ItemsSet = new DataSet();
        public DataSet ItemsSet
        {
            get { return _ItemsSet; }
            set
            {
                if (_ItemsSet != value)
                {
                    _ItemsSet = value;

                    RaisePropertyChanged("ItemsSet");
                }
            }
        }

        DataView _ItemsView = new DataView();
        public DataView ItemsView
        {
            get { return _ItemsView; }
            set
            {
                if (_ItemsView != value)
                {
                    _ItemsView = value;

                    RaisePropertyChanged("ItemsView");
                }
            }
        }

        private readonly List<SYS_AUTH> functions;
        //private readonly ObservableCollection<MenuLists> functions;
        private List<SYS_AUTH> filteredFunctions;
        //private List<MenuLists> filteredFunctions;
        private string filterText;
        private ICommand navigateToCommand;
        private RelayCommand<string> navigatemenuCommand;
        public RelayCommand myCommand;

        #endregion
        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        #region · FirstGeneration ·

        /// <summary>
        /// Returns a read-only collection containing the first application option
        /// in the tree, to which the TreeView can bind.
        /// </summary>
        public List<SYS_AUTH> Functions
        {
            get
            {
                if (String.IsNullOrEmpty(this.filterText))
                {
                    return this.functions;
                }
                else
                {
                    return new List<SYS_AUTH>(this.filteredFunctions);
                }
            }
        }

        #endregion
        #region · Commands ·

        /// <summary>
        /// Gets the navigation command
        /// </summary>
        public ICommand NavigateToCommand
        {
            get
            {
                if (this.navigateToCommand == null)
                {
                    this.navigateToCommand = new RelayCommand<string>
                    (
                        x => OnNavigateTo(x),
                        x => CanNavigate()
                    );
                }

                return this.navigateToCommand;
            }
        }

        /// <summary>
        /// Gets the navigation command
        /// </summary>
        public RelayCommand<string> NavigateMenuCommand
        {
            get
            {
                if (this.navigatemenuCommand == null)
                {
                   this.navigatemenuCommand = new RelayCommand<string>((x) => OnNavigateToMenu(x));
                }

                return this.navigatemenuCommand;
            }
        }

        //public ICommand myCommand; // { get; private set; }

        public RelayCommand MenuCommand
        {
            get
            {
                if (this.myCommand == null)
                {
                    myCommand = new RelayCommand(()=> Test()); 
                }

                return this.myCommand;
            }
        }

    private void Test()
    {
        var msg = new NavigateToView() { ViewName = "test" };
        Messenger.Default.Send<NavigateToView>(msg);
    }
       
        #endregion

        #region · Properties ·

       

        #region · FilterText ·

        /// <summary>
        /// Gets/sets a fragment of the name to filter for.
        /// </summary>
        public string FilterText
        {
            get { return this.filterText; }
            set
            {
                if (value != filterText)
                {
                    this.filterText = value;
                    this.PerformFilter();
                }
            }
        }

        #endregion

        #endregion

        #region · Constructor ·

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigatorWidget"/> class.
        /// </summary>
        public NavigatorWidgetViewModel()
            : base()
        {
            if (!DesignMode.IsInDesignMode)
            {
                //this.filteredFunctions = new List<MenuLists>();
                //this.functions = TreeData.GetAll();
                this.filteredFunctions = new List<SYS_AUTH>();
                this.functions = (List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST;
                GetTreeData();
            }
        }
        private void GetTreeData()
        {
            ItemsData = new List<SYS_AUTH>();
            ItemsSet.Tables.Add(ConvertToDataTable(this.functions));
            //ItemsSet.Relations.Add("FK", ItemsSet.Tables[0].Columns["Id"], ItemsSet.Tables[0].Columns["ParentID"]);

            ItemsSet.Relations.Add("rsParentChild",
                    ItemsSet.Tables[0].Columns["menu_code"],
                    ItemsSet.Tables[0].Columns["menu_parent"], false);
            ItemsView = ItemsSet.Tables[0].DefaultView;
            ItemsView.RowFilter = "menu_parent IS NULL"; //see what happens when i am commented out
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        #endregion

        #region · Command Actions ·

        /// <summary>
        /// Returns a value indcating whether the navigation command can be executed
        /// </summary>
        /// <returns></returns>
        private bool CanNavigate()
        {
            return this.filteredFunctions != null && this.filteredFunctions.Count == 1;
        }
        private bool CanNavigateMenu()
        {
            return true;
        }

        /// <summary>
        /// Handles the navigation command
        /// </summary>
        private void OnNavigateTo(string url)
        {
            SimpleIoc.Default.GetInstance<INavigationService>().Navigate(url);
        }
        private void OnNavigateToMenu(string url)
        {
            //Messagenger.Default.GetInstance<INavigationService>().Navigate(url);
            var msg = new NavigateToView() { ViewName = url };
            Messenger.Default.Send<NavigateToView>(msg);
        }
        private void OnTreeNodeDoubleClick(object sender, MouseButtonEventArgs mouseEvtArgs)
        {
            var msg = new NavigateToView() { ViewName = "" };
            Messenger.Default.Send<NavigateToView>(msg);
            mouseEvtArgs.Handled = true;
        }


        #endregion

        #region · Search Logic ·

        private void PerformFilter()
        {
            this.VerifyMatchingOptionEnumerator();
        }

        private void VerifyMatchingOptionEnumerator()
        {
            // Clear current matching options
            this.filteredFunctions.Clear();

            // Perform filter if needed
            if (!String.IsNullOrEmpty(this.filterText))
            {
                this.filteredFunctions.AddRange(this.FindMatches(this.filterText));
            }

            // Notify changes
            this.NotifyPropertyChanged(() => Functions);
        }

        private List<SYS_AUTH> FindMatches(string filterText)
        {
            var nodes = from node in this.Functions
                        where node.ts_name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) && (node.ts_name != null)
                        select node;
            return nodes.ToList();
        }

        #endregion
    }
}
