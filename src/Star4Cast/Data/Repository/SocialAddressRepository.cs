using Microsoft.Extensions.Configuration;
using Star4Cast.ViewModels.ProfileManage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Star4Cast.Data.Repository
{
    public class SocialAddressRepository : RepositoryAbstract
    {
        public static SocialAddressRepository Instance
        {
            get
            {
                return new SocialAddressRepository();
            }
        }

        public async Task<List<UserSocilaAddVM>> GetSocialAddressAsync(string UserId)
        {
            return await Task.Factory.StartNew(() =>
            {
                try
                {
                    using (var conn = SQLConnection)
                    {
                        if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
                            conn.OpenAsync();

                        var param = new DynamicParameters();
                        param.Add("@UserId", UserId);
                        var userSocilaAddVMist = SqlMapper.QueryAsync<UserSocilaAddVM>(conn, "SelectSocialAddress", param, commandType: CommandType.StoredProcedure).Result.ToList();

                        return userSocilaAddVMist.ToList();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}
