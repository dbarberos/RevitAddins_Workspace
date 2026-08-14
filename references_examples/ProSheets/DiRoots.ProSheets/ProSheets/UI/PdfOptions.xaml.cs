using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.ProSheets.UI;
using DiRoots.ProSheets.ViewModels;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using Xceed.Wpf.Toolkit;

namespace ProSheets.UI
{
	// Token: 0x0200008E RID: 142
	public partial class PdfOptions : BaseUserControl
	{
		// Token: 0x060008C2 RID: 2242 RVA: 0x00035780 File Offset: 0x00033980
		public PdfOptions(Document inputDoc, ParameterBaseModel parameterBaseModel)
		{
			\u000E\u0019\u0003.\u0018(this);
			this.WJ = parameterBaseModel;
			List<IParameterModel> u = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0007\u0003\u0003.\u0018(this.WJ)));
			this.TJ = new CustomParameterModel();
			\u001B\u0013\u0003.\u0018(this.TJ, u);
			\u0005\u0019\u0003.\u0018(this, inputDoc);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x000357F8 File Offset: 0x000339F8
		public void loadPrintConfig(Document objDoc)
		{
			this.OJ = true;
			this.YB = objDoc;
			PSCommand.objFlag = false;
			\u0003\u0019\u0018.\u0018(this.EJ, \u0019\u0009\u0018.\u0014());
			\u0009\u0019\u0018.\u0018(this.EJ, 0);
			\u0003\u0019\u0018.\u0018(this.HF, \u0019\u0009\u0018.\u000F());
			\u0003\u0019\u0018.\u0018(this.NF, \u0019\u0009\u0018.\u0012());
			\u0003\u0019\u0018.\u0018(this.VF, \u0019\u0009\u0018.\u000D());
			if (\u0002\u000D\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.VF)) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.loadPrintConfig(Document)).MethodHandle;
				}
				\u0014\u0019\u0018.\u0018(this.VF, false);
			}
			\u0008\u0013\u0014.\u0018(this.UF, Visibility.Collapsed);
			\u0008\u0013\u0014.\u0018(this.LF, Visibility.Visible);
			\u0014\u0019\u0018.\u0018(this.EF, false);
			bool flag = \u000C\u0007\u0003.\u0018(this.YB);
			object gj = this.GJ;
			string u000C = "0.00";
			string u;
			if (!flag)
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
				u = "in";
			}
			else
			{
				u = "mm";
			}
			\u0012\u000B\u0018.\u0018(gj, \u000D\u001E\u0018.\u0018(u000C, u));
			object aj = this.AJ;
			string u000C2 = "0.00";
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
			\u0012\u000B\u0018.\u0018(aj, \u000D\u001E\u0018.\u0018(u000C2, u2));
			\u0007\u0018\u0003.\u0018(this.LJ, new bool?(false));
			\u0007\u0018\u0003.\u0018(this.UJ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.DJ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.FF, new bool?(false));
			\u0007\u0018\u0003.\u0018(this.JF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.IF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.MF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.XF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.YF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.OF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.CF, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.TF, new bool?(false));
			try
			{
				if (\u0014\u001F\u0018.\u0003())
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
					\u001C\u0010\u0014.\u0018(\u0005\u0003\u0014.\u0018(this.YB), \u0002\u001A\u0014.\u0018());
					\u0019\u0007\u0014.\u0018(\u0005\u0003\u0014.\u0018(this.YB));
					PdfOptions.objPaperSizeSet = \u0019\u0009\u0018.\u0018(this.YB);
				}
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\PdfOptions.xaml.cs", "loadPrintConfig");
			}
			this.OJ = false;
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00035A84 File Offset: 0x00033C84
		public static bool IsMetric(Document doc)
		{
			bool result = false;
			\u0019\u0004\u0018.\u0018(doc);
			if (\u000F\u0009\u0003.\u0018(doc) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.IsMetric(Document)).MethodHandle;
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00035ABC File Offset: 0x00033CBC
		internal void BH(ExportTemPlateInfo P)
		{
			PdfOptions.\u0003\u0020\u0018 u0003_u0020_u = new PdfOptions.\u0003\u0020\u0018();
			u0003_u0020_u.\u000C = P;
			this.QH(u0003_u0020_u.\u000C);
			if (!\u000C\u0011\u0014.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.BH(ExportTemPlateInfo)).MethodHandle;
				}
				return;
			}
			EnumInfo enumInfo = Enumerable.FirstOrDefault<EnumInfo>(Enumerable.Cast<EnumInfo>(\u000D\u000F\u0014.\u0018(this.VF)), new Func<EnumInfo, bool>(u0003_u0020_u.\u0018));
			if (enumInfo != null)
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
				\u0016\u0007\u0018.\u0018(this.VF, enumInfo);
			}
			else
			{
				\u0009\u0019\u0018.\u0018(this.VF, 0);
			}
			string text = Enumerable.FirstOrDefault<string>(Enumerable.Cast<string>(\u000D\u000F\u0014.\u0018(this.KF)), new Func<string, bool>(u0003_u0020_u.\u0014));
			if (text != null)
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
				\u0016\u0007\u0018.\u0018(this.KF, text);
			}
		}

		// Token: 0x060008C7 RID: 2247 RVA: 0x00035B90 File Offset: 0x00033D90
		private void QH(ExportTemPlateInfo P)
		{
			this.OJ = true;
			List<IParameterModel> u000C = Enumerable.ToList<IParameterModel>(Enumerable.OfType<IParameterModel>(\u0007\u0003\u0003.\u0018(this.WJ)));
			if (\u000B\u0007\u0003.\u0018(P) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.QH(ExportTemPlateInfo)).MethodHandle;
				}
				\u0019\u0007\u0003.\u0018(P, \u0019\u0003\u0003.\u0018(string.Empty, \u000D\u001F\u0018.\u0018(u000C, \u0009\u0003\u0003.\u0014(P))));
			}
			\u000D\u001F\u0018.\u000C(u000C, \u000B\u0007\u0003.\u0018(P));
			\u0020\u0009\u0003.\u0014(this.TJ, \u000B\u0007\u0003.\u0018(P));
			\u0007\u0018\u0003.\u0018(this.UJ, new bool?(\u001A\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.LJ, new bool?(!\u001A\u0007\u0003.\u0018(P)));
			\u001D\u0009\u0003.\u0018(this.EJ, \u001D\u0007\u0003.\u0018(P));
			this.FH();
			bool flag = \u000C\u0007\u0003.\u0018(this.YB);
			string text = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0004\u0007\u0003.\u0018(P), "mm", ""), "in", "");
			string text2 = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0002\u0007\u0003.\u0018(P), "mm", ""), "in", "");
			object gj = this.GJ;
			string u000C2 = text;
			string u;
			if (!flag)
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
				u = "in";
			}
			else
			{
				u = "mm";
			}
			\u0012\u000B\u0018.\u0018(gj, \u000D\u001E\u0018.\u0018(u000C2, u));
			object aj = this.AJ;
			string u000C3 = text2;
			string u2;
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
				u2 = "in";
			}
			else
			{
				u2 = "mm";
			}
			\u0012\u000B\u0018.\u0018(aj, \u000D\u001E\u0018.\u0018(u000C3, u2));
			if (\u001E\u0007\u0003.\u0018(P))
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
				\u0007\u0018\u0003.\u0018(this.DJ, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.KJ, new bool?(true));
			}
			\u0008\u0020\u0003.\u0018(this.PF, new int?(\u0017\u0007\u0003.\u0018(P)));
			if (\u0015\u0007\u0003.\u0018(P))
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
				\u0007\u0018\u0003.\u0018(this.JF, new bool?(true));
			}
			else
			{
				\u0007\u0018\u0003.\u0018(this.FF, new bool?(true));
			}
			\u0016\u0007\u0018.\u0018(this.HF, this.HF.\u0016(\u0011\u0007\u0003.\u0018(P)));
			\u001D\u0009\u0003.\u0018(this.NF, \u001F\u0007\u0003.\u0018(P));
			\u0007\u0018\u0003.\u0018(this.MF, new bool?(\u0020\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.XF, new bool?(\u000A\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.YF, new bool?(\u0009\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.OF, new bool?(\u0013\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.CF, new bool?(\u001C\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.WF, new bool?(\u000D\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.UF, new bool?(\u0012\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.LF, new bool?(\u000F\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.IF, new bool?(\u0018\u0007\u0003.\u0018(P)));
			\u0007\u0018\u0003.\u0018(this.TF, new bool?(\u0016\u0007\u0003.\u0018(P)));
			\u0009\u0009\u0003.\u0014(this.TJ, \u0003\u0007\u0003.\u0018(P));
			if (\u0013\u0009\u0003.\u0014(this.TJ))
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
				\u0012\u0009\u0003.\u0014(this.TJ, \u0014\u0007\u0003.\u0018(P));
			}
			if (!\u0018\u0007\u0003.\u0018(P))
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
				\u0007\u0018\u0003.\u0018(this.SF, new bool?(true));
			}
			this.JH();
			this.OJ = false;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00035F48 File Offset: 0x00034148
		private void JH()
		{
			bool? flag = \u001B\u0001\u0018.\u0018(this.SF);
			bool flag2 = \u000C\u0007\u0018.\u0018(ref flag);
			\u0014\u0019\u0018.\u0018(this.UF, flag2);
			\u0014\u0019\u0018.\u0018(this.LF, flag2);
			object gf = this.GF;
			bool u;
			if (flag2)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.JH()).MethodHandle;
				}
				flag = \u001B\u0001\u0018.\u0018(this.UF);
				bool flag3 = false;
				u = (\u000C\u0007\u0018.\u0018(ref flag) == flag3 & \u0006\u0007\u0003.\u0018(ref flag));
			}
			else
			{
				u = false;
			}
			\u0014\u0019\u0018.\u0018(gf, u);
			flag = \u001B\u0001\u0018.\u0018(this.UF);
			\u0010\u0007\u0003.\u0018(\u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.LF);
			\u0007\u0007\u0003.\u0018(\u000F\u0014\u0003.\u0018(ref flag));
			\u0008\u0013\u0014.\u0018(this.UF, Visibility.Collapsed);
			\u0008\u0013\u0014.\u0018(this.LF, Visibility.Visible);
			\u0014\u0019\u0018.\u0018(this.GF, flag2);
			if (\u000D\u0007\u0018.\u0018(this.VF) == 1)
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
				\u0008\u0013\u0014.\u0018(this.UF, Visibility.Collapsed);
				\u0008\u0013\u0014.\u0018(this.LF, Visibility.Collapsed);
			}
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00036060 File Offset: 0x00034260
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			this.OJ = true;
			\u0019\u0007\u0003.\u0018(templateInfo, \u001C\u000A\u0003.\u0014(this.TJ));
			bool? flag = \u001B\u0001\u0018.\u0018(this.UJ);
			\u0002\u0010\u0003.\u0018(templateInfo, \u000C\u0007\u0018.\u0018(ref flag));
			object obj = \u001E\u000A\u0003.\u0018(this.EJ);
			string u;
			if (obj == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.GetPrintConfig(ExportTemPlateInfo)).MethodHandle;
				}
				u = \u0005\u001E\u000F.\u000C;
			}
			else
			{
				u = \u0001\u0017\u0018.\u0018(obj);
			}
			\u001E\u0010\u0003.\u0018(templateInfo, u);
			\u0017\u0010\u0003.\u0018(templateInfo, \u0001\u000B\u0018.\u0018(this.GJ));
			\u0015\u0010\u0003.\u0018(templateInfo, \u0001\u000B\u0018.\u0018(this.AJ));
			\u0011\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.DJ)));
			int? num = \u001F\u0020\u0003.\u0018(this.PF);
			\u0020\u0010\u0003.\u0018(templateInfo, \u001F\u0010\u0003.\u0018(ref num));
			\u000A\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.JF)));
			if (\u0012\u0007\u0018.\u0018(this.HF) != null)
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
				\u0009\u0010\u0003.\u0018(templateInfo, \u0012\u0007\u0018.\u0018(this.HF).\u0018());
			}
			if (\u0012\u0007\u0018.\u0018(this.NF) != null)
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
				\u0013\u0010\u0003.\u0018(templateInfo, \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.NF)));
			}
			\u001C\u0010\u0003.\u0018(templateInfo, \u0013\u0009\u0003.\u0014(this.TJ));
			if (\u0013\u0009\u0003.\u0014(this.TJ))
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
				\u000D\u0010\u0003.\u0018(templateInfo, \u0012\u000A\u0003.\u0014(this.TJ));
			}
			\u0012\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.MF)));
			\u000F\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.XF)));
			\u0016\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.YF)));
			\u0003\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.OF)));
			\u0014\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.CF)));
			\u0018\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.WF)));
			\u000C\u0010\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.IF)));
			\u000E\u0007\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.TF)));
			\u0005\u0007\u0003.\u0018(templateInfo, \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.UF)));
			flag = \u001B\u0001\u0018.\u0018(this.LF);
			\u001B\u0007\u0003.\u0018(templateInfo, \u000C\u0007\u0018.\u0018(ref flag));
			\u0001\u0007\u0003.\u0018(templateInfo, \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.VF)));
			object obj2 = \u001E\u000A\u0003.\u0018(this.KF);
			string u2;
			if (obj2 == null)
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
				u2 = \u0005\u001E\u000F.\u000C;
			}
			else
			{
				u2 = \u0001\u0017\u0018.\u0018(obj2);
			}
			\u0008\u0007\u0003.\u0018(templateInfo, u2);
			this.OJ = false;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00036388 File Offset: 0x00034588
		public void getPDFControlValues()
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\PdfOptions.xaml.cs", "getPDFControlValues");
				\u0016\u0006\u0003.\u0018(\u0002\u001A\u0014.\u0018());
				bool? flag;
				try
				{
					flag = \u001B\u0001\u0018.\u0018(this.UJ);
					if (\u000C\u0007\u0018.\u0018(ref flag))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.getPDFControlValues()).MethodHandle;
						}
						\u0003\u0006\u0003.\u0018(0);
					}
					else
					{
						\u0003\u0006\u0003.\u0018(1);
						if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.EJ)), "No Margin"))
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
							\u0014\u0006\u0003.\u0018(0);
						}
						else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.EJ)), "Printer Limit"))
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
							\u0014\u0006\u0003.\u0018(1);
						}
						else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.EJ)), "User Defined"))
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
							\u0014\u0006\u0003.\u0018(2);
							bool flag2 = \u000C\u0007\u0003.\u0018(this.YB);
							string u000C = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0001\u000B\u0018.\u0018(this.GJ), "mm", ""), "in", "");
							if (\u001F\u001A\u0018.\u0018(u000C))
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
								\u0018\u0006\u0003.\u0018(0.0);
							}
							else if (flag2)
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
								\u0018\u0006\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C));
							}
							else
							{
								\u0018\u0006\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C) * 25.4);
							}
							u000C = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0001\u000B\u0018.\u0018(this.AJ), "mm", ""), "in", "");
							if (\u001F\u001A\u0018.\u0018(u000C))
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
								\u000C\u0006\u0003.\u0018(0.0);
							}
							else if (flag2)
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
								\u000C\u0006\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C));
							}
							else
							{
								\u000C\u0006\u0003.\u0018(\u0007\u001C\u0003.\u0018(u000C) * 25.4);
							}
						}
					}
				}
				catch (Exception u)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\PdfOptions.xaml.cs", "getPDFControlValues");
				}
				flag = \u001B\u0001\u0018.\u0018(this.DJ);
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
					\u000E\u0010\u0003.\u0018(0);
				}
				else
				{
					\u000E\u0010\u0003.\u0018(1);
					\u0005\u0010\u0003.\u0018(\u0001\u000F\u0014.\u0018(\u001F\u0020\u0003.\u0018(this.PF)));
					if (\u000F\u0006\u0014.\u0018() <= 0)
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
						\u0005\u0010\u0003.\u0018(100);
					}
				}
				flag = \u001B\u0001\u0018.\u0018(this.JF);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
					\u001B\u0010\u0003.\u0018(0);
				}
				else
				{
					\u001B\u0010\u0003.\u0018(1);
				}
				\u0001\u0010\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.HF).\u0018());
				if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.NF)), "Color"))
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
					\u0008\u0010\u0003.\u0018(2);
				}
				else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.NF)), "Gray Scale"))
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
					\u0008\u0010\u0003.\u0018(1);
				}
				else if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.NF)), "Black Line"))
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
					\u0008\u0010\u0003.\u0018(0);
				}
				\u0006\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.MF)));
				\u0010\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.XF)));
				\u0007\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.YF)));
				\u0019\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.OF)));
				\u000B\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.CF)));
				\u001A\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.WF)));
				\u001D\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.TF)));
				\u0004\u0010\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.SF)));
				flag = \u001B\u0001\u0018.\u0018(this.LF);
				\u0007\u0007\u0003.\u0018(\u000C\u0007\u0018.\u0018(ref flag));
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\PdfOptions.xaml.cs", "getPDFControlValues");
			}
			catch (Exception u2)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\PdfOptions.xaml.cs", "getPDFControlValues");
			}
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00036890 File Offset: 0x00034A90
		private void RdbCenter_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.EJ, false);
			\u0007\u0018\u0003.\u0018(this.LJ, new bool?(false));
			\u0014\u0019\u0018.\u0018(this.GJ, false);
			\u0014\u0019\u0018.\u0018(this.AJ, false);
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x000368D4 File Offset: 0x00034AD4
		private void RdbOffsetFromCorner_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.EJ, true);
			\u0007\u0018\u0003.\u0018(this.UJ, new bool?(false));
			this.FH();
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00036904 File Offset: 0x00034B04
		private void CmbOffsetFromCorner_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			this.FH();
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00036918 File Offset: 0x00034B18
		private void FH()
		{
			try
			{
				if (\u000F\u0002\u0018.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.EJ)), "User Defined"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.FH()).MethodHandle;
					}
					\u0014\u0019\u0018.\u0018(this.GJ, true);
					\u0014\u0019\u0018.\u0018(this.AJ, true);
				}
				else
				{
					\u0014\u0019\u0018.\u0018(this.GJ, false);
					\u0014\u0019\u0018.\u0018(this.AJ, false);
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\PdfOptions.xaml.cs", "CheckForUserDefined");
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x000369B8 File Offset: 0x00034BB8
		private void RdbFitToPage_Checked(object sender, RoutedEventArgs e)
		{
			\u0007\u0018\u0003.\u0018(this.KJ, new bool?(false));
			\u0008\u0013\u0014.\u0018(this.PF, Visibility.Hidden);
			\u0008\u0013\u0014.\u0018(this.BF, Visibility.Hidden);
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x000369F0 File Offset: 0x00034BF0
		private void RdbZoom_Checked(object sender, RoutedEventArgs e)
		{
			\u0007\u0018\u0003.\u0018(this.DJ, new bool?(false));
			\u0008\u0013\u0014.\u0018(this.PF, Visibility.Visible);
			\u0008\u0013\u0014.\u0018(this.BF, Visibility.Visible);
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00036A28 File Offset: 0x00034C28
		private void MyUpDownControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			int? num = \u001F\u0020\u0003.\u0018(this.PF);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.MyUpDownControl_ValueChanged(object, RoutedPropertyChangedEventArgs<object>)).MethodHandle;
				}
				\u0008\u0020\u0003.\u0018(this.PF, new int?(100));
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00036A88 File Offset: 0x00034C88
		private void RdbSeparateFile_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.EF, false);
			Export.isPDFCombineFile = false;
			this.JH();
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00036AB0 File Offset: 0x00034CB0
		private void RdbCombineFile_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.EF, true);
			Export.isPDFCombineFile = true;
			this.JH();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00036AD8 File Offset: 0x00034CD8
		private void TxtX_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			TextBox q = \u0018\u0004\u000F.\u000C(sender);
			PdfOptions.RH(e, q);
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00036AF8 File Offset: 0x00034CF8
		private void TxtY_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			TextBox q = \u0018\u0004\u000F.\u000C(sender);
			PdfOptions.RH(e, q);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x00036B18 File Offset: 0x00034D18
		private static void RH(TextCompositionEventArgs P, TextBox Q)
		{
			if (!\u000A\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(Q), "m"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.RH(TextCompositionEventArgs, TextBox)).MethodHandle;
				}
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "m"))
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
					switch (4)
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
					switch (7)
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
					switch (5)
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
					switch (7)
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
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			if (!\u000A\u0017\u0014.\u0018(\u0001\u000B\u0018.\u0018(Q), "-"))
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
				if (\u000F\u0002\u0018.\u0018(\u000E\u0020\u0003.\u0018(P), "-"))
				{
					return;
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
			double num;
			if (!\u0005\u0020\u0003.\u0018(\u000E\u0020\u0003.\u0018(P), ref num))
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
				\u001D\u000B\u0018.\u0018(P, true);
			}
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00036CE4 File Offset: 0x00034EE4
		private void TxtX_KeyUp(object sender, KeyEventArgs e)
		{
			PdfOptions.HH(\u0018\u0004\u000F.\u000C(sender), this.YB);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00036D04 File Offset: 0x00034F04
		private void TxtY_KeyUp(object sender, KeyEventArgs e)
		{
			PdfOptions.HH(\u0018\u0004\u000F.\u000C(sender), this.YB);
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x00036D24 File Offset: 0x00034F24
		private static void HH(TextBox P, Document Q)
		{
			string text = \u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0010\u000B\u0014.\u0018(\u0001\u000B\u0018.\u0018(P), "m", ""), "i", ""), "n", "");
			bool flag = \u000C\u0007\u0003.\u0018(Q);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.HH(TextBox, Document)).MethodHandle;
				}
				u = "in";
			}
			else
			{
				u = "mm";
			}
			\u0012\u000B\u0018.\u0018(P, \u000D\u001E\u0018.\u0018(u000C, u));
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x00036DA8 File Offset: 0x00034FA8
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
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.txtCombineFileName_PreviewTextInput(object, TextCompositionEventArgs)).MethodHandle;
					}
					\u001D\u000B\u0018.\u0018(e, true);
					return;
				}
			}
			for (;;)
			{
				switch (7)
				{
				case 0:
					continue;
				}
				break;
			}
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00036E1C File Offset: 0x0003501C
		private void btnOrderSheetsViews_Click(object sender, RoutedEventArgs e)
		{
			OrderBaseModel<SheetInfo> u000C = \u0012\u0006\u0003.\u0018(\u0010\u000E\u0018.\u0018());
			UI_OrderPdf u000C2 = \u000F\u0006\u0003.\u0018(u000C);
			\u0012\u000A\u0014.\u0018(u000C2, this);
			bool? flag = \u001E\u0007\u0018.\u0014(u000C2);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.btnOrderSheetsViews_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u000E\u000C\u0003.\u0018(Enumerable.ToList<SheetInfo>(\u0003\u0009\u0014.\u0018(u000C)));
			}
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00036E84 File Offset: 0x00035084
		private void ChkJumpToSection_Checked(object sender, RoutedEventArgs e)
		{
			\u0010\u0007\u0003.\u0018(true);
			if (!this.OJ)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.ChkJumpToSection_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				\u001B\u0003\u0014.\u0018(\u001C\u0009\u0018.\u0004\u0016, this, 400.0);
			}
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00036ECC File Offset: 0x000350CC
		private void ChkJumpToSection_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0010\u0007\u0003.\u0018(false);
			\u0014\u0019\u0018.\u0018(this.GF, true);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00036EEC File Offset: 0x000350EC
		private void ChkKeepSizAndOrientation_Click(object sender, RoutedEventArgs e)
		{
			bool? flag = \u001B\u0001\u0018.\u0018(this.LF);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.ChkKeepSizAndOrientation_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0007\u0007\u0003.\u0018(true);
				\u001B\u0003\u0014.\u0018(\u001C\u0009\u0018.\u001D\u0016, this, 350.0);
				return;
			}
			\u0007\u0007\u0003.\u0018(false);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00036F4C File Offset: 0x0003514C
		private void cmbPrinter_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.VF != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.cmbPrinter_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				if (\u0008\u0012\u0014.\u0018(this.VF) != null)
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
					if (\u000D\u0007\u0018.\u0018(this.VF) == -1)
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
					}
					else
					{
						\u001C\u0006\u0003.\u0018(\u001C\u001D\u0003.\u0003(\u000D\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.VF))));
						if (this.NH())
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
							\u0007\u0018\u0003.\u0018(this.UF, new bool?(false));
							\u0008\u0013\u0014.\u0018(this.DF, Visibility.Visible);
						}
						else
						{
							\u0008\u0013\u0014.\u0018(this.DF, Visibility.Collapsed);
						}
						this.JH();
						if (!this.NH())
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
							\u000D\u0006\u0003.\u0018(this, true);
							return;
						}
						if (this.CJ == null)
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
							this.CJ = \u000A\u0020\u0018.\u0014(this.YB);
						}
						IEnumerable<ExportPDFSettings> cj = this.CJ;
						Func<ExportPDFSettings, string> func;
						if ((func = PdfOptions.<>c.\u0018) == null)
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
							func = (PdfOptions.<>c.\u0018 = new Func<ExportPDFSettings, string>(PdfOptions.<>c.\u000C.\u0003));
						}
						List<string> list = Enumerable.ToList<string>(Enumerable.Select<ExportPDFSettings, string>(cj, func));
						\u0002\u000B\u0014.\u0018(list, 0, \u000D\u0009\u0018.\u0004\u0014);
						\u0003\u0019\u0018.\u0018(this.KF, list);
						\u0009\u0019\u0018.\u0018(this.KF, 0);
						return;
					}
				}
			}
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x000370B4 File Offset: 0x000352B4
		private bool NH()
		{
			EnumInfo enumInfo = \u000D\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.VF));
			string u000C;
			if (enumInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.NH()).MethodHandle;
				}
				u000C = null;
			}
			else
			{
				u000C = \u001C\u001D\u0003.\u0014(enumInfo);
			}
			return \u000F\u0002\u0018.\u0018(u000C, "Revit Native");
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00037104 File Offset: 0x00035304
		private void CmbSetup_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			PdfOptions.\u0018\u0020\u0018 u0018_u0020_u = new PdfOptions.\u0018\u0020\u0018();
			u0018_u0020_u.\u000C = this;
			if (\u000D\u0007\u0018.\u0018(this.KF) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.CmbSetup_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				\u000D\u0006\u0003.\u0018(this, true);
				return;
			}
			ExportPDFSettings exportPDFSettings = \u0006\u0006\u0003.\u0018(this.CJ, new Predicate<ExportPDFSettings>(u0018_u0020_u.\u0014));
			if (exportPDFSettings == null)
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
				return;
			}
			\u000D\u0006\u0003.\u0018(this, false);
			u0018_u0020_u.\u0018 = \u0010\u0006\u0003.\u0018(exportPDFSettings);
			ExportTemPlateInfo exportTemPlateInfo = \u0003\u0020\u0014.\u0018();
			\u0002\u0010\u0003.\u0018(exportTemPlateInfo, \u0007\u0006\u0003.\u0018(u0018_u0020_u.\u0018) == 0);
			object u000C = exportTemPlateInfo;
			double num = this.ZH(\u0019\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0017\u0010\u0003.\u0018(u000C, \u000D\u0005\u0014.\u0018(ref num));
			object u000C2 = exportTemPlateInfo;
			num = this.ZH(\u000B\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0015\u0010\u0003.\u0018(u000C2, \u000D\u0005\u0014.\u0018(ref num));
			if (\u0019\u0006\u0003.\u0018(u0018_u0020_u.\u0018) == 0.0)
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
				if (\u000B\u0006\u0003.\u0018(u0018_u0020_u.\u0018) == 0.0)
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
					\u001E\u0010\u0003.\u0018(exportTemPlateInfo, "No Margin");
					goto IL_138;
				}
			}
			\u001E\u0010\u0003.\u0018(exportTemPlateInfo, "User Defined");
			IL_138:
			\u0011\u0010\u0003.\u0018(exportTemPlateInfo, \u001A\u0006\u0003.\u0018(u0018_u0020_u.\u0018) == 0);
			\u0020\u0010\u0003.\u0018(exportTemPlateInfo, \u001D\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u000A\u0010\u0003.\u0018(exportTemPlateInfo, !\u0004\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0009\u0010\u0003.\u0018(exportTemPlateInfo, \u0002\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0013\u0010\u0003.\u0018(exportTemPlateInfo, \u001E\u0006\u0003.\u0018(Enumerable.First<EnumInfo>(\u0019\u0009\u0018.\u0012(), new Func<EnumInfo, bool>(u0018_u0020_u.\u0003))));
			\u0012\u0010\u0003.\u0018(exportTemPlateInfo, \u0017\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u000F\u0010\u0003.\u0018(exportTemPlateInfo, \u0015\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0016\u0010\u0003.\u0018(exportTemPlateInfo, \u0011\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0003\u0010\u0003.\u0018(exportTemPlateInfo, \u001F\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0014\u0010\u0003.\u0018(exportTemPlateInfo, \u0020\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0018\u0010\u0003.\u0018(exportTemPlateInfo, \u000A\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u000E\u0007\u0003.\u0018(exportTemPlateInfo, \u0009\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			\u0005\u0007\u0003.\u0018(exportTemPlateInfo, false);
			\u000C\u0010\u0003.\u0018(exportTemPlateInfo, !\u0013\u0006\u0003.\u0018(u0018_u0020_u.\u0018));
			this.QH(exportTemPlateInfo);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x0003736C File Offset: 0x0003556C
		public void UpdateControlEnableState(bool isEnabled)
		{
			\u0014\u0019\u0018.\u0018(this.SJ, isEnabled);
			\u0014\u0019\u0018.\u0018(this.VJ, isEnabled);
			\u0014\u0019\u0018.\u0018(this.QF, isEnabled);
			\u0014\u0019\u0018.\u0018(this.RF, isEnabled);
			\u0014\u0019\u0018.\u0018(this.ZF, isEnabled);
			\u0014\u0019\u0018.\u0018(this.IF, isEnabled);
			\u0014\u0019\u0018.\u0018(this.SF, isEnabled);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x000373D0 File Offset: 0x000355D0
		private double ZH(double P)
		{
			ForgeTypeId u;
			if (!\u000C\u0007\u0003.\u0018(this.YB))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.ZH(double)).MethodHandle;
				}
				u = \u001B\u0006\u0003.\u0018();
			}
			else
			{
				u = \u0001\u0006\u0003.\u0018();
			}
			return \u0008\u0006\u0003.\u0018(P, u);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x00037418 File Offset: 0x00035618
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00037440 File Offset: 0x00035640
		private void BtnCustomizeFileName_Click(object sender, RoutedEventArgs e)
		{
			this.TJ = \u0018\u001F\u0003.\u0018(this.TJ, \u0005\u0007\u0018.\u0018(this));
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00037468 File Offset: 0x00035668
		internal void PH()
		{
			\u0005\u0006\u0003.\u0018(\u0008\u0020\u0018.\u000C(\u001C\u000A\u0003.\u0014(this.TJ), \u0012\u000A\u0003.\u0014(this.TJ), \u0013\u0009\u0003.\u0014(this.TJ)));
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x000374A8 File Offset: 0x000356A8
		protected override void ApplyLicense(bool isLicenseValid)
		{
			PdfOptions.\u0014\u0020\u0018 u0014_u0020_u = new PdfOptions.\u0014\u0020\u0018();
			u0014_u0020_u.\u000C = isLicenseValid;
			List<EnumInfo> list = Enumerable.ToList<EnumInfo>(Enumerable.Cast<EnumInfo>(\u000D\u000F\u0014.\u0018(this.VF)));
			IEnumerable<EnumInfo> enumerable = list;
			Func<EnumInfo, bool> func;
			if ((func = PdfOptions.<>c.\u0014) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PdfOptions.ApplyLicense(bool)).MethodHandle;
				}
				func = (PdfOptions.<>c.\u0014 = new Func<EnumInfo, bool>(PdfOptions.<>c.\u000C.\u0016));
			}
			\u000E\u0006\u0003.\u0018(Enumerable.ToList<EnumInfo>(Enumerable.Where<EnumInfo>(enumerable, func)), new Action<EnumInfo>(u0014_u0020_u.\u0018));
			\u0003\u0019\u0018.\u0018(this.VF, list);
			if (!u0014_u0020_u.\u000C)
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
				\u0009\u0019\u0018.\u0018(this.VF, 0);
			}
		}

		// Token: 0x040003EF RID: 1007
		private Document YB;

		// Token: 0x040003F0 RID: 1008
		private bool OJ;

		// Token: 0x040003F1 RID: 1009
		private List<ExportPDFSettings> CJ;

		// Token: 0x040003F2 RID: 1010
		private ParameterBaseModel WJ;

		// Token: 0x040003F3 RID: 1011
		public static List<PaperSize> objPaperSizeSet = \u0003\u0002\u0014.\u0018();

		// Token: 0x040003F4 RID: 1012
		private CustomParameterModel TJ;

		// Token: 0x020001AB RID: 427
		[CompilerGenerated]
		private sealed class \u0018\u0020\u0018
		{
			// Token: 0x06001179 RID: 4473 RVA: 0x0005CB1C File Offset: 0x0005AD1C
			internal bool \u0014(ExportPDFSettings \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001E\u0016\u0014.\u0018(\u000C), \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.\u000C.KF)));
			}

			// Token: 0x0600117A RID: 4474 RVA: 0x0005CB54 File Offset: 0x0005AD54
			internal bool \u0003(EnumInfo \u000C)
			{
				return \u0014\u0002\u0016.\u0018(\u000C) == \u000F\u001F\u000F.\u0018(this.\u0018);
			}

			// Token: 0x04000834 RID: 2100
			public PdfOptions \u000C;

			// Token: 0x04000835 RID: 2101
			public PDFExportOptions \u0018;
		}

		// Token: 0x020001AC RID: 428
		[CompilerGenerated]
		private sealed class \u0014\u0020\u0018
		{
			// Token: 0x0600117C RID: 4476 RVA: 0x0005CB8C File Offset: 0x0005AD8C
			internal void \u0018(EnumInfo \u000C)
			{
				\u0012\u001F\u000F.\u0018(\u000C, this.\u000C);
			}

			// Token: 0x04000836 RID: 2102
			public bool \u000C;
		}

		// Token: 0x020001AD RID: 429
		[CompilerGenerated]
		private sealed class \u0003\u0020\u0018
		{
			// Token: 0x0600117E RID: 4478 RVA: 0x0005CBBC File Offset: 0x0005ADBC
			internal bool \u0018(EnumInfo \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001C\u001D\u0003.\u0003(\u000C), \u0004\u0012\u0016.\u0018(this.\u000C));
			}

			// Token: 0x0600117F RID: 4479 RVA: 0x0005CBE8 File Offset: 0x0005ADE8
			internal bool \u0014(string \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000C, \u000D\u001F\u000F.\u0018(this.\u000C));
			}

			// Token: 0x04000837 RID: 2103
			public ExportTemPlateInfo \u000C;
		}
	}
}
