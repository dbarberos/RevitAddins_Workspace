using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Interfaces;
using Syncfusion.XlsIO;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x0200011A RID: 282
	public class SheetRegionInfo
	{
		// Token: 0x170002EA RID: 746
		// (get) Token: 0x06000AAA RID: 2730 RVA: 0x00045820 File Offset: 0x00043A20
		// (set) Token: 0x06000AAB RID: 2731 RVA: 0x00045834 File Offset: 0x00043A34
		internal static List<SheetRegionInfo> SheetRegion { get; set; } = \u001D\u001E\u0004.\u000A();

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x06000AAC RID: 2732 RVA: 0x00045848 File Offset: 0x00043A48
		// (set) Token: 0x06000AAD RID: 2733 RVA: 0x0004585C File Offset: 0x00043A5C
		internal string FilePath { get; set; }

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x06000AAE RID: 2734 RVA: 0x00045870 File Offset: 0x00043A70
		// (set) Token: 0x06000AAF RID: 2735 RVA: 0x00045884 File Offset: 0x00043A84
		internal Dictionary<string, List<NamedRangeInfo>> SheeWithRegions { get; set; }

		// Token: 0x06000AB0 RID: 2736 RVA: 0x00045898 File Offset: 0x00043A98
		internal static Dictionary<string, List<NamedRangeInfo>> \u001D(string \u001F)
		{
			SheetRegionInfo.\u0013\u0005 u0013_u = new SheetRegionInfo.\u0013\u0005();
			u0013_u.\u001F = \u001F;
			SheetRegionInfo sheetRegionInfo = Enumerable.FirstOrDefault<SheetRegionInfo>(\u0016\u001E\u0004.\u000A(), new Func<SheetRegionInfo, bool>(u0013_u.\u000A));
			if (sheetRegionInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetRegionInfo.\u001D(string)).MethodHandle;
				}
				return \u000B\u001E\u0004.\u000A(sheetRegionInfo);
			}
			Dictionary<string, List<NamedRangeInfo>> dictionary = \u001B\u001E\u001D.\u000A();
			ExcelEngine excelEngine = \u0008\u001E\u001D.\u000A();
			try
			{
				IApplication u001F = \u000E\u001E\u001D.\u000A(excelEngine);
				\u0010\u001E\u001D.\u000A(u001F, ExcelVersion.Excel2013);
				u001F.\u001F(\u0007\u0018.\u0007<ICustomLogger>());
				IWorkbook workbook = \u0012\u0019\u000E.\u001F;
				try
				{
					workbook = \u001C\u001E\u001D.\u000A(\u000D\u001E\u001D.\u000A(u001F), u0013_u.\u001F);
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SheetRegionInfo.cs", "GetSheetNameWithRegions");
				}
				if (workbook != null)
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
					try
					{
						IWorksheets u001F2 = \u0003\u001E\u001D.\u000A(workbook);
						List<SheetRegionInfo.\u0014\u0005> u001F3 = SheetRegionInfo.\u0019(workbook);
						for (int i = 0; i < \u0017\u0011\u001D.\u000A(u001F2); i++)
						{
							IWorksheet u001F4 = \u0012\u001E\u001D.\u000A(\u0003\u001E\u001D.\u000A(workbook), i);
							List<string> list = \u0014\u000D\u0007.\u000A();
							IEnumerator<IListObject> enumerator = \u0006\u001E\u001D.\u000A(\u000F\u001E\u001D.\u000A(u001F4));
							try
							{
								while (\u000A\u0017\u000A.\u000A(enumerator))
								{
									IListObject u001F5 = \u0002\u001E\u001D.\u000A(enumerator);
									\u001A\u0008\u0007.\u000A(list, \u000B\u001E\u001D.\u000A(u001F5));
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
							finally
							{
								if (enumerator != null)
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
									\u001F\u0017\u000A.\u000A(enumerator);
								}
							}
							bool flag = false;
							List<NamedRangeInfo> list2 = SheetRegionInfo.\u0004(u001F3, \u0014\u0011\u001D.\u000A(u001F4), list);
							List<NamedRangeInfo> list3 = \u0005\u001E\u001D.\u000A();
							IRange u001F6 = \u0018\u001E\u001D.\u000A(u001F4);
							if (!\u0019\u001E\u001D.\u000A(u001F6))
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
								flag = true;
								\u000C\u0011\u001D.\u000A(list3, \u0004\u001E\u001D.\u000A(u001F6, \u0007\u0018.\u0007<ICustomLogger>()));
							}
							if (\u0007\u001E\u001D.\u000A(\u001D\u001E\u001D.\u000A(u001F4)) != null)
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
								flag = true;
								\u001A\u0011\u001D.\u000A(list3, SheetRegionInfo.\u0018(u001F4));
							}
							if (flag)
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
								if (\u000A\u001E\u001D.\u000A(list2) > 0)
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
									object u001F7 = list3;
									NamedRangeInfo namedRangeInfo = \u001F\u001E\u001D.\u000A();
									\u0009\u0011\u001D.\u000A(namedRangeInfo, string.Empty);
									\u0001\u0011\u001D.\u000A(namedRangeInfo, RangeTypes.SeparatorRange);
									\u0015\u0011\u001D.\u000A(namedRangeInfo, false);
									\u000C\u0011\u001D.\u000A(u001F7, namedRangeInfo);
								}
							}
							\u001A\u0011\u001D.\u000A(list3, list2);
							\u0013\u0011\u001D.\u000A(dictionary, \u0014\u0011\u001D.\u000A(u001F4), list3);
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
						\u0020\u0011\u001D.\u000A(workbook, false);
					}
					catch (Exception u000A2)
					{
						\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SheetRegionInfo.cs", "GetSheetNameWithRegions");
					}
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
			object u001F8 = \u0016\u001E\u0004.\u000A();
			SheetRegionInfo sheetRegionInfo2 = \u0005\u001E\u0004.\u000A();
			\u0018\u001E\u0004.\u000A(sheetRegionInfo2, u0013_u.\u001F);
			\u0019\u001E\u0004.\u000A(sheetRegionInfo2, dictionary);
			\u0004\u001E\u0004.\u000A(u001F8, sheetRegionInfo2);
			return dictionary;
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00045BD8 File Offset: 0x00043DD8
		private static List<NamedRangeInfo> \u0004(List<SheetRegionInfo.\u0014\u0005> \u001F, string \u000A, List<string> \u0007)
		{
			List<NamedRangeInfo> list = \u0005\u001E\u001D.\u000A();
			List<SheetRegionInfo.\u0014\u0005>.Enumerator enumerator = \u0003\u001E\u0004.\u000A(\u001F);
			try
			{
				while (\u0002\u001E\u0004.\u000A(ref enumerator))
				{
					SheetRegionInfo.\u0014\u0005 u001F = \u0012\u001E\u0004.\u000A(ref enumerator);
					IName u001F2 = \u000F\u001E\u0004.\u000A(u001F);
					if (!\u000A\u0020\u001D.\u000A(u001F2))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetRegionInfo.\u0004(List<SheetRegionInfo.\u0014\u0005>, string, List<string>)).MethodHandle;
						}
						if (!\u001F\u0020\u001D.\u000A(\u0007, \u001A\u001E\u001D.\u000A(u001F2)))
						{
							continue;
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
					IRange range = \u0006\u001E\u0004.\u000A(u001F);
					if (\u000D\u0008\u000A.\u000A(\u0014\u0011\u001D.\u000A(\u000C\u001E\u001D.\u000A(range)), \u000A, true))
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
						NamedRangeInfo namedRangeInfo = \u001F\u001E\u001D.\u000A();
						string text = \u001A\u001E\u001D.\u000A(u001F2);
						if (\u0014\u001E\u001D.\u000A(text, \u0013\u001E\u001D.\u0007(namedRangeInfo)))
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
							\u0017\u001E\u001D.\u000A(namedRangeInfo, true);
						}
						\u0020\u001E\u001D.\u000A(namedRangeInfo, range, \u0007\u0018.\u0007<ICustomLogger>());
						\u0011\u001E\u001D.\u000A(namedRangeInfo, !\u001E\u001E\u001D.\u000A(u001F2));
						\u0009\u0011\u001D.\u000A(namedRangeInfo, text);
						\u000C\u0011\u001D.\u000A(list, namedRangeInfo);
					}
				}
				for (;;)
				{
					switch (1)
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
			return list;
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x00045D2C File Offset: 0x00043F2C
		private static List<SheetRegionInfo.\u0014\u0005> \u0019(IWorkbook \u001F)
		{
			List<SheetRegionInfo.\u0014\u0005> list = \u000E\u001E\u0004.\u000A();
			IEnumerator u001F = \u001D\u0011\u000A.\u000A(\u0007\u0020\u001D.\u000A(\u001F));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					IName name = \u0006\u0004\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					IRange range;
					try
					{
						range = \u0009\u001E\u001D.\u000A(name);
					}
					catch (Exception)
					{
						continue;
					}
					if (range != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SheetRegionInfo.\u0019(IWorkbook)).MethodHandle;
						}
						if (!\u0008\u0013\u000A.\u000A(\u001C\u000B\u001D.\u0007(\u001A\u001E\u001D.\u000A(name), "_xlnm.", ""), "Print_Area"))
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
							if (\u0001\u001E\u001D.\u000A(range) != 1)
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
								if (!\u0008\u0013\u000A.\u000A(\u0015\u001E\u001D.\u000A(name), "=#REF!#REF!"))
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
									if (\u000C\u001E\u001D.\u000A(range) != null)
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
										object u001F2 = list;
										SheetRegionInfo.\u0014\u0005 u0014_u = new SheetRegionInfo.\u0014\u0005();
										\u0010\u001E\u0004.\u000A(u0014_u, name);
										\u000D\u001E\u0004.\u000A(u0014_u, range);
										\u001C\u001E\u0004.\u000A(u001F2, u0014_u);
									}
								}
							}
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
			}
			finally
			{
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			return list;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00045E7C File Offset: 0x0004407C
		internal static List<NamedRangeInfo> \u0018(IWorksheet \u001F)
		{
			List<NamedRangeInfo> list = \u0005\u001E\u001D.\u000A();
			object u001F = \u0007\u001E\u001D.\u000A(\u001D\u001E\u001D.\u000A(\u001F));
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = ',';
			string[] array2 = \u0009\u0007\u001D.\u000A(u001F, array);
			int num = 1;
			string[] array3 = array2;
			for (int i = 0; i < (int)\u000C\u0007\u000E.\u001F(array3); i++)
			{
				string u000A = array3[i];
				object u001F2 = list;
				NamedRangeInfo namedRangeInfo = \u001F\u001E\u001D.\u000A();
				\u0011\u001E\u0004.\u000A(namedRangeInfo, num);
				\u0009\u0011\u001D.\u000A(namedRangeInfo, \u0018\u000E\u0007.\u000A("<{0} {1}>", \u001B\u001E\u0004.\u000A(), num));
				\u0001\u0011\u001D.\u000A(namedRangeInfo, RangeTypes.PrintRange);
				\u0008\u001E\u0004.\u000A(namedRangeInfo, u000A);
				\u000C\u0011\u001D.\u000A(u001F2, namedRangeInfo);
				num++;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(SheetRegionInfo.\u0018(IWorksheet)).MethodHandle;
			}
			return list;
		}

		// Token: 0x0400044A RID: 1098
		[CompilerGenerated]
		private static List<SheetRegionInfo> \u001F;

		// Token: 0x0400044B RID: 1099
		[CompilerGenerated]
		private string \u000A;

		// Token: 0x0400044C RID: 1100
		[CompilerGenerated]
		private Dictionary<string, List<NamedRangeInfo>> \u0007;

		// Token: 0x0200080E RID: 2062
		private class \u0014\u0005
		{
			// Token: 0x17001367 RID: 4967
			// (get) Token: 0x06004D95 RID: 19861 RVA: 0x001DE904 File Offset: 0x001DCB04
			// (set) Token: 0x06004D96 RID: 19862 RVA: 0x001DE918 File Offset: 0x001DCB18
			public IName Name { get; set; }

			// Token: 0x17001368 RID: 4968
			// (get) Token: 0x06004D97 RID: 19863 RVA: 0x001DE92C File Offset: 0x001DCB2C
			// (set) Token: 0x06004D98 RID: 19864 RVA: 0x001DE940 File Offset: 0x001DCB40
			public IRange Range { get; set; }

			// Token: 0x04002058 RID: 8280
			[CompilerGenerated]
			private IName \u001F;

			// Token: 0x04002059 RID: 8281
			[CompilerGenerated]
			private IRange \u000A;
		}

		// Token: 0x0200080F RID: 2063
		[CompilerGenerated]
		private sealed class \u0013\u0005
		{
			// Token: 0x06004D9A RID: 19866 RVA: 0x001DE968 File Offset: 0x001DCB68
			internal bool \u000A(SheetRegionInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001E\u001F\u0010.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400205A RID: 8282
			public string \u001F;
		}
	}
}
