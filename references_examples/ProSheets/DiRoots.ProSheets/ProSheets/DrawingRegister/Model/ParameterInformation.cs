using System;
using System.Collections.Generic;
using System.Windows;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using ProSheets.Commons.CustomNameManageWindow.Enums;
using ProSheets.Commons.CustomNameManageWindow.Models;
using ProSheets.Commons.CustomNameManageWindow.Models.Interfaces;

namespace ProSheets.DrawingRegister.Model
{
	// Token: 0x0200011D RID: 285
	[Serializable]
	public class ParameterInformation : ModelBase, IParameterModel
	{
		// Token: 0x06000E5F RID: 3679 RVA: 0x000541B0 File Offset: 0x000523B0
		public ParameterInformation()
		{
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x000541D8 File Offset: 0x000523D8
		public ParameterInformation(ParameterInformation parameter)
		{
			\u0003\u000B\u0016.\u0003(this, \u0010\u0008\u0016.\u0014(parameter));
			\u0018\u000B\u0016.\u0003(this, \u000D\u0004\u0016.\u0018(parameter));
			\u0012\u0004\u0016.\u0003(this, \u0020\u0016\u000F.\u0018(parameter));
			\u000E\u001A\u0016.\u0003(this, \u0009\u0004\u0016.\u0014(parameter));
			\u000C\u000B\u0016.\u0003(this, \u000A\u0016\u000F.\u0018(parameter));
			\u0016\u001B\u0016.\u0003(this, \u0013\u0004\u0016.\u0018(parameter));
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00054254 File Offset: 0x00052454
		// (set) Token: 0x06000E62 RID: 3682 RVA: 0x00054268 File Offset: 0x00052468
		public string ParameterName { get; set; }

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06000E63 RID: 3683 RVA: 0x0005427C File Offset: 0x0005247C
		// (set) Token: 0x06000E64 RID: 3684 RVA: 0x00054290 File Offset: 0x00052490
		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return this._horizontalAlignment;
			}
			set
			{
				this._horizontalAlignment = value;
				\u0007\u001B\u0018.\u0018(this, "HorizontalAlignment");
			}
		}

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06000E65 RID: 3685 RVA: 0x000542B0 File Offset: 0x000524B0
		// (set) Token: 0x06000E66 RID: 3686 RVA: 0x000542C4 File Offset: 0x000524C4
		public string DisplayParameterName
		{
			get
			{
				return this._displayParameterName;
			}
			set
			{
				this._displayParameterName = value;
				\u0007\u001B\u0018.\u0018(this, "DisplayParameterName");
			}
		}

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06000E67 RID: 3687 RVA: 0x000542E4 File Offset: 0x000524E4
		// (set) Token: 0x06000E68 RID: 3688 RVA: 0x000542F8 File Offset: 0x000524F8
		public long ParameterId { get; set; }

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x0005430C File Offset: 0x0005250C
		public string DisplayName
		{
			get
			{
				return \u0010\u0008\u0016.\u0003(this);
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06000E6A RID: 3690 RVA: 0x00054324 File Offset: 0x00052524
		// (set) Token: 0x06000E6B RID: 3691 RVA: 0x00054338 File Offset: 0x00052538
		public string ParameterValue { get; set; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06000E6C RID: 3692 RVA: 0x0005434C File Offset: 0x0005254C
		// (set) Token: 0x06000E6D RID: 3693 RVA: 0x00054360 File Offset: 0x00052560
		public ParameterType ParameterType
		{
			get
			{
				return this._parameterType;
			}
			set
			{
				this._parameterType = value;
				\u001F\u0016\u000F.\u0018(this, \u0009\u0004\u0016.\u0003(this) == ParameterType.ProjectParameter);
			}
		}

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x00054388 File Offset: 0x00052588
		// (set) Token: 0x06000E6F RID: 3695 RVA: 0x0005439C File Offset: 0x0005259C
		public bool IsChecked
		{
			get
			{
				return this._isChecked;
			}
			set
			{
				this._isChecked = value;
				\u0007\u001B\u0018.\u0018(this, "IsChecked");
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06000E70 RID: 3696 RVA: 0x000543BC File Offset: 0x000525BC
		// (set) Token: 0x06000E71 RID: 3697 RVA: 0x000543D0 File Offset: 0x000525D0
		public bool IsLinkParameter { get; set; }

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06000E72 RID: 3698 RVA: 0x000543E4 File Offset: 0x000525E4
		// (set) Token: 0x06000E73 RID: 3699 RVA: 0x000543F8 File Offset: 0x000525F8
		public bool IsProjectParameter { get; set; }

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06000E74 RID: 3700 RVA: 0x0005440C File Offset: 0x0005260C
		// (set) Token: 0x06000E75 RID: 3701 RVA: 0x00054420 File Offset: 0x00052620
		public StorageType StorageType { get; set; }

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06000E76 RID: 3702 RVA: 0x00054434 File Offset: 0x00052634
		// (set) Token: 0x06000E77 RID: 3703 RVA: 0x00054448 File Offset: 0x00052648
		public List<ParameterModel> ParameterModels { get; set; } = new List<ParameterModel>();

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06000E78 RID: 3704 RVA: 0x0005445C File Offset: 0x0005265C
		// (set) Token: 0x06000E79 RID: 3705 RVA: 0x00054470 File Offset: 0x00052670
		public bool IsCustomParameter { get; set; }

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x06000E7A RID: 3706 RVA: 0x00054484 File Offset: 0x00052684
		// (set) Token: 0x06000E7B RID: 3707 RVA: 0x00054498 File Offset: 0x00052698
		public string DateFormat { get; set; }

		// Token: 0x0400067D RID: 1661
		private string _displayParameterName;

		// Token: 0x0400067E RID: 1662
		private ParameterType _parameterType;

		// Token: 0x0400067F RID: 1663
		private HorizontalAlignment _horizontalAlignment = HorizontalAlignment.Center;

		// Token: 0x04000683 RID: 1667
		private bool _isChecked;
	}
}
