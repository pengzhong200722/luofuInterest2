using InterestShareDal.IDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterestShare.Model.Models;
using EB.SaleChannnel.DAL;

namespace InterestShareDal.Dal
{
    public class UserDal : BaseDAL, IUserDal
    {
        public InterestUser Query(string account)
        {
            InterestUser result = new InterestUser();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select * from User where Account=@Account");
                result = EBDapperHelper.Query<InterestUser>(sql.ToString(), new { Account = account }).FirstOrDefault();
            }
            catch(Exception ex)
            {

            }
            return result;
        }

        public List<InterestUser> QueryList(string conditions, object conditionValues)
        {
            return EBDapperHelper.Query<InterestUser>(SqlCommandBuilder.GetSelectCommandStringByType<InterestUser>(conditions), conditionValues).ToList();
        }
    }
}
