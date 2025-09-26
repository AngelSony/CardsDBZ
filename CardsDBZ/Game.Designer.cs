
namespace CardsDBZ
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bwReader = new System.ComponentModel.BackgroundWorker();
            this.lblPlayerPoints = new System.Windows.Forms.Label();
            this.lblEnemyPoints = new System.Windows.Forms.Label();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEnemyPoints = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerCards = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerHand = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerTable = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEnemyCards = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEnemyHand = new System.Windows.Forms.TableLayoutPanel();
            this.tlpEnemyTable = new System.Windows.Forms.TableLayoutPanel();
            this.tlpPlayerPoints = new System.Windows.Forms.TableLayoutPanel();
            this.btnEndAction = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.ttCard = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpEnemyPoints.SuspendLayout();
            this.tlpPlayerCards.SuspendLayout();
            this.tlpEnemyCards.SuspendLayout();
            this.tlpPlayerPoints.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwReader
            // 
            this.bwReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReader_DoWork);
            // 
            // lblPlayerPoints
            // 
            this.lblPlayerPoints.AutoSize = true;
            this.lblPlayerPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlayerPoints.Font = new System.Drawing.Font("Stencil", 20F);
            this.lblPlayerPoints.Location = new System.Drawing.Point(0, 885);
            this.lblPlayerPoints.Margin = new System.Windows.Forms.Padding(0);
            this.lblPlayerPoints.Name = "lblPlayerPoints";
            this.lblPlayerPoints.Size = new System.Drawing.Size(428, 64);
            this.lblPlayerPoints.TabIndex = 4;
            this.lblPlayerPoints.Text = "000000";
            this.lblPlayerPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEnemyPoints
            // 
            this.lblEnemyPoints.AutoSize = true;
            this.lblEnemyPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEnemyPoints.Font = new System.Drawing.Font("Stencil", 20F);
            this.lblEnemyPoints.Location = new System.Drawing.Point(0, 0);
            this.lblEnemyPoints.Margin = new System.Windows.Forms.Padding(0);
            this.lblEnemyPoints.Name = "lblEnemyPoints";
            this.lblEnemyPoints.Size = new System.Drawing.Size(260, 64);
            this.lblEnemyPoints.TabIndex = 6;
            this.lblEnemyPoints.Text = "000000";
            this.lblEnemyPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.Controls.Add(this.tlpEnemyPoints, 1, 0);
            this.tlpMain.Controls.Add(this.tlpPlayerCards, 0, 1);
            this.tlpMain.Controls.Add(this.tlpEnemyCards, 0, 0);
            this.tlpMain.Controls.Add(this.tlpPlayerPoints, 1, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(6);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(2768, 1898);
            this.tlpMain.TabIndex = 8;
            // 
            // tlpEnemyPoints
            // 
            this.tlpEnemyPoints.ColumnCount = 1;
            this.tlpEnemyPoints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpEnemyPoints.Controls.Add(this.lblEnemyPoints, 0, 0);
            this.tlpEnemyPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEnemyPoints.Location = new System.Drawing.Point(2508, 0);
            this.tlpEnemyPoints.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEnemyPoints.MaximumSize = new System.Drawing.Size(260, 0);
            this.tlpEnemyPoints.Name = "tlpEnemyPoints";
            this.tlpEnemyPoints.RowCount = 2;
            this.tlpEnemyPoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEnemyPoints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEnemyPoints.Size = new System.Drawing.Size(260, 949);
            this.tlpEnemyPoints.TabIndex = 12;
            // 
            // tlpPlayerCards
            // 
            this.tlpPlayerCards.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpPlayerCards.ColumnCount = 1;
            this.tlpPlayerCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerCards.Controls.Add(this.tlpPlayerHand, 0, 2);
            this.tlpPlayerCards.Controls.Add(this.tlpPlayerTable, 0, 0);
            this.tlpPlayerCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayerCards.Location = new System.Drawing.Point(0, 949);
            this.tlpPlayerCards.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPlayerCards.Name = "tlpPlayerCards";
            this.tlpPlayerCards.RowCount = 3;
            this.tlpPlayerCards.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlayerCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerCards.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlayerCards.Size = new System.Drawing.Size(2508, 949);
            this.tlpPlayerCards.TabIndex = 10;
            // 
            // tlpPlayerHand
            // 
            this.tlpPlayerHand.AllowDrop = true;
            this.tlpPlayerHand.ColumnCount = 2;
            this.tlpPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayerHand.Location = new System.Drawing.Point(1, 515);
            this.tlpPlayerHand.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPlayerHand.Name = "tlpPlayerHand";
            this.tlpPlayerHand.RowCount = 1;
            this.tlpPlayerHand.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlayerHand.Size = new System.Drawing.Size(2506, 433);
            this.tlpPlayerHand.TabIndex = 2;
            this.tlpPlayerHand.DragDrop += new System.Windows.Forms.DragEventHandler(this.tableLayoutPanel_DragDrop);
            this.tlpPlayerHand.DragEnter += new System.Windows.Forms.DragEventHandler(this.tableLayoutPanel_DragEnter);
            // 
            // tlpPlayerTable
            // 
            this.tlpPlayerTable.AllowDrop = true;
            this.tlpPlayerTable.ColumnCount = 2;
            this.tlpPlayerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPlayerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayerTable.Location = new System.Drawing.Point(1, 1);
            this.tlpPlayerTable.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPlayerTable.Name = "tlpPlayerTable";
            this.tlpPlayerTable.RowCount = 1;
            this.tlpPlayerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerTable.Size = new System.Drawing.Size(2506, 433);
            this.tlpPlayerTable.TabIndex = 3;
            this.tlpPlayerTable.DragDrop += new System.Windows.Forms.DragEventHandler(this.tableLayoutPanel_DragDrop);
            this.tlpPlayerTable.DragEnter += new System.Windows.Forms.DragEventHandler(this.tableLayoutPanel_DragEnter);
            // 
            // tlpEnemyCards
            // 
            this.tlpEnemyCards.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpEnemyCards.ColumnCount = 1;
            this.tlpEnemyCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEnemyCards.Controls.Add(this.tlpEnemyHand, 0, 0);
            this.tlpEnemyCards.Controls.Add(this.tlpEnemyTable, 0, 2);
            this.tlpEnemyCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEnemyCards.Location = new System.Drawing.Point(0, 0);
            this.tlpEnemyCards.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEnemyCards.Name = "tlpEnemyCards";
            this.tlpEnemyCards.RowCount = 3;
            this.tlpEnemyCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 202F));
            this.tlpEnemyCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEnemyCards.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEnemyCards.Size = new System.Drawing.Size(2508, 949);
            this.tlpEnemyCards.TabIndex = 9;
            // 
            // tlpEnemyHand
            // 
            this.tlpEnemyHand.ColumnCount = 2;
            this.tlpEnemyHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEnemyHand.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEnemyHand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEnemyHand.Location = new System.Drawing.Point(1, 1);
            this.tlpEnemyHand.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEnemyHand.Name = "tlpEnemyHand";
            this.tlpEnemyHand.RowCount = 1;
            this.tlpEnemyHand.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpEnemyHand.Size = new System.Drawing.Size(2506, 202);
            this.tlpEnemyHand.TabIndex = 3;
            // 
            // tlpEnemyTable
            // 
            this.tlpEnemyTable.ColumnCount = 2;
            this.tlpEnemyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEnemyTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpEnemyTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEnemyTable.Location = new System.Drawing.Point(1, 515);
            this.tlpEnemyTable.Margin = new System.Windows.Forms.Padding(0);
            this.tlpEnemyTable.Name = "tlpEnemyTable";
            this.tlpEnemyTable.RowCount = 1;
            this.tlpEnemyTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEnemyTable.Size = new System.Drawing.Size(2506, 433);
            this.tlpEnemyTable.TabIndex = 4;
            // 
            // tlpPlayerPoints
            // 
            this.tlpPlayerPoints.ColumnCount = 1;
            this.tlpPlayerPoints.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPlayerPoints.Controls.Add(this.lblPlayerPoints, 0, 3);
            this.tlpPlayerPoints.Controls.Add(this.btnEndAction, 0, 0);
            this.tlpPlayerPoints.Controls.Add(this.lblStatus, 0, 1);
            this.tlpPlayerPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPlayerPoints.Location = new System.Drawing.Point(2508, 949);
            this.tlpPlayerPoints.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPlayerPoints.MaximumSize = new System.Drawing.Size(300, 0);
            this.tlpPlayerPoints.Name = "tlpPlayerPoints";
            this.tlpPlayerPoints.RowCount = 4;
            this.tlpPlayerPoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlayerPoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlayerPoints.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPlayerPoints.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPlayerPoints.Size = new System.Drawing.Size(260, 949);
            this.tlpPlayerPoints.TabIndex = 11;
            // 
            // btnEndAction
            // 
            this.btnEndAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEndAction.Font = new System.Drawing.Font("Stencil", 15F);
            this.btnEndAction.Location = new System.Drawing.Point(0, 0);
            this.btnEndAction.Margin = new System.Windows.Forms.Padding(0);
            this.btnEndAction.Name = "btnEndAction";
            this.btnEndAction.Size = new System.Drawing.Size(428, 135);
            this.btnEndAction.TabIndex = 6;
            this.btnEndAction.Text = "Start Game";
            this.btnEndAction.UseVisualStyleBackColor = true;
            this.btnEndAction.Click += new System.EventHandler(this.btnEndAction_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Stencil", 10F);
            this.lblStatus.Location = new System.Drawing.Point(0, 135);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lblStatus.MaximumSize = new System.Drawing.Size(260, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(260, 32);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Cargando...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ttCard
            // 
            this.ttCard.OwnerDraw = true;
            this.ttCard.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ttCard_Draw);
            this.ttCard.Popup += new System.Windows.Forms.PopupEventHandler(this.ttCard_Popup);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2768, 1898);
            this.Controls.Add(this.tlpMain);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Game";
            this.Text = "Partida";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.tlpMain.ResumeLayout(false);
            this.tlpEnemyPoints.ResumeLayout(false);
            this.tlpEnemyPoints.PerformLayout();
            this.tlpPlayerCards.ResumeLayout(false);
            this.tlpEnemyCards.ResumeLayout(false);
            this.tlpPlayerPoints.ResumeLayout(false);
            this.tlpPlayerPoints.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwReader;
        private System.Windows.Forms.Label lblPlayerPoints;
        private System.Windows.Forms.Label lblEnemyPoints;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerCards;
        private System.Windows.Forms.TableLayoutPanel tlpEnemyCards;
        private System.Windows.Forms.TableLayoutPanel tlpEnemyPoints;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerPoints;
        private System.Windows.Forms.TableLayoutPanel tlpEnemyHand;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerHand;
        private System.Windows.Forms.TableLayoutPanel tlpPlayerTable;
        private System.Windows.Forms.TableLayoutPanel tlpEnemyTable;
        private System.Windows.Forms.Button btnEndAction;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolTip ttCard;
    }
}