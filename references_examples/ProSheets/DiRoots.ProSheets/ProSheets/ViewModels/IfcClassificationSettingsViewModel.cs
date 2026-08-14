using System;
using System.Runtime.CompilerServices;
using A;
using ProSheets.Models;

namespace ProSheets.ViewModels
{
	// Token: 0x02000083 RID: 131
	public class IfcClassificationSettingsViewModel
	{
		// Token: 0x060007DF RID: 2015 RVA: 0x00028888 File Offset: 0x00026A88
		public IfcClassificationSettingsViewModel(IfcClassificationSettings ifcClassificationSettings)
		{
			IfcClassificationSettings u = ifcClassificationSettings;
			if (ifcClassificationSettings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(IfcClassificationSettingsViewModel..ctor(IfcClassificationSettings)).MethodHandle;
				}
				u = new IfcClassificationSettings();
			}
			\u001E\u000D\u0003.\u0018(this, u);
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x060007E0 RID: 2016 RVA: 0x000288C0 File Offset: 0x00026AC0
		// (set) Token: 0x060007E1 RID: 2017 RVA: 0x000288D4 File Offset: 0x00026AD4
		public IfcClassificationSettings ClassificationSettings { get; set; }

		// Token: 0x04000317 RID: 791
		[CompilerGenerated]
		private IfcClassificationSettings \u000C;
	}
}
