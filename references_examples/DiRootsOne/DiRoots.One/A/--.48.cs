using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;
using Syncfusion.XlsIO;

namespace A
{
	// Token: 0x020000EA RID: 234
	internal static class \u0003\u0018
	{
		// Token: 0x060008A2 RID: 2210 RVA: 0x00034920 File Offset: 0x00032B20
		internal static \u0006\u0018 \u001F(IRange \u001F, Action \u000A, bool \u0007 = false, \u001C\u0016 \u001D = null)
		{
			\u0006\u0018 u0006_u = new \u0006\u0018();
			IWorksheet u001F = \u000C\u001E\u001D.\u000A(\u001F);
			int num = (int)\u0018\u0004\u000E.\u001F(\u0013\u0014\u001D.\u000A(\u001F));
			int num2 = \u0009\u0020\u001D.\u000A(\u001F);
			int num3 = num2;
			int num4 = (int)\u0018\u0004\u000E.\u001F(\u001A\u0014\u001D.\u000A(\u001F));
			int num5 = \u0001\u0020\u001D.\u000A(\u001F);
			int num6 = num5;
			\u0005\u0013\u001D.\u000A(\u000A\u0018.\u000A(u001F, num2, num5, \u000B\u0013\u001D.\u000A(\u001F), \u0016\u0013\u001D.\u000A(\u001F), false, \u0007));
			\u0006\u000A\u0004.\u000A(\u0005\u000A\u0004.\u000A());
			int i = 0;
			while (i < num4)
			{
				if (\u001C\u0014\u001D.\u000A(u001F, num6))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u001F(IRange, Action, bool, \u001C\u0016)).MethodHandle;
					}
					\u0003\u0005 u0003_u = new \u0003\u0005();
					double u000A = (double)\u0005\u001A\u001D.\u000A(u001F, num6);
					\u0002\u000A\u0004.\u000A(u0003_u, \u0019\u001A\u001D.\u000A(\u0018\u001A\u001D.\u000A(u001F), u000A, MeasureUnits.Pixel, MeasureUnits.Millimeter));
					\u000B\u000A\u0004.\u000A(u0003_u, i);
					\u0016\u000A\u0004.\u000A(\u0005\u000A\u0004.\u000A(), u0003_u);
				}
				i++;
				num6++;
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
			\u0018\u000A\u0004.\u000A(u0006_u, Enumerable.ToList<\u0003\u0005>(\u0005\u000A\u0004.\u000A()));
			int num7 = 1;
			int num8;
			if (num <= 50)
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
				num8 = 10;
			}
			else
			{
				num8 = 50;
			}
			int num9 = num8;
			int j = 1;
			while (j <= num)
			{
				if (j % num9 == 0)
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
					if (\u000A != null)
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
						\u001B\u0015\u0007.\u000A(\u000A);
					}
				}
				if (!\u0019\u0013\u001D.\u000A(u001F, num3))
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
					num7++;
				}
				else
				{
					num6 = num5;
					int num10 = 1;
					int k = 1;
					while (k <= num4)
					{
						if (k % 20 == 0)
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
							if (\u000A != null)
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
								\u001B\u0015\u0007.\u000A(\u000A);
							}
						}
						if (!\u001C\u0014\u001D.\u000A(u001F, num6))
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
							num10++;
						}
						else
						{
							IRange range = \u000D\u0014\u001D.\u000A(\u0010\u0014\u001D.\u000A(u001F), num3, num6);
							\u001C\u0005 u001C_u = new \u001C\u0005();
							string empty = string.Empty;
							\u0012\u0017\u001D.\u000A(u001C_u, \u0017\u0016.\u001F(range, \u001D));
							\u001B\u0017\u001D.\u000A(u001C_u, \u0009\u0020\u001D.\u000A(range));
							\u0008\u0017\u001D.\u000A(u001C_u, \u0001\u0020\u001D.\u000A(range));
							\u0019\u000A\u0004.\u000A(u001C_u, \u0009\u0020\u001D.\u000A(range));
							\u0004\u000A\u0004.\u000A(u001C_u, \u0001\u0020\u001D.\u000A(range));
							\u001D\u000A\u0004.\u000A(u001C_u, num7);
							\u0007\u000A\u0004.\u000A(u001C_u, num10);
							double u000A2 = (double)\u0016\u001A\u001D.\u000A(u001F, num3);
							\u000A\u000A\u0004.\u000A(u001C_u, \u0019\u001A\u001D.\u000A(\u0018\u001A\u001D.\u000A(u001F), u000A2, MeasureUnits.Pixel, MeasureUnits.Millimeter));
							IFont font = \u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(range));
							if (font != null)
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
								\u0010\u0005 u0010_u = \u0016\u0004\u000E.\u001F;
								string u001F2 = string.Empty;
								try
								{
									u001F2 = \u0001\u0017\u001D.\u000A(range);
								}
								catch (Exception u000A3)
								{
									\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Schedule\\ScheduleExcelHandler.cs", "ReadExcelValues");
								}
								bool flag = \u0014\u001E\u001D.\u000A(\u0018\u0006\u001D.\u0007(u001F2), "<font");
								if (flag)
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
									u0010_u = \u000C\u0019.\u0007(u001F2);
									Color color = \u001A\u0017\u001D.\u0007(u0010_u);
									if (\u0015\u0017\u001D.\u000A(ref color) != 0)
									{
										goto IL_360;
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
									color = \u001A\u0017\u001D.\u0007(u0010_u);
									if (\u000C\u0017\u001D.\u000A(ref color) != 0)
									{
										goto IL_360;
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
									color = \u001A\u0017\u001D.\u0007(u0010_u);
									bool flag2 = \u0013\u0017\u001D.\u000A(ref color) == 0;
									IL_361:
									if (!flag2)
									{
										goto IL_3AF;
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
									if (\u0014\u0017\u001D.\u000A(u0010_u))
									{
										goto IL_3AF;
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
									if (\u0017\u0017\u001D.\u000A(u0010_u))
									{
										goto IL_3AF;
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
									if (!\u0020\u0017\u001D.\u000A(u0010_u))
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
										flag = false;
										goto IL_3AF;
									}
									goto IL_3AF;
									IL_360:
									flag2 = false;
									goto IL_361;
								}
								IL_3AF:
								\u001F\u000A\u0004.\u000A(u001C_u, \u000C\u0019.\u0019(\u001C\u001A\u001D.\u000A(range)));
								\u0009\u001F\u0004.\u000A(u001C_u, \u000C\u0019.\u0018(\u0003\u001A\u001D.\u000A(range)));
								object u001F3 = u001C_u;
								\u0010\u0005 u000A4;
								if (!flag)
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
									u000A4 = \u000C\u0019.\u0007(font);
								}
								else
								{
									u000A4 = u0010_u;
								}
								\u000F\u0017\u001D.\u000A(u001F3, u000A4);
								\u0002\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u001C_u), \u0002\u0018.\u0018(font, \u000A\u0014\u001D.\u001D(\u001A\u001F\u0004.\u0007(u001C_u))));
								\u0003\u0017\u001D.\u000A(u001C_u, \u001D\u0013\u001D.\u000A(\u001F\u0014\u001D.\u000A(range)));
								if (\u0007)
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
									\u000B\u0017\u001D.\u000A(u001C_u, \u0015\u001A\u001D.\u000A(\u0011\u001A\u001D.\u000A(font), \u000A\u000C\u001D.\u000A(font), \u001E\u0017\u001D.\u000A(font), \u001F\u000C\u001D.\u000A(font), \u0009\u001A\u001D.\u000A(font), \u0001\u001A\u001D.\u000A(font) > ExcelUnderline.None));
								}
							}
							\u0006\u0014\u001D.\u000A(u001C_u, \u0009\u0014\u001D.\u000A(\u001F\u0014\u001D.\u000A(range)));
							\u0003\u0018.\u0004(range, u001C_u, \u0007);
							if (\u0001\u0014\u001D.\u000A(range))
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
								\u0001\u001F\u0004.\u000A(u001C_u, new \u0008\u0005());
								IRange[] array = \u0017\u0014\u001D.\u000A(\u001E\u0014\u001D.\u000A(range));
								for (int l = 0; l < (int)\u0018\u0004\u000E.\u001F(array); l++)
								{
									IRange u001F4 = array[l];
									\u000E\u0005 u000E_u = new \u000E\u0005();
									\u001B\u001F\u0004.\u000A(u000E_u, \u0001\u0020\u001D.\u000A(u001F4));
									\u0010\u001F\u0004.\u000A(u000E_u, \u0009\u0020\u001D.\u000A(u001F4));
									\u0015\u001F\u0004.\u000A(u000E_u, \u0001\u0020\u001D.\u000A(u001F4));
									\u000C\u001F\u0004.\u000A(u000E_u, \u0009\u0020\u001D.\u000A(u001F4));
									\u000D\u001F\u0004.\u000A(\u0005\u001F\u0004.\u0007(\u0016\u001F\u0004.\u000A(u001C_u)), u000E_u);
									if (\u0009\u0020\u001D.\u000A(\u001E\u0014\u001D.\u000A(range)) == num3)
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
										if (\u0001\u0020\u001D.\u000A(\u001E\u0014\u001D.\u000A(range)) == num6)
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
											\u0003\u0018.\u0004(u001F4, u001C_u, false);
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
								\u0003\u0018.\u0019(Enumerable.FirstOrDefault<IRange>(\u0017\u0014\u001D.\u000A(\u001E\u0014\u001D.\u000A(range))), u001C_u, true);
								\u0003\u0018.\u0019(Enumerable.LastOrDefault<IRange>(\u0017\u0014\u001D.\u000A(\u001E\u0014\u001D.\u000A(range))), u001C_u, false);
							}
							else if (\u001D\u0017\u000A.\u000A(\u000A\u0014\u001D.\u001D(\u001A\u001F\u0004.\u0007(u001C_u)), ""))
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
								if (!\u000E\u0014\u001D.\u000A(range))
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
									\u0003\u0018.\u000A(u001C_u, range, \u000B\u0013\u001D.\u000A(\u001F), \u0016\u0013\u001D.\u000A(\u001F));
								}
							}
							\u0013\u001F\u0004.\u000A(\u0018\u0020\u001D.\u000A(u0006_u), u001C_u);
						}
						k++;
						num6++;
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
				j++;
				num3++;
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
			\u0003\u0018.\u0007(\u0018\u0020\u001D.\u000A(u0006_u), num2 - 1, num5 - 1);
			\u0003\u0018.\u001D(\u0018\u0020\u001D.\u000A(u0006_u), num2 - 1, num5 - 1);
			IEnumerable<\u001C\u0005> enumerable = \u0018\u0020\u001D.\u000A(u0006_u);
			Func<\u001C\u0005, bool> func;
			if ((func = \u0003\u0018.<>c.\u000A) == null)
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
				func = (\u0003\u0018.<>c.\u000A = new Func<\u001C\u0005, bool>(\u0003\u0018.<>c.\u001F.\u0007));
			}
			List<\u001C\u0005> u001F5 = Enumerable.ToList<\u001C\u0005>(Enumerable.Where<\u001C\u0005>(enumerable, func));
			int num11 = 1;
			int num12;
			if (\u001E\u001F\u0004.\u000A(u001F5) <= 50)
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
				num12 = 10;
			}
			else
			{
				num12 = 50;
			}
			num9 = num12;
			List<\u001C\u0005>.Enumerator enumerator = \u0014\u001F\u0004.\u000A(u001F5);
			try
			{
				while (\u0004\u001F\u0004.\u000A(ref enumerator))
				{
					\u001C\u0005 u001F6 = \u0017\u001F\u0004.\u000A(ref enumerator);
					if (num11 % num9 == 0)
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
						if (\u000A != null)
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
							\u001B\u0015\u0007.\u000A(\u000A);
						}
					}
					num11++;
					List<\u000E\u0005> u001F7 = \u0020\u001F\u0004.\u000A();
					List<\u000E\u0005>.Enumerator enumerator2 = \u0003\u001F\u0004.\u000A(\u0005\u001F\u0004.\u0007(\u0016\u001F\u0004.\u000A(u001F6)));
					try
					{
						while (\u0019\u001F\u0004.\u000A(ref enumerator2))
						{
							\u0003\u0018.\u000F\u0018 u000F_u = new \u0003\u0018.\u000F\u0018();
							u000F_u.\u001F = \u0012\u001F\u0004.\u000A(ref enumerator2);
							List<\u001C\u0005> u001F8 = Enumerable.ToList<\u001C\u0005>(Enumerable.Where<\u001C\u0005>(\u0018\u0020\u001D.\u000A(u0006_u), new Func<\u001C\u0005, bool>(u000F_u.\u000A)));
							if (\u001E\u001F\u0004.\u000A(u001F8) > 0)
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
								\u001B\u001F\u0004.\u000A(u000F_u.\u001F, \u0011\u001F\u0004.\u000A(\u0008\u001F\u0004.\u000A(u001F8, 0)));
								\u0010\u001F\u0004.\u000A(u000F_u.\u001F, \u000E\u001F\u0004.\u000A(\u0008\u001F\u0004.\u000A(u001F8, 0)));
							}
							else
							{
								\u000D\u001F\u0004.\u000A(u001F7, u000F_u.\u001F);
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
						((IDisposable)enumerator2).Dispose();
					}
					if (\u001C\u001F\u0004.\u000A(u001F7) > 0)
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
						enumerator2 = \u0003\u001F\u0004.\u000A(u001F7);
						try
						{
							IL_932:
							while (\u0019\u001F\u0004.\u000A(ref enumerator2))
							{
								\u000E\u0005 u001F9 = \u0012\u001F\u0004.\u000A(ref enumerator2);
								List<\u000E\u0005>.Enumerator enumerator3 = \u0003\u001F\u0004.\u000A(Enumerable.ToList<\u000E\u0005>(\u0005\u001F\u0004.\u0007(\u0016\u001F\u0004.\u000A(u001F6))));
								try
								{
									while (\u0019\u001F\u0004.\u000A(ref enumerator3))
									{
										\u000E\u0005 u000E_u2 = \u0012\u001F\u0004.\u000A(ref enumerator3);
										if (\u000F\u001F\u0004.\u000A(u000E_u2) == \u0006\u001F\u0004.\u000A(u001F9))
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
											if (\u0002\u001F\u0004.\u000A(u000E_u2) == \u000B\u001F\u0004.\u000A(u001F9))
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
												\u0018\u001F\u0004.\u000A(\u0005\u001F\u0004.\u0007(\u0016\u001F\u0004.\u000A(u001F6)), u000E_u2);
												goto IL_932;
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
									((IDisposable)enumerator3).Dispose();
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
							((IDisposable)enumerator2).Dispose();
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
			\u001D\u001F\u0004.\u000A(u0006_u, Enumerable.ToList<\u001B\u0005>(\u000B\u0014\u001D.\u000A()));
			return u0006_u;
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00035340 File Offset: 0x00033540
		private static void \u000A(\u001C\u0005 \u001F, IRange \u000A, int \u0007, int \u001D)
		{
			IFont u001F = \u0009\u0017\u001D.\u000A(\u001F\u0014\u001D.\u000A(\u000A));
			FontFamily u001F2 = \u0002\u0018.\u0006(u001F);
			Font u = \u001B\u001A\u001D.\u000A(\u0011\u001A\u001D.\u000A(u001F), (float)\u001E\u0017\u001D.\u000A(u001F), \u0013\u0019.\u000E(u001F2));
			Graphics u001F3 = \u0008\u001A\u001D.\u000A(IntPtr.Zero);
			string text;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u000A(\u001C\u0005, IRange, int, int)).MethodHandle;
				}
				text = null;
			}
			else
			{
				\u001E\u0016 u001E_u = \u001A\u001F\u0004.\u001D(\u001F);
				if (u001E_u == null)
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
					text = null;
				}
				else
				{
					text = \u000A\u0014\u001D.\u0007(u001E_u);
				}
			}
			string text2;
			if ((text2 = text) == null)
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
				text2 = string.Empty;
			}
			string text3 = text2;
			if (\u001A\u0006\u0007.\u000A(text3))
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
					text3 = \u0007\u000C\u001D.\u000A(\u000A);
				}
				catch (Exception u000A)
				{
					text3 = \u0012\u000A\u0004.\u000A(\u000A);
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Schedule\\ScheduleExcelHandler.cs", "MergeToAdjacentCells");
				}
			}
			SizeF sizeF = \u000E\u001A\u001D.\u000A(u001F3, text3, u);
			double num = \u0019\u001A\u001D.\u000A(\u0018\u001A\u001D.\u000A(\u000C\u001E\u001D.\u000A(\u000A)), (double)\u0010\u001A\u001D.\u000A(ref sizeF), MeasureUnits.Pixel, MeasureUnits.Millimeter);
			double u000A2 = (double)\u0005\u001A\u001D.\u000A(\u000C\u001E\u001D.\u000A(\u000A), \u0011\u001F\u0004.\u000A(\u001F));
			double num2 = \u0019\u001A\u001D.\u000A(\u0018\u001A\u001D.\u000A(\u000C\u001E\u001D.\u000A(\u000A)), u000A2, MeasureUnits.Pixel, MeasureUnits.Millimeter);
			if (num2 < num)
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
				int u000A3 = \u000E\u001F\u0004.\u000A(\u001F);
				int num3 = \u0011\u001F\u0004.\u000A(\u001F) + 1;
				do
				{
					IRange u001F4 = \u000F\u000A\u0004.\u000A(\u000C\u001E\u001D.\u000A(\u000A), u000A3, num3);
					bool flag = !\u001C\u0014\u001D.\u000A(\u000C\u001E\u001D.\u000A(u001F4), num3);
					if (\u001D\u0017\u000A.\u000A(\u0003\u0014\u001D.\u000A(u001F4), "") || flag)
					{
						return;
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
					if (\u000A\u0018.\u0018(u001F4))
					{
						return;
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
					if (\u0009\u0020\u001D.\u000A(u001F4) > \u0007)
					{
						return;
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
					if (\u0001\u0020\u001D.\u000A(u001F4) > \u001D)
					{
						return;
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
					if (\u0016\u001F\u0004.\u000A(\u001F) == null)
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
						\u0001\u001F\u0004.\u000A(\u001F, new \u0008\u0005());
						\u000E\u0005 u000E_u = new \u000E\u0005();
						\u001B\u001F\u0004.\u000A(u000E_u, \u0011\u001F\u0004.\u000A(\u001F));
						\u0010\u001F\u0004.\u000A(u000E_u, \u000E\u001F\u0004.\u000A(\u001F));
						\u0015\u001F\u0004.\u000A(u000E_u, \u0011\u001F\u0004.\u000A(\u001F));
						\u000C\u001F\u0004.\u000A(u000E_u, \u000E\u001F\u0004.\u000A(\u001F));
						\u000D\u001F\u0004.\u000A(\u0005\u001F\u0004.\u0007(\u0016\u001F\u0004.\u000A(\u001F)), u000E_u);
					}
					\u000E\u0005 u000E_u2 = new \u000E\u0005();
					\u001B\u001F\u0004.\u000A(u000E_u2, \u0001\u0020\u001D.\u000A(u001F4));
					\u0010\u001F\u0004.\u000A(u000E_u2, \u0009\u0020\u001D.\u000A(u001F4));
					\u0015\u001F\u0004.\u000A(u000E_u2, \u0001\u0020\u001D.\u000A(u001F4));
					\u000C\u001F\u0004.\u000A(u000E_u2, \u0009\u0020\u001D.\u000A(u001F4));
					\u000D\u001F\u0004.\u000A(\u0005\u001F\u0004.\u0007(\u0016\u001F\u0004.\u000A(\u001F)), u000E_u2);
					u000A2 = (double)\u0005\u001A\u001D.\u000A(\u000C\u001E\u001D.\u000A(\u000A), num3);
					num2 += \u0019\u001A\u001D.\u000A(\u0018\u001A\u001D.\u000A(\u000C\u001E\u001D.\u000A(\u000A)), u000A2, MeasureUnits.Pixel, MeasureUnits.Millimeter);
					num3++;
				}
				while (num2 < num);
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
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00035688 File Offset: 0x00033888
		private static void \u0007(List<\u001C\u0005> \u001F, int \u000A, int \u0007)
		{
			List<\u001B\u0005>.Enumerator enumerator = \u0011\u000A\u0004.\u000A(\u000B\u0014\u001D.\u000A());
			try
			{
				while (\u0003\u000A\u0004.\u000A(ref enumerator))
				{
					\u0003\u0018.\u0012\u0018 u0012_u = new \u0003\u0018.\u0012\u0018();
					u0012_u.\u001F = \u001B\u000A\u0004.\u000A(ref enumerator);
					int num = \u000A;
					int num2 = \u0007;
					\u001C\u0005 u001C_u = Enumerable.FirstOrDefault<\u001C\u0005>(\u001F, new Func<\u001C\u0005, bool>(u0012_u.\u000A));
					if (u001C_u != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u0007(List<\u001C\u0005>, int, int)).MethodHandle;
						}
						num += \u0008\u000A\u0004.\u000A(u001C_u);
						num2 += \u000E\u000A\u0004.\u000A(u001C_u);
						\u0010\u000A\u0004.\u000A(u0012_u.\u001F, \u0016\u001F\u0004.\u000A(u001C_u));
					}
					\u001B\u0005 u001F = u0012_u.\u001F;
					\u001F\u0001\u001D.\u000A(u001F, \u000D\u000A\u0004.\u000A(u001F) - num);
					\u001B\u0005 u001F2 = u0012_u.\u001F;
					\u0009\u0015\u001D.\u000A(u001F2, \u001C\u000A\u0004.\u000A(u001F2) - num2);
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
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00035780 File Offset: 0x00033980
		private static void \u001D(List<\u001C\u0005> \u001F, int \u000A, int \u0007)
		{
			List<\u001C\u0005>.Enumerator enumerator = \u0014\u001F\u0004.\u000A(\u001F);
			try
			{
				while (\u0004\u001F\u0004.\u000A(ref enumerator))
				{
					\u001C\u0005 u001C_u = \u0017\u001F\u0004.\u000A(ref enumerator);
					int num = \u000A + \u0008\u000A\u0004.\u000A(u001C_u);
					int num2 = \u0007 + \u000E\u000A\u0004.\u000A(u001C_u);
					\u001C\u0005 u001F = u001C_u;
					\u0019\u000A\u0004.\u000A(u001F, \u000E\u001F\u0004.\u000A(u001F) - num);
					\u001C\u0005 u001F2 = u001C_u;
					\u0004\u000A\u0004.\u000A(u001F2, \u0011\u001F\u0004.\u000A(u001F2) - num2);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u001D(List<\u001C\u0005>, int, int)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x0003581C File Offset: 0x00033A1C
		private static void \u0004(IRange \u001F, \u001C\u0005 \u000A, bool \u0007 = false)
		{
			\u000D\u0005 u000D_u = \u0005\u0007\u0004.\u000A(\u000A);
			if (u000D_u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u0004(IRange, \u001C\u0005, bool)).MethodHandle;
				}
				u000D_u = new \u000D\u0005();
			}
			List<BorderLinestyles> u001F = \u000C\u0019.\u0005(\u001F);
			object u001F2 = u000D_u;
			BorderLinestyles u000A;
			if (\u0018\u0007\u0004.\u000A(u000D_u) == BorderLinestyles.None)
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
				u000A = \u0014\u0014\u001D.\u000A(u001F, 0);
			}
			else
			{
				u000A = \u0018\u0007\u0004.\u000A(u000D_u);
			}
			\u0019\u0007\u0004.\u000A(u001F2, u000A);
			object u001F3 = u000D_u;
			BorderLinestyles u000A2;
			if (\u0004\u0007\u0004.\u000A(u000D_u) == BorderLinestyles.None)
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
				u000A2 = \u0014\u0014\u001D.\u000A(u001F, 1);
			}
			else
			{
				u000A2 = \u0004\u0007\u0004.\u000A(u000D_u);
			}
			\u001D\u0007\u0004.\u000A(u001F3, u000A2);
			object u001F4 = u000D_u;
			BorderLinestyles u000A3;
			if (\u0007\u0007\u0004.\u000A(u000D_u) == BorderLinestyles.None)
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
				u000A3 = \u0014\u0014\u001D.\u000A(u001F, 2);
			}
			else
			{
				u000A3 = \u0007\u0007\u0004.\u000A(u000D_u);
			}
			\u000A\u0007\u0004.\u000A(u001F4, u000A3);
			object u001F5 = u000D_u;
			BorderLinestyles u000A4;
			if (\u001F\u0007\u0004.\u000A(u000D_u) == BorderLinestyles.None)
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
				u000A4 = \u0014\u0014\u001D.\u000A(u001F, 3);
			}
			else
			{
				u000A4 = \u001F\u0007\u0004.\u000A(u000D_u);
			}
			\u0009\u000A\u0004.\u000A(u001F5, u000A4);
			if (\u0007)
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
				IBorders u001F6 = \u0007\u0013\u001D.\u000A(\u001F);
				if (\u0001\u000A\u0004.\u000A(u000D_u) == null)
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
					if (\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeTop)) != ExcelLineStyle.None)
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
						Color u000A5 = \u000F\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeTop));
						\u0015\u000A\u0004.\u000A(u000D_u, \u0006\u001A\u001D.\u000A(\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeTop)), u000A5));
					}
				}
				if (\u000C\u000A\u0004.\u000A(u000D_u) == null)
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
					if (\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeBottom)) != ExcelLineStyle.None)
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
						Color u000A6 = \u000F\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeBottom));
						\u001A\u000A\u0004.\u000A(u000D_u, \u0006\u001A\u001D.\u000A(\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeBottom)), u000A6));
					}
				}
				if (\u0013\u000A\u0004.\u000A(u000D_u) == null)
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
					if (\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeLeft)) != ExcelLineStyle.None)
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
						Color u000A7 = \u000F\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeLeft));
						\u0014\u000A\u0004.\u000A(u000D_u, \u0006\u001A\u001D.\u000A(\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeLeft)), u000A7));
					}
				}
				if (\u0017\u000A\u0004.\u000A(u000D_u) == null)
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
					if (\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeRight)) != ExcelLineStyle.None)
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
						Color u000A8 = \u000F\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeRight));
						\u0020\u000A\u0004.\u000A(u000D_u, \u0006\u001A\u001D.\u000A(\u0012\u001A\u001D.\u000A(\u000A\u0013\u001D.\u000A(u001F6, ExcelBordersIndex.EdgeRight)), u000A8));
					}
				}
			}
			\u001E\u000A\u0004.\u000A(\u000A, u000D_u);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00035AB4 File Offset: 0x00033CB4
		private static void \u0019(IRange \u001F, \u001C\u0005 \u000A, bool \u0007)
		{
			\u000D\u0005 u000D_u = \u0005\u0007\u0004.\u000A(\u000A);
			if (u000D_u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u0019(IRange, \u001C\u0005, bool)).MethodHandle;
				}
				u000D_u = new \u000D\u0005();
			}
			List<BorderLinestyles> u001F = \u000C\u0019.\u0005(\u001F);
			if (\u0007)
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
				\u000A\u0007\u0004.\u000A(u000D_u, \u0014\u0014\u001D.\u000A(u001F, 2));
			}
			else
			{
				\u0009\u000A\u0004.\u000A(u000D_u, \u0014\u0014\u001D.\u000A(u001F, 3));
			}
			\u001E\u000A\u0004.\u000A(\u000A, u000D_u);
		}

		// Token: 0x020007F1 RID: 2033
		[CompilerGenerated]
		private sealed class \u000F\u0018
		{
			// Token: 0x06004D24 RID: 19748 RVA: 0x001DDA3C File Offset: 0x001DBC3C
			internal bool \u000A(\u001C\u0005 \u001F)
			{
				if (\u0018\u0018\u0004.\u000A(\u001F) == \u000B\u001F\u0004.\u000A(this.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u000F\u0018.\u000A(\u001C\u0005)).MethodHandle;
					}
					return \u0016\u0018\u0004.\u000A(\u001F) == \u0006\u001F\u0004.\u000A(this.\u001F);
				}
				return false;
			}

			// Token: 0x04002007 RID: 8199
			public \u000E\u0005 \u001F;
		}

		// Token: 0x020007F2 RID: 2034
		[CompilerGenerated]
		private sealed class \u0012\u0018
		{
			// Token: 0x06004D26 RID: 19750 RVA: 0x001DDAA0 File Offset: 0x001DBCA0
			internal bool \u000A(\u001C\u0005 \u001F)
			{
				if (\u000E\u001F\u0004.\u000A(\u001F) == \u000D\u000A\u0004.\u000A(this.\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0018.\u0012\u0018.\u000A(\u001C\u0005)).MethodHandle;
					}
					return \u0011\u001F\u0004.\u000A(\u001F) == \u001C\u000A\u0004.\u000A(this.\u001F);
				}
				return false;
			}

			// Token: 0x04002008 RID: 8200
			public \u001B\u0005 \u001F;
		}
	}
}
