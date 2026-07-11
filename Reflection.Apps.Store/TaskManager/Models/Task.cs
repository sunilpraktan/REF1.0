using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;

namespace Reflection.Apps.Store.TaskManager
{
    public class Task : BaseTask
    {
        public Folder Folderd()
        { return null; }
        public Folder Folder
        {
            get { return m_folder; }
            set
            {
                var args = new FolderChangingEventArgs(value);
                OnFolderChanging(args);
                if (args.Cancel)
                {
                    throw new OperationCanceledException();
                }
                else
                {
                    if (m_folder != null)
                    {
                        m_folder.PropertyChanged -= folder_propertyChanged;
                    }
                    m_folder = value;
                    if (m_folder != null)
                    {
                        m_folder.PropertyChanged += folder_propertyChanged;
                    }
                    RaisePropertyChanged("Folder");
                    RaisePropertyChanged("EffectiveFolder");
                    RaisePropertyChanged("FolderName");
                }
            }
        }

        public string FolderName
        {
            get
            {
                if (folder_name == null)
                {
                    return EffectiveFolder.Name;
                }
                else
                {
                    return folder_name;
                    
                }
            }
            set
            {
                //throw new NotSupportedException();
            }
        }

        public BaseFolder EffectiveFolder { get { return m_folder == null ? SpecialFolder.InboxFolder : (BaseFolder)m_folder; } }

        public event EventHandler<FolderChangingEventArgs> FolderChanging;

        protected virtual void OnFolderChanging(FolderChangingEventArgs args)
        {
            var handler = FolderChanging;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void folder_propertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                RaisePropertyChanged("FolderName");
            }
        }

        private Folder m_folder;
    }

    public class MultipleContext_Task
    {
        public List<Task> taskData { get; set; }
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ADM_M010_PopUp> UserMaster_1 { get; set; }
        public List<SEL_T001_P> SalesInquiry { get; set; }
        public List<TSK_T001_B_Folder> FolderDetails { get; set; }  //Task
    }

    public class ADM_M010_PopUp
    {
        public string id { get; set; }
        //public Nullable<int> empid { get; set; }
        [DisplayName("User Name")]
        public string AssignToUser { get; set; }
        public string EmpId { get; set; }
        public string EmpName { get; set; }


    }

    public class TSK_T001_B_Folder
    {
        public int id { get; set; }

        [DisplayName("Folder Name")]
        public string folder_name { get; set; }

    }



}
