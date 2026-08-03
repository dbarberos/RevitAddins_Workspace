using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.ProSheets.Models;
using DiRoots.ProSheets.ViewModels;
using ProSheets;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Helpers;
using ProSheets.Models;
using ProSheets.UI;

namespace A
{
	// Token: 0x02000066 RID: 102
	internal class \u000C\u000A\u0018
	{
		// Token: 0x14000013 RID: 19
		// (add) Token: 0x06000535 RID: 1333 RVA: 0x0001AB18 File Offset: 0x00018D18
		// (remove) Token: 0x06000536 RID: 1334 RVA: 0x0001AB64 File Offset: 0x00018D64
		public static event \u000C\u000A\u0018.\u0006\u0009\u0018 \u000C
		{
			[CompilerGenerated]
			add
			{
				\u000C\u000A\u0018.\u0006\u0009\u0018 u0006_u0009_u = \u000C\u000A\u0018.\u000C;
				\u000C\u000A\u0018.\u0006\u0009\u0018 u0006_u0009_u2;
				do
				{
					u0006_u0009_u2 = u0006_u0009_u;
					\u000C\u000A\u0018.\u0006\u0009\u0018 value2 = (\u000C\u000A\u0018.\u0006\u0009\u0018)\u001C\u0019\u0018.\u0018(u0006_u0009_u2, value);
					u0006_u0009_u = Interlocked.CompareExchange<\u000C\u000A\u0018.\u0006\u0009\u0018>(ref \u000C\u000A\u0018.\u000C, value2, u0006_u0009_u2);
				}
				while (u0006_u0009_u != u0006_u0009_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.add_\u000C(\u000C\u000A\u0018.\u0006\u0009\u0018)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u000C\u000A\u0018.\u0006\u0009\u0018 u0006_u0009_u = \u000C\u000A\u0018.\u000C;
				\u000C\u000A\u0018.\u0006\u0009\u0018 u0006_u0009_u2;
				do
				{
					u0006_u0009_u2 = u0006_u0009_u;
					\u000C\u000A\u0018.\u0006\u0009\u0018 value2 = (\u000C\u000A\u0018.\u0006\u0009\u0018)\u0013\u0019\u0018.\u0018(u0006_u0009_u2, value);
					u0006_u0009_u = Interlocked.CompareExchange<\u000C\u000A\u0018.\u0006\u0009\u0018>(ref \u000C\u000A\u0018.\u000C, value2, u0006_u0009_u2);
				}
				while (u0006_u0009_u != u0006_u0009_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.remove_\u000C(\u000C\u000A\u0018.\u0006\u0009\u0018)).MethodHandle;
				}
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0001ABB0 File Offset: 0x00018DB0
		public static List<SheetInfo> \u0014(Document \u000C, List<ViewSheet> \u0018)
		{
			List<SheetInfo> list = \u0010\u001A\u000F.\u000C;
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheets");
				Func<ViewSheet, bool> func;
				if ((func = \u000C\u000A\u0018.<>c.\u0018) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0014(Document, List<ViewSheet>)).MethodHandle;
					}
					func = (\u000C\u000A\u0018.<>c.\u0018 = new Func<ViewSheet, bool>(\u000C\u000A\u0018.<>c.\u000C.\u000A));
				}
				\u000C\u000A\u0018.\u0018 = Enumerable.ToList<ViewSheet>(Enumerable.Where<ViewSheet>(\u0018, func));
				list = \u000C\u000A\u0018.\u0003(\u000C, \u000C\u000A\u0018.\u0018);
				IEnumerable<SheetInfo> enumerable = list;
				Func<SheetInfo, string> func2;
				if ((func2 = \u000C\u000A\u0018.<>c.\u0014) == null)
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
					func2 = (\u000C\u000A\u0018.<>c.\u0014 = new Func<SheetInfo, string>(\u000C\u000A\u0018.<>c.\u000C.\u0020));
				}
				list = Enumerable.ToList<SheetInfo>(Enumerable.OrderBy<SheetInfo, string>(enumerable, func2));
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheets");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheets");
			}
			return list;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0001ACA8 File Offset: 0x00018EA8
		public static List<SheetInfo> \u0003(Document \u000C, List<ViewSheet> \u0018)
		{
			List<\u000C\u000A\u0018.\u0008\u0009\u0018> u = \u000C\u000A\u0018.\u000F(\u000C);
			List<SheetInfo> list = \u001D\u0017\u0014.\u0018();
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheetDeatils");
				int num = 0;
				int num2 = \u0011\u001D\u0014.\u0018(\u0018);
				int num3;
				if (\u0011\u001D\u0014.\u0018(\u0018) / 10 != 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0003(Document, List<ViewSheet>)).MethodHandle;
					}
					num3 = \u0011\u001D\u0014.\u0018(\u0018) / 10;
				}
				else
				{
					num3 = 1;
				}
				int num4 = num3;
				bool u2 = \u0014\u001F\u0018.\u0016(IocContainer.GetService<ICustomLogger>());
				List<ViewSheet>.Enumerator enumerator = \u001F\u001D\u0014.\u0018(\u0018);
				try
				{
					while (\u0013\u001D\u0014.\u0018(ref enumerator))
					{
						ViewSheet u3 = \u0020\u001D\u0014.\u0018(ref enumerator);
						if (\u000A\u001D\u0014.\u0018())
						{
							goto IL_10E;
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
						if (num % num4 == 0)
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
							int u4 = num * 100 / num2;
							\u000C\u000A\u0018.\u0006\u0009\u0018 u000C = \u000C\u000A\u0018.\u000C;
							if (u000C == null)
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
							}
							else
							{
								\u0009\u001D\u0014.\u0018(u000C, u4);
							}
						}
						num++;
						SheetInfo u5 = \u000C\u000A\u0018.\u0016(\u000C, u, u3, u2);
						\u0007\u000E\u0018.\u0018(list, u5);
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
					((IDisposable)enumerator).Dispose();
				}
				IL_10E:
				PdfOptions.objPaperSizeSet = \u0019\u0009\u0018.\u0018(\u000C);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheetDeatils");
			}
			catch (Exception u6)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u6, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheetDeatils");
			}
			return list;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001AE3C File Offset: 0x0001903C
		private static SheetInfo \u0016(Document \u000C, List<\u000C\u000A\u0018.\u0008\u0009\u0018> \u0018, ViewSheet \u0014, bool \u0003)
		{
			\u000C\u000A\u0018.\u000E\u0009\u0018 u000E_u0009_u = new \u000C\u000A\u0018.\u000E\u0009\u0018();
			\u000C\u000A\u0018.\u000E\u0009\u0018 u000E_u0009_u2 = u000E_u0009_u;
			SheetInfo u000C = \u0012\u0004\u0014.\u0018();
			\u000F\u0004\u0014.\u0018(u000C, \u0009\u0002\u0018.\u0018(\u0014));
			\u0002\u001D\u0014.\u0018(u000C, \u0009\u0002\u0018.\u0018(\u0014).\u000C());
			\u0016\u0004\u0014.\u0018(u000C, \u001E\u001D\u0014.\u0018(\u0014));
			\u0003\u0004\u0014.\u0018(u000C, \u001E\u0016\u0014.\u0018(\u0014));
			\u0015\u001D\u0014.\u0018(u000C, \u0001\u0002\u0018.\u0018(\u0017\u001D\u0014.\u0018(\u0014, -1007412L)));
			\u0018\u0004\u0014.\u0018(u000C, \u001A\u0003\u0014.\u0018(\u0014));
			u000E_u0009_u2.\u000C = u000C;
			List<\u000C\u000A\u0018.\u0008\u0009\u0018> u = Enumerable.ToList<\u000C\u000A\u0018.\u0008\u0009\u0018>(Enumerable.Where<\u000C\u000A\u0018.\u0008\u0009\u0018>(\u0018, new Func<\u000C\u000A\u0018.\u0008\u0009\u0018, bool>(u000E_u0009_u.\u0018)));
			string u2;
			string u3;
			\u000C\u000A\u0018.\u0013(\u000C, u, \u0003, out u2, out u3);
			\u0005\u000E\u0018.\u0018(u000E_u0009_u.\u000C, u2);
			\u0008\u0002\u0014.\u0018(u000E_u0009_u.\u000C, \u0004\u0017\u0014.\u0018(u000E_u0009_u.\u000C));
			\u0006\u000E\u0018.\u0018(u000E_u0009_u.\u000C, u3);
			return u000E_u0009_u.\u000C;
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0001AF24 File Offset: 0x00019124
		private static List<\u000C\u000A\u0018.\u0008\u0009\u0018> \u000F(Document \u000C)
		{
			List<\u000C\u000A\u0018.\u0008\u0009\u0018> list = \u0008\u001D\u0014.\u0018();
			object u000C = Enumerable.ToList<FamilyInstance>(Enumerable.Cast<FamilyInstance>(\u0010\u001D\u0014.\u0014(\u0006\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(\u000C), -2000280L), \u000A\u001D\u0018.\u0018(\u000D\u000B\u000F.\u000C()))));
			int num = 0;
			List<FamilyInstance>.Enumerator enumerator = \u0007\u001D\u0014.\u0018(u000C);
			try
			{
				while (\u0004\u001D\u0014.\u0018(ref enumerator))
				{
					FamilyInstance familyInstance = \u0019\u001D\u0014.\u0018(ref enumerator);
					\u000C\u000A\u0018.\u0008\u0009\u0018 u0008_u0009_u = new \u000C\u000A\u0018.\u0008\u0009\u0018();
					try
					{
						u0008_u0009_u.\u000C = \u000B\u001D\u0014.\u0018(familyInstance).\u000C();
						u0008_u0009_u.\u0003 = \u001A\u001D\u0014.\u0018(\u0017\u001D\u0014.\u0018(familyInstance, -1007410L));
						u0008_u0009_u.\u0016 = \u001A\u001D\u0014.\u0018(\u0017\u001D\u0014.\u0018(familyInstance, -1007411L));
					}
					catch (Exception)
					{
					}
					u0008_u0009_u.\u0018 = num;
					u0008_u0009_u.\u0014 = familyInstance;
					\u001D\u001D\u0014.\u0018(list, u0008_u0009_u);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u000F(Document)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0001B050 File Offset: 0x00019250
		public static List<SheetInfo> \u0012(Document \u000C, List<View> \u0018, List<string> \u0014)
		{
			List<SheetInfo> list = \u001D\u0017\u0014.\u0018();
			try
			{
				List<Element> u000C;
				if (\u0018 == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0012(Document, List<View>, List<string>)).MethodHandle;
					}
					u000C = Enumerable.ToList<Element>(\u000D\u001A\u0014.\u0018(\u0010\u001D\u0014.\u0014(\u0020\u001D\u0018.\u0018(\u000C), \u000A\u001D\u0018.\u0018(\u0012\u000B\u000F.\u000C()))));
				}
				else
				{
					u000C = Enumerable.ToList<Element>(Enumerable.Cast<Element>(\u0018));
				}
				int num = 0;
				int num2 = \u0012\u001A\u0014.\u0018(u000C);
				int num3;
				if (\u0012\u001A\u0014.\u0018(u000C) / 10 != 0)
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
					num3 = \u0012\u001A\u0014.\u0018(u000C) / 10;
				}
				else
				{
					num3 = 1;
				}
				int num4 = num3;
				List<Element>.Enumerator enumerator = \u000F\u001A\u0014.\u0018(u000C);
				try
				{
					while (\u0001\u001D\u0014.\u0018(ref enumerator))
					{
						Element u000C2 = \u0016\u001A\u0014.\u0018(ref enumerator);
						\u000C\u000A\u0018.\u0001\u0009\u0018 u0001_u0009_u = new \u000C\u000A\u0018.\u0001\u0009\u0018();
						if (\u000A\u001D\u0014.\u0018())
						{
							goto IL_250;
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
						if (num % num4 == 0)
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
							int u = num * 100 / num2;
							\u000C\u000A\u0018.\u0006\u0009\u0018 u000C3 = \u000C\u000A\u0018.\u000C;
							if (u000C3 == null)
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
							}
							else
							{
								\u0009\u001D\u0014.\u0018(u000C3, u);
							}
						}
						num++;
						View u000C4 = \u0018\u0002\u000F.\u000C(u000C2);
						u0001_u0009_u.\u000C = \u001A\u0003\u0014.\u0018(u000C4).\u000C();
						if (\u0003\u001A\u0014.\u0018(u000C4))
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
							if (\u0014\u001A\u0014.\u0018(\u0014, new Predicate<string>(u0001_u0009_u.\u0018)))
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
								SheetInfo sheetInfo = \u0012\u0004\u0014.\u0018();
								\u000F\u0004\u0014.\u0018(sheetInfo, \u0009\u0002\u0018.\u0018(u000C4));
								\u0002\u001D\u0014.\u0018(sheetInfo, \u0009\u0002\u0018.\u0018(u000C4).\u000C());
								\u0016\u0004\u0014.\u0018(sheetInfo, \u0001\u0017\u0018.\u0018(\u0009\u0002\u0018.\u0018(u000C4)));
								\u0003\u0004\u0014.\u0018(sheetInfo, \u001E\u0016\u0014.\u0018(u000C4));
								\u000C\u001A\u0014.\u0018(sheetInfo, \u000F\u0009\u0014.\u0018(\u0018\u001A\u0014.\u0018(u000C4)));
								\u000E\u001D\u0014.\u0018(sheetInfo, \u000C\u000A\u0018.\u000D(u000C4));
								string u2;
								if (\u001A\u0003\u0014.\u0018(u000C4) != 11)
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
									u2 = \u000F\u0009\u0014.\u0018(\u0005\u001D\u0014.\u0018(u000C4));
								}
								else
								{
									u2 = "NA";
								}
								\u001B\u001D\u0014.\u0018(sheetInfo, u2);
								\u0018\u0004\u0014.\u0018(sheetInfo, \u001A\u0003\u0014.\u0018(u000C4));
								SheetInfo u3 = sheetInfo;
								\u0007\u000E\u0018.\u0018(list, u3);
							}
						}
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				IL_250:
				IEnumerable<SheetInfo> enumerable = list;
				Func<SheetInfo, string> func;
				if ((func = \u000C\u000A\u0018.<>c.\u0003) == null)
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
					func = (\u000C\u000A\u0018.<>c.\u0003 = new Func<SheetInfo, string>(\u000C\u000A\u0018.<>c.\u000C.\u001F));
				}
				list = Enumerable.ToList<SheetInfo>(Enumerable.OrderBy<SheetInfo, string>(enumerable, func));
			}
			catch (Exception u4)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u4, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getViews");
			}
			return list;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001B33C File Offset: 0x0001953C
		public static string \u000D(View \u000C)
		{
			int num = \u0013\u001A\u0014.\u0018(\u000C);
			string result = \u0010\u001E\u0018.\u0018(ref num);
			Parameter parameter = \u0017\u001D\u0014.\u0018(\u000C, -1005151L);
			if (parameter != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u000D(View)).MethodHandle;
				}
				result = \u001C\u001A\u0014.\u0018(parameter);
			}
			return result;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0001B38C File Offset: 0x0001958C
		public static List<string> \u001C(List<View> \u000C)
		{
			List<string> list = \u0011\u0002\u0018.\u0018();
			List<ViewType> list2 = \u0017\u001A\u0014.\u0018();
			\u0015\u001A\u0014.\u0018(list2, 5);
			\u0015\u001A\u0014.\u0018(list2, 6);
			\u0015\u001A\u0014.\u0018(list2, 7);
			\u0015\u001A\u0014.\u0018(list2, 12);
			List<ViewType> u000C = list2;
			List<View>.Enumerator enumerator = \u0011\u001A\u0014.\u0018(\u000C);
			try
			{
				while (\u000A\u001A\u0014.\u0018(ref enumerator))
				{
					View u000C2 = \u001F\u001A\u0014.\u0018(ref enumerator);
					string u = \u001A\u0003\u0014.\u0018(u000C2).\u000C();
					if (\u0003\u001A\u0014.\u0018(u000C2))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u001C(List<View>)).MethodHandle;
						}
						if (!\u0007\u0017\u0014.\u0018(list, u))
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
							if (!\u0020\u001A\u0014.\u0018(u000C, \u001A\u0003\u0014.\u0018(u000C2)))
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
								\u0019\u0017\u0014.\u0018(list, u);
							}
						}
					}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0009\u001A\u0014.\u0018(list);
			return list;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0001B480 File Offset: 0x00019680
		private unsafe static void \u0013(Document \u000C, List<\u000C\u000A\u0018.\u0008\u0009\u0018> \u0018, bool \u0014, out string \u0003, out string \u0016)
		{
			\u0003 = "-";
			\u0016 = "-";
			Func<\u000C\u000A\u0018.\u0008\u0009\u0018, double> func;
			if ((func = \u000C\u000A\u0018.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0013(Document, List<\u000C\u000A\u0018.\u0008\u0009\u0018>, bool, string*, string*)).MethodHandle;
				}
				func = (\u000C\u000A\u0018.<>c.\u0016 = new Func<\u000C\u000A\u0018.\u0008\u0009\u0018, double>(\u000C\u000A\u0018.<>c.\u000C.\u0011));
			}
			IOrderedEnumerable<\u000C\u000A\u0018.\u0008\u0009\u0018> orderedEnumerable = Enumerable.OrderByDescending<\u000C\u000A\u0018.\u0008\u0009\u0018, double>(\u0018, func);
			Func<\u000C\u000A\u0018.\u0008\u0009\u0018, double> func2;
			if ((func2 = \u000C\u000A\u0018.<>c.\u000F) == null)
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
				func2 = (\u000C\u000A\u0018.<>c.\u000F = new Func<\u000C\u000A\u0018.\u0008\u0009\u0018, double>(\u000C\u000A\u0018.<>c.\u000C.\u0015));
			}
			\u000C\u000A\u0018.\u0008\u0009\u0018 u0008_u0009_u = Enumerable.FirstOrDefault<\u000C\u000A\u0018.\u0008\u0009\u0018>(Enumerable.ThenByDescending<\u000C\u000A\u0018.\u0008\u0009\u0018, double>(orderedEnumerable, func2));
			if (u0008_u0009_u != null)
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
				try
				{
					double u = u0008_u0009_u.\u0003;
					double u2 = u0008_u0009_u.\u0016;
					\u0003 = \u000C\u000A\u0018.\u000A(u, u2, \u0014, \u000C);
					\u0016 = \u000C\u000A\u0018.\u0009(u, u2);
				}
				catch (Exception)
				{
				}
			}
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0001B558 File Offset: 0x00019758
		private static string \u0009(double \u000C, double \u0018)
		{
			if (\u000C >= \u0018)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0009(double, double)).MethodHandle;
				}
				return "Landscape";
			}
			return "Portrait";
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0001B588 File Offset: 0x00019788
		public static string \u000A(double \u000C, double \u0018, bool \u0014, Document \u0003)
		{
			bool flag = \u000C < \u0018;
			double num = \u000C * 12.0;
			double num2 = \u0018 * 12.0;
			int num3 = \u0019\u001A\u0014.\u0018(\u0007\u001A\u0014.\u0018(num * 25.4, 2));
			int num4 = \u0019\u001A\u0014.\u0018(\u0007\u001A\u0014.\u0018(num2 * 25.4, 2));
			if (!\u0014)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u000A(double, double, bool, Document)).MethodHandle;
				}
				return \u0014\u001E\u0018.\u0018(\u0010\u001E\u0018.\u0018(ref num3), "x", \u0010\u001E\u0018.\u0018(ref num4));
			}
			string text = "";
			\u000B\u001A\u0014.\u0018();
			double u000C = num;
			double u000C2 = num2;
			\u001A\u001A\u0014.\u0018();
			List<PaperSize>.Enumerator enumerator = \u0010\u0002\u0014.\u0018(\u0006\u0002\u0014.\u0018());
			try
			{
				while (\u000B\u0002\u0014.\u0018(ref enumerator))
				{
					PaperSize u000C3 = \u0007\u0002\u0014.\u0018(ref enumerator);
					double u = (double)\u001D\u001A\u0014.\u0018(u000C3) / 100.0;
					double u2 = (double)\u0004\u001A\u0014.\u0018(u000C3) / 100.0;
					if (\u000C\u000A\u0018.\u0020(u000C, u))
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
						if (\u000C\u000A\u0018.\u0020(u000C2, u2))
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
							text = \u0019\u0002\u0014.\u0018(u000C3);
							goto IL_190;
						}
					}
					if (\u000C\u000A\u0018.\u0020(u000C, u2))
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
						if (\u000C\u000A\u0018.\u0020(u000C2, u))
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
							text = \u0019\u0002\u0014.\u0018(u000C3);
							goto IL_190;
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
				((IDisposable)enumerator).Dispose();
			}
			IL_190:
			if (\u000F\u0002\u0018.\u0018(text, ""))
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
				string text2 = \u001A\u001E\u0018.\u0018("{0}x{1}", num3, num4);
				try
				{
					\u000C\u000A\u0018.\u001B\u0009\u0018 u001B_u0009_u = new \u000C\u000A\u0018.\u001B\u0009\u0018();
					u001B_u0009_u.\u000C = \u000D\u001E\u0018.\u0018("PS_", text2);
					if (!flag)
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
						if (!\u000B\u0017\u0018.\u0018(\u0002\u001A\u0014.\u0018(), u001B_u0009_u.\u000C, (float)num4, (float)num3))
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
							return text2;
						}
					}
					else if (!\u000B\u0017\u0018.\u0018(\u0002\u001A\u0014.\u0018(), u001B_u0009_u.\u000C, (float)num3, (float)num4))
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
						return text2;
					}
					\u001E\u001A\u0014.\u0018(\u0020\u001F\u0018.\u0003());
					if (Enumerable.Any<PaperSize>(\u0006\u0002\u0014.\u0018(), new Func<PaperSize, bool>(u001B_u0009_u.\u0018)))
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
						text = u001B_u0009_u.\u000C;
					}
					else
					{
						text = text2;
					}
				}
				catch (Exception)
				{
					text = text2;
				}
				return text;
			}
			return text;
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0001B850 File Offset: 0x00019A50
		public static bool \u0020(double \u000C, double \u0018)
		{
			return \u0017\u001C\u0014.\u0018(\u000C - \u0018) <= 0.04;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0001B878 File Offset: 0x00019A78
		public static List<SelectionParameter> \u001F(List<ViewSheet> \u000C)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameterWithoutYesNO_ForSheets");
			List<SelectionParameter> list = \u0013\u000B\u0014.\u0018();
			if (\u0011\u001D\u0014.\u0018(\u000C) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u001F(List<ViewSheet>)).MethodHandle;
				}
				return list;
			}
			Dictionary<string, BuiltInParameter> u000C = \u001C\u000B\u0014.\u0018();
			BuiltInParameter[] array = \u000F\u000B\u000F.\u000C(20);
			\u0017\u001A\u0018.\u0018(array, fieldof(\u0009\u0017\u0018.\u000C).FieldHandle);
			BuiltInParameter[] array2 = array;
			ViewSheet u000C2 = \u000D\u000B\u0014.\u0018(\u000C, 0);
			try
			{
				IEnumerator u000C3 = \u000F\u000B\u0014.\u0018(\u0012\u000B\u0014.\u0018(u000C2));
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C3))
					{
						Parameter u000C4 = \u0003\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C3));
						BuiltInParameter builtInParameter = \u0016\u000B\u0014.\u0018(\u0016\u000B\u000F.\u000C(\u0018\u000B\u0014.\u0018(u000C4)));
						string u = \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C4));
						BuiltInParameter builtInParameter2;
						if (\u0014\u000B\u0014.\u0018(u000C, u, ref builtInParameter2))
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
							if (builtInParameter2 == builtInParameter)
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
							if (builtInParameter2 == -1L)
							{
								continue;
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
						if (!Enumerable.Contains<BuiltInParameter>(array2, builtInParameter))
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
							if (!\u0018\u000B\u0014.\u0018(u000C4).\u000C())
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
								if (\u001B\u0002\u0018.\u0018(u000C4) != null)
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
									\u000C\u000B\u0014.\u0018(u000C, u, builtInParameter);
									SelectionParameter selectionParameter = \u0006\u0018\u0014.\u0018();
									\u0019\u0018\u0014.\u0018(selectionParameter, SelectionParameterType.Revit);
									\u0007\u0018\u0014.\u0018(selectionParameter, u);
									\u000E\u001A\u0014.\u0018(selectionParameter, u);
									\u001B\u001A\u0014.\u0018(selectionParameter, \u0005\u001A\u0014.\u0018(u000C4).\u000C());
									\u0001\u001A\u0014.\u0018(selectionParameter, \u001B\u0002\u0018.\u0018(u000C4));
									\u0008\u001A\u0014.\u0018(selectionParameter, builtInParameter);
									SelectionParameter u2 = selectionParameter;
									\u0006\u001A\u0014.\u0018(list, u2);
								}
							}
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
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C3);
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
				object u000C5 = list;
				Comparison<SelectionParameter> u3;
				if ((u3 = \u000C\u000A\u0018.<>c.\u0012) == null)
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
					u3 = (\u000C\u000A\u0018.<>c.\u0012 = new Comparison<SelectionParameter>(\u000C\u000A\u0018.<>c.\u000C.\u0017));
				}
				\u0010\u001A\u0014.\u0018(u000C5, u3);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameterWithoutYesNO_ForSheets");
			}
			catch (Exception u4)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u4, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameterWithoutYesNO_ForSheets");
			}
			return list;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0001BAFC File Offset: 0x00019CFC
		public static List<SelectionParameter> \u0011(List<View> \u000C)
		{
			\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameterWithoutYesNO_ForViews");
			List<SelectionParameter> list = \u0013\u000B\u0014.\u0018();
			if (\u001E\u000B\u0014.\u0018(\u000C) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0011(List<View>)).MethodHandle;
				}
				return list;
			}
			List<View> list2 = \u000C\u001E\u0014.\u0018();
			List<ViewType> list3 = \u0017\u001A\u0014.\u0018();
			\u0015\u001A\u0014.\u0018(list3, 5);
			\u0015\u001A\u0014.\u0018(list3, 6);
			\u0015\u001A\u0014.\u0018(list3, 7);
			\u0015\u001A\u0014.\u0018(list3, 12);
			List<ViewType> u000C = list3;
			try
			{
				List<View>.Enumerator enumerator = \u0011\u001A\u0014.\u0018(\u000C);
				try
				{
					while (\u000A\u001A\u0014.\u0018(ref enumerator))
					{
						View view = \u001F\u001A\u0014.\u0018(ref enumerator);
						if (\u000A\u001D\u0014.\u0018())
						{
							goto IL_F2;
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
						if (\u0003\u001A\u0014.\u0018(view))
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
							if (!\u0020\u001A\u0014.\u0018(u000C, \u001A\u0003\u0014.\u0018(view)))
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
								\u0017\u000B\u0014.\u0018(list2, view);
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
				IL_F2:
				IEnumerable<View> enumerable = list2;
				Func<View, ViewType> func;
				if ((func = \u000C\u000A\u0018.<>c.\u000D) == null)
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
					func = (\u000C\u000A\u0018.<>c.\u000D = new Func<View, ViewType>(\u000C\u000A\u0018.<>c.\u000C.\u001E));
				}
				IEnumerable<IGrouping<ViewType, View>> enumerable2 = Enumerable.GroupBy<View, ViewType>(enumerable, func);
				Func<IGrouping<ViewType, View>, ViewType> func2;
				if ((func2 = \u000C\u000A\u0018.<>c.\u001C) == null)
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
					func2 = (\u000C\u000A\u0018.<>c.\u001C = new Func<IGrouping<ViewType, View>, ViewType>(\u000C\u000A\u0018.<>c.\u000C.\u0002));
				}
				Func<IGrouping<ViewType, View>, List<View>> func3;
				if ((func3 = \u000C\u000A\u0018.<>c.\u0013) == null)
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
					func3 = (\u000C\u000A\u0018.<>c.\u0013 = new Func<IGrouping<ViewType, View>, List<View>>(\u000C\u000A\u0018.<>c.\u000C.\u0004));
				}
				Dictionary<ViewType, List<View>>.Enumerator enumerator2 = \u0015\u000B\u0014.\u0018(Enumerable.ToDictionary<IGrouping<ViewType, View>, ViewType, List<View>>(enumerable2, func2, func3));
				try
				{
					while (\u0009\u000B\u0014.\u0018(ref enumerator2))
					{
						KeyValuePair<ViewType, List<View>> keyValuePair = \u0011\u000B\u0014.\u0018(ref enumerator2);
						IEnumerator u000C2 = \u000F\u000B\u0014.\u0018(\u0012\u000B\u0014.\u0018(\u0020\u000B\u0014.\u0018(\u001F\u000B\u0014.\u0018(ref keyValuePair), 0)));
						try
						{
							while (\u001F\u001E\u0018.\u0018(u000C2))
							{
								Parameter u000C3 = \u0003\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2));
								string u = \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C3));
								BuiltInParameter builtInParameter = \u0016\u000B\u0014.\u0018(\u0016\u000B\u000F.\u000C(\u0018\u000B\u0014.\u0018(u000C3)));
								bool flag = false;
								List<SelectionParameter>.Enumerator enumerator3 = \u001D\u0018\u0014.\u0018(list);
								try
								{
									while (\u0017\u0018\u0014.\u0018(ref enumerator3))
									{
										SelectionParameter u000C4 = \u0004\u0018\u0014.\u0018(ref enumerator3);
										if (\u000A\u000B\u0014.\u0014(u000C4) != -1L)
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
											if (\u000A\u000B\u0014.\u0014(u000C4) != builtInParameter)
											{
												continue;
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
											flag = true;
										}
										else
										{
											if (!\u000F\u0002\u0018.\u0018(\u0002\u0020\u0014.\u0014(u000C4), u))
											{
												continue;
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
											flag = true;
										}
										goto IL_28D;
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
									((IDisposable)enumerator3).Dispose();
								}
								IL_28D:
								if (!flag)
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
									if (!\u0018\u000B\u0014.\u0018(u000C3).\u000C())
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
										if (\u001B\u0002\u0018.\u0018(u000C3) != null)
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
											if (\u000C\u000A\u0018.\u0015(builtInParameter))
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
												SelectionParameter selectionParameter = \u0006\u0018\u0014.\u0018();
												\u0019\u0018\u0014.\u0018(selectionParameter, SelectionParameterType.Revit);
												\u0007\u0018\u0014.\u0018(selectionParameter, u);
												\u000E\u001A\u0014.\u0018(selectionParameter, u);
												\u001B\u001A\u0014.\u0018(selectionParameter, \u0005\u001A\u0014.\u0018(u000C3).\u000C());
												\u0001\u001A\u0014.\u0018(selectionParameter, \u001B\u0002\u0018.\u0018(u000C3));
												\u0008\u001A\u0014.\u0018(selectionParameter, builtInParameter);
												\u0006\u001A\u0014.\u0018(list, selectionParameter);
											}
										}
									}
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
							IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
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
								\u0020\u001E\u0018.\u0018(disposable);
							}
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
					((IDisposable)enumerator2).Dispose();
				}
				object u000C5 = list;
				Comparison<SelectionParameter> u2;
				if ((u2 = \u000C\u000A\u0018.<>c.\u0009) == null)
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
					u2 = (\u000C\u000A\u0018.<>c.\u0009 = new Comparison<SelectionParameter>(\u000C\u000A\u0018.<>c.\u000C.\u001D));
				}
				\u0010\u001A\u0014.\u0018(u000C5, u2);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameterWithoutYesNO_ForViews");
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameterWithoutYesNO_ForViews");
			}
			return list;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0001BF90 File Offset: 0x0001A190
		private static bool \u0015(BuiltInParameter \u000C)
		{
			if (\u000C != -1005147L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0015(BuiltInParameter)).MethodHandle;
				}
				if (\u000C != -1002052L)
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
					if (\u000C != -1140362L)
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
						if (\u000C != -1002051L)
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
							if (\u000C != -1139998L)
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
								if (\u000C != -1002002L)
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
									if (\u000C != -1002001L)
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
										if (\u000C != -1007419L)
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
											if (\u000C != -1140363L)
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
												if (\u000C != -1139999L)
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
													if (\u000C != -1002000L)
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
														if (\u000C != -1012109L)
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
															if (\u000C != -1139997L)
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
																if (\u000C != -1012106L)
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
																	if (\u000C != -1002050L)
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
																		if (\u000C != -1007409L)
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
																			if (\u000C != -1006602L)
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
																				if (\u000C != -1013201L)
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
																					if (\u000C != -1005150L)
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
																						if (\u000C != -1005158L)
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
																							if (\u000C != -1005177L)
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
																								if (\u000C != -1154613L)
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
																									if (\u000C != -1006601L)
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
																										if (\u000C != -1005207L)
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
																											if (\u000C != -1012202L)
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
																												if (\u000C != -1005254L)
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
																													if (\u000C != -1005153L)
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
																														if (\u000C != -1005335L)
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
																															if (\u000C != -1012103L)
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
																																if (\u000C != -1011003L)
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
																																	if (\u000C != -1005181L)
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
																																		if (\u000C != -1005148L)
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
																																			if (\u000C != -1005002L)
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
																																				if (\u000C != -1005110L)
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
																																					if (\u000C != -1005104L)
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
																																						if (\u000C != -1005000L)
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
																																							if (\u000C != -1005169L)
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
																																								if (\u000C != -1005120L)
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
																																									if (\u000C != -1006613L)
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
																																										if (\u000C != -1006614L)
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
																																											if (\u000C != -1006612L)
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
																																												if (\u000C != -1006609L)
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
																																													if (\u000C != -1007608L)
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
																																														if (\u000C != -1005183L)
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
																																															if (\u000C != -1005182L)
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
																																																if (\u000C != -1005123L)
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
																																																	if (\u000C != -1005050L)
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
																																																		if (\u000C != -1005161L)
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
																																																			if (\u000C != -1005332L)
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
																																																				if (\u000C != -1008203L)
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
																																																					return \u000C != -1005199L;
																																																				}
																																																			}
																																																		}
																																																	}
																																																}
																																															}
																																														}
																																													}
																																												}
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0001C3F4 File Offset: 0x0001A5F4
		public static List<string> \u0017(Document \u000C)
		{
			List<string> list = \u0011\u0002\u0018.\u0018();
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameter");
				List<ViewSheet> u = \u000C\u000A\u0018.\u0018;
				ViewSheet viewSheet;
				if (u == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0017(Document)).MethodHandle;
					}
					viewSheet = \u0014\u000B\u000F.\u000C;
				}
				else
				{
					viewSheet = Enumerable.FirstOrDefault<ViewSheet>(u);
				}
				ViewSheet viewSheet2 = viewSheet;
				if (viewSheet2 != null)
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
					IEnumerator u000C = \u000F\u000B\u0014.\u0018(\u0012\u000B\u0014.\u0018(viewSheet2));
					try
					{
						while (\u001F\u001E\u0018.\u0018(u000C))
						{
							Parameter u000C2 = \u0003\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
							string u2 = \u0003\u000B\u0014.\u0018(\u0018\u000B\u0014.\u0018(u000C2));
							if (!\u0007\u0017\u0014.\u0018(list, u2))
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
								if (\u001B\u0002\u0018.\u0018(u000C2) != null)
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
									BuiltInParameter builtInParameter = \u0016\u000B\u0014.\u0018(\u0016\u000B\u000F.\u000C(\u0018\u000B\u0014.\u0018(u000C2)));
									if (builtInParameter != -1005147L)
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
										if (builtInParameter != -1002052L)
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
											if (builtInParameter != -1140362L)
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
												if (builtInParameter != -1002051L)
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
													if (builtInParameter != -1005171L)
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
														if (builtInParameter != -1139998L)
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
															if (builtInParameter != -1002002L)
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
																if (builtInParameter != -1002001L)
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
																	if (builtInParameter != -1007419L)
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
																		if (builtInParameter != -1140363L)
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
																			if (builtInParameter != -1139999L)
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
																				if (builtInParameter != -1002000L)
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
																					if (builtInParameter != -1012109L)
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
																						if (builtInParameter != -1139997L)
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
																							if (builtInParameter != -1012106L)
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
																								if (builtInParameter != -1002050L)
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
																									if (builtInParameter != -1007409L)
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
																										if (builtInParameter != -1006602L)
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
																											if (builtInParameter != -1013201L)
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
																												if (builtInParameter != -1007409L)
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
																													if (builtInParameter != -1005170L)
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
																														if (builtInParameter != -1007400L)
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
																															if (builtInParameter != -1007401L)
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
																																if (builtInParameter != -1006601L)
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
																																	if (builtInParameter != -1002053L)
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
																																		\u0019\u0017\u0014.\u0018(list, u2);
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
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
						IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
						if (disposable != null)
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
							\u0020\u001E\u0018.\u0018(disposable);
						}
					}
				}
				\u0009\u001A\u0014.\u0018(list);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameter");
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "GetCustomParameter");
			}
			\u0002\u000B\u0014.\u0018(list, 0, "Orientation");
			return list;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x0001C7C4 File Offset: 0x0001A9C4
		public static string \u001E(long \u000C, string \u0018)
		{
			\u000C\u000A\u0018.\u0005\u0009\u0018 u0005_u0009_u = new \u000C\u000A\u0018.\u0005\u0009\u0018();
			u0005_u0009_u.\u000C = \u000C;
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheetParameterValue");
				ViewSheet viewSheet = \u0004\u000B\u0014.\u0018(\u000C\u000A\u0018.\u0018, new Predicate<ViewSheet>(u0005_u0009_u.\u0018));
				if (viewSheet != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u001E(long, string)).MethodHandle;
					}
					string result;
					if ((result = \u000C\u000A\u0018.\u001D(\u0005\u0002\u0018.\u0014(viewSheet, \u0018))) == null)
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
						result = "";
					}
					return result;
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheetParameterValue");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getSheetParameterValue");
			}
			return "";
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0001C890 File Offset: 0x0001AA90
		public static List<SheetInfo> \u0002(List<SheetInfo> \u000C, string \u0018)
		{
			List<SheetInfo> list = \u001D\u0017\u0014.\u0018();
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomParamValue");
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u000C);
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
						\u0007\u000B\u0014.\u0018(sheetInfo, \u000C\u000A\u0018.\u001E(\u0015\u0005\u0018.\u0014(sheetInfo).\u000C(), \u0018));
						if (\u0019\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), \u0018))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0002(List<SheetInfo>, string)).MethodHandle;
							}
							\u000B\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), \u0018, \u001A\u000B\u0014.\u0018(sheetInfo));
						}
						else
						{
							\u001D\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), \u0018, \u001A\u000B\u0014.\u0018(sheetInfo));
						}
						\u0007\u000E\u0018.\u0018(list, sheetInfo);
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
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomParamValue");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomParamValue");
			}
			return list;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0001C9C0 File Offset: 0x0001ABC0
		public static List<SheetInfo> \u0002(List<SheetInfo> \u000C, List<string> \u0018)
		{
			List<SheetInfo> list = \u001D\u0017\u0014.\u0018();
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomParamValue");
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u000C);
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
						List<string>.Enumerator enumerator2 = \u0008\u0015\u0014.\u0018(\u0018);
						try
						{
							while (\u0010\u0015\u0014.\u0018(ref enumerator2))
							{
								string text = \u0006\u0015\u0014.\u0018(ref enumerator2);
								if (\u000F\u0002\u0018.\u0018(text, "Orientation"))
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0002(List<SheetInfo>, List<string>)).MethodHandle;
									}
									\u0007\u000B\u0014.\u0018(sheetInfo, \u0011\u0017\u0014.\u0014(sheetInfo));
									if (\u0019\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), text))
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
										\u000B\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), text, \u001A\u000B\u0014.\u0018(sheetInfo));
									}
									else
									{
										\u001D\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), text, \u001A\u000B\u0014.\u0018(sheetInfo));
									}
								}
								else
								{
									\u0007\u000B\u0014.\u0018(sheetInfo, \u000C\u000A\u0018.\u001E(\u0015\u0005\u0018.\u0014(sheetInfo).\u000C(), text));
									if (\u0019\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), text))
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
										\u000B\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), text, \u001A\u000B\u0014.\u0018(sheetInfo));
									}
									else
									{
										\u001D\u000B\u0014.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo), text, \u001A\u000B\u0014.\u0018(sheetInfo));
									}
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
							((IDisposable)enumerator2).Dispose();
						}
						\u0007\u000E\u0018.\u0018(list, sheetInfo);
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
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomParamValue");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomParamValue");
			}
			return list;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0001CBE0 File Offset: 0x0001ADE0
		public static void \u0004(Document \u000C, ParameterBaseModel \u0018, ParameterBaseModel \u0014, bool \u0003 = false)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getCustomDrawingNumber");
				\u000C\u000A\u0018.\u0001(\u000C, false);
				\u000C\u000A\u0018.\u0001(\u000C, true);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getCustomDrawingNumber");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getCustomDrawingNumber");
			}
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0001CC54 File Offset: 0x0001AE54
		public static string \u001D(Document \u000C, SheetInfo \u0018, View \u0014, List<SelectionParameter> \u0003, string \u0016)
		{
			List<AbstractExpression> list = \u001C\u0019\u0014.\u0018();
			List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(\u0003);
			try
			{
				while (\u0017\u0018\u0014.\u0018(ref enumerator))
				{
					SelectionParameter selectionParameter = \u0004\u0018\u0014.\u0018(ref enumerator);
					switch (\u000B\u0020\u0014.\u0014(selectionParameter))
					{
					case SelectionParameterType.Revit:
					{
						object u000C = list;
						RevitParameterExpression revitParameterExpression = \u000D\u0019\u0014.\u0018();
						\u0012\u0019\u0014.\u0018(revitParameterExpression, \u000C);
						\u0014\u0019\u0014.\u0018(revitParameterExpression, selectionParameter);
						\u000F\u0019\u0014.\u0018(revitParameterExpression, \u0014);
						\u000C\u0019\u0014.\u0018(u000C, revitParameterExpression);
						break;
					}
					case SelectionParameterType.CustomText:
					{
						object u000C2 = list;
						SeparatorExpression separatorExpression = \u0016\u0019\u0014.\u0018();
						\u0014\u0019\u0014.\u0018(separatorExpression, selectionParameter);
						\u000C\u0019\u0014.\u0018(u000C2, separatorExpression);
						break;
					}
					case SelectionParameterType.CustemSeparator:
					{
						object u000C3 = list;
						SeparatorExpression separatorExpression2 = \u0016\u0019\u0014.\u0018();
						\u0014\u0019\u0014.\u0018(separatorExpression2, selectionParameter);
						\u000C\u0019\u0014.\u0018(u000C3, separatorExpression2);
						break;
					}
					case SelectionParameterType.Variable:
					{
						object u000C4 = list;
						VariableExpression variableExpression = \u0003\u0019\u0014.\u0018();
						\u0014\u0019\u0014.\u0018(variableExpression, selectionParameter);
						\u0018\u0019\u0014.\u0018(variableExpression, \u0018);
						\u000C\u0019\u0014.\u0018(u000C4, variableExpression);
						break;
					}
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u001D(Document, SheetInfo, View, List<SelectionParameter>, string)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			Context context = \u000E\u000B\u0014.\u0018();
			for (int i = 0; i < \u0008\u000B\u0014.\u0018(list); i++)
			{
				if (\u001B\u000B\u0014.\u0018(\u0005\u000B\u0014.\u0018(list, i), context))
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
					if (i < \u0008\u000B\u0014.\u0018(list) - 1)
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
						if (\u000B\u0020\u0014.\u0014(\u0001\u000B\u0014.\u0018(\u0003, i + 1)) != SelectionParameterType.CustemSeparator)
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
							\u0017\u0020\u0014.\u0018(\u001E\u0020\u0014.\u0018(context), \u0016);
						}
					}
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
			string text = \u0001\u0017\u0018.\u0018(\u001E\u0020\u0014.\u0018(context));
			char[] array = \u0008\u001A\u0018.\u0018();
			for (int j = 0; j < (int)\u0018\u000B\u000F.\u000C(array); j++)
			{
				char c = array[j];
				text = \u0010\u000B\u0014.\u0018(text, \u0006\u000B\u0014.\u0018(ref c), "");
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
			return text;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0001CE48 File Offset: 0x0001B048
		public static string \u001A(Document \u000C, SheetInfo \u0018, View \u0014)
		{
			string result = string.Empty;
			try
			{
				if (\u0009\u0019\u0014.\u0018() == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u001A(Document, SheetInfo, View)).MethodHandle;
					}
					return string.Empty;
				}
				Parameters parameters;
				if (\u000E\u001A\u000F.\u000C(\u0014) == null)
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
					parameters = \u000A\u0019\u0014.\u0018();
				}
				else
				{
					parameters = \u0009\u0019\u0014.\u0018();
				}
				Parameters parameters2 = parameters;
				if (parameters2 == null)
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
					return string.Empty;
				}
				result = \u000C\u000A\u0018.\u000B(\u0013\u0019\u0014.\u0018(parameters2), \u0014, \u0018);
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "getParameterValue");
			}
			return result;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0001CEF8 File Offset: 0x0001B0F8
		public static string \u000B(List<ParameterModel> \u000C, View \u0018, SheetInfo \u0014 = null)
		{
			StringBuilder u000C = \u0005\u0017\u0018.\u0018();
			int num = 0;
			List<ParameterModel>.Enumerator enumerator = \u0019\u0019\u0014.\u0018(\u000C);
			try
			{
				while (\u0020\u0019\u0014.\u0018(ref enumerator))
				{
					ParameterModel parameterModel = \u000B\u0019\u0014.\u0018(ref enumerator);
					StringBuilder stringBuilder = \u0005\u0017\u0018.\u0018();
					\u0017\u0020\u0014.\u0018(stringBuilder, \u001A\u0019\u0014.\u0018(parameterModel));
					if (\u001D\u0019\u0014.\u0018(parameterModel))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u000B(List<ParameterModel>, View, SheetInfo)).MethodHandle;
						}
						string u = string.Empty;
						if (\u001B\u0013\u0018.\u0018(\u0004\u0019\u0014.\u0014(parameterModel), "%sheetsize%", true))
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
							if (!\u001F\u001A\u0018.\u0018(\u0010\u0020\u0014.\u0014(\u0014)))
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
								if (!\u0014.\u0003())
								{
									goto IL_F3;
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
							string text;
							if (!\u001F\u001A\u0018.\u0018(\u0019\u0020\u0014.\u0018(\u0014)))
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
								text = \u0019\u0020\u0014.\u0018(\u0014);
							}
							else
							{
								text = "{{Sheet Size}}";
							}
							u = text;
						}
						else
						{
							u = \u0018\u001F\u0018.\u0018(\u0004\u0019\u0014.\u0014(parameterModel));
						}
						IL_F3:
						\u0017\u0020\u0014.\u0018(stringBuilder, u);
					}
					else
					{
						\u0017\u0020\u0014.\u0018(stringBuilder, \u000C\u000A\u0018.\u001D(\u0018, parameterModel));
					}
					\u0017\u0020\u0014.\u0018(stringBuilder, \u0002\u0019\u0014.\u0018(parameterModel));
					if (num > 0)
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
						if (\u001E\u0019\u0014.\u0018(stringBuilder) > 0)
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
							\u0011\u0019\u0014.\u0018(stringBuilder, 0, \u0015\u0019\u0014.\u0018(\u0017\u0019\u0014.\u0018(\u000C, num - 1)));
						}
					}
					\u001F\u0019\u0014.\u0018(u000C, stringBuilder);
					num++;
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
				((IDisposable)enumerator).Dispose();
			}
			return \u000C\u000A\u0018.\u0019(\u0001\u0017\u0018.\u0018(u000C));
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x0001D0D0 File Offset: 0x0001B2D0
		private static string \u0019(string \u000C)
		{
			char[] array = \u0008\u001A\u0018.\u0018();
			for (int i = 0; i < (int)\u0018\u000B\u000F.\u000C(array); i++)
			{
				char c = array[i];
				\u000C = \u0010\u000B\u0014.\u0018(\u000C, \u0006\u000B\u0014.\u0018(ref c), "-");
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0019(string)).MethodHandle;
			}
			return \u000C;
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x0001D12C File Offset: 0x0001B32C
		private static string \u001D(View \u000C, ParameterModel \u0018)
		{
			return \u000C\u000A\u0018.\u001D(\u000C\u000A\u0018.\u0007(\u000C, \u0018));
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0001D14C File Offset: 0x0001B34C
		private static string \u001D(Parameter \u000C)
		{
			string text = string.Empty;
			if (\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u001D(Parameter)).MethodHandle;
				}
				return text;
			}
			if (\u001B\u0002\u0018.\u0018(\u000C) == 3)
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
				text = \u0001\u0002\u0018.\u0018(\u000C);
			}
			else
			{
				if (\u001B\u0002\u0018.\u0018(\u000C) == 4)
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
					Document u = \u0007\u0015\u0018.\u0003;
					ElementId elementId = \u0007\u0019\u0014.\u0018(\u000C);
					if (elementId.\u000C() == \u0018\u001D\u0018.\u0018().\u000C())
					{
						goto IL_D5;
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
					try
					{
						Element element = \u0003\u0004\u0018.\u0018(u, elementId);
						string text2;
						if (element == null)
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
							text2 = null;
						}
						else
						{
							text2 = \u001E\u0016\u0014.\u0018(element);
						}
						string text3;
						if ((text3 = text2) == null)
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
							text3 = string.Empty;
						}
						text = text3;
						goto IL_D5;
					}
					catch (Exception)
					{
						text = "";
						goto IL_D5;
					}
				}
				text = \u001C\u001A\u0014.\u0018(\u000C);
			}
			IL_D5:
			string result;
			if ((result = text) == null)
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
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0001D254 File Offset: 0x0001B454
		private static Parameter \u0007(View \u000C, ParameterModel \u0018)
		{
			bool u = \u0006\u0019\u0014.\u0018(\u0018);
			if (\u0010\u0019\u0014.\u0018(\u0018) >= 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0007(View, ParameterModel)).MethodHandle;
				}
				return \u000C\u000A\u0018.\u0006(\u000C, \u0004\u0019\u0014.\u0014(\u0018), u);
			}
			return \u000C\u000A\u0018.\u0010(\u000C, \u0010\u0019\u0014.\u0018(\u0018), u);
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0001D2AC File Offset: 0x0001B4AC
		internal static string \u001D(View \u000C, long \u0018, string \u0014, bool \u0003 = false)
		{
			return \u000C\u000A\u0018.\u001D(\u000C\u000A\u0018.\u0007(\u000C, \u0018, \u0014, \u0003));
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0001D2CC File Offset: 0x0001B4CC
		private static Parameter \u0007(View \u000C, long \u0018, string \u0014, bool \u0003)
		{
			if (\u0018 >= 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0007(View, long, string, bool)).MethodHandle;
				}
				return \u000C\u000A\u0018.\u0006(\u000C, \u0014, \u0003);
			}
			return \u000C\u000A\u0018.\u0010(\u000C, \u0018, \u0003);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001D308 File Offset: 0x0001B508
		private static Parameter \u0010(View \u000C, long \u0018, bool \u0014)
		{
			if (\u0014)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0010(View, long, bool)).MethodHandle;
				}
				return \u0017\u001D\u0014.\u0018(\u000E\u0002\u0018.\u0018(\u0007\u0015\u0018.\u0003), \u0018);
			}
			return \u0017\u001D\u0014.\u0018(\u000C, \u0018);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001D34C File Offset: 0x0001B54C
		private static Parameter \u0006(View \u000C, string \u0018, bool \u0014)
		{
			if (\u0014)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0006(View, string, bool)).MethodHandle;
				}
				return \u0005\u0002\u0018.\u0014(\u000E\u0002\u0018.\u0018(\u0007\u0015\u0018.\u0003), \u0018);
			}
			return \u0005\u0002\u0018.\u0014(\u000C, \u0018);
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0001D390 File Offset: 0x0001B590
		public static string \u0008(Document \u000C, View \u0018, BuiltInParameter \u0014, bool \u0003 = false)
		{
			string text = \u000C\u000A\u0018.\u001D(\u0017\u001D\u0014.\u0018(\u0018, \u0014));
			if (\u0003)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0008(Document, View, BuiltInParameter, bool)).MethodHandle;
				}
				return text;
			}
			string u = \u0014\u001E\u0018.\u0018("[", \u001B\u0019\u0014.\u0018(\u0003\u000B\u0018.\u0018(\u0008\u001A\u0018.\u0018())), "]");
			object u000C = \u0010\u000B\u0014.\u0018(\u0001\u0019\u0014.\u0018(text, u, "-"), "  ", " ");
			char[] array = \u0020\u0002\u000F.\u000C(1);
			array[0] = ' ';
			return \u0008\u0019\u0014.\u0018(u000C, array);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0001D424 File Offset: 0x0001B624
		internal static string \u0008(Document \u000C, string \u0018)
		{
			IEnumerator u000C = \u000C\u0007\u0014.\u0018(\u0018\u0007\u0014.\u0018(\u0018, "%[^%]+%"));
			try
			{
				while (\u001F\u001E\u0018.\u0018(u000C))
				{
					Match u000C2 = \u000C\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
					string text = \u0010\u000B\u0014.\u0018(\u0005\u0019\u0014.\u0018(u000C2), "%", "");
					string u000C3 = \u0015\u000C\u0014.\u0018(text);
					Parameter parameter = \u0005\u001A\u000F.\u000C;
					if (!\u000E\u0019\u0014.\u0018(u000C3, "vs-"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0008(Document, string)).MethodHandle;
						}
						if (!\u000E\u0019\u0014.\u0018(u000C3, "v-"))
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
							parameter = \u0005\u0002\u0018.\u0014(\u000E\u0002\u0018.\u0018(\u000C), text);
						}
					}
					string u000C4 = string.Empty;
					if (parameter != null)
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
						u000C4 = \u000C\u000A\u0018.\u001D(parameter);
					}
					\u0018 = \u0010\u000B\u0014.\u0018(\u0018, \u0005\u0019\u0014.\u0018(u000C2), \u000C\u000A\u0018.\u0019(u000C4));
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
			finally
			{
				IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
				if (disposable != null)
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
					\u0020\u001E\u0018.\u0018(disposable);
				}
			}
			return \u0018;
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001D55C File Offset: 0x0001B75C
		public static string \u0008(Document \u000C, View \u0018, string \u0014)
		{
			Parameter parameter = \u0005\u001A\u000F.\u000C;
			string u000C = \u0015\u000C\u0014.\u0018(\u0014);
			if (\u000E\u0019\u0014.\u0018(u000C, "pp-"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0008(Document, View, string)).MethodHandle;
				}
				\u0014 = \u0010\u000B\u0014.\u0018(\u0014, "pp-", "");
				parameter = \u0005\u0002\u0018.\u0014(\u000E\u0002\u0018.\u0018(\u000C), \u0014);
			}
			else
			{
				if (\u000E\u0019\u0014.\u0018(u000C, "vs-"))
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
					if (\u000E\u001A\u000F.\u000C(\u0018) != null)
					{
						goto IL_A3;
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
				if (\u000E\u0019\u0014.\u0018(u000C, "v-"))
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
				}
				else
				{
					Parameter parameter2;
					if (\u0018 == null)
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
						parameter2 = \u0005\u001A\u000F.\u000C;
					}
					else
					{
						parameter2 = \u0005\u0002\u0018.\u0003(\u0018, \u0014);
					}
					parameter = parameter2;
					if (parameter == null)
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
						parameter = \u0005\u0002\u0018.\u0014(\u000E\u0002\u0018.\u0018(\u000C), \u0014);
						goto IL_126;
					}
					goto IL_126;
				}
				IL_A3:
				\u0014 = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0014, "vs-", ""), "v-", "");
				Parameter parameter3;
				if (\u0018 == null)
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
					parameter3 = \u0005\u001A\u000F.\u000C;
				}
				else
				{
					parameter3 = \u0005\u0002\u0018.\u0003(\u0018, \u0014);
				}
				parameter = parameter3;
			}
			IL_126:
			return \u000C\u000A\u0018.\u0019(\u000C\u000A\u0018.\u001D(parameter));
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0001D6A0 File Offset: 0x0001B8A0
		public static void \u0001(Document \u000C, bool \u0018)
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomDrawingNumber");
				object u000C;
				if (!\u0018)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u000A\u0018.\u0001(Document, bool)).MethodHandle;
					}
					u000C = \u0003\u0007\u0014.\u0018();
				}
				else
				{
					u000C = \u0014\u0007\u0014.\u0018();
				}
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(u000C);
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
						View u = \u001D\u001A\u000F.\u000C(\u0003\u0004\u0018.\u0018(\u000C, \u0015\u0005\u0018.\u0014(sheetInfo)));
						\u0001\u0002\u0014.\u0018(sheetInfo, \u000C\u000A\u0018.\u001A(\u000C, sheetInfo, u));
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
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomDrawingNumber");
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ReadProjectFile.cs", "setCustomDrawingNumber");
			}
		}

		// Token: 0x040001DE RID: 478
		private static List<ViewSheet> \u0018;

		// Token: 0x0200017E RID: 382
		// (Invoke) Token: 0x060010CC RID: 4300
		public delegate void \u0006\u0009\u0018(int percent);

		// Token: 0x0200017F RID: 383
		public class \u0008\u0009\u0018
		{
			// Token: 0x040007B4 RID: 1972
			public long \u000C;

			// Token: 0x040007B5 RID: 1973
			public int \u0018;

			// Token: 0x040007B6 RID: 1974
			public FamilyInstance \u0014;

			// Token: 0x040007B7 RID: 1975
			public double \u0003 = -1.0;

			// Token: 0x040007B8 RID: 1976
			public double \u0016 = -1.0;
		}

		// Token: 0x02000181 RID: 385
		[CompilerGenerated]
		private sealed class \u0001\u0009\u0018
		{
			// Token: 0x060010DD RID: 4317 RVA: 0x0005AE34 File Offset: 0x00059034
			internal bool \u0018(string \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000C, this.\u000C);
			}

			// Token: 0x040007C4 RID: 1988
			public string \u000C;
		}

		// Token: 0x02000182 RID: 386
		[CompilerGenerated]
		private sealed class \u001B\u0009\u0018
		{
			// Token: 0x060010DF RID: 4319 RVA: 0x0005AE64 File Offset: 0x00059064
			internal bool \u0018(PaperSize \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u0019\u0002\u0014.\u0018(\u000C), this.\u000C, true);
			}

			// Token: 0x040007C5 RID: 1989
			public string \u000C;
		}

		// Token: 0x02000183 RID: 387
		[CompilerGenerated]
		private sealed class \u0005\u0009\u0018
		{
			// Token: 0x060010E1 RID: 4321 RVA: 0x0005AE9C File Offset: 0x0005909C
			internal bool \u0018(ViewSheet \u000C)
			{
				return \u0009\u0002\u0018.\u0018(\u000C).\u000C() == this.\u000C;
			}

			// Token: 0x040007C6 RID: 1990
			public long \u000C;
		}

		// Token: 0x02000184 RID: 388
		[CompilerGenerated]
		private sealed class \u000E\u0009\u0018
		{
			// Token: 0x060010E3 RID: 4323 RVA: 0x0005AED4 File Offset: 0x000590D4
			internal bool \u0018(\u000C\u000A\u0018.\u0008\u0009\u0018 \u000C)
			{
				return \u000C.\u000C == \u0015\u0005\u0018.\u0014(this.\u000C).\u000C();
			}

			// Token: 0x040007C7 RID: 1991
			public SheetInfo \u000C;
		}
	}
}
