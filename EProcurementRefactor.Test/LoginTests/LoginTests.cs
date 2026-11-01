using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Domain.Entities;
using EProcurementRefactor.Infrastructure.Reposetories;
using Moq;
using System.Linq.Expressions;

namespace EProcurementRefactor.Test.LoginTests
{
    public class LoginTests
    {
        [Fact]
        public async Task Login_ReturnsTheRegisterdAdmin_WhenCredentialsAreValid()
        {
            var cancellationToken = CancellationToken.None;

            //Arrange
            var adminLogiDto = new AdminLoginDto("Ali", "123456");

            var genericRepoMock = new Mock<IGenericRepository<SiacAdmin>>();

            var passwordServiceMock = new Mock<IPasswordService>();

            var expectedAdmin = new SiacAdmin
            {
                Id = 1,
                Username = "Ali",
                Password = "123456"
            };

            genericRepoMock
            .Setup(x => x.FindByFirstOrDefault(
                It.IsAny<Expression<Func<SiacAdmin, bool>>>(),
                cancellationToken))
            .ReturnsAsync(expectedAdmin);

            passwordServiceMock
            .Setup(x => x.VerifyPassword(
                adminLogiDto.password,
                expectedAdmin.Password))
            .Returns(true);

            // Act
            var adminRepo = new AdminRepository(genericRepoMock.Object,passwordServiceMock.Object);

            var result = await adminRepo.Login(
            adminLogiDto,
            cancellationToken);

            //Assert
            Assert.Equal(expectedAdmin, result);
        }

        [Fact]
        public async Task Login_ThrowsKeyNotFoundException_WhenUsernameNotFound()
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            var genericRepoMock = new Mock<IGenericRepository<SiacAdmin>>();
            var passwordServiceMock = new Mock<IPasswordService>();

            genericRepoMock
                .Setup(x => x.FindByFirstOrDefault(
                    It.IsAny<Expression<Func<SiacAdmin, bool>>>(),
                    cancellationToken))
                .ReturnsAsync((SiacAdmin?)null);

            var adminRepo = new AdminRepository(
                genericRepoMock.Object,
                passwordServiceMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(
                () => adminRepo.Login(
                    new AdminLoginDto("Ramy", "123"),
                    cancellationToken));
        }

    }
}
