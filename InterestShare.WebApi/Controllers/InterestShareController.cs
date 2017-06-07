using InterestShare.Model;
using InterestShare.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InterestShare.Bll;
using InterestShare.Bll.Bll;
using InterestShare.Bll.IBll;
namespace InterestShare.WebApi.Controllers
{    
    public class InterestShareController : ApiController
    {
        protected IResourceBll Resourcebll
        {
            get
            {
                return BllFactory.GetBLLInstance<ResourceBll>();
            }
        }
        [HttpGet]
        [Route("api-interest-movie")]
        public CommonPagedDataViewModel<ResourceModel> GetDataGridDataByCondition(int page, int rows, string name, string code)
        {
           CommonPagedDataViewModel<ResourceModel> result = new CommonPagedDataViewModel<ResourceModel>();
            try
            {
                result = Resourcebll.GetResourceByCondition(page, rows, name, code);
                
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}
