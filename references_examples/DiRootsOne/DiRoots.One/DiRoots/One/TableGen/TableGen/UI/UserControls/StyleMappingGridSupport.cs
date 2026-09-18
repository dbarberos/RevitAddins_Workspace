using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using A;
using DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings;

namespace DiRoots.One.TableGen.TableGen.UI.UserControls
{
	// Token: 0x0200017E RID: 382
	public static class StyleMappingGridSupport
	{
		// Token: 0x06000E41 RID: 3649 RVA: 0x0005B4D4 File Offset: 0x000596D4
		public static IComparer BuildComparer(string sortMemberPath, ListSortDirection direction, bool isTextTab)
		{
			StyleMappingGridSupport.\u000A\u0002 u000A_u = new StyleMappingGridSupport.\u000A\u0002();
			u000A_u.\u001F = sortMemberPath;
			bool u000A = direction == ListSortDirection.Ascending;
			string u001F = u000A_u.\u001F;
			if (u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.BuildComparer(string, ListSortDirection, bool)).MethodHandle;
				}
				int num = \u001C\u000F\u0007.\u001D(u001F);
				switch (num)
				{
				case 4:
					if (!\u0008\u0013\u000A.\u000A(u001F, "Size"))
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
						goto IL_239;
					}
					break;
				case 5:
				{
					if (!\u0008\u0013\u000A.\u000A(u001F, "Color"))
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
						goto IL_239;
					}
					Func<object, ValueTuple<int, double, double>> u001F2;
					if ((u001F2 = StyleMappingGridSupport.<>c.\u000A) == null)
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
						u001F2 = (StyleMappingGridSupport.<>c.\u000A = new Func<object, ValueTuple<int, double, double>>(StyleMappingGridSupport.<>c.\u001F.\u0004));
					}
					return \u0019\u000E\u0019.\u000A(u001F2, u000A);
				}
				case 6:
				case 7:
					goto IL_239;
				case 8:
					if (!\u0008\u0013\u000A.\u000A(u001F, "SizeInPt"))
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
						goto IL_239;
					}
					break;
				default:
					switch (num)
					{
					case 14:
					{
						if (!\u0008\u0013\u000A.\u000A(u001F, "RevitStyleName"))
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
							goto IL_239;
						}
						Func<object, ValueTuple<int, string>> u001F3;
						if ((u001F3 = StyleMappingGridSupport.<>c.\u0007) == null)
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
							u001F3 = (StyleMappingGridSupport.<>c.\u0007 = new Func<object, ValueTuple<int, string>>(StyleMappingGridSupport.<>c.\u001F.\u0019));
						}
						return \u001D\u000E\u0019.\u000A(u001F3, u000A);
					}
					case 15:
						goto IL_239;
					case 16:
						if (!\u0008\u0013\u000A.\u000A(u001F, "ScheduleFontSize"))
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
							goto IL_239;
						}
						break;
					case 17:
					{
						if (!\u0008\u0013\u000A.\u000A(u001F, "BoldItalicDisplay"))
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
							goto IL_239;
						}
						Func<object, int> u001F4;
						if ((u001F4 = StyleMappingGridSupport.\u001F\u0002.\u001F) == null)
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
							u001F4 = (StyleMappingGridSupport.\u001F\u0002.\u001F = new Func<object, int>(StyleMappingGridSupport.\u000A));
						}
						return \u0004\u000E\u0019.\u000A(u001F4, u000A);
					}
					case 18:
					{
						if (!\u0008\u0013\u000A.\u000A(u001F, "RevitTextStyleName"))
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
							goto IL_239;
						}
						Func<object, ValueTuple<int, string>> u001F5;
						if ((u001F5 = StyleMappingGridSupport.<>c.\u001D) == null)
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
							u001F5 = (StyleMappingGridSupport.<>c.\u001D = new Func<object, ValueTuple<int, string>>(StyleMappingGridSupport.<>c.\u001F.\u0018));
						}
						return \u001D\u000E\u0019.\u000A(u001F5, u000A);
					}
					default:
						goto IL_239;
					}
					break;
				}
				return \u0007\u000E\u0019.\u000A(new Func<object, double>(u000A_u.\u000A), u000A);
			}
			IL_239:
			return \u000A\u000E\u0019.\u000A(new Func<object, string>(u000A_u.\u0007), u000A);
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x0005B730 File Offset: 0x00059930
		private static Color \u001F(object \u001F)
		{
			LineStyleMappingVM lineStyleMappingVM = \u0003\u0005\u000E.\u001F(\u001F);
			if (lineStyleMappingVM != null)
			{
				return \u0005\u000E\u0019.\u000A(lineStyleMappingVM);
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.\u001F(object)).MethodHandle;
			}
			TextStyleMappingVM textStyleMappingVM = \u000E\u0005\u000E.\u001F(\u001F);
			if (textStyleMappingVM == null)
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
				return \u0013\u0012\u0019.\u000A();
			}
			return \u0018\u000E\u0019.\u000A(textStyleMappingVM);
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x0005B790 File Offset: 0x00059990
		private static int \u000A(object \u001F)
		{
			TextStyleMappingVM textStyleMappingVM = \u000E\u0005\u000E.\u001F(\u001F);
			if (textStyleMappingVM != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.\u000A(object)).MethodHandle;
				}
				return \u0002\u0005.\u000C(\u0018\u001D\u0004.\u0007(\u0016\u000E\u0019.\u000A(textStyleMappingVM)), \u0019\u001D\u0004.\u0007(\u0016\u000E\u0019.\u000A(textStyleMappingVM)), false);
			}
			return 0;
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x0005B7E4 File Offset: 0x000599E4
		[return: TupleElementNames(new string[]
		{
			"bucket",
			"name"
		})]
		private static ValueTuple<int, string> \u0007(object \u001F, bool \u000A)
		{
			if (!\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.\u0007(object, bool)).MethodHandle;
				}
				LineStyleMappingVM lineStyleMappingVM = \u0003\u0005\u000E.\u001F(\u001F);
				if (lineStyleMappingVM != null)
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
					if (\u000A\u001C\u0019.\u000A(lineStyleMappingVM))
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
						return new ValueTuple<int, string>(0, null);
					}
					if (\u001F\u001C\u0019.\u000A(lineStyleMappingVM))
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
						return new ValueTuple<int, string>(1, \u0009\u0003\u0019.\u000A(lineStyleMappingVM));
					}
					return new ValueTuple<int, string>(2, \u0009\u0003\u0019.\u000A(lineStyleMappingVM));
				}
			}
			if (\u000A)
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
				TextStyleMappingVM textStyleMappingVM = \u000E\u0005\u000E.\u001F(\u001F);
				if (textStyleMappingVM != null)
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
					if (\u0011\u0010\u0019.\u000A(textStyleMappingVM))
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
						return new ValueTuple<int, string>(1, \u001B\u0010\u0019.\u000A(textStyleMappingVM));
					}
					return new ValueTuple<int, string>(2, \u001B\u0010\u0019.\u000A(textStyleMappingVM));
				}
			}
			return new ValueTuple<int, string>(3, null);
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x0005B8CC File Offset: 0x00059ACC
		private static object \u001D(object \u001F, string \u000A)
		{
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.\u001D(object, string)).MethodHandle;
				}
				return null;
			}
			PropertyInfo propertyInfo = \u0002\u000E\u0019.\u000A(\u0003\u0011\u000A.\u0007(\u001F), \u000A, BindingFlags.Instance | BindingFlags.Public);
			if (propertyInfo == null)
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
				return null;
			}
			return \u000B\u000E\u0019.\u0007(propertyInfo, \u001F);
		}

		// Token: 0x02000853 RID: 2131
		[CompilerGenerated]
		private static class \u001F\u0002
		{
			// Token: 0x04002136 RID: 8502
			public static Func<object, int> \u001F;
		}

		// Token: 0x02000855 RID: 2133
		[CompilerGenerated]
		private sealed class \u000A\u0002
		{
			// Token: 0x06004EA4 RID: 20132 RVA: 0x001E1384 File Offset: 0x001DF584
			internal double \u000A(object \u001F)
			{
				object u001F;
				if ((u001F = StyleMappingGridSupport.\u001D(\u001F, this.\u001F)) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.\u000A\u0002.\u000A(object)).MethodHandle;
					}
					u001F = 0.0;
				}
				return \u0015\u000C\u000A.\u000A(u001F);
			}

			// Token: 0x06004EA5 RID: 20133 RVA: 0x001E13CC File Offset: 0x001DF5CC
			internal string \u0007(object \u001F)
			{
				object obj = StyleMappingGridSupport.\u001D(\u001F, this.\u001F);
				string text;
				if (obj == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingGridSupport.\u000A\u0002.\u0007(object)).MethodHandle;
					}
					text = null;
				}
				else
				{
					text = \u001A\u000C\u000A.\u000A(obj);
				}
				string result;
				if ((result = text) == null)
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
					result = string.Empty;
				}
				return result;
			}

			// Token: 0x0400213B RID: 8507
			public string \u001F;
		}
	}
}
