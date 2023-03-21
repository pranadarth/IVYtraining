using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace ChatBot
{
    internal class WhatIs
    {
        string path = @"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\OwnBrowser\data.html";
        string toRead = string.Empty;
        private string searchData;
        public string searchAns { get; set; }

        public WhatIs(string data) 
        {
            searchData = data;
            using (FileStream fs = File.Create(path)) { }
            searchAns = search();
        }
        public string Filter(string str, List<char> charsToRemove)
        {
            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }
        private string search()
        {
            string responseText;
            string content = string.Empty, data = string.Empty;
            string address = searchData;
            address = address.Replace(" ", "_");
            Console.WriteLine("address:" + address);
            try
            {

                if (searchData == null || searchData == "")
                {
                    MessageBox.Show("Please Enter Some keyword!!");
                  
                    return "";
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://en.wikipedia.org/wiki/{address}");

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        responseText = responseStream.ReadToEnd();
                    }
                }

                bool k = true;
                // Console.WriteLine("Output:" + responseText);
                using (StreamWriter writer = new StreamWriter(path))
                {
                    foreach (char c in responseText)
                    {
                        if (c == '[')
                            k = false;
                        if (k)
                        {
                            writer.Write(c);
                        }
                        else
                        {
                            if (c == ']')
                                k = true;
                        }

                    }


                }

                HtmlDocument document = new HtmlDocument();
                document.Load(path);
                foreach (HtmlNode paragraph in document.DocumentNode.SelectNodes("//p"))
                {
                    // do something with the paragraph node here

                    data += paragraph.InnerText; // or something similar


                }
                Console.WriteLine(data);
                if (data.Contains("("))
                {
                    int init = data.IndexOf("(");
                    int endt = data.IndexOf(")");
                    data = data.Remove(init, (endt - init) + 1);
                }
                else if (data.Contains("["))
                {
                    int init = data.IndexOf("[");
                    int endt = data.IndexOf("]");
                    data = data.Remove(init, endt - init + 1);
                }
                int ini = data.IndexOf(searchData);
                int end = data.IndexOf("\n", data.IndexOf(searchData));
                if (ini == -1)
                    ini = 0;
                else if (end == -1)
                    content = data.Substring(ini, 100);
                else
                    content = data.Substring(ini, end - ini);
            }
            catch (WebException ex)
            {
                if (ex.Message.Contains("404"))
                  return  content = "Sorry Not Found";
                content= ex.Message;
            }
            catch (ArgumentOutOfRangeException ix)
            {
                try
                {
                    content = data.Substring(0, data.IndexOf("."));
                }
                catch (Exception exp) { content = data; }
            }
            catch (Exception ep)
            {
                content = ep.Message;
            }
            List<char> charsToRemove = new List<char>() { '@', '_', '#', '$', '!', '^', '&', ';', '<', '>', '(', ')' };
            content = Filter(content, charsToRemove);
            Console.WriteLine("Final:" + content);

            //toRead = content;
            return content;
        }

       
    }
}

   