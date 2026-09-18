using System;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000076 RID: 118
	[Schema("3C1B8978-78A0-4C0D-81B9-2F4C5BE2E878", "StoredModelPhaseData")]
	public class ModelPhase : ModelObject
	{
		// Token: 0x06000517 RID: 1303 RVA: 0x0001F1C0 File Offset: 0x0001D3C0
		public ModelPhase()
		{
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0001F1D4 File Offset: 0x0001D3D4
		public ModelPhase(string name) : base(name)
		{
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0001F1E8 File Offset: 0x0001D3E8
		public ModelPhase(Phase phase) : base(phase)
		{
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0001F21C File Offset: 0x0001D41C
		internal static ModelPhase NullModelPhase
		{
			get
			{
				return ModelPhase._nullModelPhase;
			}
		}

		// Token: 0x040001F0 RID: 496
		private static readonly ModelPhase _nullModelPhase = \u0011\u0009\u0007.\u000A(\u0015\u0012\u0007.\u000A());
	}
}
