using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.One.Commons;

namespace A
{
	// Token: 0x020000D5 RID: 213
	internal static class \u0017\u001F\u0018
	{
		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06000B48 RID: 2888 RVA: 0x00045020 File Offset: 0x00043220
		// (set) Token: 0x06000B49 RID: 2889 RVA: 0x00045034 File Offset: 0x00043234
		public static bool IsInitialized { get; set; }

		// Token: 0x06000B4A RID: 2890 RVA: 0x00045048 File Offset: 0x00043248
		public static void \u0014(UIApplication \u000C)
		{
			\u0017\u001F\u0018.\u0015\u001F\u0018 u0015_u001F_u = new \u0017\u001F\u0018.\u0015\u001F\u0018();
			u0015_u001F_u.\u000C = \u000C;
			if (!\u0001\u0020\u0016.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u001F\u0018.\u0014(UIApplication)).MethodHandle;
				}
				int num;
				\u0019\u000F\u0014.\u0018(\u0008\u0020\u0016.\u0018(\u0009\u0015\u0014.\u0018(u0015_u001F_u.\u000C)), ref num);
				object u000C = u0015_u001F_u.\u000C;
				EventHandler<DialogBoxShowingEventArgs> u;
				if ((u = \u0017\u001F\u0018.\u0011\u001F\u0018.\u000C) == null)
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
					u = (\u0017\u001F\u0018.\u0011\u001F\u0018.\u000C = new EventHandler<DialogBoxShowingEventArgs>(\u0017\u001F\u0018.\u0003));
				}
				\u0006\u0020\u0016.\u0018(u000C, u);
				object u000C2 = u0015_u001F_u.\u000C;
				EventHandler<DialogBoxShowingEventArgs> u2;
				if ((u2 = \u0017\u001F\u0018.\u0011\u001F\u0018.\u000C) == null)
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
					u2 = (\u0017\u001F\u0018.\u0011\u001F\u0018.\u000C = new EventHandler<DialogBoxShowingEventArgs>(\u0017\u001F\u0018.\u0003));
				}
				\u0010\u0020\u0016.\u0018(u000C2, u2);
				\u0011\u0009\u0018.\u0014();
				\u0013\u0011\u0014.\u0018(\u001A\u0009\u0018.\u0018);
				if (\u0017\u001F\u0018.\u0018 == null)
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
					\u0017\u001F\u0018.\u0018 = \u001C\u0011\u0014.\u0018(new ParameterizedThreadStart(u0015_u001F_u.\u0018));
					\u000D\u0011\u0014.\u0018(\u0017\u001F\u0018.\u0018);
				}
				\u0007\u0020\u0016.\u0018("ProSheets");
				\u0019\u0020\u0016.\u0018("");
				ActiveDocumentHandler implementation = \u000B\u0020\u0016.\u0018(u0015_u001F_u.\u000C);
				\u0004\u0005\u0018.\u0018().RegisterSingleton<ActiveDocumentHandler>(implementation);
				try
				{
					string u000C3 = \u0019\u001E\u0018.\u0018(\u001C\u0015\u0014.\u0018(\u0014\u001F\u0014.\u0018(\u000A\u001D\u0018.\u0018(\u0011\u0010\u000F.\u000C()))));
					\u001A\u0020\u0016.\u0018(\u0003\u001A\u0018.\u0018(u000C3, "Xceed.Wpf.Toolkit.dll"));
					\u001A\u0020\u0016.\u0018(\u0003\u001A\u0018.\u0018(u000C3, "PdfSharp.dll"));
					\u001A\u0020\u0016.\u0018(\u0003\u001A\u0018.\u0018(u000C3, "PdfSharp.Charting.dll"));
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x000451E8 File Offset: 0x000433E8
		private static void \u0003(object \u000C, DialogBoxShowingEventArgs \u0018)
		{
			try
			{
				TaskDialogShowingEventArgs taskDialogShowingEventArgs = \u0017\u001A\u000F.\u000C(\u0018);
				if (taskDialogShowingEventArgs != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u001F\u0018.\u0003(object, DialogBoxShowingEventArgs)).MethodHandle;
					}
					if (\u0018\u0015\u0014.\u0018())
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
						int num = \u0012\u0015\u0014.\u0018(\u000D\u0015\u0014.\u0018(), \u000F\u0015\u0014.\u0018(taskDialogShowingEventArgs), \u0016\u0015\u0014.\u0018(taskDialogShowingEventArgs));
						if (num != -1)
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
							\u0003\u0015\u0014.\u0018(\u0018, num);
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0400054B RID: 1355
		[CompilerGenerated]
		private static bool \u000C;

		// Token: 0x0400054C RID: 1356
		private static Thread \u0018;

		// Token: 0x020001D5 RID: 469
		[CompilerGenerated]
		private static class \u0011\u001F\u0018
		{
			// Token: 0x04000897 RID: 2199
			public static EventHandler<DialogBoxShowingEventArgs> \u000C;
		}

		// Token: 0x020001D6 RID: 470
		[CompilerGenerated]
		private sealed class \u0015\u001F\u0018
		{
			// Token: 0x0600120B RID: 4619 RVA: 0x0005DC94 File Offset: 0x0005BE94
			internal void \u0018(object \u000C)
			{
				\u001A\u0009\u0018.\u0014(\u001F\u0011\u000F.\u0018(\u0009\u0015\u0014.\u0018(this.\u000C)));
			}

			// Token: 0x04000898 RID: 2200
			public UIApplication \u000C;
		}
	}
}
