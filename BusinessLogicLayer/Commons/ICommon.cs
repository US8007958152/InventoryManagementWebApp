using Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Commons
{
    public interface ICommon
    {
        List<Dropdown> GetUserTypeDropdown();
        List<Dropdown> GetCountryDropdown();
        List<Dropdown> GetStateDropdown(int countryId);       
        List<Dropdown> GetCityDropdown(int stateId);
    }
}
