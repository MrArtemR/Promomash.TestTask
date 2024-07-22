using Moq;
using Promomash.TestTask.Application.Interfaces;
using Promomash.TestTask.Application.Managers;
using Promomash.TestTask.Domain.Common;

namespace Promomash.TestTask.Tests
{
    public class UserManagerTests
    {
        [Fact]
        public void If_password_is_invalid_should_be_teturn_fail_result()
        {
            // arrange
            var passwordHasher = new Mock<IPasswordHasher>();
            var passwordValidator = new Mock<IPasswordValidator>();
            passwordValidator
                .Setup(x => x.Validate(It.IsAny<string>()))
                .Returns(false);

            var userManager = new UserManager(passwordHasher.Object, passwordValidator.Object);

            // act
            var hasedPassword = userManager.HashPassword(string.Empty);

            // assert
            Assert.False(hasedPassword.IsSuccess);
            Assert.Equal(ErrorCode.InvalidUserPassword, hasedPassword.ErrorCode);
        }
    }
}
