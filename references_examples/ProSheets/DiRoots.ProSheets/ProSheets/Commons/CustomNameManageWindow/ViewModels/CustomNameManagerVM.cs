using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.DrawingRegister.Helpers;
using ProSheets.Extensions;

namespace ProSheets.Commons.CustomNameManageWindow.ViewModels
{
	// Token: 0x0200013E RID: 318
	public class CustomNameManagerVM : DataGridOrderChange<IParameterModel>
	{
		// Token: 0x06000FB1 RID: 4017 RVA: 0x00058AB4 File Offset: 0x00056CB4
		public CustomNameManagerVM(bool isCombineParameter, bool isFileTextBox, List<IParameterModel> availableElements, List<IParameterModel> preSelectElements, string fileName)
		{
			\u0012\u0013\u000F.\u0018(this, isCombineParameter);
			\u000F\u0013\u000F.\u0018(this, isFileTextBox);
			\u0016\u0013\u000F.\u0018(this, new ObservableCollection<IParameterModel>(availableElements));
			this.\u000E\u0012 = availableElements;
			\u0012\u001B\u0016.\u0018(this.\u000E\u0012, preSelectElements);
			string u;
			if (!\u0003\u0013\u000F.\u0018(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM..ctor(bool, bool, List<IParameterModel>, List<IParameterModel>, string)).MethodHandle;
				}
				u = \u000D\u0009\u0018.\u0011\u0003;
			}
			else
			{
				u = \u000D\u0009\u0018.\u001F\u0003;
			}
			\u0014\u0013\u000F.\u0018(this, u);
			\u0018\u0013\u000F.\u0018(this, new ObservableCollection<IParameterModel>());
			if (Enumerable.Any<IParameterModel>(preSelectElements))
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
				this.\u000A\u000A(preSelectElements);
			}
			\u000E\u001C\u000F.\u0018(this, \u0010\u0006\u0018.\u0018(\u000C\u0013\u000F.\u0018(this)));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u0005\u001C\u000F.\u0018(this)), new SortDescription("IsCustomParameter", ListSortDirection.Ascending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u0005\u001C\u000F.\u0018(this)), new SortDescription("IsProjectParameter", ListSortDirection.Ascending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(\u0005\u001C\u000F.\u0018(this)), new SortDescription("ParameterName", ListSortDirection.Ascending));
			ICollectionView u000C = \u0005\u001C\u000F.\u0018(this);
			\u0005\u0006\u0018.\u0018(u000C, \u0007\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(\u000E\u0006\u0018.\u0018(u000C), new Predicate<object>(this.\u0011\u000A))));
			\u001B\u001C\u000F.\u0018(this, new CommandBase(new Action(this.Refresh), new Predicate<object>(base.CanReloadCmd)));
			\u0001\u001C\u000F.\u0018(this, new CommandBase(new Action(this.MoveForwords), new Predicate<object>(base.CanMoveForwardCmd)));
			\u0008\u001C\u000F.\u0018(this, new CommandBase(new Action(this.MoveBackwords), new Predicate<object>(base.CanMoveParameterCmd)));
			\u0010\u001C\u000F.\u0018(this, \u0004\u0008\u000F.\u000C(\u001C\u0019\u0018.\u0018(\u0006\u001C\u000F.\u0018(this), new Action(this.SetPreviewText))));
			this.\u0020\u000A();
			\u0007\u001C\u000F.\u0018(this);
			\u0019\u001C\u000F.\u0018(this, fileName);
			\u000B\u001C\u000F.\u0018(this, !\u001F\u001A\u0018.\u0018(fileName));
			\u001A\u001C\u000F.\u0018(this, new CommandBase(new Action(this.\u0009\u000A), new Predicate<object>(this.\u0013\u000A)));
		}

		// Token: 0x1700055D RID: 1373
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x00058CD8 File Offset: 0x00056ED8
		// (set) Token: 0x06000FB3 RID: 4019 RVA: 0x00058CEC File Offset: 0x00056EEC
		public string CustomField
		{
			get
			{
				return this.\u000D\u0014;
			}
			set
			{
				this.\u000D\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "CustomField");
			}
		}

		// Token: 0x1700055E RID: 1374
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x00058D0C File Offset: 0x00056F0C
		// (set) Token: 0x06000FB5 RID: 4021 RVA: 0x00058D20 File Offset: 0x00056F20
		public Dictionary<string, object> SelectedParameterType
		{
			get
			{
				return this.\u0005\u0012;
			}
			set
			{
				this.\u0005\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedParameterType");
			}
		}

		// Token: 0x1700055F RID: 1375
		// (get) Token: 0x06000FB6 RID: 4022 RVA: 0x00058D40 File Offset: 0x00056F40
		// (set) Token: 0x06000FB7 RID: 4023 RVA: 0x00058D54 File Offset: 0x00056F54
		public Dictionary<string, object> ParameterMeterType { get; set; }

		// Token: 0x17000560 RID: 1376
		// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x00058D68 File Offset: 0x00056F68
		// (set) Token: 0x06000FB9 RID: 4025 RVA: 0x00058D7C File Offset: 0x00056F7C
		public bool IsCombineParameterName
		{
			get
			{
				return this.\u0010\u0012;
			}
			set
			{
				this.\u0010\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "IsCombineParameterName");
			}
		}

		// Token: 0x17000561 RID: 1377
		// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00058D9C File Offset: 0x00056F9C
		// (set) Token: 0x06000FBB RID: 4027 RVA: 0x00058DB0 File Offset: 0x00056FB0
		public string CombineParameterName
		{
			get
			{
				return this.\u001B\u0012;
			}
			set
			{
				this.\u001B\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "CombineParameterName");
			}
		}

		// Token: 0x17000562 RID: 1378
		// (get) Token: 0x06000FBC RID: 4028 RVA: 0x00058DD0 File Offset: 0x00056FD0
		// (set) Token: 0x06000FBD RID: 4029 RVA: 0x00058DE4 File Offset: 0x00056FE4
		public string PreviewText
		{
			get
			{
				return this.\u0001\u0012;
			}
			set
			{
				this.\u0001\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "PreviewText");
			}
		}

		// Token: 0x17000563 RID: 1379
		// (get) Token: 0x06000FBE RID: 4030 RVA: 0x00058E04 File Offset: 0x00057004
		// (set) Token: 0x06000FBF RID: 4031 RVA: 0x00058E18 File Offset: 0x00057018
		public IList<IParameterModel> SelectSelectedParameter
		{
			get
			{
				return this.\u0008\u0012;
			}
			set
			{
				this.\u0008\u0012 = value;
				\u000D\u0013\u000F.\u0018(this, \u001C\u0013\u000F.\u0018(\u0013\u0013\u000F.\u0018(this)));
				\u0011\u0010\u0018.\u0018(this, "SelectSelectedParameter");
			}
		}

		// Token: 0x17000564 RID: 1380
		// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x00058E4C File Offset: 0x0005704C
		// (set) Token: 0x06000FC1 RID: 4033 RVA: 0x00058E60 File Offset: 0x00057060
		public IList<IParameterModel> SelectAvailableParameter
		{
			get
			{
				return this.\u0006\u0012;
			}
			set
			{
				this.\u0006\u0012 = value;
				\u0009\u0013\u000F.\u0018(this, \u001C\u0013\u000F.\u0018(\u000A\u0013\u000F.\u0018(this)));
				\u0011\u0010\u0018.\u0018(this, "SelectAvailableParameter");
			}
		}

		// Token: 0x17000565 RID: 1381
		// (get) Token: 0x06000FC2 RID: 4034 RVA: 0x00058E94 File Offset: 0x00057094
		// (set) Token: 0x06000FC3 RID: 4035 RVA: 0x00058EA8 File Offset: 0x000570A8
		public string SearchText
		{
			get
			{
				return this.\u0009\u0018;
			}
			set
			{
				this.\u0009\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SearchText");
			}
		}

		// Token: 0x17000566 RID: 1382
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x00058EC8 File Offset: 0x000570C8
		// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x00058EDC File Offset: 0x000570DC
		public string PreviewLabel { get; set; }

		// Token: 0x17000567 RID: 1383
		// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x00058EF0 File Offset: 0x000570F0
		// (set) Token: 0x06000FC7 RID: 4039 RVA: 0x00058F04 File Offset: 0x00057104
		public Parameters DefinedParameters { get; set; }

		// Token: 0x17000568 RID: 1384
		// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x00058F18 File Offset: 0x00057118
		// (set) Token: 0x06000FC9 RID: 4041 RVA: 0x00058F2C File Offset: 0x0005712C
		public ICollectionView AvailableParameter
		{
			get
			{
				return this.\u000C\u000D;
			}
			set
			{
				this.\u000C\u000D = value;
				\u0011\u0010\u0018.\u0018(this, "AvailableParameter");
			}
		}

		// Token: 0x17000569 RID: 1385
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00058F4C File Offset: 0x0005714C
		// (set) Token: 0x06000FCB RID: 4043 RVA: 0x00058F60 File Offset: 0x00057160
		public string FileName
		{
			get
			{
				return this.\u0016\u000D;
			}
			set
			{
				this.\u0016\u000D = value;
				\u0011\u0010\u0018.\u0018(this, "FileName");
			}
		}

		// Token: 0x1700056A RID: 1386
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x00058F80 File Offset: 0x00057180
		// (set) Token: 0x06000FCD RID: 4045 RVA: 0x00058F94 File Offset: 0x00057194
		public bool IsFile
		{
			get
			{
				return this.\u000F\u000D;
			}
			set
			{
				this.\u000F\u000D = value;
				if (!\u0006\u0004\u0016.\u0003(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.set_IsFile(bool)).MethodHandle;
					}
					\u0019\u001C\u000F.\u0018(this, string.Empty);
				}
				\u0011\u0010\u0018.\u0018(this, "IsFile");
			}
		}

		// Token: 0x1700056B RID: 1387
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x00058FDC File Offset: 0x000571DC
		// (set) Token: 0x06000FCF RID: 4047 RVA: 0x00058FF0 File Offset: 0x000571F0
		public bool IsFileTextBox
		{
			get
			{
				return this.\u0012\u000D;
			}
			set
			{
				this.\u0012\u000D = value;
				\u0011\u0010\u0018.\u0018(this, "IsFileTextBox");
			}
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x00059010 File Offset: 0x00057210
		private bool \u0013\u000A(object \u000C)
		{
			return !\u001F\u001A\u0018.\u0018(\u0020\u0013\u000F.\u0018(this));
		}

		// Token: 0x1700056C RID: 1388
		// (get) Token: 0x06000FD1 RID: 4049 RVA: 0x00059030 File Offset: 0x00057230
		// (set) Token: 0x06000FD2 RID: 4050 RVA: 0x00059044 File Offset: 0x00057244
		public CommandBase AddCustomField { get; set; }

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00059058 File Offset: 0x00057258
		private void \u0009\u000A()
		{
			ParameterModel parameterModel = \u0017\u0013\u000F.\u0018();
			\u0015\u0013\u000F.\u0014(parameterModel, \u0020\u0013\u000F.\u0018(this));
			\u001C\u0009\u0016.\u0018(parameterModel, true);
			\u001F\u0009\u0016.\u0014(parameterModel, "-");
			\u001F\u0013\u000F.\u0018(\u0011\u0013\u000F.\u0018(this), parameterModel);
			\u0007\u001C\u000F.\u0018(this);
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x000590A4 File Offset: 0x000572A4
		private void \u000A\u000A(List<IParameterModel> \u000C)
		{
			if (\u0003\u0013\u000F.\u0018(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.\u000A\u000A(List<IParameterModel>)).MethodHandle;
				}
				List<IParameterModel>.Enumerator enumerator = \u001A\u0013\u000F.\u0018(\u000C);
				try
				{
					while (\u001E\u0013\u000F.\u0018(ref enumerator))
					{
						IParameterModel u000C = \u001D\u0013\u000F.\u0018(ref enumerator);
						\u0004\u0013\u000F.\u0018(this, \u001E\u0009\u0016.\u0018(u000C));
						\u0014\u0009\u0016.\u0018(\u0002\u0013\u000F.\u0018(u000C), new Action<ParameterModel>(this.\u0002\u000A));
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
					return;
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
			}
			\u0014\u0009\u0016.\u0018(Enumerable.ToList<ParameterModel>(Enumerable.OfType<ParameterModel>(\u000C)), new Action<ParameterModel>(this.\u0004\u000A));
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00059164 File Offset: 0x00057364
		private void \u0020\u000A()
		{
			Dictionary<string, object> dictionary = \u0018\u0010\u0016.\u0018();
			\u0005\u0007\u0016.\u0018(dictionary, \u000D\u0009\u0018.\u0011, -1);
			\u0005\u0007\u0016.\u0018(dictionary, \u0005\u0001\u0016.\u0018(), 0);
			\u0005\u0007\u0016.\u0018(dictionary, \u001B\u0001\u0016.\u0018(), 1);
			\u0007\u0013\u000F.\u0018(this, dictionary);
			\u000B\u0013\u000F.\u0018(this, \u0010\u0001\u0016.\u0018(\u0019\u0013\u000F.\u0018(this)));
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x000591CC File Offset: 0x000573CC
		private ParameterModel \u001F\u000A(IParameterModel \u000C)
		{
			ParameterModel parameterModel = \u0011\u0009\u0016.\u0018(\u001E\u0009\u0016.\u0018(\u000C), \u0017\u0009\u0016.\u0018(\u000C), \u0015\u0009\u0016.\u0018(\u000C), "", "", "-");
			\u0009\u0009\u0016.\u0018(parameterModel, \u000A\u0009\u0016.\u0018(\u000C));
			\u001C\u0009\u0016.\u0018(parameterModel, \u0013\u0009\u0016.\u0018(\u000C));
			return parameterModel;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x00059224 File Offset: 0x00057424
		private ParameterModel \u001F\u000A(ParameterModel \u000C)
		{
			ParameterModel parameterModel = \u0011\u0009\u0016.\u0018(\u0004\u0019\u0014.\u0014(\u000C), \u0010\u0019\u0014.\u0018(\u000C), \u0010\u0013\u000F.\u0014(\u000C), \u001A\u0019\u0014.\u0018(\u000C), \u0002\u0019\u0014.\u0018(\u000C), \u0015\u0019\u0014.\u0018(\u000C));
			\u0009\u0009\u0016.\u0018(parameterModel, \u0006\u0019\u0014.\u0018(\u000C));
			\u001C\u0009\u0016.\u0018(parameterModel, \u001D\u0019\u0014.\u0018(\u000C));
			return parameterModel;
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00059284 File Offset: 0x00057484
		private bool \u0011\u000A(object \u000C)
		{
			IParameterModel parameterModel = \u0002\u0008\u000F.\u000C(\u000C);
			if (parameterModel == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.\u0011\u000A(object)).MethodHandle;
				}
				return false;
			}
			bool flag = false;
			if (\u0008\u0013\u000F.\u0018(this) != null)
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
				IEnumerable<KeyValuePair<string, object>> enumerable = \u0008\u0013\u000F.\u0018(this);
				Func<KeyValuePair<string, object>, bool> func;
				if ((func = CustomNameManagerVM.<>c.\u0018) == null)
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
					func = (CustomNameManagerVM.<>c.\u0018 = new Func<KeyValuePair<string, object>, bool>(CustomNameManagerVM.<>c.\u000C.\u001C));
				}
				if (Enumerable.Any<KeyValuePair<string, object>>(enumerable, func))
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
				}
				else
				{
					IEnumerable<KeyValuePair<string, object>> enumerable2 = \u0008\u0013\u000F.\u0018(this);
					Func<KeyValuePair<string, object>, bool> func2;
					if ((func2 = CustomNameManagerVM.<>c.\u0014) == null)
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
						func2 = (CustomNameManagerVM.<>c.\u0014 = new Func<KeyValuePair<string, object>, bool>(CustomNameManagerVM.<>c.\u000C.\u0013));
					}
					if (Enumerable.Any<KeyValuePair<string, object>>(enumerable2, func2))
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
						flag = \u000A\u0009\u0016.\u0018(parameterModel);
						goto IL_121;
					}
					IEnumerable<KeyValuePair<string, object>> enumerable3 = \u0008\u0013\u000F.\u0018(this);
					Func<KeyValuePair<string, object>, bool> func3;
					if ((func3 = CustomNameManagerVM.<>c.\u0003) == null)
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
						func3 = (CustomNameManagerVM.<>c.\u0003 = new Func<KeyValuePair<string, object>, bool>(CustomNameManagerVM.<>c.\u000C.\u0009));
					}
					if (Enumerable.Any<KeyValuePair<string, object>>(enumerable3, func3))
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
						flag = !\u000A\u0009\u0016.\u0018(parameterModel);
						goto IL_121;
					}
					goto IL_121;
				}
			}
			flag = true;
			IL_121:
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
				flag = this.\u0015\u000A(\u001E\u0009\u0016.\u0018(parameterModel), \u0006\u0013\u000F.\u0018(this));
			}
			return flag;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x000593DC File Offset: 0x000575DC
		private bool \u0015\u000A(string \u000C, string \u0018)
		{
			if (\u001F\u001A\u0018.\u0018(\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.\u0015\u000A(string, string)).MethodHandle;
				}
				return true;
			}
			return \u001B\u0013\u0018.\u000C(\u000C, \u0018);
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x00059414 File Offset: 0x00057614
		public void Refresh()
		{
			IEnumerable<IParameterModel> enumerable = \u0011\u0013\u000F.\u0018(this);
			Func<IParameterModel, string> func;
			if ((func = CustomNameManagerVM.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.Refresh()).MethodHandle;
				}
				func = (CustomNameManagerVM.<>c.\u0016 = new Func<IParameterModel, string>(CustomNameManagerVM.<>c.\u000C.\u000A));
			}
			List<IParameterModel> u000C = Enumerable.ToList<IParameterModel>(Enumerable.OrderBy<IParameterModel, string>(enumerable, func));
			\u0018\u0013\u000F.\u0018(this, \u0001\u0013\u000F.\u0018(u000C));
			\u0007\u001C\u000F.\u0018(this);
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x00059480 File Offset: 0x00057680
		private unsafe string \u0017\u000A(ParameterModel \u000C, ref int \u0018)
		{
			StringBuilder u000C = \u0005\u0017\u0018.\u0018();
			\u0017\u0020\u0014.\u0018(u000C, \u001A\u0019\u0014.\u0018(\u000C));
			\u0017\u0020\u0014.\u0018(u000C, \u0004\u0019\u0014.\u0014(\u000C));
			\u0017\u0020\u0014.\u0018(u000C, \u0002\u0019\u0014.\u0018(\u000C));
			if (\u0018 != \u001B\u0013\u000F.\u0018(\u0011\u0013\u000F.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.\u0017\u000A(ParameterModel, int*)).MethodHandle;
				}
				\u0017\u0020\u0014.\u0018(u000C, \u0015\u0019\u0014.\u0018(\u000C));
			}
			string result = \u0001\u0017\u0018.\u0018(u000C);
			\u0018++;
			return result;
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x00059510 File Offset: 0x00057710
		[BindableMethod("AvailableElementsRefresh")]
		public void AvailableElementsRefresh()
		{
			\u001D\u0008\u0018.\u0018(\u0005\u001C\u000F.\u0018(this));
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0005952C File Offset: 0x0005772C
		[BindableMethod("MoveForwords")]
		public void MoveForwords()
		{
			if (\u000C\u0009\u000F.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.MoveForwords()).MethodHandle;
				}
				if (Enumerable.Any<IParameterModel>(\u000C\u0009\u000F.\u0018(this)))
				{
					IEnumerator<IParameterModel> enumerator = \u000E\u0013\u000F.\u0018(\u000C\u0009\u000F.\u0018(this));
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							IParameterModel u000C = \u0005\u0013\u000F.\u0018(enumerator);
							\u001F\u0013\u000F.\u0018(\u0011\u0013\u000F.\u0018(this), this.\u001F\u000A(u000C));
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
							\u0020\u001E\u0018.\u0018(enumerator);
						}
					}
					\u0007\u001C\u000F.\u0018(this);
					return;
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
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x000595E4 File Offset: 0x000577E4
		public void SetPreviewText()
		{
			if (!Enumerable.Any<IParameterModel>(\u0011\u0013\u000F.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.SetPreviewText()).MethodHandle;
				}
				\u0018\u0009\u000F.\u0018(this, string.Empty);
				return;
			}
			int num = 1;
			StringBuilder u000C = \u0005\u0017\u0018.\u0018();
			IEnumerable<IParameterModel> enumerable = \u0011\u0013\u000F.\u0018(this);
			Func<IParameterModel, ParameterModel> func;
			if ((func = CustomNameManagerVM.<>c.\u000F) == null)
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
				func = (CustomNameManagerVM.<>c.\u000F = new Func<IParameterModel, ParameterModel>(CustomNameManagerVM.<>c.\u000C.\u0020));
			}
			IEnumerator<ParameterModel> enumerator = \u0003\u0009\u000F.\u0018(Enumerable.Select<IParameterModel, ParameterModel>(enumerable, func));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					ParameterModel u000C2 = \u0014\u0009\u000F.\u0018(enumerator);
					string u = this.\u0017\u000A(u000C2, ref num);
					\u0017\u0020\u0014.\u0018(u000C, u);
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
			\u0018\u0009\u000F.\u0018(this, \u0001\u0017\u0018.\u0018(u000C));
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x000596D8 File Offset: 0x000578D8
		[BindableMethod("CombinePrefixChange")]
		public void CombineTextPrefixChange(object sender)
		{
			this.\u001E\u000A(sender, "Prefix");
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x000596F4 File Offset: 0x000578F4
		[BindableMethod("CombineSuffixChange")]
		public void CombineSuffixChange(object sender)
		{
			this.\u001E\u000A(sender, "Suffix");
		}

		// Token: 0x06000FE1 RID: 4065 RVA: 0x00059710 File Offset: 0x00057910
		[BindableMethod("CombineSeparatorChange")]
		public void CombineSeparatorChange(object sender)
		{
			this.\u001E\u000A(sender, "Separator");
		}

		// Token: 0x06000FE2 RID: 4066 RVA: 0x0005972C File Offset: 0x0005792C
		private void \u001E\u000A(object \u000C, string \u0018)
		{
			if (\u0013\u0013\u000F.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.\u001E\u000A(object, string)).MethodHandle;
				}
				TextBox textBox = \u0018\u0004\u000F.\u000C(\u000C);
				if (textBox != null)
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
					ParameterModel parameterModel = \u001E\u0008\u000F.\u000C(\u0003\u0012\u0014.\u0014(textBox));
					if (parameterModel != null)
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
						IEnumerable<IParameterModel> enumerable = \u0013\u0013\u000F.\u0018(this);
						Func<IParameterModel, long> func;
						if ((func = CustomNameManagerVM.<>c.\u0012) == null)
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
							func = (CustomNameManagerVM.<>c.\u0012 = new Func<IParameterModel, long>(CustomNameManagerVM.<>c.\u000C.\u001F));
						}
						if (Enumerable.Contains<long>(Enumerable.Select<IParameterModel, long>(enumerable, func), \u0010\u0019\u0014.\u0018(parameterModel)))
						{
							PropertyInfo u000C = \u0007\u0012\u0014.\u0018(\u0004\u0017\u0018.\u0014(parameterModel), \u0018);
							object u = \u001D\u0009\u0016.\u0018(u000C, parameterModel);
							IEnumerator<ParameterModel> enumerator = \u0003\u0009\u000F.\u0018(Enumerable.OfType<ParameterModel>(\u0013\u0013\u000F.\u0018(this)));
							try
							{
								while (\u001F\u001E\u0018.\u0018(enumerator))
								{
									ParameterModel u2 = \u0014\u0009\u000F.\u0018(enumerator);
									\u0018\u0002\u0016.\u0003(u000C, u2, u);
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
							\u0007\u001C\u000F.\u0018(this);
							return;
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
				}
			}
		}

		// Token: 0x06000FE3 RID: 4067 RVA: 0x00059870 File Offset: 0x00057A70
		[BindableMethod("MoveBackwords")]
		public void MoveBackwords()
		{
			if (\u000F\u0009\u000F.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.MoveBackwords()).MethodHandle;
				}
				if (Enumerable.Any<IParameterModel>(\u000F\u0009\u000F.\u0018(this)))
				{
					IEnumerator<IParameterModel> enumerator = \u000E\u0013\u000F.\u0018(\u000F\u0009\u000F.\u0018(this));
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							IParameterModel u = \u0005\u0013\u000F.\u0018(enumerator);
							\u0016\u0009\u000F.\u0018(\u0011\u0013\u000F.\u0018(this), u);
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
								switch (2)
								{
								case 0:
									continue;
								}
								break;
							}
							\u0020\u001E\u0018.\u0018(enumerator);
						}
					}
					\u0007\u001C\u000F.\u0018(this);
					return;
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
		}

		// Token: 0x06000FE4 RID: 4068 RVA: 0x00059924 File Offset: 0x00057B24
		[BindableMethod("Apply")]
		public void Apply()
		{
			IEnumerable<IParameterModel> enumerable = \u0011\u0013\u000F.\u0018(this);
			Func<IParameterModel, ParameterModel> func;
			if ((func = CustomNameManagerVM.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.Apply()).MethodHandle;
				}
				func = (CustomNameManagerVM.<>c.\u000D = new Func<IParameterModel, ParameterModel>(CustomNameManagerVM.<>c.\u000C.\u0011));
			}
			List<ParameterModel> u = Enumerable.ToList<ParameterModel>(Enumerable.Select<IParameterModel, ParameterModel>(enumerable, func));
			if (\u001F\u001A\u0018.\u0018(\u000D\u0009\u000F.\u0018(this)))
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
				\u0004\u0013\u000F.\u0018(this, \u001C\u0009\u000F.\u0018(this));
			}
			\u0012\u0009\u000F.\u0018(this, \u0019\u0003\u0003.\u0018(\u000D\u0009\u000F.\u0018(this), u));
			\u0007\u000B\u0018.\u0003(\u0001\u000C\u0014.\u0018(this), new bool?(true));
			\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x000599DC File Offset: 0x00057BDC
		[BindableMethod("Cancel")]
		public void Cancel()
		{
			\u0007\u000B\u0018.\u0003(\u0001\u000C\u0014.\u0018(this), new bool?(false));
			\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
		}

		// Token: 0x06000FE6 RID: 4070 RVA: 0x00059A0C File Offset: 0x00057C0C
		[BindableMethod("TextValidationOnPreviewTextInput")]
		public void TextValidationOnPreviewTextInput(TextCompositionEventArgs e)
		{
			bool u;
			if (!\u001F\u001A\u0018.\u0018(\u000E\u0020\u0003.\u0018(e)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CustomNameManagerVM.TextValidationOnPreviewTextInput(TextCompositionEventArgs)).MethodHandle;
				}
				u = \u001F\u000B\u0018.\u0018(\u000E\u0020\u0003.\u0018(e));
			}
			else
			{
				u = true;
			}
			\u001D\u000B\u0018.\u0018(e, u);
		}

		// Token: 0x06000FE7 RID: 4071 RVA: 0x00059A58 File Offset: 0x00057C58
		[BindableMethod("CheckForVaildTextInput")]
		public void CheckForVaildTextInput(TextCompositionEventArgs e)
		{
			char[] array = \u0008\u001A\u0018.\u0018();
			\u001D\u000B\u0018.\u0018(e, Enumerable.Contains<char>(array, \u0002\u0001\u0018.\u0014(\u000E\u0020\u0003.\u0018(e), 0)));
		}

		// Token: 0x06000FE8 RID: 4072 RVA: 0x00059A8C File Offset: 0x00057C8C
		[CompilerGenerated]
		private void \u0002\u000A(ParameterModel \u000C)
		{
			\u001F\u0013\u000F.\u0018(\u0011\u0013\u000F.\u0018(this), this.\u001F\u000A(\u000C));
		}

		// Token: 0x06000FE9 RID: 4073 RVA: 0x00059AB0 File Offset: 0x00057CB0
		[CompilerGenerated]
		private void \u0004\u000A(ParameterModel \u000C)
		{
			\u001F\u0013\u000F.\u0018(\u0011\u0013\u000F.\u0018(this), this.\u001F\u000A(\u000C));
		}

		// Token: 0x040006FE RID: 1790
		private bool \u0010\u0012;

		// Token: 0x040006FF RID: 1791
		private IList<IParameterModel> \u0006\u0012;

		// Token: 0x04000700 RID: 1792
		private IList<IParameterModel> \u0008\u0012;

		// Token: 0x04000701 RID: 1793
		private string \u0001\u0012 = string.Empty;

		// Token: 0x04000702 RID: 1794
		private string \u0009\u0018;

		// Token: 0x04000703 RID: 1795
		private string \u001B\u0012;

		// Token: 0x04000704 RID: 1796
		private Dictionary<string, object> \u0005\u0012;

		// Token: 0x04000705 RID: 1797
		private List<IParameterModel> \u000E\u0012;

		// Token: 0x04000706 RID: 1798
		private ICollectionView \u000C\u000D;

		// Token: 0x04000707 RID: 1799
		private string \u000D\u0014;

		// Token: 0x04000708 RID: 1800
		[CompilerGenerated]
		private Dictionary<string, object> \u0018\u000D;

		// Token: 0x04000709 RID: 1801
		[CompilerGenerated]
		private string \u0014\u000D;

		// Token: 0x0400070A RID: 1802
		[CompilerGenerated]
		private Parameters \u0003\u000D;

		// Token: 0x0400070B RID: 1803
		private string \u0016\u000D;

		// Token: 0x0400070C RID: 1804
		private bool \u000F\u000D;

		// Token: 0x0400070D RID: 1805
		private bool \u0012\u000D;

		// Token: 0x0400070E RID: 1806
		[CompilerGenerated]
		private CommandBase \u000D\u000D;
	}
}
