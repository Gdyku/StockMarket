using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace StockMarket.Models
{
    public class StockOffer
    {
        public string Instrument { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
    }
}
