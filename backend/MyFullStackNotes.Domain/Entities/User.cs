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
        public User(string email, string name, string passwordHash)
        {
            Email = email;
            Name = name;
            PasswordHash = passwordHash;
        }
        public void ChangeEmail(string newEmail)
        {
            Email = newEmail;
        }

        public void ChangeName(string newName)
        {
            Name = newName;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
        }

        public void ChangeRole(UserRole newRole)
        {
            Role = newRole;
        }
    }
}
