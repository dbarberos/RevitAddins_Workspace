using System;
using System.Collections.Generic;
using System.IO;
using Autodesk.Revit.DB;

namespace TransferSingleApp
{
	// Token: 0x02000010 RID: 16
	public class FailurePreproccessor : IFailuresPreprocessor
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00006E90 File Offset: 0x00005090
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			DateTime dateTime = default(DateTime);
			dateTime = DateTime.Now;
			string format = "yyyyMMddHHmm";
			IList<FailureMessageAccessor> failureMessages = failuresAccessor.GetFailureMessages();
			if (failureMessages.Count == 0)
			{
				return 0;
			}
			if (this.logtofile)
			{
				StreamWriter streamWriter;
				if (!File.Exists(this.logarchivo))
				{
					streamWriter = new StreamWriter(this.logarchivo);
				}
				else
				{
					streamWriter = File.AppendText(this.logarchivo);
				}
				streamWriter.WriteLine("-----------------------------------------------------");
				streamWriter.WriteLine("log: " + dateTime.ToString(format));
				foreach (FailureMessageAccessor failureMessageAccessor in failureMessages)
				{
					failureMessageAccessor.GetFailureDefinitionId();
					streamWriter.WriteLine(failureMessageAccessor.GetDescriptionText());
					failuresAccessor.DeleteWarning(failureMessageAccessor);
				}
				streamWriter.Close();
			}
			else
			{
				foreach (FailureMessageAccessor failureMessageAccessor2 in failureMessages)
				{
					failureMessageAccessor2.GetFailureDefinitionId();
					failuresAccessor.DeleteWarning(failureMessageAccessor2);
				}
			}
			if (FormLoad.overwrite)
			{
				return 1;
			}
			return 2;
		}

		// Token: 0x0400006A RID: 106
		private bool logtofile = true;

		// Token: 0x0400006B RID: 107
		private string logarchivo = FormLoad.Directorio + "\\log_LoadFamilies.txt";
	}
}
