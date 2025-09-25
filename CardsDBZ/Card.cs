using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class Card
    {
        private int _IDCard;
        private int _PlayerOwner;
        private string _Description;
        private string _Title;
        private int _AtkPoints;
        private int _DefPoints;
        private List<int> _DragonBalls;

        public Card() { }
        public Card(int idCard) : this()
        {
            _IDCard = idCard;
        }
        public Card(int idcard, int atkpoints, int defpoints, List<int> dragonBalls, string title, string description) : this()
        {
            _IDCard = idcard;
            _AtkPoints = atkpoints;
            _DefPoints = defpoints;
            _Title = title;
            _Description = description;
            _DragonBalls = dragonBalls;
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Card c = (Card)obj;
                return (ID == c.ID);
            }
        }
        public string ID
        {
            get => _PlayerOwner.ToString() + "_" + _IDCard.ToString();
        }
        public int IDCard { get => _IDCard; set => _IDCard = value; }
        public int PlayerOwner { get => _PlayerOwner; set => _PlayerOwner = value; }
        public string Description { get => _Description; set => _Description = value; }
        public string Title { get => _Title; set => _Title = value; }
        public int AtkPoints { get => _AtkPoints; set => _AtkPoints = value; }
        public int DefPoints { get => _DefPoints; set => _DefPoints = value; }
        public List<int> DragonBalls { get => _DragonBalls; set => _DragonBalls = value; }
    }
}
