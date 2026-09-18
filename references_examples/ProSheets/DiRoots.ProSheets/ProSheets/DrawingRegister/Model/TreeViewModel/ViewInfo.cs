using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.TreeGrid;

namespace ProSheets.DrawingRegister.Model.TreeViewModel
{
	// Token: 0x02000122 RID: 290
	[Serializable]
	public class ViewInfo : BaseTreeItem
	{
		// Token: 0x06000EB6 RID: 3766 RVA: 0x00054A4C File Offset: 0x00052C4C
		public ViewInfo()
		{
			\u001A\u0016\u000F.\u0014(this, new List<ViewInfo>());
			\u001D\u0016\u000F.\u0018(this, true);
			this._isMatch = true;
			\u0004\u0016\u000F.\u0018(this, false);
			\u000F\u0014\u000F.\u0018(this, new bool?(true));
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00054A94 File Offset: 0x00052C94
		public ViewInfo(string name)
		{
			\u001A\u0016\u000F.\u0014(this, new List<ViewInfo>());
			\u001D\u0016\u000F.\u0018(this, true);
			this._isMatch = true;
			\u0004\u0016\u000F.\u0018(this, false);
			\u0019\u0016\u000F.\u0014(this, name);
			\u000B\u0016\u000F.\u0014(this, true);
			\u000F\u0014\u000F.\u0018(this, new bool?(true));
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00054AE8 File Offset: 0x00052CE8
		public ViewInfo(string name, long elementId, string uniqueId)
		{
			\u001A\u0016\u000F.\u0014(this, new List<ViewInfo>());
			\u0019\u0016\u000F.\u0014(this, name);
			\u0010\u0016\u000F.\u0014(this, elementId);
			\u0007\u0016\u000F.\u0014(this, uniqueId);
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00054B24 File Offset: 0x00052D24
		public ViewInfo(string name, long elementId)
		{
			\u001A\u0016\u000F.\u0014(this, new List<ViewInfo>());
			\u0019\u0016\u000F.\u0014(this, name);
			\u0010\u0016\u000F.\u0014(this, elementId);
		}

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06000EBA RID: 3770 RVA: 0x00054B58 File Offset: 0x00052D58
		// (set) Token: 0x06000EBB RID: 3771 RVA: 0x00054B6C File Offset: 0x00052D6C
		public string SheetName { get; set; }

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06000EBC RID: 3772 RVA: 0x00054B80 File Offset: 0x00052D80
		// (set) Token: 0x06000EBD RID: 3773 RVA: 0x00054B94 File Offset: 0x00052D94
		[XmlIgnore]
		public Document Document { get; set; }

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06000EBE RID: 3774 RVA: 0x00054BA8 File Offset: 0x00052DA8
		// (set) Token: 0x06000EBF RID: 3775 RVA: 0x00054BBC File Offset: 0x00052DBC
		public bool IsEnabled { get; set; }

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x06000EC0 RID: 3776 RVA: 0x00054BD0 File Offset: 0x00052DD0
		// (set) Token: 0x06000EC1 RID: 3777 RVA: 0x00054BE4 File Offset: 0x00052DE4
		public string Levell
		{
			get
			{
				return this._level;
			}
			set
			{
				this._level = value;
				\u0007\u001B\u0018.\u0018(this, "Levell");
			}
		}

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x00054C04 File Offset: 0x00052E04
		// (set) Token: 0x06000EC3 RID: 3779 RVA: 0x00054C18 File Offset: 0x00052E18
		public string CategoryName
		{
			get
			{
				return this._categoryName;
			}
			set
			{
				this._categoryName = value;
				\u0007\u001B\u0018.\u0018(this, "CategoryName");
			}
		}

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x06000EC4 RID: 3780 RVA: 0x00054C38 File Offset: 0x00052E38
		// (set) Token: 0x06000EC5 RID: 3781 RVA: 0x00054C4C File Offset: 0x00052E4C
		public new List<ViewInfo> Children
		{
			get
			{
				return this._children;
			}
			set
			{
				this._children = value;
				\u000E\u0016\u000F.\u0018(\u0008\u0016\u000F.\u0018(this));
				List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(value);
				try
				{
					while (\u000B\u0019\u0016.\u0018(ref enumerator))
					{
						ViewInfo viewInfo = \u0006\u0019\u0016.\u0018(ref enumerator);
						\u0005\u0016\u000F.\u0018(viewInfo, this);
						\u0001\u0016\u000F.\u0018(viewInfo, \u001B\u0016\u000F.\u0018(this));
						\u0006\u0016\u000F.\u0018(\u0008\u0016\u000F.\u0018(this), viewInfo);
					}
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.set_Children(List<ViewInfo>)).MethodHandle;
					}
				}
				finally
				{
					((IDisposable)enumerator).Dispose();
				}
				\u0007\u001B\u0018.\u0018(this, "Children");
			}
		}

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06000EC6 RID: 3782 RVA: 0x00054CF0 File Offset: 0x00052EF0
		// (set) Token: 0x06000EC7 RID: 3783 RVA: 0x00054D04 File Offset: 0x00052F04
		public string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
				\u0007\u001B\u0018.\u0018(this, "Name");
			}
		}

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06000EC8 RID: 3784 RVA: 0x00054D24 File Offset: 0x00052F24
		// (set) Token: 0x06000EC9 RID: 3785 RVA: 0x00054D38 File Offset: 0x00052F38
		public string ImageLocation
		{
			get
			{
				return this._imageLocation;
			}
			set
			{
				this._imageLocation = value;
				\u0007\u001B\u0018.\u0018(this, "ImageLocation");
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06000ECA RID: 3786 RVA: 0x00054D58 File Offset: 0x00052F58
		// (set) Token: 0x06000ECB RID: 3787 RVA: 0x00054D6C File Offset: 0x00052F6C
		public string UniqueId
		{
			get
			{
				return this._uniqueid;
			}
			set
			{
				this._uniqueid = value;
				\u0007\u001B\u0018.\u0018(this, "UniqueId");
			}
		}

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06000ECC RID: 3788 RVA: 0x00054D8C File Offset: 0x00052F8C
		// (set) Token: 0x06000ECD RID: 3789 RVA: 0x00054DA0 File Offset: 0x00052FA0
		public long ElementId
		{
			get
			{
				return this._elementId;
			}
			set
			{
				this._elementId = value;
				\u0007\u001B\u0018.\u0018(this, "ElementId");
			}
		}

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000ECE RID: 3790 RVA: 0x00054DC0 File Offset: 0x00052FC0
		// (set) Token: 0x06000ECF RID: 3791 RVA: 0x00054DD4 File Offset: 0x00052FD4
		public int CatId
		{
			get
			{
				return this._catId;
			}
			set
			{
				this._catId = value;
				\u0007\u001B\u0018.\u0018(this, "CatId");
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06000ED0 RID: 3792 RVA: 0x00054DF4 File Offset: 0x00052FF4
		// (set) Token: 0x06000ED1 RID: 3793 RVA: 0x00054E08 File Offset: 0x00053008
		public bool IsImportCadType { get; set; }

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06000ED2 RID: 3794 RVA: 0x00054E1C File Offset: 0x0005301C
		// (set) Token: 0x06000ED3 RID: 3795 RVA: 0x00054E30 File Offset: 0x00053030
		public string ElemTypeName { get; set; }

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x00054E44 File Offset: 0x00053044
		// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x00054E58 File Offset: 0x00053058
		public int ElemTypeId { get; set; }

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00054E6C File Offset: 0x0005306C
		// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x00054E80 File Offset: 0x00053080
		public string ElemTypeUniqueId { get; set; }

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00054E94 File Offset: 0x00053094
		// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x00054EA8 File Offset: 0x000530A8
		public bool CadLinkImageBased { get; set; }

		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x00054EBC File Offset: 0x000530BC
		// (set) Token: 0x06000EDB RID: 3803 RVA: 0x00054ED0 File Offset: 0x000530D0
		public string ViewType { get; set; }

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x00054EE4 File Offset: 0x000530E4
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x00054EF8 File Offset: 0x000530F8
		public bool IsDisciplineExists { get; set; }

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x00054F0C File Offset: 0x0005310C
		// (set) Token: 0x06000EDF RID: 3807 RVA: 0x00054F20 File Offset: 0x00053120
		public bool IsTemplate { get; set; }

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06000EE0 RID: 3808 RVA: 0x00054F34 File Offset: 0x00053134
		// (set) Token: 0x06000EE1 RID: 3809 RVA: 0x00054F48 File Offset: 0x00053148
		public string ParametricViewType { get; set; }

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06000EE2 RID: 3810 RVA: 0x00054F5C File Offset: 0x0005315C
		// (set) Token: 0x06000EE3 RID: 3811 RVA: 0x00054F70 File Offset: 0x00053170
		public string Discipline { get; set; }

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06000EE4 RID: 3812 RVA: 0x00054F84 File Offset: 0x00053184
		// (set) Token: 0x06000EE5 RID: 3813 RVA: 0x00054F98 File Offset: 0x00053198
		public bool IsTitleblockRevisionSchedule { get; set; }

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x00054FAC File Offset: 0x000531AC
		// (set) Token: 0x06000EE7 RID: 3815 RVA: 0x00054FC0 File Offset: 0x000531C0
		public double? NumberOfRowsInSchedules { get; set; }

		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x00054FD4 File Offset: 0x000531D4
		// (set) Token: 0x06000EE9 RID: 3817 RVA: 0x00054FE8 File Offset: 0x000531E8
		public string SheetNumber { get; set; }

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06000EEA RID: 3818 RVA: 0x00054FFC File Offset: 0x000531FC
		// (set) Token: 0x06000EEB RID: 3819 RVA: 0x00055010 File Offset: 0x00053210
		public int ViewTemplateId { get; set; }

		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06000EEC RID: 3820 RVA: 0x00055024 File Offset: 0x00053224
		// (set) Token: 0x06000EED RID: 3821 RVA: 0x00055038 File Offset: 0x00053238
		public string ViewPhaseName { get; set; }

		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06000EEE RID: 3822 RVA: 0x0005504C File Offset: 0x0005324C
		// (set) Token: 0x06000EEF RID: 3823 RVA: 0x00055060 File Offset: 0x00053260
		public string CategoryBuiltName { get; set; }

		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06000EF0 RID: 3824 RVA: 0x00055074 File Offset: 0x00053274
		// (set) Token: 0x06000EF1 RID: 3825 RVA: 0x00055088 File Offset: 0x00053288
		public bool IsMatch
		{
			get
			{
				return this._isMatch;
			}
			set
			{
				if (value == this._isMatch)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.set_IsMatch(bool)).MethodHandle;
					}
					return;
				}
				this._isMatch = value;
				\u0007\u001B\u0018.\u0018(this, "IsMatch");
			}
		}

		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x000550C4 File Offset: 0x000532C4
		public bool IsLeaf
		{
			get
			{
				return !Enumerable.Any<ViewInfo>(\u0007\u0019\u0016.\u0003(this));
			}
		}

		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06000EF3 RID: 3827 RVA: 0x000550E4 File Offset: 0x000532E4
		// (set) Token: 0x06000EF4 RID: 3828 RVA: 0x000550F8 File Offset: 0x000532F8
		public bool IsDependent { get; set; }

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06000EF5 RID: 3829 RVA: 0x0005510C File Offset: 0x0005330C
		// (set) Token: 0x06000EF6 RID: 3830 RVA: 0x00055120 File Offset: 0x00053320
		public bool IsView { get; set; }

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06000EF7 RID: 3831 RVA: 0x00055134 File Offset: 0x00053334
		// (set) Token: 0x06000EF8 RID: 3832 RVA: 0x00055148 File Offset: 0x00053348
		public bool IsFolder { get; set; }

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06000EF9 RID: 3833 RVA: 0x0005515C File Offset: 0x0005335C
		// (set) Token: 0x06000EFA RID: 3834 RVA: 0x00055170 File Offset: 0x00053370
		public bool IsUsed { get; set; } = true;

		// Token: 0x06000EFB RID: 3835 RVA: 0x00055184 File Offset: 0x00053384
		private bool MQ(string P)
		{
			if (!\u001F\u001A\u0018.\u0018(P))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.MQ(string)).MethodHandle;
				}
				return \u001B\u0013\u0018.\u000C(this._name, P);
			}
			return true;
		}

		// Token: 0x06000EFC RID: 3836 RVA: 0x000551C0 File Offset: 0x000533C0
		private void XQ(string P, ViewInfo Q)
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u0007\u0019\u0016.\u0014(Q));
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo viewInfo = \u0006\u0019\u0016.\u0018(ref enumerator);
					if (\u001E\u0010\u0016.\u0018(viewInfo))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.XQ(string, ViewInfo)).MethodHandle;
						}
						if (!viewInfo.MQ(P))
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
							\u000C\u000F\u000F.\u0014(viewInfo, false);
						}
					}
					this.XQ(P, viewInfo);
				}
				for (;;)
				{
					switch (5)
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
		}

		// Token: 0x06000EFD RID: 3837 RVA: 0x00055260 File Offset: 0x00053460
		public void ApplyCriteria(string criteria, Stack<ViewInfo> ancestors)
		{
			if (this.MQ(criteria))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.ApplyCriteria(string, Stack<ViewInfo>)).MethodHandle;
				}
				\u000C\u000F\u000F.\u0003(this, true);
				Stack<ViewInfo>.Enumerator enumerator = \u0012\u000F\u000F.\u0018(ancestors);
				try
				{
					while (\u0016\u000F\u000F.\u0018(ref enumerator))
					{
						ViewInfo viewInfo = \u000F\u000F\u000F.\u0018(ref enumerator);
						\u000C\u000F\u000F.\u0014(viewInfo, true);
						\u0016\u0014\u000F.\u0018(viewInfo, !\u001F\u001A\u0018.\u0018(criteria));
						this.XQ(criteria, viewInfo);
					}
					for (;;)
					{
						switch (3)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					enumerator.Dispose();
				}
				\u0016\u0014\u000F.\u0018(this, false);
			}
			else
			{
				\u000C\u000F\u000F.\u0003(this, false);
			}
			\u0003\u000F\u000F.\u0018(ancestors, this);
			List<ViewInfo>.Enumerator enumerator2 = \u0008\u0019\u0016.\u0018(\u0007\u0019\u0016.\u0003(this));
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator2))
				{
					\u0014\u000F\u000F.\u0018(\u0006\u0019\u0016.\u0018(ref enumerator2), criteria, ancestors);
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator2).Dispose();
			}
			\u0018\u000F\u000F.\u0018(ancestors);
		}

		// Token: 0x06000EFE RID: 3838 RVA: 0x00055374 File Offset: 0x00053574
		public void Initialize()
		{
			List<ViewInfo>.Enumerator enumerator = \u0008\u0019\u0016.\u0018(\u0007\u0019\u0016.\u0003(this));
			try
			{
				while (\u000B\u0019\u0016.\u0018(ref enumerator))
				{
					ViewInfo u000C = \u0006\u0019\u0016.\u0018(ref enumerator);
					IEnumerable<ViewInfo> enumerable = \u0007\u0019\u0016.\u0014(u000C);
					Func<ViewInfo, string> func;
					if ((func = ViewInfo.<>c.\u0018) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(ViewInfo.Initialize()).MethodHandle;
						}
						func = (ViewInfo.<>c.\u0018 = new Func<ViewInfo, string>(ViewInfo.<>c.\u000C.\u0014));
					}
					\u001A\u0016\u000F.\u0003(u000C, Enumerable.ToList<ViewInfo>(Enumerable.OrderBy<ViewInfo, string>(enumerable, func)));
					\u0005\u0016\u000F.\u0018(u000C, this);
					\u000D\u000F\u000F.\u0018(u000C);
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
		}

		// Token: 0x06000EFF RID: 3839 RVA: 0x0005542C File Offset: 0x0005362C
		public void RemoveChild(ViewInfo viewInfo)
		{
			\u0017\u000C\u000F.\u0018(\u0007\u0019\u0016.\u0003(this), viewInfo);
			\u001C\u000F\u000F.\u0018(\u0008\u0016\u000F.\u0018(this), viewInfo);
		}

		// Token: 0x040006A3 RID: 1699
		private string _name;

		// Token: 0x040006A4 RID: 1700
		private string _uniqueid;

		// Token: 0x040006A5 RID: 1701
		private long _elementId;

		// Token: 0x040006A6 RID: 1702
		private string _categoryName;

		// Token: 0x040006A7 RID: 1703
		private string _level;

		// Token: 0x040006A8 RID: 1704
		private int _catId;

		// Token: 0x040006A9 RID: 1705
		private List<ViewInfo> _children;

		// Token: 0x040006AA RID: 1706
		private bool _isMatch;

		// Token: 0x040006AB RID: 1707
		private string _imageLocation;
	}
}
