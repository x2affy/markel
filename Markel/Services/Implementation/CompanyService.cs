using Markel.DataAccess.Abstraction;
using Markel.Models;
using Markel.Services.Abstraction;

namespace Markel.Services.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyService> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyRepository"></param>
        /// <param name="logger"></param>
        public CompanyService(ICompanyRepository companyRepository, ILogger<CompanyService> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CompanyDto? GetCompanyById(int id)
        {
            try
            {
                var company = _companyRepository.GetCompanyById(id);

                if (company == null)
                {
                    _logger.LogError($"GetCompanyById: No company found for Id:{id}");
                    return null; // throw an exception or return null
                }

                var dto = new CompanyDto
                {
                    Id = company.Id,
                    Name = company.Name,
                    Address1 = company.Address1,
                    Address2 = company.Address2,
                    Address3 = company.Address3,
                    PostCode = company.PostCode,
                    Country = company.Country,
                    Active = company.Active,
                    InsuranceEndDate = company.InsuranceEndDate,
                    InsurancePolicyActive = company.InsuranceEndDate > DateTime.Now
                };

                _logger.LogInformation($"GetCompanyById:{id}, Returning company");
                return dto;
            }
            catch (Exception ex)
            {
                var message = $"GetCompanyById: An error occurred: {ex.Message}";
                _logger.LogError(ex,message );
                throw; 
            }
        }
    }
}
