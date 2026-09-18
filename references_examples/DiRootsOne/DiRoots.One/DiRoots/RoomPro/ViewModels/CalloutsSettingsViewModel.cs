using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.QuickViews.Models.Profile;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x02000057 RID: 87
	public class CalloutsSettingsViewModel : ViewModelBase
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x00013250 File Offset: 0x00011450
		public CalloutsSettingsViewModel(IModelSettings callOutViewSettings = null, IModelSettings namingConfigurationSettings = null, IModelSettings parameterSettings = null)
		{
			\u0004\u000B\u0007.\u000A(this, \u0019\u0004.\u000A());
			if (callOutViewSettings != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutsSettingsViewModel..ctor(IModelSettings, IModelSettings, IModelSettings)).MethodHandle;
				}
				\u001D\u000B\u0007.\u000A(\u000C\u0016\u0007.\u000A(this), \u001F\u001F\u000E.\u001F(callOutViewSettings));
			}
			if (namingConfigurationSettings != null)
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
				\u0007\u000B\u0007.\u000A(\u000C\u0016\u0007.\u000A(this), \u0009\u0009\u0010.\u001F(namingConfigurationSettings));
			}
			if (parameterSettings != null)
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
				\u000A\u000B\u0007.\u000A(\u000C\u0016\u0007.\u000A(this), \u000A\u001F\u000E.\u001F(parameterSettings));
			}
			\u0009\u0016\u0007.\u000A(this, new CalloutViewTabViewModel(\u001F\u000B\u0007.\u000A(\u000C\u0016\u0007.\u000A(this))));
			\u0015\u0016\u0007.\u000A(this, new CalloutNamingConfigurationTabViewModel(\u0001\u0016\u0007.\u000A(\u000C\u0016\u0007.\u000A(this))));
			\u0013\u0016\u0007.\u000A(this, new ParametersTabViewModel(\u001A\u0016\u0007.\u000A(\u000C\u0016\u0007.\u000A(this))));
			\u0014\u0016\u0007.\u000A(this, new CommandBase(new Action(this.EKR), new Predicate<object>(this.VKR)));
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x060002E3 RID: 739 RVA: 0x00013350 File Offset: 0x00011550
		// (set) Token: 0x060002E4 RID: 740 RVA: 0x00013364 File Offset: 0x00011564
		public CalloutViewTabViewModel CalloutViewTabViewModel { get; set; }

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060002E5 RID: 741 RVA: 0x00013378 File Offset: 0x00011578
		// (set) Token: 0x060002E6 RID: 742 RVA: 0x0001338C File Offset: 0x0001158C
		public CalloutNamingConfigurationTabViewModel CalloutNamingConfigurationTabViewModel { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060002E7 RID: 743 RVA: 0x000133A0 File Offset: 0x000115A0
		// (set) Token: 0x060002E8 RID: 744 RVA: 0x000133B4 File Offset: 0x000115B4
		public ParametersTabViewModel ParametersTabViewModel { get; set; }

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x000133C8 File Offset: 0x000115C8
		// (set) Token: 0x060002EA RID: 746 RVA: 0x000133DC File Offset: 0x000115DC
		public CalloutUserSettings CalloutUserSettings { get; set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060002EB RID: 747 RVA: 0x000133F0 File Offset: 0x000115F0
		// (set) Token: 0x060002EC RID: 748 RVA: 0x00013404 File Offset: 0x00011604
		public ICommand ApplyCmd { get; private set; }

		// Token: 0x060002ED RID: 749 RVA: 0x00013418 File Offset: 0x00011618
		private void EKR()
		{
			this.NKR();
			Window window = \u0018\u000B\u0007.\u0007(this);
			if (window == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutsSettingsViewModel.EKR()).MethodHandle;
				}
				return;
			}
			\u0019\u000B\u0007.\u0007(window);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00013450 File Offset: 0x00011650
		private void NKR()
		{
			CalloutsSettingsViewModel.\u0011\u0007 u0011_u = new CalloutsSettingsViewModel.\u0011\u0007();
			IModelSettings f;
			\u0012\u000B\u0007.\u000A(this).JWR(out f);
			IModelSettings r;
			\u000F\u000B\u0007.\u000A(this).JWR(out r);
			IModelSettings modelSettings;
			\u0006\u000B\u0007.\u0007(this).JWR(out modelSettings);
			object u001F = \u0002\u000B\u0007.\u000A(\u000A\u001F\u000E.\u001F(modelSettings));
			u0011_u.\u001F = \u000B\u000B\u0007.\u000A();
			\u0016\u000B\u0007.\u000A(u001F, new Action<SpatialElementParameter>(u0011_u.\u000A));
			\u0005\u000B\u0007.\u000A(\u000B\u0016\u0007.\u000A(), u0011_u.\u001F);
			this.MKR(f, r, modelSettings);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000134E4 File Offset: 0x000116E4
		private void MKR(IModelSettings F, IModelSettings R, IModelSettings D)
		{
			CalloutViewSettings calloutViewSettings = \u001F\u001F\u000E.\u001F(F);
			NamingConfigurationSettings u000A = \u0009\u0009\u0010.\u001F(R);
			ParametersSettings u000A2 = \u000A\u001F\u000E.\u001F(D);
			CalloutUserSettings calloutUserSettings = \u001C\u000B\u0007.\u000A();
			\u001D\u000B\u0007.\u000A(calloutUserSettings, calloutViewSettings);
			\u0007\u000B\u0007.\u000A(calloutUserSettings, u000A);
			\u000A\u000B\u0007.\u000A(calloutUserSettings, u000A2);
			CalloutUserSettings u001F = calloutUserSettings;
			if (calloutViewSettings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutsSettingsViewModel.MKR(IModelSettings, IModelSettings, IModelSettings)).MethodHandle;
				}
				return;
			}
			\u000B\u0004 u000B_u = new \u000B\u0004(u001F);
			\u000D\u0001\u000A.\u001D(u000B_u, \u0003\u000B\u0007.\u000A());
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000B_u);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00013574 File Offset: 0x00011774
		private bool VKR(object F)
		{
			if (!\u000D\u000B\u0007.\u000A(\u0012\u000B\u0007.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(CalloutsSettingsViewModel.VKR(object)).MethodHandle;
				}
				return !\u000D\u000B\u0007.\u000A(\u000F\u000B\u0007.\u000A(this));
			}
			return false;
		}

		// Token: 0x0400010E RID: 270
		[CompilerGenerated]
		private CalloutViewTabViewModel U;

		// Token: 0x0400010F RID: 271
		[CompilerGenerated]
		private CalloutNamingConfigurationTabViewModel W;

		// Token: 0x04000110 RID: 272
		[CompilerGenerated]
		private ParametersTabViewModel K;

		// Token: 0x04000111 RID: 273
		[CompilerGenerated]
		private CalloutUserSettings J;

		// Token: 0x04000112 RID: 274
		[CompilerGenerated]
		private ICommand E;

		// Token: 0x02000790 RID: 1936
		[CompilerGenerated]
		private sealed class \u0011\u0007
		{
			// Token: 0x06004B6F RID: 19311 RVA: 0x001DA064 File Offset: 0x001D8264
			internal void \u000A(SpatialElementParameter \u001F)
			{
				object u001F = this.\u001F;
				ParameterSettingInfo parameterSettingInfo = \u0011\u0015\u000D.\u000A();
				\u001B\u0015\u000D.\u000A(parameterSettingInfo, \u0012\u000A\u001D.\u0007(\u001F));
				\u0008\u0015\u000D.\u000A(parameterSettingInfo, \u0005\u0018\u001D.\u000A(\u001F));
				\u000E\u0015\u000D.\u000A(parameterSettingInfo, \u000F\u000A\u001D.\u0007(\u001F));
				\u0010\u0015\u000D.\u000A(u001F, parameterSettingInfo);
			}

			// Token: 0x04001EBA RID: 7866
			public List<ParameterSettingInfo> \u001F;
		}
	}
}
