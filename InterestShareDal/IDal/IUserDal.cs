using InterestShare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestShareDal.IDal
{
    public interface IUserDal
    {
         InterestUser Query(string account);
        List<InterestUser> QueryList(string conditions, object conditionValues);
    }
}
