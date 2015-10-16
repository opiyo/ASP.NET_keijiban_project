using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
	public class Memo
	{
		[Key]
		[DisplayName("メモID")]
		public int MemoId { get; set; }
		[Required(ErrorMessage ="{0}は必須です。")]
		[DisplayName("タイトル")]
		public string Title { get; set; }
		[DisplayName("本文")]
		[Required(ErrorMessage = "{0}は必須です。")]
		public string Body { get; set; }
		//作成日時、更新日時、削除日時
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 hh:MM:ss}")]
		[DisplayName("作成日")]
		public DateTime CreatedAt { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 hh:MM:ss}")]
		[DisplayName("更新日")]
		public DateTime UpdateAt { get; set; }
		[DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日 hh:MM:ss}")]
		public DateTime DeletedAt { get; set; }
		public bool DeleteFlg { get; set; }

		
		public int UserId { get; set; } //外部プロパティ
		[ForeignKey("UserId")]
		public virtual User User { get; set; } //ナビゲーションプロパティ
	}
}
