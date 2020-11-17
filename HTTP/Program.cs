using System;
using System.Text;

namespace HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://post-shift.ru/api/?lang=ru
            Console.OutputEncoding = Encoding.UTF8;
            
            PostShiftQuery query = new PostShiftQuery();
            int id = 1;

            string[] arrayAction = new string[]
            {
                $"new&name={Generator.GenerationName(8)}", //создание нового ящика
                $"getlist&key=", //получение списка писем
                $"livetime&key=", //узнать оставшееся время жизни почты
                $"update&key=", //продлить время жизни почты до 10 минут
                $"delete&key=", //удалить использованный ящик
                $"clear&key=", //очистить ящик
                "deleteall", //удалить все активные ящики по ip
                $"getmail&key=" //получение текста письма
            };
            
            do
            {
                Console.Write("Введите цифру от 0 до 7: ");
                int act = Convert.ToInt32(Console.ReadLine());
                switch (act)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        arrayAction[act] += query.key;
                        break;
                    case 7:
                        arrayAction[7] += query.key + "&id=" + id;
                        break;
                }
                query.GetResponse(arrayAction[act]);
            } 
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("Press Enter to finish the program...");
            Console.ReadLine();
        }
    }
}
