using BL.Interfaces;
using Core.Contracts.PL_BL;
using Microsoft.AspNetCore.Mvc;
using PL.CustomComponent;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.Controllers
{
    public class UserController : ControllerWithUserSession
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        // registration actions:

        public IActionResult RegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegistrationPageVM newUser)
        {
            var nuc = new NewUserContract()
            {
                Login = newUser.Login,
                Password = newUser.Password,
                ConfirmPassword = newUser.ConfirmPassword,
                Name = newUser.Name,
                Surname = newUser.Surname
            };

            var response = userService.RegisterUser(nuc);

            TempData["ToastMessage"] = response.Message;

            if (response.IsSuccessful)
                return RedirectToAction("Index", "Home");
            else
                return RedirectToAction("LoginPage");
        }

        // login actions:

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginPageVM lpvm)
        {
            var lic = new LoggingInContract()
            {
                Login = lpvm.Login,
                Password = lpvm.Password
            };

            var result = userService.LogInUser(lic);

            TempData["ToastMessage"] = result.Message;

            if (result.IsSuccessful)
            {
                SessionLoggedInInfo = result.Data;

                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("LoginPage");
        }

        public IActionResult Logout()
        {
            ClearSessionData();

            return RedirectToAction("Index", "Home");
        }

        // user info actions:

        public IActionResult AccountDetailsPage()
        {
            var userInfo = SessionLoggedInInfo;
            var acpvm = new AccountDetailsPageVM()
            {
                Age = userInfo.Age,
                Email = userInfo.Email,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            };

            return View(acpvm);
        }

        [HttpPost]
        public IActionResult UpdateUserInfo(AccountDetailsPageVM acpvm)
        {
            var uuic = new UserUpdateInfoContract()
            {
                Age = acpvm.Age,
                Email = acpvm.Email,
                Name = acpvm.Name,
                Surname = acpvm.Surname
            };

            var response = userService.UpdateUserInfo((int)SessionUserId, uuic);

            TempData["ToastMessage"] = response.Message;

            if (response.IsSuccessful)
                SessionLoggedInInfo = response.Data;

            return RedirectToAction("AccountDetailsPage");
        }

        // shopping cart actions:

        public IActionResult ShoppingCartPage()
        {
            return View();
        }

        [HttpPost]
        public string AddToShoppingCartById(int productId)// is requested via ajax
        {
            string responseMessage;
            if (SessionUserId == null)
                responseMessage = "Log in first";
            else
                responseMessage = userService.AddProductToShopptingCart(productId, (int)SessionUserId).Message;

            return responseMessage;// returns message for toast
        }

        public IActionResult GetUserShoppingCartItems()
        {
            var result = userService.GetUserShoppingCartItems((int)SessionUserId).Data;
            return Json(result);
        }

        // orders actions

        public IActionResult ConfirmOrder()
        {
            var response = userService.ConfirmOrder((int)SessionUserId);

            TempData["ToastMessage"] = response.Message;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserOrdersPage()
        {
            var response = userService.GetUserOrders((int)SessionUserId).Data;

            var uopvm = new UserOrdersPageVM()
            {
                ItemsPurchased = response,
            };

            return View(uopvm);
        }
    }
}
