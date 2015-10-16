using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebApplication5.Models
{
	class UserInitializer :CreateDatabaseIfNotExists<ContextData>
	{
		protected override void Seed(ContextData context)
		{
			var users = new List<User> {
				new User {
					UserId = 1,
					UserName="aaa",
					LoginId="test1",
					LoginPassword="test1234",
					CreatedAt = DateTime.Now
		},
				new User {
					UserId = 2,
					UserName="bbb",
					LoginId="test2",
					LoginPassword="test5678",
					CreatedAt = DateTime.Now
		}
			};
			users.ForEach(a => context.Users.Add(a));

			var memos = new List<Memo> {
				new Memo {
					MemoId = 1,
					Title="aaa",
					Body="aaa",
					CreatedAt = DateTime.Now,
					UpdateAt = DateTime.Now,
					UserId = 1
				},
				new Memo {
					MemoId = 2,
					Title="bbb",
					Body="bbb",
					CreatedAt = DateTime.Now,
					UpdateAt = DateTime.Now,
					UserId = 1
		}
			};
			memos.ForEach(m => context.Memos.Add(m));

			context.SaveChanges();
		}
	}
}
