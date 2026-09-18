using System;
using System.Runtime.CompilerServices;

namespace DiRoots.One.TGDatabaseLayer.StyleMapping
{
	// Token: 0x02000125 RID: 293
	public class GeneralMappingSetting
	{
		// Token: 0x1700030F RID: 783
		// (get) Token: 0x06000B0E RID: 2830 RVA: 0x00047228 File Offset: 0x00045428
		// (set) Token: 0x06000B0F RID: 2831 RVA: 0x0004723C File Offset: 0x0004543C
		public bool UseAdvancedMapping { get; set; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000B10 RID: 2832 RVA: 0x00047250 File Offset: 0x00045450
		// (set) Token: 0x06000B11 RID: 2833 RVA: 0x00047264 File Offset: 0x00045464
		public UpdateBehaviorOption UpdateBehavior
		{
			get
			{
				return this.\u000A;
			}
			set
			{
				UpdateBehaviorOption u000A;
				if (!GeneralMappingSetting.\u0019(value))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(GeneralMappingSetting.set_UpdateBehavior(UpdateBehaviorOption)).MethodHandle;
					}
					u000A = UpdateBehaviorOption.RecreateSchedule;
				}
				else
				{
					u000A = value;
				}
				this.\u000A = u000A;
			}
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x00047298 File Offset: 0x00045498
		private static bool \u0019(UpdateBehaviorOption \u001F)
		{
			if (\u001F != UpdateBehaviorOption.RecreateSchedule)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(GeneralMappingSetting.\u0019(UpdateBehaviorOption)).MethodHandle;
				}
				return \u001F == UpdateBehaviorOption.UpdateDataOnly;
			}
			return true;
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000B13 RID: 2835 RVA: 0x000472C4 File Offset: 0x000454C4
		// (set) Token: 0x06000B14 RID: 2836 RVA: 0x000472D8 File Offset: 0x000454D8
		public BlackAndWhiteTextLinesOption BlackAndWhiteTextLines { get; set; }

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000B15 RID: 2837 RVA: 0x000472EC File Offset: 0x000454EC
		// (set) Token: 0x06000B16 RID: 2838 RVA: 0x00047300 File Offset: 0x00045500
		public BlackAndWhiteBackgroundOption BlackAndWhiteBackground { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06000B17 RID: 2839 RVA: 0x00047314 File Offset: 0x00045514
		// (set) Token: 0x06000B18 RID: 2840 RVA: 0x00047328 File Offset: 0x00045528
		public DecimalSymbolOption DecimalSymbol { get; set; }

		// Token: 0x04000470 RID: 1136
		[CompilerGenerated]
		private bool \u001F;

		// Token: 0x04000471 RID: 1137
		private UpdateBehaviorOption \u000A;

		// Token: 0x04000472 RID: 1138
		[CompilerGenerated]
		private BlackAndWhiteTextLinesOption \u0007;

		// Token: 0x04000473 RID: 1139
		[CompilerGenerated]
		private BlackAndWhiteBackgroundOption \u001D;

		// Token: 0x04000474 RID: 1140
		[CompilerGenerated]
		private DecimalSymbolOption \u0004;
	}
}
