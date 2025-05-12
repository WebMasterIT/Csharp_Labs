using StoreManager_4lab.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoreManager_4lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void ProductsListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Универсально для ListBox и ListView
            if (sender is not Selector selector) return;

            var result = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            if (result == null) return;

            DependencyObject obj = result.VisualHit;

            // Поднимаемся по дереву до ListBoxItem или ListViewItem
            while (obj != null && obj is not ListBoxItem && obj is not ListViewItem)
            {
                obj = VisualTreeHelper.GetParent(obj);
            }

            // Если клик был не по элементу — снимаем выделение
            if (obj == null)
            {
                selector.SelectedItem = null;

                if (DataContext is MainViewModel vm)
                {
                    // Очищаем оба — корзину и товар
                    vm.SelectedProduct = null;
                    vm.SelectedCartItem = null;
                    vm.ClearProductFields();
                }

                e.Handled = true;
            }
        }


        private void CartListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is not Selector selector) return;

            var result = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            if (result == null) return;

            DependencyObject obj = result.VisualHit;

            while (obj != null && obj is not ListBoxItem)
            {
                obj = VisualTreeHelper.GetParent(obj);
            }

            if (obj == null)
            {
                selector.SelectedItem = null;

                if (DataContext is MainViewModel vm)
                {
                    vm.SelectedCartItem = null;
                }

                e.Handled = true;
            }
        }



        private void ProductsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;

            if (listView?.SelectedItem == null)
            {
                if (DataContext is MainViewModel vm)
                {
                    vm.ClearProductFields();
                    vm.SelectedProduct = null;
                }
            }
        }

    }


}