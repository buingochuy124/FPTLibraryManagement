using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FPTLibrary.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
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
                        return RedirectToAction("BookLibraryPartialView", "Book");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult BookLibraryPartialView()
        {
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];

            var result = new List<DataAccess.DTO.BookDTO>();
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
                        result = new DataAccess.DAOImpl.BookDAOImpl().Books_GetList();

                        return PartialView(result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
      
        }

    }
}