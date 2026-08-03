using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using A;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x02000379 RID: 889
	[XmlInclude(typeof(RevisionParameter))]
	[XmlInclude(typeof(SelectionParameter))]
	[XmlInclude(typeof(ParameterModel))]
	[XmlInclude(typeof(ParameterIntegerValue))]
	[XmlInclude(typeof(ParameterStringValue))]
	[XmlInclude(typeof(ParameterIdValue))]
	[Serializable]
	public class SGProfile : Profile
	{
		// Token: 0x0600247A RID: 9338 RVA: 0x000DEFD0 File Offset: 0x000DD1D0
		public SGProfile()
		{
			\u001A\u0015\u000B.\u000A(this, true);
		}

		// Token: 0x17000A4E RID: 2638
		// (get) Token: 0x0600247B RID: 9339 RVA: 0x000DEFEC File Offset: 0x000DD1EC
		// (set) Token: 0x0600247C RID: 9340 RVA: 0x000DF000 File Offset: 0x000DD200
		public override string Name { get; set; }

		// Token: 0x17000A4F RID: 2639
		// (get) Token: 0x0600247D RID: 9341 RVA: 0x000DF014 File Offset: 0x000DD214
		// (set) Token: 0x0600247E RID: 9342 RVA: 0x000DF028 File Offset: 0x000DD228
		public override bool IsValid { get; set; }

		// Token: 0x17000A50 RID: 2640
		// (get) Token: 0x0600247F RID: 9343 RVA: 0x000DF03C File Offset: 0x000DD23C
		// (set) Token: 0x06002480 RID: 9344 RVA: 0x000DF050 File Offset: 0x000DD250
		public override string FilePath { get; set; }

		// Token: 0x17000A51 RID: 2641
		// (get) Token: 0x06002481 RID: 9345 RVA: 0x000DF064 File Offset: 0x000DD264
		// (set) Token: 0x06002482 RID: 9346 RVA: 0x000DF078 File Offset: 0x000DD278
		public List<List<SelectionParameter>> SheetParameters { get; set; }

		// Token: 0x17000A52 RID: 2642
		// (get) Token: 0x06002483 RID: 9347 RVA: 0x000DF08C File Offset: 0x000DD28C
		// (set) Token: 0x06002484 RID: 9348 RVA: 0x000DF0A0 File Offset: 0x000DD2A0
		public List<List<SelectionParameter>> PlaceholderParameters { get; set; }

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06002485 RID: 9349 RVA: 0x000DF0B4 File Offset: 0x000DD2B4
		// (set) Token: 0x06002486 RID: 9350 RVA: 0x000DF0C8 File Offset: 0x000DD2C8
		public List<List<RevisionParameter>> RevisionParameters { get; set; }

		// Token: 0x06002487 RID: 9351 RVA: 0x000DF0DC File Offset: 0x000DD2DC
		internal static Profile \u001F(bool \u001F)
		{
			if (\u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SGProfile.\u001F(bool)).MethodHandle;
				}
				VMProfile vmprofile = \u0013\u0010\u000B.\u000A();
				\u0008\u001B\u000B.\u000A(vmprofile, \u000A\u000F\u001D.\u000A());
				\u001A\u0015\u000B.\u000A(vmprofile, false);
				return vmprofile;
			}
			SGProfile sgprofile = \u0017\u0010\u000B.\u000A();
			\u0008\u001B\u000B.\u000A(sgprofile, \u000A\u000F\u001D.\u000A());
			\u001A\u0015\u000B.\u000A(sgprofile, false);
			return sgprofile;
		}
	}
}
