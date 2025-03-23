using System.Web.Mvc;

public class AccountController : Controller
{
    public ActionResult Logout()
    {
        Session.Clear();
        Session.Abandon();
        return RedirectToAction("Login", "Login");
    }
}
