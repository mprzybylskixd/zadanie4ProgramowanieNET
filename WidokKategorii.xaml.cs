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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WidokKategorii : Window
    {
        Kategoria Kategoria { get; set; }
        DataGrid listaProduktów;
        public WidokKategorii(Kategoria kategoria)
        {
            DataContext = Kategoria = kategoria;
            InitializeComponent();
            listaProduktów = (DataGrid)FindName("ListaProduktów");
        }

        private void DodajProdukt(object sender, RoutedEventArgs e)
        {
            Kategoria.Produkty.Add(new());
        }

        private void UsuńProdukty(object sender, RoutedEventArgs e)
        {
            if (listaProduktów.SelectedItem is Produkt selectedProdukt)
            {
                Kategoria.Produkty.Remove(selectedProdukt);
            }
        }
    }
}
