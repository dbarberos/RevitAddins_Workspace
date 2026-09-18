using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;

namespace A
{
	// Token: 0x020001FE RID: 510
	internal class \u001A\u000F
	{
		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06001309 RID: 4873 RVA: 0x000711E4 File Offset: 0x0006F3E4
		// (set) Token: 0x0600130A RID: 4874 RVA: 0x000711F8 File Offset: 0x0006F3F8
		internal static bool IsDocumentChangedEventCompleted { get; set; }

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x0600130B RID: 4875 RVA: 0x0007120C File Offset: 0x0006F40C
		// (set) Token: 0x0600130C RID: 4876 RVA: 0x00071220 File Offset: 0x0006F420
		internal static long KeyParamId { get; set; } = -1L;

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x0600130D RID: 4877 RVA: 0x00071234 File Offset: 0x0006F434
		// (set) Token: 0x0600130E RID: 4878 RVA: 0x00071248 File Offset: 0x0006F448
		internal static List<\u001A\u000F> KeyScheduleDataCache { get; set; } = \u000C\u001C\u0018.\u000A();

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x0600130F RID: 4879 RVA: 0x0007125C File Offset: 0x0006F45C
		// (set) Token: 0x06001310 RID: 4880 RVA: 0x00071270 File Offset: 0x0006F470
		public long ScheduleId { get; set; }

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06001311 RID: 4881 RVA: 0x00071284 File Offset: 0x0006F484
		// (set) Token: 0x06001312 RID: 4882 RVA: 0x00071298 File Offset: 0x0006F498
		public long ParameterId { get; set; }

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06001313 RID: 4883 RVA: 0x000712AC File Offset: 0x0006F4AC
		// (set) Token: 0x06001314 RID: 4884 RVA: 0x000712C0 File Offset: 0x0006F4C0
		public Dictionary<long, string> ElementsInKeySchedule { get; set; } = new Dictionary<long, string>();

