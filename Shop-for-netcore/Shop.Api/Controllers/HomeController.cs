
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventCloud.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : EventCloudControllerBase
    {
        public ActionResult Index()
        {
            return  View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}