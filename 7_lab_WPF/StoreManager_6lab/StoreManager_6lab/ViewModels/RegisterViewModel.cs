using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StoreManager_7lab.Commands;
using StoreManager_7lab.Models;
using StoreManager_7lab.Services;

namespace StoreManager_7lab.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged

    { 
           
        public string Username { get; set; }
        public string Password { get; set; }
        public ObservableCollection<string> Roles { get; } = new() { "Customer", "Admin" };
        public string SelectedRole { get; set; }

        public ICommand RegisterCommand { get; }

   

        public event Action RegistrationSucceeded;

        private readonly ApiService _api = new();

        public RegisterViewModel()
        {
            RegisterCommand = new RelayCommand(async _ => await RegisterAsync(), _ => CanRegister());
        }

        private async Task RegisterAsync()
        {
            try
            {
                await _api.InitAsync(); // только здесь
                var dto = new UserRegisterDto
                {
                    Username = Username,
                    Password = Password,
                    Role = SelectedRole
                };

                await _api.RegisterAsync(dto);

                var successWindow = new SuccessWindow();
                successWindow.ShowDialog();

                var loginWindow = new LoginWindow();
                loginWindow.Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is RegisterWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Ошибка регистрации: {ex.Message}");
            }
        }


        private bool CanRegister() =>
            !string.IsNullOrWhiteSpace(Username) &&
            !string.IsNullOrWhiteSpace(Password) &&
            !string.IsNullOrWhiteSpace(SelectedRole);

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        

    }
}
