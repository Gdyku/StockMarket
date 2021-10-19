using System;
using System.IO;
using StockMarket.Models;

namespace StockMarket
{
    class Program
    {
        static void Main(string[] args)
        {
            //stringi ze ścieżką do plików
            string instrumentsPath = "C:/Users/patryk.gdyczynski/Desktop/Akademia/Ćwiczenia/StockMarket/instruments.txt";
            string historyList = "C:/Users/patryk.gdyczynski/Desktop/Akademia/Ćwiczenia/StockMarket/Oferts.txt";

            var obj = new StockExTools();
            //Daily offer to dzienna oferta wartości dla wszystkich instrumentów 
            Console.WriteLine("Hello, how many daily offers do you want to create?");
            //int count = Convert.ToInt32(Console.ReadLine());
            var writer = new StreamWriter(historyList);
            for (int i = 0; i <= 100; i++)
            {
                var offer = obj.CreateOffer(instrumentsPath);
                obj.SaveOffer(writer, offer);
            }

            Console.WriteLine("Please enter your name and we will create an account for you");
            string name = Console.ReadLine();
            User user = new User(name);
            Console.WriteLine($"Hello {user.Name}, what do you want to do?");

            DateTime start, end;
            Console.WriteLine("Please enter a range of dates for which you want to observe a stock market history");
            Console.WriteLine("Start date");
            start = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("End date");
            end = DateTime.Parse(Console.ReadLine());

            var obj2 = new UserInterface();
            obj2.GetOfferHistory(historyList, start, end);
        }
    }
}
