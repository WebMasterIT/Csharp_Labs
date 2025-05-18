using Microsoft.EntityFrameworkCore;
using StoreManagerApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


// Добавь в builder.Services:
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // отключи на dev
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("THIS_IS_MY_SUPER_SECRET_KEY_1234567890")) // замени на свой ключ
    };
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
}); 
// Добавление контекста базы данных и конфигурация SQLite
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlite("Data Source=store.db")); // Строка подключения

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });          // Добавление контроллеров
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
    app.UseSwagger();                        // Включение Swagger
    app.UseSwaggerUI();                      // UI интерфейс Swagger
}


app.UseCors("AllowAll");
//app.UseHttpsRedirection();                  // Перенаправление на HTTPS
app.UseAuthentication();
app.UseAuthorization();                     // Использование авторизации (не применяется)
app.MapControllers();                       // Маршрутизация контроллеров
app.Run();                                  // Запуск приложения
