using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GridGame
{
    /// <summary>
    /// Interaction logic for GridTile.xaml
    /// </summary>
    public partial class GridTile : Button
    {
        public Piece OccupyingPiece { get; set; }

        public GridTile()
        {
            //InitializeComponent;
        }

        public GridTile(Piece gamePiece)
        {
            //InitializeComponent;

            OccupyingPiece = gamePiece;

            Content = gamePiece.PieceImage;
        }

        //public GamePiece OccupyingPiece { get; set; }

        //public enum GamePiece
        //{
        //    ALPHA, BETA, NONE
        //}

        //public GridTile()
        //{
        //    InitializeComponent();

        //    OccupyingPiece = GamePiece.NONE;
        //}

        //public GridTile(GamePiece piece)
        //{
        //    Image myImage;
            
        //    myImage = new Image();

        //    // Assign the proper game piece image to myImage
        //    if (piece == GamePiece.ALPHA)
        //    {
        //        myImage.Source = new BitmapImage(new Uri("Images/Alpha1.png", UriKind.Relative));
        //    }
        //    else if (piece == GamePiece.BETA)
        //    {
        //        myImage.Source = new BitmapImage(new Uri("Images/Beta1.png", UriKind.Relative));
        //    }

        //    // Set myImage as this GridTile's content
        //    Content = myImage;

        //    // Set this GridTile's OccupyingPiece property
        //    OccupyingPiece = piece;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine("GridTile clicked.");
        }

        /// <summary>
        /// Apply the fast animation when the mouse hovers over the gridTile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //Image myImage;
            //AnimationTimeline fastAnimation;

            //myImage = (sender as Button).Content as Image;
            //fastAnimation = Application.Current.Properties["fastAnimation"] as AnimationTimeline;

            //myImage.BeginAnimation(Image.SourceProperty, fastAnimation);
        }
    }
}
