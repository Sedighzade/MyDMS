using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PNB.SAS.Data
{
    public enum DataTagType { Boolean, Double, Text, Complex, Enumerated }
    [Serializable]
    public abstract class DataTag : ISerializable
    {
        public DataTag()
        {
            Time = DateTime.Now.Ticks;
        }
        public DataTagType TagType { set; get; }
        public long Time { set; get; }
        public long InfoID { set; get; }
        public long IED { set; get; }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        public abstract byte[] GetBytes();
        public abstract DataTag Deserialize(byte[] bts);
        protected void GetInternalByts(byte[] bts)
        {
            Array.Copy(BitConverter.GetBytes(Time), 0, bts, 0, sizeof(long));
            Array.Copy(BitConverter.GetBytes(InfoID), 0, bts, sizeof(long), sizeof(long));
        }
    }
    public class ENS : DataTag
    {
        public double Value { set; get; }

        public override DataTag Deserialize(byte[] bts)
        {
            ENS ens = this;
            ens.Value = 0;
            ens.Time = 0;
            ens.InfoID = 0;

            return ens;
        }

        public override byte[] GetBytes()
        {
            byte[] bts = new byte[sizeof(long) + sizeof(long) + sizeof(double)];
            GetInternalByts(bts);
            Array.Copy(BitConverter.GetBytes(Value), 0, bts, sizeof(long) + sizeof(long), sizeof(double));
            return bts;
        }
    }
    public class InternalCommand : DataTag
    {
        List<long> ieds = new List<long>();
        public int SMVReportSamples { set; get; }
        public long StartTime { set; get; }
        public long EndTime { set; get; }
        public string Text { set; get; }
        public bool MatchCase { set; get; }
        public bool MatchWholeWordOnly { set; get; }
        public List<long> IEDs { get { return ieds; } }

        public override byte[] GetBytes()
        {
            return null;
        }

        public override DataTag Deserialize(byte[] bts)
        {
            return null;         
        }
    }
}
