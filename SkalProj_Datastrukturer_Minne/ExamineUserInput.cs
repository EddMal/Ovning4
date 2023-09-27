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
            SendOutput("Enter Input: Start with \"+\" to add a member to the list, \"-\" to remove a member. \nFollow the Select-operator with member name example \"+Girgula\":");
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

                    
            }

            return inputs;
        }
    }
}
