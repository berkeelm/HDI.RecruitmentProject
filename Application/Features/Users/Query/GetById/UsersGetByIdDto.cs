using Domain.Enums;

namespace Application.Features.Users.Query.GetById
{
    public class UsersGetByIdDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}