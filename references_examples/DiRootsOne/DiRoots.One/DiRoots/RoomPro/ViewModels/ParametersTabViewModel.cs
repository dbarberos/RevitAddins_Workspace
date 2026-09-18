using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.QuickViews.Models.Profile;
using DiRoots.RoomPro.Interfaces;
using DiRoots.RoomPro.Models;

namespace DiRoots.RoomPro.ViewModels
{
	// Token: 0x0200005A RID: 90
	public class ParametersTabViewModel : SettingsTabViewModel
	{
		// Token: 0x06000350 RID: 848 RVA: 0x00015270 File Offset: 0x00013470
		public ParametersTabViewModel(IModelSettings settings)
		{
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000C\u001D.\u0006);
			\u001F\u0012\u0007.\u000A(this, \u000A\u001F\u000E.\u001F(settings));
			IEnumerable<Parameter> enumerable = u0013_u001D.\u001E();
			Func<Parameter, string> func;
			if ((func = ParametersTabViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersTabViewModel..ctor(IModelSettings)).MethodHandle;
				}
				func = (ParametersTabViewModel.<>c.\u000A = new Func<Parameter, string>(ParametersTabViewModel.<>c.\u001F.\u0007));
			}
			this.DD = new List<Parameter>(Enumerable.OrderBy<Parameter, string>(enumerable, func));
			this.JKR();
			\u0009\u000F\u0007.\u000A(this, new CommandBase(new Action(this.FJR), new Predicate<object>(this.DJR)));
			\u0001\u000F\u0007.\u000A(this, new CommandBase(new Action(this.RJR), new Predicate<object>(this.HJR)));
		}

		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000351 RID: 849 RVA: 0x00015344 File Offset: 0x00013544
		// (set) Token: 0x06000352 RID: 850 RVA: 0x00015358 File Offset: 0x00013558
		public ObservableCollection<SpatialElementParameter> Parameters
		{
			get
			{
				return this.HD;
			}
			set
			{
				this.HD = value;
				\u000D\u0020\u000A.\u000A(this, "Parameters");
			}
		}

		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00015378 File Offset: 0x00013578
		// (set) Token: 0x06000354 RID: 852 RVA: 0x0001538C File Offset: 0x0001358C
		public ParametersSettings ParametersSettings
		{
			get
			{
				return this.YD;
			}
			set
			{
				this.YD = value;
				\u000D\u0020\u000A.\u000A(this, "ParametersSettings");
			}
		}

		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x06000355 RID: 853 RVA: 0x000153AC File Offset: 0x000135AC
		// (set) Token: 0x06000356 RID: 854 RVA: 0x000153C0 File Offset: 0x000135C0
		public ICommand AddCmd { get; set; }

		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000357 RID: 855 RVA: 0x000153D4 File Offset: 0x000135D4
		// (set) Token: 0x06000358 RID: 856 RVA: 0x000153E8 File Offset: 0x000135E8
		public ICommand RemoveCmd { get; set; }

		// Token: 0x06000359 RID: 857 RVA: 0x000153FC File Offset: 0x000135FC
		private void FJR()
		{
			\u000A\u0012\u0007.\u000A(\u001D\u0012\u0007.\u000A(this), \u0007\u0012\u0007.\u000A(Enumerable.FirstOrDefault<Parameter>(this.DD), this.DD));
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00015430 File Offset: 0x00013630
		private void RJR()
		{
			\u0004\u0012\u0007.\u000A(\u001D\u0012\u0007.\u000A(this), \u0019\u0012\u0007.\u000A(\u001D\u0012\u0007.\u000A(this)) - 1);
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0001545C File Offset: 0x0001365C
		private bool DJR(object F)
		{
			return Enumerable.Any<Parameter>(this.DD);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x00015478 File Offset: 0x00013678
		private bool HJR(object F)
		{
			return Enumerable.Any<SpatialElementParameter>(\u001D\u0012\u0007.\u000A(this));
		}

		// Token: 0x0600035D RID: 861 RVA: 0x00015494 File Offset: 0x00013694
		private void JKR()
		{
			if (Enumerable.Any<SpatialElementParameter>(\u0002\u000B\u0007.\u000A(\u0016\u0012\u0007.\u000A(this))))
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersTabViewModel.JKR()).MethodHandle;
				}
				\u0018\u0012\u0007.\u000A(this, \u0005\u0012\u0007.\u000A(\u0002\u000B\u0007.\u000A(\u0016\u0012\u0007.\u000A(this))));
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x000154E8 File Offset: 0x000136E8
		public override bool Validate(string propertyName, object value)
		{
			throw \u000C\u000C\u000A.\u000A();
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000154FC File Offset: 0x000136FC
		public ParametersSettings SettingParameter(List<ParameterSettingInfo> parameterSettings)
		{
			ParametersTabViewModel.\u0014\u0007 u0014_u = new ParametersTabViewModel.\u0014\u0007();
			u0014_u.\u001F = this;
			u0014_u.\u000A = \u0002\u0012\u0007.\u000A();
			\u000B\u0012\u0007.\u000A(parameterSettings, new Action<ParameterSettingInfo>(u0014_u.\u0007));
			return u0014_u.\u000A;
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0001553C File Offset: 0x0001373C
		internal override bool JWR(out IModelSettings F)
		{
			ParametersSettings parametersSettings = \u0002\u0012\u0007.\u000A();
			\u0006\u0012\u0007.\u000A(parametersSettings, Enumerable.ToList<SpatialElementParameter>(\u001D\u0012\u0007.\u000A(this)));
			F = parametersSettings;
			return true;
		}

		// Token: 0x0400013A RID: 314
		private readonly List<Parameter> DD;

		// Token: 0x0400013B RID: 315
		private ObservableCollection<SpatialElementParameter> HD = new ObservableCollection<SpatialElementParameter>();

		// Token: 0x0400013C RID: 316
		private ParametersSettings YD;

		// Token: 0x0400013D RID: 317
		[CompilerGenerated]
		private ICommand CD;

		// Token: 0x0400013E RID: 318
		[CompilerGenerated]
		private ICommand LD;

		// Token: 0x02000797 RID: 1943
		[CompilerGenerated]
		private sealed class \u0014\u0007
		{
			// Token: 0x06004B8F RID: 19343 RVA: 0x001DA434 File Offset: 0x001D8634
			internal void \u0007(ParameterSettingInfo \u001F)
			{
				ParametersTabViewModel.\u0013\u0007 u0013_u = new ParametersTabViewModel.\u0013\u0007();
				u0013_u.\u001F = \u001F;
				Parameter parameter;
				if (\u001D\u0001\u000D.\u000A(u0013_u.\u001F) >= 0L)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ParametersTabViewModel.\u0014\u0007.\u0007(ParameterSettingInfo)).MethodHandle;
					}
					parameter = \u001A\u0005\u0002.\u000A(this.\u001F.DD, new Predicate<Parameter>(u0013_u.\u0007));
				}
				else
				{
					parameter = \u001A\u0005\u0002.\u000A(this.\u001F.DD, new Predicate<Parameter>(u0013_u.\u000A));
				}
				Parameter parameter2 = parameter;
				if (parameter2 != null)
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
					object u001F = \u0002\u000B\u0007.\u000A(this.\u000A);
					SpatialElementParameter spatialElementParameter = \u0007\u0012\u0007.\u000A(parameter2, this.\u001F.DD);
					\u000A\u0001\u000D.\u000A(spatialElementParameter, \u0007\u0001\u000D.\u000A(u0013_u.\u001F));
					\u001F\u0001\u000D.\u000A(spatialElementParameter, parameter2);
					\u0009\u0015\u000D.\u000A(u001F, spatialElementParameter);
				}
			}

			// Token: 0x04001ECD RID: 7885
			public ParametersTabViewModel \u001F;

			// Token: 0x04001ECE RID: 7886
			public ParametersSettings \u000A;
		}

		// Token: 0x02000798 RID: 1944
		[CompilerGenerated]
		private sealed class \u0013\u0007
		{
			// Token: 0x06004B91 RID: 19345 RVA: 0x001DA514 File Offset: 0x001D8714
			internal bool \u000A(Parameter \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) == \u001D\u0001\u000D.\u000A(this.\u001F);
			}

			// Token: 0x06004B92 RID: 19346 RVA: 0x001DA540 File Offset: 0x001D8740
			internal bool \u0007(Parameter \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u001F)), \u0004\u0001\u000D.\u000A(this.\u001F));
			}

			// Token: 0x04001ECF RID: 7887
			public ParameterSettingInfo \u001F;
		}
	}
}
