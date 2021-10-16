using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace MyAdultList.Data
{
    public class FileReader:IFileReader
    {
        private FileContext FileContext;
        
        public FileReader()
        {
            FileContext = new FileContext();
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
    }
}