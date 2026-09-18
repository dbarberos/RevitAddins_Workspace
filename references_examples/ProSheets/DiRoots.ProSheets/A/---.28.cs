using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Autodesk.Revit.DB;
using ProSheets.Models;
using ProSheets.UI;

namespace A
{
	// Token: 0x020000D6 RID: 214
	internal static class \u001E\u001F\u0018
	{
		// Token: 0x06000B4C RID: 2892 RVA: 0x00045274 File Offset: 0x00043474
		internal static void \u000C(MenuItem \u000C, RoutedEventHandler \u0018)
		{
			List<BasicBindingInfo> list = \u000F\u001F\u0016.\u0018();
			if (\u000F\u000A\u0018.\u0003\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u001F\u0018.\u000C(MenuItem, RoutedEventHandler)).MethodHandle;
				}
				object u000C = list;
				BasicBindingInfo basicBindingInfo = \u0016\u001F\u0016.\u0018();
				\u0003\u001F\u0016.\u0018(basicBindingInfo, 2.ToString());
				\u0014\u001F\u0016.\u0018(basicBindingInfo, \u001C\u0009\u0018.\u0013\u0016);
				\u0018\u001F\u0016.\u0018(u000C, basicBindingInfo);
			}
			object u000C2 = list;
			BasicBindingInfo basicBindingInfo2 = \u0016\u001F\u0016.\u0018();
			\u0003\u001F\u0016.\u0018(basicBindingInfo2, 0.ToString());
			\u0014\u001F\u0016.\u0018(basicBindingInfo2, \u001C\u0009\u0018.\u0009\u0016);
			\u0018\u001F\u0016.\u0018(u000C2, basicBindingInfo2);
			object u000C3 = list;
			BasicBindingInfo basicBindingInfo3 = \u0016\u001F\u0016.\u0018();
			\u0003\u001F\u0016.\u0018(basicBindingInfo3, 1.ToString());
			\u0014\u001F\u0016.\u0018(basicBindingInfo3, \u001C\u0009\u0018.\u000A\u0016);
			\u0018\u001F\u0016.\u0018(u000C3, basicBindingInfo3);
			List<BasicBindingInfo>.Enumerator enumerator = \u000C\u001F\u0016.\u0018(list);
			try
			{
				while (\u001B\u0020\u0016.\u0018(ref enumerator))
				{
					BasicBindingInfo u000C4 = \u000E\u0020\u0016.\u0018(ref enumerator);
					\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), \u001E\u001F\u0018.\u0016(\u0005\u0020\u0016.\u0018(u000C4), \u0018));
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

