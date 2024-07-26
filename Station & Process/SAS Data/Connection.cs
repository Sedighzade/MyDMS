using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNB.SAS.Data
{
    [Serializable]
    public class Connection
    {
        public long ID { set; get; }
        public string Name { set; get; }
    }
}
