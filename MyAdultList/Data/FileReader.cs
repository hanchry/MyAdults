using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using Restricting.Models;

namespace MyAdultList.Data
{
    public class FileReader:IFileReader
    {
        private FileContext FileContext;
        private IList<User> users;
        
        public FileReader()
        {
            FileContext = new FileContext();
            users = FileContext.Users;
        }
        
        public IList<Adult> GetAdults()
        {
            return FileContext.Adults;
        }

        public void UpdateAdult(Adult adult)
        {
            Adult adultFromFile = FileContext.Adults.First(t => t.Id == adult.Id);
            adultFromFile = adult;
            FileContext.SaveChanges();
        }

        public User ValidateUser(string userName, string password)
        {
            User checkUser = users.FirstOrDefault(user => user.UserName.Equals(userName));

            if (checkUser == null)
            {
                throw new Exception("User not found");
            }

            if (!checkUser.Password.Equals(password))
            {
                throw new Exception("Wrong password");
            }

            return checkUser;
        }
    }
}