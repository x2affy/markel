using Markel.Models;

namespace Markel.Services.Abstraction
{
    public interface ICompanyService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CompanyDto? GetCompanyById(int id);
    }
}
