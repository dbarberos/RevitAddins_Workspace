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
	// Token: 0x0200005D RID: 93
	public class SectionsSettingsViewModel : ViewModelBase
	{
		// Token: 0x06000405 RID: 1029 RVA: 0x000195A0 File Offset: 0x000177A0
		public SectionsSettingsViewModel(IModelSettings sectionViewSettings = null, IModelSettings namingConfigurationSettings = null, IModelSettings parameterSettings = null)
		{
			\u000B\u001E\u0007.\u000A(this, \u0019\u0004.\u001F());
			if (sectionViewSettings != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsSettingsViewModel..ctor(IModelSettings, IModelSettings, IModelSettings)).MethodHandle;
				}
				\u0016\u001E\u0007.\u000A(\u000A\u001E\u0007.\u000A(this), \u0008\u001F\u000E.\u001F(sectionViewSettings));
			}
			if (namingConfigurationSettings != null)
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
				\u0005\u001E\u0007.\u000A(\u000A\u001E\u0007.\u000A(this), \u000E\u001F\u000E.\u001F(namingConfigurationSettings));
			}
			if (parameterSettings != null)
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
				\u0018\u001E\u0007.\u000A(\u000A\u001E\u0007.\u000A(this), \u000A\u001F\u000E.\u001F(parameterSettings));
			}
			\u0004\u001E\u0007.\u000A(this, new SectionsViewTabViewModel(\u0019\u001E\u0007.\u000A(\u000A\u001E\u0007.\u000A(this))));
			\u0007\u001E\u0007.\u000A(this, new SectionNamingConfigurationTabViewModel(\u001D\u001E\u0007.\u000A(\u000A\u001E\u0007.\u000A(this))));
			\u0009\u0011\u0007.\u000A(this, new ParametersTabViewModel(\u001F\u001E\u0007.\u000A(\u000A\u001E\u0007.\u000A(this))));
			\u0001\u0011\u0007.\u000A(this, new CommandBase(new Action(this.EKR), new Predicate<object>(this.VKR)));
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x000196A0 File Offset: 0x000178A0
		// (set) Token: 0x06000407 RID: 1031 RVA: 0x000196B4 File Offset: 0x000178B4
		public SectionsViewTabViewModel SectionsViewTabViewModel { get; set; }

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000408 RID: 1032 RVA: 0x000196C8 File Offset: 0x000178C8
		// (set) Token: 0x06000409 RID: 1033 RVA: 0x000196DC File Offset: 0x000178DC
		public SectionNamingConfigurationTabViewModel SectionNamingConfigurationTabViewModel { get; set; }

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x0600040A RID: 1034 RVA: 0x000196F0 File Offset: 0x000178F0
		// (set) Token: 0x0600040B RID: 1035 RVA: 0x00019704 File Offset: 0x00017904
		public ParametersTabViewModel ParametersTabViewModel { get; set; }

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x0600040C RID: 1036 RVA: 0x00019718 File Offset: 0x00017918
		// (set) Token: 0x0600040D RID: 1037 RVA: 0x0001972C File Offset: 0x0001792C
		private SectionAndElevationUserSettings SectionAndElevationUserSettings { get; set; }

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x0600040E RID: 1038 RVA: 0x00019740 File Offset: 0x00017940
		// (set) Token: 0x0600040F RID: 1039 RVA: 0x00019754 File Offset: 0x00017954
		public ICommand ApplyCmd { get; private set; }

		// Token: 0x06000410 RID: 1040 RVA: 0x00019768 File Offset: 0x00017968
		private void EKR()
		{
			this.NKR();
			Window window = \u0018\u000B\u0007.\u0007(this);
			if (window == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsSettingsViewModel.EKR()).MethodHandle;
				}
				return;
			}
			\u0019\u000B\u0007.\u0007(window);
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000197A0 File Offset: 0x000179A0
		private void NKR()
		{
			SectionsSettingsViewModel.\u0006\u001D u0006_u001D = new SectionsSettingsViewModel.\u0006\u001D();
			IModelSettings f;
			\u000F\u001E\u0007.\u000A(this).JWR(out f);
			IModelSettings r;
			\u0006\u001E\u0007.\u000A(this).JWR(out r);
			IModelSettings modelSettings;
			\u000E\u001B\u0007.\u001D(this).JWR(out modelSettings);
			this.VER(f, r, modelSettings);
			object u001F = \u0002\u000B\u0007.\u000A(\u000A\u001F\u000E.\u001F(modelSettings));
			u0006_u001D.\u001F = \u000B\u000B\u0007.\u000A();
			\u0016\u000B\u0007.\u000A(u001F, new Action<SpatialElementParameter>(u0006_u001D.\u000A));
			\u0002\u001E\u0007.\u000A(\u000B\u001B\u0007.\u000A(), u0006_u001D.\u001F);
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x00019834 File Offset: 0x00017A34
		private void VER(IModelSettings F, IModelSettings R, IModelSettings D)
		{
			SectionViewSettings sectionViewSettings = \u0008\u001F\u000E.\u001F(F);
			SectionNamingConfigurationSettings u000A = \u000E\u001F\u000E.\u001F(R);
			ParametersSettings u000A2 = \u000A\u001F\u000E.\u001F(D);
			SectionAndElevationUserSettings sectionAndElevationUserSettings = \u0003\u001E\u0007.\u000A();
			\u0016\u001E\u0007.\u000A(sectionAndElevationUserSettings, sectionViewSettings);
			\u0005\u001E\u0007.\u000A(sectionAndElevationUserSettings, u000A);
			\u0018\u001E\u0007.\u000A(sectionAndElevationUserSettings, u000A2);
			SectionAndElevationUserSettings u001F = sectionAndElevationUserSettings;
			if (sectionViewSettings == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsSettingsViewModel.VER(IModelSettings, IModelSettings, IModelSettings)).MethodHandle;
				}
				return;
			}
			\u000B\u0004 u000B_u = new \u000B\u0004(u001F);
			\u000D\u0001\u000A.\u001D(u000B_u, \u0012\u001E\u0007.\u000A());
			\u000B\u0004 u000A3 = u000B_u;
			\u0020\u001E\u000A.\u000A(\u0017\u001E\u000A.\u000A(), u000A3);
			\u0011\u001E\u000A.\u000A(\u001E\u001E\u000A.\u000A());
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000198C4 File Offset: 0x00017AC4
		private bool VKR(object F)
		{
			if (!\u000D\u000B\u0007.\u000A(\u000F\u001E\u0007.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SectionsSettingsViewModel.VKR(object)).MethodHandle;
				}
				return !\u000D\u000B\u0007.\u000A(\u0006\u001E\u0007.\u000A(this));
			}
			return false;
		}

		// Token: 0x04000178 RID: 376
		[CompilerGenerated]
		private SectionsViewTabViewModel BY;

		// Token: 0x04000179 RID: 377
		[CompilerGenerated]
		private SectionNamingConfigurationTabViewModel UY;

		// Token: 0x0400017A RID: 378
		[CompilerGenerated]
		private ParametersTabViewModel K;

		// Token: 0x0400017B RID: 379
		[CompilerGenerated]
		private SectionAndElevationUserSettings WY;

		// Token: 0x0400017C RID: 380
		[CompilerGenerated]
		private ICommand E;

		// Token: 0x020007AB RID: 1963
		[CompilerGenerated]
		private sealed class \u0006\u001D
		{
			// Token: 0x06004BF3 RID: 19443 RVA: 0x001DB43C File Offset: 0x001D963C
			internal void \u000A(SpatialElementParameter \u001F)
			{
				object u001F = this.\u001F;
				ParameterSettingInfo parameterSettingInfo = \u0011\u0015\u000D.\u000A();
				\u001B\u0015\u000D.\u000A(parameterSettingInfo, \u0012\u000A\u001D.\u0007(\u001F));
				\u0008\u0015\u000D.\u000A(parameterSettingInfo, \u0005\u0018\u001D.\u000A(\u001F));
				\u000E\u0015\u000D.\u000A(parameterSettingInfo, \u000F\u000A\u001D.\u0007(\u001F));
				\u0010\u0015\u000D.\u000A(u001F, parameterSettingInfo);
			}

			// Token: 0x04001F23 RID: 7971
			public List<ParameterSettingInfo> \u001F;
		}
	}
}
