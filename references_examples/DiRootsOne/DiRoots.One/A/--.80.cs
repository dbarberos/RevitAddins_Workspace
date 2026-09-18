using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using Syncfusion.Pdf.Parsing;

namespace A
{
	// Token: 0x02000131 RID: 305
	internal static class \u0016\u0016
	{
		// Token: 0x06000B8A RID: 2954 RVA: 0x00048D7C File Offset: 0x00046F7C
		public static \u0020\u0019 \u001F(SelectedExcel \u001F, CancellationTokenSource \u000A, Action \u0007)
		{
			\u0008\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\PdfToImageExporter.cs", "Export");
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0004\u001E\u000A.\u000A("Exporting Pdf to image for ", \u0011\u0020\u001D.\u0007(\u001F)), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\PdfToImageExporter.cs", "Export");
			Stream stream = \u0014\u0010\u0004.\u000A(\u0011\u0020\u001D.\u0007(\u001F), FileMode.Open, FileAccess.Read);
			\u0020\u0019 result;
			try
			{
				PdfLoadedDocument pdfLoadedDocument = \u001B\u0013\u0004.\u000A(stream);
				try
				{
					result = \u0016\u0016.\u001F(pdfLoadedDocument, \u001F, \u000A, \u0007);
				}
				finally
				{
					if (pdfLoadedDocument != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0016.\u001F(SelectedExcel, CancellationTokenSource, Action)).MethodHandle;
						}
						\u001F\u0017\u000A.\u000A(pdfLoadedDocument);
					}
				}
			}
			finally
			{
				if (stream != null)
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
					\u001F\u0017\u000A.\u000A(stream);
				}
			}
			return result;
		}

		// Token: 0x06000B8B RID: 2955 RVA: 0x00048E40 File Offset: 0x00047040
		internal static \u0020\u0019 \u001F(PdfLoadedDocument \u001F, SelectedExcel \u000A, CancellationTokenSource \u0007, Action \u001D)
		{
			\u0016\u0016.\u0005\u0016 u0005_u = new \u0016\u0016.\u0005\u0016();
			u0005_u.\u001F = \u001F;
			\u0020\u0019 u0020_u = new \u0020\u0019();
			\u0004\u0020\u001D.\u000A(u0020_u, \u000A);
			if (\u000D\u001B\u001D.\u0007(\u0004\u0011\u0004.\u001D(\u000A)) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0016.\u001F(PdfLoadedDocument, SelectedExcel, CancellationTokenSource, Action)).MethodHandle;
				}
				List<int> u = Enumerable.ToList<int>(\u0011\u0013\u0004.\u000A(0, \u001E\u0013\u0004.\u000A(\u0020\u0013\u0004.\u000A(u0005_u.\u001F))));
				\u0016\u0016.\u001F(u0005_u.\u001F, \u000A, u0020_u, \u0007, \u001D, u);
			}
			else
			{
				List<int> u2 = Enumerable.ToList<int>(Enumerable.Where<int>(\u0013\u0016.\u001F(\u000A\u0011\u0004.\u001D(\u000A)), new Func<int, bool>(u0005_u.\u000A)));
				\u0016\u0016.\u001F(u0005_u.\u001F, \u000A, u0020_u, \u0007, \u001D, u2);
			}
			\u0005\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\PdfToImageExporter.cs", "Export");
			return u0020_u;
		}

		// Token: 0x06000B8C RID: 2956 RVA: 0x00048F14 File Offset: 0x00047114
		private static void \u001F(PdfLoadedDocument \u001F, SelectedExcel \u000A, \u0020\u0019 \u0007, CancellationTokenSource \u001D, Action \u0004, List<int> \u0019)
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
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0016.\u001F(PdfLoadedDocument, SelectedExcel, \u0020\u0019, CancellationTokenSource, Action, List<int>)).MethodHandle;
						}
						return;
					}
					if (num % 100 == 0)
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
						if (\u0004 != null)
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
							\u001B\u0015\u0007.\u000A(\u0004);
						}
					}
					num++;
					ImageExportSettings imageExportSettings = \u0015\u0013\u0004.\u000A();
					\u000C\u0013\u0004.\u000A(imageExportSettings, true);
					\u001A\u0013\u0004.\u000A(imageExportSettings, (float)\u0018\u0011\u0004.\u001D(\u000A));
					\u0013\u0013\u0004.\u000A(imageExportSettings, (float)\u0018\u0011\u0004.\u001D(\u000A));
					Bitmap u001F = \u0014\u0013\u0004.\u000A(\u001F, u000A, imageExportSettings);
					\u0019\u0016.\u001F(u001F, \u0018\u0011\u0004.\u001D(\u000A), \u0007, false);
					\u0019\u0015\u001D.\u000A(u001F);
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

		// Token: 0x02000813 RID: 2067
		[CompilerGenerated]
		private sealed class \u0005\u0016
		{
			// Token: 0x06004DA5 RID: 19877 RVA: 0x001DEAC8 File Offset: 0x001DCCC8
			internal bool \u000A(int \u001F)
			{
				return \u001F < \u001E\u0013\u0004.\u000A(\u0020\u0013\u0004.\u000A(this.\u001F));
			}

			// Token: 0x04002061 RID: 8289
			public PdfLoadedDocument \u001F;
		}
	}
}
