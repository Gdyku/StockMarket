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
        TextForUI textObj = new TextForUI();
        public void GetOfferHistory(string path, DateTime start, DateTime end)
        {
            var list = stockTool.SendListInJson(path);

            foreach (var element in list)
            {
                if (element.Date > start && element.Date < end)
                {
                    Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
                }
            }
        }


        public void SetWatcher(string path, StreamWriter writer)
        {
            Console.WriteLine("Set a maximal value for watcher");
            int value = Convert.ToInt32(Console.ReadLine());

            var list = stockTool.SendListInJson(path);
            var offersToBuyList = stockTool.UserJsonSerializer(writer, list, value);

            stockTool.SaveOffer(writer, offersToBuyList);
        }      

        public void GetTransactions(string userFile)
        {
            var list = stockTool.SendListInJson(userFile);

            foreach(var element in list)
            {
                Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
            }
        }

        public void Run(string path, string userFile)
        {
            var list = stockTool.SendListInJson(path);
            foreach(var element in list)
            {
                Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
            }

            Console.WriteLine("Do you want to check which stock have you bought?");
            Console.WriteLine("Press Y for yes or N for no");
            bool answer = textObj.YesOrNoAnswer();
            if(answer == true)
            {
                GetTransactions(userFile);
            } 
        }   
    }
}
