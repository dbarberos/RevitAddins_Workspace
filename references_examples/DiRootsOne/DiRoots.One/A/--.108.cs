using System;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;

namespace A
{
	// Token: 0x020001F1 RID: 497
	internal static class \u0001\u0006
	{
		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x060012A5 RID: 4773 RVA: 0x0006B864 File Offset: 0x00069A64
		// (set) Token: 0x060012A6 RID: 4774 RVA: 0x0006B878 File Offset: 0x00069A78
		internal static string PluginName { get; set; } = "SheetLink";

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x060012A7 RID: 4775 RVA: 0x0006B88C File Offset: 0x00069A8C
		// (set) Token: 0x060012A8 RID: 4776 RVA: 0x0006B8A0 File Offset: 0x00069AA0
		internal static ICustomLogger LoggerInstance { get; set; }

		// Token: 0x060012A9 RID: 4777 RVA: 0x0006B8B4 File Offset: 0x00069AB4
		internal static string \u0005()
		{
			try
			{
				if (!\u000C\u0010\u0004.\u000A(\u0001\u0006.\u000A))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0006.\u0005()).MethodHandle;
					}
					\u0011\u0015\u001D.\u000A(\u0001\u0006.\u000A);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Helpers\\Constant.cs", "GeAccessKeyFilePath");
			}
			return \u001B\u0015\u001D.\u000A(\u0001\u0006.\u000A, "settings.xml");
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x060012AA RID: 4778 RVA: 0x0006B92C File Offset: 0x00069B2C
		internal static string \u0016
		{
			get
			{
				return "pack://application:,,,/DiRoots.One.Morta;component/UI/Resources/Images/loading.gif";
			}
		}

		// Token: 0x04000776 RID: 1910
		private static readonly string \u001F = \u0008\u0005\u0018.\u000A(Environment.SpecialFolder.LocalApplicationData);

		// Token: 0x04000777 RID: 1911
		internal static readonly string \u000A = \u0017\u0006\u0007.\u000A("{0}\\DiRootsOne\\Morta", \u0001\u0006.\u001F);

		// Token: 0x04000778 RID: 1912
		[CompilerGenerated]
		private static string \u0007;

		// Token: 0x04000779 RID: 1913
		internal static string \u001D;

		// Token: 0x0400077A RID: 1914
		internal static string \u0004;

		// Token: 0x0400077B RID: 1915
		internal static string \u0019;

		// Token: 0x0400077C RID: 1916
		[CompilerGenerated]
		private static ICustomLogger \u0018;
	}
}
