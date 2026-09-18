using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.Profiles;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using DiRoots.One.TGRevitHelper.StyleMapping;
using Newtonsoft.Json;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000177 RID: 375
	public class StyleMappingSettingsViewModel : ModelBase
	{
		// Token: 0x06000DF0 RID: 3568 RVA: 0x000595D4 File Offset: 0x000577D4
		public StyleMappingSettingsViewModel(Document doc, List<SelectedExcel> selectedExcels, StyleMappingDto styleMappings, Profile activeProfile, StyleMappingDto defaultProfile, ExcelStylesAggregator styleCache, StyleCacheReloadCallback reloadCallback, StyleCacheSyncCallback syncCallback)
		{
			this.ND = doc;
			this.MD = selectedExcels;
			this.VD = styleCache;
			if (reloadCallback == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel..ctor(Document, List<SelectedExcel>, StyleMappingDto, Profile, StyleMappingDto, ExcelStylesAggregator, StyleCacheReloadCallback, StyleCacheSyncCallback)).MethodHandle;
				}
				throw new ArgumentNullException("reloadCallback");
			}
			this.ZD = reloadCallback;
			if (syncCallback == null)
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
				throw new ArgumentNullException("syncCallback");
			}
			this.XD = syncCallback;
			this.AD = true;
			StyleMappingDto od;
			if (defaultProfile == null)
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
				od = new StyleMappingDto();
			}
			else
			{
				od = StyleMappingSettingsViewModel.JP(defaultProfile);
			}
			this.OD = od;
			StyleMappingDto pd;
			if (styleMappings == null)
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
				pd = StyleMappingSettingsViewModel.JP(this.OD);
			}
			else
			{
				pd = StyleMappingSettingsViewModel.JP(styleMappings);
			}
			this.PD = pd;
			\u0018\u000D\u0019.\u000A(this, new GeneralViewModel(\u0009\u0004\u0004.\u0007(this.PD), new Action(this.UP)));
			\u0017\u0003\u0019.\u000A(\u0019\u000D\u0019.\u000A(this), new PropertyChangedEventHandler(this.WP));
			\u0004\u000D\u0019.\u000A(this, new LineStylesViewModel(this.ND, \u0012\u001C\u0004.\u0007(this.PD), new Action(this.RP), new Action(this.UP)));
			\u001D\u000D\u0019.\u000A(this, new TextStylesViewModel(this.ND, \u0005\u000D\u0004.\u0007(this.PD), new Action(this.RP), new Action(this.UP)));
			this.NP();
			this.AD = false;
			this.QD = false;
			this.TD = activeProfile;
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x00059764 File Offset: 0x00057964
		// (set) Token: 0x06000DF2 RID: 3570 RVA: 0x00059778 File Offset: 0x00057978
		public GeneralViewModel GeneralViewModel { get; set; }

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x06000DF3 RID: 3571 RVA: 0x0005978C File Offset: 0x0005798C
		// (set) Token: 0x06000DF4 RID: 3572 RVA: 0x000597A0 File Offset: 0x000579A0
		public LineStylesViewModel LineStylesViewModel { get; set; }

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x000597B4 File Offset: 0x000579B4
		// (set) Token: 0x06000DF6 RID: 3574 RVA: 0x000597C8 File Offset: 0x000579C8
		public TextStylesViewModel TextStylesViewModel { get; set; }

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x000597DC File Offset: 0x000579DC
		// (set) Token: 0x06000DF8 RID: 3576 RVA: 0x000597F0 File Offset: 0x000579F0
		public StyleMappingDto StyleMappings
		{
			get
			{
				return this.PD;
			}
			private set
			{
				base.SetProperty<StyleMappingDto>(ref this.PD, value, null, "StyleMappings");
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x06000DF9 RID: 3577 RVA: 0x00059814 File Offset: 0x00057A14
		// (set) Token: 0x06000DFA RID: 3578 RVA: 0x00059828 File Offset: 0x00057A28
		public string ActiveProfileName
		{
			get
			{
				return this.ID;
			}
			set
			{
				string newValue = value;
				if (value == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.set_ActiveProfileName(string)).MethodHandle;
					}
					newValue = string.Empty;
				}
				base.SetProperty<string>(ref this.ID, newValue, null, "ActiveProfileName");
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x06000DFB RID: 3579 RVA: 0x00059868 File Offset: 0x00057A68
		// (set) Token: 0x06000DFC RID: 3580 RVA: 0x0005987C File Offset: 0x00057A7C
		public bool HasUnsavedProfileChanges
		{
			get
			{
				return this.QD;
			}
			private set
			{
				base.SetProperty<bool>(ref this.QD, value, null, "HasUnsavedProfileChanges");
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x06000DFD RID: 3581 RVA: 0x000598A0 File Offset: 0x00057AA0
		// (set) Token: 0x06000DFE RID: 3582 RVA: 0x000598B4 File Offset: 0x00057AB4
		public int SelectedTabIndex
		{
			get
			{
				return this.GD;
			}
			set
			{
				base.SetProperty<int>(ref this.GD, value, null, "SelectedTabIndex");
			}
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x000598D8 File Offset: 0x00057AD8
		internal void RP()
		{
			try
			{
				EnumInfo enumInfo = \u001C\u0012\u0019.\u001D(\u0019\u000D\u0019.\u000A(this));
				BlackAndWhiteTextLinesOption blackAndWhiteTextLinesOption;
				if (enumInfo == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.RP()).MethodHandle;
					}
					blackAndWhiteTextLinesOption = BlackAndWhiteTextLinesOption.ConvertAllColorsToBlack;
				}
				else
				{
					blackAndWhiteTextLinesOption = (BlackAndWhiteTextLinesOption)\u000D\u001B\u001D.\u001D(enumInfo);
				}
				BlackAndWhiteTextLinesOption blackAndWhiteTextLinesOption2 = blackAndWhiteTextLinesOption;
				EnumInfo enumInfo2 = \u0012\u0012\u0019.\u001D(\u0019\u000D\u0019.\u000A(this));
				BlackAndWhiteBackgroundOption blackAndWhiteBackgroundOption;
				if (enumInfo2 == null)
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
					blackAndWhiteBackgroundOption = BlackAndWhiteBackgroundOption.RemoveAllBackgrounds;
				}
				else
				{
					blackAndWhiteBackgroundOption = (BlackAndWhiteBackgroundOption)\u000D\u001B\u001D.\u001D(enumInfo2);
				}
				BlackAndWhiteBackgroundOption u000A = blackAndWhiteBackgroundOption;
				\u0003\u0012\u0019.\u000A(\u0009\u0004\u0004.\u0007(this.PD), blackAndWhiteTextLinesOption2);
				\u000F\u0012\u0019.\u000A(\u0009\u0004\u0004.\u0007(this.PD), u000A);
				\u0005\u000D\u0019.\u000A(this.ZD, this.MD, blackAndWhiteTextLinesOption2);
				ExcelStylesAggregator vd = this.VD;
				IReadOnlyCollection<ExcelLineStyleInfo> u001F;
				if (vd == null)
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
					u001F = null;
				}
				else
				{
					u001F = \u0001\u001D\u0019.\u001D(vd);
				}
				ExcelStylesAggregator vd2 = this.VD;
				IReadOnlyCollection<ExcelTextStyleInfo> u000A2;
				if (vd2 == null)
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
					u000A2 = null;
				}
				else
				{
					u000A2 = \u000C\u001D\u0019.\u001D(vd2);
				}
				this.OD = \u0002\u0005.\u000B(u001F, u000A2, this.ND);
				StyleMappingDto pd = this.PD;
				StyleMappingDto od = this.OD;
				ExcelStylesAggregator vd3 = this.VD;
				IReadOnlyCollection<ExcelLineStyleInfo> u;
				if (vd3 == null)
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
					u = null;
				}
				else
				{
					u = \u0001\u001D\u0019.\u001D(vd3);
				}
				ExcelStylesAggregator vd4 = this.VD;
				IReadOnlyCollection<ExcelTextStyleInfo> u001D;
				if (vd4 == null)
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
					u001D = null;
				}
				else
				{
					u001D = \u000C\u001D\u0019.\u001D(vd4);
				}
				\u0002\u0005.\u0003(pd, od, u, u001D, this.ND, this.TD);
				this.EP();
				this.NP();
				this.UP();
			}
			catch (Exception u000A3)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\StyleMappings\\StyleMappingSettingsViewModel.cs", "OnReadFromFiles");
			}
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00059A68 File Offset: 0x00057C68
		internal void DP()
		{
			\u000C\u001C\u0004.\u000A(this.PD, \u0006\u000D\u0019.\u000A(\u000F\u000D\u0019.\u000A(this)));
			\u001A\u001C\u0004.\u000A(this.PD, \u000B\u000D\u0019.\u000A(\u0002\u000D\u0019.\u000A(this)));
			\u0015\u001C\u0004.\u000A(this.PD, \u0016\u000D\u0019.\u000A(\u0019\u000D\u0019.\u000A(this)));
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00059AC4 File Offset: 0x00057CC4
		internal StyleMappingDto HP()
		{
			this.DP();
			return StyleMappingSettingsViewModel.JP(this.PD);
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00059AE4 File Offset: 0x00057CE4
		internal ProfileTemplate YP()
		{
			ProfileTemplate result = \u001B\u0018\u0019.\u000A(this.HP());
			\u0012\u000D\u0019.\u000A(this, false);
			return result;
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00059B08 File Offset: 0x00057D08
		internal ProfileTemplate CP()
		{
			return this.YP();
		}

		// Token: 0x06000E04 RID: 3588 RVA: 0x00059B20 File Offset: 0x00057D20
		internal void LP(Profile F)
		{
			this.TD = F;
			string r;
			StyleMappingDto f = this.SP(F, out r);
			this.BP(f, r);
		}

		// Token: 0x06000E05 RID: 3589 RVA: 0x00059B48 File Offset: 0x00057D48
		private unsafe StyleMappingDto SP(Profile F, out string R)
		{
			string text;
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.SP(Profile, string*)).MethodHandle;
				}
				text = null;
			}
			else
			{
				text = \u001A\u0018\u0019.\u001D(F);
			}
			string text2;
			if ((text2 = text) == null)
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
				text2 = string.Empty;
			}
			R = text2;
			return \u0002\u0005.\u0012(F, this.OD);
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x00059B9C File Offset: 0x00057D9C
		internal void BP(StyleMappingDto F, string R)
		{
			if (F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.BP(StyleMappingDto, string)).MethodHandle;
				}
				return;
			}
			this.AD = true;
			try
			{
				string id = R;
				if (R == null)
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
					id = string.Empty;
				}
				this.ID = id;
				\u0007\u0013\u000A.\u000A(this, "ActiveProfileName");
				\u0003\u000D\u0019.\u000A(\u0019\u000D\u0019.\u000A(this), \u0009\u0004\u0004.\u0007(F));
				\u0002\u0005.\u000F(this.PD, F, this.ND);
				this.NP();
			}
			finally
			{
				this.AD = false;
				\u0012\u000D\u0019.\u000A(this, false);
			}
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x00059C3C File Offset: 0x00057E3C
		private void UP()
		{
			if (this.AD)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.UP()).MethodHandle;
				}
				return;
			}
			\u0012\u000D\u0019.\u000A(this, true);
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00059C6C File Offset: 0x00057E6C
		private void WP(object F, PropertyChangedEventArgs R)
		{
			if (\u0008\u0013\u000A.\u000A(\u001C\u000D\u0019.\u000A(R), "UseAdvancedMapping"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.WP(object, PropertyChangedEventArgs)).MethodHandle;
				}
				if (!\u0010\u000D\u0019.\u000A(\u0019\u000D\u0019.\u000A(this)))
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
					\u000D\u000D\u0019.\u000A(this, 0);
				}
				return;
			}
			if (\u0008\u0013\u000A.\u000A(\u001C\u000D\u0019.\u000A(R), "SelectedBlackAndWhiteTextLines"))
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
				this.KP();
			}
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00059CEC File Offset: 0x00057EEC
		private void KP()
		{
			EnumInfo enumInfo = \u001C\u0012\u0019.\u001D(\u0019\u000D\u0019.\u000A(this));
			BlackAndWhiteTextLinesOption blackAndWhiteTextLinesOption;
			if (enumInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.KP()).MethodHandle;
				}
				blackAndWhiteTextLinesOption = BlackAndWhiteTextLinesOption.ConvertAllColorsToBlack;
			}
			else
			{
				blackAndWhiteTextLinesOption = (BlackAndWhiteTextLinesOption)\u000D\u001B\u001D.\u001D(enumInfo);
			}
			BlackAndWhiteTextLinesOption u000A = blackAndWhiteTextLinesOption;
			\u0003\u0012\u0019.\u000A(\u0009\u0004\u0004.\u0007(this.PD), u000A);
			\u000E\u000D\u0019.\u000A(this.XD, u000A);
			this.AD = true;
			try
			{
				ExcelStylesAggregator vd = this.VD;
				IReadOnlyCollection<ExcelLineStyleInfo> u001F;
				if (vd == null)
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
					u001F = null;
				}
				else
				{
					u001F = \u0001\u001D\u0019.\u001D(vd);
				}
				ExcelStylesAggregator vd2 = this.VD;
				IReadOnlyCollection<ExcelTextStyleInfo> u000A2;
				if (vd2 == null)
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
					u000A2 = null;
				}
				else
				{
					u000A2 = \u000C\u001D\u0019.\u001D(vd2);
				}
				this.OD = \u0002\u0005.\u000B(u001F, u000A2, this.ND);
				StyleMappingDto pd = this.PD;
				ExcelStylesAggregator vd3 = this.VD;
				IReadOnlyCollection<ExcelLineStyleInfo> u000A3;
				if (vd3 == null)
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
					u000A3 = null;
				}
				else
				{
					u000A3 = \u0001\u001D\u0019.\u001D(vd3);
				}
				ExcelStylesAggregator vd4 = this.VD;
				IReadOnlyCollection<ExcelTextStyleInfo> u;
				if (vd4 == null)
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
					u = null;
				}
				else
				{
					u = \u000C\u001D\u0019.\u001D(vd4);
				}
				\u0002\u0005.\u0006(pd, u000A3, u, this.ND);
				this.EP();
				this.NP();
			}
			finally
			{
				this.AD = false;
			}
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00059E14 File Offset: 0x00058014
		private static StyleMappingDto JP(StyleMappingDto F)
		{
			if (F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(StyleMappingSettingsViewModel.JP(StyleMappingDto)).MethodHandle;
				}
				return null;
			}
			StyleMappingDto result;
			try
			{
				StyleMappingDto styleMappingDto;
				if ((styleMappingDto = JsonConvert.DeserializeObject<StyleMappingDto>(\u000E\u000D\u0004.\u000A(F, Formatting.None))) == null)
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
					styleMappingDto = \u001F\u000D\u0004.\u000A();
				}
				result = styleMappingDto;
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\StyleMappings\\StyleMappingSettingsViewModel.cs", "DeepClone");
				result = \u001F\u000D\u0004.\u000A();
			}
			return result;
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00059E98 File Offset: 0x00058098
		private void EP()
		{
			\u001E\u0003\u0019.\u001D(\u000F\u000D\u0019.\u000A(this), \u0012\u001C\u0004.\u0007(this.PD));
			\u0008\u000D\u0019.\u0007(\u0002\u000D\u0019.\u000A(this), \u0005\u000D\u0004.\u0007(this.PD));
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00059EDC File Offset: 0x000580DC
		private void NP()
		{
			\u0011\u000D\u0019.\u000A(\u000F\u000D\u0019.\u000A(this));
			\u001B\u000D\u0019.\u000A(\u0002\u000D\u0019.\u000A(this));
		}

		// Token: 0x0400057D RID: 1405
		private readonly Document ND;

		// Token: 0x0400057E RID: 1406
		private readonly List<SelectedExcel> MD;

		// Token: 0x0400057F RID: 1407
		private readonly ExcelStylesAggregator VD;

		// Token: 0x04000580 RID: 1408
		private readonly StyleCacheReloadCallback ZD;

		// Token: 0x04000581 RID: 1409
		private readonly StyleCacheSyncCallback XD;

		// Token: 0x04000582 RID: 1410
		private StyleMappingDto PD;

		// Token: 0x04000583 RID: 1411
		private StyleMappingDto OD;

		// Token: 0x04000584 RID: 1412
		private Profile TD;

		// Token: 0x04000585 RID: 1413
		private string ID;

		// Token: 0x04000586 RID: 1414
		private bool QD;

		// Token: 0x04000587 RID: 1415
		private bool AD;

		// Token: 0x04000588 RID: 1416
		private int GD;

		// Token: 0x04000589 RID: 1417
		[CompilerGenerated]
		private GeneralViewModel FH;

		// Token: 0x0400058A RID: 1418
		[CompilerGenerated]
		private LineStylesViewModel RH;

		// Token: 0x0400058B RID: 1419
		[CompilerGenerated]
		private TextStylesViewModel DH;
	}
}
