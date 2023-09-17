using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        void OnSubmit()
        {

            if (FrontInput.Text != "" && BackInput.Text != "")
            {
                Adat.Front.Add(FrontInput.Text);
                Adat.Back.Add(BackInput.Text);
                Adat.Date.Add(0);
                FrontInput.Text = "";
                BackInput.Text = "";
                WarningText.Text = "";
                FrontInput.Focus();
            }
            else {
                WarningText.Text = "Can't leave it empty!";
            }
        }

        void Back(object sender, RoutedEventArgs s) { 
        
            MainWindow win = new MainWindow();
            win.Show();
            Close();
        
        }


        void Submit(object sender, RoutedEventArgs s)
        {
        //    data.Front.Add(FrontInput.Text);
        //    data.Back.Add(BackInput.Text);
        //    data.Date.Add(0);
        //    FrontInput.Text = "";
        //    BackInput.Text = "";
        //    FrontInput.Focus();
            OnSubmit();
        }
        void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                OnSubmit();
            }
        }
    }
}
