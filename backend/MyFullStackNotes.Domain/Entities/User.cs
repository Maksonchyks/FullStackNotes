using MyFullStackNotes.Domain.Enums;

namespace MyFullStackNotes.Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; } = UserRole.User;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public List<Note> Notes { get; private set; } = new();
        public User(string email, string name, string passwordHash)
        {
            Email = email;
            Name = name;
            PasswordHash = passwordHash;
        }
        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrWhiteSpace(newEmail))
                throw new ArgumentException("Email не може бути порожнім.", nameof(newEmail));

            Email = newEmail;
        }

        public void ChangeName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Ім’я не може бути порожнім.", nameof(newName));

            Name = newName;
        }

        public void ChangePassword(string newPasswordHash)
        {
            if (string.IsNullOrWhiteSpace(newPasswordHash))
                throw new ArgumentException("Пароль не може бути порожнім.", nameof(newPasswordHash));

            PasswordHash = newPasswordHash;
        }

        public void ChangeRole(UserRole newRole)
        {
            if (!Enum.IsDefined(typeof(UserRole), newRole))
                throw new ArgumentException("Неприпустиме значення ролі.", nameof(newRole));

            Role = newRole;
        }

    }
}
