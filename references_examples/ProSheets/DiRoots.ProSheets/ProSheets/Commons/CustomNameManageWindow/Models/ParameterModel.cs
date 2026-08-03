using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;

namespace ProSheets.Commons.CustomNameManageWindow.Models
{
	// Token: 0x02000142 RID: 322
	[Serializable]
	public class ParameterModel : ModelBase, IParameterModel
	{
		// Token: 0x06000FF0 RID: 4080 RVA: 0x00059CC0 File Offset: 0x00057EC0
		public ParameterModel()
		{
		}

		// Token: 0x06000FF1 RID: 4081 RVA: 0x00059CF4 File Offset: 0x00057EF4
		public ParameterModel(string pName, long pId, StorageType sType, string prefix = "", string suffix = "", string separator = "-")
		{
			\u0015\u0013\u000F.\u0003(this, pName);
			\u000A\u0009\u000F.\u0018(this, pId);
			\u0009\u0009\u000F.\u0018(this, sType);
			\u0020\u0009\u0016.\u0003(this, prefix);
			\u0012\u0009\u0016.\u0003(this, suffix);
			\u001F\u0009\u0016.\u0003(this, separator);
		}

		// Token: 0x1700056D RID: 1389
		// (get) Token: 0x06000FF2 RID: 4082 RVA: 0x00059D58 File Offset: 0x00057F58
		// (set) Token: 0x06000FF3 RID: 4083 RVA: 0x00059D6C File Offset: 0x00057F6C
		public string ParameterName { get; set; }

		// Token: 0x1700056E RID: 1390
		// (get) Token: 0x06000FF4 RID: 4084 RVA: 0x00059D80 File Offset: 0x00057F80
		// (set) Token: 0x06000FF5 RID: 4085 RVA: 0x00059D94 File Offset: 0x00057F94
		public StorageType StorageType { get; set; }

		// Token: 0x1700056F RID: 1391
		// (get) Token: 0x06000FF6 RID: 4086 RVA: 0x00059DA8 File Offset: 0x00057FA8
		// (set) Token: 0x06000FF7 RID: 4087 RVA: 0x00059DBC File Offset: 0x00057FBC
		public long ParameterId { get; set; }

		// Token: 0x17000570 RID: 1392
		// (get) Token: 0x06000FF8 RID: 4088 RVA: 0x00059DD0 File Offset: 0x00057FD0
		// (set) Token: 0x06000FF9 RID: 4089 RVA: 0x00059DE4 File Offset: 0x00057FE4
		public string Prefix
		{
			get
			{
				return this._prefix;
			}
			set
			{
				this._prefix = value;
				\u0007\u001B\u0018.\u0018(this, "Prefix");
			}
		}

		// Token: 0x17000571 RID: 1393
		// (get) Token: 0x06000FFA RID: 4090 RVA: 0x00059E04 File Offset: 0x00058004
		// (set) Token: 0x06000FFB RID: 4091 RVA: 0x00059E18 File Offset: 0x00058018
		public string Suffix
		{
			get
			{
				return this._suffix;
			}
			set
			{
				this._suffix = value;
				\u0007\u001B\u0018.\u0018(this, "Suffix");
			}
		}

		// Token: 0x17000572 RID: 1394
		// (get) Token: 0x06000FFC RID: 4092 RVA: 0x00059E38 File Offset: 0x00058038
		[XmlIgnore]
		public string SampleValue
		{
			get
			{
				return this.YQ();
			}
		}

		// Token: 0x17000573 RID: 1395
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x00059E50 File Offset: 0x00058050
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x00059E64 File Offset: 0x00058064
		[XmlAttribute("xml:space=preserve")]
		public string Separator
		{
			get
			{
				return this._separator;
			}
			set
			{
				this._separator = value;
				\u0007\u001B\u0018.\u0018(this, "Separator");
			}
		}

		// Token: 0x17000574 RID: 1396
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x00059E84 File Offset: 0x00058084
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x00059E98 File Offset: 0x00058098
		public bool IsProjectParameter { get; set; }

		// Token: 0x17000575 RID: 1397
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x00059EAC File Offset: 0x000580AC
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x00059EC0 File Offset: 0x000580C0
		public List<ParameterModel> ParameterModels { get; set; }

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x00059ED4 File Offset: 0x000580D4
		// (set) Token: 0x06001004 RID: 4100 RVA: 0x00059EE8 File Offset: 0x000580E8
		public bool IsCustomParameter { get; set; }

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x00059EFC File Offset: 0x000580FC
		public string DisplayName
		{
			get
			{
				return \u001A\u001B\u0018.\u0018(\u0004\u0019\u0014.\u0003(this));
			}
		}

		// Token: 0x06001006 RID: 4102 RVA: 0x00059F18 File Offset: 0x00058118
		private string YQ()
		{
			string result = string.Empty;
			switch (\u0010\u0013\u000F.\u0003(this))
			{
			case 0:
			case 3:
			case 4:
				result = \u0020\u0009\u000F.\u0018(this);
				break;
			case 1:
				result = "1";
				break;
			case 2:
				result = "1.0";
				break;
			}
			return result;
		}

		// Token: 0x04000718 RID: 1816
		private string _prefix = string.Empty;

		// Token: 0x04000719 RID: 1817
		private string _suffix = string.Empty;

		// Token: 0x0400071A RID: 1818
		private string _separator = "-";
	}
}
