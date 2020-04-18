using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using socialApp.API.Models;

namespace socialApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.Users.Any()) 
            {
                // read the file to get all raw data
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");

                // all the raw data loading to objects
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                // loop through each user data and generate the password hash
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    // user.PasswordHash = passwordHash;
                    // user.PasswordSalt = passwordSalt;
                    user.UserName = user.UserName.ToLower();
                    context.Users.Add(user);
                }

                // save all the users data to DB
                context.SaveChanges();
            }
        }

        // same method in AuthRepository
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
           
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}