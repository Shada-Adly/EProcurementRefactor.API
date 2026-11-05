using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Domain.Entities;
using Moq;

namespace EProcurementRefactor.Test.CreateAutomaticMaterialPackageTests
{
    public class AutomaticMaterialPackageTests
    {
        public Task CreateMaterialPackage_ShouldReturnsTrue()
        {
            //Arrange
            var UnitOfWorkMock = new Mock<IUnitOfWork>();
            var PackagesHeaderMock = new Mock<IGenericPackagesRepo<PackagesHeader>>();
            var PackageDetailsMock = new Mock<IGenericPackagesRepo<PackagesDetail>>();

            //Act 
            UnitOfWorkMock.Setup(u => u.BeginTransaction(It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);

            UnitOfWorkMock.Setup(u => u.SaveChangesAsync())
                          .ReturnsAsync(4);

            UnitOfWorkMock.Setup(u => u.CommitTransaction(It.IsAny<CancellationToken>()))
                           .Returns(Task.CompletedTask);
        }
    }
}
