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
        private readonly HttpClient _http; // HTTP-клиент для запросов к API

        public ApiService()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true // Разрешить самоподписанные сертификаты
            };

            _http = new HttpClient(handler)
            {
                BaseAddress = TryUseHttps()
                    ? new Uri("https://localhost:7259/api/")
                    : new Uri("http://localhost:5107/api/") // Базовый адрес сервера API
            };
        }

        // Попытка проверить доступность HTTPS API
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

        // === Методы работы с товарами ===

        public async Task<List<Product>> GetProductsAsync() // Получить список товаров
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

        public async Task AddProductAsync(Product product) => // Добавить новый товар
            await _http.PostAsJsonAsync("Product", product);

        public async Task UpdateProductAsync(Product product) => // Обновить товар по ID
            await _http.PutAsJsonAsync($"Product/{product.Id}", product);

        public async Task DeleteProductAsync(int id) => // Удалить товар по ID
            await _http.DeleteAsync($"Product/{id}");

        // === Методы работы с заказами ===

        public async Task<List<Order>> GetOrdersAsync() // Получить список заказов
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

        public async Task AddOrderAsync(Order order) => // Добавить новый заказ
            await _http.PostAsJsonAsync("Order", order);

        public async Task DeleteOrderAsync(int id) => // Удалить заказ по ID
            await _http.DeleteAsync($"Order/{id}");
    }
}
