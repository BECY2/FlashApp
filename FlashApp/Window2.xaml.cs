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
using System.Windows.Shapes;

namespace FlashApp
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        void Change() { 
        
            Random r = new Random();
            if (Adat.Front.Count > 0)
            {
                Randi.rand = r.Next(Adat.Front.Count);
                Question.Text = Adat.Front[Randi.rand];
                Answer.Text = "";
            }
            else
            {
                Question.Text = "Nincs szöveg";
                Answer.Text = "";
            }
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            Change();
        
        }

        private bool Active = false;

        void Check(object sender, RoutedEventArgs s) {

            if (!Active) {
                Answer.Text = Adat.Back[Randi.rand];
                Active = true;
                Check_Button.Content = "Next";
            }
            else
            {
                Change();
                Active = false;
                Check_Button.Content = "Check";
            }
        
        }
        void Back(object sender, RoutedEventArgs s)
        {

            MainWindow win = new MainWindow();
            win.Show();
            Close();

        }
    }

    public static class Randi {

        public static int rand { get; set; } = 0;    
    }
}
