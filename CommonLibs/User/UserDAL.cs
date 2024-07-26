using PNB.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.Lib.UserMgmt
{
    public class UserDAL
    {
        public UserDAL()
        {
        }
        public User GetUser(string un, string pass)
        {
            if (string.IsNullOrWhiteSpace(un) || string.IsNullOrWhiteSpace(pass))
                return null;
            SqlDataAccess s = new SqlDataAccess();
            string sql = string.Format("SELECT * FROM Users WHERE un='{0}' AND pass='{1}';", un, pass);
            string err = "";
            DataTable dt = s.Execute(sql, out err);
            if (dt == null) return null;
            if (dt.HasErrors) return null;
            if (dt.Rows.Count == 0) return null;

            User u = null;

            if (dt.Rows[0]["un"].ToString().Trim() == un.Trim() && dt.Rows[0]["pass"].ToString().Trim() == pass.Trim())
            {
                u = new User();
                u.UserName = un.Trim();
                u.Password = pass.Trim();
                u.Name = dt.Rows[0]["fullname"].ToString().Trim();
            }

            return u;
        }
    }
}
