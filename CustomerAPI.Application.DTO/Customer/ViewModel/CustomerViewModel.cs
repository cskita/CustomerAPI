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

        [SwaggerSchema(Description = "Id gender of customer")]
        public int GenderId { get; set; }

        [SwaggerSchema(Description = "Id city of customer")]
        public int? CityId { get; set; }

        [SwaggerSchema(Description = "Id region of customer")]
        public int? RegionId { get; set; }

        [SwaggerSchema(Description = "Id classification of customer")]
        public int? ClassificationId { get; set; }

        [SwaggerSchema(Description = "Id user of customer")]
        public int? UserId { get; set; }
    }
}
