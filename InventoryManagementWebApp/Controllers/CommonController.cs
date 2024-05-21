using BusinessLogicLayer.Commons;
using DataAccessLayer.Commons;
using Microsoft.AspNetCore.Mvc;

namespace InventoryWebApp.Controllers
{
    public class CommonController : Controller
    {
        #region Private Members
        //private readonly ICommon _common;
        private readonly IConfiguration _configuration;
        private readonly string _connString;
        private ICommon _common
        {
            get
            {
                return new CommonDAL(_connString);
            }
        }
        #endregion Private Members

        #region Constructors
        public CommonController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connString = _configuration.GetConnectionString("InventoryDevDB");
        }
        #endregion Constructors

        #region Common Web APIs
        [HttpGet]
        public IActionResult GetUserTypeDropdown()
        {
            try
            {
                var userTypes = _common.GetUserTypeDropdown();
                return Ok(userTypes);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpGet]
        public IActionResult GetCountryDropdown()
        {
            try
            {
                var userTypes = _common.GetCountryDropdown();
                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult GetStateDropdown(int countryId)
        {
            try
            {
                var userTypes = _common.GetStateDropdown(countryId);
                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public IActionResult GetCityDropdown(int stateId)
        {
            try
            {
                var userTypes = _common.GetCityDropdown(stateId);
                return Ok(userTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion Common Web APIs
    }
}
