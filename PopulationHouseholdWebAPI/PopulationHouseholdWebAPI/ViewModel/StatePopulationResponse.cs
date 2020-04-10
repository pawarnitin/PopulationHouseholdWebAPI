using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PopulationHouseholdWebAPI.ViewModel
{
    public class StatePopulationResponse
    {
        public List<StatePopulationVM> StatePopulationVMList { get; set; }
        public List<StateHouseholdVM> StateHouseholdVMList { get; set; }
    }
}
