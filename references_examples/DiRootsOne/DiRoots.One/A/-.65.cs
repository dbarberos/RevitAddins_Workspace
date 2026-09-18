using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using DiRoots.One.Commons.Models;
using DiRoots.One.Morta.Enums;
using DiRoots.One.Morta.Model;
using DiRoots.One.Morta.UI.Windows;
using DiRoots.One.Morta.ViewModel;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001F4 RID: 500
	internal static class \u000A\u000F
	{
		// Token: 0x060012C1 RID: 4801 RVA: 0x0006BE10 File Offset: 0x0006A010
		private static void \u001F(\u0013\u0006 \u001F, Workbook \u000A, Window \u0007, bool \u001D)
		{
			\u000F\u0006 u000F_u = new \u000F\u0006(\u000A, \u001D);
			if (\u0009\u001D\u0018.\u001D(u000F_u) == UploadTypes.SingleTableUpload)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u000F.\u001F(\u0013\u0006, Workbook, Window, bool)).MethodHandle;
				}
				SingleTableUploadUI u001F = \u001D\u0016\u0018.\u000A(\u001F, u000F_u, true);
				\u0015\u000D\u001D.\u000A(u001F, \u0007);
				\u0018\u0020\u000A.\u0007(u001F);
				return;
			}
			MultipleTableUploadUI u001F2 = \u0007\u0016\u0018.\u000A(\u001F, u000F_u);
			\u0015\u000D\u001D.\u000A(u001F2, \u0007);
			\u0018\u0020\u000A.\u0007(u001F2);
		}

		// Token: 0x060012C2 RID: 4802 RVA: 0x0006BE74 File Offset: 0x0006A074
		private static void \u000A(\u0013\u0006 \u001F, Window \u000A)
		{
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x0006BE84 File Offset: 0x0006A084
		internal static Dictionary<DataTable, List<ParamExportInfo>> \u0007(Window \u001F)
		{
			Login u001F = \u0019\u0016\u0018.\u000A();
			if (\u000A\u000F.\u001D(u001F, \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u000F.\u0007(Window)).MethodHandle;
				}
				SingleTableUploadUI u001F2 = \u001D\u0016\u0018.\u000A(new \u0013\u0006(u001F), null, false);
				\u0015\u000D\u001D.\u000A(u001F2, \u001F);
				bool? flag = \u0018\u0020\u000A.\u0007(u001F2);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					ImportTableViewModel importTableViewModel = \u0015\u0016\u000E.\u001F(\u0007\u000C\u000A.\u0007(u001F2));
					if (importTableViewModel != null)
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
						return \u0004\u0016\u0018.\u000A(importTableViewModel);
					}
				}
			}
			return null;
		}

		// Token: 0x060012C4 RID: 4804 RVA: 0x0006BF14 File Offset: 0x0006A114
		internal static void \u0007(Workbook \u001F, Window \u000A, bool \u0007)
		{
			Login u001F = \u0019\u0016\u0018.\u000A();
			if (\u000A\u000F.\u001D(u001F, \u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u000F.\u0007(Workbook, Window, bool)).MethodHandle;
				}
				\u000A\u000F.\u001F(new \u0013\u0006(u001F), \u001F, \u000A, \u0007);
			}
		}

		// Token: 0x060012C5 RID: 4805 RVA: 0x0006BF58 File Offset: 0x0006A158
		private static bool \u001D(Login \u001F, Window \u000A)
		{
			\u0005\u0016\u0018.\u000A(\u0010\u0011\u000A.\u000A());
			if (\u0018\u0016\u0018.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u000F.\u001D(Login, Window)).MethodHandle;
				}
				return true;
			}
			ConnectToMorta u001F = \u0020\u0007\u0018.\u000A(\u001F);
			\u0015\u000D\u001D.\u000A(u001F, \u000A);
			bool? flag = \u0018\u0020\u000A.\u0007(u001F);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
				return true;
			}
			return false;
		}
	}
}
