using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Enums;
using ProSheets.Helpers;

namespace ProSheets.Models
{
	// Token: 0x020000FE RID: 254
	[Serializable]
	public class SheetInfo : ISetViewInfo, IEquatable<SheetInfo>, INotifyPropertyChanged
	{
		// Token: 0x06000C23 RID: 3107 RVA: 0x00049324 File Offset: 0x00047524
		public SheetInfo()
		{
			\u0015\u0004\u0016.\u0018(this, new List<string>());
			\u0011\u0004\u0016.\u0018(this, new Dictionary<string, string>());
		}

		// Token: 0x1400001C RID: 28
		// (add) Token: 0x06000C24 RID: 3108 RVA: 0x00049354 File Offset: 0x00047554
		// (remove) Token: 0x06000C25 RID: 3109 RVA: 0x000493A0 File Offset: 0x000475A0
		public static event SheetInfo.CheckedOrUncheckedHandler CheckedOrUnchecked
		{
			[CompilerGenerated]
			add
			{
				SheetInfo.CheckedOrUncheckedHandler checkedOrUncheckedHandler = SheetInfo.\u000C;
				SheetInfo.CheckedOrUncheckedHandler checkedOrUncheckedHandler2;
				do
				{
					checkedOrUncheckedHandler2 = checkedOrUncheckedHandler;
					SheetInfo.CheckedOrUncheckedHandler value2 = (SheetInfo.CheckedOrUncheckedHandler)\u001C\u0019\u0018.\u0018(checkedOrUncheckedHandler2, value);
					checkedOrUncheckedHandler = Interlocked.CompareExchange<SheetInfo.CheckedOrUncheckedHandler>(ref SheetInfo.\u000C, value2, checkedOrUncheckedHandler2);
				}
				while (checkedOrUncheckedHandler != checkedOrUncheckedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.add_CheckedOrUnchecked(SheetInfo.CheckedOrUncheckedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				SheetInfo.CheckedOrUncheckedHandler checkedOrUncheckedHandler = SheetInfo.\u000C;
				SheetInfo.CheckedOrUncheckedHandler checkedOrUncheckedHandler2;
				do
				{
					checkedOrUncheckedHandler2 = checkedOrUncheckedHandler;
					SheetInfo.CheckedOrUncheckedHandler value2 = (SheetInfo.CheckedOrUncheckedHandler)\u0013\u0019\u0018.\u0018(checkedOrUncheckedHandler2, value);
					checkedOrUncheckedHandler = Interlocked.CompareExchange<SheetInfo.CheckedOrUncheckedHandler>(ref SheetInfo.\u000C, value2, checkedOrUncheckedHandler2);
				}
				while (checkedOrUncheckedHandler != checkedOrUncheckedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.remove_CheckedOrUnchecked(SheetInfo.CheckedOrUncheckedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x000493EC File Offset: 0x000475EC
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x00049400 File Offset: 0x00047600
		public string FamilyAndTypeName { get; set; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06000C28 RID: 3112 RVA: 0x00049414 File Offset: 0x00047614
		// (set) Token: 0x06000C29 RID: 3113 RVA: 0x00049428 File Offset: 0x00047628
		public string Name { get; set; }

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06000C2A RID: 3114 RVA: 0x0004943C File Offset: 0x0004763C
		// (set) Token: 0x06000C2B RID: 3115 RVA: 0x00049450 File Offset: 0x00047650
		public string CustomParamValue { get; set; }

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06000C2C RID: 3116 RVA: 0x00049464 File Offset: 0x00047664
		// (set) Token: 0x06000C2D RID: 3117 RVA: 0x00049478 File Offset: 0x00047678
		private string _CustomDrawingNumber { get; set; }

		// Token: 0x17000444 RID: 1092
		// (get) Token: 0x06000C2E RID: 3118 RVA: 0x0004948C File Offset: 0x0004768C
		// (set) Token: 0x06000C2F RID: 3119 RVA: 0x000494A0 File Offset: 0x000476A0
		[XmlIgnore]
		public ElementId Id { get; set; }

		// Token: 0x17000445 RID: 1093
		// (get) Token: 0x06000C30 RID: 3120 RVA: 0x000494B4 File Offset: 0x000476B4
		// (set) Token: 0x06000C31 RID: 3121 RVA: 0x000494C8 File Offset: 0x000476C8
		public long ElementId { get; set; }

		// Token: 0x17000446 RID: 1094
		// (get) Token: 0x06000C32 RID: 3122 RVA: 0x000494DC File Offset: 0x000476DC
		// (set) Token: 0x06000C33 RID: 3123 RVA: 0x000494F0 File Offset: 0x000476F0
		public string Revision { get; set; }

		// Token: 0x17000447 RID: 1095
		// (get) Token: 0x06000C34 RID: 3124 RVA: 0x00049504 File Offset: 0x00047704
		// (set) Token: 0x06000C35 RID: 3125 RVA: 0x00049518 File Offset: 0x00047718
		public string SheetSizeInFileName { get; set; }

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06000C36 RID: 3126 RVA: 0x0004952C File Offset: 0x0004772C
		// (set) Token: 0x06000C37 RID: 3127 RVA: 0x00049540 File Offset: 0x00047740
		public string SheetSize { get; set; }

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06000C38 RID: 3128 RVA: 0x00049554 File Offset: 0x00047754
		// (set) Token: 0x06000C39 RID: 3129 RVA: 0x00049568 File Offset: 0x00047768
		public string NewSheetSize { get; set; }

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x06000C3A RID: 3130 RVA: 0x0004957C File Offset: 0x0004777C
		// (set) Token: 0x06000C3B RID: 3131 RVA: 0x00049590 File Offset: 0x00047790
		public DateTime ExportStartTime { get; set; }

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x06000C3C RID: 3132 RVA: 0x000495A4 File Offset: 0x000477A4
		// (set) Token: 0x06000C3D RID: 3133 RVA: 0x000495B8 File Offset: 0x000477B8
		public DateTime ExportEndTime { get; set; }

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x06000C3E RID: 3134 RVA: 0x000495CC File Offset: 0x000477CC
		// (set) Token: 0x06000C3F RID: 3135 RVA: 0x000495E0 File Offset: 0x000477E0
		public string ExportFilePath { get; set; }

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x000495F4 File Offset: 0x000477F4
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x00049608 File Offset: 0x00047808
		public string ExportFileName { get; set; }

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x0004961C File Offset: 0x0004781C
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x00049630 File Offset: 0x00047830
		public string Format { get; set; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x00049644 File Offset: 0x00047844
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x00049658 File Offset: 0x00047858
		public string _Notes { get; set; }

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x0004966C File Offset: 0x0004786C
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x00049680 File Offset: 0x00047880
		public string Orientation { get; set; }

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x00049694 File Offset: 0x00047894
		// (set) Token: 0x06000C49 RID: 3145 RVA: 0x000496A8 File Offset: 0x000478A8
		public string NewPDFOrientation { get; set; }

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x06000C4A RID: 3146 RVA: 0x000496BC File Offset: 0x000478BC
		// (set) Token: 0x06000C4B RID: 3147 RVA: 0x000496D0 File Offset: 0x000478D0
		public string NewDWFOrientation { get; set; }

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x06000C4C RID: 3148 RVA: 0x000496E4 File Offset: 0x000478E4
		// (set) Token: 0x06000C4D RID: 3149 RVA: 0x000496F8 File Offset: 0x000478F8
		public bool IsBrowserOrganizationFilter { get; set; } = true;

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06000C4E RID: 3150 RVA: 0x0004970C File Offset: 0x0004790C
		// (set) Token: 0x06000C4F RID: 3151 RVA: 0x00049720 File Offset: 0x00047920
		[XmlIgnore]
		public Dictionary<string, string> CustomParamWithColumns { get; set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06000C50 RID: 3152 RVA: 0x00049734 File Offset: 0x00047934
		// (set) Token: 0x06000C51 RID: 3153 RVA: 0x00049748 File Offset: 0x00047948
		public string ExportFolderSelectionPath { get; set; }

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06000C52 RID: 3154 RVA: 0x0004975C File Offset: 0x0004795C
		// (set) Token: 0x06000C53 RID: 3155 RVA: 0x00049774 File Offset: 0x00047974
		public string Notes
		{
			get
			{
				return \u0017\u0004\u0016.\u0018(this);
			}
			set
			{
				\u0002\u0004\u0016.\u0018(this, value);
				\u001E\u0004\u0016.\u0018(this, "");
			}
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06000C54 RID: 3156 RVA: 0x00049794 File Offset: 0x00047994
		// (set) Token: 0x06000C55 RID: 3157 RVA: 0x000497A8 File Offset: 0x000479A8
		public PublishStatus Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
				\u001E\u0004\u0016.\u0018(this, "");
			}
		}

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06000C56 RID: 3158 RVA: 0x000497C8 File Offset: 0x000479C8
		// (set) Token: 0x06000C57 RID: 3159 RVA: 0x000497DC File Offset: 0x000479DC
		public string SheetNumber { get; set; }

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x06000C58 RID: 3160 RVA: 0x000497F0 File Offset: 0x000479F0
		// (set) Token: 0x06000C59 RID: 3161 RVA: 0x00049808 File Offset: 0x00047A08
		public string CustomDrawingNumber
		{
			get
			{
				return \u0004\u0004\u0016.\u0018(this);
			}
			set
			{
				\u001D\u0004\u0016.\u0018(this, value);
				\u001E\u0004\u0016.\u0018(this, "");
			}
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x06000C5A RID: 3162 RVA: 0x00049828 File Offset: 0x00047A28
		// (set) Token: 0x06000C5B RID: 3163 RVA: 0x0004983C File Offset: 0x00047A3C
		public string Scale { get; set; }

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x00049850 File Offset: 0x00047A50
		// (set) Token: 0x06000C5D RID: 3165 RVA: 0x00049864 File Offset: 0x00047A64
		public string DetailLevel { get; set; }

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x00049878 File Offset: 0x00047A78
		// (set) Token: 0x06000C5F RID: 3167 RVA: 0x0004988C File Offset: 0x00047A8C
		public string Discipline { get; set; }

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x06000C60 RID: 3168 RVA: 0x000498A0 File Offset: 0x00047AA0
		// (set) Token: 0x06000C61 RID: 3169 RVA: 0x000498B4 File Offset: 0x00047AB4
		public bool IsChecked
		{
			get
			{
				return this._Checked;
			}
			set
			{
				this._Checked = value;
				if (SheetInfo.\u000C != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.set_IsChecked(bool)).MethodHandle;
					}
					\u001A\u0004\u0016.\u0018(SheetInfo.\u000C, this, value);
				}
				\u001E\u0004\u0016.\u0018(this, "");
			}
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000C62 RID: 3170 RVA: 0x000498FC File Offset: 0x00047AFC
		// (set) Token: 0x06000C63 RID: 3171 RVA: 0x00049910 File Offset: 0x00047B10
		public bool IsCheckedOnCreate
		{
			get
			{
				return this._isCheckedOnCreate;
			}
			set
			{
				this._isCheckedOnCreate = value;
				\u001E\u0004\u0016.\u0018(this, "");
			}
		}

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000C64 RID: 3172 RVA: 0x00049930 File Offset: 0x00047B30
		// (set) Token: 0x06000C65 RID: 3173 RVA: 0x00049944 File Offset: 0x00047B44
		[XmlIgnore]
		public ViewType ViewTypeEnum { get; set; }

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000C66 RID: 3174 RVA: 0x00049958 File Offset: 0x00047B58
		public string ViewType
		{
			get
			{
				return \u0014\u0004\u0014.\u0003(this).\u000C();
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x00049974 File Offset: 0x00047B74
		public string OrderingType
		{
			get
			{
				if (!\u001F\u001A\u0018.\u0018(\u0014\u000C\u0014.\u0003(this)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.get_OrderingType()).MethodHandle;
					}
					if (\u000B\u0004\u0016.\u0018(\u0014\u000C\u0014.\u0003(this), \u000D\u0009\u0018.\u0008) != 0)
					{
						return \u000D\u001E\u0018.\u0018(\u0014\u000C\u0014.\u0003(this), " View");
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
				return "Sheet";
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000C68 RID: 3176 RVA: 0x000499E4 File Offset: 0x00047BE4
		public string OrderingNumber
		{
			get
			{
				if (\u000F\u0002\u0018.\u0018(\u000A\u0013\u0003.\u0003(this), "Sheet"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.get_OrderingNumber()).MethodHandle;
					}
					return \u001E\u000E\u0018.\u0003(this);
				}
				return "N/A";
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000C69 RID: 3177 RVA: 0x00049A28 File Offset: 0x00047C28
		public string OrderingName
		{
			get
			{
				if (\u000F\u0002\u0018.\u0018(\u000A\u0013\u0003.\u0003(this), "Sheet"))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.get_OrderingName()).MethodHandle;
					}
					return \u0002\u000E\u0018.\u0003(this);
				}
				return \u0014\u001E\u0018.\u0018(\u0014\u000C\u0014.\u0003(this), " - ", \u0002\u000E\u0018.\u0003(this));
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000C6A RID: 3178 RVA: 0x00049A84 File Offset: 0x00047C84
		// (set) Token: 0x06000C6B RID: 3179 RVA: 0x00049A98 File Offset: 0x00047C98
		public bool IsSelected { get; set; }

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x00049AAC File Offset: 0x00047CAC
		// (set) Token: 0x06000C6D RID: 3181 RVA: 0x00049AC0 File Offset: 0x00047CC0
		public List<string> ViewSetName { get; set; }

		// Token: 0x1400001D RID: 29
		// (add) Token: 0x06000C6E RID: 3182 RVA: 0x00049AD4 File Offset: 0x00047CD4
		// (remove) Token: 0x06000C6F RID: 3183 RVA: 0x00049B24 File Offset: 0x00047D24
		public event PropertyChangedEventHandler PropertyChanged
		{
			[CompilerGenerated]
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = \u0011\u0007\u000F.\u000C(\u001C\u0019\u0018.\u0018(propertyChangedEventHandler2, value));
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.add_PropertyChanged(PropertyChangedEventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = \u0011\u0007\u000F.\u000C(\u0013\u0019\u0018.\u0018(propertyChangedEventHandler2, value));
					propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.PropertyChanged, value2, propertyChangedEventHandler2);
				}
				while (propertyChangedEventHandler != propertyChangedEventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.remove_PropertyChanged(PropertyChangedEventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x00049B74 File Offset: 0x00047D74
		protected void OnPropertyChanged(string name = "")
		{
			PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
			if (propertyChanged != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.OnPropertyChanged(string)).MethodHandle;
				}
				\u0006\u001B\u0003.\u0018(propertyChanged, this, \u0008\u001B\u0003.\u0018(name));
			}
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00049BB0 File Offset: 0x00047DB0
		public override bool Equals(object obj)
		{
			return \u0019\u0004\u0016.\u0018(this, \u0003\u001D\u000F.\u000C(obj));
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x00049BD0 File Offset: 0x00047DD0
		public bool Equals(SheetInfo other)
		{
			if (other != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.Equals(SheetInfo)).MethodHandle;
				}
				if (\u001B\u000F\u0014.\u0018(\u0015\u0005\u0018.\u0003(this), \u0015\u0005\u0018.\u0014(other)))
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
					return \u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0003(this), \u0010\u0020\u0014.\u0014(other));
				}
			}
			return false;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x00049C30 File Offset: 0x00047E30
		public string GetFilePath(View view, string rootPath, string subFolder, string fileNameWithouExtension, string fileExtension, bool splitFlag)
		{
			string text = \u001E\u001B\u0014.\u0018(\u0010\u000B\u0014.\u0018(fileNameWithouExtension, "./", "--"), '/', '-');
			text = \u000D\u001E\u0018.\u0018(text, fileExtension);
			string text2 = this.\u0018(rootPath);
			IEnumerator u000C = \u000C\u0007\u0014.\u0018(\u0018\u0007\u0014.\u0018(text2, "%[^%]+%"));
			try
			{
				while (\u001F\u001E\u0018.\u0018(u000C))
				{
					Match u000C2 = \u000C\u000B\u000F.\u000C(\u0003\u000F\u0014.\u0018(u000C));
					text2 = \u0010\u000B\u0014.\u0018(text2, \u0005\u0019\u0014.\u0018(u000C2), \u000C\u000A\u0018.\u0008(\u000E\u0002\u0016.\u0018(view), view, \u0010\u000B\u0014.\u0018(\u0005\u0019\u0014.\u0018(u000C2), "%", "")));
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.GetFilePath(View, string, string, string, string, bool)).MethodHandle;
				}
			}
			finally
			{
				IDisposable disposable = \u000D\u001D\u000F.\u000C(u000C);
				if (disposable != null)
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
					\u0020\u001E\u0018.\u0018(disposable);
				}
			}
			string text3;
			if (!splitFlag)
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
				text3 = text2;
			}
			else
			{
				text3 = \u0003\u001A\u0018.\u0018(text2, subFolder);
			}
			string text4 = text3;
			text4 = \u0003\u001A\u0018.\u0018(text4, text);
			\u0007\u0006\u0014.\u0003(this, text);
			\u0006\u0006\u0014.\u0003(this, text4);
			\u0018\u0017\u0014.\u0003(this, "");
			if (\u001C\u0002\u0018.\u0014(\u0014\u001B\u0014.\u0003(this)) > 259)
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
				\u0018\u0017\u0014.\u0003(this, \u001C\u0009\u0018.\u000E\u0014);
			}
			try
			{
				\u0015\u001B\u0014.\u0018(text4);
			}
			catch (Exception ex)
			{
				\u0018\u0017\u0014.\u0003(this, \u000A\u0001\u0018.\u0018(ex));
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Models\\CustomItem.cs", "GetFilePath");
			}
			return text4;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x00049DD0 File Offset: 0x00047FD0
		private string \u0018(string \u000C)
		{
			if (!\u001F\u000B\u0018.\u0018(\u000D\u000C\u0003.\u0003(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.\u0018(string)).MethodHandle;
				}
				return \u000D\u000C\u0003.\u0003(this);
			}
			return \u000C;
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x00049E0C File Offset: 0x0004800C
		public override int GetHashCode()
		{
			string text;
			if ((text = \u0010\u0020\u0014.\u0003(this)) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetInfo.GetHashCode()).MethodHandle;
				}
				text = "";
			}
			string u000C = text;
			long num = \u0015\u0005\u0018.\u0003(this).\u000C();
			return \u0004\u001B\u0018.\u0018(ref num) ^ \u0002\u001B\u0018.\u0018(u000C);
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x00049E60 File Offset: 0x00048060
		internal bool \u0014()
		{
			return \u000F\u0002\u0018.\u0018(\u0011\u0017\u0014.\u0003(this), "Landscape");
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00049E84 File Offset: 0x00048084
		internal bool \u0003()
		{
			return \u000F\u0002\u0018.\u0018(\u0010\u0020\u0014.\u0003(this), "PDF");
		}

		// Token: 0x04000594 RID: 1428
		[CompilerGenerated]
		private static SheetInfo.CheckedOrUncheckedHandler \u000C;

		// Token: 0x040005AB RID: 1451
		public PublishStatus _status;

		// Token: 0x040005B0 RID: 1456
		private bool _Checked;

		// Token: 0x040005B1 RID: 1457
		private bool _isCheckedOnCreate;

		// Token: 0x020001F2 RID: 498
		// (Invoke) Token: 0x06001253 RID: 4691
		public delegate void CheckedOrUncheckedHandler(SheetInfo sender, bool IsChecked);
	}
}
