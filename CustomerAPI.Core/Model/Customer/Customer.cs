using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.Core.Model.Customer
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Phone")]
        public string Phone { get; set; }

        [Column("LastPurchase")]
        public DateTime LastPurchase { get; set; }

        [Column("GenderId")]
        public int GenderId { get; set; }

        [Column("CityId")]
        public int? CityId { get; set; }

        [Column("RegionId")]
        public int? RegionId { get; set; }

        [Column("ClassificationId")]
        public int? ClassificationId { get; set; }

        [Column("UserId")]
        public int? UserId { get; set; }
    }
}
