using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;
using ProSheets.ScheduleAssistant.Model;

namespace ProSheets.ScheduleAssistant
{
	// Token: 0x020000A6 RID: 166
	public static class SchedulerThread
	{
		// Token: 0x17000356 RID: 854
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x0003BABC File Offset: 0x00039CBC
		// (set) Token: 0x060009A0 RID: 2464 RVA: 0x0003BAD0 File Offset: 0x00039CD0
		public static SchedulerTimer SchedulerTimer { get; set; }

		// Token: 0x060009A1 RID: 2465 RVA: 0x0003BAE4 File Offset: 0x00039CE4
		public static void DoStuff()
		{
			for (;;)
			{
				if (\u001F\u0018\u0003.\u0018() != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SchedulerThread.DoStuff()).MethodHandle;
					}
					if (!\u0015\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()))
					{
						DateTime dateTime = \u0011\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
						DateTime u000C = \u000E\u000C\u0016.\u0018(ref dateTime);
						dateTime = \u001F\u0018\u0016.\u0018();
						if (\u0020\u0018\u0016.\u0018(u000C, \u000E\u000C\u0016.\u0018(ref dateTime)))
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
							dateTime = \u0009\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
							int num = \u000A\u0018\u0016.\u0018(ref dateTime);
							dateTime = \u0019\u0015\u0014.\u0018();
							if (num == \u000A\u0018\u0016.\u0018(ref dateTime))
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
								dateTime = \u0009\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
								int num2 = \u0013\u0018\u0016.\u0018(ref dateTime);
								dateTime = \u0019\u0015\u0014.\u0018();
								if (num2 == \u0013\u0018\u0016.\u0018(ref dateTime))
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
										ProSheetCurrentData u000C2 = \u001D\u0020\u0018.\u0016(\u001C\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()));
										ExportTemPlateInfo exportTemPlateInfo = \u0017\u000A\u0014.\u0018(u000C2);
										if (exportTemPlateInfo == null)
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
											continue;
										}
										string u000C3 = \u0018\u001F\u0018.\u0018(\u000D\u0018\u0016.\u0018(u000C2));
										\u0010\u0017\u0014.\u0018(u000C3);
										\u0012\u0018\u0016.\u0018(u000C3);
										\u000D\u0013\u0003.\u0018(\u000F\u0018\u0016.\u0018(u000C2));
										\u001D\u0013\u0003.\u0018(\u0016\u0018\u0016.\u0018(u000C2));
										\u001D\u0020\u0018.\u000F(u000C2, exportTemPlateInfo);
										\u0003\u0018\u0016.\u0018(ExportExternalEvent.HandlerInstance, true);
										object handlerInstance = ExportExternalEvent.HandlerInstance;
										ExportExternalEvent.ExportReportHandler u;
										if ((u = SchedulerThread.\u001F\u0020\u0018.\u000C) == null)
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
											u = (SchedulerThread.\u001F\u0020\u0018.\u000C = new ExportExternalEvent.ExportReportHandler(SchedulerThread.\u0014));
										}
										\u0014\u0018\u0016.\u0018(handlerInstance, u);
										\u001A\u0014\u0014.\u0018(ExportExternalEvent.HandlerEvent);
										\u0013\u0017\u0014.\u0018(60000);
										continue;
									}
									catch (Exception)
									{
										\u0013\u0017\u0014.\u0018(50000);
										continue;
									}
								}
							}
						}
						\u0013\u0017\u0014.\u0018(50000);
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
				\u0013\u0017\u0014.\u0018(60000);
			}
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0003BCD0 File Offset: 0x00039ED0
		private static void \u0018()
		{
			if (\u001F\u0018\u0003.\u0018() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SchedulerThread.\u0018()).MethodHandle;
				}
				return;
			}
			\u0006\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018(), true);
			if (\u001D\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()) != RepeatMode.DoesNotRepeat)
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
				SchedulerTimer schedulerTimer = \u0008\u0018\u0016.\u0018();
				\u0006\u0018\u0016.\u0018(schedulerTimer, false);
				\u0010\u0018\u0016.\u0018(schedulerTimer, \u001D\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()));
				\u0007\u0018\u0016.\u0018(schedulerTimer, \u0004\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()));
				\u0019\u0018\u0016.\u0018(schedulerTimer, \u0009\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()));
				\u000B\u0018\u0016.\u0018(schedulerTimer, \u001C\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()));
				if (\u001D\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()) == RepeatMode.Monthly)
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
					object u000C = schedulerTimer;
					DateTime dateTime = \u0011\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
					\u0017\u0018\u0016.\u0018(u000C, \u001A\u0018\u0016.\u0018(ref dateTime, 1));
				}
				if (\u001D\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()) == RepeatMode.Weekly)
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
					IEnumerable<WeekDay> enumerable = \u0004\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
					Func<WeekDay, DayOfWeek> func;
					if ((func = SchedulerThread.<>c.\u0018) == null)
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
						func = (SchedulerThread.<>c.\u0018 = new Func<WeekDay, DayOfWeek>(SchedulerThread.<>c.\u000C.\u0014));
					}
					List<DayOfWeek> u = Enumerable.ToList<DayOfWeek>(Enumerable.Select<WeekDay, DayOfWeek>(enumerable, func));
					DateTime dateTime = \u0011\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
					int num = (int)\u001D\u0020\u0018.\u001F(\u0002\u0018\u0016.\u0018(ref dateTime), u);
					dateTime = \u0011\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
					int num2 = (num - (int)\u0002\u0018\u0016.\u0018(ref dateTime) + 7) % 7;
					object u000C2 = schedulerTimer;
					dateTime = \u0011\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018());
					\u0017\u0018\u0016.\u0018(u000C2, \u001E\u0018\u0016.\u0018(ref dateTime, (double)num2));
				}
				\u000C\u0015\u0014.\u0018(schedulerTimer);
			}
			else
			{
				\u000C\u0015\u0014.\u0018(\u000E\u000B\u000F.\u000C);
			}
			\u001D\u0020\u0018.\u000C();
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0003BE98 File Offset: 0x0003A098
		private static void \u0014(DateTime \u000C, DateTime \u0018, DateTime \u0014, DateTime \u0003, DateTime \u0016, DateTime \u000F, DateTime \u0012, DateTime \u000D)
		{
			SchedulerThread.\u0018();
			bool flag = true;
			bool u000C = false;
			string u = "";
			if (\u000F\u0002\u0018.\u0018(\u001B\u0018\u0016.\u0018(), \u001C\u0009\u0018.\u0001\u0014))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SchedulerThread.\u0014(DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime, DateTime)).MethodHandle;
				}
				flag = false;
			}
			else if (\u000F\u0002\u0018.\u0018(\u001B\u0018\u0016.\u0018(), \u001C\u0009\u0018.\u0005\u0014))
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
				u000C = true;
				u = \u0003\u001A\u0018.\u0018(\u0015\u0010\u0014.\u0018(), "ProSheets Report.csv");
			}
			else if (\u000F\u0002\u0018.\u0018(\u001B\u0018\u0016.\u0018(), \u001C\u0009\u0018.\u001B\u0014))
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
				u = \u0003\u001A\u0018.\u0018(\u0015\u0010\u0014.\u0018(), "ProSheets Report.xlsx");
			}
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
				try
				{
					\u0009\u001F\u0018.\u000C(u000C, u, \u000C, \u0018, \u0014, \u0003, \u0016, \u000F, \u0012, \u000D);
				}
				catch (Exception u2)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\ScheduleAssistant\\SchedulerThread.cs", "ExportReport");
				}
			}
			object handlerInstance = ExportExternalEvent.HandlerInstance;
			ExportExternalEvent.ExportReportHandler u3;
			if ((u3 = SchedulerThread.\u001F\u0020\u0018.\u000C) == null)
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
				u3 = (SchedulerThread.\u001F\u0020\u0018.\u000C = new ExportExternalEvent.ExportReportHandler(SchedulerThread.\u0014));
			}
			\u0001\u0018\u0016.\u0018(handlerInstance, u3);
		}

		// Token: 0x04000489 RID: 1161
		[CompilerGenerated]
		private static SchedulerTimer \u000C;

		// Token: 0x020001B9 RID: 441
		[CompilerGenerated]
		private static class \u001F\u0020\u0018
		{
			// Token: 0x04000851 RID: 2129
			public static ExportExternalEvent.ExportReportHandler \u000C;
		}
	}
}
