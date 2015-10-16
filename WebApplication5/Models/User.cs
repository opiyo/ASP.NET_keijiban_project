using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
	public class User
	{
		[Key]
		[DisplayName("ユーザーID")]
		public int UserId { get; set; }
		[DisplayName("名前")]
		public string UserName { get; set; }
		[DisplayName("ログインID")]
		public string LoginId { get; set; }
		[DisplayName("ログインパスワード")]
		public string LoginPassword { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 HH:mm:SS}")]
		[DisplayName("最終ログイン日時")]
		public DateTime LastLoginAt { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 HH:mm:SS}")]
		[DisplayName("作成日")]
		public DateTime CreatedAt { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 HH:mm:SS}")]
		[DisplayName("更新日")]
		public DateTime UpdateAt { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 HH:mm:SS}")]
		public DateTime DeletedAt { get; set; }

		public virtual ICollection<Memo> Memos { get; set; } //ナビゲーションプロパティ
	}
}
