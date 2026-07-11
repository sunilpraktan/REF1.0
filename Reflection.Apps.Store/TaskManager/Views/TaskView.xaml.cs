using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using System.Collections;


namespace Reflection.Apps.Store.TaskManager
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {

        public static readonly DependencyProperty SelectedItemsProperty =
      DependencyProperty.Register("SelectedItems", typeof(Dictionary<string, object>), typeof(TaskView), new FrameworkPropertyMetadata(null,
  new PropertyChangedCallback(TaskView.OnSelectedItemsChanged)));


        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TaskView control = (TaskView)d;
            //control.SelectNodes();
            //control.SetText();
        }

        #region Constructors

        BaseTask btask = new BaseTask();
        DraftTask draftTask = new DraftTask();
        TaskDAL dal = new TaskDAL();


        private EditTask m_UpdateTask;
        private readonly ObservableCollection<TaskViewModel> m_unfilteredTaskList;
        private readonly TaskData m_taskList;

        public TaskView()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) =>
            {
                //Debug.Assert(args.OldValue == null, "DataContext shouldn't be changed more than once.");

                var tasks = args.NewValue as TaskViewModel;
                if (tasks != null)
                {
                    //Commands.MapCommand(tasks.DeleteTaskCommand, ApplicationCommands.Delete, this);
                }
            };
            SelectionChangedCommand_singal = new RelayCommand<IList>(
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

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Opacity = 0.85;
            this.IsEnabled = false;

            Action a = () =>
            {
                Task t = (this.DataContext as TaskViewModel).Task;
                if (t != null)
                {
                    ApplicationCommands.Delete.Execute(t, this as IInputElement);
                }
            };

            Dispatcher.Invoke(a, DispatcherPriority.Background);
        }

        private void FolderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // we set the new value manually to avoid a two way binding (the two
            // way binding had some timing issues with the Folders.RefreshFolders 
            // method that caused us to lose folder data

            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                Folder folder = e.AddedItems[0] as Folder;
                if (folder == null) return;

                // get the folder object from the datacontext and set the new folder
                TaskViewModel tvm = (sender as FrameworkElement).DataContext as TaskViewModel;
                //tvm.Task.Folder = folder;
            }
        }

        #endregion Event Handlers

        private void FolderDropDown_RequestFolderChange(object sender, RequestFolderChangeEventArgs e)
        {
            TaskViewModel v = DataContext as TaskViewModel;
            if (v != null)
            {
                Debug.Assert(v.Task == e.Task);
                var destination = TaskManagerView.Root.TaskData.MoveTask(v.Task, e.FolderName, TaskManagerView.Root.FolderColorOptions);
                TaskManagerView.Root.TaskData.CurrentFolder = destination;
            }
        }
      
        public RelayCommand<IList> SelectionChangedCommand_singal
        {
            get;
            private set;
        }
        //extra added code by Priyanka
        //private void CompletedCheck_Checked(object sender, RoutedEventArgs e)
        //{
           
        //    if (CompletedCheck.IsChecked == true)
        //    {
        //        btask.completed = true;
        //    }
        //    else
        //    {
        //        btask.completed = false;
        //    }
           

        //    //Debug.Assert(m_UpdateTask != null);

        //    //m_UpdateTask.Task = dal.UpdateTaskData(m_UpdateTask.Task);
        //    //var updateTask = m_taskList.AddTask(m_UpdateTask.Task, TaskManagerView.Root.FolderColorOptions);
        //    //m_unfilteredTaskList.Add(new TaskViewModel(updateTask));
        //    //m_taskList.CurrentFolder = updateTask.EffectiveFolder;



        //    dal.UpdateTaskData(draftTask);
        //    //dal.UpdateTaskData(UpdateTask.Task);
            
        //}
       

        //private void PriorityCheck_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (PriorityCheck.IsChecked == true)
        //    {
        //        btask.tsk_priority = 1;
        //    }
        //    else if (PriorityCheck.IsChecked == false)
        //    {
        //        btask.tsk_priority = 0;
        //    }
        //    dal.UpdateTaskData(draftTask);
        //}
    }
}
