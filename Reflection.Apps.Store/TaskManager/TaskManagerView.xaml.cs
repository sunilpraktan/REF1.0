using Microsoft.WindowsAPICodePack.ApplicationServices;
using MS.WindowsAPICodePack.Internal;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Apps.Store.TaskManager
{
    /// <summary>
    /// Interaction logic for TaskManagerView.xaml
    /// </summary>
    public partial class TaskManagerView : WindowElement
    {

        #region Fields

        private Thickness c_glassMargins = new Thickness(-1);
        private const int c_hotKeyId = 68;
        private const int c_keepAliveInterval = 5000;
        private readonly Root m_rootViewModel;

        private static Root m_root;
        //public static Root Root;
        public static Root Root
        {
            get { return m_root; }
            set
            {
                m_root = value;
                //RaisePropertychanged("Root");
            }
        }

        TaskDAL dal = new TaskDAL();
        #endregion Fields

        #region Constructors

        public TaskManagerView()
        {
            //m_root = new Root(dal.GetTaskData(), FindResource("FolderColors") as List<Color>);//uncommented by Priyanka
            m_root = new Root(dal.GetTaskData(), GetColors());
            InitializeComponent();

            m_rootViewModel = m_root;
            this.DataContext = m_rootViewModel;

            Commands.MapCommand(m_rootViewModel.Tasks.NewTaskCommand, ApplicationCommands.New, this);
            Commands.MapCommand(m_rootViewModel.Tasks.CancelNewCommand, Commands.Cancel, this);

            this.CommandBindings.Add(
                new CommandBinding(ApplicationCommands.Close, (sender, args) => Close()));

            this.Closing += new CancelEventHandler(MainWindow_Closing);

            this.Loaded += (sender, e) =>
            {
                Taskbar.Init();
                //ProcessCommandLineArgs(SingleInstance<App>.CommandLineArgs, true);
            };

            RegisterApplicationRecoveryAndRestart();

        }

        private List<Color> GetColors()
        {
            List<Color> colorList = new List<Color>();
            colorList.Add((Color)ColorConverter.ConvertFromString("#00acff"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#357e7f"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#529010"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#b1c70c"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#ffc211"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#fb791a"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#f24e22"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#da1a4c"));
            colorList.Add((Color)ColorConverter.ConvertFromString("#00FFFFFF"));

            return colorList;
        }
        #endregion Constructors

        #region Event Handlers

        private void About_Click(object sender, RoutedEventArgs e)
        {
            //AboutBox.Visibility = Visibility.Visible;
        }

        private void About_CloseRequested(object sender, RoutedEventArgs e)
        {
            //AboutBox.Visibility = Visibility.Collapsed;
        }

        private void DeleteCompleted_Click(object sender, RoutedEventArgs e)
        {
            var items = m_rootViewModel.Tasks.AllTasks.Where(t => (bool)t.Task.completed).ToArray();

            if (items.Length > 0)
            {
                if (MessageBox.Show(String.Format("Are you sure you want to delete {0} completed task{1}? There is no way to restore {2} once {3} deleted.", items.Length, (items.Length > 1 ? "s" : ""), (items.Length > 1 ? "them" : "it"), (items.Length > 1 ? "they are" : "it is")), "Delete completed tasks?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //items.ForEach(tvm => m_rootViewModel.Tasks.DeleteTask(tvm.Task));
                }
            }
            else
            {
                MessageBox.Show("Sorry, there aren't any completed tasks to delete.");
            }


            //old code 
            //var items = m_rootViewModel.Tasks.AllTasks.Where(t => t.Task.IsComplete).ToArray();

            //if (items.Length > 0)
            //{
            //    if (MessageBox.Show(String.Format("Are you sure you want to delete {0} completed task{1}? There is no way to restore {2} once {3} deleted.", items.Length, (items.Length > 1 ? "s" : ""), (items.Length > 1 ? "them" : "it"), (items.Length > 1 ? "they are" : "it is")), "Delete completed tasks?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //    {
            //        //items.ForEach(tvm => m_rootViewModel.Tasks.DeleteTask(tvm.Task));
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Sorry, there aren't any completed tasks to delete.");
            //}
            //end
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            //Storage.Save(m_rootViewModel.TaskData);
            //HotKeyHelper.UnregisterHotKey(this, c_hotKeyId);

            //UnregisterApplicationRecoveryAndRestart();
        }

        private void ShowWelcome_Click(object sender, RoutedEventArgs e)
        {
            //WelcomeTour.Show();
        }

        private void TasksView_HideScrollSlider(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.Resources["HideScrollColumn"] as Storyboard;
            this.BeginStoryboard(sb);
        }

        private void TasksView_ShowScrollSlider(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.Resources["ShowScrollColumn"] as Storyboard;
            this.BeginStoryboard(sb);
        }

        private void this_hotkey(object sender, EventArgs args)
        {
            this.Activate();
            m_rootViewModel.Tasks.ShowNewTask();
        }

        #endregion Event Handlers

        #region Public Methods

        /// <summary>
        /// Processes the command line args.
        /// </summary>
        /// <param name="commandLineArgs">The command line args.</param>
        /// <param name="isFirstInstance"><c>True</c> if called by is first instance.</param>
        /// <returns>True</returns>
        public bool ProcessCommandLineArgs(IList<string> commandLineArgs, bool isFirstInstance)
        {
            if (commandLineArgs == null || commandLineArgs.Count == 0)
            {
                return true;
            }

            // if no arguments and first instance
            if ((commandLineArgs.Count == 1) && isFirstInstance)
            {
                // Do nothing
            }
            // if no arguments and not first instance
            else if ((commandLineArgs.Count == 1) && !isFirstInstance)
            {
                // Do nothing
            }
            // if second argument is /newtask
            else if ((commandLineArgs.Count > 1) && (commandLineArgs[1].ToLowerInvariant() == "/newtask"))
            {
                this_hotkey(null, EventArgs.Empty);
            }
            // otherwise, second argument is /goto and third argument is folder to select
            else if ((commandLineArgs.Count > 1) && (commandLineArgs[1].ToLowerInvariant() == "/goto"))
            {
                // find requested folder
                var theFolder = m_rootViewModel.TaskData.AllFolders
                    .Where(folder => folder.Name.EasyEquals(commandLineArgs[2]))
                    .FirstOrDefault();

                if (theFolder != null)
                {
                    m_rootViewModel.TaskData.CurrentFolder = theFolder;
                }
            }

            return true;
        }

        #endregion Public Methods

        #region Private Methods


        /// <summary>
        /// Performs recovery by saving the state 
        /// </summary>
        /// <param name="parameter">Unused.</param>
        /// <returns>Unused.</returns>
        private int PerformRecovery(object parameter)
        {
            try
            {
                ApplicationRestartRecoveryManager.ApplicationRecoveryInProgress();
                //Storage.Save(m_rootViewModel.TaskData);
                ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(true);
            }
            catch
            {
                ApplicationRestartRecoveryManager.ApplicationRecoveryFinished(false);
            }

            return 0;
        }

        private void RegisterApplicationRecoveryAndRestart()
        {
            if (CoreHelpers.RunningOnVista)
            {
                // register for Application Restart and Recovery
                RestartSettings restartSettings = new RestartSettings(string.Empty, RestartRestrictions.None);
                ApplicationRestartRecoveryManager.RegisterForApplicationRestart(restartSettings);

                RecoverySettings recoverySettings = new RecoverySettings(new RecoveryData(PerformRecovery, null), c_keepAliveInterval);
                ApplicationRestartRecoveryManager.RegisterForApplicationRecovery(recoverySettings);
            }
        }

        private void UnregisterApplicationRecoveryAndRestart()
        {
            if (CoreHelpers.RunningOnVista)
            {
                ApplicationRestartRecoveryManager.UnregisterApplicationRestart();
                ApplicationRestartRecoveryManager.UnregisterApplicationRecovery();
            }
        }

        #endregion Private Methods

        private void DeleteFolders_Click(object sender, RoutedEventArgs e)
        {
            //m_rootViewModel.TaskData.UserFolders
            //    .Where(f => !m_rootViewModel.TaskData.Tasks.Any(t => t.Folder == f))
            //    .ToArray()
            //    .ForEach(f => m_rootViewModel.TaskData.RemoveFolder(f));
        }
    }
}
