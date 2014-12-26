using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Classified.Models;
using System.Web.Security;

namespace Classified.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        UserManager objUserManager = new UserManager();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Profile

        [AllowAnonymous]
        public ActionResult Profile(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if(User.Identity.IsAuthenticated)
            {
               return View(objUserManager.getUserByUsername(User.Identity.Name.ToString()));
            }
            return View();
        }


        //
        // POST: /Account/Profile

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(UserModel model)
        {
            objUserManager.updateUserByUsername(model);

            //    if (ModelState.IsValid)
            //    {
            //        // Attempt to register the user
            //        try
            //        {
            //            WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
            //            WebSecurity.Login(model.UserName, model.Password);
            //            model.Role = "basic";
            //            model.DateAdded = DateTime.Today;
            //            userManager.registerUser(model);
            //            Roles.AddUserToRole(model.UserName, "basic");
            //            return RedirectToAction("Index", "Home");
            //        }
            //        catch (MembershipCreateUserException e)
            //        {
            //            ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
            //            return View(model);
            //        }
            //    }
            //    else
            //    {
                    return View(model);
            //    }
            //    // If we got this far, something failed, redisplay form  
            //}

        }
    }
}
