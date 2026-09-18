using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.QuickViews.Helpers;
using DiRoots.One.QuickViews.Models.Profile;
using DiRoots.RoomPro.Enums;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x02000058 RID: 88
	public class CalloutViewTabViewModel : SettingsTabViewModel
	{
		// Token: 0x060002F1 RID: 753 RVA: 0x000135BC File Offset: 0x000117BC
		public CalloutViewTabViewModel(IModelSettings settings)
		{
			List<ViewDetailLevel> list = new List<ViewDetailLevel>();
			\u0017\u000B\u0007.\u000A(list, 1);
			\u0017\u000B\u0007.\u000A(list, 2);
			\u0017\u000B\u0007.\u000A(list, 3);
			this.ViewDetailLevels = list;
			base..ctor();
			this.R = \u000C\u001D.\u0006;
			\u0020\u000B\u0007.\u000A(this, \u001F\u001F\u000E.\u001F(settings));
			this.M = \u001E\u000B\u0007.\u000A(this.R);
			string[] u000A;
			if (this.M != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutViewTabViewModel..ctor(IModelSettings)).MethodHandle;
				}
				u000A = \u0009\u001D.\u000A;
			}
			else
			{
				u000A = \u0009\u001D.\u001F;
			}
			\u0011\u000B\u0007.\u000A(this, u000A);
			\u0013\u001D u0013_u001D = new \u0013\u001D(this.R);
			IEnumerable<ViewFamilyType> enumerable = u0013_u001D.\u000F(109);
			Func<ViewFamilyType, ModelViewType> func;
			if ((func = CalloutViewTabViewModel.<>c.\u000A) == null)
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
				func = (CalloutViewTabViewModel.<>c.\u000A = new Func<ViewFamilyType, ModelViewType>(CalloutViewTabViewModel.<>c.\u001F.\u001D));
			}
			\u001B\u000B\u0007.\u000A(this, Enumerable.ToList<ModelViewType>(Enumerable.Select<ViewFamilyType, ModelViewType>(enumerable, func)));
			IEnumerable<Phase> enumerable2 = u0013_u001D.\u0012();
			Func<Phase, ModelPhase> func2;
			if ((func2 = CalloutViewTabViewModel.<>c.\u0007) == null)
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
				func2 = (CalloutViewTabViewModel.<>c.\u0007 = new Func<Phase, ModelPhase>(CalloutViewTabViewModel.<>c.\u001F.\u0004));
			}
			\u0008\u000B\u0007.\u000A(this, Enumerable.ToList<ModelPhase>(Enumerable.Select<Phase, ModelPhase>(enumerable2, func2)));
			\u000E\u000B\u0007.\u000A(this, Enumerable.ToList<ViewTemplate>(u0013_u001D.\u0010()));
			this.JKR(\u0010\u000B\u0007.\u000A(this));
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x00013708 File Offset: 0x00011908
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x0001371C File Offset: 0x0001191C
		public CalloutViewSettings CalloutViewSettings
		{
			get
			{
				return this.N;
			}
			set
			{
				this.N = value;
				\u000D\u0020\u000A.\u000A(this, "CalloutViewSettings");
			}
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0001373C File Offset: 0x0001193C
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x00013750 File Offset: 0x00011950
		public List<ModelViewType> CalloutTypes { get; private set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060002F6 RID: 758 RVA: 0x00013764 File Offset: 0x00011964
		// (set) Token: 0x060002F7 RID: 759 RVA: 0x00013778 File Offset: 0x00011978
		public string[] Scales { get; private set; }

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060002F8 RID: 760 RVA: 0x0001378C File Offset: 0x0001198C
		// (set) Token: 0x060002F9 RID: 761 RVA: 0x000137A0 File Offset: 0x000119A0
		public List<ViewDetailLevel> ViewDetailLevels { get; private set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x060002FA RID: 762 RVA: 0x000137B4 File Offset: 0x000119B4
		// (set) Token: 0x060002FB RID: 763 RVA: 0x000137C8 File Offset: 0x000119C8
		public List<ViewTemplate> ViewTemplates { get; private set; }

		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060002FC RID: 764 RVA: 0x000137DC File Offset: 0x000119DC
		// (set) Token: 0x060002FD RID: 765 RVA: 0x000137F0 File Offset: 0x000119F0
		public List<ModelPhase> Phases { get; private set; }

		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060002FE RID: 766 RVA: 0x00013804 File Offset: 0x00011A04
		// (set) Token: 0x060002FF RID: 767 RVA: 0x00013818 File Offset: 0x00011A18
		public ModelViewType SelectedCalloutType { get; set; }

		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000300 RID: 768 RVA: 0x0001382C File Offset: 0x00011A2C
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00013840 File Offset: 0x00011A40
		public string SelectedScale { get; set; }

		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00013854 File Offset: 0x00011A54
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00013868 File Offset: 0x00011A68
		public ViewDetailLevel ViewDetailLevel { get; set; }

		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x06000304 RID: 772 RVA: 0x0001387C File Offset: 0x00011A7C
		// (set) Token: 0x06000305 RID: 773 RVA: 0x00013890 File Offset: 0x00011A90
		public ModelPhase SelectedPhase { get; set; }

		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x06000306 RID: 774 RVA: 0x000138A4 File Offset: 0x00011AA4
		// (set) Token: 0x06000307 RID: 775 RVA: 0x000138B8 File Offset: 0x00011AB8
		public ViewTemplate SelectedViewTemplate { get; set; }

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x06000308 RID: 776 RVA: 0x000138CC File Offset: 0x00011ACC
		// (set) Token: 0x06000309 RID: 777 RVA: 0x000138E0 File Offset: 0x00011AE0
		public double OffsetFromBoundary
		{
			get
			{
				return this.V;
			}
			set
			{
				this.V = value;
				\u000D\u0020\u000A.\u000A(this, "OffsetFromBoundary");
			}
		}

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00013900 File Offset: 0x00011B00
		// (set) Token: 0x0600030B RID: 779 RVA: 0x00013914 File Offset: 0x00011B14
		public CalloutShape SelectedCalloutShape { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00013928 File Offset: 0x00011B28
		// (set) Token: 0x0600030D RID: 781 RVA: 0x0001393C File Offset: 0x00011B3C
		public bool IsCallOutDependent { get; set; }

		// Token: 0x0600030E RID: 782 RVA: 0x00013950 File Offset: 0x00011B50
		public override bool Validate(string propertyName, object value)
		{
			if (\u0008\u0013\u000A.\u000A(propertyName, "OffsetFromBoundary"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutViewTabViewModel.Validate(string, object)).MethodHandle;
				}
				return this.ZKR(propertyName, value);
			}
			return true;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0001398C File Offset: 0x00011B8C
		internal override bool JWR(out IModelSettings F)
		{
			CalloutViewSettings calloutViewSettings = \u0002\u0002\u0007.\u000A();
			\u0016\u0002\u0007.\u000A(calloutViewSettings, \u000B\u0002\u0007.\u000A(this));
			\u0018\u0002\u0007.\u000A(calloutViewSettings, \u0001\u001D.\u001F(\u0005\u0002\u0007.\u000A(this), this.M));
			\u0004\u0002\u0007.\u000A(calloutViewSettings, \u0019\u0002\u0007.\u000A(this));
			\u0007\u0002\u0007.\u000A(calloutViewSettings, \u001D\u0002\u0007.\u000A(this));
			\u001F\u0002\u0007.\u000A(calloutViewSettings, \u000A\u0002\u0007.\u000A(this));
			\u0001\u000B\u0007.\u000A(calloutViewSettings, \u0009\u000B\u0007.\u000A(this));
			\u000C\u000B\u0007.\u000A(calloutViewSettings, (int)\u0015\u000B\u0007.\u000A(this));
			\u0013\u000B\u0007.\u000A(calloutViewSettings, \u001A\u000B\u0007.\u000A(this));
			F = calloutViewSettings;
			object u001F = \u000B\u0016\u0007.\u000A();
			CalloutViewSettings calloutViewSettings2 = \u0002\u0002\u0007.\u000A();
			\u0016\u0002\u0007.\u000A(calloutViewSettings2, \u000B\u0002\u0007.\u000A(this));
			\u0018\u0002\u0007.\u000A(calloutViewSettings2, \u0001\u001D.\u001F(\u0005\u0002\u0007.\u000A(this), this.M));
			\u0004\u0002\u0007.\u000A(calloutViewSettings2, \u0019\u0002\u0007.\u000A(this));
			\u0007\u0002\u0007.\u000A(calloutViewSettings2, \u001D\u0002\u0007.\u000A(this));
			\u001F\u0002\u0007.\u000A(calloutViewSettings2, \u000A\u0002\u0007.\u000A(this));
			\u0001\u000B\u0007.\u000A(calloutViewSettings2, \u0009\u000B\u0007.\u000A(this));
			\u000C\u000B\u0007.\u000A(calloutViewSettings2, (int)\u0015\u000B\u0007.\u000A(this));
			\u0013\u000B\u0007.\u000A(calloutViewSettings2, \u001A\u000B\u0007.\u000A(this));
			\u0014\u000B\u0007.\u000A(u001F, calloutViewSettings2);
			return true;
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00013AB0 File Offset: 0x00011CB0
		public IModelSettings SettingCallOutViewInfo(CallOutViewInfo callOutViewInfo)
		{
			CalloutViewTabViewModel.\u001E\u0007 u001E_u = new CalloutViewTabViewModel.\u001E\u0007();
			u001E_u.\u001F = callOutViewInfo;
			CalloutViewSettings calloutViewSettings = \u0002\u0002\u0007.\u000A();
			\u0016\u0002\u0007.\u000A(calloutViewSettings, \u001B\u0002\u0007.\u000A(\u0011\u0002\u0007.\u000A(this), new Predicate<ModelViewType>(u001E_u.\u000A)));
			\u0018\u0002\u0007.\u000A(calloutViewSettings, \u0008\u0002\u0007.\u000A(u001E_u.\u001F));
			\u0004\u0002\u0007.\u000A(calloutViewSettings, \u000E\u0002\u0007.\u000A(u001E_u.\u001F));
			\u0007\u0002\u0007.\u000A(calloutViewSettings, \u000D\u0002\u0007.\u000A(\u0010\u0002\u0007.\u000A(this), new Predicate<ModelPhase>(u001E_u.\u0007)));
			\u001F\u0002\u0007.\u000A(calloutViewSettings, \u0003\u0002\u0007.\u000A(\u001C\u0002\u0007.\u000A(this), new Predicate<ViewTemplate>(u001E_u.\u001D)));
			\u0001\u000B\u0007.\u000A(calloutViewSettings, \u0012\u0002\u0007.\u000A(u001E_u.\u001F));
			\u000C\u000B\u0007.\u000A(calloutViewSettings, \u000F\u0002\u0007.\u000A(u001E_u.\u001F));
			\u0013\u000B\u0007.\u000A(calloutViewSettings, \u0006\u0002\u0007.\u000A(u001E_u.\u001F));
			return calloutViewSettings;
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00013B94 File Offset: 0x00011D94
		private void JKR(CalloutViewSettings F)
		{
			CalloutViewTabViewModel.\u0020\u0007 u0020_u = new CalloutViewTabViewModel.\u0020\u0007();
			u0020_u.\u001F = F;
			ModelViewType u000A;
			if ((u000A = \u001B\u0002\u0007.\u000A(\u0011\u0002\u0007.\u000A(this), new Predicate<ModelViewType>(u0020_u.\u000A))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutViewTabViewModel.JKR(CalloutViewSettings)).MethodHandle;
				}
				u000A = \u001B\u0002\u0007.\u000A(\u0011\u0002\u0007.\u000A(this), new Predicate<ModelViewType>(u0020_u.\u0007));
			}
			\u0004\u0006\u0007.\u000A(this, u000A);
			if (\u000B\u0002\u0007.\u000A(this) == null)
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
				\u0004\u0006\u0007.\u000A(this, \u0019\u0006\u0007.\u000A(\u0011\u0002\u0007.\u000A(this), 0));
			}
			\u0007\u0006\u0007.\u000A(this, \u0001\u001D.\u000A(\u001D\u0006\u0007.\u000A(u0020_u.\u001F), this.M));
			\u001F\u0006\u0007.\u000A(this, \u000A\u0006\u0007.\u000A(u0020_u.\u001F));
			ModelPhase u000A2;
			if ((u000A2 = \u000D\u0002\u0007.\u000A(\u0010\u0002\u0007.\u000A(this), new Predicate<ModelPhase>(u0020_u.\u001D))) == null)
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
				u000A2 = \u000D\u0002\u0007.\u000A(\u0010\u0002\u0007.\u000A(this), new Predicate<ModelPhase>(u0020_u.\u0004));
			}
			\u0001\u0002\u0007.\u000A(this, u000A2);
			if (\u001D\u0002\u0007.\u000A(this) == null)
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
				\u0001\u0002\u0007.\u000A(this, \u0009\u0002\u0007.\u000A(\u0010\u0002\u0007.\u000A(this), 0));
			}
			\u000C\u0002\u0007.\u000A(this, \u0003\u0002\u0007.\u000A(\u001C\u0002\u0007.\u000A(this), new Predicate<ViewTemplate>(u0020_u.\u0019)));
			if (\u000A\u0002\u0007.\u000A(this) == null)
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
				\u000C\u0002\u0007.\u000A(this, \u0015\u0002\u0007.\u000A(\u001C\u0002\u0007.\u000A(this), 0));
			}
			\u0013\u0002\u0007.\u000A(this, \u001A\u0002\u0007.\u000A(u0020_u.\u001F));
			\u0017\u0002\u0007.\u000A(this, (CalloutShape)\u0014\u0002\u0007.\u000A(u0020_u.\u001F));
			\u001E\u0002\u0007.\u000A(this, \u0020\u0002\u0007.\u000A(u0020_u.\u001F));
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00013D58 File Offset: 0x00011F58
		private bool ZKR(string F, object R)
		{
			bool flag = \u0018\u0007\u000A.\u001F(this, F, R);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutViewTabViewModel.ZKR(string, object)).MethodHandle;
				}
				return flag;
			}
			double num = this.XKR(R);
			if (\u001D\u0017\u000A.\u000A(F, "OffsetFromBoundary"))
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
				return flag;
			}
			if (num < 0.0)
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
				\u0018\u0006\u0007.\u000A(this, F, \u0005\u0006\u0007.\u000A(\u0016\u0006\u0007.\u000A(), ErrorType.Error));
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00013DDC File Offset: 0x00011FDC
		private double XKR(object F)
		{
			double result = 0.0;
			string text = \u0007\u001F\u000E.\u001F(F);
			if (text != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutViewTabViewModel.XKR(object)).MethodHandle;
				}
				string text2;
				\u000B\u0006\u0007.\u000A(\u0006\u0006\u0007.\u000A(this.R), \u0002\u0006\u0007.\u000A(), text, ref result, ref text2);
			}
			return result;
		}

		// Token: 0x04000113 RID: 275
		private CalloutViewSettings N;

		// Token: 0x04000114 RID: 276
		private readonly DisplayUnit M;

		// Token: 0x04000115 RID: 277
		private readonly Document R;

		// Token: 0x04000116 RID: 278
		private double V;

		// Token: 0x04000117 RID: 279
		[CompilerGenerated]
		private List<ModelViewType> P;

		// Token: 0x04000118 RID: 280
		[CompilerGenerated]
		private string[] O;

		// Token: 0x04000119 RID: 281
		[CompilerGenerated]
		private List<ViewDetailLevel> T;

		// Token: 0x0400011A RID: 282
		[CompilerGenerated]
		private List<ViewTemplate> I;

		// Token: 0x0400011B RID: 283
		[CompilerGenerated]
		private List<ModelPhase> Q;

		// Token: 0x0400011C RID: 284
		[CompilerGenerated]
		private ModelViewType A;

		// Token: 0x0400011D RID: 285
		[CompilerGenerated]
		private string G;

		// Token: 0x0400011E RID: 286
		[CompilerGenerated]
		private ViewDetailLevel FR;

		// Token: 0x0400011F RID: 287
		[CompilerGenerated]
		private ModelPhase RR;

		// Token: 0x04000120 RID: 288
		[CompilerGenerated]
		private ViewTemplate DR;

		// Token: 0x04000121 RID: 289
		[CompilerGenerated]
		private CalloutShape HR;

		// Token: 0x04000122 RID: 290
		[CompilerGenerated]
		private bool YR;

		// Token: 0x02000792 RID: 1938
		[CompilerGenerated]
		private sealed class \u001E\u0007
		{
			// Token: 0x06004B75 RID: 19317 RVA: 0x001DA124 File Offset: 0x001D8324
			internal bool \u000A(ModelViewType \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u0014\u0015\u000D.\u000A(this.\u001F));
			}

			// Token: 0x06004B76 RID: 19318 RVA: 0x001DA150 File Offset: 0x001D8350
			internal bool \u0007(ModelPhase \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u0013\u0015\u000D.\u000A(this.\u001F));
			}

			// Token: 0x06004B77 RID: 19319 RVA: 0x001DA17C File Offset: 0x001D837C
			internal bool \u001D(ViewTemplate \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u001A\u0015\u000D.\u000A(this.\u001F);
			}

			// Token: 0x04001EBE RID: 7870
			public CallOutViewInfo \u001F;
		}

		// Token: 0x02000793 RID: 1939
		[CompilerGenerated]
		private sealed class \u0020\u0007
		{
			// Token: 0x06004B79 RID: 19321 RVA: 0x001DA1B4 File Offset: 0x001D83B4
			internal bool \u000A(ModelViewType \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u0011\u001D\u001D.\u000A(this.\u001F));
			}

			// Token: 0x06004B7A RID: 19322 RVA: 0x001DA1E0 File Offset: 0x001D83E0
			internal bool \u0007(ModelViewType \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u0011\u001D\u001D.\u000A(this.\u001F)));
			}

			// Token: 0x06004B7B RID: 19323 RVA: 0x001DA210 File Offset: 0x001D8410
			internal bool \u001D(ModelPhase \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u0018\u0013\u0007.\u000A(this.\u001F));
			}

			// Token: 0x06004B7C RID: 19324 RVA: 0x001DA23C File Offset: 0x001D843C
			internal bool \u0004(ModelPhase \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001D\u000D\u0007.\u0007(\u001F), \u001D\u000D\u0007.\u0007(\u0018\u0013\u0007.\u000A(this.\u001F)));
			}

			// Token: 0x06004B7D RID: 19325 RVA: 0x001DA26C File Offset: 0x001D846C
			internal bool \u0019(ViewTemplate \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == \u0018\u0018\u0007.\u0007(\u0005\u0013\u0007.\u000A(this.\u001F));
			}

			// Token: 0x04001EBF RID: 7871
			public CalloutViewSettings \u001F;
		}
	}
}
