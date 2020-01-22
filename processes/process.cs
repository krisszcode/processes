using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

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

        public double CpuUsage { get; set; }
        public int Threads { get; set; }
        public string? Comment { get; set; }


        public Proces() { }

        public Proces(string processName = "No Name",
            int processId = 0,
            double memoryUsage = 0,
            string runningTime = "Nope",
            DateTime startTime = default(DateTime),
            double cpuUsage = 0,
            int threads = 0,
            string? comment = null
            )
        {
            ProcessName = processName;
            ProcessId = processId;
            MemoryUsage = memoryUsage;
            RunningTime = runningTime;
            StartTime = startTime;
            CpuUsage = cpuUsage;
            Threads = threads;
            Comment = comment;
        }

        public override string ToString()
        {
            return string.Format($"{ProcessName} {ProcessId} {MemoryUsage} {RunningTime} {StartTime} {CpuUsage} {Threads} {Comment}");
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Processname", ProcessName);
            info.AddValue("ProcessID", ProcessId);
            info.AddValue("Memoryusage", MemoryUsage);
            info.AddValue("Runningtime", RunningTime);
            info.AddValue("Starttime", StartTime);
            info.AddValue("CpuUsage", CpuUsage);
            info.AddValue("Threads", Threads);
            info.AddValue("Comment", Comment);


        }

        public Proces(SerializationInfo info, StreamingContext context)
        {
            ProcessName = (string)info.GetValue("Processname", typeof(string));
            ProcessId = (int)info.GetValue("ProcessID", typeof(int));
            MemoryUsage = (double)info.GetValue("Memoryusage", typeof(double));
            RunningTime = (string)info.GetValue("Runningtime", typeof(string));
            StartTime = (DateTime)info.GetValue("Starttime", typeof(DateTime));
            CpuUsage = (double)info.GetValue("Cpuusage", typeof(double));
            Threads = (int)info.GetValue("Threads", typeof(int));
            Comment = (string)info.GetValue("Comment", typeof(string));

        }
    }
}
