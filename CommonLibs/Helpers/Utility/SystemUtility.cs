using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;

namespace PNB.Helpers
{
    public class SystemUtility
    {
        [DllImport("ntdll.dll", EntryPoint = "NtSetTimerResolution")]
        static extern void NtSetTimerResolution(uint DesiredResolution, bool SetResolution, ref uint CurrentResolution);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SetResolution"></param>
        /// <returns></returns>
        public static uint SetResolution(bool SetResolution, uint DesiredResolution)
        {
            /*
             Timer interrupts are, by their very nature, extremely stable and precise.
            They happen at exactly the requested frequency, and your thread is readied immediately when they fire. 
            So, on all Windows operating systems you can assume that Sleep() readies your thread at exactly the correct time (rounded up or down).
            So, where do the variations come from? Why does careful measurement 
            show that the interval is sometimes a few tenths of a millisecond longer or shorter?

            The answer is that even an idle Windows system is still running other code.
            Some of this other code may also be triggered by the timer interrupt which means that
            there will sometimes be a lot of processes that all want to run at exactly the same time.
            Even on a multi-core system this can lead to short delays, 
            especially if some cores are parked or if the Windows scheduler is trying to maintain core affinity.
             */

            //https://randomascii.wordpress.com/2013/07/08/windows-timer-resolution-megawatts-wasted/
            //https://randomascii.wordpress.com/2020/10/04/windows-timer-resolution-the-great-rule-change/
            //https://randomascii.wordpress.com/2013/04/02/sleep-variation-investigated/

            ////////VERY IMPORTANT ///////////
            ///https://docs.microsoft.com/en-us/archive/msdn-magazine/2004/february/comparing-the-timer-classes-in-the-net-framework-class-library#S3
            ///

            //https://docs.microsoft.com/en-gb/windows/win32/multimedia/about-multimedia-timers
            //https://stackoverflow.com/questions/3744032/why-are-net-timers-limited-to-15-ms-resolution
            //http://mirrors.arcadecontrols.com/www.sysinternals.com/Information/HighResolutionTimers.html
            //https://docs.microsoft.com/en-us/archive/msdn-magazine/2004/march/implementing-a-high-resolution-time-provider-for-windows


            // The requested resolution in 100 ns units:
            if (DesiredResolution == 0)
                DesiredResolution = 5000;
            uint CurrentResolution = 0;
            NtSetTimerResolution(DesiredResolution, SetResolution, ref CurrentResolution);
            return CurrentResolution;
        }


        public static void StartService(string servcieName, string path)
        {
            ServiceController sc = ServiceExist(servcieName);
            if (sc == null)//Create the service
            {
                sc = new ServiceController();
            }
        }
        public static ServiceController ServiceExist(string servcieName)
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            foreach (ServiceController sc in scServices)
                if (sc.ServiceName == servcieName)
                    return sc;

            return null;
        }

        public static void CreateTempFolder()
        {
            if (Util.IsWindows)
            {
               
            }
            else if (Util.IsLinux)
            {
            }
        }
        public static void OpenFolder(string path)
        {
            //https://stackoverflow.com/questions/22637461/how-can-i-open-a-file-location-or-open-a-folder-location-in-monodevelop-gtk
            if (Util.IsLinux)
            {
                //TODO:
                /// use System.Diagnostics.Process.Start("nemo", "/home");
                /// and file all available file managers and use one

                /// use this to find all avialable file managers
                //Process.Start("mimetype", path); 

                Process.Start("nemo", path);
                Process.Start("pcmanfm", path);
                Process.Start("thunar", path);
            }
            else if (Util.IsWindows)
                Process.Start("explorer.exe", path);
        }

