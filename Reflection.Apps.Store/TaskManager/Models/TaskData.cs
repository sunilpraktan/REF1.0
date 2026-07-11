using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PixelLab.Common;

namespace Reflection.Apps.Store.TaskManager
{
    public sealed class TaskData : INotifyPropertyChanged
    {
        public TaskData() : this(Enumerable.Empty<Task>(), Enumerable.Empty<Folder>(), SpecialFolder.AllFolder, null, Enumerable.Empty<ADM_M010_PopUp>(), Enumerable.Empty<Task>(), Enumerable.Empty<TSK_T001_B_Folder>()) { }

        public TaskData(IEnumerable<Task> tasks, IEnumerable<Folder> folders, BaseFolder currentFolder, string filter, IEnumerable<ADM_M010_PopUp> t_allUsers, IEnumerable<Task> t_alltask,IEnumerable<TSK_T001_B_Folder> t_folders)
        {
            folders.ToList().ForEach(folder => AddFolder(folder));
            m_userFolders = new ReadOnlyCollection<Folder>(m_folderList);
            tasks.ToList().ForEach(task => AddTask(task));
            CurrentFolder = currentFolder;
            m_filter = filter;
            m_allUsers = new ObservableCollection<ADM_M010_PopUp>(t_allUsers);
            m_folders = new ObservableCollection<TSK_T001_B_Folder>(t_folders);//edited
            refreshAllFolders();
        }

        public string Filter
        {
            get { return m_filter; }
            set
            {
                if (value != m_filter)
                {
                    m_filter = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Filter"));
                }
            }
        }

        public ObservableCollection<BaseFolder> AllFolders { get { return m_allFolders; } }
        public IList<Folder> UserFolders { get { return m_userFolders; } }
        public ObservableCollection<Task> Tasks { get { return m_taskList; } }
        public ObservableCollection<ADM_M010_PopUp> allUsers { get { return m_allUsers; } }
        public ObservableCollection<TSK_T001_B_Folder> Folders { get { return m_folders; } }


        public BaseFolder CurrentFolder
        {
            get { return m_currentFolder; }
            set
            {
                value = value ?? SpecialFolder.InboxFolder;

                if (value != m_currentFolder)
                {
                    if (!value.IsSpecial)
                    {
                        Util.RequireArgument(m_folderList.Contains((Folder)value), "folder"); //uncommented
                    }
                    m_currentFolder = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("CurrentFolder"));
                }
            }
        }

        public void AddFolder(Folder folder)
        {
            //Util.RequireNotNull(folder, "folder");
            //Util.RequireArgument(!m_folderList.Contains(folder), "folder");
            //Util.RequireArgument(
            //    !m_folderList.Any(existing => existing.Name.EasyEquals(folder.Name)),
            //    "folder", "A folder with the same name exists");

            m_folderList.Add(folder);
            refreshAllFolders();
        }

        public void RemoveFolder(Folder folder)
        {
            //Util.RequireNotNull(folder, "folder");
            //Util.RequireArgument(m_folderList.Contains(folder), "folder");
            //m_taskList
            //    .Where(task => task.Folder == folder)
            //    .ForEach(task => task.Folder = null);
            m_folderList.Remove(folder);
            refreshAllFolders();
        }

        public void RenameFolder(Folder folder, string newName)
        {

            //uncommented by Priyanka
            Util.RequireNotNull(folder, "folder");
            Util.RequireArgument(m_folderList.Contains(folder), "folder");
            Util.RequireArgument(newName == newName.SuperTrim(), "newName");
            Util.RequireArgument(Folder.IsValidFolderName(newName), "newName");
            //end
            if (folder.Name == newName)
            {
                // no-op
            }
            else if (folder.Name.Equals(newName))
            {
                // just a case change -> easy
                // make darn sure we haven't broken our logic -> should only have folder that matches w/ case
                Debug.Assert(m_folderList.Count(existing => existing.Name.Equals(newName)) == 1);
                folder.UpdateName(newName);
            }
            else if (m_folderList.Count(existing => existing.Name.Equals(newName)) > 0)
            {
                Debug.Assert(m_folderList.Count(existing => existing.Name.Equals(newName)) == 1);
                var target = m_folderList.First(existing => existing.Name.Equals(newName));

                // move existing items to target folder
                m_taskList
                    .Where(task => task.Folder == folder)
                    .ForEach(task => task.Folder = target);

                // nuke existing folder
                m_folderList.Remove(folder);
                if (m_currentFolder == folder)
                {
                    CurrentFolder = target;
                }
            }
            else
            {
                // this is an entirely novel name. Cool!
                // make darn sure we haven't broken our logic -> should have no folder with matching name
                Debug.Assert(m_folderList.Count(existing => existing.Name.Equals(newName)) == 0);
                folder.UpdateName(newName);
            }

            refreshAllFolders();
        }

