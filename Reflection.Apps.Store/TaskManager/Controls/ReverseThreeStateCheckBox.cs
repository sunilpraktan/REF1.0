using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Reflection.Apps.Store.TaskManager
{
    // Thanks! http://dutchmarcel.wordpress.com/2009/10/21/the-three-state-checkbox/

    public class ReverseThreeStateCheckBox : CheckBox
    {
        //extra added by Priyanka
        BaseTask btask = new BaseTask();
        DraftTask draftTask = new DraftTask();
        TaskDAL dal = new TaskDAL();
        //end
        protected override void OnToggle()
        {
            if (this.IsChecked == false)
            {
                this.IsChecked = this.IsThreeState ? null : ((bool?)true);
            }
            else
            {
                this.IsChecked = new bool?(!this.IsChecked.HasValue);
            }
            dal.UpdateTaskData(draftTask);//added by Priyanka
        }
    }
}
