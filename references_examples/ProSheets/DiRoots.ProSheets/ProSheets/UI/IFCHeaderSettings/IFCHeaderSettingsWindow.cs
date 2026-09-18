using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using ProSheets.ViewModels;
using Revit.IFC.Common.Extensions;

namespace ProSheets.UI.IFCHeaderSettings
{
	// Token: 0x02000093 RID: 147
	public class IFCHeaderSettingsWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000912 RID: 2322 RVA: 0x0003874C File Offset: 0x0003694C
		public IFCHeaderSettingsWindow(IFCFileHeaderItem ifcHeaderSettings, bool hasSavedItem)
		{
			if (hasSavedItem)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCHeaderSettingsWindow..ctor(IFCFileHeaderItem, bool)).MethodHandle;
				}
				this.LR = \u0020\u0001\u0003.\u0018(this.UR);
			}
			this.IR = new IfcHeaderSettingsViewModel(ifcHeaderSettings);
			this.UR = \u000A\u0001\u0003.\u0018(this.IR);
			\u0009\u0001\u0003.\u0018(this.UR, \u001C\u0009\u0018.\u0006\u0016);
			\u0013\u0001\u0003.\u0018(this.UR, \u001C\u0009\u0018.\u0008\u0016);
			\u000D\u0001\u0003.\u0018(this.UR, \u001C\u0001\u0003.\u0018(\u0009\u0015\u0014.\u0018(\u0012\u0001\u0003.\u0018())));
			\u0016\u0001\u0003.\u0018(this.UR, \u000F\u0001\u0003.\u0018(\u0009\u0015\u0014.\u0018(\u0012\u0001\u0003.\u0018())));
			\u001C\u000B\u0018.\u0003(this, this.IR);
			\u0003\u0001\u0003.\u0018(this);
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00038840 File Offset: 0x00036A40
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (!\u001F\u0001\u0003.\u0018(this.UR, this.LR))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCHeaderSettingsWindow.Button_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0005\u0020\u0018.\u000F(new Action(this.QM));
			}
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0003888C File Offset: 0x00036A8C
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCHeaderSettingsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/ifcwindow/ifcheadersettings/ifcheadersettingswindow.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x000388D4 File Offset: 0x00036AD4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			if (P == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCHeaderSettingsWindow.CN(int, object)).MethodHandle;
				}
				\u000C\u0019\u0018.\u0018(\u000E\u0002\u000F.\u000C(Q), new RoutedEventHandler(this.Button_Click));
				return;
			}
			this.Q = true;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x0003891C File Offset: 0x00036B1C
		[CompilerGenerated]
		private void QM()
		{
			\u0011\u0001\u0003.\u0018(this.SR, \u0007\u0015\u0018.\u0003, this.UR);
		}

		// Token: 0x0400043C RID: 1084
		private readonly IfcHeaderSettingsViewModel IR;

		// Token: 0x0400043D RID: 1085
		private IFCFileHeader SR = new IFCFileHeader();

		// Token: 0x0400043E RID: 1086
		private IFCFileHeaderItem UR = new IFCFileHeaderItem();

		// Token: 0x0400043F RID: 1087
		private IFCFileHeaderItem LR = new IFCFileHeaderItem();

		// Token: 0x04000440 RID: 1088
		private bool Q;
	}
}
