using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;

namespace ProSheets.UI
{
	// Token: 0x0200008D RID: 141
	public partial class NwcOptions : UserControl
	{
		// Token: 0x060008B6 RID: 2230 RVA: 0x00034C6C File Offset: 0x00032E6C
		public NwcOptions()
		{
			\u0017\u000B\u0003.\u0018(this);
			\u0015\u000B\u0003.\u0018(this);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00034C8C File Offset: 0x00032E8C
		public void loadConfig()
		{
			PSCommand.objFlag = false;
			\u0007\u0018\u0003.\u0018(this.J, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.Z, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.M, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.Y, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.O, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.C, new bool?(true));
			\u0003\u0019\u0018.\u0018(this.F, \u0002\u000B\u0003.\u0018());
			\u0003\u0019\u0018.\u0018(this.X, \u001E\u000B\u0003.\u0018());
			\u0007\u0018\u0003.\u0018(this.T, new bool?(true));
			\u0012\u000B\u0018.\u0018(this.S, "1.0");
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00034D4C File Offset: 0x00032F4C
		public static List<EnumInfo> GetNWC_Parameters()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0011, "All", 2, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u001B\u0018, "Elements", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0010\u0018, "None", 0, false));
			return list;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00034DB4 File Offset: 0x00032FB4
		public static List<EnumInfo> GetNWC_Coordinates()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0005\u0018, "Shared", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u000E\u0018, "Internal", 0, false));
			return list;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00034E00 File Offset: 0x00033000
		public void SetPrintConfig(Export export, ExportTemPlateInfo templateInfo)
		{
			try
			{
				\u0007\u0018\u0003.\u0018(this.I, new bool?(\u0018\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.T, new bool?(\u000C\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				object s = this.S;
				double num = \u000E\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo));
				\u0012\u000B\u0018.\u0018(s, \u000D\u0005\u0014.\u0018(ref num));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\NwcOptions.xaml.cs", "SetPrintConfig");
			}
			try
			{
				\u0007\u0018\u0003.\u0018(this.H, new bool?(\u0005\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0016\u0007\u0018.\u0018(this.X, this.X.\u0016(\u001B\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.Y, new bool?(\u0001\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.J, new bool?(\u0008\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.N, new bool?(\u0006\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.Q, new bool?(\u0010\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.Z, new bool?(\u0007\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.O, new bool?(\u0019\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.M, new bool?(\u000B\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0007\u0018\u0003.\u0018(this.C, new bool?(\u001A\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
				\u0016\u0007\u0018.\u0018(this.F, \u0004\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo)));
				\u0016\u0007\u0018.\u0018(this.F, this.F.\u0016(\u0004\u000B\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo))));
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\NwcOptions.xaml.cs", "SetPrintConfig");
			}
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00035060 File Offset: 0x00033260
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			try
			{
				\u0015\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.I)));
				\u0011\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.T)));
				\u001F\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u001C\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.S)));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\NwcOptions.xaml.cs", "GetPrintConfig");
			}
			try
			{
				\u0020\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.H)));
				\u000A\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.X).\u0018());
				\u0009\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Y)));
				\u0013\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.J)));
				\u001C\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.N)));
				\u000D\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Q)));
				\u0012\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Z)));
				\u000F\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.O)));
				\u0016\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.M)));
				\u0003\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.C)));
				\u0014\u0019\u0003.\u0018(\u001D\u000B\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.F).\u0018());
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\NwcOptions.xaml.cs", "GetPrintConfig");
			}
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x000352E0 File Offset: 0x000334E0
		public void getNWCControlValues()
		{
			try
			{
				\u001B\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.I)));
				\u0001\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.T)));
				\u0008\u0019\u0003.\u0018(\u0007\u001C\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.S)));
				\u0006\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.H)));
				\u0010\u0019\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.X).\u0018());
				\u0007\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Y)));
				\u0019\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.J)));
				\u000B\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.N)));
				\u001A\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Q)));
				\u001D\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.Z)));
				\u0004\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.O)));
				\u0002\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.M)));
				\u001E\u0019\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.C)));
				\u0017\u0019\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.F).\u0018());
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\NwcOptions.xaml.cs", "getNWCControlValues");
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000354BC File Offset: 0x000336BC
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex u000C = \u000D\u0009\u0014.\u0018("[^0-9.-]+");
			\u001D\u000B\u0018.\u0018(e, \u0012\u0009\u0014.\u0018(u000C, \u000E\u0020\u0003.\u0018(e)));
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x000354EC File Offset: 0x000336EC
		private void txtFacetingFactor_LostFocus(object sender, RoutedEventArgs e)
		{
			if (\u000F\u0002\u0018.\u0018(\u0001\u000B\u0018.\u0018(this.S), ""))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NwcOptions.txtFacetingFactor_LostFocus(object, RoutedEventArgs)).MethodHandle;
				}
				\u0012\u000B\u0018.\u0018(this.S, "1.0");
				return;
			}
			if (\u000F\u0002\u0018.\u0018(\u0001\u000B\u0018.\u0018(this.S), "0"))
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
				\u0012\u000B\u0018.\u0018(this.S, "0.1");
			}
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00035570 File Offset: 0x00033770
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}
	}
}
