using InterestShare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterestShare.Bll.IBll
{
    public interface IUserBll
    {
        InterestUser Query(string account);
        InterestUser Query(string account,string password);
    }
}
