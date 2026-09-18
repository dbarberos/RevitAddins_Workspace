using System;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace A
{
	// Token: 0x020000EF RID: 239
	internal static class \u0011\u0018
	{
		// Token: 0x060008BA RID: 2234 RVA: 0x00039274 File Offset: 0x00037474
		internal static string \u001F(Document \u001F, double \u000A, int \u0007 = 128)
		{
			Units u001F = \u0006\u0006\u0007.\u000A(\u001F);
			FormatOptions u000A = \u0011\u0018.\u0007(u001F, \u0007, true);
			FormatValueOptions formatValueOptions = \u001D\u0005\u0004.\u000A();
			string result;
			try
			{
				\u0007\u0005\u0004.\u000A(formatValueOptions, u000A);
				result = \u000A\u0005\u0004.\u000A(u001F, \u0002\u0006\u0007.\u000A(), \u000A, true, formatValueOptions);
			}
			finally
			{
				if (formatValueOptions != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0018.\u001F(Document, double, int)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(formatValueOptions);
				}
			}
			return result;
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x000392E8 File Offset: 0x000374E8
		internal static string \u000A(double \u001F)
		{
			Units u001F = \u0006\u0006\u0007.\u000A(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()));
			FormatOptions u000A = \u0011\u0018.\u001D();
			FormatValueOptions formatValueOptions = \u001D\u0005\u0004.\u000A();
			string result;
			try
			{
				\u0007\u0005\u0004.\u000A(formatValueOptions, u000A);
				result = \u000A\u0005\u0004.\u000A(u001F, \u0002\u0006\u0007.\u000A(), \u001F, true, formatValueOptions);
			}
			finally
			{
				if (formatValueOptions != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0018.\u000A(double)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(formatValueOptions);
				}
			}
			return result;
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00039368 File Offset: 0x00037568
		private static FormatOptions \u0007(Units \u001F, int \u000A, bool \u0007)
		{
			FormatOptions formatOptions = \u0012\u0005\u0004.\u000A(\u001F, \u0002\u0006\u0007.\u000A());
			object u001F = formatOptions;
			ForgeTypeId u000A;
			if (!\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0018.\u0007(Units, int, bool)).MethodHandle;
				}
				u000A = \u001F\u0005\u0004.\u000A();
			}
			else
			{
				u000A = \u000F\u0005\u0004.\u000A();
			}
			\u0006\u0005\u0004.\u000A(u001F, u000A);
			object u001F2 = formatOptions;
			ForgeTypeId u000A2;
			if (!\u0007)
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
				u000A2 = \u000B\u0005\u0004.\u000A();
			}
			else
			{
				u000A2 = \u0016\u0005\u0004.\u000A();
			}
			if (\u0002\u0005\u0004.\u000A(u001F2, u000A2))
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
				object u001F3 = formatOptions;
				ForgeTypeId u000A3;
				if (!\u0007)
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
					u000A3 = \u000B\u0005\u0004.\u000A();
				}
				else
				{
					u000A3 = \u0016\u0005\u0004.\u000A();
				}
				\u0005\u0005\u0004.\u000A(u001F3, u000A3);
			}
			\u0018\u0005\u0004.\u000A(formatOptions, false);
			\u0019\u0005\u0004.\u000A(formatOptions, 1.0 / (double)\u000A);
			\u0004\u0005\u0004.\u000A(formatOptions, false);
			return formatOptions;
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x0003942C File Offset: 0x0003762C
		public static FormatOptions \u001D()
		{
			Document u001F = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
			Units u001F2 = \u0006\u0006\u0007.\u000A(u001F);
			if (\u001E\u000B\u0007.\u000A(u001F) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0018.\u001D()).MethodHandle;
				}
				return \u0011\u0018.\u0007(u001F2, 256, true);
			}
			return \u0011\u0018.\u0007(u001F2, 10, false);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00039488 File Offset: 0x00037688
		public unsafe static bool \u0004(string \u001F, out double \u000A)
		{
			Document u001F = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
			FormatOptions u000A = \u0011\u0018.\u001D();
			ValueParsingOptions valueParsingOptions = \u000D\u0005\u0004.\u000A();
			bool result;
			try
			{
				\u001C\u0005\u0004.\u000A(valueParsingOptions, u000A);
				result = \u0003\u0005\u0004.\u000A(\u0006\u0006\u0007.\u000A(u001F), \u0002\u0006\u0007.\u000A(), \u001F, valueParsingOptions, ref \u000A);
			}
			finally
			{
				if (valueParsingOptions != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0011\u0018.\u0004(string, double*)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(valueParsingOptions);
				}
			}
			return result;
		}
	}
}
