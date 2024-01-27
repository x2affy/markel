using Markel.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ILogger<CompaniesController> _logger;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyService"></param>
        /// <param name="logger"></param>
        public CompaniesController(ICompanyService companyService, ILogger<CompaniesController> logger)
        {
            _companyService = companyService;
            _logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCompanyById(int id)
        {
            try
            {
                var data = _companyService.GetCompanyById(id);

                // Check if the company data is null
                if (data == null)
                {
                    var message = $"{nameof(GetCompanyById)}: Company with ID {id} not found.";
                    _logger.LogWarning(message);
                    return NotFound(message);
                }

                // Returning JSON response with the company data
                _logger.LogInformation($"{nameof(GetCompanyById)}: Company found successfully.");
                return Ok(data);
            }
            catch (Exception ex)
            {

                _logger.LogError($"{nameof(GetCompanyById)}: Error : {ex.Message}");

                return StatusCode(500, $"GetCompanyById: Internal Server Error - {ex.Message}");

            }
        }

    }
}
