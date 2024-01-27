using AutoFixture;
using Markel.DataAccess.Abstraction;
using Markel.DomainObjects;
using Markel.Services.Abstraction;
using Markel.Services.Implementation;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

// ReSharper disable once IdentifierTypo
namespace Markel.Tests;

[TestFixture]
public class Tests
{

    private Fixture? _fixture;
    private ICompanyService _sut = null!;
    private ICompanyRepository _companyRepositoryMock = null!;
    private ILogger<CompanyService> _loggerMock = null!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _fixture = new Fixture();
    }

    [SetUp]
    public void Setup()
    {
        _companyRepositoryMock = Substitute.For<ICompanyRepository>();
        _loggerMock = Substitute.For<ILogger<CompanyService>>();

        _sut = new CompanyService(_companyRepositoryMock, _loggerMock);

    }

    [TearDown]
    public void TearDown()
    {
        _companyRepositoryMock.ClearReceivedCalls();
    }


    [Test]

    public void GetCompanyById_Returns_Company_Throw()
    {

        // Arrange
        _companyRepositoryMock.GetCompanyById(Arg.Any<int>()).Throws(new Exception());

        // Act/Assert
        Assert.Throws<Exception>(() => _sut.GetCompanyById(1));
    }

    [Test]
    public void GetCompanyById_Returns_Company_Success()
    {
        // Arrange
        var expected = _fixture.Create<Company>();
        _companyRepositoryMock.GetCompanyById(Arg.Any<int>()).Returns(expected);

        // Act
        var result = _sut.GetCompanyById(_fixture.Create<int>());

        // Assert
        Assert.IsNotNull(result);
    }

    [Test]
    public void GetCompanyById_Returns_Company_FailsWIthNull()
    {
        // Arrange
        _companyRepositoryMock.GetCompanyById(Arg.Any<int>()).Returns((Company?)null);

        // Act
        var result = _sut.GetCompanyById(_fixture.Create<int>());

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void GetCompanyById_Returns_Active_Company_Success()
    {
        // Arrange
        var expected = _fixture.Create<Company>();
        // set active date in future
        expected.InsuranceEndDate = DateTime.Parse("2025-01-01");

        _companyRepositoryMock.GetCompanyById(Arg.Any<int>()).Returns(expected);

        // Act
        var result = _sut.GetCompanyById(_fixture.Create<int>());

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result!.InsurancePolicyActive, Is.EqualTo(true));
    }

    [Test]
    public void GetCompanyById_Returns_Active_Company_Fails()
    {
        // Arrange
        var expected = _fixture.Create<Company>();
        // set active date in past
        expected.InsuranceEndDate = DateTime.Parse("2024-01-01");

        _companyRepositoryMock.GetCompanyById(Arg.Any<int>()).Returns(expected);

        // Act
        var result = _sut.GetCompanyById(_fixture.Create<int>());

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result!.InsurancePolicyActive, Is.EqualTo(false));
    }
}