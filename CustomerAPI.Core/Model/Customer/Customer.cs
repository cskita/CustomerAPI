using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GenderModel = CustomerAPI.Core.Model.Gender.Gender;
using CityModel = CustomerAPI.Core.Model.City.City;
using RegionModel = CustomerAPI.Core.Model.Region.Region;
using ClassificationModel = CustomerAPI.Core.Model.Classification.Classification;
using UserSysModel = CustomerAPI.Core.Model.User.UserSys;

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

        [ForeignKey("Gender")]
        [Column("GenderId")]
        public int GenderId { get; set; }

        [ForeignKey("City")]
        [Column("CityId")]
        public int? CityId { get; set; }

        [ForeignKey("Region")]
        [Column("RegionId")]
        public int? RegionId { get; set; }

        [ForeignKey("Classification")]
        [Column("ClassificationId")]
        public int? ClassificationId { get; set; }

        [ForeignKey("UserSys")]
        [Column("UserId")]
        public int? UserId { get; set; }

        public virtual GenderModel Gender { get; set; }
        public virtual CityModel City { get; set; }
        public virtual RegionModel Region { get; set; }
        public virtual ClassificationModel Classification { get; set; }
        public virtual UserSysModel UserSys { get; set; }

    }
}
