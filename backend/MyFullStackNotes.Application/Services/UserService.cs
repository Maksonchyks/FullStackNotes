using Microsoft.Extensions.Logging;
using MyFullStackNotes.Application.Interfaces;
using MyFullStackNotes.Domain.Entities;
using MyFullStackNotes.Domain.Enums;

namespace MyFullStackNotes.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly ILogger<UserService> _logger;
        private readonly IPasswordHasher _hasher;
        public UserService(IUserRepository repo,
                       ILogger<UserService> logger,
                       IPasswordHasher hasher)
        {
            _repo = repo;
            _logger = logger;
            _hasher = hasher;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
            _logger.LogInformation("Deleted user {UserId}", id);
        }

        public Task<List<User>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
           return _repo.GetByEmailAsync(email);
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            return _repo.GetByIdAsync(id);
        }

        public async Task<User> RegisterAsync(string email, string name, string plainPassword)
        {
            // Мінімальні перевірки
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException("Email, Name та Password не можуть бути порожніми");

            // Email уже існує?
            if (await _repo.GetByEmailAsync(email) is not null)
                throw new InvalidOperationException("Користувач із таким email уже зареєстрований");

            // Хешуємо пароль
            var hash = _hasher.Hash(plainPassword);

            // Створюємо доменну модель
            var user = new User(email, name, hash);

            await _repo.AddAsync(user);
            _logger.LogInformation("✔️ Created user {UserId}", user.Id);

            return user;
        }

        public async Task UpdateRoleAsync(Guid id, UserRole newRole)
        {
            var user = await _repo.GetByIdAsync(id)
                       ?? throw new KeyNotFoundException("Користувача не знайдено");

            user.ChangeRole(newRole);           // метод моделі
            await _repo.UpdateAsync(user);

            _logger.LogInformation("🔄 Role for {UserId} set to {Role}", id, newRole);
        }
    }
}
