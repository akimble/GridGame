using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame
{
    class Alpha : Piece
    {
        public Alpha()
        {
            moveRange = 1;
            hp = 3;
            attack = 3;
            defense = 5;
            gridPosition = 0;
        }

        protected override void MovePiece(uint gridPosition)
        {
            // account for edges of board, ex: left position edges are 0,2,6,12,16
            if (gridPosition == this.gridPosition++ || gridPosition == this.gridPosition--)
            {
                this.gridPosition = gridPosition;
                Console.WriteLine("Alpha piece moved to gridPosition " + gridPosition + ".");
            }
        }
    }
}
