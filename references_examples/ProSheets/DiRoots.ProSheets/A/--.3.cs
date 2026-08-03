using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ProSheets;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;

namespace A
{
	// Token: 0x020000CE RID: 206
	internal static class \u000D\u001F\u0018
	{
		// Token: 0x06000B34 RID: 2868 RVA: 0x00042864 File Offset: 0x00040A64
		public static bool \u000C(List<IParameterModel> \u000C, Parameters \u0018)
		{
			\u000D\u001F\u0018.\u0016\u001F\u0018 u0016_u001F_u = new \u000D\u001F\u0018.\u0016\u001F\u0018();
			u0016_u001F_u.\u000C = \u0018;
			bool result = false;
			List<ParameterModel> u000C = \u000F\u0009\u0016.\u0018();
			List<ParameterModel>.Enumerator enumerator = \u0019\u0019\u0014.\u0018(\u0013\u0019\u0014.\u0018(u0016_u001F_u.\u000C));
			try
			{
				while (\u0020\u0019\u0014.\u0018(ref enumerator))
				{
					\u000D\u001F\u0018.\u000F\u001F\u0018 u000F_u001F_u = new \u000D\u001F\u0018.\u000F\u001F\u0018();
					u000F_u001F_u.\u000C = \u000B\u0019\u0014.\u0018(ref enumerator);
					if (!\u0016\u0009\u0016.\u0018(\u000C, new Predicate<IParameterModel>(u000F_u001F_u.\u0018)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u001F\u0018.\u000C(List<IParameterModel>, Parameters)).MethodHandle;
						}
						result = true;
						\u0003\u0009\u0016.\u0018(u000C, u000F_u001F_u.\u000C);
					}
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
			\u0014\u0009\u0016.\u0018(u000C, new Action<ParameterModel>(u0016_u001F_u.\u0018));
			return result;
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x00042938 File Offset: 0x00040B38
		public static List<ParameterModel> \u0018(List<IParameterModel> \u000C, SelectionTemPlateInfo \u0018)
		{
			string text;
			if (!\u000E\u0003\u0003.\u0018(\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u001F\u0018.\u0018(List<IParameterModel>, SelectionTemPlateInfo)).MethodHandle;
				}
				text = string.Empty;
			}
			else
			{
				char c = \u001B\u0003\u0003.\u0018(\u0018);
				text = \u0006\u000B\u0014.\u0018(ref c);
			}
			string text2 = text;
			List<SelectionParameter> u000C = \u0010\u0003\u0003.\u0018(\u0018);
			List<ParameterModel> list = \u000F\u0009\u0016.\u0018();
			StringBuilder u000C2 = \u0005\u0017\u0018.\u0018();
			int num = 0;
			List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(u000C);
			try
			{
				while (\u0017\u0018\u0014.\u0018(ref enumerator))
				{
					\u000D\u001F\u0018.\u0012\u001F\u0018 u0012_u001F_u = new \u000D\u001F\u0018.\u0012\u001F\u0018();
					u0012_u001F_u.\u000C = \u0004\u0018\u0014.\u0018(ref enumerator);
					switch (\u000B\u0020\u0014.\u0014(u0012_u001F_u.\u000C))
					{
					case SelectionParameterType.Revit:
					case SelectionParameterType.Variable:
					{
						IParameterModel u000C3 = \u0002\u0009\u0016.\u0018(\u000C, new Predicate<IParameterModel>(u0012_u001F_u.\u0018));
						ParameterModel parameterModel = \u0011\u0009\u0016.\u0018(\u001E\u0009\u0016.\u0018(u000C3), \u0017\u0009\u0016.\u0018(u000C3), \u0015\u0009\u0016.\u0018(u000C3), "", "", "-");
						\u001F\u0009\u0016.\u0014(parameterModel, text2);
						\u0020\u0009\u0016.\u0014(parameterModel, \u0001\u0017\u0018.\u0018(u000C2));
						\u0009\u0009\u0016.\u0018(parameterModel, \u000A\u0009\u0016.\u0018(u000C3));
						\u001C\u0009\u0016.\u0018(parameterModel, \u0013\u0009\u0016.\u0018(u000C3));
						\u0003\u0009\u0016.\u0018(list, parameterModel);
						\u000D\u0009\u0016.\u0018(u000C2);
						break;
					}
					case SelectionParameterType.CustomText:
						\u0017\u0020\u0014.\u0018(\u0017\u0020\u0014.\u0018(u000C2, \u0002\u0020\u0014.\u0014(u0012_u001F_u.\u000C)), text2);
						break;
					case SelectionParameterType.CustemSeparator:
						if (num > 0)
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
							if (\u000B\u0020\u0014.\u0014(\u0001\u000B\u0014.\u0018(u000C, num - 1)) != SelectionParameterType.Revit)
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
								if (\u000B\u0020\u0014.\u0014(\u0001\u000B\u0014.\u0018(u000C, num - 1)) != SelectionParameterType.Variable)
								{
									goto IL_13F;
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
							\u001F\u0009\u0016.\u0014(Enumerable.LastOrDefault<ParameterModel>(list), \u0002\u0020\u0014.\u0014(u0012_u001F_u.\u000C));
							break;
						}
						IL_13F:
						\u000D\u001F\u0018.\u0014(u000C2, text2);
						\u0017\u0020\u0014.\u0018(u000C2, \u0002\u0020\u0014.\u0014(u0012_u001F_u.\u000C));
						break;
					}
					num++;
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
			if (\u001E\u0019\u0014.\u0018(u000C2) > 0)
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
				if (Enumerable.Any<ParameterModel>(list))
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
					\u0011\u0019\u0014.\u0018(u000C2, 0, text2);
					\u000D\u001F\u0018.\u0014(u000C2, text2);
					\u0012\u0009\u0016.\u0014(Enumerable.LastOrDefault<ParameterModel>(list), \u0001\u0017\u0018.\u0018(u000C2));
				}
			}
			return list;
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x00042BD4 File Offset: 0x00040DD4
		private static void \u0014(StringBuilder \u000C, string \u0018)
		{
			if (\u001E\u0019\u0014.\u0018(\u000C) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u001F\u0018.\u0014(StringBuilder, string)).MethodHandle;
				}
				if (\u0015\u0013\u0016.\u0018(\u0001\u0017\u0018.\u0018(\u000C), \u0018))
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
					\u0004\u0009\u0016.\u0018(\u000C, \u001E\u0019\u0014.\u0018(\u000C) - \u001C\u0002\u0018.\u0014(\u0018), \u001C\u0002\u0018.\u0014(\u0018));
				}
			}
		}

