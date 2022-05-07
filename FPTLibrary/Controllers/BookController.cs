using DataAccess.DTO;
using System;
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
                        return View();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult BookLibraryParialView(int? PageNumber, int? NumberPerPage)
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
                        if (PageNumber == null && NumberPerPage == null)
                        {
                            PageNumber = 1;
                            NumberPerPage = 6;
                        }
                        var result = new DataAccess.DAOImpl.BookDAOImpl().Books_GetListByPage(PageNumber, NumberPerPage);
                        ViewBag.CurrentPage = PageNumber;
                        ViewBag.NumberPerPage = NumberPerPage;
                        ViewBag.EndPage = (new DataAccess.DAOImpl.BookDAOImpl().Books_GetList().Count) / NumberPerPage + 1;
                        if (PageNumber > ViewBag.EndPage)
                        {
                            return HttpNotFound();
                        }
                        foreach (var item in result)
                        {
                            item.CategoryName = new DataAccess.DAOImpl.CategoryDAOImpl()
                                .Category_GetDetailByID(item.CategoryID).CategoryName;
                        }

                        return PartialView(result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public ActionResult BookDetail(long BookISBN)
        {
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];
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
                    var result = new DataAccess.DAOImpl.BookDAOImpl().Book_GetDetail(BookISBN);
                    return View(result);

                }
            }
        }

    }
}