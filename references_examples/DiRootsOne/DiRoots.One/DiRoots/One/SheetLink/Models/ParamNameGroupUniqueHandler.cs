using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x02000249 RID: 585
	public class ParamNameGroupUniqueHandler
	{
		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x00099F18 File Offset: 0x00098118
		// (set) Token: 0x06001787 RID: 6023 RVA: 0x00099F2C File Offset: 0x0009812C
		public string Name { get; set; }

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x00099F40 File Offset: 0x00098140
		// (set) Token: 0x06001789 RID: 6025 RVA: 0x00099F54 File Offset: 0x00098154
		public long Id { get; set; }

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x00099F68 File Offset: 0x00098168
		// (set) Token: 0x0600178B RID: 6027 RVA: 0x00099F7C File Offset: 0x0009817C
		public OtherParamTypes OtherParamType { get; set; }

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x00099F90 File Offset: 0x00098190
		// (set) Token: 0x0600178D RID: 6029 RVA: 0x00099FA4 File Offset: 0x000981A4
		public string StorageType { get; set; }

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x00099FB8 File Offset: 0x000981B8
		// (set) Token: 0x0600178F RID: 6031 RVA: 0x00099FCC File Offset: 0x000981CC
		public string FieldType { get; set; }

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x00099FE0 File Offset: 0x000981E0
		// (set) Token: 0x06001791 RID: 6033 RVA: 0x00099FF4 File Offset: 0x000981F4
		public int ParamNameGroupIndex { get; set; }

		// Token: 0x06001792 RID: 6034 RVA: 0x0009A008 File Offset: 0x00098208
		internal static void \u0018(\u0015\u001C \u001F, List<RevitParameter> \u000A)
		{
			List<RevitParameter>.Enumerator enumerator = \u0013\u000D\u0018.\u000A(\u000A);
			try
			{
				while (\u0011\u000D\u0018.\u000A(ref enumerator))
				{
					ParamNameGroupUniqueHandler.\u001D\u000D u001D_u000D = new ParamNameGroupUniqueHandler.\u001D\u000D();
					u001D_u000D.\u001F = \u0014\u000D\u0018.\u000A(ref enumerator);
					ParamNameGroupUniqueHandler paramNameGroupUniqueHandler = \u000F\u0011\u0005.\u000A();
					\u0015\u001B\u0005.\u000A(paramNameGroupUniqueHandler, \u0001\u001B\u0005.\u000A(u001D_u000D.\u001F));
					\u0006\u0011\u0005.\u000A(paramNameGroupUniqueHandler, \u0004\u001E\u0018.\u0007(u001D_u000D.\u001F));
					\u0002\u0011\u0005.\u000A(paramNameGroupUniqueHandler, \u0017\u000B\u0018.\u0007(u001D_u000D.\u001F));
					\u000B\u0011\u0005.\u000A(paramNameGroupUniqueHandler, \u001E\u0011\u0018.\u0007(u001D_u000D.\u001F));
					\u0016\u0011\u0005.\u000A(paramNameGroupUniqueHandler, \u001F\u001E\u0018.\u0007(u001D_u000D.\u001F));
					\u0005\u0011\u0005.\u000A(paramNameGroupUniqueHandler, \u0004\u001B\u0018.\u0007(u001D_u000D.\u001F));
					if (!Enumerable.Contains<ParamNameGroupUniqueHandler>(\u001F\u0011\u0005.\u000A(\u001F), paramNameGroupUniqueHandler, new \u0006\u000E()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ParamNameGroupUniqueHandler.\u0018(\u0015\u001C, List<RevitParameter>)).MethodHandle;
						}
						\u0018\u0011\u0005.\u000A(\u001F\u0011\u0005.\u000A(\u001F), paramNameGroupUniqueHandler);
					}
					else
					{
						ParamNameGroupUniqueHandler paramNameGroupUniqueHandler2 = \u0009\u001B\u0005.\u000A(\u001F\u0011\u0005.\u000A(\u001F), new Predicate<ParamNameGroupUniqueHandler>(u001D_u000D.\u000A));
						if (paramNameGroupUniqueHandler2 != null)
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
							\u0015\u001B\u0005.\u000A(paramNameGroupUniqueHandler, \u0019\u0011\u0005.\u000A(paramNameGroupUniqueHandler2));
							\u000A\u0011\u0005.\u000A(u001D_u000D.\u001F, \u0019\u0011\u0005.\u000A(paramNameGroupUniqueHandler2));
						}
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			Func<RevitParameter, string> func;
			if ((func = ParamNameGroupUniqueHandler.<>c.\u000A) == null)
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
				func = (ParamNameGroupUniqueHandler.<>c.\u000A = new Func<RevitParameter, string>(ParamNameGroupUniqueHandler.<>c.\u001F.\u0005));
			}
			IEnumerable<IGrouping<string, RevitParameter>> enumerable = Enumerable.GroupBy<RevitParameter, string>(\u000A, func);
			Func<IGrouping<string, RevitParameter>, string> func2;
			if ((func2 = ParamNameGroupUniqueHandler.<>c.\u0007) == null)
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
				func2 = (ParamNameGroupUniqueHandler.<>c.\u0007 = new Func<IGrouping<string, RevitParameter>, string>(ParamNameGroupUniqueHandler.<>c.\u001F.\u0016));
			}
			Func<IGrouping<string, RevitParameter>, List<RevitParameter>> func3;
			if ((func3 = ParamNameGroupUniqueHandler.<>c.\u001D) == null)
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
				func3 = (ParamNameGroupUniqueHandler.<>c.\u001D = new Func<IGrouping<string, RevitParameter>, List<RevitParameter>>(ParamNameGroupUniqueHandler.<>c.\u001F.\u000B));
			}
			Dictionary<string, List<RevitParameter>>.Enumerator enumerator2 = \u0004\u0011\u0005.\u000A(Enumerable.ToDictionary<IGrouping<string, RevitParameter>, string, List<RevitParameter>>(enumerable, func2, func3));
			try
			{
				while (\u000C\u001B\u0005.\u000A(ref enumerator2))
				{
					KeyValuePair<string, List<RevitParameter>> keyValuePair = \u001D\u0011\u0005.\u000A(ref enumerator2);
					int num = 1;
					List<RevitParameter> list = \u0007\u0011\u0005.\u000A(ref keyValuePair);
					if (\u0008\u000D\u0018.\u000A(list) > 1)
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
						IEnumerable<RevitParameter> enumerable2 = \u0007\u0011\u0005.\u000A(ref keyValuePair);
						Func<RevitParameter, int> func4;
						if ((func4 = ParamNameGroupUniqueHandler.<>c.\u0004) == null)
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
							func4 = (ParamNameGroupUniqueHandler.<>c.\u0004 = new Func<RevitParameter, int>(ParamNameGroupUniqueHandler.<>c.\u001F.\u0002));
						}
						list = Enumerable.ToList<RevitParameter>(Enumerable.OrderBy<RevitParameter, int>(enumerable2, func4));
						IEnumerable<RevitParameter> enumerable3 = list;
						Func<RevitParameter, int> func5;
						if ((func5 = ParamNameGroupUniqueHandler.<>c.\u0019) == null)
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
							func5 = (ParamNameGroupUniqueHandler.<>c.\u0019 = new Func<RevitParameter, int>(ParamNameGroupUniqueHandler.<>c.\u001F.\u0006));
						}
						num = Enumerable.Max<RevitParameter>(enumerable3, func5);
						num++;
					}
					IEnumerable<RevitParameter> enumerable4 = list;
					Func<RevitParameter, bool> func6;
					if ((func6 = ParamNameGroupUniqueHandler.<>c.\u0018) == null)
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
						func6 = (ParamNameGroupUniqueHandler.<>c.\u0018 = new Func<RevitParameter, bool>(ParamNameGroupUniqueHandler.<>c.\u001F.\u000F));
					}
					list = Enumerable.ToList<RevitParameter>(Enumerable.Where<RevitParameter>(enumerable4, func6));
					enumerator = \u0013\u000D\u0018.\u000A(list);
					try
					{
						while (\u0011\u000D\u0018.\u000A(ref enumerator))
						{
							ParamNameGroupUniqueHandler.\u0004\u000D u0004_u000D = new ParamNameGroupUniqueHandler.\u0004\u000D();
							u0004_u000D.\u001F = \u0014\u000D\u0018.\u000A(ref enumerator);
							\u000A\u0011\u0005.\u000A(u0004_u000D.\u001F, num);
							ParamNameGroupUniqueHandler paramNameGroupUniqueHandler3 = \u0009\u001B\u0005.\u000A(\u001F\u0011\u0005.\u000A(\u001F), new Predicate<ParamNameGroupUniqueHandler>(u0004_u000D.\u000A));
							if (paramNameGroupUniqueHandler3 != null)
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
								\u0015\u001B\u0005.\u000A(paramNameGroupUniqueHandler3, \u0001\u001B\u0005.\u000A(u0004_u000D.\u001F));
							}
							num++;
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
					}
					finally
					{
						((IDisposable)enumerator).Dispose();
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
				((IDisposable)enumerator2).Dispose();
			}
		}

		// Token: 0x04000943 RID: 2371
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x04000944 RID: 2372
		[CompilerGenerated]
		private long \u000A;

		// Token: 0x04000945 RID: 2373
		[CompilerGenerated]
		private OtherParamTypes \u0007;

		// Token: 0x04000946 RID: 2374
		[CompilerGenerated]
		private string \u001D;

		// Token: 0x04000947 RID: 2375
		[CompilerGenerated]
		private string \u0004;

		// Token: 0x04000948 RID: 2376
		[CompilerGenerated]
		private int \u0019;

		// Token: 0x02000920 RID: 2336
		[CompilerGenerated]
		private sealed class \u001D\u000D
		{
			// Token: 0x060051D4 RID: 20948 RVA: 0x001E96EC File Offset: 0x001E78EC
			internal bool \u000A(ParamNameGroupUniqueHandler \u001F)
			{
				return \u0006\u000E.\u001F(\u001F, this.\u001F);
			}

			// Token: 0x040023FC RID: 9212
			public RevitParameter \u001F;
		}

		// Token: 0x02000921 RID: 2337
		[CompilerGenerated]
		private sealed class \u0004\u000D
		{
			// Token: 0x060051D6 RID: 20950 RVA: 0x001E971C File Offset: 0x001E791C
			internal bool \u000A(ParamNameGroupUniqueHandler \u001F)
			{
				return \u0006\u000E.\u001F(\u001F, this.\u001F);
			}

			// Token: 0x040023FD RID: 9213
			public RevitParameter \u001F;
		}
	}
}
