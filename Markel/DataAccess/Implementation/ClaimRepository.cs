using Markel.DataAccess.Abstraction;
using Markel.DomainObjects;
using Markel.Models;
using static Markel.DataAccess.Data.TestData;


namespace Markel.DataAccess.Implementation
{
    public class ClaimRepository : IClaimRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public IList<Claim> GetListOfClaimsByCompanyId(int companyId)
        {
            var claims = Claims
                .Where(x => x.CompanyId == companyId)
                .ToList();

            return claims;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimId"></param>
        /// <returns></returns>
        public Claim? GetClaimByCompanyClaimId(string claimId)
        {
            return Claims
                .FirstOrDefault(x => x.UCR == claimId);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="claimRequest"></param>
        /// <param name="claimId"></param>
        /// <returns></returns>
        public bool UpdateClaim(ClaimRequest claimRequest, string claimId)
        {
            var claim = GetClaimByCompanyClaimId(claimId);

            if (claim != null)
            {
                claim.AssuredName = claimRequest.AssuredName;
            }

            return true;

            /*
             using an orm..

            example:

             DbConnection.ExecuteAsync
                ("UPDATE Claim 
                    SET 
                     IsClosed = @IsClosed,
                     AssuredName = @AssuredName,
                     IncurredLoss =@IncurredLoss 
                   WHERE
                     ClaimId = @claimId ",
                    new { claimId, claim.IsClosed,claim.AssuredName, claim.IncurredLoss}
                );

            */
        }
    }



}
