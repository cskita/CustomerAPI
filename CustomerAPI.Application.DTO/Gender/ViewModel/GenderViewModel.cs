using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.Gender.ViewModel
{
    public class GenderViewModel
    {
        [SwaggerSchema(Description = "Id of gender")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Name of gender")]
        public string Name { get; set; }
    }
}
