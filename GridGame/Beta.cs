using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame
{
    class Beta : Piece
    {
        public Beta()
        {
            moveRange = 2;
            hp = 5;
            attack = 3;
            defense = 2;
            gridPosition = 4;
        }

        protected override void MovePiece(uint gridPosition)
        {
            uint[] legalPositions = new uint[8];

            // account for edges of board, ex: left position edges are 0,2,6,12,16
            legalPositions[0] = this.gridPosition;
            legalPositions[1] = this.gridPosition--;
            legalPositions[2] = this.gridPosition - 2;

            if (legalPositions.Contains(gridPosition))
            { 
                this.gridPosition = gridPosition;
                Console.WriteLine("Beta piece moved to gridPosition " + gridPosition + ".");
            }
        }
    }
}
