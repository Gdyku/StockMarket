using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using StockMarket.Models;
using Newtonsoft.Json;

namespace StockMarket
{
    public class UserInterface
    {

        StockExTools stockTool = new StockExTools();
        UserTools userTool = new UserTools();
        public void GetOfferHistory(string path, DateTime start, DateTime end)
        {
            var list = stockTool.SendHistoryListInJson(path);

            foreach (var element in list)
            {
                if (element.Date > start && element.Date < end)
                {
                    Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
                }
            }
        }


        public void SetWatcher(string path, User user, string userFile)
        {
            Console.WriteLine("Set a maximal value for watcher");
            int value = Convert.ToInt32(Console.ReadLine());

            var list = stockTool.SendHistoryListInJson(path);
            foreach(var element in list)
            {
                if(element.Value <= value)
                {
                    userTool.BuyOffer(user, element);
                }
            }
        }

        public void GetTransactions(string path)
        {
            var list = stockTool.SendHistoryListInJson(path);

            foreach(var element in list)
            {
                Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
            }
        }

        public void Run(string path, User user)
        {
            var list = stockTool.SendHistoryListInJson(path);
            foreach(var element in list)
            {
                Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
            }

            Console.WriteLine("Do you want to check which stock have you bought?");
            Console.WriteLine("Press Y for yes or N for no");
            char sign = Convert.ToChar(Console.ReadLine().ToUpper());
            if(sign == 'Y')
            {
                userTool.ShowUserStocks(user);
            } else if( sign == 'N')
            {

            } else
            {

            }
        }
    }
}
