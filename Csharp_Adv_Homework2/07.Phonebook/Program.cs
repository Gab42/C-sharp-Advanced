using System;
using System.Collections.Generic;

namespace _07.Phonebook
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter new phonebook entries in the form of \"Name-Number\".");
            Console.WriteLine("Use \"search\" followed by a name to find a contact's number.");
            Console.WriteLine();
          
            var phonebook = new List<List<string>>();
            var entry = new List<string>();
            string input = "";
            var digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            while (input != "search")
            {
                input = Console.ReadLine();

                if (input.Equals("search"))
                {
                    break;
                }
                else
                {
                    if (input.Split('-').Length == 2)
                    {
                        string name = (input.Split('-')[0]).TrimEnd(digits);
                        string number = input.Split('-')[1];
                        bool check = false;
                        bool numCheck = false;

                        for (int i = 0; i < phonebook.Count; i++)
                        {
                            if (phonebook[i][0] == name )
                            {
                                check = true;
                                for (int j = 1; j < phonebook[i].Count; j++)
                                {
                                    if (phonebook[i][j] == number)
                                    {
                                        numCheck = true;
                                    }
                                }
                                if (!numCheck)
                                {
                                    phonebook[i].Add(number);
                                }
                                else
                                {
                                    Console.WriteLine("This number already exists for this person.");
                                }
                            }
                        }
                            if (!check)
                        {
                            entry.Add(name);
                            entry.Add(number);
                            phonebook.Add(entry);
                        }                           
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter new entries in the form of Name-Number");
                    }            
                }              
            }

            while(true)
            {
                bool check = false;
                input = Console.ReadLine();
                for (int i = 0; i < phonebook.Count; i++)
                {
                    if (phonebook[i][0] == input)
                    {
                        check = true;
                        Console.Write(input);

                        for (int j = 1; j < phonebook[i].Count; j++)
                        {
                            Console.WriteLine(" -> " + phonebook[i][j]);
                        }
                    }                   
                }

                if (!check)
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }
            }
        }
    }
}
