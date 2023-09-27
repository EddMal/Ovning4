using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal class ExamineUserInput: ExamineInput
    {
        public List<string> AddOrRemove(List<string> inputs)
        {
            SendOutput("Enter Input:Press Q to return to startmenu.\nEnter: Start with \"+\" to add a member to the list, \"-\" to remove a member.\nEnter the member name after the option-select-operator.\nExample: \"+Girgula\":");
            do
            {
                InputForExamination();
                switch (SelectAction)
                {
                    case '+':
                        inputs.Add(Input);
                        SendOutput($"Added \"{Input}\" to the list.");
                        break;
                    case '-':
                        bool inputFound = false;

                        foreach (var item in inputs)
                        {
                            //Removes one item of input-name, i there are more of the same name they will still be on the list.
                            if (Input == item)
                            {
                                inputs.Remove(Input);
                                inputFound = true;
                                SendOutput($"Removed \"{Input}\" from the list.");
                                break;
                            }
                        }
                        if (!inputFound)
                        {
                            SendOutput($"\"{Input}\" does not exist in the list.");
                        }
                        break;
                    case 'q':
                        break;
                    default:
                        SendOutput($"Falty input : \"{Input}\", input cant be left empty must be atleast two characters and start with \"-\" or \"+\".");

                        break;

                }



            } while (SelectAction != 'q');
                return inputs;
            
        }


        public override bool ValidateInput(string input)
        {
            bool isValid = false;
            if (input.Length > 1)
                {
                isValid = true;
            }
            else
            {
                //SendOutput($"Error falty input : \"{input}\", input cant be left empty or consist of whitespace.");

            }

            return isValid;
        }

        public override void InputForExamination()
        {
            string UserInput = GetInput();

            SelectAction = UserInput.First();
            
            if (ValidateInput(UserInput))
            Input = UserInput.TrimStart(UserInput.First());
        }

        public override string GetInput()
        {
            string input;
            //do
            //{
                input = UserInput();

            //} while (ValidateInput(input) == false);

            return input;
        }
    }
}
