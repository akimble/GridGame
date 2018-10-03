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
            Console.WriteLine("GridTile initialized.");
        }
    }
}
