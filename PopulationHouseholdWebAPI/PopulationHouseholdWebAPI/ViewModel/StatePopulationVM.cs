using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationHouseholdWebAPI.ViewModel
{
    public class StatePopulationVM
    {
        public int State { get; set; }
        public decimal Population { get; set; }
    }
    public class StateHouseholdVM
    {
        public int State { get; set; }
        public decimal Households { get; set; }

    }
}
