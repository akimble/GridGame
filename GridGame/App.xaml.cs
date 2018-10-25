using System.Windows;
using System.Windows.Media.Animation;

namespace GridGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public enum GamePiece
        {
            ALPHA, BETA, NONE
        }

        //public App()
        //{
        //    InitializeComponent();

            //ObjectAnimationUsingKeyFrames slowAnimation, fastAnimation;

            //slowAnimation = Current.FindResource("slowAnimation") as ObjectAnimationUsingKeyFrames;
            //fastAnimation = Current.FindResource("fastAnimation") as ObjectAnimationUsingKeyFrames;

            //// Store in Global dictionary
            //Current.Properties["slowAnimation"] = slowAnimation;
            //Current.Properties["fastAnimation"] = fastAnimation;
        //}
    }
}
