namespace SkalProj_Datastrukturer_Minne
{
    internal class UIUserInterface
    {

        public string UserInput()
        {
            return Console.ReadLine();
        }

        public void SendOutput(string output)
        {
            Console.WriteLine(output);
        }

    }
}