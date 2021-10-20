using System;
using System.Collections.Generic;
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
            string userFile = "C:/Users/patryk.gdyczynski/Desktop/Akademia/Ćwiczenia/StockMarket/UserStocks.txt";
            TextForUI consoleOptions = new TextForUI();
            StockExTools stockExToolsObj = new StockExTools();
            UserTools userTools = new UserTools();

            Console.WriteLine("Hello, how many daily offers do you want to create?");
            int offersCount = Convert.ToInt32(Console.ReadLine());
            var list = new List<List<StockOffer>>();
            
            using (StreamWriter writer = new StreamWriter(historyList))
            {
                for (int i = 0; i < offersCount; i++)
                {
                    var offer = stockExToolsObj.CreateOffer(instrumentsPath);
                    list.Add(offer);
                }
                stockExToolsObj.SaveOffer(writer, list);
            }

            User user = new User(userTools.SettingName());
            Console.WriteLine($"Hello {user.Name}, what do you want to do? Type one of the number for answer");


            for (; ; )
            {
                Start:
                consoleOptions.InterfaceOptions();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        {
                            var userInterfaceObj = new UserInterface();
                            DateTime start, end;
                            Console.WriteLine("Please enter a range of dates for which you want to observe a stock market history. Please enter dae in below format\nYYYY-MM-DD");
                            Console.WriteLine("Start date");
                            start = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("End date");
                            end = DateTime.Parse(Console.ReadLine());
                            userInterfaceObj.GetOfferHistory(historyList, start, end);
                        }
                        break;
                    case 2:
                        {
                            using(StreamWriter writer = new StreamWriter(userFile))
                            {
                                var userInterfaceObj = new UserInterface();
                                userInterfaceObj.SetWatcher(historyList, writer);
                            }
                        }
                        break;
                    case 3:
                        {
                            var userInterfaceObj = new UserInterface();
                            userInterfaceObj.GetTransactions(userFile);
                            Console.WriteLine("Do you want to filter results for particular company? Type Y for yes and N to exit program");
                            bool answer2 = consoleOptions.YesOrNoAnswer();
                            if(answer2 == true)
                            {
                                stockExToolsObj.FilteringResults(userFile);
                            }
                            else                         
                                break;                            
                        }
                        break;
                    case 4:
                        {
                            var userInterfaceObj = new UserInterface();
                            userInterfaceObj.Run(historyList, userFile);
                        }
                        break;
                }

                Console.WriteLine("Do you want to do any other operation? Type Y for yes and N to exit program");
                bool answer = consoleOptions.YesOrNoAnswer();
                if (answer == true)
                    goto Start;
                else
                    break;
            }

            using (StreamWriter writer = new StreamWriter(historyList))
            {
                stockExToolsObj.ClearFile(writer);
            }
            using (StreamWriter writer = new StreamWriter(userFile))
            {
                stockExToolsObj.ClearFile(writer);
            }
        }
    }
}
