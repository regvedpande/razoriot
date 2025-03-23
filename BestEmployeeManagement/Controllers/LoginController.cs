using BestEmployeeManagement.Models;
using System.Security.Policy;
using System.Web.Mvc;

namespace BestEmployeeManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserDAL _userDAL;

        public LoginController()
        {
            _userDAL = new UserDAL();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(RegisterUserModel user)
        {
            var response = _userDAL.UserLogin(user);
            if (response.Status)
            {
                Session["UserName"] = user.Username;
                Session["IsAuthenticated"] = true;
                return Json(new { Status = true, Message = "Login successful", RedirectUrl = Url.Action("Index", "Employee") });
            }
            else
            {
                return Json(new { Status = false, Message = response.Message });
            }
        }

        public ActionResult Register()
        {
            var roles = _userDAL.GetRoles();
            ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterUserModel user)
        {
            var response = _userDAL.RegisterUser(user);
            if (response.Status)
            {
                TempData["Message"] = "User registered successfully.";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = response.Message;
                return View();
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            var response = _userDAL.ForgotPassword(model);
            if (response.Status)
            {
                TempData["Message"] = response.Message;
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = response.Message;
                return View();
            }
        }
    }


}
