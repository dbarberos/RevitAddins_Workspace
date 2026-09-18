using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using ProSheets.DrawingRegister.Model;
using ProSheets.Models;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x02000127 RID: 295
	internal static class \u0008\u0015\u0018
	{
		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x000561BC File Offset: 0x000543BC
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x000561D0 File Offset: 0x000543D0
		public static string FilePath { get; set; }

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x000561E4 File Offset: 0x000543E4
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x000561F8 File Offset: 0x000543F8
		public static Dictionary<string, ExcelHAlign> HorizontalAlignment { get; set; }

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x0005620C File Offset: 0x0005440C
		// (set) Token: 0x06000F3C RID: 3900 RVA: 0x00056220 File Offset: 0x00054420
		public static ExcelEngine ExcelEngine { get; set; } = \u0012\u0020\u0016.\u0018();

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x00056234 File Offset: 0x00054434
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x00056248 File Offset: 0x00054448
		public static IApplication ExcelPackage { get; set; } = \u000F\u0020\u0016.\u0018(\u0011\u000F\u000F.\u0018());

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0005625C File Offset: 0x0005445C
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x00056270 File Offset: 0x00054470
		public static IWorkbook Workbook { get; set; }

		// Token: 0x06000F41 RID: 3905 RVA: 0x00056284 File Offset: 0x00054484
		public static void \u000F()
		{
			if (!\u001F\u001A\u0018.\u0018(\u001F\u001B\u0016.\u0018()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u000F()).MethodHandle;
				}
				if (\u000C\u001A\u0018.\u0018(\u001F\u001B\u0016.\u0018()))
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
					\u000C\u0020\u0014.\u0018(\u001F\u001B\u0016.\u0018());
				}
			}
			\u001D\u000F\u000F.\u0018(\u001A\u000F\u000F.\u0018(\u0003\u0020\u0016.\u0018(\u000B\u000F\u000F.\u0018()), 1));
			string u000C = \u000D\u001E\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "\\DiRoots\\DocRegister");
			if (!\u0012\u0006\u0018.\u0018(u000C))
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
				\u000F\u0006\u0018.\u0018(u000C);
			}
			string u000C2 = \u0004\u000F\u000F.\u0018();
			string u000C3 = \u0003\u001A\u0018.\u0018(u000C, \u000D\u001E\u0018.\u0018(u000C2, ".xlsx"));
			if (!\u000C\u001A\u0018.\u0018(u000C3))
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
				\u0008\u0015\u0018.\u0012();
				FileInfo u000C4 = \u001B\u001E\u0014.\u0018(u000C3);
				\u0014\u000A\u0016.\u0018(\u0002\u000F\u000F.\u0018(), \u0001\u0017\u0018.\u0018(u000C4));
			}
			\u0017\u000F\u000F.\u0018(\u001E\u000F\u000F.\u0018());
			\u0015\u000F\u000F.\u0018(u000C3);
		}

		// Token: 0x06000F42 RID: 3906 RVA: 0x00056394 File Offset: 0x00054594
		public static IWorksheet \u0012()
		{
			if (\u0002\u000F\u000F.\u0018() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u0012()).MethodHandle;
				}
				return null;
			}
			DateTime dateTime = \u0019\u0015\u0014.\u0018();
			string text = \u0013\u0013\u0016.\u0018(ref dateTime, "yyyy-MM-dd");
			IWorksheet worksheet;
			if (\u0008\u0015\u0018.\u0011(text))
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
				worksheet = \u0008\u000F\u000F.\u0018(\u0018\u0020\u0016.\u0018(\u0002\u000F\u000F.\u0018()), text);
			}
			else
			{
				worksheet = \u0006\u000F\u000F.\u0018(\u0018\u0020\u0016.\u0018(\u0002\u000F\u000F.\u0018()), 0);
				\u0010\u000F\u000F.\u0018(worksheet, text);
				\u0007\u000F\u000F.\u0018(worksheet);
				\u0019\u000F\u000F.\u0018(\u000C\u0020\u0016.\u0018(\u0018\u0020\u0016.\u0018(\u0002\u000F\u000F.\u0018()), 0));
			}
			return worksheet;
		}

		// Token: 0x06000F43 RID: 3907 RVA: 0x00056444 File Offset: 0x00054644
		public static void \u000D(int \u000C, int \u0018, int \u0014, List<SheetInformation> \u0003, List<RevisionInformation> \u0016, string \u000F, RevisionNumbering \u0012)
		{
			IWorksheet u000C = \u0008\u0015\u0018.\u0012();
			IRange u000C2 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), \u000C - 1, \u0018, \u000C - 1, \u0018 + \u0014 - 1);
			IRange[] array = \u000D\u0012\u000F.\u0018(u000C2);
			for (int i = 0; i < (int)\u001F\u0010\u000F.\u000C(array); i++)
			{
				\u0012\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(array[i]), \u001E\u000A\u0016.\u0018(218, 218, 218));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u000D(int, int, int, List<SheetInformation>, List<RevisionInformation>, string, RevisionNumbering)).MethodHandle;
			}
			\u001C\u000A\u0016.\u0018(u000C2);
			\u0017\u000A\u0016.\u0018(u000C2, "Revisions");
			\u000E\u000F\u000F.\u0018(u000C2, ExcelLineStyle.Thin);
			\u000C\u0012\u000F.\u0018(u000C2, ExcelHAlign.HAlignCenter);
			\u000F\u0012\u000F.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C2)), true);
			for (int j = 0; j < \u0005\u000F\u000F.\u0018(\u0003); j++)
			{
				for (int k = 0; k < \u001B\u0005\u0016.\u0018(\u0016); k++)
				{
					if (\u0016\u0012\u000F.\u0018(\u0003\u0012\u000F.\u0018(\u0003, j), \u0002\u0006\u0016.\u0018(\u0014\u0012\u000F.\u0018(\u0016, k))))
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
						string u = string.Empty;
						if (\u0012 != null)
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
							if (\u0012 != 1)
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
							}
							else if (\u0019\u000B\u0014.\u0018(\u0010\u0002\u0016.\u0003(\u0003\u0012\u000F.\u0018(\u0003, j)), \u0002\u0006\u0016.\u0018(\u0014\u0012\u000F.\u0018(\u0016, k))))
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
								u = \u0018\u0012\u000F.\u0018(\u0010\u0002\u0016.\u0003(\u0003\u0012\u000F.\u0018(\u0003, j)), \u0002\u0006\u0016.\u0018(\u0014\u0012\u000F.\u0018(\u0016, k)));
							}
						}
						else
						{
							u = \u000F;
						}
						\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, k + \u0018), u);
						\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, k + \u0018), ExcelLineStyle.Thin);
						\u000C\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, k + \u0018), ExcelHAlign.HAlignCenter);
					}
					else
					{
						string u2 = "";
						\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, k + \u0018), u2);
					}
					\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, k + \u0018), ExcelLineStyle.Thin);
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
				for (int l = 0; l < \u0014 - \u001B\u0005\u0016.\u0018(\u0016); l++)
				{
					\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, l + \u001B\u0005\u0016.\u0018(\u0016) + \u0018), string.Empty);
					\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), j + \u000C, l + \u001B\u0005\u0016.\u0018(\u0016) + \u0018), ExcelLineStyle.Thin);
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
			for (;;)
			{
				switch (2)
				{
				case 0:
					continue;
				}
				break;
			}
			\u0001\u000F\u000F.\u0018(\u001B\u000F\u000F.\u0018(u000C));
			\u0008\u0015\u0018.\u001F(\u001F\u001B\u0016.\u0018());
		}

		// Token: 0x06000F44 RID: 3908 RVA: 0x0005673C File Offset: 0x0005493C
		public static ColumnRowDetail \u001C(List<ParameterInformation> \u000C, int \u0018, int \u0014, string \u0003 = null)
		{
			IWorksheet u000C = \u0008\u0015\u0018.\u0012();
			for (int i = 0; i < \u0015\u000B\u0016.\u0018(\u000C); i++)
			{
				\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 1 + \u0014), \u001F\u0001\u0016.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i)));
				\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 2 + \u0014), \u0020\u0016\u000F.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i)));
				if (!\u001F\u001A\u0018.\u0018(\u0020\u0008\u0016.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i))))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u001C(List<ParameterInformation>, int, int, string)).MethodHandle;
					}
					object u000C2 = \u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 2 + \u0014);
					DateTime dateTime = \u0019\u0015\u0014.\u0018();
					\u0017\u000A\u0016.\u0018(u000C2, \u000E\u000A\u0016.\u0018(ref dateTime));
					\u0020\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 2 + \u0014), \u0020\u0008\u0016.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i)));
				}
				\u0012\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 1 + \u0014)), \u001E\u000A\u0016.\u0018(218, 218, 218));
				\u000F\u0012\u000F.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 1 + \u0014))), true);
				ExcelHAlign u = ExcelHAlign.HAlignCenter;
				HorizontalAlignment horizontalAlignment = \u0011\u0014\u000F.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i));
				if (horizontalAlignment != System.Windows.HorizontalAlignment.Left)
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
					if (horizontalAlignment != System.Windows.HorizontalAlignment.Right)
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
					}
					else
					{
						u = ExcelHAlign.HAlignRight;
					}
				}
				else
				{
					u = ExcelHAlign.HAlignLeft;
				}
				\u000C\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 1 + \u0014), u);
				\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 1 + \u0014), ExcelLineStyle.Thin);
				\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 2 + \u0014), ExcelLineStyle.Thin);
				\u000C\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 2 + \u0014), u);
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
			\u0001\u000F\u000F.\u0018(\u001B\u000F\u000F.\u0018(u000C));
			\u0008\u0015\u0018.\u001F(\u001F\u001B\u0016.\u0018());
			ColumnRowDetail columnRowDetail = \u0009\u0012\u000F.\u0018();
			\u0013\u0012\u000F.\u0018(columnRowDetail, 2 + \u0014);
			\u001C\u0012\u000F.\u0018(columnRowDetail, \u0015\u000B\u0016.\u0018(\u000C) + \u0018);
			return columnRowDetail;
		}

		// Token: 0x06000F45 RID: 3909 RVA: 0x000569A0 File Offset: 0x00054BA0
		public static void \u0013(string \u000C)
		{
			IWorksheet u000C = \u0008\u0015\u0018.\u0012();
			if (\u000B\u0012\u000F.\u0018(\u0017\u0012\u000F.\u0018(u000C)) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u0013(string)).MethodHandle;
				}
				\u001D\u0012\u000F.\u0018(\u001A\u0012\u000F.\u0018(\u0017\u0012\u000F.\u0018(u000C), 0));
			}
			if (\u000C != null)
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
				if (!\u001F\u001A\u0018.\u0018(\u000C))
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
					double num = 1.0;
					if (\u000C\u001A\u0018.\u0018(\u000C))
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
						Image image = \u0004\u0012\u000F.\u0018(\u000C);
						try
						{
							num = (double)\u0002\u0012\u000F.\u0018(image) / (double)\u001E\u0012\u000F.\u0018(image);
						}
						finally
						{
							if (image != null)
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
								\u0020\u001E\u0018.\u0018(image);
							}
						}
					}
					IPictureShape u000C2 = \u0015\u0012\u000F.\u0018(\u0017\u0012\u000F.\u0018(u000C), 1, 1, \u000C);
					\u0011\u0012\u000F.\u0018(u000C2, 80);
					\u001F\u0012\u000F.\u0018(u000C2, (int)(80.0 * num));
				}
			}
			\u0008\u0015\u0018.\u001F(\u001F\u001B\u0016.\u0018());
		}

		// Token: 0x06000F46 RID: 3910 RVA: 0x00056AB0 File Offset: 0x00054CB0
		public static ColumnRowDetail \u0009(List<RevisionData> \u000C, int \u0018, int \u0014)
		{
			IWorksheet u000C = \u0008\u0015\u0018.\u0012();
			for (int i = 0; i < \u0019\u0012\u000F.\u0018(\u000C) * 2; i += 2)
			{
				int num = \u0014\u000E\u0016.\u0018(\u0003\u000E\u0016.\u0014(\u0008\u0012\u000F.\u0018(\u000C, i / 2)));
				IRange u000C2 = \u0013\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, 1 + \u0014, i + 1 + \u0018, num + \u0014);
				\u001C\u000A\u0016.\u0018(u000C2);
				IRange[] array = \u000D\u0012\u000F.\u0018(u000C2);
				for (int j = 0; j < (int)\u001F\u0010\u000F.\u000C(array); j++)
				{
					\u0012\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(array[j]), \u001E\u000A\u0016.\u0018(218, 218, 218));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u0009(List<RevisionData>, int, int)).MethodHandle;
				}
				\u000C\u0012\u000F.\u0018(u000C2, ExcelHAlign.HAlignCenter);
				\u000E\u000F\u000F.\u0018(u000C2, ExcelLineStyle.Thin);
				\u0017\u000A\u0016.\u0018(u000C2, \u0020\u000E\u0016.\u0014(\u0008\u0012\u000F.\u0018(\u000C, i / 2)));
				\u000F\u0012\u000F.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(u000C2)), true);
				for (int k = 0; k < num; k++)
				{
					\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 2 + \u0018, k + 1 + \u0014), \u0001\u0012\u000F.\u0018(\u001B\u0012\u000F.\u0018(\u0003\u000E\u0016.\u0014(\u0008\u0012\u000F.\u0018(\u000C, i / 2)), k)));
					\u0006\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 2 + \u0018, k + 1 + \u0014)), 0);
					if (\u0017\u0016\u000F.\u0003(\u0008\u0012\u000F.\u0018(\u000C, i / 2)) == 1)
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
						\u0006\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 2 + \u0018, k + 1 + \u0014)), 90);
					}
					\u0010\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 2 + \u0018, k + 1 + \u0014), ExcelVAlign.VAlignCenter);
					\u000C\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 2 + \u0018, k + 1 + \u0014), ExcelHAlign.HAlignCenter);
					\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 2 + \u0018, k + 1 + \u0014), ExcelLineStyle.Thin);
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
			for (;;)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			\u0001\u000F\u000F.\u0018(\u001B\u000F\u000F.\u0018(u000C));
			\u0007\u0012\u000F.\u0018(\u001B\u000F\u000F.\u0018(u000C));
			\u0008\u0015\u0018.\u001F(\u001F\u001B\u0016.\u0018());
			ColumnRowDetail columnRowDetail = \u0009\u0012\u000F.\u0018();
			\u0013\u0012\u000F.\u0018(columnRowDetail, 0);
			\u001C\u0012\u000F.\u0018(columnRowDetail, 2 * \u0019\u0012\u000F.\u0018(\u000C) + \u0018);
			return columnRowDetail;
		}

		// Token: 0x06000F47 RID: 3911 RVA: 0x00056D3C File Offset: 0x00054F3C
		public static void \u000A(List<SheetInformation> \u000C, int \u0018, int \u0014)
		{
			IWorksheet u000C = \u0008\u0015\u0018.\u0012();
			for (int i = 0; i < \u0005\u000F\u000F.\u0018(\u000C); i++)
			{
				for (int j = 0; j < \u0015\u000B\u0016.\u0018(\u001F\u0004\u0016.\u0003(\u0003\u0012\u000F.\u0018(\u000C, i))); j++)
				{
					\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, j + 1 + \u0014), \u0020\u0016\u000F.\u0018(\u000A\u0012\u000F.\u0018(\u001F\u0004\u0016.\u0003(\u0003\u0012\u000F.\u0018(\u000C, i)), j)));
					\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, j + 1 + \u0014), ExcelLineStyle.Thin);
					ExcelHAlign u = \u0005\u0012\u000F.\u0018(\u000E\u0012\u000F.\u0018(), \u0010\u0008\u0016.\u0014(\u000A\u0012\u000F.\u0018(\u001F\u0004\u0016.\u0003(\u0003\u0012\u000F.\u0018(\u000C, i)), j)));
					\u000C\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), i + 1 + \u0018, j + 1 + \u0014), u);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u000A(List<SheetInformation>, int, int)).MethodHandle;
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
			\u0001\u000F\u000F.\u0018(\u001B\u000F\u000F.\u0018(u000C));
			\u0008\u0015\u0018.\u001F(\u001F\u001B\u0016.\u0018());
		}

		// Token: 0x06000F48 RID: 3912 RVA: 0x00056E74 File Offset: 0x00055074
		public static void \u0020(List<ParameterInformation> \u000C, int \u0018, int \u0014)
		{
			IWorksheet u000C = \u0008\u0015\u0018.\u0012();
			\u0017\u000F\u000F.\u0018(\u001E\u000F\u000F.\u0018());
			for (int i = 0; i < \u0015\u000B\u0016.\u0018(\u000C); i++)
			{
				\u0017\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), \u0018, i + 1 + \u0014), \u001F\u0001\u0016.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i)));
				\u000F\u0012\u000F.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), \u0018, i + 1 + \u0014))), true);
				\u0012\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), \u0018, i + 1 + \u0014)), \u001E\u000A\u0016.\u0018(255, 219, 88));
				\u000E\u000F\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), \u0018, i + 1 + \u0014), ExcelLineStyle.Thin);
				ExcelHAlign excelHAlign = ExcelHAlign.HAlignCenter;
				HorizontalAlignment horizontalAlignment = \u0011\u0014\u000F.\u0018(\u000A\u0012\u000F.\u0018(\u000C, i));
				if (horizontalAlignment != System.Windows.HorizontalAlignment.Left)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u0020(List<ParameterInformation>, int, int)).MethodHandle;
					}
					if (horizontalAlignment != System.Windows.HorizontalAlignment.Right)
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
						excelHAlign = ExcelHAlign.HAlignRight;
					}
				}
				else
				{
					excelHAlign = ExcelHAlign.HAlignLeft;
				}
				\u000C\u0012\u000F.\u0018(\u0004\u000A\u0016.\u0018(\u0009\u000A\u0016.\u0018(u000C), \u0018, i + 1 + \u0014), excelHAlign);
				\u000C\u000D\u000F.\u0018(\u000E\u0012\u000F.\u0018(), \u0010\u0008\u0016.\u0014(\u000A\u0012\u000F.\u0018(\u000C, i)), excelHAlign);
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
			\u0001\u000F\u000F.\u0018(\u001B\u000F\u000F.\u0018(u000C));
			\u0008\u0015\u0018.\u001F(\u001F\u001B\u0016.\u0018());
		}

		// Token: 0x06000F49 RID: 3913 RVA: 0x00056FF0 File Offset: 0x000551F0
		public static bool \u001F(string \u000C)
		{
			bool result = false;
			try
			{
				\u0014\u000A\u0016.\u0018(\u0002\u000F\u000F.\u0018(), \u000C);
				result = true;
			}
			catch (Exception)
			{
				\u001B\u0019\u0018.\u0018(\u0018\u000D\u000F.\u0018(), \u001C\u001D\u0016.\u0018(), MessageBoxButtons.OK);
				result = false;
			}
			return result;
		}

		// Token: 0x06000F4A RID: 3914 RVA: 0x0005703C File Offset: 0x0005523C
		public static bool \u0011(string \u000C)
		{
			\u0008\u0015\u0018.\u0006\u0015\u0018 u0006_u0015_u = new \u0008\u0015\u0018.\u0006\u0015\u0018();
			u0006_u0015_u.\u000C = \u000C;
			return Enumerable.Any<IWorksheet>(\u0018\u0020\u0016.\u0018(\u0002\u000F\u000F.\u0018()), new Func<IWorksheet, bool>(u0006_u0015_u.\u0018));
		}

		// Token: 0x06000F4B RID: 3915 RVA: 0x00057078 File Offset: 0x00055278
		public static void \u0015()
		{
			IWorksheet worksheet = \u0008\u0015\u0018.\u0012();
			if (worksheet == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u0015\u0018.\u0015()).MethodHandle;
				}
				return;
			}
			\u0012\u000D\u000F.\u0018(\u001B\u000F\u000F.\u0018(worksheet));
			if (\u000F\u000D\u000F.\u0018(\u001B\u000F\u000F.\u0018(worksheet)) > 1)
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
				\u0016\u000D\u000F.\u0018(\u001B\u000F\u000F.\u0018(worksheet));
				\u000F\u0012\u000F.\u0018(\u0011\u000A\u0016.\u0018(\u000D\u000A\u0016.\u0018(\u001B\u000F\u000F.\u0018(worksheet))), false);
				\u0006\u0012\u000F.\u0018(\u000D\u000A\u0016.\u0018(\u001B\u000F\u000F.\u0018(worksheet)), 0);
				\u0003\u000D\u000F.\u0018(\u001B\u000F\u000F.\u0018(worksheet));
				\u0014\u000D\u000F.\u0018(\u000D\u000A\u0016.\u0018(\u001B\u000F\u000F.\u0018(worksheet)), ExcelKnownColors.None);
				\u0001\u000F\u000F.\u0018(\u001B\u000F\u000F.\u0018(worksheet));
				\u0007\u0012\u000F.\u0018(\u001B\u000F\u000F.\u0018(worksheet));
			}
			if (\u000B\u0012\u000F.\u0018(\u0017\u0012\u000F.\u0018(worksheet)) > 0)
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
				\u001D\u0012\u000F.\u0018(\u001A\u0012\u000F.\u0018(\u0017\u0012\u000F.\u0018(worksheet), 0));
			}
		}

		// Token: 0x040006D3 RID: 1747
		[CompilerGenerated]
		private static string \u000C;

		// Token: 0x040006D4 RID: 1748
		[CompilerGenerated]
		private static Dictionary<string, ExcelHAlign> \u0018;

		// Token: 0x040006D5 RID: 1749
		[CompilerGenerated]
		private static ExcelEngine \u0014;

		// Token: 0x040006D6 RID: 1750
		[CompilerGenerated]
		private static IApplication \u0003;

		// Token: 0x040006D7 RID: 1751
		[CompilerGenerated]
		private static IWorkbook \u0016;

		// Token: 0x02000214 RID: 532
		[CompilerGenerated]
		private sealed class \u0006\u0015\u0018
		{
			// Token: 0x060012FE RID: 4862 RVA: 0x00061440 File Offset: 0x0005F640
			internal bool \u0018(IWorksheet \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u001E\u000F.\u0018(\u000C), this.\u000C);
			}

			// Token: 0x04000964 RID: 2404
			public string \u000C;
		}
	}
}
