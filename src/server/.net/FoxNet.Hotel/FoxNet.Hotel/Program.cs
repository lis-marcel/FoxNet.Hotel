using System;
using FoxNet.Hotel.BO;
using FoxNet.Hotel.Common;

namespace FoxNet.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initalizing server...");

            var db = DbStorage.GetDefault();

            DbStorage.InsertTestData(db);

            Console.WriteLine("Ended process.");
        }
    }
}