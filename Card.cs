using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    public class Card
    {
        public string Name
        {
            get;
            set;
        }

        public Image Item
        {
            get;
            set;
        }
        public int ID
        {
            get;
            set;
        }

        public Card(string name, Image card, int id)
        {
            Name = name;
            Item = card;
            ID = id;
        }
    }
}