        public static bool IsAnotherInstanceRunning(string appGuid)
        {
            bool res = false;
            if (Util.IsLinux) { }
            else
            {
                System.Threading.Mutex mutex = new System.Threading.Mutex(false, "Global\\" + appGuid);
                res = !mutex.WaitOne(0, false);
                GC.KeepAlive(mutex);
            }

            return res;
        }

    }

    namespace PAB
    {
        public class HiPerfTimer
        {
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);
            [DllImport("Kernel32.dll")]
            private static extern bool QueryPerformanceFrequency(out long lpFrequency);

            private long startTime;
            private long stopTime;
            private long freq;
            /// <summary>
            /// ctor
            /// </summary>
            public HiPerfTimer()
            {
                startTime = 0;
                stopTime = 0;
                freq = 0;
                if (QueryPerformanceFrequency(out freq) == false)
                {
                    throw new Win32Exception(); // timer not supported
                }
            }
            /// <summary>
            /// Start the timer
            /// </summary>
            /// <returns>long - tick count</returns>
            public long Start()
            {
                QueryPerformanceCounter(out startTime);
                return startTime;
            }
            /// <summary>
            /// Stop timer
            /// </summary>
            /// <returns>long - tick count</returns>
            public long Stop()
            {
                QueryPerformanceCounter(out stopTime);
                return stopTime;
            }
            /// <summary>
            /// Return the duration of the timer (in seconds)
            /// </summary>
            /// <returns>double - duration</returns>
            public double Duration
            {
                get
                {
                    return (double)(stopTime - startTime) / (double)freq;
                }
            }
            /// <summary>
            /// Frequency of timer (no counts in one second on this machine)
            /// </summary>
            ///<returns>long - Frequency</returns>
            public long Frequency
            {
                get
                {
                    QueryPerformanceFrequency(out freq);
                    return freq;
                }
            }
        }

        public class Logging
        {
            public double StartTicks;
            public double EndTicks;
            public double cumTime;
            public string ActiveGUID = String.Empty;
            public string strLogFileName = String.Empty;
            private HiPerfTimer hpt;
            public Logging(string strFileName)
            {
                if (strFileName != "")
                {
                    strLogFileName = strFileName;
                }
                else
                {
                    strLogFileName = "DefaultAppLog";
                }
                hpt = new PAB.HiPerfTimer();
            }

            public string StartLogEntry(string strLogEntryName, string strComment)
            {
                string lf = String.Empty;
                if (strLogFileName != "")
                {
                    lf = @"\" + strLogFileName + ".csv";
                }
                else
                {
                    lf = @"\DefaultAppLog.csv";
                }
                string strFullLogPathName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + lf;
                string strLogEntryGUID = Guid.NewGuid().ToString();
                ActiveGUID = strLogEntryGUID;
                string strtime = DateTime.Now.ToShortDateString() + ": " + DateTime.Now.ToShortTimeString();


                hpt.Start();
                StartTicks = 0;// set to zero
                cumTime = 0;
                Debug.WriteLine(StartTicks.ToString());
                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("New Entry: ");
                sbLog.Append(",");
                sbLog.Append(strLogEntryGUID);
                sbLog.Append(",");
                sbLog.Append(strtime);
                sbLog.Append(",");
                sbLog.Append(strLogEntryName);
                sbLog.Append(",");
                sbLog.Append(strComment);
                sbLog.Append("| Caller: ");
                string strCallAssy = System.Reflection.Assembly.GetCallingAssembly().ToString();
                strCallAssy = strCallAssy.Substring(0, strCallAssy.IndexOf(","));
                sbLog.Append(strCallAssy);

                sbLog.Append(",");
                sbLog.Append("0");
                sbLog.Append(",");
                sbLog.Append("0");
                sbLog.Append("\r\n");
                try
                {
                    FileInfo fi = new FileInfo(strFullLogPathName);
                    FileStream sWriterAppend = fi.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    sWriterAppend.Write(System.Text.Encoding.ASCII.GetBytes(sbLog.ToString()), 0, sbLog.Length);
                    sWriterAppend.Flush();
                    sWriterAppend.Close();
                    sbLog = null;
                    fi = null;
                    sWriterAppend = null;
                }
                catch (Exception ex)
                {
                    sbLog = null;
                    return ex.Message;
                }
                return strLogEntryGUID;
            }

            public string AddLogEntry(string strLogEntryGUID, string strLogEntryName, string strComment)
            {
                if (strLogEntryGUID != ActiveGUID) throw new Exception("Log Entry GUID Mismatch.");

                string lf = String.Empty;

                if (strLogFileName.Length > 0)
                {
                    lf = @"\" + strLogFileName + ".csv";
                }
                else
                {
                    lf = @"\DefaultAppLog.csv";
                }

                string strFullLogPathName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + lf;
                string strtime = DateTime.Now.ToShortDateString() + ": " + DateTime.Now.ToShortTimeString();

                hpt.Stop();
                EndTicks = hpt.Duration;
                cumTime += EndTicks; // add to cum time elapsed

                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("Add Entry: ");
                sbLog.Append(",");
                sbLog.Append(strLogEntryGUID);
                sbLog.Append(",");
                sbLog.Append(strtime);
                sbLog.Append(",");
                sbLog.Append(strLogEntryName);
                sbLog.Append(",");
                sbLog.Append(strComment);
                sbLog.Append(",");
                string strIntElapsed = String.Empty;


                sbLog.Append(EndTicks.ToString()); // this event duration in sec
                sbLog.Append(",");
                strIntElapsed = cumTime.ToString();
                hpt.Start();
                sbLog.Append(strIntElapsed);
                sbLog.Append("\r\n");
                try
                {
                    FileInfo fi = new FileInfo(strFullLogPathName);
                    FileStream sWriterAppend = fi.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    sWriterAppend.Write(System.Text.Encoding.ASCII.GetBytes(sbLog.ToString()), 0, sbLog.Length);
                    sWriterAppend.Flush();
                    sWriterAppend.Close();
                    sbLog = null;
                    fi = null;
                    sWriterAppend = null;
                }
                catch (Exception ex)
                {
                    sbLog = null;
                    return ex.Message;
                }
                return strLogEntryGUID;
            }

            public string CloseLogEntry(string strLogEntryGUID, string strLogEntryName, string strComment)
            {
                if (strLogEntryGUID != ActiveGUID)
                {
                    throw new Exception("Log Entry GUID Mismatch.");
                }
                string lf = String.Empty;

                if (strLogFileName != "")
                {
                    lf = @"\" + strLogFileName + ".csv";
                }
                else
                {
                    lf = @"\DefaultAppLog.csv";
                }

                string strFullLogPathName = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + lf;
                string strtime = DateTime.Now.ToShortDateString() + ": " + DateTime.Now.ToShortTimeString();
                hpt.Stop();
                EndTicks = hpt.Duration;
                cumTime += EndTicks; // add to cum time elapsed
                StringBuilder sbLog = new StringBuilder();
                sbLog.Append("Close Entry: ");
                sbLog.Append(",");
                sbLog.Append(strLogEntryGUID);
                sbLog.Append(",");
                sbLog.Append(strtime);
                sbLog.Append(",");
                sbLog.Append(strLogEntryName);
                sbLog.Append(",");
                sbLog.Append(strComment);
                sbLog.Append(",");
                sbLog.Append(EndTicks.ToString());
                sbLog.Append(",");
                sbLog.Append(cumTime.ToString());
                sbLog.Append("\r\n");
                try
                {
                    FileInfo fi = new FileInfo(strFullLogPathName);
                    FileStream sWriterAppend = fi.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    sWriterAppend.Write(System.Text.Encoding.ASCII.GetBytes(sbLog.ToString()), 0, sbLog.Length);
                    sWriterAppend.Flush();
                    sWriterAppend.Close();
                    sbLog = null;
                    fi = null;
                    sWriterAppend = null;
                    StartTicks = 0;

                    EndTicks = 0;
                    cumTime = 0;
                }
                catch (Exception ex)
                {
                    sbLog = null;
                    return ex.Message;
                }
                return strLogEntryGUID;
            }
        }
    }


    namespace Maju_M
    {
        public class wifi
        {

            #region declarations

            private const int WLAN_API_VERSION_2_0 = 2; //Windows Vista WiFi API Version
            private const int WLAN_API_XP_VERSION = 1;
            private const int ERROR_SUCCESS = 0;

            /// <summary>
            /// Opens a connection to the server
            /// </summary>
            [DllImport("wlanapi.dll", SetLastError = true)]
            private static extern UInt32 WlanOpenHandle(UInt32 dwClientVersion, IntPtr pReserved, out UInt32 pdwNegotiatedVersion, ref IntPtr phClientHandle);

            /// <summary>
            /// Closes a connection to the server
            /// </summary>
            [DllImport("wlanapi.dll", SetLastError = true)]
            private static extern UInt32 WlanCloseHandle(IntPtr hClientHandle, IntPtr pReserved);

            /// <summary>
            /// Enumerates all wireless interfaces in the laptop
            /// </summary>
            [DllImport("wlanapi.dll", SetLastError = true)]
            private static extern UInt32 WlanEnumInterfaces(IntPtr hClientHandle, IntPtr pReserved, ref IntPtr ppInterfaceList);

            /// <summary>
            /// Frees memory returned by native WiFi functions
            /// </summary>
            [DllImport("wlanapi.dll", SetLastError = true)]
            private static extern void WlanFreeMemory(IntPtr pmemory);

            /// <summary>
            /// Interface state enums
            /// </summary>
            public enum WLAN_INTERFACE_STATE : int
            {
                wlan_interface_state_not_ready = 0,
                wlan_interface_state_connected,
                wlan_interface_state_ad_hoc_network_formed,
                wlan_interface_state_disconnecting,
                wlan_interface_state_disconnected,
                wlan_interface_state_associating,
                wlan_interface_state_discovering,
                wlan_interface_state_authenticating
            };

            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct WLAN_INTERFACE_INFO
            {
                /// GUID->_GUID
                public Guid InterfaceGuid;

                /// WCHAR[256]
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
                public string strInterfaceDescription;

                /// WLAN_INTERFACE_STATE->_WLAN_INTERFACE_STATE
                public WLAN_INTERFACE_STATE isState;
            }
            /// <summary>
            /// This structure contains an array of NIC information
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct WLAN_INTERFACE_INFO_LIST
            {
                public Int32 dwNumberofItems;
                public Int32 dwIndex;
                public WLAN_INTERFACE_INFO[] InterfaceInfo;

                public WLAN_INTERFACE_INFO_LIST(IntPtr pList)
                {
                    // The first 4 bytes are the number of WLAN_INTERFACE_INFO structures.
                    dwNumberofItems = Marshal.ReadInt32(pList, 0);

                    // The next 4 bytes are the index of the current item in the unmanaged API.
                    dwIndex = Marshal.ReadInt32(pList, 4);

                    // Construct the array of WLAN_INTERFACE_INFO structures.
                    InterfaceInfo = new WLAN_INTERFACE_INFO[dwNumberofItems];

                    for (int i = 0; i < dwNumberofItems; i++)
                    {
                        // The offset of the array of structures is 8 bytes past the beginning. Then, take the index and multiply it by the number of bytes in the structure.
                        // the length of the WLAN_INTERFACE_INFO structure is 532 bytes - this was determined by doing a sizeof(WLAN_INTERFACE_INFO) in an unmanaged C++ app.
                        IntPtr pItemList = new IntPtr(pList.ToInt32() + (i * 532) + 8);

                        // Construct the WLAN_INTERFACE_INFO structure, marshal the unmanaged structure into it, then copy it to the array of structures.
                        WLAN_INTERFACE_INFO wii = new WLAN_INTERFACE_INFO();
                        wii = (WLAN_INTERFACE_INFO)Marshal.PtrToStructure(pItemList, typeof(WLAN_INTERFACE_INFO));
                        InterfaceInfo[i] = wii;
                    }
                }
            }

            #endregion

            #region Private Functions
            /// <summary>
            ///get NIC state  
            /// </summary>
            private string getStateDescription(WLAN_INTERFACE_STATE state)
            {
                string stateDescription = string.Empty;
                switch (state)
                {
                    case WLAN_INTERFACE_STATE.wlan_interface_state_not_ready:
                        stateDescription = "not ready to operate";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_connected:
                        stateDescription = "connected";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_ad_hoc_network_formed:
                        stateDescription = "first node in an adhoc network";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_disconnecting:
                        stateDescription = "disconnecting";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_disconnected:
                        stateDescription = "disconnected";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_associating:
                        stateDescription = "associating";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_discovering:
                        stateDescription = "discovering";
                        break;
                    case WLAN_INTERFACE_STATE.wlan_interface_state_authenticating:
                        stateDescription = "authenticating";
                        break;
                }

                return stateDescription;
            }
            #endregion

            #region Public Functions

            /// <summary>
            /// enumerate wireless network adapters using wifi api
            /// </summary>
            public string[] EnumerateNICs()
            {
                List<string> nics = new List<string>();
                uint serviceVersion = 0;
                IntPtr handle = IntPtr.Zero;
                if (WlanOpenHandle(2, IntPtr.Zero, out serviceVersion, ref handle) == ERROR_SUCCESS)
                {
                    IntPtr ppInterfaceList = IntPtr.Zero;
                    WLAN_INTERFACE_INFO_LIST interfaceList;

                    if (WlanEnumInterfaces(handle, IntPtr.Zero, ref ppInterfaceList) == ERROR_SUCCESS)
                    {
                        //Tranfer all values from IntPtr to WLAN_INTERFACE_INFO_LIST structure 
                        interfaceList = new WLAN_INTERFACE_INFO_LIST(ppInterfaceList);

                        //Console.WriteLine("Enumerating Wireless Network Adapters...");
                        for (int i = 0; i < interfaceList.dwNumberofItems; i++)
                            nics.Add(interfaceList.InterfaceInfo[i].strInterfaceDescription);
                        //Console.WriteLine("{0}-->{1}", interfaceList.InterfaceInfo[i].strInterfaceDescription, getStateDescription(interfaceList.InterfaceInfo[i].isState));

                        //frees memory
                        if (ppInterfaceList != IntPtr.Zero)
                            WlanFreeMemory(ppInterfaceList);
                    }
                    //close handle
                    WlanCloseHandle(handle, IntPtr.Zero);
                }

                return nics.ToArray();
            }
            #endregion
        }
    }

}
