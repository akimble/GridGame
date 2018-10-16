using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame
{
    abstract class Piece
    {
        protected uint moveRange;
        protected int hp;
        protected int attack;
        protected int defense;
        protected uint gridPosition;

        protected abstract void MovePiece(uint gridPosition);
        
        public void SubtractHealth(int enemyAtk)
        {
            hp -= enemyAtk + defense;
            Console.WriteLine(hp);
        }
    }
}
