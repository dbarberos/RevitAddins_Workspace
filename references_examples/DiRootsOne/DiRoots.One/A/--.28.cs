using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Enums;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.One.ViewAligner.Services;
using DiRoots.Revit.SheetsAndViews.Errors;
using DiRoots.Revit.SheetsAndViews.Results;

namespace A
{
	// Token: 0x020000C4 RID: 196
	internal class \u001D\u0019
	{
		// Token: 0x0600079D RID: 1949 RVA: 0x0002BE24 File Offset: 0x0002A024
		// Note: this type is marked as 'beforefieldinit'.
		static \u001D\u0019()
		{
			Dictionary<ErrorCode, string> u001F = \u0018\u000D\u001D.\u000A();
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.ScopeBox_InvalidReference, \u0019\u000D\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.ScopeBox_ReadOnly, \u0004\u000D\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.ScopeBox_NotSet, \u001D\u000D\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.ScopeBox_NotApplicable, \u0007\u000D\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.ScopeBox_Exception, \u000A\u000D\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.AlignView_Exception, \u001F\u000D\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.AlignTitle_InvalidReference, \u0009\u001C\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.AlignTitle_Exception, \u0001\u001C\u001D.\u000A());
			\u000C\u001C\u001D.\u000A(u001F, ErrorCode.AlignTitle_NotApplicable, \u0015\u001C\u001D.\u000A());
			\u001D\u0019.\u001F = u001F;
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x0600079E RID: 1950 RVA: 0x0002BEE0 File Offset: 0x0002A0E0
		// (set) Token: 0x0600079F RID: 1951 RVA: 0x0002BEF4 File Offset: 0x0002A0F4
		public ViewInfo ReferenceView { get; set; }

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060007A0 RID: 1952 RVA: 0x0002BF08 File Offset: 0x0002A108
		// (set) Token: 0x060007A1 RID: 1953 RVA: 0x0002BF1C File Offset: 0x0002A11C
		public List<ViewInfo> TargetViews { get; set; }

