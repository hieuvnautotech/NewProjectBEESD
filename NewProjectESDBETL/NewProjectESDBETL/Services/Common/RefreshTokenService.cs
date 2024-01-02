﻿using Dapper;
using NewProjectESDBETL.DbAccess;
using static NewProjectESDBETL.Extensions.ServiceExtensions;
using System.Data;
using NewProjectESDBETL.Models.Dtos.Common;

namespace NewProjectESDBETL.Services.Common
{
    public interface IRefreshTokenService
    {
        Task<string> Create(RefreshTokenDto model);
        Task<string> Modify(RefreshTokenDto model);
        Task<RefreshTokenDto?> Get(UserRefreshTokenRequest request);
        Task<HashSet<string>> GetAvailables();
    }

    [SingletonRegistration]
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly ISqlDataAccess _sqlDataAccess;

        public RefreshTokenService(ISqlDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task<string> Create(RefreshTokenDto model)
        {
            string proc = "sysUsp_RefreshToken_Create";
            var param = new DynamicParameters();
            param.Add("@accessToken", model.accessToken);
            param.Add("@refreshToken", model.refreshToken);
            param.Add("@createdDate", model.createdDate);
            param.Add("@expirationDate", model.expiredDate);
            param.Add("@ipAddress", model.ipAddress);
            param.Add("@userId", model.userId);
            param.Add("@isOnApp", model.isOnApp);
            param.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output, size: int.MaxValue);//luôn để DataOutput trong stored procedure
            return await _sqlDataAccess.SaveDataUsingStoredProcedure<string>(proc, param); ;
        }

        public async Task<RefreshTokenDto?> Get(UserRefreshTokenRequest request)
        {
            string proc = "sysUsp_RefreshToken_Get";
            var param = new DynamicParameters();
            param.Add("@accessToken", request.expiredToken);
            param.Add("@refreshToken", request.refreshToken);
            param.Add("@ipAddress", request.ipAddress);

            var data = await _sqlDataAccess.LoadDataUsingStoredProcedure<RefreshTokenDto>(proc, param);
            return data.FirstOrDefault() ?? default;
        }

        public async Task<HashSet<string>> GetAvailables()
        {
            string proc = "sysUsp_RefreshToken_GetAvailables";
            var param = new DynamicParameters();
            var data = await _sqlDataAccess.LoadDataUsingStoredProcedure<string>(proc, param);
            return data.ToHashSet();
        }

        public async Task<string> Modify(RefreshTokenDto model)
        {
            string proc = "sysUsp_RefreshToken_Modify";
            var param = new DynamicParameters();
            param.Add("@refreshTokenId", model.refreshTokenId);
            param.Add("@output", dbType: DbType.String, direction: ParameterDirection.Output);//luôn để DataOutput trong stored procedure
            return await _sqlDataAccess.SaveDataUsingStoredProcedure<string>(proc, param); ;
        }
    }
}
