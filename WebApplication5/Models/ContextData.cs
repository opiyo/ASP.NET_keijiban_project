using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
	[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
	class ContextData :DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Memo> Memos { get; set; }
	}
}
