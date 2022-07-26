using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Weather_parser
{
    class Parsing
    {
        static void Main()
        {
            string city = null;
            Console.WriteLine("\nВыберите город, по которому хотите смотреть погоду");

            Console.WriteLine("W - Москва\nA - Ульяновск\nD - Казань\nS - Санкт-Петербург");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    Console.Clear();
                    city = "moskva";
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    city = "ulyanovsk";
                    break;
                case ConsoleKey.D:
                    Console.Clear();
                    city = "kazan";
                    break;
                case ConsoleKey.S:
                    Console.Clear();
                    city = "saint_petersburg";
                    break;
                default:
                    Main();
                    break; 
            }

            var html = $@"https://world-weather.ru/pogoda/russia/{city}/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'dw-into']//text()");

            Console.WriteLine("Погода на сегодня: " + node.InnerHtml);
            Main();
        }
    }
}
