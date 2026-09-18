using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.Commons.WindowControl;
using ProSheets.Extensions;
using ProSheets.Helper.Enums;

namespace DiRoots.ProfileControl.Helpers
{
	// Token: 0x02000019 RID: 25
	public class NewNameViewModel : ViewModelBase, INewSelectionName
	{
		// Token: 0x060000CE RID: 206 RVA: 0x00006244 File Offset: 0x00004444
		public NewNameViewModel(IEnumerable<string> existingParameterFileterNames, IEnumerable<string> existingSelectionNames, DiRootsWindow mainWindow)
		{
			\u001F\u0010\u0018.\u0018(this, Enumerable.ToList<string>(existingSelectionNames));
			\u0020\u0010\u0018.\u0018(this, Enumerable.ToList<string>(existingParameterFileterNames));
			this.\u001B = \u000A\u0010\u0018.\u0018().GetService<INewName>(false);
			\u0009\u0010\u0018.\u0018(this.\u001B, this);
			\u0013\u0010\u0018.\u0018(this.\u001B, mainWindow);
			\u001C\u0010\u0018.\u0018(this.\u001B);
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000CF RID: 207 RVA: 0x000062B0 File Offset: 0x000044B0
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000062C4 File Offset: 0x000044C4
		public List<string> ItemsNames
		{
			get
			{
				return this.\u0008;
			}
			set
			{
				this.\u0008 = value;
				\u0011\u0010\u0018.\u0018(this, "ItemsNames");
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x000062E4 File Offset: 0x000044E4
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x000062F8 File Offset: 0x000044F8
		public List<string> FilterItemsNames
		{
			get
			{
				return this.\u0001;
			}
			set
			{
				this.\u0001 = value;
				\u0011\u0010\u0018.\u0018(this, "FilterItemsNames");
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00006318 File Offset: 0x00004518
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000632C File Offset: 0x0000452C
		public bool Result { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00006340 File Offset: 0x00004540
		public Action OnClose { get; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x00006354 File Offset: 0x00004554
		// (set) Token: 0x060000D7 RID: 215 RVA: 0x00006368 File Offset: 0x00004568
		public SavingMode Mode { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0000637C File Offset: 0x0000457C
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00006390 File Offset: 0x00004590
		public string SelectionName
		{
			get
			{
				return this.\u0005;
			}
			set
			{
				if (\u000F\u0002\u0018.\u0018(this.\u0005, value))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NewNameViewModel.set_SelectionName(string)).MethodHandle;
					}
					return;
				}
				this.\u0005 = value;
				this.OnPropertyChanged<string>(new Func<string>(this.\u001A\u000D), "SelectionName");
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000DA RID: 218 RVA: 0x000063E0 File Offset: 0x000045E0
		public CommandBase CancelCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u000B\u000D), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00006408 File Offset: 0x00004608
		[BindableMethod("OnKeyDown")]
		public void OnKeyDown(object sender, KeyEventArgs args, bool isEnabled, string btnContent)
		{
			if (!isEnabled)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewNameViewModel.OnKeyDown(object, KeyEventArgs, bool, string)).MethodHandle;
				}
				return;
			}
			if (\u0018\u0004\u000F.\u000C(sender) != null)
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
				if (\u001A\u000B\u0018.\u0018(args) == Key.Return)
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
					\u001D\u000B\u0018.\u0018(args, true);
					if (!\u001F\u001A\u0018.\u0018(\u0004\u001A\u0018.\u0003(this)))
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
						\u0017\u0010\u0018.\u0018(this, btnContent);
					}
				}
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00006480 File Offset: 0x00004680
		[BindableMethod("SaveSelection")]
		public void SaveSelection(string modeName)
		{
			if (\u000F\u0002\u0018.\u0018(modeName, \u000D\u0009\u0018.\u000F\u0014))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewNameViewModel.SaveSelection(string)).MethodHandle;
				}
				\u0004\u0010\u0018.\u0018(this, SavingMode.Save);
			}
			else
			{
				\u0004\u0010\u0018.\u0018(this, SavingMode.Update);
			}
			\u0002\u0010\u0018.\u0018(this, true);
			\u001E\u0010\u0018.\u0018(this.\u001B);
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000064D4 File Offset: 0x000046D4
		[CompilerGenerated]
		private string \u001A\u000D()
		{
			return \u0004\u001A\u0018.\u0003(this);
		}

		// Token: 0x060000DE RID: 222 RVA: 0x000064EC File Offset: 0x000046EC
		[CompilerGenerated]
		private void \u000B\u000D()
		{
			\u001E\u0010\u0018.\u0018(this.\u001B);
		}

		// Token: 0x04000050 RID: 80
		private List<string> \u0008;

		// Token: 0x04000051 RID: 81
		private List<string> \u0001;

		// Token: 0x04000052 RID: 82
		private readonly INewName \u001B;

		// Token: 0x04000053 RID: 83
		private string \u0005;

		// Token: 0x04000054 RID: 84
		[CompilerGenerated]
		private bool \u000E;

		// Token: 0x04000055 RID: 85
		[CompilerGenerated]
		private readonly Action \u000C\u0018;

		// Token: 0x04000056 RID: 86
		[CompilerGenerated]
		private SavingMode \u0018\u0018;
	}
}
