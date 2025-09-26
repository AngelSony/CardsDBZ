using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    class Table
    {
        private int _Turn;
        private TurnStages _TurnStage;
        private Connection _Conn;
        private bool _Ongoing;
        private List<Card> _AttackCards;
        private List<Card> _DefenseCards;
        private int _Damage;

        public Table(Connection conn)
        {
            _Conn = conn;
            _TurnStage = TurnStages.Starting;
        }
        public GameAction Reader(int player)
        {
            try
            {
                if (_Conn.clients[player].Connected)
                {
                    Message msj = _Conn.Recieve(player);
                    if (msj.ObjType.Equals(typeof(GameAction)))
                    {
                        GameAction act = ((Newtonsoft.Json.Linq.JObject)msj.Obj).ToObject<GameAction>();
                        return act;
                    }
                    else
                    {
                        throw new Exception("Tipo no contemplado.");
                    }
                }
                else
                {
                    throw new Exception("Jugador no conectado.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async void StartGame()
        {
            for (int i = 0; i < 2; i++)
            {
                GameAction act = new GameAction(GameAction.Actions.StartGame);
                act.Player = i;
                Message msj = new Message(act, typeof(GameAction));
                _Conn.Send(msj, i);
            }

            await Task.Run(() =>
            {
                if (Reader(0).ActionType.Equals(GameAction.Actions.ConfirmStart))
                    Console.WriteLine("Jugador 0 listo");
            });
            await Task.Run(() =>
            {
                if (Reader(1).ActionType.Equals(GameAction.Actions.ConfirmStart))
                    Console.WriteLine("Jugador 1 listo");
            });

            _Ongoing = true;
            _Turn = 0;
            _TurnStage = TurnStages.Attacking;
            Console.WriteLine("Juego Iniciado");
            while (_Ongoing)
            {
                switch (_TurnStage)
                {
                    case TurnStages.Attacking:
                        Attack(_Turn);
                        break;
                    case TurnStages.Defending:
                        Deffend(_Turn);
                        break;
                    case TurnStages.ShowResult:
                        ShowResult(_Turn);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("Juego Terminado");
        }
        public void Attack(int turn)
        {
            GameAction act = new GameAction(GameAction.Actions.StartAttack);
            Message msj = new Message(act, typeof(GameAction));
            _Conn.Send(msj, turn);

            GameAction reAct = Reader(turn);
            if (reAct.ActionType.Equals(GameAction.Actions.EndAttack))
            {
                _AttackCards = reAct.Cards;
            }
            _TurnStage = TurnStages.Defending;
        }
        public void Deffend(int turn)
        {
            turn = SwitchTurn(turn);
            GameAction act = new GameAction(GameAction.Actions.StartDefense);
            act.Cards = _AttackCards;
            Message msj = new Message(act, typeof(GameAction));
            _Conn.Send(msj, turn);

            GameAction reAct = Reader(turn);
            if (reAct.ActionType.Equals(GameAction.Actions.EndDefense))
            {
                _DefenseCards = reAct.Cards;
            }
            _TurnStage = TurnStages.ShowResult;
        }
        public void ShowResult(int turn)
        {
            _Damage = ComputeDamage();
            //Message to defender
            GameAction act1 = new GameAction(GameAction.Actions.ShowResult);
            act1.Damage = _Damage;
            Message msj1 = new Message(act1, typeof(GameAction));
            _Conn.Send(msj1, SwitchTurn(turn));

            //Message to attacker
            GameAction act0 = new GameAction(GameAction.Actions.ShowResult);
            act0.Damage = _Damage;
            act0.Cards = _DefenseCards;
            Message msj0 = new Message(act0, typeof(GameAction));
            _Conn.Send(msj0, turn);

            GameAction reAct = Reader(turn);
            if (reAct.ActionType.Equals(GameAction.Actions.EndTurn))
            {
                _DefenseCards = null;
                _AttackCards = null;
                _Damage = 0;
            }
            _Turn = SwitchTurn(_Turn);
            _TurnStage = TurnStages.Attacking;
        }
        public int SwitchTurn(int turn)
        {
            return (turn + 1) % 2;
        }
        public int ComputeDamage()
        {
            int damage;
            damage = ComputeAttack() - ComputeDefense();
            if (damage < 0)
            {
                damage = 0;
            }
            return damage;
        }
        public int ComputeAttack()
        {
            int sum = 0;
            foreach (Card c in _AttackCards)
            {
                sum += c.AtkPoints;
            }
            return sum;
        }
        public int ComputeDefense()
        {
            int sum = 0;
            foreach (Card c in _DefenseCards)
            {
                sum += c.DefPoints;
            }
            return sum;
        }
        public int Turn { get => _Turn; set => _Turn = value; }
        internal TurnStages TurnStage { get => _TurnStage; set => _TurnStage = value; }
        public bool Ongoing { get => _Ongoing; set => _Ongoing = value; }
        public enum TurnStages
        {
            Starting,
            DrawingCards,
            Attacking,
            Defending,
            ShowResult
        }
    }
}
