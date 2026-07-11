using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PixelLab.Common;
using PixelLab.Wpf;
using System.ComponentModel;
using Reflection.Presentation.Services;

namespace Reflection.Apps.Store.TaskManager
{
    public class Filters
    {
        #region Fields

        //public ICommand Command { get; }

        private readonly IDictionary<string, Func<Reflection.Apps.Store.TaskManager.Task, bool>> m_items;
        private readonly RelayCommand<string> m_setCurrentCommand;
        //private readonly CommandWrapper<string> m_setCurrentCommand;
        private readonly TaskData m_taskList;
        
        #endregion Fields

        #region Constructors

        public Filters(TaskData taskList)
        {
            Util.RequireNotNull(taskList, "taskList");
            m_taskList = taskList;

            m_items = new Dictionary<string, Func<Reflection.Apps.Store.TaskManager.Task, bool>>();
            //m_items = new Dictionary<string, Func<Task, bool>>();
            
            m_items.Add("All Tasks", task => true);

            m_items.Add("Not Completed", task => !(bool)task.completed);
            //m_items.Add("Not Completed", task => !task.IsComplete);

            m_items.Add("Important Tasks", task => task.tsk_priority == "1");
            //m_items.Add("Important Tasks", task => task.IsImportant == true);

            //m_items.Add("Unimportant Tasks", task => task.tsk_priority == 0);
            //m_items.Add("Unimportant Tasks", task => task.IsImportant == false);

            m_items.Add("No Unimportant Tasks", task => task.tsk_priority == null);
            //m_items.Add("No Unimportant Tasks", task => task.IsImportant != false);

            m_items.Add("Due Today", task =>
            {
                if ((bool)task.completed) return false;
                if (!task.end_date.HasValue) return false;
                return task.end_date.Value.Date == DateTime.Today;
            });

            //m_items.Add("Due Today", task =>
            //{
            //    if (task.IsComplete) return false;
            //    if (!task.Due.HasValue) return false;
            //    return task.Due.Value.Date == DateTime.Today;
            //});

            m_items.Add("Due Soon", task =>
            {
                if ((bool)task.completed) return false;
                if (!task.end_date.HasValue) return false;
                return task.end_date.Value.Date >= DateTime.Today && task.end_date.Value <= DateTime.Today.AddDays(3);
            });

            //m_items.Add("Due Soon", task =>
            //{
            //    if (task.IsComplete) return false;
            //    if (!task.Due.HasValue) return false;
            //    return task.Due.Value.Date >= DateTime.Today && task.Due.Value <= DateTime.Today.AddDays(3);
            //});

            m_items.Add("Overdue", task => task.end_date < DateTime.Now && !(bool)task.completed);

            //m_items.Add("Overdue", task => task.Due < DateTime.Now && !task.IsComplete);

            m_items.Add("Not Scheduled", task => task.end_date == null);

            m_items.Add("Completed", task => (bool)task.completed);

            //m_items.Add("Completed", task => task.IsComplete);

            m_setCurrentCommand = new RelayCommand<string>(
            //m_setCurrentCommand = new CommandWrapper<string>(
                filterName => Current = filterName,
                filterName => Current != filterName && m_items.ContainsKey(filterName));

            var current = m_taskList.Filter;
            if (current == null || !m_items.ContainsKey(current))
                current = Items[0];

            Current = current;

            m_items.Add("Assign By Tasks", task => task.assign_by == AppSessionState.UserID);
            m_items.Add("Assign To Tasks", task => task.assign_to == AppSessionState.UserID);
        }

        #endregion Constructors

        #region Properties

        public string Current
        {
            get { return m_taskList.Filter; }
            private set
            {
                if (value != m_taskList.Filter)
                {
                    Util.RequireArgument(m_items.ContainsKey(value), "value"); //uncommented by Priyanka
                    m_taskList.Filter = value;

                    m_setCurrentCommand.RaiseCanExecuteChanged();
                    OnCurrentChanged(EventArgs.Empty);
                }
            }

            //get { return m_taskList.Filter; }
            //private set
            //{
            //    if (value != m_taskList.Filter)
            //    {
            //        Util.RequireArgument(m_items.ContainsKey(value), "value");
            //        m_taskList.Filter = value;
       
            //        m_setCurrentCommand.UpdateCanExecute();
            //        OnCurrentChanged(EventArgs.Empty);
            //    }
            //}
        }

        public IList<string> Items { get { return m_items.Keys.ToArray(); } }

        public ICommand SetCurrentCommand { get { return m_setCurrentCommand; } }
        //public ICommand SetCurrentCommand { get { return m_setCurrentCommand.Command; } }

        #endregion Properties

        #region Events

        public event EventHandler CurrentChanged;

        #endregion Events

        #region Public Methods

        public bool InCurrent(Reflection.Apps.Store.TaskManager.Task task)
        {
            return m_items[m_taskList.Filter](task);
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnCurrentChanged(EventArgs e)
        {
            var handler = CurrentChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods
    }
}
