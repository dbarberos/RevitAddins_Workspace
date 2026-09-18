using System;
using System.Collections.Generic;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x0200011B RID: 283
	[Serializable]
	public class HeaderProfile
	{
		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x000540B8 File Offset: 0x000522B8
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x000540CC File Offset: 0x000522CC
		public string ImagePath { get; set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x000540E0 File Offset: 0x000522E0
		// (set) Token: 0x06000E56 RID: 3670 RVA: 0x000540F4 File Offset: 0x000522F4
		public List<ParameterInformation> SelectedParameter { get; set; }
	}
}
