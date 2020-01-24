using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace processes
{
    class UserInterface
    {
       
        DataManager data = new DataManager();

       public void PrintOutProcesses(List<Proces> ListOfProcesses)
        {
            foreach (Proces proc in ListOfProcesses)
            {
                Console.WriteLine(proc.ToString());
            }

        }

        void KillProcess(string name) 
        {
            Process[] processlist = Process.GetProcesses();
            foreach (var proc in Process.GetProcessesByName(name))
            {
                if (name == proc.ProcessName)
                {
                    proc.Kill();
                    
                }
               
            }
        }

        public Proces AskForId(List<Proces> ListOfProcesses)
        {
            Console.WriteLine("Do you want to add a comment or kill process? \n1. Add\n2. Kill\n3. Quit\nYour choice: ");
            string userdecided = Console.ReadLine();

            if (userdecided == "Add" || userdecided == "add" || userdecided == "ADD")
            {
                TimeSpan ts = new TimeSpan(0, 0, 2);

                Console.WriteLine("Do you want to add a comment to a process?[yes/no]: ");
                string userdecide = Console.ReadLine();

                if (userdecide == "yes" || userdecide == "Yes")
                {

                    Console.WriteLine("If you want to comment a process please give me an ID from the list: ");
                    int userinput = Convert.ToInt32(Console.ReadLine());
                    foreach (Proces process in ListOfProcesses)
                    {

                        if (process.ProcessId == userinput)
                        {
                            Console.WriteLine("Please enter a comment: ");
                            string userinputcomment = Console.ReadLine();
                            process.Comment = userinputcomment;


                            Console.WriteLine("Comment added!");

                            Thread.Sleep(ts);
                            return process;
                        }



                    }


                }

                else if (userdecide == "no" || userdecide == "No")
                {
                    Console.WriteLine("Closing program...");


                    Environment.Exit(0);
                }
            }
            else if(userdecided == "kill" || userdecided == "Kill" || userdecided == "KILL")
            {
                Console.WriteLine("If you want to kill a process please give me a name from the list: ");
                try
                {
                    string userinput = Console.ReadLine();
                    KillProcess(userinput);
                }
                catch (Exception)
                {
                    Console.WriteLine("You cant kill this process");
                   
                }
                
            }
            else if (userdecided == "Quit" || userdecided == "quit" || userdecided == "QUIT")
            {
                Console.WriteLine("Closing program...");
                Environment.Exit(0);
            }
            
            

            throw new Exception("Wrong input!");
        }
          
        }
    }

