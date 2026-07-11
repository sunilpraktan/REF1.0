using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Reflection.Presentation.Core.Configuration;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Widgets;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using NLog;
using GalaSoft.MvvmLight.Command;

namespace Reflection.Shell.WidgetLibrary
{
    /// <summary>
    /// Widget library ViewModel
    /// </summary>
    public sealed class WidgetLibraryViewModel
        : WidgetViewModel
    {
        #region · Constants ·

        private static readonly string AllWidgetsKey = "All";

        #endregion

        #region · PropertyChangedEventArgs Cached Instances ·

        private static readonly PropertyChangedEventArgs FilterChangedArgs = CreateArgs<WidgetLibraryViewModel>(x => x.Filter);
        private static readonly PropertyChangedEventArgs WidgetsChangedArgs = CreateArgs<WidgetLibraryViewModel>(x => x.Widgets);
        private static readonly PropertyChangedEventArgs SelectedWidgetChangedArgs = CreateArgs<WidgetLibraryViewModel>(x => x.SelectedWidget);

        #endregion

        #region · Fields ·

        private string filter;
        private List<string> groups;
        private List<WidgetItemViewModel> widgets;
        private IWidget selectedWidget;
        private RelayCommand createWidgetCommand;

        #endregion

        #region · Commands ·

        /// <summary>
        /// Gets the create widget command.
        /// </summary>
        /// <value>The create widget command.</value>
        public RelayCommand CreateWidgetCommand
        {
            get
            {
                if (this.createWidgetCommand == null)
                {
                    this.createWidgetCommand = new RelayCommand
                    (
                        () => OnCreateWidget(),
                        () => CanCreateWidget()
                    );
                }

                return this.createWidgetCommand;
            }
        }

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets/sets a fragment of the name to filter for.
        /// </summary>
        public string Filter
        {
            get { return this.filter; }
            set
            {
                if (value != filter)
                {
                    this.filter = value;
                    this.NotifyPropertyChanged(FilterChangedArgs);
                    this.NotifyPropertyChanged(WidgetsChangedArgs);

                    this.SelectedWidget = null;
                }
            }
        }

        /// <summary>
        /// Gets the list of widget groups.
        /// </summary>
        /// <value>The groups.</value>
        public IEnumerable<string> Groups
        {
            get { return this.groups; }
        }

        /// <summary>
        /// Gets the list of widgets
        /// </summary>
        public IList<WidgetItemViewModel> Widgets
        {
            get
            {
                if (String.IsNullOrEmpty(this.filter)
                    || this.filter == AllWidgetsKey)
                {
                    return this.widgets;
                }
                else
                {
                    return new ReadOnlyCollection<WidgetItemViewModel>(this.widgets.Where(x => x.Group == this.filter).ToList());
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected widget.
        /// </summary>
        /// <value>The selected widget.</value>
        public IWidget SelectedWidget
        {
            get { return this.selectedWidget; }
            set
            {
                if (this.selectedWidget != value)
                {
                    this.selectedWidget = value;
                    this.NotifyPropertyChanged(SelectedWidgetChangedArgs);
                    //this.CreateWidgetCommand.CanExecute(SelectedWidgetChangedArgs);
                }
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="WidgetLibrary"/> class.
        /// </summary>
        public WidgetLibraryViewModel()
            : base()
        {
            this.widgets = this.DiscoverWidgets();
            this.groups = this.DiscoverWidgetGroups();
        }

        #endregion

        #region · Overriden Methods ·

        /// <summary>
        /// Called when the related view is being closed.
        /// </summary>
        public override void Close()
        {
            base.Close();

            this.selectedWidget = null;
            this.createWidgetCommand = null;

            if (this.groups != null)
            {
                this.groups.Clear();
                this.groups = null;
            }

            if (this.widgets != null)
            {
                this.widgets.Clear();
                this.widgets = null;
            }
        }

        #endregion

        #region · Command Actions ·

        private bool CanCreateWidget()
        {
            return (this.selectedWidget != null);
        }

        /// <summary>
        /// Handles the create widget command.
        /// </summary>
        private void OnCreateWidget()
        {
            this.GetService<IVirtualDesktopManager>()
                .Show(this.selectedWidget.CreateView() as IDesktopElement);
        }

        #endregion

        #region · Private Methods ·

        private List<string> DiscoverWidgetGroups()
        {
            List<string> groups = new List<string>();
            var q = from widgetdef in this.widgets
                    select widgetdef.Group;

            groups.Add(AllWidgetsKey);
            groups.AddRange(q.Distinct().ToList());

            return groups;
        }

        private List<WidgetItemViewModel> DiscoverWidgets()
        {
            IEnumerable<IWidget> widgetDefs = this.GetService<IWidgetConfigurationService>()
                                                  .GetWidgets();

            if (widgetDefs != null)
            {
                var query = from widgetdef in widgetDefs
                            select new WidgetItemViewModel(widgetdef);

                return query.ToList();
            }

            return null;
        }

        #endregion
    }
}
