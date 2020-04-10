using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopulationHouseholdWebAPI.DB;
using PopulationHouseholdWebAPI.Model;
using PopulationHouseholdWebAPI.ViewModel;

namespace PopulationHouseholdWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateDetailsController : ControllerBase
    {
        private readonly StateDBContext _context;

        public StateDetailsController(StateDBContext context)
        {
            _context = context;
        }

        // GET: api/Actuals
        [HttpGet]
        public IEnumerable<Actucals> GetPopulationHouseholds()
        {
            return _context.Actuals.ToList();
        }

        [HttpGet("population/{state}")]
        /// <summary>
        /// GET: /api/StateDetails/population/1
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<IActionResult> GetPopulation([FromRoute] string state)
        {

            string[] intArr = state.Split(',');
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var responsePopulation = new StatePopulationResponse();
            for (int i = 0; i < intArr.Length; i++)
            {
                var _state = _context.Actuals.Find(Convert.ToInt32(intArr[i]));
                var _StatePopulationVM = new StatePopulationVM();
                int stateID = Convert.ToInt32(intArr[i]);
                var _Actuals = _context.Actuals.Where(x => x.State == stateID);

                if (_state != null)
                {
                    if (_Actuals != null)
                    {
                        var totalPopulation = _Actuals.Sum(y => y.Population);
                        _StatePopulationVM.State = stateID;
                        _StatePopulationVM.Population = totalPopulation;
                        if (responsePopulation.StatePopulationVMList == null)
                        {
                            responsePopulation.StatePopulationVMList = new List<StatePopulationVM>();
                        }
                        responsePopulation.StatePopulationVMList.Add(_StatePopulationVM);
                    }
                    else
                    {

                        var _Estimates = _context.Estimates.Where(x => x.State == stateID);

                        if (_Estimates != null)
                        {
                            var totalPopulation = _Estimates.Sum(y => y.Population);
                            _StatePopulationVM.State = stateID;
                            _StatePopulationVM.Population = totalPopulation;
                            if (responsePopulation.StatePopulationVMList == null)
                            {
                                responsePopulation.StatePopulationVMList = new List<StatePopulationVM>();
                            }
                            responsePopulation.StatePopulationVMList.Add(_StatePopulationVM);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                }
                else
                {
                    return NotFound();
                }

            }
            return Ok(responsePopulation.StatePopulationVMList);
        }

        /// <summary>
        /// GET: /api/StateDetails/households/1
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("households/{state}")]
        public async Task<IActionResult> GetHouseholds([FromRoute] string state)
        {

            string[] intArr = state.Split(',');
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var responseHouseholds = new StatePopulationResponse();
            for (int i = 0; i < intArr.Length; i++)
            {
                var _state = _context.Actuals.Find(Convert.ToInt32(intArr[i]));
                var _StateHouseholdVM = new StateHouseholdVM();
                int stateID = Convert.ToInt32(intArr[i]);
                var _Actuals = _context.Actuals.Where(x => x.State == stateID);

                if (_state != null)
                {
                    if (_Actuals != null)
                    {
                        var totalHouseholds = _Actuals.Sum(y => y.Households);
                        _StateHouseholdVM.State = stateID;
                        _StateHouseholdVM.Households = totalHouseholds;
                        if (responseHouseholds.StateHouseholdVMList == null)
                        {
                            responseHouseholds.StateHouseholdVMList = new List<StateHouseholdVM>();
                        }
                        responseHouseholds.StateHouseholdVMList.Add(_StateHouseholdVM);
                    }
                    else
                    {

                        var _Estimates = _context.Estimates.Where(x => x.State == stateID);

                        if (_Estimates != null)
                        {
                            var totalHouseholds = _Estimates.Sum(y => y.Households);
                            _StateHouseholdVM.State = stateID;
                            _StateHouseholdVM.Households = totalHouseholds;
                            if (responseHouseholds.StateHouseholdVMList == null)
                            {
                                responseHouseholds.StateHouseholdVMList = new List<StateHouseholdVM>();
                            }
                            responseHouseholds.StateHouseholdVMList.Add(_StateHouseholdVM);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                }
                else
                {
                    return NotFound();
                }

            }
            return Ok(responseHouseholds.StateHouseholdVMList);
        }
        private bool ActucalsExists(int id)
        {
            return _context.Actuals.Any(e => e.ID == id);
        }
    }
}
