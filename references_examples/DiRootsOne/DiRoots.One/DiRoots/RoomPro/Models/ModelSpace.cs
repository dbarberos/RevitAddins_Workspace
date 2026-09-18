using System;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000078 RID: 120
	[Schema("AA88E5C9-1E10-44FF-BA7F-EE60AC13D592", "ModelSpaceData")]
	public class ModelSpace : ModelSpatialElement
	{
		// Token: 0x06000521 RID: 1313 RVA: 0x0001F2A4 File Offset: 0x0001D4A4
		public ModelSpace()
		{
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0001F2B8 File Offset: 0x0001D4B8
		public ModelSpace(Space space, RevitLinkInstance revitLinkInstance, bool isFromLinkedFile = false) : base(space, revitLinkInstance, isFromLinkedFile)
		{
			\u0020\u0009\u0007.\u000A(this, space);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0001F2D8 File Offset: 0x0001D4D8
		public ModelSpace(Space room) : this(room, null, false)
		{
		}

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x0001F2F0 File Offset: 0x0001D4F0
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x0001F304 File Offset: 0x0001D504
		[XmlIgnore]
		public Space Space { get; set; }
	}
}
