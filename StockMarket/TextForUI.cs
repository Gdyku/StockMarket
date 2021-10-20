using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class TextForUI
    {
        public void InterfaceOptions()
        {
            Console.WriteLine("1. Get Offer History.\n Here you can choose a time interval for which you want to see stock offers history");
            Console.WriteLine("2. Set Watcher.\n You can set a value and watcher will buy for you all stocks offers which will be cheaper than value you set");
            Console.WriteLine("3. Get Transactions.\n It will show you all the transactions that you did");
            Console.WriteLine("4. Run. It will show you history of all stock offers. If you will decide you can also look on you transactions");
        }

        public bool YesOrNoAnswer()
        {
            Beginning:
            char letter = Convert.ToChar(Console.ReadLine().ToUpper());
            if (letter == 'Y')
                return true;
            else if (letter == 'N')
                return false;
            else
            {
                Console.WriteLine("You have typed wrong letter. Try one more time");
                goto Beginning;
            }
        }
    }
}
