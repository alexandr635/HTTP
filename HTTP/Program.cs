using System;
using System.Text;

namespace HTTP
{
    class Program
    {
        static void Main()
        {
            //https://post-shift.ru/api/?lang=ru
            Console.OutputEncoding = Encoding.UTF8;
            
            PostShiftQuery query = new PostShiftQuery();
            
            do
            {
                Console.Clear();
                Console.WriteLine("0 - создать новый почтовый ящик");
                Console.WriteLine("1 - получить список писем");
                Console.WriteLine("2 - получить время жизни ящика");
                Console.WriteLine("3 - увеличить время жизни ящика на 10 мин");
                Console.WriteLine("4 - удалить ящик");
                Console.WriteLine("5 - очистить ящик");
                Console.WriteLine("6 - удалить все ящики");
                Console.WriteLine("7 - получить текст письма");
                Console.Write(">> ");
                try
                {
                    int act = Convert.ToInt32(Console.ReadLine());

                    string result = "";
                    switch (act)
                    {
                        case 0:
                            result = query.CreateEmail();
                            break;
                        case 1:
                            result = query.GetListOfLetters();
                            break;
                        case 2:
                            result = query.GetLifeTime();
                            break;
                        case 3:
                            result = query.ProlongLifeTime();
                            break;
                        case 4:
                            result = query.DeleteEmail();
                            break;
                        case 5:
                            result = query.ClearEmail();
                            break;
                        case 6:
                            result = query.DeleteAllEmails();
                            break;
                        case 7:
                            Console.Write("Введите идентификатор письма: ");
                            try
                            {
                                int id = Convert.ToInt32(Console.Read());
                                result = query.GetTextOfLetter(id);
                            }
                            catch
                            {
                                Console.WriteLine("Введите число!");
                            }
                            break;
                        default:
                            Console.WriteLine("Введите число из диапазона!");
                            break;
                    }
                    if (result != "")
                        Console.WriteLine(result);
                }
                catch
                {
                    Console.WriteLine("Введите число от 0 до 7!");
                }
                Console.Write("Press Enter to continue");
            } 
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("Press Enter to finish the program...");
            Console.ReadLine();
        }
    }
}
