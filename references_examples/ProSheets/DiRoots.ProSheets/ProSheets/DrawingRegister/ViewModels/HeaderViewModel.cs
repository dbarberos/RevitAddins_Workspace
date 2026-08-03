using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using Microsoft.Win32;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.DrawingRegister.Helpers;
using ProSheets.DrawingRegister.Model;
using ProSheets.DrawingRegister.UI.Windows;
using ProSheets.Extensions;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x02000108 RID: 264
	public class HeaderViewModel : ViewModelBase
	{
		// Token: 0x06000CF1 RID: 3313 RVA: 0x0004CD24 File Offset: 0x0004AF24
		public HeaderViewModel()
		{
			\u0014\u0008\u0016.\u0018(this, new HeaderParameterOrderChange());
			\u0018\u0008\u0016.\u0018(this);
			\u000C\u0008\u0016.\u0018(this, new ObservableCollection<ParameterInformation>());
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06000CF2 RID: 3314 RVA: 0x0004CD54 File Offset: 0x0004AF54
		// (set) Token: 0x06000CF3 RID: 3315 RVA: 0x0004CD68 File Offset: 0x0004AF68
		public string Status
		{
			get
			{
				return this.\u000E\u0003;
			}
			set
			{
				this.\u000E\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "Status");
			}
		}

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06000CF4 RID: 3316 RVA: 0x0004CD88 File Offset: 0x0004AF88
		// (set) Token: 0x06000CF5 RID: 3317 RVA: 0x0004CD9C File Offset: 0x0004AF9C
		public IList<ParameterInformation> SelectedProjectParameters
		{
			get
			{
				return this.\u0005\u0003;
			}
			set
			{
				this.\u0005\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedProjectParameters");
			}
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06000CF6 RID: 3318 RVA: 0x0004CDBC File Offset: 0x0004AFBC
		// (set) Token: 0x06000CF7 RID: 3319 RVA: 0x0004CDD0 File Offset: 0x0004AFD0
		public ObservableCollection<ParameterInformation> ProjectParametersShow
		{
			get
			{
				return this.\u000C\u0016;
			}
			set
			{
				this.\u000C\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "ProjectParametersShow");
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06000CF8 RID: 3320 RVA: 0x0004CDF0 File Offset: 0x0004AFF0
		// (set) Token: 0x06000CF9 RID: 3321 RVA: 0x0004CE04 File Offset: 0x0004B004
		public HeaderParameterOrderChange ParameterSequenceChange
		{
			get
			{
				return this.\u0003\u0016;
			}
			set
			{
				this.\u0003\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "ParameterSequenceChange");
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06000CFA RID: 3322 RVA: 0x0004CE24 File Offset: 0x0004B024
		// (set) Token: 0x06000CFB RID: 3323 RVA: 0x0004CE38 File Offset: 0x0004B038
		public ObservableCollection<ParameterInformation> SelectProjectParametersShow
		{
			get
			{
				return this.\u0018\u0016;
			}
			set
			{
				this.\u0018\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectProjectParametersShow");
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06000CFC RID: 3324 RVA: 0x0004CE58 File Offset: 0x0004B058
		// (set) Token: 0x06000CFD RID: 3325 RVA: 0x0004CE6C File Offset: 0x0004B06C
		public ParameterInformation RowParameterInformation { get; set; }

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06000CFE RID: 3326 RVA: 0x0004CE80 File Offset: 0x0004B080
		// (set) Token: 0x06000CFF RID: 3327 RVA: 0x0004CE94 File Offset: 0x0004B094
		public bool HideUnchecked
		{
			get
			{
				return this.\u0013;
			}
			set
			{
				this.\u0013 = value;
				\u0011\u0010\u0018.\u0018(this, "HideUnchecked");
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06000D00 RID: 3328 RVA: 0x0004CEB4 File Offset: 0x0004B0B4
		// (set) Token: 0x06000D01 RID: 3329 RVA: 0x0004CEC8 File Offset: 0x0004B0C8
		public bool? IsAllChecked
		{
			get
			{
				return this.\u001E\u0018;
			}
			set
			{
				this.\u001E\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "IsAllChecked");
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x0004CEE8 File Offset: 0x0004B0E8
		// (set) Token: 0x06000D03 RID: 3331 RVA: 0x0004CEFC File Offset: 0x0004B0FC
		public ICollectionView ParameterCollectionView
		{
			get
			{
				return this.\u0001\u0003;
			}
			set
			{
				this.\u0001\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "ParameterCollectionView");
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x0004CF1C File Offset: 0x0004B11C
		// (set) Token: 0x06000D05 RID: 3333 RVA: 0x0004CF30 File Offset: 0x0004B130
		public string ProjectParameterFilter
		{
			get
			{
				return this.\u001B\u0003;
			}
			set
			{
				this.\u001B\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "ProjectParameterFilter");
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x0004CF50 File Offset: 0x0004B150
		// (set) Token: 0x06000D07 RID: 3335 RVA: 0x0004CF64 File Offset: 0x0004B164
		public List<ParameterInformation> ProjectParameters { get; set; }

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x0004CF78 File Offset: 0x0004B178
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x0004CF8C File Offset: 0x0004B18C
		public string ImagePath
		{
			get
			{
				return this.\u0014\u0016;
			}
			set
			{
				this.\u0014\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "ImagePath");
			}
		}

		// Token: 0x06000D0A RID: 3338 RVA: 0x0004CFAC File Offset: 0x0004B1AC
		public void Initialize()
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\HeaderViewModel.cs", "Initialize");
			\u0013\u0008\u0016.\u0018(this, \u001F\u0007\u0016.\u0018(\u0006\u0007\u0016.\u0018()));
			this.\u0016\u0009();
			\u001C\u0008\u0016.\u0018(this, \u0010\u0006\u0018.\u0018(\u001B\u0006\u0016.\u0003(this)));
			\u0005\u0006\u0018.\u0018(\u000D\u0008\u0016.\u0018(this), new Predicate<object>(this.\u000F\u0009));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u000D\u0008\u0016.\u0018(this)), new SortDescription("ParameterType", ListSortDirection.Ascending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u000D\u0008\u0016.\u0018(this)), new SortDescription("ParameterName", ListSortDirection.Ascending));
			\u000F\u0008\u0016.\u0018(this, \u0012\u0008\u0016.\u0018());
			\u0016\u0008\u0016.\u0018(this, new bool?(false));
			\u0010\u0006\u0016.\u0003(this);
			\u0003\u0008\u0016.\u0018(this, \u0015\u0010\u0018.\u0018(new Action(this.UndoParmeterName), new Predicate<object>(this.\u000D\u0009)));
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\HeaderViewModel.cs", "Initialize");
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06000D0B RID: 3339 RVA: 0x0004D0B0 File Offset: 0x0004B2B0
		// (set) Token: 0x06000D0C RID: 3340 RVA: 0x0004D0C4 File Offset: 0x0004B2C4
		public CommandBase UndoParameterNameCommand { get; set; }

		// Token: 0x06000D0D RID: 3341 RVA: 0x0004D0D8 File Offset: 0x0004B2D8
		private void \u0016\u0009()
		{
			ParameterInformation parameterInformation = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation, \u0004\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation, \u0004\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation, -1L);
			\u001F\u0008\u0016.\u0018(parameterInformation, "dd-MM-yyyy");
			object u000C = parameterInformation;
			DateTime dateTime = \u0019\u0015\u0014.\u0018();
			\u0012\u0004\u0016.\u0014(u000C, \u0013\u0013\u0016.\u0018(ref dateTime, \u0020\u0008\u0016.\u0018(parameterInformation)));
			\u000E\u001A\u0016.\u0014(parameterInformation, ParameterType.CustomerParameter);
			ParameterInformation parameterInformation2 = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation2, \u0002\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation2, \u0002\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation2, -2L);
			\u001F\u0008\u0016.\u0018(parameterInformation2, "dd-MM-yy");
			object u000C2 = parameterInformation2;
			dateTime = \u0019\u0015\u0014.\u0018();
			\u0012\u0004\u0016.\u0014(u000C2, \u0013\u0013\u0016.\u0018(ref dateTime, \u0020\u0008\u0016.\u0018(parameterInformation2)));
			\u000E\u001A\u0016.\u0014(parameterInformation2, ParameterType.CustomerParameter);
			ParameterInformation parameterInformation3 = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation3, \u001E\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation3, \u001E\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation3, -3L);
			\u001F\u0008\u0016.\u0018(parameterInformation3, "MM-dd-yyyy");
			object u000C3 = parameterInformation3;
			dateTime = \u0019\u0015\u0014.\u0018();
			\u0012\u0004\u0016.\u0014(u000C3, \u0013\u0013\u0016.\u0018(ref dateTime, \u0020\u0008\u0016.\u0018(parameterInformation3)));
			\u000E\u001A\u0016.\u0014(parameterInformation3, ParameterType.CustomerParameter);
			ParameterInformation parameterInformation4 = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation4, \u0017\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation4, \u0017\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation4, -4L);
			\u001F\u0008\u0016.\u0018(parameterInformation4, "MM-dd-yy");
			object u000C4 = parameterInformation4;
			dateTime = \u0019\u0015\u0014.\u0018();
			\u0012\u0004\u0016.\u0014(u000C4, \u0013\u0013\u0016.\u0018(ref dateTime, \u0020\u0008\u0016.\u0018(parameterInformation4)));
			\u000E\u001A\u0016.\u0014(parameterInformation4, ParameterType.CustomerParameter);
			ParameterInformation parameterInformation5 = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation5, \u0015\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation5, \u0015\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation5, -5L);
			\u001F\u0008\u0016.\u0018(parameterInformation5, "yy-MM-dd");
			object u000C5 = parameterInformation5;
			dateTime = \u0019\u0015\u0014.\u0018();
			\u0012\u0004\u0016.\u0014(u000C5, \u0013\u0013\u0016.\u0018(ref dateTime, \u0020\u0008\u0016.\u0018(parameterInformation5)));
			\u000E\u001A\u0016.\u0014(parameterInformation5, ParameterType.CustomerParameter);
			ParameterInformation parameterInformation6 = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation6, \u0011\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation6, \u0011\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation6, -6L);
			\u001F\u0008\u0016.\u0018(parameterInformation6, "yyyy-MM-dd");
			object u000C6 = parameterInformation6;
			dateTime = \u0019\u0015\u0014.\u0018();
			\u0012\u0004\u0016.\u0014(u000C6, \u0013\u0013\u0016.\u0018(ref dateTime, \u0020\u0008\u0016.\u0018(parameterInformation6)));
			\u000E\u001A\u0016.\u0014(parameterInformation6, ParameterType.CustomerParameter);
			ParameterInformation parameterInformation7 = \u0016\u000B\u0016.\u0018();
			\u0003\u000B\u0016.\u0014(parameterInformation7, \u000A\u0008\u0016.\u0018());
			\u0014\u000B\u0016.\u0018(parameterInformation7, \u000A\u0008\u0016.\u0018());
			\u0018\u000B\u0016.\u0014(parameterInformation7, -7L);
			\u0012\u0004\u0016.\u0014(parameterInformation7, \u0009\u0008\u0016.\u0018());
			\u000E\u001A\u0016.\u0014(parameterInformation7, ParameterType.CustomerParameter);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation2);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation3);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation4);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation5);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation6);
			\u0005\u001A\u0016.\u0018(\u001B\u0006\u0016.\u0003(this), parameterInformation7);
			object u000C7 = \u001B\u0006\u0016.\u0003(this);
			Action<ParameterInformation> u;
			if ((u = HeaderViewModel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.\u0016\u0009()).MethodHandle;
				}
				u = (HeaderViewModel.<>c.\u0018 = new Action<ParameterInformation>(HeaderViewModel.<>c.\u000C.\u001C));
			}
			\u001D\u0007\u0016.\u0018(u000C7, u);
		}

		// Token: 0x06000D0E RID: 3342 RVA: 0x0004D40C File Offset: 0x0004B60C
		public void UpdateStatus()
		{
			string u000C = \u001A\u0008\u0016.\u0018();
			object u = \u0015\u000B\u0016.\u0018(\u001B\u0006\u0016.\u0003(this));
			IEnumerable<ParameterInformation> enumerable = \u001B\u0006\u0016.\u0003(this);
			Func<ParameterInformation, bool> func;
			if ((func = HeaderViewModel.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.UpdateStatus()).MethodHandle;
				}
				func = (HeaderViewModel.<>c.\u0014 = new Func<ParameterInformation, bool>(HeaderViewModel.<>c.\u000C.\u0013));
			}
			string u2 = \u001A\u001E\u0018.\u0018(u000C, u, Enumerable.Count<ParameterInformation>(enumerable, func));
			\u001D\u0008\u0016.\u0018(this, u2);
		}

		// Token: 0x06000D0F RID: 3343 RVA: 0x0004D48C File Offset: 0x0004B68C
		private bool \u000F\u0009(object \u000C)
		{
			ParameterInformation parameterInformation = \u0012\u0006\u000F.\u000C(\u000C);
			if (parameterInformation == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.\u000F\u0009(object)).MethodHandle;
				}
				return false;
			}
			bool flag = true;
			if (!\u001F\u001A\u0018.\u0018(\u0007\u0008\u0016.\u0018(this)))
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
				flag = \u001B\u0013\u0018.\u000C(\u0010\u0008\u0016.\u0014(parameterInformation), \u0007\u0008\u0016.\u0018(this));
			}
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
				if (\u0019\u0008\u0016.\u0018(this))
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
					flag = \u000B\u0008\u0016.\u0018(parameterInformation);
				}
			}
			return flag;
		}

		// Token: 0x06000D10 RID: 3344 RVA: 0x0004D51C File Offset: 0x0004B71C
		private void \u0012\u0009(ParameterInformation \u000C)
		{
			if (\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.\u0012\u0009(ParameterInformation)).MethodHandle;
				}
				return;
			}
			if (\u000B\u0008\u0016.\u0018(\u000C))
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
				\u0001\u0008\u0016.\u0018(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)), \u001B\u0008\u0016.\u0018(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this))), \u000C);
				return;
			}
			IEnumerable<ParameterInformation> enumerable = \u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this));
			Func<ParameterInformation, long> func;
			if ((func = HeaderViewModel.<>c.\u0003) == null)
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
				func = (HeaderViewModel.<>c.\u0003 = new Func<ParameterInformation, long>(HeaderViewModel.<>c.\u000C.\u0009));
			}
			int num = \u0008\u0008\u0016.\u0018(Enumerable.ToList<long>(Enumerable.Select<ParameterInformation, long>(enumerable, func)), \u000D\u0004\u0016.\u0018(\u000C));
			if (num >= 0)
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
				\u0006\u0008\u0016.\u0018(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)), num);
			}
		}

		// Token: 0x06000D11 RID: 3345 RVA: 0x0004D608 File Offset: 0x0004B808
		[BindableMethod("ParameterChecked")]
		public void ParameterChecked(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.ParameterChecked(object)).MethodHandle;
				}
				ParameterInformation parameterInformation = \u0012\u0006\u000F.\u000C(\u0003\u0012\u0014.\u0014(checkBox));
				if (parameterInformation != null)
				{
					if (\u000C\u0001\u0016.\u0018(this) != null)
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
						IEnumerable<ParameterInformation> enumerable = \u000C\u0001\u0016.\u0018(this);
						Func<ParameterInformation, long> func;
						if ((func = HeaderViewModel.<>c.\u0016) == null)
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
							func = (HeaderViewModel.<>c.\u0016 = new Func<ParameterInformation, long>(HeaderViewModel.<>c.\u000C.\u000A));
						}
						if (Enumerable.Contains<long>(Enumerable.Select<ParameterInformation, long>(enumerable, func), \u000D\u0004\u0016.\u0018(parameterInformation)))
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
							IEnumerator<ParameterInformation> enumerator = \u0003\u0001\u0016.\u0018(\u000C\u0001\u0016.\u0018(this));
							try
							{
								while (\u001F\u001E\u0018.\u0018(enumerator))
								{
									\u0018\u0001\u0016.\u0018(\u0014\u0001\u0016.\u0018(enumerator), \u000B\u0008\u0016.\u0018(parameterInformation));
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
									\u0020\u001E\u0018.\u0018(enumerator);
								}
							}
							\u001D\u0007\u0016.\u0018(Enumerable.ToList<ParameterInformation>(\u000C\u0001\u0016.\u0018(this)), new Action<ParameterInformation>(this.\u0013\u0009));
							goto IL_124;
						}
					}
					this.\u0012\u0009(parameterInformation);
					IL_124:
					object u000C = \u001B\u0006\u0016.\u0003(this);
					Predicate<ParameterInformation> u;
					if ((u = HeaderViewModel.<>c.\u000F) == null)
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
						u = (HeaderViewModel.<>c.\u000F = new Predicate<ParameterInformation>(HeaderViewModel.<>c.\u000C.\u0020));
					}
					\u0016\u0008\u0016.\u0018(this, new bool?(\u000E\u0008\u0016.\u0018(u000C, u)));
					bool? u2 = \u0005\u0008\u0016.\u0018(this);
					if (!\u000F\u0014\u0003.\u0018(ref u2))
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
						object u000C2 = \u001B\u0006\u0016.\u0003(this);
						Predicate<ParameterInformation> u3;
						if ((u3 = HeaderViewModel.<>c.\u0012) == null)
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
							u3 = (HeaderViewModel.<>c.\u0012 = new Predicate<ParameterInformation>(HeaderViewModel.<>c.\u000C.\u001F));
						}
						if (\u000A\u0010\u0016.\u0018(u000C2, u3))
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
							\u000B\u0004\u000F.\u000C(ref u2);
							\u0016\u0008\u0016.\u0018(this, u2);
						}
					}
					\u0010\u0006\u0016.\u0003(this);
					return;
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
		}

		// Token: 0x06000D12 RID: 3346 RVA: 0x0004D804 File Offset: 0x0004BA04
		[BindableMethod("SelectAllParameter")]
		public void SelectAllParameters()
		{
			List<ParameterInformation>.Enumerator enumerator = \u0020\u0004\u0016.\u0018(Enumerable.ToList<ParameterInformation>(Enumerable.Cast<ParameterInformation>(\u000D\u0008\u0016.\u0018(this))));
			try
			{
				while (\u000F\u0004\u0016.\u0018(ref enumerator))
				{
					ParameterInformation parameterInformation = \u000A\u0004\u0016.\u0018(ref enumerator);
					object u000C = parameterInformation;
					bool? flag = \u0005\u0008\u0016.\u0018(this);
					\u0018\u0001\u0016.\u0018(u000C, \u000F\u0014\u0003.\u0018(ref flag));
					this.\u0012\u0009(parameterInformation);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.SelectAllParameters()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0010\u0006\u0016.\u0003(this);
		}

		// Token: 0x06000D13 RID: 3347 RVA: 0x0004D8A0 File Offset: 0x0004BAA0
		[BindableMethod("ReloadAll")]
		public void ReloadAll()
		{
			object u000C = \u001B\u0006\u0016.\u0003(this);
			Action<ParameterInformation> u;
			if ((u = HeaderViewModel.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.ReloadAll()).MethodHandle;
				}
				u = (HeaderViewModel.<>c.\u000D = new Action<ParameterInformation>(HeaderViewModel.<>c.\u000C.\u0011));
			}
			\u001D\u0007\u0016.\u0018(u000C, u);
			\u0012\u0001\u0016.\u0018(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)));
			\u0016\u0008\u0016.\u0018(this, new bool?(false));
			\u000F\u0001\u0016.\u0018(this, string.Empty);
			\u0005\u0006\u0016.\u0003(this, string.Empty);
			\u0016\u0001\u0016.\u0018(this, false);
			\u001D\u0008\u0018.\u0018(\u000D\u0008\u0016.\u0018(this));
		}

		// Token: 0x06000D14 RID: 3348 RVA: 0x0004D938 File Offset: 0x0004BB38
		[BindableMethod("AddImage")]
		public void AddImage()
		{
			OpenFileDialog u000C = \u0003\u0007\u0018.\u0018();
			\u0014\u0007\u0018.\u0018(u000C, "Image Files (*.png;*.jpg)|*.png;*.jpg");
			\u000D\u0001\u0016.\u0018(u000C, false);
			bool? flag = \u0018\u0007\u0018.\u0018(u000C);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.AddImage()).MethodHandle;
				}
				\u0005\u0006\u0016.\u0003(this, \u000E\u0019\u0018.\u0018(u000C));
			}
		}

		// Token: 0x06000D15 RID: 3349 RVA: 0x0004D994 File Offset: 0x0004BB94
		[BindableMethod("DeleteImage")]
		public void DeleteImage()
		{
			\u0005\u0006\u0016.\u0003(this, string.Empty);
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x0004D9AC File Offset: 0x0004BBAC
		[BindableMethod("OnSelectedElementNameComponents")]
		public void OnSelectedElementNameComponents(object sender)
		{
			List<ParameterInformation> u000C = Enumerable.ToList<ParameterInformation>(Enumerable.OfType<ParameterInformation>(\u0014\u000F\u0014.\u0018(\u0007\u000B\u000F.\u000C(sender))));
			\u000C\u0008\u0016.\u0018(this, \u0008\u0006\u0016.\u0018(u000C));
			\u001C\u0001\u0016.\u0014(\u001D\u000B\u0016.\u0003(this), \u0013\u0001\u0016.\u0018(this));
		}

		// Token: 0x06000D17 RID: 3351 RVA: 0x0004D9FC File Offset: 0x0004BBFC
		[BindableMethod("Refresh")]
		public void Refresh()
		{
			\u001D\u0008\u0018.\u0018(\u000D\u0008\u0016.\u0018(this));
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0004DA18 File Offset: 0x0004BC18
		[BindableMethod("EditParameterName")]
		public void EditParameterName()
		{
			try
			{
				HeaderViewModel.\u000F\u0015\u0018 u000F_u0015_u = new HeaderViewModel.\u000F\u0015\u0018();
				u000F_u0015_u.\u0018 = this;
				u000F_u0015_u.\u000C = \u0020\u0001\u0016.\u0018(\u001F\u0001\u0016.\u0018(\u0011\u0001\u0016.\u0018(this)));
				\u000A\u0001\u0016.\u0018(u000F_u0015_u.\u000C, new Action(u000F_u0015_u.\u0014));
				ParameterNameChange u000C = \u0009\u0001\u0016.\u0018(u000F_u0015_u.\u000C);
				\u001B\u0007\u0018.\u0018(u000C, \u0001\u000C\u0014.\u0018(this));
				\u001E\u0007\u0018.\u0014(u000C);
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\HeaderViewModel.cs", "EditParameterName");
			}
		}

		// Token: 0x06000D19 RID: 3353 RVA: 0x0004DAB4 File Offset: 0x0004BCB4
		private bool \u000D\u0009(object \u000C)
		{
			bool result;
			try
			{
				if (\u0011\u0001\u0016.\u0018(this) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(HeaderViewModel.\u000D\u0009(object)).MethodHandle;
					}
					result = false;
				}
				else
				{
					ParameterInformation parameterInformation = Enumerable.FirstOrDefault<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)), new Func<ParameterInformation, bool>(this.\u000A\u0009));
					bool flag;
					if (parameterInformation != null)
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
						flag = \u0009\u001E\u0018.\u0018(\u001F\u0001\u0016.\u0018(parameterInformation), \u0010\u0008\u0016.\u0014(\u0011\u0001\u0016.\u0018(this)));
					}
					else
					{
						flag = false;
					}
					result = flag;
				}
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\HeaderViewModel.cs", "CanUndoParameterName");
				result = false;
			}
			return result;
		}

		// Token: 0x06000D1A RID: 3354 RVA: 0x0004DB64 File Offset: 0x0004BD64
		public void UndoParmeterName()
		{
			try
			{
				\u0014\u000B\u0016.\u0018(Enumerable.FirstOrDefault<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)), new Func<ParameterInformation, bool>(this.\u0020\u0009)), \u0010\u0008\u0016.\u0014(\u0011\u0001\u0016.\u0018(this)));
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\HeaderViewModel.cs", "UndoParmeterName");
			}
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x0004DBD4 File Offset: 0x0004BDD4
		[BindableMethod("ParameterLeftAlign")]
		public void ParameterLeftAlign()
		{
			this.\u001C\u0009(HorizontalAlignment.Left);
		}

		// Token: 0x06000D1C RID: 3356 RVA: 0x0004DBE8 File Offset: 0x0004BDE8
		[BindableMethod("ParameterRightAlign")]
		public void ParameterRightAlign()
		{
			this.\u001C\u0009(HorizontalAlignment.Right);
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x0004DBFC File Offset: 0x0004BDFC
		[BindableMethod("ParameterCenterAlign")]
		public void ParameterCenterAlign()
		{
			this.\u001C\u0009(HorizontalAlignment.Center);
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x0004DC10 File Offset: 0x0004BE10
		private void \u001C\u0009(HorizontalAlignment \u000C)
		{
			\u0015\u0001\u0016.\u0018(Enumerable.FirstOrDefault<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this)), new Func<ParameterInformation, bool>(this.\u001F\u0009)), \u000C);
		}

		// Token: 0x06000D1F RID: 3359 RVA: 0x0004DC48 File Offset: 0x0004BE48
		[CompilerGenerated]
		private void \u0013\u0009(ParameterInformation \u000C)
		{
			this.\u0012\u0009(\u000C);
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x0004DC5C File Offset: 0x0004BE5C
		[CompilerGenerated]
		private bool \u0009\u0009(ParameterInformation \u000C)
		{
			return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(\u0011\u0001\u0016.\u0018(this));
		}

		// Token: 0x06000D21 RID: 3361 RVA: 0x0004DC84 File Offset: 0x0004BE84
		[CompilerGenerated]
		private bool \u000A\u0009(ParameterInformation \u000C)
		{
			return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(\u0011\u0001\u0016.\u0018(this));
		}

		// Token: 0x06000D22 RID: 3362 RVA: 0x0004DCAC File Offset: 0x0004BEAC
		[CompilerGenerated]
		private bool \u0020\u0009(ParameterInformation \u000C)
		{
			return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(\u0011\u0001\u0016.\u0018(this));
		}

		// Token: 0x06000D23 RID: 3363 RVA: 0x0004DCD4 File Offset: 0x0004BED4
		[CompilerGenerated]
		private bool \u001F\u0009(ParameterInformation \u000C)
		{
			return \u000D\u0004\u0016.\u0018(\u000C) == \u000D\u0004\u0016.\u0018(\u0011\u0001\u0016.\u0018(this));
		}

		// Token: 0x040005E0 RID: 1504
		private ICollectionView \u0001\u0003;

		// Token: 0x040005E1 RID: 1505
		private string \u001B\u0003;

		// Token: 0x040005E2 RID: 1506
		private bool? \u001E\u0018;

		// Token: 0x040005E3 RID: 1507
		private bool \u0013;

		// Token: 0x040005E4 RID: 1508
		private IList<ParameterInformation> \u0005\u0003;

		// Token: 0x040005E5 RID: 1509
		private string \u000E\u0003;

		// Token: 0x040005E6 RID: 1510
		private ObservableCollection<ParameterInformation> \u000C\u0016;

		// Token: 0x040005E7 RID: 1511
		private ObservableCollection<ParameterInformation> \u0018\u0016;

		// Token: 0x040005E8 RID: 1512
		private string \u0014\u0016;

		// Token: 0x040005E9 RID: 1513
		private HeaderParameterOrderChange \u0003\u0016;

		// Token: 0x040005EA RID: 1514
		[CompilerGenerated]
		private ParameterInformation \u0016\u0016;

		// Token: 0x040005EB RID: 1515
		[CompilerGenerated]
		private List<ParameterInformation> \u000F\u0016;

		// Token: 0x040005EC RID: 1516
		[CompilerGenerated]
		private CommandBase \u0012\u0016;

		// Token: 0x020001FE RID: 510
		[CompilerGenerated]
		private sealed class \u000F\u0015\u0018
		{
			// Token: 0x06001296 RID: 4758 RVA: 0x0006070C File Offset: 0x0005E90C
			internal void \u0014()
			{
				\u0014\u000B\u0016.\u0018(Enumerable.FirstOrDefault<ParameterInformation>(\u0004\u000B\u0016.\u0014(\u001D\u000B\u0016.\u0003(this.\u0018)), new Func<ParameterInformation, bool>(this.\u0018.\u0009\u0009)), \u0002\u0001\u0016.\u0003(this.\u000C));
			}

			// Token: 0x04000915 RID: 2325
			public ParameterChangeViewModel \u000C;

			// Token: 0x04000916 RID: 2326
			public HeaderViewModel \u0018;
		}
	}
}
