using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNB.Lib.UserMgmt
{
    public interface ISecurable
    {
        Role UserRole { get; set; }
        List<Role> UserRoles { get; }

        long LoginTime { set; get; }
    }
}
