using PNB.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace PNB.Lib.UserMgmt
{
    public enum Permissions
    {
        [Description("ewtert")]
        DoConfig = 1,
        Save = 2,
        SendData2Server = 3,
        Login = 4,
        BackupDB = 5,
        ManualDataEntry = 6,
        ReportGenerator = 7,
        ExportReport = 8,
        ConfigureNetwork = 9,
        AckAlarm = 10,
        AccessUSB = 11,
        CloseApp = 12,
        SeeReport = 13,
        RestoreBackup = 14,
        ChangeSettings = 15,
        ResetService = 16,
        CollectData = 17,
        DetectTag = 18,
        Logout = 19
    }

    public enum AuthenticationMethod { Form, RFID, IRIS }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SM
    {
        internal User dangerousUser = new User();
        public User LoggedInUser { get { return loggedinUser; } }
        User loggedinUser = null;
        public static readonly User defaultUser = new User();
        UserDAL udal;

        /// <summary>
        /// min
        /// </summary>
        public const int DefaultAllowedLoginTime = 10;

        /// <summary>
        /// min
        /// </summary>
        public int AllowedLoginTime { set; get; }
        public bool UseSecurity { get; set; }
        //public bool EndAuthentication { get; internal set; }
        public void SetLoggedInUSer(User u) { this.loggedinUser = u; }
        public SM()
        {
            UseSecurity = true;
            AllowedLoginTime = DefaultAllowedLoginTime;
            udal = new UserDAL();
            defaultUser.Name = defaultUser.Name = "Default User";


            dangerousUser.Name = "DANGER!";
            dangerousUser.UserRoles.Add(new Role());
            string[] names = Enum.GetNames(typeof(Permissions));
            foreach (string nm in names)
                dangerousUser.UserRoles[0].Permissions.Add((Permissions)Enum.Parse(typeof(Permissions), nm));
        }

        public (bool, User, bool) Login(User[] users, AuthenticationMethod method)
        {
            loggedinUser = null;
            if (UseSecurity == false)
            {
                loggedinUser = defaultUser;
                return (false, null, false);
            }

            while (loggedinUser == null)
            {
                (User u, bool end) = Authenticate(users, method);//Login
                loggedinUser = u;
                //This will be set through the form
                if (end)
                    return (false, null, true);

                if (IsUserAllowedTo(loggedinUser, Permissions.Login))
                    break;
            }

            return (true, loggedinUser, false);
        }
        public void Logout()
        {
            this.loggedinUser = null;
        }


        public bool IsUserAllowedTo(User cu, Permissions perm)
        {
            //Helpers.Logger.Debug($"Use:{UseSecurity}");
            if (UseSecurity == false) return true;

            bool res = IsObjectAuthorized(cu, perm);
            if (!res)
                System.Windows.Forms.MessageBox.Show("Permission denied!\nEffective Permision: " + perm.ToString(), "Permission", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            return res;
        }



        public bool IsObjectAuthorized(ISecurable isec, Permissions p)
        {
            //Helpers.Logger.Debug($"isec==null:{isec == null}");
            if (isec == null) return false;
            if (!AllowedToStayLogin(isec)) return false;
            Role role = isec.UserRoles.Find(r => r.Permissions.Contains(p));
            //Helpers.Logger.Debug($"role==null:{role == null}");
            return role != null;
        }
        public bool AllowedToStayLogin(ISecurable sec)
        {
            return TimeSpan.FromTicks(DateTime.Now.Ticks - sec.LoginTime).TotalMinutes > AllowedLoginTime;
        }

        #region Authentication
        public (User, bool end) Authenticate(User[] users, AuthenticationMethod am)
        {
            bool e = false;
            User u = null;
            switch (am)
            {
                case AuthenticationMethod.Form:
                    {
                        (User u1, bool end1) = AuthenticateByForm(users);
                        u = u1;
                        e = end1;
                    }
                    break;
                case AuthenticationMethod.RFID:
                    {
                        (User u2, bool end2) = AuthenticateByRFID(users);
                        u = u2;
                        //Helpers.Logger.Debug($"u2==null:{u2 == null}");
                        e = end2;
                    }
                    break;
            }

            return (u, e);
        }
        private (User, bool end) AuthenticateByForm(User[] users)
        {
            User u = null;
            frmFormAuthentication f = new frmFormAuthentication(this, users);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                u = f.AuthenticatedUser;

            return (u, f.End);
        }
        private (User, bool) AuthenticateByRFID(User[] users)
        {
            User u = null;
            frmRFAuthentication f = new frmRFAuthentication(users);
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                u = f.AuthenticatedUser;
            //Helpers.Logger.Debug($"AuthenticatedUser==null:{f.AuthenticatedUser == null}");
            if (f.UseDangerous)
                u = dangerousUser;
            //Helpers.Logger.Debug($"u==null:{u == null}. use dangerous={f.UseDangerous}");
            return (u, f.End);
        }
        #endregion
    }

    public class AuthenticateEventArg
    {
        public long ID { set; get; }
        public User AuthenticatedUser { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool Authenticated { set; get; }
    }

    [Serializable]
    public class PermissionBadge : IDName
    {
        //Role r = new Role();
        public Role BadgeRole { set; get; }

        public PermissionBadge() : base()
        {
            this.Name = "New Permisson Bag";
        }
    }

    [Serializable]
    public class Role : IDName
    {
        List<Permissions> perms = new List<Permissions>();

        public Role() : base()
        {
            this.Name = "New Role";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (ReferenceEquals(null, obj)) return false;

            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            Role role = obj as Role;

            return role.Deleted == Deleted && role.ID == ID && role.Name == Name && Enumerable.SequenceEqual(role.Permissions, this.perms);

            //return base.Equals(obj);
        }
        public static bool operator ==(Role a, Role b)
        {
            if (System.Object.ReferenceEquals(a, null))
            {
                if (System.Object.ReferenceEquals(b, null))
                    return true;

                return false;
            }
            if (System.Object.ReferenceEquals(b, null))
            {
                if (System.Object.ReferenceEquals(a, null))
                    return true;

                return false;
            }

            foreach (Permissions p in a.Permissions)
                if (!b.Permissions.Contains(p))
                    return false;
            foreach (Permissions p in b.Permissions)
                if (!a.Permissions.Contains(p))
                    return false;

            return true;
        }
        public static bool operator !=(Role a, Role b)
        {
            return !(a == b);
        }
        public List<Permissions> Permissions { get { return perms; } }
    }
}
