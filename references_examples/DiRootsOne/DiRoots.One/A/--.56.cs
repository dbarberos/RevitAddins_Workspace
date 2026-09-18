using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000F4 RID: 244
	internal static class \u001F\u0005
	{
		// Token: 0x060008E2 RID: 2274 RVA: 0x0003C684 File Offset: 0x0003A884
		public static void \u001F(\u0020\u0019 \u001F, StyleMappingDto \u000A, bool \u0007)
		{
			bool flag;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0005.\u001F(\u0020\u0019, StyleMappingDto, bool)).MethodHandle;
				}
				flag = true;
			}
			else
			{
				SelectedExcel selectedExcel = \u0002\u0016\u0004.\u001D(\u001F);
				bool? flag2;
				bool? flag3;
				if (selectedExcel == null)
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
					\u001B\u000A\u000E.\u001F(ref flag2);
					flag3 = flag2;
				}
				else
				{
					FormatOptions formatOptions = \u000A\u000B\u0004.\u001D(selectedExcel);
					if (formatOptions == null)
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
						\u001B\u000A\u000E.\u001F(ref flag2);
						flag3 = flag2;
					}
					else
					{
						flag3 = new bool?(\u001F\u000B\u0004.\u001D(formatOptions));
					}
				}
				flag2 = flag3;
				flag = !\u0012\u0015\u000A.\u000A(ref flag2);
			}
			if (flag)
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
				return;
			}
			if (\u000C\u001D\u0004.\u0007(\u001F) == null)
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
				return;
			}
			BlackAndWhiteSettings u000A = \u0009\u0016\u0004.\u000A(\u000A);
			if (\u0007)
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
				List<\u001C\u0005>.Enumerator enumerator = \u0014\u001F\u0004.\u000A(\u000C\u001D\u0004.\u0007(\u001F));
				try
				{
					while (\u0004\u001F\u0004.\u000A(ref enumerator))
					{
						\u001C\u0005 u001C_u = \u0017\u001F\u0004.\u000A(ref enumerator);
						if (u001C_u != null)
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
							\u001F\u0005.\u000A(u001C_u, u000A);
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
					return;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			IEnumerator<\u0012\u0005> enumerator2 = \u0020\u0019\u0004.\u000A(Enumerable.Cast<\u0012\u0005>(\u000C\u001D\u0004.\u0007(\u001F)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					\u0012\u0005 u0012_u = \u001E\u0019\u0004.\u000A(enumerator2);
					if (u0012_u != null)
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
						\u001F\u0005.\u0007(u0012_u, u000A);
					}
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
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0003C818 File Offset: 0x0003AA18
		private static void \u000A(\u001C\u0005 \u001F, BlackAndWhiteSettings \u000A)
		{
			if (\u0006\u0017\u001D.\u000A(\u001F) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0005.\u000A(\u001C\u0005, BlackAndWhiteSettings)).MethodHandle;
				}
				\u0004\u000C\u001D.\u0007(\u0006\u0017\u001D.\u000A(\u001F), \u0001\u000B\u0004.\u000A(\u001A\u0017\u001D.\u0007(\u0006\u0017\u001D.\u000A(\u001F)), \u0009\u000B\u0004.\u000A(ref \u000A)));
			}
			if (\u0004\u001D\u0004.\u000A(\u001F) != null)
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
				\u000B\u0017\u001D.\u000A(\u001F, \u001A\u0006\u0004.\u000A(\u0004\u001D\u0004.\u000A(\u001F), \u0001\u000B\u0004.\u000A(\u0005\u001D\u0004.\u0007(\u0004\u001D\u0004.\u000A(\u001F)), \u0009\u000B\u0004.\u000A(ref \u000A))));
			}
			\u000D\u0005 u000D_u = \u0005\u0007\u0004.\u000A(\u001F);
			if (u000D_u != null)
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
				if (\u0001\u000A\u0004.\u000A(u000D_u) != null)
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
					\u0015\u000A\u0004.\u000A(u000D_u, \u0013\u0006\u0004.\u000A(\u0001\u000A\u0004.\u000A(u000D_u), \u0001\u000B\u0004.\u000A(\u0012\u0002\u0004.\u0007(\u0001\u000A\u0004.\u000A(u000D_u)), \u0009\u000B\u0004.\u000A(ref \u000A))));
				}
				if (\u000C\u000A\u0004.\u000A(u000D_u) != null)
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
					\u001A\u000A\u0004.\u000A(u000D_u, \u0013\u0006\u0004.\u000A(\u000C\u000A\u0004.\u000A(u000D_u), \u0001\u000B\u0004.\u000A(\u0012\u0002\u0004.\u0007(\u000C\u000A\u0004.\u000A(u000D_u)), \u0009\u000B\u0004.\u000A(ref \u000A))));
				}
				if (\u0013\u000A\u0004.\u000A(u000D_u) != null)
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
					\u0014\u000A\u0004.\u000A(u000D_u, \u0013\u0006\u0004.\u000A(\u0013\u000A\u0004.\u000A(u000D_u), \u0001\u000B\u0004.\u000A(\u0012\u0002\u0004.\u0007(\u0013\u000A\u0004.\u000A(u000D_u)), \u0009\u000B\u0004.\u000A(ref \u000A))));
				}
				if (\u0017\u000A\u0004.\u000A(u000D_u) != null)
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
					\u0020\u000A\u0004.\u000A(u000D_u, \u0013\u0006\u0004.\u000A(\u0017\u000A\u0004.\u000A(u000D_u), \u0001\u000B\u0004.\u000A(\u0012\u0002\u0004.\u0007(\u0017\u000A\u0004.\u000A(u000D_u)), \u0009\u000B\u0004.\u000A(ref \u000A))));
				}
			}
			Color? color = \u0017\u0006\u0004.\u000A(\u0011\u0007\u0004.\u000A(\u001F), \u0014\u0006\u0004.\u000A(ref \u000A));
			Color? color2 = color;
			Color u000A;
			if (!\u0020\u0006\u0004.\u000A(ref color2))
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
				u000A = Color.Empty;
			}
			else
			{
				u000A = \u001E\u0006\u0004.\u000A(ref color2);
			}
			\u0006\u0014\u001D.\u000A(\u001F, u000A);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0003CA38 File Offset: 0x0003AC38
		private static void \u0007(\u0012\u0005 \u001F, BlackAndWhiteSettings \u000A)
		{
			\u001F\u0005.\u000A(\u001F, \u000A);
			if (\u0020\u0001\u001D.\u000A(\u001F) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0005.\u0007(\u0012\u0005, BlackAndWhiteSettings)).MethodHandle;
				}
				\u000B\u001A\u001D.\u000A(\u001F, \u0013\u0006\u0004.\u000A(\u0020\u0001\u001D.\u000A(\u001F), \u0001\u000B\u0004.\u000A(\u0012\u0002\u0004.\u0007(\u0020\u0001\u001D.\u000A(\u001F)), \u0009\u000B\u0004.\u000A(ref \u000A))));
			}
		}
	}
}
