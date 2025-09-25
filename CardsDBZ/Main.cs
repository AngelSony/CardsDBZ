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
    public partial class formMain : Form
    {
        private string playerType;
        private Connection conn;
        public formMain()
        {
            InitializeComponent();

            txtIp.Text = Connection.MyLocalIp();
            txtPort.Text = "25255";
        }
        private async Task Host(int port)
        {

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
            //this.Hide();
        }
        private void btnHost_Click(object sender, EventArgs e)
        {
            playerType = "Host";
            int port = int.Parse(txtPort.Text);
            string ip = txtIp.Text;
            //Host game

            //Open formGame

            //this.Hide();
        }
    }
}
