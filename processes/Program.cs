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

            async Task<double> GetCpuUsageForProcess()
            {
                var startTime = DateTime.UtcNow;
                var startCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;

                await Task.Delay(0);

                var endTime = DateTime.UtcNow;
                var endCpuUsage = Process.GetCurrentProcess().TotalProcessorTime;

                var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
                var totalMsPassed = (endTime - startTime).TotalMilliseconds;

                var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);

                return cpuUsageTotal * 100;
            }
            
            var result = GetCpuUsageForProcess();
            double CpuUsage = Math.Round(result.Result, 2);

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Length > 0)
                {
                    try
                    {
                       
                        
                        DateTime StartTime = theprocess.StartTime;
                        DateTime EndTime = now;
                        long diffTicks = (EndTime - StartTime).Ticks;

                        TimeSpan t = TimeSpan.FromSeconds(diffTicks);

                        string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                        t.Hours,
                                        t.Minutes,
                                        t.Seconds,
                                        t.Milliseconds);
                        ListOfProcesses.Add(new Proces(theprocess.ProcessName, theprocess.Id, theprocess.WorkingSet64 / 1024f / 1024f, answer, theprocess.StartTime, CpuUsage));
//                        Console.WriteLine("Process Name: {0} ID: {1} Memory: {2} MB  Start time: {3} Running time: {4}",
//                            theprocess.ProcessName, theprocess.Id, (theprocess.WorkingSet64 / 1024f / 1024f), theprocess.StartTime, answer);

                        

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

