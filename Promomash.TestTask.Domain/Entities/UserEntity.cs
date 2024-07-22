using Promomash.TestTask.Domain.Common;
using Promomash.TestTask.Domain.Values;

namespace Promomash.TestTask.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public Login Login { get; private set; }
        public string PasswrdHash { get; private set; }
        public int CountryId { get; private set; }
        public int ProvinceId { get; private set; }

        public CountryEntity Country { get; private set; }
        public ProvinceEntity Province { get; private set; }


        //Нужно для генерации миграции
        public UserEntity() { }

        public UserEntity(Login login, string passwordHash, int countryId, int provinceId)
        {
            Login = login;
            PasswrdHash = passwordHash.Trim();
            CountryId = countryId;
            ProvinceId = provinceId;
            Created = DateTime.UtcNow;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(PasswrdHash))
            {
                throw new AppErrorException("Invalid user password", ErrorCode.InvalidUserPassword);
            }
        }
    }
}
