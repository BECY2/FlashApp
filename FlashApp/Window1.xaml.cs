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

        void OnSubmit()
        {
            void AddInput() {
                Adat.ID = Convert.ToInt32(Combo.SelectedItem);
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
                if (Adat.ID == Convert.ToInt32(Combo.SelectedItem))
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
            if (Adat.ID != 0)
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
        
            int max = 0;
            for (int i = 0; i < Combo.Items.Count; i++)
            {
                max++;
            }
            Combo.Items.Add(max + 1);
        
        }

    }
}
