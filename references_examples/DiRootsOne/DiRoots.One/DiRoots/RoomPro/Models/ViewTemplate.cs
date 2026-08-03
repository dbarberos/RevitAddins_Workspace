using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000088 RID: 136
	[Schema("06CF8D0B-0E52-4CE5-9B88-5C3E9F41938A", "StoredViewTemplateData")]
	public class ViewTemplate : ModelObject
	{
		// Token: 0x060005F9 RID: 1529 RVA: 0x00021494 File Offset: 0x0001F694
		public ViewTemplate()
		{
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x000214A8 File Offset: 0x0001F6A8
		public ViewTemplate(string name) : base(name)
		{
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x000214BC File Offset: 0x0001F6BC
		public ViewTemplate(View view) : base(view)
		{
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x000214F0 File Offset: 0x0001F6F0
		internal static ViewTemplate NullViewTemplate
		{
			get
			{
				return ViewTemplate._nullViewTemplate;
			}
		}

		// Token: 0x0400024E RID: 590
		private static readonly ViewTemplate _nullViewTemplate = \u0020\u000A\u001D.\u000A(\u0015\u0012\u0007.\u000A());
	}
}
