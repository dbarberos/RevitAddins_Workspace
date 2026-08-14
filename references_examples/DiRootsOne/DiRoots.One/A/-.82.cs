using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.SheetGen;
using DiRoots.One.SheetGen.Core.Services;
using DiRoots.One.SheetGen.Delegates;

namespace A
{
	// Token: 0x020002A4 RID: 676
	internal class \u0020\u0008 : ExternalEventInfo
	{
		// Token: 0x1400002D RID: 45
		// (add) Token: 0x06001AAF RID: 6831 RVA: 0x000ADB2C File Offset: 0x000ABD2C
		// (remove) Token: 0x06001AB0 RID: 6832 RVA: 0x000ADB7C File Offset: 0x000ABD7C
		public event TaskFinishedHandler \u001F
		{
			[CompilerGenerated]
			add
			{
				TaskFinishedHandler taskFinishedHandler = this.\u001F;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0008.add_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				TaskFinishedHandler taskFinishedHandler = this.\u001F;
				TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					TaskFinishedHandler value2 = \u000A\u0003\u000E.\u001F(\u0012\u001E\u000A.\u000A(taskFinishedHandler2, value));
					taskFinishedHandler = Interlocked.CompareExchange<TaskFinishedHandler>(ref this.\u001F, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0008.remove_\u001F(TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000752 RID: 1874
		// (get) Token: 0x06001AB1 RID: 6833 RVA: 0x000ADBCC File Offset: 0x000ABDCC
		// (set) Token: 0x06001AB2 RID: 6834 RVA: 0x000ADBE0 File Offset: 0x000ABDE0
		public SheetInfo SelectedSheet { get; set; }

		// Token: 0x17000753 RID: 1875
		// (get) Token: 0x06001AB3 RID: 6835 RVA: 0x000ADBF4 File Offset: 0x000ABDF4
		// (set) Token: 0x06001AB4 RID: 6836 RVA: 0x000ADC08 File Offset: 0x000ABE08
		public int NumberofSheets { get; set; }

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06001AB5 RID: 6837 RVA: 0x000ADC1C File Offset: 0x000ABE1C
		// (set) Token: 0x06001AB6 RID: 6838 RVA: 0x000ADC30 File Offset: 0x000ABE30
		public bool PopulateViews { get; set; }

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06001AB7 RID: 6839 RVA: 0x000ADC44 File Offset: 0x000ABE44
		// (set) Token: 0x06001AB8 RID: 6840 RVA: 0x000ADC58 File Offset: 0x000ABE58
		public bool KeepLegends { get; set; }

		// Token: 0x17000756 RID: 1878
		// (get) Token: 0x06001AB9 RID: 6841 RVA: 0x000ADC6C File Offset: 0x000ABE6C
		// (set) Token: 0x06001ABA RID: 6842 RVA: 0x000ADC80 File Offset: 0x000ABE80
		public bool KeepSchedules { get; set; }

		// Token: 0x06001ABB RID: 6843 RVA: 0x000ADC94 File Offset: 0x000ABE94
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\NewSheetEvent.cs", "Execute");
			\u000F\u0006\u0016.\u000A(true);
			\u000D\u0005\u0016.\u000A(SheetTemplate.\u0006(\u001D\u0004\u0016.\u0007(\u0006\u0006\u0016.\u000A(this)), \u001B\u001D\u0016.\u0007(\u0006\u0006\u0016.\u000A(this)), null, false));
			TitleBlockService titleBlockService = \u0002\u0006\u0016.\u000A(\u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
			for (int i = 1; i <= \u0018\u0006\u0016.\u000A(this); i++)
			{
				int num = 1;
				string text = this.\u000F\u0005(num);
				while (this.\u0006\u0005(text))
				{
					num++;
					text = this.\u000F\u0005(num);
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0020\u0008.Execute(UIApplication)).MethodHandle;
				}
				SheetInfo sheetInfo = \u001C\u0005\u0016.\u000A(\u000C\u0018\u0016.\u000A(), titleBlockService);
				\u0003\u0005\u0016.\u000A(sheetInfo, text);
				\u001F\u0018\u0016.\u000A(sheetInfo, text);
				SheetInfo sheetInfo2 = sheetInfo;
				sheetInfo2.TO(titleBlockService);
				\u0017\u0018\u0016.\u000A(sheetInfo2, \u000C\u0018\u0016.\u000A(), \u000B\u0006\u0016.\u000A(this), \u0016\u0006\u0016.\u000A(this), \u0005\u0006\u0016.\u000A(this));
				\u0008\u0018\u0016.\u000A(\u0014\u0007\u0016.\u000A(), sheetInfo2);
			}
			for (;;)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			TaskFinishedHandler u001F = this.\u001F;
			if (u001F == null)
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
			}
			else
			{
				\u001C\u0007\u0016.\u000A(u001F);
			}
			\u000F\u0012\u0007.\u000A(\u0011\u0015\u0005.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Core\\ExternalEvents\\NewSheetEvent.cs", "Execute");
		}

		// Token: 0x06001ABC RID: 6844 RVA: 0x000ADDEC File Offset: 0x000ABFEC
		private bool \u0006\u0005(string \u001F)
		{
			\u0020\u0008.\u001E\u0008 u001E_u = new \u0020\u0008.\u001E\u0008();
			u001E_u.\u001F = \u001F;
			return Enumerable.Any<SheetInfo>(\u0014\u0007\u0016.\u000A(), new Func<SheetInfo, bool>(u001E_u.\u000A));
		}

		// Token: 0x06001ABD RID: 6845 RVA: 0x000ADE20 File Offset: 0x000AC020
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string \u000F\u0005(int \u001F)
		{
			return \u0004\u001E\u000A.\u000A("XX-", \u0008\u0005\u0016.\u000A(ref \u001F, "D4", \u001F\u0015\u000A.\u000A()));
		}

		// Token: 0x04000A9F RID: 2719
		[CompilerGenerated]
		private SheetInfo \u001D\u0007;

		// Token: 0x04000AA0 RID: 2720
		[CompilerGenerated]
		private int \u0008\u0007;

		// Token: 0x04000AA1 RID: 2721
		[CompilerGenerated]
		private bool \u001B\u0007;

		// Token: 0x04000AA2 RID: 2722
		[CompilerGenerated]
		private bool \u001F\u0007;

		// Token: 0x04000AA3 RID: 2723
		[CompilerGenerated]
		private bool \u000A\u0007;

		// Token: 0x02000976 RID: 2422
		[CompilerGenerated]
		private sealed class \u001E\u0008
		{
			// Token: 0x060052E4 RID: 21220 RVA: 0x001EB6BC File Offset: 0x001E98BC
			internal bool \u000A(SheetInfo \u001F)
			{
				return \u000D\u0008\u000A.\u000A(\u0011\u0007\u0016.\u0007(\u001F), this.\u001F, true);
			}

			// Token: 0x040024B9 RID: 9401
			public string \u001F;
		}
	}
}
