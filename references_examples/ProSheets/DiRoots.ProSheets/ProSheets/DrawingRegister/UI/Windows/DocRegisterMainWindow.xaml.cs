using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.ProfileControl;
using DiRoots.ProfileControl.UI;
using ProSheets.DrawingRegister.UI.Controls;
using ProSheets.DrawingRegister.ViewModels;

namespace ProSheets.DrawingRegister.UI.Windows
{
	// Token: 0x0200010E RID: 270
	public partial class DocRegisterMainWindow : DiRootsWindow
	{
		// Token: 0x06000E08 RID: 3592 RVA: 0x00052800 File Offset: 0x00050A00
		public DocRegisterMainWindow()
		{
			\u000F\u0003\u000F.\u0018(this, \u0002\u0002\u0016.\u0018());
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\UI\\Windows\\DocRegisterMainWindow.xaml.cs", ".ctor");
			DocRegisterViewModel docRegisterViewModel = new DocRegisterViewModel();
			\u000B\u0005\u0018.\u0014(docRegisterViewModel, this);
			this.IH = docRegisterViewModel;
			\u0016\u0003\u000F.\u0018(this);
			\u000B\u0005\u0018.\u0014(\u0011\u001A\u0016.\u0003(this.IH), this);
			\u000B\u0005\u0018.\u0014(\u000A\u001A\u0016.\u0003(this.IH), this);
			\u001C\u000B\u0018.\u0003(this, this.IH);
			\u0016\u001E\u0014.\u0018(\u001C\u000B\u0016.\u0003(this.IH), this);
			\u0006\u0018\u0003.\u0018(this, "DocRegister");
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\UI\\Windows\\DocRegisterMainWindow.xaml.cs", ".ctor");
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000E09 RID: 3593 RVA: 0x000528B4 File Offset: 0x00050AB4
		// (set) Token: 0x06000E0A RID: 3594 RVA: 0x000528C8 File Offset: 0x00050AC8
		public static DocRegisterMainWindow CurrentDocRegisterWindow { get; set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000E0B RID: 3595 RVA: 0x000528DC File Offset: 0x00050ADC
		// (set) Token: 0x06000E0C RID: 3596 RVA: 0x000528F0 File Offset: 0x00050AF0
		public static string ProfileName { get; set; }

		// Token: 0x06000E0D RID: 3597 RVA: 0x00052904 File Offset: 0x00050B04
		private void MainDocRegisterWindowClosed(object sender, EventArgs e)
		{
			\u0013\u001D\u0016.\u0018(\u0010\u0006\u000F.\u000C);
			if (\u000C\u001A\u0018.\u0018(\u001F\u001B\u0016.\u0018()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterMainWindow.MainDocRegisterWindowClosed(object, EventArgs)).MethodHandle;
				}
				\u000C\u0020\u0014.\u0018(\u001F\u001B\u0016.\u0018());
			}
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x0005294C File Offset: 0x00050B4C
		private void DRProfileControl_AddProfile(object sender, RoutedEventArgs e)
		{
			\u0006\u0019\u0018.\u0003(this.SH, \u0012\u0003\u000F.\u0018(this.IH));
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00052974 File Offset: 0x00050B74
		private void DRProfileControl_SaveProfile(object sender, RoutedEventArgs e)
		{
			\u0006\u0019\u0018.\u0003(this.SH, \u000D\u0003\u000F.\u0018(this.IH));
		}

		// Token: 0x06000E10 RID: 3600 RVA: 0x0005299C File Offset: 0x00050B9C
		private void DRProfileControl_ProfileChanged(object sender, RoutedEventArgs e)
		{
			\u0013\u0003\u000F.\u0018(this.IH, \u001F\u0007\u0018.\u0003(this.SH));
			string u000C;
			if (\u001F\u0007\u0018.\u0003(this.SH) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterMainWindow.DRProfileControl_ProfileChanged(object, RoutedEventArgs)).MethodHandle;
				}
				u000C = \u0005\u001E\u000F.\u000C;
			}
			else
			{
				Profile profile = \u0010\u0007\u0018.\u0003(this.SH);
				if (profile == null)
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
					u000C = \u0005\u001E\u000F.\u000C;
				}
				else
				{
					u000C = \u0008\u0007\u0018.\u0003(profile);
				}
			}
			\u001C\u0003\u000F.\u0018(u000C);
		}

		// Token: 0x06000E11 RID: 3601 RVA: 0x00052A18 File Offset: 0x00050C18
		private void DiRootsWindow_Loaded(object sender, RoutedEventArgs e)
		{
			\u001F\u0003\u000F.\u0018(\u0011\u0003\u000F.\u0018("ProSheets", \u0015\u0003\u000F.\u0018(this)));
			\u0020\u0003\u000F.\u0018(this.SH, "SelectionsSettings");
			\u000A\u0003\u000F.\u0018(\u0007\u0019\u0018.\u0003(this.SH), \u000A\u001D\u0018.\u0018(\u0007\u0006\u000F.\u000C()));
			\u0009\u0003\u000F.\u0018(this.SH);
			Profile profile = \u0010\u0007\u0018.\u0003(this.SH);
			string u000C;
			if (profile == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DocRegisterMainWindow.DiRootsWindow_Loaded(object, RoutedEventArgs)).MethodHandle;
				}
				u000C = \u0005\u001E\u000F.\u000C;
			}
			else
			{
				u000C = \u0008\u0007\u0018.\u0003(profile);
			}
			\u001C\u0003\u000F.\u0018(u000C);
		}

		// Token: 0x06000E13 RID: 3603 RVA: 0x00052AF8 File Offset: 0x00050CF8
		[GeneratedCode("PresentationBuildTasks", "9.0.8.0")]
		[DebuggerNonUserCode]
		internal Delegate TN(Type P, string Q)
		{
			return \u000E\u000B\u0018.\u0018(P, this, Q);
		}

		// Token: 0x04000631 RID: 1585
		private DocRegisterViewModel IH;
	}
}
