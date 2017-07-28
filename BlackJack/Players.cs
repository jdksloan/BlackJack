using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Players
    {
        private string[] _playerA { get; set; }

        public string[] PlayerA
        {
            get { return _playerA; }
            set { _playerA = value; }
        }

        private string[] _playerB;

        public string[] PlayerB
        {
            get { return _playerB; }
            set { _playerB = value; }
        }

        public List<Card> PlayerACards = new List<Card>();

        public List<Card> PlayerBCards =  new List<Card>();

        private bool _playerAWins;

        public bool PlayerAwins
        {
            get { return _playerAWins; }
            set { _playerAWins = value; }
        }

        public int PlayerAScore { get; set; }

        public int PlayerBScore { get; set; }


        public Players(
           string[] playerA,
           string [] playerB,
           bool playerAWins)
        {
            PlayerA = playerA;
            PlayerB = playerB;
            PlayerAwins = playerAWins;

            PlayerACards =  SetCards(PlayerA);
            PlayerAScore = GetScore(PlayerACards);
            PlayerBCards = SetCards(PlayerB);
            PlayerBScore = GetScore(PlayerBCards);

        }

        private List<Card> SetCards(string[] Player)
        {
            List<Card> cards = new List<Card>();
            foreach (var item in Player)
            {
                int Value = 0;
                int cardNumber = 0;
                if (int.TryParse(item.Substring(0, item.Length - 1), out Value))
                {
                    cardNumber = Value;
                }
                else
                {
                    char pic= item.ToUpper()[0];
                    if ( pic == 'A')
                    {
                        Value = 11;
                    }
                    else
                    {
                        Value = 10;
                    }
                }
                

                Card card = new Card(GetSuit(item.ToUpper()[item.Length - 1]), Value, GetCardNumber(item.Substring(0, item.Length -1)));
                cards.Add(card);

            }
            return cards;

        }

        //Gets the card suit in enum form
        private Suit GetSuit(char suit)
        {
            switch (suit)
            {
                case 'S':
                    return Suit.S;
                case 'H':
                    return Suit.H;
                case 'C':
                    return Suit.C;
                case 'D':
                    return Suit.D;
                default:
                    return Suit.S;
            }
        }

        private int GetCardNumber(string pic)
        {
            switch (pic)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "10":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return 0;
            }
        }

        private int GetScore(List<Card> Cards)
        {
            int sum = Cards.Sum(x => x.Value);
            if (sum > 20)
            {
                return 0;
            }
            else
            {
                return sum;
            }
        }

        public int GetHighestCardNumber(List<Card> Cards)
        {
            return Cards.Max(x => x.CardNumber);
        }

        public int GetHighestSuit(List<Card> Cards)
        {
            return Cards.Max(x => (int)x.Suit);
        }

    }
}
