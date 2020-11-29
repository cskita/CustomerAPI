using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.Region.ViewModel
{
    public class RegionViewModel
    {
        [SwaggerSchema(Description = "Id of region")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Name of region")]
        public string Name { get; set; }
    }
}