		// Token: 0x06000B4D RID: 2893 RVA: 0x000453A4 File Offset: 0x000435A4
		internal static void \u0018(MenuItem \u000C, RoutedEventHandler \u0018)
		{
			MenuItem menuItem = \u001E\u001F\u0018.\u0016("A", \u0015\u0010\u000F.\u000C);
			MenuItem menuItem2 = \u001E\u001F\u0018.\u0016("B", \u0015\u0010\u000F.\u000C);
			MenuItem menuItem3 = \u001E\u001F\u0018.\u0016("ARCH", \u0015\u0010\u000F.\u000C);
			MenuItem menuItem4 = \u001E\u001F\u0018.\u0016("ANSI", \u0015\u0010\u000F.\u000C);
			MenuItem menuItem5 = \u001E\u001F\u0018.\u0016(\u000D\u0009\u0018.\u0016\u0003, \u0015\u0010\u000F.\u000C);
			if (!\u000F\u000A\u0018.\u0003\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u001F\u0018.\u0018(MenuItem, RoutedEventHandler)).MethodHandle;
				}
				IEnumerable<PaperSize> enumerable = Enumerable.ToList<PaperSize>(PdfOptions.objPaperSizeSet);
				Func<PaperSize, BasicBindingInfo> func;
				if ((func = \u001E\u001F\u0018.<>c.\u0018) == null)
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
					func = (\u001E\u001F\u0018.<>c.\u0018 = new Func<PaperSize, BasicBindingInfo>(\u001E\u001F\u0018.<>c.\u000C.\u0016));
				}
				IEnumerable<BasicBindingInfo> enumerable2 = Enumerable.ToList<BasicBindingInfo>(Enumerable.Select<PaperSize, BasicBindingInfo>(enumerable, func));
				Func<BasicBindingInfo, int> func2;
				if ((func2 = \u001E\u001F\u0018.<>c.\u0014) == null)
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
					func2 = (\u001E\u001F\u0018.<>c.\u0014 = new Func<BasicBindingInfo, int>(\u001E\u001F\u0018.<>c.\u000C.\u000F));
				}
				IOrderedEnumerable<BasicBindingInfo> orderedEnumerable = Enumerable.OrderBy<BasicBindingInfo, int>(enumerable2, func2);
				Func<BasicBindingInfo, string> func3;
				if ((func3 = \u001E\u001F\u0018.<>c.\u0003) == null)
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
					func3 = (\u001E\u001F\u0018.<>c.\u0003 = new Func<BasicBindingInfo, string>(\u001E\u001F\u0018.<>c.\u000C.\u0012));
				}
				List<BasicBindingInfo>.Enumerator enumerator = \u000C\u001F\u0016.\u0018(Enumerable.ToList<BasicBindingInfo>(Enumerable.ThenBy<BasicBindingInfo, string>(orderedEnumerable, func3, new \u0014\u0017\u0018())));
				try
				{
					while (\u001B\u0020\u0016.\u0018(ref enumerator))
					{
						BasicBindingInfo u000C = \u000E\u0020\u0016.\u0018(ref enumerator);
						string u000C2 = \u0013\u001F\u0016.\u0018(u000C);
						MenuItem u000C3;
						if (!\u000F\u0002\u0018.\u0018(u000C2, "A"))
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
							if (!\u000F\u0002\u0018.\u0018(u000C2, "B"))
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
								if (!\u000F\u0002\u0018.\u0018(u000C2, "ARCH"))
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
									if (!\u000F\u0002\u0018.\u0018(u000C2, "ANSI"))
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
										u000C3 = menuItem5;
									}
									else
									{
										u000C3 = menuItem4;
									}
								}
								else
								{
									u000C3 = menuItem3;
								}
							}
							else
							{
								u000C3 = menuItem2;
							}
						}
						else
						{
							u000C3 = menuItem;
						}
						MenuItem u = \u001E\u001F\u0018.\u0016(\u0005\u0020\u0016.\u0018(u000C), \u0018);
						\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(u000C3), u);
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
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), menuItem);
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), menuItem2);
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), menuItem3);
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), menuItem4);
				\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), menuItem5);
				return;
			}
			List<PaperSizeInfo>.Enumerator enumerator2 = \u001C\u001F\u0016.\u0018(\u0015\u001C\u0003.\u0018(new \u000A\u0020\u0018()));
			try
			{
				while (\u0012\u001F\u0016.\u0018(ref enumerator2))
				{
					MenuItem u2 = \u001E\u001F\u0018.\u0016(\u000A\u001C\u0003.\u0014(\u000D\u001F\u0016.\u0018(ref enumerator2)), \u0018);
					\u0016\u000A\u0014.\u0018(\u000D\u000F\u0014.\u0018(\u000C), u2);
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
				((IDisposable)enumerator2).Dispose();
			}
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x000456AC File Offset: 0x000438AC
		public static int \u0014(string \u000C)
		{
			if (\u000F\u0002\u0018.\u0018(\u000C, "A"))
			{
				return 1;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u001F\u0018.\u0014(string)).MethodHandle;
			}
			if (\u000F\u0002\u0018.\u0018(\u000C, "B"))
			{
				return 2;
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
			if (\u000F\u0002\u0018.\u0018(\u000C, "ARCH"))
			{
				return 3;
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
			if (!\u000F\u0002\u0018.\u0018(\u000C, "ANSI"))
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
				return 5;
			}
			return 4;
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00045734 File Offset: 0x00043934
		internal static int \u0014(PaperSize \u000C)
		{
			return \u001E\u001F\u0018.\u0014(\u001E\u001F\u0018.\u0003(\u0005\u0007\u0014.\u0018(\u000C)));
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00045758 File Offset: 0x00043958
		public static string \u0003(string \u000C)
		{
			string u000C = \u0012\u0002\u0018.\u0018(\u000C);
			if (\u000E\u0019\u0014.\u0018(u000C, "a"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u001F\u0018.\u0003(string)).MethodHandle;
				}
				if (\u001C\u0002\u0018.\u0014(\u000C) < 4)
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
					return "A";
				}
			}
			if (\u000E\u0019\u0014.\u0018(u000C, "iso b"))
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
				return "B";
			}
			if (\u000E\u0019\u0014.\u0018(u000C, "arch"))
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
				return "ARCH";
			}
			if (\u000E\u0019\u0014.\u0018(u000C, "ansi"))
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
				return "ANSI";
			}
			return \u000D\u0009\u0018.\u0016\u0003;
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x00045810 File Offset: 0x00043A10
		private static MenuItem \u0016(string \u000C, RoutedEventHandler \u0018 = null)
		{
			MenuItem menuItem = \u000C\u000F\u0003.\u0018();
			\u000E\u0016\u0003.\u0018(menuItem, \u000C);
			Image image = \u0005\u0016\u0003.\u0018();
			\u001B\u0016\u0003.\u0018(image, \u0017\u0013\u0003.\u0018(\u0005\u000B\u0018.\u0018("../Images/page_white_stack.png", UriKind.Relative)));
			\u000F\u0016\u0003.\u0018(menuItem, image);
			MenuItem menuItem2 = menuItem;
			if (\u0018 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u001F\u0018.\u0016(string, RoutedEventHandler)).MethodHandle;
				}
				\u0008\u0016\u0003.\u0018(menuItem2, \u0018);
			}
			return menuItem2;
		}
	}
}
