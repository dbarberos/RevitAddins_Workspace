using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using ProSheets.Enums;

namespace ProSheets.UI
{
	// Token: 0x02000092 RID: 146
	public class SettingUserControl : UserControl, IComponentConnector
	{
		// Token: 0x0600090C RID: 2316 RVA: 0x00038330 File Offset: 0x00036530
		public SettingUserControl()
		{
			\u0006\u0008\u0003.\u0018(this);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0003834C File Offset: 0x0003654C
		public void Init()
		{
			if (\u0005\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()) == TemporaryModeOption.Leave)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SettingUserControl.Init()).MethodHandle;
				}
				\u0007\u0018\u0003.\u0018(this.Q, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.P, new bool?(true));
			}
			if (\u001B\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()) == TemporaryModeOption.Leave)
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
				\u0007\u0018\u0003.\u0018(this.F, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.J, new bool?(true));
			}
			if (\u0001\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()) == TemporaryModeOption.Leave)
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
				\u0007\u0018\u0003.\u0018(this.N, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.H, new bool?(true));
			}
			if (\u0008\u0008\u0003.\u0018(\u000E\u000F\u0003.\u0018()) == TemporaryModeOption.Leave)
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
				\u0007\u0018\u0003.\u0018(this.M, new bool?(true));
				return;
			}
			\u0007\u0018\u0003.\u0018(this.Z, new bool?(true));
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00038460 File Offset: 0x00036660
		private void RdbButton_Click(object sender, RoutedEventArgs e)
		{
			object u000C = \u000E\u000F\u0003.\u0018();
			bool? flag = \u001B\u0001\u0018.\u0018(this.P);
			TemporaryModeOption u;
			if (!\u000C\u0007\u0018.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SettingUserControl.RdbButton_Click(object, RoutedEventArgs)).MethodHandle;
				}
				u = TemporaryModeOption.Leave;
			}
			else
			{
				u = TemporaryModeOption.TurnOff;
			}
			\u0014\u0001\u0003.\u0018(u000C, u);
			object u000C2 = \u000E\u000F\u0003.\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.J);
			TemporaryModeOption u2;
			if (!\u000C\u0007\u0018.\u0018(ref flag))
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
				u2 = TemporaryModeOption.Leave;
			}
			else
			{
				u2 = TemporaryModeOption.TurnOff;
			}
			\u0018\u0001\u0003.\u0018(u000C2, u2);
			object u000C3 = \u000E\u000F\u0003.\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.H);
			TemporaryModeOption u3;
			if (!\u000C\u0007\u0018.\u0018(ref flag))
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
				u3 = TemporaryModeOption.Leave;
			}
			else
			{
				u3 = TemporaryModeOption.TurnOff;
			}
			\u000C\u0001\u0003.\u0018(u000C3, u3);
			object u000C4 = \u000E\u000F\u0003.\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.Z);
			TemporaryModeOption u4;
			if (!\u000C\u0007\u0018.\u0018(ref flag))
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
				u4 = TemporaryModeOption.Leave;
			}
			else
			{
				u4 = TemporaryModeOption.TurnOff;
			}
			\u000E\u0008\u0003.\u0018(u000C4, u4);
			\u000F\u0003\u0003.\u0018();
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0003854C File Offset: 0x0003674C
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00038574 File Offset: 0x00036774
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.X)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SettingUserControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.X = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/usercontrols/settingusercontrol.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000385BC File Offset: 0x000367BC
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.Y(int P, object Q)
		{
			switch (P)
			{
			case 1:
				\u0018\u0019\u0018.\u0018(\u0002\u000B\u000F.\u000C(Q), new RoutedEventHandler(this.UserControl_Loaded));
				return;
			case 2:
				this.P = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.P, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 3:
				this.Q = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.Q, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 4:
				this.J = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.J, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 5:
				this.F = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.F, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 6:
				this.H = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.H, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 7:
				this.N = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.N, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 8:
				this.Z = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.Z, new RoutedEventHandler(this.RdbButton_Click));
				return;
			case 9:
				this.M = \u0001\u0004\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.M, new RoutedEventHandler(this.RdbButton_Click));
				return;
			default:
				this.X = true;
				return;
			}
		}

		// Token: 0x04000433 RID: 1075
		internal RadioButton P;

		// Token: 0x04000434 RID: 1076
		internal RadioButton Q;

		// Token: 0x04000435 RID: 1077
		internal RadioButton J;

		// Token: 0x04000436 RID: 1078
		internal RadioButton F;

		// Token: 0x04000437 RID: 1079
		internal RadioButton H;

		// Token: 0x04000438 RID: 1080
		internal RadioButton N;

		// Token: 0x04000439 RID: 1081
		internal RadioButton Z;

		// Token: 0x0400043A RID: 1082
		internal RadioButton M;

		// Token: 0x0400043B RID: 1083
		private bool X;
	}
}
