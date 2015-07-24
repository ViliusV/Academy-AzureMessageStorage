using System;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace MessagesStorage.AzureConfiguration
{
	public static class Configuration
	{
		public const string AuthorName = "viliaus";

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
			
			//Implementation:
			var client = account.CreateCloudQueueClient();
			var queue = client.GetQueueReference(queueName);
			queue.CreateIfNotExists();

			return queue;
		}

		public static CloudBlobContainer GetContainer()
		{
			var account = GetStorageAccount();
			var containerName = "reports-container-" + AuthorName;

			//Implementation:
			var client = account.CreateCloudBlobClient();
			var container = client.GetContainerReference("reports-file");
			container.CreateIfNotExists();

			return container;
		}


	}
}