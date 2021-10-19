using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Models
{
    public class User
    {
        public string Name { get; }
        public List<StockOffer> Stocks { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }
}
