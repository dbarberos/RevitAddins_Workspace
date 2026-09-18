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
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace ProSheets.UI
{
	// Token: 0x02000087 RID: 135
	public partial class DngOptions : UserControl
	{
		// Token: 0x06000823 RID: 2083 RVA: 0x0002B780 File Offset: 0x00029980
		public DngOptions(List<string> inputConfig)
		{
			\u0019\u0013\u0003.\u0018(this);
			\u0003\u0019\u0018.\u0018(this.J, inputConfig);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0002B7A8 File Offset: 0x000299A8
		public void SetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			if (Enumerable.Contains<string>(Enumerable.Cast<string>(\u000D\u000F\u0014.\u0018(this.J)), \u0007\u0013\u0003.\u0018(templateInfo)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DngOptions.SetPrintConfig(ExportTemPlateInfo)).MethodHandle;
				}
				\u0016\u0007\u0018.\u0018(this.J, \u0007\u0013\u0003.\u0018(templateInfo));
			}
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002B800 File Offset: 0x00029A00
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			try
			{
				\u0006\u0013\u0003.\u0018(templateInfo, \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.J)));
			}
			catch (Exception u)
			{
				\u0010\u0013\u0003.\u0018(templateInfo, "");
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DngOptions.xaml.cs", "GetPrintConfig");
			}
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0002B860 File Offset: 0x00029A60
		public void getDGNControlValues()
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DngOptions.xaml.cs", "getDGNControlValues");
				\u0008\u0013\u0003.\u0018(\u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.J)));
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DngOptions.xaml.cs", "getDGNControlValues");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DngOptions.xaml.cs", "getDGNControlValues");
			}
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0002B8DC File Offset: 0x00029ADC
		public void ShowWarning()
		{
			if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.J)), \u001C\u0009\u0018.\u0020\u0018))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DngOptions.ShowWarning()).MethodHandle;
				}
				\u0014\u001A\u0018.\u0018(\u001C\u0009\u0018.\u001E\u0018);
			}
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0002B930 File Offset: 0x00029B30
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}
	}
}
