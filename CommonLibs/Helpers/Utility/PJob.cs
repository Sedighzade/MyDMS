using PNB.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;

namespace PNB.Helpers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class JobManager
    {
        Timer t;
        List<PTask> tasks = new List<PTask>();
        //public List<PTask> Tasks { get { return tasks; } }

        /// <summary>
        /// Interval in milliseconds
        /// </summary>
        /// <param name="interval"></param>
        public JobManager(int interval)
        {
            t = new Timer(interval);
            t.Elapsed += T_Elapsed;
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            long ticks = DateTime.Now.Ticks;

            lock (tasks)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    TimeSpan ts = TimeSpan.FromTicks(ticks - tasks[i].StartTime);
                    if (ts.TotalMilliseconds > tasks[i].StartupDelay)
                        if (TimeSpan.FromTicks(ticks - tasks[i].LastCheckTicks).TotalMilliseconds > tasks[i].Interval)
                        {
                            //Logger.Debug(tasks[i].Name);
                            if (tasks[i].ExecuteInSeperateThread)
                            {
                                //Logger.Debug(tasks[i].Name+" executed in seperate thread");
                                System.Threading.ThreadPool.QueueUserWorkItem(tasks[i].WC, tasks[i].State);
                            }
                            else
                            {
                                //Logger.Debug(tasks[i].Name+ " executed!");
                                System.Threading.WaitCallback wc = tasks[i].WC;
                                //wc.Invoke(tasks[i].State);
                                tasks[i].WC.Invoke(tasks[i].State);
                            }
                            tasks[i].LastCheckTicks = ticks;
                        }
                    //else
                    //    Logger.Debug("tasks[i].Interval=" + tasks[i].Interval);
                    //else
                    //    Logger.Debug("ts.TotalMilliseconds = " + ts.TotalMilliseconds.ToString());
                }
            }
        }

        public void Start()
        {
            Logger.Debug("JobManager started...");
            t.Start();

        }
        public void Stop()
        {
            t.Stop();
            Logger.Debug("JobManager stopped...");
        }

        public void Register(PTask task)
        {
            if (task == null) return;

            lock (tasks)
            {
                task.StartTime = DateTime.Now.Ticks;
                tasks.Add(task);
            }
            Logger.Debug("'" + task.Name + "' registered! Number of Active Tasks: " + tasks.Count);

        }
        public void UnRegister(PTask task)
        {
            if (task == null) return;

            lock (tasks)
            {
                PTask job = tasks.Find(x => x == task);
                tasks.Remove(job);
            }
            Logger.Debug("'" + task.Name + "' unregistered! Number of Active Tasks: " + tasks.Count);
        }
        public override string ToString()
        {
            return "Job Manager";
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PTask : IDName
    {
        public System.Threading.WaitCallback WC;
        public PTask(string taskName, int interval)
        {
            Interval = interval;
            Name = taskName;
            StartupDelay = 0;
        }
        public bool StartupDelayPassed { set; get; }
        public long StartTime { set; get; }
        /// <summary>
        /// millisecond
        /// </summary>
        public int StartupDelay { set; get; }
        public bool ExecuteInSeperateThread { set; get; }
        public object State { set; get; }
        public long LastCheckTicks { set; get; }
        public int Interval { set; get; }
    }
}
