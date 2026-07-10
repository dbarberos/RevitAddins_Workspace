using System;
using Autodesk.Revit.DB;

namespace TransferSingleApp
{
	// Token: 0x02000029 RID: 41
	public class Archivo
	{
		// Token: 0x060001A2 RID: 418 RVA: 0x00015A6B File Offset: 0x00013C6B
		public Archivo(Document e)
		{
			this.Adoc = e;
			this.Nombre = this.Adoc.Title;
			this.Checked = false;
		}

		// Token: 0x04000164 RID: 356
		public string Nombre;

		// Token: 0x04000165 RID: 357
		public Document Adoc;

		// Token: 0x04000166 RID: 358
		public bool Checked;

		// Token: 0x04000167 RID: 359
		public bool EsVinculo;
	}
}
