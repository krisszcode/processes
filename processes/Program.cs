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
            if (File.Exists(@"C:\Users\Fsociety\Desktop\processes\processes\CommentedProcesses.xml"))
            {
                data.Load();
                data.GenerateProcesses();
                while (true)
                {

                    ui.PrintOutProcesses(data.ListOfProcesses);
                    data.CommentedList.Add(ui.AskForId(data.ListOfProcesses));

                    data.Save(data.CommentedList);

                }
            }
            else
            {
                data.GenerateProcesses();
                while (true)
                {

                    ui.PrintOutProcesses(data.ListOfProcesses);
                    data.CommentedList.Add(ui.AskForId(data.ListOfProcesses));

                    data.Save(data.CommentedList);

                }
            }
            


        }
    }                   
}
            

 

