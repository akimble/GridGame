using System;
using System.Windows.Media.Imaging;

namespace GridGame
{
    class Beta : Piece
    {
        public Beta()
        {
            Hp = 3;
            MoveRange = 2;
            Atk = 4;
            Def = 5;

            PieceImage.Source = new BitmapImage(new Uri("Images/Beta1.png", UriKind.Relative));
            PieceType = App.GamePiece.BETA;
        }
    }
}
