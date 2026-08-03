using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModel;
using DiRoots.One.UnitTextBox.UI.Validation;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x02000059 RID: 89
	public class NamingConfigurationViewModel : ValidationViewModelBase
	{
		// Token: 0x06000314 RID: 788 RVA: 0x00013E34 File Offset: 0x00012034
		public NamingConfigurationViewModel()
		{
			Document u = \u000C\u001D.\u0006;
			this.CR = new \u0013\u001D(u);
			\u001B\u0006\u0007.\u000A(this, new CommandBase(new Action(this.MoveForward), new Predicate<object>(this.PKR)));
			\u0008\u0006\u0007.\u000A(this, new CommandBase(new Action(this.Reload), new Predicate<object>(this.OKR)));
			\u000E\u0006\u0007.\u000A(this, new CommandBase(new Action(this.MoveBack), new Predicate<object>(this.TKR)));
			\u0010\u0006\u0007.\u000A(this, new CommandBase(new Action(this.MoveUp), new Predicate<object>(this.TKR)));
			\u000D\u0006\u0007.\u000A(this, new CommandBase(new Action(this.MoveDown), new Predicate<object>(this.TKR)));
			\u001C\u0006\u0007.\u000A(this, new CommandBase(new Action(this.MoveTop), new Predicate<object>(this.TKR)));
			\u0003\u0006\u0007.\u000A(this, new CommandBase(new Action(this.MoveBottom), new Predicate<object>(this.TKR)));
			\u0012\u0006\u0007.\u000A(this, new CommandBase(new Action(this.AddCustomField), new Predicate<object>(this.IKR)));
			\u000F\u0006\u0007.\u000A(this, new CommandBase(new Action(this.AddCustomSeparator), new Predicate<object>(this.QKR)));
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000315 RID: 789 RVA: 0x00013FD8 File Offset: 0x000121D8
		// (set) Token: 0x06000316 RID: 790 RVA: 0x00013FEC File Offset: 0x000121EC
		public ObservableCollection<NamingParameter> ElementParameters
		{
			get
			{
				return this.BR;
			}
			set
			{
				this.BR = value;
				\u000D\u0020\u000A.\u000A(this, "ElementParameters");
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000317 RID: 791 RVA: 0x0001400C File Offset: 0x0001220C
		// (set) Token: 0x06000318 RID: 792 RVA: 0x00014020 File Offset: 0x00012220
		public ObservableCollection<NamingParameter> SelectedItems
		{
			get
			{
				return this.WR;
			}
			set
			{
				this.WR = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedItems");
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000319 RID: 793 RVA: 0x00014040 File Offset: 0x00012240
		// (set) Token: 0x0600031A RID: 794 RVA: 0x00014054 File Offset: 0x00012254
		public ObservableCollection<NamingParameter> ElementNameComponents
		{
			get
			{
				return this.UR;
			}
			set
			{
				this.UR = value;
				\u000D\u0020\u000A.\u000A(this, "ElementNameComponents");
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x0600031B RID: 795 RVA: 0x00014074 File Offset: 0x00012274
		// (set) Token: 0x0600031C RID: 796 RVA: 0x00014088 File Offset: 0x00012288
		public ObservableCollection<NamingParameter> SelectedElementNameComponents
		{
			get
			{
				return this.KR;
			}
			set
			{
				this.KR = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedElementNameComponents");
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x0600031D RID: 797 RVA: 0x000140A8 File Offset: 0x000122A8
		// (set) Token: 0x0600031E RID: 798 RVA: 0x000140BC File Offset: 0x000122BC
		public bool UseProjectParameters
		{
			get
			{
				return this.JR;
			}
			set
			{
				NamingConfigurationViewModel.\u0017\u0007 u0017_u = new NamingConfigurationViewModel.\u0017\u0007();
				this.JR = value;
				\u000D\u0020\u000A.\u000A(this, "UseProjectParameters");
				List<NamingParameter> u001F = Enumerable.ToList<NamingParameter>(\u000F\u0016\u0007.\u001D(this));
				NamingConfigurationViewModel.\u0017\u0007 u0017_u2 = u0017_u;
				IEnumerable<Parameter> enumerable = this.CR.\u0014();
				Func<Parameter, NamingParameter> func;
				if ((func = NamingConfigurationViewModel.<>c.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.set_UseProjectParameters(bool)).MethodHandle;
					}
					func = (NamingConfigurationViewModel.<>c.\u000A = new Func<Parameter, NamingParameter>(NamingConfigurationViewModel.<>c.\u001F.\u0002));
				}
				u0017_u2.\u001F = Enumerable.Select<Parameter, NamingParameter>(enumerable, func);
				if (this.JR)
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
					\u001E\u0006\u0007.\u000A(u001F, u0017_u.\u001F);
				}
				else
				{
					\u0011\u0006\u0007.\u000A(u001F, new Predicate<NamingParameter>(u0017_u.\u000A));
				}
				\u0013\u0005\u0007.\u001D(this, \u000E\u0016\u0007.\u000A(u001F));
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x0600031F RID: 799 RVA: 0x00014180 File Offset: 0x00012380
		// (set) Token: 0x06000320 RID: 800 RVA: 0x00014194 File Offset: 0x00012394
		public bool UseFieldSeparator
		{
			get
			{
				return this.ER;
			}
			set
			{
				this.ER = value;
				\u000D\u0020\u000A.\u000A(this, "UseFieldSeparator");
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06000321 RID: 801 RVA: 0x000141B4 File Offset: 0x000123B4
		// (set) Token: 0x06000322 RID: 802 RVA: 0x000141C8 File Offset: 0x000123C8
		public string FieldSeparator
		{
			get
			{
				return this.NR;
			}
			set
			{
				this.NR = value;
				\u000C\u0006\u0007.\u000A(this, "FieldSeparator");
				if (\u001A\u0006\u0007.\u000A(this.NR))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.set_FieldSeparator(string)).MethodHandle;
					}
					return;
				}
				if (!\u0013\u0006\u0007.\u000A(this, "FieldSeparator", value))
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
					string u = \u0017\u0006\u0007.\u000A("{0} ? | \\ : {{ }}[ ] ; < > ` ~ ", \u0014\u0006\u0007.\u000A());
					\u0020\u0006\u0007.\u000A(this, "FieldSeparator", u, ErrorType.Error);
				}
				\u000D\u0020\u000A.\u000A(this, "FieldSeparator");
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06000323 RID: 803 RVA: 0x00014250 File Offset: 0x00012450
		// (set) Token: 0x06000324 RID: 804 RVA: 0x00014264 File Offset: 0x00012464
		public string CustomField
		{
			get
			{
				return this.MR;
			}
			set
			{
				this.MR = value;
				\u000C\u0006\u0007.\u000A(this, "CustomField");
				if (\u001A\u0006\u0007.\u000A(this.MR))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.set_CustomField(string)).MethodHandle;
					}
					return;
				}
				if (!\u0013\u0006\u0007.\u000A(this, "CustomField", value))
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
					string u = \u0017\u0006\u0007.\u000A("{0} ? | \\ : {{ }}[ ] ; < > ` ~ ", \u0014\u0006\u0007.\u000A());
					\u0020\u0006\u0007.\u000A(this, "CustomField", u, ErrorType.Error);
				}
				\u000D\u0020\u000A.\u000A(this, "CustomField");
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000325 RID: 805 RVA: 0x000142EC File Offset: 0x000124EC
		// (set) Token: 0x06000326 RID: 806 RVA: 0x00014300 File Offset: 0x00012500
		public string CustomSeparator
		{
			get
			{
				return this.VR;
			}
			set
			{
				this.VR = value;
				\u000C\u0006\u0007.\u000A(this, "CustomSeparator");
				if (\u001A\u0006\u0007.\u000A(this.VR))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.set_CustomSeparator(string)).MethodHandle;
					}
					return;
				}
				if (!\u0013\u0006\u0007.\u000A(this, "CustomSeparator", value))
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
					string u = \u0017\u0006\u0007.\u000A("{0} ? | \\ : {{ }}[ ] ; < > ` ~ ", \u0015\u0006\u0007.\u000A());
					\u0020\u0006\u0007.\u000A(this, "CustomSeparator", u, ErrorType.Error);
				}
				\u000D\u0020\u000A.\u000A(this, "CustomSeparator");
			}
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000327 RID: 807 RVA: 0x00014388 File Offset: 0x00012588
		// (set) Token: 0x06000328 RID: 808 RVA: 0x0001439C File Offset: 0x0001259C
		public bool CustomFieldGotFocused
		{
			get
			{
				return this.ZR;
			}
			set
			{
				this.ZR = value;
				\u000D\u0020\u000A.\u000A(this, "CustomFieldGotFocused");
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000329 RID: 809 RVA: 0x000143BC File Offset: 0x000125BC
		// (set) Token: 0x0600032A RID: 810 RVA: 0x000143D0 File Offset: 0x000125D0
		public bool CustomSeparatorGotFocused
		{
			get
			{
				return this.XR;
			}
			set
			{
				this.XR = value;
				\u000D\u0020\u000A.\u000A(this, "CustomSeparatorGotFocused");
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x0600032B RID: 811 RVA: 0x000143F0 File Offset: 0x000125F0
		// (set) Token: 0x0600032C RID: 812 RVA: 0x00014404 File Offset: 0x00012604
		public ICommand MoveForwardCmd { get; set; }

		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x0600032D RID: 813 RVA: 0x00014418 File Offset: 0x00012618
		// (set) Token: 0x0600032E RID: 814 RVA: 0x0001442C File Offset: 0x0001262C
		public ICommand MoveBackCmd { get; set; }

		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x0600032F RID: 815 RVA: 0x00014440 File Offset: 0x00012640
		// (set) Token: 0x06000330 RID: 816 RVA: 0x00014454 File Offset: 0x00012654
		public ICommand MoveUpCmd { get; set; }

		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000331 RID: 817 RVA: 0x00014468 File Offset: 0x00012668
		// (set) Token: 0x06000332 RID: 818 RVA: 0x0001447C File Offset: 0x0001267C
		public ICommand MoveDownCmd { get; set; }

		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000333 RID: 819 RVA: 0x00014490 File Offset: 0x00012690
		// (set) Token: 0x06000334 RID: 820 RVA: 0x000144A4 File Offset: 0x000126A4
		public ICommand MoveTopCmd { get; set; }

		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000335 RID: 821 RVA: 0x000144B8 File Offset: 0x000126B8
		// (set) Token: 0x06000336 RID: 822 RVA: 0x000144CC File Offset: 0x000126CC
		public ICommand MoveBottomCmd { get; set; }

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000337 RID: 823 RVA: 0x000144E0 File Offset: 0x000126E0
		// (set) Token: 0x06000338 RID: 824 RVA: 0x000144F4 File Offset: 0x000126F4
		public ICommand Reloads { get; set; }

		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000339 RID: 825 RVA: 0x00014508 File Offset: 0x00012708
		// (set) Token: 0x0600033A RID: 826 RVA: 0x0001451C File Offset: 0x0001271C
		public ICommand AddCustomFieldCmd { get; set; }

		// Token: 0x170000CD RID: 205
		// (get) Token: 0x0600033B RID: 827 RVA: 0x00014530 File Offset: 0x00012730
		// (set) Token: 0x0600033C RID: 828 RVA: 0x00014544 File Offset: 0x00012744
		public ICommand AddCustomSeparatorCmd { get; set; }

		// Token: 0x0600033D RID: 829 RVA: 0x00014558 File Offset: 0x00012758
		public void OnSelectedElementParameters(object sender)
		{
			List<NamingParameter> u001F = Enumerable.ToList<NamingParameter>(Enumerable.OfType<NamingParameter>(\u0009\u0006\u0007.\u0007(\u001D\u001F\u000E.\u001F(sender))));
			\u0001\u0006\u0007.\u000A(this, \u000E\u0016\u0007.\u000A(u001F));
		}

		// Token: 0x0600033E RID: 830 RVA: 0x00014594 File Offset: 0x00012794
		public void OnSelectedElementNameComponents(object sender)
		{
			List<NamingParameter> u001F = Enumerable.ToList<NamingParameter>(Enumerable.OfType<NamingParameter>(\u0009\u0006\u0007.\u0007(\u001D\u001F\u000E.\u001F(sender))));
			\u001F\u000F\u0007.\u000A(this, \u000E\u0016\u0007.\u000A(u001F));
		}

		// Token: 0x0600033F RID: 831 RVA: 0x000145D0 File Offset: 0x000127D0
		public void Reload()
		{
			IEnumerable<NamingParameter> enumerable = \u000B\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this));
			\u0010\u0016\u0007.\u001D(this, \u0016\u000F\u0007.\u000A());
			Func<NamingParameter, bool> func;
			if ((func = NamingConfigurationViewModel.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.Reload()).MethodHandle;
				}
				func = (NamingConfigurationViewModel.<>c.\u0007 = new Func<NamingParameter, bool>(NamingConfigurationViewModel.<>c.\u001F.\u0006));
			}
			IEnumerator<NamingParameter> enumerator = \u0005\u000F\u0007.\u000A(Enumerable.Where<NamingParameter>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
					\u0019\u000F\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), u000A);
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
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			IEnumerable<NamingParameter> enumerable2 = \u000F\u0016\u0007.\u001D(this);
			Func<NamingParameter, bool> func2;
			if ((func2 = NamingConfigurationViewModel.<>c.\u001D) == null)
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
				func2 = (NamingConfigurationViewModel.<>c.\u001D = new Func<NamingParameter, bool>(NamingConfigurationViewModel.<>c.\u001F.\u000F));
			}
			List<NamingParameter> list = Enumerable.ToList<NamingParameter>(Enumerable.Where<NamingParameter>(enumerable2, func2));
			\u0013\u0005\u0007.\u001D(this, \u0004\u000F\u0007.\u000A(Enumerable.Except<NamingParameter>(\u000F\u0016\u0007.\u001D(this), list)));
			IEnumerable<NamingParameter> enumerable3 = \u000F\u0016\u0007.\u001D(this);
			Func<NamingParameter, string> func3;
			if ((func3 = NamingConfigurationViewModel.<>c.\u0004) == null)
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
				func3 = (NamingConfigurationViewModel.<>c.\u0004 = new Func<NamingParameter, string>(NamingConfigurationViewModel.<>c.\u001F.\u0012));
			}
			\u0013\u0005\u0007.\u001D(this, \u0004\u000F\u0007.\u000A(Enumerable.OrderBy<NamingParameter, string>(enumerable3, func3)));
			for (int i = 0; i < \u000A\u000F\u0007.\u000A(list); i++)
			{
				\u0007\u000F\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), i, \u001D\u000F\u0007.\u000A(list, i));
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

		// Token: 0x06000340 RID: 832 RVA: 0x00014764 File Offset: 0x00012964
		public void MoveForward()
		{
			if (\u0006\u000F\u0007.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.MoveForward()).MethodHandle;
				}
				if (Enumerable.Any<NamingParameter>(\u0006\u000F\u0007.\u000A(this)))
				{
					IEnumerator<NamingParameter> enumerator = \u0002\u000F\u0007.\u000A(\u0006\u000F\u0007.\u000A(this));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
							\u0019\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), u000A);
							\u0006\u0016\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), u000A);
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
								switch (3)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					return;
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
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00014820 File Offset: 0x00012A20
		public void AddCustomField()
		{
			if (\u001C\u000F\u0007.\u0007(\u0012\u000F\u0007.\u000A(this)) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.AddCustomField()).MethodHandle;
				}
				if (\u0003\u000F\u0007.\u000A(this))
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
					\u0019\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), \u000F\u000F\u0007.\u000A(\u0012\u000F\u0007.\u000A(this), NamingParameterType.CustomField));
				}
			}
		}

		// Token: 0x06000342 RID: 834 RVA: 0x00014884 File Offset: 0x00012A84
		public void AddCustomSeparator()
		{
			if (\u001C\u000F\u0007.\u0007(\u000D\u000F\u0007.\u000A(this)) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.AddCustomSeparator()).MethodHandle;
				}
				if (\u0010\u000F\u0007.\u000A(this))
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
					\u0019\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), \u000F\u000F\u0007.\u000A(\u000D\u000F\u0007.\u000A(this), NamingParameterType.CustomField));
				}
			}
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000148E8 File Offset: 0x00012AE8
		public void MoveBack()
		{
			if (\u0008\u000F\u0007.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.MoveBack()).MethodHandle;
				}
				if (Enumerable.Any<NamingParameter>(\u0008\u000F\u0007.\u000A(this)))
				{
					IEnumerable<Parameter> enumerable = this.CR.\u0014();
					Func<Parameter, NamingParameter> func;
					if ((func = NamingConfigurationViewModel.<>c.\u0019) == null)
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
						func = (NamingConfigurationViewModel.<>c.\u0019 = new Func<Parameter, NamingParameter>(NamingConfigurationViewModel.<>c.\u001F.\u0003));
					}
					IEnumerable<NamingParameter> enumerable2 = Enumerable.Select<Parameter, NamingParameter>(enumerable, func);
					Func<NamingParameter, string> func2;
					if ((func2 = NamingConfigurationViewModel.<>c.\u0018) == null)
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
						func2 = (NamingConfigurationViewModel.<>c.\u0018 = new Func<NamingParameter, string>(NamingConfigurationViewModel.<>c.\u001F.\u001C));
					}
					IOrderedEnumerable<NamingParameter> u001F = Enumerable.OrderBy<NamingParameter, string>(enumerable2, func2);
					IEnumerator<NamingParameter> enumerator = \u0002\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							NamingParameter namingParameter = \u0018\u000F\u0007.\u000A(enumerator);
							\u0006\u0016\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), namingParameter);
							if (\u000E\u000F\u0007.\u0007(namingParameter) == 0)
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
								\u0019\u000F\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), namingParameter);
							}
							else if (\u000E\u000F\u0007.\u0007(namingParameter) == 3)
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
								\u0007\u000F\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), 0, namingParameter);
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
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					enumerator = \u0005\u000F\u0007.\u000A(u001F);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
							\u0006\u0016\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), u000A);
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
								switch (2)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					if (\u000A\u0016\u0007.\u001D(this))
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
						enumerator = \u0005\u000F\u0007.\u000A(u001F);
						try
						{
							while (\u000A\u0017\u000A.\u000A(enumerator))
							{
								NamingParameter u000A2 = \u0018\u000F\u0007.\u000A(enumerator);
								\u0019\u000F\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), u000A2);
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
									switch (2)
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
					IEnumerable<NamingParameter> enumerable3 = \u000F\u0016\u0007.\u001D(this);
					Func<NamingParameter, bool> func3;
					if ((func3 = NamingConfigurationViewModel.<>c.\u0005) == null)
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
						func3 = (NamingConfigurationViewModel.<>c.\u0005 = new Func<NamingParameter, bool>(NamingConfigurationViewModel.<>c.\u001F.\u000D));
					}
					IEnumerable<NamingParameter> enumerable4 = Enumerable.TakeWhile<NamingParameter>(enumerable3, func3);
					Func<NamingParameter, string> func4;
					if ((func4 = NamingConfigurationViewModel.<>c.\u0016) == null)
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
						func4 = (NamingConfigurationViewModel.<>c.\u0016 = new Func<NamingParameter, string>(NamingConfigurationViewModel.<>c.\u001F.\u0010));
					}
					List<NamingParameter> list = Enumerable.ToList<NamingParameter>(Enumerable.OrderBy<NamingParameter, string>(enumerable4, func4));
					IEnumerable<NamingParameter> enumerable5 = Enumerable.Except<NamingParameter>(\u000F\u0016\u0007.\u001D(this), list);
					Func<NamingParameter, string> func5;
					if ((func5 = NamingConfigurationViewModel.<>c.\u000B) == null)
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
						func5 = (NamingConfigurationViewModel.<>c.\u000B = new Func<NamingParameter, string>(NamingConfigurationViewModel.<>c.\u001F.\u000E));
					}
					\u0013\u0005\u0007.\u001D(this, \u0004\u000F\u0007.\u000A(Enumerable.OrderBy<NamingParameter, string>(enumerable5, func5)));
					for (int i = 0; i < \u000A\u000F\u0007.\u000A(list); i++)
					{
						\u0007\u000F\u0007.\u000A(\u000F\u0016\u0007.\u001D(this), i, \u001D\u000F\u0007.\u000A(list, i));
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

		// Token: 0x06000344 RID: 836 RVA: 0x00014C0C File Offset: 0x00012E0C
		public void MoveTop()
		{
			if (\u0008\u000F\u0007.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.MoveTop()).MethodHandle;
				}
				if (Enumerable.Any<NamingParameter>(\u0008\u000F\u0007.\u000A(this)))
				{
					object u001F = Enumerable.Except<NamingParameter>(\u0005\u0016\u0007.\u001D(this), \u0008\u000F\u0007.\u000A(this));
					\u0010\u0016\u0007.\u001D(this, \u0004\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this)));
					IEnumerator<NamingParameter> enumerator = \u0005\u000F\u0007.\u000A(u001F);
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
							\u0019\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), u000A);
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
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
							\u001F\u0017\u000A.\u000A(enumerator);
						}
					}
					return;
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
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00014CDC File Offset: 0x00012EDC
		public void MoveBottom()
		{
			IEnumerator<NamingParameter> enumerator = \u0002\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
					int num = \u001E\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), u000A);
					if (num >= 0)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.MoveBottom()).MethodHandle;
						}
						if (num < \u0011\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this)) - 1)
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
							\u001B\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num, \u0011\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this)) - 1);
						}
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
						switch (1)
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

		// Token: 0x06000346 RID: 838 RVA: 0x00014DA4 File Offset: 0x00012FA4
		public void MoveUp()
		{
			if (\u0008\u000F\u0007.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.MoveUp()).MethodHandle;
				}
				if (Enumerable.Any<NamingParameter>(\u0008\u000F\u0007.\u000A(this)))
				{
					int num = \u0011\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this));
					int num2 = \u001E\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), \u0017\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this), 0));
					IEnumerator<NamingParameter> enumerator = \u0002\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
							int num3 = \u001E\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), u000A);
							if (num3 < num2)
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
								num2 = num3;
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
					if (num2 > 0)
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
						NamingParameter u = \u0017\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num2 - 1);
						\u0020\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num2 - 1);
						\u0007\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num2 - 1 + num, u);
					}
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

		// Token: 0x06000347 RID: 839 RVA: 0x00014EDC File Offset: 0x000130DC
		public void MoveDown()
		{
			if (\u0008\u000F\u0007.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.MoveDown()).MethodHandle;
				}
				if (Enumerable.Any<NamingParameter>(\u0008\u000F\u0007.\u000A(this)))
				{
					int num = \u0011\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this));
					int num2 = \u001E\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), \u0017\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this), 0));
					IEnumerator<NamingParameter> enumerator = \u0002\u000F\u0007.\u000A(\u0008\u000F\u0007.\u000A(this));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator))
						{
							NamingParameter u000A = \u0018\u000F\u0007.\u000A(enumerator);
							int num3 = \u001E\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), u000A);
							if (num3 > num2)
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
								num2 = num3;
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
					if (num2 < \u0011\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this)) - 1)
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
						NamingParameter u = \u0017\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num2 + 1);
						\u0020\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num2 + 1);
						\u0007\u000F\u0007.\u000A(\u0005\u0016\u0007.\u001D(this), num2 + 1 - num, u);
					}
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

		// Token: 0x06000348 RID: 840 RVA: 0x00015024 File Offset: 0x00013224
		private bool PKR(object F)
		{
			return Enumerable.Any<NamingParameter>(\u0006\u000F\u0007.\u000A(this));
		}

		// Token: 0x06000349 RID: 841 RVA: 0x00015040 File Offset: 0x00013240
		private bool OKR(object F)
		{
			return Enumerable.Any<NamingParameter>(\u0005\u0016\u0007.\u001D(this));
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0001505C File Offset: 0x0001325C
		private bool TKR(object F)
		{
			return Enumerable.Any<NamingParameter>(\u0008\u000F\u0007.\u000A(this));
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00015078 File Offset: 0x00013278
		private bool IKR(object F)
		{
			if (\u0003\u000F\u0007.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.IKR(object)).MethodHandle;
				}
				if (\u001C\u000F\u0007.\u0007(\u0012\u000F\u0007.\u000A(this)) > 0)
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
					return !Enumerable.Any<ErrorObject>(Enumerable.Cast<ErrorObject>(\u0014\u000F\u0007.\u000A(this, "CustomField")));
				}
			}
			return false;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x000150E0 File Offset: 0x000132E0
		private bool QKR(object F)
		{
			if (\u0010\u000F\u0007.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.QKR(object)).MethodHandle;
				}
				if (\u001C\u000F\u0007.\u0007(\u000D\u000F\u0007.\u000A(this)) > 0)
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
					return !Enumerable.Any<ErrorObject>(Enumerable.Cast<ErrorObject>(\u0014\u000F\u0007.\u000A(this, "CustomSeparator")));
				}
			}
			return false;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00015148 File Offset: 0x00013348
		private bool AKR(string F)
		{
			return \u0013\u000F\u0007.\u0007(F, \u001A\u000F\u0007.\u0007("?|\\:{}[];<>`~")) < 0;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0001516C File Offset: 0x0001336C
		private bool GKR(string F)
		{
			return \u000C\u000F\u0007.\u0007(\u0015\u000F\u0007.\u000A("[^a-zA-Z0-9]"), F);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00015190 File Offset: 0x00013390
		public override bool Validate(string propertyName, object value)
		{
			bool result = true;
			if (!\u0008\u0013\u000A.\u000A(propertyName, "CustomField"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamingConfigurationViewModel.Validate(string, object)).MethodHandle;
				}
				if (!\u0008\u0013\u000A.\u000A(propertyName, "FieldSeparator"))
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
					if (!\u0008\u0013\u000A.\u000A(propertyName, "CustomSeparator"))
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
						bool flag;
						if (this.AKR(\u0013\u0001\u0010.\u001F(value)))
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
							flag = this.GKR(\u0013\u0001\u0010.\u001F(value));
						}
						else
						{
							flag = false;
						}
						result = flag;
					}
				}
				else
				{
					bool flag2;
					if (this.AKR(\u0013\u0001\u0010.\u001F(value)))
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
						flag2 = this.GKR(\u0013\u0001\u0010.\u001F(value));
					}
					else
					{
						flag2 = false;
					}
					result = flag2;
				}
			}
			else
			{
				result = this.AKR(\u0013\u0001\u0010.\u001F(value));
			}
			return result;
		}

		// Token: 0x04000123 RID: 291
		private readonly \u0013\u001D CR;

		// Token: 0x04000124 RID: 292
		private static string LR;

		// Token: 0x04000125 RID: 293
		private static string SR;

		// Token: 0x04000126 RID: 294
		private ObservableCollection<NamingParameter> BR;

		// Token: 0x04000127 RID: 295
		private ObservableCollection<NamingParameter> UR = new ObservableCollection<NamingParameter>();

		// Token: 0x04000128 RID: 296
		private ObservableCollection<NamingParameter> WR = new ObservableCollection<NamingParameter>();

		// Token: 0x04000129 RID: 297
		private ObservableCollection<NamingParameter> KR = new ObservableCollection<NamingParameter>();

		// Token: 0x0400012A RID: 298
		private bool JR;

		// Token: 0x0400012B RID: 299
		private bool ER;

		// Token: 0x0400012C RID: 300
		private string NR = " ";

		// Token: 0x0400012D RID: 301
		private string MR = "";

		// Token: 0x0400012E RID: 302
		private string VR = "";

		// Token: 0x0400012F RID: 303
		private bool ZR;

		// Token: 0x04000130 RID: 304
		private bool XR;

		// Token: 0x04000131 RID: 305
		[CompilerGenerated]
		private ICommand PR;

		// Token: 0x04000132 RID: 306
		[CompilerGenerated]
		private ICommand OR;

		// Token: 0x04000133 RID: 307
		[CompilerGenerated]
		private ICommand TR;

		// Token: 0x04000134 RID: 308
		[CompilerGenerated]
		private ICommand IR;

		// Token: 0x04000135 RID: 309
		[CompilerGenerated]
		private ICommand QR;

		// Token: 0x04000136 RID: 310
		[CompilerGenerated]
		private ICommand AR;

		// Token: 0x04000137 RID: 311
		[CompilerGenerated]
		private ICommand GR;

		// Token: 0x04000138 RID: 312
		[CompilerGenerated]
		private ICommand FD;

		// Token: 0x04000139 RID: 313
		[CompilerGenerated]
		private ICommand RD;

		// Token: 0x02000795 RID: 1941
		[CompilerGenerated]
		private sealed class \u0017\u0007
		{
			// Token: 0x06004B8A RID: 19338 RVA: 0x001DA3B8 File Offset: 0x001D85B8
			internal bool \u000A(NamingParameter \u001F)
			{
				return Enumerable.Contains<NamingParameter>(this.\u001F, \u001F);
			}

			// Token: 0x04001ECA RID: 7882
			public IEnumerable<NamingParameter> \u001F;
		}
	}
}
