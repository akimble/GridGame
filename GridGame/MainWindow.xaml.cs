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
        public MainWindow()
        {
            InitializeComponent();

            RestartGridTileAnimations();
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
            RestartGridTileAnimations();
        }
    }
}
