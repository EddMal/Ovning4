using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal class CheckUsersParantheses:UIUserInterface
    {
        private String inputWithParantheses;

        private String InputWithParantheses
        {
            get => inputWithParantheses;
            set => inputWithParantheses = value ?? throw new ArgumentException($"Null is not a valid string input.");
        }

        public CheckUsersParantheses(Func<string> InputMethod)
        {
            bool valid = false;
            string input;
            do
            {
                
                input = InputMethod();
                //Lambda, tried out need more info to make swifter.
                valid = true ? input != null: false ;
                if (!valid)
                {
                    SendOutput("String consist of faulty input, try again:");
                }

            } while (!valid);
            InputWithParantheses = input;
        }

        internal void CompareParanteses()
        {


            Stack<char> rightFacingParantheses = new Stack<char>();
            Stack<char> leftFacingParantheses = new Stack<char>();
            //Queue<char> leftFacingParantheses = new Queue<char>();

            IEnumerable<char> listRightFacingP = new List<char>();
            IEnumerable<char> listLeftFacingP = new List<char>();


            PushParantheses(rightFacingParantheses, '(', '{', '[');
            PushParantheses(leftFacingParantheses, ')', '}', ']');
            //QueueParantheses(leftFacingParantheses, ')', '}', ']');

            // New error.
            listRightFacingP = PopParantheses(rightFacingParantheses);
            listLeftFacingP = PopParantheses(leftFacingParantheses);
            IEnumerable<char> reversedLeft = listLeftFacingP.Reverse();

            bool valid = MatchParantheses(listRightFacingP, reversedLeft);

             if (valid)
                 SendOutput("Parantheses did match.");
             else
                 SendOutput("Parantheses did not match.");
        }


        private bool MatchParantheses(IEnumerable<char> listRightFacingP, IEnumerable<char> listLeftFacingP) 
        {
            bool valid = true;
            while (valid)
            { 
                foreach (char cr in listRightFacingP)
                {
                    foreach (char cl in listLeftFacingP)
                    {
                        if ((cr is '(' && cl == ')') || (cr is '[' && cl is ']') || (cr is '{' && cl is '}'))
                            valid = true;
                        else
                            valid = false;
                    }
                }
            }
            return valid;
            
        }

        //To manu parameters should be replaced with lambda perhaps.
        internal void PushParantheses (Stack<char> stack, char one, char two, char three)
        {
            foreach (char item in InputWithParantheses)
            {
                char parantheses = item;

                if (item == one || item == two || item == three)
                    stack.Push(parantheses);

            }
        }

        //internal void QueueParantheses(Queue<char> queue, char one, char two, char three)
        //{
        //    foreach (char item in InputWithParantheses)
        //    {
        //        char parantheses = item;

        //        if (item == one || item == two || item == three)
        //            queue.Enqueue(parantheses);

        //    }
        //}

        internal IEnumerable<char> PopParantheses(Stack<char> stack)
        {
            if (stack.Count > 0)
            {
                
                int count = stack.Count;
                SendOutput("\nThe Stack:");
                foreach (var item in stack)
                {
                
                   yield return item;
                    count--;
                }
            }

        }
    }
}
