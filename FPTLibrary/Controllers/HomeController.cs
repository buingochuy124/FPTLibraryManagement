using DataAccess.DTO;
using System.Web.Mvc;

namespace FPTLibrary.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];

            try
            {
                if (userSession == null)
                {

                    return RedirectToAction("DoNotHavePermission", "Shared");
                }
                else
                {
                    if (userSession.RoleID == 1)
                    {
                        return RedirectToAction("UserManagement", "User");
                    }
                    else if (userSession.RoleID == 2)
                    {
                        return RedirectToAction("Index", "Book");
                    }
                    else if (userSession.RoleID == 3)
                    {
                        return RedirectToAction("StoreManagement", "Store");
                    }
                }

            }
            catch (System.Exception)
            {

                throw;
            }


            ViewBag.UserRoleID = userSession.RoleID;
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