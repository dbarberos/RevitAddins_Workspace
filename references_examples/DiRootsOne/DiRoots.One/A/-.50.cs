using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DiRoots.One.TGDatabaseLayer;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000DC RID: 220
	internal static class \u000C\u0019
	{
		// Token: 0x0600085F RID: 2143 RVA: 0x000326E8 File Offset: 0x000308E8
		internal static string \u001F(IRange \u001F)
		{
			string result;
			if (\u001D\u000C\u001D.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u001F(IRange)).MethodHandle;
				}
				result = \u0007\u000C\u001D.\u000A(\u001F);
			}
			else
			{
				result = \u0003\u0014\u001D.\u000A(\u001F);
			}
			return result;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00032730 File Offset: 0x00030930
		internal static BorderLinestyles \u000A(IBorder \u001F)
		{
			if (\u0012\u001A\u001D.\u000A(\u001F) == ExcelLineStyle.Thick)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u000A(IBorder)).MethodHandle;
				}
				return BorderLinestyles.Thick;
			}
			if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Thin)
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
				if (\u0012\u001A\u001D.\u000A(\u001F) == ExcelLineStyle.Double)
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
				}
				else
				{
					if (\u0012\u001A\u001D.\u000A(\u001F) == ExcelLineStyle.Medium)
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
						return BorderLinestyles.Medium;
					}
					if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Dashed)
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
						if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Dash_dot)
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
							if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Dash_dot_dot)
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
								if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Dotted)
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
									if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Medium_dashed)
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
										if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Medium_dash_dot)
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
											if (\u0012\u001A\u001D.\u000A(\u001F) != ExcelLineStyle.Medium_dash_dot_dot)
											{
												return BorderLinestyles.None;
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
									}
								}
							}
						}
					}
					return BorderLinestyles.Overhead;
				}
			}
			return BorderLinestyles.Thin;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x00032840 File Offset: 0x00030A40
		internal static \u0010\u0005 \u0007(IFont \u001F)
		{
			\u0010\u0005 u0010_u = new \u0010\u0005();
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u0007(IFont)).MethodHandle;
				}
				\u0016\u000C\u001D.\u0007(u0010_u, \u0011\u001A\u001D.\u000A(\u001F));
				\u0005\u000C\u001D.\u000A(u0010_u, \u001F\u000C\u001D.\u000A(\u001F));
				\u0018\u000C\u001D.\u000A(u0010_u, \u0009\u001A\u001D.\u000A(\u001F));
				\u0019\u000C\u001D.\u000A(u0010_u, \u0001\u001A\u001D.\u000A(\u001F) > ExcelUnderline.None);
				\u0004\u000C\u001D.\u0007(u0010_u, \u000A\u000C\u001D.\u000A(\u001F));
			}
			return u0010_u;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x000328B4 File Offset: 0x00030AB4
		internal static \u0010\u0005 \u0007(string \u001F)
		{
			\u000C\u0019.\u001A\u0019 u001A_u = new \u000C\u0019.\u001A\u0019();
			u001A_u.\u001F = new \u0010\u0005();
			string u001F = \u0018\u0006\u001D.\u0007(\u001F);
			\u000C\u0019.\u001D(u001F, "text-decoration", "underline", new Action<string>(u001A_u.\u000A));
			\u000C\u0019.\u001D(u001F, "font-family", null, new Action<string>(u001A_u.\u0007));
			\u000C\u0019.\u001D(u001F, "color", null, new Action<string>(u001A_u.\u001D));
			\u000C\u0019.\u001D(u001F, "font-weight", "bold", new Action<string>(u001A_u.\u0004));
			\u000C\u0019.\u001D(u001F, "font-style", "italic", new Action<string>(u001A_u.\u0019));
			\u000C\u0019.\u001D(u001F, "font-size", null, new Action<string>(u001A_u.\u0018));
			return u001A_u.\u001F;
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0003297C File Offset: 0x00030B7C
		private static void \u001D(string \u001F, string \u000A, string \u0007, Action<string> \u001D)
		{
			if (\u000F\u000C\u001D.\u0007(\u001F, \u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u001D(string, string, string, Action<string>)).MethodHandle;
				}
				string[] array = \u0006\u000C\u001D.\u000A(\u001F, \u000A);
				if (\u000C\u0007\u000E.\u001F(array) != 0)
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
					string[] array2 = \u0006\u000C\u001D.\u000A(array[1], ";");
					if (\u000C\u0007\u000E.\u001F(array2) != 0)
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
						if (\u0007 != null)
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
							object u001F = array2[0];
							char[] array3 = \u001C\u0007\u000E.\u001F(1);
							array3[0] = ':';
							if (!\u0008\u0013\u000A.\u000A(\u0002\u000C\u001D.\u000A(u001F, array3), \u0007))
							{
								return;
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
						object u001F2 = array2[0];
						char[] array4 = \u001C\u0007\u000E.\u001F(1);
						array4[0] = ':';
						\u000B\u000C\u001D.\u000A(\u001D, \u0002\u000C\u001D.\u000A(u001F2, array4));
					}
				}
			}
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x00032A44 File Offset: 0x00030C44
		private static double \u0004(string \u001F)
		{
			object u001F = \u001C\u000B\u001D.\u0007(\u001F, "pt", "");
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = ':';
			double result;
			if (\u0013\u000C\u000A.\u000A(\u0002\u000C\u001D.\u000A(u001F, array), ref result))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u0004(string)).MethodHandle;
				}
				return result;
			}
			return 0.0;
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x00032AA0 File Offset: 0x00030CA0
		internal static HorizontalAlignments \u0019(ExcelHAlign \u001F)
		{
			HorizontalAlignments result = HorizontalAlignments.Left;
			if (\u001F == ExcelHAlign.HAlignCenter)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u0019(ExcelHAlign)).MethodHandle;
				}
				result = HorizontalAlignments.Center;
			}
			else if (\u001F == ExcelHAlign.HAlignLeft)
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
				result = HorizontalAlignments.Left;
			}
			else if (\u001F == ExcelHAlign.HAlignRight)
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
				result = HorizontalAlignments.Right;
			}
			return result;
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00032AF0 File Offset: 0x00030CF0
		internal static VerticalAlignments \u0018(ExcelVAlign \u001F)
		{
			VerticalAlignments result = VerticalAlignments.Middle;
			if (\u001F == ExcelVAlign.VAlignBottom)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u0018(ExcelVAlign)).MethodHandle;
				}
				result = VerticalAlignments.Bottom;
			}
			else if (\u001F == ExcelVAlign.VAlignCenter)
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
				result = VerticalAlignments.Middle;
			}
			else if (\u001F == ExcelVAlign.VAlignTop)
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
				result = VerticalAlignments.Top;
			}
			return result;
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00032B3C File Offset: 0x00030D3C
		internal static List<BorderLinestyles> \u0005(IRange \u001F)
		{
			IBorders u001F = \u0007\u0013\u001D.\u000A(\u001F);
			BorderLinestyles u000A = \u000C\u0019.\u000A(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeTop));
			BorderLinestyles u000A2 = \u000C\u0019.\u000A(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeRight));
			BorderLinestyles u000A3 = \u000C\u0019.\u000A(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeBottom));
			BorderLinestyles u000A4 = \u000C\u0019.\u000A(\u000A\u0013\u001D.\u000A(u001F, ExcelBordersIndex.EdgeLeft));
			List<BorderLinestyles> list = \u0003\u000C\u001D.\u000A(4);
			\u0012\u000C\u001D.\u000A(list, u000A);
			\u0012\u000C\u001D.\u000A(list, u000A3);
			\u0012\u000C\u001D.\u000A(list, u000A4);
			\u0012\u000C\u001D.\u000A(list, u000A2);
			return list;
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00032BBC File Offset: 0x00030DBC
		internal static bool \u0016(string \u001F)
		{
			string u001F = \u0018\u0006\u001D.\u0007(\u001B\u0002\u001D.\u000A(\u001F));
			if (!\u0008\u0013\u000A.\u000A(u001F, ".xlsx"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000C\u0019.\u0016(string)).MethodHandle;
				}
				return \u0008\u0013\u000A.\u000A(u001F, ".xlsm");
			}
			return true;
		}

		// Token: 0x020007EC RID: 2028
		[CompilerGenerated]
		private sealed class \u001A\u0019
		{
			// Token: 0x06004D11 RID: 19729 RVA: 0x001DD7E4 File Offset: 0x001DB9E4
			internal void \u000A(string \u001F)
			{
				\u0019\u000C\u001D.\u000A(this.\u001F, true);
			}

			// Token: 0x06004D12 RID: 19730 RVA: 0x001DD800 File Offset: 0x001DBA00
			internal void \u0007(string \u001F)
			{
				\u0016\u000C\u001D.\u0007(this.\u001F, \u001F);
			}

			// Token: 0x06004D13 RID: 19731 RVA: 0x001DD81C File Offset: 0x001DBA1C
			internal void \u001D(string \u001F)
			{
				\u0004\u000C\u001D.\u0007(this.\u001F, \u000A\u001F\u0010.\u000A(\u001F));
			}

			// Token: 0x06004D14 RID: 19732 RVA: 0x001DD83C File Offset: 0x001DBA3C
			internal void \u0004(string \u001F)
			{
				\u0005\u000C\u001D.\u000A(this.\u001F, true);
			}

			// Token: 0x06004D15 RID: 19733 RVA: 0x001DD858 File Offset: 0x001DBA58
			internal void \u0019(string \u001F)
			{
				\u0018\u000C\u001D.\u000A(this.\u001F, true);
			}

			// Token: 0x06004D16 RID: 19734 RVA: 0x001DD874 File Offset: 0x001DBA74
			internal void \u0018(string \u001F)
			{
				\u0002\u0017\u001D.\u000A(this.\u001F, \u000C\u0019.\u0004(\u001F));
			}

			// Token: 0x04001FFF RID: 8191
			public \u0010\u0005 \u001F;
		}
	}
}
