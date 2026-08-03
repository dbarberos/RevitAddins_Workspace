using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Helpers;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.UI.Windows;

namespace A
{
	// Token: 0x02000275 RID: 629
	internal class \u001A\u0010 : ExternalEventInfo
	{
		// Token: 0x06001906 RID: 6406 RVA: 0x000A2584 File Offset: 0x000A0784
		public \u001A\u0010(Dictionary<DataTable, List<ParamExportInfo>> \u001F)
		{
			\u001C\u000C\u0005.\u000A(this, DiRoots.One.SheetLink.Enums.UpdateStatus.None);
			\u0003\u000C\u0005.\u000A(this, new List<ReportInfo>());
			this.\u0019\u000A = \u001F;
		}

		// Token: 0x06001907 RID: 6407 RVA: 0x000A25B0 File Offset: 0x000A07B0
		public \u001A\u0010()
		{
			\u001C\u000C\u0005.\u000A(this, DiRoots.One.SheetLink.Enums.UpdateStatus.None);
			\u0003\u000C\u0005.\u000A(this, new List<ReportInfo>());
		}

		// Token: 0x170006E9 RID: 1769
		// (get) Token: 0x06001908 RID: 6408 RVA: 0x000A25D8 File Offset: 0x000A07D8
		// (set) Token: 0x06001909 RID: 6409 RVA: 0x000A25EC File Offset: 0x000A07EC
		public DiRoots.One.SheetLink.Enums.UpdateStatus ImportStatus { get; set; }

		// Token: 0x170006EA RID: 1770
		// (get) Token: 0x0600190A RID: 6410 RVA: 0x000A2600 File Offset: 0x000A0800
		// (set) Token: 0x0600190B RID: 6411 RVA: 0x000A2614 File Offset: 0x000A0814
		public List<ReportInfo> CurrentReports { get; set; }

		// Token: 0x170006EB RID: 1771
		// (get) Token: 0x0600190C RID: 6412 RVA: 0x000A2628 File Offset: 0x000A0828
		// (set) Token: 0x0600190D RID: 6413 RVA: 0x000A263C File Offset: 0x000A083C
		public Window ParentWindow { get; set; }

		// Token: 0x170006EC RID: 1772
		// (get) Token: 0x0600190E RID: 6414 RVA: 0x000A2650 File Offset: 0x000A0850
		// (set) Token: 0x0600190F RID: 6415 RVA: 0x000A2664 File Offset: 0x000A0864
		public bool IsGoogleDirve { get; set; }

		// Token: 0x170006ED RID: 1773
		// (get) Token: 0x06001910 RID: 6416 RVA: 0x000A2678 File Offset: 0x000A0878
		// (set) Token: 0x06001911 RID: 6417 RVA: 0x000A268C File Offset: 0x000A088C
		public ProgressModel ActiveProgressModel { get; set; }

