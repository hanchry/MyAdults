using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Models;

namespace MyAdultList.Pages
{
    public partial class AdultList:ComponentBase
    {
        private IList<Adult> allAdults;
        private IList<Adult> adultsToShow;
        
        private string? firstName;

        protected override async Task OnInitializedAsync()
        {
            allAdults = fileReader.GetAdults();
            adultsToShow = allAdults;
        }
        public void FindByName(ChangeEventArgs changeEventArgs)
        {
            firstName = null;
            try
            {
                firstName = changeEventArgs.Value.ToString();
            }
            catch (Exception e)
            {
            }
            adultsToShow = allAdults.Where(adult => (adult.FirstName.Contains(firstName))).ToList();
        }
    }
}