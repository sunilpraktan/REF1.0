using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;

namespace Reflection.Apps.Store.TaskManager
{
    public class Root : INotifyPropertyChanged
    {
        #region Fields

        private readonly TaskData m_taskData;
        private readonly List<Color> m_folderColorOptions;

        #endregion Fields

        #region Constructors

        public Root(TaskData taskData, IEnumerable<Color> folderColorOptions)
        {
            m_taskData = taskData;
            userData = taskData.allUsers;
            //folderData = taskData.Folders;
            m_folderColorOptions = (List<Color>)folderColorOptions;

            Tasks = new TaskListViewModel(taskData, filter);
            Timeline = new TimelineViewModel(Tasks.AllTasks);

            Filters = new Filters(taskData);
            Folders = new Folders(taskData);

            taskData.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "CurrentFolder" || args.PropertyName == "Filter")
                {
                    Tasks.RefreshFilter();
                }
            };

            DispatcherTimer dateChanger = new DispatcherTimer();
            dateChanger.Interval = TimeSpan.FromMinutes(1);
            dateChanger.Tick += new EventHandler(dateChanger_Tick);
            Tasks.RefreshFilter();
        }

        #endregion Constructors

        #region Properties

        public ObservableCollection<ADM_M010_PopUp> userData { get; private set; } //-----------------------------------remainder
        //public ObservableCollection<TSK_T001_B_Folder> folderData { get; private set; }
        public TaskData TaskData { get { return m_taskData; } }

        public IList<Color> FolderColorOptions { get { return m_folderColorOptions; } }

        public Filters Filters { get; private set; }

        public Folders Folders { get; private set; }

        public TaskListViewModel Tasks { get; private set; }

        public TimelineViewModel Timeline { get; private set; }

        public DateTime Now { get { return DateTime.Now; } }

        public DateTime Today { get { return DateTime.Today; } }

        #endregion Properties

        #region Event Handlers

        void dateChanger_Tick(object sender, EventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs("Today"));
                handler(this, new PropertyChangedEventArgs("Now"));
            }
        }

        #endregion Event Handlers

        #region Private Methods

        private bool filter(Reflection.Apps.Store.TaskManager.Task task)
        {
            return Filters.InCurrent(task) && TaskData.CurrentFolder.ContainsTask(task);
        }

        #endregion Private Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
