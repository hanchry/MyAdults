using System.Collections;
using System.Collections.Generic;
using Models;
using Restricting.Models;

namespace MyAdultList.Data
{
    public interface IFileReader
    {
        IList<Adult> GetAdults();
        void UpdateAdult(Adult adult);
        User ValidateUser(string userName, string password);
    }
}