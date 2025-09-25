using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class CardDrop
    {
        private Card _Card;
        private string _PictureBox;

        public CardDrop() { }
        public CardDrop(Card card, string pBox) : this()
        {
            _Card = card;
            _PictureBox = pBox;
        }
        public string PictureBox { get => _PictureBox; set => _PictureBox = value; }
        public Card Card { get => _Card; set => _Card = value; }
    }
}
