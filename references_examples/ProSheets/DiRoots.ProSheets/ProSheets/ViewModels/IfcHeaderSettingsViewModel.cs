using System;
using System.Runtime.CompilerServices;
using A;
using Revit.IFC.Common.Extensions;

namespace ProSheets.ViewModels
{
	// Token: 0x02000084 RID: 132
	public class IfcHeaderSettingsViewModel
	{
		// Token: 0x060007E2 RID: 2018 RVA: 0x000288E8 File Offset: 0x00026AE8
		public IfcHeaderSettingsViewModel(IFCFileHeaderItem ifcHeaderSettings)
		{
			IFCFileHeaderItem u = ifcHeaderSettings;
			if (ifcHeaderSettings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcHeaderSettingsViewModel..ctor(IFCFileHeaderItem)).MethodHandle;
				}
				u = new IFCFileHeaderItem();
			}
			\u0002\u000D\u0003.\u0018(this, u);
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x00028920 File Offset: 0x00026B20
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x00028934 File Offset: 0x00026B34
		public IFCFileHeaderItem IfcHeaderSettings { get; set; }

		// Token: 0x04000318 RID: 792
		[CompilerGenerated]
		private IFCFileHeaderItem \u000C;
	}
}
