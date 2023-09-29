using System;
using System.Diagnostics;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            List<string> theList = new List<string>();
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList(theList);
                        break;
                    case '2':
                        ExamineQueue(queue);
                        break;
                    case '3':
                        ExamineStack(stack);
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList(List<string> theList)
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);
            //switch(nav){...}
            var Do = new ExamineUserList();
            theList = Do.AddOrRemove(theList);

            //--------------------
            // Övning 1: Frågor 2-6
            //--------------------
            
            // Fråga 2. När en member läggs till så sätts den till default kapacitet (4)
            // när en femte member läggs till ökar kapaiteten ned 4 (till 8).
            
            // Fråga 3. && Fråga 4. Anledningen till ökningen att när listans kapacitet överskrids duplicers storleken genom:
            // int newcapacity = _items.Length == 0 ? DefaultCapacity : 2 * _items.Length;
            
            // Fråga 5. Nej.

            // Fråga 6. Exempelvis när du vill ha större kontroll över utrymme som används.

      }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue(Queue<string> queue)
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            var Do = new ExamineUserQueue();
            queue = Do.EnqueueOrDequeue(queue);

            
        }

       

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack(Stack<string> stack)
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            //--------------------
            // Övning 3: Fråga 1
            //--------------------
            // Svar: Flödet för stacken hindrar att plocka ut i annan ordning än sista datan som stoppades in,
            // om vi då stoppar in kalle sedan greta och ska plocka ut kalle måste vi först plocka ut greta.

            var Do = new ExamineUserStack();
            stack = Do.PushOrPop(stack);

            // ändra i stackutskrift i slutet om reversed har kört så skrivs "Stack: " ut kanske även vid direkt "q"? kolla även för queue.
            //kontrolera ordningsnummer för stack /queue.
        }

        static void CheckParanthesis()
        {
            //ckeck if examine queue prints the leaving member.
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

        }

    }
}

