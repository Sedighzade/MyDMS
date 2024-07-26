using PNB.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PNB.Lib.UserMgmt
{
    [Serializable]
    public class User : IDName, ISecurable
    {
        public const string Unknown = "Unknown User";
        public const string DefaultName = "New User";
        List<long> sites = new List<long>();
        List<Role> uroles = new List<Role>();
        public User() : base()
        {
            ///UserRole = Role.Operator;
            Name = DefaultName;
        }
        public string UserName { set; get; }
        public string Password { set; get; }
        public long RFCodeCode { set; get; }
        public byte[] ImageBytes { set; get; }
        //public string FullName { get; set; }
        public long DateAdded { get; set; }
        public List<Role> UserRoles { get { return uroles; } }
        [Obsolete("Do not use!")]
        public Role UserRole { get; set; }
        public long LoginTime { get; set; }

        //[NonSerialized]
        //Image img;
        //public Image Photo
        //{
        //    set
        //    {
        //        img = value;
        //        using (MemoryStream m = new MemoryStream())
        //        {
        //            img.Save(m, img.RawFormat);
        //            ImageBytes = m.ToArray();
        //        }
        //    }
        //    get { return img; }
        //}
        public List<long> Sites { get { return sites; } }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            //if (DateAdded == 0)
            //    DateAdded = DateTime.Now.Ticks;
            //if (sites == null)
            //    sites = new List<long>();

            //if (Name != DefaultName)
            //    RFCodeCode = ID;

            //if (uroles == null)
            //{
            //    uroles = new List<Role>();
            //    if (UserRole != null)
            //    {
            //        uroles.Add(UserRole);
            //        UserRole = null;
            //    }
            //}
        }

    }
}
