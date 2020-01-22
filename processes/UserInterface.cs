using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace processes
{
    class UserInterface
    {
        DataManager data = new DataManager();
       public void PrintOutProcesses()
        {
            foreach (Proces a in data.ListOfProcesses)
            {
                Console.WriteLine(a.ToString());
            }

        }

        public void AddComment(int ID, string comment)
        {
            foreach (Proces process in data.ListOfProcesses)
            {
                if (ID == process.ProcessId)
                {
                    process.Comment = comment;
                }
            }

        }

        public void AskForId()
        {
            Console.WriteLine("Do you want to add a comment to a process?[yes/no]: ");
            string userdecide = Console.ReadLine();

            if (userdecide == "yes" || userdecide == "Yes")
            {
                Console.WriteLine("If you want to a process please give me an ID from the list: ");
                int userinput = Convert.ToInt32(Console.ReadLine());
                foreach (Proces process in data.ListOfProcesses)
                {
                    if (process.ProcessId == userinput)
                    {
                        Console.WriteLine("Please enter a comment: ");
                        string userinputcomment = Console.ReadLine();
                        AddComment(userinput, userinputcomment);
                        Console.WriteLine("Comment added!");
                        TimeSpan ts = new TimeSpan(0, 0, 5);

                        Thread.Sleep(ts);
                        data.Save();
                    }
                    Console.WriteLine("There is no such process with that ID! Try again.");
                }
            }
            else if(userdecide == "no" || userdecide == "No")
            {
                Console.WriteLine("Closing program...");
                Environment.Exit(0);
            }
            else
            {
                throw new Exception("Wrong input");
            }
            


        }

    }
}
