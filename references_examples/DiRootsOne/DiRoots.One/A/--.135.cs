using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.SheetLink.SheetLink.Core.Models.ScheduleTreeView;
using DiRoots.One.SheetLink.UI.Controls;

namespace A
{
	// Token: 0x02000266 RID: 614
	internal static class \u0002\u0010
	{
		// Token: 0x060018CE RID: 6350 RVA: 0x000A0EFC File Offset: 0x0009F0FC
		public static List<ScheduleInfo> \u001F(IList<ICategoryModel> \u001F, BrowserOrganization \u000A)
		{
			ScheduleInfo u001F = \u000D\u001A\u0005.\u000A();
			IEnumerator<ICategoryModel> enumerator = \u0013\u001C\u0018.\u000A(\u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ScheduleInfo scheduleInfo = \u001C\u001A\u0005.\u000A(\u0014\u001C\u0018.\u000A(enumerator));
					List<FolderItemInfo> u001F2 = Enumerable.ToList<FolderItemInfo>(\u0003\u001A\u0005.\u000A(\u000A, \u001E\u0001\u000A.\u000A(\u001A\u0019\u0005.\u000A(scheduleInfo))));
					if (\u0005\u001A\u0005.\u000A(u001F2) <= 0)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0010.\u001F(IList<ICategoryModel>, BrowserOrganization)).MethodHandle;
						}
						\u0018\u001A\u0005.\u000A(\u0018\u0018\u0005.\u0007(u001F), scheduleInfo);
					}
					else
					{
						\u0002\u0010.\u0005\u0010 u0005_u = new \u0002\u0010.\u0005\u0010();
						u0005_u.\u001F = \u0012\u001A\u0005.\u000A(u001F2, 0);
						List<ScheduleInfo> list = \u0018\u0018\u0005.\u0007(u001F);
						ScheduleInfo scheduleInfo2;
						if (list == null)
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
							scheduleInfo2 = \u001C\u0012\u000E.\u001F;
						}
						else
						{
							scheduleInfo2 = \u000F\u001A\u0005.\u000A(list, new Predicate<ScheduleInfo>(u0005_u.\u000A));
						}
						ScheduleInfo scheduleInfo3 = scheduleInfo2;
						if (scheduleInfo3 == null)
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
							scheduleInfo3 = \u000B\u001A\u0005.\u000A(\u0006\u001A\u0005.\u000A(u0005_u.\u001F), \u000B\u001E\u000A.\u000A(\u0002\u001A\u0005.\u000A(u0005_u.\u001F)));
							\u0016\u001A\u0005.\u000A(scheduleInfo3, true);
							\u0018\u001A\u0005.\u000A(\u0018\u0018\u0005.\u0007(u001F), scheduleInfo3);
						}
						ScheduleInfo scheduleInfo4 = scheduleInfo3;
						for (int i = 1; i < \u0005\u001A\u0005.\u000A(u001F2); i++)
						{
							\u0002\u0010.\u0016\u0010 u0016_u = new \u0002\u0010.\u0016\u0010();
							u0016_u.\u001F = \u0012\u001A\u0005.\u000A(u001F2, i);
							ScheduleInfo scheduleInfo5;
							if (scheduleInfo4 == null)
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
								scheduleInfo5 = \u001C\u0012\u000E.\u001F;
							}
							else
							{
								List<ScheduleInfo> list2 = \u0018\u0018\u0005.\u001D(scheduleInfo4);
								if (list2 == null)
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
									scheduleInfo5 = \u001C\u0012\u000E.\u001F;
								}
								else
								{
									scheduleInfo5 = \u000F\u001A\u0005.\u000A(list2, new Predicate<ScheduleInfo>(u0016_u.\u000A));
								}
							}
							ScheduleInfo scheduleInfo6 = scheduleInfo5;
							if (scheduleInfo6 == null)
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
								scheduleInfo6 = \u000B\u001A\u0005.\u000A(\u0006\u001A\u0005.\u000A(u0016_u.\u001F), \u000B\u001E\u000A.\u000A(\u0002\u001A\u0005.\u000A(u0016_u.\u001F)));
								\u0016\u001A\u0005.\u000A(scheduleInfo6, false);
								\u0018\u001A\u0005.\u000A(\u0018\u0018\u0005.\u0007(scheduleInfo4), scheduleInfo6);
							}
							scheduleInfo4 = scheduleInfo6;
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
						\u0018\u001A\u0005.\u000A(\u0018\u0018\u0005.\u0007(scheduleInfo4), scheduleInfo);
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
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			\u0002\u0010.\u0004(\u0018\u0018\u0005.\u0007(u001F));
			return \u0018\u0018\u0005.\u0007(u001F);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x000A116C File Offset: 0x0009F36C
		public static List<ScheduleInfo> \u000A(List<ScheduleInfo> \u001F, bool \u000A = false)
		{
			List<ScheduleInfo> list = \u000E\u001A\u0005.\u000A();
			List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u001F);
			try
			{
				while (\u0015\u0019\u0005.\u000A(ref enumerator))
				{
					ScheduleInfo u001F = \u0001\u0019\u0005.\u000A(ref enumerator);
					\u0010\u001A\u0005.\u000A(list, \u0002\u0010.\u001D(u001F, \u000A));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0010.\u000A(List<ScheduleInfo>, bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x000A11E4 File Offset: 0x0009F3E4
		public static void \u0007(ScheduleInfo \u001F, ICategoryModel \u000A)
		{
			\u0002\u0010.\u000B\u0010 u000B_u = new \u0002\u0010.\u000B\u0010();
			u000B_u.\u001F = \u000A;
			if (\u0006\u001C\u001D.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0010.\u0007(ScheduleInfo, ICategoryModel)).MethodHandle;
				}
				\u0019\u0018\u0005.\u000A(\u0018\u0018\u0005.\u0007(\u001F), new Action<ScheduleInfo>(u000B_u.\u000A));
				return;
			}
			if (\u001A\u0019\u0005.\u000A(\u001F) == \u0017\u001C\u0018.\u000A(u000B_u.\u001F))
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
				\u0017\u0019\u0005.\u000A(\u001F, new bool?(\u001D\u000C\u0018.\u000A(u000B_u.\u001F)));
			}
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x000A1270 File Offset: 0x0009F470
		private static List<ScheduleInfo> \u001D(ScheduleInfo \u001F, bool \u000A)
		{
			List<ScheduleInfo> list = \u000E\u001A\u0005.\u000A();
			if (!\u0006\u001C\u001D.\u000A(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0010.\u001D(ScheduleInfo, bool)).MethodHandle;
				}
				bool? flag = \u0005\u0018\u0005.\u000A(\u001F);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					if (!\u000A)
					{
						\u0018\u001A\u0005.\u000A(list, \u001F);
						return list;
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
					flag = \u000B\u0018\u0005.\u000A(\u001F);
					if (\u0012\u0015\u000A.\u000A(ref flag))
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
						\u0018\u001A\u0005.\u000A(list, \u001F);
						return list;
					}
					return list;
				}
			}
			List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u0018\u0018\u0005.\u0007(\u001F));
			try
			{
				while (\u0015\u0019\u0005.\u000A(ref enumerator))
				{
					ScheduleInfo u001F = \u0001\u0019\u0005.\u000A(ref enumerator);
					\u0010\u001A\u0005.\u000A(list, \u0002\u0010.\u001D(u001F, \u000A));
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x000A1364 File Offset: 0x0009F564
		private static void \u0004(List<ScheduleInfo> \u001F)
		{
			List<ScheduleInfo>.Enumerator enumerator = \u0009\u0019\u0005.\u000A(\u001F);
			try
			{
				while (\u0015\u0019\u0005.\u000A(ref enumerator))
				{
					ScheduleInfo u001F = \u0001\u0019\u0005.\u000A(ref enumerator);
					IEnumerable<ScheduleInfo> enumerable = \u0018\u0018\u0005.\u0007(u001F);
					Func<ScheduleInfo, string> func;
					if ((func = \u0002\u0010.<>c.\u000A) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0010.\u0004(List<ScheduleInfo>)).MethodHandle;
						}
						func = (\u0002\u0010.<>c.\u000A = new Func<ScheduleInfo, string>(\u0002\u0010.<>c.\u001F.\u0007));
					}
					\u000D\u0013\u0005.\u001D(u001F, Enumerable.ToList<ScheduleInfo>(Enumerable.OrderBy<ScheduleInfo, string>(enumerable, func)));
					\u000C\u0013\u0005.\u000A(u001F);
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
		}

		// Token: 0x02000940 RID: 2368
		[CompilerGenerated]
		private sealed class \u0005\u0010
		{
			// Token: 0x06005234 RID: 21044 RVA: 0x001EA1AC File Offset: 0x001E83AC
			internal bool \u000A(ScheduleInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u0018\u0005.\u000A(\u001F), \u0006\u001A\u0005.\u000A(this.\u001F));
			}

			// Token: 0x04002440 RID: 9280
			public FolderItemInfo \u001F;
		}

		// Token: 0x02000941 RID: 2369
		[CompilerGenerated]
		private sealed class \u0016\u0010
		{
			// Token: 0x06005236 RID: 21046 RVA: 0x001EA1EC File Offset: 0x001E83EC
			internal bool \u000A(ScheduleInfo \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u0018\u0005.\u000A(\u001F), \u0006\u001A\u0005.\u000A(this.\u001F));
			}

			// Token: 0x04002441 RID: 9281
			public FolderItemInfo \u001F;
		}

		// Token: 0x02000942 RID: 2370
		[CompilerGenerated]
		private sealed class \u000B\u0010
		{
			// Token: 0x06005238 RID: 21048 RVA: 0x001EA22C File Offset: 0x001E842C
			internal void \u000A(ScheduleInfo \u001F)
			{
				\u0002\u0010.\u0007(\u001F, this.\u001F);
			}

			// Token: 0x04002442 RID: 9282
			public ICategoryModel \u001F;
		}
	}
}
