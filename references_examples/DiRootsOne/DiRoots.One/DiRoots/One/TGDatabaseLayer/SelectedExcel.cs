using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Input;
using System.Xml.Serialization;
using A;
using DiRoots.One.Commons;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.TGDatabaseLayer.Dto;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x02000119 RID: 281
	[Serializable]
	public class SelectedExcel : ModelBase
	{
		// Token: 0x06000A1F RID: 2591 RVA: 0x00042E10 File Offset: 0x00041010
		public SelectedExcel()
		{
			this.IZ();
			\u0005\u0008\u0004.\u0007(this, \u0016\u0008\u0004.\u000A(this._viewTypes, 0));
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00042EAC File Offset: 0x000410AC
		public SelectedExcel(EnumInfo viewType)
		{
			this.IZ();
			this._viewType = viewType;
			\u0002\u0008\u0004.\u0007(this, new SelectedExcel());
		}

		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06000A22 RID: 2594 RVA: 0x00042F70 File Offset: 0x00041170
		// (set) Token: 0x06000A23 RID: 2595 RVA: 0x00042F84 File Offset: 0x00041184
		internal static List<SelectedExcel> ExcelAndViews { get; set; } = \u0003\u000B\u0004.\u000A();

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x06000A24 RID: 2596 RVA: 0x00042F98 File Offset: 0x00041198
		// (set) Token: 0x06000A25 RID: 2597 RVA: 0x00042FAC File Offset: 0x000411AC
		internal static bool IsOldVersion { get; set; }

		// Token: 0x1400000E RID: 14
		// (add) Token: 0x06000A26 RID: 2598 RVA: 0x00042FC0 File Offset: 0x000411C0
		// (remove) Token: 0x06000A27 RID: 2599 RVA: 0x0004300C File Offset: 0x0004120C
		internal static event SelectedExcel.ViewTypeUnallowedHandler XR
		{
			[CompilerGenerated]
			add
			{
				SelectedExcel.ViewTypeUnallowedHandler viewTypeUnallowedHandler = SelectedExcel.XR;
				SelectedExcel.ViewTypeUnallowedHandler viewTypeUnallowedHandler2;
				do
				{
					viewTypeUnallowedHandler2 = viewTypeUnallowedHandler;
					SelectedExcel.ViewTypeUnallowedHandler value2 = (SelectedExcel.ViewTypeUnallowedHandler)\u000F\u001E\u000A.\u000A(viewTypeUnallowedHandler2, value);
					viewTypeUnallowedHandler = Interlocked.CompareExchange<SelectedExcel.ViewTypeUnallowedHandler>(ref SelectedExcel.XR, value2, viewTypeUnallowedHandler2);
				}
				while (viewTypeUnallowedHandler != viewTypeUnallowedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.add_XR(SelectedExcel.ViewTypeUnallowedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				SelectedExcel.ViewTypeUnallowedHandler viewTypeUnallowedHandler = SelectedExcel.XR;
				SelectedExcel.ViewTypeUnallowedHandler viewTypeUnallowedHandler2;
				do
				{
					viewTypeUnallowedHandler2 = viewTypeUnallowedHandler;
					SelectedExcel.ViewTypeUnallowedHandler value2 = (SelectedExcel.ViewTypeUnallowedHandler)\u0012\u001E\u000A.\u000A(viewTypeUnallowedHandler2, value);
					viewTypeUnallowedHandler = Interlocked.CompareExchange<SelectedExcel.ViewTypeUnallowedHandler>(ref SelectedExcel.XR, value2, viewTypeUnallowedHandler2);
				}
				while (viewTypeUnallowedHandler != viewTypeUnallowedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.remove_XR(SelectedExcel.ViewTypeUnallowedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x06000A28 RID: 2600 RVA: 0x00043058 File Offset: 0x00041258
		// (remove) Token: 0x06000A29 RID: 2601 RVA: 0x000430A4 File Offset: 0x000412A4
		internal static event SelectedExcel.AutoSyncChangedHandler PR
		{
			[CompilerGenerated]
			add
			{
				SelectedExcel.AutoSyncChangedHandler autoSyncChangedHandler = SelectedExcel.PR;
				SelectedExcel.AutoSyncChangedHandler autoSyncChangedHandler2;
				do
				{
					autoSyncChangedHandler2 = autoSyncChangedHandler;
					SelectedExcel.AutoSyncChangedHandler value2 = (SelectedExcel.AutoSyncChangedHandler)\u000F\u001E\u000A.\u000A(autoSyncChangedHandler2, value);
					autoSyncChangedHandler = Interlocked.CompareExchange<SelectedExcel.AutoSyncChangedHandler>(ref SelectedExcel.PR, value2, autoSyncChangedHandler2);
				}
				while (autoSyncChangedHandler != autoSyncChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.add_PR(SelectedExcel.AutoSyncChangedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				SelectedExcel.AutoSyncChangedHandler autoSyncChangedHandler = SelectedExcel.PR;
				SelectedExcel.AutoSyncChangedHandler autoSyncChangedHandler2;
				do
				{
					autoSyncChangedHandler2 = autoSyncChangedHandler;
					SelectedExcel.AutoSyncChangedHandler value2 = (SelectedExcel.AutoSyncChangedHandler)\u0012\u001E\u000A.\u000A(autoSyncChangedHandler2, value);
					autoSyncChangedHandler = Interlocked.CompareExchange<SelectedExcel.AutoSyncChangedHandler>(ref SelectedExcel.PR, value2, autoSyncChangedHandler2);
				}
				while (autoSyncChangedHandler != autoSyncChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.remove_PR(SelectedExcel.AutoSyncChangedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x06000A2A RID: 2602 RVA: 0x000430F0 File Offset: 0x000412F0
		// (remove) Token: 0x06000A2B RID: 2603 RVA: 0x0004313C File Offset: 0x0004133C
		internal static event SelectedExcel.ExcelFileChangedHandler OR
		{
			[CompilerGenerated]
			add
			{
				SelectedExcel.ExcelFileChangedHandler excelFileChangedHandler = SelectedExcel.OR;
				SelectedExcel.ExcelFileChangedHandler excelFileChangedHandler2;
				do
				{
					excelFileChangedHandler2 = excelFileChangedHandler;
					SelectedExcel.ExcelFileChangedHandler value2 = (SelectedExcel.ExcelFileChangedHandler)\u000F\u001E\u000A.\u000A(excelFileChangedHandler2, value);
					excelFileChangedHandler = Interlocked.CompareExchange<SelectedExcel.ExcelFileChangedHandler>(ref SelectedExcel.OR, value2, excelFileChangedHandler2);
				}
				while (excelFileChangedHandler != excelFileChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.add_OR(SelectedExcel.ExcelFileChangedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				SelectedExcel.ExcelFileChangedHandler excelFileChangedHandler = SelectedExcel.OR;
				SelectedExcel.ExcelFileChangedHandler excelFileChangedHandler2;
				do
				{
					excelFileChangedHandler2 = excelFileChangedHandler;
					SelectedExcel.ExcelFileChangedHandler value2 = (SelectedExcel.ExcelFileChangedHandler)\u0012\u001E\u000A.\u000A(excelFileChangedHandler2, value);
					excelFileChangedHandler = Interlocked.CompareExchange<SelectedExcel.ExcelFileChangedHandler>(ref SelectedExcel.OR, value2, excelFileChangedHandler2);
				}
				while (excelFileChangedHandler != excelFileChangedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.remove_OR(SelectedExcel.ExcelFileChangedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x00043188 File Offset: 0x00041388
		private void IZ()
		{
			this._viewTypes = \u001D\u0016.\u001D();
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x06000A2D RID: 2605 RVA: 0x000431A4 File Offset: 0x000413A4
		// (set) Token: 0x06000A2E RID: 2606 RVA: 0x000431B8 File Offset: 0x000413B8
		public List<SheetAndNamedRange> SheetAndNamedRanges
		{
			get
			{
				return this._sheetAndNamedRanges;
			}
			set
			{
				this._sheetAndNamedRanges = value;
				IEnumerable<SheetAndNamedRange> sheetAndNamedRanges = this._sheetAndNamedRanges;
				Func<SheetAndNamedRange, bool> func;
				if ((func = SelectedExcel.<>c.\u000A) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_SheetAndNamedRanges(List<SheetAndNamedRange>)).MethodHandle;
					}
					func = (SelectedExcel.<>c.\u000A = new Func<SheetAndNamedRange, bool>(SelectedExcel.<>c.\u001F.\u0012));
				}
				IEnumerable<SheetAndNamedRange> enumerable = Enumerable.Where<SheetAndNamedRange>(sheetAndNamedRanges, func);
				Func<SheetAndNamedRange, string> func2;
				if ((func2 = SelectedExcel.<>c.\u0007) == null)
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
					func2 = (SelectedExcel.<>c.\u0007 = new Func<SheetAndNamedRange, string>(SelectedExcel.<>c.\u001F.\u0003));
				}
				\u0006\u0008\u0004.\u000A(this, Enumerable.ToList<string>(Enumerable.Select<SheetAndNamedRange, string>(enumerable, func2)));
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x06000A2F RID: 2607 RVA: 0x00043248 File Offset: 0x00041448
		// (set) Token: 0x06000A30 RID: 2608 RVA: 0x0004325C File Offset: 0x0004145C
		[XmlIgnore]
		public bool FromTableGen { get; set; }

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000A31 RID: 2609 RVA: 0x00043270 File Offset: 0x00041470
		// (set) Token: 0x06000A32 RID: 2610 RVA: 0x00043284 File Offset: 0x00041484
		public StyleMappingDto StyleMappingSnapshot { get; set; }

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000A33 RID: 2611 RVA: 0x00043298 File Offset: 0x00041498
		// (set) Token: 0x06000A34 RID: 2612 RVA: 0x000432AC File Offset: 0x000414AC
		[XmlIgnore]
		public bool OutOfDate
		{
			get
			{
				return this._outOfDate;
			}
			set
			{
				if (this._outOfDate == value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_OutOfDate(bool)).MethodHandle;
					}
					return;
				}
				this._outOfDate = value;
				\u0007\u0013\u000A.\u000A(this, "OutOfDate");
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000A35 RID: 2613 RVA: 0x000432E8 File Offset: 0x000414E8
		// (set) Token: 0x06000A36 RID: 2614 RVA: 0x000432FC File Offset: 0x000414FC
		public bool IsSelected
		{
			get
			{
				return this._isSelected;
			}
			set
			{
				this._isSelected = value;
				\u0007\u0013\u000A.\u000A(this, "IsSelected");
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000A37 RID: 2615 RVA: 0x0004331C File Offset: 0x0004151C
		// (set) Token: 0x06000A38 RID: 2616 RVA: 0x00043330 File Offset: 0x00041530
		public ActionTypes ActionType
		{
			get
			{
				return this._actionType;
			}
			set
			{
				this._actionType = value;
				\u0007\u0013\u000A.\u000A(this, "ActionType");
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000A39 RID: 2617 RVA: 0x00043350 File Offset: 0x00041550
		// (set) Token: 0x06000A3A RID: 2618 RVA: 0x00043364 File Offset: 0x00041564
		public UpdateStates UpdateState
		{
			get
			{
				return this._updateState;
			}
			set
			{
				this._updateState = value;
				\u0007\u0013\u000A.\u000A(this, "UpdateState");
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000A3B RID: 2619 RVA: 0x00043384 File Offset: 0x00041584
		// (set) Token: 0x06000A3C RID: 2620 RVA: 0x00043398 File Offset: 0x00041598
		public int ViewScale
		{
			get
			{
				return this._viewScale;
			}
			set
			{
				if (base.SetProperty<int>(ref this._viewScale, value, null, "ViewScale"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_ViewScale(int)).MethodHandle;
					}
					\u0012\u0008\u0004.\u0007(this);
					\u000F\u0008\u0004.\u000A(this);
				}
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000A3D RID: 2621 RVA: 0x000433DC File Offset: 0x000415DC
		public string ToolTipMessage
		{
			get
			{
				switch (\u0001\u0016\u0004.\u001D(this))
				{
				case UpdateStates.Updated:
					if (!\u000D\u0008\u0004.\u000A(this))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_ToolTipMessage()).MethodHandle;
						}
						return \u001C\u0008\u0004.\u000A();
					}
					return \u0003\u0008\u0004.\u000A();
				case UpdateStates.Modified:
					return \u0011\u0008\u0004.\u000A();
				case UpdateStates.ToTrash:
					return \u0010\u0008\u0004.\u000A();
				case UpdateStates.ToAdd:
					return \u0008\u0008\u0004.\u000A();
				case UpdateStates.ToDuplicate:
					return \u000E\u0008\u0004.\u000A();
				case UpdateStates.Recreate:
					return \u001B\u0008\u0004.\u000A();
				}
				return "";
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000A3E RID: 2622 RVA: 0x00043470 File Offset: 0x00041670
		// (set) Token: 0x06000A3F RID: 2623 RVA: 0x00043538 File Offset: 0x00041738
		public bool IsRelativePath
		{
			get
			{
				if (this._isRelativePath)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_IsRelativePath()).MethodHandle;
					}
					try
					{
						if (\u001A\u0006\u0007.\u000A(\u0017\u0008\u0004.\u0007(this)))
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
							if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this)))
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
								\u001E\u0008\u0004.\u0007(this, \u0020\u0008\u0004.\u0007(this, \u0011\u0020\u001D.\u001D(this), \u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())))));
							}
						}
					}
					catch (Exception u000A)
					{
						\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "IsRelativePath");
					}
				}
				return this._isRelativePath;
			}
			set
			{
				bool isRelativePath = this._isRelativePath;
				if (value)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_IsRelativePath(bool)).MethodHandle;
					}
					try
					{
						if (\u001A\u0006\u0007.\u000A(\u0017\u0008\u0004.\u0007(this)))
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
							if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this)))
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
								\u001E\u0008\u0004.\u0007(this, \u0020\u0008\u0004.\u0007(this, \u0011\u0020\u001D.\u001D(this), \u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())))));
							}
						}
					}
					catch (Exception u000A)
					{
						\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "IsRelativePath");
					}
				}
				this._isRelativePath = value;
				\u0007\u0013\u000A.\u000A(this, "IsRelativePath");
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x0004360C File Offset: 0x0004180C
		[XmlIgnore]
		public bool IsFileNotFound
		{
			get
			{
				return !\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this));
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000A41 RID: 2625 RVA: 0x0004362C File Offset: 0x0004182C
		[XmlIgnore]
		public string DisplayPath
		{
			get
			{
				if (!\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this)))
				{
					return \u0014\u0008\u0004.\u000A();
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_DisplayPath()).MethodHandle;
				}
				if (!\u0013\u0008\u0004.\u0007(this))
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
					return \u0011\u0020\u001D.\u001D(this);
				}
				return \u0017\u0008\u0004.\u0007(this);
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000A42 RID: 2626 RVA: 0x0004368C File Offset: 0x0004188C
		// (set) Token: 0x06000A43 RID: 2627 RVA: 0x000436A0 File Offset: 0x000418A0
		public string DataSourceDefinitionId { get; set; }

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x06000A44 RID: 2628 RVA: 0x000436B4 File Offset: 0x000418B4
		// (set) Token: 0x06000A45 RID: 2629 RVA: 0x000436C8 File Offset: 0x000418C8
		public EnumInfo SourceType { get; set; } = \u000B\u0008\u0004.\u000A(SourceTypes.Excel);

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x06000A46 RID: 2630 RVA: 0x000436DC File Offset: 0x000418DC
		public List<EnumInfo> ImportTypesList
		{
			get
			{
				return SelectedExcel.ZR;
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x000436F0 File Offset: 0x000418F0
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x00043704 File Offset: 0x00041904
		public EnumInfo ImportType
		{
			get
			{
				return this._importType;
			}
			set
			{
				if (base.SetProperty<EnumInfo>(ref this._importType, value, null, "ImportType"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_ImportType(EnumInfo)).MethodHandle;
					}
					if (\u000C\u0008\u0004.\u000A(this._importType, ImportTypes.Image))
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
						\u001A\u0008\u0004.\u000A(\u000A\u000B\u0004.\u001D(this), false);
					}
					\u0012\u0008\u0004.\u0007(this);
				}
				this.DX();
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x06000A49 RID: 2633 RVA: 0x00043774 File Offset: 0x00041974
		public List<int> DpiValues
		{
			get
			{
				return \u0011\u0019.\u0019;
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x06000A4A RID: 2634 RVA: 0x00043788 File Offset: 0x00041988
		// (set) Token: 0x06000A4B RID: 2635 RVA: 0x0004379C File Offset: 0x0004199C
		public int SelectedDpi
		{
			get
			{
				return this._selectedDpi;
			}
			set
			{
				if (base.SetProperty<int>(ref this._selectedDpi, value, null, "SelectedDpi"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_SelectedDpi(int)).MethodHandle;
					}
					\u0012\u0008\u0004.\u0007(this);
				}
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000A4C RID: 2636 RVA: 0x000437DC File Offset: 0x000419DC
		// (set) Token: 0x06000A4D RID: 2637 RVA: 0x000437F0 File Offset: 0x000419F0
		public bool AutoSync
		{
			get
			{
				return this._autoSync;
			}
			set
			{
				bool autoSync = this._autoSync;
				this._autoSync = value;
				\u0007\u0013\u000A.\u000A(this, "AutoSync");
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000A4E RID: 2638 RVA: 0x00043818 File Offset: 0x00041A18
		// (set) Token: 0x06000A4F RID: 2639 RVA: 0x0004382C File Offset: 0x00041A2C
		public bool AutoSyncInitial { get; set; }

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000A50 RID: 2640 RVA: 0x00043840 File Offset: 0x00041A40
		// (set) Token: 0x06000A51 RID: 2641 RVA: 0x00043854 File Offset: 0x00041A54
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

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000A52 RID: 2642 RVA: 0x00043874 File Offset: 0x00041A74
		// (set) Token: 0x06000A53 RID: 2643 RVA: 0x00043888 File Offset: 0x00041A88
		public long ViewElementId { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000A54 RID: 2644 RVA: 0x0004389C File Offset: 0x00041A9C
		// (set) Token: 0x06000A55 RID: 2645 RVA: 0x000438B0 File Offset: 0x00041AB0
		public string UniqueId { get; set; }

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000A56 RID: 2646 RVA: 0x000438C4 File Offset: 0x00041AC4
		// (set) Token: 0x06000A57 RID: 2647 RVA: 0x000438D8 File Offset: 0x00041AD8
		public string SheetName
		{
			get
			{
				return this._sheetName;
			}
			set
			{
				string sheetName;
				if (value == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_SheetName(string)).MethodHandle;
					}
					sheetName = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					sheetName = \u0003\u000B\u001D.\u001D(value);
				}
				this._sheetName = sheetName;
				\u0007\u0013\u000A.\u000A(this, "SheetName");
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000A58 RID: 2648 RVA: 0x0004391C File Offset: 0x00041B1C
		// (set) Token: 0x06000A59 RID: 2649 RVA: 0x00043930 File Offset: 0x00041B30
		public string SheetNameInitial { get; set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000A5A RID: 2650 RVA: 0x00043944 File Offset: 0x00041B44
		// (set) Token: 0x06000A5B RID: 2651 RVA: 0x00043958 File Offset: 0x00041B58
		public string Modified
		{
			get
			{
				return this._modified;
			}
			set
			{
				string modified;
				try
				{
					DateTime dateTime = \u0015\u0008\u0004.\u000A(value, \u001F\u0015\u000A.\u000A());
					modified = \u0020\u0016\u0004.\u000A(ref dateTime, "MM/dd/yyyy HH:mm:ss");
				}
				catch (Exception)
				{
					modified = value;
				}
				this._modified = modified;
				\u0007\u0013\u000A.\u000A(this, "Modified");
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x000439B0 File Offset: 0x00041BB0
		public List<EnumInfo> PageOptions
		{
			get
			{
				return \u0011\u0019.\u0018;
			}
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x000439C4 File Offset: 0x00041BC4
		// (set) Token: 0x06000A5E RID: 2654 RVA: 0x000439D8 File Offset: 0x00041BD8
		public EnumInfo PageOption
		{
			get
			{
				return this._pageOption;
			}
			set
			{
				if (base.SetProperty<EnumInfo>(ref this._pageOption, value, null, "PageOption"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_PageOption(EnumInfo)).MethodHandle;
					}
					\u0012\u0008\u0004.\u0007(this);
				}
				if (\u000C\u0008\u0004.\u000A(this._pageOption, DiRoots.One.TGDatabaseLayer.PageOptions.All))
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
					this._selectedPages = "";
					\u0007\u0013\u000A.\u000A(this, "SelectedPages");
				}
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000A5F RID: 2655 RVA: 0x00043A4C File Offset: 0x00041C4C
		// (set) Token: 0x06000A60 RID: 2656 RVA: 0x00043A60 File Offset: 0x00041C60
		public string SelectedPages
		{
			get
			{
				return this._selectedPages;
			}
			set
			{
				if (base.SetProperty<string>(ref this._selectedPages, value, null, "SelectedPages"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_SelectedPages(string)).MethodHandle;
					}
					\u0012\u0008\u0004.\u0007(this);
					\u0001\u0008\u0004.\u000A(this);
				}
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000A61 RID: 2657 RVA: 0x00043AA4 File Offset: 0x00041CA4
		// (set) Token: 0x06000A62 RID: 2658 RVA: 0x00043AB8 File Offset: 0x00041CB8
		public string WorkSheetInitial { get; set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000A63 RID: 2659 RVA: 0x00043ACC File Offset: 0x00041CCC
		// (set) Token: 0x06000A64 RID: 2660 RVA: 0x00043AE0 File Offset: 0x00041CE0
		public List<NamedRangeInfo> WorkSheetRegions
		{
			get
			{
				return this._workSheetRegions;
			}
			set
			{
				this._workSheetRegions = value;
				\u0007\u0013\u000A.\u000A(this, "WorkSheetRegions");
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000A65 RID: 2661 RVA: 0x00043B00 File Offset: 0x00041D00
		// (set) Token: 0x06000A66 RID: 2662 RVA: 0x00043B14 File Offset: 0x00041D14
		public NamedRangeInfo WorkSheetRegionInitial { get; set; } = new NamedRangeInfo();

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000A67 RID: 2663 RVA: 0x00043B28 File Offset: 0x00041D28
		// (set) Token: 0x06000A68 RID: 2664 RVA: 0x00043B3C File Offset: 0x00041D3C
		public NamedRangeInfo WorkSheetRegion
		{
			get
			{
				return this._workSheetRegion;
			}
			set
			{
				bool flag;
				if (value != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_WorkSheetRegion(NamedRangeInfo)).MethodHandle;
					}
					flag = \u001D\u0017\u000A.\u000A(\u001B\u0012\u0004.\u001D(value), \u001B\u0012\u0004.\u001D(this._workSheetRegion));
				}
				else
				{
					flag = false;
				}
				if (value != null)
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
					this._workSheetRegion = value;
				}
				if (flag)
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
					\u0012\u0008\u0004.\u0007(this);
				}
				\u0007\u0013\u000A.\u000A(this, "WorkSheetRegion");
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00043BB0 File Offset: 0x00041DB0
		// (set) Token: 0x06000A6A RID: 2666 RVA: 0x00043BC4 File Offset: 0x00041DC4
		public List<string> WorkSheets { get; set; } = new List<string>();

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00043BD8 File Offset: 0x00041DD8
		// (set) Token: 0x06000A6C RID: 2668 RVA: 0x00043BEC File Offset: 0x00041DEC
		public string WorkSheet
		{
			get
			{
				return this._workSheet;
			}
			set
			{
				bool flag = \u001D\u0017\u000A.\u000A(value, this._workSheet);
				this._workSheet = value;
				if (flag)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_WorkSheet(string)).MethodHandle;
					}
					try
					{
						List<SheetAndNamedRange> u001F = Enumerable.ToList<SheetAndNamedRange>(Enumerable.Where<SheetAndNamedRange>(\u0018\u001B\u0004.\u0007(this), new Func<SheetAndNamedRange, bool>(this.YX)));
						if (\u0019\u001B\u0004.\u000A(u001F) > 0)
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
							\u0007\u001B\u0004.\u0007(this, Enumerable.ToList<NamedRangeInfo>(\u001D\u001B\u0004.\u000A(\u0004\u001B\u0004.\u000A(u001F, 0))));
						}
						if (\u000A\u001E\u001D.\u000A(\u000A\u001B\u0004.\u0007(this)) > 0)
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
							NamedRangeInfo namedRangeInfo = \u0010\u0019\u000E.\u001F;
							if (\u0014\u0020\u001D.\u001D(this) != null)
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
								namedRangeInfo = Enumerable.FirstOrDefault<NamedRangeInfo>(\u000A\u001B\u0004.\u0007(this), new Func<NamedRangeInfo, bool>(this.CX));
							}
							if (namedRangeInfo != null)
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
								if (\u0013\u0020\u001D.\u0007(namedRangeInfo) != RangeTypes.UsedRange)
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
									\u001F\u001B\u0004.\u0007(this, namedRangeInfo);
									goto IL_117;
								}
							}
							\u001F\u001B\u0004.\u0007(this, NamedRangeInfo.\u000A(\u000A\u001B\u0004.\u0007(this)));
						}
						IL_117:
						\u0012\u0008\u0004.\u0007(this);
					}
					catch (Exception)
					{
						\u0009\u0008\u0004.\u000A(true);
					}
				}
				\u0007\u0013\u000A.\u000A(this, "WorkSheet");
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x00043D3C File Offset: 0x00041F3C
		// (set) Token: 0x06000A6E RID: 2670 RVA: 0x00043D50 File Offset: 0x00041F50
		public string ExcelFileRelative { get; set; }

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000A6F RID: 2671 RVA: 0x00043D64 File Offset: 0x00041F64
		// (set) Token: 0x06000A70 RID: 2672 RVA: 0x00043E8C File Offset: 0x0004208C
		public string ExcelFile
		{
			get
			{
				string text = this._excelFile;
				if (!\u0010\u0002\u001D.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_ExcelFile()).MethodHandle;
					}
					if (\u0017\u0008\u0004.\u0007(this) != null)
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
						try
						{
							if (\u000F\u0005.\u0006(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()))))
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
								\u000F\u0005 u000F_u = \u000F\u0005.\u000B(text, \u000F\u0005.\u000F(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())), true), \u0016\u001B\u0004.\u0007(this));
								if (u000F_u != null)
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
									text = \u0005\u001B\u0004.\u0007(u000F_u);
								}
							}
							else
							{
								string text2 = \u001B\u0015\u001D.\u000A(\u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()))), \u0017\u0008\u0004.\u0007(this));
								if (\u0010\u0002\u001D.\u000A(text2))
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
									text = text2;
								}
							}
						}
						catch (Exception u000A)
						{
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "ExcelFile");
						}
					}
				}
				return text;
			}
			set
			{
				bool flag = \u001D\u0017\u000A.\u000A(value, this._excelFile);
				this._excelFile = value;
				if (flag)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_ExcelFile(string)).MethodHandle;
					}
					if (\u000F\u0005.\u0006(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()))))
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
						string u = \u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())));
						\u0020\u0008\u0004.\u0007(this, \u0011\u0020\u001D.\u001D(this), u);
					}
					\u0012\u0008\u0004.\u0007(this);
				}
				\u0007\u0013\u000A.\u000A(this, "ExcelFile");
				\u0007\u0013\u000A.\u000A(this, "IsFileNotFound");
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000A71 RID: 2673 RVA: 0x00043F38 File Offset: 0x00042138
		[XmlIgnore]
		public string ModifiedForExcel
		{
			get
			{
				string result = "";
				try
				{
					if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_ModifiedForExcel()).MethodHandle;
						}
						DateTime dateTime = \u000B\u001B\u0004.\u000A(\u0011\u0020\u001D.\u001D(this));
						result = \u0020\u0016\u0004.\u000A(ref dateTime, "MM/dd/yyyy HH:mm:ss");
					}
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "ModifiedForExcel");
				}
				return result;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000A72 RID: 2674 RVA: 0x00043FBC File Offset: 0x000421BC
		[XmlIgnore]
		public bool IsUpToDate
		{
			get
			{
				bool result = true;
				try
				{
					string u001F = \u000F\u001B\u0004.\u0007(this);
					string u001F2 = "";
					if (\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_IsUpToDate()).MethodHandle;
						}
						DateTime dateTime = \u000B\u001B\u0004.\u000A(\u0011\u0020\u001D.\u001D(this));
						u001F2 = \u0020\u0016\u0004.\u000A(ref dateTime, "MM/dd/yyyy HH:mm:ss");
					}
					if (!\u001A\u0006\u0007.\u000A(u001F))
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
						if (!\u001A\u0006\u0007.\u000A(u001F2))
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
							DateTime u000A = \u0006\u001B\u0004.\u000A(u001F, "MM/dd/yyyy HH:mm:ss", \u0001\u0019\u000E.\u001F);
							if (\u0002\u001B\u0004.\u000A(\u0006\u001B\u0004.\u000A(u001F2, "MM/dd/yyyy HH:mm:ss", \u0001\u0019\u000E.\u001F), u000A))
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
								result = false;
							}
						}
					}
				}
				catch (Exception u000A2)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "IsUpToDate");
				}
				return result;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000A73 RID: 2675 RVA: 0x000440B4 File Offset: 0x000422B4
		// (set) Token: 0x06000A74 RID: 2676 RVA: 0x000440C8 File Offset: 0x000422C8
		public EnumInfo ViewType
		{
			get
			{
				return this._viewType;
			}
			set
			{
				EnumInfo viewType = this._viewType;
				bool flag;
				if (viewType == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.set_ViewType(EnumInfo)).MethodHandle;
					}
					flag = false;
				}
				else
				{
					flag = \u0010\u001B\u0004.\u000A(viewType, value);
				}
				if (flag)
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
					return;
				}
				bool flag2 = true;
				if (this._viewType != null)
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
					flag2 = \u000D\u001B\u0004.\u0007(this, value, true);
				}
				if (flag2)
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
					this._viewType = value;
					\u0007\u0013\u000A.\u000A(this, "ViewType");
					SelectedExcel.ViewTypeUnallowedHandler xr = SelectedExcel.XR;
					if (xr == null)
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
					}
					else
					{
						\u0003\u001B\u0004.\u000A(xr, false);
					}
				}
				else
				{
					SelectedExcel.ViewTypeUnallowedHandler xr2 = SelectedExcel.XR;
					if (xr2 == null)
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
					}
					else
					{
						IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
						Func<SelectedExcel, bool> func;
						if ((func = SelectedExcel.<>c.\u001D) == null)
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
							func = (SelectedExcel.<>c.\u001D = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u001C));
						}
						\u0003\u001B\u0004.\u000A(xr2, Enumerable.Count<SelectedExcel>(enumerable, func) == 1);
					}
				}
				if (\u000D\u001B\u001D.\u0007(this._viewType) == 5)
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
					\u0012\u001B\u0004.\u0007(this, 1);
				}
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000A75 RID: 2677 RVA: 0x000441DC File Offset: 0x000423DC
		[XmlIgnore]
		public List<EnumInfo> ViewTypes
		{
			get
			{
				return this._viewTypes;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x06000A76 RID: 2678 RVA: 0x000441F0 File Offset: 0x000423F0
		[XmlIgnore]
		public bool IsViewTypeEnabled
		{
			get
			{
				if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.ToAdd)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.get_IsViewTypeEnabled()).MethodHandle;
					}
					if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.ToDuplicate)
					{
						return false;
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
				return true;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x06000A77 RID: 2679 RVA: 0x00044234 File Offset: 0x00042434
		// (set) Token: 0x06000A78 RID: 2680 RVA: 0x00044248 File Offset: 0x00042448
		[Obsolete("OldSelectedExcel is deprecated, please use OldSelectedExcelName instead.")]
		public SelectedExcel OldSelectedExcel { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x0004425C File Offset: 0x0004245C
		// (set) Token: 0x06000A7A RID: 2682 RVA: 0x00044270 File Offset: 0x00042470
		public string OldSelectedExcelSheetName { get; set; }

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x00044284 File Offset: 0x00042484
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x00044298 File Offset: 0x00042498
		public SelectedExcel OriginalInfo { get; set; }

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x06000A7D RID: 2685 RVA: 0x000442AC File Offset: 0x000424AC
		// (set) Token: 0x06000A7E RID: 2686 RVA: 0x000442C0 File Offset: 0x000424C0
		public FormatOptions FormatOptions { get; set; } = new FormatOptions();

		// Token: 0x06000A7F RID: 2687 RVA: 0x000442D4 File Offset: 0x000424D4
		public bool RefreshRegions()
		{
			try
			{
				if (!\u0010\u0002\u001D.\u000A(\u0011\u0020\u001D.\u001D(this)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.RefreshRegions()).MethodHandle;
					}
					return false;
				}
				if (\u0020\u001B\u0004.\u0007(this))
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
					if (\u0019\u0010\u0004.\u001D(this) == ActionTypes.None)
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
						return true;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
			try
			{
				if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u001D(this)) != 0)
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
					return true;
				}
				string u000A = \u0020\u0020\u001D.\u001D(this);
				Dictionary<string, List<NamedRangeInfo>> dictionary = \u0013\u0019.\u001F(\u0011\u0020\u001D.\u001D(this));
				if (dictionary == null)
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
					return true;
				}
				IEnumerable<KeyValuePair<string, List<NamedRangeInfo>>> enumerable = dictionary;
				Func<KeyValuePair<string, List<NamedRangeInfo>>, SheetAndNamedRange> func;
				if ((func = SelectedExcel.<>c.\u0004) == null)
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
					func = (SelectedExcel.<>c.\u0004 = new Func<KeyValuePair<string, List<NamedRangeInfo>>, SheetAndNamedRange>(SelectedExcel.<>c.\u001F.\u000D));
				}
				\u001E\u001B\u0004.\u0007(this, Enumerable.ToList<SheetAndNamedRange>(Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, SheetAndNamedRange>(enumerable, func)));
				List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(\u0011\u001B\u0004.\u0007(this));
				try
				{
					while (\u0017\u0008\u0007.\u000A(ref enumerator))
					{
						string text = \u0014\u0008\u0007.\u000A(ref enumerator);
						if (\u0008\u0013\u000A.\u000A(text, u000A))
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
							\u001B\u001B\u0004.\u0007(this, text);
							goto IL_156;
						}
					}
					for (;;)
					{
						switch (2)
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
				IL_156:
				if (\u0020\u0020\u001D.\u001D(this) == null)
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
					\u001B\u001B\u0004.\u0007(this, \u0001\u0013\u0007.\u000A(\u0011\u001B\u0004.\u0007(this), 0));
				}
				List<SheetAndNamedRange> u001F = Enumerable.ToList<SheetAndNamedRange>(Enumerable.Where<SheetAndNamedRange>(\u0018\u001B\u0004.\u0007(this), new Func<SheetAndNamedRange, bool>(this.LX)));
				if (\u0019\u001B\u0004.\u000A(u001F) > 0)
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
					\u0007\u001B\u0004.\u0007(this, Enumerable.ToList<NamedRangeInfo>(\u001D\u001B\u0004.\u000A(\u0004\u001B\u0004.\u000A(u001F, 0))));
					NamedRangeInfo namedRangeInfo = \u0008\u001B\u0004.\u0007(this);
					NamedRangeInfo u000A2;
					if (namedRangeInfo == null)
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
						u000A2 = \u0010\u0019\u000E.\u001F;
					}
					else
					{
						u000A2 = \u000E\u001B\u0004.\u001D(namedRangeInfo, \u000A\u001B\u0004.\u0007(this));
					}
					\u0008\u0016\u0004.\u001D(this, u000A2);
					\u001F\u001B\u0004.\u0007(this, \u000E\u001B\u0004.\u0007(\u0014\u0020\u001D.\u001D(this), \u000A\u001B\u0004.\u0007(this)));
				}
				else
				{
					\u0007\u001B\u0004.\u0007(this, \u0005\u001E\u001D.\u000A());
				}
			}
			catch (Exception u000A3)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "RefreshRegions");
			}
			return true;
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x00044588 File Offset: 0x00042788
		public void SetUpdateState()
		{
			if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.ToAdd)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.SetUpdateState()).MethodHandle;
				}
				if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.ToDuplicate)
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
					if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.Recreate)
					{
						UpdateStates u000A;
						if (!\u0017\u001B\u0004.\u0007(this))
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
							u000A = UpdateStates.Updated;
						}
						else
						{
							u000A = UpdateStates.Modified;
						}
						\u000D\u0016\u0004.\u001D(this, u000A);
						return;
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
			}
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x000445FC File Offset: 0x000427FC
		public string GetRelativePath(string fileSpec, string folder)
		{
			try
			{
				folder = \u001C\u000B\u001D.\u0007(folder, "/", "\\");
				object u001F = folder;
				char directorySeparatorChar = Path.DirectorySeparatorChar;
				if (!\u0001\u0016\u001D.\u000A(u001F, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.GetRelativePath(string, string)).MethodHandle;
					}
					string u001F2 = folder;
					directorySeparatorChar = Path.DirectorySeparatorChar;
					folder = \u0004\u001E\u000A.\u000A(u001F2, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar));
				}
				Uri u000A = \u0011\u000E\u0004.\u000A(fileSpec);
				object u001F3 = folder;
				directorySeparatorChar = Path.DirectorySeparatorChar;
				if (!\u0001\u0016\u001D.\u000A(u001F3, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar)))
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
					string u001F4 = folder;
					directorySeparatorChar = Path.DirectorySeparatorChar;
					folder = \u0004\u001E\u000A.\u000A(u001F4, \u001E\u000E\u0004.\u000A(ref directorySeparatorChar));
				}
				if (!\u000F\u0005.\u0006(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()))))
				{
					return \u0008\u000E\u0004.\u000A(\u000C\u0003\u0004.\u000A(\u001A\u000C\u000A.\u000A(\u001B\u000E\u0004.\u000A(\u0011\u000E\u0004.\u000A(folder), u000A)), '/', Path.DirectorySeparatorChar));
				}
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				\u000F\u0005 u000F_u = \u000F\u0005.\u000B(fileSpec, \u000F\u0005.\u000F(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())), true), \u000F\u0015\u0010.\u001F);
				if (u000F_u != null)
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
					\u0014\u001B\u0004.\u0007(this, \u0013\u001B\u0004.\u000A(u000F_u));
					return \u0005\u001B\u0004.\u0007(u000F_u);
				}
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\SelectedExcel.cs", "GetRelativePath");
			}
			return "";
		}

		// Token: 0x06000A82 RID: 2690 RVA: 0x00044798 File Offset: 0x00042998
		[BindableMethod("OnWorkSheetChanged")]
		public void OnWorkSheetChanged()
		{
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = SelectedExcel.<>c.\u0019) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnWorkSheetChanged()).MethodHandle;
				}
				func = (SelectedExcel.<>c.\u0019 = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u0010));
			}
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(Enumerable.Where<SelectedExcel>(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func)), new Func<SelectedExcel, bool>(this.SX)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel u001F = \u0011\u000F\u0004.\u000A(enumerator);
					string text = Enumerable.FirstOrDefault<string>(\u0011\u001B\u0004.\u001D(u001F), new Func<string, bool>(this.BX));
					if (text != null)
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
						\u001B\u001B\u0004.\u001D(u001F, text);
					}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000A83 RID: 2691 RVA: 0x0004487C File Offset: 0x00042A7C
		[BindableMethod("OnViewTypeChanged")]
		public void OnViewTypeChanged()
		{
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(\u001C\u001B\u0004.\u000A(), new Func<SelectedExcel, bool>(this.UX))));
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					\u001A\u001B\u0004.\u000A(\u001F\u0016\u0004.\u000A(ref enumerator), (long)\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u001D(this)));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnViewTypeChanged()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00044910 File Offset: 0x00042B10
		public bool IsValidViewType(EnumInfo viewType, bool isInternal = true)
		{
			bool result = true;
			List<SelectedExcel> u001F = \u0003\u000B\u0004.\u000A();
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(\u001C\u001B\u0004.\u000A());
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					SelectedExcel selectedExcel = \u001F\u0016\u0004.\u000A(ref enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0014\u0005\u0004.\u0007(selectedExcel), \u0014\u0005\u0004.\u001D(this)))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.IsValidViewType(EnumInfo, bool)).MethodHandle;
						}
						if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(selectedExcel)) == \u000D\u001B\u001D.\u0007(viewType))
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
							\u001A\u0016\u0004.\u000A(u001F, selectedExcel);
						}
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
			if (isInternal)
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
				if (\u000C\u001B\u0004.\u000A(u001F) > 0)
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
					result = false;
				}
			}
			else if (\u000C\u001B\u0004.\u000A(u001F) > 1)
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
				result = false;
			}
			if (isInternal)
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
				if (\u0015\u0018.\u000A(\u000D\u001B\u001D.\u0007(viewType), \u0014\u0005\u0004.\u001D(this)))
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
					result = false;
				}
			}
			return result;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00044A40 File Offset: 0x00042C40
		[BindableMethod("OnRegionChanged")]
		public void OnRegionChanged()
		{
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = SelectedExcel.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnRegionChanged()).MethodHandle;
				}
				func = (SelectedExcel.<>c.\u0018 = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u000E));
			}
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(Enumerable.Where<SelectedExcel>(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func)), new Func<SelectedExcel, bool>(this.WX)));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel u001F = \u0011\u000F\u0004.\u000A(enumerator);
					NamedRangeInfo namedRangeInfo = Enumerable.FirstOrDefault<NamedRangeInfo>(\u000A\u001B\u0004.\u001D(u001F), new Func<NamedRangeInfo, bool>(this.KX));
					if (namedRangeInfo != null)
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
						\u001F\u001B\u0004.\u001D(u001F, namedRangeInfo);
					}
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
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000A86 RID: 2694 RVA: 0x00044B24 File Offset: 0x00042D24
		[BindableMethod("OnAutoSyncClicked")]
		public void OnAutoSyncClicked(bool checkStatus)
		{
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = SelectedExcel.<>c.\u0005) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnAutoSyncClicked(bool)).MethodHandle;
				}
				func = (SelectedExcel.<>c.\u0005 = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u0008));
			}
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func)));
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					\u0001\u001B\u0004.\u000A(\u001F\u0016\u0004.\u000A(ref enumerator), checkStatus);
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
				((IDisposable)enumerator).Dispose();
			}
			SelectedExcel.AutoSyncChangedHandler pr = SelectedExcel.PR;
			if (pr == null)
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
				return;
			}
			\u0015\u001B\u0004.\u000A(pr, true);
		}

		// Token: 0x06000A87 RID: 2695 RVA: 0x00044BE0 File Offset: 0x00042DE0
		[BindableMethod("OnImporTypeChanged")]
		public void OnImporTypeChanged()
		{
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = SelectedExcel.<>c.\u0016) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnImporTypeChanged()).MethodHandle;
				}
				func = (SelectedExcel.<>c.\u0016 = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u001B));
			}
			List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(Enumerable.ToList<SelectedExcel>(Enumerable.Where<SelectedExcel>(enumerable, func)));
			try
			{
				while (\u0001\u0005\u0004.\u000A(ref enumerator))
				{
					\u0009\u001B\u0004.\u000A(\u001F\u0016\u0004.\u000A(ref enumerator), \u0015\u0016\u0004.\u001D(this));
				}
				for (;;)
				{
					switch (2)
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

		// Token: 0x06000A88 RID: 2696 RVA: 0x00044C8C File Offset: 0x00042E8C
		[BindableMethod("OnDpiChanged")]
		public void OnDpiChanged()
		{
			Func<SelectedExcel, bool> f;
			if ((f = SelectedExcel.<>c.\u000B) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnDpiChanged()).MethodHandle;
				}
				f = (SelectedExcel.<>c.\u000B = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u0011));
			}
			this.QZ(f, new Action<SelectedExcel>(this.JX));
		}

		// Token: 0x06000A89 RID: 2697 RVA: 0x00044CE0 File Offset: 0x00042EE0
		[BindableMethod("OnPageOptionChanged")]
		public void OnPageOptionChanged()
		{
			Func<SelectedExcel, bool> f;
			if ((f = SelectedExcel.<>c.\u0002) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnPageOptionChanged()).MethodHandle;
				}
				f = (SelectedExcel.<>c.\u0002 = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u001E));
			}
			this.QZ(f, new Action<SelectedExcel>(this.EX));
		}

		// Token: 0x06000A8A RID: 2698 RVA: 0x00044D34 File Offset: 0x00042F34
		public void OnViewScaleChanged()
		{
			Func<SelectedExcel, bool> f;
			if ((f = SelectedExcel.<>c.\u0006) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnViewScaleChanged()).MethodHandle;
				}
				f = (SelectedExcel.<>c.\u0006 = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u0020));
			}
			this.QZ(f, new Action<SelectedExcel>(this.NX));
		}

		// Token: 0x06000A8B RID: 2699 RVA: 0x00044D88 File Offset: 0x00042F88
		public void OnSelectedPagesChanged()
		{
			Func<SelectedExcel, bool> f;
			if ((f = SelectedExcel.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnSelectedPagesChanged()).MethodHandle;
				}
				f = (SelectedExcel.<>c.\u000F = new Func<SelectedExcel, bool>(SelectedExcel.<>c.\u001F.\u0017));
			}
			this.QZ(f, new Action<SelectedExcel>(this.MX));
		}

		// Token: 0x06000A8C RID: 2700 RVA: 0x00044DDC File Offset: 0x00042FDC
		private void QZ(Func<SelectedExcel, bool> F, Action<SelectedExcel> R)
		{
			SelectedExcel.\u001E\u0005 u001E_u = new SelectedExcel.\u001E\u0005();
			u001E_u.\u001F = F;
			IEnumerable<SelectedExcel> enumerable = \u001C\u001B\u0004.\u000A();
			Func<SelectedExcel, bool> func;
			if ((func = u001E_u.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.QZ(Func<SelectedExcel, bool>, Action<SelectedExcel>)).MethodHandle;
				}
				func = (u001E_u.\u000A = new Func<SelectedExcel, bool>(u001E_u.\u0007));
			}
			IEnumerator<SelectedExcel> enumerator = \u001E\u000F\u0004.\u000A(Enumerable.Where<SelectedExcel>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					SelectedExcel u000A = \u0011\u000F\u0004.\u000A(enumerator);
					\u001F\u0011\u0004.\u000A(R, u000A);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000A8D RID: 2701 RVA: 0x00044E8C File Offset: 0x0004308C
		private void AZ(int F)
		{
			if (base.SetProperty<int>(ref this._viewScale, F, null, "ViewScale"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.AZ(int)).MethodHandle;
				}
				\u0012\u0008\u0004.\u0007(this);
			}
		}

		// Token: 0x06000A8E RID: 2702 RVA: 0x00044ECC File Offset: 0x000430CC
		private void GZ(string F)
		{
			if (base.SetProperty<string>(ref this._selectedPages, F, null, "SelectedPages"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.GZ(string)).MethodHandle;
				}
				\u0012\u0008\u0004.\u0007(this);
			}
		}

		// Token: 0x06000A8F RID: 2703 RVA: 0x00044F0C File Offset: 0x0004310C
		public void RefreshDisplayPath()
		{
			\u0007\u0013\u000A.\u000A(this, "DisplayPath");
			\u0007\u0013\u000A.\u000A(this, "IsFileNotFound");
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x00044F30 File Offset: 0x00043130
		internal void FX(EnumInfo F)
		{
			this._viewType = F;
			\u0007\u0013\u000A.\u000A(this, "ViewType");
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x00044F50 File Offset: 0x00043150
		[Obsolete("Use IsModified instead ")]
		public bool IsEdited()
		{
			return \u0017\u001B\u0004.\u0007(this);
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x00044F68 File Offset: 0x00043168
		public bool IsModified()
		{
			if (!\u001D\u0017\u000A.\u000A(\u0012\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)), \u0014\u0005\u0004.\u001D(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.IsModified()).MethodHandle;
				}
				if (!\u001D\u0017\u000A.\u000A(\u000F\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)), \u0011\u0020\u001D.\u001D(this)))
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
					if (\u0006\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)) == \u000D\u001B\u001D.\u0007(\u0015\u0016\u0004.\u001D(this)))
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
						if (\u0002\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)) != \u0019\u0020\u001D.\u001D(this))
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
						}
						else
						{
							if (!\u000C\u0008\u0004.\u000A(\u0002\u0003\u0004.\u001D(this), SourceTypes.Excel))
							{
								if (\u0005\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)) == \u0018\u0011\u0004.\u0007(this))
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
									int num = \u0019\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this));
									EnumInfo enumInfo = \u0004\u0011\u0004.\u0007(this);
									int? num3;
									if (enumInfo == null)
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
										int? num2;
										\u000B\u0007\u000E.\u001F(ref num2);
										num3 = num2;
									}
									else
									{
										num3 = new int?(\u000D\u001B\u001D.\u001D(enumInfo));
									}
									int? num4 = num3;
									if (num == \u0009\u001F\u001D.\u000A(ref num4) & \u000A\u000A\u001D.\u000A(ref num4))
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
										return \u001D\u0017\u000A.\u000A(\u0007\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)), \u000A\u0011\u0004.\u0007(this));
									}
								}
								return true;
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
							if (\u000C\u0008\u0004.\u000A(\u0015\u0016\u0004.\u001D(this), ImportTypes.Image))
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
								if (\u0005\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)) != \u0018\u0011\u0004.\u0007(this))
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
									return true;
								}
							}
							else if (\u000B\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this)) != \u001F\u000B\u0004.\u0007(\u000A\u000B\u0004.\u001D(this)))
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
								return true;
							}
							if (!\u001D\u0017\u000A.\u000A(\u0016\u0011\u0004.\u0007(this), \u0020\u0020\u001D.\u001D(this)))
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
								NamedRangeInfo namedRangeInfo = \u0008\u001B\u0004.\u0007(this);
								string u001F;
								if (namedRangeInfo == null)
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
									u001F = null;
								}
								else
								{
									u001F = \u001B\u0012\u0004.\u0007(namedRangeInfo);
								}
								NamedRangeInfo namedRangeInfo2 = \u0014\u0020\u001D.\u001D(this);
								string u000A;
								if (namedRangeInfo2 == null)
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
									u000A = \u000F\u0015\u0010.\u001F;
								}
								else
								{
									u000A = \u001B\u0012\u0004.\u0007(namedRangeInfo2);
								}
								return \u001D\u0017\u000A.\u000A(u001F, u000A);
							}
							return true;
						}
					}
				}
			}
			return true;
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x000451D0 File Offset: 0x000433D0
		public SelectedExcel Clone()
		{
			return XMLUtility.CloneBySerialise<SelectedExcel>(this, false);
		}

		// Token: 0x06000A94 RID: 2708 RVA: 0x000451E8 File Offset: 0x000433E8
		internal void RX()
		{
			\u001B\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u000D\u001B\u001D.\u0007(\u0015\u0016\u0004.\u001D(this)));
			\u0008\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u0018\u0011\u0004.\u0007(this));
			\u000E\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u000D\u001B\u001D.\u0007(\u0004\u0011\u0004.\u0007(this)));
			\u0010\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u000A\u0011\u0004.\u0007(this));
			\u000D\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u0019\u0020\u001D.\u001D(this));
			\u001C\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u0011\u0020\u001D.\u001D(this));
			\u0003\u0011\u0004.\u000A(\u001D\u0011\u0004.\u0007(this), \u001F\u000B\u0004.\u0007(\u000A\u000B\u0004.\u001D(this)));
		}

		// Token: 0x06000A95 RID: 2709 RVA: 0x000452A0 File Offset: 0x000434A0
		[BindableMethod("OnSelectedPagesPreviewText")]
		public void OnSelectedPagesPreviewText(TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[\\d,\\s-]");
			\u0019\u0013\u000A.\u000A(e, !\u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x06000A96 RID: 2710 RVA: 0x000452D4 File Offset: 0x000434D4
		private void DX()
		{
			SelectedExcel.\u0020\u0005 u0020_u = new SelectedExcel.\u0020\u0005();
			u0020_u.\u001F = \u0006\u0020\u001D.\u001D(this);
			if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.ToAdd)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.DX()).MethodHandle;
				}
				if (\u0001\u0016\u0004.\u001D(this) != UpdateStates.ToDuplicate)
				{
					goto IL_54;
				}
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			this._viewTypes = \u001D\u0016.\u001D();
			IL_54:
			if (\u000C\u0008\u0004.\u000A(\u0015\u0016\u0004.\u001D(this), ImportTypes.Image))
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
				if (\u001E\u0011\u0004.\u000A(\u0020\u0011\u0004.\u0007(this)) == 3)
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
					\u0011\u0011\u0004.\u000A(this._viewTypes, 1);
				}
			}
			if (u0020_u.\u001F != null)
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
				if (Enumerable.Any<EnumInfo>(this._viewTypes, new Func<EnumInfo, bool>(u0020_u.\u000A)))
				{
					goto IL_E8;
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
			\u0005\u0008\u0004.\u0007(this, \u0016\u0008\u0004.\u000A(this._viewTypes, 0));
			IL_E8:
			\u0007\u0013\u000A.\u000A(this, "ViewTypes");
		}

		// Token: 0x06000A97 RID: 2711 RVA: 0x000453D4 File Offset: 0x000435D4
		[BindableMethod("OnBrowseLocation")]
		public void OnBrowseLocation()
		{
			try
			{
				string text = \u0019\u000E\u0004.\u000A(\u0011\u0020\u001D.\u001D(this));
				if (!\u000C\u0010\u0004.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.OnBrowseLocation()).MethodHandle;
					}
					text = "";
				}
				string text2 = FilePathHelper.\u001F(\u0002\u0003\u0004.\u001D(this), text);
				if (\u001A\u0006\u0007.\u000A(text2))
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
				}
				else
				{
					bool flag = !\u001B\u0003\u0004.\u000A(text2, \u0011\u0020\u001D.\u001D(this), StringComparison.OrdinalIgnoreCase);
					\u0014\u0011\u0004.\u0007(this, text2);
					if (flag)
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
						SelectedExcel.ExcelFileChangedHandler or = SelectedExcel.OR;
						if (or == null)
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
						}
						else
						{
							\u0017\u0011\u0004.\u000A(or, this);
						}
					}
				}
			}
			catch (Exception u001F)
			{
				\u000A\u0016.\u001F(u001F);
			}
		}

		// Token: 0x06000A98 RID: 2712 RVA: 0x00045498 File Offset: 0x00043698
		public void RefreshExcelFile(string filePath)
		{
			if (\u001A\u0006\u0007.\u000A(filePath))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.RefreshExcelFile(string)).MethodHandle;
				}
				return;
			}
			if (\u0008\u0013\u000A.\u000A(\u0011\u0020\u001D.\u001D(this), filePath))
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
				return;
			}
			\u000C\u0011\u0004.\u0007(this, filePath);
			\u001C\u0016\u0004.\u001D(this, ActionTypes.UpdateFrom);
			if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u001D(this)) == 0)
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
				\u001A\u0011\u0004.\u0007(this);
			}
			\u0012\u0008\u0004.\u0007(this);
			\u0013\u0011\u0004.\u0007(this);
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x00045520 File Offset: 0x00043720
		public void UpdateRelativePath()
		{
			if (\u0013\u0008\u0004.\u0007(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.UpdateRelativePath()).MethodHandle;
				}
				\u001E\u0008\u0004.\u0007(this, this.HX());
			}
			\u0015\u0011\u0004.\u0007(this);
		}

		// Token: 0x06000A9A RID: 2714 RVA: 0x00045560 File Offset: 0x00043760
		private string HX()
		{
			return \u0020\u0008\u0004.\u0007(this, \u0011\u0020\u001D.\u001D(this), \u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>()))));
		}

		// Token: 0x06000A9B RID: 2715 RVA: 0x0004559C File Offset: 0x0004379C
		public void UpdateViewTypeIfValid(long viewTypeId)
		{
			SelectedExcel.\u0017\u0005 u0017_u = new SelectedExcel.\u0017\u0005();
			u0017_u.\u001F = viewTypeId;
			EnumInfo enumInfo = Enumerable.FirstOrDefault<EnumInfo>(\u0020\u0011\u0004.\u0007(this), new Func<EnumInfo, bool>(u0017_u.\u000A));
			if (enumInfo != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.UpdateViewTypeIfValid(long)).MethodHandle;
				}
				if (\u000D\u001B\u0004.\u0007(this, enumInfo, true))
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
					\u0005\u0008\u0004.\u0007(this, enumInfo);
				}
			}
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x00045608 File Offset: 0x00043808
		[CompilerGenerated]
		private bool YX(SheetAndNamedRange F)
		{
			return \u0008\u0013\u000A.\u000A(\u0001\u0011\u0004.\u000A(F), this._workSheet);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0004562C File Offset: 0x0004382C
		[CompilerGenerated]
		private bool CX(NamedRangeInfo F)
		{
			return \u0008\u0013\u000A.\u000A(\u0017\u0020\u001D.\u0007(F), \u0017\u0020\u001D.\u0007(\u0014\u0020\u001D.\u001D(this)));
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x00045658 File Offset: 0x00043858
		[CompilerGenerated]
		private bool LX(SheetAndNamedRange F)
		{
			return \u0008\u0013\u000A.\u000A(\u0001\u0011\u0004.\u000A(F), this._workSheet);
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x0004567C File Offset: 0x0004387C
		[CompilerGenerated]
		private bool SX(SelectedExcel F)
		{
			return \u001D\u0017\u000A.\u000A(\u0020\u0020\u001D.\u0007(F), \u0020\u0020\u001D.\u001D(this));
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x000456A0 File Offset: 0x000438A0
		[CompilerGenerated]
		private bool BX(string F)
		{
			return \u0008\u0013\u000A.\u000A(F, this._workSheet);
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x000456BC File Offset: 0x000438BC
		[CompilerGenerated]
		private bool UX(SelectedExcel F)
		{
			if (\u001F\u001E\u0004.\u000A(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.UX(SelectedExcel)).MethodHandle;
				}
				if (\u0009\u0011\u0004.\u000A(F))
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
					return \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(F)) != \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u001D(this));
				}
			}
			return false;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x00045720 File Offset: 0x00043920
		[CompilerGenerated]
		private bool WX(SelectedExcel F)
		{
			return \u001D\u0017\u000A.\u000A(\u0017\u0020\u001D.\u0007(\u0014\u0020\u001D.\u0007(F)), \u0017\u0020\u001D.\u0007(\u0014\u0020\u001D.\u001D(this)));
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x00045754 File Offset: 0x00043954
		[CompilerGenerated]
		private bool KX(NamedRangeInfo F)
		{
			return \u0008\u0013\u000A.\u000A(\u0017\u0020\u001D.\u0007(F), \u0017\u0020\u001D.\u0007(\u0014\u0020\u001D.\u001D(this)));
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x00045780 File Offset: 0x00043980
		[CompilerGenerated]
		private void JX(SelectedExcel F)
		{
			\u000A\u001E\u0004.\u000A(F, \u0018\u0011\u0004.\u0007(this));
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0004579C File Offset: 0x0004399C
		[CompilerGenerated]
		private void EX(SelectedExcel F)
		{
			\u0007\u001E\u0004.\u000A(F, \u0004\u0011\u0004.\u0007(this));
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x000457B8 File Offset: 0x000439B8
		[CompilerGenerated]
		private void NX(SelectedExcel F)
		{
			F.AZ(\u0019\u0020\u001D.\u001D(this));
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x000457D4 File Offset: 0x000439D4
		[CompilerGenerated]
		private void MX(SelectedExcel F)
		{
			F.GZ(\u000A\u0011\u0004.\u0007(this));
		}

		// Token: 0x0400041F RID: 1055
		[CompilerGenerated]
		private static List<SelectedExcel> MR;

		// Token: 0x04000420 RID: 1056
		[CompilerGenerated]
		private static bool VR;

		// Token: 0x04000421 RID: 1057
		private static readonly List<EnumInfo> ZR = \u001D\u0016.\u0004();

		// Token: 0x04000422 RID: 1058
		private List<SheetAndNamedRange> _sheetAndNamedRanges = new List<SheetAndNamedRange>();

		// Token: 0x04000423 RID: 1059
		private UpdateStates _updateState = UpdateStates.ToAdd;

		// Token: 0x04000424 RID: 1060
		private ActionTypes _actionType;

		// Token: 0x04000425 RID: 1061
		private EnumInfo _importType = \u000B\u0008\u0004.\u000A(ImportTypes.Table);

		// Token: 0x04000426 RID: 1062
		private bool _isSelected;

		// Token: 0x04000427 RID: 1063
		private int _viewScale;

		// Token: 0x04000428 RID: 1064
		private bool _isRelativePath;

		// Token: 0x04000429 RID: 1065
		private bool _autoSync;

		// Token: 0x0400042A RID: 1066
		private bool _isChecked;

		// Token: 0x0400042B RID: 1067
		private string _sheetName;

		// Token: 0x0400042C RID: 1068
		private string _modified;

		// Token: 0x0400042D RID: 1069
		private List<NamedRangeInfo> _workSheetRegions = new List<NamedRangeInfo>();

		// Token: 0x0400042E RID: 1070
		private NamedRangeInfo _workSheetRegion = new NamedRangeInfo();

		// Token: 0x0400042F RID: 1071
		private string _workSheet;

		// Token: 0x04000430 RID: 1072
		private string _excelFile;

		// Token: 0x04000431 RID: 1073
		private EnumInfo _viewType;

		// Token: 0x04000432 RID: 1074
		private List<EnumInfo> _viewTypes;

		// Token: 0x04000433 RID: 1075
		private int _selectedDpi;

		// Token: 0x04000434 RID: 1076
		private EnumInfo _pageOption;

		// Token: 0x04000435 RID: 1077
		private string _selectedPages;

		// Token: 0x0400043B RID: 1083
		private bool _outOfDate;

		// Token: 0x02000807 RID: 2055
		// (Invoke) Token: 0x06004D75 RID: 19829
		public delegate void ViewTypeUnallowedHandler(bool showWarning);

		// Token: 0x02000808 RID: 2056
		// (Invoke) Token: 0x06004D79 RID: 19833
		public delegate void AutoSyncChangedHandler(bool isAutoSync);

		// Token: 0x02000809 RID: 2057
		// (Invoke) Token: 0x06004D7D RID: 19837
		public delegate void ExcelFileChangedHandler(SelectedExcel changedExcel);

		// Token: 0x0200080B RID: 2059
		[CompilerGenerated]
		private sealed class \u001E\u0005
		{
			// Token: 0x06004D8F RID: 19855 RVA: 0x001DE848 File Offset: 0x001DCA48
			internal bool \u0007(SelectedExcel \u001F)
			{
				if (\u001F\u001E\u0004.\u000A(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectedExcel.\u001E\u0005.\u0007(SelectedExcel)).MethodHandle;
					}
					return \u0011\u001F\u0010.\u000A(this.\u001F, \u001F);
				}
				return false;
			}

			// Token: 0x04002054 RID: 8276
			public Func<SelectedExcel, bool> \u001F;

			// Token: 0x04002055 RID: 8277
			public Func<SelectedExcel, bool> \u000A;
		}

		// Token: 0x0200080C RID: 2060
		[CompilerGenerated]
		private sealed class \u0020\u0005
		{
			// Token: 0x06004D91 RID: 19857 RVA: 0x001DE898 File Offset: 0x001DCA98
			internal bool \u000A(EnumInfo \u001F)
			{
				return \u000D\u001B\u001D.\u0007(\u001F) == \u000D\u001B\u001D.\u0007(this.\u001F);
			}

			// Token: 0x04002056 RID: 8278
			public EnumInfo \u001F;
		}

		// Token: 0x0200080D RID: 2061
		[CompilerGenerated]
		private sealed class \u0017\u0005
		{
			// Token: 0x06004D93 RID: 19859 RVA: 0x001DE8D0 File Offset: 0x001DCAD0
			internal bool \u000A(EnumInfo \u001F)
			{
				return (long)\u000D\u001B\u001D.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x04002057 RID: 8279
			public long \u001F;
		}
	}
}
