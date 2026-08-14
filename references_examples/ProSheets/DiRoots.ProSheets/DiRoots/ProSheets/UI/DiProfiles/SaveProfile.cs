using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.ProSheets.UI.DiProfiles
{
	// Token: 0x0200004A RID: 74
	public class SaveProfile : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x00011ED8 File Offset: 0x000100D8
		public SaveProfile(string profile_name)
		{
			\u001F\u0020\u0014.\u0018(this);
			this.RJ = profile_name;
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x060002F5 RID: 757 RVA: 0x00011EF8 File Offset: 0x000100F8
		// (remove) Token: 0x060002F6 RID: 758 RVA: 0x00011F44 File Offset: 0x00010144
		public event SaveProfile.SaveProfileEventHandler SaveProfileEvent
		{
			[CompilerGenerated]
			add
			{
				SaveProfile.SaveProfileEventHandler saveProfileEventHandler = this.HJ;
				SaveProfile.SaveProfileEventHandler saveProfileEventHandler2;
				do
				{
					saveProfileEventHandler2 = saveProfileEventHandler;
					SaveProfile.SaveProfileEventHandler value2 = (SaveProfile.SaveProfileEventHandler)\u001C\u0019\u0018.\u0018(saveProfileEventHandler2, value);
					saveProfileEventHandler = Interlocked.CompareExchange<SaveProfile.SaveProfileEventHandler>(ref this.HJ, value2, saveProfileEventHandler2);
				}
				while (saveProfileEventHandler != saveProfileEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SaveProfile.add_SaveProfileEvent(SaveProfile.SaveProfileEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				SaveProfile.SaveProfileEventHandler saveProfileEventHandler = this.HJ;
				SaveProfile.SaveProfileEventHandler saveProfileEventHandler2;
				do
				{
					saveProfileEventHandler2 = saveProfileEventHandler;
					SaveProfile.SaveProfileEventHandler value2 = (SaveProfile.SaveProfileEventHandler)\u0013\u0019\u0018.\u0018(saveProfileEventHandler2, value);
					saveProfileEventHandler = Interlocked.CompareExchange<SaveProfile.SaveProfileEventHandler>(ref this.HJ, value2, saveProfileEventHandler2);
				}
				while (saveProfileEventHandler != saveProfileEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SaveProfile.remove_SaveProfileEvent(SaveProfile.SaveProfileEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00011F90 File Offset: 0x00010190
		private void btnSave_Click(object sender, RoutedEventArgs e)
		{
			SaveProfile.SaveProfileEventHandler hj = this.HJ;
			if (hj == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SaveProfile.btnSave_Click(object, RoutedEventArgs)).MethodHandle;
				}
			}
			else
			{
				\u0011\u0020\u0014.\u0018(hj, this, this.RJ, false);
			}
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00011FD0 File Offset: 0x000101D0
		private void btnSaveAs_Click(object sender, RoutedEventArgs e)
		{
			SaveProfile.SaveProfileEventHandler hj = this.HJ;
			if (hj == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SaveProfile.btnSaveAs_Click(object, RoutedEventArgs)).MethodHandle;
				}
			}
			else
			{
				\u0011\u0020\u0014.\u0018(hj, this, this.RJ, true);
			}
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00012010 File Offset: 0x00010210
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SaveProfile.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/profile/saveprofile.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00012058 File Offset: 0x00010258
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.CN(int P, object Q)
		{
			if (P == 1)
			{
				this.NJ = \u000E\u0002\u000F.\u000C(Q);
				\u000C\u0019\u0018.\u0018(this.NJ, new RoutedEventHandler(this.btnSaveAs_Click));
				return;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(SaveProfile.CN(int, object)).MethodHandle;
			}
			if (P != 2)
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
				this.Q = true;
				return;
			}
			this.ZJ = \u000E\u0002\u000F.\u000C(Q);
			\u000C\u0019\u0018.\u0018(this.ZJ, new RoutedEventHandler(this.btnSave_Click));
		}

		// Token: 0x04000161 RID: 353
		private readonly string RJ;

		// Token: 0x04000162 RID: 354
		[CompilerGenerated]
		private SaveProfile.SaveProfileEventHandler HJ;

		// Token: 0x04000163 RID: 355
		internal Button NJ;

		// Token: 0x04000164 RID: 356
		internal Button ZJ;

		// Token: 0x04000165 RID: 357
		private bool Q;

		// Token: 0x0200016D RID: 365
		// (Invoke) Token: 0x0600108F RID: 4239
		public delegate void SaveProfileEventHandler(SaveProfile sender, string profile_name, bool saveAs);
	}
}
