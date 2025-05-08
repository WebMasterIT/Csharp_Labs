using Microsoft.Data.Sqlite; 
using StoreManager_4lab.Models;

namespace StoreManager_4lab.Repositories
{
    public class ProductRepository
    {
        private const string ConnectionString = "Data Source=store.db";

        public List<Product> GetAll()
        {
            var list = new List<Product>();
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Product";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Stock = reader.GetInt32(3),
                    Category = reader.IsDBNull(4) ? null : reader.GetString(4)
                });
            }

            return list;
        }
         
        public void Add(Product product)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Product (Name, Price, Stock, Category) VALUES (@name, @price, @stock, @category)";
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@stock", product.Stock);
            command.Parameters.AddWithValue("@category", product.Category ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }

        public void Update(Product product)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Product SET Name=@name, Price=@price, Stock=@stock, Category=@category WHERE Id=@id";
            command.Parameters.AddWithValue("@id", product.Id);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@stock", product.Stock);
            command.Parameters.AddWithValue("@category", product.Category ?? (object)DBNull.Value);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Product WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}
