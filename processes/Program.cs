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
                Console.WriteLine("Welcome to Budget Task Manager Alpha version. \n\n Your options are: View processes, add comment to them(saved to an xml file later), and kill processes. \n We know it ain't much but it is honest work.\n\n");
                
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
                Console.WriteLine("Welcome to Budget Task Manager Alpha version. \n\n Your options are: View processes, add comment to them(saved to an xml file later), and kill processes. \n We know it ain't much but it is honest work.\n\n");
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
            

 

