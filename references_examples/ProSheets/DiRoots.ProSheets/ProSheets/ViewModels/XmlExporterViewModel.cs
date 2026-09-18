using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.ProSheets.Xml.Interfaces;
using DiRoots.ProSheets.Xml.Models;
using DiRoots.ProSheets.Xml.ViewModels;
using ProSheets.Services;

namespace ProSheets.ViewModels
{
	// Token: 0x02000085 RID: 133
	public class XmlExporterViewModel
	{
		// Token: 0x060007E5 RID: 2021 RVA: 0x00028948 File Offset: 0x00026B48
		public XmlExporterViewModel(SelectionParametersCollector collector)
		{
			\u001D\u000D\u0003.\u0018(this, new XmlParameterBaseModel(\u001E\u000A\u0018.\u000C(collector.\u0020(true)), new List<IParameterInfo>(), this.\u0014(true)));
			\u0004\u000D\u0003.\u0018(this, new XmlParameterBaseModel(\u001E\u000A\u0018.\u000C(collector.\u0020(false)), new List<IParameterInfo>(), this.\u0014(false)));
			XmlExportOptions u = new XmlExportOptions();
			\u0016\u000D\u0003.\u0018(\u000C\u000D\u0003.\u0003(this), u);
			\u0016\u000D\u0003.\u0018(\u0014\u000D\u0003.\u0003(this), u);
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x060007E6 RID: 2022 RVA: 0x000289D0 File Offset: 0x00026BD0
		// (set) Token: 0x060007E7 RID: 2023 RVA: 0x000289E4 File Offset: 0x00026BE4
		public XmlParameterBaseModel SheetParameterModel { get; set; }

		// Token: 0x17000330 RID: 816
		// (get) Token: 0x060007E8 RID: 2024 RVA: 0x000289F8 File Offset: 0x00026BF8
		// (set) Token: 0x060007E9 RID: 2025 RVA: 0x00028A0C File Offset: 0x00026C0C
		public XmlParameterBaseModel ViewParameterModel { get; set; }

		// Token: 0x060007EA RID: 2026 RVA: 0x00028A20 File Offset: 0x00026C20
		private ComboBoxViewModel \u0014(bool \u000C = true)
		{
			ComboBoxViewModel comboBoxViewModel = \u0008\u000D\u0003.\u0018();
			List<IComboxItemModel> list = \u0006\u000D\u0003.\u0018();
			EnumInfo enumInfo = \u0010\u000D\u0003.\u0018();
			\u0007\u000D\u0003.\u0018(enumInfo, -1);
			\u0019\u000D\u0003.\u0018(enumInfo, \u000D\u0009\u0018.\u0011);
			\u000B\u000D\u0003.\u0018(list, enumInfo);
			EnumInfo enumInfo2 = \u0010\u000D\u0003.\u0018();
			\u0007\u000D\u0003.\u0018(enumInfo2, 1);
			\u0019\u000D\u0003.\u0018(enumInfo2, \u0019\u0020\u0018.\u0014);
			\u000B\u000D\u0003.\u0018(list, enumInfo2);
			EnumInfo enumInfo3 = \u0010\u000D\u0003.\u0018();
			\u0007\u000D\u0003.\u0018(enumInfo3, 0);
			string u;
			if (!\u000C)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(XmlExporterViewModel.\u0014(bool)).MethodHandle;
				}
				u = \u0019\u0020\u0018.\u0018;
			}
			else
			{
				u = \u0019\u0020\u0018.\u000C;
			}
			\u0019\u000D\u0003.\u0018(enumInfo3, u);
			\u000B\u000D\u0003.\u0018(list, enumInfo3);
			EnumInfo enumInfo4 = \u0010\u000D\u0003.\u0018();
			\u0007\u000D\u0003.\u0018(enumInfo4, 2);
			\u0019\u000D\u0003.\u0018(enumInfo4, \u0019\u0020\u0018.\u0003);
			\u000B\u000D\u0003.\u0018(list, enumInfo4);
			\u001A\u000D\u0003.\u0018(comboBoxViewModel, list);
			return comboBoxViewModel;
		}

		// Token: 0x04000319 RID: 793
		[CompilerGenerated]
		private XmlParameterBaseModel \u000C;

		// Token: 0x0400031A RID: 794
		[CompilerGenerated]
		private XmlParameterBaseModel \u0018;
	}
}
