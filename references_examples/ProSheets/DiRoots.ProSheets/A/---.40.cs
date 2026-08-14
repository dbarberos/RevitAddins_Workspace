using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Controls;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace A
{
	// Token: 0x020000E9 RID: 233
	internal static class \u001E\u0011\u0018
	{
		// Token: 0x06000BAD RID: 2989 RVA: 0x000476C0 File Offset: 0x000458C0
		// Note: this type is marked as 'beforefieldinit'.
		static \u001E\u0011\u0018()
		{
			HttpClient httpClient = \u0005\u0015\u0016.\u0018();
			\u0001\u0015\u0016.\u0018(httpClient, \u001B\u0015\u0016.\u0018(30.0));
			\u001E\u0011\u0018.\u000D = httpClient;
		}

		// Token: 0x06000BAE RID: 2990 RVA: 0x00047708 File Offset: 0x00045908
		private static Task \u0013()
		{
			\u001E\u0011\u0018.\u0013\u0011\u0018 u0013_u0011_u;
			u0013_u0011_u.\u0018 = \u0006\u0014\u0003.\u0018();
			u0013_u0011_u.\u000C = -1;
			u0013_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u0013\u0011\u0018>(ref u0013_u0011_u);
			return \u0010\u0014\u0003.\u0018(ref u0013_u0011_u.\u0018);
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x00047748 File Offset: 0x00045948
		internal static Task \u0009(ICustomLogger \u000C)
		{
			\u001E\u0011\u0018.\u001F\u0011\u0018 u001F_u0011_u;
			u001F_u0011_u.\u0018 = \u0006\u0014\u0003.\u0018();
			u001F_u0011_u.\u0014 = \u000C;
			u001F_u0011_u.\u000C = -1;
			u001F_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u001F\u0011\u0018>(ref u001F_u0011_u);
			return \u0010\u0014\u0003.\u0018(ref u001F_u0011_u.\u0018);
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x00047790 File Offset: 0x00045990
		private static Task<HttpResponseMessage> \u000A(Func<HttpRequestMessage> \u000C)
		{
			\u001E\u0011\u0018.\u0017\u0011\u0018 u0017_u0011_u;
			u0017_u0011_u.\u0018 = \u0014\u0017\u0016.\u0018();
			u0017_u0011_u.\u0014 = \u000C;
			u0017_u0011_u.\u000C = -1;
			u0017_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u0017\u0011\u0018>(ref u0017_u0011_u);
			return \u0018\u0017\u0016.\u0018(ref u0017_u0011_u.\u0018);
		}

		// Token: 0x06000BB1 RID: 2993 RVA: 0x000477D8 File Offset: 0x000459D8
		[return: TupleElementNames(new string[]
		{
			"accessToken",
			"baseApiUrl"
		})]
		private static Task<ValueTuple<string, string>> \u0020()
		{
			\u001E\u0011\u0018.\u0009\u0011\u0018 u0009_u0011_u;
			u0009_u0011_u.\u0018 = \u0016\u0017\u0016.\u0018();
			u0009_u0011_u.\u000C = -1;
			u0009_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u0009\u0011\u0018>(ref u0009_u0011_u);
			return \u0003\u0017\u0016.\u0018(ref u0009_u0011_u.\u0018);
		}

		// Token: 0x06000BB2 RID: 2994 RVA: 0x00047818 File Offset: 0x00045A18
		private static Task<int> \u001F()
		{
			\u001E\u0011\u0018.\u000A\u0011\u0018 u000A_u0011_u;
			u000A_u0011_u.\u0018 = \u0012\u0017\u0016.\u0018();
			u000A_u0011_u.\u000C = -1;
			u000A_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u000A\u0011\u0018>(ref u000A_u0011_u);
			return \u000F\u0017\u0016.\u0018(ref u000A_u0011_u.\u0018);
		}

		// Token: 0x06000BB3 RID: 2995 RVA: 0x00047858 File Offset: 0x00045A58
		internal static Task<bool> \u0011(bool \u000C, Label \u0018)
		{
			\u001E\u0011\u0018.\u001C\u0011\u0018 u001C_u0011_u;
			u001C_u0011_u.\u0018 = \u001C\u0017\u0016.\u0018();
			u001C_u0011_u.\u0014 = \u000C;
			u001C_u0011_u.\u0003 = \u0018;
			u001C_u0011_u.\u000C = -1;
			u001C_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u001C\u0011\u0018>(ref u001C_u0011_u);
			return \u000D\u0017\u0016.\u0018(ref u001C_u0011_u.\u0018);
		}

		// Token: 0x06000BB4 RID: 2996 RVA: 0x000478A8 File Offset: 0x00045AA8
		public static Task<int> \u0015()
		{
			\u001E\u0011\u0018.\u0020\u0011\u0018 u0020_u0011_u;
			u0020_u0011_u.\u0018 = \u0012\u0017\u0016.\u0018();
			u0020_u0011_u.\u000C = -1;
			u0020_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u0020\u0011\u0018>(ref u0020_u0011_u);
			return \u000F\u0017\u0016.\u0018(ref u0020_u0011_u.\u0018);
		}

		// Token: 0x06000BB5 RID: 2997 RVA: 0x000478E8 File Offset: 0x00045AE8
		internal static Task \u0017(int \u000C, ICustomLogger \u0018)
		{
			\u001E\u0011\u0018.\u0015\u0011\u0018 u0015_u0011_u;
			u0015_u0011_u.\u0018 = \u0006\u0014\u0003.\u0018();
			u0015_u0011_u.\u0003 = \u000C;
			u0015_u0011_u.\u0014 = \u0018;
			u0015_u0011_u.\u000C = -1;
			u0015_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u0015\u0011\u0018>(ref u0015_u0011_u);
			return \u0010\u0014\u0003.\u0018(ref u0015_u0011_u.\u0018);
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x00047938 File Offset: 0x00045B38
		internal static Task<bool> \u001E()
		{
			\u001E\u0011\u0018.\u0011\u0011\u0018 u0011_u0011_u;
			u0011_u0011_u.\u0018 = \u001C\u0017\u0016.\u0018();
			u0011_u0011_u.\u000C = -1;
			u0011_u0011_u.\u0018.Start<\u001E\u0011\u0018.\u0011\u0011\u0018>(ref u0011_u0011_u);
			return \u000D\u0017\u0016.\u0018(ref u0011_u0011_u.\u0018);
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x00047978 File Offset: 0x00045B78
		internal static void \u0002(ProgressBar \u000C, Label \u0018)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\UsageTracker\\UsageTracker.cs", "UpdateExportLimitProgressBar");
			try
			{
				int u000F = \u001E\u0011\u0018.\u000F;
				int num;
				if (\u001E\u0011\u0018.\u0012 >= u000F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0011\u0018.\u0002(ProgressBar, Label)).MethodHandle;
					}
					num = u000F;
				}
				else
				{
					num = \u001E\u0011\u0018.\u0012;
				}
				int num2 = num;
				\u000A\u0017\u0016.\u0018(\u000C, (double)u000F);
				\u0019\u001C\u0003.\u0018(\u000C, (double)num2);
				\u0018\u0009\u0014.\u0018(\u0018, \u001A\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0003\u000F, num2, u000F));
				double num3 = (double)num2 / (double)u000F * 100.0;
				string u000C = "#88B561";
				if (num3 == 100.0)
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
					u000C = "#F94E4E";
				}
				else if (num3 > 50.0)
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
					u000C = "#e6ae46";
				}
				\u0013\u0017\u0016.\u0018(\u000C, \u000F\u000E\u0003.\u0018(\u0006\u0010\u000F.\u000C(\u0009\u0017\u0016.\u0018(u000C))));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\UsageTracker\\UsageTracker.cs", "UpdateExportLimitProgressBar");
			}
			\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\UsageTracker\\UsageTracker.cs", "UpdateExportLimitProgressBar");
		}

		// Token: 0x04000566 RID: 1382
		private static string \u000C = \u000C\u0017\u0016.\u0018();

		// Token: 0x04000567 RID: 1383
		private static string \u0018 = \u000E\u0015\u0016.\u0018();

		// Token: 0x04000568 RID: 1384
		private static string \u0014;

		// Token: 0x04000569 RID: 1385
		private static string \u0003;

		// Token: 0x0400056A RID: 1386
		private static string \u0016;

		// Token: 0x0400056B RID: 1387
		private static int \u000F;

		// Token: 0x0400056C RID: 1388
		private static int \u0012;

		// Token: 0x0400056D RID: 1389
		private static readonly HttpClient \u000D;

		// Token: 0x0400056E RID: 1390
		private static string \u001C;

		// Token: 0x020001E2 RID: 482
		[CompilerGenerated]
		private sealed class \u0012\u0011\u0018
		{
			// Token: 0x06001231 RID: 4657 RVA: 0x0005E6E8 File Offset: 0x0005C8E8
			internal HttpRequestMessage \u0018()
			{
				StringContent u = \u000D\u0015\u000F.\u0018(this.\u000C, \u001D\u0012\u0003.\u0018(), "application/json-patch+json");
				HttpRequestMessage httpRequestMessage = \u0003\u0015\u000F.\u0018(\u0012\u0015\u000F.\u0018(), \u000D\u001E\u0018.\u0018(\u001E\u0011\u0018.\u0016, "/registsms/prosheetsexportregist"));
				\u000F\u0015\u000F.\u0018(httpRequestMessage, u);
				return httpRequestMessage;
			}

			// Token: 0x040008B1 RID: 2225
			public string \u000C;
		}

		// Token: 0x020001E3 RID: 483
		[CompilerGenerated]
		private sealed class \u000D\u0011\u0018
		{
			// Token: 0x06001233 RID: 4659 RVA: 0x0005E74C File Offset: 0x0005C94C
			internal HttpRequestMessage \u0018()
			{
				StringContent u = \u000D\u0015\u000F.\u0018(this.\u000C, \u001D\u0012\u0003.\u0018(), "application/json-patch+json");
				HttpRequestMessage httpRequestMessage = \u0003\u0015\u000F.\u0018(\u0012\u0015\u000F.\u0018(), \u000D\u001E\u0018.\u0018(\u001E\u0011\u0018.\u0016, "/registsms/prosheetsexportregist"));
				\u000F\u0015\u000F.\u0018(httpRequestMessage, u);
				return httpRequestMessage;
			}

			// Token: 0x040008B2 RID: 2226
			public string \u000C;
		}
	}
}
