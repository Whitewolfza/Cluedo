namespace Cluedo
{
    partial class Board
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
            this.pnlControls = new System.Windows.Forms.Panel();
            this.PnlBoard = new System.Windows.Forms.Panel();
            this.pnlGreen = new System.Windows.Forms.Panel();
            this.pnlWhite = new System.Windows.Forms.Panel();
            this.pnlMustard = new System.Windows.Forms.Panel();
            this.pnlPeacock = new System.Windows.Forms.Panel();
            this.pnlScarlett = new System.Windows.Forms.Panel();
            this.pnlPlum = new System.Windows.Forms.Panel();
            this.btnRoll = new System.Windows.Forms.Button();
            this.pbDice2 = new System.Windows.Forms.PictureBox();
            this.pbDice1 = new System.Windows.Forms.PictureBox();
            this.lblTurn = new System.Windows.Forms.Label();
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            this.PnlBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDice2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDice1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.btnEndTurn);
            this.pnlControls.Controls.Add(this.lblTurn);
            this.pnlControls.Controls.Add(this.btnRoll);
            this.pnlControls.Controls.Add(this.pbDice2);
            this.pnlControls.Controls.Add(this.pbDice1);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControls.Location = new System.Drawing.Point(700, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(200, 700);
            this.pnlControls.TabIndex = 1;
            // 
            // PnlBoard
            // 
            this.PnlBoard.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PnlBoard.Controls.Add(this.pnlGreen);
            this.PnlBoard.Controls.Add(this.pnlWhite);
            this.PnlBoard.Controls.Add(this.pnlMustard);
            this.PnlBoard.Controls.Add(this.pnlPeacock);
            this.PnlBoard.Controls.Add(this.pnlScarlett);
            this.PnlBoard.Controls.Add(this.pnlPlum);
            this.PnlBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBoard.Location = new System.Drawing.Point(0, 0);
            this.PnlBoard.Name = "PnlBoard";
            this.PnlBoard.Size = new System.Drawing.Size(700, 700);
            this.PnlBoard.TabIndex = 0;
            this.PnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBoard_Paint);
            // 
            // pnlGreen
            // 
            this.pnlGreen.BackColor = System.Drawing.Color.Green;
            this.pnlGreen.Location = new System.Drawing.Point(279, 658);
            this.pnlGreen.Name = "pnlGreen";
            this.pnlGreen.Size = new System.Drawing.Size(27, 27);
            this.pnlGreen.TabIndex = 5;
            // 
            // pnlWhite
            // 
            this.pnlWhite.BackColor = System.Drawing.Color.White;
            this.pnlWhite.Location = new System.Drawing.Point(412, 656);
            this.pnlWhite.Name = "pnlWhite";
            this.pnlWhite.Size = new System.Drawing.Size(27, 27);
            this.pnlWhite.TabIndex = 4;
            // 
            // pnlMustard
            // 
            this.pnlMustard.BackColor = System.Drawing.Color.Orange;
            this.pnlMustard.Location = new System.Drawing.Point(648, 211);
            this.pnlMustard.Name = "pnlMustard";
            this.pnlMustard.Size = new System.Drawing.Size(27, 27);
            this.pnlMustard.TabIndex = 3;
            // 
            // pnlPeacock
            // 
            this.pnlPeacock.BackColor = System.Drawing.Color.Blue;
            this.pnlPeacock.Location = new System.Drawing.Point(42, 439);
            this.pnlPeacock.Name = "pnlPeacock";
            this.pnlPeacock.Size = new System.Drawing.Size(25, 25);
            this.pnlPeacock.TabIndex = 2;
            // 
            // pnlScarlett
            // 
            this.pnlScarlett.BackColor = System.Drawing.Color.Red;
            this.pnlScarlett.ForeColor = System.Drawing.Color.DarkRed;
            this.pnlScarlett.Location = new System.Drawing.Point(458, 36);
            this.pnlScarlett.Name = "pnlScarlett";
            this.pnlScarlett.Size = new System.Drawing.Size(27, 27);
            this.pnlScarlett.TabIndex = 1;
            // 
            // pnlPlum
            // 
            this.pnlPlum.BackColor = System.Drawing.Color.Plum;
            this.pnlPlum.Location = new System.Drawing.Point(42, 163);
            this.pnlPlum.Name = "pnlPlum";
            this.pnlPlum.Size = new System.Drawing.Size(27, 27);
            this.pnlPlum.TabIndex = 0;
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(46, 590);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(90, 21);
            this.btnRoll.TabIndex = 9;
            this.btnRoll.Text = "Roll Dice";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // pbDice2
            // 
            this.pbDice2.Location = new System.Drawing.Point(100, 541);
            this.pbDice2.Name = "pbDice2";
            this.pbDice2.Size = new System.Drawing.Size(36, 31);
            this.pbDice2.TabIndex = 8;
            this.pbDice2.TabStop = false;
            // 
            // pbDice1
            // 
            this.pbDice1.Location = new System.Drawing.Point(46, 541);
            this.pbDice1.Name = "pbDice1";
            this.pbDice1.Size = new System.Drawing.Size(36, 31);
            this.pbDice1.TabIndex = 7;
            this.pbDice1.TabStop = false;
            // 
            // lblTurn
            // 
            this.lblTurn.AutoSize = true;
            this.lblTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTurn.Location = new System.Drawing.Point(6, 66);
            this.lblTurn.Name = "lblTurn";
            this.lblTurn.Size = new System.Drawing.Size(45, 20);
            this.lblTurn.TabIndex = 10;
            this.lblTurn.Text = "Turn";
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Location = new System.Drawing.Point(46, 617);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(90, 23);
            this.btnEndTurn.TabIndex = 11;
            this.btnEndTurn.Text = "End Turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.btnEndTurn_Click);
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.PnlBoard);
            this.Controls.Add(this.pnlControls);
            this.Name = "Board";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board";
            this.Load += new System.EventHandler(this.Board_Load);
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.PnlBoard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbDice2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDice1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlBoard;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Panel pnlGreen;
        private System.Windows.Forms.Panel pnlWhite;
        private System.Windows.Forms.Panel pnlMustard;
        private System.Windows.Forms.Panel pnlPeacock;
        private System.Windows.Forms.Panel pnlScarlett;
        private System.Windows.Forms.Panel pnlPlum;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.PictureBox pbDice2;
        private System.Windows.Forms.PictureBox pbDice1;
        private System.Windows.Forms.Label lblTurn;
        private System.Windows.Forms.Button btnEndTurn;
    }
}