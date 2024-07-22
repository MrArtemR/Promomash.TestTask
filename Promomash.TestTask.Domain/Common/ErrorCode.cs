namespace Promomash.TestTask.Domain.Common
{
    public enum ErrorCode
    {
        UnknowErorr = 0,
        ValidationError = 1,
        UserWithThisLoginAlreadyExists = 2,
        CountryNotFound = 3,
        ProvinceNotFounde = 4,
        InvalidUserPassword = 5,
    }
}
