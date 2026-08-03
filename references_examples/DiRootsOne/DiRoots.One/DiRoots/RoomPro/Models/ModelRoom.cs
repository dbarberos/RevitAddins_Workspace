using System;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000077 RID: 119
	[Schema("8B96E98C-970F-439D-8784-8AB3FA793292", "ModelRoomData")]
	public class ModelRoom : ModelSpatialElement
	{
		// Token: 0x0600051C RID: 1308 RVA: 0x0001F230 File Offset: 0x0001D430
		public ModelRoom()
		{
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0001F244 File Offset: 0x0001D444
		public ModelRoom(Room room, RevitLinkInstance revitLinkInstance, bool isFromLinkedFile = false) : base(room, revitLinkInstance, isFromLinkedFile)
		{
			\u001E\u0009\u0007.\u000A(this, room);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0001F264 File Offset: 0x0001D464
		public ModelRoom(Room room) : this(room, null, false)
		{
		}

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x0600051F RID: 1311 RVA: 0x0001F27C File Offset: 0x0001D47C
		// (set) Token: 0x06000520 RID: 1312 RVA: 0x0001F290 File Offset: 0x0001D490
		[XmlIgnore]
		public Room Room { get; set; }
	}
}
