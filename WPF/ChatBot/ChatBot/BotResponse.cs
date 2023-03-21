using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIMLbot;
using WpfCamera;

namespace ChatBot
{
    internal class BotResponse
    {
        public string Response { get; set; }
        public int image { get; set; }
        private string userName="Friend";
        private List<string> nrmlName = new List<string>();
        private string[] notty = { "jyo","shivani" };
        private string[] fav = { "prana", "pradeep","saniya","teje" };
        private string[] whatQuesFilter = { "what is","what", "meaning", "meaning of", "means","mean by","who is","?","who","meanby", "search for", "meant by" };
        private string[] whatQues = { "search for","meaning of","meaning", "meant by", "means","mean by"};
        private string[] creator = { "who created you", " who is owner of you" ,"who invented you", "you were invented","your boss", 
                                     "you were created", "you created","you invented","about you" };
        private string[] affair = { "marry", "love" };
        private string[] userCheck = { "i am", "my name", "am " };
        private string[] userCheckFilter = { "i am", "my name", "am ",".","hi ","is " };
        private string[] cameraCheck = { "camera", "audio", "video","photo","selfie","rec","pic" };



        User currentUser;
        Bot Ai;
        Request req;
        Camera camera;
        public BotResponse() 
        {
           
            camera = new Camera();
           
        }

        public string Filter(string str, string[] charsToRemove)
        {
            foreach (string c in charsToRemove)
            {
                str = str.Replace(c, String.Empty);
            }

            return str;
        }

        private string AIRepsonse(string Query)
        {

            Ai = new Bot();
            Ai.loadSettings();
            Ai.loadAIMLFromFiles();
            Ai.isAcceptingUserInput = true;
            currentUser = new User(userName, Ai);
            req = new Request(Query, currentUser, Ai);

            Result final = Ai.Chat(req);
            if (final.Output.Contains("un-named"))
                return final.Output.Replace("un-named user", userName);
            return final.Output;
        }

        public string Decision(string Ques)
        {
            string final = string.Empty;

            if (Ques.Contains("who are you") || Ques.Contains("your name"))
            {
                final = "Hi.. am Aucu 😄 \nand you?";
            }
            else if (affair.Any(Ques.Contains))
            {
                if (userName == "Boss")
                    final = "I Love you boss";
                else
                    final = "I will love only  My Boss Pranadarth ";
            }
            else if (creator.Any(Ques.Contains))
            {
               
                final = "I was created by My Boss Pranadarth on Feb 2023";

            }
            else if (whatQues.Any(Ques.Contains))
            {
                string extract = Filter(Ques, whatQuesFilter);
                extract = extract.Trim();
                Console.WriteLine(extract);
                WhatIs what = new WhatIs(extract);
                final = what.searchAns;
            }
            else if (userCheck.Any(Ques.Contains) && !Ques.Contains("am i") && !Ques.Contains("who"))
            {

                if (notty.Any(Ques.Contains))
                { final = $"Hi  stupid 😒"; userName = "stupid"; }
                else if (fav.Any(Ques.Contains))
                { final = $"Hi Boss  😉"; userName = "Boss"; }
                else
                {userName = Filter(Ques, userCheckFilter); final = $"Hieeeee {userName} 😄"; }
            }
            else if (cameraCheck.Any(Ques.Contains))
            {
                int sec = 3;
                if(Ques.Contains("sec"))
                   sec = int.Parse( string.Concat(Ques.Where(char.IsNumber)));
                if (Ques.Contains("video"))
                {
       
                    camera.startRec(sec);
                    final = "Ok..Starting Now";
                }
                else if(Ques.Contains("audio") || Ques.Contains("voice"))
                {
                    camera.AudioRecStart(sec);
                    final = "Ok..Recording Now";
                }
                else if (Ques.Contains("Stop"))
                {

                    camera.stopRec();
                    final = "Ok..Stopped";
                }
                else
                {
                    camera.TakePhoto();
                   
                    final = "Ok..Say Cheese!!";
                    image = 1;
                }
                final += "\n 3.. 2.. 1..";
            }
            else
                final = AIRepsonse(Ques);
                //final = "Sorry 😕 I don't know what u say";
            return Response = final;
        }
    }
}