		// Token: 0x020001CF RID: 463
		[CompilerGenerated]
		private sealed class \u0016\u001F\u0018
		{
			// Token: 0x060011F3 RID: 4595 RVA: 0x0005D9C8 File Offset: 0x0005BBC8
			internal void \u0018(ParameterModel \u000C)
			{
				\u0009\u0011\u000F.\u0018(\u0013\u0019\u0014.\u0018(this.\u000C), \u000C);
			}

			// Token: 0x04000884 RID: 2180
			public Parameters \u000C;
		}

		// Token: 0x020001D0 RID: 464
		[CompilerGenerated]
		private sealed class \u000F\u001F\u0018
		{
			// Token: 0x060011F5 RID: 4597 RVA: 0x0005DA00 File Offset: 0x0005BC00
			internal bool \u0018(IParameterModel \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001E\u0009\u0016.\u0018(\u000C), \u0004\u0019\u0014.\u0014(this.\u000C));
			}

			// Token: 0x04000885 RID: 2181
			public ParameterModel \u000C;
		}

		// Token: 0x020001D1 RID: 465
		[CompilerGenerated]
		private sealed class \u0012\u001F\u0018
		{
			// Token: 0x060011F7 RID: 4599 RVA: 0x0005DA40 File Offset: 0x0005BC40
			internal bool \u0018(IParameterModel \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u001E\u0009\u0016.\u0018(\u000C), \u0002\u0020\u0014.\u0014(this.\u000C), true);
			}

			// Token: 0x04000886 RID: 2182
			public SelectionParameter \u000C;
		}
	}
}
