using System.Collections.Generic;
using System.Text.RegularExpressions;
using bit.userManager.IRepository;
using bit.userManager.Models;
using bit.userManager.Service;
using Microsoft.AspNetCore.Mvc;

namespace bit.userManager.Repository
{

    public class UserService : IUser
    {
        private readonly MyDbContext _dbContext;
        public UserService(MyDbContext cont)
        {
             _dbContext = cont;
        }
        public int addNumber() 
        { 
            return 1 + 2; 
        }

        public string CreateUser(user model)
        {
            List<user> list = new List<user>();

            if (model != null)
            {
                if (string.IsNullOrEmpty(model.FullName))
                {
                    return "Full name cannot be empty";
                }
                else if (string.IsNullOrEmpty(model.Email))
                {
                    return "Email cannot be empty";
                }
                else if (string.IsNullOrEmpty(model.Password))
                {
                    return "Password cannot be null";
                }
                else if (model.Password.Length < 7)
                {
                    return "Password is not long enough";
                }
                else if (!HasSpecialCharacters(model.Password))
                {
                    return "Password must contain special characters";
                }

               
                _dbContext.Users.Add(model);
                var isTrue = _dbContext.SaveChanges();
                return "User added successfully";
            }

            return "Invalid request";
        }

        public user deleteUser(int id)
        {
            {
                var userToRemove = _dbContext.Users.FirstOrDefault(u => u.Id == id);

                if (userToRemove == null)
                {
                    return null; // User not found
                }

                _dbContext.Users.Remove(userToRemove);
                _dbContext.SaveChanges();

                return userToRemove;
            }
        }

        public List<user> getUser(user model)
        {
            var users = _dbContext.Users.ToList();
            return users;
        }

        public user getUserId(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public user updateUser(int id, [FromBody] user updatedUser)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return null;
            }

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            user.Password = updatedUser.Password;

            return user;

        }

        public user updateUser(int id)
        {
            throw new NotImplementedException();
        }

        // Method to check for special characters in the password
        private bool HasSpecialCharacters(string input)
        {
            // Regular expression pattern to match special characters
            Regex regex = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            return regex.IsMatch(input);
        }
    }
}
