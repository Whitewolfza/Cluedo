using TrueRandom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cluedo
{
    public partial class Form1 : Form
    {
        List<Card> Rooms;
        List<Card> Suspects;
        List<Card> Weapons;
        List<Card> Mine;

        List<Card> Murder;
        List<Dice> Roller;
        int Roll;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BuildCardList();
            BuildDice();
            GetMurder();

            //TEst code
            pictureBox1.BackgroundImage = Murder[0].Item;
            pictureBox2.BackgroundImage = Murder[1].Item;
            pictureBox3.BackgroundImage = Murder[2].Item;
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
            JimRandom Random = new JimRandom();

            //Roll DIce 1
            int dice1 = Random.Next(1, 7);
            //Roll DIce 2
            int dice2 = Random.Next(1, 7);

            Roll = dice1 + dice2;


            //Test code
            pictureBox4.BackgroundImage = Roller[dice1 - 1].Picture;
            pictureBox5.BackgroundImage = Roller[dice2 - 1].Picture;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetMurder();

            //TEst code
            pictureBox1.BackgroundImage = Murder[0].Item;
            pictureBox2.BackgroundImage = Murder[1].Item;
            pictureBox3.BackgroundImage = Murder[2].Item;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RollDice();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Board frm = new Board();
            frm.ShowDialog();
        }
    }
}
