using Microsoft.Data.Sqlite; 
using StoreManager_4lab.Models;

namespace StoreManager_4lab.Repositories
{
    public class OrderRepository
    {
        private const string ConnectionString = "Data Source=store.db";

        public List<Order> GetAll(List<Product> allProducts)
        {
            var orders = new List<Order>();

            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, CustomerName, OrderDate FROM [Order]";
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var order = new Order
                {
                    Id = reader.GetInt32(0),
                    CustomerName = reader.GetString(1),
                    OrderDate = DateTime.Parse(reader.GetString(2)),
                    Items = new List<OrderItem>()
                };

                orders.Add(order);
            }

            foreach (var order in orders)
            {
                var itemCmd = connection.CreateCommand();
                itemCmd.CommandText = "SELECT ProductId, Quantity FROM OrderItem WHERE OrderId = @orderId";
                itemCmd.Parameters.AddWithValue("@orderId", order.Id);
                using var itemReader = itemCmd.ExecuteReader();

                while (itemReader.Read())
                {
                    var productId = itemReader.GetInt32(0);
                    var quantity = itemReader.GetInt32(1);
                    var product = allProducts.FirstOrDefault(p => p.Id == productId);

                    if (product != null)
                    {
                        order.Items.Add(new OrderItem
                        {
                            Product = product,
                            Quantity = quantity
                        });
                    }
                }
            }

            return orders;
        }

        public void Add(Order order)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var transaction = connection.BeginTransaction();

            var orderCmd = connection.CreateCommand();
            orderCmd.CommandText = "INSERT INTO [Order] (CustomerName, OrderDate) VALUES (@name, @date); SELECT last_insert_rowid();";
            orderCmd.Parameters.AddWithValue("@name", order.CustomerName);
            orderCmd.Parameters.AddWithValue("@date", order.OrderDate.ToString("s"));
            var orderId = (long)orderCmd.ExecuteScalar();

            foreach (var item in order.Items)
            {
                var itemCmd = connection.CreateCommand();
                itemCmd.CommandText = "INSERT INTO OrderItem (OrderId, ProductId, Quantity) VALUES (@orderId, @productId, @quantity)";
                itemCmd.Parameters.AddWithValue("@orderId", orderId);
                itemCmd.Parameters.AddWithValue("@productId", item.ProductId);
                itemCmd.Parameters.AddWithValue("@quantity", item.Quantity);
                itemCmd.ExecuteNonQuery();
            }

            transaction.Commit();
        }
            
        public void Delete(int orderId)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM [Order] WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", orderId);
            cmd.ExecuteNonQuery();
        }
    }
}
