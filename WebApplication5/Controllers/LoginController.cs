using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
	public class LoginController : Controller
    {
		private ContextData context = new ContextData();

		public ActionResult Login()
		{
			//非ログイン時ログイン画面へ
			if (Session["id"] != null && Session["password"] != null)
			{
				return RedirectToAction("Index", "Article");
			}
			else
			{
				return View();
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Login(string id, string password)
		{
			var user = from a in context.Users
						  where a.LoginId == id && a.LoginPassword == password
						  select a;
			if (!user.Any())
			{
				return RedirectToAction("Login");
			}
			else
			{
				Session["id"] = id;
				Session["password"] = password;
				return RedirectToAction("Index", "Article");
			}
		}
    }
}