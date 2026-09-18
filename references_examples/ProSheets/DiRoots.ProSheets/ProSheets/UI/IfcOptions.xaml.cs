using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using BIM.IFC.Export;
using BIM.IFC.Export.UI;
using DiRoots.One.Commons.Interfaces;
using Microsoft.Win32;
using ProSheets.Enums;
using ProSheets.Helpers;
using ProSheets.Models;
using Revit.IFC.Common.Extensions;

namespace ProSheets.UI
{
	// Token: 0x0200008B RID: 139
	public partial class IfcOptions : UserControl
	{
		// Token: 0x0600087E RID: 2174 RVA: 0x00030224 File Offset: 0x0002E424
		public IfcOptions(Document inputDoc)
		{
			\u0016\u0017\u0003.\u0018(this);
			this.J = new List<IFCExportConfiguration>();
			\u0003\u0017\u0003.\u0018(this, inputDoc);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00030270 File Offset: 0x0002E470
		public void loadConfig(Document objDoc)
		{
			this.P = objDoc;
			PSCommand.objFlag = false;
			\u0003\u0019\u0018.\u0018(this.Y, this.RQ());
			\u0009\u0019\u0018.\u0018(this.Y, 0);
			\u0003\u0019\u0018.\u0018(this.W, \u000A\u0017\u0003.\u0018(this));
			\u0009\u0019\u0018.\u0018(this.W, 0);
			\u0009\u0017\u0003.\u0018(this);
			\u0003\u0019\u0018.\u0018(this.T, this.Q);
			\u0009\u0019\u0018.\u0018(this.T, 0);
			List<EnumInfo> u = \u0013\u0017\u0003.\u0018(this);
			\u0003\u0019\u0018.\u0018(this.M, \u001C\u0017\u0003.\u0018(this, u));
			\u0009\u0019\u0018.\u0018(this.M, 0);
			\u0003\u0019\u0018.\u0018(this.S, u);
			\u0009\u0019\u0018.\u0018(this.S, 0);
			\u0003\u0019\u0018.\u0018(this.I, \u000D\u0017\u0003.\u0018(this));
			\u0009\u0019\u0018.\u0018(this.I, 0);
			\u0003\u0019\u0018.\u0018(this.QB, \u0012\u0017\u0003.\u0018(this));
			\u0009\u0019\u0018.\u0018(this.QB, 1);
			\u0014\u0019\u0018.\u0018(this.CB, false);
			\u0014\u0019\u0018.\u0018(this.XB, false);
			\u0014\u0019\u0018.\u0018(this.WB, false);
			\u0014\u0019\u0018.\u0018(this.YB, false);
			\u0007\u0018\u0003.\u0018(this.L, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.FB, new bool?(true));
			\u0014\u0019\u0018.\u0018(this.NB, false);
			\u0007\u0018\u0003.\u0018(this.PB, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.EB, new bool?(false));
			\u0008\u0013\u0014.\u0018(this.E, Visibility.Visible);
			\u0008\u0013\u0014.\u0018(this.BQ, Visibility.Visible);
			\u0008\u0013\u0014.\u0018(this.QQ, Visibility.Visible);
			\u0007\u0018\u0003.\u0018(this.BQ, new bool?(false));
			\u0007\u0018\u0003.\u0018(this.QQ, new bool?(false));
			\u0003\u0019\u0018.\u0018(this.D, \u000F\u0017\u0003.\u0018(this));
			\u0009\u0019\u0018.\u0018(this.D, 0);
			List<string> list = \u0011\u0002\u0018.\u0018();
			\u0019\u0017\u0014.\u0018(list, \u001C\u0009\u0018.\u0019\u0014);
			\u0008\u0013\u0014.\u0018(this.O, Visibility.Collapsed);
			\u0003\u0019\u0018.\u0018(this.C, list);
			\u0009\u0019\u0018.\u0018(this.C, 0);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00030488 File Offset: 0x0002E688
		public void SetSavedPrintConfig(ExportTemPlateInfo templateInfo)
		{
			if (\u0009\u001E\u0018.\u0018(\u001F\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo)), "<In Session>"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.SetSavedPrintConfig(ExportTemPlateInfo)).MethodHandle;
				}
				EnumInfo enumInfo = this.M.\u0016(\u001F\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo)));
				if (enumInfo != null)
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
					\u0016\u0007\u0018.\u0018(this.M, enumInfo);
					return;
				}
			}
			else
			{
				\u0009\u0019\u0018.\u0018(this.M, 0);
				\u0020\u0017\u0003.\u0018(this, templateInfo);
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00030510 File Offset: 0x0002E710
		public void SetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			IfcOptions.\u000C\u0020\u0018 u000C_u0020_u = new IfcOptions.\u000C\u0020\u0018();
			u000C_u0020_u.\u000C = templateInfo;
			try
			{
				bool flag = false;
				IEnumerator u000C = \u0016\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.T));
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						IFCPhase ifcphase = \u0014\u0007\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
						if (\u000E\u0005\u0014.\u0018(ifcphase) == \u000E\u0005\u0014.\u0018(\u001E\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.SetPrintConfig(ExportTemPlateInfo)).MethodHandle;
							}
							flag = true;
							\u0016\u0007\u0018.\u0018(this.T, ifcphase);
						}
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
				}
				finally
				{
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
					if (disposable != null)
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
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
					\u0009\u0019\u0018.\u0018(this.T, 0);
				}
				\u0007\u0018\u0003.\u0018(this.K, new bool?(\u0017\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.RB, new bool?(\u0015\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.KB, new bool?(\u0011\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.FB, new bool?(\u001F\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.JB, new bool?(\u0020\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				object d = this.D;
				ComboBox d2 = this.D;
				string u;
				if ((u = \u000A\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))) == null)
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
					u = LinkedFileExportAs.DontExport.ToString();
				}
				\u0016\u0007\u0018.\u0018(d, d2.\u0016(u));
				\u0007\u0018\u0003.\u0018(this.UB, new bool?(\u0009\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.BB, new bool?(\u0013\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.HB, new bool?(\u001C\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.LB, new bool?(\u000D\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.NB, new bool?(\u0012\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.OB, new bool?(\u000F\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0012\u000B\u0018.\u0018(this.CB, \u0016\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)));
				\u0007\u0018\u0003.\u0018(this.ZB, new bool?(\u0003\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.MB, new bool?(\u0014\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0012\u000B\u0018.\u0018(this.XB, \u0018\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)));
				\u0007\u0018\u0003.\u0018(this.EB, new bool?(\u000C\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.BQ, new bool?(\u000E\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.QQ, new bool?(\u0005\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				u000C = \u0016\u000F\u0014.\u0018(\u000D\u000F\u0014.\u0018(this.Y));
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C))
					{
						IFCVersionAttributes ifcversionAttributes = \u000C\u0007\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
						if (\u001B\u0017\u0003.\u0018(ifcversionAttributes) == \u0001\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)))
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
							\u0016\u0007\u0018.\u0018(this.Y, ifcversionAttributes);
							goto IL_42E;
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
				finally
				{
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
					if (disposable != null)
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
				IL_42E:
				object w = this.W;
				ComboBox w2 = this.W;
				string u2;
				if ((u2 = \u0008\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))) == null)
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
					u2 = 0.ToString();
				}
				\u0016\u0007\u0018.\u0018(w, w2.\u0016(u2));
				\u0007\u0018\u0003.\u0018(this.VB, new bool?(\u0006\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.L, new bool?(\u0010\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u001D\u0009\u0003.\u0018(this.S, \u0007\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)));
				\u001D\u0009\u0003.\u0018(this.I, \u0019\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)));
				\u0007\u0018\u0003.\u0018(this.DB, new bool?(\u000B\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				if (\u001A\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)) != -1.0)
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
					\u001D\u0009\u0003.\u0018(this.QB, \u000E\u001F\u0018.\u000F(\u001A\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				}
				else
				{
					\u001D\u0009\u0003.\u0018(this.QB, \u001D\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C)));
				}
				\u0007\u0018\u0003.\u0018(this.AB, new bool?(\u0004\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.GB, new bool?(\u0002\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.PQ, new bool?(\u001E\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.U, new bool?(\u0017\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				\u0007\u0018\u0003.\u0018(this.PB, new bool?(\u0015\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(u000C_u0020_u.\u000C))));
				List<string> list = Enumerable.ToList<string>(Enumerable.Cast<string>(\u000D\u000F\u0014.\u0018(this.C)));
				object c = this.C;
				string u3;
				if ((u3 = Enumerable.FirstOrDefault<string>(list, new Func<string, bool>(u000C_u0020_u.\u0018))) == null)
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
					u3 = \u0006\u0005\u0018.\u0018(list, 0);
				}
				\u0016\u0007\u0018.\u0018(c, u3);
			}
			catch (Exception u4)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u4, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\IfcOptions.xaml.cs", "SetPrintConfig");
			}
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00030C24 File Offset: 0x0002EE24
		public void GetPrintConfig(ExportTemPlateInfo templateInfo)
		{
			try
			{
				if (\u000D\u0007\u0018.\u0018(this.M) != 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.GetPrintConfig(ExportTemPlateInfo)).MethodHandle;
					}
					\u001D\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.M)));
				}
				else
				{
					\u0004\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u000E\u0019\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.T)));
					\u0002\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.K)));
					\u001E\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RB)));
					\u0017\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.KB)));
					\u0015\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.FB)));
					\u0011\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.JB)));
					\u001F\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.D).\u0014());
					\u0020\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.UB)));
					\u000A\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.HB)));
					\u0009\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LB)));
					\u0013\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.NB)));
					\u001C\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.OB)));
					\u000D\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u000B\u0018.\u0018(this.CB));
					\u0012\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZB)));
					\u000F\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.MB)));
					\u0016\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u000B\u0018.\u0018(this.XB));
					\u0003\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u001B\u0017\u0003.\u0018(\u000C\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Y))));
					\u0014\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0012\u0007\u0018.\u0018(this.W).\u0014());
					\u0018\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.VB)));
					\u000C\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.L)));
					\u000E\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)));
					\u0005\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.I)));
					\u001B\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.DB)));
					\u0001\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)));
					\u0008\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.AB)));
					\u0006\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.GB)));
					\u0010\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.PQ)));
					\u0007\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.U)));
					\u0019\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.PB)));
					\u000B\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.BB)));
					\u001A\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.EB)));
					\u001D\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.BQ)));
					\u0004\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QQ)));
					\u0002\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(templateInfo), \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.C)));
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\IfcOptions.xaml.cs", "GetPrintConfig");
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00031184 File Offset: 0x0002F384
		public void getIFCControlValues()
		{
			try
			{
				object obj = \u001E\u000A\u0003.\u0018(this.M);
				string text;
				if (obj == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.getIFCControlValues()).MethodHandle;
					}
					text = null;
				}
				else
				{
					text = \u0001\u0017\u0018.\u0018(obj);
				}
				string u000C;
				if ((u000C = text) == null)
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
					u000C = string.Empty;
				}
				\u0019\u0004\u0003.\u0018(u000C);
				\u000B\u0004\u0003.\u0018(\u000E\u0019\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.T)));
				\u001A\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.K)));
				\u001D\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RB)));
				\u0004\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.KB)));
				\u0002\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.FB)));
				\u001E\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.JB)));
				\u0017\u0004\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.D).\u0014());
				\u0015\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.UB)));
				\u0011\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.HB)));
				\u001F\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LB)));
				if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.HB)))
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
					\u0020\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.NB)));
				}
				else
				{
					\u0020\u0004\u0003.\u0018(false);
				}
				\u000A\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.OB)));
				\u0009\u0004\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.CB));
				\u0013\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZB)));
				\u001C\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.MB)));
				\u000D\u0004\u0003.\u0018(\u0001\u000B\u0018.\u0018(this.XB));
				\u0012\u0004\u0003.\u0018(\u001B\u0017\u0003.\u0018(\u000C\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Y))));
				\u000F\u0004\u0003.\u0018(\u0012\u0007\u0018.\u0018(this.W).\u0014());
				\u0016\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.VB)));
				\u0003\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.L)));
				\u0014\u0004\u0003.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)));
				\u0018\u0004\u0003.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.I)));
				\u000C\u0004\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.DB)));
				\u000E\u0002\u0003.\u0018(\u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)));
				\u0005\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.AB)));
				\u001B\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.GB)));
				\u0001\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.PQ)));
				\u0008\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.U)));
				\u0006\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.PB)));
				\u0010\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.BB)));
				\u0007\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.EB)));
				\u0019\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.BQ)));
				\u000B\u0002\u0003.\u0018(\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QQ)));
				\u001A\u0002\u0003.\u0018(\u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.C)));
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\IfcOptions.xaml.cs", "getIFCControlValues");
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00031600 File Offset: 0x0002F800
		public List<EnumInfo> GetLinkedFileExport()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001E\u0003, "DontExport", 0, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0002\u0003, "ExportAsSeparate", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0004\u0003, "ExportSameProject", 2, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001D\u0003, "ExportSameSite", 3, false));
			return list;
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00031680 File Offset: 0x0002F880
		public List<EnumInfo> GetFileTypes()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018("IFC", "Ifc", 0, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018("IFC XML", "IfcXML", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0007\u0014, "IfcZIP", 2, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0010\u0014, "IfcXMLZIP", 3, false));
			return list;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x000316FC File Offset: 0x0002F8FC
		public List<EnumInfo> GetTessellationLevelOfDetails()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u000D\u0009\u0018.\u001E\u0018, "Extra Low", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0017\u0018, "Low", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0002\u0018, "Medium", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u000D\u0009\u0018.\u0004\u0018, "High", false));
			return list;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00031778 File Offset: 0x0002F978
		public List<EnumInfo> GetSpaceBoundaries()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0010\u0018, "None", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0013\u0014, "1st Level", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0009\u0014, "2nd Level", false));
			return list;
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x000317DC File Offset: 0x0002F9DC
		public List<EnumInfo> GetSitePlacements()
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0003\u0014, "Current Shared Coordinates", 0, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0016\u0014, "Site Survey Point", 1, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u000F\u0014, "Project Base Point", 2, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0012\u0014, "Internal Coordinates", 3, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u000D\u0014, "Project Base Point oriented in True North", 4, false));
			\u0016\u0002\u0014.\u0018(list, \u001A\u0002\u0014.\u0018(\u001C\u0009\u0018.\u001C\u0014, "Internal Origin oriented in True North", 5, false));
			return list;
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00031894 File Offset: 0x0002FA94
		public List<EnumInfo> GetListOfSetup(List<EnumInfo> sitePlacementList)
		{
			List<EnumInfo> list = \u0012\u0002\u0014.\u0018();
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0019\u0014, "<In Session>", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0011\u0014, "IFC 2x3 Coordination View 2.0", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u001F\u0014, "IFC 2x3 Coordination View", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u001E\u0014, "IFC 2x3 GSA Concept Design BIM 2010", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u001A\u0014, "IFC 2x3 Basic FM Handover View", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0020\u0014, "IFC 2x2 Coordination View", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0017\u0014, "IFC 2x2 Singapore BCA e-Plan Check", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0002\u0014, "IFC 2x3 COBie 2.4 Design Deliverable View", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u001D\u0014, "IFC4 Reference View", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0004\u0014, "IFC4 Design Transfer View", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u000C\u000F, "IFC4x3 [Experimental]", false));
			\u0016\u0002\u0014.\u0018(list, \u000F\u0002\u0014.\u0018(\u001C\u0009\u0018.\u0018\u000F, "IFC-SG Regulatory Requirements View", false));
			\u0001\u0004\u0003.\u0018(this.P);
			IFCExportConfigurationsMap u000C = \u0008\u0004\u0003.\u0018();
			object j = this.J;
			IEnumerable<IFCExportConfiguration> enumerable = \u0006\u0004\u0003.\u0018(u000C);
			Func<IFCExportConfiguration, bool> func;
			if ((func = IfcOptions.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.GetListOfSetup(List<EnumInfo>)).MethodHandle;
				}
				func = (IfcOptions.<>c.\u0018 = new Func<IFCExportConfiguration, bool>(IfcOptions.<>c.\u000C.\u0016));
			}
			\u0010\u0004\u0003.\u0018(j, Enumerable.Where<IFCExportConfiguration>(enumerable, func));
			IEnumerable<IFCExportConfiguration> j2 = this.J;
			Func<IFCExportConfiguration, bool> func2;
			if ((func2 = IfcOptions.<>c.\u0014) == null)
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
				func2 = (IfcOptions.<>c.\u0014 = new Func<IFCExportConfiguration, bool>(IfcOptions.<>c.\u000C.\u000F));
			}
			IEnumerable<IFCExportConfiguration> enumerable2 = Enumerable.Where<IFCExportConfiguration>(j2, func2);
			Func<IFCExportConfiguration, EnumInfo> func3;
			if ((func3 = IfcOptions.<>c.\u0003) == null)
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
				func3 = (IfcOptions.<>c.\u0003 = new Func<IFCExportConfiguration, EnumInfo>(IfcOptions.<>c.\u000C.\u0012));
			}
			\u0007\u0004\u0003.\u0018(list, Enumerable.ToList<EnumInfo>(Enumerable.Select<IFCExportConfiguration, EnumInfo>(enumerable2, func3)));
			return list;
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00031AB4 File Offset: 0x0002FCB4
		public void GetActivePhases()
		{
			this.Q = \u0003\u001D\u0003.\u0018();
			PhaseArray u000C = \u0014\u001D\u0003.\u0018(this.P);
			IFCPhase ifcphase = \u001F\u001E\u0014.\u0018();
			\u000E\u0004\u0003.\u0018(ifcphase, \u0018\u001D\u0018.\u0018().\u000C());
			\u0005\u0004\u0003.\u0018(ifcphase, \u001C\u0009\u0018.\u000A\u0014);
			\u001B\u0004\u0003.\u0018(this.Q, ifcphase);
			if (\u0018\u001D\u0003.\u0018(u000C) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.GetActivePhases()).MethodHandle;
				}
				IEnumerator u000C2 = \u000C\u001D\u0003.\u0018(u000C);
				try
				{
					while (\u001F\u001E\u0018.\u0018(u000C2))
					{
						Phase u000C3 = \u0018\u0007\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C2));
						IFCPhase ifcphase2 = \u001F\u001E\u0014.\u0018();
						\u000E\u0004\u0003.\u0018(ifcphase2, \u0009\u0002\u0018.\u0018(u000C3).\u000C());
						\u0005\u0004\u0003.\u0018(ifcphase2, \u001E\u0016\u0014.\u0018(u000C3));
						\u001B\u0004\u0003.\u0018(this.Q, ifcphase2);
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
				finally
				{
					IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C2);
					if (disposable != null)
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
						\u0020\u001E\u0018.\u0018(disposable);
					}
				}
			}
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00031BD0 File Offset: 0x0002FDD0
		private List<IFCVersionAttributes> RQ()
		{
			List<IFCVersionAttributes> list = \u0012\u001D\u0003.\u0018();
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(21));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(10));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(9));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(23));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(8));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(17));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(24));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(27));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(26));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(25));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(29));
			\u0016\u001D\u0003.\u0018(list, \u000F\u001D\u0003.\u0018(30));
			return list;
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00031C98 File Offset: 0x0002FE98
		private void btnExportUserDefinedPsetsFileName_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog u000C = \u0003\u0007\u0018.\u0018();
			\u000D\u001D\u0003.\u0018(u000C, "Select File");
			\u0014\u0007\u0018.\u0018(u000C, "Template Files (*.txt)|*.txt");
			bool? flag = \u0018\u0007\u0018.\u0018(u000C);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.btnExportUserDefinedPsetsFileName_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0012\u000B\u0018.\u0018(this.XB, \u000E\u0019\u0018.\u0018(u000C));
			}
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00031D00 File Offset: 0x0002FF00
		private void btnExportUserDefinedParameterMappingFileName_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog u000C = \u0003\u0007\u0018.\u0018();
			\u000D\u001D\u0003.\u0018(u000C, "Select File");
			\u0014\u0007\u0018.\u0018(u000C, "Template Files (*.txt)|*.txt");
			bool? flag = \u0018\u0007\u0018.\u0018(u000C);
			if (\u000C\u0007\u0018.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.btnExportUserDefinedParameterMappingFileName_Click(object, RoutedEventArgs)).MethodHandle;
				}
				\u0012\u000B\u0018.\u0018(this.CB, \u000E\u0019\u0018.\u0018(u000C));
			}
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00031D68 File Offset: 0x0002FF68
		private void chkExportSchedulesAsPsets_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.NB, true);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00031D84 File Offset: 0x0002FF84
		private void chkExportSchedulesAsPsets_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0007\u0018\u0003.\u0018(this.NB, new bool?(false));
			\u0014\u0019\u0018.\u0018(this.NB, false);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00031DB0 File Offset: 0x0002FFB0
		private void chkExportUserDefinedPsets_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.XB, true);
			\u0014\u0019\u0018.\u0018(this.YB, true);
			\u0014\u0019\u0018.\u0018(this.MB, true);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00031DE4 File Offset: 0x0002FFE4
		private void chkExportUserDefinedPsets_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.XB, false);
			\u0014\u0019\u0018.\u0018(this.YB, false);
			\u0014\u0019\u0018.\u0018(this.MB, false);
			\u0007\u0018\u0003.\u0018(this.MB, new bool?(false));
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00031E28 File Offset: 0x00030028
		private void chkExportUserDefinedParameterMapping_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.CB, true);
			\u0014\u0019\u0018.\u0018(this.WB, true);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00031E50 File Offset: 0x00030050
		private void chkExportUserDefinedParameterMapping_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.CB, false);
			\u0014\u0019\u0018.\u0018(this.WB, false);
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00031E78 File Offset: 0x00030078
		private void chkVisibleElementsOfCurrentView_Checked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.BB, true);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00031E94 File Offset: 0x00030094
		private void chkVisibleElementsOfCurrentView_Unchecked(object sender, RoutedEventArgs e)
		{
			\u0014\u0019\u0018.\u0018(this.BB, false);
			\u0007\u0018\u0003.\u0018(this.BB, new bool?(false));
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00031EC0 File Offset: 0x000300C0
		private void CmbSetup_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			IfcOptions.\u0005\u000A\u0018 u0005_u000A_u = new IfcOptions.\u0005\u000A\u0018();
			u0005_u000A_u.\u000C = \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.M));
			IFCExportConfiguration ifcexportConfiguration = Enumerable.FirstOrDefault<IFCExportConfiguration>(this.J, new Func<IFCExportConfiguration, bool>(u0005_u000A_u.\u0018));
			if (ifcexportConfiguration != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.CmbSetup_SelectionChanged(object, SelectionChangedEventArgs)).MethodHandle;
				}
				IfcOptions.\u000E\u000A\u0018 u000E_u000A_u = new IfcOptions.\u000E\u000A\u0018();
				if (\u000F\u0002\u0018.\u0018(this.F, "<In Session>"))
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
					this.H = this.NQ();
				}
				this.ZQ(false);
				u000E_u000A_u.\u000C = \u001D\u0011\u0018.\u0003(ifcexportConfiguration);
				IFCPhase ifcphase = Enumerable.FirstOrDefault<IFCPhase>(this.Q, new Func<IFCPhase, bool>(u000E_u000A_u.\u0018));
				IFCVersion p = \u000C\u001A\u0003.\u0018(ifcexportConfiguration);
				int q = \u000E\u001D\u0003.\u0018(ifcexportConfiguration);
				bool j = \u0005\u001D\u0003.\u0018(ifcexportConfiguration);
				bool f = \u001B\u001D\u0003.\u0018(ifcexportConfiguration);
				bool h = \u0001\u001D\u0003.\u0018(ifcexportConfiguration);
				bool n = \u0008\u001D\u0003.\u0018(ifcexportConfiguration);
				bool z = \u0006\u001D\u0003.\u0018(ifcexportConfiguration);
				bool m = \u0010\u001D\u0003.\u0018(ifcexportConfiguration);
				bool x = \u0007\u001D\u0003.\u0018(ifcexportConfiguration);
				bool y = \u0019\u001D\u0003.\u0018(ifcexportConfiguration);
				string o = ifcexportConfiguration.\u0018();
				string c = ifcexportConfiguration.\u0016();
				bool w = ifcexportConfiguration.\u000F();
				IFCPhase t = ifcphase;
				double i = \u000B\u001D\u0003.\u0018(ifcexportConfiguration);
				bool s = \u001A\u001D\u0003.\u0018(ifcexportConfiguration);
				bool u = \u001D\u001D\u0003.\u0018(ifcexportConfiguration);
				bool l = \u0004\u001D\u0003.\u0018(ifcexportConfiguration);
				bool e2 = \u0002\u001D\u0003.\u0018(ifcexportConfiguration);
				bool a = \u001E\u001D\u0003.\u0018(ifcexportConfiguration);
				bool v = \u0017\u001D\u0003.\u0018(ifcexportConfiguration);
				bool d = \u0015\u001D\u0003.\u0018(ifcexportConfiguration);
				bool k = ifcexportConfiguration.\u0012();
				bool pb = ifcexportConfiguration.\u000D();
				bool bb = ifcexportConfiguration.\u001C();
				bool qb = \u0011\u001D\u0003.\u0018(ifcexportConfiguration);
				bool jb = \u001F\u001D\u0003.\u0018(ifcexportConfiguration);
				bool fb = \u0020\u001D\u0003.\u0018(ifcexportConfiguration);
				bool? flag = \u000A\u001D\u0003.\u0018(ifcexportConfiguration);
				ExportTemPlateInfo exportTemPlateInfo = this.HQ(p, q, j, f, h, n, z, m, x, y, o, c, w, t, i, s, u, l, e2, a, v, d, k, pb, bb, qb, jb, fb, \u000C\u0007\u0018.\u0018(ref flag), \u0009\u001D\u0003.\u0018(ifcexportConfiguration), \u0013\u001D\u0003.\u0018(ifcexportConfiguration), ifcexportConfiguration.\u0009());
				object u000C = \u0011\u0017\u0003.\u0018(exportTemPlateInfo);
				EnumInfo enumInfo = this.S.\u0016(ifcexportConfiguration.\u0014());
				string u2;
				if (enumInfo == null)
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
					u2 = \u0005\u001E\u000F.\u000C;
				}
				else
				{
					u2 = \u001C\u001D\u0003.\u0014(enumInfo);
				}
				\u000E\u001E\u0003.\u0018(u000C, u2);
				\u0014\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), "IFCFileType");
				\u0002\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), ifcexportConfiguration.\u0013());
				\u0020\u0017\u0003.\u0018(this, exportTemPlateInfo);
			}
			else
			{
				string u000C2 = u0005_u000A_u.\u000C;
				if (u000C2 != null)
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
					int num = \u001C\u0002\u0018.\u0003(u000C2);
					if (num <= 21)
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
						if (num != 12)
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
							if (num != 19)
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
								if (num != 21)
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
								}
								else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC4x3 [Experimental]"))
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
								}
								else
								{
									if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
										this.H = this.NQ();
									}
									this.ZQ(false);
									ExportTemPlateInfo u3 = this.HQ(29, 0, true, false, false, false, false, false, false, false, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
									\u0020\u0017\u0003.\u0018(this, u3);
									\u0014\u0019\u0018.\u0018(this.D, true);
									\u0014\u0019\u0018.\u0018(this.PB, false);
									\u0014\u0019\u0018.\u0018(this.BQ, true);
									\u0014\u0019\u0018.\u0018(this.QQ, true);
								}
							}
							else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC4 Reference View"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u4 = this.HQ(25, 0, true, false, false, false, false, false, false, false, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u4);
								\u0014\u0019\u0018.\u0018(this.L, false);
							}
						}
						else if (!\u000F\u0002\u0018.\u0018(u000C2, "<In Session>"))
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
						else if (\u0009\u001E\u0018.\u0018(this.F, ""))
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
							this.ZQ(true);
							\u0020\u0017\u0003.\u0018(this, this.H);
						}
					}
					else if (num != 25)
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
						switch (num)
						{
						case 29:
							if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x3 Coordination View 2.0"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u5 = this.HQ(21, 0, false, false, false, false, false, false, false, false, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u5);
							}
							break;
						case 30:
							if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x3 Basic FM Handover View"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u6 = this.HQ(27, 1, true, true, false, false, false, false, true, false, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u6);
							}
							break;
						case 31:
						case 32:
						case 33:
							break;
						case 34:
							if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x2 Singapore BCA e-Plan Check"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u7 = this.HQ(8, 1, false, true, true, false, false, false, false, false, "DontExport", "", false, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u7);
								\u0014\u0019\u0018.\u0018(this.L, false);
							}
							break;
						case 35:
						{
							char c2 = \u0002\u0001\u0018.\u0003(u000C2, 3);
							if (c2 != ' ')
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
								if (c2 != '-')
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
								}
								else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC-SG Regulatory Requirements View"))
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
								}
								else
								{
									if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
										this.H = this.NQ();
									}
									this.ZQ(false);
									IFCPhase t2 = \u000E\u0019\u000F.\u000C(\u0020\u000F\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.T), 2));
									ExportTemPlateInfo u8 = this.HQ(30, 1, true, true, false, false, true, false, true, false, "DontExport", "", false, t2, -1.0, false, false, false, false, true, true, false, true, false, false, true, true, true, false, "", "", false);
									\u0020\u0017\u0003.\u0018(this, u8);
									\u0014\u0019\u0018.\u0018(this.D, true);
									\u0014\u0019\u0018.\u0018(this.BQ, true);
									\u0014\u0019\u0018.\u0018(this.QQ, true);
									\u0014\u0019\u0018.\u0018(this.L, false);
									\u0014\u0019\u0018.\u0018(this.PB, false);
									\u0014\u0019\u0018.\u0018(this.BB, false);
								}
							}
							else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x3 GSA Concept Design BIM 2010"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u9 = this.HQ(17, 2, true, true, true, false, false, false, true, true, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u9);
							}
							break;
						}
						default:
							if (num != 41)
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
							}
							else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x3 COBie 2.4 Design Deliverable View"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u10 = this.HQ(24, 1, true, false, false, true, true, false, true, true, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u10);
							}
							break;
						}
					}
					else
					{
						char c2 = \u0002\u0001\u0018.\u0003(u000C2, 6);
						if (c2 != '2')
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
							if (c2 != '3')
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
								if (c2 != 'e')
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
								else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC4 Design Transfer View"))
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
								}
								else
								{
									if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
										this.H = this.NQ();
									}
									this.ZQ(false);
									ExportTemPlateInfo u11 = this.HQ(26, 0, true, false, false, false, false, false, false, false, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
									\u0020\u0017\u0003.\u0018(this, u11);
									\u0014\u0019\u0018.\u0018(this.L, false);
								}
							}
							else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x3 Coordination View"))
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
							}
							else
							{
								if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
									this.H = this.NQ();
								}
								this.ZQ(false);
								ExportTemPlateInfo u12 = this.HQ(10, 1, false, false, true, false, false, false, true, false, "DontExport", "", true, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
								\u0020\u0017\u0003.\u0018(this, u12);
							}
						}
						else if (!\u000F\u0002\u0018.\u0018(u000C2, "IFC 2x2 Coordination View"))
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
						}
						else
						{
							if (\u000F\u0002\u0018.\u0018(this.F, \u001C\u0009\u0018.\u0019\u0014))
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
								this.H = this.NQ();
							}
							this.ZQ(false);
							ExportTemPlateInfo u13 = this.HQ(9, 1, false, false, true, false, false, false, false, false, "DontExport", "", false, null, -1.0, false, false, false, false, false, false, false, false, false, false, false, true, false, false, "", "", false);
							\u0020\u0017\u0003.\u0018(this, u13);
							\u0014\u0019\u0018.\u0018(this.L, false);
						}
					}
				}
			}
			this.F = u0005_u000A_u.\u000C;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x00032A9C File Offset: 0x00030C9C
		private ExportTemPlateInfo HQ(IFCVersion P, int Q, bool J, bool F, bool H, bool N, bool Z, bool M, bool X, bool Y, string O, string C = "", bool W = false, IFCPhase T = null, double I = -1.0, bool S = false, bool U = false, bool L = false, bool E = false, bool A = false, bool V = false, bool D = false, bool K = false, bool PB = false, bool BB = false, bool QB = false, bool JB = true, bool FB = false, bool RB = false, string HB = "", string NB = "", bool ZB = false)
		{
			ExportTemPlateInfo exportTemPlateInfo = \u0003\u0020\u0014.\u0018();
			\u001D\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.M)));
			\u0003\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), P);
			\u0005\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0020\u000F\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.I), Q).\u000C());
			\u001E\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), J);
			\u0007\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), F);
			\u0011\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), H);
			\u0012\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), Z);
			\u000F\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), ZB);
			\u001C\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), M);
			\u0017\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), Y);
			\u001F\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), O);
			\u000A\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), N);
			if (T != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.HQ(IFCVersion, int, bool, bool, bool, bool, bool, bool, bool, bool, string, string, bool, IFCPhase, double, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, bool, string, string, bool)).MethodHandle;
				}
				\u0004\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), T);
			}
			else
			{
				\u0004\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u000E\u0019\u000F.\u000C(\u0020\u000F\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.T), 0)));
			}
			\u0002\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), X);
			\u000E\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0020\u000F\u0003.\u0018(\u000D\u000F\u0014.\u0018(this.S), 0).\u000C());
			\u000C\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), W);
			\u0015\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), JB);
			\u0020\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), S);
			\u0019\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), QB);
			\u000B\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), FB);
			\u0009\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), U);
			\u0013\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), RB);
			\u000D\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), NB);
			\u0016\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), HB);
			\u0018\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), V);
			\u001B\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), D);
			\u0018\u001A\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), I);
			if (\u001A\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo)) != -1.0)
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
				\u0001\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u000E\u001F\u0018.\u000F(\u001A\u0017\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo))));
			}
			else
			{
				\u0001\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), "Low");
			}
			\u0008\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), L);
			\u0006\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), E);
			\u0010\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), K);
			\u001A\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), A);
			\u001D\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), PB);
			\u0004\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), BB);
			return exportTemPlateInfo;
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00032D84 File Offset: 0x00030F84
		private ExportTemPlateInfo NQ()
		{
			ExportTemPlateInfo exportTemPlateInfo = \u0003\u0020\u0014.\u0018();
			\u0004\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u000E\u0019\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.T)));
			\u0002\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.K)));
			\u001E\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RB)));
			\u0017\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.KB)));
			\u0015\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.FB)));
			\u0011\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.JB)));
			\u001F\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0012\u0007\u0018.\u0018(this.D).\u0014());
			\u0020\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.UB)));
			\u0019\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.PB)));
			\u000B\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.BB)));
			\u000A\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.HB)));
			\u0009\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LB)));
			\u0013\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.NB)));
			\u001C\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.OB)));
			\u000D\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u000B\u0018.\u0018(this.CB));
			\u0012\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZB)));
			\u000F\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.MB)));
			\u0016\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u000B\u0018.\u0018(this.XB));
			\u0003\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u001B\u0017\u0003.\u0018(\u000C\u0007\u000F.\u000C(\u0012\u0007\u0018.\u0018(this.Y))));
			\u0014\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0012\u0007\u0018.\u0018(this.W).\u0014());
			\u0002\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u0017\u0018.\u0018(\u0012\u0007\u0018.\u0018(this.C)));
			\u0018\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.VB)));
			\u000C\u0002\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.L)));
			\u000E\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.S)));
			\u0005\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.I)));
			\u001B\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.DB)));
			\u0001\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0001\u0017\u0018.\u0018(\u001E\u000A\u0003.\u0018(this.QB)));
			\u0008\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.AB)));
			\u0006\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.GB)));
			\u0010\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.PQ)));
			\u0007\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.U)));
			\u001A\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.EB)));
			\u001D\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.BQ)));
			\u0004\u001E\u0003.\u0018(\u0011\u0017\u0003.\u0018(exportTemPlateInfo), \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QQ)));
			return exportTemPlateInfo;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x0003326C File Offset: 0x0003146C
		private void ZQ(bool P)
		{
			try
			{
				\u0014\u0019\u0018.\u0018(this.T, P);
				\u0014\u0019\u0018.\u0018(this.K, P);
				\u0014\u0019\u0018.\u0018(this.RB, P);
				\u0014\u0019\u0018.\u0018(this.KB, P);
				\u0014\u0019\u0018.\u0018(this.FB, P);
				\u0014\u0019\u0018.\u0018(this.JB, P);
				\u0014\u0019\u0018.\u0018(this.D, true);
				\u0014\u0019\u0018.\u0018(this.UB, P);
				\u0014\u0019\u0018.\u0018(this.BB, true);
				\u0014\u0019\u0018.\u0018(this.HB, P);
				\u0014\u0019\u0018.\u0018(this.LB, P);
				\u0014\u0019\u0018.\u0018(this.NB, P);
				\u0014\u0019\u0018.\u0018(this.OB, P);
				\u0014\u0019\u0018.\u0018(this.CB, P);
				\u0014\u0019\u0018.\u0018(this.ZB, P);
				\u0014\u0019\u0018.\u0018(this.MB, P);
				\u0014\u0019\u0018.\u0018(this.XB, P);
				\u0014\u0019\u0018.\u0018(this.Y, P);
				\u0014\u0019\u0018.\u0018(this.W, P);
				\u0014\u0019\u0018.\u0018(this.C, P);
				\u0014\u0019\u0018.\u0018(this.VB, P);
				\u0014\u0019\u0018.\u0018(this.L, true);
				\u0014\u0019\u0018.\u0018(this.S, P);
				\u0014\u0019\u0018.\u0018(this.I, P);
				\u0014\u0019\u0018.\u0018(this.DB, P);
				\u0014\u0019\u0018.\u0018(this.QB, P);
				\u0014\u0019\u0018.\u0018(this.AB, P);
				\u0014\u0019\u0018.\u0018(this.GB, P);
				\u0014\u0019\u0018.\u0018(this.PQ, P);
				\u0014\u0019\u0018.\u0018(this.U, P);
				\u0014\u0019\u0018.\u0018(this.PB, true);
				\u0014\u0019\u0018.\u0018(this.WB, P);
				\u0014\u0019\u0018.\u0018(this.YB, P);
				\u0014\u0019\u0018.\u0018(this.IB, P);
				\u0014\u0019\u0018.\u0018(this.SB, true);
				\u0014\u0019\u0018.\u0018(this.EB, P);
				\u0014\u0019\u0018.\u0018(this.QQ, P);
				\u0014\u0019\u0018.\u0018(this.BQ, P);
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\IfcOptions.xaml.cs", "DisableEnableEverything");
			}
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x0003347C File Offset: 0x0003167C
		private void BtnImport_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog u000C = \u0003\u0007\u0018.\u0018();
			\u0014\u0007\u0018.\u0018(u000C, "Xml Files (.xml)|*.xml");
			bool? flag = \u0018\u0007\u0018.\u0018(u000C);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.BtnImport_Click(object, RoutedEventArgs)).MethodHandle;
				}
				try
				{
					string u = \u000E\u0019\u0018.\u0018(u000C);
					IFCSettings u2 = \u0003\u001A\u0003.\u0018(this, u);
					ExportTemPlateInfo exportTemPlateInfo = \u0003\u0020\u0014.\u0018();
					\u0014\u001A\u0003.\u0018(exportTemPlateInfo, u2);
					\u0020\u0017\u0003.\u0018(this, exportTemPlateInfo);
				}
				catch (Exception u3)
				{
					\u001C\u000A\u0014.\u0018(\u0013\u000A\u0014.\u0018(), u3, true);
				}
			}
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00033514 File Offset: 0x00031714
		private void BtnExport_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog u000C = \u000B\u000A\u0014.\u0018();
			\u001A\u000A\u0014.\u0018(u000C, "Settings");
			\u001D\u000A\u0014.\u0018(u000C, true);
			\u0014\u0007\u0018.\u0018(u000C, "Xml Files (.xml)|*.xml");
			bool? flag = \u0018\u0007\u0018.\u0018(u000C);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.BtnExport_Click(object, RoutedEventArgs)).MethodHandle;
				}
				try
				{
					\u0016\u001A\u0003.\u0018(\u000E\u0019\u0018.\u0018(u000C), \u0011\u0017\u0003.\u0018(this.NQ()));
				}
				catch (Exception u)
				{
					\u001C\u000A\u0014.\u0018(\u0013\u000A\u0014.\u0018(), u, true);
				}
			}
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000335B0 File Offset: 0x000317B0
		public static bool SerializeIFC(string path, IFCSettings settings)
		{
			bool result;
			try
			{
				XmlSerializer u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u001B\u0019\u000F.\u000C()));
				XmlSerializerNamespaces xmlSerializerNamespaces = \u0019\u001D\u0018.\u0018();
				\u000B\u001D\u0018.\u0018(xmlSerializerNamespaces, "", "");
				TextWriter textWriter = \u001A\u001D\u0018.\u0018(path);
				try
				{
					\u001D\u001D\u0018.\u0018(u000C, textWriter, settings, xmlSerializerNamespaces);
					\u0004\u001D\u0018.\u0018(textWriter);
				}
				finally
				{
					if (textWriter != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.SerializeIFC(string, IFCSettings)).MethodHandle;
						}
						\u0020\u001E\u0018.\u0018(textWriter);
					}
				}
				result = true;
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\IfcOptions.xaml.cs", "SerializeIFC");
				result = false;
			}
			return result;
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x00033660 File Offset: 0x00031860
		public IFCSettings DeserialiseIFC(string path)
		{
			IFCSettings result = \u000F\u001A\u0003.\u0018();
			try
			{
				if (\u000C\u001A\u0018.\u0018(path))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(IfcOptions.DeserialiseIFC(string)).MethodHandle;
					}
					object u000C = \u0007\u001D\u0018.\u0018(\u000A\u001D\u0018.\u0018(\u001B\u0019\u000F.\u000C()));
					StreamReader streamReader = \u000E\u001D\u0018.\u0018(path);
					result = \u0005\u0019\u000F.\u000C(\u0005\u001D\u0018.\u0018(u000C, streamReader));
					\u001B\u001D\u0018.\u0018(streamReader);
				}
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\IfcOptions.xaml.cs", "DeserialiseIFC");
			}
			return result;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x000336F4 File Offset: 0x000318F4
		private void btnClassificationSettings_Click(object sender, RoutedEventArgs e)
		{
			IList<IfcClassificationSettings> list;
			bool u = \u000D\u001A\u0003.\u0018(this.P, null, out list);
			\u001E\u0007\u0018.\u0014(\u0012\u001A\u0003.\u0018(this.P, Enumerable.FirstOrDefault<IfcClassificationSettings>(list), u));
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00033730 File Offset: 0x00031930
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00033758 File Offset: 0x00031958
		private void btnFileHeaderSettings_Click(object sender, RoutedEventArgs e)
		{
			object u000C = \u0009\u001A\u0003.\u0018();
			Document u = \u0007\u0015\u0018.\u0003;
			IFCFileHeaderItem u000C2;
			bool u2 = \u0013\u001A\u0003.\u0018(u000C, u, ref u000C2);
			\u001E\u0007\u0018.\u0014(\u001C\u001A\u0003.\u0018(u000C2, u2));
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00033790 File Offset: 0x00031990
		private void btnProjectSettings_Click(object sender, RoutedEventArgs e)
		{
			IFCAddressItem u000C;
			\u0020\u001A\u0003.\u0018(\u001F\u001A\u0003.\u0018(), this.P, ref u000C);
			\u001E\u0007\u0018.\u0014(\u000A\u001A\u0003.\u0018(u000C));
		}

		// Token: 0x0400039B RID: 923
		private Document P;

		// Token: 0x0400039C RID: 924
		private List<IFCPhase> Q = new List<IFCPhase>();

		// Token: 0x0400039D RID: 925
		private List<IFCExportConfiguration> J;

		// Token: 0x0400039E RID: 926
		private string F = "";

		// Token: 0x0400039F RID: 927
		private ExportTemPlateInfo H = new ExportTemPlateInfo();

		// Token: 0x020001A7 RID: 423
		[CompilerGenerated]
		private sealed class \u0005\u000A\u0018
		{
			// Token: 0x0600116F RID: 4463 RVA: 0x0005CA10 File Offset: 0x0005AC10
			internal bool \u0018(IFCExportConfiguration \u000C)
			{
				return \u001B\u0013\u0018.\u0018(\u0018\u001F\u000F.\u0018(\u000C), this.\u000C, true);
			}

			// Token: 0x0400082E RID: 2094
			public string \u000C;
		}

		// Token: 0x020001A8 RID: 424
		[CompilerGenerated]
		private sealed class \u000E\u000A\u0018
		{
			// Token: 0x06001171 RID: 4465 RVA: 0x0005CA48 File Offset: 0x0005AC48
			internal bool \u0018(IFCPhase \u000C)
			{
				return \u000E\u0005\u0014.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x0400082F RID: 2095
			public long \u000C;
		}

		// Token: 0x020001A9 RID: 425
		[CompilerGenerated]
		private sealed class \u000C\u0020\u0018
		{
			// Token: 0x06001173 RID: 4467 RVA: 0x0005CA7C File Offset: 0x0005AC7C
			internal bool \u0018(string \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u000C, \u0014\u001F\u000F.\u0018(\u0011\u0017\u0003.\u0018(this.\u000C)));
			}

			// Token: 0x04000830 RID: 2096
			public ExportTemPlateInfo \u000C;
		}
	}
}
