using Markel.DomainObjects;
using Markel.Models;

namespace Markel.DataAccess.Abstraction
{
    public interface IClaimRepository
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
        Claim? GetClaimByCompanyClaimId(string claimId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claim"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        bool UpdateClaim(ClaimRequest claim, string claimId);
    }
}
