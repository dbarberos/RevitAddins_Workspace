using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.WindowControl;
using DiRoots.One.SheetLink.Core.Enums;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.SheetLink.UI.Windows
{
	// Token: 0x0200021C RID: 540
	public class ExportOptions : DiRootsWindow, IComponentConnector
	{
		// Token: 0x060014B1 RID: 5297 RVA: 0x00086E98 File Offset: 0x00085098
		public ExportOptions(bool enableKeepFormatting, bool checkKeepFormatting)
		{
			\u0012\u001D\u0005.\u000A(this);
			\u0015\u0009\u000A.\u000A(this.HY, enableKeepFormatting);
			\u000D\u000C\u0007.\u000A(this.HY, new bool?(checkKeepFormatting));
			object yy = this.YY;
			Visibility u000A;
			if (!enableKeepFormatting)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportOptions..ctor(bool, bool)).MethodHandle;
				}
				u000A = Visibility.Collapsed;
			}
			else
			{
				u000A = Visibility.Visible;
			}
			\u001D\u000C\u000A.\u0007(yy, u000A);
			if (!enableKeepFormatting)
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
				\u001D\u000C\u000A.\u0007(this.KY, Visibility.Collapsed);
			}
		}

		// Token: 0x060014B2 RID: 5298 RVA: 0x00086F0C File Offset: 0x0008510C
		public ExportOptions(bool enableKeepFormatting, bool checkKeepFormatting, bool isFolder)
		{
			\u0012\u001D\u0005.\u000A(this);
			\u0003\u001D\u0005.\u000A(this, isFolder);
			\u001D\u000C\u000A.\u0007(this.YY, Visibility.Collapsed);
			\u001D\u000C\u000A.\u0007(this.KY, Visibility.Collapsed);
			\u0015\u0009\u000A.\u000A(this.HY, enableKeepFormatting);
			\u000D\u000C\u0007.\u000A(this.HY, new bool?(checkKeepFormatting));
			\u001D\u000C\u000A.\u0007(this.UY, Visibility.Collapsed);
			this.UYR();
		}

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x060014B3 RID: 5299 RVA: 0x00086F74 File Offset: 0x00085174
		// (set) Token: 0x060014B4 RID: 5300 RVA: 0x00086F88 File Offset: 0x00085188
		private ExportOutputTypes _exportOutputType { get; set; }

		// Token: 0x170005DA RID: 1498
		// (get) Token: 0x060014B5 RID: 5301 RVA: 0x00086F9C File Offset: 0x0008519C
		// (set) Token: 0x060014B6 RID: 5302 RVA: 0x00086FB0 File Offset: 0x000851B0
		private bool _isFolder { get; set; }

		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x060014B7 RID: 5303 RVA: 0x00086FC4 File Offset: 0x000851C4
		public ExportOption OptionInstance
		{
			get
			{
				ExportOption exportOption = \u000B\u000C\u0018.\u000A();
				bool? flag = \u0003\u0015\u000A.\u000A(this.HY);
				\u0008\u001D\u0005.\u000A(exportOption, \u0012\u0015\u000A.\u000A(ref flag));
				flag = \u0003\u0015\u000A.\u000A(this.YY);
				\u000E\u001D\u0005.\u000A(exportOption, \u0012\u0015\u000A.\u000A(ref flag));
				flag = \u0003\u0015\u000A.\u000A(this.CY);
				\u0010\u001D\u0005.\u000A(exportOption, \u0012\u0015\u000A.\u000A(ref flag));
				\u001C\u001D\u0005.\u000A(exportOption, \u000D\u001D\u0005.\u000A(this));
				return exportOption;
			}
		}

		// Token: 0x060014B8 RID: 5304 RVA: 0x00087040 File Offset: 0x00085240
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0015\u0009\u000A.\u000A(this.WY, isLicenseValid);
			if (\u0012\u0001\u000A.\u000A(this.UY) == Visibility.Visible)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportOptions.ApplyLicense(bool)).MethodHandle;
				}
				\u0015\u0009\u000A.\u000A(this.LY, isLicenseValid);
			}
		}

		// Token: 0x060014B9 RID: 5305 RVA: 0x00087088 File Offset: 0x00085288
		private void btnExportToGoogle_Click(object sender, RoutedEventArgs e)
		{
			this.BYR(ExportOutputTypes.GoogleDrive);
		}

		// Token: 0x060014BA RID: 5306 RVA: 0x0008709C File Offset: 0x0008529C
		private void btnExportToExcel_Click(object sender, RoutedEventArgs e)
		{
			this.BYR(ExportOutputTypes.Excel);
		}

		// Token: 0x060014BB RID: 5307 RVA: 0x000870B0 File Offset: 0x000852B0
		private void BtnConnectToMorta_Click(object sender, RoutedEventArgs e)
		{
			this.BYR(ExportOutputTypes.Morta);
		}

		// Token: 0x060014BC RID: 5308 RVA: 0x000870C4 File Offset: 0x000852C4
		private void BYR(ExportOutputTypes F)
		{
			\u0006\u0015\u0007.\u0007(this, new bool?(true));
			\u001B\u001D\u0005.\u000A(this, F);
			\u0019\u000B\u0007.\u0007(this);
		}

		// Token: 0x060014BD RID: 5309 RVA: 0x000870EC File Offset: 0x000852EC
		private void chkKeepFormatting_Checked(object sender, RoutedEventArgs e)
		{
			this.UYR();
		}

		// Token: 0x060014BE RID: 5310 RVA: 0x00087100 File Offset: 0x00085300
		private void chkKeepFormatting_Unchecked(object sender, RoutedEventArgs e)
		{
			this.UYR();
		}

		// Token: 0x060014BF RID: 5311 RVA: 0x00087114 File Offset: 0x00085314
		private void UYR()
		{
			bool? flag = \u0003\u0015\u000A.\u000A(this.HY);
			if (\u0012\u0015\u000A.\u000A(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportOptions.UYR()).MethodHandle;
				}
				if (\u001E\u001D\u0005.\u000A(this))
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
					\u000F\u0015\u0007.\u000A(this.BY, \u0011\u001D\u0005.\u000A());
					\u001D\u000C\u000A.\u0007(this.SY, Visibility.Collapsed);
					return;
				}
			}
			\u000F\u0015\u0007.\u000A(this.BY, "Excel");
			\u001D\u000C\u000A.\u0007(this.SY, Visibility.Visible);
		}

		// Token: 0x060014C0 RID: 5312 RVA: 0x0008719C File Offset: 0x0008539C
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		[DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (this.R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExportOptions.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.R = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/windows/exportoptions.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060014C1 RID: 5313 RVA: 0x000871E4 File Offset: 0x000853E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.QQ(int F, object R)
		{
			switch (F)
			{
			case 1:
				this.HY = \u0016\u0009\u0010.\u001F(R);
				\u000E\u0015\u000A.\u000A(this.HY, new RoutedEventHandler(this.chkKeepFormatting_Checked));
				\u000D\u0015\u000A.\u000A(this.HY, new RoutedEventHandler(this.chkKeepFormatting_Unchecked));
				return;
			case 2:
				this.YY = \u0016\u0009\u0010.\u001F(R);
				return;
			case 3:
				this.CY = \u0016\u0009\u0010.\u001F(R);
				return;
			case 4:
				this.LY = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.LY, new RoutedEventHandler(this.btnExportToExcel_Click));
				return;
			case 5:
				this.SY = \u0015\u0002\u000E.\u001F(R);
				return;
			case 6:
				this.BY = \u001B\u0001\u0010.\u001F(R);
				return;
			case 7:
				this.UY = \u001B\u0001\u0010.\u001F(R);
				return;
			case 8:
				this.WY = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.WY, new RoutedEventHandler(this.btnExportToGoogle_Click));
				return;
			case 9:
				this.CH = \u001B\u0001\u0010.\u001F(R);
				return;
			case 10:
				this.KY = \u001E\u0001\u0010.\u001F(R);
				\u0010\u0015\u000A.\u000A(this.KY, new RoutedEventHandler(this.BtnConnectToMorta_Click));
				return;
			default:
				this.R = true;
				return;
			}
		}

		// Token: 0x040007EA RID: 2026
		[CompilerGenerated]
		private ExportOutputTypes RY;

		// Token: 0x040007EB RID: 2027
		[CompilerGenerated]
		private bool DY;

		// Token: 0x040007EC RID: 2028
		internal CheckBox HY;

		// Token: 0x040007ED RID: 2029
		internal CheckBox YY;

		// Token: 0x040007EE RID: 2030
		internal CheckBox CY;

		// Token: 0x040007EF RID: 2031
		internal Button LY;

		// Token: 0x040007F0 RID: 2032
		internal Image SY;

		// Token: 0x040007F1 RID: 2033
		internal TextBlock BY;

		// Token: 0x040007F2 RID: 2034
		internal TextBlock UY;

		// Token: 0x040007F3 RID: 2035
		internal Button WY;

		// Token: 0x040007F4 RID: 2036
		internal TextBlock CH;

		// Token: 0x040007F5 RID: 2037
		internal Button KY;

		// Token: 0x040007F6 RID: 2038
		private bool R;
	}
}
