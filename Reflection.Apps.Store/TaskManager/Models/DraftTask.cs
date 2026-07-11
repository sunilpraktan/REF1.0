using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Apps.Store.TaskManager
{
    public class DraftTask : BaseTask
    {
        //private int m_folder_id;
        //public int folder_id
        //{
        //    get
        //    {
        //        return m_folder_id;
        //    }
        //    set
        //    {
        //        if (value != m_folder_id)
        //        {
        //            m_folder_id = value;
        //            RaisePropertyChanged("folder_id");
        //        }
        //    }
        //}
        private string m_folderName;
        public string FolderName
        {
            get
            {
                return m_folderName;
            }
            set
            {
                //if (value != m_folderName)
                //{
                m_folderName = value;
                RaisePropertyChanged("FolderName");
                //}
            }
        }

       
        
    }
}
