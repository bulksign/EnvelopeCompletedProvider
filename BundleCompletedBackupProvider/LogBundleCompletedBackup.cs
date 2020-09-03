using System.Collections.Generic;
using Bulksign.Extensibility;

namespace BundleCompletedProviderSample
{
	public class LogBundleCompletedBackup : Bulksign.Extensibility.ICompletedBundleBackupProvider
	{
		public Dictionary<string, string> Settings
		{
			get;
			set;
		}

		public string ProviderName => "LogBundleCompletedBackup";

		public event LogDelegate Log;

		public string Process(string bundlePublicId, string archiveFilePath)
		{
			//just log the received information. Replace this and copy the file, back it up or read the file content and sent it to another service
			Log(LogLevel.Info, null, $"Received bundle finished notification for bundle with id {bundlePublicId}, file path is {archiveFilePath}");

			//a real provider should return here the identifier for the file (path , DMS id etc)
			
		
			//for this sample just return string.Empty
			return string.Empty;

		}
	}
}