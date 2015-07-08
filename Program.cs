using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NFA2DFA
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            LinkedList<string> states = new LinkedList<string>();
            LinkedList<string> finalStates = new LinkedList<string>();
            LinkedList<string> alphabets = new LinkedList<string>();
            LinkedList<LinkedList<string>> NFA_Table = new LinkedList<LinkedList<string>>();
            states = createStates();
            finalStates = setFinals();
            alphabets = createAlphabets();
            NFA_Table = createNFATable();
            NFA_Print(states, finalStates, alphabets, NFA_Table);
            **/
            string str = "abcdefg";
            string[] ar = new string[100];
            ar = str.Split();
            Console.WriteLine(ar.ElementAt(4));
            
        }
        static LinkedList<string> createStates()
        {
            int num;
            LinkedList<string> states = new LinkedList<string>();
            Console.Write("Enter Number Of States:");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write("States = { ");
            for (int i = 0; i < num; i++)
            {
                states.AddLast(Convert.ToString(i));
                Console.Write(Convert.ToString(i)+" ");
            }
            Console.WriteLine("} And Start State = 0\n");
            Console.WriteLine();
            return states;
            
        }
        static LinkedList<string> setFinals()
        {
            Console.WriteLine("Set Final States(Enter 'exit' To Exit):");
            LinkedList<string> finalStates = new LinkedList<string>();
            string input = "";
            while (input.CompareTo("exit") != 0)
            {
                input = Console.ReadLine();
                if(input.CompareTo("exit") != 0){
                    finalStates.AddLast(input);
                }
            }
            Console.Write("Final States = { ");
            for (int i = 0; i < finalStates.Count; i++)
            {
                Console.Write(finalStates.ElementAt(i) + " ");
            }
            Console.WriteLine("}\n");
            return finalStates;
        }
        static LinkedList<string> createAlphabets()
        {
            Console.WriteLine("Set Alphabets(Enter 'exit' To Exit):");
            LinkedList<string> alphabets = new LinkedList<string>();
            string input = "";
            while (input.CompareTo("exit") != 0)
            {
                input = Console.ReadLine();
                if (input.CompareTo("exit") != 0)
                {
                    alphabets.AddLast(input);
                }
            }
            Console.Write("Alphabets = { ");
            for (int i = 0; i < alphabets.Count; i++)
            {
                Console.Write(alphabets.ElementAt(i) + " ");
            }
            Console.WriteLine("}\n");
            return alphabets;
        }
        static LinkedList<LinkedList<string>> createNFATable()
        {
            LinkedList<LinkedList<string>> NFATable = new LinkedList<LinkedList<string>>();
            
            Console.WriteLine("Set Contacts");
            string input = "";
            while (input.CompareTo("exit") != 0)
            {
                LinkedList<string> contacts = new LinkedList<string>();
                Console.Write("From State:");
                input = Console.ReadLine();
                contacts.AddLast(input);

                Console.Write("To State:");
                input = Console.ReadLine();
                contacts.AddLast(input);

                Console.Write("With Alphabet:");
                input = Console.ReadLine();
                contacts.AddLast(input);


                NFATable.AddLast(contacts);
            
                
                Console.WriteLine("For Exit Enter 'exit' Or Continue...");
                input = Console.ReadLine();
                
            }
            return NFATable;

        }
        static void NFA_Print(LinkedList<string> states,LinkedList<string> finalStates,LinkedList<string> alphabets,LinkedList<LinkedList<string>> NFA_Table){
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.Write("States = { ");
            for (int i = 0; i < states.Count; i++)
            {
                Console.Write(states.ElementAt(i) + " ");
            }
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("Start State = { 0 }");
            Console.WriteLine();
            Console.Write("Final States = { ");
            for (int i = 0; i < finalStates.Count; i++)
            {
                Console.Write(finalStates.ElementAt(i) + " ");
            }
            Console.WriteLine("}");
            Console.WriteLine();
            Console.Write("Alphabets = { ");
            for (int i = 0; i < alphabets.Count; i++)
            {
                Console.Write(alphabets.ElementAt(i) + " ");
            }
            Console.WriteLine("}");
            Console.WriteLine();
            Console.WriteLine("Contact Table");
            for (int i = 0; i < NFA_Table.Count; i++)
            {
                Console.WriteLine(NFA_Table.ElementAt(i).ElementAt(0) + "\t" + NFA_Table.ElementAt(i).ElementAt(1) + "\t" + NFA_Table.ElementAt(i).ElementAt(2));
            }
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
        }
        static LinkedList<LinkedList<string>> convertToDFA(LinkedList<LinkedList<string>> NFA_Table, LinkedList<string> states, LinkedList<string> finalStates, LinkedList<string> alphabets)
        {

            LinkedList<LinkedList<string>> DFA_Table = new LinkedList<LinkedList<string>>();
            LinkedList<string> DFA_States = new LinkedList<string>();
            string newState="";
            DFA_States.AddLast("0");
            for (int i = 0; i < DFA_States.Count; i++)
            {
                for (int j = 0; j < alphabets.Count; j++)
                {
                    for (int k = 0; k < NFA_Table.Count; k++)
                    {
                        if (NFA_Table.ElementAt(k).ElementAt(0).CompareTo(DFA_States.ElementAt(i)) == 0 && NFA_Table.ElementAt(k).ElementAt(2).CompareTo(alphabets.ElementAt(j)) == 0)
                        {
                            newState += NFA_Table.ElementAt(i).ElementAt(1);
                        }
                    }
                    if (DFA_States.Contains(newState) == false)
                    {
                        DFA_States.AddLast(newState);
                        LinkedList<string> DFA_Contacts = new LinkedList<string>();
                        DFA_Contacts.AddLast(DFA_States.ElementAt(i));
                        DFA_Contacts.AddLast(newState);
                        DFA_Contacts.AddLast(alphabets.ElementAt(j));
                        DFA_Table.AddLast(DFA_Contacts);
                        
                    }
                    newState = "";
                }
            }

            return DFA_Table;
        }
        
    }
}
