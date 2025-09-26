using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardsDBZ
{
    public partial class Main : Form
    {
        private string playerType;
        private Game formGame;
        private Connection conn;
        private Table table;
        public Main()
        {
            InitializeComponent();

            Fonts.LoadFonts();

            txtIp.Text = Connection.MyLocalIp();
            txtPort.Text = "25255";
        }
        private async Task Host(int port)
        {
            conn = new Connection();

            await Task.Run(() =>
            {
                int jugadores = 0;
                while (jugadores < 2)
                {
                    conn.Host(port);
                    jugadores++;
                    Console.WriteLine("Player " + jugadores.ToString() + " connected");
                }
            });

            MessageBox.Show("¿Iniciar juego?");

            await Task.Run(() =>
            {
                table = new Table(conn);
                try
                {
                    table.StartGame();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnJoin_Click(object sender, EventArgs e)
        {
            playerType = "Client";
            int port = int.Parse(txtPort.Text);
            string ip = txtIp.Text;

            //Open formGame
            formGame = new Game(port, ip);
            formGame.Show(this);
            this.Hide();
        }
        private void btnHost_Click(object sender, EventArgs e)
        {
            playerType = "Host";
            int port = int.Parse(txtPort.Text);
            string ip = txtIp.Text;

            //Host game
            Host(port);

            //Open formGame
            formGame = new Game(port, ip);
            formGame.Show(this);

            this.Hide();
        }
    }
}
