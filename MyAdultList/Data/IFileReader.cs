using System.Collections;
using System.Collections.Generic;
using Models;

namespace MyAdultList.Data
{
    public interface IFileReader
    {
        IList<Adult> GetAdults();
        void UpdateAdult(Adult adult);
    }
}