using DataAccess.DTO;
using FPTLibrary.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FPTLibrary.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cart()
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
                    if (userSession.UserID != 2)
                    {
                        return RedirectToAction("DoNotHavePermission", "Shared");
                    }
                    else
                    {
                        var result = new DataAccess.DAOImpl.CartDAOImpl().Carts_GetCartByUser(userSession.UserID);
                        ViewBag.User = userSession;
                        return View(result);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public JsonResult AddBookToCart(long BookISBN)
        {
            var returnData = new ReturnData();
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];


            try
            {

                var result = new DataAccess.DAOImpl.CartDAOImpl().Cart_AddBookToCart(BookISBN, userSession.UserID);

                if (result > 0)
                {
                    returnData.ResponseCode = 99;
                    returnData.Description = "Added Book to cart";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    returnData.ResponseCode = -99;
                    returnData.Description = "Some thing went Wrong!! Please try again";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }



            }
            catch (Exception)
            {
                returnData.ResponseCode = -999;
                returnData.Description = "System Bussy!! Please try again";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult BookInCartPartialView()
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
                    var cartsOfUser = new DataAccess.DAOImpl.CartDAOImpl().Carts_GetCartByUser(userSession.UserID);
                    var result = new List<DataAccess.DTO.BookDTO>();
                    foreach (var item in cartsOfUser)
                    {
                        result.Add(new DataAccess.DAOImpl.BookDAOImpl().Book_GetDetail(item.BookISBN));
                    }
                    
                    return PartialView(result);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        public JsonResult CheckOut(string Quantity)
        {
            var userSession = (UserDTO)Session[DataAccess.Libs.Config.SessionAccount];

            var cartsOfUser = new DataAccess.DAOImpl.CartDAOImpl().Carts_GetCartByUser(userSession.UserID);
            var listBook = new List<DataAccess.DTO.BookDTO>();
            double total = 0;
            cartsOfUser.Reverse();

            foreach (var item in cartsOfUser)
            {
                listBook.Add(new DataAccess.DAOImpl.BookDAOImpl().Book_GetDetail(item.BookISBN));
            }
            for (int i = 0; i < listBook.Count; i++)
            {
                foreach (var item in listBook)
                {
                    item.Quantity = int.Parse(Quantity.Split('_')[i]);
                    total += item.Quantity*item.Cost;
                }
            }
            DateTime date = DateTime.Now;

            var createOrder = new DataAccess.DAOImpl.OrderDAOImpl()
                .Order_Create(userSession.UserID, total, date);
            foreach (var item in listBook)
            {
                var createOrderDetail = new DataAccess.DAOImpl.OrderDetailImpl()
                    .OrderDetail_Create(item.BookISBN,item.Quantity,)

            }

            var returnData = new ReturnData();
     
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }
    }
}