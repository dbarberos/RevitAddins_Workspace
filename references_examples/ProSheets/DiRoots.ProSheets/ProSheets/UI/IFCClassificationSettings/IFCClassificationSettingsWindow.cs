using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.WindowControl;
using ProSheets.Models;
using ProSheets.ViewModels;

namespace ProSheets.UI.IFCClassificationSettings
{
	// Token: 0x02000094 RID: 148
	public class IFCClassificationSettingsWindow : DiRootsWindow, IComponentConnector
	{
		// Token: 0x06000917 RID: 2327 RVA: 0x00038944 File Offset: 0x00036B44
		public IFCClassificationSettingsWindow(Document document, IfcClassificationSettings ifcClassificationSettings, bool hasSavedItem)
		{
			this.ER = document;
			if (hasSavedItem)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCClassificationSettingsWindow..ctor(Document, IfcClassificationSettings, bool)).MethodHandle;
				}
				this.AR = \u001E\u0001\u0003.\u0018(ifcClassificationSettings);
			}
			this.VR = new IfcClassificationSettingsViewModel(ifcClassificationSettings);
			this.GR = \u0017\u0001\u0003.\u0018(this.VR);
			\u001C\u000B\u0018.\u0003(this, this.VR);
			\u0015\u0001\u0003.\u0018(this);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x000389CC File Offset: 0x00036BCC
		private void Button_OK_Click(object sender, RoutedEventArgs e)
		{
			if (!\u0004\u0001\u0003.\u0018(this.GR, this.AR))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCClassificationSettingsWindow.Button_OK_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (!\u0002\u0001\u0003.\u0018(this.GR))
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
					this.JM(this.GR);
				}
				\u0005\u0020\u0018.\u000F(new Action(this.FM));
			}
			\u000B\u000B\u0018.\u0003(this);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00038A40 File Offset: 0x00036C40
		private void JM(IfcClassificationSettings P)
		{
			if (\u001F\u000B\u0018.\u0018(\u0010\u0001\u0003.\u0014(P)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCClassificationSettingsWindow.JM(IfcClassificationSettings)).MethodHandle;
				}
				\u0007\u0001\u0003.\u0014(P, "");
			}
			if (\u001F\u000B\u0018.\u0018(\u0019\u0001\u0003.\u0014(P)))
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
				\u000B\u0001\u0003.\u0014(P, "");
			}
			if (\u001F\u000B\u0018.\u0018(\u001A\u0001\u0003.\u0014(P)))
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
				\u001D\u0001\u0003.\u0014(P, "");
			}
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00038AC8 File Offset: 0x00036CC8
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.Q)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IFCClassificationSettingsWindow.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.Q = true;
			Uri u = \u0005\u000B\u0018.\u0018("/DiRoots.ProSheets;V2.1.2.0;component/ui/ifcwindow/ifcclassificationsettings/ifcclassificationsettingswindow.xaml", UriKind.Relative);
			\u001B\u000B\u0018.\u0018(this, u);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00038B10 File Offset: 0x00036D10
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		void IComponentConnector.CN(int P, object Q)
		{
			if (P == 1)
			{
				this.DR = \u0020\u0007\u000F.\u000C(Q);
				return;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(IFCClassificationSettingsWindow.CN(int, object)).MethodHandle;
			}
			if (P != 2)
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
				this.Q = true;
				return;
			}
			\u000C\u0019\u0018.\u0018(\u000E\u0002\u000F.\u000C(Q), new RoutedEventHandler(this.Button_OK_Click));
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00038B74 File Offset: 0x00036D74
		[CompilerGenerated]
		private void FM()
		{
			\u0006\u0001\u0003.\u0018(this.ER, this.GR);
		}

		// Token: 0x04000441 RID: 1089
		private readonly Document ER;

		// Token: 0x04000442 RID: 1090
		private readonly IfcClassificationSettings GR = new IfcClassificationSettings();

		// Token: 0x04000443 RID: 1091
		private readonly IfcClassificationSettings AR = new IfcClassificationSettings();

		// Token: 0x04000444 RID: 1092
		private readonly IfcClassificationSettingsViewModel VR;

		// Token: 0x04000445 RID: 1093
		internal DatePicker DR;

		// Token: 0x04000446 RID: 1094
		private bool Q;
	}
}
