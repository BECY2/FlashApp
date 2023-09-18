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

namespace FlashApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        void Plusz(object sender, RoutedEventArgs s) {

            Window1 AddWindow = new Window1();
            AddWindow.Show();
            Close();
        }

        void Practice(object sender, RoutedEventArgs s)
        {

            Window2 PracticeWindow = new Window2();
            PracticeWindow.Show();
            Close();

        }

        void Tip(object sender, RoutedEventArgs s) { 
        
            Window3 TipWindow = new Window3();
            TipWindow.Show();
            Close();
        }
    }

    public static class Adat
    {
        // Declare a static List to serve as a global list
        public static List<string> Front { get; } = new List<string>();
        public static List<string> Back { get; } = new List<string>();
        public static List<int> Date { get; } = new List<int>();
    }


}
//public class Adat
//{

//    public List<string> Front = new List<string>();
//    public List<string> Back = new List<string>();
//    public List<int> Date = new List<int>();

//}