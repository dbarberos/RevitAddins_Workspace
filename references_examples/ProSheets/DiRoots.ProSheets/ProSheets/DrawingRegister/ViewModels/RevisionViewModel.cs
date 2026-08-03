using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.ViewModels;
using ProSheets.DrawingRegister.Enums;
using ProSheets.DrawingRegister.Helpers;
using ProSheets.DrawingRegister.Model;
using ProSheets.Extensions;
using ProSheets.Models;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x0200010C RID: 268
	public class RevisionViewModel : ViewModelBase
	{
		// Token: 0x06000D58 RID: 3416 RVA: 0x0004EAC8 File Offset: 0x0004CCC8
		public RevisionViewModel(RevisionNumbering revisionNumbering)
		{
			this.\u0006\u001C();
			\u001D\u001B\u0016.\u0018(this, revisionNumbering);
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000D59 RID: 3417 RVA: 0x0004EAE8 File Offset: 0x0004CCE8
		// (set) Token: 0x06000D5A RID: 3418 RVA: 0x0004EAFC File Offset: 0x0004CCFC
		private RevisionDataOrderChange _revisionDataOrderChanged { get; set; }

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000D5B RID: 3419 RVA: 0x0004EB10 File Offset: 0x0004CD10
		// (set) Token: 0x06000D5C RID: 3420 RVA: 0x0004EB24 File Offset: 0x0004CD24
		public string RevisionMarker
		{
			get
			{
				return this.\u0014\u000F;
			}
			set
			{
				this.\u0014\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "RevisionMarker");
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000D5D RID: 3421 RVA: 0x0004EB44 File Offset: 0x0004CD44
		// (set) Token: 0x06000D5E RID: 3422 RVA: 0x0004EB58 File Offset: 0x0004CD58
		public int OldMaxNumberOfRevision { get; set; }

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000D5F RID: 3423 RVA: 0x0004EB6C File Offset: 0x0004CD6C
		// (set) Token: 0x06000D60 RID: 3424 RVA: 0x0004EB80 File Offset: 0x0004CD80
		public bool IsLinkedFile
		{
			get
			{
				return this.\u0018\u000F;
			}
			set
			{
				this.\u0018\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "IsLinkedFile");
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000D61 RID: 3425 RVA: 0x0004EBA0 File Offset: 0x0004CDA0
		// (set) Token: 0x06000D62 RID: 3426 RVA: 0x0004EBB4 File Offset: 0x0004CDB4
		public string Status
		{
			get
			{
				return this.\u000E\u0003;
			}
			set
			{
				this.\u000E\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "Status");
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000D63 RID: 3427 RVA: 0x0004EBD4 File Offset: 0x0004CDD4
		// (set) Token: 0x06000D64 RID: 3428 RVA: 0x0004EBE8 File Offset: 0x0004CDE8
		public bool IsEnabled
		{
			get
			{
				return this.\u0019\u0016;
			}
			set
			{
				this.\u0019\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "IsEnabled");
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000D65 RID: 3429 RVA: 0x0004EC08 File Offset: 0x0004CE08
		// (set) Token: 0x06000D66 RID: 3430 RVA: 0x0004EC1C File Offset: 0x0004CE1C
		public IList<RevisionInformation> SelectedRevisionData
		{
			get
			{
				return this.\u0010\u0016;
			}
			set
			{
				this.\u0010\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "SelectedRevisionData");
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000D67 RID: 3431 RVA: 0x0004EC3C File Offset: 0x0004CE3C
		// (set) Token: 0x06000D68 RID: 3432 RVA: 0x0004EC50 File Offset: 0x0004CE50
		public bool HideUnchecked
		{
			get
			{
				return this.\u0013;
			}
			set
			{
				this.\u0013 = value;
				\u0011\u0010\u0018.\u0018(this, "HideUnchecked");
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000D69 RID: 3433 RVA: 0x0004EC70 File Offset: 0x0004CE70
		// (set) Token: 0x06000D6A RID: 3434 RVA: 0x0004EC84 File Offset: 0x0004CE84
		public int MaxNumberOfRevision
		{
			get
			{
				return this.\u0007\u0016;
			}
			set
			{
				this.\u0007\u0016 = value;
				\u001A\u001B\u0016.\u0018(this);
				\u0011\u0010\u0018.\u0018(this, "MaxNumberOfRevision");
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000D6B RID: 3435 RVA: 0x0004ECAC File Offset: 0x0004CEAC
		// (set) Token: 0x06000D6C RID: 3436 RVA: 0x0004ECC0 File Offset: 0x0004CEC0
		public string ProjectParameterFilter
		{
			get
			{
				return this.\u001B\u0003;
			}
			set
			{
				this.\u001B\u0003 = value;
				\u0011\u0010\u0018.\u0018(this, "ProjectParameterFilter");
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000D6D RID: 3437 RVA: 0x0004ECE0 File Offset: 0x0004CEE0
		// (set) Token: 0x06000D6E RID: 3438 RVA: 0x0004ECF4 File Offset: 0x0004CEF4
		public bool? IsAllChecked
		{
			get
			{
				return this.\u001E\u0018;
			}
			set
			{
				this.\u001E\u0018 = value;
				\u0011\u0010\u0018.\u0018(this, "IsAllChecked");
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000D6F RID: 3439 RVA: 0x0004ED14 File Offset: 0x0004CF14
		// (set) Token: 0x06000D70 RID: 3440 RVA: 0x0004ED28 File Offset: 0x0004CF28
		public List<RevisionInformation> Revisions { get; set; }

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000D71 RID: 3441 RVA: 0x0004ED3C File Offset: 0x0004CF3C
		// (set) Token: 0x06000D72 RID: 3442 RVA: 0x0004ED50 File Offset: 0x0004CF50
		public ICollectionView RevisionCollectionView
		{
			get
			{
				return this.\u001D\u0016;
			}
			set
			{
				this.\u001D\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "RevisionCollectionView");
			}
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06000D73 RID: 3443 RVA: 0x0004ED70 File Offset: 0x0004CF70
		// (set) Token: 0x06000D74 RID: 3444 RVA: 0x0004ED84 File Offset: 0x0004CF84
		public ICollectionView RevisionDataCollectionView
		{
			get
			{
				return this.\u001A\u0016;
			}
			set
			{
				this.\u001A\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "RevisionDataCollectionView");
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000D75 RID: 3445 RVA: 0x0004EDA4 File Offset: 0x0004CFA4
		// (set) Token: 0x06000D76 RID: 3446 RVA: 0x0004EDB8 File Offset: 0x0004CFB8
		public ObservableCollection<RevisionData> RevisionData
		{
			get
			{
				return this.\u000B\u0016;
			}
			set
			{
				this.\u000B\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "RevisionData");
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000D77 RID: 3447 RVA: 0x0004EDD8 File Offset: 0x0004CFD8
		// (set) Token: 0x06000D78 RID: 3448 RVA: 0x0004EDEC File Offset: 0x0004CFEC
		public RevisionData SequenceData
		{
			get
			{
				return this.\u0006\u0016;
			}
			set
			{
				this.\u0006\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "SequenceData");
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000D79 RID: 3449 RVA: 0x0004EE0C File Offset: 0x0004D00C
		// (set) Token: 0x06000D7A RID: 3450 RVA: 0x0004EE20 File Offset: 0x0004D020
		public RevisionData RevisionNumberData
		{
			get
			{
				return this.\u0008\u0016;
			}
			set
			{
				this.\u0008\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "RevisionNumberData");
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06000D7B RID: 3451 RVA: 0x0004EE40 File Offset: 0x0004D040
		// (set) Token: 0x06000D7C RID: 3452 RVA: 0x0004EE54 File Offset: 0x0004D054
		public RevisionData DescriptionData
		{
			get
			{
				return this.\u0001\u0016;
			}
			set
			{
				this.\u0001\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "DescriptionData");
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06000D7D RID: 3453 RVA: 0x0004EE74 File Offset: 0x0004D074
		// (set) Token: 0x06000D7E RID: 3454 RVA: 0x0004EE88 File Offset: 0x0004D088
		public RevisionData IssuedByData
		{
			get
			{
				return this.\u001B\u0016;
			}
			set
			{
				this.\u001B\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "IssuedByData");
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (get) Token: 0x06000D7F RID: 3455 RVA: 0x0004EEA8 File Offset: 0x0004D0A8
		// (set) Token: 0x06000D80 RID: 3456 RVA: 0x0004EEBC File Offset: 0x0004D0BC
		public RevisionData IssuedToData
		{
			get
			{
				return this.\u0005\u0016;
			}
			set
			{
				this.\u0005\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "IssuedToData");
			}
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06000D81 RID: 3457 RVA: 0x0004EEDC File Offset: 0x0004D0DC
		// (set) Token: 0x06000D82 RID: 3458 RVA: 0x0004EEF0 File Offset: 0x0004D0F0
		public RevisionData DateData
		{
			get
			{
				return this.\u000E\u0016;
			}
			set
			{
				this.\u000E\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "DateData");
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06000D83 RID: 3459 RVA: 0x0004EF10 File Offset: 0x0004D110
		// (set) Token: 0x06000D84 RID: 3460 RVA: 0x0004EF24 File Offset: 0x0004D124
		public RevisionData IssuedData
		{
			get
			{
				return this.\u000C\u000F;
			}
			set
			{
				this.\u000C\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "IssuedData");
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06000D85 RID: 3461 RVA: 0x0004EF44 File Offset: 0x0004D144
		// (set) Token: 0x06000D86 RID: 3462 RVA: 0x0004EF58 File Offset: 0x0004D158
		public List<string> OrientationOptions { get; set; }

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06000D87 RID: 3463 RVA: 0x0004EF6C File Offset: 0x0004D16C
		// (set) Token: 0x06000D88 RID: 3464 RVA: 0x0004EF84 File Offset: 0x0004D184
		public RevisionDataOrderChange RevisionDataOrderChanged
		{
			get
			{
				return \u000B\u001B\u0016.\u0018(this);
			}
			set
			{
				\u0019\u001B\u0016.\u0018(this, value);
				\u0011\u0010\u0018.\u0018(this, "RevisionDataOrderChanged");
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06000D89 RID: 3465 RVA: 0x0004EFA4 File Offset: 0x0004D1A4
		// (set) Token: 0x06000D8A RID: 3466 RVA: 0x0004EFB8 File Offset: 0x0004D1B8
		public RevisionNumbering RevisionNumber
		{
			get
			{
				return this.\u0003\u000F;
			}
			set
			{
				this.\u0003\u000F = value;
				this.\u000B\u0009();
				\u0011\u0010\u0018.\u0018(this, "RevisionNumber");
			}
		}

		// Token: 0x170004BE RID: 1214
		public string this[string columnName]
		{
			get
			{
				string result = \u0005\u001E\u000F.\u000C;
				if (\u000F\u0002\u0018.\u0018(columnName, "MaxNumberOfRevision"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.get_Item(string)).MethodHandle;
					}
					if (\u0011\u000B\u0016.\u0003(this) < 1)
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
						result = "Max number of revision should be greater than 0";
					}
				}
				return result;
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x0004F034 File Offset: 0x0004D234
		// (set) Token: 0x06000D8D RID: 3469 RVA: 0x0004F048 File Offset: 0x0004D248
		public string NumberingStatus
		{
			get
			{
				return this.\u0016\u000F;
			}
			set
			{
				this.\u0016\u000F = value;
				\u0011\u0010\u0018.\u0018(this, "NumberingStatus");
			}
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x0004F068 File Offset: 0x0004D268
		private void \u000B\u0009()
		{
			string u = string.Empty;
			RevisionNumbering revisionNumbering = \u0020\u000B\u0016.\u0003(this);
			if (revisionNumbering != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.\u000B\u0009()).MethodHandle;
				}
				if (revisionNumbering != 1)
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
				}
				else
				{
					u = \u0006\u001B\u0016.\u0018();
				}
			}
			else
			{
				u = \u0008\u001B\u0016.\u0018();
			}
			\u0007\u001B\u0016.\u0018(this, \u001C\u001E\u0018.\u0018(\u0010\u001B\u0016.\u0018(), u));
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0004F0D4 File Offset: 0x0004D2D4
		private void \u0006\u001C()
		{
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\RevisionViewModel.cs", "Init");
			\u000E\u001B\u0016.\u0018(this, \u0016\u0004\u0016.\u0018());
			\u001C\u0006\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u0012\u0006\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u0014\u0006\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u000C\u0006\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u000E\u0010\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u0005\u0010\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u001B\u0010\u0016.\u0003(this, \u0007\u0006\u0016.\u0018());
			\u0013\u0006\u0016.\u0003(this, false);
			\u001D\u0010\u0016.\u0003(this, \u001C\u0005\u0016.\u0018());
			\u000D\u0005\u0016.\u0018(this, \u0011\u0002\u0018.\u0018());
			\u0019\u0017\u0014.\u0018(\u000F\u0005\u0016.\u0018(this), \u0012\u0005\u0016.\u0018());
			\u0019\u0017\u0014.\u0018(\u000F\u0005\u0016.\u0018(this), \u0016\u0005\u0016.\u0018());
			\u0014\u0005\u0016.\u0018(this, \u0003\u0005\u0016.\u0018());
			\u000E\u001B\u0016.\u0018(this, \u000C\u0005\u0016.\u0018(\u0018\u0005\u0016.\u0018()));
			\u0005\u001B\u0016.\u0018(this, \u0010\u0006\u0018.\u0018(\u001E\u001A\u0016.\u0003(this)));
			\u0005\u0006\u0018.\u0018(\u001B\u001B\u0016.\u0018(this), new Predicate<object>(this.\u000F\u0009));
			\u0017\u001A\u0016.\u0003(this, 5);
			\u0015\u001A\u0016.\u0003(this);
			\u0001\u001B\u0016.\u0018(this, new bool?(false));
			\u001F\u0006\u0016.\u0003(this, "X");
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\RevisionViewModel.cs", "Init");
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x0004F234 File Offset: 0x0004D434
		private bool \u000F\u0009(object \u000C)
		{
			RevisionInformation revisionInformation = \u0020\u0006\u000F.\u000C(\u000C);
			if (revisionInformation == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.\u000F\u0009(object)).MethodHandle;
				}
				return false;
			}
			bool flag = true;
			if (!\u001F\u001A\u0018.\u0018(\u000A\u0005\u0016.\u0018(this)))
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
				bool flag2;
				if (!\u001B\u0013\u0018.\u000C(\u001F\u0005\u0016.\u0018(revisionInformation), \u000A\u0005\u0016.\u0018(this)))
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
					flag2 = \u001B\u0013\u0018.\u000C(\u0020\u0005\u0016.\u0018(revisionInformation), \u000A\u0005\u0016.\u0018(this));
				}
				else
				{
					flag2 = true;
				}
				flag = flag2;
			}
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
				if (\u0009\u0005\u0016.\u0018(this))
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
					flag = \u0013\u0005\u0016.\u0018(revisionInformation);
				}
			}
			return flag;
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x0004F2E8 File Offset: 0x0004D4E8
		[BindableMethod("AddLinkedFilesRevision")]
		public void AddLinkedFilesRevision()
		{
			\u000E\u001B\u0016.\u0018(this, \u0016\u0004\u0016.\u0018());
			\u0011\u0005\u0016.\u0018(\u001E\u001A\u0016.\u0003(this), \u0018\u0005\u0016.\u0018());
			if (\u000C\u0007\u0016.\u0003(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.AddLinkedFilesRevision()).MethodHandle;
				}
				\u0011\u0005\u0016.\u0018(\u001E\u001A\u0016.\u0003(this), \u0015\u0005\u0016.\u0018());
			}
			\u0005\u001B\u0016.\u0018(this, \u0010\u0006\u0018.\u0018(\u001E\u001A\u0016.\u0003(this)));
			\u0005\u0006\u0018.\u0018(\u001B\u001B\u0016.\u0018(this), new Predicate<object>(this.\u000F\u0009));
			\u0015\u001A\u0016.\u0003(this);
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x0004F37C File Offset: 0x0004D57C
		[BindableMethod("RevisionChecked")]
		public void RevisionChecked(object revisionObj)
		{
			RevisionViewModel.\u001C\u0015\u0018 u001C_u0015_u = new RevisionViewModel.\u001C\u0015\u0018();
			u001C_u0015_u.\u000C = \u0020\u0006\u000F.\u000C(revisionObj);
			if (u001C_u0015_u.\u000C == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.RevisionChecked(object)).MethodHandle;
				}
				return;
			}
			if (\u000B\u0005\u0016.\u0018(this) != null)
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
				if (Enumerable.Any<RevisionInformation>(\u000B\u0005\u0016.\u0018(this), new Func<RevisionInformation, bool>(u001C_u0015_u.\u0018)))
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
					IEnumerator<RevisionInformation> enumerator = \u001A\u0005\u0016.\u0018(\u000B\u0005\u0016.\u0018(this));
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							\u001E\u0006\u0016.\u0018(\u001D\u0005\u0016.\u0018(enumerator), \u0013\u0005\u0016.\u0018(u001C_u0015_u.\u000C));
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
								switch (1)
								{
								case 0:
									continue;
								}
								break;
							}
							\u0020\u001E\u0018.\u0018(enumerator);
						}
					}
				}
			}
			object u000C = \u001E\u001A\u0016.\u0003(this);
			Predicate<RevisionInformation> u;
			if ((u = RevisionViewModel.<>c.\u0018) == null)
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
				u = (RevisionViewModel.<>c.\u0018 = new Predicate<RevisionInformation>(RevisionViewModel.<>c.\u000C.\u001A));
			}
			\u0013\u0006\u0016.\u0003(this, \u0002\u001A\u0016.\u0018(u000C, u));
			\u0015\u001A\u0016.\u0003(this);
			object u000C2 = \u001E\u001A\u0016.\u0003(this);
			Predicate<RevisionInformation> u2;
			if ((u2 = RevisionViewModel.<>c.\u0014) == null)
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
				u2 = (RevisionViewModel.<>c.\u0014 = new Predicate<RevisionInformation>(RevisionViewModel.<>c.\u000C.\u000B));
			}
			\u0001\u001B\u0016.\u0018(this, new bool?(\u0004\u0005\u0016.\u0018(u000C2, u2)));
			bool? u3 = \u0002\u0005\u0016.\u0018(this);
			if (!\u000F\u0014\u0003.\u0018(ref u3))
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
				object u000C3 = \u001E\u001A\u0016.\u0003(this);
				Predicate<RevisionInformation> u4;
				if ((u4 = RevisionViewModel.<>c.\u0003) == null)
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
					u4 = (RevisionViewModel.<>c.\u0003 = new Predicate<RevisionInformation>(RevisionViewModel.<>c.\u000C.\u0019));
				}
				if (\u0002\u001A\u0016.\u0018(u000C3, u4))
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
					\u000B\u0004\u000F.\u000C(ref u3);
					\u0001\u001B\u0016.\u0018(this, u3);
				}
			}
			int num = \u0011\u000B\u0016.\u0003(this);
			IEnumerable<RevisionInformation> enumerable = \u001E\u001A\u0016.\u0003(this);
			Func<RevisionInformation, bool> func;
			if ((func = RevisionViewModel.<>c.\u0016) == null)
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
				func = (RevisionViewModel.<>c.\u0016 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0007));
			}
			if (num < Enumerable.Count<RevisionInformation>(enumerable, func))
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
				\u001E\u0006\u0016.\u0018(\u001E\u0005\u0016.\u0018(\u001E\u001A\u0016.\u0003(this), new Predicate<RevisionInformation>(u001C_u0015_u.\u0014)), false);
				\u0001\u0019\u0018.\u0018(\u0017\u0005\u0016.\u0018(), \u0001\u000C\u0014.\u0018(this), 350.0, MessageBoxButtons.OK);
			}
			this.\u0019\u0009();
		}

		// Token: 0x06000D93 RID: 3475 RVA: 0x0004F5E8 File Offset: 0x0004D7E8
		private void \u0019\u0009()
		{
			if (Enumerable.Any<RevisionData>(\u0019\u0005\u0016.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.\u0019\u0009()).MethodHandle;
				}
				List<RevisionData> u000C = \u0001\u0005\u0016.\u0018();
				IEnumerator<RevisionData> enumerator = \u0008\u0005\u0016.\u0018(\u001E\u000B\u0016.\u0014(\u0002\u000B\u0016.\u0003(this)));
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						RevisionData revisionData = \u0006\u0005\u0016.\u0018(enumerator);
						RevisionData u = \u0007\u0010\u0016.\u0003(this, revisionData, \u0010\u0005\u0016.\u0018(revisionData));
						\u0007\u0005\u0016.\u0018(u000C, u);
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
					if (enumerator != null)
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
				\u001D\u0010\u0016.\u0003(this, \u0004\u0010\u0016.\u0018(u000C));
				\u0002\u0010\u0016.\u0014(\u0002\u000B\u0016.\u0003(this), \u0019\u0005\u0016.\u0018(this));
			}
		}

		// Token: 0x06000D94 RID: 3476 RVA: 0x0004F6BC File Offset: 0x0004D8BC
		[BindableMethod("SelectAllParameter")]
		public void SelectAllParameters(ICollectionView collectionView)
		{
			List<RevisionInformation> u000C = Enumerable.ToList<RevisionInformation>(Enumerable.Cast<RevisionInformation>(collectionView));
			bool? flag = \u0002\u0005\u0016.\u0018(this);
			if (\u000F\u0014\u0003.\u0018(ref flag))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.SelectAllParameters(ICollectionView)).MethodHandle;
				}
				if (!\u0001\u0019\u0018.\u0018(\u0014\u001E\u0018.\u0018(\u000E\u0005\u0016.\u0018(), "\n", \u0005\u0005\u0016.\u0018()), \u0001\u000C\u0014.\u0018(this), 350.0, MessageBoxButtons.OKCancel))
				{
					\u0001\u001B\u0016.\u0018(this, new bool?(false));
					return;
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
				\u0017\u001A\u0016.\u0003(this, \u001B\u0005\u0016.\u0018(u000C));
			}
			List<RevisionInformation>.Enumerator enumerator = \u001D\u0006\u0016.\u0018(u000C);
			try
			{
				while (\u0017\u0006\u0016.\u0018(ref enumerator))
				{
					object u000C2 = \u0004\u0006\u0016.\u0018(ref enumerator);
					flag = \u0002\u0005\u0016.\u0018(this);
					\u001E\u0006\u0016.\u0018(u000C2, \u000F\u0014\u0003.\u0018(ref flag));
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
			this.\u0019\u0009();
			\u0015\u001A\u0016.\u0003(this);
		}

		// Token: 0x06000D95 RID: 3477 RVA: 0x0004F7C8 File Offset: 0x0004D9C8
		[BindableMethod("Refresh")]
		public void Refresh()
		{
			\u001D\u0008\u0018.\u0018(\u001B\u001B\u0016.\u0018(this));
		}

		// Token: 0x06000D96 RID: 3478 RVA: 0x0004F7E4 File Offset: 0x0004D9E4
		[BindableMethod("ReloadAll")]
		public void ReloadAll()
		{
			object u000C = \u001E\u001A\u0016.\u0003(this);
			Action<RevisionInformation> u;
			if ((u = RevisionViewModel.<>c.\u000F) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.ReloadAll()).MethodHandle;
				}
				u = (RevisionViewModel.<>c.\u000F = new Action<RevisionInformation>(RevisionViewModel.<>c.\u000C.\u0010));
			}
			\u0004\u001A\u0016.\u0018(u000C, u);
			\u0013\u0006\u0016.\u0003(this, false);
			object u000C2 = Enumerable.ToList<RevisionData>(\u0019\u0005\u0016.\u0018(this));
			Action<RevisionData> u2;
			if ((u2 = RevisionViewModel.<>c.\u0012) == null)
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
				u2 = (RevisionViewModel.<>c.\u0012 = new Action<RevisionData>(RevisionViewModel.<>c.\u000C.\u0006));
			}
			\u001A\u0010\u0016.\u0018(u000C2, u2);
			\u0001\u001B\u0016.\u0018(this, new bool?(false));
			\u0018\u000E\u0016.\u0018(this, string.Empty);
			\u001D\u0010\u0016.\u0003(this, \u001C\u0005\u0016.\u0018());
			\u0002\u0010\u0016.\u0014(\u0002\u000B\u0016.\u0003(this), \u0019\u0005\u0016.\u0018(this));
			\u000C\u000E\u0016.\u0018(this, false);
			\u0017\u001A\u0016.\u0003(this, 5);
			\u0015\u001A\u0016.\u0003(this);
		}

		// Token: 0x06000D97 RID: 3479 RVA: 0x0004F8C4 File Offset: 0x0004DAC4
		[BindableMethod("ChangeInMax")]
		public void ChangeInMaxRev()
		{
			int num = \u0011\u000B\u0016.\u0003(this);
			IEnumerable<RevisionInformation> enumerable = \u001E\u001A\u0016.\u0003(this);
			Func<RevisionInformation, bool> func;
			if ((func = RevisionViewModel.<>c.\u000D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.ChangeInMaxRev()).MethodHandle;
				}
				func = (RevisionViewModel.<>c.\u000D = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0008));
			}
			if (num < Enumerable.Count<RevisionInformation>(enumerable, func))
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
				\u0001\u0019\u0018.\u0018(\u000F\u000E\u0016.\u0018(), \u0001\u000C\u0014.\u0018(this), 350.0, MessageBoxButtons.OK);
				IEnumerable<RevisionInformation> enumerable2 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func2;
				if ((func2 = RevisionViewModel.<>c.\u001C) == null)
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
					func2 = (RevisionViewModel.<>c.\u001C = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0001));
				}
				\u0017\u001A\u0016.\u0003(this, Enumerable.Count<RevisionInformation>(enumerable2, func2));
				if (Enumerable.Any<RevisionData>(\u0019\u0005\u0016.\u0018(this)))
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
					\u0017\u001A\u0016.\u0003(this, \u0014\u000E\u0016.\u0018(\u0003\u000E\u0016.\u0014(\u0016\u000E\u0016.\u0018(\u0019\u0005\u0016.\u0018(this), 0))));
				}
			}
		}

		// Token: 0x06000D98 RID: 3480 RVA: 0x0004F9C8 File Offset: 0x0004DBC8
		[BindableMethod("SequenceUpdate")]
		public void SequenceUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.SequenceUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u000D\u0006\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u000D\u0006\u0016.\u0003(this), RevisionDataProperty.Sequence);
		}

		// Token: 0x06000D99 RID: 3481 RVA: 0x0004FA20 File Offset: 0x0004DC20
		[BindableMethod("RevisionNumberUpdate")]
		public void RevisionNumberUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.RevisionNumberUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u000F\u0006\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u000F\u0006\u0016.\u0003(this), RevisionDataProperty.RevisionNumber);
		}

		// Token: 0x06000D9A RID: 3482 RVA: 0x0004FA78 File Offset: 0x0004DC78
		[BindableMethod("DescriptionUpdate")]
		public void DescriptionUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.DescriptionUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u0018\u0006\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u0018\u0006\u0016.\u0003(this), RevisionDataProperty.Description);
		}

		// Token: 0x06000D9B RID: 3483 RVA: 0x0004FAD0 File Offset: 0x0004DCD0
		[BindableMethod("IssuedByUpdate")]
		public void IssuedByUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.IssuedByUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u0001\u0010\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u0001\u0010\u0016.\u0003(this), RevisionDataProperty.IssuedBy);
		}

		// Token: 0x06000D9C RID: 3484 RVA: 0x0004FB28 File Offset: 0x0004DD28
		[BindableMethod("DateUpdate")]
		public void DateUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.DateUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u0006\u0010\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u0006\u0010\u0016.\u0003(this), RevisionDataProperty.Date);
		}

		// Token: 0x06000D9D RID: 3485 RVA: 0x0004FB80 File Offset: 0x0004DD80
		[BindableMethod("IssuedToUpdate")]
		public void IssuedToUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.IssuedToUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u0008\u0010\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u0008\u0010\u0016.\u0003(this), RevisionDataProperty.IssuedTo);
		}

		// Token: 0x06000D9E RID: 3486 RVA: 0x0004FBD8 File Offset: 0x0004DDD8
		[BindableMethod("IssuedUpdate")]
		public void IssuedUpdate(object sender)
		{
			CheckBox checkBox = \u0015\u0019\u000F.\u000C(sender);
			if (checkBox == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.IssuedUpdate(object)).MethodHandle;
				}
				return;
			}
			\u000D\u000E\u0016.\u0018(\u0010\u0010\u0016.\u0003(this), \u0001\u0017\u0018.\u0018(\u0002\u000B\u0018.\u0018(checkBox)));
			\u0012\u000E\u0016.\u0018(this, \u0010\u0010\u0016.\u0003(this), RevisionDataProperty.Issued);
		}

		// Token: 0x06000D9F RID: 3487 RVA: 0x0004FC30 File Offset: 0x0004DE30
		[BindableMethod("OnSelectedElementNameComponents")]
		public void OnSelectedElementNameComponents(object sender)
		{
			List<RevisionData> u000C = Enumerable.ToList<RevisionData>(Enumerable.OfType<RevisionData>(\u0014\u000F\u0014.\u0018(\u0007\u000B\u000F.\u000C(sender))));
			\u001C\u000E\u0016.\u0018(\u0002\u000B\u0016.\u0003(this), \u0004\u0010\u0016.\u0018(u000C));
		}

		// Token: 0x06000DA0 RID: 3488 RVA: 0x0004FC70 File Offset: 0x0004DE70
		public void DataUpdate(RevisionData revisionData, RevisionDataProperty revisiondataProperty)
		{
			RevisionViewModel.\u0013\u0015\u0018 u0013_u0015_u = new RevisionViewModel.\u0013\u0015\u0018();
			u0013_u0015_u.\u000C = revisionData;
			if (!\u0011\u000E\u0016.\u0018(u0013_u0015_u.\u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.DataUpdate(ProSheets.DrawingRegister.Model.RevisionData, RevisionDataProperty)).MethodHandle;
				}
				if (Enumerable.Any<RevisionData>(\u0019\u0005\u0016.\u0018(this), new Func<RevisionData, bool>(u0013_u0015_u.\u0018)))
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
					RevisionData u = Enumerable.First<RevisionData>(\u0019\u0005\u0016.\u0018(this), new Func<RevisionData, bool>(u0013_u0015_u.\u0014));
					if (\u000F\u0002\u0018.\u0018(\u001F\u000E\u0016.\u0014(u0013_u0015_u.\u000C), \u0020\u000E\u0016.\u0014(u0013_u0015_u.\u000C)))
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
						\u000A\u000E\u0016.\u0014(u0013_u0015_u.\u000C, string.Empty);
					}
					\u0009\u000E\u0016.\u0018(\u0019\u0005\u0016.\u0018(this), u);
					\u0002\u0010\u0016.\u0014(\u0002\u000B\u0016.\u0003(this), \u0019\u0005\u0016.\u0018(this));
					return;
				}
			}
			else
			{
				RevisionData u2 = \u0007\u0010\u0016.\u0003(this, u0013_u0015_u.\u000C, revisiondataProperty);
				\u0013\u000E\u0016.\u0018(\u0019\u0005\u0016.\u0018(this), u2);
				\u0002\u0010\u0016.\u0014(\u0002\u000B\u0016.\u0003(this), \u0019\u0005\u0016.\u0018(this));
			}
		}

		// Token: 0x06000DA1 RID: 3489 RVA: 0x0004FD8C File Offset: 0x0004DF8C
		[BindableMethod("ChangeNameOfDoc")]
		public void ChangeNameOfDocument(object item, object sender)
		{
			string text = \u0014\u0004\u000F.\u000C(item);
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.ChangeNameOfDocument(object, object)).MethodHandle;
				}
				return;
			}
			TextBox textBox = \u0018\u0004\u000F.\u000C(sender);
			if (textBox == null)
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
				return;
			}
			if (\u001F\u001A\u0018.\u0018(\u0001\u000B\u0018.\u0018(textBox)))
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
				\u0012\u000B\u0018.\u0018(textBox, text);
			}
		}

		// Token: 0x06000DA2 RID: 3490 RVA: 0x0004FDF4 File Offset: 0x0004DFF4
		public RevisionData UpdateProperty(RevisionData revisionData, RevisionDataProperty revisiondataProperty)
		{
			RevisionViewModel.\u0009\u0015\u0018 u0009_u0015_u = new RevisionViewModel.\u0009\u0015\u0018();
			u0009_u0015_u.\u0018 = revisionData;
			\u000A\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\RevisionViewModel.cs", "UpdateProperty");
			u0009_u0015_u.\u000C = \u0011\u0002\u0018.\u0018();
			string u = \u001F\u000E\u0016.\u0014(u0009_u0015_u.\u0018);
			if (\u001F\u001A\u0018.\u0018(\u0020\u000E\u0016.\u0014(u0009_u0015_u.\u0018)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.UpdateProperty(ProSheets.DrawingRegister.Model.RevisionData, RevisionDataProperty)).MethodHandle;
				}
				\u000A\u000E\u0016.\u0014(u0009_u0015_u.\u0018, u);
			}
			switch (revisiondataProperty)
			{
			case RevisionDataProperty.Sequence:
			{
				IEnumerable<RevisionInformation> enumerable = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func;
				if ((func = RevisionViewModel.<>c.\u0013) == null)
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
					func = (RevisionViewModel.<>c.\u0013 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u001B));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable, func)), new Action<RevisionInformation>(u0009_u0015_u.\u0003));
				break;
			}
			case RevisionDataProperty.RevisionNumber:
			{
				IEnumerable<RevisionInformation> enumerable2 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func2;
				if ((func2 = RevisionViewModel.<>c.\u0009) == null)
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
					func2 = (RevisionViewModel.<>c.\u0009 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0005));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable2, func2)), new Action<RevisionInformation>(u0009_u0015_u.\u0016));
				break;
			}
			case RevisionDataProperty.Date:
			{
				IEnumerable<RevisionInformation> enumerable3 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func3;
				if ((func3 = RevisionViewModel.<>c.\u0011) == null)
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
					func3 = (RevisionViewModel.<>c.\u0011 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0014\u0018));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable3, func3)), new Action<RevisionInformation>(u0009_u0015_u.\u001C));
				break;
			}
			case RevisionDataProperty.Description:
			{
				IEnumerable<RevisionInformation> enumerable4 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func4;
				if ((func4 = RevisionViewModel.<>c.\u000A) == null)
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
					func4 = (RevisionViewModel.<>c.\u000A = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u000E));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable4, func4)), new Action<RevisionInformation>(u0009_u0015_u.\u000F));
				break;
			}
			case RevisionDataProperty.Issued:
			{
				IEnumerable<RevisionInformation> enumerable5 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func5;
				if ((func5 = RevisionViewModel.<>c.\u0015) == null)
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
					func5 = (RevisionViewModel.<>c.\u0015 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0003\u0018));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable5, func5)), new Action<RevisionInformation>(u0009_u0015_u.\u0013));
				break;
			}
			case RevisionDataProperty.IssuedTo:
			{
				IEnumerable<RevisionInformation> enumerable6 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func6;
				if ((func6 = RevisionViewModel.<>c.\u001F) == null)
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
					func6 = (RevisionViewModel.<>c.\u001F = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0018\u0018));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable6, func6)), new Action<RevisionInformation>(u0009_u0015_u.\u000D));
				break;
			}
			case RevisionDataProperty.IssuedBy:
			{
				IEnumerable<RevisionInformation> enumerable7 = \u001E\u001A\u0016.\u0003(this);
				Func<RevisionInformation, bool> func7;
				if ((func7 = RevisionViewModel.<>c.\u0020) == null)
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
					func7 = (RevisionViewModel.<>c.\u0020 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u000C\u0018));
				}
				\u0004\u001A\u0016.\u0018(Enumerable.ToList<RevisionInformation>(Enumerable.Where<RevisionInformation>(enumerable7, func7)), new Action<RevisionInformation>(u0009_u0015_u.\u0012));
				break;
			}
			}
			object u2 = u0009_u0015_u.\u0018;
			IEnumerable<RevisionInformation> enumerable8 = \u001E\u001A\u0016.\u0003(this);
			Func<RevisionInformation, bool> func8;
			if ((func8 = RevisionViewModel.<>c.\u0017) == null)
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
				func8 = (RevisionViewModel.<>c.\u0017 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0016\u0018));
			}
			IEnumerable<RevisionInformation> enumerable9 = Enumerable.Where<RevisionInformation>(enumerable8, func8);
			Func<RevisionInformation, long> func9;
			if ((func9 = RevisionViewModel.<>c.\u001E) == null)
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
				func9 = (RevisionViewModel.<>c.\u001E = new Func<RevisionInformation, long>(RevisionViewModel.<>c.\u000C.\u000F\u0018));
			}
			\u001A\u0006\u0016.\u0018(u2, Enumerable.ToList<long>(Enumerable.Select<RevisionInformation, long>(enumerable9, func9)));
			object u3 = u0009_u0015_u.\u0018;
			IEnumerable<RevisionInformation> enumerable10 = \u001E\u001A\u0016.\u0003(this);
			Func<RevisionInformation, bool> func10;
			if ((func10 = RevisionViewModel.<>c.\u0002) == null)
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
				func10 = (RevisionViewModel.<>c.\u0002 = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u0012\u0018));
			}
			IEnumerable<RevisionInformation> enumerable11 = Enumerable.Where<RevisionInformation>(enumerable10, func10);
			Func<RevisionInformation, string> func11;
			if ((func11 = RevisionViewModel.<>c.\u0004) == null)
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
				func11 = (RevisionViewModel.<>c.\u0004 = new Func<RevisionInformation, string>(RevisionViewModel.<>c.\u000C.\u000D\u0018));
			}
			\u001D\u000E\u0016.\u0018(u3, Enumerable.ToList<string>(Enumerable.Select<RevisionInformation, string>(enumerable11, func11)));
			\u0019\u0006\u0016.\u0018(u0009_u0015_u.\u0018, revisiondataProperty);
			if (\u0001\u0015\u0014.\u0018(u0009_u0015_u.\u000C) != \u0011\u000B\u0016.\u0003(this))
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
				int num = \u0011\u000B\u0016.\u0003(this) - \u0001\u0015\u0014.\u0018(u0009_u0015_u.\u000C);
				if (num < 0)
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
					num = \u0004\u000E\u0016.\u0018(num);
					for (int i = 0; i < num; i++)
					{
						\u0002\u000E\u0016.\u0018(u0009_u0015_u.\u000C, \u0001\u0015\u0014.\u0018(u0009_u0015_u.\u000C) - 1);
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
				}
				else
				{
					for (int j = 0; j < num; j++)
					{
						\u0019\u0017\u0014.\u0018(u0009_u0015_u.\u000C, string.Empty);
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
			}
			u0009_u0015_u.\u0014 = \u001E\u000E\u0016.\u0018();
			\u0017\u000E\u0016.\u0018(u0009_u0015_u.\u000C, new Action<string>(u0009_u0015_u.\u0009));
			\u0015\u000E\u0016.\u0018(u0009_u0015_u.\u0018, u0009_u0015_u.\u0014);
			\u000D\u001D\u0016.\u0018(\u0002\u0002\u0016.\u0018(), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\RevisionViewModel.cs", "UpdateProperty");
			return u0009_u0015_u.\u0018;
		}

		// Token: 0x06000DA3 RID: 3491 RVA: 0x000502E8 File Offset: 0x0004E4E8
		[BindableMethod("ChangeInMaxRevision")]
		public void ChangeInMaxRevision()
		{
			\u000B\u000E\u0016.\u0018(this, \u0011\u000B\u0016.\u0003(this));
			if (Enumerable.Any<RevisionData>(\u0019\u0005\u0016.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.ChangeInMaxRevision()).MethodHandle;
				}
				if (\u0011\u000B\u0016.\u0003(this) > 0)
				{
					List<RevisionData> u000C = \u0001\u0005\u0016.\u0018();
					IEnumerator<RevisionData> enumerator = \u0008\u0005\u0016.\u0018(\u0019\u0005\u0016.\u0018(this));
					try
					{
						while (\u001F\u001E\u0018.\u0018(enumerator))
						{
							RevisionData revisionData = \u0006\u0005\u0016.\u0018(enumerator);
							if (\u0014\u000E\u0016.\u0018(\u0003\u000E\u0016.\u0014(revisionData)) != \u0011\u000B\u0016.\u0003(this))
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
								int num = \u0011\u000B\u0016.\u0003(this) - \u0014\u000E\u0016.\u0018(\u0003\u000E\u0016.\u0014(revisionData));
								if (num < 0)
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
									num = \u0004\u000E\u0016.\u0018(num);
									for (int i = 0; i < num; i++)
									{
										\u001A\u000E\u0016.\u0018(\u0003\u000E\u0016.\u0014(revisionData), \u0014\u000E\u0016.\u0018(\u0003\u000E\u0016.\u0014(revisionData)) - 1);
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
								else
								{
									\u0015\u000E\u0016.\u0018(revisionData, \u001E\u000E\u0016.\u0018());
									\u0007\u0010\u0016.\u0003(this, revisionData, \u0010\u0005\u0016.\u0018(revisionData));
								}
							}
							\u0007\u0005\u0016.\u0018(u000C, revisionData);
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
							\u0020\u001E\u0018.\u0018(enumerator);
						}
					}
					\u001D\u0010\u0016.\u0003(this, \u0004\u0010\u0016.\u0018(u000C));
					\u0002\u0010\u0016.\u0014(\u0002\u000B\u0016.\u0003(this), \u0019\u0005\u0016.\u0018(this));
					return;
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
		}

		// Token: 0x06000DA4 RID: 3492 RVA: 0x0005047C File Offset: 0x0004E67C
		[BindableMethod("NumberValidationOnPreviewTextInput")]
		public void NumberValidationOnPreviewTextInput(TextCompositionEventArgs e)
		{
			Regex u000C = \u000D\u0009\u0014.\u0018("[^0-9]+");
			\u001D\u000B\u0018.\u0018(e, \u0012\u0009\u0014.\u0018(u000C, \u000E\u0020\u0003.\u0018(e)));
		}

		// Token: 0x06000DA5 RID: 3493 RVA: 0x000504AC File Offset: 0x0004E6AC
		[BindableMethod("TextValidationOnPreviewTextInput")]
		public void TextValidationOnPreviewTextInput(TextCompositionEventArgs e)
		{
			bool u;
			if (!\u001F\u001A\u0018.\u0018(\u000E\u0020\u0003.\u0018(e)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.TextValidationOnPreviewTextInput(TextCompositionEventArgs)).MethodHandle;
				}
				u = \u001F\u000B\u0018.\u0018(\u000E\u0020\u0003.\u0018(e));
			}
			else
			{
				u = true;
			}
			\u001D\u000B\u0018.\u0018(e, u);
		}

		// Token: 0x06000DA6 RID: 3494 RVA: 0x000504F8 File Offset: 0x0004E6F8
		public void UpdateStatus()
		{
			string u000C = \u0007\u000E\u0016.\u0018();
			object u = \u001B\u0005\u0016.\u0018(\u001E\u001A\u0016.\u0003(this));
			IEnumerable<RevisionInformation> enumerable = \u001E\u001A\u0016.\u0003(this);
			Func<RevisionInformation, bool> func;
			if ((func = RevisionViewModel.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevisionViewModel.UpdateStatus()).MethodHandle;
				}
				func = (RevisionViewModel.<>c.\u001D = new Func<RevisionInformation, bool>(RevisionViewModel.<>c.\u000C.\u001C\u0018));
			}
			string u2 = \u001A\u001E\u0018.\u0018(u000C, u, Enumerable.Count<RevisionInformation>(enumerable, func));
			\u0019\u000E\u0016.\u0018(this, u2);
		}

		// Token: 0x040005FB RID: 1531
		private ICollectionView \u001D\u0016;

		// Token: 0x040005FC RID: 1532
		private ICollectionView \u001A\u0016;

		// Token: 0x040005FD RID: 1533
		private ObservableCollection<RevisionData> \u000B\u0016;

		// Token: 0x040005FE RID: 1534
		private string \u001B\u0003;

		// Token: 0x040005FF RID: 1535
		private bool? \u001E\u0018;

		// Token: 0x04000600 RID: 1536
		private bool \u0013;

		// Token: 0x04000601 RID: 1537
		private bool \u0019\u0016;

		// Token: 0x04000602 RID: 1538
		private string \u000E\u0003;

		// Token: 0x04000603 RID: 1539
		private int \u0007\u0016;

		// Token: 0x04000604 RID: 1540
		private IList<RevisionInformation> \u0010\u0016;

		// Token: 0x04000605 RID: 1541
		private RevisionData \u0006\u0016;

		// Token: 0x04000606 RID: 1542
		private RevisionData \u0008\u0016;

		// Token: 0x04000607 RID: 1543
		private RevisionData \u0001\u0016;

		// Token: 0x04000608 RID: 1544
		private RevisionData \u001B\u0016;

		// Token: 0x04000609 RID: 1545
		private RevisionData \u0005\u0016;

		// Token: 0x0400060A RID: 1546
		private RevisionData \u000E\u0016;

		// Token: 0x0400060B RID: 1547
		private RevisionData \u000C\u000F;

		// Token: 0x0400060C RID: 1548
		private bool \u0018\u000F;

		// Token: 0x0400060D RID: 1549
		private string \u0014\u000F;

		// Token: 0x0400060E RID: 1550
		private RevisionNumbering \u0003\u000F;

		// Token: 0x0400060F RID: 1551
		private string \u0016\u000F;

		// Token: 0x04000610 RID: 1552
		[CompilerGenerated]
		private RevisionDataOrderChange \u000F\u000F;

		// Token: 0x04000611 RID: 1553
		[CompilerGenerated]
		private int \u0012\u000F;

		// Token: 0x04000612 RID: 1554
		[CompilerGenerated]
		private List<RevisionInformation> \u000D\u000F;

		// Token: 0x04000613 RID: 1555
		[CompilerGenerated]
		private List<string> \u001C\u000F;

		// Token: 0x02000203 RID: 515
		[CompilerGenerated]
		private sealed class \u001C\u0015\u0018
		{
			// Token: 0x060012C0 RID: 4800 RVA: 0x00060BC8 File Offset: 0x0005EDC8
			internal bool \u0018(RevisionInformation \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0002\u0006\u0016.\u0018(\u000C), \u0002\u0006\u0016.\u0018(this.\u000C));
			}

			// Token: 0x060012C1 RID: 4801 RVA: 0x00060BF4 File Offset: 0x0005EDF4
			internal bool \u0014(RevisionInformation \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u0002\u0006\u0016.\u0018(\u000C), \u0002\u0006\u0016.\u0018(this.\u000C));
			}

			// Token: 0x0400093B RID: 2363
			public RevisionInformation \u000C;
		}

		// Token: 0x02000204 RID: 516
		[CompilerGenerated]
		private sealed class \u0013\u0015\u0018
		{
			// Token: 0x060012C3 RID: 4803 RVA: 0x00060C34 File Offset: 0x0005EE34
			internal bool \u0018(RevisionData \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u000E\u0016.\u0014(\u000C), \u001F\u000E\u0016.\u0014(this.\u000C));
			}

			// Token: 0x060012C4 RID: 4804 RVA: 0x00060C60 File Offset: 0x0005EE60
			internal bool \u0014(RevisionData \u000C)
			{
				return \u000F\u0002\u0018.\u0018(\u001F\u000E\u0016.\u0014(\u000C), \u001F\u000E\u0016.\u0014(this.\u000C));
			}

			// Token: 0x0400093C RID: 2364
			public RevisionData \u000C;
		}

		// Token: 0x02000205 RID: 517
		[CompilerGenerated]
		private sealed class \u0009\u0015\u0018
		{
			// Token: 0x060012C6 RID: 4806 RVA: 0x00060CA0 File Offset: 0x0005EEA0
			internal void \u0003(RevisionInformation \u000C)
			{
				object u000C = this.\u000C;
				int num = \u0017\u0002\u0016.\u0003(\u000C);
				\u0019\u0017\u0014.\u0018(u000C, \u0010\u001E\u0018.\u0018(ref num));
			}

			// Token: 0x060012C7 RID: 4807 RVA: 0x00060CCC File Offset: 0x0005EECC
			internal void \u0016(RevisionInformation \u000C)
			{
				\u0019\u0017\u0014.\u0018(this.\u000C, \u0001\u0017\u0018.\u0018(\u0014\u001E\u000F.\u0018(\u000C)));
			}

			// Token: 0x060012C8 RID: 4808 RVA: 0x00060CF4 File Offset: 0x0005EEF4
			internal void \u000F(RevisionInformation \u000C)
			{
				\u0019\u0017\u0014.\u0018(this.\u000C, \u0001\u0017\u0018.\u0018(\u0015\u0002\u0016.\u0003(\u000C)));
			}

			// Token: 0x060012C9 RID: 4809 RVA: 0x00060D1C File Offset: 0x0005EF1C
			internal void \u0012(RevisionInformation \u000C)
			{
				\u0019\u0017\u0014.\u0018(this.\u000C, \u0001\u0017\u0018.\u0018(\u0003\u001E\u000F.\u0018(\u000C)));
			}

			// Token: 0x060012CA RID: 4810 RVA: 0x00060D44 File Offset: 0x0005EF44
			internal void \u000D(RevisionInformation \u000C)
			{
				\u0019\u0017\u0014.\u0018(this.\u000C, \u0001\u0017\u0018.\u0018(\u0016\u001E\u000F.\u0018(\u000C)));
			}

			// Token: 0x060012CB RID: 4811 RVA: 0x00060D6C File Offset: 0x0005EF6C
			internal void \u001C(RevisionInformation \u000C)
			{
				\u0019\u0017\u0014.\u0018(this.\u000C, \u0001\u0017\u0018.\u0018(\u0020\u0005\u0016.\u0018(\u000C)));
			}

			// Token: 0x060012CC RID: 4812 RVA: 0x00060D94 File Offset: 0x0005EF94
			internal void \u0013(RevisionInformation \u000C)
			{
				\u0019\u0017\u0014.\u0018(this.\u000C, \u0001\u0017\u0018.\u0018(\u000F\u001E\u000F.\u0018(\u000C)));
			}

			// Token: 0x060012CD RID: 4813 RVA: 0x00060DBC File Offset: 0x0005EFBC
			internal void \u0009(string \u000C)
			{
				RevisionValue revisionValue = \u000D\u001E\u000F.\u0018();
				\u001B\u0017\u000F.\u0018(revisionValue, \u000C);
				\u0002\u0016\u000F.\u0018(revisionValue, \u0017\u0016\u000F.\u0003(this.\u0018));
				RevisionValue u = revisionValue;
				\u0012\u001E\u000F.\u0018(this.\u0014, u);
			}

			// Token: 0x0400093D RID: 2365
			public List<string> \u000C;

			// Token: 0x0400093E RID: 2366
			public RevisionData \u0018;

			// Token: 0x0400093F RID: 2367
			public List<RevisionValue> \u0014;
		}
	}
}
