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

		public EnvelopeBackupResult Process(string envelopeId, byte[] zipCompletedDocuments, bool hasRejectedSignStep)
		{
			//envelopeId : the identifier of the envelope 
			//zipCompletedDocuments : byte array with a zip file which contains ALL  envelope documents + the audit trail
			//hasRejectedSignStep : flag which determines if the envelope has a rejected step.

			try
			{
				Log(LogLevel.Info, null, $"Received envelope completed documents for envelopeId '{envelopeId}'");

				//a real provider should send here the byte[] to a LongTerm Archiving/ DMS/ storage

				//return a successful result. Since we didnt actually implemented the backup procedure here, we'll return an empty token
				return new EnvelopeBackupResult()
				{
					BackupToken = string.Empty,
					ErrorCode = 0,
					ErrorMessage = string.Empty,
					IsSuccess = true,
					RequestIdentifier = string.Empty
				};
			}
			catch (Exception ex)
			{
				Log?.Invoke(LogLevel.Error, ex);

				return new EnvelopeBackupResult()
				{
					BackupToken = string.Empty,
					ErrorCode = 1,
					ErrorMessage = ex.Message,
					IsSuccess = false,
					RequestIdentifier = string.Empty
				};
			}
		}
	}
}