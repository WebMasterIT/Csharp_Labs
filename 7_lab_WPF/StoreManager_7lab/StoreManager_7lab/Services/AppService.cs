using StoreManager_7lab.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Windows;
using System.Net;
using System.Text.Json;

namespace StoreManager_7lab.Services
{
    public class ApiService
    {
        private HttpClient _http;
        private string _token;
        private string _role;



        public async Task InitAsync()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (a, b, c, d) => true
            };

            bool useHttps = await TryUseHttps();  

            var baseUri = useHttps
                ? "https://localhost:7259/api/"
                : "http://localhost:5107/api/";

            _http = new HttpClient(handler)
            {
                BaseAddress = new Uri(baseUri)
            };
        }

        private async Task<bool> TryUseHttps()
        {
            try
            {
                using var testClient = new HttpClient(new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (a, b, c, d) => true
                });
                var response = await testClient.GetAsync("https://localhost:7259/api/Product");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
         
        // === Аутентификация ===

        public void SetToken(string token)
        {
            _token = token;
            if (_http != null)
            {
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                Console.WriteLine("Token установлен: " + token);
            }
        }

        public void SetRole(string role)
        {
            _role = role;
        }

        public string GetRole() => _role;

        public void ClearAuth()
        {
            _token = null;
            _role = null;

            if (_http != null)
                _http.DefaultRequestHeaders.Authorization = null;
        }


        public HttpClient Client => _http;

        // === Работа с продуктами ===

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var response = await _http.GetAsync("Product");
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON от сервера:\n" + json);

                response.EnsureSuccessStatusCode();

                var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return products ?? new List<Product>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении товаров: {ex.Message}");
                return new List<Product>();
            }
        }


        public async Task AddProductAsync(Product product)
        {
            MessageBox.Show($"Добавляем товар:\n{product.Name}, {product.Price}, {product.Stock}, {product.Category}");

            var response = await _http.PostAsJsonAsync("Product", product);

            if (!response.IsSuccessStatusCode)
            {
                string errorText = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Ошибка добавления товара:\nКод: {response.StatusCode}\nОтвет сервера: {errorText}");
            }
            else
            {
                MessageBox.Show("Товар добавлен успешно");
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            var response = await _http.PutAsJsonAsync($"Product/{product.Id}", product);
            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show($"Ошибка обновления товара: {response.StatusCode}");
            } 
        }

        public async Task DeleteProductAsync(int id)
        {
            var response = await _http.DeleteAsync($"Product/{id}");
            if (!response.IsSuccessStatusCode)
            {
                string errorText = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Ошибка удаления товара:\nКод: {response.StatusCode}\nОтвет сервера: {errorText}");
            }
            else
            {
                MessageBox.Show("Товар удалён успешно");
            }
        }
        // === Работа с заказами ===

        public async Task<List<Order>> GetOrdersAsync()
        {
            if (string.IsNullOrWhiteSpace(_token))
            {
                return new List<Order>();
            }

            try
            {
                var response = await _http.GetAsync("Order");

                if (response.StatusCode == HttpStatusCode.MethodNotAllowed)
                {
                    MessageBox.Show("Метод получения заказов недоступен (405).");
                    return new List<Order>();
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Здесь можно не показывать сообщение, если это часть нормального потока (например, после выхода)
                    return new List<Order>();
                }

                response.EnsureSuccessStatusCode();

                var orders = await response.Content.ReadFromJsonAsync<List<Order>>();

                // ✅ если null или пусто — безопасный возврат
                return orders?.Where(o => o != null && o.Items != null).ToList() ?? new List<Order>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении заказов: {ex.Message}");
                return new List<Order>();
            }
        }

        public async Task AddOrderAsync(Order order) =>
            await _http.PostAsJsonAsync("Order", order);

        public async Task DeleteOrderAsync(int id) =>
            await _http.DeleteAsync($"Order/{id}");

        public async Task<bool> LoginAsync(string username, string password)
        {
            try
            {
                var dto = new
                {
                    Username = username,
                    Password = password, 
                };

                var response = await _http.PostAsJsonAsync("auth/login", dto);

                if (!response.IsSuccessStatusCode)
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($" Ошибка входа: {response.StatusCode}\n{error}");
                    return false;
                }

                var json = await response.Content.ReadFromJsonAsync<JsonElement>();
                string token = json.GetProperty("token").GetString();
                string role = json.GetProperty("role").GetString();

                SetToken(token);
                SetRole(role);

                return true;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Не удалось подключиться к серверу: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка авторизации: " + ex.Message);
                return false;
            }
        }



        public async Task RegisterAsync(UserRegisterDto dto)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = null // отключает camelCase, включает PascalCase
            };

            var response = await _http.PostAsJsonAsync("auth/register", dto, options);
            response.EnsureSuccessStatusCode();
        }
    }
}
