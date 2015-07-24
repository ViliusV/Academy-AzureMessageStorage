using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace MessagesStorage.AzureConfiguration
{
	public static class Configuration
	{
		public const string AuthorName = ;

		public static CloudStorageAccount GetStorageAccount()
		{
			var storageAccount = CloudStorageAccount.Parse(
				ConfigurationManager.AppSettings["AzureStorageConnectionString"]);

			return storageAccount;
		}

		public static CloudQueue GetQueue()
		{
			var account = GetStorageAccount();
			var queueName = "messages-" + AuthorName;
			
			//TODO: return Azure queue
			throw new NotImplementedException();

			CloudQueue queue = null;
			return queue;
		}

		public static CloudBlobContainer GetContainer()
		{
			var account = GetStorageAccount();
			var containerName = "reports-container-" + AuthorName;
			//TODO: return Azure container
			throw new NotImplementedException();

			CloudBlobContainer container = null;
			return container;
		}


	}
}