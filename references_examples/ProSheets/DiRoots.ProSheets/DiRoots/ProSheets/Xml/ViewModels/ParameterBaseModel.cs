using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.ProSheets.Xml.Interfaces;
using ProSheets.Extensions;

namespace DiRoots.ProSheets.Xml.ViewModels
{
	// Token: 0x02000021 RID: 33
	public class ParameterBaseModel : ViewModelBase
	{
		// Token: 0x06000125 RID: 293 RVA: 0x00007978 File Offset: 0x00005B78
		public ParameterBaseModel()
		{
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000798C File Offset: 0x00005B8C
		public ParameterBaseModel(List<IParameterInfo> availableItems, List<IParameterInfo> selectedItems)
		{
			\u0018\u0008\u0018.\u0018(this, Enumerable.ToList<IParameterInfo>(availableItems));
			this.\u0012\u0018 = new ObservableCollection<IParameterInfo>(availableItems);
			ICollectionView u000C = \u0010\u0006\u0018.\u0018(\u000C\u0008\u0018.\u0014(this));
			\u0005\u0006\u0018.\u0018(u000C, \u0007\u0004\u000F.\u000C(\u001C\u0019\u0018.\u0018(\u000E\u0006\u0018.\u0018(u000C), new Predicate<object>(this.ParameterFilter))));
			this.\u000D\u0018 = new ObservableCollection<IParameterInfo>(selectedItems);
			this.\u0001\u000D();
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00007A04 File Offset: 0x00005C04
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00007A18 File Offset: 0x00005C18
		public List<IParameterInfo> DefaultParameters { get; set; }

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000129 RID: 297 RVA: 0x00007A2C File Offset: 0x00005C2C
		// (set) Token: 0x0600012A RID: 298 RVA: 0x00007A40 File Offset: 0x00005C40
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
				\u0014\u0008\u0018.\u0018(this);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600012B RID: 299 RVA: 0x00007A68 File Offset: 0x00005C68
		// (set) Token: 0x0600012C RID: 300 RVA: 0x00007A7C File Offset: 0x00005C7C
		public ObservableCollection<IParameterInfo> AvailableParams
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

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600012D RID: 301 RVA: 0x00007A9C File Offset: 0x00005C9C
		// (set) Token: 0x0600012E RID: 302 RVA: 0x00007AB0 File Offset: 0x00005CB0
		public ObservableCollection<IParameterInfo> UsedParams
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

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600012F RID: 303 RVA: 0x00007AD0 File Offset: 0x00005CD0
		// (set) Token: 0x06000130 RID: 304 RVA: 0x00007AE4 File Offset: 0x00005CE4
		public IList<IParameterInfo> SelectedUsedParams
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

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000131 RID: 305 RVA: 0x00007B04 File Offset: 0x00005D04
		// (set) Token: 0x06000132 RID: 306 RVA: 0x00007B18 File Offset: 0x00005D18
		public IList<IParameterInfo> SelectedAvailableParams
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

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00007B38 File Offset: 0x00005D38
		// (set) Token: 0x06000134 RID: 308 RVA: 0x00007B4C File Offset: 0x00005D4C
		public string SelectionStatus
		{
			get
			{
				return this.\u000A\u0018;
			}
			set
			{
				this.\u000A\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectionStatus");
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00007B6C File Offset: 0x00005D6C
		public CommandBase AvailableToUsedCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.AvailableToUsed), new Predicate<object>(this.\u0010\u000D));
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00007B98 File Offset: 0x00005D98
		public CommandBase UsedToAvailableCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.UsedToAvailable), new Predicate<object>(this.\u0006\u000D));
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00007BC4 File Offset: 0x00005DC4
		public CommandBase MoveToTopCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0019\u000D), new Predicate<object>(this.\u0006\u000D));
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00007BF0 File Offset: 0x00005DF0
		public CommandBase MoveUpCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.MoveUp), new Predicate<object>(this.\u0006\u000D));
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000139 RID: 313 RVA: 0x00007C1C File Offset: 0x00005E1C
		public CommandBase MoveDownCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.MoveDown), new Predicate<object>(this.\u0006\u000D));
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00007C48 File Offset: 0x00005E48
		public CommandBase MoveToEndCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0007\u000D), new Predicate<object>(this.\u0006\u000D));
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600013B RID: 315 RVA: 0x00007C74 File Offset: 0x00005E74
		public CommandBase ReloadCommand
		{
			get
			{
				return \u0015\u0010\u0018.\u0018(new Action(this.\u0008\u000D), \u0013\u0004\u000F.\u000C);
			}
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00007C9C File Offset: 0x00005E9C
		protected virtual bool ParameterFilter(object obj)
		{
			IParameterInfo u000C = \u0019\u0004\u000F.\u000C(obj);
			if (!\u001F\u001A\u0018.\u0018(\u0003\u0008\u0018.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.ParameterFilter(object)).MethodHandle;
				}
				return \u001B\u0013\u0018.\u000C(\u0016\u0008\u0018.\u0018(u000C), \u0003\u0008\u0018.\u0018(this));
			}
			return true;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00007CF0 File Offset: 0x00005EF0
		[BindableMethod("UsedToAvailable")]
		public void UsedToAvailable()
		{
			if (\u000A\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.UsedToAvailable()).MethodHandle;
				}
				IEnumerator<IParameterInfo> enumerator = \u0009\u0008\u0018.\u0018(\u000A\u0008\u0018.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						IParameterInfo parameterInfo = \u0013\u0008\u0018.\u0018(enumerator);
						if (!\u001C\u0008\u0018.\u0018(parameterInfo))
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
							\u000D\u0008\u0018.\u0018(\u000C\u0008\u0018.\u0014(this), parameterInfo);
						}
						\u000F\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), parameterInfo);
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
			this.\u0001\u000D();
		}

		// Token: 0x0600013E RID: 318 RVA: 0x00007DAC File Offset: 0x00005FAC
		[BindableMethod("AvailableToUsed")]
		public void AvailableToUsed()
		{
			if (\u0020\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.AvailableToUsed()).MethodHandle;
				}
				IEnumerator<IParameterInfo> enumerator = \u0009\u0008\u0018.\u0018(\u0020\u0008\u0018.\u0018(this));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						IParameterInfo u = \u0013\u0008\u0018.\u0018(enumerator);
						\u000D\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), u);
						\u000F\u0008\u0018.\u0018(\u000C\u0008\u0018.\u0014(this), u);
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
			}
			this.\u0001\u000D();
		}

		// Token: 0x0600013F RID: 319 RVA: 0x00007E54 File Offset: 0x00006054
		private void \u0019\u000D()
		{
			if (\u000A\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0019\u000D()).MethodHandle;
				}
				object u000C = Enumerable.ToList<IParameterInfo>(Enumerable.OrderBy<IParameterInfo, int>(\u000A\u0008\u0018.\u0018(this), new Func<IParameterInfo, int>(\u0012\u0008\u0018.\u0014(this).IndexOf)));
				int num = 0;
				List<IParameterInfo>.Enumerator enumerator = \u001E\u0008\u0018.\u0018(u000C);
				try
				{
					while (\u001F\u0008\u0018.\u0018(ref enumerator))
					{
						IParameterInfo u = \u0017\u0008\u0018.\u0018(ref enumerator);
						\u0011\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), \u0015\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), u), num++);
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
					((IDisposable)enumerator).Dispose();
				}
			}
		}

		// Token: 0x06000140 RID: 320 RVA: 0x00007F18 File Offset: 0x00006118
		public void MoveUp()
		{
			if (\u000A\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.MoveUp()).MethodHandle;
				}
				List<IParameterInfo>.Enumerator enumerator = \u001E\u0008\u0018.\u0018(Enumerable.ToList<IParameterInfo>(Enumerable.OrderBy<IParameterInfo, int>(\u000A\u0008\u0018.\u0018(this), new Func<IParameterInfo, int>(\u0012\u0008\u0018.\u0014(this).IndexOf))));
				try
				{
					while (\u001F\u0008\u0018.\u0018(ref enumerator))
					{
						IParameterInfo u = \u0017\u0008\u0018.\u0018(ref enumerator);
						int num = \u0015\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), u);
						int num2 = num - 1;
						if (num2 < 0)
						{
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
						\u0011\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), num, num2);
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

		// Token: 0x06000141 RID: 321 RVA: 0x00007FEC File Offset: 0x000061EC
		public void MoveDown()
		{
			if (\u000A\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.MoveDown()).MethodHandle;
				}
				List<IParameterInfo>.Enumerator enumerator = \u001E\u0008\u0018.\u0018(Enumerable.ToList<IParameterInfo>(Enumerable.OrderByDescending<IParameterInfo, int>(\u000A\u0008\u0018.\u0018(this), new Func<IParameterInfo, int>(\u0012\u0008\u0018.\u0014(this).IndexOf))));
				try
				{
					while (\u001F\u0008\u0018.\u0018(ref enumerator))
					{
						IParameterInfo u = \u0017\u0008\u0018.\u0018(ref enumerator);
						int num = \u0015\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), u);
						int num2 = num + 1;
						if (num2 >= \u0002\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this)))
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
						\u0011\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), num, num2);
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

		// Token: 0x06000142 RID: 322 RVA: 0x000080CC File Offset: 0x000062CC
		private void \u0007\u000D()
		{
			if (\u000A\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0007\u000D()).MethodHandle;
				}
				object u000C = Enumerable.ToList<IParameterInfo>(Enumerable.OrderByDescending<IParameterInfo, int>(\u000A\u0008\u0018.\u0018(this), new Func<IParameterInfo, int>(\u0012\u0008\u0018.\u0014(this).IndexOf)));
				int num = \u0002\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this)) - 1;
				List<IParameterInfo>.Enumerator enumerator = \u001E\u0008\u0018.\u0018(u000C);
				try
				{
					while (\u001F\u0008\u0018.\u0018(ref enumerator))
					{
						IParameterInfo u = \u0017\u0008\u0018.\u0018(ref enumerator);
						\u0011\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), \u0015\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this), u), num--);
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
		}

		// Token: 0x06000143 RID: 323 RVA: 0x000081A0 File Offset: 0x000063A0
		private bool \u0010\u000D(object \u000C)
		{
			if (\u0020\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0010\u000D(object)).MethodHandle;
				}
				return \u0004\u0008\u0018.\u0018(\u0020\u0008\u0018.\u0018(this)) > 0;
			}
			return false;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x000081E0 File Offset: 0x000063E0
		private bool \u0006\u000D(object \u000C)
		{
			if (\u000A\u0008\u0018.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterBaseModel.\u0006\u000D(object)).MethodHandle;
				}
				return \u0004\u0008\u0018.\u0018(\u000A\u0008\u0018.\u0018(this)) > 0;
			}
			return false;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x00008220 File Offset: 0x00006420
		[BindableMethod("RefreshItems")]
		public void RefreshItems()
		{
			\u001D\u0008\u0018.\u0018(\u0010\u0006\u0018.\u0018(\u000C\u0008\u0018.\u0014(this)));
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00008244 File Offset: 0x00006444
		private void \u0008\u000D()
		{
			\u000B\u0008\u0018.\u0018(this, string.Empty);
			\u001A\u0008\u0018.\u0014(this);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00008264 File Offset: 0x00006464
		public virtual void Reload()
		{
			\u0010\u0008\u0018.\u0018(this, \u0006\u0008\u0018.\u0018(\u0008\u0008\u0018.\u0018(this)));
			\u0019\u0008\u0018.\u0018(this, \u0007\u0008\u0018.\u0018());
			\u0005\u0006\u0018.\u0018(\u0010\u0006\u0018.\u0018(\u000C\u0008\u0018.\u0014(this)), new Predicate<object>(this.ParameterFilter));
		}

		// Token: 0x06000148 RID: 328 RVA: 0x000082B4 File Offset: 0x000064B4
		private void \u0001\u000D()
		{
			\u0001\u0008\u0018.\u0018(this, \u001A\u001E\u0018.\u0018("Total:{0} | Selected:{1}", \u0002\u0008\u0018.\u0018(\u000C\u0008\u0018.\u0014(this)), \u0002\u0008\u0018.\u0018(\u0012\u0008\u0018.\u0014(this))));
		}

		// Token: 0x04000084 RID: 132
		private ObservableCollection<IParameterInfo> \u0012\u0018;

		// Token: 0x04000085 RID: 133
		private ObservableCollection<IParameterInfo> \u000D\u0018;

		// Token: 0x04000086 RID: 134
		private IList<IParameterInfo> \u001C\u0018;

		// Token: 0x04000087 RID: 135
		private IList<IParameterInfo> \u0013\u0018;

		// Token: 0x04000088 RID: 136
		private string \u0009\u0018;

		// Token: 0x04000089 RID: 137
		private string \u000A\u0018;

		// Token: 0x0400008A RID: 138
		[CompilerGenerated]
		private List<IParameterInfo> \u0020\u0018;
	}
}
