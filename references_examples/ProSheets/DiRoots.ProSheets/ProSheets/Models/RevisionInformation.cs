using System;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;

namespace ProSheets.Models
{
	// Token: 0x020000F7 RID: 247
	public class RevisionInformation : ModelBase
	{
		// Token: 0x06000BEA RID: 3050 RVA: 0x000489A8 File Offset: 0x00046BA8
		public RevisionInformation(Revision revision)
		{
			\u000D\u0002\u0016.\u0018(this, revision);
		}

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x06000BEB RID: 3051 RVA: 0x000489C4 File Offset: 0x00046BC4
		// (set) Token: 0x06000BEC RID: 3052 RVA: 0x000489D8 File Offset: 0x00046BD8
		public Revision Revision { get; set; }

		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x06000BED RID: 3053 RVA: 0x000489EC File Offset: 0x00046BEC
		public string Name
		{
			get
			{
				return \u001E\u0016\u0014.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00048A08 File Offset: 0x00046C08
		public string RevisionNumber
		{
			get
			{
				return this.BQ();
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000BEF RID: 3055 RVA: 0x00048A20 File Offset: 0x00046C20
		public string Description
		{
			get
			{
				return \u0013\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x00048A3C File Offset: 0x00046C3C
		public string IssuedBy
		{
			get
			{
				return \u0009\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000BF1 RID: 3057 RVA: 0x00048A58 File Offset: 0x00046C58
		public string IssuedTo
		{
			get
			{
				return \u000A\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x00048A74 File Offset: 0x00046C74
		public string Date
		{
			get
			{
				return \u0020\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06000BF3 RID: 3059 RVA: 0x00048A90 File Offset: 0x00046C90
		public string Issued
		{
			get
			{
				bool flag = \u001F\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
				return \u0001\u001B\u0014.\u0018(ref flag);
			}
		}

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x00048AB8 File Offset: 0x00046CB8
		public int Sequence
		{
			get
			{
				return \u0011\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06000BF5 RID: 3061 RVA: 0x00048AD4 File Offset: 0x00046CD4
		// (set) Token: 0x06000BF6 RID: 3062 RVA: 0x00048AE8 File Offset: 0x00046CE8
		public bool IsLinkDoc { get; set; }

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x00048AFC File Offset: 0x00046CFC
		public string DisplayName
		{
			get
			{
				int num = \u0017\u0002\u0016.\u0014(this);
				return \u0014\u001E\u0018.\u0018(\u0010\u001E\u0018.\u0018(ref num), "-", \u0015\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x00048B30 File Offset: 0x00046D30
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x00048B44 File Offset: 0x00046D44
		public bool IsChecked
		{
			get
			{
				return this.Q;
			}
			set
			{
				this.Q = value;
				\u0007\u001B\u0018.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x00048B64 File Offset: 0x00046D64
		public string UniqueId
		{
			get
			{
				return \u001E\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x00048B80 File Offset: 0x00046D80
		private string BQ()
		{
			string result = string.Empty;
			try
			{
				result = \u0004\u0002\u0016.\u0018(\u001C\u0002\u0016.\u0014(this));
			}
			catch (Exception u)
			{
				\u0017\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), u, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\Models\\RevisionInformation.cs", "GettingRevisionNumber");
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x04000584 RID: 1412
		private bool Q;

		// Token: 0x04000585 RID: 1413
		[CompilerGenerated]
		private Revision OB;

		// Token: 0x04000586 RID: 1414
		[CompilerGenerated]
		private bool CB;
	}
}
