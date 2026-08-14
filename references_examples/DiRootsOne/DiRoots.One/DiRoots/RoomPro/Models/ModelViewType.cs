using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x0200007A RID: 122
	[Schema("64536503-9A93-4A54-A385-B1F6818EB25F", "StoredModelViewTypeData")]
	public class ModelViewType : ModelObject
	{
		// Token: 0x06000555 RID: 1365 RVA: 0x0001FB5C File Offset: 0x0001DD5C
		public ModelViewType()
		{
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0001FB70 File Offset: 0x0001DD70
		public ModelViewType(string name) : base(name)
		{
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0001FB84 File Offset: 0x0001DD84
		public ModelViewType(ViewFamilyType viewFamilyType) : base(viewFamilyType)
		{
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x0001FBB8 File Offset: 0x0001DDB8
		internal static ModelViewType NullModelViewType
		{
			get
			{
				return ModelViewType._nullModelViewType;
			}
		}

		// Token: 0x04000208 RID: 520
		private static readonly ModelViewType _nullModelViewType = \u001C\u001F\u001D.\u000A(\u0015\u0012\u0007.\u000A());
	}
}
