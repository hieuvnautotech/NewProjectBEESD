using Dapper;
using NewProjectESDBETL.Models.Dtos.Common;

namespace NewProjectESDBETL.Services.Common
{
    public interface ILoginService
    {
        Task<string> CheckLogin(LoginModelDto model);
        Task<ResponseModel<IEnumerable<UserDto>?>> GetOnlineUsers();
    }

    [SingletonRegistration]
    public class LoginService : ILoginService
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public LoginService(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<string> CheckLogin(LoginModelDto model) {
            model.userPassword = MD5Encryptor.MD5Hash(model.userPassword);
            string proc = "sysUsp_User_CheckLogin";
            var param = new DynamicParameters();
            param.Add("@userName", model.userName);
            param.Add("@userPassword", model.userPassword);

            var data = await _sqlDataAccess.LoadDataUsingStoredProcedure<string>(proc, param);
            return data.FirstOrDefault() ?? string.Empty;
        }
    }

    
}
