using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
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
            for (int i = 0; i < ReaData.reaData.Count; i++)
            {
                Combo.Items.Add(ReaData.reaData[i].ID);
            }
        }
        //private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        //{
        //    Canvs.Width = e.NewSize.Width;
        //    Canvs.Height = e.NewSize.Height;
        //    // Calculate new positions based on the window size
        //    double newLeft = e.NewSize.Width; // Example: 20% from the left
        //    double newTop = e.NewSize.Height; // Example: 10% from the top
        //    double[] multiLeft = {0.15, 0.15, 0.27, 0.27, 0.57, 0.27, 0.8, 0.15, 0.305, 0.35};
        //    double[] multiTop = {0.32, 0.53, 0.33, 0.54, 0.34, 0.58, 0.8, 0.19, 0.19, 0.19};
        //    WarningText.Text = $"{newLeft} {newTop}";

        //    // Update the Button's position within the Canvas
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Canvas.SetLeft(Canvs.Children[i], newLeft * multiLeft[i]);
        //        Canvas.SetTop(Canvs.Children[i], newTop * multiTop[i]);
        //    }
         
        //}

        void OnSubmit()
        {
            void AddInput() {
                Adat.ID = Combo.SelectedItem.ToString(); ;
                Adat.Front.Add(FrontInput.Text);
                Adat.Back.Add(BackInput.Text);
                Adat.Date.Add(0);
                FrontInput.Text = "";
                BackInput.Text = "";
                WarningText.Text = "";
                FrontInput.Focus();
            }

            if (FrontInput.Text != "" && BackInput.Text != "" && Combo.SelectedItem != null)
            {
                if (Adat.ID == Combo.SelectedItem.ToString())
                {
                    AddInput();
                }
                else {
                    Adat2 dta = new Adat2();
                    dta.Change();
                    SaveSystem.SaveToJson(dta);
                    Adat.FullClear();
                    AddInput();
                }
            }
            else {
                WarningText.Text = "Can't leave it empty!";
            }
        }

        void Back(object sender, RoutedEventArgs s) {
            
            MainWindow win = new MainWindow();
            if (Adat.ID != "")
            {
                Adat2 dta = new Adat2();
                dta.Change();
                SaveSystem.SaveToJson(dta);
            }
            win.Show();
            Close();

        }


        void Submit(object sender, RoutedEventArgs s)
        {
            OnSubmit();
        }
        void OnEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                OnSubmit();
            }
        }
        void Adas(object sender, RoutedEventArgs s) {

            //int max = 0;
            //for (int i = 0; i < Combo.Items.Count; i++)
            //{
            //    max++;
            //}
            bool jo = true;
            foreach (string item in Combo.Items)
            {
                if (item == DeckName.Text) { 
                
                    jo = false;
                    break;
                }
            }
            if (jo && DeckName.Text != "")
            {
                Combo.Items.Add(DeckName.Text);
                Combo.Text = DeckName.Text;
                DeckName.Text = "";
                Rossz.Text = "";
            }
            else if (!jo)
            {
                Rossz.Text = "Deck name is already existing";
            }
            else {
                Rossz.Text = "Choose a name";
            }
        
        }

        private void DeckName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
