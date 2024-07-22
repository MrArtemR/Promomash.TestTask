using Promomash.TestTask.Domain.Common;

namespace Promomash.TestTask.Domain.Entities
{
    public class ProvinceEntity : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; private set; }

        public CountryEntity Country { get; private set; }

        public ProvinceEntity(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new AppErrorException("Province name cannot be empty", ErrorCode.ValidationError);
            }
        }
    }
}
