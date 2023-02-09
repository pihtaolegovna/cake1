using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Cakes
{
    internal class Menu
    {
        private string[,] prices = new string[6, 6]
            {
                {"500", "500", "500", "700", "", ""},
                {"1000", "1200", "2000", "", "", ""},
                {"100", "100", "150", "200", "250", ""},
                {"200", "400", "600", "800", "", ""},
                {"100", "100", "150", "150", "200", ""},
                {"150", "150", "150", "", "", ""},
            };
        private string[,] parameters = new string[6, 6]
        {
                {"Круг", "Квадрат", "Прямоугольник", "Сердешко", "", ""},
                {"Маленький(D - 16cm, 8 порц.)", "Обычный(D - 18cm, 10 порц.)", "Большой(D - 28cm, 24 порц.)", "", "", ""},
                {"Ванильный", "Шоколадный", "Карамельный", "Ягодный", "Кокосовый", ""},
                {"1 корж", "2 коржа", "3 коржа", "4 коржа", "", ""},
                {"Шоколад", "Крем", "Бизе", "Драже", "Ягоды", ""},
                {"Шоколадная", "Ягодная", "Кремовая", "", "", ""},
        };
        public void MenuUI()
        {


            int upborder = 8;
            int downborder = 2;
            int VerPos = 1;
            int price = 0;
            int menu = 1;
            int index = 0;
            Cake cake = new Cake(0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "");
            ConsoleKey key;

            while (true)
            {
                cake.AllPrice = cake.FormPrice + cake.SizePrice + cake.TastePrice + cake.AmountPrice + cake.DecorationPrice + cake.GlazePrice;
                cake.AllOptions = $"{cake.form} {cake.size} {cake.taste} {cake.amount} {cake.decoration} {cake.glaze}";
                switch (menu)
                {
                    case 1:
                        MainMenu(price, cake);
                        break;
                    case 2:
                        SecondaryMenu(prices, parameters, index);
                        break;
                }
                WriteCursor(VerPos);
                key = Console.ReadKey(true).Key;
                VerPos = arrows(VerPos, upborder, downborder, key);
                switch (menu)
                {
                    case 1:
                        switch (key)
                        {
                            case ConsoleKey.Enter:
                                if (VerPos < 8)
                                {
                                    menu = 2;
                                    downborder = 3;
                                    index = VerPos - 2;
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (parameters[index, i] == "")
                                        {
                                            upborder -= 1;
                                        }
                                    }
                                }
                                else if (VerPos == 8)
                                {
                                    WritingOrder(cake.AllOptions, cake.AllPrice);
                                    Console.Clear();
                                    Console.WriteLine("Заказ выполнен");
                                    Console.WriteLine("Если хотите завершить выполнение программы нажмите ESC.");
                                    key = Console.ReadKey(true).Key;
                                    if (key == ConsoleKey.Escape)
                                    {
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        cake = new Cake(0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "", "");
                                    }
                                }
                                break;
                        }
                        break;
                    case 2:
                        switch (key)
                        {
                            case ConsoleKey.Enter:
                                int option = VerPos - 3;
                                ChoosingOptions(option, index, parameters, prices, cake);
                                menu = 1;
                                downborder = 2;
                                upborder = 8;
                                break;
                            case ConsoleKey.Escape:
                                menu = 1;
                                downborder = 2;
                                upborder = 8;
                                break;
                        }
                        break;
                }
            }
        }
        private void MainMenu(int price, Cake cake)
        {
            Console.Clear();
            Console.WriteLine("Cakes");
            Console.WriteLine("Выберите параметр: ");
            Console.WriteLine("  Форма торта");
            Console.WriteLine("  Размер торта");
            Console.WriteLine("  Вкус коржей");
            Console.WriteLine("  Кол-во коржей");
            Console.WriteLine("  Глазурь");
            Console.WriteLine("  Декор");
            Console.WriteLine("  Конец заказа");
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Цена: {cake.AllPrice}");
            Console.WriteLine($"Заказ: {cake.AllOptions}");

        }
        private int arrows(int startheight, int mheight, int MinVerPos, ConsoleKey key)
        {
            switch (key)
            {
                case (ConsoleKey.UpArrow):
                    startheight--;
                    if (startheight < MinVerPos)
                    {
                        startheight = MinVerPos;
                    }
                    break;
                case (ConsoleKey.DownArrow):
                    startheight++;
                    if (startheight > mheight)
                    {
                        startheight = mheight;
                    };
                    break;
            }
            return startheight;
        }
        private void WriteCursor(int VerPos)
        {
            Console.SetCursorPosition(0, VerPos);
            Console.WriteLine("> ");
        }
        private void SecondaryMenu(string[,] prices, string[,] parameters, int index)
        {
            Console.Clear();
            Console.WriteLine("Для выхода нажмите ESC");
            Console.WriteLine("Выберите параметр торта");
            Console.WriteLine("-----------------------------------------");
            for (int i = 0; i < 6; i++)
            {
                if (parameters[index, i] != "")
                {
                    Console.WriteLine($"  {parameters[index, i]} - {prices[index, i]} рубелей");
                }
            }

        }
        private void ChoosingOptions(int option, int index, string[,] parameters, string[,] prices, Cake cake)
        {
            switch (index)
            {
                case 0:
                    cake.form = parameters[index, option];
                    cake.FormPrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 1:
                    cake.size = parameters[index, option];
                    cake.SizePrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 2:
                    cake.taste = parameters[index, option];
                    cake.TastePrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 3:
                    cake.amount = parameters[index, option];
                    cake.AmountPrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 4:
                    cake.glaze = parameters[index, option];
                    cake.GlazePrice = Convert.ToInt32(prices[index, option]);
                    break;
                case 5:
                    cake.decoration = parameters[index, option];
                    cake.DecorationPrice = Convert.ToInt32(prices[index, option]);
                    break;
            }
        }
        private void WritingOrder(string AllOptions, int AllPrice)
        {
            if (!File.Exists("C:\\menu\\Order.txt"))
            {
                FileStream fileStream = File.Create("C:\\menu\\Order.txt");
                fileStream.Dispose();
            }
            File.AppendAllText("C:\\menu\\Order.txt", $"\n{DateTime.Now}\n{AllPrice}\n{AllOptions}");
        }
    }
}
