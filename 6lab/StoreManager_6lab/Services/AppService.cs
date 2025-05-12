using StoreManager_6lab.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Windows;

namespace StoreManager_6lab.Services
{
    public class ApiService
    {
        private readonly HttpClient _http;

        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                // ✅ разрешаем подключаться к самоподписанному SSL-сертификату
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };

            _http = new HttpClient(handler)
            {
                // ✅ выбираем, что доступно первым
                BaseAddress = TryUseHttps()
                    ? new Uri("https://localhost:7259/api/")
                    : new Uri("http://localhost:5107/api/")
            };
        }

        private bool TryUseHttps()
        {
            try
            {
                using var testClient = new HttpClient(
                    new HttpClientHandler { ServerCertificateCustomValidationCallback = (a, b, c, d) => true });

                var response = testClient.GetAsync("https://localhost:7259/api/Product").Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        // === Методы API ===

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Product>>("Product") ?? new List<Product>();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task AddProductAsync(Product product) =>
            await _http.PostAsJsonAsync("Product", product);

        public async Task UpdateProductAsync(Product product) =>
            await _http.PutAsJsonAsync($"Product/{product.Id}", product);

        public async Task DeleteProductAsync(int id) =>
            await _http.DeleteAsync($"Product/{id}");

        public async Task<List<Order>> GetOrdersAsync()
        {
            try
            {
                return await _http.GetFromJsonAsync<List<Order>>("Order") ?? new List<Order>();
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
    }
}
