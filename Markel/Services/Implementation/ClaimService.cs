using Markel.DataAccess.Abstraction;
using Markel.DomainObjects;
using Markel.Models;
using Markel.Services.Abstraction;

namespace Markel.Services.Implementation
{
    public class ClaimService : IClaimService
    {
        private readonly IClaimRepository _claimRepository;
        private readonly ILogger<IClaimRepository> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimRepository"></param>
        /// <param name="logger"></param>
        public ClaimService(IClaimRepository claimRepository, ILogger<IClaimRepository> logger)
        {
            _claimRepository = claimRepository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public IList<Claim> GetListOfClaimsByCompanyId(int companyId)
        {
            return _claimRepository.GetListOfClaimsByCompanyId(companyId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimId"></param>
        /// <returns></returns>
        public ClaimDto? GetClaimByCompanyClaimId(string claimId)
        {
            try
            {
                var claim = _claimRepository.GetClaimByCompanyClaimId(claimId);

                if (claim == null)
                {
                    _logger.LogInformation($"{nameof(GetClaimByCompanyClaimId)}: {claimId}, No claim found for claimId and companyId");

                    return null;
                }


                var currentDate = DateTime.Now;

                var dto = new ClaimDto
                {
                    UCR = claim.UCR,
                    AssuredName = claim.AssuredName,
                    ClaimDate = claim.ClaimDate,
                    Closed = claim.Closed,
                    CompanyId = claim.CompanyId,
                    IncurredLoss = claim.IncurredLoss,
                    LossDate = claim.LossDate,
                    ClaimTypeName = claim.ClaimType?.Name,
                    DaysSinceClaim = (int)(currentDate - claim.ClaimDate).TotalDays
                };

                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetClaimByCompanyClaimId)}: {claimId}, Error : {ex.Message}");
                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool UpdateClaim(ClaimRequest claim, string claimId)
        {
            return _claimRepository.UpdateClaim(claim, claimId);
        }
    }
}
