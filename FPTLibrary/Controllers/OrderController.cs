using DataAccess.DTO;
using FPTLibrary.Models;
using System;
using System.Web.Mvc;

namespace FPTLibrary.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderRecord(long BookISBN)
        {
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];
            try
            {
                if (userSession == null)
                {
                    return RedirectToAction("Login", "Unauthenticate");

                }
                else
                {
                    if (userSession.RoleID != 2)
                    {
                        return RedirectToAction("DoNotHavePermission", "Shared");
                    }
                    else
                    {
                        var result = new DataAccess.DAOImpl.OrderDAOImpl().Orders_GetListByUser(userSession.UserID);
                        return View(result);

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public ActionResult OrderRecord()
        {
            return View();

        }
    }
}