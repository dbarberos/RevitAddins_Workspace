using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000087 RID: 135
	[Schema("1F0A1228-9CA3-4D0A-A07F-D05E3A0B5C74", "StoredSpatialElementData", Documentation = "Spatial Element Data to be stored.")]
	public class SpatialElementStoredData : IRevitEntity
	{
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x060005E2 RID: 1506 RVA: 0x00020D74 File Offset: 0x0001EF74
		// (set) Token: 0x060005E3 RID: 1507 RVA: 0x00020D88 File Offset: 0x0001EF88
		[Obsolete("Please use SectionsIdAsValues instead. Support for reading data from the old schema will be removed in future updates.")]
		[Field]
		[XmlIgnore]
		public List<ElementId> SectionsIds { get; set; } = new List<ElementId>();

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x060005E4 RID: 1508 RVA: 0x00020D9C File Offset: 0x0001EF9C
		// (set) Token: 0x060005E5 RID: 1509 RVA: 0x00020DB0 File Offset: 0x0001EFB0
		[Obsolete("Please use MarkersIdAsValues instead. Support for reading data from the old schema will be removed in future updates.")]
		[XmlIgnore]
		[Field]
		public List<ElementId> MarkersIds { get; set; } = new List<ElementId>();

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00020DC4 File Offset: 0x0001EFC4
		// (set) Token: 0x060005E7 RID: 1511 RVA: 0x00020DD8 File Offset: 0x0001EFD8
		[Obsolete("Please use CalloutViewsIdAsValues instead. Support for reading data from the old schema will be removed in future updates.")]
		[Field]
		[XmlIgnore]
		public List<ElementId> CalloutViewsIds { get; set; } = new List<ElementId>();

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x00020DEC File Offset: 0x0001EFEC
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00020E78 File Offset: 0x0001F078
		public List<long> SectionsIdAsValues
		{
			get
			{
				if (\u001A\u0014\u000A.\u000A(\u001C\u000A\u001D.\u000A(this)) != 0)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.get_SectionsIdAsValues()).MethodHandle;
					}
					IEnumerable<ElementId> enumerable = \u001C\u000A\u001D.\u000A(this);
					Func<ElementId, long> func;
					if ((func = SpatialElementStoredData.<>c.<>9__20_0) == null)
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
						func = (SpatialElementStoredData.<>c.<>9__20_0 = ((ElementId x) => \u000B\u001E\u000A.\u000A(x)));
					}
					this._sectionsIdAsValues = Enumerable.ToList<long>(Enumerable.Select<ElementId, long>(enumerable, func));
					\u0003\u000A\u001D.\u000A(\u001C\u000A\u001D.\u000A(this));
				}
				return this._sectionsIdAsValues;
			}
			set
			{
				this._sectionsIdAsValues = value;
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x00020E8C File Offset: 0x0001F08C
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x00020F18 File Offset: 0x0001F118
		public List<long> MarkersIdAsValues
		{
			get
			{
				if (\u001A\u0014\u000A.\u000A(\u000D\u000A\u001D.\u000A(this)) != 0)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.get_MarkersIdAsValues()).MethodHandle;
					}
					IEnumerable<ElementId> enumerable = \u000D\u000A\u001D.\u000A(this);
					Func<ElementId, long> func;
					if ((func = SpatialElementStoredData.<>c.<>9__23_0) == null)
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
						func = (SpatialElementStoredData.<>c.<>9__23_0 = ((ElementId x) => \u000B\u001E\u000A.\u000A(x)));
					}
					this._markersIdAsValues = Enumerable.ToList<long>(Enumerable.Select<ElementId, long>(enumerable, func));
					\u0003\u000A\u001D.\u000A(\u000D\u000A\u001D.\u000A(this));
				}
				return this._markersIdAsValues;
			}
			set
			{
				this._markersIdAsValues = value;
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00020F2C File Offset: 0x0001F12C
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x00020FB8 File Offset: 0x0001F1B8
		public List<long> CalloutViewsIdAsValues
		{
			get
			{
				if (\u001A\u0014\u000A.\u000A(\u0010\u000A\u001D.\u000A(this)) != 0)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.get_CalloutViewsIdAsValues()).MethodHandle;
					}
					IEnumerable<ElementId> enumerable = \u0010\u000A\u001D.\u000A(this);
					Func<ElementId, long> func;
					if ((func = SpatialElementStoredData.<>c.<>9__26_0) == null)
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
						func = (SpatialElementStoredData.<>c.<>9__26_0 = ((ElementId x) => \u000B\u001E\u000A.\u000A(x)));
					}
					this._calloutViewsIdAsValues = Enumerable.ToList<long>(Enumerable.Select<ElementId, long>(enumerable, func));
					\u0003\u000A\u001D.\u000A(\u0010\u000A\u001D.\u000A(this));
				}
				return this._calloutViewsIdAsValues;
			}
			set
			{
				this._calloutViewsIdAsValues = value;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00020FCC File Offset: 0x0001F1CC
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x000210A8 File Offset: 0x0001F2A8
		public List<string> SectionsUniqueId
		{
			get
			{
				if (\u001B\u000A\u001D.\u000A(\u0008\u000A\u001D.\u000A(this)) != 0)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.get_SectionsUniqueId()).MethodHandle;
					}
					IEnumerable<long> enumerable = \u0008\u000A\u001D.\u000A(this);
					Func<long, ElementId> func;
					if ((func = SpatialElementStoredData.<>c.<>9__29_0) == null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						func = (SpatialElementStoredData.<>c.<>9__29_0 = ((long x) => \u001E\u0001\u000A.\u000A(x)));
					}
					IEnumerable<View> enumerable2 = Enumerable.OfType<View>(Enumerable.Select<ElementId, Element>(Enumerable.Select<long, ElementId>(enumerable, func), new Func<ElementId, Element>(\u000C\u001D.\u0006.GetElement)));
					Func<View, string> func2;
					if ((func2 = SpatialElementStoredData.<>c.<>9__29_1) == null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						func2 = (SpatialElementStoredData.<>c.<>9__29_1 = ((View x) => \u0012\u0010\u0007.\u000A(x)));
					}
					this._sectionsUniqueId = Enumerable.ToList<string>(Enumerable.Select<View, string>(enumerable2, func2));
					\u000E\u000A\u001D.\u000A(\u0008\u000A\u001D.\u000A(this));
				}
				return this._sectionsUniqueId;
			}
			set
			{
				this._sectionsUniqueId = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x000210BC File Offset: 0x0001F2BC
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x00021198 File Offset: 0x0001F398
		public List<string> MarkersUniqueId
		{
			get
			{
				if (\u001B\u000A\u001D.\u000A(\u0011\u000A\u001D.\u000A(this)) != 0)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.get_MarkersUniqueId()).MethodHandle;
					}
					IEnumerable<long> enumerable = \u0011\u000A\u001D.\u000A(this);
					Func<long, ElementId> func;
					if ((func = SpatialElementStoredData.<>c.<>9__32_0) == null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
						func = (SpatialElementStoredData.<>c.<>9__32_0 = ((long x) => \u001E\u0001\u000A.\u000A(x)));
					}
					IEnumerable<View> enumerable2 = Enumerable.OfType<View>(Enumerable.Select<ElementId, Element>(Enumerable.Select<long, ElementId>(enumerable, func), new Func<ElementId, Element>(\u000C\u001D.\u0006.GetElement)));
					Func<View, string> func2;
					if ((func2 = SpatialElementStoredData.<>c.<>9__32_1) == null)
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
						func2 = (SpatialElementStoredData.<>c.<>9__32_1 = ((View x) => \u0012\u0010\u0007.\u000A(x)));
					}
					this._markersUniqueId = Enumerable.ToList<string>(Enumerable.Select<View, string>(enumerable2, func2));
					\u000E\u000A\u001D.\u000A(\u0011\u000A\u001D.\u000A(this));
				}
				return this._markersUniqueId;
			}
			set
			{
				this._markersUniqueId = value;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x000211AC File Offset: 0x0001F3AC
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x00021288 File Offset: 0x0001F488
		public List<string> CalloutViewsUniqueId
		{
			get
			{
				if (\u001B\u000A\u001D.\u000A(\u001E\u000A\u001D.\u000A(this)) != 0)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.get_CalloutViewsUniqueId()).MethodHandle;
					}
					IEnumerable<long> enumerable = \u001E\u000A\u001D.\u000A(this);
					Func<long, ElementId> func;
					if ((func = SpatialElementStoredData.<>c.<>9__35_0) == null)
					{
						for (;;)
						{
							switch (1)
							{
							case 0:
								continue;
							}
							break;
						}
						func = (SpatialElementStoredData.<>c.<>9__35_0 = ((long x) => \u001E\u0001\u000A.\u000A(x)));
					}
					IEnumerable<View> enumerable2 = Enumerable.OfType<View>(Enumerable.Select<ElementId, Element>(Enumerable.Select<long, ElementId>(enumerable, func), new Func<ElementId, Element>(\u000C\u001D.\u0006.GetElement)));
					Func<View, string> func2;
					if ((func2 = SpatialElementStoredData.<>c.<>9__35_1) == null)
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
						func2 = (SpatialElementStoredData.<>c.<>9__35_1 = ((View x) => \u0012\u0010\u0007.\u000A(x)));
					}
					this._calloutViewsUniqueId = Enumerable.ToList<string>(Enumerable.Select<View, string>(enumerable2, func2));
					\u000E\u000A\u001D.\u000A(\u001E\u000A\u001D.\u000A(this));
				}
				return this._calloutViewsUniqueId;
			}
			set
			{
				this._calloutViewsUniqueId = value;
			}
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0002129C File Offset: 0x0001F49C
		public List<View> GetSectionViews(Document doc)
		{
			IEnumerable<View> enumerable = Enumerable.OfType<View>(Enumerable.Select<string, Element>(\u001E\u0008\u0007.\u001D(this), new Func<string, Element>(doc.GetElement)));
			Func<View, bool> func;
			if ((func = SpatialElementStoredData.<>c.<>9__37_0) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.GetSectionViews(Document)).MethodHandle;
				}
				func = (SpatialElementStoredData.<>c.<>9__37_0 = ((View x) => x != \u0011\u001F\u000E.\u001F));
			}
			return Enumerable.ToList<View>(Enumerable.Where<View>(enumerable, func));
		}

		// Token: 0x060005F5 RID: 1525 RVA: 0x0002130C File Offset: 0x0001F50C
		public List<ElevationMarker> GetMarkerViews(Document doc)
		{
			IEnumerable<ElevationMarker> enumerable = Enumerable.OfType<ElevationMarker>(Enumerable.Select<string, Element>(\u001B\u0008\u0007.\u001D(this), new Func<string, Element>(doc.GetElement)));
			Func<ElevationMarker, bool> func;
			if ((func = SpatialElementStoredData.<>c.<>9__38_0) == null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.GetMarkerViews(Document)).MethodHandle;
				}
				func = (SpatialElementStoredData.<>c.<>9__38_0 = ((ElevationMarker x) => x != \u0002\u0005\u0008.\u001F));
			}
			return Enumerable.ToList<ElevationMarker>(Enumerable.Where<ElevationMarker>(enumerable, func));
		}

		// Token: 0x060005F6 RID: 1526 RVA: 0x0002137C File Offset: 0x0001F57C
		public List<View> GetCallOutViews(Document doc)
		{
			IEnumerable<View> enumerable = Enumerable.OfType<View>(Enumerable.Select<string, Element>(\u0020\u0008\u0007.\u001D(this), new Func<string, Element>(doc.GetElement)));
			Func<View, bool> func;
			if ((func = SpatialElementStoredData.<>c.<>9__39_0) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.GetCallOutViews(Document)).MethodHandle;
				}
				func = (SpatialElementStoredData.<>c.<>9__39_0 = ((View x) => x != \u0011\u001F\u000E.\u001F));
			}
			return Enumerable.ToList<View>(Enumerable.Where<View>(enumerable, func));
		}

		// Token: 0x060005F7 RID: 1527 RVA: 0x000213EC File Offset: 0x0001F5EC
		public void SetSelectionUniqueId(List<Element> elements)
		{
			Func<Element, string> func;
			if ((func = SpatialElementStoredData.<>c.<>9__40_0) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.SetSelectionUniqueId(List<Element>)).MethodHandle;
				}
				func = (SpatialElementStoredData.<>c.<>9__40_0 = ((Element x) => \u0012\u0010\u0007.\u000A(x)));
			}
			this._sectionsUniqueId = Enumerable.ToList<string>(Enumerable.Select<Element, string>(elements, func));
		}

		// Token: 0x060005F8 RID: 1528 RVA: 0x00021440 File Offset: 0x0001F640
		public void SetMarkerUniqueId(List<Element> elements)
		{
			Func<Element, string> func;
			if ((func = SpatialElementStoredData.<>c.<>9__41_0) == null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElementStoredData.SetMarkerUniqueId(List<Element>)).MethodHandle;
				}
				func = (SpatialElementStoredData.<>c.<>9__41_0 = ((Element x) => \u0012\u0010\u0007.\u000A(x)));
			}
			this._markersUniqueId = Enumerable.ToList<string>(Enumerable.Select<Element, string>(elements, func));
		}

		// Token: 0x04000245 RID: 581
		private List<long> _sectionsIdAsValues = new List<long>();

		// Token: 0x04000246 RID: 582
		private List<long> _markersIdAsValues = new List<long>();

		// Token: 0x04000247 RID: 583
		private List<long> _calloutViewsIdAsValues = new List<long>();

		// Token: 0x04000248 RID: 584
		private List<string> _calloutViewsUniqueId = new List<string>();

		// Token: 0x04000249 RID: 585
		private List<string> _markersUniqueId = new List<string>();

		// Token: 0x0400024A RID: 586
		private List<string> _sectionsUniqueId = new List<string>();
	}
}
