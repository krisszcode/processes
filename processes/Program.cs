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
            UserInterface ui = new UserInterface();
            DataManager data = new DataManager();

            while (true)
            {
                if (File.Exists(@"C:\Users\Fsociety\Desktop\process\processes\pos.xml"))
                {
                    data.Load();
                    ui.PrintOutProcesses();
                    ui.AskForId();
                    Console.Clear();
                }
                else
                {
                    data.GenerateProcesses();
                    foreach (var item in data.ListOfProcesses)
                    {
                        Console.WriteLine("1");
                        Console.WriteLine(item);
                    }
                    data.Save();
                    data.Load();
                    ui.PrintOutProcesses();
                    ui.AskForId();
                    Console.Clear();
                }



            }


        }
    }                   
}
            

 

