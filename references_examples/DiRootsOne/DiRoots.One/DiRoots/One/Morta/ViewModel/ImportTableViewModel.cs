using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Morta.Interfaces;
using DiRoots.One.Morta.Model;
using DiRoots.One.Morta.Model.Json.Column;
using DiRoots.One.Morta.Model.Json.Table;
using DiRoots.One.SheetLink.Models;

namespace DiRoots.One.Morta.ViewModel
{
	// Token: 0x020001AB RID: 427
	public class ImportTableViewModel : SingleTableUploadViewModel
	{
		// Token: 0x06000FCF RID: 4047 RVA: 0x00064E84 File Offset: 0x00063084
		internal ImportTableViewModel(\u0013\u0006 F, IDataFactory R) : base(F, R)
		{
			\u001F\u000A\u0018.\u000A(this, false);
			\u0009\u001F\u0018.\u000A(this, string.Empty);
			\u0001\u001F\u0018.\u000A(this, new CommandBase(new Action(this.AMR), new Predicate<object>(this.GMR)));
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x00064ED0 File Offset: 0x000630D0
		// (set) Token: 0x06000FD1 RID: 4049 RVA: 0x00064EE4 File Offset: 0x000630E4
		internal Dictionary<DataTable, List<ParamExportInfo>> TablesWithParameters { get; set; }

		// Token: 0x06000FD2 RID: 4050 RVA: 0x00064EF8 File Offset: 0x000630F8
		protected override void OnSelectedTableChanged()
		{
			\u0019\u000A\u0018.\u0007(this);
			if (\u0004\u000A\u0018.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ImportTableViewModel.OnSelectedTableChanged()).MethodHandle;
				}
				\u000A\u000A\u0018.\u0007(\u001D\u000A\u0018.\u000A(this), Enumerable.FirstOrDefault<TableTypeInfo>(\u0007\u000A\u0018.\u0007(\u001D\u000A\u0018.\u000A(this)), new Func<TableTypeInfo, bool>(this.HVR)));
			}
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x00064F58 File Offset: 0x00063158
		private void AMR()
		{
			ImportTableViewModel.\u0007\u0006 u0007_u;
			u0007_u.\u000A = \u0018\u000A\u0018.\u000A();
			u0007_u.\u0007 = this;
			u0007_u.\u001F = -1;
			u0007_u.\u000A.Start<ImportTableViewModel.\u0007\u0006>(ref u0007_u);
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x00064F94 File Offset: 0x00063194
		private bool GMR(object F)
		{
			return \u0004\u000A\u0018.\u000A(this) != \u001C\u0016\u000E.\u001F;
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x00064FB0 File Offset: 0x000631B0
		internal Task FVR()
		{
			ImportTableViewModel.\u000A\u0006 u000A_u;
			u000A_u.\u000A = \u0008\u0011\u000A.\u000A();
			u000A_u.\u0007 = this;
			u000A_u.\u001F = -1;
			u000A_u.\u000A.Start<ImportTableViewModel.\u000A\u0006>(ref u000A_u);
			return \u000E\u0011\u000A.\u000A(ref u000A_u.\u000A);
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x00064FF8 File Offset: 0x000631F8
		internal static List<ParamExportInfo> RVR(List<Column> F)
		{
			List<ParamExportInfo> list = \u0012\u000A\u0018.\u000A();
			for (int i = 0; i < \u0005\u000A\u0018.\u000A(F); i++)
			{
				DiRoots.One.Morta.Model.Json.Column.Description description = \u0006\u000A\u0018.\u000A(\u000F\u000A\u0018.\u000A(F, i));
				string text;
				if (description == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ImportTableViewModel.RVR(List<Column>)).MethodHandle;
					}
					text = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					text = description.\u001F();
				}
				string u001F = text;
				ParamExportInfo paramExportInfo = \u0003\u0016\u000E.\u001F;
				if (!\u001A\u0006\u0007.\u000A(u001F))
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
					paramExportInfo = ParamExportInfo.\u0004(u001F);
				}
				if (paramExportInfo == null)
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
					paramExportInfo = \u0002\u000A\u0018.\u000A();
				}
				\u000B\u000A\u0018.\u000A(paramExportInfo, 1);
				\u0016\u000A\u0018.\u000A(list, paramExportInfo);
			}
			for (;;)
			{
				switch (1)
				{
				case 0:
					continue;
				}
				break;
			}
			return list;
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x000650B0 File Offset: 0x000632B0
		private static Type DVR(string F)
		{
			string u001F = \u0018\u0006\u001D.\u0007(F);
			if (\u0008\u0013\u000A.\u000A(u001F, "integer"))
			{
				return \u001E\u0011\u000A.\u000A(\u0016\u0005\u000E.\u001F());
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(ImportTableViewModel.DVR(string)).MethodHandle;
			}
			if (!\u0008\u0013\u000A.\u000A(u001F, "float"))
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
				return \u001E\u0011\u000A.\u000A(\u001A\u0001\u0010.\u001F());
			}
			return \u001E\u0011\u000A.\u000A(\u0012\u0016\u000E.\u001F());
		}

		// Token: 0x06000FD8 RID: 4056 RVA: 0x00065130 File Offset: 0x00063330
		[CompilerGenerated]
		private bool HVR(TableTypeInfo F)
		{
			return \u0008\u0013\u000A.\u000A(\u0003\u000A\u0018.\u0007(F), \u0003\u000A\u0018.\u0007(\u001C\u000A\u0018.\u000A(\u0004\u000A\u0018.\u000A(this))));
		}

		// Token: 0x04000650 RID: 1616
		[CompilerGenerated]
		private Dictionary<DataTable, List<ParamExportInfo>> GB;

		// Token: 0x0200086D RID: 2157
		[CompilerGenerated]
		private sealed class \u001F\u0006
		{
			// Token: 0x06004F0D RID: 20237 RVA: 0x001E1D38 File Offset: 0x001DFF38
			internal bool \u000A(Column \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0017\u001D\u0010.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x0400219D RID: 8605
			public string \u001F;
		}
	}
}
