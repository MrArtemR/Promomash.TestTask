using Promomash.TestTask.Domain.Common;
using Promomash.TestTask.Domain.Entities;
using Promomash.TestTask.Domain.Values;

namespace Promomash.TestTask.Tests
{
    public class EntityTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("test")]
        public void If_login_is_invalid_should_be_fail_result(string login)
        {
            // arrange
            var loginResult = Login.Create(login);

            // act

            // assert
            Assert.False(loginResult.IsSuccess);
            Assert.Equal(ErrorCode.ValidationError, loginResult.ErrorCode);
        }

        [Fact]
        public void If_password_is_invalid_should_be_throw_exception()
        {
            // arrange
            var loginResult = Login.Create("test@mail.com");

            // act
            var exception = Assert.Throws<AppErrorException>(() => new UserEntity(loginResult.Value, string.Empty, 1, 1));

            // assert
            Assert.Equal(ErrorCode.InvalidUserPassword, exception.ErrorCode);
        }
    }
}