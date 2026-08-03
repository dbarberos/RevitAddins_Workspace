using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.UI.UserControls;
using ProSheets.Helpers;

namespace ProSheets.UI
{
	// Token: 0x02000089 RID: 137
	public partial class DwgOptions : BaseUserControl
	{
		// Token: 0x0600084D RID: 2125 RVA: 0x0002D6EC File Offset: 0x0002B8EC
		public DwgOptions(List<string> inputConfig, Document doc)
		{
			\u000F\u001F\u0003.\u0018(this);
			this.YB = doc;
			\u0003\u0019\u0018.\u0018(this.CB, inputConfig);
			\u0008\u0013\u0014.\u0018(this.WB, Visibility.Visible);
			\u0008\u0013\u0014.\u0018(this.SB, Visibility.Visible);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x0002D730 File Offset: 0x0002B930
		public void SetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			if (Enumerable.Contains<string>(Enumerable.Cast<string>(\u000D\u000F\u0014.\u0018(this.CB)), \u000A\u001F\u0003.\u0018(templateInfo)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwgOptions.SetPrintConfig(ExportTemPlateInfo)).MethodHandle;
				}
				\u0016\u0007\u0018.\u0018(this.CB, \u000A\u001F\u0003.\u0018(templateInfo));
			}
			\u0007\u0018\u0003.\u0018(this.TB, new bool?(\u0009\u001F\u0003.\u0018(templateInfo)));
			ElementClassFilter u = \u0009\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0008\u001A\u000F.\u000C()));
			List<ExportDWGSettings>.Enumerator enumerator = \u000A\u0002\u0014.\u0018(Enumerable.ToList<ExportDWGSettings>(Enumerable.Cast<ExportDWGSettings>(\u0013\u001D\u0018.\u0003(\u0020\u001D\u0018.\u0018(this.YB), u))));
			try
			{
				while (\u0013\u0002\u0014.\u0018(ref enumerator))
				{
					ExportDWGSettings u000C = \u0009\u0002\u0014.\u0018(ref enumerator);
					if (\u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(u000C), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.CB))))
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
						DWGExportOptions u000C2 = \u0013\u001F\u0003.\u0018(u000C);
						\u0007\u0018\u0003.\u0018(this.TB, new bool?(!\u001C\u001F\u0003.\u0018(u000C2)));
						goto IL_12A;
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IL_12A:
			if (\u000C\u0011\u0014.\u0018())
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
				\u0007\u0018\u0003.\u0018(this.IB, new bool?(\u000D\u001F\u0003.\u0018(templateInfo)));
				\u0007\u0018\u0003.\u0018(this.UB, new bool?(\u0012\u001F\u0003.\u0018(templateInfo)));
			}
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0002D8B8 File Offset: 0x0002BAB8
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			try
			{
				\u0010\u0013\u0003.\u0018(templateInfo, \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.CB)));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwgOptions.xaml.cs", "GetPrintConfig");
				\u0010\u0013\u0003.\u0018(templateInfo, "");
			}
			\u0011\u001F\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.TB)));
			\u001F\u001F\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.IB)));
			\u0020\u001F\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.UB)));
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0002D974 File Offset: 0x0002BB74
		public void getDWGControlValues()
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwgOptions.xaml.cs", "getDWGControlValues");
				\u0002\u001F\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.TB)));
				\u001E\u001F\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.IB)));
				\u0017\u001F\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.UB)));
				\u0015\u001F\u0003.\u0018(\u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.CB)));
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwgOptions.xaml.cs", "getDWGControlValues");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwgOptions.xaml.cs", "getDWGControlValues");
			}
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0002DA4C File Offset: 0x0002BC4C
		private void cmbDWGName_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ElementClassFilter u = \u0009\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u0008\u001A\u000F.\u000C()));
			List<ExportDWGSettings>.Enumerator enumerator = \u000A\u0002\u0014.\u0018(Enumerable.ToList<ExportDWGSettings>(Enumerable.Cast<ExportDWGSettings>(\u0013\u001D\u0018.\u0003(\u0020\u001D\u0018.\u0018(this.YB), u))));
			try
			{
				while (\u0013\u0002\u0014.\u0018(ref enumerator))
				{
					ExportDWGSettings u000C = \u0009\u0002\u0014.\u0018(ref enumerator);
					if (\u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(u000C), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.CB))))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DwgOptions.cmbDWGName_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
						}
						DWGExportOptions u000C2 = \u0013\u001F\u0003.\u0018(u000C);
						\u0007\u0018\u0003.\u0018(this.TB, new bool?(!\u001C\u001F\u0003.\u0018(u000C2)));
						return;
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0002DB3C File Offset: 0x0002BD3C
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0002DB64 File Offset: 0x0002BD64
		protected override void ApplyLicense(bool isLicenseValid)
		{
			\u0014\u0019\u0018.\u0018(this.IB, isLicenseValid);
			\u0014\u0019\u0018.\u0018(this.UB, isLicenseValid);
			if (!isLicenseValid)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwgOptions.ApplyLicense(bool)).MethodHandle;
				}
				\u0007\u0018\u0003.\u0018(this.IB, new bool?(false));
				\u0007\u0018\u0003.\u0018(this.UB, new bool?(false));
			}
		}

		// Token: 0x04000361 RID: 865
		private Document YB;
	}
}
