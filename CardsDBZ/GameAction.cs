using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class GameAction
    {
        private Actions _ActionType;
        private List<Card> _Cards;
        private int _Player;
        private int _Damage;
        public GameAction() { }
        public GameAction(Actions act)
        {
            _ActionType = act;
        }
        public Actions ActionType { get => _ActionType; set => _ActionType = value; }
        public List<Card> Cards { get => _Cards; set => _Cards = value; }
        public int Player { get => _Player; set => _Player = value; }
        public int Damage { get => _Damage; set => _Damage = value; }
        public enum Actions
        {
            //Client actions
            ConfirmStart,
            EndAttack,
            EndDefense,
            EndTurn,

            //Server actions
            StartGame,
            StartAttack,
            StartDefense,
            ShowResult
        }
    }
}
