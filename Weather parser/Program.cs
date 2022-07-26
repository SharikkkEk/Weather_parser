using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Weather_parser
{
    class cities
    {
        public string name;
        public string pogoda;
    }
    class Program
    {
        static void Main()
        {
            Choice();
        }
        static void Parsing(string city)
        {
            var html = $@"https://world-weather.ru/pogoda/russia/{city}/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode("//span[@class = 'dw-into']//text()");

            Console.WriteLine("Погода на сегодня: " + node.InnerHtml);
            Continue();
        }
        static void Choice()
        {
            Console.WriteLine("\nВыберите город, по которому хотите смотреть погоду");

            Console.WriteLine("W - Москва\nA - Ульяновск\nD - Казань\nS - Санкт-Петербург");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    Console.Clear();
                    Parsing("moskva");
                    break;
                case ConsoleKey.A:
                    Console.Clear();
                    Parsing("ulyanovsk");
                    break;
                case ConsoleKey.D:
                    Console.Clear();
                    Parsing("kazan");
                    break;
                case ConsoleKey.S:
                    Console.Clear();
                    Parsing("saint_petersburg");
                    break;
                default:
                    Main();
                    break;
            }
        }
        static void Continue()
        {
            Console.WriteLine("\nПродолжить?");
            Console.WriteLine("Q - да\nE - нет");
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Q:
                    Choice();
                    break;
                case ConsoleKey.E:
                    break;
                default:
                    Choice();
                    break;
            }
        }
    }
}
