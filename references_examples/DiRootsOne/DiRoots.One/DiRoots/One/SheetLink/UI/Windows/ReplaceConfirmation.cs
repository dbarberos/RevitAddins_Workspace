using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.UI.Windows
{
	// Token: 0x0200021B RID: 539
	public class ReplaceConfirmation : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060014A5 RID: 5285 RVA: 0x00086B58 File Offset: 0x00084D58
		public ReplaceConfirmation(List<string> sheetNames, string filePath)
		{
			\u0006\u001D\u0005.\u000A(this);
			\u0002\u001D\u0005.\u000A(this, filePath);
			\u0011\u000E\u0019.\u0007(this.AH);
			\u000F\u0015\u0007.\u000A(this.QH, "");
			\u000F\u0015\u0007.\u000A(this.IH, "");
			if (\u0015\u0007\u0019.\u000A(sheetNames) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReplaceConfirmation..ctor(List<string>, string)).MethodHandle;
				}
				\u001D\u000C\u000A.\u0007(this.IH, Visibility.Visible);
				\u000F\u0015\u0007.\u000A(this.IH, \u000B\u001D\u0005.\u000A("\n", \u001B\u0007\u0005.\u000A(sheetNames)));
				\u000F\u0015\u0007.\u000A(this.QH, \u0016\u001D\u0005.\u000A());
				return;
			}
			\u001D\u000C\u000A.\u0007(this.IH, Visibility.Hidden);
			\u001D\u000C\u000A.\u0007(this.AH, Visibility.Collapsed);
			\u001D\u000C\u000A.\u0007(this.GH, Visibility.Visible);
			Run u000A = new Run(\u0005\u001D\u0005.\u000A());
			\u0019\u001D\u0005.\u000A(\u0018\u001D\u0005.\u000A(this.QH), u000A);
		}

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x060014A6 RID: 5286 RVA: 0x00086C48 File Offset: 0x00084E48
		// (set) Token: 0x060014A7 RID: 5287 RVA: 0x00086C5C File Offset: 0x00084E5C
		public string FilePath { get; set; }

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x060014A8 RID: 5288 RVA: 0x00086C70 File Offset: 0x00084E70
		// (set) Token: 0x060014A9 RID: 5289 RVA: 0x00086C84 File Offset: 0x00084E84
		public WriteModes WriteMode { get; set; }

		// Token: 0x060014AA RID: 5290 RVA: 0x00086C98 File Offset: 0x00084E98
		private void btnCancel_Click(object sender, RoutedEventArgs e)
		{
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x060014AB RID: 5291 RVA: 0x00086CAC File Offset: 0x00084EAC
		private void BtnOk_Click(object sender, RoutedEventArgs e)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
		}

		// Token: 0x060014AC RID: 5292 RVA: 0x00086CC8 File Offset: 0x00084EC8
		private void BtnSelectFile_OnClick(object sender, RoutedEventArgs e)
		{
			string text = \u0004\u000F.\u0018(\u0012\u0015\u001D.\u000A(\u0018\u0020\u0018.\u001D(this)), false, false);
			if (!\u001A\u0006\u0007.\u000A(text))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReplaceConfirmation.BtnSelectFile_OnClick(object, RoutedEventArgs)).MethodHandle;
				}
				\u0002\u001D\u0005.\u000A(this, text);
				\u000F\u001D\u0005.\u000A(this, WriteModes.CreateFile);
				\u0011\u0012.\u0007(\u0010\u0016\u0018.\u000A(\u000E\u0016\u0018.\u000A(text)));
				\u0006\u0015\u0007.\u0007(this, new bool?(true));
				return;
			}
			\u0002\u001D\u0005.\u000A(this, "");
		}

		// Token: 0x060014AD RID: 5293 RVA: 0x00086D48 File Offset: 0x00084F48
		private void btnOverwrite_Click(object sender, RoutedEventArgs e)
		{
			\u000F\u001D\u0005.\u000A(this, WriteModes.RemoveSheets);
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
		}

		// Token: 0x060014AE RID: 5294 RVA: 0x00086D68 File Offset: 0x00084F68
		private void BtnInsert_OnClick(object sender, RoutedEventArgs e)
		{
			\u000F\u001D\u0005.\u000A(this, WriteModes.InsertSheets);
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
		}

		// Token: 0x060014AF RID: 5295 RVA: 0x00086D88 File Offset: 0x00084F88
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ReplaceConfirmation.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink.core/ui/windows/replaceconfirmation.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060014B0 RID: 5296 RVA: 0x00086DD0 File Offset: 0x00084FD0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.IH = \u001B\u0001\u0010.\u001F(R);
				return;
			case 2:
				this.QH = \u001B\u0001\u0010.\u001F(R);
				return;
			case 3:
				this.AH = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.AH, new RoutedEventHandler(this.btnOverwrite_Click));
				return;
			case 4:
				this.GH = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.GH, new RoutedEventHandler(this.BtnInsert_OnClick));
				return;
			case 5:
				this.FY = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.FY, new RoutedEventHandler(this.BtnSelectFile_OnClick));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040007E2 RID: 2018
		[CompilerGenerated]
		private string OH;

		// Token: 0x040007E3 RID: 2019
		[CompilerGenerated]
		private WriteModes TH;

		// Token: 0x040007E4 RID: 2020
		internal TextBlock IH;

		// Token: 0x040007E5 RID: 2021
		internal TextBlock QH;

		// Token: 0x040007E6 RID: 2022
		internal Button AH;

		// Token: 0x040007E7 RID: 2023
		internal Button GH;

		// Token: 0x040007E8 RID: 2024
		internal Button FY;

		// Token: 0x040007E9 RID: 2025
		private bool R;
	}
}
