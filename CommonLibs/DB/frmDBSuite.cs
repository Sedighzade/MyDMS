using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.Data
{
    public partial class frmDBSuite : Form
    {
        readonly string cs;
        public frmDBSuite(string connectionString)
        {
            InitializeComponent();
            cs = txtCS.Text = connectionString;
            cmbxFreq.SelectedIndex = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQ.Text.Trim())) return;

            btnExecute.Enabled = false;
            Text = "DB Suite";
            ThreadPool.QueueUserWorkItem(DoTask, txtQ.Text);
        }
        private void DoTask(object obj)
        {
            string q = obj.ToString().ToUpper();

            bool nonQ = q.Contains("CREATE") || q.Contains("ALTER") || q.Contains("INSERT") || q.Contains("UPDATE") || q.Contains("DBDC") || q.Contains("DELETE");

            SqlDataAccess sql = new SqlDataAccess(txtCS.Text);
            int res = 0;
            DataTable dt = null;
            string resStr = "";
            string err = "";
            try
            {
                if (nonQ)
                    res = sql.ExecuteNonQuery(q);
                else
                {
                    dt = sql.Execute(q, out err);

                    Invoke((MethodInvoker)(() =>
                    {
                        dataGridView1.DataSource = dt;
                    }
                    ));
                }

                resStr = "DB Suite - ";
                if (nonQ)
                    resStr = "DB Suite - " + res.ToString();
                else
                {
                    if (dt == null)
                        resStr += "Error: " + err;
                    else
                        resStr += "Successful! Row Count= " + dt.Rows.Count;
                }
            }
            catch (Exception ee)
            {
                resStr = ee.Message;
            }
            finally
            {
                Invoke((MethodInvoker)(() =>
                {
                    btnExecute.Enabled = true;
                    Text = resStr;
                }
                ));
            }
        }

        private void cmbxFreq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbxFreq.SelectedIndex == 0)
                return;

            txtQ.Text = cmbxFreq.SelectedItem.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQ.Text = "";
        }
    }
}
