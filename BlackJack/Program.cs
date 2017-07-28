using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace BlackJack
{
    class Program
    {
        private const string s3URL = "https://s3-eu-west-1.amazonaws.com/yoco-testing/tests.json";
        private const string fileLocation = "C:\\test.json";
        static List<Players> PlayerList = new List<BlackJack.Players>();
        static void Main(string[] args)
        {
            DownloadS3FIle();
            CreateArray();
            ProcessResults();
            Console.ReadLine();
        }

        private static void DownloadS3FIle()
        {
            using (WebClient myWebClient = new WebClient())
            {
                myWebClient.DownloadFile(s3URL, fileLocation);
            }
        }

        private static void CreateArray()
        {
            using(FileStream fs = new FileStream(fileLocation, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    string test = reader.ReadToEnd();
                    PlayerList = JsonConvert.DeserializeObject<List<Players>>(test);
                }
            }
           
        }

        private static void ProcessResults()
        {
            foreach (Players players in PlayerList)
            {
                bool playerAWins = true;
                if(players.PlayerAScore > players.PlayerBScore)
                {
                    playerAWins = true;
                }
                else if (players.PlayerAScore == players.PlayerBScore)
                {
                    //ONLY if the players score is equal we got and get each ones highest Card Number
                    int PlayerAHighestCardNumber = players.GetHighestCardNumber(players.PlayerACards);
                    int PlayerBHighestCardNumber = players.GetHighestCardNumber(players.PlayerBCards);

                    if (PlayerAHighestCardNumber > PlayerBHighestCardNumber)
                    {
                        playerAWins = true;
                    }
                    else if (PlayerAHighestCardNumber == PlayerBHighestCardNumber)
                    {
                        //Only if they both have the same card number we look at the higest suit.
                        int PlayerAHighestSuit = players.GetHighestSuit(players.PlayerACards);
                        int PlayerBHighestSuit = players.GetHighestSuit(players.PlayerBCards);
                        if (PlayerAHighestSuit < PlayerBHighestSuit)
                        {
       
                            playerAWins = false;
                        }
                        else
                        {
                            playerAWins = true;
                        }
                    }
                    else
                    { 
                        playerAWins = false;
                    }
                }
                else
                {
                    playerAWins = false;
                }

                Console.WriteLine("Test Check {0}", players.PlayerAwins == playerAWins);


            }
        }




    }
}