		// Token: 0x06001912 RID: 6418 RVA: 0x000A26A0 File Offset: 0x000A08A0
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ImportEvent.cs", "Execute");
			this.\u0003\u0018(\u0020\u0013\u000A.\u000A(app));
			try
			{
				\u0019\u0013\u0019.\u000A(false);
				\u0002\u0013\u0019.\u0007(\u001C\u0014\u0018.\u001D(this));
				\u0003\u0001\u0018.\u0007(\u001C\u0014\u0018.\u001D(this), 0.0);
				\u001E\u0014\u0018.\u001D(\u001C\u0014\u0018.\u001D(this), (double)\u0010\u0017\u0018.\u000A(this.\u0019\u000A));
				List<ReportInfo> u000A;
				\u001C\u000C\u0005.\u000A(this, \u001B\u0012.\u001C(this.\u0019\u000A, \u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()), \u001C\u0014\u0018.\u001D(this), \u0017\u0007\u0005.\u001D(this), out u000A));
				\u0003\u000C\u0005.\u000A(this, u000A);
			}
			catch (TaskCanceledException u000A2)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ImportEvent.cs", "Execute");
			}
			catch (Exception u000A3)
			{
				\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A3, true);
			}
			this.\u001C\u0018(\u0020\u0013\u000A.\u000A(app));
			if (\u0010\u000C\u0005.\u000A(this))
			{
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0010.Execute(UIApplication)).MethodHandle;
				}
				Delegate @delegate = \u000D\u000C\u0005.\u000A(\u001C\u0014\u0018.\u001D(this));
				if (@delegate == null)
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
				}
				else
				{
					\u0010\u001F\u0018.\u000A(@delegate, Array.Empty<object>());
				}
			}
			else
			{
				Delegate delegate2 = \u000D\u000C\u0005.\u000A(\u001C\u0014\u0018.\u001D(this));
				if (delegate2 == null)
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
				}
				else
				{
					object[] array = \u0004\u0015\u0010.\u001F(1);
					array[0] = this;
					\u0010\u001F\u0018.\u000A(delegate2, array);
				}
			}
			\u0020\u0007\u0005.\u000A(false);
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ImportEvent.cs", "Execute");
		}

		// Token: 0x06001913 RID: 6419 RVA: 0x000A2844 File Offset: 0x000A0A44
		public void \u0003\u0018(UIDocument \u001F)
		{
			MainWindow mainWindow = \u000D\u0012\u000E.\u001F(\u0017\u0007\u0005.\u001D(this));
			if (mainWindow != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0010.\u0003\u0018(UIDocument)).MethodHandle;
				}
				\u000E\u000C\u0005.\u000A(mainWindow);
			}
			if (\u000D\u000B\u001D.\u000A(\u0020\u0005\u0004.\u000A(\u0017\u0005\u0004.\u0007(\u0011\u0020\u000A.\u0007(\u001F)))) > 2019)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				object u001F = \u0005\u001B\u0019.\u001D(\u001F);
				EventHandler<DialogBoxShowingEventArgs> u000A;
				if ((u000A = \u001A\u0010.\u0013\u0010.\u001F) == null)
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
					u000A = (\u001A\u0010.\u0013\u0010.\u001F = new EventHandler<DialogBoxShowingEventArgs>(\u001A\u0010.\u000D\u0018));
				}
				\u0018\u001B\u0019.\u000A(u001F, u000A);
				return;
			}
			IntPtr intPtr = \u0004\u001B\u0019.\u000A(\u0019\u001B\u0019.\u000A());
			this.\u0007\u000A = \u000A\u001B\u0019.\u000A(\u001D\u001B\u0019.\u000A(ref intPtr), \u0007\u001B\u0019.\u000A(\u0017\u0007\u0005.\u001D(this)), -1);
		}

		// Token: 0x06001914 RID: 6420 RVA: 0x000A2914 File Offset: 0x000A0B14
		public void \u001C\u0018(UIDocument \u001F)
		{
			MainWindow mainWindow = \u000D\u0012\u000E.\u001F(\u0017\u0007\u0005.\u001D(this));
			if (mainWindow != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u0010.\u001C\u0018(UIDocument)).MethodHandle;
				}
				\u0008\u000C\u0005.\u000A(mainWindow);
			}
			if (\u000D\u000B\u001D.\u000A(\u0020\u0005\u0004.\u000A(\u0017\u0005\u0004.\u0007(\u0011\u0020\u000A.\u0007(\u001F)))) > 2019)
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
				object u001F = \u0005\u001B\u0019.\u001D(\u001F);
				EventHandler<DialogBoxShowingEventArgs> u000A;
				if ((u000A = \u001A\u0010.\u0013\u0010.\u001F) == null)
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
					u000A = (\u001A\u0010.\u0013\u0010.\u001F = new EventHandler<DialogBoxShowingEventArgs>(\u001A\u0010.\u000D\u0018));
				}
				\u000B\u001B\u0019.\u000A(u001F, u000A);
				return;
			}
			DialogCloser u0007_u000A = this.\u0007\u000A;
			if (u0007_u000A == null)
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
				return;
			}
			\u0016\u001B\u0019.\u000A(u0007_u000A);
		}

		// Token: 0x06001915 RID: 6421 RVA: 0x000A29C8 File Offset: 0x000A0BC8
		internal static void \u000D\u0018(object \u001F, DialogBoxShowingEventArgs \u000A)
		{
			try
			{
				\u0002\u001B\u0019.\u000A(\u000A, 1);
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ImportEvent.cs", "AppDialogShowing");
			}
		}

		// Token: 0x040009F0 RID: 2544
		private DialogCloser \u0007\u000A;

		// Token: 0x040009F1 RID: 2545
		[CompilerGenerated]
		private DiRoots.One.SheetLink.Enums.UpdateStatus \u001D\u000A;

		// Token: 0x040009F2 RID: 2546
		[CompilerGenerated]
		private List<ReportInfo> \u0004\u000A;

		// Token: 0x040009F3 RID: 2547
		public Dictionary<DataTable, List<ParamExportInfo>> \u0019\u000A;

		// Token: 0x040009F4 RID: 2548
		[CompilerGenerated]
		private Window \u0018\u000A;

		// Token: 0x040009F5 RID: 2549
		[CompilerGenerated]
		private bool \u0005\u000A;

		// Token: 0x040009F6 RID: 2550
		[CompilerGenerated]
		private ProgressModel \u0001;

		// Token: 0x0200094E RID: 2382
		[CompilerGenerated]
		private static class \u0013\u0010
		{
			// Token: 0x0400244D RID: 9293
			public static EventHandler<DialogBoxShowingEventArgs> \u001F;
		}
	}
}
