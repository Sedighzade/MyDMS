using PNB.SAS.Data;
using PNB.SAS.DataProcessor;
using System.Collections.Generic;
using System.Threading;

namespace PNB.SAS.DAQ
{
    public class DAQ
    {
        bool shutdown = false;
        object LOCK_process = new object();
        object LOCK_station = new object();
        List<DataTag> m_Process = new List<DataTag>();
        List<DataTag> m_Station = new List<DataTag>();
        PNB.SAS.Settings.Settings settings;
        Archive.Archive arc;

        public List<DataTag> Process
        {
            get
            {
                return m_Process;
            }
        }
        public List<DataTag> Station
        {
            get
            {
                return m_Station;
            }
        }


        public DAQ()
        {
            init();
        }
        private void init()
        {
            settings = new Settings.Settings();
            arc = new Archive.Archive(null);
        }
        private void Start()
        {
            ///setup helpers
            settings.Load();

            ThreadPool.QueueUserWorkItem(delegate { FromProcessBus(); });
            ThreadPool.QueueUserWorkItem(delegate { FromStationBus(); });

            settings.Save();
        }

        #region Station
        void FromProcessBus()
        {
            List<NetData> nd = new List<NetData>();
            ProcessEngine pe = new ProcessEngine();
            List<DataTag> lst = new List<DataTag>();
            while (!shutdown)
            {
                lock (LOCK_process)
                {
                    lst.AddRange(m_Process);
                    m_Process.Clear();
                }

                pe.Process(lst, nd);
                ToStationBus(nd);

                lst.Clear();
                Thread.Sleep(50);
            }
        }
        void ToProcessBus()
        {
        }
        #endregion


        #region Station
        void FromStationBus()
        {
            List<DataTag> lst = new List<DataTag>();
            while (!shutdown)
            {
                lock (LOCK_station)
                {
                    lst.AddRange(m_Process);
                    m_Station.Clear();
                }

                lst.Clear();
                Thread.Sleep(50);
            }
        }
        void ToStationBus(List<NetData> nd) { }

        #endregion
    }
}
