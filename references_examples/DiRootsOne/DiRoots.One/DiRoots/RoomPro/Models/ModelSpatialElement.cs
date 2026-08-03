using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.ExtensibleStorage;
using DiRoots.One.QuickViews.Models;
using DiRoots.RoomPro.Enums;
using DiRoots.RoomPro.Interfaces;

namespace DiRoots.RoomPro.Models
{
	// Token: 0x02000079 RID: 121
	[XmlInclude(typeof(ModelRoom))]
	[XmlInclude(typeof(ModelSpace))]
	[Schema("bfc5df94-568a-4956-8b94-9989fba077b1", "StoredModelSpatialElement")]
	public class ModelSpatialElement : ModelObject, IModelElement
	{
		// Token: 0x06000526 RID: 1318 RVA: 0x0001F318 File Offset: 0x0001D518
		public ModelSpatialElement()
		{
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0001F33C File Offset: 0x0001D53C
		public ModelSpatialElement(SpatialElement spatialElement, RevitLinkInstance revitLinkInstance, bool isFromLinkedFile = false) : this()
		{
			Document u = \u000C\u001D.\u0006;
			\u0018\u001F\u001D.\u000A(this, isFromLinkedFile);
			\u0019\u001F\u001D.\u000A(this, revitLinkInstance);
			if (\u0016\u0007\u000E.\u001F(spatialElement) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelSpatialElement..ctor(SpatialElement, RevitLinkInstance, bool)).MethodHandle;
				}
				\u0004\u001F\u001D.\u000A(this, SpatialType.Room);
			}
			else
			{
				\u0004\u001F\u001D.\u000A(this, SpatialType.Space);
			}
			\u001D\u001F\u001D.\u000A(this, spatialElement);
			\u0007\u001F\u001D.\u000A(this, spatialElement);
			\u001C\u0009\u0007.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(spatialElement)));
			\u000A\u001F\u001D.\u000A(this, \u0014\u0014\u0007.\u000A(spatialElement));
			\u000D\u0009\u0007.\u000A(this, \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(spatialElement, -1006900L)));
			try
			{
				\u001F\u001F\u001D.\u000A(this, \u0002\u0004\u0007.\u000A(spatialElement, \u0004\u0013\u000A.\u0007(u)));
			}
			catch (Exception u000A)
			{
				\u0009\u0009\u0007.\u000A(\u001E\u000A\u0007.\u000A(), \u0004\u001E\u000A.\u000A("Number: ", \u0007\u000D\u0007.\u001D(this)), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Models\\ModelSpatialElement.cs", ".ctor");
				\u0009\u0009\u0007.\u000A(\u001E\u000A\u0007.\u000A(), \u0004\u001E\u000A.\u000A("Name: ", \u001D\u000D\u0007.\u001D(this)), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Models\\ModelSpatialElement.cs", ".ctor");
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Models\\ModelSpatialElement.cs", ".ctor");
			}
			if (\u0001\u0009\u0007.\u000A(this) != null)
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
				\u0015\u0009\u0007.\u000A(this, revitLinkInstance);
			}
			if (\u0014\u001C\u0007.\u001D(this))
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
				\u001A\u0009\u0007.\u000A(this, spatialElement.\u000F(1, \u000C\u0009\u0007.\u0007(this)));
			}
			else
			{
				\u001A\u0009\u0007.\u000A(this, spatialElement.\u000F(1, \u000C\u0009\u0010.\u001F));
			}
			\u0013\u0009\u0007.\u000A(this, spatialElement.\u0002());
			\u0017\u0009\u0007.\u000A(this, \u0014\u0009\u0007.\u0007(\u0008\u0019\u0007.\u000A(spatialElement)));
		}

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x0001F4F8 File Offset: 0x0001D6F8
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x0001F50C File Offset: 0x0001D70C
		[XmlIgnore]
		public ListCollectionView ViewInformations { get; set; }

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x0001F520 File Offset: 0x0001D720
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x0001F534 File Offset: 0x0001D734
		[XmlIgnore]
		public SpatialElement SpatialElement { get; set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x0600052C RID: 1324 RVA: 0x0001F548 File Offset: 0x0001D748
		// (set) Token: 0x0600052D RID: 1325 RVA: 0x0001F55C File Offset: 0x0001D75C
		[XmlIgnore]
		public SpatialType Type { get; set; }

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x0001F570 File Offset: 0x0001D770
		// (set) Token: 0x0600052F RID: 1327 RVA: 0x0001F584 File Offset: 0x0001D784
		[XmlIgnore]
		public Element Element { get; set; }

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000530 RID: 1328 RVA: 0x0001F598 File Offset: 0x0001D798
		// (set) Token: 0x06000531 RID: 1329 RVA: 0x0001F5AC File Offset: 0x0001D7AC
		[XmlIgnore]
		public RevitLinkInstance RvtLinkInstance { get; set; }

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000532 RID: 1330 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
		// (set) Token: 0x06000533 RID: 1331 RVA: 0x0001F5D4 File Offset: 0x0001D7D4
		[XmlIgnore]
		public BoundingBoxXYZ BoundingBox { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000534 RID: 1332 RVA: 0x0001F5E8 File Offset: 0x0001D7E8
		// (set) Token: 0x06000535 RID: 1333 RVA: 0x0001F5FC File Offset: 0x0001D7FC
		[XmlIgnore]
		public XYZ BoundingBoxMin { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0001F610 File Offset: 0x0001D810
		// (set) Token: 0x06000537 RID: 1335 RVA: 0x0001F624 File Offset: 0x0001D824
		[XmlIgnore]
		public XYZ BoundingBoxMax { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x0001F638 File Offset: 0x0001D838
		// (set) Token: 0x06000539 RID: 1337 RVA: 0x0001F64C File Offset: 0x0001D84C
		[XmlIgnore]
		public XYZ Origin { get; set; }

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0001F660 File Offset: 0x0001D860
		// (set) Token: 0x0600053B RID: 1339 RVA: 0x0001F674 File Offset: 0x0001D874
		[XmlIgnore]
		public Transform Transform { get; set; }

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x0001F688 File Offset: 0x0001D888
		// (set) Token: 0x0600053D RID: 1341 RVA: 0x0001F69C File Offset: 0x0001D89C
		[XmlIgnore]
		public List<Line> Boundaries { get; private set; }

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x0600053E RID: 1342 RVA: 0x0001F6B0 File Offset: 0x0001D8B0
		[XmlIgnore]
		public int BoundariesNumber
		{
			get
			{
				List<Line> list = \u0005\u001F\u001D.\u000A(this);
				if (list == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ModelSpatialElement.get_BoundariesNumber()).MethodHandle;
					}
					return 0;
				}
				return \u000E\u0007\u0007.\u001D(list);
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x0600053F RID: 1343 RVA: 0x0001F6E8 File Offset: 0x0001D8E8
		// (set) Token: 0x06000540 RID: 1344 RVA: 0x0001F6FC File Offset: 0x0001D8FC
		[XmlIgnore]
		public Level Level { get; private set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000541 RID: 1345 RVA: 0x0001F710 File Offset: 0x0001D910
		// (set) Token: 0x06000542 RID: 1346 RVA: 0x0001F724 File Offset: 0x0001D924
		[XmlIgnore]
		public string Number { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x06000543 RID: 1347 RVA: 0x0001F738 File Offset: 0x0001D938
		// (set) Token: 0x06000544 RID: 1348 RVA: 0x0001F74C File Offset: 0x0001D94C
		[XmlIgnore]
		public string DocumentTitle { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x06000545 RID: 1349 RVA: 0x0001F760 File Offset: 0x0001D960
		// (set) Token: 0x06000546 RID: 1350 RVA: 0x0001F774 File Offset: 0x0001D974
		[XmlIgnore]
		public bool IsFromLinkedFile { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000547 RID: 1351 RVA: 0x0001F788 File Offset: 0x0001D988
		// (set) Token: 0x06000548 RID: 1352 RVA: 0x0001F79C File Offset: 0x0001D99C
		[XmlIgnore]
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				this._isChecked = value;
				\u0007\u0013\u000A.\u000A(this, "IsChecked");
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x0001F7BC File Offset: 0x0001D9BC
		// (set) Token: 0x0600054A RID: 1354 RVA: 0x0001F7D0 File Offset: 0x0001D9D0
		[XmlIgnore]
		public bool IsCreated
		{
			get
			{
				return this._isCreated;
			}
			set
			{
				this._isCreated = value;
				\u0007\u0013\u000A.\u000A(this, "IsCreated");
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x0600054B RID: 1355 RVA: 0x0001F7F0 File Offset: 0x0001D9F0
		// (set) Token: 0x0600054C RID: 1356 RVA: 0x0001F804 File Offset: 0x0001DA04
		[Field]
		public ViewInformation ViewInformation
		{
			get
			{
				return this._viewInformation;
			}
			set
			{
				this._viewInformation = value;
				\u0007\u0013\u000A.\u000A(this, "ViewInformation");
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0001F824 File Offset: 0x0001DA24
		// (set) Token: 0x0600054E RID: 1358 RVA: 0x0001F838 File Offset: 0x0001DA38
		[Field]
		public int CalloutStatus
		{
			get
			{
				return this._calloutStatus;
			}
			set
			{
				this._calloutStatus = value;
				\u0007\u0013\u000A.\u000A(this, "CalloutStatus");
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x0600054F RID: 1359 RVA: 0x0001F858 File Offset: 0x0001DA58
		// (set) Token: 0x06000550 RID: 1360 RVA: 0x0001F86C File Offset: 0x0001DA6C
		[Field]
		public int SectionAndElevationStatus
		{
			get
			{
				return this._sectionAndElevationStatus;
			}
			set
			{
				this._sectionAndElevationStatus = value;
				\u0007\u0013\u000A.\u000A(this, "SectionAndElevationStatus");
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x06000551 RID: 1361 RVA: 0x0001F88C File Offset: 0x0001DA8C
		// (set) Token: 0x06000552 RID: 1362 RVA: 0x0001F8A0 File Offset: 0x0001DAA0
		[XmlIgnore]
		public bool IsDisplayed
		{
			get
			{
				return this._isDisplayed;
			}
			set
			{
				this._isDisplayed = value;
				\u0007\u0013\u000A.\u000A(this, "IsDisplayed");
			}
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0001F8C0 File Offset: 0x0001DAC0
		private void SetBoundingBoxParams(RevitLinkInstance revitLinkInstance)
		{
			\u000F\u001F\u001D.\u000A(this, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(\u0001\u0009\u0007.\u000A(this))), \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(\u0001\u0009\u0007.\u000A(this))), \u0003\u000A\u0007.\u000A(\u000B\u0004\u0007.\u000A(\u0001\u0009\u0007.\u000A(this)))));
			\u0006\u001F\u001D.\u000A(this, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(\u0001\u0009\u0007.\u000A(this))), \u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(\u0001\u0009\u0007.\u000A(this))), \u0003\u000A\u0007.\u000A(\u0016\u0004\u0007.\u000A(\u0001\u0009\u0007.\u000A(this)))));
			if (revitLinkInstance == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ModelSpatialElement.SetBoundingBoxParams(RevitLinkInstance)).MethodHandle;
				}
				XYZ u001F = \u001B\u001F\u0007.\u000A((\u000D\u001F\u0007.\u000A(\u000B\u001F\u001D.\u000A(this)) + \u000D\u001F\u0007.\u000A(\u0002\u001F\u001D.\u000A(this))) / 2.0, (\u001C\u001F\u0007.\u000A(\u000B\u001F\u001D.\u000A(this)) + \u001C\u001F\u0007.\u000A(\u0002\u001F\u001D.\u000A(this))) / 2.0, (\u0003\u000A\u0007.\u000A(\u000B\u001F\u001D.\u000A(this)) + \u0003\u000A\u0007.\u000A(\u0002\u001F\u001D.\u000A(this))) / 2.0);
				\u0016\u001F\u001D.\u000A(this, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F), \u001C\u001F\u0007.\u000A(u001F), \u0003\u000A\u0007.\u000A(\u000B\u001F\u001D.\u000A(this))));
				return;
			}
			\u0012\u001F\u001D.\u000A(this, \u0003\u001F\u001D.\u000A(revitLinkInstance));
			\u000F\u001F\u001D.\u000A(this, \u0007\u0013\u0007.\u000A(\u000C\u0009\u0007.\u0007(this), \u000B\u001F\u001D.\u000A(this)));
			\u0006\u001F\u001D.\u000A(this, \u0007\u0013\u0007.\u000A(\u000C\u0009\u0007.\u0007(this), \u0002\u001F\u001D.\u000A(this)));
			XYZ u001F2 = \u001B\u001F\u0007.\u000A((\u000D\u001F\u0007.\u000A(\u000B\u001F\u001D.\u000A(this)) + \u000D\u001F\u0007.\u000A(\u0002\u001F\u001D.\u000A(this))) / 2.0, (\u001C\u001F\u0007.\u000A(\u000B\u001F\u001D.\u000A(this)) + \u001C\u001F\u0007.\u000A(\u0002\u001F\u001D.\u000A(this))) / 2.0, (\u0003\u000A\u0007.\u000A(\u000B\u001F\u001D.\u000A(this)) + \u0003\u000A\u0007.\u000A(\u0002\u001F\u001D.\u000A(this))) / 2.0);
			\u0016\u001F\u001D.\u000A(this, \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F2), \u001C\u001F\u0007.\u000A(u001F2), \u0003\u000A\u0007.\u000A(\u000B\u001F\u001D.\u000A(this))));
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0001FB2C File Offset: 0x0001DD2C
		public override string ToString()
		{
			return \u0002\u0013\u000A.\u000A(\u001D\u000D\u0007.\u001D(this), " - ", \u0005\u001E\u000A.\u000A(\u000A\u000D\u0007.\u001D(this)));
		}

		// Token: 0x040001F3 RID: 499
		private bool _isChecked;

		// Token: 0x040001F4 RID: 500
		private bool _isCreated;

		// Token: 0x040001F5 RID: 501
		private int _calloutStatus = 1;

		// Token: 0x040001F6 RID: 502
		private int _sectionAndElevationStatus = 1;

		// Token: 0x040001F7 RID: 503
		private bool _isDisplayed;

		// Token: 0x040001F8 RID: 504
		private ViewInformation _viewInformation;
	}
}
