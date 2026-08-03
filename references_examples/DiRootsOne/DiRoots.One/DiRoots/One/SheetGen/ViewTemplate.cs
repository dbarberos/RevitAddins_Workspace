using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002C2 RID: 706
	public class ViewTemplate
	{
		// Token: 0x06001CA2 RID: 7330 RVA: 0x000B63D8 File Offset: 0x000B45D8
		public ViewTemplate()
		{
			\u001F\u000E\u0016.\u001D(this, "");
			\u0011\u000E\u0016.\u001D(this, 1);
			\u001F\u001B\u0016.\u000A(this, 0);
			\u0009\u0008\u0016.\u000A(this, new XYZLocation());
		}

		// Token: 0x06001CA3 RID: 7331 RVA: 0x000B6410 File Offset: 0x000B4610
		public ViewTemplate(Viewport vp, bool checkForEntity)
		{
			View u000A = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(vp), \u0019\u0011\u001D.\u000A(vp)));
			this.\u0002(vp, u000A, checkForEntity);
			\u001F\u001B\u0016.\u000A(this, \u0004\u0019\u0016.\u000A(vp));
		}

		// Token: 0x06001CA4 RID: 7332 RVA: 0x000B645C File Offset: 0x000B465C
		public ViewTemplate(Viewport vp, View view, bool checkForEntity)
		{
			this.\u0002(vp, view, checkForEntity);
			\u001F\u001B\u0016.\u000A(this, \u0004\u0019\u0016.\u000A(vp));
		}

		// Token: 0x06001CA5 RID: 7333 RVA: 0x000B6488 File Offset: 0x000B4688
		public ViewTemplate(ScheduleSheetInstance sc, ViewSchedule view, bool checkForEntity)
		{
			this.\u0002(sc, view, checkForEntity);
			\u001F\u001B\u0016.\u000A(this, \u0016\u0019\u0016.\u000A(sc));
		}

		// Token: 0x06001CA6 RID: 7334 RVA: 0x000B64B4 File Offset: 0x000B46B4
		public ViewTemplate(ViewInfo viewInfo)
		{
			\u0016\u000E\u0016.\u001D(this, 0L);
			\u0005\u000E\u0016.\u001D(this, \u000A\u0012\u0016.\u000A());
			\u0011\u000E\u0016.\u001D(this, \u001D\u0019\u0016.\u0007(viewInfo));
			\u0008\u000E\u0016.\u001D(this, \u000D\u001D\u0016.\u000A(viewInfo));
			\u001B\u000E\u0016.\u001D(this, \u0012\u0019\u0016.\u000A(viewInfo));
			\u0009\u0008\u0016.\u000A(this, \u0003\u001D\u0016.\u000A(viewInfo));
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x000B6514 File Offset: 0x000B4714
		public ViewTemplate(ViewTemplate viewTemplate)
		{
			\u0016\u000E\u0016.\u001D(this, 0L);
			\u0005\u000E\u0016.\u001D(this, \u000A\u0012\u0016.\u000A());
			\u0011\u000E\u0016.\u001D(this, \u0018\u0008\u0016.\u000A(viewTemplate));
			\u0008\u000E\u0016.\u001D(this, \u001C\u0008\u0016.\u000A(viewTemplate));
			\u001B\u000E\u0016.\u001D(this, \u0002\u0008\u0016.\u000A(viewTemplate));
			\u0009\u0008\u0016.\u000A(this, \u0006\u0008\u0016.\u000A(viewTemplate));
		}

		// Token: 0x06001CA8 RID: 7336 RVA: 0x000B6574 File Offset: 0x000B4774
		private void \u0002(Element \u001F, View \u000A, bool \u0007)
		{
			\u0016\u000E\u0016.\u001D(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000A)));
			\u0005\u000E\u0016.\u001D(this, \u0005\u001E\u000A.\u000A(\u000A));
			\u0011\u000E\u0016.\u001D(this, \u001C\u001C\u0007.\u0007(\u000A));
			\u0008\u000E\u0016.\u001D(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
			\u001B\u000E\u0016.\u001D(this, \u000B\u001E\u000A.\u000A(\u0004\u0013\u0007.\u000A(\u001F)));
			if (\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewTemplate.\u0002(Element, View, bool)).MethodHandle;
				}
				ViewportStoredData viewportStoredData = \u001F.\u000A<ViewportStoredData>();
				string text;
				if (viewportStoredData == null)
				{
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					text = null;
				}
				else
				{
					text = \u0008\u0019\u0016.\u001D(viewportStoredData);
				}
				string u000A;
				if ((u000A = text) == null)
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
					u000A = "";
				}
				\u000E\u000E\u0016.\u001D(this, u000A);
			}
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x06001CA9 RID: 7337 RVA: 0x000B662C File Offset: 0x000B482C
		// (set) Token: 0x06001CAA RID: 7338 RVA: 0x000B6640 File Offset: 0x000B4840
		public long ViewPortTypeId { get; set; }

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x06001CAB RID: 7339 RVA: 0x000B6654 File Offset: 0x000B4854
		// (set) Token: 0x06001CAC RID: 7340 RVA: 0x000B6668 File Offset: 0x000B4868
		public string ColumnText { get; set; }

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06001CAD RID: 7341 RVA: 0x000B667C File Offset: 0x000B487C
		// (set) Token: 0x06001CAE RID: 7342 RVA: 0x000B6690 File Offset: 0x000B4890
		public long ViewId { get; set; }

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06001CAF RID: 7343 RVA: 0x000B66A4 File Offset: 0x000B48A4
		// (set) Token: 0x06001CB0 RID: 7344 RVA: 0x000B66B8 File Offset: 0x000B48B8
		public long ViewPortId { get; set; }

		// Token: 0x17000805 RID: 2053
		// (get) Token: 0x06001CB1 RID: 7345 RVA: 0x000B66CC File Offset: 0x000B48CC
		// (set) Token: 0x06001CB2 RID: 7346 RVA: 0x000B66E0 File Offset: 0x000B48E0
		public XYZLocation ViewLocationOnSheet { get; set; }

		// Token: 0x17000806 RID: 2054
		// (get) Token: 0x06001CB3 RID: 7347 RVA: 0x000B66F4 File Offset: 0x000B48F4
		// (set) Token: 0x06001CB4 RID: 7348 RVA: 0x000B6708 File Offset: 0x000B4908
		public ViewType Type { get; set; }

		// Token: 0x17000807 RID: 2055
		// (get) Token: 0x06001CB5 RID: 7349 RVA: 0x000B671C File Offset: 0x000B491C
		// (set) Token: 0x06001CB6 RID: 7350 RVA: 0x000B6730 File Offset: 0x000B4930
		public ViewportRotation Rotation { get; set; }

		// Token: 0x17000808 RID: 2056
		// (get) Token: 0x06001CB7 RID: 7351 RVA: 0x000B6744 File Offset: 0x000B4944
		// (set) Token: 0x06001CB8 RID: 7352 RVA: 0x000B6758 File Offset: 0x000B4958
		public long SheetId { get; set; }

		// Token: 0x17000809 RID: 2057
		// (get) Token: 0x06001CB9 RID: 7353 RVA: 0x000B676C File Offset: 0x000B496C
		// (set) Token: 0x06001CBA RID: 7354 RVA: 0x000B6780 File Offset: 0x000B4980
		public string Name { get; internal set; }

		// Token: 0x1700080A RID: 2058
		// (get) Token: 0x06001CBB RID: 7355 RVA: 0x000B6794 File Offset: 0x000B4994
		// (set) Token: 0x06001CBC RID: 7356 RVA: 0x000B67A8 File Offset: 0x000B49A8
		public string StoredGUID { get; internal set; }

		// Token: 0x04000B80 RID: 2944
		[CompilerGenerated]
		private long \u001F;

		// Token: 0x04000B81 RID: 2945
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x04000B82 RID: 2946
		[CompilerGenerated]
		private long \u0007;

		// Token: 0x04000B83 RID: 2947
		[CompilerGenerated]
		private long \u001D;

		// Token: 0x04000B84 RID: 2948
		[CompilerGenerated]
		private XYZLocation \u0004;

		// Token: 0x04000B85 RID: 2949
		[CompilerGenerated]
		private ViewType \u0019;

		// Token: 0x04000B86 RID: 2950
		[CompilerGenerated]
		private ViewportRotation \u0018;

		// Token: 0x04000B87 RID: 2951
		[CompilerGenerated]
		private long \u0005;

		// Token: 0x04000B88 RID: 2952
		[CompilerGenerated]
		private string \u0016;

		// Token: 0x04000B89 RID: 2953
		[CompilerGenerated]
		private string \u000B;
	}
}
