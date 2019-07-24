using CustomCMS.Core.Interface;
using CustomCMS.Core.Model;
using CustomCMS.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCMS.Infrastructure.Repository
{
    public class LoginMasterRepository : ILoginMaster
    {
        #region "Declaration"
        private static DBHelper objDBHelper = new DBHelper();
        #endregion

        #region Login
        public Boolean IsLogin(LoginModel obj)
        {
            Boolean Status = false;
            try
            {
                objDBHelper = new DBHelper();
                objDBHelper.Command.Parameters.Clear();
                objDBHelper.AddParameter("LEmail", obj.Email);
                objDBHelper.AddParameter("LPassword", PasswordHelper.Encrypt(obj.Password));

                using (DbDataReader dr = objDBHelper.ExecuteReader(SPName.spLogin, CommandType.StoredProcedure))
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Status = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Status;
        }
        #endregion
    }
}
