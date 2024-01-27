using Markel.DomainObjects;
using Markel.Models;

namespace Markel.Services.Abstraction
{
    public interface IClaimService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        IList<Claim> GetListOfClaimsByCompanyId(int companyId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimId"></param>
        /// <returns></returns>
        ClaimDto? GetClaimByCompanyClaimId(string claimId);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        bool UpdateClaim(ClaimRequest claim, string claimId);
    }
}
