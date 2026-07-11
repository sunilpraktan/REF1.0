using GalaSoft.MvvmLight;
using Reflection.WebServices.Gateway;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;





namespace Reflection.Apps.Store.TaskManager
{
    

    public class TaskDAL : ViewModelBase, INotifyPropertyChanged
    {
        private string _filterString;

        WebServiceRepository<Reflection.Apps.Store.TaskManager.Task> repository = new WebServiceRepository<Reflection.Apps.Store.TaskManager.Task>();
        WebServiceRepository<MultipleContext_Task> repositoryMC1 = new WebServiceRepository<MultipleContext_Task>();
        WebServiceRepository<List<Reflection.Apps.Store.TaskManager.Task>> repositoryMC = new WebServiceRepository<List<Reflection.Apps.Store.TaskManager.Task>>();
        public List<Reflection.Apps.Store.TaskManager.BaseTask> _baseTask;
        public List<Reflection.Apps.Store.TaskManager.BaseTask> baseTask
        {
            get { return _baseTask; }
            set
            {
                if (_baseTask != value)
                {
                    _baseTask = value;

                    RaisePropertyChanged("baseTask");
                }
            }
        }
        public List<Reflection.Apps.Store.TaskManager.Task> _TempTask;
        public List<Reflection.Apps.Store.TaskManager.Task> TempTask
        {
            get { return _TempTask; }
            set
            {
                if (_TempTask != value)
                {
                    _TempTask = value;

                    RaisePropertyChanged("TempTask");
                }
            }
        }
        private Task _tTask;
        public Task tTask
        {
            get
            {

                return _tTask;
            }
            set
            {
                if (_tTask != value)
                {
                    _tTask = value;
                    RaisePropertychanged("tTask");

                }
            }
        }

