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
    /*public static string ToSHA256(string s)
    {
        using var sha256 = SHA256.Create();
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

        for (int i = 0; i < bytes.Length; i++)
        {
            sb.Append(bytes[i].ToString("x2"));
        }
        return sb.ToString();
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            string[] items = new string[] { "Камень", "Ножницы", "Бумага", "Помощь" };
            Random rand = new Random();
            int a=rand.Next(0, 2);
            
            //Ход человека
            Console.WriteLine("1- Камень 2- Ножницы 3- Бумага 4- Помощь");
            Console.WriteLine("Введите количество элементов массива");
            byte key = byte.Parse(Console.ReadLine());

            string[] elementsCount = Console.ReadLine().Split(' ');
            Console.WriteLine(elementsCount[0]);
            /*int[] myArray = new int[elementsCount];*/
            /*Console.WriteLine("Вывод массива: ");
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            };*/

            switch (key)
            {
                case 1:
                    Console.WriteLine("Вы выбрали: "+items[0]);
                    Console.WriteLine("Компьютер выбрал: "+items[a]);
                    if (a==0)
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
                break;
                case 2:
                    Console.WriteLine("Вы выбрали: " + items[1]);
                    Console.WriteLine("Компьютер выбрал: " + items[a]);
                    if (a==1)
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
                break;
                case 4:
                    /*Console.WriteLine("Вы выбрали: " + items[3]);
                    Console.WriteLine("ПК/Игр\tКамень\tБумага\tНожницы");
                    Console.WriteLine("Камень\tНичья\tПобеда\tПроигр");
                    Console.WriteLine("Бумага\tПроигр\tНичья\tПобеда");
                    Console.WriteLine("Ножницы\tПобеда\tПроигр\tНичья");*/


                    /*var table = new ConsoleTable("ПК/Игр", "Камень", "Бумага", "Ножницы");
                    table.AddRow(1, 2, 3, 4)
                         .AddRow("ПК/Игр", "Камень", "Бумага", "Ножницы");

                    table.Write();
                    Console.WriteLine();

                    var rows = Enumerable.Repeat(new Something(), 10);

                    ConsoleTable
                        .From<Something>(rows)
                        .Configure(o => o.NumberAlignment = Alignment.Right)
                        .Write(Format.Alternative);*/

                    Console.ReadKey();
                    break;
            }
            Console.ReadKey();
        }
    }
}
