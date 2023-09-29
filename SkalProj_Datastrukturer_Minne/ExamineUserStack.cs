using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal class ExamineUserStack:ExamineUserQueue
    {
        public Stack<string> PushOrPop(Stack<string> stack)
        {
            return AddOrRemove(stack);

        }
        // Method should be divided in to methods for readability and "changeability", this should be done in class "parent-class".
        public override T AddOrRemove<T>(T inputs)
        {
            Stack<string> stackMessages = inputs as Stack<string>;
            SendOutput("Enter Input:\"q\" to return to startmenu.\nEnter: Start with \"+\" to add a message to the stack, \"-\" to pop the last message on the stack.\nTo add a message enter the message after the option-select-operator.\nWhen poping a message from the stack the only relevant input is the first char \"-\"");
            do
            {
                InputForExamination();
                switch (SelectAction)
                {
                    case '+':
                        stackMessages.Push(Input); 
                        SendOutput($"\"{Input}\" entered the stack at position {stackMessages.Count}.");
                        break;
                    case '-':
                        if (stackMessages.Count > 0)
                        {
                            SendOutput($"\"{stackMessages.Peek()}\" is poped from the stack.");
                            stackMessages.Pop();
                        }
                        else
                        {
                            SendOutput($"The stack is empty, there is nothing to see here..");
                        }
                        break;
                    case '*':


                        if (Input is not null or "")
                        {
                            Stack<char> stackReverseMessage = new Stack<char>();
                            //string reversedMessage;

                            foreach (var item in Input)
                            {
                                stackReverseMessage.Push(item);
                            }

                            int countItems = stackReverseMessage.Count;

                            StringBuilder StringBuilderstack = new StringBuilder();

                            for (int i = 0; i < countItems; i++)
                            {


                                StringBuilderstack.Append($"{stackReverseMessage.Peek()}");
                                stackReverseMessage.Pop();
                            }

                            String reversedMessage = StringBuilderstack.ToString();
                            SendOutput($"{reversedMessage}");
                            
                        }
                        break;
                    case 'q':
                        break;
                    default:
                        SendOutput($"Faulty input. Input can not be left empty, to pop input must be atleast two characters starting with \"+\" to pop or \"-\" to pop \"q\"to return to main menu");
                        break;

                }



            } while (SelectAction != 'q');

            if (stackMessages.Count > 0)
            {
                int count = stackMessages.Count;
                SendOutput("\nThe Stack:");
                foreach (var item in stackMessages)
                {
                    
                    SendOutput($"{count}.{item}");
                    count--;
                }
            }
            else
            {
                SendOutput($"The Stack is empty.");
            }

            return (T)Convert.ChangeType(stackMessages, typeof(T));

        }
    }
}
