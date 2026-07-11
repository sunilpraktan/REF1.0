using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Reflection.Apps.Store.TaskManager
{
    public class Folders
    {
        #region Fields

        private readonly RelayCommand<Color> m_setCurrentColorCommand;
        private readonly RelayCommand<BaseFolder> m_setCurrentCommand;
        private readonly TaskData m_taskData;

        #endregion Fields

        #region Constructors

        public Folders(TaskData taskData)
        {
            //Util.RequireNotNull(taskData, "taskList");
            m_taskData = taskData;

            m_setCurrentCommand = new RelayCommand<BaseFolder>(
                val => m_taskData.CurrentFolder = val,
                val => m_taskData.CurrentFolder != val);

            m_setCurrentColorCommand = new RelayCommand<Color>(
                var => m_taskData.CurrentFolder.Color = var,
                var => IsCurrentUserFolder
            );
        }

        #endregion Constructors

        #region Properties

        public TaskData TaskData
        {
            get
            {
                return m_taskData;
            }
        }

        public bool IsCurrentUserFolder
        {
            get { return !m_taskData.CurrentFolder.IsSpecial; }
        }

        public ICommand SetCurrentColorCommand { get { return m_setCurrentColorCommand; } }

        public ICommand SetCurrentCommand { get { return m_setCurrentCommand; } }

        #endregion Properties
    }
}
