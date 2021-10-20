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
        public string SettingName()
        {
            Console.WriteLine("Please enter your name and we will create an account for you");
            var name = Console.ReadLine();
            return name;
        }
    }
}
