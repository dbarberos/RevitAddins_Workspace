using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;
using Syncfusion.XlsIO;
using Syncfusion.XlsIO.Implementation.Shapes;

namespace A
{
	// Token: 0x020000E0 RID: 224
	internal static class \u000A\u0018
	{
		// Token: 0x0600086E RID: 2158 RVA: 0x00032ED8 File Offset: 0x000310D8
		internal static List<\u001B\u0005> \u000A(IWorksheet \u001F, int \u000A, int \u0007, int \u001D, int \u0004, bool \u0019, bool \u0018)
		{
			List<\u001B\u0005> list = \u000F\u0015\u001D.\u000A();
			string u001F = \u0006\u0015\u001D.\u000A();
			IPictures u001F2 = \u0002\u0015\u001D.\u000A(\u001F);
			object u001F3 = \u000B\u0015\u001D.\u000A(\u001F);
			float num = \u0007\u0016.\u000A(true);
			float num2 = \u0007\u0016.\u000A(false);
			\u000E\u0011\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), \u0018\u000E\u0007.\u000A("Creating images with the following DPI: Height{0} Width:{1}", num2, num), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ImageHelper.cs", "ExtractImages");
			IEnumerator u001F4 = \u001D\u0011\u000A.\u000A(u001F3);
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F4))
				{
					IChartShape u001F5 = \u000E\u0004\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F4));
					ShapeImpl shapeImpl = \u0008\u0004\u000E.\u001F(u001F5);
					if (\u000A\u0015\u001D.\u000A(shapeImpl) >= \u000A)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0018.\u000A(IWorksheet, int, int, int, int, bool, bool)).MethodHandle;
						}
						if (\u000A\u0015\u001D.\u000A(shapeImpl) <= \u001D)
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
							if (\u001F\u0015\u001D.\u000A(shapeImpl) >= \u0007)
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
								if (\u001F\u0015\u001D.\u000A(shapeImpl) <= \u0004)
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
									string u000A = \u000A\u0018.\u0007(u001F, shapeImpl);
									MemoryStream memoryStream = \u0003\u0002\u001D.\u000A();
									\u0016\u0015\u001D.\u000A(u001F5, memoryStream);
									\u0005\u0002\u001D.\u000A(memoryStream, 0L);
									Image u001F6 = \u0005\u0015\u001D.\u000A(memoryStream);
									\u0018\u0015\u001D.\u000A(u001F6, u000A);
									\u0019\u0015\u001D.\u000A(u001F6);
									\u001B\u0005 u000A2 = \u000A\u0018.\u0019(shapeImpl, u000A, \u0019, \u0018);
									\u000C\u000C\u001D.\u000A(list, u000A2);
								}
							}
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
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F4);
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
			List<Exception> list2 = \u0004\u0015\u001D.\u000A();
			u001F4 = \u001D\u0011\u000A.\u000A(u001F2);
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F4))
				{
					IPictureShape u001F7 = \u001B\u0004\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F4));
					if (\u001D\u0015\u001D.\u000A(u001F7) != 0)
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
						if (\u0007\u0015\u001D.\u000A(u001F7) != 0)
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
							ShapeImpl shapeImpl2 = \u0008\u0004\u000E.\u001F(u001F7);
							if (\u000A\u0015\u001D.\u000A(shapeImpl2) >= \u000A)
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
								if (\u000A\u0015\u001D.\u000A(shapeImpl2) <= \u001D)
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
									if (\u001F\u0015\u001D.\u000A(shapeImpl2) >= \u0007)
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
										if (\u001F\u0015\u001D.\u000A(shapeImpl2) <= \u0004)
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
											try
											{
												string u000A3 = \u000A\u0018.\u0007(u001F, shapeImpl2);
												\u0015\u000C\u001D.\u000A(\u0009\u000C\u001D.\u000A(u001F7), u000A3, \u0001\u000C\u001D.\u000A());
												\u001B\u0005 u000A4 = \u000A\u0018.\u0019(shapeImpl2, u000A3, \u0019, \u0018);
												\u000C\u000C\u001D.\u000A(list, u000A4);
											}
											catch (Exception u000A5)
											{
												\u001A\u000C\u001D.\u000A(list2, u000A5);
												\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A5, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ImageHelper.cs", "ExtractImages");
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
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F4);
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
			if (\u0013\u000C\u001D.\u000A(list2) > 0)
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
				\u000A\u0016.\u001F(Enumerable.First<Exception>(list2));
			}
			return list;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00033244 File Offset: 0x00031444
		private static string \u0007(string \u001F, ShapeImpl \u000A)
		{
			string text = \u000A\u0018.\u001D(\u000A);
			string text2 = \u0019\u0005.\u000A(\u0012\u0015\u001D.\u000A(\u0003\u0015\u001D.\u000A(\u000A)));
			string[] array = \u001B\u001F\u000E.\u001F(5);
			array[0] = "TableGen_Import_";
			array[1] = text2;
			array[2] = "_";
			array[3] = text;
			array[4] = ".png";
			string u000A = \u0014\u0006\u001D.\u000A(array);
			return \u000A\u0018.\u0004(\u001F, u000A);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x000332AC File Offset: 0x000314AC
		private static string \u001D(ShapeImpl \u001F)
		{
			string u001F = "W{0}-H{1}-L{2}-T{3}";
			object[] array = \u0004\u0015\u0010.\u001F(4);
			array[0] = \u0008\u0015\u001D.\u000A(\u001F);
			array[1] = \u000E\u0015\u001D.\u000A(\u001F);
			array[2] = \u0010\u0015\u001D.\u000A(\u001F);
			array[3] = \u000D\u0015\u001D.\u000A(\u001F);
			return \u001C\u0015\u001D.\u000A(u001F, array);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00033310 File Offset: 0x00031510
		private static string \u0004(string \u001F, string \u000A)
		{
			\u0011\u0015\u001D.\u000A(\u001F);
			string u000A = \u0012\u0015\u001D.\u000A(\u000A);
			string u001D = \u001B\u0002\u001D.\u000A(\u000A);
			string text = \u001B\u0015\u001D.\u000A(\u001F, \u000A);
			int num = 1;
			while (\u0010\u0002\u001D.\u000A(text))
			{
				string u000A2 = \u001E\u0007\u0007.\u000A("{0} ({1}){2}", u000A, num, u001D);
				text = \u001B\u0015\u001D.\u000A(\u001F, u000A2);
				num++;
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0018.\u0004(string, string)).MethodHandle;
			}
			return text;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0003338C File Offset: 0x0003158C
		private static \u001B\u0005 \u0019(ShapeImpl \u001F, string \u000A, bool \u0007, bool \u001D)
		{
			\u001B\u0005 u001B_u = new \u001B\u0005();
			\u000A\u0001\u001D.\u000A(u001B_u, \u000A);
			\u001F\u0001\u001D.\u000A(u001B_u, \u000A\u0015\u001D.\u000A(\u001F));
			\u0009\u0015\u001D.\u000A(u001B_u, \u001F\u0015\u001D.\u000A(\u001F));
			\u001B\u0005 u001B_u2 = u001B_u;
			if (\u0007)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0018.\u0019(ShapeImpl, string, bool, bool)).MethodHandle;
				}
				if (\u001D)
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
					float num = \u0007\u0016.\u000A(true);
					float num2 = \u0007\u0016.\u000A(false);
					\u0017\u0015\u001D.\u000A(u001B_u2, \u0001\u0015\u001D.\u000A(\u001F) / (double)num);
					\u001E\u0015\u001D.\u000A(u001B_u2, \u0015\u0015\u001D.\u000A(\u001F) / (double)num2);
					\u001A\u0015\u001D.\u000A(u001B_u2, \u000C\u0015\u001D.\u000A(\u001F) / (double)num);
					\u0014\u0015\u001D.\u000A(u001B_u2, \u0013\u0015\u001D.\u000A(\u001F) / (double)num2);
				}
				else
				{
					\u0017\u0015\u001D.\u000A(u001B_u2, \u0019\u001A\u001D.\u000A(\u0020\u0015\u001D.\u000A(\u001F), (double)\u0008\u0015\u001D.\u000A(\u001F), MeasureUnits.Point, MeasureUnits.Inch));
					\u001E\u0015\u001D.\u000A(u001B_u2, \u0019\u001A\u001D.\u000A(\u0020\u0015\u001D.\u000A(\u001F), (double)\u000E\u0015\u001D.\u000A(\u001F), MeasureUnits.Point, MeasureUnits.Inch));
				}
			}
			return u001B_u2;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00033484 File Offset: 0x00031684
		internal static bool \u0018(IRange \u001F)
		{
			\u000A\u0018.\u001F\u0018 u001F_u = new \u000A\u0018.\u001F\u0018();
			u001F_u.\u001F = \u001F;
			return Enumerable.FirstOrDefault<\u001B\u0005>(\u000B\u0014\u001D.\u000A(), new Func<\u001B\u0005, bool>(u001F_u.\u000A)) != null;
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x000334BC File Offset: 0x000316BC
		internal static void \u0005(string \u001F)
		{
			try
			{
				if (\u0010\u0002\u001D.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0018.\u0005(string)).MethodHandle;
					}
					\u0007\u0001\u001D.\u000A(\u001F);
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\ImageHelper.cs", "RemoveImage");
			}
		}

		// Token: 0x04000351 RID: 849
		internal static string \u001F;

		// Token: 0x020007ED RID: 2029
		[CompilerGenerated]
		private sealed class \u001F\u0018
		{
			// Token: 0x06004D18 RID: 19736 RVA: 0x001DD8A8 File Offset: 0x001DBAA8
			internal bool \u000A(\u001B\u0005 \u001F)
			{
				if (\u000D\u000A\u0004.\u000A(\u001F) == \u0009\u0020\u001D.\u000A(this.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A\u0018.\u001F\u0018.\u000A(\u001B\u0005)).MethodHandle;
					}
					return \u001C\u000A\u0004.\u000A(\u001F) == \u0001\u0020\u001D.\u000A(this.\u001F);
				}
				return false;
			}

			// Token: 0x04002000 RID: 8192
			public IRange \u001F;
		}
	}
}
