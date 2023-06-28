using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7
{
    public class Kategoria
    {
        public string Nazwa { get; set; }
        public ObservableCollection<Produkt> Produkty { get; set; } = new();
    }
}
