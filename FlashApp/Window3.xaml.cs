using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlashApp
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        Random r = new Random();
        int hely = 0;

        int Exclud(List<int> nums)
        {
            int rr = r.Next(Adat.Back.Count);
            while (nums.Contains(rr))
            {
                rr = r.Next(Adat.Back.Count);
            }

            return rr;

        }
        void Changes() {

            Vege.Text = "";
            List<int> exe = new List<int>();
            Randi.rand = r.Next(Adat.Front.Count);
            exe.Add(Randi.rand);
            if (Adat.Front.Count > 0)
            {

                Display.Text = Adat.Front[Randi.rand];
                int randi = r.Next(3);
                if (randi == 0)
                {
                    egy.Content = Adat.Back[Randi.rand];
                    int kuki = Exclud(exe);
                    exe.Add(kuki);
                    ket.Content = Adat.Back[kuki];
                    int puki = Exclud(exe);
                    exe.Add(puki);
                    har.Content = Adat.Back[puki];
                    hely = 1;
                }
                else if (randi == 1)
                {
                    ket.Content = Adat.Back[Randi.rand];
                    int kuki = Exclud(exe);
                    exe.Add(kuki);
                    egy.Content = Adat.Back[kuki];
                    int puki = Exclud(exe);
                    exe.Add(puki);
                    har.Content = Adat.Back[puki];
                    hely = 2;
                }
                else {
                    har.Content = Adat.Back[Randi.rand];
                    int kuki = Exclud(exe);
                    exe.Add(kuki);
                    egy.Content = Adat.Back[kuki];
                    int puki = Exclud(exe);
                    exe.Add(puki);
                    ket.Content = Adat.Back[puki];
                    hely = 3;
                }
            }
            else
            {
                Display.Text = "Nincs szöveg";
            }
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {

            Changes();

        }

        bool siet = false;

        async Task Checks() {


            if (siet)
            {
                Changes();
            }

            else if (hely == 1 && egy.IsChecked == true)
            {
                egy.IsChecked = false;
                Vege.Text = "Jó válasz";
            }
            else if (hely == 2 && ket.IsChecked == true)
            {
                ket.IsChecked = false;
                Vege.Text = "jó válasz";
            }
            else if (hely == 3 && har.IsChecked == true)
            {
                har.IsChecked = false;
                Vege.Text = "jó válasz";
            }
            else
            {

                Vege.Text = "Rossz válasz";
            }
            siet = true;
            hely = 0;
            await Task.Delay(1000);
            Changes();
            siet = false;
        }

        void Chuck(object sender, RoutedEventArgs s) {

            Checks();

        }

        //void Enteren(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Return)
        //    {
        //        Changes();
        //    }
        //}
    }
}
