using System;
using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.Customer.ViewModel
{
    public class CustomerViewModel
    {
        [SwaggerSchema(Description = "Id of customer")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Name of customer")]
        public string Name { get; set; }

        [SwaggerSchema(Description = "Phone of customer")]
        public string Phone { get; set; }

        [SwaggerSchema(Description = "Last purchase of customer")]
        public DateTime LastPurchase { get; set; }

        [SwaggerSchema(Description = "Gender ID of customer")]
        public int GenderId { get; set; }

        [SwaggerSchema(Description = "Gender description of customer")]
        public string GenderDescription { get; set; }

        [SwaggerSchema(Description = "City ID of customer")]
        public int? CityId { get; set; }

        [SwaggerSchema(Description = "City description of customer")]
        public string CityDescription { get; set; }

        [SwaggerSchema(Description = "Region ID of customer")]
        public int? RegionId { get; set; }

        [SwaggerSchema(Description = "Region description of customer")]
        public string RegionDescription { get; set; }

        [SwaggerSchema(Description = "Classification ID of customer")]
        public int? ClassificationId { get; set; }

        [SwaggerSchema(Description = "Classification description of customer")]
        public string ClassificationDescription { get; set; }

        [SwaggerSchema(Description = "Seller ID of customer")]
        public int? SellerId { get; set; }

        [SwaggerSchema(Description = "Seller name of customer")]
        public string SellerName { get; set; }
    }
}
