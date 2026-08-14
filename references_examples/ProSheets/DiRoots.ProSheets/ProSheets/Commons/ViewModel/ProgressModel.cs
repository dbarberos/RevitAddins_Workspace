using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using A;
using DiRoots.One.Commons.ViewModels;

namespace ProSheets.Commons.ViewModel
{
	// Token: 0x02000137 RID: 311
	public class ProgressModel : ViewModelBase
	{
		// Token: 0x06000F81 RID: 3969 RVA: 0x00058268 File Offset: 0x00056468
		public ProgressModel()
		{
			\u0016\u001C\u000F.\u0018(this, new Action<int>(this.ShowProgress));
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x06000F82 RID: 3970 RVA: 0x000582B4 File Offset: 0x000564B4
		// (set) Token: 0x06000F83 RID: 3971 RVA: 0x000582C8 File Offset: 0x000564C8
		public Delegate ProgressChanged { get; set; }

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x06000F84 RID: 3972 RVA: 0x000582DC File Offset: 0x000564DC
		// (set) Token: 0x06000F85 RID: 3973 RVA: 0x000582F0 File Offset: 0x000564F0
		public Delegate TaskFinished { get; set; }

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x06000F86 RID: 3974 RVA: 0x00058304 File Offset: 0x00056504
		// (set) Token: 0x06000F87 RID: 3975 RVA: 0x00058318 File Offset: 0x00056518
		public double Minimum
		{
			get
			{
				return this.\u0002\u0012;
			}
			set
			{
				this.\u0002\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "Minimum");
			}
		}

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x06000F88 RID: 3976 RVA: 0x00058338 File Offset: 0x00056538
		// (set) Token: 0x06000F89 RID: 3977 RVA: 0x0005834C File Offset: 0x0005654C
		public double Maximum
		{
			get
			{
				return this.\u0004\u0012;
			}
			set
			{
				this.\u0004\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "Maximum");
			}
		}

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0005836C File Offset: 0x0005656C
		// (set) Token: 0x06000F8B RID: 3979 RVA: 0x00058380 File Offset: 0x00056580
		public double ProgressValue
		{
			get
			{
				return this.\u001E\u0012;
			}
			set
			{
				this.\u001E\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "ProgressValue");
			}
		}

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x06000F8C RID: 3980 RVA: 0x000583A0 File Offset: 0x000565A0
		// (set) Token: 0x06000F8D RID: 3981 RVA: 0x000583B4 File Offset: 0x000565B4
		public string ProgressText
		{
			get
			{
				return this.\u001A\u0012;
			}
			set
			{
				this.\u001A\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "ProgressText");
			}
		}

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x06000F8E RID: 3982 RVA: 0x000583D4 File Offset: 0x000565D4
		// (set) Token: 0x06000F8F RID: 3983 RVA: 0x000583E8 File Offset: 0x000565E8
		public string ProgressStatus
		{
			get
			{
				return this.\u001D\u0012;
			}
			set
			{
				this.\u001D\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "ProgressStatus");
			}
		}

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x06000F90 RID: 3984 RVA: 0x00058408 File Offset: 0x00056608
		// (set) Token: 0x06000F91 RID: 3985 RVA: 0x0005841C File Offset: 0x0005661C
		public string TotalStatus
		{
			get
			{
				return this.\u000B\u0012;
			}
			set
			{
				this.\u000B\u0012 = value;
				\u0011\u0010\u0018.\u0018(this, "TotalStatus");
			}
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x06000F92 RID: 3986 RVA: 0x0005843C File Offset: 0x0005663C
		// (set) Token: 0x06000F93 RID: 3987 RVA: 0x00058450 File Offset: 0x00056650
		public bool IsIndeterminate { get; set; }

		// Token: 0x1700055A RID: 1370
		// (get) Token: 0x06000F94 RID: 3988 RVA: 0x00058464 File Offset: 0x00056664
		// (set) Token: 0x06000F95 RID: 3989 RVA: 0x00058478 File Offset: 0x00056678
		public ContentControl ActiveControl { get; set; }

		// Token: 0x06000F96 RID: 3990 RVA: 0x0005848C File Offset: 0x0005668C
		public virtual void RunProcess()
		{
		}

		// Token: 0x06000F97 RID: 3991 RVA: 0x0005849C File Offset: 0x0005669C
		public void SetWindow(Window window)
		{
			\u000B\u0005\u0018.\u0003(this, window);
		}

		// Token: 0x06000F98 RID: 3992 RVA: 0x000584B0 File Offset: 0x000566B0
		public void ShowProgress(int percent)
		{
			\u0012\u001C\u000F.\u0018(this, percent, DispatcherPriority.Background);
		}

		// Token: 0x06000F99 RID: 3993 RVA: 0x000584C8 File Offset: 0x000566C8
		public void ShowProgress(int percent, DispatcherPriority priority)
		{
			\u000A\u001C\u000F.\u0018(this, (double)percent);
			\u001C\u001C\u000F.\u0018(this, \u001C\u001E\u0018.\u0018("{0:0}%", \u0009\u001C\u000F.\u0018(this) * 100.0 / \u0013\u001C\u000F.\u0018(this)));
			\u000D\u001C\u000F.\u0018(this);
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x00058518 File Offset: 0x00056718
		public void Reset()
		{
			\u000A\u001C\u000F.\u0018(this, 0.0);
			\u0015\u001C\u000F.\u0018(this, 0.0);
			\u0011\u001C\u000F.\u0018(this, 100.0);
			\u001C\u001C\u000F.\u0018(this, "0%");
			\u001F\u001C\u000F.\u0018(this, "Completed ");
			ContentControl contentControl = \u0020\u001C\u000F.\u0018(this);
			if (contentControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressModel.Reset()).MethodHandle;
				}
				return;
			}
			object u000C = \u0005\u0014\u0003.\u0014(contentControl);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = ProgressModel.<>c.\u0018) == null)
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
				u2 = (ProgressModel.<>c.\u0018 = new Action(ProgressModel.<>c.\u000C.\u0016));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x000585C4 File Offset: 0x000567C4
		public void Reset(int maxCount, string progressText)
		{
			\u000A\u001C\u000F.\u0018(this, 0.0);
			\u0015\u001C\u000F.\u0018(this, 0.0);
			\u0011\u001C\u000F.\u0018(this, (double)maxCount);
			\u001F\u001C\u000F.\u0018(this, progressText);
			\u001C\u001C\u000F.\u0018(this, "0%");
			ContentControl contentControl = \u0020\u001C\u000F.\u0018(this);
			if (contentControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressModel.Reset(int, string)).MethodHandle;
				}
				return;
			}
			object u000C = \u0005\u0014\u0003.\u0014(contentControl);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = ProgressModel.<>c.\u0014) == null)
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
				u2 = (ProgressModel.<>c.\u0014 = new Action(ProgressModel.<>c.\u000C.\u000F));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x00058664 File Offset: 0x00056864
		public void UpdateProgress(string progressText)
		{
			\u001F\u001C\u000F.\u0018(this, progressText);
			\u000D\u001C\u000F.\u0018(this);
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x00058680 File Offset: 0x00056880
		public static int GetProgressRefreshIntervel(int total)
		{
			if (total / 10 != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressModel.GetProgressRefreshIntervel(int)).MethodHandle;
				}
				return total / 10;
			}
			return 1;
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x000586AC File Offset: 0x000568AC
		public void TaskMethod()
		{
			\u000A\u001C\u000F.\u0018(this, 0.0);
			\u001C\u001C\u000F.\u0018(this, "0%");
			\u000D\u001C\u000F.\u0018(this);
			if (\u0001\u000C\u0014.\u0018(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressModel.TaskMethod()).MethodHandle;
				}
				\u0007\u000B\u0018.\u0003(\u0001\u000C\u0014.\u0018(this), new bool?(true));
				\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
				\u000B\u0005\u0018.\u0003(this, \u0017\u0008\u000F.\u000C);
			}
		}

		// Token: 0x06000F9F RID: 3999 RVA: 0x00058724 File Offset: 0x00056924
		public void TaskMethodModeless()
		{
			\u000A\u001C\u000F.\u0018(this, 0.0);
			\u001C\u001C\u000F.\u0018(this, "0%");
			\u000D\u001C\u000F.\u0018(this);
			\u000B\u000B\u0018.\u0014(\u0001\u000C\u0014.\u0018(this));
		}

		// Token: 0x06000FA0 RID: 4000 RVA: 0x00058760 File Offset: 0x00056960
		public void Refresh()
		{
			ContentControl contentControl = \u0020\u001C\u000F.\u0018(this);
			if (contentControl == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ProgressModel.Refresh()).MethodHandle;
				}
				return;
			}
			object u000C = \u0005\u0014\u0003.\u0014(contentControl);
			DispatcherPriority u = DispatcherPriority.Background;
			Action u2;
			if ((u2 = ProgressModel.<>c.\u0003) == null)
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
				u2 = (ProgressModel.<>c.\u0003 = new Action(ProgressModel.<>c.\u000C.\u0012));
			}
			\u001B\u0014\u0003.\u0018(u000C, u, u2);
		}

		// Token: 0x040006F1 RID: 1777
		[CompilerGenerated]
		private Delegate \u0015\u0012;

		// Token: 0x040006F2 RID: 1778
		[CompilerGenerated]
		private Delegate \u0017\u0012;

		// Token: 0x040006F3 RID: 1779
		private double \u001E\u0012;

		// Token: 0x040006F4 RID: 1780
		private double \u0002\u0012;

		// Token: 0x040006F5 RID: 1781
		private double \u0004\u0012 = 100.0;

		// Token: 0x040006F6 RID: 1782
		private string \u001D\u0012 = "0%";

		// Token: 0x040006F7 RID: 1783
		private string \u001A\u0012 = \u000F\u001C\u000F.\u0018();

		// Token: 0x040006F8 RID: 1784
		private string \u000B\u0012;

		// Token: 0x040006F9 RID: 1785
		[CompilerGenerated]
		private bool \u0019\u0012;

		// Token: 0x040006FA RID: 1786
		[CompilerGenerated]
		private ContentControl \u0007\u0012;
	}
}
