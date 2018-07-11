using System.Collections.Generic;
using Bulksign.Extensibility;

namespace BundleFinishedProvider
{
	public class LogBundleFinished : IBundleFinished
	{
		public Dictionary<string, string> Settings
		{
			get;
			set;
		}

		public string ProviderName => "LogBundleFinishedProvider";

		public event LogDelegate Log;

		public void Process(string bundlePublicId, string archiveFilePath)
		{
			//just log the received information. Replace this and copy the file, back it up or read the file content and sent it to another service
			Log(LogLevel.Info, null, $"Received bundle finished notification for bundle with id {bundlePublicId}, file path is {archiveFilePath}");
		}
	}
}