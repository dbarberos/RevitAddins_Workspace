using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000F5 RID: 245
	internal static class \u000A\u0005
	{
		// Token: 0x060008E5 RID: 2277 RVA: 0x0003CAA0 File Offset: 0x0003ACA0
		internal static IRange \u001F(IWorkbook \u001F, SelectedExcel \u000A)
		{
			if (\u001F != null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0005.\u001F(IWorkbook, SelectedExcel)).MethodHandle;
				}
				bool flag;
				if (\u000A == null)
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
					flag = (null != null);
				}
				else
				{
					flag = (\u0014\u0020\u001D.\u001D(\u000A) != null);
				}
				if (flag)
				{
					IRange result;
					try
					{
						IWorksheet worksheet = \u000A\u000F\u0004.\u000A(\u0003\u001E\u001D.\u000A(\u001F), \u0020\u0020\u001D.\u0007(\u000A));
						if (worksheet == null)
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
							result = \u000B\u0004\u000E.\u001F;
						}
						else
						{
							NamedRangeInfo u001F = \u0014\u0020\u001D.\u0007(\u000A);
							if (\u0013\u0020\u001D.\u0007(u001F) == RangeTypes.UsedRange)
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
								result = \u0018\u001E\u001D.\u000A(worksheet);
							}
							else if (\u0013\u0020\u001D.\u0007(u001F) == RangeTypes.PrintRange)
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
								result = \u0009\u0006\u0004.\u000A(worksheet, \u001F\u000F\u0004.\u000A(u001F));
							}
							else
							{
								INames names;
								if (!\u0001\u0006\u0004.\u000A(u001F))
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
									names = \u0015\u0006\u0004.\u000A(worksheet);
								}
								else
								{
									names = \u0007\u0020\u001D.\u000A(\u001F);
								}
								INames u001F2 = names;
								IName name = \u000C\u0006\u0004.\u000A(u001F2, \u0017\u0020\u001D.\u0007(u001F));
								if (name == null)
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
									IEnumerator u001F3 = \u001D\u0011\u000A.\u000A(u001F2);
									try
									{
										while (\u000A\u0017\u000A.\u000A(u001F3))
										{
											IName name2 = \u0006\u0004\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F3));
											string u001F4 = \u0003\u000B\u001D.\u0007(\u001A\u001E\u001D.\u000A(name2));
											string text = \u0017\u0020\u001D.\u0007(u001F);
											string u000A;
											if (text == null)
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
												u000A = \u000F\u0015\u0010.\u001F;
											}
											else
											{
												u000A = \u0003\u000B\u001D.\u001D(text);
											}
											if (\u0008\u0013\u000A.\u000A(u001F4, u000A))
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
												name = name2;
												goto IL_1B1;
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
									}
									finally
									{
										IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F3);
										if (disposable != null)
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
											\u001F\u0017\u000A.\u000A(disposable);
										}
									}
								}
								IL_1B1:
								IRange range;
								if (name == null)
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
									range = \u000B\u0004\u000E.\u001F;
								}
								else
								{
									range = \u0009\u001E\u001D.\u000A(name);
								}
								result = range;
							}
						}
					}
					catch (Exception u000A2)
					{
						\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\ExcelStyleExtractor.cs", "ResolveRange");
						result = \u000B\u0004\u000E.\u001F;
					}
					return result;
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return null;
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x0003CCD8 File Offset: 0x0003AED8
		[return: TupleElementNames(new string[]
		{
			"lineStyles",
			"textStyles"
		})]
		internal static ValueTuple<HashSet<ExcelLineStyleInfo>, HashSet<ExcelTextStyleInfo>> \u000A(IRange \u001F)
		{
			HashSet<ExcelLineStyleInfo> hashSet = \u001D\u000F\u0004.\u000A();
			HashSet<ExcelTextStyleInfo> hashSet2 = \u0007\u000F\u0004.\u000A();
			if (\u001F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0005.\u000A(IRange)).MethodHandle;
				}
				return new ValueTuple<HashSet<ExcelLineStyleInfo>, HashSet<ExcelTextStyleInfo>>(hashSet, hashSet2);
			}
			IWorksheet u001F = \u000C\u001E\u001D.\u000A(\u001F);
			int num = \u000B\u0013\u001D.\u000A(\u001F) - \u0009\u0020\u001D.\u000A(\u001F) + 1;
			int num2 = \u0016\u0013\u001D.\u000A(\u001F) - \u0001\u0020\u001D.\u000A(\u001F) + 1;
			int num3 = \u0009\u0020\u001D.\u000A(\u001F);
			int num4 = \u0001\u0020\u001D.\u000A(\u001F);
			for (int i = 0; i < num; i++)
			{
				int u000A = num3 + i;
				if (\u0019\u0013\u001D.\u000A(u001F, u000A))
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
					for (int j = 0; j < num2; j++)
					{
						int num5 = num4 + j;
						if (\u001C\u0014\u001D.\u000A(u001F, num5))
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
							IRange u001F2 = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F), u000A, num5);
							\u000A\u0005.\u0007(u001F2, hashSet);
							\u000A\u0005.\u0004(u001F2, hashSet2);
						}
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
			return new ValueTuple<HashSet<ExcelLineStyleInfo>, HashSet<ExcelTextStyleInfo>>(hashSet, hashSet2);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0003CDF8 File Offset: 0x0003AFF8
		private static void \u0007(IRange \u001F, HashSet<ExcelLineStyleInfo> \u000A)
		{
			IBorders u001F = \u0007\u0013\u001D.\u000A(\u001F);
			\u000A\u0005.\u001D(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeTop), \u000A);
			\u000A\u0005.\u001D(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeRight), \u000A);
			\u000A\u0005.\u001D(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeBottom), \u000A);
			\u000A\u0005.\u001D(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeLeft), \u000A);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x0003CE4C File Offset: 0x0003B04C
		private static void \u001D(IBorder \u001F, HashSet<ExcelLineStyleInfo> \u000A)
		{
			if (\u0012\u001A\u001D.\u000A(\u001F) == ExcelLineStyle.None)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0005.\u001D(IBorder, HashSet<ExcelLineStyleInfo>)).MethodHandle;
				}
				return;
			}
			\u0004\u000F\u0004.\u000A(\u000A, \u0006\u001A\u001D.\u000A(\u0012\u001A\u001D.\u000A(\u001F), \u000F\u001A\u001D.\u000A(\u001F)));
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0003CE98 File Offset: 0x0003B098
		private static void \u0004(IRange \u001F, HashSet<ExcelTextStyleInfo> \u000A)
		{
			IFont font = \u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u001F));
			if (font == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0005.\u0004(IRange, HashSet<ExcelTextStyleInfo>)).MethodHandle;
				}
				return;
			}
			Color u000A = \u000A\u000C\u001D.\u000A(font);
			ExcelTextStyleInfo u000A2 = \u0015\u001A\u001D.\u000A(\u0011\u001A\u001D.\u000A(font), u000A, \u001E\u0017\u001D.\u000A(font), \u001F\u000C\u001D.\u000A(font), \u0009\u001A\u001D.\u000A(font), \u0001\u001A\u001D.\u000A(font) > ExcelUnderline.None);
			\u0019\u000F\u0004.\u000A(\u000A, u000A2);
		}
	}
}
