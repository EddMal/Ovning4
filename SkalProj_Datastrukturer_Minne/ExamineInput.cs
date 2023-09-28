using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    abstract class ExamineInput: UIUserInterface
    {
        //Could be replaced with locals inside methods.
        private string input;
        private char selectAction;
 

        public string Input
        {
                get
                {
                    return input;
                }
                set
                {
                    if (value.Length < 1 )
                    {
                        throw new ArgumentException($"Error: Faulty input: \"{value}\", input must be at least 1 character");
                    }

                    input = value;

                }
        }

        public char SelectAction
        {
            get
            {
                return selectAction;
            }
            set
            {
                if (value is ' ')//value is '-' or '+')
                {
                    throw new ArgumentException($"Error: Faulty input: \"{value}\", input must be at least 1 character and not whitespace");
                }

                selectAction = value;

            }

        }
        public virtual void InputForExamination()
        {
            string UserInput = GetInput();

            SelectAction = UserInput.First();
            Input = UserInput.TrimStart(UserInput.First());
        }

        public virtual string GetInput()
        {
            string input;
            do
            {
                input = UserInput();

            } while (ValidateInput(input) == false);
            
            return input;
        }

        //public virtual string UserInput()
        //{
        //    string input = Console.ReadLine();

        //    return input;
        //}

        public virtual bool ValidateInput(string input)
        {
            bool isValid = false;
            if (input.Length > 1 && input.First() is '+' or '-')
            {
                isValid = true;
            }
            else
            {
                SendOutput($"Error falty input : \"{input}\", input cant be left empty must be atleast two characters and start with \"-\" or \"+\". Enter \"q\" to return to main menu.");
                
            }

            return isValid;
        }

        //private void SendOutput(string output)
        //{
        //    Console.WriteLine(output);
        //}
    }
}
