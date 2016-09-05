using Dapper;
using Star4Cast.Models.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Data.Repository
{
    public class UserRepository :RepositoryAbstract
    {
        public static UserRepository Instance
        {
            get
            {
                return new UserRepository();
            }
        }

        public async Task<UserAddress> GetUserAddressAsync(string UserId)
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
                        var userSocilaAddVMist = SqlMapper.QueryAsync<UserAddress>(conn, "SelectUserAddress", param, commandType: CommandType.StoredProcedure);

                        return userSocilaAddVMist.Result.FirstOrDefault();
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
