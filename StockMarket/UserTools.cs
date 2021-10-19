using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using StockMarket.Models;

namespace StockMarket
{
    public class UserTools
    {
        string userFile = "C:/Users/patryk.gdyczynski/Desktop/Akademia/Ćwiczenia/StockMarket/UserStocks.txt";

        public void BuyOffer(User user, StockOffer offer)
        {
            user.Stocks.Add(offer);
            string json = JsonConvert.SerializeObject(offer);
            StreamWriter writer = new StreamWriter(userFile);
            writer.WriteLine(json);
        }
        public void ShowUserStocks(User user)
        {
            var list = user.Stocks;
            foreach(var element in list)
            {
                Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
            }
        }
    }
}
