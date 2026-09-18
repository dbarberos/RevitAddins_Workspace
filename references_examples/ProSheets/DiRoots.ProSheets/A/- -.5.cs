using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Autodesk.Revit.DB;
using DiRoots.One.Commons;
using ProSheets;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.Model;

namespace A
{
	// Token: 0x020000B9 RID: 185
	internal static class \u001D\u0020\u0018
	{
		// Token: 0x06000A5A RID: 2650 RVA: 0x0003EB8C File Offset: 0x0003CD8C
		public static void \u000C()
		{
			string u000C = \u0003\u001A\u0018.\u0018(\u001D\u0020\u0018.\u0018(), "TimerQueue");
			if (!\u0012\u0006\u0018.\u0018(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u000C()).MethodHandle;
				}
				\u000F\u0006\u0018.\u0018(u000C);
			}
			string u000C2 = \u001B\u0020\u0018.\u0012(\u0007\u0015\u0018.\u0003, true);
			string text = \u0003\u001A\u0018.\u0018(u000C, \u000D\u001E\u0018.\u0018(u000C2, ".xml"));
			bool flag = \u001F\u001A\u0018.\u0018(u000C2);
			if (!\u000C\u001A\u0018.\u0018(text))
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
				if (flag)
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
					u000C2 = \u001D\u001B\u0018.\u0018().ToString();
				}
				text = \u0003\u001A\u0018.\u0018(u000C, \u000D\u001E\u0018.\u0018(u000C2, ".xml"));
			}
			XMLUtility.SerialiseInfo<SchedulerTimer>(\u001F\u0018\u0003.\u0018(), text);
			if (flag)
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
				\u0012\u0017\u0018 u = new \u0012\u0017\u0018(u000C2, true);
				\u0019\u0014\u0014.\u0018(\u0007\u0014\u0014.\u0018(), u);
				\u001A\u0014\u0014.\u0018(\u000B\u0014\u0014.\u0018());
			}
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0003EC98 File Offset: 0x0003CE98
		public static string \u0018()
		{
			return \u0008\u001E\u0014.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "DiRoots", "ProSheets", "Scheduler");
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0003ECC4 File Offset: 0x0003CEC4
		internal static string \u0014()
		{
			return \u0003\u001A\u0018.\u0018(\u001D\u0020\u0018.\u0018(), "TimerQueue");
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x0003ECE4 File Offset: 0x0003CEE4
		public static SchedulerTimer \u0003(Document \u000C)
		{
			string u000C = \u0003\u001A\u0018.\u0018(\u001D\u0020\u0018.\u0018(), "TimerQueue");
			string u000C2 = \u001B\u0020\u0018.\u0012(\u000C, true);
			string text = \u0003\u001A\u0018.\u0018(u000C, \u000D\u001E\u0018.\u0018(u000C2, ".xml"));
			if (!\u000C\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u0003(Document)).MethodHandle;
				}
				return null;
			}
			return XMLUtility.DeserialiseInfo<SchedulerTimer>(text);
		}

		// Token: 0x06000A5E RID: 2654 RVA: 0x0003ED4C File Offset: 0x0003CF4C
		public static ProSheetCurrentData \u0016(string \u000C)
		{
			string text = \u0003\u001A\u0018.\u0018(\u001D\u0020\u0018.\u0018(), \u000D\u001E\u0018.\u0018(\u000C, ".xml"));
			if (!\u000C\u001A\u0018.\u0018(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u0016(string)).MethodHandle;
				}
				return null;
			}
			ProSheetCurrentData proSheetCurrentData = XMLUtility.DeserialiseInfo<ProSheetCurrentData>(text);
			object u000C = \u001C\u0003\u0016.\u0018(proSheetCurrentData);
			Action<SheetInfo> u;
			if ((u = \u001D\u0020\u0018.<>c.\u0018) == null)
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
				u = (\u001D\u0020\u0018.<>c.\u0018 = new Action<SheetInfo>(\u001D\u0020\u0018.<>c.\u000C.\u000F));
			}
			\u0020\u0005\u0018.\u0018(u000C, u);
			return proSheetCurrentData;
		}

		// Token: 0x06000A5F RID: 2655 RVA: 0x0003EDD4 File Offset: 0x0003CFD4
		internal static void \u000F(ProSheetCurrentData \u000C, ExportTemPlateInfo \u0018)
		{
			\u0001\u001F\u0003.\u0018(\u0011\u0002\u0018.\u0018());
			\u001F\u0013\u0003.\u0018(\u001C\u0003\u0016.\u0018(\u000C));
			object u000C = \u001C\u0017\u0014.\u0018();
			Action<SheetInfo> u;
			if ((u = \u001D\u0020\u0018.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u000F(ProSheetCurrentData, ExportTemPlateInfo)).MethodHandle;
				}
				u = (\u001D\u0020\u0018.<>c.\u0014 = new Action<SheetInfo>(\u001D\u0020\u0018.<>c.\u000C.\u0012));
			}
			\u0020\u0005\u0018.\u0018(u000C, u);
			List<SheetInfo> list = \u001D\u0017\u0014.\u0018();
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo sheetInfo = \u000C\u000C\u0014.\u0018(ref enumerator);
					if (!\u000F\u0002\u0018.\u0018(\u0004\u0017\u0014.\u0018(sheetInfo), ""))
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
						if (!\u000F\u0002\u0018.\u0018(\u0011\u0017\u0014.\u0014(sheetInfo), ""))
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
					\u0007\u000E\u0018.\u0018(list, sheetInfo);
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
			object u000C2 = list;
			Action<SheetInfo> u2;
			if ((u2 = \u001D\u0020\u0018.<>c.\u0003) == null)
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
				u2 = (\u001D\u0020\u0018.<>c.\u0003 = new Action<SheetInfo>(\u001D\u0020\u0018.<>c.\u000C.\u000D));
			}
			\u0020\u0005\u0018.\u0018(u000C2, u2);
			if (\u001F\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "PDF");
				\u001D\u0020\u0018.\u000D(\u0018, \u000F\u000C\u0003.\u0018(\u001C\u0003\u0016.\u0018(\u000C), 0));
			}
			if (\u0009\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DWF");
				\u001D\u0020\u0018.\u0020(\u0018);
			}
			if (\u0020\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DWG");
				\u001D\u0020\u0018.\u0012(\u0018);
			}
			if (\u0013\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "NWC");
				\u001D\u0020\u0018.\u0009(\u0018);
			}
			if (\u000D\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "Image");
				\u001D\u0020\u0018.\u0013(\u0018);
			}
			if (\u000A\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DGN");
				\u001D\u0020\u0018.\u000A(\u0018);
			}
			if (\u001C\u0011\u0003.\u0018(\u0018))
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
				\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "IFC");
				\u001D\u0020\u0018.\u001C(\u0018);
			}
		}

		// Token: 0x06000A60 RID: 2656 RVA: 0x0003F044 File Offset: 0x0003D244
		private static void \u0012(ExportTemPlateInfo \u000C)
		{
			\u0015\u001F\u0003.\u0018(\u000A\u001F\u0003.\u0018(\u000C));
			\u0002\u001F\u0003.\u0018(\u0009\u001F\u0003.\u0018(\u000C));
			\u001E\u001F\u0003.\u0018(\u000D\u001F\u0003.\u0018(\u000C));
			\u0017\u001F\u0003.\u0018(\u0012\u001F\u0003.\u0018(\u000C));
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0003F088 File Offset: 0x0003D288
		private static void \u000D(ExportTemPlateInfo \u000C, SheetInfo \u0018)
		{
			\u0004\u0010\u0003.\u0018(!\u0018\u0007\u0003.\u0018(\u000C));
			if (\u000F\u0002\u0018.\u0018(\u001D\u0007\u0003.\u0018(\u000C), "No Margin"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u000D(ExportTemPlateInfo, SheetInfo)).MethodHandle;
				}
				\u0014\u0006\u0003.\u0018(0);
			}
			else if (\u000F\u0002\u0018.\u0018(\u001D\u0007\u0003.\u0018(\u000C), "Printer Limit"))
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
				\u0014\u0006\u0003.\u0018(1);
			}
			else if (\u000F\u0002\u0018.\u0018(\u001D\u0007\u0003.\u0018(\u000C), "User Defined"))
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
				\u0014\u0006\u0003.\u0018(2);
			}
			\u0018\u0006\u0003.\u0018(\u001D\u0020\u0018.\u0011(\u0004\u0007\u0003.\u0018(\u000C)));
			\u000C\u0006\u0003.\u0018(\u001D\u0020\u0018.\u0011(\u0002\u0007\u0003.\u0018(\u000C)));
			\u0005\u0010\u0003.\u0018(\u0017\u0007\u0003.\u0018(\u000C));
			\u000E\u0010\u0003.\u0018(1);
			if (\u001E\u0007\u0003.\u0018(\u000C))
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
				\u000E\u0010\u0003.\u0018(0);
			}
			\u0003\u0006\u0003.\u0018(1);
			if (\u001A\u0007\u0003.\u0018(\u000C))
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
				\u0003\u0006\u0003.\u0018(0);
			}
			\u0001\u0010\u0003.\u0018(\u0011\u0007\u0003.\u0018(\u000C));
			if (\u000F\u0002\u0018.\u0018(\u001F\u0007\u0003.\u0018(\u000C), "Color"))
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
				\u0008\u0010\u0003.\u0018(2);
			}
			else if (\u000F\u0002\u0018.\u0018(\u001F\u0007\u0003.\u0018(\u000C), "Gray Scale"))
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
				\u0008\u0010\u0003.\u0018(1);
			}
			else if (\u000F\u0002\u0018.\u0018(\u001F\u0007\u0003.\u0018(\u000C), "Black Line"))
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
				\u0008\u0010\u0003.\u0018(0);
			}
			\u0007\u0007\u0003.\u0018(\u000F\u0007\u0003.\u0018(\u000C));
			\u0010\u0010\u0003.\u0018(\u000A\u0007\u0003.\u0018(\u000C));
			\u0007\u0010\u0003.\u0018(\u0009\u0007\u0003.\u0018(\u000C));
			\u0019\u0010\u0003.\u0018(\u0013\u0007\u0003.\u0018(\u000C));
			\u000B\u0010\u0003.\u0018(\u001C\u0007\u0003.\u0018(\u000C));
			\u001A\u0010\u0003.\u0018(\u000D\u0007\u0003.\u0018(\u000C));
			\u0006\u0010\u0003.\u0018(\u0020\u0007\u0003.\u0018(\u000C));
			\u0010\u0007\u0003.\u0018(\u0012\u0007\u0003.\u0018(\u000C));
			\u001C\u0006\u0003.\u0018(\u0004\u0012\u0016.\u0018(\u000C));
			\u001D\u0010\u0003.\u0018(\u0016\u0007\u0003.\u0018(\u000C));
			\u001B\u0010\u0003.\u0018(1);
			if (\u0015\u0007\u0003.\u0018(\u000C))
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
				\u001B\u0010\u0003.\u0018(0);
			}
			\u0005\u0006\u0003.\u0018(\u0008\u0020\u0018.\u000C(\u000B\u0007\u0003.\u0018(\u000C), \u0014\u0007\u0003.\u0018(\u000C), \u0003\u0007\u0003.\u0018(\u000C)));
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0003F2E4 File Offset: 0x0003D4E4
		private static void \u001C(ExportTemPlateInfo \u000C)
		{
			\u0012\u0004\u0003.\u0018(\u0001\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u000F\u0004\u0003.\u0018(\u0008\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001A\u0012\u0016.\u0018(\u000B\u0012\u0016.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u000B\u0004\u0003.\u0018(\u001E\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0018\u0004\u0003.\u0018(\u0019\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0014\u0004\u0003.\u0018(\u0007\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0008\u0002\u0003.\u0018(\u0017\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0003\u0004\u0003.\u0018(\u0010\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001A\u0004\u0003.\u0018(\u0017\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0017\u0004\u0003.\u0018(\u000A\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0010\u0002\u0003.\u0018(\u0013\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001E\u0004\u0003.\u0018(\u0020\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0002\u0004\u0003.\u0018(\u001F\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001D\u0004\u0003.\u0018(\u0015\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0011\u0004\u0003.\u0018(\u001C\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0020\u0004\u0003.\u0018(\u0012\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0013\u0004\u0003.\u0018(\u0003\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001C\u0004\u0003.\u0018(\u0014\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			string u000C;
			if (\u0018\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u001C(ExportTemPlateInfo)).MethodHandle;
				}
				u000C = string.Empty;
			}
			else
			{
				u000C = \u0018\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C));
			}
			\u000D\u0004\u0003.\u0018(u000C);
			\u000A\u0004\u0003.\u0018(\u000F\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			string u000C2;
			if (\u0016\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)) == null)
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
				u000C2 = string.Empty;
			}
			else
			{
				u000C2 = \u0016\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C));
			}
			\u0009\u0004\u0003.\u0018(u000C2);
			\u000E\u0002\u0003.\u0018(\u001D\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0015\u0004\u0003.\u0018(\u0009\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001F\u0004\u0003.\u0018(\u000D\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001B\u0002\u0003.\u0018(\u0002\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0005\u0002\u0003.\u0018(\u0004\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0016\u0004\u0003.\u0018(\u0006\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u000C\u0004\u0003.\u0018(\u000B\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0004\u0004\u0003.\u0018(\u0011\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0001\u0002\u0003.\u0018(\u001E\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0006\u0002\u0003.\u0018(\u0015\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u001D\u0012\u0016.\u0018(\u001A\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0007\u0002\u0003.\u0018(\u000C\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u0019\u0002\u0003.\u0018(\u000E\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
			\u000B\u0002\u0003.\u0018(\u0005\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(\u000C)));
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0003F5FC File Offset: 0x0003D7FC
		private static void \u0013(ExportTemPlateInfo \u000C)
		{
			\u0004\u001A\u0003.\u0018(\u000C\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u0002\u001A\u0003.\u0018(\u0005\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u0019\u001A\u0003.\u0018(\u0014\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u001E\u001A\u0003.\u0018(\u0007\u0012\u0016.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u001D\u001A\u0003.\u0018(\u001B\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u0007\u001A\u0003.\u0018(\u0001\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u0017\u001A\u0003.\u0018(\u0019\u0012\u0016.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u001A\u001A\u0003.\u0018(\u0006\u001A\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
			\u000B\u001A\u0003.\u0018(\u0018\u000B\u0003.\u0018(\u0008\u001A\u0003.\u0018(\u000C)));
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x0003F6C0 File Offset: 0x0003D8C0
		private static void \u0009(ExportTemPlateInfo \u000C)
		{
			\u001B\u0019\u0003.\u0018(\u0018\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0001\u0019\u0003.\u0018(\u000C\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0008\u0019\u0003.\u0018(\u000E\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0006\u0019\u0003.\u0018(\u0005\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0010\u0019\u0003.\u0018(\u001B\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0007\u0019\u0003.\u0018(\u0001\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0019\u0019\u0003.\u0018(\u0008\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u000B\u0019\u0003.\u0018(\u0006\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u001A\u0019\u0003.\u0018(\u0010\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u001D\u0019\u0003.\u0018(\u0007\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0004\u0019\u0003.\u0018(\u0019\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0002\u0019\u0003.\u0018(\u000B\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u001E\u0019\u0003.\u0018(\u001A\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
			\u0017\u0019\u0003.\u0018(\u0004\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(\u000C)));
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x0003F7E8 File Offset: 0x0003D9E8
		private static void \u000A(ExportTemPlateInfo \u000C)
		{
			\u0008\u0013\u0003.\u0018(\u0007\u0013\u0003.\u0018(\u000C));
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0003F804 File Offset: 0x0003DA04
		private static void \u0020(ExportTemPlateInfo \u000C)
		{
			\u0006\u0020\u0003.\u0018(\u0016\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0010\u0020\u0003.\u0018(\u0003\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0007\u0020\u0003.\u0018(\u0005\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0019\u0020\u0003.\u0018(\u001B\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u001A\u0020\u0003.\u0018(\u0018\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0004\u0020\u0003.\u0018(\u000C\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u001D\u0020\u0003.\u0018(\u000E\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u000B\u0020\u0003.\u0018(\u0014\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0002\u0020\u0003.\u0018(1);
			if (\u0001\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u0020(ExportTemPlateInfo)).MethodHandle;
				}
				\u0002\u0020\u0003.\u0018(0);
			}
			if (\u000F\u0002\u0018.\u0018(\u0008\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), "No Margin"))
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
				\u001E\u0020\u0003.\u0018(0);
			}
			else if (\u000F\u0002\u0018.\u0018(\u0008\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), "Printer Limit"))
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
				\u001E\u0020\u0003.\u0018(1);
			}
			else if (\u000F\u0002\u0018.\u0018(\u0008\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), "User Defined"))
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
				\u001E\u0020\u0003.\u0018(2);
			}
			\u0017\u0020\u0003.\u0018(\u001D\u0020\u0018.\u0011(\u0006\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C))));
			\u0015\u0020\u0003.\u0018(\u001D\u0020\u0018.\u0011(\u0010\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C))));
			\u0020\u0020\u0003.\u0018(\u0017\u0007\u0003.\u0018(\u000C));
			\u0011\u0020\u0003.\u0018(1);
			if (\u0007\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)))
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
				\u0011\u0020\u0003.\u0018(0);
			}
			if (\u000F\u0002\u0018.\u0018(\u001A\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), "Color"))
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
				\u0013\u0020\u0003.\u0018(2);
			}
			else if (\u000F\u0002\u0018.\u0018(\u001A\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), "Gray Scale"))
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
				\u0013\u0020\u0003.\u0018(1);
			}
			else if (\u000F\u0002\u0018.\u0018(\u001A\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), "Black Line"))
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
				\u0013\u0020\u0003.\u0018(0);
			}
			\u0009\u0020\u0003.\u0018(\u000B\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0011\u0020\u0003.\u0018(1);
			if (\u0007\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)))
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
				\u0011\u0020\u0003.\u0018(0);
			}
			\u000A\u0020\u0003.\u0018(1);
			if (\u0019\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)))
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
				\u000A\u0020\u0003.\u0018(0);
			}
			\u000D\u0020\u0003.\u0018(\u0004\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u000F\u0020\u0003.\u0018(\u001E\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0012\u0020\u0003.\u0018(\u0002\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0016\u0020\u0003.\u0018(\u0017\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0003\u0020\u0003.\u0018(\u0015\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0014\u0020\u0003.\u0018(!\u0011\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)));
			\u0018\u0020\u0003.\u0018(\u0008\u0020\u0018.\u000C(\u001F\u0009\u0003.\u0018(\u000C), \u000D\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C)), \u000A\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(\u000C))));
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0003FB70 File Offset: 0x0003DD70
		internal static DayOfWeek \u001F(DayOfWeek \u000C, List<DayOfWeek> \u0018)
		{
			IEnumerable<DayOfWeek> enumerable = \u0018;
			Func<DayOfWeek, DayOfWeek> func;
			if ((func = \u001D\u0020\u0018.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0020\u0018.\u001F(DayOfWeek, List<DayOfWeek>)).MethodHandle;
				}
				func = (\u001D\u0020\u0018.<>c.\u0016 = new Func<DayOfWeek, DayOfWeek>(\u001D\u0020\u0018.<>c.\u000C.\u001C));
			}
			\u0018 = Enumerable.ToList<DayOfWeek>(Enumerable.OrderBy<DayOfWeek, DayOfWeek>(enumerable, func));
			List<DayOfWeek>.Enumerator enumerator = \u0008\u0012\u0016.\u0018(\u0018);
			try
			{
				while (\u0010\u0012\u0016.\u0018(ref enumerator))
				{
					DayOfWeek dayOfWeek = \u0006\u0012\u0016.\u0018(ref enumerator);
					if (dayOfWeek > \u000C)
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
						return dayOfWeek;
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return Enumerable.First<DayOfWeek>(\u0018);
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0003FC28 File Offset: 0x0003DE28
		private static double \u0011(string \u000C)
		{
			string u000C = \u0001\u0019\u0014.\u0018(\u000C, "[a-zA-Z]", "");
			double result = 0.0;
			\u0001\u0012\u0016.\u0018(u000C, NumberStyles.Float, \u001B\u0012\u0016.\u0018(), ref result);
			return result;
		}
	}
}
