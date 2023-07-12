using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : EntityBase
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}