        MultipleContext_Task _MC = new MultipleContext_Task();
        public MultipleContext_Task MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    //RaisePropertychanged("MC");
                }
            }
        }

        private BaseTask _bTask;
        

        #region Methods
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
        #endregion

        public TaskData GetTaskData()
        {
            Reflection.Apps.Store.TaskManager.Task tTask = new Reflection.Apps.Store.TaskManager.Task();
            MultipleContext_Task MTask = new MultipleContext_Task();
            TempTask = new List<Reflection.Apps.Store.TaskManager.Task>();
            Reflection.Apps.Store.TaskManager.Task TempTaskSingle = new Reflection.Apps.Store.TaskManager.Task();
            ObjectSerializationService objSer = new ObjectSerializationService();
            string strObjectString = objSer.ObjectToXML(TempTask);

            MTask = repositoryMC1.GetDataWithReturnDomainObject<MultipleContext_Task>(MTask, "Task_Data", "TaskManager", "Communication", "", 0,"");
         

            // var t = (from data in TempTask);

            //TempTask = repositoryMC.GetDataWithReturnDomainObject<Reflection.Apps.Store.TaskManager.Task>(TempTask, "Task_Data", "TaskManager", "Administration", "", 0, "");
            //TempTask = repositoryMC.GetDataWithReturnDomainObject<Reflection.Apps.Store.TaskManager.Task>(TempTask, "Task_Data", "TaskManager", "Communication", "", 0, "");
            //TempTask = (List<Reflection.Apps.Store.TaskManager.Task>)objSer.XMLToObject(strMessage, TempTask);

            TempTask = MTask.taskData;
            //MC.taskData = MTask.taskData;
            MC.UserMaster_1 = MTask.UserMaster_1;
            MC.FolderDetails = MTask.FolderDetails;
            tTask.act_date = System.DateTime.Now;
            //FolderData = MTask.FolderDetails.ToList();
             
            //FolderData = MTask.FolderDetails();
            //DataGridCollection = CollectionViewSource.GetDefaultView(MTask.taskData);

            //DataGridCollection.Filtear = new Predicate<object>(Filter);
            IDictionary<int, Folder> folderMapper;
            var folders = GetFolders(TempTask, out folderMapper);
            IEnumerable<Reflection.Apps.Store.TaskManager.Task> tasks = GetTasks(TempTask, guid => folderMapper[guid]);

            BaseFolder currentFolder = null;
            string filter = "";

            #region Shital
            //FolderData = new List<test_folder>();
            //try
            //{
            //    object dataSource = MTask.taskData;
            //    string displayMember = "folderid";
            //    string valueMember = "folder_name";
            //    IEnumerable list = (IEnumerable)dataSource;
            //    Type elementType = list.GetType().GetGenericArguments()[0];
            //    PropertyInfo property = elementType.GetProperty(displayMember);
            //    List<object> displayValues = list.Cast<object>()
            //                                     .Select(v => property.GetValue(v, null))
            //                                     .ToList();


            //    string displayMember1 = "folder_name";
            //    string valueMember1 = "folderid";
            //    IEnumerable list1 = (IEnumerable)dataSource;
            //    Type elementType1 = list1.GetType().GetGenericArguments()[0];

            //    PropertyInfo property1 = elementType1.GetProperty(displayMember1);
            //    List<object> displayValues1 = list1.Cast<object>()
            //                                     .Select(v1 => property1.GetValue(v1, null))
            //                                     .ToList();



            //    for (int y = 0; y < displayValues.Count; y++)
            //    {                    
            //        FolderData.Add(new test_folder { f_id = Convert.ToInt32(displayValues[y].ToString()) });
            //        FolderData.Add(new test_folder { f_name = displayValues1[y].ToString() });

            //    }
            //    //int z=0;
            //    //foreach (var item in displayValues1)
            //    //{
            //    //    FolderData.Insert(z,item);
            //    //    z=z + 1;
            //    //}

            //}catch
            //{

            //}
            #endregion

            return new TaskData(tasks, folders, currentFolder, filter, MC.UserMaster_1, TempTask, MC.FolderDetails);

            #region backup
            //MultipleContext_Task MTask = new MultipleContext_Task();
            //TempTask = new List<Reflection.Apps.Store.TaskManager.Task>();
            //Reflection.Apps.Store.TaskManager.Task TempTaskSingle = new Reflection.Apps.Store.TaskManager.Task();
            //ObjectSerializationService objSer = new ObjectSerializationService();
            //string strObjectString = objSer.ObjectToXML(TempTask);

            ////TempTask = repositoryMC.GetDataWithReturnDomainObject<Reflection.Apps.Store.TaskManager.Task>(TempTask, "Task_Data", "TaskManager", "Communication", "", 0, "");

            //MTask = repositoryMC1.GetDataWithReturnDomainObject<MultipleContext_Task>(MTask, "Task_Data", "TaskManager", "Communication", "", 0, "");
            //TempTask = MTask.taskData;
            ////DataGridCollection = CollectionViewSource.GetDefaultView(MTask.taskData);

            ////DataGridCollection.Filter = new Predicate<object>(Filter);

            //IDictionary<int, Folder> folderMapper;
            //var folders = GetFolders(TempTask, out folderMapper);
            //IEnumerable<Reflection.Apps.Store.TaskManager.Task> tasks = GetTasks(TempTask, guid => folderMapper[guid]);

            //BaseFolder currentFolder = null;
            //string filter = "";
            //return new TaskData(tasks, folders, currentFolder, filter);
            #endregion
        }
        static object Copy(object a, object b)
        {
            Type typeB = b.GetType();
            foreach (PropertyInfo property in a.GetType().GetProperties())
            {
                if (!property.CanRead || (property.GetIndexParameters().Length > 0))
                    continue;

                PropertyInfo other = typeB.GetProperty(property.Name);
                if ((other != null) && (other.CanWrite))
                    other.SetValue(b, property.GetValue(a, null), null);
            }
            return b;
        }
        public DraftTask InsertTaskData(DraftTask draftTask)
        {
           
            Reflection.Apps.Store.TaskManager.Task tTask = new Reflection.Apps.Store.TaskManager.Task();
            //TempTask.Where(X => X.folder_name == draftTask.folder_name).FirstOrDefault();
            //var folder_id = (from data in FolderData where data.folder_name == draftTask.folder_name select data.id);
            //draftTask.folder_id = Convert.ToInt32(from data in TempTask where data.folder_name == draftTask.folder_name select data.folder_id);

            TempTask = new List<Reflection.Apps.Store.TaskManager.Task>();
           
            tTask = (Reflection.Apps.Store.TaskManager.Task)Copy(draftTask, tTask);
            tTask.doc_cat = "SM";
            tTask.doc_type = "SM";
            tTask.start_date = tTask.start_date ?? System.DateTime.Now;
            tTask.doc_date = tTask.doc_date ?? System.DateTime.Now;
            tTask.client = AppSessionState.client;
            tTask.comp_code = tTask.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code;
            tTask.location_Id = tTask.location_Id ?? AppSessionState.OBJ_LOCATION.location_id;
            if (tTask.act_action == "SCHEDULE" && tTask.action_type == "Meeting")
            {
                tTask.doc_cat = "SM";
                tTask.doc_type = "SM";
            }
            if (tTask.act_action == "SCHEDULE" && tTask.action_type == "Call")
            {
                tTask.doc_cat = "SC";
                tTask.doc_type = "SC";
            }

            if (draftTask.FolderName != null )
            {
                tTask.folder_name = draftTask.FolderName;
                tTask.FolderName = draftTask.FolderName;
                tTask.assign_by = AppSessionState.UserID;
                tTask.editby = AppSessionState.UserID;
                tTask.add_by = AppSessionState.UserID;
                tTask.fin_year = "15-16";
                tTask.location_Id = AppSessionState.location_Id;
                tTask.comp_code = AppSessionState.comp_code;
                tTask.posting_period = "1";
                tTask.active = true;
                tTask.t_status = "Draft";
               
            }
            else
            {
                if (tTask.FolderName != null )
                {
                    tTask.folder_name = tTask.FolderName;
                    tTask.FolderName = tTask.FolderName;
                    tTask.assign_by = AppSessionState.UserID;
                    tTask.editby = AppSessionState.UserID;
                    tTask.add_by = AppSessionState.UserID;
                    tTask.fin_year = "15-16";
                    tTask.location_Id = AppSessionState.location_Id;
                    tTask.comp_code = AppSessionState.comp_code;
                    tTask.posting_period = "1";
                    tTask.active = true;
                }
               


            }
           
            //TSK_T001_B_Folder tsk = new TSK_T001_B_Folder();
            //tsk.f_id = DataGridCollection

            //ObjectSerializationService objSer = new ObjectSerializationService();
            //string strObjectString = objSer.ObjectToXML(tTask);
            //tTask = repository.SaveWithReturnDomainObject<Reflection.Apps.Store.TaskManager.Task>(tTask, "TaskManager", "Administration");

             tTask = repository.SaveWithReturnDomainObject<Reflection.Apps.Store.TaskManager.Task>(tTask, "TaskManager", "Communication");

            //TempTask = (List<Reflection.Apps.Store.TaskManager.Task>)objSer.XMLToObject(strMessage, TempTask);
            //tTask = TempTask[0];
            draftTask = (Reflection.Apps.Store.TaskManager.DraftTask)Copy(tTask, draftTask);

            return draftTask;
        }
        public DraftTask UpdateTaskData(DraftTask draftTask)
        {
            int tskid;
            
            TempTask = new List<Reflection.Apps.Store.TaskManager.Task>();
            Reflection.Apps.Store.TaskManager.Task tTask = new Reflection.Apps.Store.TaskManager.Task();
            tTask = (Reflection.Apps.Store.TaskManager.Task)Copy(draftTask, tTask);
            //Reflection.Apps.Store.TaskManager.Task tTask1 = new Reflection.Apps.Store.TaskManager.Task();
            tTask = repository.UpdateWithReturnDomainObject<Reflection.Apps.Store.TaskManager.Task>(tTask, "TaskManager", "Communication");
            draftTask = (Reflection.Apps.Store.TaskManager.DraftTask)Copy(tTask, draftTask);

            return draftTask;
        }
        public DraftTask DeleteTaskData(DraftTask draftTask)
        {
            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //showMessageService.ButtonSetup = DialogButton.Ok;
            //showMessageService.Caption = "Delete Changes";
            //showMessageService.Text =
            //    String.Format(
            //        "This record will delete forever '{0}'",
            //            this.Title);

            //if (showMessageService.ShowMessage() == DialogResult.Ok)
            //{
            //    SelectedZADM_M013.CancelEdit();
            //    string response = repository.Delete(SelectedZADM_M013.machine_id, "MachineMaster", "Administration");
            //    SelectedList.Remove(SelectedZADM_M013);
            //    _dataGridCollection.Refresh();
            //    SelectedZADM_M013 = new ZADM_M013();
            //}
            return draftTask;
        }
        public static IEnumerable<Folder> GetFolders(IEnumerable<Reflection.Apps.Store.TaskManager.Task> element, out IDictionary<int, Folder> folderMapper)
        {
            var list = new List<Folder>();
            int key;
            Folder folder;
            folderMapper = new Dictionary<int, Folder>();
            //element = element.Select(x => x.folder_name).Distinct().ToList();
            //element = (from mci in element select mci).Distinct().ToList();
            element = element.DistinctBy(i => i.folder_name).DistinctBy(i => i.folderid).ToList();
            foreach (Reflection.Apps.Store.TaskManager.Task singleTask in element)
            {
                if (singleTask.folder_id > 1)
                {
                    list.Add(folder = GetFolder(singleTask, out key));
                    folderMapper[key] = folder;
                }
            }
            return list;
        }
        public static Folder GetFolder(BaseTask element, out int key)
        {
            var name = element.folder_name;
            var color = BOT.ParseHexColor(element.color_code);
            key = element.folder_id;  // folderid
            return new Folder(name, color);
        }
        public static IEnumerable<Reflection.Apps.Store.TaskManager.Task> GetTasks(IEnumerable<Reflection.Apps.Store.TaskManager.Task> element, Func<int, Folder> folderMapper)
        {
            foreach (var taskElement in element)
            {
                yield return GetTask(taskElement, folderMapper);
            }
        }
        public static Reflection.Apps.Store.TaskManager.Task GetTask(Reflection.Apps.Store.TaskManager.Task element, Func<int, Folder> folderMapper)
        {
            var task = new Reflection.Apps.Store.TaskManager.Task();
            task = element;
            if (element.folder_id > 1)
            {
                task.Folder = folderMapper(element.folder_id);
            }
            return task = element;
        }
       




    }
}
