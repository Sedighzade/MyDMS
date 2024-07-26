using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyDMS.Secretariat
{
    public enum VehicleType { Bus, Airplane }
    [Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
    public class Mission
    {
        long id;
        public Mission()
        {
            id = PNB.Helpers.Util.GetLong();
        }

        public long ID { get { return id; } }

        public string Destination { set; get; }

        public string Subject { set; get; }

        public DateTime From { set; get; }
        public DateTime To { set; get; }
        public VehicleType Vehicle { set; get; }

        /// <summary>
        /// Days
        /// </summary>
        public int Duration { set; get; }
    }
}
