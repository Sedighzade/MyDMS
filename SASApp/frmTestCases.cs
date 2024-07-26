using PNB.SAS.Archive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.SAS
{
    public partial class frmTestCases : Form
    {
        public frmTestCases()
        {
            InitializeComponent();
            btnTestArchive_Click(null, null);
        }

        private void btnTestArchive_Click(object sender, EventArgs e)
        {
            frmTest frm = new frmTest();

            frm.ShowDialog(this);
        }
    }
}
