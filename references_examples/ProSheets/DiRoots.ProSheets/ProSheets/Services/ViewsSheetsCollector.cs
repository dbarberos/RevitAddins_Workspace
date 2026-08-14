using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Autodesk.Revit.DB;

namespace ProSheets.Services
{
	// Token: 0x020000A2 RID: 162
	public class ViewsSheetsCollector
	{
		// Token: 0x06000989 RID: 2441 RVA: 0x0003AAF8 File Offset: 0x00038CF8
		public ViewsSheetsCollector(Document document)
		{
			this.\u000C = document;
			this.\u0016 = \u000F\u000A\u0018.\u0016\u0018<View>(document);
			this.\u0014 = this.\u000F();
			this.\u0018 = this.\u0012();
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x0003AB3C File Offset: 0x00038D3C
		public List<ViewSheet> SheetsList
		{
			get
			{
				List<ViewSheet> result;
				if ((result = this.\u0014) == null)
				{
					for (;;)
					{
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsSheetsCollector.get_SheetsList()).MethodHandle;
					}
					result = (this.\u0014 = this.\u000F());
				}
				return result;
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x0600098B RID: 2443 RVA: 0x0003AB78 File Offset: 0x00038D78
		public List<View> ViewsList
		{
			get
			{
				List<View> result;
				if ((result = this.\u0018) == null)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsSheetsCollector.get_ViewsList()).MethodHandle;
					}
					result = (this.\u0018 = this.\u0012());
				}
				return result;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x0003ABB4 File Offset: 0x00038DB4
		public List<string> ViewTypesList
		{
			get
			{
				List<string> result;
				if ((result = this.\u0003) == null)
				{
					for (;;)
					{
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsSheetsCollector.get_ViewTypesList()).MethodHandle;
					}
					result = (this.\u0003 = this.\u000D());
				}
				return result;
			}
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0003ABF0 File Offset: 0x00038DF0
		private List<ViewSheet> \u000F()
		{
			return Enumerable.ToList<ViewSheet>(Enumerable.OfType<ViewSheet>(this.\u0016));
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x0003AC14 File Offset: 0x00038E14
		private List<View> \u0012()
		{
			return Enumerable.ToList<View>(Enumerable.Except<View>(this.\u0016, this.\u0014));
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x0003AC3C File Offset: 0x00038E3C
		private List<string> \u000D()
		{
			List<string> list = \u000C\u000A\u0018.\u001C(this.\u0018);
			object u000C = list;
			int u = 0;
			string u2;
			if (\u0001\u0015\u0014.\u0018(list) != 0)
			{
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewsSheetsCollector.\u000D()).MethodHandle;
				}
				u2 = \u000D\u0009\u0018.\u0015;
			}
			else
			{
				u2 = \u000D\u0009\u0018.\u0017;
			}
			\u0002\u000B\u0014.\u0018(u000C, u, u2);
			return list;
		}

		// Token: 0x04000479 RID: 1145
		private readonly Document \u000C;

		// Token: 0x0400047A RID: 1146
		private List<View> \u0018;

		// Token: 0x0400047B RID: 1147
		private List<ViewSheet> \u0014;

		// Token: 0x0400047C RID: 1148
		private List<string> \u0003;

		// Token: 0x0400047D RID: 1149
		private readonly List<View> \u0016;
	}
}
