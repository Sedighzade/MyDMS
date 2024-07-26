using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{
    public class TabControlEx : TabControl
    {
        public class CloseTabArgs : EventArgs { public bool Cancel { set; get; } }

        public event EventHandler<CloseTabArgs> BeforeClose;
        public TabControlEx()
        {
            this.DrawMode = TabDrawMode.OwnerDrawFixed;

            this.DrawItem += delegate (object sender, DrawItemEventArgs e)
            {
                //This code will render a "x" mark at the end of the Tab caption. 
                e.Graphics.DrawString("x", e.Font, Brushes.Black, e.Bounds.Right - 15, e.Bounds.Top + 4);
                e.Graphics.DrawString(TabPages[e.Index].Text, e.Font, Brushes.Black, e.Bounds.Left + 12, e.Bounds.Top + 4);
                e.DrawFocusRectangle();
            };

            this.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                for (int i = 0; i < TabPages.Count; i++)
                {
                    Rectangle r = GetTabRect(i);
                    //Getting the position of the "x" mark.
                    Rectangle closeButton = new Rectangle(r.Right - 15, r.Top + 4, 9, 7);
                    if (closeButton.Contains(e.Location))
                    {
                        CloseTabArgs cta = new TabControlEx.CloseTabArgs();
                        BeforeClose?.Invoke(this, cta);
                        //if (MessageBox.Show("Would you like to Close this Tab?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        if (cta.Cancel) return;
                        TabPages.RemoveAt(i);
                        break;
                        //}
                    }
                }
            };
        }
    }
}
