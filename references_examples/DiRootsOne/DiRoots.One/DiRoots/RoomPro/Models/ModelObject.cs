using System;
using System.Collections.Generic;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.One.Commons.Models;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000075 RID: 117
	[Schema("A0B2E05A-F827-4671-B628-EA43D08AE8B3", "StoredModelObject")]
	public class ModelObject : ModelBase, IRevitEntity
	{
		// Token: 0x0600050D RID: 1293 RVA: 0x0001EFE8 File Offset: 0x0001D1E8
		public ModelObject()
		{
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0001F008 File Offset: 0x0001D208
		public ModelObject(string name)
		{
			\u000D\u0009\u0007.\u000A(this, name);
			\u001C\u0009\u0007.\u000A(this, -1L);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x0001F038 File Offset: 0x0001D238
		public ModelObject(Element element)
		{
			\u000D\u0009\u0007.\u000A(this, \u0005\u001E\u000A.\u000A(element));
			\u001C\u0009\u0007.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element)));
		}

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x0001F07C File Offset: 0x0001D27C
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x0001F090 File Offset: 0x0001D290
		[Field]
		public string Name { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x0001F0A4 File Offset: 0x0001D2A4
		// (set) Token: 0x06000513 RID: 1299 RVA: 0x0001F0B8 File Offset: 0x0001D2B8
		[Field]
		public long Id { get; set; }

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x0001F0CC File Offset: 0x0001D2CC
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x0001F0E0 File Offset: 0x0001D2E0
		[Field]
		public SpatialElementStoredData SpatialElementStoredData { get; set; } = new SpatialElementStoredData();

		// Token: 0x06000516 RID: 1302 RVA: 0x0001F0F4 File Offset: 0x0001D2F4
		public Element GetElement()
		{
			Document u = \u000C\u001D.\u0006;
			Element element = \u0011\u0017\u000A.\u0007(u, \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u001D(this)));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelObject.GetElement()).MethodHandle;
				}
				return element;
			}
			List<RevitLinkInstance>.Enumerator enumerator = \u001B\u0009\u0007.\u000A(new \u0013\u001D(u).\u0007());
			try
			{
				while (\u0010\u0009\u0007.\u000A(ref enumerator))
				{
					Element element2 = \u0011\u0017\u000A.\u0007(\u000E\u0009\u0007.\u000A(\u0008\u0009\u0007.\u000A(ref enumerator)), \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u001D(this)));
					if (element2 != null)
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
						return element2;
					}
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
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			return element;
		}
	}
}
