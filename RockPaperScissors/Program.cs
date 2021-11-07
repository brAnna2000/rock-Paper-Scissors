using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using System.IO;
using System.Security.Cryptography;

namespace RockPaperScissors
{       
    public class Hashing
    {
        static string HMACHASH(string str, string key)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] data = new byte[128];
            rng.GetBytes(data);
            Console.WriteLine(rng);

            //byte[] bkey = Encoding.Default.GetBytes(rng);
            byte[] bkey = Encoding.Default.GetBytes(str);
            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                return BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower();
            }
        }
        public static string ToSHA256(string s)
        {
            //byte[] random = new byte[128];
            //rng.cryptoserviceprovider rng = new rng.cryptoserviceprovider();
            //rng.getbytes(random); *//*случайный ключ длинной 128б

            Random rand = new Random();
            int a = rand.Next(0, 2);  /*Генерируем рандомное число*/

            var sha256 = SHA256.Create();
            //byte[] bytes = { };
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            switch (a)
            {
                case 0:
                    bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes("Камень"));
                    break;
                case 1:
                    bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes("Ножницы"));
                    break;
                case 2:
                    bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes("Бумага"));
                    break;

            }
            

            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }

    public class Table
    {
        public static string[] ParamNames(string[] s)
        {
        var table = new ConsoleTable(s[0], s[1], s[2], s[3], s[4], s[5]);
        table.AddRow("Камень", "Ничья", "Победа", "Проигрыш", "Проигрыш", "Победа")
             .AddRow("Бумага", "Проигрыш", "Ничья", "Победа", "Победа", "Проигрыш")
             .AddRow("Ножницы", "Победа", "Проигрыш", "Ничья", "Проигрыш", "Победа")
             .AddRow("Ящерица", "Победа", "Проигрыш", "Победа", "Ничья", "Проигрыш")
             .AddRow("Спок", "Проигрыш", "Победа", "Проигрыш", "Победа", "Ничья");
            table.Write();
        Console.ReadKey();
        return s;
        }
    }

    class Program
    {
        static void Main(string[] args)
            {
            //Console.WriteLine("строка для hash");
            //string input = Console.ReadLine();
            //Console.WriteLine($"строка hash:{Hashing.ToSHA256(input)}");

            string[] items = new string[] { "Камень", "Ножницы", "Бумага", "Ящерица", "Спок", "Помощь" };
            Random rand = new Random();
            int a = rand.Next(0, 4);

            Console.WriteLine("1- камень 2- ножницы 3- бумага 4- ящерица 5- спок 6- помощь");

            string elementsCount = Console.ReadLine();
            String[] numberStrs = elementsCount.Split(' ');
            int n = numberStrs.Distinct().Count();

            if (numberStrs.Length == 1 && int.Parse(numberStrs[0]) == 6)
            {
                string[] names = {"ПК/Игр","Камень","Бумага","Ножницы", "Ящерица", "Спок" };
                Table.ParamNames(names);
            }
            else if(numberStrs.Length < 4 || numberStrs.Length % 2 == 0 || numberStrs.Length != n || numberStrs.Length == 0)
            {
                Console.WriteLine($"Ошибка: Четное число ходов, меньше 4, повторяющиеся ходы или нет ввода");
            }
            else
            {
                int[] numbers = new int[numberStrs.Length];
                for (int i = 0; i < numberStrs.Length; i++)
                {
                    numbers[i] = int.Parse(numberStrs[i]);
                }

                for (int i = 0; i < numberStrs.Length; i++)
                {
                    byte key = (byte)numbers[i];

                    switch (key)
                    {
                        case 1:
                            Console.WriteLine("Вы выбрали: " + items[0]);
                            Console.WriteLine("Компьютер выбрал: " + items[a]);
                            if (a == 0)
                            {
                                Console.WriteLine("У вас ничья!");
                            }
                            if (a == 1)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 2)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            if (a == 3)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 4)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Вы выбрали: " + items[1]);
                            Console.WriteLine("Компьютер выбрал: " + items[a]);
                            if (a == 1)
                            {
                                Console.WriteLine("У вас ничья!");
                            }
                            if (a == 2)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            if (a == 3)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 4)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Вы выбрали: " + items[2]);
                            Console.WriteLine("Компьютер выбрал: " + items[a]);
                            if (a == 2)
                            {
                                Console.WriteLine("У вас ничья!");
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 1)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            if (a == 3)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            if (a == 4)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Вы выбрали: " + items[3]);
                            Console.WriteLine("Компьютер выбрал: " + items[a]);
                            if (a == 2)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Вы проиграли");
                            }
                            if (a == 1)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 3)
                            {
                                Console.WriteLine("У вас ничья!");
                            }
                            if (a == 4)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Вы выбрали: " + items[4]);
                            Console.WriteLine("Компьютер выбрал: " + items[a]);
                            if (a == 2)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            if (a == 0)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 1)
                            {
                                Console.WriteLine("Вы победили!");
                            }
                            if (a == 3)
                            {
                                Console.WriteLine("У вас ничья!");
                            }
                            if (a == 4)
                            {
                                Console.WriteLine("Вы проиграли!");
                            }
                            break;
                    } 
                }
            }
            Console.ReadKey();
        }
    }
}
