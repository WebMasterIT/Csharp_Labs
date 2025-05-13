using System.Windows;
using System.Windows.Controls; 
using System.Windows.Input;
using StoreManager_7lab.ViewModels;

namespace StoreManager_7lab
{

    public partial class LoginWindow : Window
    {
        private void RegisterText_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var reg = new RegisterWindow();
            reg.ShowDialog();
             
            this.Close();
        }
        public LoginWindow()
        {
            InitializeComponent();
            if (DataContext is LoginViewModel vm)
            {
                vm.LoginSucceeded += () => this.Close();
            }
        }   

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
                vm.Password = PasswordBox.Password;
        }

    }
}

