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
using Newtonsoft.Json;
using System.IO;



namespace FlashApp
{

    public static class SaveSystem
    {

        public static void ReadFromJson()
        {

            string filePath = "Data.json";
            // Read the existing JSON data from the file
            string json = File.ReadAllText(filePath);
            List<Adat2> dta = JsonConvert.DeserializeObject<List<Adat2>>(json);
            ReaData.reaData = dta;
        }

        public static void SaveToJson(Adat2 data)
        {
            string filePath = "Data.json";
            if (File.Exists(filePath))
        {
                // Read the existing JSON data from the file
                string json = File.ReadAllText(filePath);
                List<Adat2> dta = JsonConvert.DeserializeObject<List<Adat2>>(json);
                bool newe = true;
                for (int i = 0; i < dta.Count; i++)
                {
                    if (dta[i].ID == data.ID)
                    {

                        dta[i].Front.AddRange(data.Front);
                        dta[i].Back.AddRange(data.Back);
                        dta[i].Date.AddRange(data.Date);
                        newe = false;
                    }
                }
                if (newe)
                {
                    Adat2 newAdat = data;
                    dta.Add(newAdat);
                }
                string updatedJson = JsonConvert.SerializeObject(dta, Formatting.Indented);
                File.WriteAllText(filePath, updatedJson);
            }
            else
            {
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(filePath, json);
            }
        }

    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboLoad(object sender, RoutedEventArgs e) {

            SaveSystem.ReadFromJson();
            for (int i = 0; i < ReaData.reaData.Count; i++)
            {
                Choose.Items.Add(ReaData.reaData[i].ID);
            }
        }

        void Plusz(object sender, RoutedEventArgs s) {

            Window1 AddWindow = new Window1();
            AddWindow.Show();
            Close();
        }

        void Practice(object sender, RoutedEventArgs s)
        {

            if (Choose.SelectedItem != null)
            {

                Window2 PracticeWindow = new Window2();
                for (int i = 0; i < ReaData.reaData.Count; i++) {

                    if (ReaData.reaData[i].ID == Choose.SelectedItem.ToString()) {

                        Adat.Csere(ReaData.reaData[i]);
                        break;
                    }
                }
                PracticeWindow.Show();
                Close();
            }
            else {

                Bena.Text = "Choose a deck";
            }

        }

        void Tip(object sender, RoutedEventArgs s) {

            if (Choose.SelectedItem != null)
            {
                
                for (int i = 0; i < ReaData.reaData.Count; i++)
                {

                    if (ReaData.reaData[i].ID == Choose.SelectedItem.ToString())
                    {

                        Adat.Csere(ReaData.reaData[i]);
                        break;
                    }
                }

                if (Adat.Front.Count < 3)
                {

                    Bena.Text = "You have to have at least 3 card in yor deck";
                }
                else
                {
                    Window3 TipWindow = new Window3();
                    TipWindow.Show();
                    Close();
                }
            }
            else
            {

                Bena.Text = "Choose a deck";
            }
        }
    }

    public static class Adat
    {
        public static void Csere(Adat2 dta) {

            ID = dta.ID;
            Front = dta.Front;
            Back = dta.Back;
            Date = dta.Date;

        }

        public static void FullClear() { 
            
            ID = "";
            Front.Clear();
            Back.Clear();
            Date.Clear();
        
        }

        public static string ID { get; set; }
        //Declare a static List to serve as a global list
        public static List<string> Front { get; set; } = new List<string>();
        public static List<string> Back { get; set; } = new List<string>();
        public static List<int> Date { get; set; } = new List<int>();
    }

    public class Adat2
    {
        public void Change()
        {
            ID = Adat.ID;
            Front = Adat.Front;
            Back = Adat.Back;
            Date = Adat.Date;
        }
        public string ID { get; set; }
        public List<string> Front = new List<string>();
        public List<string> Back = new List<string>();
        public List<int> Date = new List<int>();

    }

    public static class ReaData { 

        public static List<Adat2> reaData { get; set; } = new List<Adat2>();
    }

}
