using InterestShare.Bll.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestShare.Model.Models;
using InterestShareDal.IDal;
using InterestShareDal;
using InterestShareDal.Dal;
using luofu_InterestShare.Common.Log;
namespace InterestShare.Bll.Bll
{
    public class UserBll : BaseBLL, IUserBll
    {
        public IUserDal UserDAL
        {
            get
            {
                return DalFactory.GetDalInstance<UserDal>();
            }
        }
        public InterestUser Query(string account)
        {
            return UserDAL.Query(account);
        }

        public InterestUser Query(string account, string password)
        {
            InterestUser model = new InterestUser();
            try
            {
                string sqlWher = "";
                sqlWher += " Account=@Account and Password=@Password ";
                var user = UserDAL.QueryList(sqlWher, new { Account = account, Password = password });
                if (user != null && user.Count > 0)
                {
                    model = user[0];
                }
            }
            catch (Exception ex)
            {
                FileLog.WriteLog(ex.ToString());
                return null;
            }
            return model;
        }
    }
}
