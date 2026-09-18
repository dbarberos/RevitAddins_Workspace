using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.SheetGen.UI.Windows
{
	// Token: 0x02000391 RID: 913
	public class NewSheetWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06002513 RID: 9491 RVA: 0x000E057C File Offset: 0x000DE77C
		public NewSheetWindow()
		{
			\u0015\u0009\u000B.\u000A(this);
			\u0005\u001B\u000A.\u0018.\u001D<\u001C\u0014>(this, new Action<\u001C\u0014>(this.PCR));
		}

		// Token: 0x06002514 RID: 9492 RVA: 0x000E05B0 File Offset: 0x000DE7B0
		private void PCR(\u001C\u0014 F)
		{
			\u0019\u000B\u0007.\u0007(this);
			\u0005\u001B\u000A.\u0018.\u0004<\u001C\u0014>(this);
		}

		// Token: 0x06002515 RID: 9493 RVA: 0x000E05D0 File Offset: 0x000DE7D0
		protected override void ApplyLicense(bool isLicenseValid)
		{
			if (\u000A\u0017\u0016.\u0007(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewSheetWindow.ApplyLicense(bool)).MethodHandle;
				}
				\u0015\u0009\u000A.\u000A(this.OW, isLicenseValid);
			}
		}

		// Token: 0x06002516 RID: 9494 RVA: 0x000E0608 File Offset: 0x000DE808
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NewSheetWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetgen/sheetgen/ui/windows/newsheetwindow.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x06002517 RID: 9495 RVA: 0x000E0650 File Offset: 0x000DE850
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		internal Delegate TDR(Type F, string R)
		{
			return \u0020\u0015\u000A.\u000A(F, this, R);
		}

		// Token: 0x06002518 RID: 9496 RVA: 0x000E0668 File Offset: 0x000DE868
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.OW = \u000C\u0015\u0010.\u001F(R);
				return;
			case 2:
				this.KR = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.FS = \u001E\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x04000EAA RID: 3754
		internal TabItem OW;

		// Token: 0x04000EAB RID: 3755
		internal TextBlock KR;

		// Token: 0x04000EAC RID: 3756
		internal Button FS;

		// Token: 0x04000EAD RID: 3757
		private bool R;
	}
}
