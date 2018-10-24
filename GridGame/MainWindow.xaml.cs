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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GridTile[] board = new GridTile[18];

        public MainWindow()
        {
            InitializeComponent();

            // Create the board - TESTING
            for (int i = 0; i < board.Length; i++)
            {
                if (i == 0)
                {
                    board[i] = new GridTile(GridTile.GamePiece.ALPHA);
                    Grid.SetRow(board[i], 0);
                    Grid.SetColumn(board[i], 2);
                }
                else if (i == 8)
                {
                    board[i] = new GridTile(GridTile.GamePiece.BETA);
                    Grid.SetRow(board[i], 2);
                    Grid.SetColumn(board[i], 2);
                }
                else
                {
                    board[i] = new GridTile(GridTile.GamePiece.NONE);
                    Grid.SetRow(board[i], i);
                    Grid.SetColumn(board[i], i);
                }
                mainGrid.Children.Add(board[i]);
            }

            //RestartGridTileAnimations();

            Alpha alpha = new Alpha();
            Beta beta = new Beta();
            alpha.SubtractHealth(1);
            beta.SubtractHealth(2);
        }

        /// <summary>
        /// Apply the slow animation to all gridTiles
        /// </summary>
        private void RestartGridTileAnimations()
        {
            foreach (GridTile gridTile in mainGrid.Children)
            {
                Image myImage;
                AnimationTimeline slowAnimation;

                myImage = gridTile.Content as Image;
                slowAnimation = Application.Current.Properties["slowAnimation"] as AnimationTimeline;

                myImage.BeginAnimation(Image.SourceProperty, slowAnimation);
            }
        }

        /// <summary>
        /// Restart all animations as slow animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridTile_MouseLeave(object sender, MouseEventArgs e)
        {
            //RestartGridTileAnimations();
        }
    }
}
