using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NewProjectESDBETL.Models.Dtos.Common;
using NewProjectESDBETL.Services.Common;

namespace NewProjectESDBETL.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // quy trình khai báo service
        private readonly ILoginService _login_Service;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IMemoryCache _memoryCache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserAuthorizationService _userAuthorizationService;

        public LoginController(
            ILoginService login_Service, 
            IUserService userService, 
            IJwtService jwtService, 
            IRefreshTokenService refreshTokenService, 
            IMemoryCache memoryCache, 
            IHttpContextAccessor httpContextAccessor, 
            IUserAuthorizationService userAuthorizationService
            )
        {
            _login_Service = login_Service;
            _userService = userService;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
            _userAuthorizationService = userAuthorizationService;
        }

        [HttpPost("checklogin")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto loginModel) {
            var result = await _login_Service.CheckLogin(loginModel);
            var returnData = new ResponseModel<AuthorizationResponse>
            {
                HttpResponseMessage = result
            };
            switch (result) {
                case StaticReturnValue.SUCCESS:
                    var data = await _userService.GetByUserName(loginModel.userName);
            }

        }
    }
}
