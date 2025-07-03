using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcrypt = BCrypt.Net.BCrypt;

using MyFullStackNotes.Application.Interfaces;

namespace MyFullStackNotes.Application.Services
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            return Bcrypt.HashPassword(password);
        }

        public bool Verify(string hash, string password)
        {
            return Bcrypt.Verify(password, hash);
        }
    }
}
