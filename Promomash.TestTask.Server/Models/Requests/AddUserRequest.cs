namespace Promomash.TestTask.Server.Models.Requests
{
    public class AddUserRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public int ProvinceId { get; set; }
    }
}