		// Token: 0x060007A2 RID: 1954 RVA: 0x0002BF30 File Offset: 0x0002A130
		public IEnumerable<AlignReport> \u001D(OperationResultList<long> \u001F, OperationResultList<long> \u000A, OperationResultList<long> \u0007, OperationResultList<long> \u001D)
		{
			IEnumerable<ViewInfo> enumerable = \u0008\u000D\u001D.\u000A(this);
			Func<ViewInfo, long> func;
			if ((func = \u001D\u0019.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0019.\u001D(OperationResultList<long>, OperationResultList<long>, OperationResultList<long>, OperationResultList<long>)).MethodHandle;
				}
				func = (\u001D\u0019.<>c.\u000A = new Func<ViewInfo, long>(\u001D\u0019.<>c.\u001F.\u0005));
			}
			IEnumerable<IGrouping<long, ViewInfo>> enumerable2 = Enumerable.GroupBy<ViewInfo, long>(enumerable, func);
			Func<IGrouping<long, ViewInfo>, ViewInfo> func2;
			if ((func2 = \u001D\u0019.<>c.\u0007) == null)
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
				func2 = (\u001D\u0019.<>c.\u0007 = new Func<IGrouping<long, ViewInfo>, ViewInfo>(\u001D\u0019.<>c.\u001F.\u0016));
			}
			IEnumerable<ViewInfo> enumerable3 = Enumerable.Select<IGrouping<long, ViewInfo>, ViewInfo>(enumerable2, func2);
			Func<ViewInfo, long> func3;
			if ((func3 = \u001D\u0019.<>c.\u001D) == null)
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
				func3 = (\u001D\u0019.<>c.\u001D = new Func<ViewInfo, long>(\u001D\u0019.<>c.\u001F.\u000B));
			}
			Func<ViewInfo, ViewInfo> func4;
			if ((func4 = \u001D\u0019.<>c.\u0004) == null)
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
				func4 = (\u001D\u0019.<>c.\u0004 = new Func<ViewInfo, ViewInfo>(\u001D\u0019.<>c.\u001F.\u0002));
			}
			Dictionary<long, ViewInfo> u001F = Enumerable.ToDictionary<ViewInfo, long, ViewInfo>(enumerable3, func3, func4);
			IEnumerable<ViewInfo> enumerable4 = \u0008\u000D\u001D.\u000A(this);
			Func<ViewInfo, long> func5;
			if ((func5 = \u001D\u0019.<>c.\u0019) == null)
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
				func5 = (\u001D\u0019.<>c.\u0019 = new Func<ViewInfo, long>(\u001D\u0019.<>c.\u001F.\u0006));
			}
			Func<ViewInfo, ViewInfo> func6;
			if ((func6 = \u001D\u0019.<>c.\u0018) == null)
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
				func6 = (\u001D\u0019.<>c.\u0018 = new Func<ViewInfo, ViewInfo>(\u001D\u0019.<>c.\u001F.\u000F));
			}
			Dictionary<long, ViewInfo> u001F2 = Enumerable.ToDictionary<ViewInfo, long, ViewInfo>(enumerable4, func5, func6);
			OperationResult<long>[] array;
			if (\u001F == null)
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
				array = null;
			}
			else
			{
				array = \u000E\u000D\u001D.\u0007(\u001F);
			}
			OperationResult<long>[] u001F3;
			if ((u001F3 = array) == null)
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
				u001F3 = Array.Empty<OperationResult<long>>();
			}
			OperationResult<long>[] array2;
			if (\u000A == null)
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
				array2 = null;
			}
			else
			{
				array2 = \u000E\u000D\u001D.\u0007(\u000A);
			}
			OperationResult<long>[] array3;
			if ((array3 = array2) == null)
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
				array3 = Array.Empty<OperationResult<long>>();
			}
			IReadOnlyCollection<OperationResult<long>> u001F4 = array3;
			OperationResult<long>[] array4;
			if (\u0007 == null)
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
				array4 = null;
			}
			else
			{
				array4 = \u000E\u000D\u001D.\u0007(\u0007);
			}
			OperationResult<long>[] array5;
			if ((array5 = array4) == null)
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
				array5 = Array.Empty<OperationResult<long>>();
			}
			IReadOnlyCollection<OperationResult<long>> u001F5 = array5;
			OperationResult<long>[] array6;
			if (\u001D == null)
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
				array6 = null;
			}
			else
			{
				array6 = \u000E\u000D\u001D.\u0007(\u001D);
			}
			OperationResult<long>[] array7;
			if ((array7 = array6) == null)
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
				array7 = Array.Empty<OperationResult<long>>();
			}
			IReadOnlyCollection<OperationResult<long>> u001F6 = array7;
			List<AlignReport> list = \u0010\u000D\u001D.\u000A();
			IEnumerator<OperationResult<long>> enumerator = \u0006\u000D\u001D.\u000A(u001F3);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					OperationResult<long> u001F7 = \u0002\u000D\u001D.\u000A(enumerator);
					ViewInfo u001F8;
					if (\u0008\u0013\u000A.\u000A(\u000D\u000D\u001D.\u000A(\u0012\u000D\u001D.\u000A(\u0003\u000D\u001D.\u000A(u001F7))), \u000D\u000D\u001D.\u000A(ErrorCode.ScopeBox_InvalidReference)))
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
						u001F8 = \u001C\u000D\u001D.\u000A(this);
					}
					else
					{
						ViewInfo viewInfo;
						if (!\u0016\u000D\u001D.\u000A(u001F, \u000B\u000D\u001D.\u000A(u001F7), ref viewInfo))
						{
							continue;
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
						u001F8 = viewInfo;
					}
					\u0005\u000D\u001D.\u000A(list, \u001D\u0019.\u0004(u001F8, \u0012\u000D\u001D.\u000A(\u0003\u000D\u001D.\u000A(u001F7))));
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
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			enumerator = \u0006\u000D\u001D.\u000A(u001F4);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					OperationResult<long> u001F9 = \u0002\u000D\u001D.\u000A(enumerator);
					ViewInfo u001F10;
					if (\u0016\u000D\u001D.\u000A(u001F2, \u000B\u000D\u001D.\u000A(u001F9), ref u001F10))
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
						\u0005\u000D\u001D.\u000A(list, \u001D\u0019.\u0004(u001F10, \u0012\u000D\u001D.\u000A(\u0003\u000D\u001D.\u000A(u001F9))));
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			enumerator = \u0006\u000D\u001D.\u000A(u001F5);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					OperationResult<long> u001F11 = \u0002\u000D\u001D.\u000A(enumerator);
					ViewInfo u001F12;
					if (\u0016\u000D\u001D.\u000A(u001F2, \u000B\u000D\u001D.\u000A(u001F11), ref u001F12))
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
						\u0005\u000D\u001D.\u000A(list, \u001D\u0019.\u0004(u001F12, \u0012\u000D\u001D.\u000A(\u0003\u000D\u001D.\u000A(u001F11))));
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
						switch (4)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			enumerator = \u0006\u000D\u001D.\u000A(u001F6);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					OperationResult<long> u001F13 = \u0002\u000D\u001D.\u000A(enumerator);
					ViewInfo u001F14;
					if (\u0008\u0013\u000A.\u000A(\u000D\u000D\u001D.\u000A(\u0012\u000D\u001D.\u000A(\u0003\u000D\u001D.\u000A(u001F13))), \u000D\u000D\u001D.\u000A(ErrorCode.AlignTitle_InvalidReference)))
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
						u001F14 = \u001C\u000D\u001D.\u000A(this);
					}
					else
					{
						ViewInfo viewInfo2;
						if (!\u0016\u000D\u001D.\u000A(u001F2, \u000B\u000D\u001D.\u000A(u001F13), ref viewInfo2))
						{
							continue;
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
						u001F14 = viewInfo2;
					}
					\u0005\u000D\u001D.\u000A(list, \u001D\u0019.\u0004(u001F14, \u0012\u000D\u001D.\u000A(\u0003\u000D\u001D.\u000A(u001F13))));
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
			if (\u0007 != null)
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
				if (Enumerable.Any<OperationResult<long>>(\u000F\u000D\u001D.\u001D(\u0007)))
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
					enumerator = \u0006\u000D\u001D.\u000A(\u000F\u000D\u001D.\u0007(\u0007));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							OperationResult<long> u001F15 = \u0002\u000D\u001D.\u000A(enumerator);
							ViewInfo u001F16;
							if (\u0016\u000D\u001D.\u000A(u001F2, \u000B\u000D\u001D.\u000A(u001F15), ref u001F16))
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
								\u0005\u000D\u001D.\u000A(list, \u001D\u0019.\u0019(u001F16));
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
						if (enumerator != null)
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
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x0002C4BC File Offset: 0x0002A6BC
		public static AlignReport \u0004(ViewInfo \u001F, ErrorCode \u000A)
		{
			string text;
			string text2;
			if (!\u0013\u000D\u001D.\u000A(\u001D\u0019.\u001F, \u000A, ref text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0019.\u0004(ViewInfo, ErrorCode)).MethodHandle;
				}
				text2 = \u0014\u000D\u001D.\u000A();
			}
			else
			{
				text2 = text;
			}
			string u000A = text2;
			AlignReport alignReport = \u0017\u000D\u001D.\u000A();
			\u0020\u000D\u001D.\u000A(alignReport, \u0005\u001C\u001D.\u001D(\u001F));
			\u0011\u000D\u001D.\u000A(alignReport, \u001E\u000D\u001D.\u000A(\u001F));
			\u0020\u0014\u0007.\u000A(alignReport, ReportStates.Error);
			\u001B\u000D\u001D.\u000A(alignReport, u000A);
			return alignReport;
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x0002C52C File Offset: 0x0002A72C
		public static AlignReport \u0019(ViewInfo \u001F)
		{
			AlignReport alignReport = \u0017\u000D\u001D.\u000A();
			\u0020\u000D\u001D.\u000A(alignReport, \u0005\u001C\u001D.\u001D(\u001F));
			\u0011\u000D\u001D.\u000A(alignReport, \u001E\u000D\u001D.\u000A(\u001F));
			\u0020\u0014\u0007.\u000A(alignReport, ReportStates.Warning);
			\u001B\u000D\u001D.\u000A(alignReport, \u001A\u000D\u001D.\u000A());
			return alignReport;
		}

		// Token: 0x04000311 RID: 785
		private static readonly Dictionary<ErrorCode, string> \u001F;

		// Token: 0x04000312 RID: 786
		[CompilerGenerated]
		private ViewInfo \u000A;

		// Token: 0x04000313 RID: 787
		[CompilerGenerated]
		private List<ViewInfo> \u0007;
	}
}
