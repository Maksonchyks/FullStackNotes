using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFullStackNotes.Domain.Entities;
using MyFullStackNotes.Domain.Enums;

namespace MyFullStackNotes.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterAsync(string email, string name, string plainPassword);
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task UpdateRoleAsync(Guid id, UserRole newRole);
        Task DeleteAsync(Guid id);
    }
}
