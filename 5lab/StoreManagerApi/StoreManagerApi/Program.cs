using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавление контекста базы данных и конфигурация SQLite
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlite("Data Source=store.db")); // Строка подключения

builder.Services.AddControllers();           // Добавление контроллеров
builder.Services.AddEndpointsApiExplorer();  // Для Swagger
builder.Services.AddSwaggerGen();           // Подключение Swagger-документации

var app = builder.Build();

// === Создание БД при старте (если нет) ===
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();     // Включение Swagger
    app.UseSwaggerUI();   // UI интерфейс Swagger
}

app.UseHttpsRedirection(); // Перенаправление на HTTPS

// app.UseAuthorization(); //   Отключено, если нет аутентификации

app.MapControllers();      // Подключение маршрутов контроллеров

app.Run();                 // Запуск приложения
