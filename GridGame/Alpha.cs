using System;
using System.Windows.Media.Imaging;

namespace GridGame
{
    class Alpha : Piece
    {
        public Alpha()
        {
            Hp = 5;
            MoveRange = 1;
            Atk = 3;
            Def = 2;

            PieceImage.Source = new BitmapImage(new Uri("Images/Alpha1.png", UriKind.Relative));
            PieceType = App.GamePiece.ALPHA;
        }
    }
}
