using CustomerAPI.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAPI.Application.DTO.Authorization.InputModel
{
    public class AuthorizationInputModel : ModelBase
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public override void Validate()
        {
            new FieldValidation<AuthorizationInputModel>(this)
                .IsRequired(c => c.Email, "Email")
                .IsRequired(c => c.Password, "Password");
        }
    }
}
