using System;
using System.Drawing;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x0200012E RID: 302
	internal static class \u0004\u0016
	{
		// Token: 0x06000B83 RID: 2947 RVA: 0x000487E8 File Offset: 0x000469E8
		public static \u0020\u0019 \u001F(SelectedExcel \u001F, bool \u000A = false)
		{
			ExcelEngine excelEngine = \u0008\u001E\u001D.\u000A();
			\u0020\u0019 result;
			try
			{
				IApplication u001F = \u000E\u001E\u001D.\u000A(excelEngine);
				\u0010\u001E\u001D.\u000A(u001F, ExcelVersion.Excel2013);
				u001F.\u001F(\u0007\u0018.\u0007<ICustomLogger>());
				IRange range = \u0013\u0019.\u001D(excelEngine, \u001F);
				if (range == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0016.\u001F(SelectedExcel, bool)).MethodHandle;
					}
					\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0004\u001E\u000A.\u000A(\u0017\u0020\u001D.\u0007(\u0014\u0020\u001D.\u0007(\u001F)), " named region is not found."), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Exporter\\ExcelToImageExporter.cs", "Export");
					result = \u0002\u0004\u000E.\u001F;
				}
				else
				{
					Bitmap u001F2 = \u0019\u0016.\u000A(\u0019\u0013\u0004.\u000A(\u000C\u001E\u001D.\u000A(range), \u0009\u0020\u001D.\u000A(range), \u0001\u0020\u001D.\u000A(range), \u000B\u0013\u001D.\u000A(range), \u0016\u0013\u001D.\u000A(range), ImageType.Metafile, \u001D\u0018\u000E.\u001F), \u0018\u0011\u0004.\u001D(\u001F));
					\u0020\u0019 u0020_u = new \u0020\u0019();
					\u0004\u0020\u001D.\u000A(u0020_u, \u001F);
					\u0019\u0016.\u001F(u001F2, \u0018\u0011\u0004.\u001D(\u001F), u0020_u, \u000A);
					result = u0020_u;
				}
			}
			finally
			{
				if (excelEngine != null)
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
					\u001F\u0017\u000A.\u000A(excelEngine);
				}
			}
			return result;
		}
	}
}
