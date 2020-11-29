using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using AuthorizationService = CustomerAPI.Core.Interface.Service.Authorization;
using CustomerAPI.Core.Model.User;
using CustomerAPI.Application.DTO.Authorization.InputModel;
using Microsoft.AspNetCore.Authorization;
using CustomerAPI.Application.DTO.Authorization.ViewModel;
using CustomerAPI.Framework.Domain;

namespace CustomerAPI.Application.Controllers.Authorization
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private AuthorizationService.IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;

        public AuthController(AuthorizationService.IAuthorizationService authorizationService,
                              IMapper mapper)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
        }

        // POST: api/region
        [AllowAnonymous]
        [HttpPost("")]
        public ActionResult<BaseResult<AuthorizationViewModel>> Authenticate([FromBody] AuthorizationInputModel inputModel)
        {
            var userLogin = _mapper.Map<UserLogin>(inputModel);
            var result = _authorizationService.Authenticate(userLogin);

            if (result.Success)
            {
                var resultMap = _mapper.Map<AuthorizationViewModel>(result.Data);

                return BaseResult<AuthorizationViewModel>.OK(resultMap);
            }

            return Unauthorized();
        }
    }
}
