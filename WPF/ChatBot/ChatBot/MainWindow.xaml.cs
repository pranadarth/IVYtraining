using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Speech.Recognition;
using System.Net.NetworkInformation;
using System.Speech.Synthesis;
using System.Threading;
using System.Windows.Controls.Primitives;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using System.IO;

namespace ChatBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BotResponse bot;
        VoiceGender voiceTone = VoiceGender.Female;
        public MainWindow()
        {
            InitializeComponent();
           DataContext= this;
            bot = new BotResponse();
        }
        public string userData { get; set; }
        public string botData { get; set; }

        string[] OnAudio = { "unmute", "turn on", "audio please","enable" };
        string[] OffAudio = { "mute", "turn off", "no audio", "disable" };
        string[] Tone = { "change your","voice","tone" };
        bool continueAnime = false,noAudio = false;
        //Task readTask;
        SpeechSynthesizer reader;
        Storyboard aiAnime;


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            clkProcess();
            // readTask = new Task(Read);
        }

        private void AnimeCtrl(object sender, EventArgs e)
        {
            if (continueAnime)
                return;
             aiAnime.Begin(this);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
           App.Current.Shutdown();
        }
        private void clearAll(object sender, RoutedEventArgs e)
        {
            TextArea.Children.Clear();
            reader.Dispose();
        }

        private void Windows_Loaded(object sender, RoutedEventArgs e)
        {
            mainContent.Focus();
            botData = "Hi.. am Aucu 😄 \nand you?";
            aiAnime = this.FindResource("speakAnime") as Storyboard;
            CreateATextBox(botData, 1);
            Read();
        }
        int i = 0;
        private void clkProcess()
        {
           //For first instance.. Not diabling the voice
            if ( i++ != 0)
            reader.Dispose();
            
            if(mainContent.Text == string.Empty) 
            { 
                userData= string.Empty; 
                return; 
            }
           
            userData =  mainContent.Text ;
            CreateATextBox(userData, 0);
            botData = botResponse();
            scroller.ScrollToEnd();
            if (OffAudio.Any((mainContent.Text.ToLower()).Contains))
            {
                noAudio = true;
                botData = "Voice disabled";
            }
            else if (OnAudio.Any((mainContent.Text.ToLower()).Contains))
            {
                noAudio = false;
                botData = "Voice enabled";
            }
            else if (Tone.Any((mainContent.Text.ToLower()).Contains))
            {
                voiceTone = (voiceTone == VoiceGender.Male)? VoiceGender.Female : VoiceGender.Male;
                botData = "Voice Changed";
            }
            mainContent.Text = string.Empty;
            if (botData == string.Empty)
            {
                return;
            }
            CreateATextBox(botData, 1);
            if(!noAudio)
            Read();
        }
        private async void CreateATextBox(string Data, int botResponse)
        {
           
           
                Border bx = new Border();
                bx.BorderThickness = new Thickness(0);
                bx.VerticalAlignment = VerticalAlignment.Top;
                bx.Margin = new Thickness(10, 5, 10, 0);

            
            
                TextBlock txtb = new TextBlock();
                txtb.Text = Data;
                txtb.FontWeight = FontWeights.Bold;
                txtb.MaxWidth = 600;
                txtb.FontSize = 20;
                txtb.Padding = new Thickness(10, 0, 10, 0);
                txtb.TextWrapping = TextWrapping.Wrap;
                txtb.Margin = new Thickness(5);
                if (botResponse == 0)
                {
                    bx.Background = new SolidColorBrush(Colors.LightSlateGray);
                    bx.CornerRadius = new CornerRadius(15, 0, 15, 15);
                    bx.HorizontalAlignment = HorizontalAlignment.Right;

                }
                else
                {
                    bx.Background = new SolidColorBrush(Colors.LightSeaGreen);
                    bx.CornerRadius = new CornerRadius(0, 15, 15, 15);
                    bx.HorizontalAlignment = HorizontalAlignment.Left;
                }
                bx.Child = txtb;
            TextArea.Children.Add(bx);

            
           
        }

        private async void createImage()
        {
            Border bx = new Border();
           
           // string folder = "C:\\Users\\suresh.pranadarth\\OneDrive - Entain Group\\Pictures";
            string folder = "C:\\Users\\suresh.pranadarth\\source\\repos\\IVYtraining\\WPF\\ChatBot\\ChatBot\\UserData";
            try
            {
                string pattern = "*.jpg";
                var dirInfo = new DirectoryInfo(folder);
               

              
                bx.BorderThickness = new Thickness(0);
                bx.VerticalAlignment = VerticalAlignment.Top;
                bx.Margin = new Thickness(10, 5, 10, 0);
                bx.Background = new SolidColorBrush(Colors.LightSeaGreen);
                bx.CornerRadius = new CornerRadius(0, 15, 15, 15);
                bx.HorizontalAlignment = HorizontalAlignment.Left;

                Image dynamicImage = new Image();
               

                // Create a BitmapSource  
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                await Task.Delay(1000);
                var file = (from f in dirInfo.GetFiles(pattern) orderby f.LastWriteTime descending select f).First();
                Console.WriteLine(file.ToString());
                bitmap.UriSource = new Uri(folder+"\\"+ file.ToString());
                bitmap.EndInit();

                // Set Image.Source  
                dynamicImage.Source = bitmap;
                dynamicImage.Height = 150;
                // Add Image to Window  
                bx.Child = dynamicImage;
            }catch(Exception ex) { }
            bot.image = 0;
            TextArea.Children.Add(bx);

        }

        private async void Read()
        {
            continueAnime = false;
            aiAnime.Completed += new EventHandler(AnimeCtrl);
            aiAnime.Begin(this);

           
            reader = new SpeechSynthesizer();
          


            await Task.Run(() =>
            {

                try
                {
                    

                    reader.SelectVoiceByHints(voiceTone, VoiceAge.Teen);

                    reader.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(speakProgress);
                    
                    // Get the message value  
                    reader.Speak(botData);
                    // Speak it out!  

                    continueAnime = true;
                    
                }
                catch { continueAnime = true; }
            });
            if (bot.image == 1)
            {
                createImage();
            }
        }

        private void speakProgress(object sender, SpeakProgressEventArgs e)
        {
            continueAnime = false;
        }

        private void enterKey(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                clkProcess();
             
            }
           
        }

        

        private string botResponse()
        {
            string temo = userData;
           
            string final=string.Empty;
            temo =userData.ToLower();
            bot.Decision(temo);
            final = bot.Response;
            final = final.Trim();
            return final;
        }
      
    }
}
