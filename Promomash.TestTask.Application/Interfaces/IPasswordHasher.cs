namespace Promomash.TestTask.Application.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
