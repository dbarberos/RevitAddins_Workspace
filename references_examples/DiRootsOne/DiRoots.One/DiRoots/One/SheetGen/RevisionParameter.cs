using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002BC RID: 700
	[Serializable]
	public class RevisionParameter : BaseParameter
	{
		// Token: 0x06001BEE RID: 7150 RVA: 0x000B2E04 File Offset: 0x000B1004
		public RevisionParameter()
		{
			\u0015\u001C\u0016.\u000A(this, \u0002\u0005\u0018.\u000A().ToString());
		}

		// Token: 0x06001BEF RID: 7151 RVA: 0x000B2E34 File Offset: 0x000B1034
		public RevisionParameter(RevisionParameterType wanted_type, string name)
		{
			\u0006\u001C\u0016.\u001D(this, wanted_type);
			\u0015\u001C\u0016.\u000A(this, \u0002\u0005\u0018.\u000A().ToString());
			\u0012\u001C\u0016.\u001D(this, name);
		}

		// Token: 0x170007C1 RID: 1985
		// (get) Token: 0x06001BF0 RID: 7152 RVA: 0x000B2E74 File Offset: 0x000B1074
		// (set) Token: 0x06001BF1 RID: 7153 RVA: 0x000B2E88 File Offset: 0x000B1088
		public string GUID { get; set; }

		// Token: 0x170007C2 RID: 1986
		// (get) Token: 0x06001BF2 RID: 7154 RVA: 0x000B2E9C File Offset: 0x000B109C
		// (set) Token: 0x06001BF3 RID: 7155 RVA: 0x000B2EB0 File Offset: 0x000B10B0
		public string Value { get; set; }

		// Token: 0x170007C3 RID: 1987
		// (get) Token: 0x06001BF4 RID: 7156 RVA: 0x000B2EC4 File Offset: 0x000B10C4
		// (set) Token: 0x06001BF5 RID: 7157 RVA: 0x000B2ED8 File Offset: 0x000B10D8
		public bool IsSelected { get; set; }

		// Token: 0x170007C4 RID: 1988
		// (get) Token: 0x06001BF6 RID: 7158 RVA: 0x000B2EEC File Offset: 0x000B10EC
		// (set) Token: 0x06001BF7 RID: 7159 RVA: 0x000B2F04 File Offset: 0x000B1104
		public new string Name
		{
			get
			{
				return \u001F\u0016\u0016.\u001D(this);
			}
			set
			{
				\u000B\u0012\u0016.\u0007(this, value);
			}
		}

		// Token: 0x170007C5 RID: 1989
		// (get) Token: 0x06001BF8 RID: 7160 RVA: 0x000B2F18 File Offset: 0x000B1118
		// (set) Token: 0x06001BF9 RID: 7161 RVA: 0x000B2F2C File Offset: 0x000B112C
		public bool IsChecked { get; set; }

		// Token: 0x170007C6 RID: 1990
		// (get) Token: 0x06001BFA RID: 7162 RVA: 0x000B2F40 File Offset: 0x000B1140
		// (set) Token: 0x06001BFB RID: 7163 RVA: 0x000B2F54 File Offset: 0x000B1154
		public RevisionParameterType ParameterType { get; set; }

		// Token: 0x06001BFC RID: 7164 RVA: 0x000B2F68 File Offset: 0x000B1168
		public void PopulateRevisions(Revision r, SheetInfo sheet)
		{
			if (r == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionParameter.PopulateRevisions(Revision, SheetInfo)).MethodHandle;
				}
				\u0001\u001C\u0016.\u000A(this, "");
				return;
			}
			try
			{
				switch (\u000F\u001C\u0016.\u001D(this))
				{
				case RevisionParameterType.Description:
					\u0001\u001C\u0016.\u000A(this, \u0017\u001C\u0016.\u000A(r));
					break;
				case RevisionParameterType.RevisionDate:
					\u0001\u001C\u0016.\u000A(this, \u0020\u001C\u0016.\u000A(r));
					break;
				case RevisionParameterType.RevisionNumber:
					if (\u0012\u0003\u0018.\u0007(\u0016\u0018\u0007.\u0007(r, -1011951L)))
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
						\u0001\u001C\u0016.\u000A(this, \u0014\u001C\u0016.\u000A(r));
					}
					else if (sheet != null)
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
						Parameter parameter = \u0016\u0018\u0007.\u0007(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(r), \u001E\u0001\u000A.\u000A(\u001D\u0004\u0016.\u0007(sheet))), -1007412L);
						if (parameter != null)
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
							\u0001\u001C\u0016.\u000A(this, \u001A\u0014\u0007.\u0007(parameter));
						}
					}
					else
					{
						\u0001\u001C\u0016.\u000A(this, "");
					}
					break;
				case RevisionParameterType.IssuedBy:
					\u0001\u001C\u0016.\u000A(this, \u000A\u000D\u0016.\u000A(r));
					break;
				case RevisionParameterType.IssuedTo:
					\u0001\u001C\u0016.\u000A(this, \u001F\u000D\u0016.\u000A(r));
					break;
				case RevisionParameterType.Show:
					\u0001\u001C\u0016.\u000A(this, this.VO(\u0009\u001C\u0016.\u000A(r)));
					break;
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0011\u0015\u0005.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetGen\\SheetGen.Core\\Models\\SheetsAggregate\\RevisionParameter.cs", "PopulateRevisions");
				\u0001\u001C\u0016.\u000A(this, "");
			}
		}

		// Token: 0x06001BFD RID: 7165 RVA: 0x000B3104 File Offset: 0x000B1304
		private string VO(RevisionVisibility F)
		{
			switch (F)
			{
			case 0:
				return "None";
			case 1:
				return "Cloud and Tag";
			case 2:
				return "Tag";
			default:
				return "";
			}
		}

		// Token: 0x06001BFE RID: 7166 RVA: 0x000B313C File Offset: 0x000B133C
		public RevisionParameter Clone()
		{
			return \u001D\u001C\u000E.\u001F(\u0001\u0012\u0016.\u000A(this));
		}
	}
}
