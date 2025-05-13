using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using StoreManager_7lab.ViewModels;

namespace StoreManager_7lab
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            if (DataContext is RegisterViewModel vm)
            {
                vm.RegistrationSucceeded += OnRegistrationSucceeded;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel vm)
            {
                vm.Password = ((PasswordBox)sender).Password;
            }
        }
        private void RegisterText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Show();

            this.Close(); // закрываем текущее окно регистрации
        }
        private void OnRegistrationSucceeded()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close();
            });
        }
    }
}
