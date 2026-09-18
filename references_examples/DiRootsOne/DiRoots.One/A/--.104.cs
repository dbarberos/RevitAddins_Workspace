using System;
using System.Collections.Generic;
using System.Drawing;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using DiRoots.One.PanelLink.Models;

namespace A
{
	// Token: 0x020001A8 RID: 424
	internal static class \u0015\u0002
	{
		// Token: 0x06000FBC RID: 4028 RVA: 0x00062B48 File Offset: 0x00060D48
		internal static string \u001F(SectionType \u001F, PanelScheduleView \u000A, int \u0007, int \u001D)
		{
			string text = \u000B\u000C\u0019.\u000A(\u000A, \u001F, \u0007, \u001D);
			try
			{
				if (!\u001A\u0006\u0007.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0002.\u001F(SectionType, PanelScheduleView, int, int)).MethodHandle;
					}
					object u001F = text;
					char[] array = \u001C\u0007\u000E.\u001F(2);
					array[0] = '\n';
					array[1] = '\r';
					text = \u0016\u000C\u0019.\u000A(u001F, array);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\PanelLink\\Helper\\RevitHandler.cs", "GetCellValue");
			}
			return text;
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x00062BC8 File Offset: 0x00060DC8
		internal static FontInfo \u000A(TableCellStyle \u001F)
		{
			FontInfo fontInfo = \u0014\u000C\u0019.\u000A();
			\u0020\u000C\u0019.\u000A(fontInfo, \u0017\u000C\u0019.\u000A(\u001F));
			\u0011\u000C\u0019.\u000A(fontInfo, \u0015\u0002.\u0007(\u0018\u001C\u0019.\u000A(\u001E\u000C\u0019.\u000A(\u001F)), \u0019\u001C\u0019.\u000A(\u001E\u000C\u0019.\u000A(\u001F)), \u0004\u001C\u0019.\u000A(\u001E\u000C\u0019.\u000A(\u001F))));
			\u0008\u000C\u0019.\u000A(fontInfo, \u001B\u000C\u0019.\u000A(\u001F));
			\u0010\u000C\u0019.\u000A(fontInfo, \u000E\u000C\u0019.\u000A(\u001F));
			\u0004\u000C\u0019.\u001D(fontInfo, \u000D\u000C\u0019.\u000A(\u001F));
			\u0003\u000C\u0019.\u000A(fontInfo, (float)\u001C\u000C\u0019.\u000A(\u001F));
			\u000F\u000C\u0019.\u000A(fontInfo, \u0015\u0002.\u0007(\u0018\u001C\u0019.\u000A(\u0012\u000C\u0019.\u000A(\u001F)), \u0019\u001C\u0019.\u000A(\u0012\u000C\u0019.\u000A(\u001F)), \u0004\u001C\u0019.\u000A(\u0012\u000C\u0019.\u000A(\u001F))));
			\u0002\u000C\u0019.\u000A(fontInfo, \u0006\u000C\u0019.\u000A(\u001F));
			return fontInfo;
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x00062CA8 File Offset: 0x00060EA8
		private static Color \u0007(byte \u001F, byte \u000A, byte \u0007)
		{
			return \u0001\u000D\u0004.\u000A((int)\u001F, (int)\u000A, (int)\u0007);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x00062CC0 File Offset: 0x00060EC0
		internal static HorizontalAlignments \u001D(TableCellStyle \u001F)
		{
			HorizontalAlignmentStyle horizontalAlignmentStyle = \u0013\u000C\u0019.\u000A(\u001F);
			HorizontalAlignments result = HorizontalAlignments.Left;
			if (horizontalAlignmentStyle == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0002.\u001D(TableCellStyle)).MethodHandle;
				}
				result = HorizontalAlignments.Center;
			}
			else if (horizontalAlignmentStyle == null)
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
				result = HorizontalAlignments.Left;
			}
			else if (horizontalAlignmentStyle == 2)
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
				result = HorizontalAlignments.Right;
			}
			return result;
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x00062D18 File Offset: 0x00060F18
		internal static VerticalAlignments \u0004(TableCellStyle \u001F)
		{
			VerticalAlignmentStyle verticalAlignmentStyle = \u001A\u000C\u0019.\u000A(\u001F);
			VerticalAlignments result = VerticalAlignments.Middle;
			if (verticalAlignmentStyle == 8)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0002.\u0004(TableCellStyle)).MethodHandle;
				}
				result = VerticalAlignments.Bottom;
			}
			else if (verticalAlignmentStyle == 4)
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
				result = VerticalAlignments.Middle;
			}
			else if (verticalAlignmentStyle == null)
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
				result = VerticalAlignments.Top;
			}
			return result;
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x00062D70 File Offset: 0x00060F70
		internal static BorderLinestyle \u0019(Dictionary<long, Category> \u001F, TableCellStyle \u000A)
		{
			Category u001F = \u000A\u0015\u0019.\u000A(\u001F, \u000B\u001E\u000A.\u000A(\u0019\u0015\u0019.\u000A(\u000A)));
			Category u001F2 = \u000A\u0015\u0019.\u000A(\u001F, \u000B\u001E\u000A.\u000A(\u0004\u0015\u0019.\u000A(\u000A)));
			Category u001F3 = \u000A\u0015\u0019.\u000A(\u001F, \u000B\u001E\u000A.\u000A(\u001D\u0015\u0019.\u000A(\u000A)));
			Category u001F4 = \u000A\u0015\u0019.\u000A(\u001F, \u000B\u001E\u000A.\u000A(\u0007\u0015\u0019.\u000A(\u000A)));
			BorderLinestyle borderLinestyle = \u001F\u0015\u0019.\u000A();
			\u0009\u000C\u0019.\u000A(borderLinestyle, \u0015\u0002.\u0018(u001F));
			\u0001\u000C\u0019.\u000A(borderLinestyle, \u0015\u0002.\u0018(u001F2));
			\u0015\u000C\u0019.\u000A(borderLinestyle, \u0015\u0002.\u0018(u001F3));
			\u000C\u000C\u0019.\u000A(borderLinestyle, \u0015\u0002.\u0018(u001F4));
			return borderLinestyle;
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x00062E1C File Offset: 0x0006101C
		internal static BorderLinestyles \u0018(Category \u001F)
		{
			int? num;
			\u0018\u0015\u0019.\u000A(ref num, 0);
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0002.\u0018(Category)).MethodHandle;
				}
				num = \u000F\u001C\u0019.\u000A(\u001F, 1);
			}
			int? num2 = num;
			int num3 = 0;
			if (\u0009\u001F\u001D.\u000A(ref num2) == num3 & \u000A\u000A\u001D.\u000A(ref num2))
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
				return BorderLinestyles.None;
			}
			num2 = num;
			num3 = 5;
			if (\u0009\u001F\u001D.\u000A(ref num2) <= num3 & \u000A\u000A\u001D.\u000A(ref num2))
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
				num2 = num;
				num3 = 0;
				if (\u0009\u001F\u001D.\u000A(ref num2) > num3 & \u000A\u000A\u001D.\u000A(ref num2))
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
					return BorderLinestyles.Thin;
				}
			}
			num2 = num;
			num3 = 8;
			if (\u0009\u001F\u001D.\u000A(ref num2) <= num3 & \u000A\u000A\u001D.\u000A(ref num2))
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
				num2 = num;
				num3 = 5;
				if (\u0009\u001F\u001D.\u000A(ref num2) > num3 & \u000A\u000A\u001D.\u000A(ref num2))
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
					return BorderLinestyles.Medium;
				}
			}
			return BorderLinestyles.Thick;
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x00062F1C File Offset: 0x0006111C
		internal unsafe static MergedCells \u0005(TableSectionData \u001F, int \u000A, int \u0007, ref bool \u001D, int \u0004)
		{
			MergedCells mergedCells = \u0010\u0015\u0019.\u000A();
			TableMergedCell u001F = \u000D\u0015\u0019.\u000A(\u001F, \u000A, \u0007);
			\u001C\u0015\u0019.\u000A(mergedCells, \u0006\u0015\u0019.\u000A(u001F) + \u0004);
			\u0003\u0015\u0019.\u000A(mergedCells, \u000B\u0015\u0019.\u000A(u001F));
			\u0012\u0015\u0019.\u000A(mergedCells, \u0002\u0015\u0019.\u000A(u001F) + \u0004);
			\u000F\u0015\u0019.\u000A(mergedCells, \u0016\u0015\u0019.\u000A(u001F));
			if (\u0006\u0015\u0019.\u000A(u001F) == \u0002\u0015\u0019.\u000A(u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u0002.\u0005(TableSectionData, int, int, bool*, int)).MethodHandle;
				}
				if (\u000B\u0015\u0019.\u000A(u001F) == \u0016\u0015\u0019.\u000A(u001F))
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
					\u001D = false;
				}
			}
			\u0005\u0015\u0019.\u000A(mergedCells, \u001D);
			return mergedCells;
		}
	}
}
