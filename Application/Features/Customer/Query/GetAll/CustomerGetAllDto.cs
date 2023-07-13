namespace Application.Features.Customer.Query.GetAll
{
    public class CustomerGetAllDto
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }
    }
}