using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace GridGame
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ObjectAnimationUsingKeyFrames slowAnimation, fastAnimation;

            slowAnimation = Current.FindResource("slowAnimation") as ObjectAnimationUsingKeyFrames;
            fastAnimation = Current.FindResource("fastAnimation") as ObjectAnimationUsingKeyFrames;

            // Store in Global dictionary
            Current.Properties["slowAnimation"] = slowAnimation;
            Current.Properties["fastAnimation"] = fastAnimation;
        }
    }
}
