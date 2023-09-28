using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal class ExamineUserQueue : ExamineUserList
    {
        public Queue<string> EnqueueOrDequeue(Queue<string> queue)
        {
            return AddOrRemove(queue);

        }
        // Method should be divided in to methods for readability and "changeability", this should be done in class "parent-class".
        public override T AddOrRemove<T>(T inputs)
        {
            Queue<string> queueInputs = inputs as Queue<string>;
            SendOutput("Enter Input:\"q\" to return to startmenu.\nEnter: Start with \"+\" to add a member to the queue, \"-\" + to dequeue the first member in queue.\nTo enqueue a member enter the member name after the option-select-operator.\nWhen dequeeue of a member the only relevant input is the first char \"-\"");
            do
            {
                InputForExamination();
                switch (SelectAction)
                {
                    case '+':
                        queueInputs.Enqueue(Input);
                        SendOutput($"\"{Input}\" entered the queue at position {queueInputs.Count}.");
                        break;
                    case '-':
                        if (queueInputs.Count != 0)
                        {
                            SendOutput($"\"{queueInputs.Peek()}\" left the queue.");
                            queueInputs.Dequeue();
                            
                        }
                        else
                        {
                            SendOutput($"The queue is empty, there is no member to dequeue.");
                        }
                        break;
                    case 'q':
                        break;
                    default:
                        SendOutput($"Faulty input. Input can not be left empty must be atleast two characters and start with \"+\", \"-\" or \"q\"to return to main menu");
                        break;

                }



            } while (SelectAction != 'q');

            if (queueInputs is not null)
            {   //Should be placed in ExamineInput class.
                int count=0;
                SendOutput("\nThe Queue:");
                foreach (var item in queueInputs)
                {
                    count++;
                    SendOutput($"{count}.{item}");
                }
            }
            else
            {
                SendOutput($"The queue is empty, there is no member to dequeue.");
            }

            return (T)Convert.ChangeType(queueInputs, typeof(T));

        }

        // Bad practise methood should be divided and handled diffrently in "parent-class"
        public override void InputForExamination()
        {
            string UserInput = GetInput();

            //Bad practise part, handling of conditions could be optimized a lot.
            //Handling input for q+charcter/characters would need to be adressed.
            if (ValidateInput(UserInput))
            {
                Input = UserInput.TrimStart(UserInput.First());
                SelectAction = UserInput.First();
            }
            else if (UserInput == "")
            {  //Triggers default in switch.
                SelectAction = 'x';

            }
            else
            {
                SelectAction = UserInput.First();
            }
        }
    }
}
