using StoreManager_6lab.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StoreManager_6lab.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly Product _product;

        public ProductViewModel(Product product)
        {
            _product = product;
        }

        public int Id => _product.Id;

        public string Name
        {
            get => _product.Name;
            set
            {
                if (_product.Name != value)
                {
                    _product.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get => _product.Price;
            set
            {
                if (_product.Price != value)
                {
                    _product.Price = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Stock
        {
            get => _product.Stock;
            set
            {
                if (_product.Stock != value)
                {
                    _product.Stock = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Category
        {
            get => _product.Category;
            set
            {
                if (_product.Category != value)
                {
                    _product.Category = value;
                    OnPropertyChanged();
                }
            }
        }

        public Product ToModel() => _product;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
