using System;

namespace CustomerAPI.Application.DTO.Customer.InputModel
{
    public class CustomerInputModel
    {
        public string Name { get; set; }
        public int GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public int? ClassificationId { get; set; }
        public int? SellerId { get; set; }
        public DateTime? LastPurchaseInitial { get; set; }
        public DateTime? LastPurchaseFinal { get; set; }
    }
}
