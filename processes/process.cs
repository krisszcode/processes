using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace processes
{
    [Serializable()]
    public class Proces
    {
        public string ProcessName { get; set; }
        public int ProcessId { get; set; }
        public double MemoryUsage { get; set; }
        public string RunningTime { get; set; }
        public DateTime StartTime { get; set; }


        public Proces() { }

        public Proces(string processName = "No Name",
            int processId = 0,
            double memoryUsage = 0,
            string runningTime = "Nope",
            DateTime startTime = default(DateTime)
            )
        {
            ProcessName = processName;
            ProcessId = processId;
            MemoryUsage = memoryUsage;
            RunningTime = runningTime;
            StartTime = startTime;
        }

        public override string ToString()
        {
            return string.Format($"{ProcessName} {ProcessId} {MemoryUsage} {RunningTime} {StartTime}");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Processname", ProcessName);
            info.AddValue("ProcessID", ProcessId);
            info.AddValue("Memoryusage", MemoryUsage);
            info.AddValue("Runningtime", RunningTime);
            info.AddValue("Starttime", StartTime);

        }

        public Proces(SerializationInfo info, StreamingContext context)
        {
            ProcessName = (string)info.GetValue("Processname", typeof(string));
            ProcessId = (int)info.GetValue("ProcessID", typeof(int));
            MemoryUsage = (double)info.GetValue("Memoryusage", typeof(double));
            RunningTime = (string)info.GetValue("Runningtime", typeof(string));
            StartTime = (DateTime)info.GetValue("Starttime", typeof(DateTime));
        }
    }
}
