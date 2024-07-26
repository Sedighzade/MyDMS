using PNB.Helpers;
using PNB.SAS.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace PNB.SAS.Archive
{
    public class Archive
    {
        /// Docs - 1398.04.01
        /// File Structure
        /// |----------------------------------------|
        /// |           HEADER section               |        
        /// |----------------------------------------|
        /// |           KEY section                  |
        /// |    1 KEY size = Time + Size            |
        /// |               = 8 + 4 byte             |
        /// |          ----------------------        |
        /// |               TIME SECTION             |
        /// |          ----------------------        |
        /// |               SIZE SECTION             |
        /// |          ----------------------        |       
        /// |    first section is slot save times    |
        /// |    second part is slot size section    |
        /// |----------------------------------------|
        /// |           DATA section                 |
        /// KEYs structure:
        ///  keys structure compose of 3 sections
        ///     slot time | slot size | Poll round times in each slot
        /// Poll round times capacity calculation:
        ///  I assume we at maximum rate, collect data every 5 seconds.
        ///    key per day = 86400 / 5 sec = 17280 keys
        ///    key per year = 17280 * 365 = 6307200 keys per year
        ///    we reserve each file for 2 year, hence
        ///    keys per 2 year = 6307200 * 2 = 12614400 keys per 2 years
        ///    Needed capacity = 12614400 * 8 bytes = 100915200 bytes
        ///    TODO:
        ///    A better solution is to store keys in a seperate file


        #region Consts
        public const float Version = 1.1F;

        /// <summary>
        /// 256
        /// </summary>
        const int HEADER_SECTION_SIZE = 256;

        /// <summary>
        /// 2628000
        /// </summary>
        const int KEYS_SLOTS_SECTION_SIZE = 2628000;//( save every 10 min. = 144 slot per day * 365 days * 2.5 years * 20 bytes

        /// <summary>
        /// 1051200
        /// </summary>
        const int KEYS_SLOTS_TIME_SECTION_SIZE = 1051200;//( save every 10 min. = 144 slot per day * 365 days * 2.5 years * 8 bytes

        /// <summary>
        /// 1576800
        /// </summary>
        const int KEYS_SLOTS_SIZE_SECTION_SIZE = 1576800;//( save every 10 min. = 144 slot per day * 365 days * 2.5 years * 12 bytes

        /// <summary>
        /// 126144000
        /// </summary>
        const int KEYS_POLL_ROUND_SECTION_SIZE = 126144000;//( save ied data every 5 sec = 17280 sample per day * 365 days * 2.5 years * 8 bytes 

        /// <summary>
        /// 12
        /// </summary>
        const int KEY_SLOT_SIZE = 20; // Time + Size + Poll Time
        /// <summary>
        /// 120 = 600 sec / ever 5 sec.
        /// </summary>
        const int KEY_POLL_COUNT_PER_SLOT = 120;
        #endregion


        #region Classes
        public class SMVFile
        {
            SMVHeader header = null;
            SMVKeySection keySec = null;
            List<byte> bytes = new List<byte>();

            public SMVFile(long ied, SMVHeader Header)
            {
                string fn = GetSMVFileName(ied);
                header = Header;
                IED = ied;
                header.FileName = fn;
                keySec = new SMVKeySection(ied);
            }
            public SMVFile(long ied)
            {
                string fn = GetSMVFileName(ied);
                keySec = new SMVKeySection(ied);
                header = new SAS.Archive.Archive.SMVHeader(ied, DateTime.Now.Ticks);//SMVFile
                IED = ied;
                header.FileName = fn;
            }
            public long IED { set; get; }
            public List<byte> Bytes { get { return bytes; } }
            public SMVHeader HeaderSection { get { return header; } }
            public SMVKeySection KeySection { get { return keySec; } }
            public static SMVFile CreateOrOpenSMVFile(long ied)
            {
                /// docs
                /// if file is older than 2.5 year, then move it to backup folder
                /// and create a new one!

                SMVFile smv = null;
                FileStream fs = null;
                string fn = Archive.GetSMVFileName(ied);
                if (File.Exists(fn))
                {
                    ///docs
                    /// Do not serialize key section when loading the file
                    try
                    {
                        SMVHeader header = SMVHeader.Deserialize(ied);//CreateOrOpenSMVFile
                        DateTime toc = new DateTime(header.TOC);
                        if (DateTime.Now.Subtract(new TimeSpan(2 * 365, 0, 0, 0)) > toc)
                        {
                            Directory.CreateDirectory(Configuration.GetSMVDataDir() + "\\Backup");
                            ///TODO: DELETE oldest files
                            File.Move(fn, GetSMVBackupFile(ied));
                            smv = CreateOrOpenSMVFile(ied);
                        }
                        else
                            smv = new SMVFile(ied, header);//CreateOrOpenSMVFile
                    }
                    catch (Exception eee) { Logger.Log(eee); }
                }
                else
                {
                    ///create a new SMV File                
                    smv = new SMVFile(ied);//CreateOrOpenSMVFile
                    try
                    {
                        fs = File.Open(fn, FileMode.OpenOrCreate);
                        fs.SetLength(HEADER_SECTION_SIZE + KEYS_SLOTS_SECTION_SIZE + KEYS_POLL_ROUND_SECTION_SIZE);//CreateOrOpenSMVFile
                        fs.Seek(0, SeekOrigin.Begin);
                        fs.Write(smv.HeaderSection.GetBytes(), 0, HEADER_SECTION_SIZE);
                        //byte[] keySection = new byte[KEYS_SLOTS_SECTION_SIZE+ KEYS_POLL_ROUND_SECTION_SIZE];
                    }
                    catch (Exception ff)
                    {
                        Logger.Log(ff);
                    }
                    finally
                    {
                        if (fs != null)
                            fs.Close();
                    }
                }
                return smv;
            }

            internal static byte[] GetChunk(long ied, int address, int length)
            {
                byte[] bts = new byte[length];
                FileStream fs = null;
                string fn = GetSMVFileName(ied);
                using (fs = File.Open(fn, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    fs.Seek(address, SeekOrigin.Begin);
                    fs.Read(bts, 0, length);
                }
                return bts;
            }

            internal void GetSlotData(SlotData srt)
            {

            }
        }
        public class SMVHeader
        {
            public SMVHeader(byte[] headerbytes)
            {
                if (headerbytes == null)
                    throw new ArgumentNullException();

                int sizeofFloat = sizeof(float);
                int sizeofLong = sizeof(long);
                int sizeofInt = sizeof(int);
                int idx = 0;
                this.Version = BitConverter.ToSingle(headerbytes, idx);
                idx += sizeofFloat;
                this.TOC = BitConverter.ToInt64(headerbytes, idx);
                idx += sizeofLong;
                this.IED = BitConverter.ToInt64(headerbytes, idx);
                idx += sizeofLong;
                this.SlotCount = BitConverter.ToInt32(headerbytes, idx);
                idx += sizeofInt;
                this.LastSaveTime = BitConverter.ToInt64(headerbytes, idx);
                idx += sizeofLong;
                this.IndexDataSection = BitConverter.ToInt64(headerbytes, idx);
                idx += sizeofLong;
                this.PollCount = BitConverter.ToInt64(headerbytes, idx);
            }
            public SMVHeader(long ied, long toc)
            {
                TOC = toc;
                IED = ied;
                LastSaveTime = 1;
                SlotCount = -1;
            }


            #region Methods
            internal static SMVHeader Deserialize(long ied)
            {
                SMVHeader h = null;
                try
                {
                    byte[] headerBytes = SMVFile.GetChunk(ied, 0, HEADER_SECTION_SIZE);
                    if (headerBytes.Length > 0)
                        h = new Archive.SMVHeader(headerBytes);//Deserialize
                }
                catch (Exception eee) { Logger.Log(eee); }
                return h;
            }
            internal byte[] GetBytes()
            {
                byte[] bts = new byte[HEADER_SECTION_SIZE];

                List<byte> lst = new List<byte>();

                byte[] gh = BitConverter.GetBytes(Archive.Version);

                lst.AddRange(BitConverter.GetBytes(Archive.Version));//ver
                lst.AddRange(BitConverter.GetBytes(TOC));//TOC
                lst.AddRange(BitConverter.GetBytes(IED));//IED
                lst.AddRange(BitConverter.GetBytes(SlotCount));//Key  Slot Count in the Key section
                lst.AddRange(BitConverter.GetBytes(LastSaveTime));//Last Save Time
                lst.AddRange(BitConverter.GetBytes(IndexDataSection));//Last Index                                                                     
                lst.AddRange(BitConverter.GetBytes(PollCount));//Poll Count
                byte[] lst2Array = lst.ToArray();
                Array.Copy(lst2Array, 0, bts, 0, lst2Array.Length);
                return bts;
            }

            #endregion

            #region Property
            public string FileName { set; get; }
            public float Version { set; get; }
            public long TOC { set; get; }
            public long LastSaveTime { set; get; }
            public long IED { set; get; }
            /// <summary>
            /// Number of slots in the key section
            /// </summary>
            public int SlotCount { set; get; }
            public long PollCount { set; get; }
            public long IndexDataSection { set; get; }
            //public int LastPageSize { set; get; }
            public bool ValidHeader { set; get; }
            #endregion

        }
        public class SMVKeySection
        {
            long[] pollRounds = new long[KEY_POLL_COUNT_PER_SLOT];
            public long IED { set; get; }
            string fn;
            public long CurrentSlotTime { set; get; }

            public SMVKeySection(long ied)
            {
                this.IED = ied;
                fn = GetSMVFileName(ied);
                CurrentSlotTime = -1;
            }

            internal void LoadKeySizeFromFile(List<SlotData> keys)
            {
                byte[] keysasByte = null;
                int counter = 0;
                keysasByte = SMVFile.GetChunk(IED, HEADER_SECTION_SIZE + KEYS_SLOTS_TIME_SECTION_SIZE, KEYS_SLOTS_SIZE_SECTION_SIZE);
                if (keysasByte == null) return;
                int idx = 0;
                while (counter < KEYS_SLOTS_TIME_SECTION_SIZE)
                {
                    SlotData kvp = keys[idx++];
                    kvp.Time = BitConverter.ToInt32(keysasByte, counter);
                    counter += sizeof(int);
                }
            }
            internal List<SlotData> LoadKeyTimesFromFile()
            {
                byte[] keysasByte = null;
                int counter = 0;
                List<SlotData> lst = new List<Archive.SlotData>();
                keysasByte = SMVFile.GetChunk(IED, HEADER_SECTION_SIZE, KEYS_SLOTS_TIME_SECTION_SIZE);
                if (keysasByte == null) return null;

                while (counter < KEYS_SLOTS_TIME_SECTION_SIZE)
                {
                    SlotData kvp = new SlotData();
                    kvp.Time = BitConverter.ToInt64(keysasByte, counter);
                    counter += sizeof(long);
                    lst.Add(kvp);
                }
                return lst;
            }
            internal List<SlotData> LoadKeysFromFile()
            {
                byte[] keysasByte = null;
                int counter = 0;
                List<SlotData> lst = new List<Archive.SlotData>();
                keysasByte = SMVFile.GetChunk(IED, HEADER_SECTION_SIZE, KEYS_SLOTS_SECTION_SIZE);
                if (keysasByte == null) return null;

                while (counter < KEYS_SLOTS_TIME_SECTION_SIZE)
                {
                    SlotData kvp = new SlotData();
                    kvp.Time = BitConverter.ToInt64(keysasByte, counter);
                    counter += sizeof(long);
                    lst.Add(kvp);
                }
                counter = 0;
                int idx2 = 0;
                while (counter < KEYS_SLOTS_SIZE_SECTION_SIZE)
                {
                    lst[idx2++].SlotSize = BitConverter.ToInt32(keysasByte, counter + KEYS_SLOTS_TIME_SECTION_SIZE);
                    counter += sizeof(int);
                }
                return lst;
            }
        }
        public class SlotData
        {
            List<long> lst = new List<long>(KEY_POLL_COUNT_PER_SLOT);
            public long Time { set; get; }
            public int SlotSize { set; get; }
            public List<long> Polls { get { return lst; } }
            public int SlotFileIndex { set; get; }

            public override string ToString()
            {
                return Util.ConvertDateTimeToFileName(Time, false);
            }
        }
        #endregion

        int count = 0;
        long lastSave = 0;
        object lockObject = new object();
        ArchiveSettings asett = new ArchiveSettings();
        List<SMVFile> smvs = new List<SMVFile>();
        List<long> ieds = new List<long>();
        public Archive(List<long> IEDs)
        {
            lastSave = DateTime.Now.Ticks;

            ieds.AddRange(IEDs);
        }
        public void Init()
        {
            foreach (long ied in ieds)
                smvs.Add(SMVFile.CreateOrOpenSMVFile(ied));//init
        }

        #region Static Methods
        public static void CreateFolderStructure()
        {
            string dir = Configuration.GetSMVDataDir();

            try
            {
                Directory.CreateDirectory(dir);
            }
            catch (Exception ee)
            {
                Logger.Log(ee);
            }
        }
        public static string GetSMVFileName(long ied)
        {
            string fn = "";
            fn = string.Format("{0}\\{1}.dat", Configuration.GetSMVDataDir(), ied);
            return fn;
        }
        public static string GetSMVBackupFile(long ied)
        {
            string fn = "";
            fn = string.Format("{0}\\Backup\\{1}_backup_{2}.dat"
                , Configuration.GetSMVDataDir()
                , ied, Util.ConvertDateTimeToFileName(false));
            return fn;
        }
        #endregion

        #region SMV
        public void BeginSMVSaveData(List<PollRoundData> data)
        {
            int c1 = 0;
            SMVFile smv = null;
            foreach (PollRoundData prd in data)
            {
                if ((smv = smvs.Find(x => x.IED == prd.IED)) == null) continue;
                List<DataTag> lst = prd.Data;
                if (lst.Count == 0) continue;
                smv.HeaderSection.PollCount++;

                lock (lockObject)
                {
                    foreach (DataTag dt in lst)
                    {
                        byte[] bts = dt.GetBytes();
                        smv.Bytes.AddRange(bts);
                        //set first time as slot time
                        if (smv.KeySection.CurrentSlotTime == -1)
                            smv.KeySection.CurrentSlotTime = dt.Time;
                        //set slot size
                        count++;
                    }
                }
            }
            c1 = count;


            bool cond = TimeSpan.FromTicks(DateTime.Now.Ticks - lastSave).TotalMinutes >= asett.SaveInterval
            || c1 > asett.MemoryObjectLimit;

            //if (cond)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    SaveSMVMeasurings();
                });
            }
        }
        private void SaveSMVMeasurings()
        {
            FileStream fs = null;

            foreach (SMVFile smv in smvs)
            {
                if (smv.Bytes.Count == 0) continue;
                byte[] bts = smv.Bytes.ToArray();

                try
                {
                    long CurrentdataIndex = smv.HeaderSection.IndexDataSection;
                    //Fill
                    fs = new FileStream(smv.HeaderSection.FileName, FileMode.Open, FileAccess.Write, FileShare.Read, 4096);

                    ///HEADER
                    smv.HeaderSection.SlotCount++;
                    smv.HeaderSection.IndexDataSection += bts.Length;//while writting bytes, actual position for current slot is IndexDataSection - bts.Length
                    smv.HeaderSection.LastSaveTime = DateTime.Now.Ticks;
                    byte[] HeadersasByte = smv.HeaderSection.GetBytes();
                    fs.Write(HeadersasByte, 0, HEADER_SECTION_SIZE);

                    ///KEY
                    fs.Seek(HEADER_SECTION_SIZE + smv.HeaderSection.SlotCount * sizeof(long), SeekOrigin.Begin);
                    fs.Write(BitConverter.GetBytes(smv.KeySection.CurrentSlotTime), 0, sizeof(long));

                    fs.Seek(HEADER_SECTION_SIZE + KEYS_SLOTS_TIME_SECTION_SIZE + smv.HeaderSection.SlotCount * sizeof(int), SeekOrigin.Begin);
                    fs.Write(BitConverter.GetBytes(bts.Length), 0, sizeof(int));
                    long pos = HEADER_SECTION_SIZE + KEYS_SLOTS_SECTION_SIZE;
                    pos += smv.HeaderSection.PollCount * sizeof(long);
                    fs.Seek(pos, SeekOrigin.Begin);
                    fs.Write(BitConverter.GetBytes(smv.HeaderSection.PollCount), 0, sizeof(long));
                    //DATA
                    fs.Seek(HEADER_SECTION_SIZE + KEYS_SLOTS_SECTION_SIZE + CurrentdataIndex, SeekOrigin.Begin);
                    fs.Write(bts, 0, bts.Length);

                    smv.Bytes.Clear();
                }
                catch (Exception ee) { Logger.Log(ee); }
                finally { if (fs != null) fs.Close(); }
            }
            lock (lockObject)
                count = 0;
        }
        public List<DataTag> GetSMVMeasurings(InternalCommand ic)
        {
            List<DataTag> lst = new List<DataTag>();

            try
            {
                foreach (long ied in ic.IEDs)
                {
                    SMVFile smv = smvs.Find(x => x.IED == ied);
                    if (smv == null) continue;

                    /// 2. search tree
                    List<SlotData> keys = smv.KeySection.LoadKeysFromFile();//GetSMVMeasurings
                    SlotData srt = keys.FirstOrDefault(x => x.Time >= ic.StartTime);

                    SlotData end = keys.FirstOrDefault(x => x.Time <= ic.EndTime);

                    foreach (SlotData k in keys)
                    {
                        if (k.Time > srt.Time) break;
                        srt.SlotFileIndex += k.SlotSize;
                    }
                    foreach (SlotData k1 in keys)
                    {
                        if (k1.Time < end.Time) break;
                        end.SlotFileIndex += k1.SlotSize;
                    }
                    ///3. Sampling
                    smv.GetSlotData(srt);
                    smv.GetSlotData(end);

                    long interval = TimeSpan.FromTicks(ic.EndTime - ic.StartTime).Ticks / ic.SMVReportSamples;
                    int idxEnd = keys.IndexOf(end);
                    FileStream fs = File.Open(GetSMVFileName(ied), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    for (int i = keys.IndexOf(srt); i < idxEnd; i++)
                    {
                        long indexOfSlot = 0;
                        long PollTime = 0;
                        DataTag dt = null;

                        try
                        {
                            dt = GetPointData(fs, indexOfSlot, PollTime);
                        }
                        catch (Exception ee) { Logger.Log(ee); }
                    }
                    fs.Close();
                }
            }
            catch (Exception eee) { Logger.Log(eee); }

            return lst;
        }

        private DataTag GetPointData(FileStream fs, long indexOfSlot, long pollTime)
        {
            DataTag dt = null;
            byte[] bts = new byte[100];

            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(bts, 0, 100);
            ENS ens = new ENS();
            ens.Deserialize(bts);
            dt = ens;
            return dt;
        }


        #endregion

        #region non-SMV
        public void BeginSaveData(List<DataTag> data)
        {
            List<DataTag> l1 = data;
            ThreadPool.QueueUserWorkItem(delegate { SaveData(l1); });
        }
        public void SaveData(List<DataTag> data)
        {

        }
        public List<DataTag> GetData(InternalCommand ic)
        {
            List<DataTag> lst = new List<DataTag>();

            return lst;
        }
        #endregion

    }

    public class ArchiveSettings
    {
        public ArchiveSettings()
        {
            MemoryObjectLimit = 10000;
            SaveInterval = 10;
        }
        /// <summary>
        /// min.
        /// </summary>
        public int SaveInterval { set; get; }
        public int MemoryObjectLimit { set; get; }
        /// <summary>
        /// Month
        /// </summary>
        //public int DeleteCycle { set; get; }
    }
}
