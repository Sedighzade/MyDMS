using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{
    public class VScrollablePanel : Panel
    {
        public VScrollablePanel()
        {            
            AutoScroll = false;
            HorizontalScroll.Enabled = false;
            HorizontalScroll.Visible = false;
            HorizontalScroll.Maximum = 0;
            AutoScroll = true;
            //ScrollBar vScrollBar1 = new VScrollBar();
            //vScrollBar1.Dock = DockStyle.Right;
            ///vScrollBar1.Scroll += (sender, e) => { VerticalScroll.Value = vScrollBar1.Value; };
            //Controls.Add(vScrollBar1);
        }
    }
}
