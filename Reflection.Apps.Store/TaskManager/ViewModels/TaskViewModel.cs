using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using System.Collections;

namespace Reflection.Apps.Store.TaskManager
{
    public class TaskViewModel : INotifyPropertyChanged
    {


        #region Fields

        private bool m_isVisible = true;

        #endregion Fields
          public RelayCommand<IList> SelectionChangedCommand_singal1
        {
            get;
            private set;
        }
        #region Constructors
        
        public TaskViewModel(Reflection.Apps.Store.TaskManager.Task task)
        {
            //Util.RequireNotNull(task, "task");
            Task = task;

            task.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals("completed") || args.PropertyName.Equals("end_date"))
                {
                    OnPropertyChanged(new PropertyChangedEventArgs("SignificantDate"));
                }
            };
            SelectionChangedCommand_singal1 = new RelayCommand<IList>(
         items =>
         {
             if (items == null)
             {
                 return;
             }
             GetSelectedList(items);
         });

        }
      private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;

        }
        #endregion Constructors

        #region Properties

        public bool IsVisible
        {
            get { return m_isVisible; }
            set
            {
                m_isVisible = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsVisible"));
            }
        }

        public DateTime? SignificantDate
        {
            get
              {
                if (this.Task.end_date.HasValue)
                {
                    return this.Task.end_date;
                }
                else
                {
                    return DateTime.Today;
                }
            }
        }

        public Reflection.Apps.Store.TaskManager.Task Task { get; private set; }

        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertychanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Events

        #region Protected Methods

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion Protected Methods

        #region Entity Object

        private Task _SelectedTask;
        public Task SelectedTask
        {
            get
            {
                //this.ErrorExist = _SelectedTask.HasErrors;
                return _SelectedTask;
            }
            set
            {
                if (_SelectedTask != value)
                {
                    _SelectedTask = value;
                    RaisePropertychanged("SelectedZADM_M013");
                    //value.BeginEdit();
                }
            }
        }

        #endregion


       
       

    }
}
