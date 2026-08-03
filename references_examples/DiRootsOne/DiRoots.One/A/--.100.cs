using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.PanelLink;
using DiRoots.One.PanelLink.Models;
using DiRoots.One.SheetLink.Core;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000190 RID: 400
	internal class \u001E\u0002 : IExternalEventHandler
	{
		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x0005E674 File Offset: 0x0005C874
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x0005E688 File Offset: 0x0005C888
		internal static ExternalEvent HandlerEvent { get; set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x0005E69C File Offset: 0x0005C89C
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x0005E6B0 File Offset: 0x0005C8B0
		internal static \u001E\u0002 HandlerInstance { get; set; }

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x06000ED0 RID: 3792 RVA: 0x0005E6C4 File Offset: 0x0005C8C4
		// (remove) Token: 0x06000ED1 RID: 3793 RVA: 0x0005E710 File Offset: 0x0005C910
		public event \u001E\u0002.\u0008\u0002 \u0007
		{
			[CompilerGenerated]
			add
			{
				\u001E\u0002.\u0008\u0002 u0008_u = this.\u0007;
				\u001E\u0002.\u0008\u0002 u0008_u2;
				do
				{
					u0008_u2 = u0008_u;
					\u001E\u0002.\u0008\u0002 value2 = (\u001E\u0002.\u0008\u0002)\u000F\u001E\u000A.\u000A(u0008_u2, value);
					u0008_u = Interlocked.CompareExchange<\u001E\u0002.\u0008\u0002>(ref this.\u0007, value2, u0008_u2);
				}
				while (u0008_u != u0008_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0002.add_\u0007(\u001E\u0002.\u0008\u0002)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u001E\u0002.\u0008\u0002 u0008_u = this.\u0007;
				\u001E\u0002.\u0008\u0002 u0008_u2;
				do
				{
					u0008_u2 = u0008_u;
					\u001E\u0002.\u0008\u0002 value2 = (\u001E\u0002.\u0008\u0002)\u0012\u001E\u000A.\u000A(u0008_u2, value);
					u0008_u = Interlocked.CompareExchange<\u001E\u0002.\u0008\u0002>(ref this.\u0007, value2, u0008_u2);
				}
				while (u0008_u != u0008_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0002.remove_\u0007(\u001E\u0002.\u0008\u0002)).MethodHandle;
				}
			}
		}

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x06000ED2 RID: 3794 RVA: 0x0005E75C File Offset: 0x0005C95C
		// (remove) Token: 0x06000ED3 RID: 3795 RVA: 0x0005E7A8 File Offset: 0x0005C9A8
		public event \u001E\u0002.\u001B\u0002 \u001D
		{
			[CompilerGenerated]
			add
			{
				\u001E\u0002.\u001B\u0002 u001B_u = this.\u001D;
				\u001E\u0002.\u001B\u0002 u001B_u2;
				do
				{
					u001B_u2 = u001B_u;
					\u001E\u0002.\u001B\u0002 value2 = (\u001E\u0002.\u001B\u0002)\u000F\u001E\u000A.\u000A(u001B_u2, value);
					u001B_u = Interlocked.CompareExchange<\u001E\u0002.\u001B\u0002>(ref this.\u001D, value2, u001B_u2);
				}
				while (u001B_u != u001B_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0002.add_\u001D(\u001E\u0002.\u001B\u0002)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u001E\u0002.\u001B\u0002 u001B_u = this.\u001D;
				\u001E\u0002.\u001B\u0002 u001B_u2;
				do
				{
					u001B_u2 = u001B_u;
					\u001E\u0002.\u001B\u0002 value2 = (\u001E\u0002.\u001B\u0002)\u0012\u001E\u000A.\u000A(u001B_u2, value);
					u001B_u = Interlocked.CompareExchange<\u001E\u0002.\u001B\u0002>(ref this.\u001D, value2, u001B_u2);
				}
				while (u001B_u != u001B_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0002.remove_\u001D(\u001E\u0002.\u001B\u0002)).MethodHandle;
				}
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0005E7F4 File Offset: 0x0005C9F4
		// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x0005E808 File Offset: 0x0005CA08
		public string FolderPath { get; set; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x0005E81C File Offset: 0x0005CA1C
		// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x0005E830 File Offset: 0x0005CA30
		public List<string> FilesPaths { get; set; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x0005E844 File Offset: 0x0005CA44
		// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x0005E858 File Offset: 0x0005CA58
		public List<Element> CheckedPanels { get; set; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0005E86C File Offset: 0x0005CA6C
		// (set) Token: 0x06000EDB RID: 3803 RVA: 0x0005E880 File Offset: 0x0005CA80
		public List<PanelData> CollectedData { get; set; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x0005E894 File Offset: 0x0005CA94
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x0005E8A8 File Offset: 0x0005CAA8
		public IExportOption ExportOption { get; set; }

		// Token: 0x06000EDE RID: 3806 RVA: 0x0005E8BC File Offset: 0x0005CABC
		public void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\ExternalEvents\\PanelScheduleEvent.cs", "Execute");
			Document u001F = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			List<Panel> u001F2 = \u0014\u0002.\u001F(u001F, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u000F\u000B\u0004.\u0007(\u0020\u0013\u000A.\u000A(app)))));
			\u0001\u0011\u0019.\u000A(this, \u0009\u0011\u0019.\u000A());
			Dictionary<long, Category> u001D = \u0017\u000D.\u0005\u000A(u001F);
			List<ImageType> u = \u0017\u000D.\u0019\u000A(u001F);
			int num = 1;
			List<Panel>.Enumerator enumerator = \u0002\u0011\u0019.\u000A(u001F2);
			try
			{
				while (\u0018\u0011\u0019.\u000A(ref enumerator))
				{
					Panel panel = \u000B\u0011\u0019.\u000A(ref enumerator);
					\u001E\u0002.\u0011\u0002 u0011_u = new \u001E\u0002.\u0011\u0002();
					u0011_u.\u001F = \u0016\u0011\u0019.\u000A(panel);
					if (Enumerable.Any<Element>(\u0015\u0011\u0019.\u000A(this), new Func<Element, bool>(u0011_u.\u000A)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0002.Execute(UIApplication)).MethodHandle;
						}
						\u001E\u0002.\u001B\u0002 u001D2 = this.\u001D;
						if (u001D2 == null)
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
							\u000C\u0011\u0019.\u000A(u001D2, num++);
						}
						PanelData u000A = \u0013\u0002.\u001F(u001F, panel, u, u001D);
						\u0013\u0011\u0019.\u000A(\u001A\u0011\u0019.\u0007(this), u000A);
					}
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u001E\u0002.\u0008\u0002 u2 = this.\u0007;
			if (u2 == null)
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
			}
			else
			{
				ExportFilesTaskArgs exportFilesTaskArgs = \u0020\u0011\u0019.\u000A(\u0014\u0011\u0019.\u000A(this), !\u0017\u0011\u0019.\u000A(\u001B\u0011\u0019.\u000A(this)));
				\u0011\u0011\u0019.\u000A(exportFilesTaskArgs, \u001E\u0011\u0019.\u000A(this));
				\u000E\u0011\u0019.\u000A(exportFilesTaskArgs, \u0008\u0011\u0019.\u000A(\u001B\u0011\u0019.\u000A(this)));
				\u0010\u0011\u0019.\u000A(u2, exportFilesTaskArgs);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Core\\ExternalEvents\\PanelScheduleEvent.cs", "Execute");
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x0005EA88 File Offset: 0x0005CC88
		internal static void \u000B()
		{
			if (\u000A\u001E\u0019.\u000A() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0002.\u000B()).MethodHandle;
				}
				\u0007\u001E\u0019.\u000A(new \u001E\u0002());
				\u001F\u001E\u0019.\u000A(\u001D\u0005\u001D.\u000A(\u000A\u001E\u0019.\u000A()));
			}
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x0005EAD0 File Offset: 0x0005CCD0
		public string GetName()
		{
			return "Panel Schedule Export";
		}

		// Token: 0x040005D1 RID: 1489
		[CompilerGenerated]
		private static ExternalEvent \u001F;

		// Token: 0x040005D2 RID: 1490
		[CompilerGenerated]
		private static \u001E\u0002 \u000A;

		// Token: 0x040005D5 RID: 1493
		[CompilerGenerated]
		private string \u0004;

		// Token: 0x040005D6 RID: 1494
		[CompilerGenerated]
		private List<string> \u0019;

		// Token: 0x040005D7 RID: 1495
		[CompilerGenerated]
		private List<Element> \u0018;

		// Token: 0x040005D8 RID: 1496
		[CompilerGenerated]
		private List<PanelData> \u0005;

		// Token: 0x040005D9 RID: 1497
		[CompilerGenerated]
		private IExportOption \u0016;

		// Token: 0x02000862 RID: 2146
		// (Invoke) Token: 0x06004ECA RID: 20170
		public delegate void \u0008\u0002(ITaskFinishedArgs args);

		// Token: 0x02000863 RID: 2147
		// (Invoke) Token: 0x06004ECE RID: 20174
		public delegate void \u001B\u0002(int percent);

		// Token: 0x02000864 RID: 2148
		[CompilerGenerated]
		private sealed class \u0011\u0002
		{
			// Token: 0x06004ED2 RID: 20178 RVA: 0x001E1700 File Offset: 0x001DF900
			internal bool \u000A(Element \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u0002\u001E\u000A.\u0007(\u001F), \u0002\u001E\u000A.\u0007(this.\u001F));
			}

			// Token: 0x0400214A RID: 8522
			public Element \u001F;
		}
	}
}
