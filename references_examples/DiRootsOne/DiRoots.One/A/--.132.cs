using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.SheetLink.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x0200025E RID: 606
	internal abstract class \u001F\u0010
	{
		// Token: 0x170006D0 RID: 1744
		// (get) Token: 0x06001896 RID: 6294 RVA: 0x0009EFB8 File Offset: 0x0009D1B8
		// (set) Token: 0x06001897 RID: 6295 RVA: 0x0009EFCC File Offset: 0x0009D1CC
		public string TransactionName { get; set; }

		// Token: 0x170006D1 RID: 1745
		// (get) Token: 0x06001898 RID: 6296 RVA: 0x0009EFE0 File Offset: 0x0009D1E0
		// (set) Token: 0x06001899 RID: 6297 RVA: 0x0009EFF4 File Offset: 0x0009D1F4
		public Document ActiveDocument { get; set; }

		// Token: 0x170006D2 RID: 1746
		// (get) Token: 0x0600189A RID: 6298 RVA: 0x0009F008 File Offset: 0x0009D208
		// (set) Token: 0x0600189B RID: 6299 RVA: 0x0009F01C File Offset: 0x0009D21C
		public KeyValuePair<DataTable, List<ParamExportInfo>> ImportData { get; set; }

		// Token: 0x170006D3 RID: 1747
		// (get) Token: 0x0600189C RID: 6300 RVA: 0x0009F030 File Offset: 0x0009D230
		// (set) Token: 0x0600189D RID: 6301 RVA: 0x0009F044 File Offset: 0x0009D244
		public ExportTypes ExportType { get; set; }

		// Token: 0x170006D4 RID: 1748
		// (get) Token: 0x0600189E RID: 6302 RVA: 0x0009F058 File Offset: 0x0009D258
		// (set) Token: 0x0600189F RID: 6303 RVA: 0x0009F06C File Offset: 0x0009D26C
		public string SheetName { get; set; }

		// Token: 0x170006D5 RID: 1749
		// (get) Token: 0x060018A0 RID: 6304 RVA: 0x0009F080 File Offset: 0x0009D280
		// (set) Token: 0x060018A1 RID: 6305 RVA: 0x0009F094 File Offset: 0x0009D294
		public List<ReportInfo> Reports { get; set; }

		// Token: 0x060018A2 RID: 6306
		public abstract Element \u0018(Phase \u001F);

		// Token: 0x060018A3 RID: 6307 RVA: 0x0009F0A8 File Offset: 0x0009D2A8
		public Dictionary<int, Element> \u0005()
		{
			\u001F\u0010.\u0001\u000D u0001_u000D = new \u001F\u0010.\u0001\u000D();
			\u0013\u0014\u0005.\u000A(this, \u0012\u000F\u0018.\u000A());
			Dictionary<int, Element> dictionary = \u0010\u0012\u0018.\u000A();
			Document u001F = \u001C\u0014\u0005.\u000A(this);
			List<Phase> list = Enumerable.ToList<Phase>(Enumerable.Cast<Phase>(\u0001\u001E\u000A.\u0007(\u0017\u0011\u000A.\u0007(\u0020\u0011\u000A.\u000A(\u001C\u0014\u0005.\u000A(this)), -2000112L))));
			u0001_u000D.\u001F = 0;
			KeyValuePair<DataTable, List<ParamExportInfo>> keyValuePair = \u000E\u0014\u0005.\u000A(this);
			IEnumerable<ParamExportInfo> enumerable = \u0004\u0012\u0018.\u000A(ref keyValuePair);
			Func<ParamExportInfo, bool> func;
			if ((func = \u001F\u0010.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u0010.\u0005()).MethodHandle;
				}
				func = (\u001F\u0010.<>c.\u000A = new Func<ParamExportInfo, bool>(\u001F\u0010.<>c.\u001F.\u0007));
			}
			ParamExportInfo paramExportInfo = Enumerable.FirstOrDefault<ParamExportInfo>(enumerable, func);
			if (paramExportInfo != null)
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
				\u001F\u0010.\u0001\u000D u0001_u000D2 = u0001_u000D;
				keyValuePair = \u000E\u0014\u0005.\u000A(this);
				u0001_u000D2.\u001F = \u0014\u0014\u0005.\u000A(\u0004\u0012\u0018.\u000A(ref keyValuePair), paramExportInfo);
			}
			Transaction transaction = \u001D\u0014\u0007.\u000A(u001F, \u0017\u0014\u0005.\u000A(this));
			try
			{
				FailureHandlingOptions failureHandlingOptions = \u0006\u0014\u0007.\u000A(transaction);
				\u0002\u0014\u0007.\u000A(failureHandlingOptions, new \u001A\u000D());
				\u000B\u0014\u0007.\u000A(transaction, failureHandlingOptions);
				\u0007\u0014\u0007.\u000A(transaction);
				try
				{
					int num = 0;
					for (;;)
					{
						int num2 = num;
						keyValuePair = \u000E\u0014\u0005.\u000A(this);
						if (num2 >= \u000A\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref keyValuePair))))
						{
							break;
						}
						\u001F\u0010.\u0009\u000D u0009_u000D = new \u001F\u0010.\u0009\u000D();
						u0009_u000D.\u000A = u0001_u000D;
						\u001F\u0010.\u0009\u000D u0009_u000D2 = u0009_u000D;
						keyValuePair = \u000E\u0014\u0005.\u000A(this);
						u0009_u000D2.\u001F = \u0011\u0012\u0018.\u000A(\u0002\u000F\u0018.\u000A(\u000B\u0006\u0018.\u000A(ref keyValuePair)), num);
						string text = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(u0009_u000D.\u001F, 0));
						ReportInfo reportInfo = \u0013\u0010\u0005.\u000A();
						\u001E\u0006\u0018.\u000A(reportInfo, num + 1);
						if (paramExportInfo != null)
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
							object u001F2 = reportInfo;
							string u001F3 = \u0004\u000F.\u0002(u0009_u000D.\u000A.\u001F + 1);
							int num3 = \u0020\u0014\u0005.\u000A(reportInfo) + \u0019\u0019\u0018.\u000A(paramExportInfo);
							\u0008\u0012\u0018.\u0007(u001F2, \u0004\u001E\u000A.\u000A(u001F3, \u000C\u0013\u0007.\u000A(ref num3)));
						}
						\u0020\u0014\u0007.\u000A(reportInfo, ReportStates.Error);
						\u0006\u0020\u0005.\u001D(reportInfo, \u001E\u0014\u0005.\u000A(this));
						\u0016\u0020\u0005.\u001D(reportInfo, "Phase");
						Element element = \u0007\u000B\u000E.\u001F;
						if (\u001A\u0006\u0007.\u000A(text))
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
							if (u0009_u000D.\u000A.\u001F == 0)
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
								\u0012\u0006\u0018.\u0007(reportInfo, \u0011\u0014\u0005.\u000A());
								\u000F\u0006\u0018.\u000A(\u000F\u0012\u0018.\u001D(this), reportInfo);
							}
							else
							{
								string text2 = \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(u0009_u000D.\u001F, u0009_u000D.\u000A.\u001F));
								if (\u001A\u0006\u0007.\u000A(text2))
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
									\u0012\u0006\u0018.\u0007(reportInfo, \u001B\u0014\u0005.\u000A());
									\u000F\u0006\u0018.\u000A(\u000F\u0012\u0018.\u001D(this), reportInfo);
								}
								else
								{
									Phase phase = Enumerable.FirstOrDefault<Phase>(list, new Func<Phase, bool>(u0009_u000D.\u0007));
									if (phase != null)
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
										try
										{
											element = this.\u0018(phase);
											\u001E\u0006\u0005.\u000A(u0009_u000D.\u001F, 0, \u0012\u0010\u0007.\u000A(element));
											text = \u0012\u0010\u0007.\u000A(element);
											goto IL_351;
										}
										catch (Exception u001F4)
										{
											\u000B\u0020\u0005.\u001D(reportInfo, text2);
											\u0012\u0006\u0018.\u0007(reportInfo, \u0003\u001A\u000A.\u000A(u001F4));
											goto IL_351;
										}
									}
									\u000B\u0020\u0005.\u001D(reportInfo, text2);
									\u0012\u0006\u0018.\u0007(reportInfo, \u0008\u0014\u0005.\u000A());
									\u000F\u0006\u0018.\u000A(\u000F\u0012\u0018.\u001D(this), reportInfo);
								}
							}
						}
						else
						{
							element = \u000C\u0008\u0007.\u000A(u001F, text);
						}
						IL_351:
						if (element != null)
						{
							goto IL_374;
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
						if (!\u001A\u0006\u0007.\u000A(text))
						{
							for (;;)
							{
								switch (4)
								{
								case 0:
									continue;
								}
								goto IL_374;
							}
						}
						IL_37E:
						num++;
						continue;
						IL_374:
						\u0002\u0012\u0018.\u000A(dictionary, num, element);
						goto IL_37E;
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
				catch (Exception)
				{
					\u001F\u0014\u0007.\u000A(transaction);
					throw;
				}
				if (\u0010\u0014\u0005.\u000A(this) == ExportTypes.Rooms)
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
					\u001E\u0018\u0007.\u000A(u001F);
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
			return dictionary;
		}

		// Token: 0x060018A4 RID: 6308 RVA: 0x0009F508 File Offset: 0x0009D708
		public void \u0016()
		{
			\u0012\u0012\u0018.\u001D(this, "");
			\u0013\u0014\u0005.\u000A(this, \u000F\u0012\u000E.\u001F);
			\u000D\u0012\u0018.\u001D(this, \u0010\u0007\u000E.\u001F);
		}

		// Token: 0x040009A2 RID: 2466
		[CompilerGenerated]
		private string \u001F;

		// Token: 0x040009A3 RID: 2467
		[CompilerGenerated]
		private Document \u000A;

		// Token: 0x040009A4 RID: 2468
		[CompilerGenerated]
		private KeyValuePair<DataTable, List<ParamExportInfo>> \u0007;

		// Token: 0x040009A5 RID: 2469
		[CompilerGenerated]
		private ExportTypes \u001D;

		// Token: 0x040009A6 RID: 2470
		[CompilerGenerated]
		private string \u0004;

		// Token: 0x040009A7 RID: 2471
		[CompilerGenerated]
		private List<ReportInfo> \u0019;

		// Token: 0x02000937 RID: 2359
		[CompilerGenerated]
		private sealed class \u0001\u000D
		{
			// Token: 0x0400242A RID: 9258
			public int \u001F;
		}

		// Token: 0x02000938 RID: 2360
		[CompilerGenerated]
		private sealed class \u0009\u000D
		{
			// Token: 0x0600521A RID: 21018 RVA: 0x001E9E80 File Offset: 0x001E8080
			internal bool \u0007(Phase \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), \u001A\u000C\u000A.\u000A(\u001F\u000F\u0018.\u000A(this.\u001F, this.\u000A.\u001F)));
			}

			// Token: 0x0400242B RID: 9259
			public DataRow \u001F;

			// Token: 0x0400242C RID: 9260
			public \u001F\u0010.\u0001\u000D \u000A;
		}
	}
}
