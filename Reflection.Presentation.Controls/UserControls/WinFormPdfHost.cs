using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reflection.Presentation.Controls
{
    public partial class WinFormPdfHost : UserControl
    {
        public WinFormPdfHost()
        {
            try
            {
                InitializeComponent();
                if (!DesignMode)
                    axAcroPDF1.setShowToolbar(true);
            }
            catch(Exception ex) { }
        }

        public void LoadFile(string path)
        {
            try
            {
                axAcroPDF1.LoadFile(path);
                axAcroPDF1.src = path;
                axAcroPDF1.setViewScroll("FitH", 0);
            }
            catch(Exception ex)
            { }
        }

        public void SetShowToolBar(bool on)
        {
            axAcroPDF1.setShowToolbar(on);
        }
    }
}
