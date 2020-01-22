using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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

      

        public void AskForId(List<Proces> ListOfProcesses)
        {
            TimeSpan ts = new TimeSpan(0, 0, 2);

            Console.WriteLine("Do you want to add a comment to a process?[yes/no]: ");
            string userdecide = Console.ReadLine();
            
                if (userdecide == "yes" || userdecide == "Yes")
                {

                    Console.WriteLine("If you want to a process please give me an ID from the list: ");
                    int userinput = Convert.ToInt32(Console.ReadLine());
                    foreach (Proces process in ListOfProcesses)
                    {
                        
                            if (process.ProcessId == userinput)
                            {
                                Console.WriteLine("Please enter a comment: ");
                                string userinputcomment = Console.ReadLine();
                                process.Comment = userinputcomment;
                                data.CommentedList.Add(process);
                                Console.WriteLine("Comment added!");

                                Thread.Sleep(ts);
                                
                               }
                   
                    }
                      

                }

                else if (userdecide == "no" || userdecide == "No")
                {
                    Console.WriteLine("Closing program...");
                    Environment.Exit(0);
                }

            }
          
        }
    }

