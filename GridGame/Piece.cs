using System.Windows.Controls;

namespace GridGame
{
    public abstract class Piece
    {
        public int Hp { get; set; }
        public int MoveRange { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public Image PieceImage { get; set; }
        public App.GamePiece PieceType { get; set; }

        public Piece() {
            PieceImage = new Image();
            PieceType = App.GamePiece.NONE;
        }
    }
}
