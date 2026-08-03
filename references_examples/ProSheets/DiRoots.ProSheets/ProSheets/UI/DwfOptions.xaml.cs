using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.ProSheets.ViewModels;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using Xceed.Wpf.Toolkit;

namespace ProSheets.UI
{
	// Token: 0x02000088 RID: 136
	public partial class DwfOptions : UserControl
	{
		// Token: 0x0600082B RID: 2091 RVA: 0x0002BA18 File Offset: 0x00029C18
		public DwfOptions(Document inputDoc, ParameterBaseModel parameterBaseModel)
		{
			\u0005\u0013\u0003.\u0018(this);
			this.Q = parameterBaseModel;
			List<IParameterModel> u = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0007\u0003\u0003.\u0018(this.Q)));
			this.J = new CustomParameterModel();
			\u001B\u0013\u0003.\u0018(this.J, u);
			\u0001\u0013\u0003.\u0018(this, inputDoc);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0002BA74 File Offset: 0x00029C74
		public void loadPrintConfig(Document objDoc)
		{
			this.P = objDoc;
			PSCommand.objFlag = false;
			\u0007\u0018\u0003.\u0018(this.H, new bool?(true));
			\u0003\u0019\u0018.\u0018(this.S, \u0019\u0009\u0018.\u0014());
			\u0009\u0019\u0018.\u0018(this.S, 0);
			\u0003\u0019\u0018.\u0018(this.BB, \u0019\u0009\u0018.\u000F());
			\u0003\u0019\u0018.\u0018(this.QB, \u0019\u0009\u0018.\u0012());
			\u0003\u0019\u0018.\u0018(this.Z, \u0014\u0009\u0003.\u0018());
			\u0003\u0019\u0018.\u0018(this.X, \u0018\u0009\u0003.\u0018());
			\u0003\u0019\u0018.\u0018(this.Y, \u000C\u0009\u0003.\u0018());
			bool flag = \u000E\u0013\u0003.\u0018(this.P);
			object u = this.U;
			string u000C = "0.00";
			string u2;
			if (!flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.loadPrintConfig(Document)).MethodHandle;
				}
				u2 = "in";
			}
			else
			{
				u2 = "mm";
			}
			\u0012\u000B\u0018.\u0018(u, \u000D\u001E\u0018.\u0018(u000C, u2));
			object l = this.L;
			string u000C2 = "0.00";
			string u3;
			if (!flag)
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
				u3 = "in";
			}
			else
			{
				u3 = "mm";
			}
			\u0012\u000B\u0018.\u0018(l, \u000D\u001E\u0018.\u0018(u000C2, u3));
			\u0007\u0018\u0003.\u0018(this.I, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.E, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.PB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.MB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.JB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.FB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.RB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.HB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.NB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.O, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.W, new bool?(true));
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x0002BC4C File Offset: 0x00029E4C
		public static List<EnumInfo> GetDWF_ImageQuality()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0015\u0018, "Default", 10, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0004\u0018, "High", 13, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0002\u0018, "Medium", 12, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0017\u0018, "Low", 11, false));
			return list;
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x0002BCD0 File Offset: 0x00029ED0
		public static List<EnumInfo> GetDWF_ImageFormats()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0006\u0014, "Lossless", 0, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0008\u0014, "Lossy", 1, false));
			return list;
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x0002BD1C File Offset: 0x00029F1C
		public static List<ExportPaperFormat> getDWF_PaperSizies()
		{
			List<ExportPaperFormat> list = \u0016\u0009\u0003.\u0018();
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWF_PaperSizies");
				\u0003\u0009\u0003.\u0018(list, 0);
				\u0003\u0009\u0003.\u0018(list, 1);
				\u0003\u0009\u0003.\u0018(list, 2);
				\u0003\u0009\u0003.\u0018(list, 3);
				\u0003\u0009\u0003.\u0018(list, 4);
				\u0003\u0009\u0003.\u0018(list, 5);
				\u0003\u0009\u0003.\u0018(list, 15);
				\u0003\u0009\u0003.\u0018(list, 16);
				\u0003\u0009\u0003.\u0018(list, 17);
				\u0003\u0009\u0003.\u0018(list, 18);
				\u0003\u0009\u0003.\u0018(list, 19);
				\u0003\u0009\u0003.\u0018(list, 20);
				\u0003\u0009\u0003.\u0018(list, 21);
				\u0003\u0009\u0003.\u0018(list, 22);
				\u0003\u0009\u0003.\u0018(list, 10);
				\u0003\u0009\u0003.\u0018(list, 9);
				\u0003\u0009\u0003.\u0018(list, 8);
				\u0003\u0009\u0003.\u0018(list, 7);
				\u0003\u0009\u0003.\u0018(list, 6);
				\u0003\u0009\u0003.\u0018(list, 14);
				\u0003\u0009\u0003.\u0018(list, 13);
				\u0003\u0009\u0003.\u0018(list, 12);
				\u0003\u0009\u0003.\u0018(list, 11);
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWF_PaperSizies");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWF_PaperSizies");
			}
			return list;
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0002BE38 File Offset: 0x0002A038
		public bool IsValidPrinter()
		{
			return true;
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x0002BE48 File Offset: 0x0002A048
		public static bool IsMetric(Document doc)
		{
			bool result = false;
			\u0019\u0004\u0018.\u0018(doc);
			if (\u000F\u0009\u0003.\u0018(doc) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.IsMetric(Document)).MethodHandle;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x0002BE80 File Offset: 0x0002A080
		public void SetPrintConfig(Export export, ExportTemPlateInfo templateInfo)
		{
			if (\u0016\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.SetPrintConfig(Export, ExportTemPlateInfo)).MethodHandle;
				}
				\u0007\u0018\u0003.\u0018(this.N, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.H, new bool?(true));
			}
			\u0016\u0007\u0018.\u0018(this.Z, \u0003\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)));
			\u0007\u0018\u0003.\u0018(this.C, new bool?(\u0014\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.M, new bool?(\u0018\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.O, new bool?(\u000C\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.W, new bool?(\u000E\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u001D\u0009\u0003.\u0018(this.X, \u0005\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)).ToString());
			\u001D\u0009\u0003.\u0018(this.Y, \u001B\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)).ToString());
			\u0007\u0018\u0003.\u0018(this.T, new bool?(\u0001\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.I, new bool?(!\u0001\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u001D\u0009\u0003.\u0018(this.S, \u0008\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)));
			bool flag = \u000E\u0013\u0003.\u0018(this.P);
			string text = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0006\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)), "mm", ""), "in", "");
			string text2 = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0010\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)), "mm", ""), "in", "");
			object u = this.U;
			string u000C = text;
			string u2;
			if (!flag)
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
				u2 = "in";
			}
			else
			{
				u2 = "mm";
			}
			\u0012\u000B\u0018.\u0018(u, \u000D\u001E\u0018.\u0018(u000C, u2));
			object l = this.L;
			string u000C2 = text2;
			string u3;
			if (!flag)
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
				u3 = "in";
			}
			else
			{
				u3 = "mm";
			}
			\u0012\u000B\u0018.\u0018(l, \u000D\u001E\u0018.\u0018(u000C2, u3));
			if (\u0007\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)))
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
				\u0007\u0018\u0003.\u0018(this.E, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.A, new bool?(true));
			}
			if (\u0019\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)))
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
				\u0007\u0018\u0003.\u0018(this.K, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.PB, new bool?(true));
			}
			\u0016\u0007\u0018.\u0018(this.BB, this.BB.\u0016(\u000B\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u001D\u0009\u0003.\u0018(this.QB, \u001A\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)));
			\u0007\u0018\u0003.\u0018(this.FB, new bool?(\u0004\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.RB, new bool?(\u0002\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.HB, new bool?(\u001E\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.NB, new bool?(\u0017\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.ZB, new bool?(\u0015\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			\u0007\u0018\u0003.\u0018(this.MB, new bool?(\u0011\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo))));
			if (!\u0011\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)))
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
				\u0007\u0018\u0003.\u0018(this.XB, new bool?(true));
			}
			\u0020\u0009\u0003.\u0014(this.J, \u001F\u0009\u0003.\u0018(templateInfo));
			\u0009\u0009\u0003.\u0014(this.J, \u000A\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)));
			if (\u0013\u0009\u0003.\u0014(this.J))
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
				\u0012\u0009\u0003.\u0014(this.J, \u000D\u0009\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo)));
			}
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x0002C2F0 File Offset: 0x0002A4F0
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			\u000C\u0020\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.N)));
			\u000E\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u001A\u0019\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Z)));
			\u0005\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.C)));
			\u001B\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.M)));
			\u0001\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.O)));
			\u0008\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.W)));
			\u0006\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.X).\u0018());
			\u0010\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.Y).\u0018());
			\u0007\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.T)));
			object u000C = \u001C\u0009\u0003.\u0018(templateInfo);
			object obj = \u001E\u000A\u0003.\u0018(this.S);
			string u;
			if (obj == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.GetPrintConfig(ExportTemPlateInfo)).MethodHandle;
				}
				u = \u0005\u001E\u000F.\u000C;
			}
			else
			{
				u = \u0001\u0017\u0018.\u0018(obj);
			}
			\u0019\u000A\u0003.\u0018(u000C, u);
			\u000B\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0001\u000B\u0018.\u0018(this.U));
			\u001A\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0001\u000B\u0018.\u0018(this.L));
			\u001D\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.E)));
			\u0004\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.K)));
			if (\u0012\u0007\u0018.\u0018(this.BB) != null)
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
				\u0002\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.BB).\u0018());
			}
			if (\u0012\u0007\u0018.\u0018(this.QB) != null)
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
				\u0017\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)));
			}
			\u0015\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.FB)));
			\u0011\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RB)));
			\u001F\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.HB)));
			\u0020\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.NB)));
			\u000A\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZB)));
			\u0009\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.MB)));
			\u0013\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0013\u0009\u0003.\u0014(this.J));
			\u000D\u000A\u0003.\u0018(templateInfo, \u001C\u000A\u0003.\u0014(this.J));
			if (\u0013\u0009\u0003.\u0014(this.J))
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
				\u000F\u000A\u0003.\u0018(\u001C\u0009\u0003.\u0018(templateInfo), \u0012\u000A\u0003.\u0014(this.J));
			}
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x0002C6BC File Offset: 0x0002A8BC
		private string WB()
		{
			return \u0008\u0020\u0018.\u000C(\u001C\u000A\u0003.\u0014(this.J), \u0012\u000A\u0003.\u0014(this.J), \u0013\u0009\u0003.\u0014(this.J));
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0002C6F8 File Offset: 0x0002A8F8
		public void getDWFControlValues()
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWFControlValues");
				if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.H)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.getDWFControlValues()).MethodHandle;
					}
					\u0006\u0020\u0003.\u0018(false);
				}
				else if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.N)))
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
					\u0006\u0020\u0003.\u0018(true);
				}
				\u0010\u0020\u0003.\u0018(\u001A\u0019\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Z)));
				\u0007\u0020\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.X).\u0018());
				\u0019\u0020\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.Y).\u0018());
				if (\u0006\u0001\u0018.\u0018(this.C))
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
					\u000B\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.C)));
				}
				else
				{
					\u000B\u0020\u0003.\u0018(false);
				}
				\u001A\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.M)));
				\u001D\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.W)));
				\u0004\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.O)));
				bool? flag;
				try
				{
					flag = \u001B\u0001\u0018.\u0018(this.T);
					if (\u000C\u0007\u0018.\u0018(ref flag))
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
						\u0002\u0020\u0003.\u0018(0);
					}
					else
					{
						\u0002\u0020\u0003.\u0018(1);
						if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)), "No Margin"))
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
							\u001E\u0020\u0003.\u0018(0);
						}
						else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)), "Printer Limit"))
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
							\u001E\u0020\u0003.\u0018(1);
						}
						else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)), "User Defined"))
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
							\u001E\u0020\u0003.\u0018(2);
							bool flag2 = \u000E\u0013\u0003.\u0018(this.P);
							string u000C = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0001\u000B\u0018.\u0018(this.U), "mm", ""), "in", "");
							if (flag2)
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
								\u0017\u0020\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C));
							}
							else
							{
								\u0017\u0020\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C) * 25.4);
							}
							u000C = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0001\u000B\u0018.\u0018(this.L), "mm", ""), "in", "");
							if (flag2)
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
								\u0015\u0020\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C));
							}
							else
							{
								\u0015\u0020\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C) * 25.4);
							}
						}
					}
				}
				catch (Exception u)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWFControlValues");
				}
				flag = \u001B\u0001\u0018.\u0018(this.E);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
					\u0011\u0020\u0003.\u0018(0);
				}
				else
				{
					\u0011\u0020\u0003.\u0018(1);
					\u0020\u0020\u0003.\u0018(\u0001\u000F\u0014.\u0018(\u001F\u0020\u0003.\u0018(this.V)));
					if (\u0002\u0001\u0014.\u0018() <= 0)
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
						\u0020\u0020\u0003.\u0018(100);
					}
				}
				flag = \u001B\u0001\u0018.\u0018(this.K);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
					\u000A\u0020\u0003.\u0018(0);
				}
				else
				{
					\u000A\u0020\u0003.\u0018(1);
				}
				\u0009\u0020\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.BB).\u0018());
				if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)), "Color"))
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
					\u0013\u0020\u0003.\u0018(2);
				}
				else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)), "Gray Scale"))
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
					\u0013\u0020\u0003.\u0018(1);
				}
				else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)), "Black Line"))
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
					\u0013\u0020\u0003.\u0018(0);
				}
				\u001C\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.JB)));
				\u000D\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.FB)));
				\u0012\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RB)));
				\u000F\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.HB)));
				\u0016\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.NB)));
				\u0003\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZB)));
				\u0014\u0020\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.XB)));
				\u0018\u0020\u0003.\u0018(this.WB());
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWFControlValues");
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\DwfOptions.xaml.cs", "getDWFControlValues");
			}
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x0002CCB8 File Offset: 0x0002AEB8
		private void CmbPaperSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (\u0012\u0007\u0018.\u0018(this.Z) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.CmbPaperSize_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				\u0010\u0020\u0003.\u0018(\u001A\u0019\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Z)));
			}
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0002CD00 File Offset: 0x0002AF00
		private void RdbCenter_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.S, false);
			\u0007\u0018\u0003.\u0018(this.I, new bool?(false));
			\u0014\u0019\u0018.\u0018(this.U, false);
			\u0014\u0019\u0018.\u0018(this.L, false);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x0002CD44 File Offset: 0x0002AF44
		private void RdbOffsetFromCorner_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.S, true);
			\u0007\u0018\u0003.\u0018(this.T, new bool?(false));
			this.TB();
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x0002CD74 File Offset: 0x0002AF74
		private void CmbOffsetFromCorner_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.TB();
		}

		// Token: 0x0600083A RID: 2106 RVA: 0x0002CD88 File Offset: 0x0002AF88
		private void TB()
		{
			try
			{
				if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)), "User Defined"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.TB()).MethodHandle;
					}
					\u0014\u0019\u0018.\u0018(this.U, true);
					\u0014\u0019\u0018.\u0018(this.L, true);
				}
				else
				{
					\u0014\u0019\u0018.\u0018(this.U, false);
					\u0014\u0019\u0018.\u0018(this.L, false);
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x0002CE14 File Offset: 0x0002B014
		private void RdbFitToPage_Checked(object sender, RoutedEventArgs e)
		{
			\u0007\u0018\u0003.\u0018(this.A, new bool?(false));
			\u0008\u0013\u0014.\u0018(this.V, Visibility.Hidden);
			\u0008\u0013\u0014.\u0018(this.D, Visibility.Hidden);
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0002CE4C File Offset: 0x0002B04C
		private void RdbZoom_Checked(object sender, RoutedEventArgs e)
		{
			\u0007\u0018\u0003.\u0018(this.E, new bool?(false));
			\u0008\u0013\u0014.\u0018(this.V, Visibility.Visible);
			\u0008\u0013\u0014.\u0018(this.D, Visibility.Visible);
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x0002CE84 File Offset: 0x0002B084
		private void MyUpDownControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			int? num = \u001F\u0020\u0003.\u0018(this.V);
			int num2 = 0;
			if (\u001B\u0020\u0003.\u0018(ref num) <= num2 & \u0001\u0020\u0003.\u0018(ref num))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.MyUpDownControl_ValueChanged(object, RoutedPropertyChangedEventArgs<object>)).MethodHandle;
				}
				\u0008\u0020\u0003.\u0018(this.V, new int?(100));
			}
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x0002CEE4 File Offset: 0x0002B0E4
		private void RdbSeparateFile_Checked(object sender, RoutedEventArgs e)
		{
			Export.isDWFCombineFile = false;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x0002CEF8 File Offset: 0x0002B0F8
		private void RdbCombineFile_Checked(object sender, RoutedEventArgs e)
		{
			Export.isDWFCombineFile = true;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x0002CF0C File Offset: 0x0002B10C
		private void TxtX_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			TextBox q = \u0018\u0004\u000F.\u000C(sender);
			DwfOptions.IB(e, q);
		}

		// Token: 0x06000841 RID: 2113 RVA: 0x0002CF2C File Offset: 0x0002B12C
		private void TxtY_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			TextBox q = \u0018\u0004\u000F.\u000C(sender);
			DwfOptions.IB(e, q);
		}

		// Token: 0x06000842 RID: 2114 RVA: 0x0002CF4C File Offset: 0x0002B14C
		private static void IB(TextCompositionEventArgs P, TextBox Q)
		{
			if (!\u000A\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(Q), "m"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.IB(TextCompositionEventArgs, TextBox)).MethodHandle;
				}
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "m"))
				{
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
			}
			if (!\u000A\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(Q), "mm"))
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
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "m"))
				{
					return;
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "mm"))
				{
					return;
				}
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			if (!\u000A\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(Q), "in"))
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
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "i"))
				{
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
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "in"))
				{
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
			}
			if (!\u000A\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(Q), "."))
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
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "."))
				{
					return;
				}
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			double num;
			if (!\u0005\u0020\u0003.\u0018(\u000E\u0020\u0003.\u0018(P), ref num))
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
				\u001D\u000B\u0018.\u0018(P, true);
			}
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x0002D0D4 File Offset: 0x0002B2D4
		private void TxtX_KeyUp(object sender, KeyEventArgs e)
		{
			DwfOptions.SB(\u0018\u0004\u000F.\u000C(sender), this.P);
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x0002D0F4 File Offset: 0x0002B2F4
		private void TxtY_KeyUp(object sender, KeyEventArgs e)
		{
			DwfOptions.SB(\u0018\u0004\u000F.\u000C(sender), this.P);
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0002D114 File Offset: 0x0002B314
		private static void SB(TextBox P, Document Q)
		{
			string text = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0001\u000B\u0018.\u0018(P), "m", ""), "i", ""), "n", "");
			bool flag = \u000E\u0013\u0003.\u0018(Q);
			string u000C = text;
			string u;
			if (!flag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.SB(TextBox, Document)).MethodHandle;
				}
				u = "in";
			}
			else
			{
				u = "mm";
			}
			\u0012\u000B\u0018.\u0018(P, \u000D\u001E\u0018.\u0018(u000C, u));
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0002D198 File Offset: 0x0002B398
		private void chkExportObjectData_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.C, true);
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x0002D1B4 File Offset: 0x0002B3B4
		private void chkExportObjectData_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.C, false);
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x0002D1D0 File Offset: 0x0002B3D0
		private void txtCombineFileName_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			List<char> u000C = Enumerable.ToList<char>(\u0008\u001A\u0018.\u0018());
			string u000C2 = \u000E\u0020\u0003.\u0018(e);
			for (int i = 0; i < \u001C\u0002\u0018.\u0014(u000C2); i++)
			{
				char u = \u0002\u0001\u0018.\u0014(u000C2, i);
				if (\u000C\u001F\u0003.\u0018(u000C, u))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(DwfOptions.txtCombineFileName_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
					}
					\u001D\u000B\u0018.\u0018(e, true);
					return;
				}
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
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0002D244 File Offset: 0x0002B444
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x0002D26C File Offset: 0x0002B46C
		private void BtnCustomizeFileName_Click(object sender, RoutedEventArgs e)
		{
			this.J = \u0018\u001F\u0003.\u0018(this.J, \u0005\u0007\u0018.\u0018(this));
		}

		// Token: 0x0400033D RID: 829
		private Document P;

		// Token: 0x0400033E RID: 830
		private ParameterBaseModel Q;

		// Token: 0x0400033F RID: 831
		private CustomParameterModel J;
	}
}
