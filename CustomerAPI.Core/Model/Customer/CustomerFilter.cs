using System;

namespace CustomerAPI.Core.Model.Customer
{
    public class CustomerFilter
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? GenderId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public int? ClassificationId { get; set; }
        public int? SellerId { get; set; }
        public DateTime? LastPurchaseInitial { get; set; }
        public DateTime? LastPurchaseFinal { get; set; }

    }
}
