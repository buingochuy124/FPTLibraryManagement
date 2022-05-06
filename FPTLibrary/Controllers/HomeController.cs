using DataAccess.DTO;
using System.Web.Mvc;

namespace FPTLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];
            ViewBag.UserAccount = userSession;
            return View();
        }
        public ActionResult PopupPartial(string title, string msg)
        {
            ViewBag.title = title;
            ViewBag.msg = msg;
            return PartialView();
        }
    }
}