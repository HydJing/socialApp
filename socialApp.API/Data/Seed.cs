using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using socialApp.API.Models;

namespace socialApp.API.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            if (!userManager.Users.Any()) 
            {
                // read the file to get all raw data
                var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");

                // all the raw data loading to objects
                var users = JsonConvert.DeserializeObject<List<User>>(userData);

                // loop through each user data and generate the password hash
                foreach (var user in users)
                {
                    userManager.CreateAsync(user, "password").Wait();
                }
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