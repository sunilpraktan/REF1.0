using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Reflection.Presentation.ViewModel
{
    public class NavigationTreeData : INotifyPropertyChanged
    {
        string _name = "";
        ObservableCollection<MenuLists> _menulists = null;

        public NavigationTreeData()
        { }

        public NavigationTreeData(string name)
            : this(name, null)
        {
        }

        public NavigationTreeData(string name, ObservableCollection<MenuLists> menulists)
        {

            _name = name;
            _menulists = menulists;
        }

        #region Properties

        bool _isExpanded;
        bool _isSelected;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string ImageUrl
        {
            get
            {
                return "../Images/" + Name.ToLower() + ".png";
            }
        }

        public ObservableCollection<MenuLists> Countries
        {
            get
            {

                if (_menulists == null) _menulists = new ObservableCollection<MenuLists>();
                return _menulists;
            }
            set { _menulists = value; }
        }


        #region IsExpanded

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is expanded.
        /// </summary>
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }

                // Expand all the way up to the root.
                //if (_isExpanded && _parent != null)
                //    _parent.IsExpanded = true;
            }
        }

        #endregion // IsExpanded

        #region IsSelected

        /// <summary>
        /// Gets/sets whether the TreeViewItem 
        /// associated with this object is selected.
        /// </summary>
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }

        #endregion // IsSelected
        #endregion

        public override string ToString()
        {
            return base.ToString();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }

    public class MenuLists
    {
        public MenuLists()
            : this("", 0, 0)
        {
        }
        public MenuLists(string name, int elementid, int parantid)
        {
            Name = name;
            ElementId = elementid;
            ParantId = parantid;

        }

        public string Name { get; set; }
        public int ElementId { get; set; }
        public int ParantId { get; set; }

        public string ImageUrl
        {
            get
            {
                return "../Images/" + Name.ToLower() + ".png";
            }
        }
    }
    

    public class MenuItem
    {
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        public string Title { get; set; }

        public ObservableCollection<MenuItem> Items { get; set; }
    }
}
