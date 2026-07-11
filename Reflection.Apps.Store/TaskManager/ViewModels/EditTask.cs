using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Apps.Store.TaskManager
{
    public class EditTask : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _filterStringAssignTo;
        #region Constructors
        public RelayCommand<IList> SelectionChangedCommandAssignTo
        {
            get;
            private set;
        }
        public EditTask()
        {
            SelectionChangedCommandAssignTo = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                AssignTo(items);
            });

            m_task = new DraftTask();
            m_task.PropertyChanged += task_propertyChanged;
            validateDescription();
        }

        #endregion Constructors
        private void AssignTo(IList AssignToList)
        {
            IList list = AssignToList as IList;
            List<ADM_M010_PopUp> SelectedAssignToTemp = list.Cast<ADM_M010_PopUp>().ToList();
            if (SelectedAssignToTemp.Count > 0)
            {
                Task.assign_to = SelectedAssignToTemp[0].id.ToString();
                Task.AssignToUser = SelectedAssignToTemp[0].AssignToUser;
            }
        }


        //public int SetPriority()
        //{
        //    return 0;
        //}

        #region Properties

        public string DescriptionString
        {
            get { return (Task == null) ? null : Task.task_desc; }
            set { Task.task_desc = value; }
        }

        public string DueString
        {
            get
            {
                if (Task == null) return null;
                return PrettyDateConverter.Convert(Task.end_date, false);
            }
            set
            {
                string errorMessage = null;
                value = value.SuperTrim();
                if (value == null)
                {
                    Task.end_date = null;
                }
                else
                {
                    Task.end_date = DateParser.ParseDate(value);
                    if (Task.end_date == null) errorMessage = "Could not parse the inputted value";
                }

                setError("DueString", errorMessage);

            }
        }

        public bool HasErrors
        {
            get
            {
                validateDescription();
                return false;
            }
        }

        public DraftTask Task
        {
            get
            {
                return m_task;
            }
            set
            {
                if (m_task != null) m_task.PropertyChanged -= task_propertyChanged;
                m_task = value;
                if (m_task != null) m_task.PropertyChanged += task_propertyChanged;
                //TODO: re-parse the task string

                validateDescription();

                OnPropertyChanged(new PropertyChangedEventArgs("Task"));
                OnPropertyChanged(new PropertyChangedEventArgs("DueString"));
                OnPropertyChanged(new PropertyChangedEventArgs("DescriptionString"));
            }
        }

        public string TaskString
        {
            get { return m_taskString; }
            set
            {
                if (value != m_taskString)
                {
                    m_taskString = value;
                    string parseError = null;
                    Task = TaskParser.TryParse(value, out parseError);
                    setError("TaskString", parseError);
                    OnPropertyChanged(new PropertyChangedEventArgs("TaskString"));
                }
            }
        }

        #endregion Properties

        #region Events

        public event EventHandler Committed;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Public Methods

        public void Commit()
        {
            OnCommitted(EventArgs.Empty);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnCommitted(EventArgs e)
        {
            var handler = Committed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string error = null;
                m_propertyErrors.TryGetValue(columnName, out error);
                return error;
            }
        }

        #endregion

        #region Private Instance Implementation

        private void setError(string columnName, string errorString)
        {
            if (errorString == null)
            {
                m_propertyErrors.Remove(columnName);
            }
            else
            {
                m_propertyErrors[columnName] = errorString;
            }
        }

        private void task_propertyChanged(object sender, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case "end_date":
                    OnPropertyChanged(new PropertyChangedEventArgs("DueString"));
                    return;
                case "task_desc":
                    validateDescription();
                    OnPropertyChanged(new PropertyChangedEventArgs("DescriptionString"));
                    return;
            }
            // m_taskString = null;-----------------------------------------------------------change
            OnPropertyChanged(new PropertyChangedEventArgs("TaskString"));
        }

        private void validateDescription()
        {
            if (Task == null) return;
            string errorMessage = null;
            if (Task.task_desc == null)
            {
                errorMessage = "Description shouldn't be null";
            }
            setError("DescriptionString", errorMessage);
        }

        private string m_taskString;
        private DraftTask m_task;
        private readonly Dictionary<string, string> m_propertyErrors =
          new Dictionary<string, string>();

        #endregion
    }
}
