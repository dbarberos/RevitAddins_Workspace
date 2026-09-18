using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.GroupHelper;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001FB RID: 507
	internal static class \u001C\u000F
	{
		// Token: 0x060012F0 RID: 4848 RVA: 0x0006EF90 File Offset: 0x0006D190
		internal static void \u001F(Document \u001F, List<DataRow> \u000A, Dictionary<string, List<ChangedColumns>> \u0007, GroupHandler \u001D)
		{
			List<Element> u001F = \u0016\u0016\u0004.\u000A();
			List<DataRow>.Enumerator enumerator = \u0019\u000F\u0018.\u000A(\u000A);
			try
			{
				while (\u001B\u0006\u0018.\u000A(ref enumerator))
				{
					string u000A = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(\u0004\u000F\u0018.\u000A(ref enumerator), 0));
					Element element = \u000C\u0008\u0007.\u000A(\u001F, u000A);
					if (element != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u001C\u000F.\u001F(Document, List<DataRow>, Dictionary<string, List<ChangedColumns>>, GroupHandler)).MethodHandle;
						}
						\u000C\u0017\u0019.\u000A(u001F, element);
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
			SubTransaction subTransaction = \u0016\u0014\u0007.\u000A(\u001F);
			try
			{
				\u0005\u0014\u0007.\u000A(subTransaction);
				int num = 0;
				List<Element>.Enumerator enumerator2 = \u0001\u0010\u0007.\u000A(u001F);
				try
				{
					while (\u000C\u0010\u0007.\u000A(ref enumerator2))
					{
						Element u001F2 = \u0015\u0010\u0007.\u000A(ref enumerator2);
						if (\u0019\u000B\u000E.\u001F(u001F2) == null)
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
							if (\u0018\u000B\u000E.\u001F(u001F2) == null)
							{
								continue;
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
						if (\u001A\u0006\u0018.\u000A(\u0007, \u0012\u0010\u0007.\u000A(u001F2)))
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
							List<ChangedColumns> list = \u0013\u0006\u0018.\u000A(\u0007, \u0012\u0010\u0007.\u000A(u001F2));
							IEnumerable<ChangedColumns> enumerable = list;
							Func<ChangedColumns, bool> func;
							if ((func = \u001C\u000F.<>c.\u000A) == null)
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
								func = (\u001C\u000F.<>c.\u000A = new Func<ChangedColumns, bool>(\u001C\u000F.<>c.\u001F.\u0007));
							}
							ChangedColumns changedColumns = Enumerable.FirstOrDefault<ChangedColumns>(enumerable, func);
							if (changedColumns == null)
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
								return;
							}
							Parameter parameter = \u0014\u0013\u0007.\u000A(u001F2, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u0014\u0006\u0018.\u000A(changedColumns))));
							if (\u0001\u0006\u0018.\u000A(\u001D))
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
								if (!\u0015\u0006\u0018.\u000A(changedColumns))
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
									if (\u001A\u0008\u0019.\u000A(\u000C\u0006\u0018.\u000A(\u001D), \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2))))
									{
										continue;
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
							}
							object u001F3 = parameter;
							string u001F4 = "_temp_transaction_";
							int num2 = num++;
							\u0016\u0018\u001D.\u0007(u001F3, \u0004\u001E\u000A.\u000A(u001F4, \u000C\u0013\u0007.\u000A(ref num2)));
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
				\u0019\u0014\u0007.\u000A(subTransaction);
			}
			finally
			{
				if (subTransaction != null)
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
					\u001F\u0017\u000A.\u000A(subTransaction);
				}
			}
		}
	}
}
