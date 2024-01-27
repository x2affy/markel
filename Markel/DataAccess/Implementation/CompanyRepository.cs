using Markel.DataAccess.Abstraction;
using Markel.DomainObjects;
using static Markel.DataAccess.Data.TestData;

namespace Markel.DataAccess.Implementation
{
    public class CompanyRepository : ICompanyRepository
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public Company? GetCompanyById(int companyId)
        {
            var company = Companies.FirstOrDefault(w => w.Id == companyId);

            return company;
        }
    }
}
