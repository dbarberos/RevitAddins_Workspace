using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using ProSheets;

namespace DiRoots.ProSheets.UI.DiProfiles
{
	// Token: 0x02000047 RID: 71
	public class NewProfile : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060002D5 RID: 725 RVA: 0x000107AC File Offset: 0x0000E9AC
		public NewProfile()
		{
			\u000B\u0009\u0014.\u0018(this);
		}

		// Token: 0x14000009 RID: 9
		// (add) Token: 0x060002D6 RID: 726 RVA: 0x000107C8 File Offset: 0x0000E9C8
		// (remove) Token: 0x060002D7 RID: 727 RVA: 0x00010814 File Offset: 0x0000EA14
		public event NewProfile.TaskFinishedHandler TaskFinished
		{
			[CompilerGenerated]
			add
			{
				NewProfile.TaskFinishedHandler taskFinishedHandler = this.PJ;
				NewProfile.TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					NewProfile.TaskFinishedHandler value2 = (NewProfile.TaskFinishedHandler)\u001C\u0019\u0018.\u0018(taskFinishedHandler2, value);
					taskFinishedHandler = Interlocked.CompareExchange<NewProfile.TaskFinishedHandler>(ref this.PJ, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProfile.add_TaskFinished(NewProfile.TaskFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				NewProfile.TaskFinishedHandler taskFinishedHandler = this.PJ;
				NewProfile.TaskFinishedHandler taskFinishedHandler2;
				do
				{
					taskFinishedHandler2 = taskFinishedHandler;
					NewProfile.TaskFinishedHandler value2 = (NewProfile.TaskFinishedHandler)\u0013\u0019\u0018.\u0018(taskFinishedHandler2, value);
					taskFinishedHandler = Interlocked.CompareExchange<NewProfile.TaskFinishedHandler>(ref this.PJ, value2, taskFinishedHandler2);
				}
				while (taskFinishedHandler != taskFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProfile.remove_TaskFinished(NewProfile.TaskFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x00010860 File Offset: 0x0000EA60
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			this.FZ();
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x00010874 File Offset: 0x0000EA74
		private void txtProfileName_KeyUp(object sender, KeyEventArgs e)
		{
			if (\u001A\u000B\u0018.\u0018(e) == Key.Return)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProfile.txtProfileName_KeyUp(object, KeyEventArgs)).MethodHandle;
				}
				this.FZ();
			}
		}

		// Token: 0x060002DA RID: 730 RVA: 0x000108A8 File Offset: 0x0000EAA8
		private void FZ()
		{
			if (\u001F\u001A\u0018.\u0018(\u0001\u000B\u0018.\u0018(this.BJ)))
			{
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u0013\u0018);
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(NewProfile.FZ()).MethodHandle;
			}
			bool flag = false;
			List<Profile>.Enumerator enumerator = \u0001\u0009\u0014.\u0018(\u001B\u0009\u0014.\u0014(\u0005\u0009\u0014.\u0018()));
			try
			{
				while (\u0010\u0009\u0014.\u0018(ref enumerator))
				{
					if (\u001B\u0013\u0018.\u0018(\u0006\u0009\u0014.\u0018(\u0008\u0009\u0014.\u0018(ref enumerator)), \u0001\u000B\u0018.\u0018(this.BJ), true))
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
						flag = true;
						goto IL_A0;
					}
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
				((IDisposable)enumerator).Dispose();
			}
			IL_A0:
			if (!flag)
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
				NewProfile.TaskFinishedHandler pj = this.PJ;
				if (pj == null)
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
					\u0019\u0009\u0014.\u0018(pj, this, \u0001\u000B\u0018.\u0018(this.BJ), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QJ)), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.FJ)));
				}
				\u000B\u000B\u0018.\u0003(this);
				return;
			}
			\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u001C\u0018);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000109F4 File Offset: 0x0000EBF4
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewProfile.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/profile/newprofile.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00010A3C File Offset: 0x0000EC3C
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			switch (P)
			{
			case 1:
				this.BJ = \u0005\u0002\u000F.\u000C(Q);
				\u000E\u0009\u0014.\u0018(this.BJ, new KeyEventHandler(this.txtProfileName_KeyUp));
				return;
			case 2:
				this.QJ = \u0001\u0004\u000F.\u000C(Q);
				return;
			case 3:
				this.JJ = \u0001\u0004\u000F.\u000C(Q);
				return;
			case 4:
				this.FJ = \u0001\u0004\u000F.\u000C(Q);
				return;
			case 5:
				this.PB = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.PB, new RoutedEventHandler(this.btnCancel_Click));
				return;
			default:
				this.Q = true;
				return;
			}
		}

		// Token: 0x04000152 RID: 338
		[CompilerGenerated]
		private NewProfile.TaskFinishedHandler PJ;

		// Token: 0x04000153 RID: 339
		internal TextBox BJ;

		// Token: 0x04000154 RID: 340
		internal RadioButton QJ;

		// Token: 0x04000155 RID: 341
		internal RadioButton JJ;

		// Token: 0x04000156 RID: 342
		internal RadioButton FJ;

		// Token: 0x04000157 RID: 343
		internal Button PB;

		// Token: 0x04000158 RID: 344
		private bool Q;

		// Token: 0x02000169 RID: 361
		// (Invoke) Token: 0x06001080 RID: 4224
		public delegate void TaskFinishedHandler(NewProfile sender, string ChosenName, bool CopySettings, bool ImportFromFile);
	}
}
