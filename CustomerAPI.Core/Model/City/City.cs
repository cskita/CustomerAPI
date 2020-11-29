using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RegionModel = CustomerAPI.Core.Model.Region;

namespace CustomerAPI.Core.Model.City
{
    [Table("City")]
    public class City
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [ForeignKey("Region")]
        [Column("RegionId")]
        public int RegionId { get; set; }

        public virtual RegionModel.Region Region { get; set; }
    }
}
