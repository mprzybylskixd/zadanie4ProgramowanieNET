using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WidokListyKategorii : Window
    {
        private const string ŚcieżkaIO = "C:\\Users\\karol\\source\\repos\\WpfApp7\\WpfApp7\\Produkty.xml";
        ListBox listaKategorii;
        ObservableCollection<Kategoria> kategorie = new ObservableCollection<Kategoria>();
        public WidokListyKategorii()
        {
            DataContext = kategorie;
            InitializeComponent();
            listaKategorii = (ListBox)FindName("ListaKategorii");
        }

        private void OtwórzKategorię(object sender, RoutedEventArgs e)
        {
            Kategoria wybranaKategoria = (Kategoria)(listaKategorii.SelectedItem);
            if (wybranaKategoria != null)
                new WidokKategorii(
                    wybranaKategoria
                    )
                    .Show()
                    ;
        }
        private void DodajKategorię(object sender, RoutedEventArgs e)
        {
            Kategoria nowaKategoria = new Kategoria();
            kategorie.Add(nowaKategoria);
            new WidokKategorii(
                nowaKategoria
                )
                .Show()
                ;
        }
        private void UsuńKategorię(object sender, RoutedEventArgs e)
        {

            Kategoria usuwanaKategoria = (Kategoria)(listaKategorii.SelectedItem);
            kategorie.Remove(usuwanaKategoria);
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Kategoria>));
            TextWriter strumieńZapisu = new StreamWriter("Produkty.xml");
            serializator.Serialize(strumieńZapisu, kategorie);
        }

        private void Wczytaj(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Kategoria>));
            FileStream plik = new FileStream(ŚcieżkaIO, FileMode.Open);
            ObservableCollection<Kategoria> wczytane
                = (ObservableCollection<Kategoria>)serializator.Deserialize(plik);
            kategorie.Clear();
            foreach (Kategoria kategoria in wczytane)
                kategorie.Add(kategoria);
            plik.Close();
        }
    }
}
