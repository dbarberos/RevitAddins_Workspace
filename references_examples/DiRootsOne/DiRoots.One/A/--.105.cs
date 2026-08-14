using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Morta.Enums;
using DiRoots.One.Morta.Interfaces;
using DiRoots.One.Morta.Model;
using DiRoots.One.Morta.Model.CustomTable;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x020001B4 RID: 436
	internal class \u000F\u0006 : IDataFactory
	{
		// Token: 0x06001044 RID: 4164 RVA: 0x00066A5C File Offset: 0x00064C5C
		public \u000F\u0006(Workbook \u001F, bool \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			if (Enumerable.Count<Worksheet>(\u001E\u001D\u0018.\u000A(\u001F), new Func<Worksheet, bool>(this.\u0012)) > 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006..ctor(Workbook, bool)).MethodHandle;
				}
				\u0011\u001D\u0018.\u000A(this, UploadTypes.MultipleTableUpload);
			}
		}

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x06001045 RID: 4165 RVA: 0x00066AB8 File Offset: 0x00064CB8
		// (set) Token: 0x06001046 RID: 4166 RVA: 0x00066ACC File Offset: 0x00064CCC
		public UploadTypes UploadType { get; set; }

		// Token: 0x06001047 RID: 4167 RVA: 0x00066AE0 File Offset: 0x00064CE0
		private bool \u001D(Worksheet \u001F)
		{
			if (!\u000D\u0008\u000A.\u000A(\u0020\u001D\u0018.\u000A(\u001F), "instructions", true))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u001D(Worksheet)).MethodHandle;
				}
				return \u0014\u001E\u001D.\u000A(\u0020\u001D\u0018.\u000A(\u001F), "ParamValues");
			}
			return true;
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x00066B30 File Offset: 0x00064D30
		internal bool \u0004(Window \u001F)
		{
			List<DiRoots.One.Morta.Model.ReportInfo> list = \u0010\u000A\u0018.\u000A();
			List<TableInfo> u001F = \u0014\u0007\u0018.\u000A();
			if (\u0009\u001D\u0018.\u0007(this) == UploadTypes.SingleTableUpload)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u0004(Window)).MethodHandle;
				}
				\u0015\u001D\u0018.\u000A(u001F, \u0001\u001D\u0018.\u000A(this));
			}
			else
			{
				\u001A\u001D\u0018.\u000A(u001F, \u000C\u001D\u0018.\u000A(this));
			}
			List<TableInfo>.Enumerator enumerator = \u0013\u001D\u0018.\u000A(u001F);
			try
			{
				while (\u0017\u001D\u0018.\u000A(ref enumerator))
				{
					TableInfo u001F2 = \u0014\u001D\u0018.\u000A(ref enumerator);
					this.\u0019(u001F2, list);
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
			if (\u001B\u0007\u0018.\u000A(list) > 0)
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
				ReportsWindow u001F3 = \u0003\u0018\u001D.\u000A(\u0008\u0007\u0018.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(list)), \u001E\u0011\u000A.\u000A(\u000D\u0016\u000E.\u001F()), 1005), false);
				\u0007\u0010\u001D.\u0007(u001F3, \u001F\u000F.\u0012);
				\u000C\u000E\u0007.\u0007(u001F3, \u001F);
				\u0018\u0020\u000A.\u0007(u001F3);
			}
			return \u001B\u0007\u0018.\u000A(list) > 0;
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x00066C48 File Offset: 0x00064E48
		protected void \u0019(TableInfo \u001F, List<DiRoots.One.Morta.Model.ReportInfo> \u000A)
		{
			IEnumerable<ColumnInfo> enumerable = \u0018\u0004\u0018.\u000A(\u001F);
			Func<ColumnInfo, string> func;
			if ((func = \u000F\u0006.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u0019(TableInfo, List<DiRoots.One.Morta.Model.ReportInfo>)).MethodHandle;
				}
				func = (\u000F\u0006.<>c.\u000A = new Func<ColumnInfo, string>(\u000F\u0006.<>c.\u001F.\u000E));
			}
			IEnumerable<IGrouping<string, ColumnInfo>> enumerable2 = Enumerable.GroupBy<ColumnInfo, string>(enumerable, func);
			Func<IGrouping<string, ColumnInfo>, bool> func2;
			if ((func2 = \u000F\u0006.<>c.\u0007) == null)
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
				func2 = (\u000F\u0006.<>c.\u0007 = new Func<IGrouping<string, ColumnInfo>, bool>(\u000F\u0006.<>c.\u001F.\u0008));
			}
			IEnumerable<IGrouping<string, ColumnInfo>> enumerable3 = Enumerable.Where<IGrouping<string, ColumnInfo>>(enumerable2, func2);
			Func<IGrouping<string, ColumnInfo>, string> func3;
			if ((func3 = \u000F\u0006.<>c.\u001D) == null)
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
				func3 = (\u000F\u0006.<>c.\u001D = new Func<IGrouping<string, ColumnInfo>, string>(\u000F\u0006.<>c.\u001F.\u001B));
			}
			Func<IGrouping<string, ColumnInfo>, List<ColumnInfo>> func4;
			if ((func4 = \u000F\u0006.<>c.\u0004) == null)
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
				func4 = (\u000F\u0006.<>c.\u0004 = new Func<IGrouping<string, ColumnInfo>, List<ColumnInfo>>(\u000F\u0006.<>c.\u001F.\u0011));
			}
			Dictionary<string, List<ColumnInfo>> u001F = Enumerable.ToDictionary<IGrouping<string, ColumnInfo>, string, List<ColumnInfo>>(enumerable3, func3, func4);
			if (\u0019\u0004\u0018.\u000A(u001F) > 0)
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
				List<string> list = Enumerable.ToList<string>(\u0004\u0004\u0018.\u000A(u001F));
				List<string> list2 = Enumerable.ToList<string>(Enumerable.Take<string>(Enumerable.Skip<string>(list, 0), \u0015\u0007\u0019.\u000A(list)));
				string u001F2 = ", ";
				IEnumerable<string> enumerable4 = list2;
				Func<string, string> func5;
				if ((func5 = \u000F\u0006.<>c.\u0019) == null)
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
					func5 = (\u000F\u0006.<>c.\u0019 = new Func<string, string>(\u000F\u0006.<>c.\u001F.\u001E));
				}
				string u000A = \u000E\u001D\u0019.\u000A(u001F2, Enumerable.Select<string, string>(enumerable4, func5));
				DiRoots.One.Morta.Model.ReportInfo reportInfo = \u001D\u0004\u0018.\u000A(\u001F);
				\u0007\u0004\u0018.\u0007(reportInfo, \u0003\u000A\u0018.\u0007(\u001F));
				\u000A\u0004\u0018.\u0007(reportInfo, \u0017\u0006\u0007.\u000A(\u001F\u000F.\u000D, u000A));
				\u0020\u0014\u0007.\u000A(reportInfo, ReportStates.Error);
				\u001F\u0004\u0018.\u000A(\u000A, reportInfo);
			}
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x00066DE0 File Offset: 0x00064FE0
		public TableInfo GetTable()
		{
			Worksheet u001F = \u0005\u0004\u0018.\u000A(\u001E\u001D\u0018.\u000A(this.\u001F), 0);
			return this.\u0018(u001F, true);
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x00066E10 File Offset: 0x00065010
		private TableInfo \u0018(Worksheet \u001F, bool \u000A = true)
		{
			TableInfo tableInfo = \u000E\u0004\u0018.\u000A();
			\u0010\u0007\u0018.\u0007(tableInfo, \u0020\u001D\u0018.\u000A(\u001F));
			\u0010\u0004\u0018.\u000A(tableInfo, \u0020\u001D\u0018.\u000A(\u001F));
			int num;
			if (this.\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u0018(Worksheet, bool)).MethodHandle;
				}
				num = this.\u0016(\u001F, tableInfo, \u000A);
			}
			else
			{
				num = this.\u0005(\u001F, tableInfo, \u000A);
			}
			IEnumerable<Range> enumerable = \u000D\u0004\u0018.\u000A(\u001F);
			Func<Range, int> func;
			if ((func = \u000F\u0006.<>c.\u0018) == null)
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
				func = (\u000F\u0006.<>c.\u0018 = new Func<Range, int>(\u000F\u0006.<>c.\u001F.\u0020));
			}
			int num2 = Enumerable.Max<Range>(enumerable, func);
			\u000F\u0006.\u0016\u0006 u0016_u = new \u000F\u0006.\u0016\u0006();
			u0016_u.\u001F = num + 1;
			while (u0016_u.\u001F <= num2)
			{
				IEnumerable<Range> enumerable2 = Enumerable.Where<Range>(\u000D\u0004\u0018.\u000A(\u001F), new Func<Range, bool>(u0016_u.\u000A));
				Func<Range, int> func2;
				if ((func2 = \u000F\u0006.<>c.\u0005) == null)
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
					func2 = (\u000F\u0006.<>c.\u0005 = new Func<Range, int>(\u000F\u0006.<>c.\u001F.\u0017));
				}
				List<Range> list = Enumerable.ToList<Range>(Enumerable.OrderBy<Range, int>(enumerable2, func2));
				if (Enumerable.Any<Range>(list))
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
					IEnumerable<Range> enumerable3 = list;
					Func<Range, string> func3;
					if ((func3 = \u000F\u0006.<>c.\u0016) == null)
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
						func3 = (\u000F\u0006.<>c.\u0016 = new Func<Range, string>(\u000F\u0006.<>c.\u001F.\u0014));
					}
					List<string> list2 = Enumerable.ToList<string>(Enumerable.Select<Range, string>(enumerable3, func3));
					int i = 0;
					while (i < \u000F\u0004\u0018.\u000A(\u0018\u0004\u0018.\u000A(tableInfo)))
					{
						if (\u0008\u0013\u000A.\u000A(\u0003\u0004\u0018.\u000A(\u001C\u0004\u0018.\u000A(\u0018\u0004\u0018.\u000A(tableInfo), i)), "integer"))
						{
							goto IL_1B5;
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
						if (\u0008\u0013\u000A.\u000A(\u0003\u0004\u0018.\u000A(\u001C\u0004\u0018.\u000A(\u0018\u0004\u0018.\u000A(tableInfo), i)), "float"))
						{
							for (;;)
							{
								switch (5)
								{
								case 0:
									continue;
								}
								goto IL_1B5;
							}
						}
						IL_206:
						i++;
						continue;
						IL_1B5:
						if (\u001A\u0006\u0007.\u000A(\u0001\u0013\u0007.\u000A(list2, i)))
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
							\u0012\u0004\u0018.\u000A(list2, i, "0");
						}
						\u0012\u0004\u0018.\u000A(list2, i, \u001C\u000B\u001D.\u0007(\u0001\u0013\u0007.\u000A(list2, i), ",", "."));
						goto IL_206;
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
					RowInfo rowInfo = \u0006\u0004\u0018.\u000A();
					\u0016\u0019\u001D.\u000A(\u0002\u0004\u0018.\u000A(rowInfo), list2);
					\u0016\u0004\u0018.\u000A(\u000B\u0004\u0018.\u000A(tableInfo), rowInfo);
				}
				int u001F = u0016_u.\u001F;
				u0016_u.\u001F = u001F + 1;
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
			return tableInfo;
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x0006709C File Offset: 0x0006529C
		public int \u0005(Worksheet \u001F, TableInfo \u000A, bool \u0007)
		{
			int num = \u0019\u0019\u0018.\u000A(\u000F\u0006.\u000F(\u001F));
			if (num == 3)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u0005(Worksheet, TableInfo, bool)).MethodHandle;
				}
				\u0010\u0007\u0018.\u0007(\u000A, \u001A\u000C\u000A.\u000A(\u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(\u001F), 0))));
				\u0010\u0007\u0018.\u0007(\u000A, \u0007\u0019\u0018.\u000A(\u0003\u000A\u0018.\u0007(\u000A), "^Name - ", ""));
				\u0010\u0004\u0018.\u000A(\u000A, \u0003\u000A\u0018.\u0007(\u000A));
			}
			List<ParamExportInfo> list = \u000F\u0006.\u0002(\u001F, num);
			if (\u0007)
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
				IEnumerable<ParamExportInfo> enumerable = list;
				Func<ParamExportInfo, string> func;
				if ((func = \u000F\u0006.<>c.\u000B) == null)
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
					func = (\u000F\u0006.<>c.\u000B = new Func<ParamExportInfo, string>(\u000F\u0006.<>c.\u001F.\u0013));
				}
				IEnumerable<IGrouping<string, ParamExportInfo>> enumerable2 = Enumerable.GroupBy<ParamExportInfo, string>(enumerable, func);
				Func<IGrouping<string, ParamExportInfo>, bool> func2;
				if ((func2 = \u000F\u0006.<>c.\u0002) == null)
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
					func2 = (\u000F\u0006.<>c.\u0002 = new Func<IGrouping<string, ParamExportInfo>, bool>(\u000F\u0006.<>c.\u001F.\u001A));
				}
				IEnumerable<IGrouping<string, ParamExportInfo>> enumerable3 = Enumerable.Where<IGrouping<string, ParamExportInfo>>(enumerable2, func2);
				Func<IGrouping<string, ParamExportInfo>, string> func3;
				if ((func3 = \u000F\u0006.<>c.\u0006) == null)
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
					func3 = (\u000F\u0006.<>c.\u0006 = new Func<IGrouping<string, ParamExportInfo>, string>(\u000F\u0006.<>c.\u001F.\u000C));
				}
				Func<IGrouping<string, ParamExportInfo>, List<ParamExportInfo>> func4;
				if ((func4 = \u000F\u0006.<>c.\u000F) == null)
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
					func4 = (\u000F\u0006.<>c.\u000F = new Func<IGrouping<string, ParamExportInfo>, List<ParamExportInfo>>(\u000F\u0006.<>c.\u001F.\u0015));
				}
				Dictionary<string, List<ParamExportInfo>>.Enumerator enumerator = \u000A\u0019\u0018.\u000A(Enumerable.ToDictionary<IGrouping<string, ParamExportInfo>, string, List<ParamExportInfo>>(enumerable3, func3, func4));
				try
				{
					while (\u0015\u0004\u0018.\u000A(ref enumerator))
					{
						KeyValuePair<string, List<ParamExportInfo>> keyValuePair = \u001F\u0019\u0018.\u000A(ref enumerator);
						for (int i = 1; i < \u0008\u0004\u0018.\u000A(\u0001\u0004\u0018.\u000A(ref keyValuePair)); i++)
						{
							\u0009\u0004\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0001\u0004\u0018.\u000A(ref keyValuePair), i), \u0018\u000E\u0007.\u000A("{0} ({1})", \u001A\u0004\u0018.\u000A(\u001E\u0004\u0018.\u000A(\u0001\u0004\u0018.\u000A(ref keyValuePair), i)), i));
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
			for (int j = 0; j < \u0008\u0004\u0018.\u000A(list); j++)
			{
				object u001F = \u0018\u0004\u0018.\u000A(\u000A);
				ColumnInfo columnInfo = \u000C\u0004\u0018.\u000A();
				\u0013\u0004\u0018.\u000A(columnInfo, \u001A\u0004\u0018.\u000A(\u001E\u0004\u0018.\u000A(list, j)));
				\u0017\u0004\u0018.\u000A(columnInfo, \u0014\u0004\u0018.\u0007(\u001E\u0004\u0018.\u000A(list, j)));
				\u0020\u0004\u0018.\u000A(columnInfo, this.\u000B(\u001E\u0004\u0018.\u000A(list, j)));
				\u0011\u0004\u0018.\u000A(columnInfo, ColumnInfo.\u0019(\u001E\u0004\u0018.\u000A(list, j)));
				\u001B\u0004\u0018.\u000A(u001F, columnInfo);
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
			return num;
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x00067344 File Offset: 0x00065544
		public int \u0016(Worksheet \u001F, TableInfo \u000A, bool \u0007)
		{
			\u000F\u0006.\u000B\u0006 u000B_u = new \u000F\u0006.\u000B\u0006();
			u000B_u.\u001F = 0;
			if (\u0014\u001E\u001D.\u000A(\u001A\u000C\u000A.\u000A(\u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(\u001F), 0))), "Name - "))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u0016(Worksheet, TableInfo, bool)).MethodHandle;
				}
				u000B_u.\u001F = 1;
				\u0010\u0007\u0018.\u0007(\u000A, \u001A\u000C\u000A.\u000A(\u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(\u001F), 0))));
				\u0010\u0007\u0018.\u0007(\u000A, \u0007\u0019\u0018.\u000A(\u0003\u000A\u0018.\u0007(\u000A), "^Name - ", ""));
				\u0010\u0004\u0018.\u000A(\u000A, \u0003\u000A\u0018.\u0007(\u000A));
			}
			List<Range> list = Enumerable.ToList<Range>(Enumerable.Where<Range>(\u000D\u0004\u0018.\u000A(\u001F), new Func<Range, bool>(u000B_u.\u000A)));
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
				IEnumerable<Range> enumerable = list;
				Func<Range, string> func;
				if ((func = \u000F\u0006.<>c.\u0012) == null)
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
					func = (\u000F\u0006.<>c.\u0012 = new Func<Range, string>(\u000F\u0006.<>c.\u001F.\u0001));
				}
				IEnumerable<IGrouping<string, Range>> enumerable2 = Enumerable.GroupBy<Range, string>(enumerable, func);
				Func<IGrouping<string, Range>, bool> func2;
				if ((func2 = \u000F\u0006.<>c.\u0003) == null)
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
					func2 = (\u000F\u0006.<>c.\u0003 = new Func<IGrouping<string, Range>, bool>(\u000F\u0006.<>c.\u001F.\u0009));
				}
				IEnumerable<IGrouping<string, Range>> enumerable3 = Enumerable.Where<IGrouping<string, Range>>(enumerable2, func2);
				Func<IGrouping<string, Range>, string> func3;
				if ((func3 = \u000F\u0006.<>c.\u001C) == null)
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
					func3 = (\u000F\u0006.<>c.\u001C = new Func<IGrouping<string, Range>, string>(\u000F\u0006.<>c.\u001F.\u001F\u000A));
				}
				Func<IGrouping<string, Range>, List<Range>> func4;
				if ((func4 = \u000F\u0006.<>c.\u000D) == null)
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
					func4 = (\u000F\u0006.<>c.\u000D = new Func<IGrouping<string, Range>, List<Range>>(\u000F\u0006.<>c.\u001F.\u000A\u000A));
				}
				Dictionary<string, List<Range>>.Enumerator enumerator = \u0006\u0019\u0018.\u000A(Enumerable.ToDictionary<IGrouping<string, Range>, string, List<Range>>(enumerable3, func3, func4));
				try
				{
					while (\u0005\u0019\u0018.\u000A(ref enumerator))
					{
						KeyValuePair<string, List<Range>> keyValuePair = \u0002\u0019\u0018.\u000A(ref enumerator);
						for (int i = 1; i < \u0018\u0019\u0018.\u000A(\u0016\u0019\u0018.\u000A(ref keyValuePair)); i++)
						{
							\u000B\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(\u0016\u0019\u0018.\u000A(ref keyValuePair), i), \u0018\u000E\u0007.\u000A("{0} ({1})", \u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(\u0016\u0019\u0018.\u000A(ref keyValuePair), i)), i));
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
			for (int j = 0; j < \u0018\u0019\u0018.\u000A(list); j++)
			{
				object u001F = \u0018\u0004\u0018.\u000A(\u000A);
				ColumnInfo columnInfo = \u000C\u0004\u0018.\u000A();
				\u0013\u0004\u0018.\u000A(columnInfo, \u001A\u000C\u000A.\u000A(\u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(list, j))));
				\u0020\u0004\u0018.\u000A(columnInfo, "text");
				\u001B\u0004\u0018.\u000A(u001F, columnInfo);
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
			return u000B_u.\u001F;
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x00067600 File Offset: 0x00065800
		private string \u000B(ParamExportInfo \u001F)
		{
			\u000F\u0006.\u0002\u0006 u0002_u = new \u000F\u0006.\u0002\u0006();
			u0002_u.\u001F = \u001F;
			if (Enumerable.Any<DropDownparamInfo>(DropDownparamInfo.\u0005(false), new Func<DropDownparamInfo, bool>(u0002_u.\u000A)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u000B(ParamExportInfo)).MethodHandle;
				}
				return "text";
			}
			if (!\u0012\u0019\u0018.\u000A(u0002_u.\u001F))
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
				if (\u0008\u0013\u000A.\u000A(\u000F\u0019\u0018.\u000A(u0002_u.\u001F), "Integer"))
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
					return "integer";
				}
			}
			if (\u0008\u0013\u000A.\u000A(\u000F\u0019\u0018.\u000A(u0002_u.\u001F), "Double"))
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
				return "float";
			}
			return "text";
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x000676C4 File Offset: 0x000658C4
		internal static List<ParamExportInfo> \u0002(Worksheet \u001F, int \u000A)
		{
			\u000F\u0006.\u0006\u0006 u0006_u = new \u000F\u0006.\u0006\u0006();
			u0006_u.\u001F = \u000A;
			List<ParamExportInfo> list = \u0012\u000A\u0018.\u000A();
			IEnumerable<Range> enumerable = Enumerable.Where<Range>(\u000D\u0004\u0018.\u000A(\u001F), new Func<Range, bool>(u0006_u.\u000A));
			Func<Range, int> func;
			if ((func = \u000F\u0006.<>c.\u0010) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u0002(Worksheet, int)).MethodHandle;
				}
				func = (\u000F\u0006.<>c.\u0010 = new Func<Range, int>(\u000F\u0006.<>c.\u001F.\u0007\u000A));
			}
			List<Range> u001F = Enumerable.ToList<Range>(Enumerable.OrderBy<Range, int>(enumerable, func));
			for (int i = 0; i < \u0018\u0019\u0018.\u000A(u001F); i++)
			{
				string u001F2 = \u001A\u000C\u000A.\u000A(\u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(u001F, i)));
				if (!\u001A\u0006\u0007.\u000A(u001F2))
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
					ParamExportInfo paramExportInfo = ParamExportInfo.\u0004(u001F2);
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
						\u0016\u000A\u0018.\u000A(list, paramExportInfo);
						\u000B\u000A\u0018.\u000A(paramExportInfo, u0006_u.\u001F);
					}
					else
					{
						\u0016\u000A\u0018.\u000A(list, \u000F\u0006.\u0006(u0006_u.\u001F));
					}
				}
				else
				{
					\u0016\u000A\u0018.\u000A(list, \u000F\u0006.\u0006(u0006_u.\u001F));
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
			return list;
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x000677EC File Offset: 0x000659EC
		private static ParamExportInfo \u0006(int \u001F)
		{
			ParamExportInfo paramExportInfo = \u0002\u000A\u0018.\u000A();
			\u000B\u000A\u0018.\u000A(paramExportInfo, \u001F);
			return paramExportInfo;
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00067808 File Offset: 0x00065A08
		private static ParamExportInfo \u000F(Worksheet \u001F)
		{
			ParamExportInfo result = \u0003\u0016\u000E.\u001F;
			for (int i = 0; i < 2; i++)
			{
				string u001F = \u001A\u000C\u000A.\u000A(\u001D\u0019\u0018.\u000A(\u0004\u0019\u0018.\u000A(\u000D\u0004\u0018.\u000A(\u001F), i)));
				if (!\u001A\u0006\u0007.\u000A(u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.\u000F(Worksheet)).MethodHandle;
					}
					if (\u0014\u001E\u001D.\u000A(u001F, "{"))
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
						if (\u0001\u0016\u001D.\u000A(u001F, "}"))
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
							result = ParamExportInfo.\u0004(u001F);
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
			return result;
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x000678B0 File Offset: 0x00065AB0
		public List<TableInfo> GetTables()
		{
			List<Worksheet> u001F = Enumerable.ToList<Worksheet>(Enumerable.Where<Worksheet>(\u001E\u001D\u0018.\u000A(this.\u001F), new Func<Worksheet, bool>(this.\u0003)));
			List<TableInfo> list = \u0014\u0007\u0018.\u000A();
			for (int i = 0; i < \u0003\u0019\u0018.\u000A(u001F); i++)
			{
				\u0015\u001D\u0018.\u000A(list, this.\u0018(\u0005\u0004\u0018.\u000A(u001F, i), true));
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F\u0006.GetTables()).MethodHandle;
			}
			return list;
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x0006792C File Offset: 0x00065B2C
		[CompilerGenerated]
		private bool \u0012(Worksheet \u001F)
		{
			return !this.\u001D(\u001F);
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x00067948 File Offset: 0x00065B48
		[CompilerGenerated]
		private bool \u0003(Worksheet \u001F)
		{
			return !this.\u001D(\u001F);
		}

		// Token: 0x0400067D RID: 1661
		private readonly Workbook \u001F;

		// Token: 0x0400067E RID: 1662
		private readonly bool \u000A;

		// Token: 0x0400067F RID: 1663
		[CompilerGenerated]
		private UploadTypes \u0007;

		// Token: 0x02000878 RID: 2168
		[CompilerGenerated]
		private sealed class \u0016\u0006
		{
			// Token: 0x06004F38 RID: 20280 RVA: 0x001E3490 File Offset: 0x001E1690
			internal bool \u000A(Range \u001F)
			{
				return \u0002\u001C\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x040021DF RID: 8671
			public int \u001F;
		}

		// Token: 0x02000879 RID: 2169
		[CompilerGenerated]
		private sealed class \u000B\u0006
		{
			// Token: 0x06004F3A RID: 20282 RVA: 0x001E34C4 File Offset: 0x001E16C4
			internal bool \u000A(Range \u001F)
			{
				return \u0002\u001C\u0005.\u000A(\u001F) == this.\u001F;
			}

			// Token: 0x040021E0 RID: 8672
			public int \u001F;
		}

		// Token: 0x0200087A RID: 2170
		[CompilerGenerated]
		private sealed class \u0002\u0006
		{
			// Token: 0x06004F3C RID: 20284 RVA: 0x001E34F8 File Offset: 0x001E16F8
			internal bool \u000A(DropDownparamInfo \u001F)
			{
				return \u001A\u0008\u0019.\u000A(\u0005\u001B\u0005.\u001D(this.\u001F), \u0005\u0019\u0010.\u000A(\u001F));
			}

			// Token: 0x040021E1 RID: 8673
			public ParamExportInfo \u001F;
		}

		// Token: 0x0200087B RID: 2171
		[CompilerGenerated]
		private sealed class \u0006\u0006
		{
			// Token: 0x06004F3E RID: 20286 RVA: 0x001E3538 File Offset: 0x001E1738
			internal bool \u000A(Range \u001F)
			{
				return \u0002\u001C\u0005.\u000A(\u001F) == this.\u001F - 1;
			}

			// Token: 0x040021E2 RID: 8674
			public int \u001F;
		}
	}
}
