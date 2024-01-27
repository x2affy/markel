using Markel.DomainObjects;

namespace Markel.DataAccess.Abstraction
{
    public interface ICompanyRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Company? GetCompanyById(int companyId);

    }
}
