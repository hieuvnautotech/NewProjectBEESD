using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NewProjectESDBETL.Extensions;
using NewProjectESDBETL.Helpers;
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
        private readonly ILoginService _loginService;
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
            _loginService = login_Service;
            _userService = userService;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _memoryCache = memoryCache;
            _httpContextAccessor = httpContextAccessor;
            _userAuthorizationService = userAuthorizationService;
        }

        [HttpPost("checklogin")]
        public async Task<IActionResult> Login([FromBody] LoginModelDto loginModel)
        {
            var result = await _loginService.CheckLogin(loginModel);
            var returnData = new ResponseModel<AuthorizationResponse>
            {
                ResponseMessage = result
            };
            switch (result)
            {
                case StaticReturnValue.SUCCESS:
                    var data = await _userService.GetByUserName(loginModel.userName);
                    //user.RoleNames = await _userService.GetUserRole(user.UserId);
                    //user.PermissionNames = await _userService.GetUserPermission(user.UserId);

                    //var menus = await _menuService.GetTreeMenuUserId(data.Data.UserId);
                    //if (menus != null)
                    //    data.Data.Menus = menus;

                    var authResponse = await _jwtService.GetTokenAsync(data.Data);
                    data.Data.Token = authResponse.accessToken;

                    var userRefreshTokenModel = new RefreshTokenDto
                    {
                        accessToken = authResponse.accessToken,
                        refreshToken = authResponse.refreshToken,
                        createdDate = DateTime.UtcNow,
                        expiredDate = DateTime.UtcNow.AddDays(60),
                        //ExpirationDate = DateTime.UtcNow.AddSeconds(60),
                        //IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                        ipAddress = UserIPHelper.UserIp,
                        isValidated = false,
                        userId = data.Data.userId,
                        isOnApp = loginModel.isOnApp
                    };

                    if (await _refreshTokenService.Create(userRefreshTokenModel) == StaticReturnValue.SUCCESS)
                    {
                        var availableTokens = _refreshTokenService.GetAvailables();
                        _memoryCache.Remove("availableTokens");
                        _memoryCache.Set("availableTokens", availableTokens.Result);
                        data.Data.RefreshToken = authResponse.refreshToken;
                        //returnData.Data = data.Data;
                        //returnData.ResponseMessage = StaticReturnValue.SUCCESS;
                        if ((bool)!loginModel.isOnApp)
                            await _userService.SetLastLoginOnWeb(data.Data);
                        else
                            await _userService.SetLastLoginOnApp(data.Data);

                        //_httpContextAccessor.HttpContext.Response.Headers["access-token"] = authResponse.accessToken;
                        //_httpContextAccessor.HttpContext.Response.Headers["refresh-token"] = authResponse.refreshToken;

                        var userAuthorization = _userAuthorizationService.GetUserAuthorization();
                        _memoryCache.Remove("userAuthorization");
                        _memoryCache.Set("userAuthorization", userAuthorization.Result);

                        returnData.Data = authResponse;
                    }
                    else
                    {
                        //returnData.HttpResponseCode = 500;
                        //returnData.ResponseMessage = StaticReturnValue.SYSTEM_ERROR;
                        returnData.HttpResponseCode = 500;
                        returnData.ResponseMessage = StaticReturnValue.SYSTEM_ERROR;
                    }

                    break;

                case StaticReturnValue.ACCOUNT_PASSWORD_INVALID:
                //returnData.HttpResponseCode = 400;
                //returnData.ResponseMessage = StaticReturnValue.ACCOUNT_PASSWORD_INVALID;
                //break;
                case StaticReturnValue.ACCOUNT_BLOCKED:
                    //    returnData.HttpResponseCode = 400;
                    //    returnData.ResponseMessage = StaticReturnValue.ACCOUNT_BLOCKED;
                    //    break;
                    returnData.HttpResponseCode = 400;
                    break;
                default:
                    //returnData.HttpResponseCode = 500;
                    //returnData.ResponseMessage = StaticReturnValue.SYSTEM_ERROR;
                    returnData.HttpResponseCode = 500;
                    returnData.ResponseMessage = StaticReturnValue.SYSTEM_ERROR;
                    break;
            }

            return Ok(returnData);
        }
    }
}
