using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication5.Models;
using System.Data.Entity;
using System.Net;

namespace WebApplication5.Controllers
{
	public class ArticleController : Controller
    {
		private ContextData context = new ContextData();
        
		//一覧表示
        public ActionResult Index()
        {
			//非ログイン時ログイン画面へ
			if (Session["id"] == null || Session["password"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				//ユーザー・メモ情報のリストを渡す
				var memos = from p in context.Memos
							 join q in context.Users
							 on p.UserId equals q.UserId
							 select p;
				return View(memos.ToList());
			}
		}

		//詳細画面
		public ActionResult Details(int? id)
		{
			//非ログイン時ログイン画面へ
			if (Session["id"] == null || Session["password"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				//ユーザー・メモ情報を１つ渡す
				var memo = (from p in context.Memos
							  join q in context.Users
						on p.UserId equals q.UserId
							  where (p.MemoId == id)
							  select p).SingleOrDefault();
				if (memo == null)
				{
					return HttpNotFound();
				}
				return View(memo);
			}
		}

		//新規作成画面
		public ActionResult Create()
		{
			//非ログイン時ログイン画面へ
			if (Session["id"] == null || Session["password"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				return View();
			}
		}

		//新規作成画面
		[HttpPost]
		[ValidateAntiForgeryToken()]
		public ActionResult Create(Memo memo)
		{
			if (ModelState.IsValid)
			{
				string id = (string)Session["id"];
				string password = (string)Session["password"];
				User user = (from p in context.Users
							 where (p.LoginId == id && p.LoginPassword == password)
							 select p).Single();

				memo.User = user;
				memo.UserId = user.UserId;
				memo.CreatedAt = DateTime.Now;
				memo.UpdateAt = DateTime.Now;
				context.Memos.Add(memo);
				context.SaveChanges();
				context.Entry(memo).State = EntityState.Unchanged;

				return RedirectToAction("Index");
			}
			return View(memo);
		}

		public ActionResult Edit(int? id)
		{
			//非ログイン時ログイン画面へ
			if (Session["id"] == null || Session["password"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				if (id == null)
				{
					return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
				}
				Memo memo = context.Memos.Find(id);
				if (memo == null)
				{
					return HttpNotFound();
				}
				ViewBag.MemoId = memo.MemoId;
				ViewBag.UserId = memo.UserId;
				ViewBag.CreatedAt = memo.CreatedAt;
				return View(memo);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken()]
		public ActionResult Edit( Memo memo)
		{
			User user = (from p in context.Users
						 where (p.UserId == memo.UserId)
						 select p).SingleOrDefault();

			memo.User = user;
			memo.UpdateAt = DateTime.Now;
			context.Entry(memo).State = EntityState.Modified;
            context.SaveChanges();
			return RedirectToAction("Details", new { id = memo.MemoId});
		}

		public ActionResult Delete(int? id)
		{
			//非ログイン時ログイン画面へ
			if (Session["id"] == null || Session["password"] == null)
			{
				return RedirectToAction("Login", "Login");
			}
			else
			{
				Memo memo = context.Memos.Find(id);
				return View(memo);
			}
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken()]
		public ActionResult DeleteConfirmed(int id)
		{
			Memo memo = context.Memos.Find(id);
			memo.DeletedAt = DateTime.Now;
			memo.DeleteFlg = true;
			context.Entry(memo).State = EntityState.Modified;
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
