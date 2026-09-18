using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x0200016F RID: 367
	public class GeneralViewModel : ModelBase
	{
		// Token: 0x06000D90 RID: 3472 RVA: 0x00057888 File Offset: 0x00055A88
		public GeneralViewModel(GeneralMappingSetting generalMapping, Action onMarkDataChanged)
		{
			this.IR = generalMapping;
			this.QR = onMarkDataChanged;
			this.TR = \u0001\u0004\u0004.\u0007(this.IR);
			\u0002\u0012\u0019.\u000A(this, \u001D\u0016.\u001F());
			\u000B\u0012\u0019.\u000A(this, \u001D\u0016.\u000A());
			\u0016\u0012\u0019.\u000A(this, \u001D\u0016.\u0007());
			EnumInfo ar;
			if ((ar = Enumerable.FirstOrDefault<EnumInfo>(\u0005\u0012\u0019.\u000A(this), new Func<EnumInfo, bool>(this.VX))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(GeneralViewModel..ctor(GeneralMappingSetting, Action)).MethodHandle;
				}
				ar = Enumerable.FirstOrDefault<EnumInfo>(\u0005\u0012\u0019.\u000A(this));
			}
			this.AR = ar;
			EnumInfo gr;
			if ((gr = Enumerable.FirstOrDefault<EnumInfo>(\u0018\u0012\u0019.\u000A(this), new Func<EnumInfo, bool>(this.ZX))) == null)
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
				gr = Enumerable.FirstOrDefault<EnumInfo>(\u0018\u0012\u0019.\u000A(this));
			}
			this.GR = gr;
			EnumInfo fd;
			if ((fd = Enumerable.FirstOrDefault<EnumInfo>(\u0019\u0012\u0019.\u000A(this), new Func<EnumInfo, bool>(this.XX))) == null)
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
				fd = Enumerable.FirstOrDefault<EnumInfo>(\u0019\u0012\u0019.\u000A(this));
			}
			this.FD = fd;
			this.RD = \u0016\u0010\u0004.\u000A(this.IR);
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06000D91 RID: 3473 RVA: 0x000579BC File Offset: 0x00055BBC
		// (set) Token: 0x06000D92 RID: 3474 RVA: 0x000579D0 File Offset: 0x00055BD0
		public bool UseAdvancedMapping
		{
			get
			{
				return this.TR;
			}
			set
			{
				base.SetProperty<bool>(ref this.TR, value, this.QR, "UseAdvancedMapping");
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06000D93 RID: 3475 RVA: 0x000579F8 File Offset: 0x00055BF8
		// (set) Token: 0x06000D94 RID: 3476 RVA: 0x00057A0C File Offset: 0x00055C0C
		public List<EnumInfo> UpdateBehaviorOptions { get; set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06000D95 RID: 3477 RVA: 0x00057A20 File Offset: 0x00055C20
		// (set) Token: 0x06000D96 RID: 3478 RVA: 0x00057A34 File Offset: 0x00055C34
		public List<EnumInfo> BlackAndWhiteTextLinesOptions { get; set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06000D97 RID: 3479 RVA: 0x00057A48 File Offset: 0x00055C48
		// (set) Token: 0x06000D98 RID: 3480 RVA: 0x00057A5C File Offset: 0x00055C5C
		public List<EnumInfo> BlackAndWhiteBackgroundOptions { get; set; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06000D99 RID: 3481 RVA: 0x00057A70 File Offset: 0x00055C70
		// (set) Token: 0x06000D9A RID: 3482 RVA: 0x00057A84 File Offset: 0x00055C84
		public EnumInfo SelectedUpdateBehavior
		{
			get
			{
				return this.AR;
			}
			set
			{
				base.SetProperty<EnumInfo>(ref this.AR, value, this.QR, "SelectedUpdateBehavior");
			}
		}

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06000D9B RID: 3483 RVA: 0x00057AAC File Offset: 0x00055CAC
		// (set) Token: 0x06000D9C RID: 3484 RVA: 0x00057AC0 File Offset: 0x00055CC0
		public EnumInfo SelectedBlackAndWhiteTextLines
		{
			get
			{
				return this.GR;
			}
			set
			{
				base.SetProperty<EnumInfo>(ref this.GR, value, this.QR, "SelectedBlackAndWhiteTextLines");
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x06000D9D RID: 3485 RVA: 0x00057AE8 File Offset: 0x00055CE8
		// (set) Token: 0x06000D9E RID: 3486 RVA: 0x00057AFC File Offset: 0x00055CFC
		public EnumInfo SelectedBlackAndWhiteBackground
		{
			get
			{
				return this.FD;
			}
			set
			{
				base.SetProperty<EnumInfo>(ref this.FD, value, this.QR, "SelectedBlackAndWhiteBackground");
			}
		}

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x06000D9F RID: 3487 RVA: 0x00057B24 File Offset: 0x00055D24
		// (set) Token: 0x06000DA0 RID: 3488 RVA: 0x00057B38 File Offset: 0x00055D38
		public DecimalSymbolOption SelectedSystemDecimalSettings
		{
			get
			{
				return this.RD;
			}
			set
			{
				base.SetProperty<DecimalSymbolOption>(ref this.RD, value, this.QR, "SelectedSystemDecimalSettings");
			}
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x00057B60 File Offset: 0x00055D60
		public GeneralMappingSetting GetGeneralMapping()
		{
			\u0001\u001C\u0004.\u000A(this.IR, this.TR);
			object ir = this.IR;
			EnumInfo enumInfo = \u0010\u0012\u0019.\u000A(this);
			UpdateBehaviorOption u000A;
			if (enumInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(GeneralViewModel.GetGeneralMapping()).MethodHandle;
				}
				u000A = UpdateBehaviorOption.RecreateSchedule;
			}
			else
			{
				u000A = (UpdateBehaviorOption)\u000D\u001B\u001D.\u001D(enumInfo);
			}
			\u000D\u0012\u0019.\u000A(ir, u000A);
			object ir2 = this.IR;
			EnumInfo enumInfo2 = \u001C\u0012\u0019.\u0007(this);
			BlackAndWhiteTextLinesOption u000A2;
			if (enumInfo2 == null)
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
				u000A2 = BlackAndWhiteTextLinesOption.ConvertAllColorsToBlack;
			}
			else
			{
				u000A2 = (BlackAndWhiteTextLinesOption)\u000D\u001B\u001D.\u001D(enumInfo2);
			}
			\u0003\u0012\u0019.\u000A(ir2, u000A2);
			object ir3 = this.IR;
			EnumInfo enumInfo3 = \u0012\u0012\u0019.\u0007(this);
			BlackAndWhiteBackgroundOption u000A3;
			if (enumInfo3 == null)
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
				u000A3 = BlackAndWhiteBackgroundOption.RemoveAllBackgrounds;
			}
			else
			{
				u000A3 = (BlackAndWhiteBackgroundOption)\u000D\u001B\u001D.\u001D(enumInfo3);
			}
			\u000F\u0012\u0019.\u000A(ir3, u000A3);
			\u0006\u0012\u0019.\u000A(this.IR, this.RD);
			return this.IR;
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x00057C20 File Offset: 0x00055E20
		public void UpdateMapping(GeneralMappingSetting mapping)
		{
			GeneralViewModel.\u0017\u000B u0017_u000B = new GeneralViewModel.\u0017\u000B();
			u0017_u000B.\u001F = mapping;
			this.IR = u0017_u000B.\u001F;
			\u001E\u0012\u0019.\u000A(this, \u0001\u0004\u0004.\u0007(u0017_u000B.\u001F));
			EnumInfo u000A;
			if ((u000A = Enumerable.FirstOrDefault<EnumInfo>(\u0005\u0012\u0019.\u000A(this), new Func<EnumInfo, bool>(u0017_u000B.\u000A))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(GeneralViewModel.UpdateMapping(GeneralMappingSetting)).MethodHandle;
				}
				u000A = Enumerable.FirstOrDefault<EnumInfo>(\u0005\u0012\u0019.\u000A(this));
			}
			\u0011\u0012\u0019.\u000A(this, u000A);
			EnumInfo u000A2;
			if ((u000A2 = Enumerable.FirstOrDefault<EnumInfo>(\u0018\u0012\u0019.\u000A(this), new Func<EnumInfo, bool>(u0017_u000B.\u0007))) == null)
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
				u000A2 = Enumerable.FirstOrDefault<EnumInfo>(\u0018\u0012\u0019.\u000A(this));
			}
			\u001B\u0012\u0019.\u000A(this, u000A2);
			EnumInfo u000A3;
			if ((u000A3 = Enumerable.FirstOrDefault<EnumInfo>(\u0019\u0012\u0019.\u000A(this), new Func<EnumInfo, bool>(u0017_u000B.\u001D))) == null)
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
				u000A3 = Enumerable.FirstOrDefault<EnumInfo>(\u0019\u0012\u0019.\u000A(this));
			}
			\u0008\u0012\u0019.\u000A(this, u000A3);
			\u000E\u0012\u0019.\u000A(this, \u0016\u0010\u0004.\u000A(u0017_u000B.\u001F));
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x00057D30 File Offset: 0x00055F30
		[CompilerGenerated]
		private bool VX(EnumInfo F)
		{
			return \u000D\u001B\u001D.\u0007(F) == (int)\u0012\u000B\u0004.\u0007(this.IR);
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x00057D54 File Offset: 0x00055F54
		[CompilerGenerated]
		private bool ZX(EnumInfo F)
		{
			return \u000D\u001B\u001D.\u0007(F) == (int)\u0005\u0010\u0004.\u0007(this.IR);
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x00057D78 File Offset: 0x00055F78
		[CompilerGenerated]
		private bool XX(EnumInfo F)
		{
			return \u000D\u001B\u001D.\u0007(F) == (int)\u0018\u0010\u0004.\u000A(this.IR);
		}

		// Token: 0x0400055D RID: 1373
		private bool TR;

		// Token: 0x0400055E RID: 1374
		private GeneralMappingSetting IR;

		// Token: 0x0400055F RID: 1375
		private readonly Action QR;

		// Token: 0x04000560 RID: 1376
		private EnumInfo AR;

		// Token: 0x04000561 RID: 1377
		private EnumInfo GR;

		// Token: 0x04000562 RID: 1378
		private EnumInfo FD;

		// Token: 0x04000563 RID: 1379
		private DecimalSymbolOption RD;

		// Token: 0x04000564 RID: 1380
		[CompilerGenerated]
		private List<EnumInfo> DD;

		// Token: 0x04000565 RID: 1381
		[CompilerGenerated]
		private List<EnumInfo> HD;

		// Token: 0x04000566 RID: 1382
		[CompilerGenerated]
		private List<EnumInfo> YD;

		// Token: 0x02000847 RID: 2119
		[CompilerGenerated]
		private sealed class \u0017\u000B
		{
			// Token: 0x06004E5B RID: 20059 RVA: 0x001E0A1C File Offset: 0x001DEC1C
			internal bool \u000A(EnumInfo \u001F)
			{
				return \u000D\u001B\u001D.\u0007(\u001F) == (int)\u0012\u000B\u0004.\u0007(this.\u001F);
			}

			// Token: 0x06004E5C RID: 20060 RVA: 0x001E0A40 File Offset: 0x001DEC40
			internal bool \u0007(EnumInfo \u001F)
			{
				return \u000D\u001B\u001D.\u0007(\u001F) == (int)\u0005\u0010\u0004.\u0007(this.\u001F);
			}

			// Token: 0x06004E5D RID: 20061 RVA: 0x001E0A64 File Offset: 0x001DEC64
			internal bool \u001D(EnumInfo \u001F)
			{
				return \u000D\u001B\u001D.\u0007(\u001F) == (int)\u0018\u0010\u0004.\u000A(this.\u001F);
			}

			// Token: 0x04002100 RID: 8448
			public GeneralMappingSetting \u001F;
		}
	}
}
