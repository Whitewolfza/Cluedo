using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrueRandom;
using System.Collections;
using DeenGames.Utils;
using DeenGames.Utils.AStarPathFinder;
using System.Diagnostics;

namespace Cluedo
{
    public partial class Board : Form
    {

        List<System.Drawing.Point> Places = new List<System.Drawing.Point>();
        int tileWidth = 28;
        int tileHeight = 28;
        int tileRows = 24;
        int tileCols = 24;

        List<Card> Rooms;
        List<Card> Suspects;
        List<Card> Weapons;
        List<Card> Mine;
        List<Card> Murder;
        List<Dice> Roller;
        int Roll;

        string CurrentPlauer;
        string CurrentPlayer;
        int iCurrentPlayer;
        List<string> Players;

        public Board()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            //initialize game
            DrawBoard();
            BuildCardList();
            BuildDice();
            GetMurder();

            //Build list of current players -testing
            Players = new List<string>();
            Players.Add("Mrs Peacock");
            Players.Add("Miss Scarlett");
            Players.Add("Reverend Green");

            //Get current player
            int start = 0;
            while (!Players.Contains(CurrentPlayer))
            {
                CurrentPlayer = Suspects[start].Name;
                GetCurrentPiece();
                start++;
            }

        }

        private void GetCurrentPiece()
        {
            switch (CurrentPlayer)
            {
                case "Colonel Mustard":
                    CurrentPlauer = "Mustard";
                    iCurrentPlayer = 0;
                    break;
                case "Miss Scarlett":
                    CurrentPlauer = "Scarlett";
                    iCurrentPlayer = 1;
                    break;
                case "Mrs Peacock":
                    CurrentPlauer = "Peacock";
                    iCurrentPlayer = 2;
                    break;
                case "Mrs White":
                    CurrentPlauer = "White";
                    iCurrentPlayer = 3;
                    break;
                case "Professor Plum":
                    CurrentPlauer = "Plum";
                    iCurrentPlayer = 4;
                    break;
                case "Reverend Green":
                    CurrentPlauer = "Green";
                    iCurrentPlayer = 5;
                    break;
            }
            lblTurn.Text = "It's " + CurrentPlayer + "'s Turn";
        }

        private void NextPlayer()
        {

            int next = iCurrentPlayer + 1;
            if (next > 5)
            {
                next = 0;
            }

            CurrentPlayer = Suspects[next].Name;
            GetCurrentPiece();
            while (!Players.Contains(CurrentPlayer))
            {
                if (next > 5)
                {
                    next = 0;
                }
                CurrentPlayer = Suspects[next].Name;
                GetCurrentPiece();
                next = iCurrentPlayer + 1;
            }
        }

