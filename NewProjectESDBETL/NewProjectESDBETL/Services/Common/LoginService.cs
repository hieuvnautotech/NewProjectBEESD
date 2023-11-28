using NewProjectESDBETL.Models.Dtos.Common;

namespace NewProjectESDBETL.Services.Common
{
    public interface ILoginService
    {
        Task<string> CheckLogin(LoginModelDto model);
        Task<ResponseModel<IEnumerable<UserDto>?>> GetOnlineUsers();
    }
    public class LoginService : ILoginService
    {

    }

    
}
