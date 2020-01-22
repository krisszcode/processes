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
               
                
                
                
                    data.GenerateProcesses();
                   
                    ui.PrintOutProcesses(data.ListOfProcesses);
                    ui.AskForId(data.ListOfProcesses);
                    data.Save();
                    
                    
               


            }


        }
    }                   
}
            

 

