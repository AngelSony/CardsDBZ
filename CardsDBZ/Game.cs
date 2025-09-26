using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CardsDBZ.Functions;

namespace CardsDBZ
{
    public partial class Game : Form
    {
        private Connection conn;
        private Player player;
        private Player enemy;
        private bool myTurn;

        public Game()
        {
            InitializeComponent();
            myTurn = false;
        }
        public Game(int port, string ip) : this()
        {
            Join(port, ip);
        }
        private void Join(int port, string ip)
        {
            try
            {
                conn = new Connection();
                conn.Join(port, ip);
                btnEndAction.Visible = false;
                lblStatus.Text = "Waiting for Host to Start";

                bwReader.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DoAction(GameAction act)
        {
            switch (act.ActionType)
            {
                case GameAction.Actions.StartGame:
                    StartGame(act);
                    break;
                case GameAction.Actions.StartAttack:
                    StartAttack();
                    break;
                case GameAction.Actions.StartDefense:
                    StartDefense(act);
                    break;
                case GameAction.Actions.ShowResult:
                    ShowResult(act);
                    break;
                default:
                    break;
            }
        }
        private void StartGame(GameAction act)
        {
            player = new Player(act.Player, false);
            enemy = new Player((act.Player + 1) % 2, true);
            this.Invoke(new Action(() =>
            {
                DrawCards(tlpEnemyHand, enemy.Hand);
                DrawCards(tlpPlayerHand, player.Hand);
                lblPlayerPoints.Text = player.Points.ToString();
                lblEnemyPoints.Text = enemy.Points.ToString();
                lblStatus.Text = "El rival está atacando";
            }));
            GameAction reAct = new GameAction(GameAction.Actions.ConfirmStart);
            Message msj = new Message(reAct, typeof(GameAction));
            conn.Send(msj);
        }
        private void StartAttack()
        {
            player.Table.Clear();
            player.DrawCards();
            enemy.Table.Clear();
            this.Invoke(new Action(() =>
            {
                DrawCards(tlpEnemyTable, enemy.Table);
                DrawCards(tlpPlayerTable, player.Table);
                DrawCards(tlpPlayerHand, player.Hand);
            }));
            myTurn = true;
            player.playerAction = Player.PlayerAction.Attacking;
            this.Invoke(new Action(() =>
            {
                btnEndAction.Enabled = true;
                btnEndAction.Text = "Finalizar Ataque";
                btnEndAction.Visible = true;
                lblStatus.Visible = false;
            }));
        }
        private void StartDefense(GameAction act)
        {
            enemy.Table = act.Cards;
            for (int i = 0; i < enemy.Table.Count; i++)
            {
                enemy.Hand.RemoveAt(0);
            }
            this.Invoke(new Action(() =>
            {
                DrawCards(tlpEnemyHand, enemy.Hand);
                DrawCards(tlpEnemyTable, enemy.Table);
            }));
            myTurn = true;
            player.playerAction = Player.PlayerAction.Defending;
            this.Invoke(new Action(() =>
            {
                btnEndAction.Text = "Finalizar Defensa";
                btnEndAction.Visible = true;
                lblStatus.Visible = false;
            }));
        }
        private void ShowResult(GameAction act)
        {
            if (player.playerAction.Equals(Player.PlayerAction.Defending))
            {
                //If player was defending
                player.Points -= act.Damage;
                this.Invoke(new Action(() =>
                {
                    lblPlayerPoints.Text = player.Points.ToString();
                    lblStatus.Text = "Esperando a que el rival finalice su turno";
                }));
            }
            else
            {
                //If player was attacking
                player.playerAction = Player.PlayerAction.EndingTurn;
                enemy.Points -= act.Damage;
                enemy.Table = act.Cards;
                for (int i = 0; i < enemy.Table.Count; i++)
                {
                    enemy.Hand.RemoveAt(0);
                }
                this.Invoke(new Action(() =>
                {
                    lblEnemyPoints.Text = enemy.Points.ToString();
                    DrawCards(tlpEnemyHand, enemy.Hand);
                    DrawCards(tlpEnemyTable, enemy.Table);
                    btnEndAction.Text = "Finalizar Turno";
                    btnEndAction.Enabled = true;
                    lblStatus.Visible = false;
                }));
            }
        }
        private void DrawCards(TableLayoutPanel tlp, List<Card> cards)
        {
            LoadPictureBox(tlp, cards.Count);
            for (int i = 0; i < tlp.Controls.Count; i++)
            {
                PictureBox pBox = (PictureBox)tlp.Controls[i];
                if (i < cards.Count())
                {
                    pBox.Tag = cards[i];
                    //pBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(cards[i].CardImage);
                    pBox.Image = ImageMaker.GetImage(cards[i]);
                    pBox.Width = 150;
                }
                else
                {
                    pBox.Tag = null;
                    pBox.Image = null;
                    pBox.Width = 0;
                }
            }
        }
        private void LoadPictureBox(TableLayoutPanel tlp, int count)
        {
            string type = GetContainerType(tlp.Name);
            tlp.Controls.Clear();
            tlp.ColumnStyles.Clear();
            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            for (int i = 1; i <= count; i++)
            {
                PictureBox pBox = new PictureBox();
                ((ISupportInitialize)pBox).BeginInit();
                pBox.Dock = DockStyle.Bottom;
                pBox.InitialImage = null;
                pBox.Location = new Point(0, 0);
                pBox.Margin = new Padding(0);
                pBox.Name = "pb" + type + "_" + i.ToString();
                pBox.SizeMode = PictureBoxSizeMode.Zoom;
                pBox.TabIndex = 0;
                pBox.TabStop = false;
                pBox.AllowDrop = false;
                if (type.Contains("Player"))
                {
                    pBox.MouseDown += new MouseEventHandler(pictureBox_MouseDown);
                }
                ColumnStyle cStyle = new ColumnStyle();
                switch (type)
                {
                    case "EnemyHand":
                        pBox.Size = new Size(0, 105);
                        cStyle = new ColumnStyle(SizeType.Absolute, 70);
                        break;
                    default:
                        pBox.Size = new Size(0, 225);
                        break;
                }
                ttCard.SetToolTip(pBox, "Card");
                tlp.ColumnCount++;
                tlp.ColumnStyles.Insert(tlp.ColumnCount - 2, cStyle);
                tlp.Controls.Add(pBox, tlp.ColumnCount - 2, 0);
                ((ISupportInitialize)pBox).EndInit();
            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (myTurn)
            {
                PictureBox pBox = (PictureBox)sender;
                Card cardMoved = (Card)pBox.Tag;
                if (cardMoved == null) return;
                CardDrop cd = new CardDrop(cardMoved, pBox.Name);
                if (DoDragDrop(ObjectToString(cd), DragDropEffects.Move) == DragDropEffects.Move)
                {
                    DrawCards(tlpPlayerHand, player.Hand);
                    DrawCards(tlpPlayerTable, player.Table);
                }
            }
        }
        private void tableLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text) &&
                MovementAllowed(StringToObject<CardDrop>((string)e.Data.GetData(DataFormats.Text)).PictureBox, ((TableLayoutPanel)sender).Name))
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        private void tableLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            TableLayoutPanel tlp = (TableLayoutPanel)sender;
            CardDrop cd = StringToObject<CardDrop>((string)e.Data.GetData(DataFormats.Text));
            Card movedCard = cd.Card;

            if (tlp.Name.Contains("PlayerTable") && cd.PictureBox.Contains("PlayerHand"))
            {
                player.Table.Add(movedCard);
                player.Hand.Remove(movedCard);
            }
            else
            {
                player.Hand.Add(movedCard);
                player.Table.Remove(movedCard);
            }
        }
        private void bwReader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (conn.clients[0].Connected)
                {
                    Message msj = conn.Receive(0);

                    if (msj.ObjType.Equals(typeof(GameAction)))
                    {
                        GameAction act = ((Newtonsoft.Json.Linq.JObject)msj.Obj).ToObject<GameAction>();
                        new Task(() => { DoAction(act); }).Start();
                    }
                    else
                    {
                        MessageBox.Show("Tipo no contemplado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }
        private void btnEndAction_Click(object sender, EventArgs e)
        {
            switch (player.playerAction)
            {
                case Player.PlayerAction.Attacking:
                    EndAttack();
                    break;
                case Player.PlayerAction.Defending:
                    EndDefense();
                    break;
                case Player.PlayerAction.EndingTurn:
                    EndTurn();
                    break;
                default:
                    break;
            }
        }
        private void EndAttack()
        {
            if (player.Table.Count != 0)
            {
                btnEndAction.Enabled = false;
                myTurn = false;
                GameAction act = new GameAction(GameAction.Actions.EndAttack);
                act.Player = player.PlayerNumber;
                act.Cards = player.Table;
                Message msj = new Message(act, typeof(GameAction));
                conn.Send(msj);
                lblStatus.Text = "El rival se está defendiendo";
            }
            else
            {
                MessageBox.Show("Debes seleccionar cartas para atacar");
            }
        }
        private void EndDefense()
        {
            if (player.Table.Count != 0)
            {
                btnEndAction.Enabled = false;
                myTurn = false;
                GameAction act = new GameAction(GameAction.Actions.EndDefense);
                act.Player = player.PlayerNumber;
                act.Cards = player.Table;
                Message msj = new Message(act, typeof(GameAction));
                conn.Send(msj);
                lblStatus.Text = "El servidor está calculando el resultado";
            }
            else
            {
                MessageBox.Show("Debes seleccionar cartas para defender");
            }
        }
        private void EndTurn()
        {
            btnEndAction.Visible = false;
            GameAction act = new GameAction(GameAction.Actions.EndTurn);
            act.Player = player.PlayerNumber;
            Message msj = new Message(act, typeof(GameAction));
            conn.Send(msj);

            player.Table.Clear();
            enemy.Table.Clear();
            enemy.DrawCards();
            DrawCards(tlpEnemyHand, enemy.Hand);
            DrawCards(tlpEnemyTable, enemy.Table);
            DrawCards(tlpPlayerTable, player.Table);
            lblStatus.Text = "El rival está atacando";
            lblStatus.Visible = true;
        }
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr h, int x, int y, int width, int height, bool redraw);
        private void ttCard_Draw(object sender, DrawToolTipEventArgs e)
        {

            var t = (ToolTip)sender;
            var h = t.GetType().GetProperty("Handle",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var handle = (IntPtr)h.GetValue(t);
            Point screenPos = Cursor.Position;
            Point formPos = PointToClient(screenPos);
            if (formPos.X + 350 > Size.Width) screenPos.X -= 350;
            if (formPos.Y + 525 > Size.Height) screenPos.Y -= 525;
            MoveWindow(handle, screenPos.X, screenPos.Y, e.Bounds.Width, e.Bounds.Height, false);
            e.Graphics.DrawImage(((PictureBox)e.AssociatedControl).Image, 0, 0, 350, 525);
        }
        private void ttCard_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = new Size(350, 525);
        }
    }
}
