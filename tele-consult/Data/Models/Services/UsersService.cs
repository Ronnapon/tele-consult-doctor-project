using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tele_consult.Data.ViewModel;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace tele_consult.Data.Models.Services
{
    public class UsersService
    {
        private AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM user)
        {
            var salt = Salt();
            var passwordhash = Hash(user.Password, salt);

            var _user = new User()
            {
                Username = user.Username,
                Password = passwordhash,
                Salt = salt,
                RoleId = user.RoleId
            };
  
            _context.Users.Add(_user);
            _context.SaveChanges();

        }

        private string Hash(string password , byte[] salt)
        {
           string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
           password: password,
           salt: salt,
           prf: KeyDerivationPrf.HMACSHA1,
           iterationCount: 10000,
           numBytesRequested: 256 / 8));
           return hashed;
        }

        private byte[] Salt()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
