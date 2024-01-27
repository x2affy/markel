using Markel.Models;
using Markel.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Markel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IClaimService _claimService;
        private readonly ILogger<ClaimsController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyService"></param>
        /// <param name="claimService"></param>
        /// <param name="logger"></param>
        public ClaimsController(
            ICompanyService companyService,
            IClaimService claimService,
            ILogger<ClaimsController> logger)
        {
            _companyService = companyService;
            _claimService = claimService;
            _logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetListOfClaimsByCompanyId([FromQuery] int companyId)
        {
            try
            {
                var company = _companyService.GetCompanyById(companyId);
                // Check if the company data is null
                if (company == null)
                {
                    var message = $"{nameof(GetListOfClaimsByCompanyId)}:Company with ID {companyId}, no Claims found.";
                    _logger.LogWarning(message);

                    // Return a 404 Not Found response
                    return NotFound(message);
                }

                // list of empty list
                var data = _claimService.GetListOfClaimsByCompanyId(companyId);

                // Check if the claim data
                if (!data.Any())
                {
                    var message = $"{nameof(GetListOfClaimsByCompanyId)}: Company with ID {companyId}, no Claims found.";
                    _logger.LogWarning(message);

                    return Ok(message);
                }

                // Returning JSON response with the company data
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"{nameof(GetListOfClaimsByCompanyId)}: Internal Server Error - {ex.Message}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimId"></param>
        /// <returns></returns>
        [HttpGet("{claimId}")]
        public IActionResult GetClaimByCompanyClaimId(string claimId)
        {
            try
            {
                // A claim or null
                var data = _claimService.GetClaimByCompanyClaimId(claimId);
                if (data == null)
                {
                    var message = $"{nameof(GetClaimByCompanyClaimId)}: no Claim {claimId} found.";
                    _logger.LogWarning(message);
                    return Ok(message);
                }

                // Returning JSON response with the company data
                return Ok(data);
            }
            catch (Exception ex)
            {
                var message = $"{nameof(GetClaimByCompanyClaimId)}: Error - {ex.Message}";
                _logger.LogError(message);

                return StatusCode(500, message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        [HttpPatch]
        public IActionResult UpdateClaim([FromBody] ClaimRequest claim, string claimId)
        {
            try
            {
                // Check if ClaimId is valid
                if (!IsValidClaimId(claimId))
                {
                    ModelState.AddModelError(nameof(claimId), "Invalid ClaimId format");
                    _logger.LogError($"{nameof(UpdateClaim)}: ClaimId is incorrect format or missing");
                    return BadRequest(ModelState);
                }

                // Check if the model is valid
                if (!ModelState.IsValid)
                {
                    _logger.LogError($"{nameof(UpdateClaim)}: Check claim params, validation failed.");
                    return BadRequest(ModelState);
                }

                var result = _claimService.UpdateClaim(claim, claimId);

                if (!result)
                {
                    var message = $"{nameof(UpdateClaim)}: Claim {claimId} was unable to be updated.";
                    _logger.LogWarning(message);
                    return Ok(message);
                }


                return Ok($"Claim {claimId} was updated.");

            }
            catch (Exception ex)
            {
                var message = $"{nameof(UpdateClaim)}: Server Error - {ex.Message}";
                _logger.LogError(message);

                return StatusCode(500, message);
            }
        }


        /// <summary>
        /// Helper method
        /// </summary>
        /// <param name="claimId"></param>
        /// <returns></returns>
        private bool IsValidClaimId(string claimId)
        {
            // Add your custom validation logic for ClaimId 
            return !string.IsNullOrEmpty(claimId) && claimId.StartsWith("A");
        }

    }
}
