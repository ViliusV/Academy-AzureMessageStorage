using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MessagesStorage.AzureConfiguration;
using MessagesStorage.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace MessagesStorage.Controllers
{
    public class MessageController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
	        var model = new MessageViewModel
	        {
		        IsImportant = false,
		        Text = string.Empty
	        };

            return View(model);
        }

		[HttpPost]
	    public ActionResult Index(MessageViewModel model)
	    {
		    if (!ModelState.IsValid)
		    {
			    return View(model);
		    }

			AddMessageToQueue(model);

		    return RedirectToAction("Index");
	    }

	    public ActionResult CreateReportsFile()
	    {
		    var messages = GetAllMessagesFromQueue();
			System.IO.File.WriteAllText("reports.txt", string.Join(",", messages));

			// Create or overwrite the "myblob" blob with contents from a local file.
			using (var fileStream = System.IO.File.OpenRead("reports.txt"))
			{
				//TODO: save file to blob
				var container = Configuration.GetContainer();
				var blobName = string.Format("Reports-{0}.txt", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
				throw  new NotImplementedException();

			}

		    return RedirectToAction("Index");
	    }

	    private void AddMessageToQueue(MessageViewModel message)
	    {
		    var queue = Configuration.GetQueue();
			//TODO: add message to Azure queue
		    throw new NotImplementedException();
	    }

	    private IEnumerable<string> GetAllMessagesFromQueue()
	    {
		    var messages = new List<string>();

		    var queue = Configuration.GetQueue();

			//TODO: 
			//1. Peek at the queue to check if messages exist 
			//2. get messages from the queue and add them to the list
			throw new NotImplementedException();

		    return messages;
	    } 
    }
}