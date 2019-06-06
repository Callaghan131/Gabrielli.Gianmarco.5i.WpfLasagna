using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Gabrielli.Gianmarco._5i.WpfLasagna
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        async private void Visualizzazione(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient(); //Creazione client
                //Riempimento lista "lasagna" preso da un url convertito in json
                List<Lasagna> lasagne = JsonConvert.DeserializeObject<List<Lasagna>>(await client.GetStringAsync("https://flr.azurewebsites.net/api/lasagna"));
                lvw_info.ItemsSource = lasagne;
            }
            catch (Exception errore)
            {
                MessageBox.Show(errore.Message);
            }
        }

        public class Lasagna
        {
            public string nome { get; set; }
            public string peso { get; set; }
            public string stringpeso { get { return $"Peso: {peso}"; } }
            public string urlfoto { get; set; }
        }
    }
}
