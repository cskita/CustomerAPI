using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Application.DTO.User.ViewModel
{
    public class UserViewModel
    {
        [SwaggerSchema(Description = "Id of user")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Login of user")]
        public string Login { get; set; }

        [SwaggerSchema(Description = "E-mail of user.")]
        public string Email { get; set; }

        [SwaggerSchema(Description = "Indicates if the user is adminstrator.")]
        public bool IsAdmin { get; set; }
    }
}
