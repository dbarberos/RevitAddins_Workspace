using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002B8 RID: 696
	public abstract class SheetModelBase : ModelBase, ISheetModel
	{
		// Token: 0x1700079E RID: 1950
		// (get) Token: 0x06001B91 RID: 7057 RVA: 0x000B178C File Offset: 0x000AF98C
		// (set) Token: 0x06001B92 RID: 7058 RVA: 0x000B17A0 File Offset: 0x000AF9A0
		public string GUID { get; set; } = \u0017\u0006\u0007.\u000A("{0}", \u0002\u0005\u0018.\u000A());

		// Token: 0x1700079F RID: 1951
		// (get) Token: 0x06001B93 RID: 7059 RVA: 0x000B17B4 File Offset: 0x000AF9B4
		// (set) Token: 0x06001B94 RID: 7060 RVA: 0x000B17C8 File Offset: 0x000AF9C8
		public long SheetId { get; set; }

		// Token: 0x170007A0 RID: 1952
		// (get) Token: 0x06001B95 RID: 7061 RVA: 0x000B17DC File Offset: 0x000AF9DC
		// (set) Token: 0x06001B96 RID: 7062 RVA: 0x000B17F0 File Offset: 0x000AF9F0
		public virtual long TemplateSheetId { get; set; }

		// Token: 0x170007A1 RID: 1953
		// (get) Token: 0x06001B97 RID: 7063 RVA: 0x000B1804 File Offset: 0x000AFA04
		// (set) Token: 0x06001B98 RID: 7064 RVA: 0x000B1818 File Offset: 0x000AFA18
		public string SheetName
		{
			get
			{
				return this.UL;
			}
			set
			{
				base.SetProperty<string>(ref this.UL, value, null, "SheetName");
			}
		}

		// Token: 0x170007A2 RID: 1954
		// (get) Token: 0x06001B99 RID: 7065 RVA: 0x000B183C File Offset: 0x000AFA3C
		// (set) Token: 0x06001B9A RID: 7066 RVA: 0x000B1850 File Offset: 0x000AFA50
		public string SheetNumber
		{
			get
			{
				return this.WL;
			}
			set
			{
				base.SetProperty<string>(ref this.WL, value, null, "SheetNumber");
			}
		}

		// Token: 0x170007A3 RID: 1955
		// (get) Token: 0x06001B9B RID: 7067 RVA: 0x000B1874 File Offset: 0x000AFA74
		public string NumberNameDisplay
		{
			get
			{
				return \u0002\u0013\u000A.\u000A(\u0011\u0007\u0016.\u001D(this), " - ", \u0019\u0004\u0016.\u001D(this));
			}
		}

		// Token: 0x170007A4 RID: 1956
		// (get) Token: 0x06001B9C RID: 7068 RVA: 0x000B18A0 File Offset: 0x000AFAA0
		// (set) Token: 0x06001B9D RID: 7069 RVA: 0x000B18B4 File Offset: 0x000AFAB4
		public string TempSheetNumberHolder { get; set; }

		// Token: 0x170007A5 RID: 1957
		// (get) Token: 0x06001B9E RID: 7070 RVA: 0x000B18C8 File Offset: 0x000AFAC8
		// (set) Token: 0x06001B9F RID: 7071 RVA: 0x000B18DC File Offset: 0x000AFADC
		public bool IsChecked
		{
			get
			{
				return this.WR;
			}
			set
			{
				base.SetProperty<bool>(ref this.WR, value, null, "IsChecked");
			}
		}

		// Token: 0x170007A6 RID: 1958
		// (get) Token: 0x06001BA0 RID: 7072 RVA: 0x000B1900 File Offset: 0x000AFB00
		// (set) Token: 0x06001BA1 RID: 7073 RVA: 0x000B1914 File Offset: 0x000AFB14
		public string CommittedName { get; set; }

		// Token: 0x170007A7 RID: 1959
		// (get) Token: 0x06001BA2 RID: 7074 RVA: 0x000B1928 File Offset: 0x000AFB28
		// (set) Token: 0x06001BA3 RID: 7075 RVA: 0x000B193C File Offset: 0x000AFB3C
		public string CommittedNumber { get; set; }

		// Token: 0x170007A8 RID: 1960
		// (get) Token: 0x06001BA4 RID: 7076 RVA: 0x000B1950 File Offset: 0x000AFB50
		// (set) Token: 0x06001BA5 RID: 7077 RVA: 0x000B1964 File Offset: 0x000AFB64
		public virtual string TemplateSheetNumber { get; set; }

		// Token: 0x170007A9 RID: 1961
		// (get) Token: 0x06001BA6 RID: 7078 RVA: 0x000B1978 File Offset: 0x000AFB78
		// (set) Token: 0x06001BA7 RID: 7079 RVA: 0x000B198C File Offset: 0x000AFB8C
		public virtual string TitleBlockName { get; set; }

		// Token: 0x170007AA RID: 1962
		// (get) Token: 0x06001BA8 RID: 7080 RVA: 0x000B19A0 File Offset: 0x000AFBA0
		// (set) Token: 0x06001BA9 RID: 7081 RVA: 0x000B19B4 File Offset: 0x000AFBB4
		public IList<ParameterModel> Parameters { get; set; } = new List<ParameterModel>();

		// Token: 0x170007AB RID: 1963
		// (get) Token: 0x06001BAA RID: 7082 RVA: 0x000B19C8 File Offset: 0x000AFBC8
		// (set) Token: 0x06001BAB RID: 7083 RVA: 0x000B19DC File Offset: 0x000AFBDC
		public virtual UpdateStates UpdateState
		{
			get
			{
				return this.KL;
			}
			set
			{
				base.SetProperty<UpdateStates>(ref this.KL, value, null, "UpdateState");
			}
		}

		// Token: 0x170007AC RID: 1964
		// (get) Token: 0x06001BAC RID: 7084 RVA: 0x000B1A00 File Offset: 0x000AFC00
		// (set) Token: 0x06001BAD RID: 7085 RVA: 0x000B1A14 File Offset: 0x000AFC14
		public UpdateStates PreviousStatus { get; set; }

		// Token: 0x170007AD RID: 1965
		// (get) Token: 0x06001BAE RID: 7086 RVA: 0x000B1A28 File Offset: 0x000AFC28
		public bool IsOrphan
		{
			get
			{
				if (\u001D\u0004\u0016.\u001D(this) <= 0L)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetModelBase.get_IsOrphan()).MethodHandle;
					}
					return \u0013\u0005\u0016.\u000A(this) <= 0L;
				}
				return false;
			}
		}

		// Token: 0x06001BAF RID: 7087 RVA: 0x000B1A68 File Offset: 0x000AFC68
		public void AddParameter(ParameterModel paramModel)
		{
			if (\u000A\u0003\u0016.\u001D(\u0004\u0005\u0016.\u0007(paramModel)) != SelectionParameterType.ProjectInformation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetModelBase.AddParameter(ParameterModel)).MethodHandle;
				}
				\u0009\u0012\u0016.\u000A(paramModel, \u0015\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u000A\u000F\u0016.\u001D(paramModel), new Action<ParameterModel>(this.OnParameterValueChanged))));
				\u0004\u0003\u0016.\u000A(paramModel, \u0005\u0007\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u0013\u000F\u0016.\u001D(paramModel), new Action(this.OnValuePropagatedToSelectedItems))));
			}
			\u001D\u0003\u0016.\u000A(\u0005\u0005\u0016.\u001D(this), paramModel);
		}

		// Token: 0x06001BB0 RID: 7088 RVA: 0x000B1AFC File Offset: 0x000AFCFC
		protected void OnValuePropagatedToSelectedItems()
		{
			if (\u0006\u0004\u0016.\u0007(this) == UpdateStates.Updated)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetModelBase.OnValuePropagatedToSelectedItems()).MethodHandle;
				}
				\u0012\u0005\u0016.\u0007(this, UpdateStates.Modified);
			}
		}

		// Token: 0x06001BB1 RID: 7089 RVA: 0x000B1B30 File Offset: 0x000AFD30
		protected virtual void OnParameterValueChanged(ParameterModel parameter)
		{
			if (\u0006\u0004\u0016.\u0007(this) == UpdateStates.Updated)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetModelBase.OnParameterValueChanged(ParameterModel)).MethodHandle;
				}
				\u0012\u0005\u0016.\u0007(this, UpdateStates.Modified);
			}
		}

		// Token: 0x04000B21 RID: 2849
		private string UL;

		// Token: 0x04000B22 RID: 2850
		private string WL;

		// Token: 0x04000B23 RID: 2851
		private bool WR;

		// Token: 0x04000B24 RID: 2852
		private UpdateStates KL;

		// Token: 0x04000B25 RID: 2853
		[CompilerGenerated]
		private string JL;

		// Token: 0x04000B26 RID: 2854
		[CompilerGenerated]
		private long EL;

		// Token: 0x04000B27 RID: 2855
		[CompilerGenerated]
		private long NL;

		// Token: 0x04000B28 RID: 2856
		[CompilerGenerated]
		private string ML;

		// Token: 0x04000B29 RID: 2857
		[CompilerGenerated]
		private string VL;

		// Token: 0x04000B2A RID: 2858
		[CompilerGenerated]
		private string ZL;

		// Token: 0x04000B2B RID: 2859
		[CompilerGenerated]
		private string XL;

		// Token: 0x04000B2C RID: 2860
		[CompilerGenerated]
		private string PL;

		// Token: 0x04000B2D RID: 2861
		[CompilerGenerated]
		private IList<ParameterModel> OL;

		// Token: 0x04000B2E RID: 2862
		[CompilerGenerated]
		private UpdateStates TL;
	}
}
