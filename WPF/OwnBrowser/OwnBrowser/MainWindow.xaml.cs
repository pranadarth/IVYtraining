using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Speech.Synthesis;
//using Windows.Media.SpeechSynthesis;

namespace OwnBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = @"C:\Users\suresh.pranadarth\source\repos\IVYtraining\WPF\OwnBrowser\data.html";
       string toRead = string.Empty;
        public MainWindow()
        {
            InitializeComponent();
           

            // The line below will create a file my_file.py in
            // the Python_Files folder in D:\ drive
            using (FileStream fs = File.Create(path)) { }
        }
        public string Filter( string str, List<char> charsToRemove)
        {
            foreach (char c in charsToRemove)
            {
                str = str.Replace(c.ToString(), String.Empty);
            }

            return str;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            src.IsEnabled= false;
            string responseText;
            string content = string.Empty,data = string.Empty;
            string address = get.Text;
            address = address.Replace(" ", "_");
            try
            {

                if (get.Text == null || get.Text == "")
                {
                    MessageBox.Show("Please Enter Some keyword!!");
                    Disp.Text = "";
                    src.IsEnabled = true;
                    return;
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
                        if(c=='[')
                            k= false;
                        if (k)
                        {
                            writer.Write(c);
                        }
                        else
                        {
                            if (c == ']') 
                                k= true;
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
                if(data.Contains("("))
                {
                    int init = data.IndexOf("(");
                    int endt = data.IndexOf(")");
                    data = data.Remove(init, (endt - init) + 1);
                }
                else if(data.Contains("["))
                {
                    int init = data.IndexOf("[");
                    int endt = data.IndexOf("]");
                    data = data.Remove(init, endt - init + 1);
                }
                int ini = data.IndexOf(get.Text);
                int end = data.IndexOf("\n", data.IndexOf(get.Text));
                if (ini == -1)
                    ini = 0;
                else if(end == -1)
                content = data.Substring(ini, 100);
                else
                    content = data.Substring(ini, end - ini);
            }
            catch (WebException ex) 
            {
                if(ex.Message.Contains("404"))
               content = "Sorry Not Found";
            }
            catch(ArgumentOutOfRangeException ix)
            {
                try { 
                content = data.Substring(0, data.IndexOf(".") );
                    }
                catch(Exception exp) { Content = data; }
            }
            catch(Exception ep) 
            {
                content = ep.Message;
            }
            List<char> charsToRemove = new List<char>() { '@', '_','#','$','!','^','&',';','<','>','(',')' };
            content = Filter(content,charsToRemove);
            Console.WriteLine("Final:" + content);

            toRead = content;
            Disp.Text = content;
            src.IsEnabled = true;
        }

        private void Read(object sender, RoutedEventArgs e)
        {
            using (var reader = new SpeechSynthesizer())
            {
                reader.SelectVoiceByHints(VoiceGender.Female);
                // Get the message value  
                reader.Speak(toRead); // Speak it out!  
            }
        }
    }
}
