using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.Morta.Model
{
	// Token: 0x020001B3 RID: 435
	public class AddComboxModel : ModelBase
	{
		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x0600102D RID: 4141 RVA: 0x00066548 File Offset: 0x00064748
		// (set) Token: 0x0600102E RID: 4142 RVA: 0x0006655C File Offset: 0x0006475C
		public bool CanBeAdded
		{
			get
			{
				return this.GH;
			}
			set
			{
				if (this.GH != value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AddComboxModel.set_CanBeAdded(bool)).MethodHandle;
					}
					this.GH = value;
					\u0007\u0013\u000A.\u000A(this, "CanBeAdded");
				}
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x0600102F RID: 4143 RVA: 0x00066598 File Offset: 0x00064798
		// (set) Token: 0x06001030 RID: 4144 RVA: 0x000665AC File Offset: 0x000647AC
		public string TempName
		{
			get
			{
				return this.AH;
			}
			set
			{
				this.AH = value;
				\u0007\u0013\u000A.\u000A(this, "TempName");
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x000665CC File Offset: 0x000647CC
		// (set) Token: 0x06001032 RID: 4146 RVA: 0x000665E0 File Offset: 0x000647E0
		public bool IsAddItemEnabled
		{
			get
			{
				return this.FY;
			}
			set
			{
				this.FY = value;
				\u0007\u0013\u000A.\u000A(this, "IsAddItemEnabled");
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x00066600 File Offset: 0x00064800
		// (set) Token: 0x06001034 RID: 4148 RVA: 0x00066614 File Offset: 0x00064814
		public ObservableCollection<TableTypeInfo> Items { get; set; } = new ObservableCollection<TableTypeInfo>();

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06001035 RID: 4149 RVA: 0x00066628 File Offset: 0x00064828
		// (set) Token: 0x06001036 RID: 4150 RVA: 0x0006663C File Offset: 0x0006483C
		public TableTypeInfo SelectedItem
		{
			get
			{
				return this.RY;
			}
			set
			{
				this.RY = value;
				\u0007\u0013\u000A.\u000A(this, "SelectedItem");
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06001037 RID: 4151 RVA: 0x0006665C File Offset: 0x0006485C
		public ICommand AllowToItemCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.PP), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x06001038 RID: 4152 RVA: 0x00066684 File Offset: 0x00064884
		public ICommand CancelItemCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OP), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x06001039 RID: 4153 RVA: 0x000666AC File Offset: 0x000648AC
		public ICommand AddItemCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.OnAddItemCommand), new Predicate<object>(this.TP));
			}
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x000666D8 File Offset: 0x000648D8
		private void PP()
		{
			\u0018\u001D\u0018.\u000A(this, true);
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x000666EC File Offset: 0x000648EC
		public void OnAddItemCommand()
		{
			TableTypeInfo u000A = \u0005\u001D\u0018.\u000A(this);
			\u000A\u000A\u0018.\u001D(this, u000A);
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x0006670C File Offset: 0x0006490C
		public TableTypeInfo AddItem()
		{
			TableTypeInfo tableTypeInfo = \u0006\u001D\u0018.\u000A();
			\u0010\u0007\u0018.\u0007(tableTypeInfo, \u0002\u001D\u0018.\u000A(this));
			TableTypeInfo tableTypeInfo2 = tableTypeInfo;
			\u000B\u001D\u0018.\u000A(\u0007\u000A\u0018.\u001D(this), tableTypeInfo2);
			\u001D\u0007\u0018.\u001D(this, Enumerable.ToList<TableTypeInfo>(\u0007\u000A\u0018.\u001D(this)));
			\u0016\u001D\u0018.\u000A(this, "");
			\u0018\u001D\u0018.\u000A(this, false);
			return tableTypeInfo2;
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x00066768 File Offset: 0x00064968
		public void AddItems(List<TableTypeInfo> tempItems)
		{
			\u0010\u001D\u0018.\u000A(tempItems, new \u000C\u0006(true));
			\u000D\u001D\u0018.\u000A(\u0007\u000A\u0018.\u001D(this));
			List<TableTypeInfo>.Enumerator enumerator = \u001C\u001D\u0018.\u000A(tempItems);
			try
			{
				while (\u0012\u001D\u0018.\u000A(ref enumerator))
				{
					TableTypeInfo tableTypeInfo = \u0003\u001D\u0018.\u000A(ref enumerator);
					if (!\u0008\u0013\u000A.\u000A(\u0003\u000A\u0018.\u0007(tableTypeInfo), "No Type"))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(AddComboxModel.AddItems(List<TableTypeInfo>)).MethodHandle;
						}
						\u000B\u001D\u0018.\u000A(\u0007\u000A\u0018.\u001D(this), tableTypeInfo);
					}
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
				((IDisposable)enumerator).Dispose();
			}
			\u000F\u001D\u0018.\u000A(\u0007\u000A\u0018.\u001D(this), 0, TableTypeInfo.\u0002());
			\u000A\u000A\u0018.\u001D(this, Enumerable.First<TableTypeInfo>(\u0007\u000A\u0018.\u001D(this)));
			try
			{
				\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u0007\u000A\u0018.\u001D(this)));
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\Model\\AddComboxModel.cs", "AddItems");
			}
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x00066878 File Offset: 0x00064A78
		private void OP()
		{
			\u0016\u001D\u0018.\u000A(this, "");
			\u0018\u001D\u0018.\u000A(this, false);
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x00066898 File Offset: 0x00064A98
		private bool TP(object F)
		{
			bool u000A;
			if (!\u0010\u0010\u001D.\u000A(\u0002\u001D\u0018.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddComboxModel.TP(object)).MethodHandle;
				}
				if (!\u0015\u001F\u0019.\u000A(\u0002\u001D\u0018.\u000A(this), false, \u000D\u0018\u000E.\u001F))
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
					if (\u0007\u000A\u0018.\u001D(this) != null)
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
						u000A = !Enumerable.Any<TableTypeInfo>(\u0007\u000A\u0018.\u001D(this), new Func<TableTypeInfo, bool>(this.IP));
						goto IL_7E;
					}
					u000A = false;
					goto IL_7E;
				}
			}
			u000A = false;
			IL_7E:
			\u0008\u001D\u0018.\u000A(this, u000A);
			return \u000E\u001D\u0018.\u000A(this);
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x00066930 File Offset: 0x00064B30
		[BindableMethod("OnPreviewKeyDown")]
		public void OnPreviewKeyDown(KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) == Key.Return)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddComboxModel.OnPreviewKeyDown(KeyEventArgs)).MethodHandle;
				}
				if (this.TP(\u0019\u001D\u000E.\u001F))
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
					\u001B\u001D\u0018.\u000A(this);
					\u0019\u0013\u000A.\u000A(e, true);
					return;
				}
			}
			if (\u001A\u001A\u0019.\u000A(e) == Key.Escape)
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
				this.OP();
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x000669A8 File Offset: 0x00064BA8
		[BindableMethod("OnComboBoxPreviewKeyDown")]
		public void OnComboBoxPreviewKeyDown(KeyEventArgs e)
		{
			if (\u001A\u001A\u0019.\u000A(e) != Key.Down)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddComboxModel.OnComboBoxPreviewKeyDown(KeyEventArgs)).MethodHandle;
				}
				if (\u001A\u001A\u0019.\u000A(e) != Key.Up)
				{
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
			\u0019\u0013\u000A.\u000A(e, true);
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x000669F4 File Offset: 0x00064BF4
		[BindableMethod("OnPreviewTextInput")]
		public void OnPreviewTextInput(TextCompositionEventArgs e)
		{
			if (\u0015\u001F\u0019.\u000A(\u0001\u0015\u0007.\u000A(e), false, \u000D\u0018\u000E.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddComboxModel.OnPreviewTextInput(TextCompositionEventArgs)).MethodHandle;
				}
				\u0019\u0013\u000A.\u000A(e, true);
			}
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x00066A34 File Offset: 0x00064C34
		[CompilerGenerated]
		private bool IP(TableTypeInfo F)
		{
			return \u000D\u0008\u000A.\u000A(\u0003\u000A\u0018.\u0007(F), \u0002\u001D\u0018.\u000A(this), true);
		}

		// Token: 0x04000678 RID: 1656
		private string AH;

		// Token: 0x04000679 RID: 1657
		private bool GH;

		// Token: 0x0400067A RID: 1658
		private bool FY;

		// Token: 0x0400067B RID: 1659
		private TableTypeInfo RY;

		// Token: 0x0400067C RID: 1660
		[CompilerGenerated]
		private ObservableCollection<TableTypeInfo> DY;
	}
}
