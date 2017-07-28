using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        private Suit _suit;

        public Suit Suit
        {
            get { return _suit; }
            set { _suit = value; }
        }


        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        private int _cardNumber;

        public int CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }



        public Card(Suit suit, int value, int cardNumber)
        {
            Suit = suit;
            Value = value;
            CardNumber = cardNumber;

        }
    }

    enum Suit
    {
        S = 4 ,
        H = 3,
        C = 2,
        D = 1
    };

}
