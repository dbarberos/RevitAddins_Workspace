using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Extensions;

namespace ProSheets.DrawingRegister.Helpers
{
	// Token: 0x02000126 RID: 294
	public class DataGridOrderChange<T> : ViewModelBase where T : class
	{
		// Token: 0x06000F10 RID: 3856 RVA: 0x000556FC File Offset: 0x000538FC
		public DataGridOrderChange()
		{
			this.ReloadCmd = new CommandBase(new Action(this.Reload), new Predicate<object>(this.CanReloadCmd));
			this.MoveUpCmd = new CommandBase(new Action(this.MoveUp), new Predicate<object>(this.CanMoveParameterCmd));
			this.MoveDownCmd = new CommandBase(new Action(this.MoveDown), new Predicate<object>(this.CanMoveParameterCmd));
			this.MoveTopCmd = new CommandBase(new Action(this.MoveTop), new Predicate<object>(this.CanMoveParameterCmd));
			this.MoveBottomCmd = new CommandBase(new Action(this.MoveBottom), new Predicate<object>(this.CanMoveParameterCmd));
			this.MoveBackCmd = new CommandBase(new Action(this.MoveBack), new Predicate<object>(this.CanMoveParameterCmd));
			this.MoveForwardCmd = new CommandBase(new Action(this.MoveForward), new Predicate<object>(this.CanMoveForwardCmd));
			this.ElementSelectComponents = new ObservableCollection<T>();
			this.SelectElementSelectComponents = new ObservableCollection<T>();
			this.SelectElementAvailableComponents = new ObservableCollection<T>();
			this.ElementAvailableComponents = new ObservableCollection<T>();
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000F11 RID: 3857 RVA: 0x00055830 File Offset: 0x00053A30
		// (set) Token: 0x06000F12 RID: 3858 RVA: 0x00055844 File Offset: 0x00053A44
		public ObservableCollection<T> ElementAvailableComponents
		{
			get
			{
				return this.\u0003\u0012;
			}
			set
			{
				this.\u0003\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "ElementAvailableComponents");
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000F13 RID: 3859 RVA: 0x00055864 File Offset: 0x00053A64
		// (set) Token: 0x06000F14 RID: 3860 RVA: 0x00055878 File Offset: 0x00053A78
		public ObservableCollection<T> SelectElementAvailableComponents
		{
			get
			{
				return this.\u0016\u0012;
			}
			set
			{
				this.\u0016\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectElementAvailableComponents");
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000F15 RID: 3861 RVA: 0x00055898 File Offset: 0x00053A98
		// (set) Token: 0x06000F16 RID: 3862 RVA: 0x000558AC File Offset: 0x00053AAC
		public ObservableCollection<T> ElementSelectComponents
		{
			get
			{
				return this.\u0018\u0012;
			}
			set
			{
				this.\u0018\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "ElementSelectComponents");
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000F17 RID: 3863 RVA: 0x000558CC File Offset: 0x00053ACC
		// (set) Token: 0x06000F18 RID: 3864 RVA: 0x000558E0 File Offset: 0x00053AE0
		public ObservableCollection<T> SelectElementSelectComponents
		{
			get
			{
				return this.\u0014\u0012;
			}
			set
			{
				this.\u0014\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectElementSelectComponents");
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000F19 RID: 3865 RVA: 0x00055900 File Offset: 0x00053B00
		// (set) Token: 0x06000F1A RID: 3866 RVA: 0x00055914 File Offset: 0x00053B14
		public Action OnCommandFinished { get; set; }

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x00055928 File Offset: 0x00053B28
		// (set) Token: 0x06000F1C RID: 3868 RVA: 0x0005593C File Offset: 0x00053B3C
		public ICommand MoveBackCmd { get; set; }

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x00055950 File Offset: 0x00053B50
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x00055964 File Offset: 0x00053B64
		public ICommand MoveForwardCmd { get; set; }

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06000F1F RID: 3871 RVA: 0x00055978 File Offset: 0x00053B78
		// (set) Token: 0x06000F20 RID: 3872 RVA: 0x0005598C File Offset: 0x00053B8C
		public ICommand MoveUpCmd { get; set; }

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x000559A0 File Offset: 0x00053BA0
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x000559B4 File Offset: 0x00053BB4
		public ICommand MoveDownCmd { get; set; }

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x000559C8 File Offset: 0x00053BC8
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x000559DC File Offset: 0x00053BDC
		public ICommand MoveTopCmd { get; set; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06000F25 RID: 3877 RVA: 0x000559F0 File Offset: 0x00053BF0
		// (set) Token: 0x06000F26 RID: 3878 RVA: 0x00055A04 File Offset: 0x00053C04
		public ICommand MoveBottomCmd { get; set; }

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06000F27 RID: 3879 RVA: 0x00055A18 File Offset: 0x00053C18
		// (set) Token: 0x06000F28 RID: 3880 RVA: 0x00055A2C File Offset: 0x00053C2C
		public ICommand ReloadCmd { get; set; }

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x06000F29 RID: 3881 RVA: 0x00055A40 File Offset: 0x00053C40
		// (set) Token: 0x06000F2A RID: 3882 RVA: 0x00055A54 File Offset: 0x00053C54
		public ICommand RefreshCmds { get; set; }

		// Token: 0x06000F2B RID: 3883 RVA: 0x00055A68 File Offset: 0x00053C68
		public void Reload()
		{
			using (List<T>.Enumerator enumerator = Enumerable.ToList<T>(this.ElementSelectComponents).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T item = enumerator.Current;
					this.ElementAvailableComponents.Add(item);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.Reload()).MethodHandle;
				}
			}
			this.ElementSelectComponents.Clear();
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x00055AF4 File Offset: 0x00053CF4
		[BindableMethod("MoveBack")]
		public void MoveBack()
		{
			if (this.SelectElementSelectComponents != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.MoveBack()).MethodHandle;
				}
				if (Enumerable.Any<T>(this.SelectElementSelectComponents))
				{
					IEnumerator<T> enumerator = this.SelectElementSelectComponents.GetEnumerator();
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							T item = enumerator.Current;
							this.ElementSelectComponents.Remove(item);
							this.ElementAvailableComponents.Add(item);
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

		// Token: 0x06000F2D RID: 3885 RVA: 0x00055BB0 File Offset: 0x00053DB0
		[BindableMethod("MoveForward")]
		public void MoveForward()
		{
			if (this.SelectElementAvailableComponents != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.MoveForward()).MethodHandle;
				}
				if (Enumerable.Any<T>(this.SelectElementAvailableComponents))
				{
					IEnumerator<T> enumerator = this.SelectElementAvailableComponents.GetEnumerator();
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							T item = enumerator.Current;
							this.ElementSelectComponents.Add(item);
							this.ElementAvailableComponents.Remove(item);
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
							\u0020\u001E\u0018.\u0018(enumerator);
						}
					}
					return;
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
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x00055C6C File Offset: 0x00053E6C
		public bool CanMoveForwardCmd(object obj)
		{
			return Enumerable.Any<T>(this.SelectElementAvailableComponents);
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x00055C88 File Offset: 0x00053E88
		public bool CanReloadCmd(object obj)
		{
			return Enumerable.Any<T>(this.ElementSelectComponents);
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x00055CA4 File Offset: 0x00053EA4
		public void MoveTop()
		{
			if (this.SelectElementSelectComponents != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.MoveTop()).MethodHandle;
				}
				if (!Enumerable.Any<T>(this.SelectElementSelectComponents))
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
					IEnumerable<T> enumerable = Enumerable.Except<T>(this.ElementSelectComponents, this.SelectElementSelectComponents);
					this.ElementSelectComponents = new ObservableCollection<T>(this.SelectElementSelectComponents);
					IEnumerator<T> enumerator = enumerable.GetEnumerator();
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							T item = enumerator.Current;
							this.ElementSelectComponents.Add(item);
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
					Action onCommandFinished = this.OnCommandFinished;
					if (onCommandFinished == null)
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
						return;
					}
					\u000D\u0005\u0003.\u0018(onCommandFinished);
					return;
				}
			}
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x00055D8C File Offset: 0x00053F8C
		public void MoveBottom()
		{
			if (this.SelectElementSelectComponents != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.MoveBottom()).MethodHandle;
				}
				if (!Enumerable.Any<T>(this.SelectElementSelectComponents))
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
					IEnumerator<T> enumerator = this.SelectElementSelectComponents.GetEnumerator();
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							T item = enumerator.Current;
							int num = this.ElementSelectComponents.IndexOf(item);
							if (num >= 0)
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
								if (num < this.ElementSelectComponents.Count - 1)
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
									this.ElementSelectComponents.Move(num, this.ElementSelectComponents.Count - 1);
								}
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
					Action onCommandFinished = this.OnCommandFinished;
					if (onCommandFinished == null)
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
					\u000D\u0005\u0003.\u0018(onCommandFinished);
					return;
				}
			}
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x00055EA0 File Offset: 0x000540A0
		public void MoveUp()
		{
			if (this.SelectElementSelectComponents != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.MoveUp()).MethodHandle;
				}
				if (!Enumerable.Any<T>(this.SelectElementSelectComponents))
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
				}
				else
				{
					int count = this.SelectElementSelectComponents.Count;
					int num = this.ElementSelectComponents.IndexOf(this.SelectElementSelectComponents[0]);
					IEnumerator<T> enumerator = this.SelectElementSelectComponents.GetEnumerator();
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							T item = enumerator.Current;
							int num2 = this.ElementSelectComponents.IndexOf(item);
							if (num2 < num)
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
								num = num2;
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
					if (num > 0)
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
						T item2 = this.ElementSelectComponents[num - 1];
						this.ElementSelectComponents.RemoveAt(num - 1);
						this.ElementSelectComponents.Insert(num - 1 + count, item2);
					}
					Action onCommandFinished = this.OnCommandFinished;
					if (onCommandFinished == null)
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
						return;
					}
					\u000D\u0005\u0003.\u0018(onCommandFinished);
					return;
				}
			}
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x00055FF4 File Offset: 0x000541F4
		public void MoveDown()
		{
			if (this.SelectElementSelectComponents != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataGridOrderChange.MoveDown()).MethodHandle;
				}
				if (!Enumerable.Any<T>(this.SelectElementSelectComponents))
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
				}
				else
				{
					int count = this.SelectElementSelectComponents.Count;
					int num = this.ElementSelectComponents.IndexOf(this.SelectElementSelectComponents[0]);
					IEnumerator<T> enumerator = this.SelectElementSelectComponents.GetEnumerator();
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							T item = enumerator.Current;
							int num2 = this.ElementSelectComponents.IndexOf(item);
							if (num2 > num)
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
								num = num2;
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
					if (num < this.ElementSelectComponents.Count - 1)
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
						T item2 = this.ElementSelectComponents[num + 1];
						this.ElementSelectComponents.RemoveAt(num + 1);
						this.ElementSelectComponents.Insert(num + 1 - count, item2);
					}
					Action onCommandFinished = this.OnCommandFinished;
					if (onCommandFinished == null)
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
					\u000D\u0005\u0003.\u0018(onCommandFinished);
					return;
				}
			}
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x00056158 File Offset: 0x00054358
		public bool CanMoveParameterCmd(object obj)
		{
			return Enumerable.Any<T>(this.SelectElementSelectComponents);
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x00056174 File Offset: 0x00054374
		public bool CanRefreshParameterCmd(object obj)
		{
			return Enumerable.Any<T>(this.ElementSelectComponents);
		}

		// Token: 0x040006C6 RID: 1734
		private ObservableCollection<T> \u0018\u0012;

		// Token: 0x040006C7 RID: 1735
		private ObservableCollection<T> \u0014\u0012;

		// Token: 0x040006C8 RID: 1736
		private ObservableCollection<T> \u0003\u0012;

		// Token: 0x040006C9 RID: 1737
		private ObservableCollection<T> \u0016\u0012;

		// Token: 0x040006CA RID: 1738
		[CompilerGenerated]
		private Action \u000F\u0012;

		// Token: 0x040006CB RID: 1739
		[CompilerGenerated]
		private ICommand \u0012\u0012;

		// Token: 0x040006CC RID: 1740
		[CompilerGenerated]
		private ICommand \u000D\u0012;

		// Token: 0x040006CD RID: 1741
		[CompilerGenerated]
		private ICommand \u001C\u0012;

		// Token: 0x040006CE RID: 1742
		[CompilerGenerated]
		private ICommand \u0013\u0012;

		// Token: 0x040006CF RID: 1743
		[CompilerGenerated]
		private ICommand \u0009\u0012;

		// Token: 0x040006D0 RID: 1744
		[CompilerGenerated]
		private ICommand \u000A\u0012;

		// Token: 0x040006D1 RID: 1745
		[CompilerGenerated]
		private ICommand \u0020\u0012;

		// Token: 0x040006D2 RID: 1746
		[CompilerGenerated]
		private ICommand \u001F\u0012;
	}
}
