using PNB.SAS;
using PNB.SAS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNB.SAS.Data
{
    [Serializable]
    public class SystemApp
    {
        List<IED> ieds;
        List<Tree> trees;
        List<Connection> connections;
        public SystemApp()
        {
            ieds = new List<IED>();
            trees = new List<Tree>();
            connections = new List<Connection>();
        }

        public List<IED> IEDs { get { return ieds; } }
        public List<Tree> Trees { get { return trees; } }
        public List<Connection> Connections { get { return connections; } }
    }
}
