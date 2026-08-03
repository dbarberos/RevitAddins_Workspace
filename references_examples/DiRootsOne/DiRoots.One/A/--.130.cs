using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000240 RID: 576
	internal class \u001E\u001C : IFailuresPreprocessor
	{
		// Token: 0x060016EE RID: 5870 RVA: 0x000969D4 File Offset: 0x00094BD4
		public \u001E\u001C()
		{
		}

		// Token: 0x060016EF RID: 5871 RVA: 0x000969F4 File Offset: 0x00094BF4
		public \u001E\u001C(long \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x060016F0 RID: 5872 RVA: 0x00096A1C File Offset: 0x00094C1C
		// (set) Token: 0x060016F1 RID: 5873 RVA: 0x00096A30 File Offset: 0x00094C30
		public List<ReportInfo> CurrentReports { get; set; } = new List<ReportInfo>();

		// Token: 0x060016F2 RID: 5874 RVA: 0x00096A44 File Offset: 0x00094C44
		public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
		{
			IList<FailureMessageAccessor> u001F = \u0013\u0017\u0007.\u000A(failuresAccessor);
			if (\u0014\u0017\u0007.\u000A(u001F) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u001C.PreprocessFailures(FailuresAccessor)).MethodHandle;
				}
				return 0;
			}
			bool flag = false;
			IEnumerator<FailureMessageAccessor> enumerator = \u001B\u0005\u0004.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					FailureMessageAccessor failureMessageAccessor = \u0008\u0005\u0004.\u000A(enumerator);
					if (\u000E\u0005\u0004.\u000A(failureMessageAccessor) == 1)
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
						\u0010\u0005\u0004.\u000A(failuresAccessor, failureMessageAccessor);
					}
					else if (\u000E\u0005\u0004.\u000A(failureMessageAccessor) == 2)
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
						flag = true;
						if (\u000E\u0006\u0018.\u001D(this) != null)
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
							long num;
							if (\u000A\u0008\u0019.\u000A(\u001F\u0008\u0019.\u000A(failureMessageAccessor)) > 0)
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
								IEnumerator<ElementId> enumerator2 = \u000B\u0013\u0007.\u000A(\u001F\u0008\u0019.\u000A(failureMessageAccessor));
								try
								{
									while (\u000A\u0017\u000A.\u000A(enumerator2))
									{
										ElementId u001F2 = \u0016\u0013\u0007.\u000A(enumerator2);
										ReportInfo reportInfo = \u0013\u0010\u0005.\u000A();
										object u001F3 = reportInfo;
										num = this.\u001F;
										\u0014\u0010\u0005.\u0007(u001F3, \u0011\u0013\u000A.\u000A(ref num));
										object u001F4 = reportInfo;
										num = \u000B\u001E\u000A.\u000A(u001F2);
										\u0020\u0010\u0005.\u0007(u001F4, \u0011\u0013\u000A.\u000A(ref num));
										\u0012\u0006\u0018.\u0007(reportInfo, \u0017\u0010\u0005.\u000A(failureMessageAccessor));
										\u0020\u0014\u0007.\u000A(reportInfo, ReportStates.Warning);
										\u000F\u0006\u0018.\u000A(\u000E\u0006\u0018.\u001D(this), reportInfo);
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
									continue;
								}
								finally
								{
									if (enumerator2 != null)
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
										\u001F\u0017\u000A.\u000A(enumerator2);
									}
								}
							}
							ReportInfo reportInfo2 = \u0013\u0010\u0005.\u000A();
							object u001F5 = reportInfo2;
							num = this.\u001F;
							\u0014\u0010\u0005.\u0007(u001F5, \u0011\u0013\u000A.\u000A(ref num));
							\u0012\u0006\u0018.\u0007(reportInfo2, \u0017\u0010\u0005.\u000A(failureMessageAccessor));
							\u0020\u0010\u0005.\u0007(reportInfo2, "-1");
							\u0020\u0014\u0007.\u000A(reportInfo2, ReportStates.Warning);
							\u000F\u0006\u0018.\u000A(\u000E\u0006\u0018.\u001D(this), reportInfo2);
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
			if (flag)
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
				return 2;
			}
			return 1;
		}

		// Token: 0x0400090B RID: 2315
		private readonly long \u001F;

		// Token: 0x0400090C RID: 2316
		[CompilerGenerated]
		private List<ReportInfo> \u000A;
	}
}
