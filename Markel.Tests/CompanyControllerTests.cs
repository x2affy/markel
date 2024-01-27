
// ReSharper disable  IdentifierTypo
using Markel.Controllers;
using Markel.Models;
using Markel.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace Markel.Tests;

[TestFixture]
public class CompanyControllerTests
{

    private CompaniesController _sut = null!;
    private ICompanyService _companyServiceMock = null!;
    private ILogger<CompaniesController> _loggerMock = null!;



    [OneTimeSetUp]
    public void OneTimeSetup()
    {
    }

    [SetUp]
    public void Setup()
    {
        _companyServiceMock = Substitute.For<ICompanyService>();
        _loggerMock = Substitute.For<ILogger<CompaniesController>>();
        _sut = new CompaniesController(_companyServiceMock, _loggerMock);

    }

    [TearDown]
    public void TearDown()
    {
        _companyServiceMock.ClearReceivedCalls();
    }

    [Test]
    public void GetCompanyById_Returns_Company_Throw_Exception()
    {
        // Arrange
        var companyId = 1;

        _companyServiceMock.GetCompanyById(companyId).Throws(new Exception("Simulated internal server error"));

        // Act
        var result = _sut.GetCompanyById(companyId);

        // Assert
        Assert.That(result, Is.TypeOf<ObjectResult>());
        var statusCodeResult = (ObjectResult)result;

        Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
        Assert.That(statusCodeResult.Value, Is.EqualTo("GetCompanyById: Internal Server Error - Simulated internal server error"));
    }

    [Test]
    public void GetCompanyById_Returns_Company_Exists()
    {
        // Arrange
        var companyId = 1;
        var companyData = new CompanyDto();

        _companyServiceMock.GetCompanyById(companyId).Returns(companyData);

        // Act
        var result = _sut.GetCompanyById(companyId) as ObjectResult;

        // Assert
        Assert.That(result, Is.TypeOf<OkObjectResult>());
        var okResult = (OkObjectResult)result!;

        Assert.That(okResult.Value, Is.InstanceOf<CompanyDto>());
        var model = (CompanyDto)okResult.Value!;

        Assert.That(model, Is.EqualTo(companyData));
    }

    [Test]
    public void GetCompanyById_ReturnsNotFound_Company_DoesNotExist()
    {
        // Arrange
        var companyId = 1;
        _companyServiceMock.GetCompanyById(companyId).Returns((CompanyDto?)null);

        // Act
        var result = _sut.GetCompanyById(companyId);

        // Assert
        Assert.That(result, Is.TypeOf<NotFoundObjectResult>());
        var notFoundResult = (NotFoundObjectResult)result;

        Assert.That(notFoundResult.Value, Is.EqualTo($"GetCompanyById: Company with ID {companyId} not found."));
    }
}