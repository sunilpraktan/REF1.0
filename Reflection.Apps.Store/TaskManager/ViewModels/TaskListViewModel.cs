using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Reflection;

namespace Reflection.Apps.Store.TaskManager
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        #region Fields
        TaskDAL dal = new TaskDAL();
        private EditTask m_newTask;
        private BaseTask m_TaskInfo;
        private readonly RelayCommand<Reflection.Apps.Store.TaskManager.Task> m_deleteTaskCommand;
        private readonly Func<Reflection.Apps.Store.TaskManager.Task, bool> m_filter;
        private readonly TaskData m_taskList;
        private readonly ObservableCollection<TaskViewModel> m_unfilteredTaskList;
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringAssignTo;

        #endregion Fields

        #region Constructors
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public TaskListViewModel(TaskData taskList, Func<Reflection.Apps.Store.TaskManager.Task, bool> filter)
        {
            //Util.RequireNotNull(taskList, "taskList");
            m_taskList = taskList;
            ((INotifyCollectionChanged)m_taskList.Tasks).CollectionChanged += (sender, args) => RefreshFilter();

            //Util.RequireNotNull(filter, "filter");
            m_filter = filter;

            m_unfilteredTaskList = new ObservableCollection<TaskViewModel>();

            //m_taskList.Tasks.ForEach(t => m_unfilteredTaskList.Add(new TaskViewModel(t)));
            m_taskList.Tasks.ToList().ForEach(t => m_unfilteredTaskList.Add(new TaskViewModel(t)));

            // Tasks
            m_newTaskCommand = new RelayCommand(ShowNewTask, () => m_newTask == null);
            m_cancelNewTaskCommand = new RelayCommand(() => CancelNewTask(), () => m_newTask != null);
            m_deleteTaskCommand = new RelayCommand<Reflection.Apps.Store.TaskManager.Task>(task => DeleteTask(task), task => true);
            // m_setPriorityCommand = new RelayCommand(SetPriority, () => m_newTask != null);

            //CollectionAssignToList.Filter = new Predicate<object>(FilterAssignTo);  //new added code
            //DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);  //new added code
            //DataGridCollection.Filter = new Predicate<object>(Filter);  //new added code
            SelectionChangedCommand = new RelayCommand<IList>(
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
            #region Test code
            //object dataSource = list[0];
            //object[] datasource1 = new object[3];
            ////Reflection.Apps.Store.TaskManager.Task - kkkk
            //datasource1[0] = dataSource;
            //string displayMember = "folder_name";
            //string valueMember = "folder_name";

            //IEnumerable list123 = (IEnumerable)dataSource;
            //Type elementType = list.GetType().GetGenericArguments()[0];
            //PropertyInfo property = elementType.GetProperty(displayMember);

            //List<object> displayValues = list.Cast<object>()
            //                                 .Select(v => property.GetValue(v, null))
            //                                 .ToList();

          
            //IEnumerable list1 = (IEnumerable)dataSource;
            //Type elementType1 = list.GetType().GetGenericArguments()[0];
            //PropertyInfo property1 = elementType.GetProperty(displayMember);

            //List<object> displayValues1 = list.Cast<object>()
            //                                 .Select(v => property1.GetValue(v, null))
            //                                 .ToList();
            #endregion


        }
        #endregion Constructors

        #region Properties

        public ObservableCollection<TaskViewModel> AllTasks
        {
            get { return m_unfilteredTaskList; }
        }


        public ICommand CancelNewCommand { get { return m_cancelNewTaskCommand; } }

        public ICommand DeleteTaskCommand { get { return m_deleteTaskCommand; } }

        public EditTask NewTask
        {
            get { return m_newTask; }
            private set
            {
                if (m_newTask != value)
                {
                    if (m_newTask != null)
                    {
                        m_newTask.Committed -= new_task_committed;
                    }
                    m_newTask = value;
                    if (m_newTask != null)
                    {
                        m_newTask.Committed += new_task_committed;
                    }

                    m_newTaskCommand.RaiseCanExecuteChanged();
                    m_cancelNewTaskCommand.RaiseCanExecuteChanged();

                    OnPropertyChanged(new PropertyChangedEventArgs("NewTask"));
                }
            }
        }
        public BaseTask TaskInfo
        {
            get { return m_TaskInfo; }
            private set
            {
                if (m_TaskInfo != value)
                {
                    //if (m_TaskInfo != null)
                    //{
                    //    m_newTask.Committed -= new_task_committed;
                    //}
                    m_TaskInfo = value;
                    //if (m_TaskInfo != null)
                    //{
                    //    m_newTask.Committed += new_task_committed;
                    //}

                    m_newTaskCommand.RaiseCanExecuteChanged();
                    m_cancelNewTaskCommand.RaiseCanExecuteChanged();

                    OnPropertyChanged(new PropertyChangedEventArgs("m_TaskInfo"));
                }
            }
        }

        public ICommand NewTaskCommand { get { return m_newTaskCommand; } }

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

        #region Event Handlers

        private void new_task_committed(object sender, EventArgs e)
        {
            Debug.Assert(m_newTask != null);

            m_newTask.Task = dal.InsertTaskData(m_newTask.Task);
            var newTask = m_taskList.AddTask(m_newTask.Task, TaskManagerView.Root.FolderColorOptions);
            m_unfilteredTaskList.Add(new TaskViewModel(newTask));
            m_taskList.CurrentFolder = newTask.EffectiveFolder;
            //m_newTask.Task = dal.InsertTaskData(m_newTask.Task);

            CancelNewTask();
        }

        #endregion Event Handlers

        #region Public Methods

        public void CancelNewTask()
        {
            NewTask = null;
        }

        public void DeleteTask(Reflection.Apps.Store.TaskManager.Task task)
        {
            TaskViewModel tvm = m_unfilteredTaskList.First(t => t.Task == task);
            m_unfilteredTaskList.Remove(tvm);

            m_taskList.RemoveTask(task);
        }

        public void MoveTask(Reflection.Apps.Store.TaskManager.Task item, Reflection.Apps.Store.TaskManager.Task toItem)
        {
            var itemIndex = m_taskList.Tasks.IndexOf(item);
            var toIndex = m_taskList.Tasks.IndexOf(toItem);
            m_taskList.ReorderTasks(item, toItem);
            m_unfilteredTaskList.Move(itemIndex, toIndex);
        }

        //public void SetPriority()
        //{
        //    if (m_newTask != null)
        //    {
        //        NewTask = new EditTask();
        //    }
        //}
        public void RefreshFilter()
        {
            m_unfilteredTaskList.ToList().ForEach(tm => tm.IsVisible = m_filter(tm.Task));
        }

        public void ShowNewTask()
        {
            if (m_newTask == null)
            {
                NewTask = new EditTask();
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods

        #region List Entity Object

        private List<Task> _SelectedList;
        public List<Task> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertychanged("SelectedList");
                }
            }
        }
        #endregion

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

        #region ICollectionView
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertychanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionAssignToList;
        public ICollectionView CollectionAssignToList
        {
            get { return _CollectionAssignToList; }
            set
            {
                _CollectionAssignToList = value;
                RaisePropertychanged("CollectionAssignToList");
            }
        }

        #endregion

        #region Filter

        #region User Filter
        public bool FilterAssignTo(object obj)
        {
            var data = obj as ADM_M010_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringAssignTo))
                {
                    return (data.id != null && data.id.ToString().ToLower().Contains(_filterStringAssignTo.ToLower()) || data.AssignToUser != null && data.AssignToUser.ToString().ToLower().Contains(_filterStringAssignTo.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringAssignTo
        {
            get { return _filterStringAssignTo; }
            set
            {
                _filterStringAssignTo = value;
                RaisePropertychanged("SelectedUser");
                FilterCollectionUser();
            }
        }
        private void FilterCollectionUser()
        {
            if (_CollectionAssignToList != null)
            {
                _CollectionAssignToList.Refresh();
            }
        }

        #endregion

        public bool Filter(object obj)
        {
            var data = obj as Task;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.id != null && data.id.ToString().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        private readonly RelayCommand m_newTaskCommand, m_cancelNewTaskCommand;
    }
}
