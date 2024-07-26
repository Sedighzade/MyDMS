using PNB.SAS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNB.SAS.Data
{
    [Serializable]
    public class Tree
    {
        List<IED> ieds;
        List<Tree> gs;
        public Tree()
        {
            ieds = new List<IED>();
            gs = new List<Tree>();
        }
        public List<Tree> Children { get { return gs; } }
        public List<IED> IEDs { get { return ieds; } }
        public Tree Owner { set; get; }
        public long ID { set; get; }
        public string Name { set; get; }
    }
}
