using StoreManager_7lab.Commands;
using StoreManager_7lab.Services; 
using System.ComponentModel; 
using System.Net.Http.Json;
using System.Runtime.CompilerServices; 
using System.Windows;
using System.Windows.Input; 

namespace StoreManager_7lab.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        private ApiService _api;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
         

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async _ => await LoginAsync(), _ => CanLogin());
        }

        private bool CanLogin() =>
            !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);


        public event Action LoginSucceeded;

        private async Task LoginAsync()
        {
            try
            {
                _api = new ApiService(); // сохраняем экземпляр
                await _api.InitAsync();

                var response = await _api.Client.PostAsJsonAsync("auth/login", new { Username, Password });
                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("❌ Неверные данные для входа");
                    return;
                }

                var result = await response.Content.ReadFromJsonAsync<LoginResult>();
                Console.WriteLine($"Роль: {result.Role}, Токен: {result.Token}");
                _api.SetToken(result.Token);
                _api.SetRole(result.Role);

                MessageBox.Show($"🔑 Вход выполнен\nРоль: {result.Role}\nТокен: {result.Token}");

                var mainWindow = new MainWindow();
                mainWindow.DataContext = new MainViewModel(_api); // <-- передаём тот же экземпляр
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();

                foreach (Window win in Application.Current.Windows)
                {
                    if (win is LoginWindow)
                    {
                        win.Close();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private class LoginResult
        {
            public string Token { get; set; }
            public string Role { get; set; }
        }
    }
}
