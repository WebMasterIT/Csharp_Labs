using System.Windows;
using StoreManager_4lab.Data;

namespace StoreManager_4lab
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Гарантируем, что БД и таблицы созданы
            using (var db = new StoreDbContext())
            {
                db.Database.EnsureCreated(); // 👈 обязательно
            }
        }
    }
}
