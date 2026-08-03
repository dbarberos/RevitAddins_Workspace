using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using DiRoots.One.Commons;
using DiRoots.One.Commons.ViewModels;
using KellermanSoftware.CompareNetObjects;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Extensions;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.Attributes;
using ProSheets.ScheduleAssistant.Model;
using ProSheets.ScheduleAssistant.Model.Enum;
using ProSheets.ScheduleAssistant.UI;

namespace ProSheets.ScheduleAssistant.ViewModel
{
	// Token: 0x020000A8 RID: 168
	public class ScheduleViewModel : ViewModelBase
	{
		// Token: 0x060009A6 RID: 2470 RVA: 0x0003C0A4 File Offset: 0x0003A2A4
		public ScheduleViewModel()
		{
			DateTime dateTime = \u0019\u0015\u0014.\u0018();
			this.\u0007\u0014 = \u0004\u0014\u0016.\u0018(ref dateTime, -2.0);
			this.FilePath = string.Empty;
			this.WeekDays = new List<WeekDay>();
			List<string> list = new List<string>();
			\u0019\u0017\u0014.\u0018(list, \u001C\u0009\u0018.\u0011\u0016);
			\u0019\u0017\u0014.\u0018(list, \u001C\u0009\u0018.\u0020\u0016);
			\u0019\u0017\u0014.\u0018(list, \u001C\u0009\u0018.\u001F\u0016);
			this.RepeatModes = list;
			this.UpdateReport = new List<UpdateReportModel>();
			base..ctor();
			WeekDay weekDay = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay, DayOfWeek.Monday);
			\u0002\u0014\u0016.\u0018(this, weekDay);
			WeekDay weekDay2 = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay2, DayOfWeek.Tuesday);
			\u001E\u0014\u0016.\u0018(this, weekDay2);
			WeekDay weekDay3 = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay3, DayOfWeek.Wednesday);
			\u0017\u0014\u0016.\u0018(this, weekDay3);
			WeekDay weekDay4 = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay4, DayOfWeek.Thursday);
			\u0015\u0014\u0016.\u0018(this, weekDay4);
			WeekDay weekDay5 = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay5, DayOfWeek.Friday);
			\u0011\u0014\u0016.\u0018(this, weekDay5);
			WeekDay weekDay6 = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay6, DayOfWeek.Saturday);
			\u001F\u0014\u0016.\u0018(this, weekDay6);
			WeekDay weekDay7 = new WeekDay();
			\u0020\u0014\u0016.\u0018(weekDay7, DayOfWeek.Sunday);
			\u000A\u0014\u0016.\u0018(this, weekDay7);
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u0009\u0014\u0016.\u0018(this));
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u0013\u0014\u0016.\u0018(this));
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u001C\u0014\u0016.\u0018(this));
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u000D\u0014\u0016.\u0018(this));
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u0012\u0014\u0016.\u0018(this));
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u000F\u0014\u0016.\u0018(this));
			\u0014\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), \u0003\u0014\u0016.\u0018(this));
			\u0009\u0018\u0003.\u0003(this);
			this.\u000F\u0013();
			this.\u0016\u0013();
		}

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060009A7 RID: 2471 RVA: 0x0003C25C File Offset: 0x0003A45C
		// (remove) Token: 0x060009A8 RID: 2472 RVA: 0x0003C2A8 File Offset: 0x0003A4A8
		public event ScheduleViewModel.GetProfileValuesHandler GetProfileValuesEvent
		{
			[CompilerGenerated]
			add
			{
				ScheduleViewModel.GetProfileValuesHandler getProfileValuesHandler = this.\u000B\u0014;
				ScheduleViewModel.GetProfileValuesHandler getProfileValuesHandler2;
				do
				{
					getProfileValuesHandler2 = getProfileValuesHandler;
					ScheduleViewModel.GetProfileValuesHandler value2 = (ScheduleViewModel.GetProfileValuesHandler)\u001C\u0019\u0018.\u0018(getProfileValuesHandler2, value);
					getProfileValuesHandler = Interlocked.CompareExchange<ScheduleViewModel.GetProfileValuesHandler>(ref this.\u000B\u0014, value2, getProfileValuesHandler2);
				}
				while (getProfileValuesHandler != getProfileValuesHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.add_GetProfileValuesEvent(ScheduleViewModel.GetProfileValuesHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				ScheduleViewModel.GetProfileValuesHandler getProfileValuesHandler = this.\u000B\u0014;
				ScheduleViewModel.GetProfileValuesHandler getProfileValuesHandler2;
				do
				{
					getProfileValuesHandler2 = getProfileValuesHandler;
					ScheduleViewModel.GetProfileValuesHandler value2 = (ScheduleViewModel.GetProfileValuesHandler)\u0013\u0019\u0018.\u0018(getProfileValuesHandler2, value);
					getProfileValuesHandler = Interlocked.CompareExchange<ScheduleViewModel.GetProfileValuesHandler>(ref this.\u000B\u0014, value2, getProfileValuesHandler2);
				}
				while (getProfileValuesHandler != getProfileValuesHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.remove_GetProfileValuesEvent(ScheduleViewModel.GetProfileValuesHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x060009A9 RID: 2473 RVA: 0x0003C2F4 File Offset: 0x0003A4F4
		// (set) Token: 0x060009AA RID: 2474 RVA: 0x0003C308 File Offset: 0x0003A508
		public string FilePath { get; set; }

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060009AB RID: 2475 RVA: 0x0003C31C File Offset: 0x0003A51C
		// (set) Token: 0x060009AC RID: 2476 RVA: 0x0003C330 File Offset: 0x0003A530
		public WeekDay Monday { get; set; }

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x060009AD RID: 2477 RVA: 0x0003C344 File Offset: 0x0003A544
		// (set) Token: 0x060009AE RID: 2478 RVA: 0x0003C358 File Offset: 0x0003A558
		public WeekDay Tuesday { get; set; }

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x060009AF RID: 2479 RVA: 0x0003C36C File Offset: 0x0003A56C
		// (set) Token: 0x060009B0 RID: 2480 RVA: 0x0003C380 File Offset: 0x0003A580
		public WeekDay Wednesday { get; set; }

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0003C394 File Offset: 0x0003A594
		// (set) Token: 0x060009B2 RID: 2482 RVA: 0x0003C3A8 File Offset: 0x0003A5A8
		public WeekDay Thursday { get; set; }

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060009B3 RID: 2483 RVA: 0x0003C3BC File Offset: 0x0003A5BC
		// (set) Token: 0x060009B4 RID: 2484 RVA: 0x0003C3D0 File Offset: 0x0003A5D0
		public WeekDay Friday { get; set; }

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060009B5 RID: 2485 RVA: 0x0003C3E4 File Offset: 0x0003A5E4
		// (set) Token: 0x060009B6 RID: 2486 RVA: 0x0003C3F8 File Offset: 0x0003A5F8
		public WeekDay Saturday { get; set; }

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060009B7 RID: 2487 RVA: 0x0003C40C File Offset: 0x0003A60C
		// (set) Token: 0x060009B8 RID: 2488 RVA: 0x0003C420 File Offset: 0x0003A620
		public WeekDay Sunday { get; set; }

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060009B9 RID: 2489 RVA: 0x0003C434 File Offset: 0x0003A634
		// (set) Token: 0x060009BA RID: 2490 RVA: 0x0003C448 File Offset: 0x0003A648
		public UpdateReportViewModel UpdateReportVM { get; set; }

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x060009BB RID: 2491 RVA: 0x0003C45C File Offset: 0x0003A65C
		// (set) Token: 0x060009BC RID: 2492 RVA: 0x0003C470 File Offset: 0x0003A670
		public bool UpdateAvailable
		{
			get
			{
				return this.\u0001\u0014;
			}
			set
			{
				this.\u0001\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "UpdateAvailable");
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x060009BD RID: 2493 RVA: 0x0003C490 File Offset: 0x0003A690
		// (set) Token: 0x060009BE RID: 2494 RVA: 0x0003C4A4 File Offset: 0x0003A6A4
		public List<WeekDay> WeekDays { get; set; }

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x060009BF RID: 2495 RVA: 0x0003C4B8 File Offset: 0x0003A6B8
		// (set) Token: 0x060009C0 RID: 2496 RVA: 0x0003C4CC File Offset: 0x0003A6CC
		public string ScheduleStatus
		{
			get
			{
				return this.\u0008\u0014;
			}
			set
			{
				this.\u0008\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "ScheduleStatus");
			}
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x060009C1 RID: 2497 RVA: 0x0003C4EC File Offset: 0x0003A6EC
		// (set) Token: 0x060009C2 RID: 2498 RVA: 0x0003C500 File Offset: 0x0003A700
		public SchedulerStatus SchedulerStatus
		{
			get
			{
				return this.\u001B\u0014;
			}
			set
			{
				this.\u001B\u0014 = value;
				this.\u001F\u0013();
				\u0011\u0010\u0018.\u0018(this, "SchedulerStatus");
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x0003C528 File Offset: 0x0003A728
		// (set) Token: 0x060009C4 RID: 2500 RVA: 0x0003C53C File Offset: 0x0003A73C
		public bool IsSchedule
		{
			get
			{
				return this.\u0010\u0014;
			}
			set
			{
				this.\u0010\u0014 = value;
				this.\u000F\u0013();
				this.\u0016\u0013();
				\u0011\u0010\u0018.\u0018(this, "IsSchedule");
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x060009C5 RID: 2501 RVA: 0x0003C568 File Offset: 0x0003A768
		// (set) Token: 0x060009C6 RID: 2502 RVA: 0x0003C57C File Offset: 0x0003A77C
		public DateTime Time
		{
			get
			{
				return this.\u0007\u0014;
			}
			set
			{
				this.\u0007\u0014 = value;
				\u0008\u000C\u0014.\u0003(this);
				\u0011\u0010\u0018.\u0018(this, "Time");
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x060009C7 RID: 2503 RVA: 0x0003C5A4 File Offset: 0x0003A7A4
		// (set) Token: 0x060009C8 RID: 2504 RVA: 0x0003C5B8 File Offset: 0x0003A7B8
		public DateTime Date
		{
			get
			{
				return this.\u0019\u0014;
			}
			set
			{
				this.\u0019\u0014 = value;
				\u0008\u000C\u0014.\u0003(this);
				\u0011\u0010\u0018.\u0018(this, "Date");
			}
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x060009C9 RID: 2505 RVA: 0x0003C5E0 File Offset: 0x0003A7E0
		// (set) Token: 0x060009CA RID: 2506 RVA: 0x0003C5F4 File Offset: 0x0003A7F4
		public List<string> RepeatModes { get; set; }

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x060009CB RID: 2507 RVA: 0x0003C608 File Offset: 0x0003A808
		// (set) Token: 0x060009CC RID: 2508 RVA: 0x0003C61C File Offset: 0x0003A81C
		public int SelectRepeatMode
		{
			get
			{
				return this.\u0006\u0014;
			}
			set
			{
				this.\u0006\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectRepeatMode");
			}
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x060009CD RID: 2509 RVA: 0x0003C63C File Offset: 0x0003A83C
		// (set) Token: 0x060009CE RID: 2510 RVA: 0x0003C650 File Offset: 0x0003A850
		public string ScheduleProfileName { get; set; }

		// Token: 0x060009CF RID: 2511 RVA: 0x0003C664 File Offset: 0x0003A864
		public void SetScheduler()
		{
			if (!\u0010\u000C\u0014.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.SetScheduler()).MethodHandle;
				}
				return;
			}
			SchedulerTimer schedulerTimer = \u001F\u0018\u0003.\u0018();
			if (schedulerTimer == null)
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
				return;
			}
			\u0001\u0014\u0016.\u0018(this, \u001C\u0018\u0016.\u0018(schedulerTimer));
			\u0008\u0014\u0016.\u0018(this, \u0011\u0018\u0016.\u0018(schedulerTimer));
			\u0006\u0014\u0016.\u0018(this, \u0009\u0018\u0016.\u0018(schedulerTimer));
			\u0010\u0014\u0016.\u0018(this, (int)\u001D\u0018\u0016.\u0018(schedulerTimer));
			List<WeekDay>.Enumerator enumerator = \u0007\u0014\u0016.\u0018(\u0004\u0018\u0016.\u0018(schedulerTimer));
			try
			{
				while (\u001D\u0014\u0016.\u0018(ref enumerator))
				{
					ScheduleViewModel.\u0011\u0020\u0018 u0011_u0020_u = new ScheduleViewModel.\u0011\u0020\u0018();
					u0011_u0020_u.\u000C = \u0019\u0014\u0016.\u0018(ref enumerator);
					WeekDay weekDay = \u000B\u0014\u0016.\u0018(\u0016\u0014\u0016.\u0018(this), new Predicate<WeekDay>(u0011_u0020_u.\u0018));
					if (weekDay != null)
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
						\u001A\u0014\u0016.\u0018(weekDay, true);
					}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0003C76C File Offset: 0x0003A96C
		private void \u0016\u0013()
		{
			bool u;
			if (\u0010\u000C\u0014.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u0016\u0013()).MethodHandle;
				}
				u = (\u0005\u0014\u0016.\u0018(this) != SchedulerStatus.Updated);
			}
			else
			{
				u = false;
			}
			\u001B\u0014\u0016.\u0018(this, u);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0003C7B0 File Offset: 0x0003A9B0
		private void \u000F\u0013()
		{
			SchedulerStatus u;
			if (!\u0010\u000C\u0014.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u000F\u0013()).MethodHandle;
				}
				u = SchedulerStatus.Off;
			}
			else
			{
				u = SchedulerStatus.Updated;
			}
			\u0018\u0003\u0016.\u0018(this, u);
			\u000E\u0014\u0016.\u0018(this, \u000C\u0003\u0016.\u0018());
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x060009D2 RID: 2514 RVA: 0x0003C7F4 File Offset: 0x0003A9F4
		// (set) Token: 0x060009D3 RID: 2515 RVA: 0x0003C808 File Offset: 0x0003AA08
		public List<UpdateReportModel> UpdateReport { get; set; }

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x060009D4 RID: 2516 RVA: 0x0003C81C File Offset: 0x0003AA1C
		// (set) Token: 0x060009D5 RID: 2517 RVA: 0x0003C830 File Offset: 0x0003AA30
		public ProSheetCurrentData ProSheetsSavedData { get; set; }

		// Token: 0x060009D6 RID: 2518 RVA: 0x0003C844 File Offset: 0x0003AA44
		public void CompairData()
		{
			if (!\u0010\u000C\u0014.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.CompairData()).MethodHandle;
				}
				return;
			}
			\u000E\u0014\u0016.\u0018(this, \u000C\u0003\u0016.\u0018());
			string text = \u0003\u001A\u0018.\u0018(\u001D\u0020\u0018.\u0018(), \u000D\u001E\u0018.\u0018(\u0007\u000C\u0014.\u0003(this), ".xml"));
			if (!\u000C\u001A\u0018.\u0018(text))
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
			\u001D\u0003\u0016.\u0018(this, XMLUtility.DeserialiseInfo<ProSheetCurrentData>(text));
			ProSheetCurrentData proSheetCurrentData = this.\u0011\u0013();
			object u000C = \u001C\u0003\u0016.\u0018(\u0012\u0003\u0016.\u0018(this));
			Action<SheetInfo> u;
			if ((u = ScheduleViewModel.<>c.\u0018) == null)
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
				u = (ScheduleViewModel.<>c.\u0018 = new Action<SheetInfo>(ScheduleViewModel.<>c.\u000C.\u000D));
			}
			\u0020\u0005\u0018.\u0018(u000C, u);
			List<UpdateReportModel> list = \u000C\u0003\u0016.\u0018();
			IEnumerable<PrintDetails> enumerable = \u0004\u000C\u0014.\u0018(\u0012\u0003\u0016.\u0018(this));
			Func<PrintDetails, long> func;
			if ((func = ScheduleViewModel.<>c.\u0014) == null)
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
				func = (ScheduleViewModel.<>c.\u0014 = new Func<PrintDetails, long>(ScheduleViewModel.<>c.\u000C.\u001C));
			}
			List<long> u000C2 = Enumerable.ToList<long>(Enumerable.Distinct<long>(Enumerable.Select<PrintDetails, long>(enumerable, func)));
			IEnumerable<SheetInfo> enumerable2 = \u0010\u000E\u0018.\u0018();
			Func<SheetInfo, long> func2;
			if ((func2 = ScheduleViewModel.<>c.\u0003) == null)
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
				func2 = (ScheduleViewModel.<>c.\u0003 = new Func<SheetInfo, long>(ScheduleViewModel.<>c.\u000C.\u0013));
			}
			IEnumerable<long> enumerable3 = Enumerable.Distinct<long>(Enumerable.Select<SheetInfo, long>(enumerable2, func2));
			List<long>.Enumerator enumerator = \u0004\u0003\u0016.\u0018(u000C2);
			try
			{
				while (\u0015\u0003\u0016.\u0018(ref enumerator))
				{
					ScheduleViewModel.\u0015\u0020\u0018 u0015_u0020_u = new ScheduleViewModel.\u0015\u0020\u0018();
					u0015_u0020_u.\u000C = \u0002\u0003\u0016.\u0018(ref enumerator);
					if (!Enumerable.Contains<long>(enumerable3, u0015_u0020_u.\u000C))
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
						UpdateReportModel updateReportModel = \u001F\u0003\u0016.\u0018();
						\u0020\u0003\u0016.\u0018(updateReportModel, UpdateReportStatus.Removed);
						PrintDetails u000C3 = \u0001\u000E\u0018.\u0018(\u0004\u000C\u0014.\u0018(\u0012\u0003\u0016.\u0018(this)), new Predicate<PrintDetails>(u0015_u0020_u.\u0018));
						\u000A\u0003\u0016.\u0018(updateReportModel, \u001A\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0010\u0016, \u001E\u0003\u0016.\u0018(u000C3), \u0017\u0003\u0016.\u0018(u000C3)));
						\u0009\u0003\u0016.\u0018(updateReportModel, TabName.Selection);
						\u0013\u0003\u0016.\u0018(list, updateReportModel);
					}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IEnumerator<SheetInfo> enumerator2 = \u0009\u0005\u0018.\u0018(Enumerable.Distinct<SheetInfo>(\u0010\u000E\u0018.\u0018(), \u0011\u0003\u0016.\u0018()));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator2))
				{
					SheetInfo u000C4 = \u0013\u0005\u0018.\u0018(enumerator2);
					if (!\u0013\u000E\u0018.\u0018(u000C2, \u0015\u0005\u0018.\u0014(u000C4).\u000C()))
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
						UpdateReportModel updateReportModel2 = \u001F\u0003\u0016.\u0018();
						\u0020\u0003\u0016.\u0018(updateReportModel2, UpdateReportStatus.Added);
						\u000A\u0003\u0016.\u0018(updateReportModel2, \u001A\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0007\u0016, \u001E\u000E\u0018.\u0014(u000C4), \u0002\u000E\u0018.\u0014(u000C4)));
						\u0009\u0003\u0016.\u0018(updateReportModel2, TabName.Selection);
						\u0013\u0003\u0016.\u0018(list, updateReportModel2);
					}
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
			finally
			{
				if (enumerator2 != null)
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
					\u0020\u001E\u0018.\u0018(enumerator2);
				}
			}
			\u000D\u0003\u0016.\u0018(this, \u001C\u0003\u0016.\u0018(\u0012\u0003\u0016.\u0018(this)), \u001C\u0003\u0016.\u0018(proSheetCurrentData));
			\u000F\u0003\u0016.\u0018(this, \u0017\u000A\u0014.\u0018(\u0012\u0003\u0016.\u0018(this)), \u0017\u000A\u0014.\u0018(proSheetCurrentData));
			\u0016\u0003\u0016.\u0018(this, proSheetCurrentData);
			\u0003\u0003\u0016.\u0018(\u0014\u0003\u0016.\u0018(this), list);
			if (Enumerable.Any<UpdateReportModel>(\u0014\u0003\u0016.\u0018(this)))
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
				\u0018\u0003\u0016.\u0018(this, SchedulerStatus.NotUpdated);
			}
			else
			{
				\u0018\u0003\u0016.\u0018(this, SchedulerStatus.Updated);
			}
			this.\u0016\u0013();
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0003CBD8 File Offset: 0x0003ADD8
		public void IsSelectionDataEqual(List<SheetInfo> previousData, List<SheetInfo> currentData)
		{
			CompareLogic u000C = \u0010\u0003\u0016.\u0018();
			\u0007\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C), int.MaxValue);
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "ElementId");
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "SheetSize");
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "Orientation");
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "Format");
			\u001A\u0003\u0016.\u0018(u000C, previousData, currentData);
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0003CC6C File Offset: 0x0003AE6C
		public void IsFormatDataEqual(ExportTemPlateInfo previousData, ExportTemPlateInfo currentData)
		{
			CompareLogic u000C = \u0010\u0003\u0016.\u0018();
			\u0007\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C), int.MaxValue);
			\u0019\u0017\u0014.\u0018(\u000E\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "SelectedProjectParameters");
			\u0019\u0017\u0014.\u0018(\u000E\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "SelectionViews");
			\u0019\u0017\u0014.\u0018(\u000E\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "SelectionSheets");
			\u0019\u0017\u0014.\u0018(\u000E\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "ParameterModels");
			List<Difference>.Enumerator enumerator = \u001B\u0003\u0016.\u0018(\u0005\u0003\u0016.\u0018(\u001A\u0003\u0016.\u0018(u000C, previousData, currentData)));
			try
			{
				while (\u0008\u0003\u0016.\u0018(ref enumerator))
				{
					Difference u000C2 = \u0001\u0003\u0016.\u0018(ref enumerator);
					this.\u0012\u0013(u000C2);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.IsFormatDataEqual(ExportTemPlateInfo, ExportTemPlateInfo)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			Type u = \u0004\u0017\u0018.\u0014(previousData);
			\u0006\u0003\u0016.\u0018(this, \u000B\u0003\u0003.\u0003(previousData), \u000B\u0003\u0003.\u0003(currentData), u, "SelectSheetParameters");
			\u0006\u0003\u0016.\u0018(this, \u001A\u0003\u0003.\u0003(previousData), \u001A\u0003\u0003.\u0003(currentData), u, "SelectViewParameters");
			\u0006\u0003\u0016.\u0018(this, \u000B\u0007\u0003.\u0018(previousData), \u000B\u0007\u0003.\u0018(currentData), u, "CustomFileNameParameters");
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0003CDBC File Offset: 0x0003AFBC
		public void IsCreateDataEqual(ProSheetCurrentData currentData)
		{
			CompareLogic u000C = \u0010\u0003\u0016.\u0018();
			\u0007\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C), int.MaxValue);
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "FileSavePath");
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "SplitFiles");
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "ReportSaveType");
			List<Difference>.Enumerator enumerator = \u001B\u0003\u0016.\u0018(\u0005\u0003\u0016.\u0018(\u001A\u0003\u0016.\u0018(u000C, \u0012\u0003\u0016.\u0018(this), currentData)));
			try
			{
				while (\u0008\u0003\u0016.\u0018(ref enumerator))
				{
					Difference u000C2 = \u0001\u0003\u0016.\u0018(ref enumerator);
					this.\u0012\u0013(u000C2);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.IsCreateDataEqual(ProSheetCurrentData)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			CompareLogic u000C3 = \u0010\u0003\u0016.\u0018();
			\u0007\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C3), 1000);
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C3)), "SheetSize");
			\u0019\u0017\u0014.\u0018(\u000B\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C3)), "Orientation");
			IEnumerable<Difference> enumerable = \u0005\u0003\u0016.\u0018(\u001A\u0003\u0016.\u0018(u000C3, \u001C\u0003\u0016.\u0018(\u0012\u0003\u0016.\u0018(this)), \u001C\u0003\u0016.\u0018(currentData)));
			Func<Difference, bool> func;
			if ((func = ScheduleViewModel.<>c.\u0016) == null)
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
				func = (ScheduleViewModel.<>c.\u0016 = new Func<Difference, bool>(ScheduleViewModel.<>c.\u000C.\u0009));
			}
			IEnumerator<Difference> enumerator2 = \u000D\u0016\u0016.\u0018(Enumerable.Where<Difference>(enumerable, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator2))
				{
					Difference u000C4 = \u0012\u0016\u0016.\u0018(enumerator2);
					UpdateReportModel updateReportModel = \u001F\u0003\u0016.\u0018();
					\u0003\u0016\u0016.\u0018(updateReportModel, this.\u0013\u0013(\u000F\u0016\u0016.\u0018(u000C4), \u0016\u0016\u0016.\u0018(u000C4)));
					\u0009\u0003\u0016.\u0018(updateReportModel, TabName.Create);
					string u = string.Empty;
					if (\u000F\u0002\u0018.\u0018(\u0014\u0016\u0016.\u0018(updateReportModel), "SheetSize"))
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
						u = \u001A\u001E\u0018.\u0018(\u001C\u0009\u0018.\u000B\u0016, \u001E\u000E\u0018.\u0014(\u0003\u001D\u000F.\u000C(\u0018\u0016\u0016.\u0018(u000C4))), \u0002\u000E\u0018.\u0014(\u0003\u001D\u000F.\u000C(\u0018\u0016\u0016.\u0018(u000C4))));
					}
					if (\u000F\u0002\u0018.\u0018(\u0014\u0016\u0016.\u0018(updateReportModel), "Orientation"))
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
						u = \u001A\u001E\u0018.\u0018(\u001C\u0009\u0018.\u0019\u0016, \u001E\u000E\u0018.\u0014(\u0003\u001D\u000F.\u000C(\u0018\u0016\u0016.\u0018(u000C4))), \u0002\u000E\u0018.\u0014(\u0003\u001D\u000F.\u000C(\u0018\u0016\u0016.\u0018(u000C4))));
					}
					\u000A\u0003\u0016.\u0018(updateReportModel, u);
					\u0020\u0003\u0016.\u0018(updateReportModel, this.\u001C\u0013(\u000C\u0016\u0016.\u0018(u000C4)));
					\u0013\u0003\u0016.\u0018(\u0014\u0003\u0016.\u0018(this), updateReportModel);
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
				if (enumerator2 != null)
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
					\u0020\u001E\u0018.\u0018(enumerator2);
				}
			}
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0003D0C4 File Offset: 0x0003B2C4
		public void CheckCustomFileName(Parameters previousParameter, Parameters currentParameter, Type type, string propName)
		{
			CompareLogic u000C = \u0010\u0003\u0016.\u0018();
			\u0007\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C), int.MaxValue);
			\u0019\u0017\u0014.\u0018(\u000E\u0003\u0016.\u0018(\u0019\u0003\u0016.\u0018(u000C)), "ParameterModels");
			if (!\u001C\u0016\u0016.\u0018(\u001A\u0003\u0016.\u0018(u000C, previousParameter, currentParameter)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.CheckCustomFileName(Parameters, Parameters, Type, string)).MethodHandle;
				}
				this.\u000D\u0013(\u0016\u0010\u0018.\u0018(), propName, type);
			}
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0003D138 File Offset: 0x0003B338
		private void \u0012\u0013(Difference \u000C)
		{
			string u = this.\u0013\u0013(\u000F\u0016\u0016.\u0018(\u000C), \u0016\u0016\u0016.\u0018(\u000C));
			Type u2 = \u0004\u0017\u0018.\u0014(\u0013\u0016\u0016.\u0018(\u000C));
			this.\u000D\u0013(\u000C\u0016\u0016.\u0018(\u000C), u, u2);
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0003D180 File Offset: 0x0003B380
		private void \u000D\u0013(object \u000C, string \u0018, Type \u0014)
		{
			UpdateReportAttribute updateReportAttribute = \u001B\u0007\u000F.\u000C(Enumerable.FirstOrDefault<object>(\u0011\u0016\u0016.\u0018(\u0007\u0012\u0014.\u0018(\u0014, \u0018), \u000A\u001D\u0018.\u0018(\u0001\u0007\u000F.\u000C()), true)));
			if (updateReportAttribute != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u000D\u0013(object, string, Type)).MethodHandle;
				}
				UpdateReportModel updateReportModel = \u001F\u0003\u0016.\u0018();
				\u0003\u0016\u0016.\u0018(updateReportModel, \u001F\u0016\u0016.\u0018(updateReportAttribute));
				\u0009\u0003\u0016.\u0018(updateReportModel, \u0020\u0016\u0016.\u0018(updateReportAttribute));
				\u000A\u0003\u0016.\u0018(updateReportModel, \u000A\u0016\u0016.\u0018(updateReportAttribute));
				\u0020\u0003\u0016.\u0018(updateReportModel, UpdateReportStatus.Changed);
				if (!\u0009\u0016\u0016.\u0018(updateReportAttribute))
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
					\u0020\u0003\u0016.\u0018(updateReportModel, this.\u001C\u0013(\u000C));
				}
				\u0013\u0003\u0016.\u0018(\u0014\u0003\u0016.\u0018(this), updateReportModel);
			}
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0003D240 File Offset: 0x0003B440
		private UpdateReportStatus \u001C\u0013(object \u000C)
		{
			UpdateReportStatus result = UpdateReportStatus.Changed;
			if (\u000C\u001D\u000F.\u000C(\u000C) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u001C\u0013(object)).MethodHandle;
				}
				bool flag = \u0017\u0002\u000F.\u000C(\u000C);
				result = UpdateReportStatus.Removed;
				if (flag)
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
					result = UpdateReportStatus.Added;
				}
			}
			return result;
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0003D288 File Offset: 0x0003B488
		private string \u0013\u0013(string \u000C, string \u0018)
		{
			if (\u001F\u001A\u0018.\u0018(\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u0013\u0013(string, string)).MethodHandle;
				}
				return \u000C;
			}
			return \u0010\u000B\u0014.\u0018(\u000C, \u000D\u001E\u0018.\u0018(\u0018, "."), string.Empty);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0003D2D4 File Offset: 0x0003B4D4
		[BindableMethod("SaveCurrentData")]
		public void SaveCurrentData()
		{
			string u000C = \u001D\u0020\u0018.\u0018();
			string u000C2 = \u001B\u0020\u0018.\u0012(\u0007\u0015\u0018.\u0003, true);
			string u000C3 = \u0009\u0006\u0018.\u0018(u000C, "TimerQueue", \u000D\u001E\u0018.\u0018(u000C2, ".xml"));
			if (!\u0012\u0006\u0018.\u0018(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.SaveCurrentData()).MethodHandle;
				}
				\u000F\u0006\u0018.\u0018(u000C);
			}
			\u0008\u000C\u0014.\u0003(this);
			\u0001\u0014\u0016.\u0018(this, \u001C\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018()));
			string text = \u0003\u001A\u0018.\u0018(u000C, \u000D\u001E\u0018.\u0018(\u0007\u000C\u0014.\u0003(this), ".xml"));
			if (!\u0010\u000C\u0014.\u0003(this))
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
				if (\u000C\u001A\u0018.\u0018(text))
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
					\u000C\u0020\u0014.\u0018(text);
				}
				if (\u000C\u001A\u0018.\u0018(u000C3))
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
					\u000C\u0020\u0014.\u0018(u000C3);
				}
				\u000C\u0015\u0014.\u0018(\u000E\u000B\u000F.\u000C);
				return;
			}
			if (!\u000C\u001A\u0018.\u0018(text))
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
				\u0001\u0014\u0016.\u0018(this, \u001D\u001B\u0018.\u0018().ToString());
				\u000B\u0018\u0016.\u0018(\u001F\u0018\u0003.\u0018(), \u0007\u000C\u0014.\u0003(this));
				text = \u0003\u001A\u0018.\u0018(u000C, \u000D\u001E\u0018.\u0018(\u0007\u000C\u0014.\u0003(this), ".xml"));
			}
			XMLUtility.SerialiseInfo<ProSheetCurrentData>(this.\u0011\u0013(), text);
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0003D438 File Offset: 0x0003B638
		public void SetSchedulerTimer()
		{
			this.\u0009\u0013();
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0003D44C File Offset: 0x0003B64C
		private void \u0009\u0013()
		{
			SchedulerTimer u000C = \u0008\u0018\u0016.\u0018();
			\u0017\u0018\u0016.\u0018(u000C, \u001E\u0016\u0016.\u0018(this));
			\u0019\u0018\u0016.\u0018(u000C, \u0017\u0016\u0016.\u0018(this));
			\u0010\u0018\u0016.\u0018(u000C, (RepeatMode)\u0015\u0016\u0016.\u0018(this));
			IEnumerable<WeekDay> enumerable = \u0016\u0014\u0016.\u0018(this);
			Func<WeekDay, bool> func;
			if ((func = ScheduleViewModel.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u0009\u0013()).MethodHandle;
				}
				func = (ScheduleViewModel.<>c.\u000F = new Func<WeekDay, bool>(ScheduleViewModel.<>c.\u000C.\u000A));
			}
			\u0007\u0018\u0016.\u0018(u000C, Enumerable.ToList<WeekDay>(Enumerable.Where<WeekDay>(enumerable, func)));
			\u000B\u0018\u0016.\u0018(u000C, \u0007\u000C\u0014.\u0003(this));
			\u000C\u0015\u0014.\u0018(u000C);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0003D4EC File Offset: 0x0003B6EC
		public void Update()
		{
			if (Enumerable.Any<UpdateReportModel>(\u0014\u0003\u0016.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.Update()).MethodHandle;
				}
				this.\u000A\u0013();
				\u0004\u0016\u0016.\u0018(this, \u001D\u0016\u0016.\u0018(\u0014\u0003\u0016.\u0018(this)));
				UpdateReport u000C = \u0002\u0016\u0016.\u0018();
				\u001C\u000B\u0018.\u0014(u000C, this);
				\u001B\u0007\u0018.\u0018(u000C, \u0001\u000C\u0014.\u0018(this));
				\u001E\u0007\u0018.\u0014(u000C);
			}
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0003D55C File Offset: 0x0003B75C
		[BindableMethod("ReportTabRefresh")]
		public void ReportTabRefresh()
		{
			\u0019\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this), \u0007\u0016\u0016.\u0018(\u000B\u0016\u0016.\u0018(this), \u0010\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this))));
			\u001D\u0008\u0018.\u0018(\u001A\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this)));
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0003D5A8 File Offset: 0x0003B7A8
		[BindableMethod("ReportStatusRefresh")]
		public void ReportStatusRefresh()
		{
			\u0006\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this), \u0007\u0016\u0016.\u0018(\u000B\u0016\u0016.\u0018(this), \u0008\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this))));
			\u001D\u0008\u0018.\u0018(\u001A\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this)));
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0003D5F4 File Offset: 0x0003B7F4
		[BindableMethod("TabFilterChecked")]
		public void TabFilterChecked(string content)
		{
			\u0001\u0016\u0016.\u0018(\u000B\u0016\u0016.\u0018(this), \u0010\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this)), content);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0003D620 File Offset: 0x0003B820
		[BindableMethod("StatusFilterChecked")]
		public void StatusFilterChecked(string content)
		{
			\u0001\u0016\u0016.\u0018(\u000B\u0016\u0016.\u0018(this), \u0008\u0016\u0016.\u0014(\u000B\u0016\u0016.\u0018(this)), content);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0003D64C File Offset: 0x0003B84C
		[BindableMethod("SaveData")]
		public void SaveData(Window window)
		{
			\u0017\u000C\u0014.\u0003(this);
			\u0018\u0003\u0016.\u0018(this, SchedulerStatus.Updated);
			\u000E\u0014\u0016.\u0018(this, \u000C\u0003\u0016.\u0018());
			this.\u0016\u0013();
			\u000B\u000B\u0018.\u0014(window);
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0003D680 File Offset: 0x0003B880
		private void \u000A\u0013()
		{
			List<UpdateReportModel> list = \u000C\u0003\u0016.\u0018();
			List<UpdateReportModel>.Enumerator enumerator = \u0012\u000F\u0016.\u0018(\u0014\u0003\u0016.\u0018(this));
			try
			{
				while (\u001B\u0016\u0016.\u0018(ref enumerator))
				{
					UpdateReportModel u000C = \u000F\u000F\u0016.\u0018(ref enumerator);
					UpdateReportModel updateReportModel = \u001F\u0003\u0016.\u0018();
					\u0003\u0016\u0016.\u0018(updateReportModel, \u0014\u0016\u0016.\u0018(u000C));
					\u0020\u0003\u0016.\u0018(updateReportModel, \u0003\u000F\u0016.\u0018(u000C));
					\u0009\u0003\u0016.\u0018(updateReportModel, \u0016\u000F\u0016.\u0018(u000C));
					\u000E\u0016\u0016.\u0018(updateReportModel, \u0016\u000F\u0016.\u0018(u000C).\u000C());
					\u0018\u000F\u0016.\u0018(updateReportModel, \u0003\u000F\u0016.\u0018(u000C).\u000C());
					\u0018\u000F\u0016.\u0018(updateReportModel, this.\u0020\u0013(\u0014\u000F\u0016.\u0018(updateReportModel)));
					\u000E\u0016\u0016.\u0018(updateReportModel, this.\u0020\u0013(\u000C\u000F\u0016.\u0018(updateReportModel)));
					\u000A\u0003\u0016.\u0018(updateReportModel, this.\u0020\u0013(\u0005\u0016\u0016.\u0018(u000C)));
					\u0013\u0003\u0016.\u0018(list, updateReportModel);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u000A\u0013()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u000E\u0014\u0016.\u0018(this, list);
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0003D7A4 File Offset: 0x0003B9A4
		private string \u0020\u0013(string \u000C)
		{
			string result = \u000C;
			if (\u000A\u0017\u0014.\u0018(\u000C, "-"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u0020\u0013(string)).MethodHandle;
				}
				result = \u0013\u0009\u0018.\u000C(\u000C, \u000C);
			}
			return result;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0003D7E0 File Offset: 0x0003B9E0
		private void \u001F\u0013()
		{
			switch (\u0005\u0014\u0016.\u0018(this))
			{
			case SchedulerStatus.Off:
				\u000D\u000F\u0016.\u0018(this, \u001C\u0009\u0018.\u0017\u0016);
				return;
			case SchedulerStatus.Updated:
				\u000D\u000F\u0016.\u0018(this, \u001C\u0009\u0018.\u0015\u0016);
				return;
			case SchedulerStatus.NotUpdated:
				\u000D\u000F\u0016.\u0018(this, \u001C\u0009\u0018.\u001A\u0016);
				return;
			default:
				return;
			}
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0003D834 File Offset: 0x0003BA34
		private ProSheetCurrentData \u0011\u0013()
		{
			ProSheetCurrentData proSheetCurrentData = \u0007\u000F\u0016.\u0018();
			\u0019\u000F\u0016.\u0018(this, \u000C\u001C\u0003.\u0018(\u000E\u000F\u0003.\u0018()));
			\u001A\u000F\u0016.\u0018(proSheetCurrentData, \u000B\u000F\u0016.\u0018(this));
			\u001D\u000F\u0016.\u0018(proSheetCurrentData, \u001B\u0018\u0016.\u0018());
			\u0004\u000F\u0016.\u0018(proSheetCurrentData, \u0011\u0010\u0014.\u0018());
			\u0018\u0020\u0014.\u0018(proSheetCurrentData, \u0003\u0020\u0014.\u0018());
			ScheduleViewModel.GetProfileValuesHandler u000B_u = this.\u000B\u0014;
			if (u000B_u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ScheduleViewModel.\u0011\u0013()).MethodHandle;
				}
			}
			else
			{
				\u0002\u000F\u0016.\u0018(u000B_u, \u0017\u000A\u0014.\u0018(proSheetCurrentData));
			}
			\u0017\u000F\u0016.\u0018(proSheetCurrentData, \u001E\u000F\u0016.\u0018());
			\u0015\u000F\u0016.\u0018(proSheetCurrentData, \u001C\u0017\u0014.\u0018());
			if (\u001C\u0017\u0014.\u0018() != null)
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
				object u000C = \u001C\u0003\u0016.\u0018(proSheetCurrentData);
				Action<SheetInfo> u;
				if ((u = ScheduleViewModel.<>c.\u0012) == null)
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
					u = (ScheduleViewModel.<>c.\u0012 = new Action<SheetInfo>(ScheduleViewModel.<>c.\u000C.\u0020));
				}
				\u0020\u0005\u0018.\u0018(u000C, u);
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u001C\u0017\u0014.\u0018());
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						SheetInfo u000C2 = \u000C\u000C\u0014.\u0018(ref enumerator);
						PrintDetails printDetails = \u0011\u000F\u0016.\u0018();
						\u001F\u000F\u0016.\u0018(printDetails, \u0002\u000E\u0018.\u0014(u000C2));
						\u0020\u000F\u0016.\u0018(printDetails, \u0011\u0017\u0014.\u0014(u000C2));
						\u000A\u000F\u0016.\u0018(printDetails, \u0010\u0020\u0014.\u0014(u000C2));
						\u0009\u000F\u0016.\u0018(printDetails, \u0004\u0017\u0014.\u0018(u000C2));
						\u0013\u000F\u0016.\u0018(printDetails, \u0015\u0005\u0018.\u0014(u000C2).\u000C());
						\u001C\u000F\u0016.\u0018(\u0004\u000C\u0014.\u0018(proSheetCurrentData), printDetails);
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
			}
			return proSheetCurrentData;
		}

		// Token: 0x0400048A RID: 1162
		[CompilerGenerated]
		private ScheduleViewModel.GetProfileValuesHandler \u000B\u0014;

		// Token: 0x0400048B RID: 1163
		private DateTime \u0019\u0014 = \u001F\u0018\u0016.\u0018();

		// Token: 0x0400048C RID: 1164
		private DateTime \u0007\u0014;

		// Token: 0x0400048D RID: 1165
		private bool \u0010\u0014;

		// Token: 0x0400048E RID: 1166
		private int \u0006\u0014;

		// Token: 0x0400048F RID: 1167
		private string \u0008\u0014;

		// Token: 0x04000490 RID: 1168
		private bool \u0001\u0014;

		// Token: 0x04000491 RID: 1169
		private SchedulerStatus \u001B\u0014;

		// Token: 0x04000492 RID: 1170
		[CompilerGenerated]
		private string \u0005\u0014;

		// Token: 0x04000493 RID: 1171
		[CompilerGenerated]
		private WeekDay \u000E\u0014;

		// Token: 0x04000494 RID: 1172
		[CompilerGenerated]
		private WeekDay \u000C\u0003;

		// Token: 0x04000495 RID: 1173
		[CompilerGenerated]
		private WeekDay \u0018\u0003;

		// Token: 0x04000496 RID: 1174
		[CompilerGenerated]
		private WeekDay \u0014\u0003;

		// Token: 0x04000497 RID: 1175
		[CompilerGenerated]
		private WeekDay \u0003\u0003;

		// Token: 0x04000498 RID: 1176
		[CompilerGenerated]
		private WeekDay \u0016\u0003;

		// Token: 0x04000499 RID: 1177
		[CompilerGenerated]
		private WeekDay \u000F\u0003;

		// Token: 0x0400049A RID: 1178
		[CompilerGenerated]
		private UpdateReportViewModel \u0012\u0003;

		// Token: 0x0400049B RID: 1179
		[CompilerGenerated]
		private List<WeekDay> \u000D\u0003;

		// Token: 0x0400049C RID: 1180
		[CompilerGenerated]
		private List<string> \u001C\u0003;

		// Token: 0x0400049D RID: 1181
		[CompilerGenerated]
		private string \u0013\u0003;

		// Token: 0x0400049E RID: 1182
		[CompilerGenerated]
		private List<UpdateReportModel> \u0009\u0003;

		// Token: 0x0400049F RID: 1183
		[CompilerGenerated]
		private ProSheetCurrentData \u000A\u0003;

		// Token: 0x020001BB RID: 443
		// (Invoke) Token: 0x060011A7 RID: 4519
		public delegate void GetProfileValuesHandler(ExportTemPlateInfo templateInfo);

		// Token: 0x020001BD RID: 445
		[CompilerGenerated]
		private sealed class \u0011\u0020\u0018
		{
			// Token: 0x060011B3 RID: 4531 RVA: 0x0005D1D0 File Offset: 0x0005B3D0
			internal bool \u0018(WeekDay \u000C)
			{
				return \u0004\u001F\u000F.\u0018(\u000C) == \u0004\u001F\u000F.\u0018(this.\u000C);
			}

			// Token: 0x0400085B RID: 2139
			public WeekDay \u000C;
		}

		// Token: 0x020001BE RID: 446
		[CompilerGenerated]
		private sealed class \u0015\u0020\u0018
		{
			// Token: 0x060011B5 RID: 4533 RVA: 0x0005D208 File Offset: 0x0005B408
			internal bool \u0018(PrintDetails \u000C)
			{
				return \u0008\u0009\u000F.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x0400085C RID: 2140
			public long \u000C;
		}
	}
}
