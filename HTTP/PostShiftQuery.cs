using System;
using System.Net;
using System.IO;
using System.Text;

namespace HTTP
{
    public class PostShiftQuery
    {

        private static string action = "https://post-shift.ru/api.php?action=";
        private static string key = null;

        public string CreateEmail()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + $"new&name={Generator.GenerationName(8)}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    if (line.Contains("Key: "))
                        key = line.Substring(5);
                }

                return streamReader.ReadToEnd();
            }
        }

        public string GetListOfLetters()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "getlist&key=" + key);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string GetLifeTime()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "livetime&key=" + key);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string ProlongLifeTime()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "update&key=" + key);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string DeleteEmail()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "delete&key=" + key);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string ClearEmail()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "clear&key=" + key);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string DeleteAllEmails()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "deleteall" + key);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        public string GetTextOfLetter(int id)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(action + "getmail&key=" + key + "&id=" + id);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
