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
        public GridTile()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("GridTile clicked.");
        }

        /// <summary>
        /// Apply the fast animation when the mouse hovers over the gridTile
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Image myImage;
            AnimationTimeline fastAnimation;

            myImage = (sender as Button).Content as Image;
            fastAnimation = Application.Current.Properties["fastAnimation"] as AnimationTimeline;

            myImage.BeginAnimation(Image.SourceProperty, fastAnimation);
        }
    }
}
