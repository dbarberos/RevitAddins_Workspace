using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.Revit.Extensions;

namespace SelectionsManager.ViewModels
{
	// Token: 0x02000025 RID: 37
	public class SelectedElementsBagViewModel : ModelBase
	{
		// Token: 0x06000131 RID: 305 RVA: 0x000073D0 File Offset: 0x000055D0
		public SelectedElementsBagViewModel(Category cat, List<ElementId> ids)
		{
			string u000A;
			if (cat == null)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedElementsBagViewModel..ctor(Category, List<ElementId>)).MethodHandle;
				}
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0009\u0014\u000A.\u0007(cat);
			}
			\u0001\u0014\u000A.\u000A(this, u000A);
			ElementId u000A2;
			if (cat == null)
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
				u000A2 = \u0012\u0015\u0010.\u001F;
			}
			else
			{
				u000A2 = \u0015\u0014\u000A.\u0007(cat);
			}
			\u000C\u0014\u000A.\u000A(this, u000A2);
			\u0013\u0014\u000A.\u000A(this, \u001A\u0014\u000A.\u000A(ids));
			\u0014\u0014\u000A.\u000A(this, new List<ElementId>(ids));
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000744C File Offset: 0x0000564C
		public SelectedElementsBagViewModel(string catName, List<ElementId> ids)
		{
			\u0001\u0014\u000A.\u000A(this, catName);
			\u000C\u0014\u000A.\u000A(this, Constants.InvalidElementId);
			\u0013\u0014\u000A.\u000A(this, \u001A\u0014\u000A.\u000A(ids));
			\u0014\u0014\u000A.\u000A(this, new List<ElementId>(ids));
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000133 RID: 307 RVA: 0x0000748C File Offset: 0x0000568C
		// (set) Token: 0x06000134 RID: 308 RVA: 0x000074A0 File Offset: 0x000056A0
		public List<ElementId> ElementIds { get; set; }

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000135 RID: 309 RVA: 0x000074B4 File Offset: 0x000056B4
		// (set) Token: 0x06000136 RID: 310 RVA: 0x000074C8 File Offset: 0x000056C8
		public int InstanceCount { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000137 RID: 311 RVA: 0x000074DC File Offset: 0x000056DC
		// (set) Token: 0x06000138 RID: 312 RVA: 0x000074F0 File Offset: 0x000056F0
		public string CategoryName { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00007504 File Offset: 0x00005704
		// (set) Token: 0x0600013A RID: 314 RVA: 0x00007518 File Offset: 0x00005718
		public ElementId CategoryId { get; set; }

		// Token: 0x04000082 RID: 130
		[CompilerGenerated]
		private List<ElementId> D;

		// Token: 0x04000083 RID: 131
		[CompilerGenerated]
		private int H;

		// Token: 0x04000084 RID: 132
		[CompilerGenerated]
		private string C;

		// Token: 0x04000085 RID: 133
		[CompilerGenerated]
		private ElementId L;
	}
}
