using PNB.SAS.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PNB.SAS.Data
{
    [Serializable]
    public class IED
    {
        List<AbsProtocol> lst = new List<AbsProtocol>();
        public long ID { set; get; }
        public string Name { set; get; }
        public List<AbsProtocol> Protocols { get { return lst; } }
    }
    public class PollRoundData
    {
        List<DataTag> lst = new List<DataTag>();
        public long IED { set; get; }
        public long Time { set; get; }
        public List<DataTag> Data { get { return lst; } }
    }
}
