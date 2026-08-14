using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Enums;

namespace DiRoots.One.SheetLink.Models
{
	// Token: 0x0200024D RID: 589
	public class RevitParameter : BaseParameter
	{
		// Token: 0x060017C2 RID: 6082 RVA: 0x0009AA98 File Offset: 0x00098C98
		public RevitParameter()
		{
		}

		// Token: 0x060017C3 RID: 6083 RVA: 0x0009AAC4 File Offset: 0x00098CC4
		public RevitParameter(Parameter p, long catId, bool isType)
		{
			this.AP(p, catId, null, isType);
		}

		// Token: 0x060017C4 RID: 6084 RVA: 0x0009AAF8 File Offset: 0x00098CF8
		public RevitParameter(Parameter p, long catId, ScheduleField scheduleField, bool isType)
		{
			this.AP(p, catId, scheduleField, isType);
		}

		// Token: 0x060017C5 RID: 6085 RVA: 0x0009AB2C File Offset: 0x00098D2C
		public RevitParameter(ScheduleField scheduleField, long catId)
		{
			\u0008\u001B\u0019.\u001D(this, \u000B\u001E\u000A.\u000A(\u0011\u0004\u0004.\u000A(scheduleField)));
			\u0007\u001E\u0005.\u0007(this, \u0001\u0010\u0018.\u000A(scheduleField));
			\u000E\u001B\u0019.\u001D(this, \u000A\u001E\u0005.\u000A(scheduleField));
			if (\u001A\u0006\u0007.\u000A(\u001D\u001B\u0018.\u001D(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter..ctor(ScheduleField, long)).MethodHandle;
				}
				\u000E\u001B\u0019.\u001D(this, \u0004\u001E\u0018.\u001D(this));
			}
			\u0013\u001B\u0019.\u001D(this, true);
			\u0014\u0010\u0018.\u001D(this, OtherParamTypes.Schedule);
			\u001F\u001E\u0005.\u000A(this, 1);
			\u000A\u0007\u0005.\u001D(this, catId);
			\u0001\u0011\u0005.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0009\u0011\u0005.\u000A(scheduleField))));
			\u000C\u0010\u0018.\u001D(this, \u0015\u0010\u0018.\u000A(scheduleField));
			\u0015\u0011\u0005.\u000A(this, \u0013\u0010\u0018.\u000A(scheduleField).ToString());
			\u001F\u0012.\u0016(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()), scheduleField, this);
			this.GP();
		}

		// Token: 0x17000693 RID: 1683
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x0009AC4C File Offset: 0x00098E4C
		// (set) Token: 0x060017C6 RID: 6086 RVA: 0x0009AC38 File Offset: 0x00098E38
		public long CatId { get; set; }

		// Token: 0x17000694 RID: 1684
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x0009AC74 File Offset: 0x00098E74
		// (set) Token: 0x060017C8 RID: 6088 RVA: 0x0009AC60 File Offset: 0x00098E60
		public long ScheduleId { get; set; }

		// Token: 0x17000695 RID: 1685
		// (get) Token: 0x060017CB RID: 6091 RVA: 0x0009AC9C File Offset: 0x00098E9C
		// (set) Token: 0x060017CA RID: 6090 RVA: 0x0009AC88 File Offset: 0x00098E88
		public int ScheduleIndex { get; set; }

		// Token: 0x17000696 RID: 1686
		// (get) Token: 0x060017CD RID: 6093 RVA: 0x0009ACC4 File Offset: 0x00098EC4
		// (set) Token: 0x060017CC RID: 6092 RVA: 0x0009ACB0 File Offset: 0x00098EB0
		public int ScheduleSkippedIndex { get; set; }

		// Token: 0x17000697 RID: 1687
		// (get) Token: 0x060017CF RID: 6095 RVA: 0x0009ACEC File Offset: 0x00098EEC
		// (set) Token: 0x060017CE RID: 6094 RVA: 0x0009ACD8 File Offset: 0x00098ED8
		public string OriginalName { get; set; }

		// Token: 0x17000698 RID: 1688
		// (get) Token: 0x060017D1 RID: 6097 RVA: 0x0009AD14 File Offset: 0x00098F14
		// (set) Token: 0x060017D0 RID: 6096 RVA: 0x0009AD00 File Offset: 0x00098F00
		public OtherParamTypes OtherParamType { get; set; }

		// Token: 0x17000699 RID: 1689
		// (get) Token: 0x060017D3 RID: 6099 RVA: 0x0009AD3C File Offset: 0x00098F3C
		// (set) Token: 0x060017D2 RID: 6098 RVA: 0x0009AD28 File Offset: 0x00098F28
		public string ToolTipText { get; set; }

		// Token: 0x1700069A RID: 1690
		// (get) Token: 0x060017D5 RID: 6101 RVA: 0x0009AD64 File Offset: 0x00098F64
		// (set) Token: 0x060017D4 RID: 6100 RVA: 0x0009AD50 File Offset: 0x00098F50
		public int ImageIndicator { get; set; }

		// Token: 0x1700069B RID: 1691
		// (get) Token: 0x060017D7 RID: 6103 RVA: 0x0009AD8C File Offset: 0x00098F8C
		// (set) Token: 0x060017D6 RID: 6102 RVA: 0x0009AD78 File Offset: 0x00098F78
		public string ElementUniqueId { get; set; }

		// Token: 0x1700069C RID: 1692
		// (get) Token: 0x060017D9 RID: 6105 RVA: 0x0009ADB4 File Offset: 0x00098FB4
		// (set) Token: 0x060017D8 RID: 6104 RVA: 0x0009ADA0 File Offset: 0x00098FA0
		public long RevitElementId { get; set; }

		// Token: 0x1700069D RID: 1693
		// (get) Token: 0x060017DA RID: 6106 RVA: 0x0009ADC8 File Offset: 0x00098FC8
		// (set) Token: 0x060017DB RID: 6107 RVA: 0x0009ADDC File Offset: 0x00098FDC
		public List<long> UsedParams { get; set; } = new List<long>();

		// Token: 0x1700069E RID: 1694
		// (get) Token: 0x060017DC RID: 6108 RVA: 0x0009ADF0 File Offset: 0x00098FF0
		// (set) Token: 0x060017DD RID: 6109 RVA: 0x0009AE04 File Offset: 0x00099004
		public string SpecTypeId { get; set; }

		// Token: 0x1700069F RID: 1695
		// (get) Token: 0x060017DF RID: 6111 RVA: 0x0009AE2C File Offset: 0x0009902C
		// (set) Token: 0x060017DE RID: 6110 RVA: 0x0009AE18 File Offset: 0x00099018
		public string FieldType { get; set; }

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x060017E1 RID: 6113 RVA: 0x0009AE54 File Offset: 0x00099054
		// (set) Token: 0x060017E0 RID: 6112 RVA: 0x0009AE40 File Offset: 0x00099040
		public string ParameterGroup { get; set; }

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x060017E3 RID: 6115 RVA: 0x0009AE7C File Offset: 0x0009907C
		// (set) Token: 0x060017E2 RID: 6114 RVA: 0x0009AE68 File Offset: 0x00099068
		public int ParamNameGroupIndex { get; set; }

		// Token: 0x170006A2 RID: 1698
		// (get) Token: 0x060017E5 RID: 6117 RVA: 0x0009AEA4 File Offset: 0x000990A4
		// (set) Token: 0x060017E4 RID: 6116 RVA: 0x0009AE90 File Offset: 0x00099090
		public bool IsExportedByType { get; set; }

		// Token: 0x170006A3 RID: 1699
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x0009AECC File Offset: 0x000990CC
		// (set) Token: 0x060017E6 RID: 6118 RVA: 0x0009AEB8 File Offset: 0x000990B8
		public bool IsDropDownAdded { get; set; }

		// Token: 0x170006A4 RID: 1700
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x0009AEF4 File Offset: 0x000990F4
		// (set) Token: 0x060017E8 RID: 6120 RVA: 0x0009AEE0 File Offset: 0x000990E0
		public ExportTypes ExportType { get; set; }

		// Token: 0x170006A5 RID: 1701
		// (get) Token: 0x060017EB RID: 6123 RVA: 0x0009AF1C File Offset: 0x0009911C
		// (set) Token: 0x060017EA RID: 6122 RVA: 0x0009AF08 File Offset: 0x00099108
		[XmlIgnore]
		public UnitOption UnitOptions { get; set; } = new UnitOption();

		// Token: 0x060017EC RID: 6124 RVA: 0x0009AF30 File Offset: 0x00099130
		private void AP(Parameter F, long R, ScheduleField D, bool H)
		{
			Definition u001F = \u0020\u001F\u001D.\u0007(F);
			string u000A = \u000F\u001E\u0005.\u000A(u001F);
			int num = 2;
			if (\u0015\u001C.\u000D(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.AP(Parameter, long, ScheduleField, bool)).MethodHandle;
				}
				num = 1;
				\u0013\u001B\u0019.\u001D(this, true);
			}
			else if (H)
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
				num = 3;
			}
			\u0008\u001B\u0019.\u001D(this, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(F)));
			\u0013\u001B\u0019.\u001D(this, \u0010\u0014\u0007.\u000A(F));
			if (num == 1)
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
				\u0013\u001B\u0019.\u001D(this, true);
			}
			\u0017\u001B\u0019.\u001D(this, H);
			\u001F\u001E\u0005.\u000A(this, num);
			\u000A\u0007\u0005.\u001D(this, R);
			if (D != null)
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
				\u0001\u0011\u0005.\u000A(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0009\u0011\u0005.\u000A(D))));
				\u000C\u0010\u0018.\u001D(this, \u0015\u0010\u0018.\u000A(D));
				\u0015\u0011\u0005.\u000A(this, \u0013\u0010\u0018.\u000A(D).ToString());
				\u000E\u001B\u0019.\u001D(this, \u000A\u001E\u0005.\u000A(D));
				\u0007\u001E\u0005.\u0007(this, \u001E\u001F\u001D.\u000A(u001F));
			}
			else
			{
				\u000E\u001B\u0019.\u001D(this, \u001E\u001F\u001D.\u000A(u001F));
				\u0007\u001E\u0005.\u0007(this, \u001D\u001B\u0018.\u001D(this));
			}
			\u0006\u001E\u0005.\u000A(this, \u0002\u001B\u0005.\u000A(F));
			if (\u001E\u001B\u0005.\u001D(this))
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
				\u0002\u001E\u0005.\u000A(this, \u0016\u001B\u0005.\u000A(F).ToString());
			}
			if (\u001A\u0006\u0007.\u000A(\u001D\u001B\u0018.\u001D(this)))
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
				\u000E\u001B\u0019.\u001D(this, \u0004\u001E\u0018.\u001D(this));
			}
			if (\u001F\u001B\u0018.\u001D(this) != 0L)
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
				\u0014\u0010\u0018.\u001D(this, OtherParamTypes.ScheduleInstanceOrType);
			}
			\u000B\u001E\u0005.\u0007(this, \u0011\u001F\u001D.\u0007(F).ToString());
			\u0018\u001E\u0005.\u000A(this, \u0005\u001E\u0005.\u000A(\u0016\u001E\u0005.\u000A(u001F)));
			\u0019\u001E\u0005.\u000A(this, u000A);
			\u0004\u001E\u0005.\u0007(this, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0010\u0003\u0018.\u000A(F))));
			\u001D\u001E\u0005.\u0007(this, \u0012\u0010\u0007.\u000A(\u0010\u0003\u0018.\u000A(F)));
			\u001F\u0012.\u0016(\u0011\u0020\u000A.\u0007(\u001F\u0011\u0018.\u000A()), D, this);
			this.GP();
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x0009B174 File Offset: 0x00099374
		public string GetColumnDisplyName()
		{
			StringBuilder stringBuilder = \u001A\u0013\u0007.\u000A();
			\u001E\u0013\u0007.\u000A(stringBuilder, "\n");
			if (\u0017\u000B\u0018.\u001D(this) == -1L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.GetColumnDisplyName()).MethodHandle;
				}
				if (\u0008\u0013\u000A.\u000A(\u001D\u001B\u0018.\u001D(this), "GUID"))
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
					\u0011\u001E\u0005.\u000A(stringBuilder);
					goto IL_196;
				}
			}
			if (\u0017\u000B\u0018.\u001D(this) == -1L)
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
				if (\u0008\u0013\u000A.\u000A(\u001D\u001B\u0018.\u001D(this), "Element ID"))
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
					\u001E\u0013\u0007.\u000A(stringBuilder, \u001B\u001E\u0005.\u000A());
					goto IL_196;
				}
			}
			if (\u0004\u001B\u0018.\u001D(this) == OtherParamTypes.Schedule)
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
				\u001E\u0013\u0007.\u000A(stringBuilder, \u0008\u001E\u0005.\u000A());
			}
			else
			{
				\u001E\u0013\u0007.\u000A(stringBuilder, \u001E\u0011\u0018.\u001D(this));
				if (\u0008\u0013\u000A.\u000A(\u000E\u001E\u0005.\u000A(this), \u0005\u001E\u0005.\u000A(\u0010\u001E\u0005.\u000A())))
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
					string u000A = \u000D\u001E\u0005.\u000A(\u0010\u001E\u0005.\u000A());
					\u001E\u0013\u0007.\u000A(stringBuilder, \u0002\u0013\u000A.\u000A(" (", u000A, ")"));
				}
				\u001E\u0013\u0007.\u000A(stringBuilder, "\n");
				object u001F = stringBuilder;
				string u000A2;
				if (!\u0018\u000C\u0019.\u0007(this))
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
					u000A2 = \u001C\u001E\u0005.\u000A();
				}
				else
				{
					u000A2 = \u0003\u001E\u0005.\u000A();
				}
				\u001E\u0013\u0007.\u000A(u001F, u000A2);
				\u001E\u0013\u0007.\u000A(stringBuilder, "\n");
				\u001E\u0013\u0007.\u000A(stringBuilder, \u0012\u001E\u0005.\u000A(this));
			}
			IL_196:
			return \u001A\u000C\u000A.\u000A(stringBuilder);
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x0009B320 File Offset: 0x00099520
		public bool CheckForYesNoParameter()
		{
			if (\u0008\u0013\u000A.\u000A(\u000E\u001E\u0005.\u000A(this), \u0005\u001E\u0005.\u000A(\u0010\u001E\u0005.\u000A())))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.CheckForYesNoParameter()).MethodHandle;
				}
				return true;
			}
			return false;
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x0009B364 File Offset: 0x00099564
		private void GP()
		{
			StringBuilder stringBuilder = \u001A\u0013\u0007.\u000A();
			\u001E\u0013\u0007.\u000A(stringBuilder, \u0002\u0013\u000A.\u000A(\u000C\u001E\u0005.\u000A(), ": ", \u0004\u001E\u0018.\u001D(this)));
			\u0015\u0016\u0019.\u000A(stringBuilder);
			if (\u0004\u001B\u0018.\u001D(this) == OtherParamTypes.Schedule)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.GP()).MethodHandle;
				}
				\u001E\u0013\u0007.\u000A(stringBuilder, \u001A\u001E\u0005.\u000A());
			}
			else
			{
				object u001F = stringBuilder;
				string u001F2 = \u0013\u001E\u0005.\u000A();
				string u000A = ": ";
				string u;
				if (!\u0018\u000C\u0019.\u0007(this))
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
					u = \u001C\u001E\u0005.\u000A();
				}
				else
				{
					u = \u0003\u001E\u0005.\u000A();
				}
				\u001E\u0013\u0007.\u000A(u001F, \u0002\u0013\u000A.\u000A(u001F2, u000A, u));
				\u0015\u0016\u0019.\u000A(stringBuilder);
				if (!\u001A\u0006\u0007.\u000A(\u000E\u001E\u0005.\u000A(this)))
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
					string text = \u000D\u001E\u0005.\u000A(\u0014\u001E\u0005.\u000A(\u000E\u001E\u0005.\u000A(this)));
					object u001F3 = stringBuilder;
					string[] array = \u001B\u001F\u000E.\u001F(6);
					array[0] = \u0017\u001E\u0005.\u000A();
					array[1] = ": ";
					array[2] = \u001E\u0011\u0018.\u001D(this);
					array[3] = " (";
					array[4] = text;
					array[5] = ")";
					\u001E\u0013\u0007.\u000A(u001F3, \u0014\u0006\u001D.\u000A(array));
					\u0015\u0016\u0019.\u000A(stringBuilder);
				}
				\u001E\u0013\u0007.\u000A(stringBuilder, \u0002\u0013\u000A.\u000A(\u0020\u001E\u0005.\u000A(), ": ", \u0012\u001E\u0005.\u000A(this)));
			}
			\u001E\u001E\u0005.\u000A(this, \u001A\u000C\u000A.\u000A(stringBuilder));
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x0009B4D8 File Offset: 0x000996D8
		internal static void FO(\u0015\u001C F, RevitParameter R, CategoryCollection D)
		{
			long u000A = \u0009\u001E\u0005.\u000A(R);
			if (\u0009\u001E\u0005.\u000A(R) != 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.FO(\u0015\u001C, RevitParameter, CategoryCollection)).MethodHandle;
				}
				u000A = \u001B\u0020\u0018.\u000A(D);
			}
			if (!\u0008\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(F), u000A))
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
				\u0001\u001E\u0005.\u000A(\u000E\u0020\u0018.\u000A(F), u000A, \u000D\u000E\u0018.\u000A());
			}
			if (!\u0015\u001E\u0005.\u000A(\u0010\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(F), u000A), R))
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
				\u0017\u0010\u0018.\u000A(\u0010\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(F), u000A), R);
			}
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x0009B580 File Offset: 0x00099780
		internal static void DO(\u0015\u001C F, List<RevitParameter> R, bool D)
		{
			ExportTypes r = ExportTypes.Normal;
			if (\u0008\u000D\u0018.\u000A(R) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.DO(\u0015\u001C, List<RevitParameter>, bool)).MethodHandle;
				}
				r = \u0017\u0011\u0018.\u000A(\u0004\u0008\u0018.\u000A(R, 0));
			}
			List<RevitParameter> u001F = RevitParameter.HO(F, r, D);
			for (int i = 0; i < \u0008\u000D\u0018.\u000A(u001F); i++)
			{
				\u001F\u0020\u0005.\u000A(R, i, \u0004\u0008\u0018.\u000A(u001F, i));
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

		// Token: 0x060017F2 RID: 6130 RVA: 0x0009B5F8 File Offset: 0x000997F8
		private static List<RevitParameter> HO(\u0015\u001C F, ExportTypes R, bool D)
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			RevitParameter revitParameter = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter, -1L);
			\u000E\u001B\u0019.\u0007(revitParameter, "GUID");
			\u0007\u001E\u0005.\u001D(revitParameter, "GUID");
			\u0013\u001B\u0019.\u0007(revitParameter, true);
			\u0014\u0010\u0018.\u0007(revitParameter, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter, "String");
			\u0004\u001E\u0005.\u001D(revitParameter, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter, "");
			\u0005\u0007\u0005.\u000A(revitParameter, R);
			RevitParameter revitParameter2 = revitParameter;
			\u0017\u0010\u0018.\u000A(list, revitParameter2);
			RevitParameter revitParameter3 = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter3, -1L);
			\u000E\u001B\u0019.\u0007(revitParameter3, "Element ID");
			\u0007\u001E\u0005.\u001D(revitParameter3, "Element ID");
			\u0013\u001B\u0019.\u0007(revitParameter3, true);
			\u0014\u0010\u0018.\u0007(revitParameter3, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter3, "String");
			\u0004\u001E\u0005.\u001D(revitParameter3, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter3, "");
			\u0005\u0007\u0005.\u000A(revitParameter3, R);
			revitParameter2 = revitParameter3;
			if (\u0007\u0020\u0005.\u000A(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.HO(\u0015\u001C, ExportTypes, bool)).MethodHandle;
				}
				\u000E\u001B\u0019.\u0007(revitParameter2, "Type ID");
				\u0007\u001E\u0005.\u001D(revitParameter2, \u001D\u001B\u0018.\u0007(revitParameter2));
			}
			\u0017\u0010\u0018.\u000A(list, revitParameter2);
			if (\u0007\u0020\u0005.\u000A(F))
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
				RevitParameter revitParameter4 = \u0009\u0010\u0018.\u000A();
				\u0008\u001B\u0019.\u0007(revitParameter4, -1002052L);
				\u000E\u001B\u0019.\u0007(revitParameter4, \u000A\u0020\u0005.\u000A());
				\u0007\u001E\u0005.\u001D(revitParameter4, \u000A\u0020\u0005.\u000A());
				\u0013\u001B\u0019.\u0007(revitParameter4, true);
				\u0014\u0010\u0018.\u0007(revitParameter4, OtherParamTypes.Custom);
				\u000B\u001E\u0005.\u001D(revitParameter4, "String");
				\u0004\u001E\u0005.\u001D(revitParameter4, -1L);
				\u001D\u001E\u0005.\u001D(revitParameter4, "");
				\u0005\u0007\u0005.\u000A(revitParameter4, R);
				revitParameter2 = revitParameter4;
				\u0017\u0010\u0018.\u000A(list, revitParameter2);
			}
			if (D)
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
				RevitParameter revitParameter5 = \u0009\u0010\u0018.\u000A();
				\u0008\u001B\u0019.\u0007(revitParameter5, -1L);
				\u000E\u001B\u0019.\u0007(revitParameter5, "Base Equipment");
				\u0007\u001E\u0005.\u001D(revitParameter5, "Base Equipment");
				\u0013\u001B\u0019.\u0007(revitParameter5, true);
				\u0014\u0010\u0018.\u0007(revitParameter5, OtherParamTypes.Custom);
				\u000B\u001E\u0005.\u001D(revitParameter5, "String");
				\u0004\u001E\u0005.\u001D(revitParameter5, -1L);
				\u001D\u001E\u0005.\u001D(revitParameter5, "");
				\u0005\u0007\u0005.\u000A(revitParameter5, R);
				revitParameter2 = revitParameter5;
				\u0017\u0010\u0018.\u000A(list, revitParameter2);
			}
			ParamUniqueHandler.\u001D(F, list, \u0005\u0012\u000E.\u001F);
			return list;
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x0009B7FC File Offset: 0x000999FC
		internal static List<RevitParameter> YO(\u0015\u001C F, bool R)
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			RevitParameter revitParameter = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter, -1L);
			\u000E\u001B\u0019.\u0007(revitParameter, \u0005\u0020\u0005.\u000A());
			\u0007\u001E\u0005.\u001D(revitParameter, "Id");
			\u0013\u001B\u0019.\u0007(revitParameter, true);
			\u0014\u0010\u0018.\u0007(revitParameter, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter, "String");
			\u0004\u001E\u0005.\u001D(revitParameter, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter, "");
			RevitParameter u000A = revitParameter;
			\u0017\u0010\u0018.\u000A(list, u000A);
			RevitParameter revitParameter2 = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter2, -1L);
			\u000E\u001B\u0019.\u0007(revitParameter2, \u0018\u0020\u0005.\u000A());
			\u0007\u001E\u0005.\u001D(revitParameter2, "Name");
			\u0013\u001B\u0019.\u0007(revitParameter2, true);
			\u0014\u0010\u0018.\u0007(revitParameter2, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter2, "String");
			\u0004\u001E\u0005.\u001D(revitParameter2, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter2, "");
			u000A = revitParameter2;
			\u0017\u0010\u0018.\u000A(list, u000A);
			RevitParameter revitParameter3 = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter3, -1L);
			\u000E\u001B\u0019.\u0007(revitParameter3, \u0019\u0020\u0005.\u000A());
			\u0007\u001E\u0005.\u001D(revitParameter3, "Projection");
			\u0014\u0010\u0018.\u0007(revitParameter3, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter3, "String");
			\u0004\u001E\u0005.\u001D(revitParameter3, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter3, "");
			u000A = revitParameter3;
			\u0017\u0010\u0018.\u000A(list, u000A);
			if (R)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.YO(\u0015\u001C, bool)).MethodHandle;
				}
				RevitParameter revitParameter4 = \u0009\u0010\u0018.\u000A();
				\u0008\u001B\u0019.\u0007(revitParameter4, -1L);
				\u000E\u001B\u0019.\u0007(revitParameter4, \u0004\u0020\u0005.\u000A());
				\u0007\u001E\u0005.\u001D(revitParameter4, "Cut");
				\u0014\u0010\u0018.\u0007(revitParameter4, OtherParamTypes.Custom);
				\u000B\u001E\u0005.\u001D(revitParameter4, "String");
				\u0004\u001E\u0005.\u001D(revitParameter4, -1L);
				\u001D\u001E\u0005.\u001D(revitParameter4, "");
				u000A = revitParameter4;
				\u0017\u0010\u0018.\u000A(list, u000A);
			}
			RevitParameter revitParameter5 = \u0009\u0010\u0018.\u000A();
			\u0008\u001B\u0019.\u0007(revitParameter5, -1L);
			\u000E\u001B\u0019.\u0007(revitParameter5, \u001D\u0020\u0005.\u000A());
			\u0007\u001E\u0005.\u001D(revitParameter5, "Color");
			\u0014\u0010\u0018.\u0007(revitParameter5, OtherParamTypes.Custom);
			\u000B\u001E\u0005.\u001D(revitParameter5, "String");
			\u0004\u001E\u0005.\u001D(revitParameter5, -1L);
			\u001D\u001E\u0005.\u001D(revitParameter5, "");
			u000A = revitParameter5;
			\u0017\u0010\u0018.\u000A(list, u000A);
			ParamUniqueHandler.\u001D(F, list, \u0005\u0012\u000E.\u001F);
			return list;
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x0009B9E8 File Offset: 0x00099BE8
		internal static bool CO(\u0015\u001C F, CategoryCollection R)
		{
			long num = \u0013\u000E\u0018.\u0007(R);
			if (\u0013\u000E\u0018.\u0007(R) != 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.CO(\u0015\u001C, CategoryCollection)).MethodHandle;
				}
				if (\u0014\u0012\u0005.\u001D(R) == null)
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
					if (!\u0016\u001E\u0018.\u0007(R))
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
						if (\u0017\u0012\u0005.\u001D(R) != null)
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
							long num2 = \u000B\u001E\u000A.\u000A(\u0004\u0013\u0007.\u000A(\u0011\u0017\u000A.\u0007(\u0017\u0012\u0005.\u001D(R), \u001E\u0001\u000A.\u000A(num))));
							if (num2 > 0L)
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
								num = num2;
							}
						}
					}
				}
			}
			if (\u0008\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(F), num))
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
				List<RevitParameter>.Enumerator enumerator = \u0013\u000D\u0018.\u000A(\u0010\u0020\u0018.\u000A(\u000E\u0020\u0018.\u000A(F), num));
				try
				{
					while (\u0011\u000D\u0018.\u000A(ref enumerator))
					{
						RevitParameter revitParameter = \u0014\u000D\u0018.\u000A(ref enumerator);
						if (!Enumerable.Contains<RevitParameter>(\u001B\u0014\u0019.\u0007(F), revitParameter, new \u0012\u000E()))
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
							\u0017\u0010\u0018.\u000A(\u001B\u0014\u0019.\u0007(F), revitParameter);
						}
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
				return true;
			}
			return false;
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x0009BB3C File Offset: 0x00099D3C
		public bool IsExists(ParamExportInfo exportInfo)
		{
			if (\u001E\u001B\u0005.\u001D(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.IsExists(ParamExportInfo)).MethodHandle;
				}
				if (!\u001A\u0006\u0007.\u000A(\u001B\u001B\u0005.\u001D(this)))
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
					if (\u0008\u0013\u000A.\u000A(\u001B\u001B\u0005.\u001D(this), \u000B\u001B\u0005.\u001D(exportInfo)))
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
			}
			if (\u001A\u0008\u0019.\u000A(\u0005\u001B\u0005.\u001D(exportInfo), \u0017\u000B\u0018.\u001D(this)))
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
				return true;
			}
			return false;
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x0009BBCC File Offset: 0x00099DCC
		public bool IsInstanceParameter()
		{
			if (!\u0018\u000C\u0019.\u0007(this))
			{
				return true;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.IsInstanceParameter()).MethodHandle;
			}
			if (\u001F\u001B\u0018.\u001D(this) > 0L)
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
				return \u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u001D(this), "Instance");
			}
			return false;
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x0009BC24 File Offset: 0x00099E24
		public bool IsTypeParameter()
		{
			if (\u0018\u000C\u0019.\u0007(this))
			{
				return true;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.IsTypeParameter()).MethodHandle;
			}
			if (\u001F\u001B\u0018.\u001D(this) > 0L)
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
				return \u0008\u0013\u000A.\u000A(\u001F\u001E\u0018.\u001D(this), "ElementType");
			}
			return false;
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0009BC7C File Offset: 0x00099E7C
		public bool IsSharedParameter()
		{
			if (\u001F\u001B\u0018.\u001D(this) > 0L)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.IsSharedParameter()).MethodHandle;
				}
				return \u001E\u001B\u0005.\u001D(this);
			}
			return false;
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x0009BCB4 File Offset: 0x00099EB4
		public override bool Equals(object obj)
		{
			if (obj != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.Equals(object)).MethodHandle;
				}
				if (\u0001\u001F\u001D.\u000A(\u0003\u0011\u000A.\u001D(this), \u0003\u0011\u000A.\u0007(obj)))
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
					RevitParameter u001F = \u0018\u0012\u000E.\u001F(obj);
					if (\u0008\u0013\u000A.\u000A(\u000F\u0020\u0018.\u001D(this), \u000F\u0020\u0018.\u0007(u001F)))
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
						return \u0018\u000C\u0019.\u0007(this) == \u0018\u000C\u0019.\u001D(u001F);
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0009BD3C File Offset: 0x00099F3C
		public override int GetHashCode()
		{
			if (\u000F\u0020\u0018.\u001D(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(RevitParameter.GetHashCode()).MethodHandle;
				}
				\u000E\u0011\u0005.\u001D(this, "");
			}
			int num = \u001B\u0013\u000A.\u000A(\u000F\u0020\u0018.\u001D(this));
			bool flag = \u0018\u000C\u0019.\u0007(this);
			return num ^ \u0004\u0020\u0004.\u000A(ref flag);
		}

		// Token: 0x0400095E RID: 2398
		[CompilerGenerated]
		private long VY;

		// Token: 0x0400095F RID: 2399
		[CompilerGenerated]
		private long ZY;

		// Token: 0x04000960 RID: 2400
		[CompilerGenerated]
		private int XY;

		// Token: 0x04000961 RID: 2401
		[CompilerGenerated]
		private int PY;

		// Token: 0x04000962 RID: 2402
		[CompilerGenerated]
		private string OY;

		// Token: 0x04000963 RID: 2403
		[CompilerGenerated]
		private OtherParamTypes TY;

		// Token: 0x04000964 RID: 2404
		[CompilerGenerated]
		private string IY;

		// Token: 0x04000965 RID: 2405
		[CompilerGenerated]
		private int IH;

		// Token: 0x04000966 RID: 2406
		[CompilerGenerated]
		private string QY;

		// Token: 0x04000967 RID: 2407
		[CompilerGenerated]
		private long AY;

		// Token: 0x04000968 RID: 2408
		[CompilerGenerated]
		private List<long> GY;

		// Token: 0x04000969 RID: 2409
		[CompilerGenerated]
		private string FC;

		// Token: 0x0400096A RID: 2410
		[CompilerGenerated]
		private string RC;

		// Token: 0x0400096B RID: 2411
		[CompilerGenerated]
		private string DC;

		// Token: 0x0400096C RID: 2412
		[CompilerGenerated]
		private int HC;

		// Token: 0x0400096D RID: 2413
		[CompilerGenerated]
		private bool YC;

		// Token: 0x0400096E RID: 2414
		[CompilerGenerated]
		private bool CC;

		// Token: 0x0400096F RID: 2415
		[CompilerGenerated]
		private ExportTypes UY;

		// Token: 0x04000970 RID: 2416
		[CompilerGenerated]
		private UnitOption LC;
	}
}
