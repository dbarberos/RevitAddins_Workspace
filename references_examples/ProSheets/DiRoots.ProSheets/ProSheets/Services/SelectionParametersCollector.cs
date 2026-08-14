using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using A;
using Autodesk.Revit.DB;
using DiRoots.ProSheets.ViewModels;

namespace ProSheets.Services
{
	// Token: 0x020000A1 RID: 161
	public class SelectionParametersCollector
	{
		// Token: 0x06000973 RID: 2419 RVA: 0x0003A500 File Offset: 0x00038700
		public SelectionParametersCollector(Document document, List<ViewSheet> sheetsList, List<View> viewsList)
		{
			string[] array = \u000C\u0002\u000F.\u000C(4);
			array[0] = "sr view calculation settings";
			array[1] = "sr document guid";
			array[2] = "dirootsid";
			array[3] = "workset";
			this.\u000C = array;
			string[] array2 = \u000C\u0002\u000F.\u000C(14);
			array2[0] = "%Y";
			array2[1] = "%m";
			array2[2] = "%d";
			array2[3] = "%H";
			array2[4] = "%M";
			array2[5] = "%S";
			array2[6] = "%yy";
			array2[7] = "%mm";
			array2[8] = "%dd";
			array2[9] = "%HH";
			array2[10] = "%MM";
			array2[11] = "%SS";
			array2[12] = "%UserName%";
			array2[13] = "%SheetSize%";
			this.\u0018 = array2;
			base..ctor();
			this.\u0014 = this.\u001E(sheetsList);
			this.\u0003 = this.\u0017(viewsList);
			this.\u0016 = this.\u0002(document);
			this.\u000F = this.\u0015();
			\u000C\u000E\u0003.\u0018(this, this.\u001F());
			\u000E\u0005\u0003.\u0018(this, this.\u000A());
			\u0005\u0005\u0003.\u0018(this, this.\u0011());
			\u001B\u0005\u0003.\u0018(this, Enumerable.ToList<SelectionParameter>(Enumerable.Concat<SelectionParameter>(this.\u0014, this.\u000F)));
			\u0001\u0005\u0003.\u0018(this, Enumerable.ToList<SelectionParameter>(Enumerable.Concat<SelectionParameter>(this.\u0003, this.\u000F)));
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000974 RID: 2420 RVA: 0x0003A66C File Offset: 0x0003886C
		// (set) Token: 0x06000975 RID: 2421 RVA: 0x0003A680 File Offset: 0x00038880
		public ParameterBaseModel SheetsParamModel { get; set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000976 RID: 2422 RVA: 0x0003A694 File Offset: 0x00038894
		// (set) Token: 0x06000977 RID: 2423 RVA: 0x0003A6A8 File Offset: 0x000388A8
		public ParameterBaseModel ViewsParamModel { get; set; }

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000978 RID: 2424 RVA: 0x0003A6BC File Offset: 0x000388BC
		// (set) Token: 0x06000979 RID: 2425 RVA: 0x0003A6D0 File Offset: 0x000388D0
		public ParameterBaseModel ProjectParamModel { get; set; }

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x0600097A RID: 2426 RVA: 0x0003A6E4 File Offset: 0x000388E4
		// (set) Token: 0x0600097B RID: 2427 RVA: 0x0003A6F8 File Offset: 0x000388F8
		public List<SelectionParameter> UnSelectedSheetParameters { get; set; }

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x0600097C RID: 2428 RVA: 0x0003A70C File Offset: 0x0003890C
		// (set) Token: 0x0600097D RID: 2429 RVA: 0x0003A720 File Offset: 0x00038920
		public List<SelectionParameter> UnSelectedViewParameters { get; set; }

		// Token: 0x0600097E RID: 2430 RVA: 0x0003A734 File Offset: 0x00038934
		private ParameterBaseModel \u000A()
		{
			List<SelectionParameter> list = this.\u0020(false);
			ParameterBaseModel parameterBaseModel = \u0014\u000E\u0003.\u0018(list, \u0013\u000B\u0014.\u0018());
			\u0018\u000E\u0003.\u0018(parameterBaseModel, Enumerable.ToList<SelectionParameter>(list));
			\u0001\u0003\u0003.\u0018(parameterBaseModel, "-");
			\u0005\u0003\u0003.\u0018(parameterBaseModel, true);
			return parameterBaseModel;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x0003A77C File Offset: 0x0003897C
		internal List<SelectionParameter> \u0020(bool \u000C = true)
		{
			List<SelectionParameter> list = \u0013\u000B\u0014.\u0018();
			IEnumerable<SelectionParameter> u;
			if (!\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParametersCollector.\u0020(bool)).MethodHandle;
				}
				u = this.\u0003;
			}
			else
			{
				u = this.\u0014;
			}
			\u0003\u000E\u0003.\u0018(list, u);
			\u0003\u000E\u0003.\u0018(list, this.\u0016);
			\u0003\u000E\u0003.\u0018(list, this.\u000F);
			return list;
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x0003A7D4 File Offset: 0x000389D4
		private ParameterBaseModel \u001F()
		{
			List<SelectionParameter> list = this.\u0020(true);
			ParameterBaseModel parameterBaseModel = \u0014\u000E\u0003.\u0018(list, \u0013\u000B\u0014.\u0018());
			\u0018\u000E\u0003.\u0018(parameterBaseModel, Enumerable.ToList<SelectionParameter>(list));
			\u0001\u0003\u0003.\u0018(parameterBaseModel, "-");
			\u0005\u0003\u0003.\u0018(parameterBaseModel, true);
			return parameterBaseModel;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x0003A81C File Offset: 0x00038A1C
		private ParameterBaseModel \u0011()
		{
			List<SelectionParameter> list = \u0013\u000B\u0014.\u0018();
			\u0003\u000E\u0003.\u0018(list, this.\u0016);
			object u000C = list;
			IEnumerable<SelectionParameter> u000F = this.\u000F;
			Func<SelectionParameter, bool> func;
			if ((func = SelectionParametersCollector.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParametersCollector.\u0011()).MethodHandle;
				}
				func = (SelectionParametersCollector.<>c.\u0018 = new Func<SelectionParameter, bool>(SelectionParametersCollector.<>c.\u000C.\u000F));
			}
			\u0003\u000E\u0003.\u0018(u000C, Enumerable.Where<SelectionParameter>(u000F, func));
			ParameterBaseModel parameterBaseModel = \u0014\u000E\u0003.\u0018(list, \u0013\u000B\u0014.\u0018());
			\u0018\u000E\u0003.\u0018(parameterBaseModel, Enumerable.ToList<SelectionParameter>(list));
			\u0001\u0003\u0003.\u0018(parameterBaseModel, "-");
			\u0005\u0003\u0003.\u0018(parameterBaseModel, true);
			\u0016\u000E\u0003.\u0018(parameterBaseModel, true);
			return parameterBaseModel;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x0003A8B8 File Offset: 0x00038AB8
		private List<SelectionParameter> \u0015()
		{
			SelectionParametersCollector.\u000F\u0020\u0018 u000F_u0020_u = new SelectionParametersCollector.\u000F\u0020\u0018();
			List<SelectionParameter> list = \u0013\u000B\u0014.\u0018();
			u000F_u0020_u.\u000C = 2;
			u000F_u0020_u.\u0018 = \u000F\u000E\u0003.\u0018(\u0012\u000E\u0003.\u0018(128, 128, 128));
			\u0003\u000E\u0003.\u0018(list, Enumerable.Select<string, SelectionParameter>(this.\u0018, new Func<string, SelectionParameter>(u000F_u0020_u.\u0014)));
			return list;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0003A91C File Offset: 0x00038B1C
		private List<SelectionParameter> \u0017(List<View> \u000C)
		{
			List<SelectionParameter> list = \u000C\u000A\u0018.\u0011(\u000C);
			\u000D\u000E\u0003.\u0018(list, new Predicate<SelectionParameter>(this.\u0004));
			return list;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x0003A948 File Offset: 0x00038B48
		private List<SelectionParameter> \u001E(List<ViewSheet> \u000C)
		{
			List<SelectionParameter> list = \u000C\u000A\u0018.\u001F(\u000C);
			\u000D\u000E\u0003.\u0018(list, new Predicate<SelectionParameter>(this.\u001D));
			return list;
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x0003A974 File Offset: 0x00038B74
		private List<SelectionParameter> \u0002(Document \u000C)
		{
			List<SelectionParameter> list = \u0013\u000B\u0014.\u0018();
			IEnumerable<Parameter> enumerable = \u001C\u000E\u0003.\u0018(\u000E\u0002\u0018.\u0018(\u000C));
			Func<Parameter, bool> func;
			if ((func = SelectionParametersCollector.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParametersCollector.\u0002(Document)).MethodHandle;
				}
				func = (SelectionParametersCollector.<>c.\u0014 = new Func<Parameter, bool>(SelectionParametersCollector.<>c.\u000C.\u0012));
			}
			IEnumerable<Parameter> enumerable2 = Enumerable.ToList<Parameter>(Enumerable.Where<Parameter>(enumerable, func));
			Func<Parameter, bool> func2;
			if ((func2 = SelectionParametersCollector.<>c.\u0003) == null)
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
				func2 = (SelectionParametersCollector.<>c.\u0003 = new Func<Parameter, bool>(SelectionParametersCollector.<>c.\u000C.\u000D));
			}
			IEnumerable<Parameter> enumerable3 = Enumerable.Where<Parameter>(enumerable2, func2);
			Func<Parameter, SelectionParameter> func3;
			if ((func3 = SelectionParametersCollector.<>c.\u0016) == null)
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
				func3 = (SelectionParametersCollector.<>c.\u0016 = new Func<Parameter, SelectionParameter>(SelectionParametersCollector.<>c.\u000C.\u001C));
			}
			List<SelectionParameter> u = Enumerable.ToList<SelectionParameter>(Enumerable.Select<Parameter, SelectionParameter>(enumerable3, func3));
			\u0003\u000E\u0003.\u0018(list, u);
			\u000D\u000E\u0003.\u0018(list, new Predicate<SelectionParameter>(this.\u001A));
			return list;
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x0003AA5C File Offset: 0x00038C5C
		[CompilerGenerated]
		private bool \u0004(SelectionParameter \u000C)
		{
			SelectionParametersCollector.\u0012\u0020\u0018 u0012_u0020_u = new SelectionParametersCollector.\u0012\u0020\u0018();
			u0012_u0020_u.\u000C = \u000C;
			return Enumerable.Any<string>(this.\u000C, new Func<string, bool>(u0012_u0020_u.\u0018));
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x0003AA90 File Offset: 0x00038C90
		[CompilerGenerated]
		private bool \u001D(SelectionParameter \u000C)
		{
			SelectionParametersCollector.\u000D\u0020\u0018 u000D_u0020_u = new SelectionParametersCollector.\u000D\u0020\u0018();
			u000D_u0020_u.\u000C = \u000C;
			return Enumerable.Any<string>(this.\u000C, new Func<string, bool>(u000D_u0020_u.\u0018));
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x0003AAC4 File Offset: 0x00038CC4
		[CompilerGenerated]
		private bool \u001A(SelectionParameter \u000C)
		{
			SelectionParametersCollector.\u001C\u0020\u0018 u001C_u0020_u = new SelectionParametersCollector.\u001C\u0020\u0018();
			u001C_u0020_u.\u000C = \u000C;
			return Enumerable.Any<string>(this.\u000C, new Func<string, bool>(u001C_u0020_u.\u0018));
		}

		// Token: 0x0400046E RID: 1134
		private readonly string[] \u000C;

		// Token: 0x0400046F RID: 1135
		private readonly string[] \u0018;

		// Token: 0x04000470 RID: 1136
		private readonly List<SelectionParameter> \u0014;

		// Token: 0x04000471 RID: 1137
		private readonly List<SelectionParameter> \u0003;

		// Token: 0x04000472 RID: 1138
		private readonly List<SelectionParameter> \u0016;

		// Token: 0x04000473 RID: 1139
		private readonly List<SelectionParameter> \u000F;

		// Token: 0x04000474 RID: 1140
		[CompilerGenerated]
		private ParameterBaseModel \u0012;

		// Token: 0x04000475 RID: 1141
		[CompilerGenerated]
		private ParameterBaseModel \u000D;

		// Token: 0x04000476 RID: 1142
		[CompilerGenerated]
		private ParameterBaseModel \u001C;

		// Token: 0x04000477 RID: 1143
		[CompilerGenerated]
		private List<SelectionParameter> \u0013;

		// Token: 0x04000478 RID: 1144
		[CompilerGenerated]
		private List<SelectionParameter> \u0009;

		// Token: 0x020001B3 RID: 435
		[CompilerGenerated]
		private sealed class \u000F\u0020\u0018
		{
			// Token: 0x06001198 RID: 4504 RVA: 0x0005CF00 File Offset: 0x0005B100
			internal SelectionParameter \u0014(string \u000C)
			{
				SelectionParameter selectionParameter = \u0006\u0018\u0014.\u0018();
				\u0007\u0018\u0014.\u0018(selectionParameter, \u000C);
				\u000E\u001A\u0014.\u0018(selectionParameter, \u000C);
				int u000C = this.\u000C;
				this.\u000C = u000C + 1;
				\u0011\u001F\u000F.\u0018(selectionParameter, u000C);
				\u001E\u001F\u000F.\u0018(selectionParameter, this.\u0018);
				\u0017\u001F\u000F.\u0018(selectionParameter, true);
				\u0019\u0018\u0014.\u0018(selectionParameter, SelectionParameterType.Variable);
				return selectionParameter;
			}

			// Token: 0x0400084A RID: 2122
			public int \u000C;

			// Token: 0x0400084B RID: 2123
			public SolidColorBrush \u0018;
		}

		// Token: 0x020001B4 RID: 436
		[CompilerGenerated]
		private sealed class \u0012\u0020\u0018
		{
			// Token: 0x0600119A RID: 4506 RVA: 0x0005CF68 File Offset: 0x0005B168
			internal bool \u0018(string \u000C)
			{
				return \u001B\u0013\u0018.\u000C(\u0002\u0020\u0014.\u0014(this.\u000C), \u000C);
			}

			// Token: 0x0400084C RID: 2124
			public SelectionParameter \u000C;
		}

		// Token: 0x020001B5 RID: 437
		[CompilerGenerated]
		private sealed class \u000D\u0020\u0018
		{
			// Token: 0x0600119C RID: 4508 RVA: 0x0005CFA0 File Offset: 0x0005B1A0
			internal bool \u0018(string \u000C)
			{
				return \u001B\u0013\u0018.\u000C(\u0002\u0020\u0014.\u0014(this.\u000C), \u000C);
			}

			// Token: 0x0400084D RID: 2125
			public SelectionParameter \u000C;
		}

		// Token: 0x020001B6 RID: 438
		[CompilerGenerated]
		private sealed class \u001C\u0020\u0018
		{
			// Token: 0x0600119E RID: 4510 RVA: 0x0005CFD8 File Offset: 0x0005B1D8
			internal bool \u0018(string \u000C)
			{
				return \u001B\u0013\u0018.\u000C(\u0002\u0020\u0014.\u0014(this.\u000C), \u000C);
			}

			// Token: 0x0400084E RID: 2126
			public SelectionParameter \u000C;
		}
	}
}
