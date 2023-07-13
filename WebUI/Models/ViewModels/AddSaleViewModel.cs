using Application.Features.Customer.Query.GetAll;
using Application.Features.Product.Query.GetAll;
using Application.Features.User.Query.GetAll;

namespace WebUI.Models.ViewModels
{
    public class AddSaleViewModel
    {
        public List<ProductGetAllDto> ProductList { get; set; }
        public List<CustomerGetAllDto> CustomerList { get; set; }
        public List<UserGetAllDto> UserList { get; set; }
    }
}
