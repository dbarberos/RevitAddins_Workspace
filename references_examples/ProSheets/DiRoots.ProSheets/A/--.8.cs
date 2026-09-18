using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using ProSheets.DrawingRegister.Model.TreeViewModel;

namespace A
{
	// Token: 0x0200012C RID: 300
	internal static class \u000C\u0017\u0018
	{
		// Token: 0x06000F66 RID: 3942 RVA: 0x00057660 File Offset: 0x00055860
		public static List<ViewInfo> \u000C(List<ViewSheet> \u000C, Document \u0018, BrowserOrganization \u0014)
		{
			List<ViewInfo> list = \u000C\u0017\u0018.\u0014(\u000C, \u0018, \u0014);
			\u000C\u0017\u0018.\u0018(list);
			return list;
		}

		// Token: 0x06000F67 RID: 3943 RVA: 0x00057680 File Offset: 0x00055880
		public static void \u0018(List<ViewInfo> \u000C)
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u000C);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo u000C = \u0006\u0019\u0016.\u0018(ref enumerator);
					IEnumerable<ViewInfo> enumerable = \u0007\u0019\u0016.\u0014(u000C);
					Func<ViewInfo, string> func;
					if ((func = \u000C\u0017\u0018.<>c.\u0018) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0017\u0018.\u0018(List<ViewInfo>)).MethodHandle;
						}
						func = (\u000C\u0017\u0018.<>c.\u0018 = new Func<ViewInfo, string>(\u000C\u0017\u0018.<>c.\u000C.\u0016));
					}
					\u001A\u0016\u000F.\u0003(u000C, Enumerable.ToList<ViewInfo>(Enumerable.OrderBy<ViewInfo, string>(enumerable, func)));
					\u000D\u000F\u000F.\u0018(u000C);
				}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0005772C File Offset: 0x0005592C
		private static List<ViewInfo> \u0014(List<ViewSheet> \u000C, Document \u0018, BrowserOrganization \u0014)
		{
			List<ViewInfo> list = \u0001\u000C\u000F.\u0018();
			ViewInfo u = \u0011\u000D\u000F.\u0018(\u0006\u0004\u0018.\u0018(\u0018));
			IEnumerable<ViewSheet> enumerable = \u000C;
			Func<ViewSheet, string> func;
			if ((func = \u000C\u0017\u0018.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0017\u0018.\u0014(List<ViewSheet>, Document, BrowserOrganization)).MethodHandle;
				}
				func = (\u000C\u0017\u0018.<>c.\u0014 = new Func<ViewSheet, string>(\u000C\u0017\u0018.<>c.\u000C.\u000F));
			}
			\u000C = Enumerable.ToList<ViewSheet>(Enumerable.OrderBy<ViewSheet, string>(enumerable, func));
			if (!Enumerable.Any<ViewSheet>(\u000C))
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
				return list;
			}
			\u000D\u0014\u000F.\u0018(list, u);
			List<ViewSheet>.Enumerator enumerator = \u001F\u001D\u0014.\u0018(\u000C);
			try
			{
				while (\u0013\u001D\u0014.\u0018(ref enumerator))
				{
					ViewSheet u000C = \u0020\u001D\u0014.\u0018(ref enumerator);
					ViewInfo viewInfo = \u000A\u0019\u0016.\u0018();
					\u0009\u000D\u000F.\u0018(viewInfo, true);
					\u0007\u0016\u000F.\u0003(viewInfo, \u001E\u0002\u0016.\u0018(u000C));
					\u0010\u0016\u000F.\u0003(viewInfo, \u0009\u0002\u0018.\u0018(u000C).\u000C());
					\u0002\u000D\u000F.\u0018(viewInfo, \u001E\u001D\u0014.\u0018(u000C));
					\u001E\u000D\u000F.\u0018(viewInfo, \u001E\u0016\u0014.\u0018(u000C));
					\u0019\u0016\u000F.\u0003(viewInfo, \u001A\u001E\u0018.\u0018("{0} - {1}", \u0017\u000D\u000F.\u0018(viewInfo), \u0015\u000D\u000F.\u0018(viewInfo)));
					\u000C\u0017\u0018.\u0003(\u0014, u, \u0009\u0002\u0018.\u0018(u000C), viewInfo);
				}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x00057890 File Offset: 0x00055A90
		public static void \u0003(BrowserOrganization \u000C, ViewInfo \u0018, ElementId \u0014, ViewInfo \u0003)
		{
			List<FolderItemInfo> u000C = Enumerable.ToList<FolderItemInfo>(\u0007\u000D\u000F.\u0018(\u000C, \u0014));
			if (\u0004\u000D\u000F.\u0018(u000C) > 0)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0017\u0018.\u0003(BrowserOrganization, ViewInfo, ElementId, ViewInfo)).MethodHandle;
				}
				\u000C\u0017\u0018.\u0005\u0015\u0018 u0005_u0015_u = new \u000C\u0017\u0018.\u0005\u0015\u0018();
				u0005_u0015_u.\u000C = \u0019\u000D\u000F.\u0018(u000C, 0);
				ViewInfo viewInfo = \u001E\u000C\u000F.\u0014(\u0007\u0019\u0016.\u0014(\u0018), new Predicate<ViewInfo>(u0005_u0015_u.\u0018));
				if (viewInfo == null)
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
					viewInfo = \u001D\u000D\u000F.\u0018(\u000B\u000D\u000F.\u0018(u0005_u0015_u.\u000C), \u001A\u000D\u000F.\u0018(u0005_u0015_u.\u000C).\u000C());
					\u000B\u0016\u000F.\u0003(viewInfo, true);
					\u000D\u0014\u000F.\u0018(\u0007\u0019\u0016.\u0014(\u0018), viewInfo);
				}
				ViewInfo viewInfo2 = viewInfo;
				for (int i = 1; i < \u0004\u000D\u000F.\u0018(u000C); i++)
				{
					\u000C\u0017\u0018.\u000E\u0015\u0018 u000E_u0015_u = new \u000C\u0017\u0018.\u000E\u0015\u0018();
					u000E_u0015_u.\u000C = \u0019\u000D\u000F.\u0018(u000C, i);
					ViewInfo viewInfo3;
					if (viewInfo2 == null)
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
						viewInfo3 = \u0013\u0008\u000F.\u000C;
					}
					else
					{
						List<ViewInfo> list = \u0007\u0019\u0016.\u0003(viewInfo2);
						if (list == null)
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
							viewInfo3 = \u0013\u0008\u000F.\u000C;
						}
						else
						{
							viewInfo3 = \u001E\u000C\u000F.\u0003(list, new Predicate<ViewInfo>(u000E_u0015_u.\u0018));
						}
					}
					ViewInfo viewInfo4 = viewInfo3;
					if (viewInfo4 == null)
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
						viewInfo4 = \u001D\u000D\u000F.\u0018(\u000B\u000D\u000F.\u0018(u000E_u0015_u.\u000C), \u001A\u000D\u000F.\u0018(u000E_u0015_u.\u000C).\u000C());
						\u000B\u0016\u000F.\u0003(viewInfo4, false);
						\u000D\u0014\u000F.\u0018(\u0007\u0019\u0016.\u0014(viewInfo2), viewInfo4);
					}
					viewInfo2 = viewInfo4;
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				\u000D\u0014\u000F.\u0018(\u0007\u0019\u0016.\u0014(viewInfo2), \u0003);
				return;
			}
			\u000D\u0014\u000F.\u0018(\u0007\u0019\u0016.\u0014(\u0018), \u0003);
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x00057A44 File Offset: 0x00055C44
		public static void \u0016(List<ViewInfo> \u000C, bool \u0018)
		{
			Func<ViewInfo, bool> func;
			if ((func = \u000C\u0017\u0018.<>c.\u0003) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0017\u0018.\u0016(List<ViewInfo>, bool)).MethodHandle;
				}
				func = (\u000C\u0017\u0018.<>c.\u0003 = new Func<ViewInfo, bool>(\u000C\u0017\u0018.<>c.\u000C.\u0012));
			}
			IEnumerator<ViewInfo> enumerator = \u0006\u000D\u000F.\u0018(Enumerable.Where<ViewInfo>(\u000C, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ViewInfo u000C = \u0010\u000D\u000F.\u0018(enumerator);
					\u0015\u0010\u0016.\u0018(u000C, new bool?(\u0018));
					if (Enumerable.Any<ViewInfo>(\u0007\u0019\u0016.\u0014(u000C)))
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
						\u000C\u0017\u0018.\u0016(Enumerable.ToList<ViewInfo>(\u0007\u0019\u0016.\u0014(u000C)), \u0018);
					}
				}
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
			finally
			{
				if (enumerator != null)
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00057B14 File Offset: 0x00055D14
		public unsafe static void \u000F(ViewInfo \u000C, ref bool \u0018)
		{
			if (\u0001\u000D\u000F.\u0018(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0017\u0018.\u000F(ViewInfo, bool*)).MethodHandle;
				}
				List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u0007\u0019\u0016.\u0014(\u000C));
				try
				{
					while (\u000B\u0019\u0016.\u0018(ref enumerator))
					{
						\u000C\u0017\u0018.\u000F(\u0006\u0019\u0016.\u0018(ref enumerator), ref \u0018);
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
					return;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			bool flag;
			if (!\u0018)
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
				flag = !\u0008\u000D\u000F.\u0018(\u000C);
			}
			else
			{
				flag = true;
			}
			\u0018 = flag;
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00057BB4 File Offset: 0x00055DB4
		public static void \u0012(List<ViewInfo> \u000C, ViewInfo \u0018)
		{
			if (!Enumerable.Any<ViewInfo>(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0017\u0018.\u0012(List<ViewInfo>, ViewInfo)).MethodHandle;
				}
				return;
			}
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u000C);
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo u000C = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (!\u001E\u0010\u0016.\u0018(u000C))
					{
						goto IL_76;
					}
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (\u0017\u0010\u0016.\u0018(u000C) != \u0017\u0010\u0016.\u0018(\u0018))
					{
						goto IL_76;
					}
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0015\u0010\u0016.\u0018(u000C, \u0019\u0019\u0016.\u0018(\u0018));
					IL_96:
					\u000C\u0017\u0018.\u0012(\u0007\u0019\u0016.\u0014(u000C), \u0018);
					continue;
					IL_76:
					if (\u001E\u0010\u0016.\u0018(u000C))
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
						\u0015\u0010\u0016.\u0018(u000C, new bool?(false));
						goto IL_96;
					}
					goto IL_96;
				}
				for (;;)
				{
					switch (4)
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
		}

		// Token: 0x02000219 RID: 537
		[CompilerGenerated]
		private sealed class \u0005\u0015\u0018
		{
			// Token: 0x0600130F RID: 4879 RVA: 0x00061600 File Offset: 0x0005F800
			internal bool \u0018(ViewInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0018\u000F.\u0018(\u000C), \u000B\u000D\u000F.\u0018(this.\u000C));
			}

			// Token: 0x04000970 RID: 2416
			public FolderItemInfo \u000C;
		}

		// Token: 0x0200021A RID: 538
		[CompilerGenerated]
		private sealed class \u000E\u0015\u0018
		{
			// Token: 0x06001311 RID: 4881 RVA: 0x00061640 File Offset: 0x0005F840
			internal bool \u0018(ViewInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u0018\u000F.\u0018(\u000C), \u000B\u000D\u000F.\u0018(this.\u000C));
			}

			// Token: 0x04000971 RID: 2417
			public FolderItemInfo \u000C;
		}
	}
}
