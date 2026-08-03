using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons;
using DiRoots.One.Commons.ViewModels;
using ProSheets;
using ProSheets.Extensions;
using ProSheets.Models;
using ProSheets.ScheduleAssistant.Model;
using ProSheets.ScheduleAssistant.ViewModel;
using ProSheets.Services;
using ProSheets.UI.CommonData;
using ProSheets.ViewModels;

namespace DiRoots.ProSheets.ViewModels
{
	// Token: 0x0200002F RID: 47
	public class MainWindowModel : ViewModelBase
	{
		// Token: 0x060001B3 RID: 435 RVA: 0x00009F14 File Offset: 0x00008114
		public MainWindowModel(Window window, Document document)
		{
			this.\u0004\u0018 = document;
			\u000B\u0005\u0018.\u0003(this, window);
			\u000F\u000E\u0018.\u0018(this, new ViewSheetSetViewModel(this.\u0004\u0018));
			\u000B\u0005\u0018.\u0014(\u0016\u000E\u0018.\u0014(this), window);
			\u0003\u000E\u0018.\u0014(this, new ViewsSheetsCollector(this.\u0004\u0018));
			\u000C\u000E\u0018.\u0018(this, new SelectionParametersCollector(this.\u0004\u0018, \u0014\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0014(this)), \u0018\u000E\u0018.\u0018(\u000E\u0005\u0018.\u0014(this))));
			\u001B\u0005\u0018.\u0018(this, \u0005\u0005\u0018.\u0018(\u000E\u0005\u0018.\u0014(this)));
			\u0001\u0005\u0018.\u0014(this, new List<long>());
			\u0010\u0005\u0018.\u0018(this, \u0006\u0005\u0018.\u0018(\u0008\u0005\u0018.\u0018(this), 0));
			\u0007\u0005\u0018.\u0018(this, new BaseViewModel());
			\u0019\u0005\u0018.\u0018(this, new BaseViewModel());
			ScheduleViewModel scheduleViewModel = new ScheduleViewModel();
			\u000B\u0005\u0018.\u0014(scheduleViewModel, window);
			\u001A\u0005\u0018.\u0018(this, scheduleViewModel);
			XmlExporterViewModel implementation = new XmlExporterViewModel(\u001D\u0005\u0018.\u0014(this));
			\u0004\u0005\u0018.\u0018().Unregister<XmlExporterViewModel>();
			\u0004\u0005\u0018.\u0018().RegisterSingleton<XmlExporterViewModel>(implementation);
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060001B4 RID: 436 RVA: 0x0000A028 File Offset: 0x00008228
		// (set) Token: 0x060001B5 RID: 437 RVA: 0x0000A03C File Offset: 0x0000823C
		public List<PrintDetails> SelectViewSheets { get; set; } = new List<PrintDetails>();

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060001B6 RID: 438 RVA: 0x0000A050 File Offset: 0x00008250
		// (set) Token: 0x060001B7 RID: 439 RVA: 0x0000A064 File Offset: 0x00008264
		public List<long> ActiveViewSheetsIds { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060001B8 RID: 440 RVA: 0x0000A078 File Offset: 0x00008278
		// (set) Token: 0x060001B9 RID: 441 RVA: 0x0000A08C File Offset: 0x0000828C
		public bool IsOpenSheet
		{
			get
			{
				return this.\u001D\u0018;
			}
			set
			{
				this.\u001D\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "IsOpenSheet");
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060001BA RID: 442 RVA: 0x0000A0AC File Offset: 0x000082AC
		// (set) Token: 0x060001BB RID: 443 RVA: 0x0000A0C0 File Offset: 0x000082C0
		public List<string> ViewTypes { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060001BC RID: 444 RVA: 0x0000A0D4 File Offset: 0x000082D4
		// (set) Token: 0x060001BD RID: 445 RVA: 0x0000A0E8 File Offset: 0x000082E8
		public ScheduleViewModel ScheduleViewModel { get; set; }

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000A0FC File Offset: 0x000082FC
		// (set) Token: 0x060001BF RID: 447 RVA: 0x0000A110 File Offset: 0x00008310
		public string SelectViewType
		{
			get
			{
				return this.\u001A\u0018;
			}
			set
			{
				this.\u001A\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectViewType");
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x060001C0 RID: 448 RVA: 0x0000A130 File Offset: 0x00008330
		// (set) Token: 0x060001C1 RID: 449 RVA: 0x0000A144 File Offset: 0x00008344
		public BaseViewModel SheetsViewModels { get; set; }

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060001C2 RID: 450 RVA: 0x0000A158 File Offset: 0x00008358
		// (set) Token: 0x060001C3 RID: 451 RVA: 0x0000A16C File Offset: 0x0000836C
		public BaseViewModel ViewsViewModels { get; set; }

		// Token: 0x060001C4 RID: 452 RVA: 0x0000A180 File Offset: 0x00008380
		public void InitializeSheetCollection(List<SheetInfo> sheetInf)
		{
			this.\u000C\u001C(sheetInf);
			object u000C = \u0016\u000E\u0018.\u0014(this);
			Func<SheetInfo, ISetViewInfo> func;
			if ((func = MainWindowModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.InitializeSheetCollection(List<SheetInfo>)).MethodHandle;
				}
				func = (MainWindowModel.<>c.\u0018 = new Func<SheetInfo, ISetViewInfo>(MainWindowModel.<>c.\u000C.\u0013));
			}
			\u001C\u000E\u0018.\u0018(u000C, Enumerable.ToList<ISetViewInfo>(Enumerable.Select<SheetInfo, ISetViewInfo>(sheetInf, func)));
			\u000D\u000E\u0018.\u0018(\u0012\u000E\u0018.\u0014(this), sheetInf, new Predicate<object>(this.\u000E\u000D));
			\u001E\u0005\u0018.\u0003(\u0012\u000E\u0018.\u0014(this), new bool?(false));
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x0000A210 File Offset: 0x00008410
		private bool \u000E\u000D(object \u000C)
		{
			SheetInfo sheetInfo = \u0003\u001D\u000F.\u000C(\u000C);
			if (sheetInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.\u000E\u000D(object)).MethodHandle;
				}
				return false;
			}
			bool flag = true;
			if (!\u001F\u001A\u0018.\u0018(\u0004\u000E\u0018.\u0018(this)))
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
				bool flag2;
				if (!this.\u0014\u001C(\u0002\u000E\u0018.\u0014(sheetInfo), this.\u000B\u0018))
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
					if (!this.\u0014\u001C(\u001E\u000E\u0018.\u0014(sheetInfo), this.\u000B\u0018))
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
						if (!this.\u0014\u001C(\u0017\u000E\u0018.\u0018(sheetInfo), this.\u000B\u0018))
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
							if (!Enumerable.Any<string>(\u0011\u000E\u0018.\u0018(\u0015\u000E\u0018.\u0018(sheetInfo)), new Func<string, bool>(this.\u0003\u001C)))
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
								flag2 = this.\u0014\u001C(\u001F\u000E\u0018.\u0018(sheetInfo), this.\u000B\u0018);
								goto IL_F1;
							}
						}
					}
				}
				flag2 = true;
				IL_F1:
				flag = flag2;
			}
			if (flag)
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
				if (\u0020\u000E\u0018.\u0014(this) != null)
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
					flag = \u0013\u000E\u0018.\u0018(\u0020\u000E\u0018.\u0014(this), \u0015\u0005\u0018.\u0014(sheetInfo).\u000C());
				}
			}
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
				if (\u000A\u000E\u0018.\u0014(this))
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
					flag = \u0013\u000E\u0018.\u0018(\u0009\u000E\u0018.\u0018(this), \u0015\u0005\u0018.\u0014(sheetInfo).\u000C());
				}
			}
			return flag;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0000A390 File Offset: 0x00008590
		public void InitializeViewCollection(List<SheetInfo> viewInf)
		{
			this.\u000C\u001C(viewInf);
			object u000C = \u000B\u000E\u0018.\u0014(\u0016\u000E\u0018.\u0014(this));
			Func<SheetInfo, ISetViewInfo> func;
			if ((func = MainWindowModel.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.InitializeViewCollection(List<SheetInfo>)).MethodHandle;
				}
				func = (MainWindowModel.<>c.\u0014 = new Func<SheetInfo, ISetViewInfo>(MainWindowModel.<>c.\u000C.\u0009));
			}
			\u001A\u000E\u0018.\u0018(u000C, Enumerable.ToList<ISetViewInfo>(Enumerable.Select<SheetInfo, ISetViewInfo>(viewInf, func)));
			\u000D\u000E\u0018.\u0018(\u001D\u000E\u0018.\u0014(this), viewInf, new Predicate<object>(this.\u0018\u001C));
			\u001E\u0005\u0018.\u0003(\u001D\u000E\u0018.\u0014(this), new bool?(false));
			\u000D\u0005\u0018.\u0003(\u001D\u000E\u0018.\u0014(this));
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0000A434 File Offset: 0x00008634
		private void \u000C\u001C(List<SheetInfo> \u000C)
		{
			if (Enumerable.Any<PrintDetails>(\u001B\u000E\u0018.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.\u000C\u001C(List<SheetInfo>)).MethodHandle;
				}
				List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(\u000C);
				try
				{
					while (\u0019\u000E\u0018.\u0018(ref enumerator))
					{
						MainWindowModel.\u0014\u0009\u0018 u0014_u0009_u = new MainWindowModel.\u0014\u0009\u0018();
						u0014_u0009_u.\u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
						IEnumerable<PrintDetails> enumerable = \u001B\u000E\u0018.\u0018(this);
						Func<PrintDetails, long> func;
						if ((func = MainWindowModel.<>c.\u0003) == null)
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
							func = (MainWindowModel.<>c.\u0003 = new Func<PrintDetails, long>(MainWindowModel.<>c.\u000C.\u000A));
						}
						if (Enumerable.Contains<long>(Enumerable.Select<PrintDetails, long>(enumerable, func), \u0015\u0005\u0018.\u0014(u0014_u0009_u.\u000C).\u000C()))
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
							\u001C\u0005\u0018.\u0018(u0014_u0009_u.\u000C, true);
							\u0005\u000E\u0018.\u0018(u0014_u0009_u.\u000C, \u000E\u000E\u0018.\u0018(\u0001\u000E\u0018.\u0018(\u001B\u000E\u0018.\u0018(this), new Predicate<PrintDetails>(u0014_u0009_u.\u0018))));
							\u0006\u000E\u0018.\u0018(u0014_u0009_u.\u000C, \u0008\u000E\u0018.\u0018(\u0001\u000E\u0018.\u0018(\u001B\u000E\u0018.\u0018(this), new Predicate<PrintDetails>(u0014_u0009_u.\u0014))));
							\u0007\u000E\u0018.\u0018(\u0010\u000E\u0018.\u0018(), u0014_u0009_u.\u000C);
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
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x0000A5AC File Offset: 0x000087AC
		private bool \u0018\u001C(object \u000C)
		{
			SheetInfo sheetInfo = \u0003\u001D\u000F.\u000C(\u000C);
			if (sheetInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.\u0018\u001C(object)).MethodHandle;
				}
				return false;
			}
			bool flag;
			if (\u000F\u0002\u0018.\u0018(\u0003\u000C\u0014.\u0018(this), \u000D\u0009\u0018.\u0015))
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
				flag = true;
			}
			else
			{
				flag = \u000F\u0002\u0018.\u0018(\u0014\u000C\u0014.\u0014(sheetInfo), \u0003\u000C\u0014.\u0018(this));
			}
			if (flag)
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
				if (!\u001F\u001A\u0018.\u0018(\u0004\u000E\u0018.\u0018(this)))
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
					bool flag2;
					if (!this.\u0014\u001C(\u0002\u000E\u0018.\u0014(sheetInfo), this.\u000B\u0018))
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
						if (!this.\u0014\u001C(\u0014\u000C\u0014.\u0014(sheetInfo), this.\u000B\u0018))
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
							flag2 = this.\u0014\u001C(\u001F\u000E\u0018.\u0018(sheetInfo), this.\u000B\u0018);
							goto IL_E7;
						}
					}
					flag2 = true;
					IL_E7:
					flag = flag2;
				}
			}
			if (flag)
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
				if (\u0020\u000E\u0018.\u0014(this) != null)
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
					flag = \u0013\u000E\u0018.\u0018(\u0020\u000E\u0018.\u0014(this), \u0015\u0005\u0018.\u0014(sheetInfo).\u000C());
				}
			}
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
				if (\u000A\u000E\u0018.\u0014(this))
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
					flag = \u0013\u000E\u0018.\u0018(\u0009\u000E\u0018.\u0018(this), \u0015\u0005\u0018.\u0014(sheetInfo).\u000C());
				}
			}
			return flag;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0000A724 File Offset: 0x00008924
		[BindableMethod("ApplyFilterSets")]
		public void ApplyFilterSets(bool isSheetsSelect)
		{
			if (\u0020\u000E\u0018.\u0014(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.ApplyFilterSets(bool)).MethodHandle;
				}
				\u0020\u0005\u0018.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u000F\u000C\u0014.\u0018(\u0003\u0005\u0018.\u0003(\u0012\u000E\u0018.\u0014(this))))), new Action<SheetInfo>(this.\u0016\u001C));
				if (\u0003\u0005\u0018.\u0003(\u001D\u000E\u0018.\u0014(this)) != null)
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
					\u0020\u0005\u0018.\u0018(Enumerable.ToList<SheetInfo>(Enumerable.Cast<SheetInfo>(\u000F\u000C\u0014.\u0018(\u0003\u0005\u0018.\u0003(\u001D\u000E\u0018.\u0014(this))))), new Action<SheetInfo>(this.\u000F\u001C));
				}
			}
			\u0016\u000C\u0014.\u0018(this, isSheetsSelect);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x0000A7E0 File Offset: 0x000089E0
		[BindableMethod("ActiveViewSheets")]
		public void SetActiveViewSheetsIds(bool isSheetsSelected)
		{
			\u0001\u0005\u0018.\u0014(this, \u000D\u000C\u0014.\u0014(this));
			List<SheetInfo> list;
			if (!isSheetsSelected)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.SetActiveViewSheetsIds(bool)).MethodHandle;
				}
				list = Enumerable.ToList<SheetInfo>(Enumerable.OfType<SheetInfo>(\u000F\u000C\u0014.\u0018(\u0003\u0005\u0018.\u0003(\u001D\u000E\u0018.\u0014(this)))));
			}
			else
			{
				list = Enumerable.ToList<SheetInfo>(Enumerable.OfType<SheetInfo>(\u000F\u000C\u0014.\u0018(\u0003\u0005\u0018.\u0003(\u0012\u000E\u0018.\u0014(this)))));
			}
			List<SheetInfo> u = list;
			\u0012\u000C\u0014.\u0014(this, u, \u0009\u000E\u0018.\u0018(this));
			\u0016\u000C\u0014.\u0018(this, isSheetsSelected);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x0000A874 File Offset: 0x00008A74
		[BindableMethod("CollectionRefresh")]
		public void CollectionRefresh(bool isSelected)
		{
			if (isSelected)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.CollectionRefresh(bool)).MethodHandle;
				}
				\u001C\u000C\u0014.\u0018(\u0012\u000E\u0018.\u0014(this));
				return;
			}
			\u001C\u000C\u0014.\u0018(\u001D\u000E\u0018.\u0014(this));
		}

		// Token: 0x060001CC RID: 460 RVA: 0x0000A8B4 File Offset: 0x00008AB4
		public void CheckItemChanged(List<SheetInfo> allItems, List<long> activeViewIds)
		{
			List<SheetInfo>.Enumerator enumerator = \u0018\u000C\u0014.\u0018(allItems);
			try
			{
				while (\u0019\u000E\u0018.\u0018(ref enumerator))
				{
					SheetInfo u000C = \u000C\u000C\u0014.\u0018(ref enumerator);
					if (!\u0013\u000E\u0018.\u0018(activeViewIds, \u0015\u0005\u0018.\u0014(u000C).\u000C()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.CheckItemChanged(List<SheetInfo>, List<long>)).MethodHandle;
						}
						\u001C\u0005\u0018.\u0018(u000C, false);
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

		// Token: 0x060001CD RID: 461 RVA: 0x0000A940 File Offset: 0x00008B40
		public List<long> GettingAllOpenViewAndSheets()
		{
			IEnumerable<UIView> enumerable = \u0013\u000C\u0014.\u0018(\u0011\u0005\u0018.\u0018());
			Func<UIView, long> func;
			if ((func = MainWindowModel.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.GettingAllOpenViewAndSheets()).MethodHandle;
				}
				func = (MainWindowModel.<>c.\u0016 = new Func<UIView, long>(MainWindowModel.<>c.\u000C.\u0020));
			}
			return Enumerable.ToList<long>(Enumerable.Select<UIView, long>(enumerable, func));
		}

		// Token: 0x060001CE RID: 462 RVA: 0x0000A99C File Offset: 0x00008B9C
		private bool \u0014\u001C(string \u000C, string \u0018)
		{
			if (!\u001F\u001A\u0018.\u0018(\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.\u0014\u001C(string, string)).MethodHandle;
				}
				if (\u001B\u0013\u0018.\u000C(\u000C, \u0018))
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
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x0000A9E0 File Offset: 0x00008BE0
		public List<long> GetViewsFromSet(List<ViewSheetSetInfo> viewSets)
		{
			List<long> list = \u0011\u000C\u0014.\u0018();
			Func<ViewSheetSetInfo, bool> func;
			if ((func = MainWindowModel.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.GetViewsFromSet(List<ViewSheetSetInfo>)).MethodHandle;
				}
				func = (MainWindowModel.<>c.\u000F = new Func<ViewSheetSetInfo, bool>(MainWindowModel.<>c.\u000C.\u001F));
			}
			IEnumerable<ViewSheetSetInfo> enumerable = Enumerable.Where<ViewSheetSetInfo>(viewSets, func);
			if (!Enumerable.Any<ViewSheetSetInfo>(enumerable))
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
				return null;
			}
			IEnumerable<ViewSheetSetInfo> enumerable2 = enumerable;
			Func<ViewSheetSetInfo, bool> func2;
			if ((func2 = MainWindowModel.<>c.\u0012) == null)
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
				func2 = (MainWindowModel.<>c.\u0012 = new Func<ViewSheetSetInfo, bool>(MainWindowModel.<>c.\u000C.\u0011));
			}
			IEnumerator<ViewSheetSetInfo> enumerator = \u001F\u000C\u0014.\u0018(Enumerable.Where<ViewSheetSetInfo>(enumerable2, func2));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ViewSheetSetInfo u000C = \u0020\u000C\u0014.\u0018(enumerator);
					object u000C2 = list;
					IEnumerable<VSSetItem> enumerable3 = \u000A\u000C\u0014.\u0018(u000C);
					Func<VSSetItem, long> func3;
					if ((func3 = MainWindowModel.<>c.\u000D) == null)
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
						func3 = (MainWindowModel.<>c.\u000D = new Func<VSSetItem, long>(MainWindowModel.<>c.\u000C.\u0015));
					}
					\u0009\u000C\u0014.\u0018(u000C2, Enumerable.Select<VSSetItem, long>(enumerable3, func3));
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
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
			list = Enumerable.ToList<long>(Enumerable.Distinct<long>(list));
			return list;
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x060001D0 RID: 464 RVA: 0x0000AB14 File Offset: 0x00008D14
		// (set) Token: 0x060001D1 RID: 465 RVA: 0x0000AB28 File Offset: 0x00008D28
		internal List<long> ViewsFromSet { get; set; }

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x060001D2 RID: 466 RVA: 0x0000AB3C File Offset: 0x00008D3C
		// (set) Token: 0x060001D3 RID: 467 RVA: 0x0000AB50 File Offset: 0x00008D50
		public ViewSheetSetViewModel SetViewModelInstance { get; set; }

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001D4 RID: 468 RVA: 0x0000AB64 File Offset: 0x00008D64
		// (set) Token: 0x060001D5 RID: 469 RVA: 0x0000AB78 File Offset: 0x00008D78
		public ViewsSheetsCollector ViewsSheetsCollector { get; set; }

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x060001D6 RID: 470 RVA: 0x0000AB8C File Offset: 0x00008D8C
		// (set) Token: 0x060001D7 RID: 471 RVA: 0x0000ABA0 File Offset: 0x00008DA0
		public SelectionParametersCollector SelectionParametersCollector { get; set; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x060001D8 RID: 472 RVA: 0x0000ABB4 File Offset: 0x00008DB4
		// (set) Token: 0x060001D9 RID: 473 RVA: 0x0000ABC8 File Offset: 0x00008DC8
		public string SearchText
		{
			get
			{
				return this.\u0009\u0018;
			}
			set
			{
				this.\u0009\u0018 = value;
				this.\u000B\u0018 = \u0015\u000C\u0014.\u0018(\u0004\u000E\u0018.\u0018(this));
				\u0011\u0010\u0018.\u0018(this, "SearchText");
			}
		}

		// Token: 0x060001DA RID: 474 RVA: 0x0000ABFC File Offset: 0x00008DFC
		[BindableMethod("SaveCurrentData")]
		public void SaveCurrentDataInScdedule()
		{
			\u0017\u000C\u0014.\u0014(\u001E\u000C\u0014.\u0014(this));
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060001DB RID: 475 RVA: 0x0000AC18 File Offset: 0x00008E18
		// (remove) Token: 0x060001DC RID: 476 RVA: 0x0000AC64 File Offset: 0x00008E64
		public event MainWindowModel.LoadProfileHandler LoadCurrentDataEvent
		{
			[CompilerGenerated]
			add
			{
				MainWindowModel.LoadProfileHandler loadProfileHandler = this.\u0018\u0014;
				MainWindowModel.LoadProfileHandler loadProfileHandler2;
				do
				{
					loadProfileHandler2 = loadProfileHandler;
					MainWindowModel.LoadProfileHandler value2 = (MainWindowModel.LoadProfileHandler)\u001C\u0019\u0018.\u0018(loadProfileHandler2, value);
					loadProfileHandler = Interlocked.CompareExchange<MainWindowModel.LoadProfileHandler>(ref this.\u0018\u0014, value2, loadProfileHandler2);
				}
				while (loadProfileHandler != loadProfileHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.add_LoadCurrentDataEvent(MainWindowModel.LoadProfileHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				MainWindowModel.LoadProfileHandler loadProfileHandler = this.\u0018\u0014;
				MainWindowModel.LoadProfileHandler loadProfileHandler2;
				do
				{
					loadProfileHandler2 = loadProfileHandler;
					MainWindowModel.LoadProfileHandler value2 = (MainWindowModel.LoadProfileHandler)\u0013\u0019\u0018.\u0018(loadProfileHandler2, value);
					loadProfileHandler = Interlocked.CompareExchange<MainWindowModel.LoadProfileHandler>(ref this.\u0018\u0014, value2, loadProfileHandler2);
				}
				while (loadProfileHandler != loadProfileHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.remove_LoadCurrentDataEvent(MainWindowModel.LoadProfileHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000ACB0 File Offset: 0x00008EB0
		// (set) Token: 0x060001DE RID: 478 RVA: 0x0000ACC4 File Offset: 0x00008EC4
		public ProSheetCurrentData ProSheetsCurrentData { get; set; }

		// Token: 0x060001DF RID: 479 RVA: 0x0000ACD8 File Offset: 0x00008ED8
		public void SetCurrentData()
		{
			if (!\u0010\u000C\u0014.\u0014(\u001E\u000C\u0014.\u0014(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(MainWindowModel.SetCurrentData()).MethodHandle;
				}
				return;
			}
			string u000C = \u000D\u001E\u0018.\u0018(\u000A\u0006\u0018.\u0018(Environment.SpecialFolder.LocalApplicationData), "\\DiRoots\\ProSheets\\Scheduler");
			string u = \u0007\u000C\u0014.\u0014(\u001E\u000C\u0014.\u0014(this));
			string text = \u0019\u000C\u0014.\u0018(u000C, "\\", u, ".xml");
			if (!\u000C\u001A\u0018.\u0018(text))
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
				return;
			}
			\u000B\u000C\u0014.\u0018(this, XMLUtility.DeserialiseInfo<ProSheetCurrentData>(text));
			MainWindowModel.LoadProfileHandler u0018_u = this.\u0018\u0014;
			if (u0018_u == null)
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
			}
			else
			{
				\u001A\u000C\u0014.\u0018(u0018_u, \u001D\u000C\u0014.\u0014(this));
			}
			IEnumerable<PrintDetails> enumerable = \u0004\u000C\u0014.\u0018(\u001D\u000C\u0014.\u0014(this));
			Func<PrintDetails, bool> func;
			if ((func = MainWindowModel.<>c.\u001C) == null)
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
				func = (MainWindowModel.<>c.\u001C = new Func<PrintDetails, bool>(MainWindowModel.<>c.\u000C.\u0017));
			}
			\u0002\u000C\u0014.\u0018(this, Enumerable.ToList<PrintDetails>(Enumerable.Where<PrintDetails>(enumerable, func)));
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x0000ADD8 File Offset: 0x00008FD8
		[BindableMethod("Update")]
		public void Update()
		{
			\u0006\u000C\u0014.\u0018(\u001E\u000C\u0014.\u0014(this));
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x0000ADF4 File Offset: 0x00008FF4
		[BindableMethod("SetSchedulerTime")]
		public void SetSchedulerTime()
		{
			\u0008\u000C\u0014.\u0014(\u001E\u000C\u0014.\u0014(this));
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x0000AE10 File Offset: 0x00009010
		[CompilerGenerated]
		private bool \u0003\u001C(string \u000C)
		{
			return this.\u0014\u001C(\u000C, this.\u000B\u0018);
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x0000AE2C File Offset: 0x0000902C
		[CompilerGenerated]
		private void \u0016\u001C(SheetInfo \u000C)
		{
			\u001C\u0005\u0018.\u0018(\u000C, \u0013\u000E\u0018.\u0018(\u0020\u000E\u0018.\u0014(this), \u0015\u0005\u0018.\u0014(\u000C).\u000C()));
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x0000AE60 File Offset: 0x00009060
		[CompilerGenerated]
		private void \u000F\u001C(SheetInfo \u000C)
		{
			\u001C\u0005\u0018.\u0018(\u000C, \u0013\u000E\u0018.\u0018(\u0020\u000E\u0018.\u0014(this), \u0015\u0005\u0018.\u0014(\u000C).\u000C()));
		}

		// Token: 0x040000E0 RID: 224
		private readonly Document \u0004\u0018;

		// Token: 0x040000E1 RID: 225
		private bool \u001D\u0018;

		// Token: 0x040000E2 RID: 226
		private string \u001A\u0018;

		// Token: 0x040000E3 RID: 227
		private string \u0009\u0018;

		// Token: 0x040000E4 RID: 228
		private string \u000B\u0018;

		// Token: 0x040000E5 RID: 229
		[CompilerGenerated]
		private List<PrintDetails> \u0019\u0018;

		// Token: 0x040000E6 RID: 230
		[CompilerGenerated]
		private List<long> \u0007\u0018;

		// Token: 0x040000E7 RID: 231
		[CompilerGenerated]
		private List<string> \u0010\u0018;

		// Token: 0x040000E8 RID: 232
		[CompilerGenerated]
		private ScheduleViewModel \u0006\u0018;

		// Token: 0x040000E9 RID: 233
		[CompilerGenerated]
		private BaseViewModel \u0008\u0018;

		// Token: 0x040000EA RID: 234
		[CompilerGenerated]
		private BaseViewModel \u0001\u0018;

		// Token: 0x040000EB RID: 235
		[CompilerGenerated]
		private List<long> \u001B\u0018;

		// Token: 0x040000EC RID: 236
		[CompilerGenerated]
		private ViewSheetSetViewModel \u0005\u0018;

		// Token: 0x040000ED RID: 237
		[CompilerGenerated]
		private ViewsSheetsCollector \u000E\u0018;

		// Token: 0x040000EE RID: 238
		[CompilerGenerated]
		private SelectionParametersCollector \u000C\u0014;

		// Token: 0x040000EF RID: 239
		[CompilerGenerated]
		private MainWindowModel.LoadProfileHandler \u0018\u0014;

		// Token: 0x040000F0 RID: 240
		[CompilerGenerated]
		private ProSheetCurrentData \u0014\u0014;

		// Token: 0x0200015F RID: 351
		// (Invoke) Token: 0x06001052 RID: 4178
		public delegate bool LoadProfileHandler(Profile profile);

		// Token: 0x02000161 RID: 353
		[CompilerGenerated]
		private sealed class \u0014\u0009\u0018
		{
			// Token: 0x06001060 RID: 4192 RVA: 0x0005A650 File Offset: 0x00058850
			internal bool \u0018(PrintDetails \u000C)
			{
				return \u0008\u0009\u000F.\u0018(\u000C) == \u0015\u0005\u0018.\u0014(this.\u000C).\u000C();
			}

			// Token: 0x06001061 RID: 4193 RVA: 0x0005A67C File Offset: 0x0005887C
			internal bool \u0014(PrintDetails \u000C)
			{
				return \u0008\u0009\u000F.\u0018(\u000C) == \u0015\u0005\u0018.\u0014(this.\u000C).\u000C();
			}

			// Token: 0x04000788 RID: 1928
			public SheetInfo \u000C;
		}
	}
}
