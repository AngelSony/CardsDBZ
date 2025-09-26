using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class Player
    {
        private List<Card> _Hand;
        private List<Card> _Table;
        private List<Card> _DiscardDeck;
        private List<Card> _MainDeck;
        private int _Points;
        private int _PlayerNumber;
        private int _HandSize;
        private bool _IsEnemy;
        private PlayerAction _PlayerAction;
        public Player()
        {
            _HandSize = 7;
            _Points = 500;
            _Hand = new List<Card> { };
            _Table = new List<Card> { };
            _DiscardDeck = new List<Card> { };
            _MainDeck = new List<Card> { };
        }
        public Player(int playernumber, bool isEnemy) : this()
        {
            _IsEnemy = isEnemy;
            if (!_IsEnemy)
            {
                _PlayerNumber = playernumber;
                LoadCards();
                _MainDeck.Shuffle();
                DrawCards();
            }
            else
            {
                _Hand = new List<Card> { };
                for (int i = 0; i < 7; i++)
                {
                    _Hand.Add(new Card(0));
                }
                _Table = new List<Card> { };
            }
        }
        private void LoadCards()
        {
            _MainDeck = Database.GetCards();
        }
        public void DrawCards()
        {
            int cardsToDraw = _HandSize - _Hand.Count();
            if (cardsToDraw != 0)
            {
                if (!_IsEnemy)
                {
                    for (int i = 0; i < cardsToDraw; i++)
                    {
                        _Hand.Add(_MainDeck[0]);
                        _MainDeck.RemoveAt(0);
                    }
                }
                else
                {
                    for (int i = 0; i < cardsToDraw; i++)
                    {
                        _Hand.Add(new Card(0));
                    }
                }
            }
        }
        public int Points { get => _Points; set => _Points = value; }
        public int PlayerNumber { get => _PlayerNumber; set => _PlayerNumber = value; }
        public int HandSize { get => _HandSize; set => _HandSize = value; }
        internal List<Card> Hand { get => _Hand; set => _Hand = value; }
        internal List<Card> Table { get => _Table; set => _Table = value; }
        internal List<Card> DiscardDeck { get => _DiscardDeck; set => _DiscardDeck = value; }
        internal List<Card> MainDeck { get => _MainDeck; set => _MainDeck = value; }
        public bool IsEnemy { get => _IsEnemy; set => _IsEnemy = value; }
        internal PlayerAction playerAction { get => _PlayerAction; set => _PlayerAction = value; }
        public enum PlayerAction
        {
            Attacking,
            Defending,
            EndingTurn
        }
    }
}
