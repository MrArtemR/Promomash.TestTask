using Promomash.TestTask.Domain.Common;

namespace Promomash.TestTask.Domain.Entities
{
    public class CountryEntity : BaseEntity
    {
        public string Name { get; private set; }

        public CountryEntity(string name)
        {
            Name = name;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new AppErrorException("Country name cannot be empty", ErrorCode.ValidationError);
            }
        }
    }
}
