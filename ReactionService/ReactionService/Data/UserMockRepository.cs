using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    /// <summary>
    /// Lažni (mock) repozitorijum u ulozi korisnika
    /// </summary>
    public class UserMockRepository : IUserMockRepository
    {
        List<User> Users = new List<User>();

        public UserMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            var userPassword = HashPassword("lozinka");

            Users.AddRange(new List<User>
            {
                new User
                {
                    UserId = Guid.Parse("03ff7611-e183-42a3-92fe-b2bb96032df6"),
                    FirstName = "Marko",
                    LastName = "Markovic",
                    UserName = "m.markovic",
                    Email = "m.markovic@mail.com",
                    Password = userPassword
                }
            });
        }

        /// <summary>
        /// Provera da li korisnik sa datim kredencijalima postoji
        /// </summary>
        public bool CheckIfUserExists(string username, string password)
        {
            User user = Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                return false;
            }

            if (BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Hash-iranje lozinke korisnika
        /// </summary>
        public String HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
