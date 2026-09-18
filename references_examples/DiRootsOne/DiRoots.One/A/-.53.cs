using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TableGen.TGRevitHelper.Script;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000EB RID: 235
	internal static class \u000D\u0018
	{
		// Token: 0x060008A8 RID: 2216 RVA: 0x00035B24 File Offset: 0x00033D24
		internal static void \u001F(Document \u001F, View \u000A, \u0020\u0019 \u0007, CancellationTokenSource \u001D, StyleMappingDto \u0004 = null, List<\u0015\u0005> \u0019 = null, bool \u0018 = true)
		{
			bool flag;
			if (\u0004 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0018.\u001F(Document, View, \u0020\u0019, CancellationTokenSource, StyleMappingDto, List<\u0015\u0005>, bool)).MethodHandle;
				}
				flag = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(\u0004));
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
			try
			{
				\u0017\u0001\u000A.\u000A(transaction, "Create Tables");
				ViewSchedule u001F = \u001A\u0004\u000E.\u001F(\u000A);
				ElementId u000A = \u001B\u0009\u001D.\u000A(-1002500);
				ScheduleFieldId u001F2 = \u000C\u0004\u000E.\u001F;
				SchedulableField u000A2 = \u0015\u0004\u000E.\u001F;
				IEnumerator<SchedulableField> enumerator = \u000C\u0004\u0004.\u000A(\u0015\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F)));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						SchedulableField schedulableField = \u001A\u0004\u0004.\u000A(enumerator);
						if (\u0011\u0016\u001D.\u000A(\u0013\u0004\u0004.\u000A(schedulableField), u000A))
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
							u000A2 = schedulableField;
							goto IL_DB;
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
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				IL_DB:
				int num = \u0017\u0004\u0004.\u000A(\u0014\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F)));
				bool flag3 = false;
				for (int i = 0; i < num; i++)
				{
					ScheduleFieldId scheduleFieldId = \u0020\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), i);
					if (\u0011\u0016\u001D.\u000A(\u0011\u0004\u0004.\u000A(\u001E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), scheduleFieldId)), u000A))
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
						u001F2 = scheduleFieldId;
						flag3 = true;
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
				if (!flag3)
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
					u001F2 = \u0008\u0004\u0004.\u000A(\u001B\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), u000A2));
				}
				while (\u0010\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F)) > 0)
				{
					\u000E\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), 0);
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
				\u000D\u0004\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), false);
				TableSectionData u001F3 = \u0003\u0004\u0004.\u000A(\u001C\u0004\u0004.\u000A(u001F), 1);
				TableSectionData tableSectionData = \u0003\u0004\u0004.\u000A(\u001C\u0004\u0004.\u000A(u001F), 0);
				do
				{
					\u0012\u0004\u0004.\u000A(tableSectionData, 0);
				}
				while (\u000F\u0004\u0004.\u000A(tableSectionData) > 0);
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				do
				{
					\u0006\u0004\u0004.\u000A(tableSectionData, 0);
				}
				while (\u0002\u0004\u0004.\u000A(tableSectionData) > 0);
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				int num2 = \u000E\u001F\u0004.\u000A(Enumerable.Last<\u001C\u0005>(\u000C\u001D\u0004.\u0007(\u0007)));
				int num3 = \u0004\u0004\u0004.\u000A(\u0019\u0004\u0004.\u000A(\u0007));
				for (int j = 0; j <= num2; j++)
				{
					\u000B\u0004\u0004.\u000A(tableSectionData, 0);
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
				for (int k = 0; k < num3; k++)
				{
					\u0016\u0004\u0004.\u000A(tableSectionData, 0);
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
				if (\u0018)
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
					double num4 = 0.0;
					for (int l = 0; l < \u0004\u0004\u0004.\u000A(\u0019\u0004\u0004.\u000A(\u0007)); l++)
					{
						double num5 = \u001B\u0018.\u001F(\u0018\u0004\u0004.\u000A(\u0005\u0004\u0004.\u000A(\u0019\u0004\u0004.\u000A(\u0007), l)));
						\u0007\u0004\u0004.\u000A(tableSectionData, l, num5);
						num4 += num5;
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
					double u001F4 = \u001D\u0004\u0004.\u000A(u001F3, 0);
					if (\u0016\u001F\u0007.\u000A(num4, 8) != \u0016\u001F\u0007.\u000A(u001F4, 8))
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
						\u0007\u0004\u0004.\u000A(u001F3, 0, num4);
					}
				}
				List<\u0008\u0005> u001F5 = \u000A\u0004\u0004.\u000A();
				List<\u001C\u0005>.Enumerator enumerator2 = \u0014\u001F\u0004.\u000A(\u000C\u001D\u0004.\u0007(\u0007));
				try
				{
					while (\u0004\u001F\u0004.\u000A(ref enumerator2))
					{
						\u001C\u0005 u001F6 = \u0017\u001F\u0004.\u000A(ref enumerator2);
						if (\u0016\u001F\u0004.\u000A(u001F6) != null)
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
							if (!\u001F\u0004\u0004.\u000A(u001F5, \u0016\u001F\u0004.\u000A(u001F6)))
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
								TableMergedCell u000A3 = \u0009\u001D\u0004.\u000A(\u0016\u001F\u0004.\u000A(u001F6).\u000A, \u0016\u001F\u0004.\u000A(u001F6).\u0007, \u0016\u001F\u0004.\u000A(u001F6).\u001D, \u0016\u001F\u0004.\u000A(u001F6).\u0004);
								\u0001\u001D\u0004.\u000A(tableSectionData, u000A3);
								\u0015\u001D\u0004.\u000A(u001F5, \u0016\u001F\u0004.\u000A(u001F6));
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
					((IDisposable)enumerator2).Dispose();
				}
				enumerator2 = \u0014\u001F\u0004.\u000A(\u000C\u001D\u0004.\u0007(\u0007));
				try
				{
					while (\u0004\u001F\u0004.\u000A(ref enumerator2))
					{
						\u001C\u0005 u001F7 = \u0017\u001F\u0004.\u000A(ref enumerator2);
						if (\u0004\u0013\u001D.\u0007(\u001D))
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
							throw \u001A\u001D\u0004.\u000A();
						}
						try
						{
							TableCellStyle tableCellStyle = \u0013\u001D\u0004.\u000A();
							TableCellStyleOverrideOptions tableCellStyleOverrideOptions = \u0014\u001D\u0004.\u000A();
							\u0017\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0020\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u001E\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0011\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u001B\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0008\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u000E\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0010\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u000D\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u001C\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0003\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0012\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u000F\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0006\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							\u0002\u001D\u0004.\u000A(tableCellStyleOverrideOptions, true);
							TableCellStyleOverrideOptions u000A4 = tableCellStyleOverrideOptions;
							\u000B\u001D\u0004.\u000A(tableCellStyle, u000A4);
							bool flag4 = false;
							if (flag2)
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
								if (\u0004\u001D\u0004.\u000A(u001F7) != null)
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
									flag4 = true;
									\u000A\u001D\u0004.\u000A(tableCellStyle, \u0016\u001D\u0004.\u0007(\u0004\u001D\u0004.\u000A(u001F7)));
									\u0009\u0007\u0004.\u000A(tableCellStyle, \u0009\u0018.\u001D(\u0004\u001D\u0004.\u000A(u001F7), \u0004, \u001F));
									\u0001\u0007\u0004.\u000A(tableCellStyle, \u0005\u001D\u0004.\u0007(\u0004\u001D\u0004.\u000A(u001F7)).\u001F());
									\u0015\u0007\u0004.\u000A(tableCellStyle, \u0018\u001D\u0004.\u0007(\u0004\u001D\u0004.\u000A(u001F7)));
									\u000C\u0007\u0004.\u000A(tableCellStyle, \u0019\u001D\u0004.\u0007(\u0004\u001D\u0004.\u000A(u001F7)));
									\u001A\u0007\u0004.\u000A(tableCellStyle, \u001D\u001D\u0004.\u0007(\u0004\u001D\u0004.\u000A(u001F7)));
									goto IL_652;
								}
							}
							if (\u0006\u0017\u001D.\u000A(u001F7) != null)
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
								flag4 = true;
								\u000A\u001D\u0004.\u000A(tableCellStyle, \u0007\u001D\u0004.\u000A(\u0006\u0017\u001D.\u000A(u001F7)));
								\u0009\u0007\u0004.\u000A(tableCellStyle, \u001F\u001D\u0004.\u000A(\u0006\u0017\u001D.\u000A(u001F7)));
								\u0001\u0007\u0004.\u000A(tableCellStyle, \u001A\u0017\u001D.\u0007(\u0006\u0017\u001D.\u000A(u001F7)).\u001F());
								\u0015\u0007\u0004.\u000A(tableCellStyle, \u0017\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u001F7)));
								\u000C\u0007\u0004.\u000A(tableCellStyle, \u0014\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u001F7)));
								\u001A\u0007\u0004.\u000A(tableCellStyle, \u0020\u0017\u001D.\u000A(\u0006\u0017\u001D.\u000A(u001F7)));
							}
							IL_652:
							if (flag4)
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
								if (\u0013\u0007\u0004.\u000A(u001F7) == HorizontalAlignments.Left)
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
									\u0014\u0007\u0004.\u000A(tableCellStyle, 0);
								}
								else if (\u0013\u0007\u0004.\u000A(u001F7) == HorizontalAlignments.Center)
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
									\u0014\u0007\u0004.\u000A(tableCellStyle, 1);
								}
								else if (\u0013\u0007\u0004.\u000A(u001F7) == HorizontalAlignments.Right)
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
									\u0014\u0007\u0004.\u000A(tableCellStyle, 2);
								}
								if (\u0017\u0007\u0004.\u000A(u001F7) == VerticalAlignments.Middle)
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
									\u0020\u0007\u0004.\u000A(tableCellStyle, 4);
								}
								else if (\u0017\u0007\u0004.\u000A(u001F7) == VerticalAlignments.Bottom)
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
									\u0020\u0007\u0004.\u000A(tableCellStyle, 8);
								}
								else if (\u0017\u0007\u0004.\u000A(u001F7) == VerticalAlignments.Top)
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
									\u0020\u0007\u0004.\u000A(tableCellStyle, 0);
								}
							}
							if (flag2)
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
								\u000D\u0018.\u0019(\u001F, tableCellStyle, \u0005\u0007\u0004.\u000A(u001F7), \u0004, \u0019);
							}
							else
							{
								\u000D\u0018.\u0004(\u001F, tableCellStyle, \u0005\u0007\u0004.\u000A(u001F7));
							}
							Color color = \u0011\u0007\u0004.\u000A(u001F7);
							if (!\u001E\u0007\u0004.\u000A(ref color))
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
								object u001F8 = tableCellStyle;
								color = \u0011\u0007\u0004.\u000A(u001F7);
								byte u001F9 = \u0015\u0017\u001D.\u000A(ref color);
								color = \u0011\u0007\u0004.\u000A(u001F7);
								byte u000A5 = \u000C\u0017\u001D.\u000A(ref color);
								color = \u0011\u0007\u0004.\u000A(u001F7);
								\u001B\u0007\u0004.\u000A(u001F8, \u001C\u000C\u001D.\u000A(u001F9, u000A5, \u0013\u0017\u001D.\u000A(ref color)));
							}
							\u000E\u0007\u0004.\u000A(tableCellStyle, \u0008\u0007\u0004.\u000A(u001F7) * 10);
							\u0010\u0007\u0004.\u000A(tableSectionData, \u000E\u001F\u0004.\u000A(u001F7), \u0011\u001F\u0004.\u000A(u001F7), tableCellStyle);
							\u000D\u0007\u0004.\u000A(tableSectionData, \u000E\u001F\u0004.\u000A(u001F7), \u0011\u001F\u0004.\u000A(u001F7), \u0014\u0016.\u0004(\u001A\u001F\u0004.\u0007(u001F7), ScriptRenderMode.FallbackUnicode));
							if (\u0018)
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
								double u001F10;
								if (!flag2)
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
									u001F10 = \u001C\u0007\u0004.\u000A(u001F7) + 0.2688;
								}
								else
								{
									u001F10 = \u001C\u0007\u0004.\u000A(u001F7);
								}
								double u = \u001B\u0018.\u001F(u001F10);
								\u0003\u0007\u0004.\u000A(tableSectionData, \u000E\u001F\u0004.\u000A(u001F7), u);
							}
						}
						catch (Exception u000A6)
						{
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A6, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Schedule\\ScheduleHandler.cs", "CreateSchedule");
							throw;
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
				\u000D\u0018.\u001D(\u001F, tableSectionData, \u0012\u0007\u0004.\u000A(\u0007), num3, num2);
				if (\u000F\u0007\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F)) > 0)
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
					if (\u0006\u0007\u0004.\u000A(u001F2, \u000C\u0004\u000E.\u001F))
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
						ScheduleFilter u000A7 = \u0002\u0007\u0004.\u000A(u001F2, 2, "NO VALUES FOUND");
						ScheduleFilter u000A8 = \u0002\u0007\u0004.\u000A(u001F2, 2, "ALL VALUES FOUND");
						\u0016\u0007\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), u000A7);
						\u0016\u0007\u0004.\u000A(\u000B\u0007\u0004.\u000A(u001F), u000A8);
					}
				}
				\u001B\u0001\u000A.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00036504 File Offset: 0x00034704
		internal static void \u000A(Document \u001F, View \u000A, \u0020\u0019 \u0007, CancellationTokenSource \u001D, StyleMappingDto \u0004 = null, List<\u0015\u0005> \u0019 = null)
		{
			bool flag;
			if (\u0004 != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0018.\u000A(Document, View, \u0020\u0019, CancellationTokenSource, StyleMappingDto, List<\u0015\u0005>)).MethodHandle;
				}
				flag = \u0001\u0004\u0004.\u0007(\u0009\u0004\u0004.\u0007(\u0004));
			}
			else
			{
				flag = false;
			}
			bool flag2 = flag;
			ViewSchedule u001F = \u001A\u0004\u000E.\u001F(\u000A);
			TableSectionData u001F2 = \u0003\u0004\u0004.\u000A(\u001C\u0004\u0004.\u000A(u001F), 0);
			int num = \u0002\u0004\u0004.\u000A(u001F2);
			int num2 = \u000F\u0004\u0004.\u000A(u001F2);
			double[] array = \u0003\u0009\u0010.\u001F(num);
			for (int i = 0; i < num; i++)
			{
				array[i] = \u001D\u0004\u0004.\u000A(u001F2, i);
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
			double[] array2 = \u0003\u0009\u0010.\u001F(num2);
			for (int j = 0; j < num2; j++)
			{
				array2[j] = \u000A\u0019\u0004.\u000A(u001F2, j);
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
			\u000D\u0018.\u001F(\u001F, \u000A, \u0007, \u001D, \u0004, \u0019, false);
			Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
			try
			{
				\u0017\u0001\u000A.\u000A(transaction, "TableGen Preserve Column/Row Sizes");
				int num3 = \u0002\u0004\u0004.\u000A(u001F2);
				int num4 = \u000F\u0004\u0004.\u000A(u001F2);
				int num5 = \u001F\u0019\u0004.\u000A(num, num3);
				for (int k = 0; k < num5; k++)
				{
					\u0007\u0004\u0004.\u000A(u001F2, k, array[k]);
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
				int num6 = \u001F\u0019\u0004.\u000A(num2, num4);
				for (int l = 0; l < num6; l++)
				{
					\u0003\u0007\u0004.\u000A(u001F2, l, array2[l]);
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
				int m = num;
				while (m < num3)
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
					if (m >= \u0004\u0004\u0004.\u000A(\u0019\u0004\u0004.\u000A(\u0007)))
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							goto IL_1C7;
						}
					}
					else
					{
						double u = \u001B\u0018.\u001F(\u0018\u0004\u0004.\u000A(\u0005\u0004\u0004.\u000A(\u0019\u0004\u0004.\u000A(\u0007), m)));
						\u0007\u0004\u0004.\u000A(u001F2, m, u);
						m++;
					}
				}
				IL_1C7:
				List<\u001C\u0005>.Enumerator enumerator = \u0014\u001F\u0004.\u000A(\u000C\u001D\u0004.\u0007(\u0007));
				try
				{
					while (\u0004\u001F\u0004.\u000A(ref enumerator))
					{
						\u001C\u0005 u001F3 = \u0017\u001F\u0004.\u000A(ref enumerator);
						if (\u000E\u001F\u0004.\u000A(u001F3) >= num2)
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
							if (\u000E\u001F\u0004.\u000A(u001F3) < num4)
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
								double u001F4;
								if (!flag2)
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
									u001F4 = \u001C\u0007\u0004.\u000A(u001F3) + 0.2688;
								}
								else
								{
									u001F4 = \u001C\u0007\u0004.\u000A(u001F3);
								}
								double u2 = \u001B\u0018.\u001F(u001F4);
								\u0003\u0007\u0004.\u000A(u001F2, \u000E\u001F\u0004.\u000A(u001F3), u2);
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
					((IDisposable)enumerator).Dispose();
				}
				double num7 = 0.0;
				for (int n = 0; n < num3; n++)
				{
					num7 += \u001D\u0004\u0004.\u000A(u001F2, n);
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
				TableSectionData u001F5 = \u0003\u0004\u0004.\u000A(\u001C\u0004\u0004.\u000A(u001F), 1);
				double u001F6 = \u001D\u0004\u0004.\u000A(u001F5, 0);
				if (\u0016\u001F\u0007.\u000A(num7, 8) != \u0016\u001F\u0007.\u000A(u001F6, 8))
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
					\u0007\u0004\u0004.\u000A(u001F5, 0, num7);
				}
				\u001B\u0001\u000A.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00036868 File Offset: 0x00034A68
		internal unsafe static void \u0007(Document \u001F, View \u000A, \u0020\u0019 \u0007, CancellationTokenSource \u001D, out int \u0004, out int \u0019, out int \u0018, out int \u0005)
		{
			\u0004 = 0;
			\u0019 = 0;
			\u0018 = 0;
			\u0005 = 0;
			TableSectionData u001F = \u0003\u0004\u0004.\u000A(\u001C\u0004\u0004.\u000A(\u001A\u0004\u000E.\u001F(\u000A)), 0);
			int num = \u000F\u0004\u0004.\u000A(u001F);
			int num2 = \u0002\u0004\u0004.\u000A(u001F);
			Transaction transaction = \u0013\u0001\u000A.\u000A(\u001F);
			try
			{
				\u0017\u0001\u000A.\u000A(transaction, "TableGen Update Data Only");
				List<\u001C\u0005>.Enumerator enumerator = \u0014\u001F\u0004.\u000A(\u000C\u001D\u0004.\u0007(\u0007));
				try
				{
					while (\u0004\u001F\u0004.\u000A(ref enumerator))
					{
						\u001C\u0005 u001F2 = \u0017\u001F\u0004.\u000A(ref enumerator);
						if (\u0004\u0013\u001D.\u0007(\u001D))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0018.\u0007(Document, View, \u0020\u0019, CancellationTokenSource, int*, int*, int*, int*)).MethodHandle;
							}
							throw \u001A\u001D\u0004.\u000A();
						}
						if (\u000E\u001F\u0004.\u000A(u001F2) >= 0)
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
							if (\u000E\u001F\u0004.\u000A(u001F2) < num)
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
								if (\u0011\u001F\u0004.\u000A(u001F2) >= 0)
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
									if (\u0011\u001F\u0004.\u000A(u001F2) < num2)
									{
										try
										{
											\u000D\u0007\u0004.\u000A(u001F, \u000E\u001F\u0004.\u000A(u001F2), \u0011\u001F\u0004.\u000A(u001F2), \u0014\u0016.\u0004(\u001A\u001F\u0004.\u0007(u001F2), ScriptRenderMode.FallbackUnicode));
											\u0004++;
										}
										catch (Exception u000A)
										{
											\u0019++;
											\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Schedule\\ScheduleHandler.cs", "UpdateDataOnly");
										}
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
							}
						}
						\u0019++;
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
				List<\u001B\u0005> list;
				if ((list = \u0012\u0007\u0004.\u000A(\u0007)) == null)
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
					list = \u000F\u0015\u001D.\u000A();
				}
				List<\u001B\u0005> u001F3 = list;
				HashSet<ValueTuple<int, int>> u001F4 = \u0006\u0019\u0004.\u000A();
				List<\u001B\u0005>.Enumerator enumerator2 = \u0011\u000A\u0004.\u000A(u001F3);
				try
				{
					while (\u0003\u000A\u0004.\u000A(ref enumerator2))
					{
						\u001B\u0005 u001B_u = \u001B\u000A\u0004.\u000A(ref enumerator2);
						if (u001B_u != null)
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
							int num3;
							if (\u0018\u0019\u0004.\u000A(u001B_u) == null)
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
								num3 = \u000D\u000A\u0004.\u000A(u001B_u);
							}
							else
							{
								num3 = \u0018\u0019\u0004.\u000A(u001B_u).\u000A;
							}
							int num4 = num3;
							int num5;
							if (\u0018\u0019\u0004.\u000A(u001B_u) == null)
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
								num5 = \u001C\u000A\u0004.\u000A(u001B_u);
							}
							else
							{
								num5 = \u0018\u0019\u0004.\u000A(u001B_u).\u0007;
							}
							int num6 = num5;
							if (num4 >= 0)
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
								if (num4 < num)
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
									if (num6 >= 0)
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
										if (num6 < num2)
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
											\u0002\u0019\u0004.\u000A(u001F4, new ValueTuple<int, int>(num4, num6));
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
					((IDisposable)enumerator2).Dispose();
				}
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < num2; j++)
					{
						if (\u0004\u0013\u001D.\u0007(\u001D))
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
							throw \u001A\u001D\u0004.\u000A();
						}
						if (!\u000B\u0019\u0004.\u000A(u001F4, new ValueTuple<int, int>(i, j)))
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
							try
							{
								if (\u0016\u0019\u0004.\u000A(u001F, i, j) == 1)
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
									\u0005\u0019\u0004.\u000A(u001F, i, j);
								}
							}
							catch (Exception u000A2)
							{
								\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Schedule\\ScheduleHandler.cs", "UpdateDataOnly");
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
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				enumerator2 = \u0011\u000A\u0004.\u000A(u001F3);
				try
				{
					while (\u0003\u000A\u0004.\u000A(ref enumerator2))
					{
						\u001B\u0005 u001B_u2 = \u001B\u000A\u0004.\u000A(ref enumerator2);
						if (\u0004\u0013\u001D.\u0007(\u001D))
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
							throw \u001A\u001D\u0004.\u000A();
						}
						if (!u001B_u2.\u0002())
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
							\u0005++;
						}
						else
						{
							int num7;
							if (\u0018\u0019\u0004.\u000A(u001B_u2) == null)
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
								num7 = \u000D\u000A\u0004.\u000A(u001B_u2);
							}
							else
							{
								num7 = \u0018\u0019\u0004.\u000A(u001B_u2).\u000A;
							}
							int num8 = num7;
							int num9;
							if (\u0018\u0019\u0004.\u000A(u001B_u2) == null)
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
								num9 = \u001C\u000A\u0004.\u000A(u001B_u2);
							}
							else
							{
								num9 = \u0018\u0019\u0004.\u000A(u001B_u2).\u0007;
							}
							int num10 = num9;
							if (num8 >= 0)
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
								if (num8 < num)
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
									if (num10 >= 0)
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
										if (num10 < num2)
										{
											try
											{
												ImageTypeOptions u000A3 = \u0019\u0019\u0004.\u000A(\u0007\u0019\u0004.\u0007(u001B_u2), false, 1);
												ImageType u001F5 = \u0004\u0019\u0004.\u000A(\u001F, u000A3);
												\u001D\u0019\u0004.\u000A(u001F, num8, num10, \u0002\u001E\u000A.\u0007(u001F5));
												\u0018++;
											}
											catch (Exception u000A4)
											{
												\u0005++;
												\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A4, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\Schedule\\ScheduleHandler.cs", "UpdateDataOnly");
											}
											finally
											{
												\u000A\u0018.\u0005(\u0007\u0019\u0004.\u0007(u001B_u2));
											}
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
								}
							}
							\u0005++;
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
					((IDisposable)enumerator2).Dispose();
				}
				\u0018\u0018.\u001F(\u001F);
				\u001B\u0001\u000A.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00036E60 File Offset: 0x00035060
		internal static void \u001D(Document \u001F, TableSectionData \u000A, List<\u001B\u0005> \u0007, int \u001D, int \u0004)
		{
			List<\u001B\u0005>.Enumerator enumerator = \u0011\u000A\u0004.\u000A(\u0007);
			try
			{
				while (\u0003\u000A\u0004.\u000A(ref enumerator))
				{
					\u001B\u0005 u001B_u = \u001B\u000A\u0004.\u000A(ref enumerator);
					if (u001B_u.\u0002())
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0018.\u001D(Document, TableSectionData, List<\u001B\u0005>, int, int)).MethodHandle;
						}
						ImageTypeOptions u000A = \u0019\u0019\u0004.\u000A(\u0007\u0019\u0004.\u0007(u001B_u), false, 1);
						ImageType u001F = \u0004\u0019\u0004.\u000A(\u001F, u000A);
						if (\u0018\u0019\u0004.\u000A(u001B_u) != null)
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
							if (\u000D\u000A\u0004.\u000A(u001B_u) < 0)
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
								\u001F\u0001\u001D.\u000A(u001B_u, 0);
							}
							if (\u001C\u000A\u0004.\u000A(u001B_u) < 0)
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
								\u0009\u0015\u001D.\u000A(u001B_u, 0);
							}
							try
							{
								\u001D\u0019\u0004.\u000A(\u000A, \u0018\u0019\u0004.\u000A(u001B_u).\u000A, \u0018\u0019\u0004.\u000A(u001B_u).\u0007, \u0002\u001E\u000A.\u0007(u001F));
								goto IL_29B;
							}
							catch (Exception u001F2)
							{
								if (\u000F\u000C\u001D.\u0007(\u0018\u0006\u001D.\u0007(\u0003\u001A\u000A.\u000A(u001F2)), "ncolumn"))
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
									int u000A2;
									if (\u0018\u0019\u0004.\u000A(u001B_u).\u000A <= 0)
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
										u000A2 = 0;
									}
									else
									{
										u000A2 = \u0018\u0019\u0004.\u000A(u001B_u).\u000A - 1;
									}
									int u;
									if (\u0018\u0019\u0004.\u000A(u001B_u).\u0007 <= 0)
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
										u = 0;
									}
									else
									{
										u = \u0018\u0019\u0004.\u000A(u001B_u).\u0007 - 1;
									}
									\u001D\u0019\u0004.\u000A(\u000A, u000A2, u, \u0002\u001E\u000A.\u0007(u001F));
								}
								goto IL_29B;
							}
							goto IL_16F;
						}
						goto IL_16F;
						IL_29B:
						\u000A\u0018.\u0005(\u0007\u0019\u0004.\u0007(u001B_u));
						continue;
						IL_16F:
						if (\u000D\u000A\u0004.\u000A(u001B_u) > \u0004)
						{
							goto IL_29B;
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
						if (\u001C\u000A\u0004.\u000A(u001B_u) <= \u001D)
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
							if (\u000D\u000A\u0004.\u000A(u001B_u) < 0)
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
								\u001F\u0001\u001D.\u000A(u001B_u, 0);
							}
							if (\u001C\u000A\u0004.\u000A(u001B_u) < 0)
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
								\u0009\u0015\u001D.\u000A(u001B_u, 0);
							}
							try
							{
								\u001D\u0019\u0004.\u000A(\u000A, \u000D\u000A\u0004.\u000A(u001B_u), \u001C\u000A\u0004.\u000A(u001B_u), \u0002\u001E\u000A.\u0007(u001F));
							}
							catch (Exception u001F3)
							{
								if (\u000F\u000C\u001D.\u0007(\u0018\u0006\u001D.\u0007(\u0003\u001A\u000A.\u000A(u001F3)), "ncolumn"))
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
									\u001B\u0005 u001F4 = u001B_u;
									\u0009\u0015\u001D.\u000A(u001F4, \u001C\u000A\u0004.\u000A(u001F4) - 1);
									\u001B\u0005 u001F5 = u001B_u;
									\u001F\u0001\u001D.\u000A(u001F5, \u000D\u000A\u0004.\u000A(u001F5) - 1);
									if (\u000D\u000A\u0004.\u000A(u001B_u) < 0)
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
										\u001F\u0001\u001D.\u000A(u001B_u, 0);
									}
									if (\u001C\u000A\u0004.\u000A(u001B_u) < 0)
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
										\u0009\u0015\u001D.\u000A(u001B_u, 0);
									}
									\u001D\u0019\u0004.\u000A(\u000A, \u000D\u000A\u0004.\u000A(u001B_u), \u001C\u000A\u0004.\u000A(u001B_u), \u0002\u001E\u000A.\u0007(u001F));
								}
							}
							goto IL_29B;
						}
						goto IL_29B;
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
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0003718C File Offset: 0x0003538C
		internal static void \u0004(Document \u001F, TableCellStyle \u000A, \u000D\u0005 \u0007)
		{
			if (\u0018\u0007\u0004.\u000A(\u0007) != BorderLinestyles.None)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0018.\u0004(Document, TableCellStyle, \u000D\u0005)).MethodHandle;
				}
				ElementId elementId = \u001D\u0018.\u0018(\u001F, \u0018\u0007\u0004.\u000A(\u0007));
				if (\u001B\u001B\u001D.\u000A(elementId, Constants.InvalidElementId))
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
					\u001C\u0019\u0004.\u000A(\u000A, elementId);
				}
			}
			if (\u001F\u0007\u0004.\u000A(\u0007) != BorderLinestyles.None)
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
				ElementId elementId2 = \u001D\u0018.\u0018(\u001F, \u001F\u0007\u0004.\u000A(\u0007));
				if (\u001B\u001B\u001D.\u000A(elementId2, Constants.InvalidElementId))
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
					\u0003\u0019\u0004.\u000A(\u000A, elementId2);
				}
			}
			if (\u0004\u0007\u0004.\u000A(\u0007) != BorderLinestyles.None)
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
				ElementId elementId3 = \u001D\u0018.\u0018(\u001F, \u0004\u0007\u0004.\u000A(\u0007));
				if (\u001B\u001B\u001D.\u000A(elementId3, Constants.InvalidElementId))
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
					\u0012\u0019\u0004.\u000A(\u000A, elementId3);
				}
			}
			if (\u0007\u0007\u0004.\u000A(\u0007) != BorderLinestyles.None)
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
				ElementId elementId4 = \u001D\u0018.\u0018(\u001F, \u0007\u0007\u0004.\u000A(\u0007));
				if (\u001B\u001B\u001D.\u000A(elementId4, Constants.InvalidElementId))
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
					\u000F\u0019\u0004.\u000A(\u000A, elementId4);
				}
			}
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x000372B8 File Offset: 0x000354B8
		private static void \u0019(Document \u001F, TableCellStyle \u000A, \u000D\u0005 \u0007, StyleMappingDto \u001D, List<\u0015\u0005> \u0004)
		{
			\u000D\u0018.\u001C\u0018 u001C_u = new \u000D\u0018.\u001C\u0018();
			u001C_u.\u001F = \u000A;
			\u000D\u0018.\u0018(\u001F, \u0001\u000A\u0004.\u000A(\u0007), \u0018\u0007\u0004.\u000A(\u0007), \u001D, \u0004, new Action<ElementId>(u001C_u.\u000A));
			\u000D\u0018.\u0018(\u001F, \u0017\u000A\u0004.\u000A(\u0007), \u001F\u0007\u0004.\u000A(\u0007), \u001D, \u0004, new Action<ElementId>(u001C_u.\u0007));
			\u000D\u0018.\u0018(\u001F, \u000C\u000A\u0004.\u000A(\u0007), \u0004\u0007\u0004.\u000A(\u0007), \u001D, \u0004, new Action<ElementId>(u001C_u.\u001D));
			\u000D\u0018.\u0018(\u001F, \u0013\u000A\u0004.\u000A(\u0007), \u0007\u0007\u0004.\u000A(\u0007), \u001D, \u0004, new Action<ElementId>(u001C_u.\u0004));
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x00037368 File Offset: 0x00035568
		private static void \u0018(Document \u001F, ExcelLineStyleInfo \u000A, BorderLinestyles \u0007, StyleMappingDto \u001D, List<\u0015\u0005> \u0004, Action<ElementId> \u0019)
		{
			if (\u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000D\u0018.\u0018(Document, ExcelLineStyleInfo, BorderLinestyles, StyleMappingDto, List<\u0015\u0005>, Action<ElementId>)).MethodHandle;
				}
				return;
			}
			ElementId elementId = \u0001\u0018.\u0004(\u001F, \u000A, \u0007, \u001D, \u0004);
			if (\u001B\u001B\u001D.\u000A(elementId, Constants.InvalidElementId))
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
				\u000D\u0019\u0004.\u000A(\u0019, elementId);
			}
		}

		// Token: 0x020007F3 RID: 2035
		[CompilerGenerated]
		private sealed class \u001C\u0018
		{
			// Token: 0x06004D28 RID: 19752 RVA: 0x001DDB04 File Offset: 0x001DBD04
			internal void \u000A(ElementId \u001F)
			{
				\u001C\u0019\u0004.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x06004D29 RID: 19753 RVA: 0x001DDB20 File Offset: 0x001DBD20
			internal void \u0007(ElementId \u001F)
			{
				\u0003\u0019\u0004.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x06004D2A RID: 19754 RVA: 0x001DDB3C File Offset: 0x001DBD3C
			internal void \u001D(ElementId \u001F)
			{
				\u0012\u0019\u0004.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x06004D2B RID: 19755 RVA: 0x001DDB58 File Offset: 0x001DBD58
			internal void \u0004(ElementId \u001F)
			{
				\u000F\u0019\u0004.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x04002009 RID: 8201
			public TableCellStyle \u001F;
		}
	}
}
