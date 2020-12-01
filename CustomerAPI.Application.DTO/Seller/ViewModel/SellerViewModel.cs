using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.Seller.ViewModel
{
    public class SellerViewModel
    {
        [SwaggerSchema(Description = "Id of seller")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Name of seller")]
        public string Name { get; set; }
    }
}
