using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CustomCMS.Models;
using CustomCMS.Core.Model;
using System.Web.Security;
using CustomCMS.Helper;
using CustomCMS.Core.Interface;

namespace CustomCMS.Controllers
{
    public class AccountController : Controller
    {
        #region "Declaration"
        string _Success, _Error;
        ILoginMaster db;
        public AccountController(ILoginMaster db)
        {
            this.db = db;
        }
        #endregion

        #region Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.IsLogin(model))
                {
                    #region Is Remember
                    int timeout = model.IsRemember ? 525600 : 30; // Timeout in minutes, 525600 = 365 days.
                    var ticket = new FormsAuthenticationTicket(model.Email, model.IsRemember, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true; // cookie not available in javascript.
                    Response.Cookies.Add(cookie);
                    #endregion

                    _Success = "You are successfully Logged In";
                    return RedirectToAction("Index", "Home").Success(_Success);
                }
                else
                {
                    _Error = "Email or Password are not quite right.";
                    return View(model).Warning(_Error);
                }
            }
            else
            {
                _Error = "Email or Password are not quite right.";
                return View(model).Warning(_Error);
            }
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
        #endregion
    }
}