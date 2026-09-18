using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.Commons.CustomNameManageWindow.UI.Windows;
using ProSheets.DrawingRegister.Helpers;
using ProSheets.DrawingRegister.Model;
using ProSheets.Extensions;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x0200010A RID: 266
	public class ParameterTransferViewModel : DataGridOrderChange<ParameterInformation>
	{
		// Token: 0x06000D2D RID: 3373 RVA: 0x0004DE70 File Offset: 0x0004C070
		public ParameterTransferViewModel(List<ParameterInformation> selectParameter, bool IsLinkedFile)
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\ParameterTransferViewModel.cs", ".ctor");
			this.\u0015\u0009();
			\u0019\u0001\u0016.\u0018(this, new CommandBase(new Action(this.Refresh), new Predicate<object>(base.CanReloadCmd)));
			List<ParameterInformation> list = new List<ParameterInformation>();
			\u001A\u0007\u0016.\u0018(list, \u0006\u0007\u0016.\u0018());
			IEnumerable<ParameterInformation> enumerable = \u0010\u0007\u0016.\u0018();
			Func<ParameterInformation, bool> func;
			if ((func = ParameterTransferViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel..ctor(List<ParameterInformation>, bool)).MethodHandle;
				}
				func = (ParameterTransferViewModel.<>c.\u0018 = new Func<ParameterInformation, bool>(ParameterTransferViewModel.<>c.\u000C.\u000A));
			}
			List<ParameterInformation> list2 = Enumerable.ToList<ParameterInformation>(Enumerable.Where<ParameterInformation>(enumerable, func));
			if (IsLinkedFile)
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
				IEnumerable<ParameterInformation> enumerable2 = \u0019\u0007\u0016.\u0018();
				Func<ParameterInformation, bool> func2;
				if ((func2 = ParameterTransferViewModel.<>c.\u0014) == null)
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
					func2 = (ParameterTransferViewModel.<>c.\u0014 = new Func<ParameterInformation, bool>(ParameterTransferViewModel.<>c.\u000C.\u0020));
				}
				\u0007\u0007\u0016.\u0018(Enumerable.ToList<ParameterInformation>(Enumerable.Where<ParameterInformation>(enumerable2, func2)));
				\u001A\u0007\u0016.\u0018(list2, \u0019\u0007\u0016.\u0018());
				IEnumerable<ParameterInformation> enumerable3 = list2;
				Func<ParameterInformation, long> func3;
				if ((func3 = ParameterTransferViewModel.<>c.\u0003) == null)
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
					func3 = (ParameterTransferViewModel.<>c.\u0003 = new Func<ParameterInformation, long>(ParameterTransferViewModel.<>c.\u000C.\u001F));
				}
				IEnumerable<IGrouping<long, ParameterInformation>> enumerable4 = Enumerable.GroupBy<ParameterInformation, long>(enumerable3, func3);
				Func<IGrouping<long, ParameterInformation>, ParameterInformation> func4;
				if ((func4 = ParameterTransferViewModel.<>c.\u0016) == null)
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
					func4 = (ParameterTransferViewModel.<>c.\u0016 = new Func<IGrouping<long, ParameterInformation>, ParameterInformation>(ParameterTransferViewModel.<>c.\u000C.\u0011));
				}
				list2 = Enumerable.ToList<ParameterInformation>(Enumerable.Select<IGrouping<long, ParameterInformation>, ParameterInformation>(enumerable4, func4));
			}
			\u001A\u0007\u0016.\u0018(list, list2);
			this.\u0011\u0009(list, selectParameter, -1007400L);
			this.\u0011\u0009(list, selectParameter, -1007401L);
			list = Enumerable.ToList<ParameterInformation>(Enumerable.Except<ParameterInformation>(list, selectParameter));
			\u000B\u0001\u0016.\u0018(this, new ObservableCollection<ParameterInformation>(list));
			\u0006\u0006\u0016.\u0003(this, new ObservableCollection<ParameterInformation>(selectParameter));
			\u001D\u0001\u0016.\u0018(this, \u0010\u0006\u0018.\u0018(\u001A\u0001\u0016.\u0018(this)));
			\u0005\u0006\u0018.\u0018(\u0004\u0001\u0016.\u0018(this), new Predicate<object>(this.\u0017\u0009));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u0004\u0001\u0016.\u0018(this)), new SortDescription("ParameterType", ListSortDirection.Descending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u0004\u0001\u0016.\u0018(this)), new SortDescription("ParameterName", ListSortDirection.Ascending));
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\ParameterTransferViewModel.cs", ".ctor");
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06000D2E RID: 3374 RVA: 0x0004E0B4 File Offset: 0x0004C2B4
		// (set) Token: 0x06000D2F RID: 3375 RVA: 0x0004E0C8 File Offset: 0x0004C2C8
		public ParameterInformation SelectCombineParameter { get; set; }

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06000D30 RID: 3376 RVA: 0x0004E0DC File Offset: 0x0004C2DC
		// (set) Token: 0x06000D31 RID: 3377 RVA: 0x0004E0F0 File Offset: 0x0004C2F0
		public string SearchAvailable
		{
			get
			{
				return this.\u0009\u0016;
			}
			set
			{
				this.\u0009\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "SearchAvailable");
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06000D32 RID: 3378 RVA: 0x0004E110 File Offset: 0x0004C310
		// (set) Token: 0x06000D33 RID: 3379 RVA: 0x0004E124 File Offset: 0x0004C324
		public string SearchSelect
		{
			get
			{
				return this.\u000A\u0016;
			}
			set
			{
				this.\u000A\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "SearchSelect");
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06000D34 RID: 3380 RVA: 0x0004E144 File Offset: 0x0004C344
		// (set) Token: 0x06000D35 RID: 3381 RVA: 0x0004E158 File Offset: 0x0004C358
		public Dictionary<string, object> ParameterTypeAvailableFilter
		{
			get
			{
				return this.\u0020\u0016;
			}
			set
			{
				this.\u0020\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "ParameterTypeAvailableFilter");
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06000D36 RID: 3382 RVA: 0x0004E178 File Offset: 0x0004C378
		// (set) Token: 0x06000D37 RID: 3383 RVA: 0x0004E18C File Offset: 0x0004C38C
		public Dictionary<string, object> ParameterTypeSelectFilter
		{
			get
			{
				return this.\u001F\u0016;
			}
			set
			{
				this.\u001F\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "ParameterTypeSelectFilter");
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06000D38 RID: 3384 RVA: 0x0004E1AC File Offset: 0x0004C3AC
		// (set) Token: 0x06000D39 RID: 3385 RVA: 0x0004E1C0 File Offset: 0x0004C3C0
		public Dictionary<string, object> ParameterTypeFilter { get; set; }

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06000D3A RID: 3386 RVA: 0x0004E1D4 File Offset: 0x0004C3D4
		// (set) Token: 0x06000D3B RID: 3387 RVA: 0x0004E1E8 File Offset: 0x0004C3E8
		public ICollectionView AvailableParameter { get; set; }

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06000D3C RID: 3388 RVA: 0x0004E1FC File Offset: 0x0004C3FC
		// (set) Token: 0x06000D3D RID: 3389 RVA: 0x0004E210 File Offset: 0x0004C410
		public ICollectionView SelectParameter
		{
			get
			{
				return this.\u0011\u0016;
			}
			set
			{
				this.\u0011\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectParameter");
			}
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0004E230 File Offset: 0x0004C430
		private void \u0011\u0009(List<ParameterInformation> \u000C, List<ParameterInformation> \u0018, long \u0014)
		{
			ParameterTransferViewModel.\u0012\u0015\u0018 u0012_u0015_u = new ParameterTransferViewModel.\u0012\u0015\u0018();
			u0012_u0015_u.\u000C = \u0014;
			u0012_u0015_u.\u0018 = \u0018;
			if (!\u000A\u0010\u0016.\u0018(\u000C, new Predicate<ParameterInformation>(u0012_u0015_u.\u0003)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.\u0011\u0009(List<ParameterInformation>, List<ParameterInformation>, long)).MethodHandle;
				}
				ParameterInformation parameterInformation = \u0011\u0010\u0016.\u0018(\u000B\u0007\u0016.\u0018(), new Predicate<ParameterInformation>(u0012_u0015_u.\u000F));
				if (parameterInformation != null)
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
					\u0005\u001A\u0016.\u0018(\u000C, parameterInformation);
				}
			}
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x0004E2AC File Offset: 0x0004C4AC
		private void \u0015\u0009()
		{
			Dictionary<string, object> dictionary = \u0018\u0010\u0016.\u0018();
			\u0005\u0007\u0016.\u0018(dictionary, \u000D\u0009\u0018.\u0011, -1);
			\u0005\u0007\u0016.\u0018(dictionary, \u0005\u0001\u0016.\u0018(), 0);
			\u0005\u0007\u0016.\u0018(dictionary, \u001B\u0001\u0016.\u0018(), 1);
			\u0001\u0001\u0016.\u0018(this, dictionary);
			\u0008\u0001\u0016.\u0018(this, \u0010\u0001\u0016.\u0018(\u0006\u0001\u0016.\u0018(this)));
			\u0007\u0001\u0016.\u0018(this, \u0010\u0001\u0016.\u0018(\u0006\u0001\u0016.\u0018(this)));
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x0004E32C File Offset: 0x0004C52C
		public void Refresh()
		{
			IEnumerable<ParameterInformation> enumerable = \u0004\u000B\u0016.\u0003(this);
			Func<ParameterInformation, string> func;
			if ((func = ParameterTransferViewModel.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.Refresh()).MethodHandle;
				}
				func = (ParameterTransferViewModel.<>c.\u000F = new Func<ParameterInformation, string>(ParameterTransferViewModel.<>c.\u000C.\u0015));
			}
			List<ParameterInformation> u000C = Enumerable.ToList<ParameterInformation>(Enumerable.OrderBy<ParameterInformation, string>(enumerable, func));
			\u0006\u0006\u0016.\u0003(this, \u0008\u0006\u0016.\u0018(u000C));
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0004E390 File Offset: 0x0004C590
		private bool \u0017\u0009(object \u000C)
		{
			ParameterTransferViewModel.\u000D\u0015\u0018 u000D_u0015_u = new ParameterTransferViewModel.\u000D\u0015\u0018();
			u000D_u0015_u.\u000C = \u0012\u0006\u000F.\u000C(\u000C);
			if (u000D_u0015_u.\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.\u0017\u0009(object)).MethodHandle;
				}
				return false;
			}
			bool flag;
			if (\u000C\u001B\u0016.\u0018(this) != null)
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
				IEnumerable<KeyValuePair<string, object>> enumerable = \u000C\u001B\u0016.\u0018(this);
				Func<KeyValuePair<string, object>, bool> func;
				if ((func = ParameterTransferViewModel.<>c.\u0012) == null)
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
					func = (ParameterTransferViewModel.<>c.\u0012 = new Func<KeyValuePair<string, object>, bool>(ParameterTransferViewModel.<>c.\u000C.\u0017));
				}
				if (!Enumerable.Any<KeyValuePair<string, object>>(enumerable, func))
				{
					flag = Enumerable.Any<KeyValuePair<string, object>>(\u000C\u001B\u0016.\u0018(this), new Func<KeyValuePair<string, object>, bool>(u000D_u0015_u.\u0018));
					goto IL_AB;
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
			}
			flag = true;
			IL_AB:
			if (flag)
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
				flag = this.\u001E\u0009(u000D_u0015_u.\u000C, \u000E\u0001\u0016.\u0018(this));
			}
			return flag;
		}

		// Token: 0x06000D42 RID: 3394 RVA: 0x0004E470 File Offset: 0x0004C670
		private bool \u001E\u0009(ParameterInformation \u000C, string \u0018)
		{
			if (\u001F\u001A\u0018.\u0018(\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.\u001E\u0009(ParameterInformation, string)).MethodHandle;
				}
				return true;
			}
			return \u001B\u0013\u0018.\u000C(\u0010\u0008\u0016.\u0014(\u000C), \u0018);
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x0004E4AC File Offset: 0x0004C6AC
		[BindableMethod("AvailableParameterRefresh")]
		public void AvailableParameterRefresh()
		{
			\u001D\u0008\u0018.\u0018(\u0004\u0001\u0016.\u0018(this));
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0004E4C8 File Offset: 0x0004C6C8
		[BindableMethod("SelectParameterRefresh")]
		public void SelectParameterRefresh()
		{
			\u001D\u0008\u0018.\u0018(\u0018\u001B\u0016.\u0018(this));
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0004E4E4 File Offset: 0x0004C6E4
		[BindableMethod("OnSelectedElementSelectComponentsChanged")]
		public void OnSelectedElementSelectComponentsChanged(object sender)
		{
			List<ParameterInformation> u000C = ParameterTransferViewModel.\u0002\u0009(sender);
			\u001C\u0001\u0016.\u0003(this, \u0008\u0006\u0016.\u0018(u000C));
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0004E508 File Offset: 0x0004C708
		[BindableMethod("OnSelectedElementAvailableComponentsChanged")]
		public void OnSelectedElementAvailableComponentsChanged(object sender)
		{
			List<ParameterInformation> u000C = ParameterTransferViewModel.\u0002\u0009(sender);
			\u0014\u001B\u0016.\u0018(this, \u0008\u0006\u0016.\u0018(u000C));
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0004E52C File Offset: 0x0004C72C
		[BindableMethod("Apply")]
		public void Apply()
		{
			\u0007\u000B\u0018.\u0003(\u0001\u000C\u0014.\u0018(this), new bool?(true));
			\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0004E55C File Offset: 0x0004C75C
		[BindableMethod("OpenCustomParameterEditor")]
		public void OpenCustomParameterEditor()
		{
			IEnumerable<ParameterInformation> enumerable = \u001A\u0001\u0016.\u0018(this);
			Func<ParameterInformation, IParameterModel> func;
			if ((func = ParameterTransferViewModel.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.OpenCustomParameterEditor()).MethodHandle;
				}
				func = (ParameterTransferViewModel.<>c.\u000D = new Func<ParameterInformation, IParameterModel>(ParameterTransferViewModel.<>c.\u000C.\u001E));
			}
			List<IParameterModel> list = Enumerable.ToList<IParameterModel>(Enumerable.Select<ParameterInformation, IParameterModel>(enumerable, func));
			IEnumerable<ParameterInformation> enumerable2 = \u0004\u000B\u0016.\u0003(this);
			Func<ParameterInformation, IParameterModel> func2;
			if ((func2 = ParameterTransferViewModel.<>c.\u001C) == null)
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
				func2 = (ParameterTransferViewModel.<>c.\u001C = new Func<ParameterInformation, IParameterModel>(ParameterTransferViewModel.<>c.\u000C.\u0002));
			}
			List<IParameterModel> u = Enumerable.ToList<IParameterModel>(Enumerable.Select<ParameterInformation, IParameterModel>(enumerable2, func2));
			\u0012\u001B\u0016.\u0018(list, u);
			List<IParameterModel> u2 = \u001C\u0014\u0003.\u0018();
			CustomNameManager u000C = \u000D\u0014\u0003.\u0018(true, list, u2, null, false);
			bool? flag = \u001E\u0007\u0018.\u0014(u000C);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
				Parameters u000C2 = \u0012\u0014\u0003.\u0018(\u0005\u000B\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C)));
				ParameterInformation parameterInformation = \u0016\u000B\u0016.\u0018();
				\u0003\u000B\u0016.\u0014(parameterInformation, \u000F\u001B\u0016.\u0018(u000C2));
				\u0014\u000B\u0016.\u0018(parameterInformation, \u0010\u0008\u0016.\u0014(parameterInformation));
				\u000E\u001A\u0016.\u0014(parameterInformation, ParameterType.CombinedParameter);
				\u0016\u001B\u0016.\u0014(parameterInformation, \u0013\u0019\u0014.\u0018(u000C2));
				\u0003\u001B\u0016.\u0018(\u0004\u000B\u0016.\u0003(this), parameterInformation);
			}
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x0004E698 File Offset: 0x0004C898
		[BindableMethod("EditCombineParameter")]
		public void EditCombineParameter()
		{
			if (\u000D\u001B\u0016.\u0018(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.EditCombineParameter()).MethodHandle;
				}
				return;
			}
			List<IParameterModel> list = \u001C\u0014\u0003.\u0018();
			\u001C\u001B\u0016.\u0018(list, \u000D\u001B\u0016.\u0018(this));
			List<IParameterModel> u = list;
			IEnumerable<ParameterInformation> enumerable = \u001A\u0001\u0016.\u0018(this);
			Func<ParameterInformation, IParameterModel> func;
			if ((func = ParameterTransferViewModel.<>c.\u0013) == null)
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
				func = (ParameterTransferViewModel.<>c.\u0013 = new Func<ParameterInformation, IParameterModel>(ParameterTransferViewModel.<>c.\u000C.\u0004));
			}
			List<IParameterModel> list2 = Enumerable.ToList<IParameterModel>(Enumerable.Select<ParameterInformation, IParameterModel>(enumerable, func));
			IEnumerable<ParameterInformation> enumerable2 = \u0004\u000B\u0016.\u0003(this);
			Func<ParameterInformation, IParameterModel> func2;
			if ((func2 = ParameterTransferViewModel.<>c.\u0009) == null)
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
				func2 = (ParameterTransferViewModel.<>c.\u0009 = new Func<ParameterInformation, IParameterModel>(ParameterTransferViewModel.<>c.\u000C.\u001D));
			}
			List<IParameterModel> u2 = Enumerable.ToList<IParameterModel>(Enumerable.Select<ParameterInformation, IParameterModel>(enumerable2, func2));
			\u0012\u001B\u0016.\u0018(list2, u2);
			CustomNameManager u000C = \u000D\u0014\u0003.\u0018(true, list2, u, null, false);
			bool? flag = \u001E\u0007\u0018.\u0014(u000C);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
				Parameters u000C2 = \u0012\u0014\u0003.\u0018(\u0005\u000B\u000F.\u000C(\u0003\u0012\u0014.\u0014(u000C)));
				\u0003\u000B\u0016.\u0014(\u000D\u001B\u0016.\u0018(this), \u000F\u001B\u0016.\u0018(u000C2));
				\u0014\u000B\u0016.\u0018(\u000D\u001B\u0016.\u0018(this), \u0010\u0008\u0016.\u0014(\u000D\u001B\u0016.\u0018(this)));
				\u0016\u001B\u0016.\u0014(\u000D\u001B\u0016.\u0018(this), \u0013\u0019\u0014.\u0018(u000C2));
			}
		}

		// Token: 0x06000D4A RID: 3402 RVA: 0x0004E7EC File Offset: 0x0004C9EC
		private static List<ParameterInformation> \u0002\u0009(object \u000C)
		{
			return Enumerable.ToList<ParameterInformation>(Enumerable.OfType<ParameterInformation>(\u0015\u000F\u0014.\u0018(\u001C\u0006\u000F.\u000C(\u000C))));
		}

		// Token: 0x040005F0 RID: 1520
		private string \u0009\u0016;

		// Token: 0x040005F1 RID: 1521
		private string \u000A\u0016;

		// Token: 0x040005F2 RID: 1522
		private Dictionary<string, object> \u0020\u0016;

		// Token: 0x040005F3 RID: 1523
		private Dictionary<string, object> \u001F\u0016;

		// Token: 0x040005F4 RID: 1524
		private ICollectionView \u0011\u0016;

		// Token: 0x040005F5 RID: 1525
		[CompilerGenerated]
		private ParameterInformation \u0015\u0016;

		// Token: 0x040005F6 RID: 1526
		[CompilerGenerated]
		private Dictionary<string, object> \u0017\u0016;

		// Token: 0x040005F7 RID: 1527
		[CompilerGenerated]
		private ICollectionView \u001E\u0016;

		// Token: 0x02000200 RID: 512
		[CompilerGenerated]
		private sealed class \u0012\u0015\u0018
		{
			// Token: 0x060012A4 RID: 4772 RVA: 0x000608A4 File Offset: 0x0005EAA4
			internal bool \u0003(ParameterInformation \u000C)
			{
				if (\u000D\u0004\u0016.\u0018(\u000C) != this.\u000C)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterTransferViewModel.\u0012\u0015\u0018.\u0003(ParameterInformation)).MethodHandle;
					}
					object u = this.\u0018;
					Predicate<ParameterInformation> u2;
					if ((u2 = this.\u0014) == null)
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
						u2 = (this.\u0014 = new Predicate<ParameterInformation>(this.\u0016));
					}
					return \u000A\u0010\u0016.\u0018(u, u2);
				}
				return true;
			}

			// Token: 0x060012A5 RID: 4773 RVA: 0x0006090C File Offset: 0x0005EB0C
			internal bool \u0016(ParameterInformation \u000C)
			{
				return \u000D\u0004\u0016.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x060012A6 RID: 4774 RVA: 0x0006092C File Offset: 0x0005EB2C
			internal bool \u000F(ParameterInformation \u000C)
			{
				return \u000D\u0004\u0016.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x04000922 RID: 2338
			public long \u000C;

			// Token: 0x04000923 RID: 2339
			public List<ParameterInformation> \u0018;

			// Token: 0x04000924 RID: 2340
			public Predicate<ParameterInformation> \u0014;
		}

		// Token: 0x02000201 RID: 513
		[CompilerGenerated]
		private sealed class \u000D\u0015\u0018
		{
			// Token: 0x060012A8 RID: 4776 RVA: 0x00060960 File Offset: 0x0005EB60
			internal bool \u0018(KeyValuePair<string, object> \u000C)
			{
				return \u001F\u001D\u000F.\u000C(\u000E\u0007\u0016.\u0018(ref \u000C)) == (int)\u0009\u0004\u0016.\u0014(this.\u000C);
			}

			// Token: 0x04000925 RID: 2341
			public ParameterInformation \u000C;
		}
	}
}
