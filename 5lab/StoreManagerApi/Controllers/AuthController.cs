using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StoreManagerApi.Data;
using StoreManagerApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace StoreManagerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public AuthController(StoreDbContext context)
        {
            _context = context; // Внедрение зависимости через DI
        }

        // POST: api/auth/register
        // Регистрирует нового пользователя с хешированием пароля
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            // Проверка: если пользователь уже существует, вернуть ошибку
            if (_context.Users.Any(u => u.Username == user.Username))
                return BadRequest("Такой пользователь уже существует");

            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, user.Password); // Хешируем пароль перед сохранением

            _context.Users.Add(user); // Добавляем пользователя в БД
            _context.SaveChanges();   // Сохраняем изменения

            return Ok("Регистрация прошла успешно");
        }

        // GET: api/auth/all
        // Возвращает всех пользователей (можно использовать для теста)
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            return Ok(_context.Users.ToList()); // Возвращаем список всех пользователей
        }

        // POST: api/auth/login
        // Авторизация: проверка логина и пароля, выдача JWT-токена
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            // Поиск пользователя по логину
            var user = _context.Users.FirstOrDefault(u => u.Username == dto.Username);
            if (user == null)
                return Unauthorized("Неверный логин");

            var hasher = new PasswordHasher<User>();
            // Сравнение введённого пароля с хешем из БД
            var result = hasher.VerifyHashedPassword(user, user.Password, dto.Password);

            if (result == PasswordVerificationResult.Failed)
                return Unauthorized("Неверный пароль");

            // Создание набора claims (утверждений) о пользователе
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username), // Имя пользователя
                new Claim(ClaimTypes.Role, user.Role)      // Его роль (Admin/Customer)
            };

            // Генерация ключа и токена
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_MY_SUPER_SECRET_KEY_1234567890"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2), // Время действия токена
                signingCredentials: creds);        // Подпись токена

            // Отправка токена клиенту
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token), // строка-токен
                role = user.Role // роль для клиента
            });
        }
    }
}