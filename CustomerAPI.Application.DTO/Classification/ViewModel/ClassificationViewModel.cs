using Swashbuckle.AspNetCore.Annotations;

namespace CustomerAPI.Application.DTO.Classification.ViewModel
{
    public class ClassificationViewModel
    {
        [SwaggerSchema(Description = "Id of classification")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Description of classification")]
        public string Name { get; set; }
    }
}
