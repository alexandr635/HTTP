using System;
using System.Net;
using System.IO;
using System.Text;

namespace HTTP
{
    public class PostShiftQuery
    {
        public string key { set; get; }
        public void GetResponse(string action)
        {
            string site = "https://post-shift.ru/api.php?action=" + action;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(site);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string line;
                while((line = streamReader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    if (line.Contains("Key: ") && action.Contains("new&name="))
                        key = line.Substring(5);
                }                
            }
        }
    }
}
