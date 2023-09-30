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

        internal void CheckUsersInput(Func<string> InputMethod)
        {
            bool valid = false;
            string input;
            do
            {
                
                
                
                input = InputMethod();
                //Lambda, tried out need more info to make swifter.
                //var isValid = false ? input is "" or null : true;
                //valid = isValid
                if(input is not "" or not null)
                    valid = true;
                if (!valid)
                {
                    SendOutput("String consist of faulty input, try again:");
                }

            } while (!valid);
            InputWithParantheses = input;
        }

        internal void CompareParanteses(Func<string> InputMethod)
        {
            SendOutput("Parantheses checker, input your line to se if parantheses adds up:");

            CheckUsersInput(InputMethod);
            Stack<char> rightFacingParantheses = new Stack<char>();
            Stack<char> leftFacingParantheses = new Stack<char>();
            //Queue<char> leftFacingParantheses = new Queue<char>();

            List<char> listRightFacingP = new List<char>();
            List<char> listLeftFacingP = new List<char>();


            PushParantheses(rightFacingParantheses, '(', '{', '[');
            PushParantheses(leftFacingParantheses, ')', '}', ']');
            //QueueParantheses(leftFacingParantheses, ')', '}', ']');

            // New error.
            listRightFacingP = PopParantheses(rightFacingParantheses);
            listLeftFacingP = PopParantheses(leftFacingParantheses);
            listLeftFacingP.Reverse();

            bool valid = MatchParantheses(listRightFacingP, listLeftFacingP);

             if (valid ==true)
                 SendOutput("Parantheses did match.");
             else
                 SendOutput("Parantheses did not match.");
        }


        private bool MatchParantheses(List<char> listRightFacingP, List<char> listLeftFacingP) 
        {
            bool valid = true;

            foreach (var (chr, chr2) in listRightFacingP.Zip(listLeftFacingP))
            {
                // Rewrite invert condition.
                if ((chr is '(' && chr2 is ')') || (chr is '[' && chr2 is ']') || (chr is '{' && chr2 is '}'))
                {
                    
                }
                else
                {
                    valid = false;
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


        internal List<char> PopParantheses(Stack<char> stack)
        {
            List<char> parantheses = new List<char>();
            if (stack.Count > 0)
            {
                foreach (var item in stack)
                {
                    parantheses.Add(item);

                }          
            }

            return parantheses;

        }
    }
}
