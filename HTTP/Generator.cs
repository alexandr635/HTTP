using System;

namespace HTTP
{
    class Generator
    {
        public static string GenerationName(int countSimblos)
        {
            string result = "";
            Random rand = new Random();
            for (int i = 0; i < countSimblos; i++)
                result += (char)rand.Next(97, 122);

            return result;
        }

    }
}
