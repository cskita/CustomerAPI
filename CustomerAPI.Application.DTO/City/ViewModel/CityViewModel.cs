using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.City.ViewModel
{
    public class CityViewModel
    {
        [SwaggerSchema(Description = "Id of City")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Name of city")]
        public string Name { get; set; }

        [SwaggerSchema(Description = "Id region of city.")]
        public int RegionId { get; set; }
    }
}
