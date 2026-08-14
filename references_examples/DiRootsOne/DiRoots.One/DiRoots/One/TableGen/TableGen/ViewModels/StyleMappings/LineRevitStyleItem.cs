using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000173 RID: 371
	public sealed class LineRevitStyleItem : RevitStyleItemBase
	{
		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x000593B4 File Offset: 0x000575B4
		// (set) Token: 0x06000DDA RID: 3546 RVA: 0x000593C8 File Offset: 0x000575C8
		public IReadOnlyList<LinePatternSegmentType> PatternSegmentTypes { get; set; } = Array.Empty<LinePatternSegmentType>();

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x000593DC File Offset: 0x000575DC
		// (set) Token: 0x06000DDC RID: 3548 RVA: 0x000593F0 File Offset: 0x000575F0
		public bool IsNone { get; set; }

		// Token: 0x06000DDD RID: 3549 RVA: 0x00059404 File Offset: 0x00057604
		public LineRevitStyleItem WithGroupName(string groupName)
		{
			LineRevitStyleItem lineRevitStyleItem = \u0006\u001C\u0019.\u000A();
			\u0010\u0003\u0019.\u000A(lineRevitStyleItem, \u0004\u0003\u0019.\u001D(this));
			\u0002\u001C\u0019.\u000A(lineRevitStyleItem, \u0007\u0003\u0019.\u001D(this));
			\u000B\u001C\u0019.\u000A(lineRevitStyleItem, \u001F\u0003\u0019.\u001D(this));
			\u000D\u001C\u0019.\u000A(lineRevitStyleItem, \u0019\u0003\u0019.\u001D(this));
			\u0016\u001C\u0019.\u000A(lineRevitStyleItem, groupName);
			\u0005\u001C\u0019.\u000A(lineRevitStyleItem, \u0014\u001C\u0019.\u0007(this));
			\u001D\u001C\u0019.\u000A(lineRevitStyleItem, \u0017\u001C\u0019.\u0007(this));
			\u0007\u001C\u0019.\u000A(lineRevitStyleItem, \u0020\u001C\u0019.\u0007(this));
			return lineRevitStyleItem;
		}

		// Token: 0x04000577 RID: 1399
		[CompilerGenerated]
		private IReadOnlyList<LinePatternSegmentType> \u0018;

		// Token: 0x04000578 RID: 1400
		[CompilerGenerated]
		private bool \u0005;
	}
}
