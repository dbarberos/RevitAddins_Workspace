using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.UI.UserControls;
using DiRoots.ProSheets.ViewModels;
using DiRoots.ProSheets.Xml.UI.UserControls;
using Microsoft.CSharp.RuntimeBinder;
using ProSheets.Helpers;
using ProSheets.ViewModels;

namespace ProSheets.UI
{
	// Token: 0x0200008A RID: 138
	public partial class Export : BaseUserControl
	{
		// Token: 0x06000856 RID: 2134 RVA: 0x0002DCE8 File Offset: 0x0002BEE8
		public Export()
		{
			\u0004\u001F\u0003.\u0018(this);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0002DD18 File Offset: 0x0002BF18
		protected override void ApplyLicense(bool isLicenseValid)
		{
			this.VR();
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0002DD2C File Offset: 0x0002BF2C
		public void loadConfig(Document objDoc, ParameterBaseModel parameterBaseModel)
		{
			this.OQ = parameterBaseModel;
			if (PSCommand.objFlag)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.loadConfig(Document, ParameterBaseModel)).MethodHandle;
				}
				this.YB = objDoc;
				\u0007\u0018\u0003.\u0018(this.CQ, new bool?(true));
				\u0019\u0009\u0018.\u0003(this.YB);
				\u0019\u0009\u0018.\u0016(this.YB);
				this.LB = \u001C\u0002\u0014.\u0018();
				\u0002\u000B\u0014.\u0018(this.LB, 0, \u001C\u0009\u0018.\u001F\u0018);
				if (\u0001\u0015\u0014.\u0018(\u0015\u0002\u0014.\u0018()) != 0)
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
					this.EB = \u0015\u0002\u0014.\u0018();
					return;
				}
				\u0019\u0017\u0014.\u0018(this.EB, \u001C\u0009\u0018.\u0020\u0018);
			}
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0002DDE8 File Offset: 0x0002BFE8
		public void getControlValues()
		{
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "getControlValues");
				if (this.AB != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Export.getControlValues()).MethodHandle;
					}
					\u0006\u001F\u0003.\u0018(this.AB);
				}
				if (this.VB != null)
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
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.IQ)))
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
						\u0010\u001F\u0003.\u0018(this.VB);
					}
				}
				if (this.DB != null)
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
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LQ)))
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
						\u0007\u001F\u0003.\u0018(this.DB);
					}
				}
				if (this.KB != null)
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
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.AQ)))
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
						\u0019\u001F\u0003.\u0018(this.KB);
					}
				}
				if (this.PQ != null)
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
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.KQ)))
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
						\u000B\u001F\u0003.\u0018(this.PQ);
					}
				}
				if (this.BQ != null)
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
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QJ)))
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
						\u001A\u001F\u0003.\u0018(this.BQ);
					}
				}
				if (this.QQ != null)
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
					if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RJ)))
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
						\u001D\u001F\u0003.\u0018(this.QQ);
					}
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "getControlValues");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "getControlValues");
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0002E00C File Offset: 0x0002C20C
		public void ShowWarning()
		{
			if (this.DB != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.ShowWarning()).MethodHandle;
				}
				if (\u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LQ)))
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
					\u0008\u001F\u0003.\u0018(this.DB);
				}
			}
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0002E064 File Offset: 0x0002C264
		public void getFormatCheckBoxValue()
		{
			\u0001\u001F\u0003.\u0018(\u0011\u0002\u0018.\u0018());
			try
			{
				\u000D\u0004\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "getFormatCheckBoxValue");
				bool? flag = \u001B\u0001\u0018.\u0018(this.CQ);
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Export.getFormatCheckBoxValue()).MethodHandle;
					}
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "PDF");
				}
				flag = \u001B\u0001\u0018.\u0018(this.IQ);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DWG");
				}
				flag = \u001B\u0001\u0018.\u0018(this.AQ);
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DWF");
				}
				flag = \u001B\u0001\u0018.\u0018(this.LQ);
				if (\u000C\u0007\u0018.\u0018(ref flag))
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "DGN");
				}
				flag = \u001B\u0001\u0018.\u0018(this.KQ);
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "NWC");
				}
				flag = \u001B\u0001\u0018.\u0018(this.QJ);
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "IFC");
				}
				flag = \u001B\u0001\u0018.\u0018(this.RJ);
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "Image");
				}
				flag = \u001B\u0001\u0018.\u0018(this.ZJ);
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
					\u0019\u0017\u0014.\u0018(\u0008\u0017\u0014.\u0018(), "XML");
				}
				\u0017\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "getFormatCheckBoxValue");
			}
			catch (Exception u)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "getFormatCheckBoxValue");
			}
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0002E288 File Offset: 0x0002C488
		public void ReadProfileConfig(Profile p)
		{
			this.GB = true;
			List<Export.\u0008\u000A\u0018> list = \u0011\u0011\u0003.\u0018();
			object u000C = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u, this.CQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u, \u001F\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C, u0008_u000A_u);
			object u000C2 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u2 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u2, this.IQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u2, \u0020\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C2, u0008_u000A_u2);
			object u000C3 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u3 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u3, this.LQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u3, \u000A\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C3, u0008_u000A_u3);
			object u000C4 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u4 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u4, this.AQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u4, \u0009\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C4, u0008_u000A_u4);
			object u000C5 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u5 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u5, this.KQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u5, \u0013\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C5, u0008_u000A_u5);
			object u000C6 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u6 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u6, this.QJ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u6, \u001C\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C6, u0008_u000A_u6);
			object u000C7 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u7 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u7, this.RJ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u7, \u000D\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C7, u0008_u000A_u7);
			object u000C8 = list;
			Export.\u0008\u000A\u0018 u0008_u000A_u8 = new Export.\u0008\u000A\u0018();
			\u0012\u0011\u0003.\u0018(u0008_u000A_u8, this.ZJ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u8, \u000F\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(p)));
			\u0003\u0011\u0003.\u0018(u000C8, u0008_u000A_u8);
			ExportTemPlateInfo exportTemPlateInfo = \u0017\u000A\u0014.\u0018(p);
			bool value = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.CQ));
			bool value2 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.IQ));
			bool value3 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LQ));
			bool value4 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.AQ));
			bool value5 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.KQ));
			bool value6 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QJ));
			bool value7 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RJ));
			bool value8 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZJ));
			\u0007\u0018\u0003.\u0018(this.CQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.IQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.LQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.AQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.KQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.QJ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.RJ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.ZJ, new bool?(true));
			PdfOptions ab = this.AB;
			if (ab == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.ReadProfileConfig(Profile)).MethodHandle;
				}
			}
			else
			{
				ab.BH(exportTemPlateInfo);
			}
			DwgOptions vb = this.VB;
			if (vb == null)
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
				\u0014\u0011\u0003.\u0018(vb, exportTemPlateInfo);
			}
			DngOptions db = this.DB;
			if (db == null)
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
				\u0018\u0011\u0003.\u0018(db, exportTemPlateInfo);
			}
			DwfOptions kb = this.KB;
			if (kb == null)
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
				\u000C\u0011\u0003.\u0018(kb, this, exportTemPlateInfo);
			}
			NwcOptions pq = this.PQ;
			if (pq == null)
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
				\u000E\u001F\u0003.\u0018(pq, this, exportTemPlateInfo);
			}
			IfcOptions bq = this.BQ;
			if (bq == null)
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
				\u0005\u001F\u0003.\u0018(bq, exportTemPlateInfo);
			}
			ImgOptions qq = this.QQ;
			if (qq == null)
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
				\u001B\u001F\u0003.\u0018(qq, this, exportTemPlateInfo);
			}
			\u001E\u000A\u0018.\u0003(\u0004\u0005\u0018.\u0018().GetService<XmlExporterViewModel>(false), exportTemPlateInfo);
			\u0007\u0018\u0003.\u0018(this.CQ, new bool?(value));
			\u0007\u0018\u0003.\u0018(this.IQ, new bool?(value2));
			\u0007\u0018\u0003.\u0018(this.LQ, new bool?(value3));
			\u0007\u0018\u0003.\u0018(this.AQ, new bool?(value4));
			\u0007\u0018\u0003.\u0018(this.KQ, new bool?(value5));
			\u0007\u0018\u0003.\u0018(this.QJ, new bool?(value6));
			\u0007\u0018\u0003.\u0018(this.RJ, new bool?(value7));
			\u0007\u0018\u0003.\u0018(this.ZJ, new bool?(value8));
			if (this.AB != null)
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
				if (this.FQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.AB);
					goto IL_60E;
				}
			}
			if (this.VB != null)
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
				if (this.RQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.VB);
					goto IL_60E;
				}
			}
			if (this.DB != null)
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
				if (this.HQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.DB);
					goto IL_60E;
				}
			}
			if (this.KB != null)
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
				if (this.NQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.KB);
					goto IL_60E;
				}
			}
			if (this.PQ != null)
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
				if (this.ZQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.PQ);
					goto IL_60E;
				}
			}
			if (this.BQ != null)
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
				if (this.MQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.BQ);
					goto IL_60E;
				}
			}
			if (this.QQ != null)
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
				if (this.XQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.QQ);
					goto IL_60E;
				}
			}
			if (this.JQ != null)
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
				if (this.YQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.JQ);
				}
			}
			IL_60E:
			this.AR(p, list);
			this.VR();
			this.GB = false;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0002E8B8 File Offset: 0x0002CAB8
		private void AR(Profile P, List<Export.\u0008\u000A\u0018> Q)
		{
			Func<Export.\u0008\u000A\u0018, bool> func;
			if ((func = Export.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.AR(Profile, List<Export.\u0008\u000A\u0018>)).MethodHandle;
				}
				func = (Export.<>c.\u0018 = new Func<Export.\u0008\u000A\u0018, bool>(Export.<>c.\u000C.\u000D));
			}
			if (Enumerable.Any<Export.\u0008\u000A\u0018>(Q, func))
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
				Func<Export.\u0008\u000A\u0018, bool> func2;
				if ((func2 = Export.<>c.\u0014) == null)
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
					func2 = (Export.<>c.\u0014 = new Func<Export.\u0008\u000A\u0018, bool>(Export.<>c.\u000C.\u001C));
				}
				Export.\u0008\u000A\u0018 u0008_u000A_u = Enumerable.FirstOrDefault<Export.\u0008\u000A\u0018>(Q, func2);
				if (u0008_u000A_u == null)
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
					Func<Export.\u0008\u000A\u0018, bool> func3;
					if ((func3 = Export.<>c.\u0003) == null)
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
						func3 = (Export.<>c.\u0003 = new Func<Export.\u0008\u000A\u0018, bool>(Export.<>c.\u000C.\u0013));
					}
					u0008_u000A_u = Enumerable.First<Export.\u0008\u000A\u0018>(Q, func3);
				}
				\u0007\u0018\u0003.\u0018(\u0015\u0011\u0003.\u0018(u0008_u000A_u), new bool?(\u001E\u0011\u0003.\u0018(u0008_u000A_u)));
				List<Export.\u0008\u000A\u0018>.Enumerator enumerator = \u0004\u0011\u0003.\u0018(Q);
				try
				{
					while (\u0017\u0011\u0003.\u0018(ref enumerator))
					{
						Export.\u0008\u000A\u0018 u0008_u000A_u2 = \u0002\u0011\u0003.\u0018(ref enumerator);
						if (u0008_u000A_u2 != u0008_u000A_u)
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
							\u0007\u0018\u0003.\u0018(\u0015\u0011\u0003.\u0018(u0008_u000A_u2), new bool?(\u001E\u0011\u0003.\u0018(u0008_u000A_u2)));
						}
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
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0007\u0018\u0003.\u0018(\u0015\u0011\u0003.\u0018(u0008_u000A_u), new bool?(false));
				\u0007\u0018\u0003.\u0018(\u0015\u0011\u0003.\u0018(u0008_u000A_u), new bool?(true));
				return;
			}
			\u0007\u0018\u0003.\u0018(this.CQ, new bool?(\u001F\u0011\u0003.\u0018(\u0017\u000A\u0014.\u0018(P))));
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0002EA54 File Offset: 0x0002CC54
		public void GetProfileConfig(ExportTemPlateInfo templateInfo)
		{
			this.GB = true;
			bool value = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.CQ));
			bool value2 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.IQ));
			bool value3 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.LQ));
			bool value4 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.AQ));
			bool value5 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.KQ));
			bool value6 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.QJ));
			bool value7 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.RJ));
			bool value8 = \u0007\u0009\u0014.\u0018(\u001B\u0001\u0018.\u0018(this.ZJ));
			\u0007\u0018\u0003.\u0018(this.CQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.IQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.LQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.AQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.KQ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.QJ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.RJ, new bool?(true));
			\u0007\u0018\u0003.\u0018(this.ZJ, new bool?(true));
			PdfOptions ab = this.AB;
			if (ab == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.GetProfileConfig(ExportTemPlateInfo)).MethodHandle;
				}
			}
			else
			{
				\u0014\u0015\u0003.\u0018(ab, templateInfo);
			}
			DwgOptions vb = this.VB;
			if (vb == null)
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
				\u0018\u0015\u0003.\u0018(vb, templateInfo);
			}
			DngOptions db = this.DB;
			if (db == null)
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
				\u000C\u0015\u0003.\u0018(db, templateInfo);
			}
			DwfOptions kb = this.KB;
			if (kb == null)
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
				\u000E\u0011\u0003.\u0018(kb, templateInfo);
			}
			NwcOptions pq = this.PQ;
			if (pq == null)
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
				\u0005\u0011\u0003.\u0018(pq, templateInfo);
			}
			IfcOptions bq = this.BQ;
			if (bq == null)
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
				\u001B\u0011\u0003.\u0018(bq, templateInfo);
			}
			ImgOptions qq = this.QQ;
			if (qq == null)
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
				\u0001\u0011\u0003.\u0018(qq, templateInfo);
			}
			\u001E\u000A\u0018.\u0014(\u0004\u0005\u0018.\u0018().GetService<XmlExporterViewModel>(false), templateInfo);
			\u0007\u0018\u0003.\u0018(this.CQ, new bool?(value));
			\u0007\u0018\u0003.\u0018(this.IQ, new bool?(value2));
			\u0007\u0018\u0003.\u0018(this.LQ, new bool?(value3));
			\u0007\u0018\u0003.\u0018(this.AQ, new bool?(value4));
			\u0007\u0018\u0003.\u0018(this.KQ, new bool?(value5));
			\u0007\u0018\u0003.\u0018(this.QJ, new bool?(value6));
			\u0007\u0018\u0003.\u0018(this.RJ, new bool?(value7));
			\u0007\u0018\u0003.\u0018(this.ZJ, new bool?(value8));
			if (this.AB != null)
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
				if (this.FQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.AB);
					goto IL_496;
				}
			}
			if (this.VB != null)
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
				if (this.RQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.VB);
					goto IL_496;
				}
			}
			if (this.DB != null)
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
				if (this.HQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.DB);
					goto IL_496;
				}
			}
			if (this.KB != null)
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
				if (this.NQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.KB);
					goto IL_496;
				}
			}
			if (this.PQ != null)
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
				if (this.ZQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.PQ);
					goto IL_496;
				}
			}
			if (this.BQ != null)
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
				if (this.MQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.BQ);
					goto IL_496;
				}
			}
			if (this.QQ != null)
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
				if (this.XQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.QQ);
					goto IL_496;
				}
			}
			if (this.JQ != null)
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
				if (this.YQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.JQ);
				}
			}
			IL_496:
			bool? flag = \u001B\u0001\u0018.\u0018(this.CQ);
			\u0008\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.IQ);
			\u0006\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.LQ);
			\u0010\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.AQ);
			\u0007\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.KQ);
			\u0019\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.QJ);
			\u000B\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.RJ);
			\u001A\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			flag = \u001B\u0001\u0018.\u0018(this.ZJ);
			\u001D\u0011\u0003.\u0018(templateInfo, \u000F\u0014\u0003.\u0018(ref flag));
			this.GB = false;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0002EFF0 File Offset: 0x0002D1F0
		private void btnIMG_Click(object sender, RoutedEventArgs e)
		{
			if (this.QQ != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.btnIMG_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.XQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.QQ);
				}
			}
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0002F03C File Offset: 0x0002D23C
		private void chkIMG_Checked(object sender, RoutedEventArgs e)
		{
			if (this.QQ == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.chkIMG_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				this.QQ = \u0003\u0015\u0003.\u0018(this.YB);
			}
			\u0018\u0009\u0014.\u0018(this.YJ, this.QQ);
			this.XQ = true;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0002F090 File Offset: 0x0002D290
		private void chkIMG_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.QQ, this.RJ, ref this.XQ);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0002F0B8 File Offset: 0x0002D2B8
		private void btnIFC_Click(object sender, RoutedEventArgs e)
		{
			if (this.BQ != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.btnIFC_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.MQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.BQ);
				}
			}
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0002F104 File Offset: 0x0002D304
		private void chkIFC_Checked(object sender, RoutedEventArgs e)
		{
			if (this.BQ == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.chkIFC_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				\u0014\u0019\u0018.\u0018(this.QJ, true);
				try
				{
					this.BQ = \u0016\u0015\u0003.\u0018(this.YB);
				}
				catch (Exception u)
				{
					\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\UI\\Export.xaml.cs", "chkIFC_Checked");
					\u0007\u0018\u0003.\u0018(this.QJ, new bool?(false));
					\u0014\u0019\u0018.\u0018(this.QJ, false);
				}
			}
			if (this.BQ != null)
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
				\u0018\u0009\u0014.\u0018(this.YJ, this.BQ);
				this.MQ = true;
			}
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0002F1C0 File Offset: 0x0002D3C0
		private void chkIFC_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.BQ, this.QJ, ref this.MQ);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0002F1E8 File Offset: 0x0002D3E8
		private void btnNWC_Click(object sender, RoutedEventArgs e)
		{
			if (this.PQ != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.btnNWC_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.ZQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.PQ);
				}
			}
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0002F234 File Offset: 0x0002D434
		private void chkNWC_Checked(object sender, RoutedEventArgs e)
		{
			bool flag;
			if (!\u000D\u0015\u0003.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.chkNWC_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				flag = this.GB;
			}
			else
			{
				flag = true;
			}
			if (flag)
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
				if (this.PQ == null)
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
					this.PQ = \u0012\u0015\u0003.\u0018();
				}
				\u0018\u0009\u0014.\u0018(this.YJ, this.PQ);
				this.ZQ = true;
				return;
			}
			NwcNotInstalledWarning u000C = \u000F\u0015\u0003.\u0018();
			\u0012\u000A\u0014.\u0018(u000C, this);
			\u001E\u0007\u0018.\u0014(u000C);
			\u0007\u0018\u0003.\u0018(this.KQ, new bool?(false));
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x0002F2D4 File Offset: 0x0002D4D4
		private void chkNWC_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.PQ, this.KQ, ref this.ZQ);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x0002F2FC File Offset: 0x0002D4FC
		private void btnDWF_Click(object sender, RoutedEventArgs e)
		{
			if (this.KB != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.btnDWF_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.NQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.KB);
				}
			}
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x0002F348 File Offset: 0x0002D548
		private void chkDWF_Checked(object sender, RoutedEventArgs e)
		{
			if (this.KB == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.chkDWF_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				this.KB = \u001C\u0015\u0003.\u0018(this.YB, this.OQ);
			}
			\u0018\u0009\u0014.\u0018(this.YJ, this.KB);
			this.NQ = true;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x0002F3A4 File Offset: 0x0002D5A4
		private void chkDWF_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.KB, this.AQ, ref this.NQ);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x0002F3CC File Offset: 0x0002D5CC
		private void ChkDGN_Checked(object sender, RoutedEventArgs e)
		{
			if (this.DB == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.ChkDGN_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				this.DB = \u0013\u0015\u0003.\u0018(this.EB);
			}
			\u0018\u0009\u0014.\u0018(this.YJ, this.DB);
			this.HQ = true;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x0002F420 File Offset: 0x0002D620
		private void ChkDGN_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.DB, this.LQ, ref this.HQ);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x0002F448 File Offset: 0x0002D648
		private void BtnDgn_Click(object sender, RoutedEventArgs e)
		{
			if (this.DB != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.BtnDgn_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.HQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.DB);
				}
			}
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x0002F494 File Offset: 0x0002D694
		private void ChkDWG_Checked(object sender, RoutedEventArgs e)
		{
			if (this.VB == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.ChkDWG_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				this.VB = \u0009\u0015\u0003.\u0018(this.LB, this.YB);
			}
			\u0018\u0009\u0014.\u0018(this.YJ, this.VB);
			this.RQ = true;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x0002F4F0 File Offset: 0x0002D6F0
		private void ChkDWG_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.VB, this.IQ, ref this.RQ);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x0002F518 File Offset: 0x0002D718
		private void BtnDwg_Click(object sender, RoutedEventArgs e)
		{
			if (this.VB != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.BtnDwg_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.RQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.VB);
				}
			}
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x0002F564 File Offset: 0x0002D764
		private void ChkPDF_Checked(object sender, RoutedEventArgs e)
		{
			if (this.AB == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.ChkPDF_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				this.AB = \u000A\u0015\u0003.\u0018(this.YB, this.OQ);
			}
			\u0018\u0009\u0014.\u0018(this.YJ, this.AB);
			this.FQ = true;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0002F5C0 File Offset: 0x0002D7C0
		private void UserControl_Loaded(object sender, RoutedEventArgs e)
		{
			\u000C\u0010\u0018.\u0018(\u0018\u0010\u0018.\u0018(\u0014\u0010\u0018.\u0018(this)));
			\u000E\u0007\u0018.\u0018(this);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x0002F5E8 File Offset: 0x0002D7E8
		private void ChkPDF_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.AB, this.CQ, ref this.FQ);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0002F610 File Offset: 0x0002D810
		private void BtnPdf_Click(object sender, RoutedEventArgs e)
		{
			if (this.AB != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.BtnPdf_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.FQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.AB);
				}
			}
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x0002F65C File Offset: 0x0002D85C
		private void VR()
		{
			if (\u0014\u001F\u0018.\u000F(\u0011\u0015\u0003.\u0018(this), IocContainer.GetService<ICustomLogger>()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.VR()).MethodHandle;
				}
				\u0014\u0019\u0018.\u0018(this.CQ, true);
				return;
			}
			List<Export.\u0008\u000A\u0018> list = \u001F\u0015\u0003.\u0018(8);
			Export.\u0008\u000A\u0018 u0008_u000A_u = new Export.\u0008\u000A\u0018();
			bool? flag = \u001B\u0001\u0018.\u0018(this.CQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u);
			Export.\u0008\u000A\u0018 u0008_u000A_u2 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.IQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u2, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u2);
			Export.\u0008\u000A\u0018 u0008_u000A_u3 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.LQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u3, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u3);
			Export.\u0008\u000A\u0018 u0008_u000A_u4 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.AQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u4, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u4);
			Export.\u0008\u000A\u0018 u0008_u000A_u5 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.KQ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u5, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u5);
			Export.\u0008\u000A\u0018 u0008_u000A_u6 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.QJ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u6, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u6);
			Export.\u0008\u000A\u0018 u0008_u000A_u7 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.RJ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u7, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u7);
			Export.\u0008\u000A\u0018 u0008_u000A_u8 = new Export.\u0008\u000A\u0018();
			flag = \u001B\u0001\u0018.\u0018(this.ZJ);
			\u0016\u0011\u0003.\u0018(u0008_u000A_u8, \u000C\u0007\u0018.\u0018(ref flag));
			\u0003\u0011\u0003.\u0018(list, u0008_u000A_u8);
			List<Export.\u0008\u000A\u0018> list2 = list;
			\u0014\u0019\u0018.\u0018(this.CQ, false);
			if (\u001E\u0011\u0003.\u0018(\u0020\u0015\u0003.\u0018(list2, 0)))
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
				IEnumerable<Export.\u0008\u000A\u0018> enumerable = Enumerable.Skip<Export.\u0008\u000A\u0018>(list2, 1);
				Func<Export.\u0008\u000A\u0018, bool> func;
				if ((func = Export.<>c.\u0016) == null)
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
					func = (Export.<>c.\u0016 = new Func<Export.\u0008\u000A\u0018, bool>(Export.<>c.\u000C.\u0009));
				}
				if (!Enumerable.Any<Export.\u0008\u000A\u0018>(enumerable, func))
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
					\u0007\u0018\u0003.\u0018(this.IQ, new bool?(true));
				}
				\u0007\u0018\u0003.\u0018(this.CQ, new bool?(false));
			}
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x0002F87C File Offset: 0x0002DA7C
		private unsafe void DR(UserControl P, CheckBox Q, ref bool J)
		{
			J = false;
			if (\u0002\u000B\u0018.\u0018(this.YJ) != P)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.DR(UserControl, CheckBox, bool*)).MethodHandle;
				}
				return;
			}
			UserControl userControl = this.KR(P);
			if (userControl != null)
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
				\u0018\u0009\u0014.\u0018(this.YJ, userControl);
				return;
			}
			\u0007\u0018\u0003.\u0018(Q, new bool?(true));
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x0002F8E0 File Offset: 0x0002DAE0
		private UserControl KR(UserControl P)
		{
			Export.\u0001\u000A\u0018 u0001_u000A_u = new Export.\u0001\u000A\u0018();
			u0001_u000A_u.\u000C = P;
			List<Export.\u0006\u000A\u0018> list = \u000C\u0017\u0003.\u0018();
			Export.\u0006\u000A\u0018 u0006_u000A_u = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u, this.AB);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u, this.FQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u);
			Export.\u0006\u000A\u0018 u0006_u000A_u2 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u2, this.VB);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u2, this.RQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u2);
			Export.\u0006\u000A\u0018 u0006_u000A_u3 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u3, this.DB);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u3, this.HQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u3);
			Export.\u0006\u000A\u0018 u0006_u000A_u4 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u4, this.KB);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u4, this.NQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u4);
			Export.\u0006\u000A\u0018 u0006_u000A_u5 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u5, this.PQ);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u5, this.ZQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u5);
			Export.\u0006\u000A\u0018 u0006_u000A_u6 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u6, this.BQ);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u6, this.MQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u6);
			Export.\u0006\u000A\u0018 u0006_u000A_u7 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u7, this.QQ);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u7, this.XQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u7);
			Export.\u0006\u000A\u0018 u0006_u000A_u8 = new Export.\u0006\u000A\u0018();
			\u000E\u0015\u0003.\u0018(u0006_u000A_u8, this.JQ);
			\u0005\u0015\u0003.\u0018(u0006_u000A_u8, this.YQ);
			\u001B\u0015\u0003.\u0018(list, u0006_u000A_u8);
			List<Export.\u0006\u000A\u0018> list2 = list;
			int num = \u0001\u0015\u0003.\u0018(list2, Enumerable.FirstOrDefault<Export.\u0006\u000A\u0018>(list2, new Func<Export.\u0006\u000A\u0018, bool>(u0001_u000A_u.\u0018)));
			IEnumerable<object> enumerable = Enumerable.Take<Export.\u0006\u000A\u0018>(list2, num);
			Func<object, bool> func;
			if ((func = Export.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.KR(UserControl)).MethodHandle;
				}
				func = (Export.<>c.\u000F = delegate(dynamic x)
				{
					if (Export.\u001B\u000A\u0018.\u0018 == null)
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
							RuntimeMethodHandle runtimeMethodHandle2 = methodof(Export.<>c.<GetNearestControl>b__56_1(object)).MethodHandle;
						}
						Export.\u001B\u000A\u0018.\u0018 = \u0006\u0015\u0003.\u0018(\u001A\u0015\u0003.\u0018(CSharpBinderFlags.None, \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C())));
					}
					object target3 = Export.\u001B\u000A\u0018.\u0018.Target;
					CallSite u9 = Export.\u001B\u000A\u0018.\u0018;
					if (Export.\u001B\u000A\u0018.\u000C == null)
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
						CSharpBinderFlags u000C4 = CSharpBinderFlags.None;
						string u10 = "IsChecked";
						Type u11 = \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C());
						CSharpArgumentInfo[] array4 = \u0006\u0019\u000F.\u000C(1);
						array4[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
						Export.\u001B\u000A\u0018.\u000C = \u001E\u0015\u0003.\u0018(\u0002\u0015\u0003.\u0018(u000C4, u10, u11, array4));
					}
					return \u000B\u0015\u0003.\u0018(target3, u9, \u0017\u0015\u0003.\u0018(Export.\u001B\u000A\u0018.\u000C.Target, Export.\u001B\u000A\u0018.\u000C, x));
				});
			}
			object obj = Enumerable.LastOrDefault<object>(enumerable, func);
			if (Export.\u001B\u000A\u0018.\u0003 == null)
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
				CSharpBinderFlags u000C = CSharpBinderFlags.None;
				ExpressionType u = 83;
				Type u2 = \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C());
				CSharpArgumentInfo[] array = \u0006\u0019\u000F.\u000C(1);
				array[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
				Export.\u001B\u000A\u0018.\u0003 = \u0006\u0015\u0003.\u0018(\u0008\u0015\u0003.\u0018(u000C, u, u2, array));
			}
			object target = Export.\u001B\u000A\u0018.\u0003.Target;
			CallSite u3 = Export.\u001B\u000A\u0018.\u0003;
			if (Export.\u001B\u000A\u0018.\u0014 == null)
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
				CSharpBinderFlags u000C2 = CSharpBinderFlags.None;
				ExpressionType u4 = 13;
				Type u5 = \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C());
				CSharpArgumentInfo[] array2 = \u0006\u0019\u000F.\u000C(2);
				array2[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
				array2[1] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.Constant, \u0005\u001E\u000F.\u000C);
				Export.\u001B\u000A\u0018.\u0014 = \u0007\u0015\u0003.\u0018(\u0010\u0015\u0003.\u0018(u000C2, u4, u5, array2));
			}
			if (\u000B\u0015\u0003.\u0018(target, u3, \u0019\u0015\u0003.\u0018(Export.\u001B\u000A\u0018.\u0014.Target, Export.\u001B\u000A\u0018.\u0014, obj, \u001F\u0002\u000F.\u000C)))
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
				IEnumerable<object> enumerable2 = Enumerable.Skip<Export.\u0006\u000A\u0018>(list2, num + 1);
				Func<object, bool> func2;
				if ((func2 = Export.<>c.\u0012) == null)
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
					func2 = (Export.<>c.\u0012 = delegate(dynamic x)
					{
						if (Export.\u001B\u000A\u0018.\u000F == null)
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
								RuntimeMethodHandle runtimeMethodHandle2 = methodof(Export.<>c.<GetNearestControl>b__56_2(object)).MethodHandle;
							}
							Export.\u001B\u000A\u0018.\u000F = \u0006\u0015\u0003.\u0018(\u001A\u0015\u0003.\u0018(CSharpBinderFlags.None, \u000A\u001D\u0018.\u0018(\u000B\u0002\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C())));
						}
						object target3 = Export.\u001B\u000A\u0018.\u000F.Target;
						CallSite u000F = Export.\u001B\u000A\u0018.\u000F;
						if (Export.\u001B\u000A\u0018.\u0016 == null)
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
							CSharpBinderFlags u000C4 = CSharpBinderFlags.None;
							string u9 = "IsChecked";
							Type u10 = \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C());
							CSharpArgumentInfo[] array4 = \u0006\u0019\u000F.\u000C(1);
							array4[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
							Export.\u001B\u000A\u0018.\u0016 = \u001E\u0015\u0003.\u0018(\u0002\u0015\u0003.\u0018(u000C4, u9, u10, array4));
						}
						return \u000B\u0015\u0003.\u0018(target3, u000F, \u0017\u0015\u0003.\u0018(Export.\u001B\u000A\u0018.\u0016.Target, Export.\u001B\u000A\u0018.\u0016, x));
					});
				}
				obj = Enumerable.FirstOrDefault<object>(enumerable2, func2);
			}
			if (Export.\u001B\u000A\u0018.\u000D == null)
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
				Export.\u001B\u000A\u0018.\u000D = \u001D\u0015\u0003.\u0018(\u001A\u0015\u0003.\u0018(CSharpBinderFlags.None, \u000A\u001D\u0018.\u0018(\u0008\u0019\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C())));
			}
			object target2 = Export.\u001B\u000A\u0018.\u000D.Target;
			CallSite u000D = Export.\u001B\u000A\u0018.\u000D;
			object obj2 = obj;
			object u6;
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
				u6 = \u001F\u0002\u000F.\u000C;
			}
			else
			{
				if (Export.\u001B\u000A\u0018.\u0012 == null)
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
					CSharpBinderFlags u000C3 = CSharpBinderFlags.None;
					string u7 = "PanelItem";
					Type u8 = \u000A\u001D\u0018.\u0018(\u0010\u0019\u000F.\u000C());
					CSharpArgumentInfo[] array3 = \u0006\u0019\u000F.\u000C(1);
					array3[0] = \u0004\u0015\u0003.\u0018(CSharpArgumentInfoFlags.None, \u0005\u001E\u000F.\u000C);
					Export.\u001B\u000A\u0018.\u0012 = \u001E\u0015\u0003.\u0018(\u0002\u0015\u0003.\u0018(u000C3, u7, u8, array3));
				}
				u6 = \u0017\u0015\u0003.\u0018(Export.\u001B\u000A\u0018.\u0012.Target, Export.\u001B\u000A\u0018.\u0012, obj2);
			}
			return \u0015\u0015\u0003.\u0018(target2, u000D, u6);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0002FC78 File Offset: 0x0002DE78
		internal void PH()
		{
			if (this.AB != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.PH()).MethodHandle;
				}
				this.AB.PH();
			}
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x0002FCAC File Offset: 0x0002DEAC
		private void ChkXml_Checked(object sender, RoutedEventArgs e)
		{
			if (this.JQ == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.ChkXml_Checked(object, RoutedEventArgs)).MethodHandle;
				}
				this.JQ = \u0014\u0017\u0003.\u0018();
			}
			XmlExporterViewModel service = \u0004\u0005\u0018.\u0018().GetService<XmlExporterViewModel>(false);
			\u0018\u0017\u0003.\u0018(this.JQ, \u000C\u000D\u0003.\u0014(service), \u0014\u000D\u0003.\u0014(service));
			\u0018\u0009\u0014.\u0018(this.YJ, this.JQ);
			this.YQ = true;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x0002FD24 File Offset: 0x0002DF24
		private void ChkXml_Unchecked(object sender, RoutedEventArgs e)
		{
			this.DR(this.JQ, this.ZJ, ref this.YQ);
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x0002FD4C File Offset: 0x0002DF4C
		private void BtnXml_Click(object sender, RoutedEventArgs e)
		{
			if (this.JQ != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(Export.BtnXml_Click(object, RoutedEventArgs)).MethodHandle;
				}
				if (this.YQ)
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
					\u0018\u0009\u0014.\u0018(this.YJ, this.JQ);
				}
			}
		}

		// Token: 0x0400036A RID: 874
		private Document YB;

		// Token: 0x0400036B RID: 875
		public static bool isPDFCombineFile;

		// Token: 0x0400036C RID: 876
		public static bool isDWFCombineFile;

		// Token: 0x0400036D RID: 877
		private List<string> LB = new List<string>();

		// Token: 0x0400036E RID: 878
		private List<string> EB = new List<string>();

		// Token: 0x0400036F RID: 879
		private bool GB;

		// Token: 0x04000370 RID: 880
		private PdfOptions AB;

		// Token: 0x04000371 RID: 881
		private DwgOptions VB;

		// Token: 0x04000372 RID: 882
		private DngOptions DB;

		// Token: 0x04000373 RID: 883
		private DwfOptions KB;

		// Token: 0x04000374 RID: 884
		private NwcOptions PQ;

		// Token: 0x04000375 RID: 885
		private IfcOptions BQ;

		// Token: 0x04000376 RID: 886
		private ImgOptions QQ;

		// Token: 0x04000377 RID: 887
		private XmlParameterManager JQ;

		// Token: 0x04000378 RID: 888
		private bool FQ;

		// Token: 0x04000379 RID: 889
		private bool RQ;

		// Token: 0x0400037A RID: 890
		private bool HQ;

		// Token: 0x0400037B RID: 891
		private bool NQ;

		// Token: 0x0400037C RID: 892
		private bool ZQ;

		// Token: 0x0400037D RID: 893
		private bool MQ;

		// Token: 0x0400037E RID: 894
		private bool XQ;

		// Token: 0x0400037F RID: 895
		private bool YQ;

		// Token: 0x04000380 RID: 896
		private ParameterBaseModel OQ;

		// Token: 0x020001A1 RID: 417
		private sealed class \u0006\u000A\u0018
		{
			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x06001154 RID: 4436 RVA: 0x0005C610 File Offset: 0x0005A810
			// (set) Token: 0x06001155 RID: 4437 RVA: 0x0005C624 File Offset: 0x0005A824
			public UserControl PanelItem { get; set; }

			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x06001156 RID: 4438 RVA: 0x0005C638 File Offset: 0x0005A838
			// (set) Token: 0x06001157 RID: 4439 RVA: 0x0005C64C File Offset: 0x0005A84C
			public bool IsChecked { get; set; }

			// Token: 0x04000815 RID: 2069
			[CompilerGenerated]
			private UserControl \u000C;

			// Token: 0x04000816 RID: 2070
			[CompilerGenerated]
			private bool \u0018;
		}

		// Token: 0x020001A2 RID: 418
		private class \u0008\u000A\u0018
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06001159 RID: 4441 RVA: 0x0005C674 File Offset: 0x0005A874
			// (set) Token: 0x0600115A RID: 4442 RVA: 0x0005C688 File Offset: 0x0005A888
			public CheckBox Control { get; set; }

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x0600115B RID: 4443 RVA: 0x0005C69C File Offset: 0x0005A89C
			// (set) Token: 0x0600115C RID: 4444 RVA: 0x0005C6B0 File Offset: 0x0005A8B0
			public bool IsChecked { get; set; }

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x0600115D RID: 4445 RVA: 0x0005C6C4 File Offset: 0x0005A8C4
			// (set) Token: 0x0600115E RID: 4446 RVA: 0x0005C6D8 File Offset: 0x0005A8D8
			public bool IsCurrentSelection { get; set; }

			// Token: 0x04000817 RID: 2071
			[CompilerGenerated]
			private CheckBox \u000C;

			// Token: 0x04000818 RID: 2072
			[CompilerGenerated]
			private bool \u0018;

			// Token: 0x04000819 RID: 2073
			[CompilerGenerated]
			private bool \u0014;
		}

		// Token: 0x020001A4 RID: 420
		[CompilerGenerated]
		private sealed class \u0001\u000A\u0018
		{
			// Token: 0x06001168 RID: 4456 RVA: 0x0005C954 File Offset: 0x0005AB54
			internal bool \u0018(Export.\u0006\u000A\u0018 \u000C)
			{
				return \u0005\u0020\u000F.\u0018(\u000C) == this.\u000C;
			}

			// Token: 0x04000821 RID: 2081
			public UserControl \u000C;
		}

		// Token: 0x020001A5 RID: 421
		[CompilerGenerated]
		private static class \u001B\u000A\u0018
		{
			// Token: 0x04000822 RID: 2082
			public static CallSite<Func<CallSite, object, object>> \u000C;

			// Token: 0x04000823 RID: 2083
			public static CallSite<Func<CallSite, object, bool>> \u0018;

			// Token: 0x04000824 RID: 2084
			public static CallSite<Func<CallSite, object, object, object>> \u0014;

			// Token: 0x04000825 RID: 2085
			public static CallSite<Func<CallSite, object, bool>> \u0003;

			// Token: 0x04000826 RID: 2086
			public static CallSite<Func<CallSite, object, object>> \u0016;

			// Token: 0x04000827 RID: 2087
			public static CallSite<Func<CallSite, object, bool>> \u000F;

			// Token: 0x04000828 RID: 2088
			public static CallSite<Func<CallSite, object, object>> \u0012;

			// Token: 0x04000829 RID: 2089
			public static CallSite<Func<CallSite, object, UserControl>> \u000D;
		}
	}
}
