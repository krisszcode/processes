﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace processes
{
    class DataManager
    {
        Process[] processlist = Process.GetProcesses();

        public List<Proces> ListOfProcesses = new List<Proces>();
       
        public List<Proces> CommentedList = new List<Proces>();


        public void Save(List<Proces> CommentedList)
        {
            using (Stream fs = new FileStream(@"C:\Users\Fsociety\Desktop\processes\processes\CommentedProcesses.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Proces>));
                serializer.Serialize(fs, CommentedList);
            }
            
        }


        public void Load()
        {
            XmlSerializer serializer2 = new XmlSerializer(typeof(List<Proces>));

            using(FileStream fs2 = File.OpenRead(@"C:\Users\Fsociety\Desktop\processes\processes\CommentedProcesses.xml"))
            {
                CommentedList = (List<Proces>)serializer2.Deserialize(fs2);
            }
        }
      



        public List<Proces> GenerateProcesses()
        {
            Console.WriteLine("Generating running processes, please wait...\n");
            Console.WriteLine("It will take some time unfortunately, so while generating, here is a coding interview question to solve on a paper: " +
                    "\nGiven a string containing just the characters '(' and ')',\n" +
                    "find the length of the longest valid (well-formed) parentheses substring.\n\n" +
                    "Input: (()\nOutput: 2 \nExplanation: The longest valid parentheses substring is () " +
                    "\n\nYou can use Python3,C#,Java to solve it.");


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
            
            DateTime now = DateTime.Now;

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


                    }
                    catch (Exception)
                    {

                    }

                }
            }
            Console.WriteLine("\nGenerating done!");
            TimeSpan ts = new TimeSpan(0, 0, 4);
            Thread.Sleep(ts);
            return ListOfProcesses;
        }

        
    }
}


