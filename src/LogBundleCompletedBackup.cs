using System.Collections.Generic;
using System.Net.Http;
using Bulksign.Extensibility;

namespace Bulksign.Sample
{
	public class LogEnvelopeCompletedBackup : ICompletedEnvelopeBackupProvider
	{
		public Dictionary<string, string> Settings
		{
			get;
			set;
		}

		public string ProviderName => "LogEnvelopeCompletedBackup";

		public HttpClient HttpClient
		{
			get;
			set;
		}

		public IJsonSerializer JsonSerializer
		{
			get;
			set;
		}

		public event LogDelegate Log;

		public EnvelopeBackupResult Process(EnvelopeBackup backup)
		{
			//just log the received information. Replace this and copy the file, back it up or read the file content and sent it to another service
			Log?.Invoke(LogLevel.Info, null, $"Received envelope completed documents for envelopeId '{backup.EnvelopeId}'");

			//a real provider should return here the identifier for the file (path , DMS id etc)
			
		
			//for this sample just return string.Empty
			return new EnvelopeBackupResult()
			{
				BackupToken = string.Empty,
				IsSuccess = true
			};

		}
	}
}