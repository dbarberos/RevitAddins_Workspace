using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002B9 RID: 697
	public class ParameterInfo : ModelBase, IEquatable<SelectionParameter>
	{
		// Token: 0x06001BB2 RID: 7090 RVA: 0x000B1B64 File Offset: 0x000AFD64
		public ParameterInfo()
		{
			\u0018\u0003\u0016.\u000A(this, "");
			\u0019\u0003\u0016.\u000A(this, new SelectionParameter());
		}

		// Token: 0x170007AE RID: 1966
		// (get) Token: 0x06001BB3 RID: 7091 RVA: 0x000B1B90 File Offset: 0x000AFD90
		// (set) Token: 0x06001BB4 RID: 7092 RVA: 0x000B1BA4 File Offset: 0x000AFDA4
		internal static bool DisableParameterChanged { get; set; }

		// Token: 0x170007AF RID: 1967
		// (get) Token: 0x06001BB5 RID: 7093 RVA: 0x000B1BB8 File Offset: 0x000AFDB8
		// (set) Token: 0x06001BB6 RID: 7094 RVA: 0x000B1BCC File Offset: 0x000AFDCC
		public ParameterIntegerValue InitialBooleanValue { get; set; }

		// Token: 0x170007B0 RID: 1968
		// (get) Token: 0x06001BB7 RID: 7095 RVA: 0x000B1BE0 File Offset: 0x000AFDE0
		// (set) Token: 0x06001BB8 RID: 7096 RVA: 0x000B1BF4 File Offset: 0x000AFDF4
		public ParameterIntegerValue BooleanValue { get; set; }

		// Token: 0x170007B1 RID: 1969
		// (get) Token: 0x06001BB9 RID: 7097 RVA: 0x000B1C08 File Offset: 0x000AFE08
		// (set) Token: 0x06001BBA RID: 7098 RVA: 0x000B1C1C File Offset: 0x000AFE1C
		public string Value
		{
			get
			{
				return this.QL;
			}
			set
			{
				this.QL = value;
				\u0007\u0013\u000A.\u000A(this, "Value");
			}
		}

		// Token: 0x170007B2 RID: 1970
		// (get) Token: 0x06001BBB RID: 7099 RVA: 0x000B1C3C File Offset: 0x000AFE3C
		// (set) Token: 0x06001BBC RID: 7100 RVA: 0x000B1C50 File Offset: 0x000AFE50
		public SelectionParameter Parameter { get; set; }

		// Token: 0x06001BBD RID: 7101 RVA: 0x000B1C64 File Offset: 0x000AFE64
		public bool Equals(SelectionParameter parameter)
		{
			bool result = false;
			if (parameter == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ParameterInfo.Equals(SelectionParameter)).MethodHandle;
				}
				return false;
			}
			if (\u0008\u000F\u0016.\u0007(\u0005\u0003\u0016.\u000A(this)) != -1L)
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
				if (\u0008\u000F\u0016.\u0007(\u0005\u0003\u0016.\u000A(this)) == \u0008\u000F\u0016.\u0007(parameter))
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
					result = true;
				}
			}
			else if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u0007(\u0005\u0003\u0016.\u000A(this)), \u001F\u0016\u0016.\u0007(parameter)))
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
				result = true;
			}
			return result;
		}

		// Token: 0x04000B2F RID: 2863
		[CompilerGenerated]
		private static bool IL;

		// Token: 0x04000B30 RID: 2864
		private string QL;

		// Token: 0x04000B31 RID: 2865
		[CompilerGenerated]
		private ParameterIntegerValue AL;

		// Token: 0x04000B32 RID: 2866
		[CompilerGenerated]
		private ParameterIntegerValue GL;

		// Token: 0x04000B33 RID: 2867
		[CompilerGenerated]
		private SelectionParameter FS;
	}
}