        private void DrawBoard()
        {
            //Reset Size
            tileWidth = PnlBoard.Width / 25;
            tileHeight = PnlBoard.Height / 25;

            MapRooms();

            using (Bitmap sourceBmp = new Bitmap(Cluedo.Properties.Resources.Tile))
            {
                Size s = new Size(tileWidth, tileHeight);
                Rectangle destRect = new Rectangle(System.Drawing.Point.Empty, s);
                //Rows
                for (int row = 0; row < tileRows; row++)
                {
                    //Columns
                    for (int col = 0; col < tileCols; col++)
                    {
                        //Draw ovelay tiles
                        if (col == 6 && row == 6)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = s;
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 6, tileHeight * 6);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 6, 6);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 6, tileHeight * 10);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 6, 10);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 5, tileHeight * 19);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 5, 19);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 8, tileHeight * 23);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 8, 23);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 9, tileHeight * 23);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 9, 23);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 9, tileHeight * 24);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 9, 24);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 14, tileHeight * 23);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 14, 23);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 15, tileHeight * 23);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 15, 23);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 14, tileHeight * 24);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 14, 24);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 16, tileHeight * 15);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 16, 15);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 17, tileHeight * 15);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 17, 15);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                            p = new PictureBox();
                            p.Size = s;
                            loc = new System.Drawing.Point(tileWidth * 18, tileHeight * 15);
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", 18, 15);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);

                        }

                        //Draw Rooms

                        //Draw Study
                        if (col == 6 && row == 3)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 7, tileHeight * 4);
                            System.Drawing.Point loc = new System.Drawing.Point(0, 0);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardStudy;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Study";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Hall
                        if (col == 9 && row == 6)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 6, tileHeight * 7);
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 9, 0);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardHall;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Hall";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Lounge
                        if (col == 17 && row == 5)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 7, tileHeight * 6);
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 17, 0);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardLoungel;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Lounge";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Library
                        if (col == 6 && row == 6)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 7, tileHeight * 5);
                            System.Drawing.Point loc = new System.Drawing.Point(0, tileHeight * 6);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardLibrary;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Library";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Billard
                        if (col == 5 && row == 12)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 6, tileHeight * 5);
                            System.Drawing.Point loc = new System.Drawing.Point(0, tileHeight * 12);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardBillard;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Billard";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Conservatory
                        if (col == 5 && row == 19)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 6, tileHeight * 5);
                            System.Drawing.Point loc = new System.Drawing.Point(0, tileHeight * 19);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardConservatory;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Conservatory";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Ball Room
                        if (col == 8 && row == 17)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 8, tileHeight * 8);
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 8, tileHeight * 17);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardBall;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "BallRoom";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Kitchen
                        if (col == 18 && row == 18)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 6, tileHeight * 6);
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 18, tileHeight * 18);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardKitchen;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Kitchen";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Dining
                        if (col == 16 && row == 9)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 8, tileHeight * 7);
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 16, tileHeight * 9);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardDinig;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "DiningRoom";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }

                        //Draw Stairs
                        if (col == 9 && row == 8)
                        {
                            PictureBox p = new PictureBox();
                            p.Size = new Size(tileWidth * 5, tileHeight * 7);
                            System.Drawing.Point loc = new System.Drawing.Point(tileWidth * 9, tileHeight * 8);
                            p.BackgroundImage = Cluedo.Properties.Resources.BoardStairs;
                            p.BackgroundImageLayout = ImageLayout.Stretch;
                            p.Location = loc;
                            p.Tag = loc;
                            p.Name = "Stairs";
                            p.MouseDown += p_MouseDown;
                            p.BackColor = Color.Transparent;
                            PnlBoard.Controls.Add(p);
                        }


                        //Draw Tile
                        System.Drawing.Point locT = new System.Drawing.Point(tileWidth * col, tileHeight * row);
                        if (!Places.Contains(locT))
                        {
                            PictureBox p = new PictureBox();
                            p.Size = s;
                            p.Image = Cluedo.Properties.Resources.Tile;
                            p.Location = locT;
                            p.Tag = locT;
                            p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                            p.MouseDown += p_MouseDown;
                            PnlBoard.Controls.Add(p);
                        }
                    }
                }

                //Draw Players at start Position
                pnlScarlett.Size = s;
                pnlScarlett.Tag = String.Format("Col={0:00}-Row={1:00}", 16, 0);
                pnlScarlett.Location = new System.Drawing.Point(tileWidth * 16, 0);

                pnlPlum.Size = s;
                pnlPlum.Tag = String.Format("Col={0:00}-Row={1:00}", 0, 5);
                pnlPlum.Location = new System.Drawing.Point(0, tileHeight * 5);

                pnlPeacock.Size = s;
                pnlPeacock.Tag = String.Format("Col={0:00}-Row={1:00}", 0, 18);
                pnlPeacock.Location = new System.Drawing.Point(0, tileHeight * 18);

                pnlGreen.Size = s;
                pnlGreen.Tag = String.Format("Col={0:00}-Row={1:00}", 9, 24);
                pnlGreen.Location = new System.Drawing.Point(tileWidth * 9, tileHeight * 24);

                pnlWhite.Size = s;
                pnlWhite.Tag = String.Format("Col={0:00}-Row={1:00}", 14, 24);
                pnlWhite.Location = new System.Drawing.Point(tileWidth * 14, tileHeight * 24);

                pnlMustard.Size = s;
                pnlMustard.Tag = String.Format("Col={0:00}-Row={1:00}", 23, 7);
                pnlMustard.Location = new System.Drawing.Point(tileWidth * 23, tileHeight * 7);

                //this.Controls.Find(String.Format("Col={0:00}-Row={1:00}", col, row), true);
            }
        }

        private void MapRooms()
        {
            //Map Rooms

            //Study
            for (int h = 0; h < 4; h++)
            {
                for (int w = 0; w < 7; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Hall
            for (int h = 0; h < 7; h++)
            {
                for (int w = 9; w < 15; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Lounge
            for (int h = 0; h < 6; h++)
            {
                for (int w = 17; w < 24; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Library
            for (int h = 6; h < 11; h++)
            {
                for (int w = 0; w < 7; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Billard
            for (int h = 12; h < 17; h++)
            {
                for (int w = 0; w < 6; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Conservatory
            for (int h = 19; h < 24; h++)
            {
                for (int w = 0; w < 6; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Ball
            for (int h = 17; h < 25; h++)
            {
                for (int w = 8; w < 16; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Kitchen
            for (int h = 18; h < 24; h++)
            {
                for (int w = 18; w < 24; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Dining
            for (int h = 9; h < 16; h++)
            {
                for (int w = 16; w < 24; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Stairs
            for (int h = 8; h < 15; h++)
            {
                for (int w = 9; w < 14; w++)
                {
                    Places.Add(new System.Drawing.Point(tileWidth * w, tileHeight * h));
                }
            }

            //Empty Spaces
            Places.Add(new System.Drawing.Point(tileWidth * 8, tileHeight * 0));
            Places.Add(new System.Drawing.Point(tileWidth * 15, tileHeight * 0));
            Places.Add(new System.Drawing.Point(tileWidth * 23, tileHeight * 6));
            Places.Add(new System.Drawing.Point(tileWidth * 23, tileHeight * 8));
            Places.Add(new System.Drawing.Point(tileWidth * 23, tileHeight * 16));
            Places.Add(new System.Drawing.Point(tileWidth * 6, tileHeight * 23));
            Places.Add(new System.Drawing.Point(tileWidth * 17, tileHeight * 23));
            Places.Add(new System.Drawing.Point(tileWidth * 0, tileHeight * 4));
            Places.Add(new System.Drawing.Point(tileWidth * 0, tileHeight * 11));
            Places.Add(new System.Drawing.Point(tileWidth * 0, tileHeight * 17));

        }

        private void DrawGrid(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //int numOfCells = 200;
            //int cellSize = 5;
            int numOfCells = 200;
            int cellSize = 25;
            Pen p = new Pen(Color.DarkGray);

            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        private void PnlBoard_Paint(object sender, PaintEventArgs e)
        {
            //DrawGrid(e);
        }

        PictureBox currentTile;
        void p_MouseDown(object sender, MouseEventArgs e)
        {
            currentTile = (PictureBox)sender;

            //Move Player if valid block
            if (currentTile.Image == Cluedo.Properties.Resources.TileActive)
            {
                //Get PlayerPiece
                Control[] PlayerPieces = PnlBoard.Controls.Find("pnl" + CurrentPlauer, true);
                Panel player = PlayerPieces[0] as Panel;
                player.Location = currentTile.Location;
                ResetTiles();
            }

        }

        private void BuildCardList()
        {
            //Add Rooms
            Rooms = new List<Card>();
            Rooms.Add(new Card("Ball Room", Cluedo.Properties.Resources.ballroom, 1));
            Rooms.Add(new Card("Billard Room", Cluedo.Properties.Resources.billiardroom, 2));
            Rooms.Add(new Card("Dining Room", Cluedo.Properties.Resources.diningroom, 3));
            Rooms.Add(new Card("Hall", Cluedo.Properties.Resources.hall, 4));
            Rooms.Add(new Card("Kitchen", Cluedo.Properties.Resources.kitchen, 5));
            Rooms.Add(new Card("Library", Cluedo.Properties.Resources.library, 6));
            Rooms.Add(new Card("Lounge", Cluedo.Properties.Resources.lounge, 7));
            Rooms.Add(new Card("Study", Cluedo.Properties.Resources.study, 8));
            Rooms.Add(new Card("Conservatory", Cluedo.Properties.Resources.conservatory, 9));

            //Add Suspects
            Suspects = new List<Card>();
            Suspects.Add(new Card("Colonel Mustard", Cluedo.Properties.Resources.colonelmustard, 1));
            Suspects.Add(new Card("Miss Scarlett", Cluedo.Properties.Resources.missscarlett, 2));
            Suspects.Add(new Card("Mrs Peacock", Cluedo.Properties.Resources.mrspeacock, 3));
            Suspects.Add(new Card("Mrs White", Cluedo.Properties.Resources.mrswhite, 4));
            Suspects.Add(new Card("Professor Plum", Cluedo.Properties.Resources.professorplum, 5));
            Suspects.Add(new Card("Reverend Green", Cluedo.Properties.Resources.reverendgreen, 6));

            //Add Weapons
            Weapons = new List<Card>();
            Weapons.Add(new Card("Candle Stick", Cluedo.Properties.Resources.candlestick, 1));
            Weapons.Add(new Card("Dagger", Cluedo.Properties.Resources.dagger, 2));
            Weapons.Add(new Card("Lead Pipe", Cluedo.Properties.Resources.leadpipe, 3));
            Weapons.Add(new Card("Revolver", Cluedo.Properties.Resources.revolver, 4));
            Weapons.Add(new Card("Rope", Cluedo.Properties.Resources.rope, 5));
            Weapons.Add(new Card("Spanner", Cluedo.Properties.Resources.spanner, 6));

        }

        private void BuildDice()
        {
            Roller = new List<Dice>();
            Roller.Add(new Dice(1, Cluedo.Properties.Resources._1));
            Roller.Add(new Dice(2, Cluedo.Properties.Resources._2));
            Roller.Add(new Dice(3, Cluedo.Properties.Resources._3));
            Roller.Add(new Dice(4, Cluedo.Properties.Resources._4));
            Roller.Add(new Dice(5, Cluedo.Properties.Resources._5));
            Roller.Add(new Dice(6, Cluedo.Properties.Resources._6));

        }

        private void GetMurder()
        {
            Murder = new List<Card>();
            JimRandom Random = new JimRandom();

            //Get Crime Scene
            int place = Random.Next(1, 10);
            Card Scene = Rooms.Find(x => x.ID == place);

            //Get Murder Weapon
            int w = Random.Next(1, 7);
            Card Weapon = Weapons.Find(x => x.ID == w);

            //Get Victim
            int v = Random.Next(1, 7);
            Card Victim = Suspects.Find(x => x.ID == v);

            Murder.Add(Scene);
            Murder.Add(Weapon);
            Murder.Add(Victim);
        }

        private void RollDice()
        {
            ResetTiles();
            JimRandom Random = new JimRandom();

            //Roll DIce 1
            int dice1 = Random.Next(1, 7);
            //Roll DIce 2
            int dice2 = Random.Next(1, 7);

            Roll = dice1 + dice2;


            //Set Dice images
            pbDice1.BackgroundImage = Roller[dice1 - 1].Picture;
            pbDice2.BackgroundImage = Roller[dice2 - 1].Picture;

            btnRoll.Enabled = false;






            Test(Roll);






            ////Show available moves
            //Control[] lCurrent = PnlBoard.Controls.Find("pnl" + CurrentPlauer, true);
            //Panel Current = null;
            //System.Drawing.Point CurrentLoc = new System.Drawing.Point(0, 0);
            //foreach (Control c in lCurrent)
            //{
            //    Current = c as Panel;
            //    CurrentLoc = new System.Drawing.Point(c.Location.X, c.Location.Y);
            //}




            ////Dynamic map
            //List<string> possiblities = new List<string>();
            //int currentRow = CurrentLoc.Y / tileWidth;
            //int currentCol = CurrentLoc.X / tileHeight;

            ////Find all possible start blocks
            //string down = String.Format("Col={0:00}-Row={1:00}", currentCol, currentRow + 1);
            //string up = String.Format("Col={0:00}-Row={1:00}", currentCol, currentRow - 1);
            //string left = String.Format("Col={0:00}-Row={1:00}", currentCol - 1, currentRow);
            //string right = String.Format("Col={0:00}-Row={1:00}", currentCol + 1, currentRow);


            //List<string> startBlocks = new List<string>();


            ////See if down is available
            //Control[] LPossible = PnlBoard.Controls.Find(down, true);
            //if (LPossible.Length > 0)
            //{
            //    startBlocks.Add(down);
            //}

            ////See if Up is available
            //LPossible = PnlBoard.Controls.Find(up, true);
            //if (LPossible.Length > 0)
            //{
            //    startBlocks.Add(up);
            //}

            ////See if left is available
            //LPossible = PnlBoard.Controls.Find(left, true);
            //if (LPossible.Length > 0)
            //{
            //    startBlocks.Add(left);
            //}

            ////See if right is available
            //LPossible = PnlBoard.Controls.Find(right, true);
            //if (LPossible.Length > 0)
            //{
            //    startBlocks.Add(right);
            //}



            ////possiblilities 1
            //foreach (string s in startBlocks)
            //{
            //    Control[] lStarBlock = PnlBoard.Controls.Find(s, true);
            //    PictureBox startBlock = lStarBlock[0] as PictureBox;

            //    int sRow = startBlock.Location.Y / tileWidth;
            //    int sCol = startBlock.Location.X / tileHeight;

            //    //Rows
            //    for (int row = sRow; row < sRow + Roll; row++)
            //    {
            //        //Columns
            //        for (int col = sCol; col < sCol + Roll; col++)
            //        {
            //            possiblities.Add(String.Format("Col={0:00}-Row={1:00}", col, row));
            //        }
            //    }

            //    ////Rows
            //    //for (int row = sRow - Roll; row > sRow; row--)
            //    //{
            //    //    //Columns
            //    //    for (int col = sCol - Roll; col > sCol; col--)
            //    //    {
            //    //        possiblities.Add(String.Format("Col={0:00}-Row={1:00}", col, row));
            //    //    }
            //    //}

            //}



            ////Show possible moves
            //foreach (string p in possiblities)
            //{
            //    LPossible = PnlBoard.Controls.Find(p, true);
            //    if (LPossible.Length > 0)
            //    {
            //        PictureBox active = LPossible[0] as PictureBox;
            //        active.Image = Cluedo.Properties.Resources.TileActive;
            //        System.Threading.Thread.Sleep(1);
            //        Application.DoEvents();
            //    }
            //    //else
            //    //{
            //    //    break;
            //    //}
            //}

        }

        private void ResetMAP()
        {

        }

        private void ResetTiles()
        {
            List<string> RoomsTiles = new List<string>();
            RoomsTiles.Add("Study");
            RoomsTiles.Add("Hall");
            RoomsTiles.Add("Lounge");
            RoomsTiles.Add("Library");
            RoomsTiles.Add("Billard");
            RoomsTiles.Add("Conservatory");
            RoomsTiles.Add("BallRoom");
            RoomsTiles.Add("Kitchen");
            RoomsTiles.Add("DiningRoom");
            RoomsTiles.Add("Stairs");

            foreach (PictureBox pb in PnlBoard.Controls.OfType<PictureBox>())
            {
                if (!RoomsTiles.Contains(pb.Name))
                {
                    pb.Image = Cluedo.Properties.Resources.Tile;
                }
            }
        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            RollDice();
        }

        private void btnEndTurn_Click(object sender, EventArgs e)
        {
            btnRoll.Enabled = true;
            NextPlayer();

        }




        public int size = 24;
        byte[,] grid;
        PathFinder pf;

        List<Move> ValidMoves;
        private void Test(int roll)
        {
            ValidMoves = new List<Move>();
            //Show available moves
            Control[] lCurrent = PnlBoard.Controls.Find("pnl" + CurrentPlauer, true);
            Panel Current = null;
            System.Drawing.Point CurrentLoc = new System.Drawing.Point(0, 0);
            foreach (Control c in lCurrent)
            {
                Current = c as Panel;
                CurrentLoc = new System.Drawing.Point(c.Location.X, c.Location.Y);
            }


            //initialize moves
            int rol = 1;
            int rollX = CurrentLoc.X / tileHeight;
            int rollY = CurrentLoc.Y / tileWidth;
            List<Move> Possible;
            string down, up, left, right;
            
            
            List<Move> possiblelities;
            possiblelities = new List<Move>();
            bool canMove;


            //Do first move
            down = String.Format("Col={0:00}-Row={1:00}", rollX, rollY + 1);
            up = String.Format("Col={0:00}-Row={1:00}", rollX, rollY - 1);
            left = String.Format("Col={0:00}-Row={1:00}", rollX - 1, rollY);
            right = String.Format("Col={0:00}-Row={1:00}", rollX + 1, rollY);

            //Can move down?
            if (isValidMove(down))
            {
                //New Block
                //rollY = rollY + 1;
                //return;
                possiblelities.Add(new Move(down, rollX, rollY + 1));
            }
            //Can move up?
            if (isValidMove(up))
            {
                //New Block
                //rollY = rollY - 1;
                //return;
                possiblelities.Add(new Move(up, rollX, rollY - 1));
            }

            //Can move left?
            if (isValidMove(left))
            {
                //new Block
                //rollX = rollX - 1;
                //return;
                possiblelities.Add(new Move(left, rollX - 1, rollY));
            }

            //Can move right?
            if (isValidMove(right))
            {
                //new Block
                //rollX = rollX + 1;
                //return;
                possiblelities.Add(new Move(right, rollX + 1, rollY));
            }

            //Do rest of rolls
            while (rol <= roll)
            {
                Possible = new List<Move>();
                foreach (Move m in possiblelities)
                {
                    ValidMoves.Add(m);
                    Possible = ShowPossible(m.X, m.Y);
                }

                

                possiblelities = Possible;
                rol++;
            }


            //grid = new byte[size, size];

            //for (int i = 0; i < size; i++)
            //{
            //    for (int j = 0; j < size; j++)
            //    {
            //        grid[i, j] = PathFinderHelper.EMPTY_TILE;
            //    }
            //}

            //grid[1, 0] = PathFinderHelper.BLOCKED_TILE;
            //grid[1, 1] = PathFinderHelper.BLOCKED_TILE;
            //grid[3, 1] = PathFinderHelper.BLOCKED_TILE;
            //grid[4, 2] = PathFinderHelper.BLOCKED_TILE;

            //pf = new PathFinder(grid);
            //pf.Diagonals = false;

            //while (!GetPath(new DeenGames.Utils.Point(, CurrentLoc.Y / tileWidth), new DeenGames.Utils.Point((CurrentLoc.X / tileHeight) + rollX, (CurrentLoc.Y / tileWidth) + rollY)))
            //{
            //    rollY--;
            //}

        }

        List<Move> ShowPossible(int rollX, int rollY)
        {
            List<Move> possiblelities;
            possiblelities = new List<Move>();
            bool canMove;
            string down, up, left, right;


            down = String.Format("Col={0:00}-Row={1:00}", rollX, rollY + 1);
            up = String.Format("Col={0:00}-Row={1:00}", rollX, rollY - 1);
            left = String.Format("Col={0:00}-Row={1:00}", rollX - 1, rollY);
            right = String.Format("Col={0:00}-Row={1:00}", rollX + 1, rollY);

            //Can move down?
            if (isValidMove(down))
            {
                //New Block
                //rollY = rollY + 1;
                //return;
                possiblelities.Add(new Move(down, rollX, rollY + 1));
            }
            //Can move up?
            if (isValidMove(up))
            {
                //New Block
                //rollY = rollY - 1;
                //return;
                possiblelities.Add(new Move(up, rollX, rollY - 1));
            }

            //Can move left?
            if (isValidMove(left))
            {
                //new Block
                //rollX = rollX - 1;
                //return;
                possiblelities.Add(new Move(left, rollX - 1, rollY));
            }

            //Can move right?
            if (isValidMove(right))
            {
                //new Block
                //rollX = rollX + 1;
                //return;
                possiblelities.Add(new Move(right, rollX + 1, rollY));
            }

            return possiblelities;
        }

        bool isValidMove(string name)
        {
            Control[] LPossible = PnlBoard.Controls.Find(name, true);
            if (LPossible.Length > 0)
            {
                PictureBox active = LPossible[0] as PictureBox;
                active.Image = Cluedo.Properties.Resources.TileActive;
                //System.Threading.Thread.Sleep(1);
                //Application.DoEvents();
                return true;
            }

            return false;
        }


        bool GetPath(DeenGames.Utils.Point from, DeenGames.Utils.Point to)
        {
            ResetTiles();
            bool found = false;
            List<PathFinderNode> path = pf.FindPath(from, to);
            if (path != null)
            {
                //Debug.Log("Found path " + path.Count);

                foreach (PathFinderNode node in path)
                {
                    string p = String.Format("Col={0:00}-Row={1:00}", node.PX, node.PY);
                    Control[] LPossible = PnlBoard.Controls.Find(p, true);
                    if (LPossible.Length > 0)
                    {
                        PictureBox active = LPossible[0] as PictureBox;
                        active.Image = Cluedo.Properties.Resources.TileActive;
                        System.Threading.Thread.Sleep(1);
                        Application.DoEvents();
                        found = true;
                    }

                    //Debug.Log(node.PX + "x" + node.PY);
                }
            }
            else
            {
                found = false;
                //Debug.Log("No path");
            }

            return found;
        }

    }

}
