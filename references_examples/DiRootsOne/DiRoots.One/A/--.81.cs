using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace A
{
	// Token: 0x02000132 RID: 306
	internal static class \u0002\u0016
	{
		// Token: 0x06000B8D RID: 2957 RVA: 0x0004900C File Offset: 0x0004720C
		public static \u0020\u0019 \u001F(SelectedExcel \u001F, CancellationTokenSource \u000A, Action \u0007)
		{
			\u0002\u0016.\u000B\u0016 u000B_u = new \u0002\u0016.\u000B\u0016();
			\u0008\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\WordToImageExporter.cs", "Export");
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0004\u001E\u000A.\u000A("Exporting Word to image for ", \u0011\u0020\u001D.\u0007(\u001F)), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\WordToImageExporter.cs", "Export");
			u000B_u.\u001F = \u001D\u001A\u0004.\u000A();
			\u0020\u0019 result;
			try
			{
				\u0007\u001A\u0004.\u000A(u000B_u.\u001F, \u0011\u0020\u001D.\u0007(\u001F), FormatType.Docx);
				u000B_u.\u001F.\u001F(\u0007\u0018.\u0007<ICustomLogger>());
				\u0020\u0019 u0020_u = new \u0020\u0019();
				\u0004\u0020\u001D.\u000A(u0020_u, \u001F);
				if (\u000D\u001B\u001D.\u0007(\u0004\u0011\u0004.\u001D(\u001F)) == 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0016.\u001F(SelectedExcel, CancellationTokenSource, Action)).MethodHandle;
					}
					List<int> u = Enumerable.ToList<int>(\u0011\u0013\u0004.\u000A(0, \u001F\u001A\u0004.\u000A(\u000A\u001A\u0004.\u000A(u000B_u.\u001F))));
					\u0002\u0016.\u001F(u000B_u.\u001F, \u001F, u0020_u, \u000A, \u0007, u);
				}
				else
				{
					List<int> u2 = Enumerable.ToList<int>(Enumerable.Where<int>(\u0013\u0016.\u001F(\u000A\u0011\u0004.\u001D(\u001F)), new Func<int, bool>(u000B_u.\u000A)));
					\u0002\u0016.\u001F(u000B_u.\u001F, \u001F, u0020_u, \u000A, \u0007, u2);
				}
				\u0005\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\WordToImageExporter.cs", "Export");
				result = u0020_u;
			}
			finally
			{
				if (u000B_u.\u001F != null)
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
					\u001F\u0017\u000A.\u000A(u000B_u.\u001F);
				}
			}
			return result;
		}

		// Token: 0x06000B8E RID: 2958 RVA: 0x00049180 File Offset: 0x00047380
		private static void \u001F(WordDocument \u001F, SelectedExcel \u000A, \u0020\u0019 \u0007, CancellationTokenSource \u001D, Action \u0004, List<int> \u0019)
		{
			int num = 1;
			List<int>.Enumerator enumerator = \u0009\u0013\u0004.\u000A(\u0019);
			try
			{
				while (\u0017\u0013\u0004.\u000A(ref enumerator))
				{
					int u000A = \u0001\u0013\u0004.\u000A(ref enumerator);
					if (\u0004\u0013\u001D.\u0007(\u001D))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0016.\u001F(WordDocument, SelectedExcel, \u0020\u0019, CancellationTokenSource, Action, List<int>)).MethodHandle;
						}
						return;
					}
					if (num % 100 == 0)
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
						if (\u0004 != null)
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
							\u001B\u0015\u0007.\u000A(\u0004);
						}
					}
					num++;
					\u0019\u0016.\u001F(\u0019\u0016.\u000A(\u0004\u001A\u0004.\u000A(\u001F, u000A, ImageType.Metafile), \u0018\u0011\u0004.\u001D(\u000A)), \u0018\u0011\u0004.\u001D(\u000A), \u0007, false);
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x02000814 RID: 2068
		[CompilerGenerated]
		private sealed class \u000B\u0016
		{
			// Token: 0x06004DA7 RID: 19879 RVA: 0x001DEB00 File Offset: 0x001DCD00
			internal bool \u000A(int \u001F)
			{
				return \u001F < \u001F\u001A\u0004.\u000A(\u000A\u001A\u0004.\u000A(this.\u001F));
			}

			// Token: 0x04002062 RID: 8290
			public WordDocument \u001F;
		}
	}
}
