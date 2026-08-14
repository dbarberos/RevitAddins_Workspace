using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using ProSheets;
using ProSheets.Extensions;

namespace DiRoots.ProSheets.ViewModels
{
	// Token: 0x02000031 RID: 49
	public class ParameterBaseModel : ViewModelBase
	{
		// Token: 0x060001FA RID: 506 RVA: 0x0000B424 File Offset: 0x00009624
		public ParameterBaseModel(List<SelectionParameter> availableItems, List<SelectionParameter> selectedItems)
		{
			this.\u0016\u0014 = new ObservableCollection<SelectionParameter>(availableItems);
			ICollectionView u000C = \u0010\u0006\u0018.\u0018(\u001B\u000C\u0014.\u0018(this));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(u000C), new SortDescription("SortingIndex", ListSortDirection.Ascending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(u000C), new SortDescription("DisplayName", ListSortDirection.Ascending));
			\u0005\u0006\u0018.\u0018(u000C, \u0007\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(\u000E\u0006\u0018.\u0018(u000C), new Predicate<object>(this.\u000A\u001C))));
			this.\u000F\u0014 = new ObservableCollection<SelectionParameter>(selectedItems);
			this.\u0012\u0018 = new ObservableCollection<SelectionParameter>(availableItems);
			this.\u000D\u0018 = new ObservableCollection<SelectionParameter>(selectedItems);
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060001FB RID: 507 RVA: 0x0000B4D0 File Offset: 0x000096D0
		// (set) Token: 0x060001FC RID: 508 RVA: 0x0000B4E4 File Offset: 0x000096E4
		public List<SelectionParameter> DefaultParameters { get; set; }

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060001FD RID: 509 RVA: 0x0000B4F8 File Offset: 0x000096F8
		// (set) Token: 0x060001FE RID: 510 RVA: 0x0000B50C File Offset: 0x0000970C
		public string SearchText
		{
			get
			{
				return this.\u0009\u0018;
			}
			set
			{
				this.\u0009\u0018 = value;
				\u001D\u0008\u0018.\u0018(\u0010\u0006\u0018.\u0018(\u001B\u000C\u0014.\u0018(this)));
				\u0011\u0010\u0018.\u0018(this, "SearchText");
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060001FF RID: 511 RVA: 0x0000B540 File Offset: 0x00009740
		// (set) Token: 0x06000200 RID: 512 RVA: 0x0000B554 File Offset: 0x00009754
		public ObservableCollection<SelectionParameter> TempAvailableParams
		{
			get
			{
				return this.\u0016\u0014;
			}
			set
			{
				this.\u0016\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "TempAvailableParams");
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x06000201 RID: 513 RVA: 0x0000B574 File Offset: 0x00009774
		// (set) Token: 0x06000202 RID: 514 RVA: 0x0000B588 File Offset: 0x00009788
		public ObservableCollection<SelectionParameter> TempUsedParams
		{
			get
			{
				return this.\u000F\u0014;
			}
			set
			{
				this.\u000F\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "TempUsedParams");
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000203 RID: 515 RVA: 0x0000B5A8 File Offset: 0x000097A8
		// (set) Token: 0x06000204 RID: 516 RVA: 0x0000B5BC File Offset: 0x000097BC
		public ObservableCollection<SelectionParameter> AvailableParams
		{
			get
			{
				return this.\u0012\u0018;
			}
			set
			{
				this.\u0012\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "AvailableParams");
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000205 RID: 517 RVA: 0x0000B5DC File Offset: 0x000097DC
		// (set) Token: 0x06000206 RID: 518 RVA: 0x0000B5F0 File Offset: 0x000097F0
		public ObservableCollection<SelectionParameter> UsedParams
		{
			get
			{
				return this.\u000D\u0018;
			}
			set
			{
				this.\u000D\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "UsedParams");
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000207 RID: 519 RVA: 0x0000B610 File Offset: 0x00009810
		// (set) Token: 0x06000208 RID: 520 RVA: 0x0000B624 File Offset: 0x00009824
		public IList<SelectionParameter> SelectedUsedParams
		{
			get
			{
				return this.\u001C\u0018;
			}
			set
			{
				this.\u001C\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedUsedParams");
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000209 RID: 521 RVA: 0x0000B644 File Offset: 0x00009844
		// (set) Token: 0x0600020A RID: 522 RVA: 0x0000B658 File Offset: 0x00009858
		public IList<SelectionParameter> SelectedAvailableParams
		{
			get
			{
				return this.\u0013\u0018;
			}
			set
			{
				this.\u0013\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedAvailableParams");
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600020B RID: 523 RVA: 0x0000B678 File Offset: 0x00009878
		// (set) Token: 0x0600020C RID: 524 RVA: 0x0000B68C File Offset: 0x0000988C
		public bool IncludeProjectParams
		{
			get
			{
				return this.\u0012\u0014;
			}
			set
			{
				this.\u0012\u0014 = value;
				\u0011\u0010\u0018.\u0018(this, "IncludeProjectParams");
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600020D RID: 525 RVA: 0x0000B6AC File Offset: 0x000098AC
		// (set) Token: 0x0600020E RID: 526 RVA: 0x0000B6C0 File Offset: 0x000098C0
		public bool DefaultSeparatorChecked
		{
			get
			{
				return this.\u0013\u0014;
			}
			set
			{
				this.\u0013\u0014 = value;
				this.OnPropertyChanged<bool>(new Func<bool>(this.\u0002\u001C), "DefaultSeparatorChecked");
			}
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600020F RID: 527 RVA: 0x0000B6EC File Offset: 0x000098EC
		// (set) Token: 0x06000210 RID: 528 RVA: 0x0000B700 File Offset: 0x00009900
		public string DefaultFieldSeparator
		{
			get
			{
				return this.\u0009\u0014;
			}
			set
			{
				this.\u0009\u0014 = value;
				this.OnPropertyChanged<string>(new Func<string>(this.\u0004\u001C), "DefaultFieldSeparator");
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0000B72C File Offset: 0x0000992C
		// (set) Token: 0x06000212 RID: 530 RVA: 0x0000B740 File Offset: 0x00009940
		public string CustomField
		{
			get
			{
				return this.\u000D\u0014;
			}
			set
			{
				this.\u000D\u0014 = value;
				this.OnPropertyChanged<string>(new Func<string>(this.\u001D\u001C), "CustomField");
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000213 RID: 531 RVA: 0x0000B76C File Offset: 0x0000996C
		// (set) Token: 0x06000214 RID: 532 RVA: 0x0000B780 File Offset: 0x00009980
		public string CustomFieldSeparator
		{
			get
			{
				return this.\u001C\u0014;
			}
			set
			{
				this.\u001C\u0014 = value;
				this.OnPropertyChanged<string>(new Func<string>(this.\u001A\u001C), "CustomFieldSeparator");
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000215 RID: 533 RVA: 0x0000B7AC File Offset: 0x000099AC
		public CommandBase AvailableToUsedCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u001F\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000216 RID: 534 RVA: 0x0000B7D4 File Offset: 0x000099D4
		public CommandBase AvailableDoubleClickCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0015\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0000B7FC File Offset: 0x000099FC
		public CommandBase UsedDoubleClickCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0011\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000218 RID: 536 RVA: 0x0000B824 File Offset: 0x00009A24
		public CommandBase UsedToAvailableCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0020\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000219 RID: 537 RVA: 0x0000B84C File Offset: 0x00009A4C
		public CommandBase MoveToBeginningCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u000D\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600021A RID: 538 RVA: 0x0000B874 File Offset: 0x00009A74
		public CommandBase MoveUpCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u001C\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600021B RID: 539 RVA: 0x0000B89C File Offset: 0x00009A9C
		public CommandBase MoveDownCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0013\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600021C RID: 540 RVA: 0x0000B8C4 File Offset: 0x00009AC4
		public CommandBase MoveToEndCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0007\u000D), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x0600021D RID: 541 RVA: 0x0000B8EC File Offset: 0x00009AEC
		public CommandBase ReloadCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0012\u001C), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600021E RID: 542 RVA: 0x0000B914 File Offset: 0x00009B14
		public CommandBase OnApplyCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.ApplyCommand), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x0600021F RID: 543 RVA: 0x0000B93C File Offset: 0x00009B3C
		[BindableMethod("OnIncludeProjectInfo")]
		public void OnIncludeProjectInfo()
		{
			\u001D\u0008\u0018.\u0018(\u0010\u0006\u0018.\u0018(\u001B\u000C\u0014.\u0018(this)));
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0000B960 File Offset: 0x00009B60
		[BindableMethod("OnAddCustomParameter")]
		public void OnCustomParameter()
		{
			this.\u0017\u001C();
		}

		// Token: 0x06000221 RID: 545 RVA: 0x0000B974 File Offset: 0x00009B74
		[BindableMethod("OnAddCustomSeparator")]
		public void OnAddCustomSeparator()
		{
			this.\u001E\u001C();
		}

		// Token: 0x06000222 RID: 546 RVA: 0x0000B988 File Offset: 0x00009B88
		private bool \u000A\u001C(object \u000C)
		{
			SelectionParameter u000C = \u000F\u001D\u000F.\u000C(\u000C);
			bool flag = true;
			if (!\u001F\u001A\u0018.\u0018(\u000C\u0018\u0014.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u000A\u001C(object)).MethodHandle;
				}
				flag = \u001B\u0013\u0018.\u000C(\u0018\u0018\u0014.\u0018(u000C), \u000C\u0018\u0014.\u0018(this));
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
				if (\u000E\u000C\u0014.\u0018(u000C))
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
					flag = \u0005\u000C\u0014.\u0018(this);
				}
			}
			return flag;
		}

		// Token: 0x06000223 RID: 547 RVA: 0x0000BA08 File Offset: 0x00009C08
		private void \u0012\u001C()
		{
			\u000D\u0018\u0014.\u0018(this, string.Empty);
			\u000F\u0018\u0014.\u0018(this, \u0003\u0018\u0014.\u0018(\u0012\u0018\u0014.\u0014(this)));
			\u0014\u0018\u0014.\u0018(this, \u0003\u0018\u0014.\u0018(\u0016\u0018\u0014.\u0014(this)));
			ICollectionView u000C = \u0010\u0006\u0018.\u0018(\u001B\u000C\u0014.\u0018(this));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(u000C), new SortDescription("SortingIndex", ListSortDirection.Ascending));
			\u001B\u0008\u0018.\u0018(\u0005\u0008\u0018.\u0018(u000C), new SortDescription("DisplayName", ListSortDirection.Ascending));
			\u0005\u0006\u0018.\u0018(u000C, \u0007\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(\u000E\u0006\u0018.\u0018(u000C), new Predicate<object>(this.\u000A\u001C))));
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000BAB0 File Offset: 0x00009CB0
		private void \u0020\u001C()
		{
			if (\u0011\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0020\u001C()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001F\u0018\u0014.\u0018(\u0011\u0018\u0014.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						SelectionParameter selectionParameter = \u0020\u0018\u0014.\u0018(enumerator);
						if (!\u000A\u0018\u0014.\u0018(selectionParameter))
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
							\u0009\u0018\u0014.\u0018(\u001B\u000C\u0014.\u0018(this), selectionParameter);
						}
						\u001C\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), selectionParameter);
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000BB68 File Offset: 0x00009D68
		private void \u001F\u001C()
		{
			if (\u0015\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u001F\u001C()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001F\u0018\u0014.\u0018(\u0015\u0018\u0014.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						SelectionParameter u = \u0020\u0018\u0014.\u0018(enumerator);
						\u0009\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), u);
						\u001C\u0018\u0014.\u0018(\u001B\u000C\u0014.\u0018(this), u);
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
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000BC0C File Offset: 0x00009E0C
		private void \u0011\u001C()
		{
			if (\u0011\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0011\u001C()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001F\u0018\u0014.\u0018(\u0011\u0018\u0014.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						SelectionParameter selectionParameter = \u0020\u0018\u0014.\u0018(enumerator);
						if (!\u000A\u0018\u0014.\u0018(selectionParameter))
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
							\u0009\u0018\u0014.\u0018(\u001B\u000C\u0014.\u0018(this), selectionParameter);
						}
						\u001C\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), selectionParameter);
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
							switch (5)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		private void \u0015\u001C()
		{
			if (\u0015\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0015\u001C()).MethodHandle;
				}
				IEnumerator<SelectionParameter> enumerator = \u001F\u0018\u0014.\u0018(\u0015\u0018\u0014.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						SelectionParameter u = \u0020\u0018\u0014.\u0018(enumerator);
						\u0009\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), u);
						\u001C\u0018\u0014.\u0018(\u001B\u000C\u0014.\u0018(this), u);
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000BD68 File Offset: 0x00009F68
		private void \u000D\u001C()
		{
			if (\u0011\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u000D\u001C()).MethodHandle;
				}
				object u000C = Enumerable.ToList<SelectionParameter>(Enumerable.OrderBy<SelectionParameter, int>(\u0011\u0018\u0014.\u0018(this), new Func<SelectionParameter, int>(this.\u000B\u001C)));
				int num = 0;
				List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(u000C);
				try
				{
					while (\u0017\u0018\u0014.\u0018(ref enumerator))
					{
						SelectionParameter u = \u0004\u0018\u0014.\u0018(ref enumerator);
						\u001E\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), u), num++);
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
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000BE24 File Offset: 0x0000A024
		private void \u001C\u001C()
		{
			if (\u0011\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u001C\u001C()).MethodHandle;
				}
				List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(Enumerable.ToList<SelectionParameter>(Enumerable.OrderBy<SelectionParameter, int>(\u0011\u0018\u0014.\u0018(this), new Func<SelectionParameter, int>(this.\u0019\u001C))));
				try
				{
					while (\u0017\u0018\u0014.\u0018(ref enumerator))
					{
						SelectionParameter u = \u0004\u0018\u0014.\u0018(ref enumerator);
						int num = \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), u);
						int num2 = num - 1;
						if (num2 < 0)
						{
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
						\u001E\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), num, num2);
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
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		private void \u0013\u001C()
		{
			if (\u0011\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0013\u001C()).MethodHandle;
				}
				List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(Enumerable.ToList<SelectionParameter>(Enumerable.OrderByDescending<SelectionParameter, int>(\u0011\u0018\u0014.\u0018(this), new Func<SelectionParameter, int>(this.\u0007\u001C))));
				try
				{
					while (\u0017\u0018\u0014.\u0018(ref enumerator))
					{
						SelectionParameter u = \u0004\u0018\u0014.\u0018(ref enumerator);
						int num = \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), u);
						int num2 = num + 1;
						if (num2 >= \u001A\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this)))
						{
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
						\u001E\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), num, num2);
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
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000BFC8 File Offset: 0x0000A1C8
		private void \u0007\u000D()
		{
			if (\u0011\u0018\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0007\u000D()).MethodHandle;
				}
				object u000C = Enumerable.ToList<SelectionParameter>(Enumerable.OrderByDescending<SelectionParameter, int>(\u0011\u0018\u0014.\u0018(this), new Func<SelectionParameter, int>(this.\u0010\u001C)));
				int num = \u001A\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this)) - 1;
				List<SelectionParameter>.Enumerator enumerator = \u001D\u0018\u0014.\u0018(u000C);
				try
				{
					while (\u0017\u0018\u0014.\u0018(ref enumerator))
					{
						SelectionParameter u = \u0004\u0018\u0014.\u0018(ref enumerator);
						\u001E\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), u), num--);
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
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000C094 File Offset: 0x0000A294
		private void \u0017\u001C()
		{
			if (\u001F\u001A\u0018.\u0018(\u0010\u0018\u0014.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0017\u001C()).MethodHandle;
				}
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0016);
				return;
			}
			SelectionParameter selectionParameter = \u0006\u0018\u0014.\u0018();
			\u0007\u0018\u0014.\u0018(selectionParameter, \u0010\u0018\u0014.\u0018(this));
			\u0019\u0018\u0014.\u0018(selectionParameter, SelectionParameterType.CustomText);
			\u0009\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), selectionParameter);
			\u000B\u0018\u0014.\u0018(this, "");
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000C10C File Offset: 0x0000A30C
		private void \u001E\u001C()
		{
			if (\u001F\u001A\u0018.\u0018(\u0001\u0018\u0014.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u001E\u001C()).MethodHandle;
				}
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0003);
				return;
			}
			SelectionParameter selectionParameter = \u0006\u0018\u0014.\u0018();
			\u0007\u0018\u0014.\u0018(selectionParameter, \u0001\u0018\u0014.\u0018(this));
			\u0019\u0018\u0014.\u0018(selectionParameter, SelectionParameterType.CustemSeparator);
			\u0009\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), selectionParameter);
			\u0008\u0018\u0014.\u0018(this, "");
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000C184 File Offset: 0x0000A384
		public void ApplyCommand()
		{
			if (\u001F\u001A\u0018.\u0018(\u000E\u0018\u0014.\u0014(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.ApplyCommand()).MethodHandle;
				}
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u000C);
				return;
			}
			\u0005\u0018\u0014.\u0018(this, \u0013\u0018\u0014.\u0018(this));
			\u001B\u0018\u0014.\u0014(this, \u001B\u000C\u0014.\u0018(this));
			\u0007\u000B\u0018.\u0003(\u0001\u000C\u0014.\u0018(this), new bool?(true));
			\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000C204 File Offset: 0x0000A404
		[CompilerGenerated]
		private bool \u0002\u001C()
		{
			return \u000C\u0014\u0014.\u0014(this);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x0000C21C File Offset: 0x0000A41C
		[CompilerGenerated]
		private string \u0004\u001C()
		{
			return \u000E\u0018\u0014.\u0014(this);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000C234 File Offset: 0x0000A434
		[CompilerGenerated]
		private string \u001D\u001C()
		{
			return \u0010\u0018\u0014.\u0018(this);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x0000C24C File Offset: 0x0000A44C
		[CompilerGenerated]
		private string \u001A\u001C()
		{
			return \u0001\u0018\u0014.\u0018(this);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000C264 File Offset: 0x0000A464
		[CompilerGenerated]
		private int \u000B\u001C(SelectionParameter \u000C)
		{
			return \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), \u000C);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000C284 File Offset: 0x0000A484
		[CompilerGenerated]
		private int \u0019\u001C(SelectionParameter \u000C)
		{
			return \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), \u000C);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000C2A4 File Offset: 0x0000A4A4
		[CompilerGenerated]
		private int \u0007\u001C(SelectionParameter \u000C)
		{
			return \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), \u000C);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000C2C4 File Offset: 0x0000A4C4
		[CompilerGenerated]
		private int \u0010\u001C(SelectionParameter \u000C)
		{
			return \u0002\u0018\u0014.\u0018(\u0013\u0018\u0014.\u0018(this), \u000C);
		}

		// Token: 0x040000F4 RID: 244
		private ObservableCollection<SelectionParameter> \u0016\u0014;

		// Token: 0x040000F5 RID: 245
		private ObservableCollection<SelectionParameter> \u000F\u0014;

		// Token: 0x040000F6 RID: 246
		private ObservableCollection<SelectionParameter> \u0012\u0018;

		// Token: 0x040000F7 RID: 247
		private ObservableCollection<SelectionParameter> \u000D\u0018;

		// Token: 0x040000F8 RID: 248
		private IList<SelectionParameter> \u001C\u0018;

		// Token: 0x040000F9 RID: 249
		private IList<SelectionParameter> \u0013\u0018;

		// Token: 0x040000FA RID: 250
		private bool \u0012\u0014;

		// Token: 0x040000FB RID: 251
		private string \u000D\u0014;

		// Token: 0x040000FC RID: 252
		private string \u001C\u0014;

		// Token: 0x040000FD RID: 253
		private bool \u0013\u0014;

		// Token: 0x040000FE RID: 254
		private string \u0009\u0014;

		// Token: 0x040000FF RID: 255
		private string \u0009\u0018;

		// Token: 0x04000100 RID: 256
		[CompilerGenerated]
		private List<SelectionParameter> \u0020\u0018;
	}
}
