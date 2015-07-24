using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace MessagesStorage.Models
{
	public class MessageViewModel
	{
		[Required]
		public string Text { get; set; }

		[DisplayName("Is Important")]
		public bool IsImportant { get; set; }

		public string ToJson()
		{
			var message = Json.Encode(this);

			return message;
		}
	}
}