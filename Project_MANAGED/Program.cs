using System.Transactions;

namespace Project_MANAGED
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Projeto de demonstração assíncrona iniciou.\r\n");

            using (Algorithms.ThreadingBasics thBasics = new Algorithms.ThreadingBasics())
            {
                thBasics.Run();
            }
        }
    }
}