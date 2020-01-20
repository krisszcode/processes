//almassdadad
using System;
using System.Diagnostics;

namespace processes
{
    class Program
    {
        static void Main()
        {

            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.Length > 0)
                {
                    DateTime now = DateTime.Now;

                    DateTime StartTime = theprocess.StartTime;
                    DateTime EndTime = now;
                    long diffTicks = (EndTime - StartTime).Ticks;

                    TimeSpan t = TimeSpan.FromSeconds(diffTicks);

                    string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);
                    Console.WriteLine(answer);
                    Console.WriteLine("Process Name: {0} ID: {1} Memory: {2} MB  Start time: {3} Running time: {4}",
                        theprocess.ProcessName, theprocess.Id, (theprocess.WorkingSet64 / 1024f / 1024f), theprocess.StartTime, answer);



                }

            }


        }


    }
}
