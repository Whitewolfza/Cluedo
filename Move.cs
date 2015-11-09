using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cluedo
{
    public class Move
    {
        public string ConrtrolName
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public Move(string name, int x, int y)
        {
            ConrtrolName = name;
            X = x;
            Y = y;
        }
    }
}
