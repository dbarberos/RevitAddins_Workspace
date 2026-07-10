using System;
using System.Collections.Generic;

namespace TransferSingleApp
{
	// Token: 0x02000026 RID: 38
	public class Estructura
	{
		// Token: 0x0400013B RID: 315
		public IList<Nodo> Raices_Nodos = new List<Nodo>();

		// Token: 0x0400013C RID: 316
		public IList<Elemento> Raices_Elementos = new List<Elemento>();

		// Token: 0x0400013D RID: 317
		public IList<Nodo> NodosSueltos = new List<Nodo>();

		// Token: 0x0400013E RID: 318
		public IList<Archivo> Archivos = new List<Archivo>();

		// Token: 0x0400013F RID: 319
		public IList<Archivo> ArchivosFiltrados = new List<Archivo>();

		// Token: 0x04000140 RID: 320
		public List<string> LogTxt = new List<string>();
	}
}
