using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager_4lab.Models
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        // Повторить для Price, Stock, Category

        private int _id;
        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set { _price = value; OnPropertyChanged(); }
        }

        private int _stock;
        public int Stock
        {
            get => _stock;
            set { _stock = value; OnPropertyChanged(); }
        }

        private string? _category;
        public string? Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