		// Token: 0x06001315 RID: 4885 RVA: 0x000712D4 File Offset: 0x0006F4D4
		internal static List<\u001A\u000F> \u0018(Document \u001F, bool \u000A)
		{
			if (\u000B\u000D\u0018.\u000A(\u0019\u001A\u0019.\u000A()) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u000F.\u0018(Document, bool)).MethodHandle;
				}
				return \u0019\u001A\u0019.\u000A();
			}
			IEnumerable<ViewSchedule> enumerable = Enumerable.Cast<ViewSchedule>(\u0004\u0010.\u0007(\u001F));
			Func<ViewSchedule, bool> func;
			if ((func = \u001A\u000F.<>c.\u000A) == null)
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
				func = (\u001A\u000F.<>c.\u000A = new Func<ViewSchedule, bool>(\u001A\u000F.<>c.\u001F.\u0004));
			}
			List<ViewSchedule>.Enumerator enumerator = \u0016\u000D\u0018.\u000A(Enumerable.ToList<ViewSchedule>(Enumerable.Where<ViewSchedule>(enumerable, func)));
			try
			{
				while (\u0015\u001C\u0018.\u000A(ref enumerator))
				{
					ViewSchedule viewSchedule = \u0005\u000D\u0018.\u000A(ref enumerator);
					if (!\u001A\u0006\u0007.\u000A(\u0018\u000D\u0018.\u000A(viewSchedule)))
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
						if (!\u001A\u000F.\u0005(\u001F, viewSchedule))
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
							int num = 0;
							while (!\u0019\u000D\u0018.\u000A())
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
								if (num >= 30)
								{
									for (;;)
									{
										switch (1)
										{
										case 0:
											continue;
										}
										goto IL_F2;
									}
								}
								else
								{
									\u0007\u000B\u0004.\u000A(1000);
									num++;
								}
							}
							IL_F2:
							if (num != 30)
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
								if (!\u000A)
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
									\u0008\u000B\u0004.\u000A();
								}
								\u0004\u000D\u0018.\u000A(false);
								if (\u0007\u000D\u0018.\u000A() > 0L)
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
									\u001A\u000F u001A_u000F = new \u001A\u000F();
									IEnumerable<Element> enumerable2 = \u0009\u001E\u000A.\u0007(\u001A\u0018\u0007.\u000A(\u001F, \u0002\u001E\u000A.\u0007(viewSchedule)));
									Func<Element, bool> func2;
									if ((func2 = \u001A\u000F.<>c.\u0007) == null)
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
										func2 = (\u001A\u000F.<>c.\u0007 = new Func<Element, bool>(\u001A\u000F.<>c.\u001F.\u0019));
									}
									List<Element> u001F = Enumerable.ToList<Element>(Enumerable.Where<Element>(enumerable2, func2));
									\u001D\u000D\u0018.\u000A(u001A_u000F, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewSchedule)));
									if (\u0016\u0018\u0007.\u0007(viewSchedule, -1007851L) == null)
									{
										continue;
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
									\u000A\u000D\u0018.\u000A(u001A_u000F, \u0007\u000D\u0018.\u000A());
									\u001F\u000D\u0018.\u000A(\u0007\u0006\u0018.\u000A(u001A_u000F), -1L, "None");
									List<Element>.Enumerator enumerator2 = \u0001\u0010\u0007.\u000A(u001F);
									try
									{
										while (\u000C\u0010\u0007.\u000A(ref enumerator2))
										{
											Element u001F2 = \u0015\u0010\u0007.\u000A(ref enumerator2);
											\u001F\u000D\u0018.\u000A(\u0007\u0006\u0018.\u000A(u001A_u000F), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)), \u0005\u001E\u000A.\u000A(u001F2));
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
									\u0009\u001C\u0018.\u000A(\u0019\u001A\u0019.\u000A(), u001A_u000F);
								}
								\u0001\u001C\u0018.\u000A(-1L);
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
				((IDisposable)enumerator).Dispose();
			}
			return \u0019\u001A\u0019.\u000A();
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x00071594 File Offset: 0x0006F794
		private static bool \u0005(Document \u001F, ViewSchedule \u000A)
		{
			bool result = false;
			TransactionGroup transactionGroup = \u0009\u0017\u0007.\u000A(\u001F, "Check Key Params");
			try
			{
				\u0001\u0017\u0007.\u000A(transactionGroup);
				object u001F = \u0017\u0005\u0004.\u0007(\u001F);
				EventHandler<DocumentChangedEventArgs> u000A;
				if ((u000A = \u001A\u000F.\u0013\u000F.\u001F) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u000F.\u0005(Document, ViewSchedule)).MethodHandle;
					}
					u000A = (\u001A\u000F.\u0013\u000F.\u001F = new EventHandler<DocumentChangedEventArgs>(\u001A\u000F.\u0016));
				}
				\u000F\u000D\u0018.\u000A(u001F, u000A);
				try
				{
					Transaction transaction = \u001D\u0014\u0007.\u000A(\u001F, "Key Params");
					try
					{
						\u0007\u0014\u0007.\u000A(transaction);
						\u0006\u000D\u0018.\u000A(\u000A, "Diroots_Room_KeyParma");
						\u001B\u0001\u000A.\u000A(transaction);
					}
					finally
					{
						if (transaction != null)
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
							\u001F\u0017\u000A.\u000A(transaction);
						}
					}
				}
				catch (Exception)
				{
					result = true;
				}
				object u001F2 = \u0017\u0005\u0004.\u0007(\u001F);
				EventHandler<DocumentChangedEventArgs> u000A2;
				if ((u000A2 = \u001A\u000F.\u0013\u000F.\u001F) == null)
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
					u000A2 = (\u001A\u000F.\u0013\u000F.\u001F = new EventHandler<DocumentChangedEventArgs>(\u001A\u000F.\u0016));
				}
				\u0002\u000D\u0018.\u000A(u001F2, u000A2);
				\u001A\u0017\u0007.\u000A(transactionGroup);
			}
			finally
			{
				if (transactionGroup != null)
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
					\u001F\u0017\u000A.\u000A(transactionGroup);
				}
			}
			return result;
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x000716B8 File Offset: 0x0006F8B8
		private static void \u0016(object \u001F, DocumentChangedEventArgs \u000A)
		{
			IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(\u0003\u000D\u0018.\u000A(\u000A));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ElementId u000A = \u0016\u0013\u0007.\u000A(enumerator);
					Element u001F = \u0011\u0017\u000A.\u0007(\u0012\u000D\u0018.\u000A(\u000A), u000A);
					if (\u0002\u000B\u000E.\u001F(u001F) != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u000F.\u0016(object, DocumentChangedEventArgs)).MethodHandle;
						}
						\u0001\u001C\u0018.\u000A(\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F)));
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
			\u0004\u000D\u0018.\u000A(true);
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x00071764 File Offset: 0x0006F964
		internal static View \u000B(Document \u001F)
		{
			IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0011\u0011\u000A.\u001D(\u0020\u0011\u000A.\u000A(\u001F), \u001E\u0011\u000A.\u000A(\u0006\u001F\u000E.\u001F())));
			Func<View, bool> func;
			if ((func = \u001A\u000F.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001A\u000F.\u000B(Document)).MethodHandle;
				}
				func = (\u001A\u000F.<>c.\u001D = new Func<View, bool>(\u001A\u000F.<>c.\u001F.\u0018));
			}
			return Enumerable.FirstOrDefault<View>(enumerable, func);
		}

		// Token: 0x04000796 RID: 1942
		[CompilerGenerated]
		private static bool \u001F;

		// Token: 0x04000797 RID: 1943
		[CompilerGenerated]
		private static long \u000A;

		// Token: 0x04000798 RID: 1944
		[CompilerGenerated]
		private static List<\u001A\u000F> \u0007;

		// Token: 0x04000799 RID: 1945
		[CompilerGenerated]
		private long \u001D;

		// Token: 0x0400079A RID: 1946
		[CompilerGenerated]
		private long \u0004;

		// Token: 0x0400079B RID: 1947
		[CompilerGenerated]
		private Dictionary<long, string> \u0019;

		// Token: 0x020008A1 RID: 2209
		[CompilerGenerated]
		private static class \u0013\u000F
		{
			// Token: 0x0400226D RID: 8813
			public static EventHandler<DocumentChangedEventArgs> \u001F;
		}
	}
}
