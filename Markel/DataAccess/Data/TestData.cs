using System.Security.Claims;
using Markel.DomainObjects;
using Claim = Markel.DomainObjects.Claim;

namespace Markel.DataAccess.Data
{
    public static class TestData
    {

        /// <summary>
        /// 
        /// </summary>
        public static List<Company> Companies { get; set; } = new()
        {
            new Company
            {
                Id = 1,
                Name = "DC Ltd",
                Address1 = "123 Main Street",
                Address2 = "Suite 456",
                Address3 = "Business District",
                PostCode = "12345",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = DateTime.Parse("2024-01-01")
            },
            new Company
            {
                Id = 2,
                Name = "Toons Ltd",
                Address1 = "789 Oak Avenue",
                Address2 = "",
                Address3 = "",
                PostCode = "56789",
                Country = "United Kingdom",
                Active = false,
                InsuranceEndDate = DateTime.Parse("2024-12-31")
            },
            new Company
            {
                Id = 3,
                Name = "Marvel Limited",
                Address1 = "456 Elm Street",
                Address2 = "Floor 3",
                Address3 = "",
                PostCode = "67890",
                Country = "United Kingdom",
                Active = true,
                InsuranceEndDate = DateTime.Parse("2024-05-15")
            }
        };

        /// <summary>
        /// 
        /// </summary>
        public static List<ClaimType> ClaimTypes { get; set; } = new()
        {
            new ClaimType
            {
                Id = 1,
                Name = "Property Damage",
            },
            new ClaimType
            {
                Id = 2,
                Name = "Leaking Roof",
            },
            new ClaimType
            {
                Id = 3,
                Name = "Blocked Pipes",
            },
            new ClaimType
            {
                Id = 4,
                Name = "Broken Windows",
            }
        };

        /// <summary>
        /// 
        /// </summary>
        public static List<Claim> Claims { get; set; } = new()
        {
        
            new Claim
            {
                UCR = "A001",
                CompanyId = 1,
                ClaimDate = DateTime.Parse("2023-01-15"),
                LossDate = DateTime.Parse("2023-01-10"),
                AssuredName = "Porky Pig",
                IncurredLoss = 5000.50m,
                Closed = false,
                ClaimTypeId = 1,
                ClaimType = ClaimTypes?.FirstOrDefault(c => c.Id == 1)!
            },
            new Claim
            {
                UCR = "A002",
                CompanyId = 3,
                ClaimDate = DateTime.Parse("2023-02-20"),
                LossDate = DateTime.Parse("2023-02-15"),
                AssuredName = "Bojack Horseman",
                IncurredLoss = 7500.75m,
                Closed = true,
                ClaimType = ClaimTypes?.FirstOrDefault(c => c.Id == 4)!


            },
            new Claim
            {
                UCR = "A003",
                CompanyId = 3,
                ClaimDate = DateTime.Parse("2023-04-20"),
                LossDate = DateTime.Parse("2023-04-15"),
                AssuredName = "Fred Flintstone",
                IncurredLoss = 1245.44m,
                Closed = true,
                ClaimType = ClaimTypes?.FirstOrDefault(c => c.Id == 4)!


            },
            new Claim
            {
                UCR = "A004",
                CompanyId = 2,
                ClaimDate = DateTime.Parse("2023-04-20"),
                LossDate = DateTime.Parse("2023-04-15"),
                AssuredName = "Sideshow Bob",
                IncurredLoss = 12600.66m,
                Closed = true,
                ClaimType = ClaimTypes?.FirstOrDefault(c => c.Id == 3)!


            }
        };
    }
}