        public void AddTask(Task task)
        {
            //Util.RequireNotNull(task, "task");
            //Util.RequireArgument(!m_taskList.Contains(task), "task");
            //Util.RequireArgument(task.Folder == null || m_folderList.Contains(task.Folder), "task", "task.Folder must be null or exist");
            m_taskList.Add(task);
            task.FolderChanging += task_folderChangeRequest;
        }

        public Task AddTask(DraftTask task, IList<Color> colorOptions)
        {
            //Util.RequireNotNull(task, "task");
            var color = getNextColor(colorOptions);

            var folder = m_folderList.FirstOrDefault(f => f.Name.Equals(task.FolderName));
            if (folder == null)
            {
                if (Folder.IsValidFolderName(task.FolderName))
                {
                    AddFolder(folder = new Folder(task.FolderName, color));
                }
            }

            var newTask = task.CloneWithFolder(folder);
            AddTask(newTask);
            return newTask;
        }

        public BaseFolder MoveTask(Task task, string folderName, IList<Color> newFolderColorOptions)
        {
            //Util.RequireArgument(m_taskList.Contains(task), "task");
            var folder = m_folderList.FirstOrDefault(f => f.Name.Equals(folderName));
            if (folder == null && Folder.IsValidFolderName(folderName))
            {
                var color = getNextColor(newFolderColorOptions);
                AddFolder(folder = new Folder(folderName, color));
            }
            //task.Folder = folder;
            return task.EffectiveFolder;
        }

        public void ReorderTasks(Task task, Task targetLocationTask)
        {
            //Util.RequireArgument(m_taskList.Contains(task), "task");
            //Util.RequireArgument(m_taskList.Contains(targetLocationTask), "targetLocationTask");
            m_taskList.Move(m_taskList.IndexOf(task), m_taskList.IndexOf(targetLocationTask));
        }

        public void RemoveTask(Task task)
        {
            //Util.RequireNotNull(task, "task");
            //Util.RequireArgument(m_taskList.Contains(task), "task");
            m_taskList.Remove(task);
            task.FolderChanging -= task_folderChangeRequest;
        }

        public static TaskData Load()
        {
            if (File.Exists(getPath(false)))
            {

            }

            return new TaskData();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #region Private Methods

        private void refreshAllFolders()
        {
            //using (m_allFolders.BeginMultiUpdate())
            //{
            m_allFolders.Clear();
            m_folderList.ForEach(folder => m_allFolders.Add(folder));
            //m_allFolders.Sort((a, b) => a.Name.CompareTo(b.Name));
            m_allFolders.Insert(0, SpecialFolder.InboxFolder);
            m_allFolders.Insert(0, SpecialFolder.AllFolder);
            //}
        }

        private void task_folderChangeRequest(object sender, FolderChangingEventArgs e)
        {
            var task = (Task)sender;
            Debug.Assert(m_taskList.Contains(task));
            if (e.Folder == null || m_folderList.Contains(e.Folder))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private static void backupFile()
        {
            var newName = string.Format("{0}.{1}.backup", c_fileName, DateTime.Now.ToFileTime());
            newName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                newName);

            File.Move(getPath(true), newName);
        }

        private static string getPath(bool createDirectyIfNeeded)
        {
            return Path.Combine(GetTasksDataFolder(createDirectyIfNeeded), c_fileName);
        }

        private static string GetTasksDataFolder(bool createIfNeeded)
        {
            string applicationDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string tasksDataFolder = Path.Combine(applicationDataFolder, "Tasks.Show");

            // make sure folder exists
            if (!Directory.Exists(tasksDataFolder))
            {
                if (createIfNeeded)
                {
                    Directory.CreateDirectory(tasksDataFolder);
                }
                else
                {
                    throw new DirectoryNotFoundException();
                }
            }

            return tasksDataFolder;
        }

        #endregion Private Methods

        private Color getNextColor(IList<Color> colorOptions)
        {
            //Util.RequireNotNull(colorOptions, "colorOptions");//uncommented by Priyanka

            var toUse = colorOptions
                .Select(color => new { Color = color, Count = m_folderList.Count(t => t.Color == color) })
                .OrderBy(cc => cc.Count)
                .FirstOrDefault();

            return toUse == null ? Colors.Transparent : toUse.Color;
        }

        private string m_filter;
        private BaseFolder m_currentFolder;
        private readonly List<Folder> m_folderList = new List<Folder>();
        private readonly ReadOnlyCollection<Folder> m_userFolders;
        private readonly ObservableCollection<Task> m_taskList = new ObservableCollection<Task>();
        private readonly ObservableCollection<BaseFolder> m_allFolders = new ObservableCollection<BaseFolder>();
        private readonly ObservableCollection<ADM_M010_PopUp> m_allUsers = new ObservableCollection<ADM_M010_PopUp>();
        private readonly ObservableCollection<TSK_T001_B_Folder> m_folders = new ObservableCollection<TSK_T001_B_Folder>();

        private const string c_fileName = "TasksShowTasks.xml";
    }
}
