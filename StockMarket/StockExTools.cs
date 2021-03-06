using StockMarket.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StockMarket
{
    public class StockExTools
    {
        //Tworzona jest jedna oferta dla wszystkich instrumentów 
        public List<StockOffer> CreateOffer(string path)
        {
            string[] list = File.ReadAllLines(path); //wczytanie ścieżki z instrumentami 
            var instruments = new List<StockOffer>(); 
            var random = new Random();
            DateTime date = RandomDateGenerator(); //tworzenie losowej daty dla danej oferty

            for (var i = 0; i < list.Length; i++) // ta pętla dodaje obiekty typu StockOffer do listy instrumentów oraz uzupełnia dla nich dane 
            {
                var offer = new StockOffer(); 
                offer.Instrument = list[i];
                offer.Value = random.Next(10, 100);
                offer.Date = date;
                instruments.Add(offer); 
            }


            return instruments;
        }

        //metoda serializacji danych do obiektu Json a następnie zapisuje go w pliku 
        public void SaveOffer(StreamWriter writer, List<List<StockOffer>> list)
        {
            string json = JsonConvert.SerializeObject(list.ToArray());
            writer.WriteLine(json);
        }

        //Ta metoda sczytuje dane z pliku a następnie deserializuje je 
        public List<StockOffer> SendListInJson(string path)
        {
            var jsonText = File.ReadAllText(path);
            var list = Deserializing(jsonText);

            return list;
        }

        private List<StockOffer> Deserializing(string jsonText)
        {
            var listOfLists = JsonConvert.DeserializeObject<List<List<StockOffer>>>(jsonText);
            var list = listOfLists.SelectMany(e => e).Distinct().OrderByDescending(e => e.Date).ToList();

            return list;
        }

        //metoda tworzy losowe daty z danym zakresem
        private DateTime RandomDateGenerator()
        {
            Random random = new Random();
            DateTime start = new DateTime(2021, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        public void FilteringResults(string path)
        {
            Console.WriteLine("Type the company for which you want to show results");
            string company = Console.ReadLine().ToUpper();

            var list = SendListInJson(path);
            foreach(var element in list)
            {
                if(element.Instrument == company)
                {
                    Console.WriteLine($"{element.Instrument}, {element.Value}, {element.Date.ToShortDateString()}");
                }
            }
        }

        public List<List<StockOffer>> UserJsonSerializer(StreamWriter writer, List<StockOffer> list, int watcherValue)
        {
            var listOfLists = new List<List<StockOffer>>();
            var offersToBuyList = new List<StockOffer>();         
            foreach (var element in list)
            {
                if (element.Value <= watcherValue)
                offersToBuyList.Add(element);
            }            
            listOfLists.Add(offersToBuyList);

            //stockTool.SaveOffer(writer, listOfLists);

            return listOfLists;
        }

        public void ClearFile(StreamWriter writer)
        {
            string clear = "";
            writer.WriteLine(clear);
        }
    }
}