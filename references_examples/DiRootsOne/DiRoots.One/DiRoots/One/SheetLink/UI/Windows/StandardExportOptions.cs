using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;

namespace DiRoots.One.SheetLink.UI.Windows
{
	// Token: 0x0200021E RID: 542
	public class StandardExportOptions : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060014E3 RID: 5347 RVA: 0x00088298 File Offset: 0x00086498
		public StandardExportOptions()
		{
			\u0014\u0004\u0005.\u000A(this);
			if (\u001F\u000C\u000A.\u001D(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A())))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StandardExportOptions..ctor()).MethodHandle;
				}
				\u000D\u000C\u0007.\u000A(this.MC, new bool?(false));
				\u001D\u000C\u000A.\u0007(this.MC, Visibility.Collapsed);
			}
		}

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x060014E4 RID: 5348 RVA: 0x000882F8 File Offset: 0x000864F8
		public bool OpenFile
		{
			get
			{
				bool? flag = \u0003\u0015\u000A.\u000A(this.CY);
				return \u0012\u0015\u000A.\u000A(ref flag);
			}
		}

		// Token: 0x170005E0 RID: 1504
		// (get) Token: 0x060014E5 RID: 5349 RVA: 0x0008831C File Offset: 0x0008651C
		// (set) Token: 0x060014E6 RID: 5350 RVA: 0x00088330 File Offset: 0x00086530
		public bool ToExcel { get; set; }

		// Token: 0x060014E7 RID: 5351 RVA: 0x00088344 File Offset: 0x00086544
		private void btnExportToGoogle_Click(object sender, RoutedEventArgs e)
		{
			if (\u0015\u0007\u0019.\u000A(\u000F\u000C\u0018.\u001D(this)) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StandardExportOptions.btnExportToGoogle_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0006\u0015\u0007.\u0007(this, new bool?(true));
				\u001A\u0004\u0005.\u000A(this, false);
				\u0019\u000B\u0007.\u0007(this);
				return;
			}
			\u0008\u0011\u001D.\u000A(\u0013\u0004\u0005.\u000A());
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x000883A0 File Offset: 0x000865A0
		private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
		{
			if (\u0015\u0007\u0019.\u000A(\u000F\u000C\u0018.\u001D(this)) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StandardExportOptions.btnExportToExcel_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0006\u0015\u0007.\u0007(this, new bool?(true));
				\u001A\u0004\u0005.\u000A(this, true);
				\u0019\u000B\u0007.\u0007(this);
				return;
			}
			\u0008\u0011\u001D.\u000A(\u0013\u0004\u0005.\u000A());
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x000883FC File Offset: 0x000865FC
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0015\u0009\u000A.\u000A(this.LY, isLicenseValid);
			\u0015\u0009\u000A.\u000A(this.WY, isLicenseValid);
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x00088424 File Offset: 0x00086624
		public List<string> GetStandardCategoryNames()
		{
			List<string> list = \u0014\u000D\u0007.\u000A();
			bool? flag = \u0003\u0015\u000A.\u000A(this.MC);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StandardExportOptions.GetStandardCategoryNames()).MethodHandle;
				}
				\u001A\u0008\u0007.\u000A(list, "Project Information");
			}
			flag = \u0003\u0015\u000A.\u000A(this.VC);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
				\u001A\u0008\u0007.\u000A(list, "Object Styles");
			}
			flag = \u0003\u0015\u000A.\u000A(this.ZC);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
				\u001A\u0008\u0007.\u000A(list, "Line Styles");
			}
			flag = \u0003\u0015\u000A.\u000A(this.XC);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
				\u001A\u0008\u0007.\u000A(list, "Families");
			}
			return list;
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x000884FC File Offset: 0x000866FC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StandardExportOptions.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/windows/standardexportoptions.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x00088544 File Offset: 0x00086744
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.CY = \u0016\u0009\u0010.\u001F(R);
				return;
			case 2:
				this.MC = \u0016\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.VC = \u0016\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.ZC = \u0016\u0009\u0010.\u001F(R);
				return;
			case 5:
				this.XC = \u0016\u0009\u0010.\u001F(R);
				return;
			case 6:
				this.LY = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.LY, new RoutedEventHandler(this.btnExportToExcel_Click));
				return;
			case 7:
				this.UY = \u001B\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.WY = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.WY, new RoutedEventHandler(this.btnExportToGoogle_Click));
				return;
			case 9:
				this.PC = \u001B\u0001\u0010.\u001F(R);
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x0400081A RID: 2074
		[CompilerGenerated]
		private bool NC;

		// Token: 0x0400081B RID: 2075
		internal CheckBox CY;

		// Token: 0x0400081C RID: 2076
		internal CheckBox MC;

		// Token: 0x0400081D RID: 2077
		internal CheckBox VC;

		// Token: 0x0400081E RID: 2078
		internal CheckBox ZC;

		// Token: 0x0400081F RID: 2079
		internal CheckBox XC;

		// Token: 0x04000820 RID: 2080
		internal Button LY;

		// Token: 0x04000821 RID: 2081
		internal TextBlock UY;

		// Token: 0x04000822 RID: 2082
		internal Button WY;

		// Token: 0x04000823 RID: 2083
		internal TextBlock PC;

		// Token: 0x04000824 RID: 2084
		private bool R;
	}
}
