using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal class ExamineUserList: ExamineInput
    {
        //Method should be divided in to methods for readability and "changeability", and a lot of the content would be beneficial to move to ExamineInput".
        public virtual T AddOrRemove<T>(T inputs)
        {
            List<string> listInputs = inputs as List<string>;
            SendOutput("Enter Input: \"q\" to return to startmenu.\nEnter: Start with \"+\" to add a member to the list, \"-\" to remove a member.\nEnter the member name after the option-select-operator.\nExample: \"+Girgula\":");
            do
            {
                InputForExamination();
                switch (SelectAction)
                {
                    case '+':
                        listInputs.Add(Input);
                        SendOutput($"Added \"{Input}\" to the list.");
                        break;
                    case '-':
                        bool inputFound = false;

                        foreach (var item in listInputs)
                        {
                            //Removes one item of input-name, if there are more members with the same name they will remain on the list.
                            if (Input == item)
                            {
                                listInputs.Remove(Input);
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
                        SendOutput($"Faulty input. Input can not be left empty must be atleast two characters and start with \"-\" or \"+\" or \"q\"to return to main menu");
                        break;

                }



            } while (SelectAction != 'q');

                return (T) Convert.ChangeType(listInputs, typeof(T));
            
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

            //NBad practise part, handling of conditions could be optimized a lot.
            //Handling input for q+charcter/characters would need to be adressed.
            if (ValidateInput(UserInput))
            {
                Input = UserInput.TrimStart(UserInput.First());
                SelectAction = UserInput.First();
            }
            else if (UserInput == "")
            {
                SelectAction = 'x';

            }
            else
            {
                //Triggers default in switch.
                if (UserInput.First() is 'q')
                {

                    SelectAction = UserInput.First();

                }
            }
            


        }

        public override string GetInput()
        {
            string input;
            input = UserInput();
            if (UserInput == null)
            {//Not the best practise part 1, handling of conditions could be optimized a lot.
             //Handling input for q+charcter/characters would need to be adressed.
             //   input = "x";
            }

            return input;
        }
    }
}
