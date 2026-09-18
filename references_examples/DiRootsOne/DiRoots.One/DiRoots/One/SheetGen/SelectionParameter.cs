using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Models;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002B5 RID: 693
	[Serializable]
	public class SelectionParameter : BaseParameter, IEquatable<SelectionParameter>
	{
		// Token: 0x06001B25 RID: 6949 RVA: 0x000B0BCC File Offset: 0x000AEDCC
		public SelectionParameter()
		{
			\u0019\u0012\u0016.\u0007(this, \u0002\u0005\u0018.\u000A().ToString());
		}

		// Token: 0x06001B26 RID: 6950 RVA: 0x000B0BFC File Offset: 0x000AEDFC
		public SelectionParameter(Parameter param, SelectionParameterType parameterType = SelectionParameterType.Sheet) : this()
		{
			\u000B\u0012\u0016.\u0007(this, \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(param)));
			\u0016\u0012\u0016.\u0007(this, \u0011\u001F\u001D.\u0007(param));
			\u0005\u0012\u0016.\u0007(this, parameterType);
			\u0018\u0012\u0016.\u0007(this, \u0004\u0016\u0016.\u000A(\u000F\u0003\u000E.\u001F(\u0020\u001F\u001D.\u0007(param))));
		}

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x06001B27 RID: 6951 RVA: 0x000B0C58 File Offset: 0x000AEE58
		// (set) Token: 0x06001B28 RID: 6952 RVA: 0x000B0C6C File Offset: 0x000AEE6C
		public string GUID { get; set; }

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x06001B29 RID: 6953 RVA: 0x000B0C80 File Offset: 0x000AEE80
		// (set) Token: 0x06001B2A RID: 6954 RVA: 0x000B0C94 File Offset: 0x000AEE94
		[XmlIgnore]
		public BuiltInParameter BuiltinParameter { get; set; }

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x06001B2B RID: 6955 RVA: 0x000B0CA8 File Offset: 0x000AEEA8
		// (set) Token: 0x06001B2C RID: 6956 RVA: 0x000B0CD0 File Offset: 0x000AEED0
		[XmlElement("BuiltinParameter")]
		public string BuiltinParameterAsString
		{
			get
			{
				return \u0008\u000F\u0016.\u001D(this).ToString();
			}
			set
			{
				BuiltInParameter u000A;
				if (Enum.TryParse<BuiltInParameter>(value, out u000A))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.set_BuiltinParameterAsString(string)).MethodHandle;
					}
					\u0018\u0012\u0016.\u0007(this, u000A);
					return;
				}
				\u0018\u0012\u0016.\u0007(this, -1L);
			}
		}

		// Token: 0x1700076F RID: 1903
		// (get) Token: 0x06001B2D RID: 6957 RVA: 0x000B0D0C File Offset: 0x000AEF0C
		// (set) Token: 0x06001B2E RID: 6958 RVA: 0x000B0D20 File Offset: 0x000AEF20
		public SelectionParameterType Type { get; set; }

		// Token: 0x17000770 RID: 1904
		// (get) Token: 0x06001B2F RID: 6959 RVA: 0x000B0D34 File Offset: 0x000AEF34
		// (set) Token: 0x06001B30 RID: 6960 RVA: 0x000B0D48 File Offset: 0x000AEF48
		public string Schedule { get; set; }

		// Token: 0x17000771 RID: 1905
		// (get) Token: 0x06001B31 RID: 6961 RVA: 0x000B0D5C File Offset: 0x000AEF5C
		// (set) Token: 0x06001B32 RID: 6962 RVA: 0x000B0D70 File Offset: 0x000AEF70
		public bool IsSelected { get; set; }

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06001B33 RID: 6963 RVA: 0x000B0D84 File Offset: 0x000AEF84
		// (set) Token: 0x06001B34 RID: 6964 RVA: 0x000B0D98 File Offset: 0x000AEF98
		public bool IsBoolean { get; set; }

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06001B35 RID: 6965 RVA: 0x000B0DAC File Offset: 0x000AEFAC
		// (set) Token: 0x06001B36 RID: 6966 RVA: 0x000B0DC0 File Offset: 0x000AEFC0
		public bool IsViewOrientation { get; set; }

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x06001B37 RID: 6967 RVA: 0x000B0DD4 File Offset: 0x000AEFD4
		// (set) Token: 0x06001B38 RID: 6968 RVA: 0x000B0DE8 File Offset: 0x000AEFE8
		public bool IsViewDiscipline { get; set; }

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x06001B39 RID: 6969 RVA: 0x000B0DFC File Offset: 0x000AEFFC
		// (set) Token: 0x06001B3A RID: 6970 RVA: 0x000B0E10 File Offset: 0x000AF010
		public bool IsViewTemplate { get; set; }

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x06001B3B RID: 6971 RVA: 0x000B0E24 File Offset: 0x000AF024
		// (set) Token: 0x06001B3C RID: 6972 RVA: 0x000B0E38 File Offset: 0x000AF038
		public bool IsDetailLevel { get; set; }

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06001B3D RID: 6973 RVA: 0x000B0E4C File Offset: 0x000AF04C
		// (set) Token: 0x06001B3E RID: 6974 RVA: 0x000B0E60 File Offset: 0x000AF060
		public bool IsScopeBox { get; set; }

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06001B3F RID: 6975 RVA: 0x000B0E74 File Offset: 0x000AF074
		// (set) Token: 0x06001B40 RID: 6976 RVA: 0x000B0E88 File Offset: 0x000AF088
		public bool IsFarClipping { get; set; }

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06001B41 RID: 6977 RVA: 0x000B0E9C File Offset: 0x000AF09C
		// (set) Token: 0x06001B42 RID: 6978 RVA: 0x000B0EB0 File Offset: 0x000AF0B0
		public bool IsVisualStyle { get; set; }

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06001B43 RID: 6979 RVA: 0x000B0EC4 File Offset: 0x000AF0C4
		// (set) Token: 0x06001B44 RID: 6980 RVA: 0x000B0ED8 File Offset: 0x000AF0D8
		public bool IsPartVisiblity { get; set; }

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06001B45 RID: 6981 RVA: 0x000B0EEC File Offset: 0x000AF0EC
		// (set) Token: 0x06001B46 RID: 6982 RVA: 0x000B0F00 File Offset: 0x000AF100
		public bool IsDisplayModel { get; set; }

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06001B47 RID: 6983 RVA: 0x000B0F14 File Offset: 0x000AF114
		// (set) Token: 0x06001B48 RID: 6984 RVA: 0x000B0F28 File Offset: 0x000AF128
		public bool IsRotationOnSheet { get; set; }

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06001B49 RID: 6985 RVA: 0x000B0F3C File Offset: 0x000AF13C
		// (set) Token: 0x06001B4A RID: 6986 RVA: 0x000B0F50 File Offset: 0x000AF150
		public bool IsShowHiddenLines { get; set; }

		// Token: 0x1700077E RID: 1918
		// (get) Token: 0x06001B4B RID: 6987 RVA: 0x000B0F64 File Offset: 0x000AF164
		// (set) Token: 0x06001B4C RID: 6988 RVA: 0x000B0F78 File Offset: 0x000AF178
		public bool IsColorSchemaLocation { get; set; }

		// Token: 0x1700077F RID: 1919
		// (get) Token: 0x06001B4D RID: 6989 RVA: 0x000B0F8C File Offset: 0x000AF18C
		// (set) Token: 0x06001B4E RID: 6990 RVA: 0x000B0FA0 File Offset: 0x000AF1A0
		public bool IsWallJoinDisplay { get; set; }

		// Token: 0x17000780 RID: 1920
		// (get) Token: 0x06001B4F RID: 6991 RVA: 0x000B0FB4 File Offset: 0x000AF1B4
		// (set) Token: 0x06001B50 RID: 6992 RVA: 0x000B0FC8 File Offset: 0x000AF1C8
		public bool IsProjectModel { get; set; }

		// Token: 0x17000781 RID: 1921
		// (get) Token: 0x06001B51 RID: 6993 RVA: 0x000B0FDC File Offset: 0x000AF1DC
		// (set) Token: 0x06001B52 RID: 6994 RVA: 0x000B0FF0 File Offset: 0x000AF1F0
		public bool IsFarClipSettings { get; set; }

		// Token: 0x17000782 RID: 1922
		// (get) Token: 0x06001B53 RID: 6995 RVA: 0x000B1004 File Offset: 0x000AF204
		// (set) Token: 0x06001B54 RID: 6996 RVA: 0x000B1018 File Offset: 0x000AF218
		public bool ShowIn { get; set; }

		// Token: 0x17000783 RID: 1923
		// (get) Token: 0x06001B55 RID: 6997 RVA: 0x000B102C File Offset: 0x000AF22C
		// (set) Token: 0x06001B56 RID: 6998 RVA: 0x000B1040 File Offset: 0x000AF240
		public bool IsUnderlayOrientation { get; set; }

		// Token: 0x17000784 RID: 1924
		// (get) Token: 0x06001B57 RID: 6999 RVA: 0x000B1054 File Offset: 0x000AF254
		// (set) Token: 0x06001B58 RID: 7000 RVA: 0x000B1068 File Offset: 0x000AF268
		public bool IsPhases { get; set; }

		// Token: 0x17000785 RID: 1925
		// (get) Token: 0x06001B59 RID: 7001 RVA: 0x000B107C File Offset: 0x000AF27C
		// (set) Token: 0x06001B5A RID: 7002 RVA: 0x000B1090 File Offset: 0x000AF290
		public bool IsPhaseFilters { get; set; }

		// Token: 0x17000786 RID: 1926
		// (get) Token: 0x06001B5B RID: 7003 RVA: 0x000B10A4 File Offset: 0x000AF2A4
		// (set) Token: 0x06001B5C RID: 7004 RVA: 0x000B10B8 File Offset: 0x000AF2B8
		public bool IsRangeBaseLevel { get; set; }

		// Token: 0x17000787 RID: 1927
		// (get) Token: 0x06001B5D RID: 7005 RVA: 0x000B10CC File Offset: 0x000AF2CC
		// (set) Token: 0x06001B5E RID: 7006 RVA: 0x000B10E0 File Offset: 0x000AF2E0
		public bool IsRangeTopLevel { get; set; }

		// Token: 0x17000788 RID: 1928
		// (get) Token: 0x06001B5F RID: 7007 RVA: 0x000B10F4 File Offset: 0x000AF2F4
		// (set) Token: 0x06001B60 RID: 7008 RVA: 0x000B1108 File Offset: 0x000AF308
		public bool IsMaterial { get; set; }

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x06001B61 RID: 7009 RVA: 0x000B111C File Offset: 0x000AF31C
		// (set) Token: 0x06001B62 RID: 7010 RVA: 0x000B1130 File Offset: 0x000AF330
		public bool IsFillPattern { get; set; }

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06001B63 RID: 7011 RVA: 0x000B1144 File Offset: 0x000AF344
		// (set) Token: 0x06001B64 RID: 7012 RVA: 0x000B1158 File Offset: 0x000AF358
		public bool IsTitleBlock { get; set; }

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06001B65 RID: 7013 RVA: 0x000B116C File Offset: 0x000AF36C
		// (set) Token: 0x06001B66 RID: 7014 RVA: 0x000B1180 File Offset: 0x000AF380
		public StorageType Storage { get; set; }

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06001B67 RID: 7015 RVA: 0x000B1194 File Offset: 0x000AF394
		// (set) Token: 0x06001B68 RID: 7016 RVA: 0x000B11A8 File Offset: 0x000AF3A8
		public bool IsReadOnly { get; set; }

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06001B69 RID: 7017 RVA: 0x000B11BC File Offset: 0x000AF3BC
		public ParameterDataType ParameterDataType
		{
			get
			{
				if (\u001D\u0005\u0016.\u001D(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.get_ParameterDataType()).MethodHandle;
					}
					return ParameterDataType.Bool;
				}
				if (\u0015\u0012\u0016.\u0007(this))
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
					return ParameterDataType.ViewOrientation;
				}
				if (\u000C\u0012\u0016.\u0007(this))
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
					return ParameterDataType.ViewDiscipline;
				}
				if (\u000A\u0006\u0016.\u001D(this))
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
					return ParameterDataType.ViewTemplate;
				}
				if (\u001A\u0012\u0016.\u0007(this))
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
					return ParameterDataType.DetailLevel;
				}
				if (\u0009\u0002\u0016.\u001D(this))
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
					return ParameterDataType.ScopeBox;
				}
				if (\u0013\u0012\u0016.\u0007(this))
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
					return ParameterDataType.FarClipping;
				}
				if (\u0011\u000F\u0016.\u001D(this))
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
					return ParameterDataType.VisualStyle;
				}
				if (\u0014\u0012\u0016.\u0007(this))
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
					return ParameterDataType.PartVisiblity;
				}
				if (\u0017\u0012\u0016.\u0007(this))
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
					return ParameterDataType.DisplayModel;
				}
				if (\u0020\u0012\u0016.\u0007(this))
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
					return ParameterDataType.RotationOnSheet;
				}
				if (\u001E\u0012\u0016.\u0007(this))
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
					return ParameterDataType.ShowHiddenLines;
				}
				if (\u0011\u0012\u0016.\u0007(this))
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
					return ParameterDataType.ColorSchemaLocation;
				}
				if (\u001B\u0012\u0016.\u0007(this))
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
					return ParameterDataType.WallJoinDisplay;
				}
				if (\u0008\u0012\u0016.\u0007(this))
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
					return ParameterDataType.ProjectModel;
				}
				if (\u000E\u0012\u0016.\u0007(this))
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
					return ParameterDataType.FarClipSettings;
				}
				if (\u0010\u0012\u0016.\u0007(this))
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
					return ParameterDataType.ShowIn;
				}
				if (\u000D\u0012\u0016.\u0007(this))
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
					return ParameterDataType.UnderlayOrientation;
				}
				if (\u001C\u0012\u0016.\u0007(this))
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
					return ParameterDataType.Phases;
				}
				if (\u0003\u0012\u0016.\u0007(this))
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
					return ParameterDataType.PhaseFilters;
				}
				if (\u0012\u0012\u0016.\u0007(this))
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
					return ParameterDataType.RangeBaseLevel;
				}
				if (\u000F\u0012\u0016.\u0007(this))
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
					return ParameterDataType.RangeTopLevel;
				}
				if (\u0006\u0012\u0016.\u0007(this))
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
					return ParameterDataType.Material;
				}
				if (\u0002\u0012\u0016.\u0007(this))
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
					return ParameterDataType.FillPattern;
				}
				if (\u000F\u000F\u0016.\u0007(this))
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
					return ParameterDataType.TitleBlock;
				}
				return ParameterDataType.Other;
			}
		}

		// Token: 0x1700078E RID: 1934
		// (get) Token: 0x06001B6A RID: 7018 RVA: 0x000B140C File Offset: 0x000AF60C
		// (set) Token: 0x06001B6B RID: 7019 RVA: 0x000B1420 File Offset: 0x000AF620
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				base.SetProperty<bool>(ref this._isChecked, value, null, "IsChecked");
			}
		}

		// Token: 0x06001B6C RID: 7020 RVA: 0x000B1444 File Offset: 0x000AF644
		public SelectionParameter Clone(bool newguid = false)
		{
			SelectionParameter selectionParameter = \u0001\u0003\u000E.\u001F(\u0001\u0012\u0016.\u000A(this));
			if (newguid)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.Clone(bool)).MethodHandle;
				}
				\u0019\u0012\u0016.\u001D(selectionParameter, \u0002\u0005\u0018.\u000A().ToString());
			}
			return selectionParameter;
		}

		// Token: 0x06001B6D RID: 7021 RVA: 0x000B1498 File Offset: 0x000AF698
		public ProjectInformationParameterModel GetSingletonParameterModel()
		{
			if (\u000A\u0003\u0016.\u0007(this) != SelectionParameterType.ProjectInformation)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.GetSingletonParameterModel()).MethodHandle;
				}
				return null;
			}
			if (this._singletonProjectInfoParamModel == null)
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
				this._singletonProjectInfoParamModel = \u001F\u0003\u0016.\u000A(this);
				ProjectInformationParameterModel singletonProjectInfoParamModel = this._singletonProjectInfoParamModel;
				\u0009\u0012\u0016.\u000A(singletonProjectInfoParamModel, \u0015\u0003\u000E.\u001F(\u000F\u001E\u000A.\u000A(\u000A\u000F\u0016.\u001D(singletonProjectInfoParamModel), new Action<ParameterModel>(this.WO))));
			}
			return this._singletonProjectInfoParamModel;
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x000B1518 File Offset: 0x000AF718
		public bool Equals(SelectionParameter parameter)
		{
			if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u001D(this), \u001F\u0016\u0016.\u0007(parameter)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.Equals(SelectionParameter)).MethodHandle;
				}
				return \u0008\u0013\u000A.\u000A(\u0007\u0003\u0016.\u001D(this), \u0007\u0003\u0016.\u0007(parameter));
			}
			return false;
		}

		// Token: 0x06001B6F RID: 7023 RVA: 0x000B156C File Offset: 0x000AF76C
		public bool Equals(Parameter parameter)
		{
			if (\u0008\u000F\u0016.\u001D(this) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.Equals(Parameter)).MethodHandle;
				}
				return \u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u001D(this), \u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(parameter)));
			}
			return \u0008\u000F\u0016.\u001D(this) == \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(parameter));
		}

		// Token: 0x06001B70 RID: 7024 RVA: 0x000B15D0 File Offset: 0x000AF7D0
		public bool EqualsByName(SelectionParameter parameter)
		{
			if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u001D(this), \u001F\u0016\u0016.\u0007(parameter)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.EqualsByName(SelectionParameter)).MethodHandle;
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001B71 RID: 7025 RVA: 0x000B160C File Offset: 0x000AF80C
		public bool EqualsByNameIdType(SelectionParameter parameter)
		{
			if (\u000F\u000F\u0016.\u0007(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.EqualsByNameIdType(SelectionParameter)).MethodHandle;
				}
				if (\u000F\u000F\u0016.\u001D(parameter))
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
			}
			if (\u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u001D(this), \u001F\u0016\u0016.\u0007(parameter)))
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
				if (\u0008\u000F\u0016.\u001D(this) == \u0008\u000F\u0016.\u0007(parameter))
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
					if (\u000A\u0003\u0016.\u0007(this) == \u000A\u0003\u0016.\u001D(parameter))
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
				}
			}
			return false;
		}

		// Token: 0x06001B72 RID: 7026 RVA: 0x000B16AC File Offset: 0x000AF8AC
		public bool EqualsByNameOrBuiltInParameter(SelectionParameter parameter)
		{
			if (\u0008\u000F\u0016.\u001D(this) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SelectionParameter.EqualsByNameOrBuiltInParameter(SelectionParameter)).MethodHandle;
				}
				return \u0008\u0013\u000A.\u000A(\u001F\u0016\u0016.\u001D(this), \u001F\u0016\u0016.\u0007(parameter));
			}
			return \u0008\u000F\u0016.\u001D(this) == \u0008\u000F\u0016.\u0007(parameter);
		}

		// Token: 0x06001B73 RID: 7027 RVA: 0x000B1704 File Offset: 0x000AF904
		public bool IsPredefinedParameter()
		{
			return \u000B\u000F\u0016.\u001D(this) != ParameterDataType.Other;
		}

		// Token: 0x06001B74 RID: 7028 RVA: 0x000B1720 File Offset: 0x000AF920
		[CompilerGenerated]
		private void WO(ParameterModel F)
		{
			\u001C\u000B\u0016.\u000A(this._singletonProjectInfoParamModel, UpdateStates.Modified);
		}

		// Token: 0x04000AFF RID: 2815
		private bool _isChecked;

		// Token: 0x04000B00 RID: 2816
		private ProjectInformationParameterModel _singletonProjectInfoParamModel;
	}
}
