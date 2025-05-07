using StoreManager_4lab.Models;
using StoreManager_4lab.Data;
using System.Collections.ObjectModel;
using System.Windows.Input; 

namespace StoreManager_4lab.ViewModels
{
 
    public class ProductViewModel : BaseViewModel
    {
        private Product _selectedProduct;
        private readonly StoreDbContext _context;
        private string _filterCategory;

        public ObservableCollection<Product> Products { get; } = new();
        public ObservableCollection<string> Categories { get; } = new();

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => SetProperty(ref _selectedProduct, value);
        }

        public string FilterCategory
        {
            get => _filterCategory;
            set
            {
                if (SetProperty(ref _filterCategory, value))
                {
                    LoadProducts();
                }
            }
        }

        public ICommand AddProductCommand { get; }
        public ICommand UpdateProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductViewModel()
        {
            _context = new StoreDbContext();
            _context.Database.EnsureCreated();

            LoadCategories();
            LoadProducts();

            AddProductCommand = new RelayCommand(_ => AddProduct());
            UpdateProductCommand = new RelayCommand(_ => UpdateProduct(), _ => SelectedProduct != null);
            DeleteProductCommand = new RelayCommand(_ => DeleteProduct(), _ => SelectedProduct != null);
        }

        private void LoadProducts()
        {
            Products.Clear();
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(FilterCategory))
                products = products.Where(p => p.Category == FilterCategory);

            foreach (var product in products.ToList())
                Products.Add(product);
        }

        private void LoadCategories()
        {
            Categories.Clear();
            var categories = _context.Products.Select(p => p.Category).Distinct().ToList();
            foreach (var category in categories)
                Categories.Add(category);
        }

        private void AddProduct()
        {
            var product = new Product { Name = "Новый товар", Price = 0, Stock = 0, Category = "Общая" };
            _context.Products.Add(product);
            _context.SaveChanges();
            Products.Add(product);
            SelectedProduct = product;
            LoadCategories();
        }

        private void UpdateProduct()
        {
            _context.Products.Update(SelectedProduct);
            _context.SaveChanges();
            LoadProducts();
        }

        private void DeleteProduct()
        {
            if (SelectedProduct != null)
            {
                _context.Products.Remove(SelectedProduct);
                _context.SaveChanges();
                Products.Remove(SelectedProduct);
                SelectedProduct = null;
                LoadCategories();
            }
        }
    }
    
}
