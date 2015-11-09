using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    public class Dice
    {
        public int Value
        {
            get;
            set;
        }

        public Image Picture
        {
            get;
            set;
        }

        public Dice(int value, Image picture)
        {
            Value = value;
            Picture = picture;
        }
    }
}
