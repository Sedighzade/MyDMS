using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{
    public class ListBox2 : ListBox
    {
        public void RefreshAllItems()
        {
            this.RefreshItems();
        }
    }
}
