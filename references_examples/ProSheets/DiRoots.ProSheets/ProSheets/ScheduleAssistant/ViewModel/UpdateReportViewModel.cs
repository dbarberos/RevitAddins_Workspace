using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.ViewModels;
using ProSheets.ScheduleAssistant.Model;
using ProSheets.ScheduleAssistant.Model.Enum;
using ProSheets.ScheduleAssistant.Model.UpdateWindowModels;

namespace ProSheets.ScheduleAssistant.ViewModel
{
	// Token: 0x020000A9 RID: 169
	public class UpdateReportViewModel : ViewModelBase
	{
		// Token: 0x060009EC RID: 2540 RVA: 0x0003D9D8 File Offset: 0x0003BBD8
		public UpdateReportViewModel(List<UpdateReportModel> models)
		{
			\u001B\u000F\u0016.\u0018(this, models);
			\u0001\u000F\u0016.\u0018(this);
			\u0008\u000F\u0016.\u0018(this);
			\u0010\u000F\u0016.\u0018(this, \u0010\u0006\u0018.\u0018(\u0006\u000F\u0016.\u0018(this)));
			\u0005\u0006\u0018.\u0018(\u001A\u0016\u0016.\u0003(this), new Predicate<object>(this.\u0015\u0013));
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x060009ED RID: 2541 RVA: 0x0003DA2C File Offset: 0x0003BC2C
		// (set) Token: 0x060009EE RID: 2542 RVA: 0x0003DA40 File Offset: 0x0003BC40
		public List<UpdateReportModel> UpdateReport { get; set; }

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x060009EF RID: 2543 RVA: 0x0003DA54 File Offset: 0x0003BC54
		// (set) Token: 0x060009F0 RID: 2544 RVA: 0x0003DA68 File Offset: 0x0003BC68
		public ICollectionView TabCollectionView { get; set; }

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0003DA7C File Offset: 0x0003BC7C
		// (set) Token: 0x060009F2 RID: 2546 RVA: 0x0003DA90 File Offset: 0x0003BC90
		public List<BaseFilter> TabFilter { get; set; }

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x0003DAA4 File Offset: 0x0003BCA4
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x0003DAB8 File Offset: 0x0003BCB8
		public List<BaseFilter> StatusFilter { get; set; }

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x0003DACC File Offset: 0x0003BCCC
		// (set) Token: 0x060009F6 RID: 2550 RVA: 0x0003DAE0 File Offset: 0x0003BCE0
		public BaseFilter SelectedTabFilter
		{
			get
			{
				return this.\u0020\u0003;
			}
			set
			{
				this.\u0020\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedTabFilter");
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x0003DB00 File Offset: 0x0003BD00
		// (set) Token: 0x060009F8 RID: 2552 RVA: 0x0003DB14 File Offset: 0x0003BD14
		public BaseFilter SelectedStatusFilter
		{
			get
			{
				return this.\u001F\u0003;
			}
			set
			{
				this.\u001F\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedStatusFilter");
			}
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x0003DB34 File Offset: 0x0003BD34
		public void InitTabFilter()
		{
			\u0003\u0012\u0016.\u0018(this, \u0016\u0012\u0016.\u0018());
			IEnumerable<UpdateReportModel> enumerable = \u0006\u000F\u0016.\u0018(this);
			Func<UpdateReportModel, TabName> func;
			if ((func = UpdateReportViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateReportViewModel.InitTabFilter()).MethodHandle;
				}
				func = (UpdateReportViewModel.<>c.\u0018 = new Func<UpdateReportModel, TabName>(UpdateReportViewModel.<>c.\u000C.\u001F));
			}
			IEnumerable<IGrouping<TabName, UpdateReportModel>> enumerable2 = Enumerable.GroupBy<UpdateReportModel, TabName>(enumerable, func);
			Func<IGrouping<TabName, UpdateReportModel>, UpdateReportModel> func2;
			if ((func2 = UpdateReportViewModel.<>c.\u0014) == null)
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
				func2 = (UpdateReportViewModel.<>c.\u0014 = new Func<IGrouping<TabName, UpdateReportModel>, UpdateReportModel>(UpdateReportViewModel.<>c.\u000C.\u0011));
			}
			object u000C = Enumerable.ToList<UpdateReportModel>(Enumerable.Select<IGrouping<TabName, UpdateReportModel>, UpdateReportModel>(enumerable2, func2));
			BaseFilter u = \u0014\u0012\u0016.\u0018(\u000D\u0009\u0018.\u0009\u0003, 0);
			\u000C\u0012\u0016.\u0018(\u0010\u0016\u0016.\u0003(this), u);
			BaseFilter baseFilter = \u0014\u0012\u0016.\u0018(\u000D\u0009\u0018.\u000A\u0003, 100);
			\u0018\u0012\u0016.\u0018(baseFilter, true);
			\u000C\u0012\u0016.\u0018(\u0010\u0016\u0016.\u0003(this), baseFilter);
			\u000E\u000F\u0016.\u0018(u000C, new Action<UpdateReportModel>(this.\u0017\u0013));
			\u0019\u0016\u0016.\u0003(this, \u0005\u000F\u0016.\u0018(\u0010\u0016\u0016.\u0003(this), 0));
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x0003DC34 File Offset: 0x0003BE34
		public void InitStatusFilter()
		{
			\u000F\u0012\u0016.\u0018(this, \u0016\u0012\u0016.\u0018());
			IEnumerable<UpdateReportModel> enumerable = \u0006\u000F\u0016.\u0018(this);
			Func<UpdateReportModel, UpdateReportStatus> func;
			if ((func = UpdateReportViewModel.<>c.\u0003) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateReportViewModel.InitStatusFilter()).MethodHandle;
				}
				func = (UpdateReportViewModel.<>c.\u0003 = new Func<UpdateReportModel, UpdateReportStatus>(UpdateReportViewModel.<>c.\u000C.\u0015));
			}
			IEnumerable<IGrouping<UpdateReportStatus, UpdateReportModel>> enumerable2 = Enumerable.GroupBy<UpdateReportModel, UpdateReportStatus>(enumerable, func);
			Func<IGrouping<UpdateReportStatus, UpdateReportModel>, UpdateReportModel> func2;
			if ((func2 = UpdateReportViewModel.<>c.\u0016) == null)
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
				func2 = (UpdateReportViewModel.<>c.\u0016 = new Func<IGrouping<UpdateReportStatus, UpdateReportModel>, UpdateReportModel>(UpdateReportViewModel.<>c.\u000C.\u0017));
			}
			object u000C = Enumerable.ToList<UpdateReportModel>(Enumerable.Select<IGrouping<UpdateReportStatus, UpdateReportModel>, UpdateReportModel>(enumerable2, func2));
			BaseFilter u = \u0014\u0012\u0016.\u0018(\u000D\u0009\u0018.\u0013\u0003, 0);
			\u000C\u0012\u0016.\u0018(\u0008\u0016\u0016.\u0003(this), u);
			BaseFilter baseFilter = \u0014\u0012\u0016.\u0018(\u000D\u0009\u0018.\u000A\u0003, 100);
			\u0018\u0012\u0016.\u0018(baseFilter, true);
			\u000C\u0012\u0016.\u0018(\u0008\u0016\u0016.\u0003(this), baseFilter);
			\u000E\u000F\u0016.\u0018(u000C, new Action<UpdateReportModel>(this.\u001E\u0013));
			\u0006\u0016\u0016.\u0003(this, \u0005\u000F\u0016.\u0018(\u0008\u0016\u0016.\u0003(this), 0));
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x0003DD34 File Offset: 0x0003BF34
		private bool \u0015\u0013(object \u000C)
		{
			UpdateReportModel updateReportModel = \u000E\u0007\u000F.\u000C(\u000C);
			if (updateReportModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateReportViewModel.\u0015\u0013(object)).MethodHandle;
				}
				return false;
			}
			bool flag = \u0012\u0012\u0016.\u0018(this, \u0010\u0016\u0016.\u0003(this), (int)\u0016\u000F\u0016.\u0018(updateReportModel));
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
				flag = \u0012\u0012\u0016.\u0018(this, \u0008\u0016\u0016.\u0003(this), (int)\u0003\u000F\u0016.\u0018(updateReportModel));
			}
			return flag;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x0003DDA4 File Offset: 0x0003BFA4
		public bool ReportFilter(List<BaseFilter> baseFilter, int tabIndex)
		{
			UpdateReportViewModel.\u0017\u0020\u0018 u0017_u0020_u = new UpdateReportViewModel.\u0017\u0020\u0018();
			u0017_u0020_u.\u000C = tabIndex;
			if (\u0013\u0012\u0016.\u0018(\u0005\u000F\u0016.\u0018(baseFilter, 0)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateReportViewModel.ReportFilter(List<BaseFilter>, int)).MethodHandle;
				}
				return true;
			}
			Func<BaseFilter, bool> func;
			if ((func = UpdateReportViewModel.<>c.\u000F) == null)
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
				func = (UpdateReportViewModel.<>c.\u000F = new Func<BaseFilter, bool>(UpdateReportViewModel.<>c.\u000C.\u001E));
			}
			if (Enumerable.Count<BaseFilter>(baseFilter, func) == 1)
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
				Predicate<BaseFilter> u;
				if ((u = UpdateReportViewModel.<>c.\u0012) == null)
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
					u = (UpdateReportViewModel.<>c.\u0012 = new Predicate<BaseFilter>(UpdateReportViewModel.<>c.\u000C.\u0002));
				}
				int num = \u000D\u0012\u0016.\u0018(\u001C\u0012\u0016.\u0018(baseFilter, u));
				return u0017_u0020_u.\u000C == num;
			}
			Func<BaseFilter, bool> func2;
			if ((func2 = UpdateReportViewModel.<>c.\u000D) == null)
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
				func2 = (UpdateReportViewModel.<>c.\u000D = new Func<BaseFilter, bool>(UpdateReportViewModel.<>c.\u000C.\u0004));
			}
			if (Enumerable.Count<BaseFilter>(baseFilter, func2) > 1)
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
				Func<BaseFilter, bool> func3;
				if ((func3 = UpdateReportViewModel.<>c.\u001C) == null)
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
					func3 = (UpdateReportViewModel.<>c.\u001C = new Func<BaseFilter, bool>(UpdateReportViewModel.<>c.\u000C.\u001D));
				}
				return Enumerable.Any<BaseFilter>(Enumerable.Where<BaseFilter>(baseFilter, func3), new Func<BaseFilter, bool>(u0017_u0020_u.\u0018));
			}
			return false;
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x0003DEEC File Offset: 0x0003C0EC
		public BaseFilter SetSelectedFilter(List<BaseFilter> baseFilter)
		{
			BaseFilter result = \u0005\u0007\u000F.\u000C;
			\u0018\u0012\u0016.\u0018(\u0005\u000F\u0016.\u0018(baseFilter, 1), true);
			\u0009\u0012\u0016.\u0014(\u0005\u000F\u0016.\u0018(baseFilter, 1), false);
			if (\u0013\u0012\u0016.\u0018(\u0005\u000F\u0016.\u0018(baseFilter, 0)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateReportViewModel.SetSelectedFilter(List<BaseFilter>)).MethodHandle;
				}
				result = \u0005\u000F\u0016.\u0018(baseFilter, 0);
			}
			else
			{
				Func<BaseFilter, bool> func;
				if ((func = UpdateReportViewModel.<>c.\u0013) == null)
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
					func = (UpdateReportViewModel.<>c.\u0013 = new Func<BaseFilter, bool>(UpdateReportViewModel.<>c.\u000C.\u001A));
				}
				if (Enumerable.Count<BaseFilter>(baseFilter, func) == 1)
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
					Predicate<BaseFilter> u;
					if ((u = UpdateReportViewModel.<>c.\u0009) == null)
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
						u = (UpdateReportViewModel.<>c.\u0009 = new Predicate<BaseFilter>(UpdateReportViewModel.<>c.\u000C.\u000B));
					}
					result = \u001C\u0012\u0016.\u0018(baseFilter, u);
				}
				else
				{
					Func<BaseFilter, bool> func2;
					if ((func2 = UpdateReportViewModel.<>c.\u000A) == null)
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
						func2 = (UpdateReportViewModel.<>c.\u000A = new Func<BaseFilter, bool>(UpdateReportViewModel.<>c.\u000C.\u0019));
					}
					if (Enumerable.Count<BaseFilter>(baseFilter, func2) > 1)
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
						\u0018\u0012\u0016.\u0018(\u0005\u000F\u0016.\u0018(baseFilter, 1), false);
						\u0009\u0012\u0016.\u0014(\u0005\u000F\u0016.\u0018(baseFilter, 1), true);
						result = \u0005\u000F\u0016.\u0018(baseFilter, 1);
					}
					else
					{
						result = \u0005\u000F\u0016.\u0018(baseFilter, 0);
					}
				}
			}
			return result;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0003E038 File Offset: 0x0003C238
		public void ReportFilterChecked(List<BaseFilter> baseFilter, string content)
		{
			UpdateReportViewModel.\u001E\u0020\u0018 u001E_u0020_u = new UpdateReportViewModel.\u001E\u0020\u0018();
			u001E_u0020_u.\u000C = baseFilter;
			\u0009\u0012\u0016.\u0014(\u0005\u000F\u0016.\u0018(u001E_u0020_u.\u000C, 1), true);
			List<BaseFilter> list = Enumerable.ToList<BaseFilter>(Enumerable.Skip<BaseFilter>(u001E_u0020_u.\u000C, 2));
			if (\u000F\u0002\u0018.\u0018(\u001F\u0012\u0016.\u0018(\u0005\u000F\u0016.\u0018(u001E_u0020_u.\u000C, 0)), content))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(UpdateReportViewModel.ReportFilterChecked(List<BaseFilter>, string)).MethodHandle;
				}
				\u0020\u0012\u0016.\u0018(list, new Action<BaseFilter>(u001E_u0020_u.\u0018));
				return;
			}
			\u0009\u0012\u0016.\u0014(\u0005\u000F\u0016.\u0018(u001E_u0020_u.\u000C, 0), false);
			object u000C = list;
			Predicate<BaseFilter> u;
			if ((u = UpdateReportViewModel.<>c.\u0020) == null)
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
				u = (UpdateReportViewModel.<>c.\u0020 = new Predicate<BaseFilter>(UpdateReportViewModel.<>c.\u000C.\u0007));
			}
			if (\u000A\u0012\u0016.\u0018(u000C, u))
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
				\u0009\u0012\u0016.\u0014(\u0005\u000F\u0016.\u0018(u001E_u0020_u.\u000C, 0), true);
			}
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x0003E128 File Offset: 0x0003C328
		[CompilerGenerated]
		private void \u0017\u0013(UpdateReportModel \u000C)
		{
			BaseFilter u = \u0014\u0012\u0016.\u0018(\u000C\u000F\u0016.\u0018(\u000C), (int)\u0016\u000F\u0016.\u0018(\u000C));
			\u000C\u0012\u0016.\u0018(\u0010\u0016\u0016.\u0003(this), u);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x0003E15C File Offset: 0x0003C35C
		[CompilerGenerated]
		private void \u001E\u0013(UpdateReportModel \u000C)
		{
			BaseFilter u = \u0014\u0012\u0016.\u0018(\u0014\u000F\u0016.\u0018(\u000C), (int)\u0003\u000F\u0016.\u0018(\u000C));
			\u000C\u0012\u0016.\u0018(\u0008\u0016\u0016.\u0003(this), u);
		}

		// Token: 0x040004A0 RID: 1184
		private BaseFilter \u0020\u0003;

		// Token: 0x040004A1 RID: 1185
		private BaseFilter \u001F\u0003;

		// Token: 0x040004A2 RID: 1186
		[CompilerGenerated]
		private List<UpdateReportModel> \u0009\u0003;

		// Token: 0x040004A3 RID: 1187
		[CompilerGenerated]
		private ICollectionView \u0011\u0003;

		// Token: 0x040004A4 RID: 1188
		[CompilerGenerated]
		private List<BaseFilter> \u0015\u0003;

		// Token: 0x040004A5 RID: 1189
		[CompilerGenerated]
		private List<BaseFilter> \u0017\u0003;

		// Token: 0x020001C0 RID: 448
		[CompilerGenerated]
		private sealed class \u0017\u0020\u0018
		{
			// Token: 0x060011C5 RID: 4549 RVA: 0x0005D46C File Offset: 0x0005B66C
			internal bool \u0018(BaseFilter \u000C)
			{
				return \u000D\u0012\u0016.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x0400086A RID: 2154
			public int \u000C;
		}

		// Token: 0x020001C1 RID: 449
		[CompilerGenerated]
		private sealed class \u001E\u0020\u0018
		{
			// Token: 0x060011C7 RID: 4551 RVA: 0x0005D4A0 File Offset: 0x0005B6A0
			internal void \u0018(BaseFilter \u000C)
			{
				\u0009\u0012\u0016.\u0014(\u000C, \u0013\u0012\u0016.\u0018(\u0005\u000F\u0016.\u0018(this.\u000C, 0)));
			}

			// Token: 0x0400086B RID: 2155
			public List<BaseFilter> \u000C;
		}
	}
}
