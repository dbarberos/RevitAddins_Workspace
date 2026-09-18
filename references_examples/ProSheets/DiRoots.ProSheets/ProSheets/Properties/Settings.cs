using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using A;

namespace ProSheets.Properties
{
	// Token: 0x020000C0 RID: 192
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000AC8 RID: 2760 RVA: 0x00040DE4 File Offset: 0x0003EFE4
		// (set) Token: 0x06000AC9 RID: 2761 RVA: 0x00040DF8 File Offset: 0x0003EFF8
		public static List<double> SheetsDGColumnWidths { get; set; }

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000ACA RID: 2762 RVA: 0x00040E0C File Offset: 0x0003F00C
		// (set) Token: 0x06000ACB RID: 2763 RVA: 0x00040E20 File Offset: 0x0003F020
		public static List<double> ViewsDGColumnWidths { get; set; }

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000ACC RID: 2764 RVA: 0x00040E34 File Offset: 0x0003F034
		// (set) Token: 0x06000ACD RID: 2765 RVA: 0x00040E58 File Offset: 0x0003F058
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public StringCollection CustomParamColumns
		{
			get
			{
				return \u000F\u0010\u000F.\u000C(\u0016\u001C\u0016.\u0018(this, "CustomParamColumns"));
			}
			set
			{
				\u000F\u001C\u0016.\u0018(this, "CustomParamColumns", value);
			}
		}
	}
}
