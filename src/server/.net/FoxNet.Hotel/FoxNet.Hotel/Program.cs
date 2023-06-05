using FoxNet.Hotel.Common;

namespace FoxNet.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating database...");

            DbStorage.GetDefault();

            Console.WriteLine("Ended process.");
        }
    }
}