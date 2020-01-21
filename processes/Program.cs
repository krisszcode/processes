using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace processes
{
    class Program
    {
        static void Main()
        {

            Process[] processlist = Process.GetProcesses();
            List<Proces> ListOfProcesses = new List<Proces>();
            DateTime now = DateTime.Now;


            async Task<double> GetCpuUsageForProcess(Process theprocess)
            {
                var startTime = DateTime.UtcNow;
                var startCpuUsage = theprocess.TotalProcessorTime;

                await Task.Delay(150);

                var endTime = DateTime.UtcNow;
                var endCpuUsage = theprocess.TotalProcessorTime;

                var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
                var totalMsPassed = (endTime - startTime).TotalMilliseconds;

                var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);

                return cpuUsageTotal * 100;
            }
            


            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Length > 0)
                {
                    try
                    {
                        
                        var result = GetCpuUsageForProcess(theprocess);
                        double CpuUsage = Math.Round(result.Result, 2);

                        DateTime StartTime = theprocess.StartTime;
                        DateTime EndTime = now;
                        long diffTicks = (EndTime - StartTime).Ticks;

                        TimeSpan t = TimeSpan.FromSeconds(diffTicks);

                        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds,
                                        t.Milliseconds);
                        ListOfProcesses.Add(new Proces(theprocess.ProcessName, theprocess.Id, theprocess.WorkingSet64 / 1024f / 1024f, answer, theprocess.StartTime, CpuUsage, theprocess.Threads.Count));
                       // Console.WriteLine("Process Name: {0} ID: {1} Memory: {2} MB  Start time: {3} Running time: {4} CPU Usage: {5}",
                          //  theprocess.ProcessName, theprocess.Id, (theprocess.WorkingSet64 / 1024f / 1024f), theprocess.StartTime, answer, CpuUsage, theprocess.Threads.Count);

                        

                    }
                    catch (Exception)
                    {

                        
                    }

                    using (Stream fs = new FileStream(@"C:\C#\processes\processes\pros.xml", FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<Proces>));
                        serializer.Serialize(fs, ListOfProcesses);
                    }

                    ListOfProcesses = null;

                    XmlSerializer serializer2 = new XmlSerializer(typeof(List<Proces>));

                    using (FileStream fs2 = File.OpenRead(@"C:\C#\processes\processes\pros.xml"))
                    {
                        ListOfProcesses = (List<Proces>)serializer2.Deserialize(fs2);
                    }

                    foreach (Proces a in ListOfProcesses)
                    {
                        Console.WriteLine(a.ToString());
                    } 



                }
              

        }
            
    }
            

     }


    }

