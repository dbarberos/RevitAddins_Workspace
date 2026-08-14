using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TGDatabaseLayer;
using DiRoots.One.UIBehaviours.Extensions;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x02000147 RID: 327
	public abstract class AddBaseViewModel : ViewModelBase
	{
		// Token: 0x06000BE4 RID: 3044 RVA: 0x0004C380 File Offset: 0x0004A580
		protected AddBaseViewModel()
		{
		}

		// Token: 0x06000BE5 RID: 3045 RVA: 0x0004C3C4 File Offset: 0x0004A5C4
		protected AddBaseViewModel(List<SelectedExcel> existingTables)
		{
			this._existingTables = existingTables;
			\u001A\u0001\u0004.\u000A(this, \u001D\u0016.\u001D());
			\u0013\u0001\u0004.\u000A(this, \u0011\u0019.\u0019);
			\u0014\u0001\u0004.\u000A(this, \u001D\u0016.\u0019());
			\u0017\u0001\u0004.\u000A(this, \u001D\u0016.\u0004());
			\u0020\u0001\u0004.\u000A(this, \u0011\u0019.\u0018);
			\u0011\u0001\u0004.\u000A(this, \u0016\u0008\u0004.\u000A(\u001E\u0001\u0004.\u000A(this), 0));
			\u0008\u0001\u0004.\u000A(this, \u0016\u0008\u0004.\u000A(\u001B\u0001\u0004.\u000A(this), 0));
			\u0010\u0001\u0004.\u000A(this, \u0016\u0008\u0004.\u000A(\u000E\u0001\u0004.\u000A(this), 0));
			\u001C\u0001\u0004.\u000A(this, \u0016\u0008\u0004.\u000A(\u000D\u0001\u0004.\u000A(this), 0));
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x06000BE6 RID: 3046 RVA: 0x0004C4A4 File Offset: 0x0004A6A4
		// (set) Token: 0x06000BE7 RID: 3047 RVA: 0x0004C4B8 File Offset: 0x0004A6B8
		public string FilePath
		{
			get
			{
				return this.HL;
			}
			set
			{
				this.HL = value;
				\u000D\u0020\u000A.\u000A(this, "FilePath");
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x0004C4D8 File Offset: 0x0004A6D8
		// (set) Token: 0x06000BE9 RID: 3049 RVA: 0x0004C4EC File Offset: 0x0004A6EC
		public string ViewName
		{
			get
			{
				return this.YL;
			}
			set
			{
				this.YL = value;
				\u000D\u0020\u000A.\u000A(this, "ViewName");
				\u000C\u0001\u0004.\u0007(this, "ViewName");
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x06000BEA RID: 3050 RVA: 0x0004C518 File Offset: 0x0004A718
		// (set) Token: 0x06000BEB RID: 3051 RVA: 0x0004C52C File Offset: 0x0004A72C
		public List<EnumInfo> Sources { get; set; }

		// Token: 0x1700034A RID: 842
		// (get) Token: 0x06000BEC RID: 3052 RVA: 0x0004C540 File Offset: 0x0004A740
		// (set) Token: 0x06000BED RID: 3053 RVA: 0x0004C554 File Offset: 0x0004A754
		public EnumInfo SelectedSourceType
		{
			get
			{
				return this.LL;
			}
			set
			{
				this.LL = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedSourceType");
				this.LNR();
			}
		}

		// Token: 0x1700034B RID: 843
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x0004C57C File Offset: 0x0004A77C
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x0004C590 File Offset: 0x0004A790
		public List<EnumInfo> Imports { get; set; }

		// Token: 0x1700034C RID: 844
		// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0004C5A4 File Offset: 0x0004A7A4
		// (set) Token: 0x06000BF1 RID: 3057 RVA: 0x0004C5B8 File Offset: 0x0004A7B8
		public EnumInfo SelectedImportType
		{
			get
			{
				return this.SL;
			}
			set
			{
				this.SL = value;
				this.SNR();
				\u000D\u0020\u000A.\u000A(this, "SelectedImportType");
			}
		}

		// Token: 0x1700034D RID: 845
		// (get) Token: 0x06000BF2 RID: 3058 RVA: 0x0004C5E0 File Offset: 0x0004A7E0
		// (set) Token: 0x06000BF3 RID: 3059 RVA: 0x0004C5F4 File Offset: 0x0004A7F4
		public List<EnumInfo> ViewTypes { get; set; }

		// Token: 0x1700034E RID: 846
		// (get) Token: 0x06000BF4 RID: 3060 RVA: 0x0004C608 File Offset: 0x0004A808
		// (set) Token: 0x06000BF5 RID: 3061 RVA: 0x0004C61C File Offset: 0x0004A81C
		public EnumInfo SelectedViewType
		{
			get
			{
				return this.CL;
			}
			set
			{
				this.CL = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedViewType");
				\u000D\u0020\u000A.\u000A(this, "IsViewScaleEnabled");
				if (\u0001\u0001\u0004.\u000A(this) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.set_SelectedViewType(EnumInfo)).MethodHandle;
					}
					\u000C\u0001\u0004.\u0007(this, "ViewName");
				}
				if (\u000D\u001B\u001D.\u0007(this.CL) == 5)
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
					\u0015\u0001\u0004.\u000A(this, 1);
				}
			}
		}

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x06000BF6 RID: 3062 RVA: 0x0004C690 File Offset: 0x0004A890
		// (set) Token: 0x06000BF7 RID: 3063 RVA: 0x0004C6A4 File Offset: 0x0004A8A4
		public bool IsViewTypeEnable
		{
			get
			{
				return this.JL;
			}
			set
			{
				this.JL = value;
				\u000D\u0020\u000A.\u000A(this, "IsViewTypeEnable");
			}
		}

		// Token: 0x17000350 RID: 848
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x0004C6C4 File Offset: 0x0004A8C4
		// (set) Token: 0x06000BF9 RID: 3065 RVA: 0x0004C6D8 File Offset: 0x0004A8D8
		public List<WorkSheetNamedRegion> WorkSheetNamedRegions
		{
			get
			{
				return this.BL;
			}
			set
			{
				this.BL = value;
				\u000D\u0020\u000A.\u000A(this, "WorkSheetNamedRegions");
			}
		}

		// Token: 0x17000351 RID: 849
		// (get) Token: 0x06000BFA RID: 3066 RVA: 0x0004C6F8 File Offset: 0x0004A8F8
		// (set) Token: 0x06000BFB RID: 3067 RVA: 0x0004C70C File Offset: 0x0004A90C
		public WorkSheetNamedRegion SelectedWorkSheet
		{
			get
			{
				return this.UL;
			}
			set
			{
				bool flag = this.UL != value;
				this.UL = value;
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.set_SelectedWorkSheet(WorkSheetNamedRegion)).MethodHandle;
					}
					WorkSheetNamedRegion workSheetNamedRegion = \u000A\u0009\u0004.\u000A(this);
					List<NamedRangeInfo> u001F;
					if (workSheetNamedRegion == null)
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
						u001F = \u001C\u0018\u000E.\u001F;
					}
					else
					{
						u001F = \u001F\u0009\u0004.\u0007(workSheetNamedRegion);
					}
					\u0009\u0001\u0004.\u000A(this, NamedRangeInfo.\u000A(u001F));
				}
				\u000D\u0020\u000A.\u000A(this, "SelectedWorkSheet");
			}
		}

		// Token: 0x17000352 RID: 850
		// (get) Token: 0x06000BFC RID: 3068 RVA: 0x0004C780 File Offset: 0x0004A980
		// (set) Token: 0x06000BFD RID: 3069 RVA: 0x0004C794 File Offset: 0x0004A994
		public NamedRangeInfo SelectedRegion
		{
			get
			{
				return this.WL;
			}
			set
			{
				this.WL = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedRegion");
			}
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x06000BFE RID: 3070 RVA: 0x0004C7B4 File Offset: 0x0004A9B4
		// (set) Token: 0x06000BFF RID: 3071 RVA: 0x0004C7C8 File Offset: 0x0004A9C8
		public int ViewScale
		{
			get
			{
				return this.KL;
			}
			set
			{
				this.KL = value;
				\u000D\u0020\u000A.\u000A(this, "ViewScale");
				\u000C\u0001\u0004.\u0007(this, "ViewScale");
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x06000C00 RID: 3072 RVA: 0x0004C7F4 File Offset: 0x0004A9F4
		// (set) Token: 0x06000C01 RID: 3073 RVA: 0x0004C808 File Offset: 0x0004AA08
		public int SelectedDpi
		{
			get
			{
				return this.EL;
			}
			set
			{
				this.EL = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedDpi");
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x06000C02 RID: 3074 RVA: 0x0004C828 File Offset: 0x0004AA28
		// (set) Token: 0x06000C03 RID: 3075 RVA: 0x0004C83C File Offset: 0x0004AA3C
		public List<int> DpiValues { get; set; }

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x06000C04 RID: 3076 RVA: 0x0004C850 File Offset: 0x0004AA50
		// (set) Token: 0x06000C05 RID: 3077 RVA: 0x0004C864 File Offset: 0x0004AA64
		public List<EnumInfo> PageOptions { get; set; }

		// Token: 0x17000357 RID: 855
		// (get) Token: 0x06000C06 RID: 3078 RVA: 0x0004C878 File Offset: 0x0004AA78
		// (set) Token: 0x06000C07 RID: 3079 RVA: 0x0004C88C File Offset: 0x0004AA8C
		public EnumInfo SelectedPageOption
		{
			get
			{
				return this.NL;
			}
			set
			{
				this.NL = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedPageOption");
			}
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06000C08 RID: 3080 RVA: 0x0004C8AC File Offset: 0x0004AAAC
		// (set) Token: 0x06000C09 RID: 3081 RVA: 0x0004C8C0 File Offset: 0x0004AAC0
		public string SelectedPages
		{
			get
			{
				return this.ML;
			}
			set
			{
				this.ML = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedPages");
				\u000C\u0001\u0004.\u0007(this, "SelectedPages");
			}
		}

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06000C0A RID: 3082 RVA: 0x0004C8EC File Offset: 0x0004AAEC
		public CommandBase OnSelectExcelFileCommand
		{
			get
			{
				return \u0003\u001E\u000A.\u000A(new Action(this.CNR), \u0002\u0015\u0010.\u001F);
			}
		}

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x06000C0B RID: 3083 RVA: 0x0004C914 File Offset: 0x0004AB14
		// (set) Token: 0x06000C0C RID: 3084 RVA: 0x0004C928 File Offset: 0x0004AB28
		public CommandBase<Window> AddOrUpdateCommand { get; set; }

		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06000C0D RID: 3085 RVA: 0x0004C93C File Offset: 0x0004AB3C
		public CommandBase<Window> CloseCommand
		{
			get
			{
				return \u0007\u0009\u0004.\u000A(new Action<Window>(this.BNR), \u0003\u0018\u000E.\u001F);
			}
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x0004C964 File Offset: 0x0004AB64
		// (set) Token: 0x06000C0F RID: 3087 RVA: 0x0004C978 File Offset: 0x0004AB78
		public bool ShowOnAdd { get; set; } = true;

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x0004C98C File Offset: 0x0004AB8C
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x0004C9A0 File Offset: 0x0004ABA0
		public bool ShowOnUpdate { get; set; } = true;

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x0004C9B4 File Offset: 0x0004ABB4
		public bool IsViewScaleEnabled
		{
			get
			{
				if (\u001D\u0009\u0004.\u000A(this) == null)
				{
					return false;
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.get_IsViewScaleEnabled()).MethodHandle;
				}
				EnumInfo enumInfo = \u001D\u0009\u0004.\u000A(this);
				if (enumInfo == null)
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
				return \u000D\u001B\u001D.\u001D(enumInfo) != 5;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06000C13 RID: 3091 RVA: 0x0004CA08 File Offset: 0x0004AC08
		// (set) Token: 0x06000C14 RID: 3092 RVA: 0x0004CA1C File Offset: 0x0004AC1C
		public bool IsEnabledOnAdd { get; set; } = true;

		// Token: 0x06000C15 RID: 3093 RVA: 0x0004CA30 File Offset: 0x0004AC30
		private void CNR()
		{
			try
			{
				string text = FilePathHelper.\u001F(\u0018\u0009\u0004.\u000A(this), "");
				if (\u001A\u0006\u0007.\u000A(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.CNR()).MethodHandle;
					}
				}
				else if (\u000D\u001B\u001D.\u0007(\u0018\u0009\u0004.\u000A(this)) == 0)
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
					\u0019\u0009\u0004.\u000A(this, text);
				}
				else
				{
					\u0004\u0009\u0004.\u000A(this, text);
				}
			}
			catch (Exception u001F)
			{
				\u000A\u0016.\u001F(u001F);
			}
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x0004CAB8 File Offset: 0x0004ACB8
		protected virtual void SetValues(string filePath)
		{
			Dictionary<string, List<NamedRangeInfo>> dictionary = \u0013\u0019.\u001F(filePath);
			if (\u0016\u0009\u0004.\u000A(dictionary) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.SetValues(string)).MethodHandle;
				}
				\u0005\u0009\u0004.\u000A(this, filePath, dictionary);
			}
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x0004CAF4 File Offset: 0x0004ACF4
		protected void SetValues(string filePath, Dictionary<string, List<NamedRangeInfo>> keyValuePairs)
		{
			\u0004\u0009\u0004.\u000A(this, filePath);
			Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion> func;
			if ((func = AddBaseViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.SetValues(string, Dictionary<string, List<NamedRangeInfo>>)).MethodHandle;
				}
				func = (AddBaseViewModel.<>c.\u000A = new Func<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(AddBaseViewModel.<>c.\u001F.\u0018));
			}
			\u000F\u0009\u0004.\u000A(this, Enumerable.ToList<WorkSheetNamedRegion>(Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, WorkSheetNamedRegion>(keyValuePairs, func)));
			\u000B\u0009\u0004.\u000A(this, \u0002\u0009\u0004.\u000A(\u0006\u0009\u0004.\u000A(this), 0));
			\u0009\u0001\u0004.\u000A(this, NamedRangeInfo.\u000A(\u001F\u0009\u0004.\u001D(\u000A\u0009\u0004.\u000A(this))));
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x0004CB84 File Offset: 0x0004AD84
		protected bool IsViewNameExistsInTableGen(string viewName)
		{
			AddBaseViewModel.\u001A\u0016 u001A_u = new AddBaseViewModel.\u001A\u0016();
			u001A_u.\u001F = this;
			u001A_u.\u000A = viewName;
			return Enumerable.Any<SelectedExcel>(this._existingTables, new Func<SelectedExcel, bool>(u001A_u.\u0007));
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x0004CBC0 File Offset: 0x0004ADC0
		protected bool IsViewNameExistsInRevit(string viewName)
		{
			return \u0015\u0018.\u000A(\u000D\u001B\u001D.\u0007(\u001D\u0009\u0004.\u000A(this)), viewName);
		}

		// Token: 0x06000C1A RID: 3098 RVA: 0x0004CBE4 File Offset: 0x0004ADE4
		protected bool CanAdd(object obj)
		{
			if (!\u0010\u0009\u0004.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.CanAdd(object)).MethodHandle;
				}
				if (!\u001A\u0006\u0007.\u000A(\u000D\u0009\u0004.\u000A(this)))
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
					if (\u000D\u001B\u001D.\u0007(\u0018\u0009\u0004.\u000A(this)) != 0)
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
						if (\u000D\u001B\u001D.\u0007(\u001C\u0009\u0004.\u000A(this)) != 0)
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
							if (\u001E\u000B\u001D.\u000A(\u0013\u0016.\u001F(\u0003\u0009\u0004.\u000A(this))) == 0)
							{
								for (;;)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									goto IL_96;
								}
							}
						}
						return true;
					}
					IL_96:
					if (\u000A\u0009\u0004.\u000A(this) != null)
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
						return \u0012\u0009\u0004.\u000A(this) != \u0010\u0019\u000E.\u001F;
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x06000C1B RID: 3099 RVA: 0x0004CCB0 File Offset: 0x0004AEB0
		protected SelectedExcel GetNewExcelInfo(string viewName)
		{
			SelectedExcel selectedExcel = \u0001\u0009\u0004.\u000A(\u001D\u0009\u0004.\u000A(this));
			\u000D\u0020\u0004.\u000A(selectedExcel, \u0018\u0009\u0004.\u000A(this));
			\u001B\u0011\u0004.\u000A(\u001D\u0011\u0004.\u001D(selectedExcel), \u000D\u001B\u001D.\u0007(\u0015\u0009\u0004.\u000A(this)));
			\u0009\u001B\u0004.\u000A(selectedExcel, \u0015\u0009\u0004.\u000A(this));
			\u0004\u0017\u0004.\u000A(selectedExcel, viewName);
			object u001F = selectedExcel;
			DateTime dateTime = \u0017\u0016\u0004.\u000A();
			\u001E\u0016\u0004.\u000A(u001F, \u0020\u0016\u0004.\u000A(ref dateTime, "MM/dd/yyyy HH:mm:ss"));
			\u000A\u001E\u0004.\u000A(selectedExcel, \u000C\u0009\u0004.\u000A(this));
			\u0007\u001E\u0004.\u000A(selectedExcel, \u001C\u0009\u0004.\u000A(this));
			\u001B\u0020\u0004.\u000A(selectedExcel, \u0003\u0009\u0004.\u000A(this));
			if (\u000D\u001B\u001D.\u0007(\u0002\u0003\u0004.\u0007(selectedExcel)) == 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.GetNewExcelInfo(string)).MethodHandle;
				}
				List<SheetAndNamedRange> list = \u001B\u0009\u0004.\u000A();
				List<WorkSheetNamedRegion>.Enumerator enumerator = \u001A\u0009\u0004.\u000A(\u0006\u0009\u0004.\u000A(this));
				try
				{
					while (\u0014\u0009\u0004.\u000A(ref enumerator))
					{
						WorkSheetNamedRegion u001F2 = \u0013\u0009\u0004.\u000A(ref enumerator);
						SheetAndNamedRange sheetAndNamedRange = \u0018\u0008\u0004.\u000A();
						\u0019\u0008\u0004.\u000A(sheetAndNamedRange, \u0017\u0009\u0004.\u000A(u001F2));
						\u001D\u0008\u0004.\u000A(sheetAndNamedRange, \u001F\u0009\u0004.\u001D(u001F2));
						\u0008\u0009\u0004.\u000A(list, sheetAndNamedRange);
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
					((IDisposable)enumerator).Dispose();
				}
				\u001E\u001B\u0004.\u001D(selectedExcel, list);
				List<string>.Enumerator enumerator2 = \u0013\u0008\u0007.\u000A(\u0011\u001B\u0004.\u001D(selectedExcel));
				try
				{
					while (\u0017\u0008\u0007.\u000A(ref enumerator2))
					{
						string text = \u0014\u0008\u0007.\u000A(ref enumerator2);
						if (\u0008\u0013\u000A.\u000A(text, \u0017\u0009\u0004.\u000A(\u000A\u0009\u0004.\u000A(this))))
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
							\u001B\u001B\u0004.\u001D(selectedExcel, text);
							goto IL_1AF;
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
					((IDisposable)enumerator2).Dispose();
				}
				IL_1AF:
				List<NamedRangeInfo>.Enumerator enumerator3 = \u0020\u0009\u0004.\u000A(\u000A\u001B\u0004.\u001D(selectedExcel));
				try
				{
					while (\u0011\u0009\u0004.\u000A(ref enumerator3))
					{
						NamedRangeInfo namedRangeInfo = \u001E\u0009\u0004.\u000A(ref enumerator3);
						if (\u0008\u0013\u000A.\u000A(\u001B\u0012\u0004.\u001D(namedRangeInfo), \u001B\u0012\u0004.\u001D(\u0012\u0009\u0004.\u000A(this))))
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
							\u001F\u001B\u0004.\u001D(selectedExcel, namedRangeInfo);
							goto IL_2AA;
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
					goto IL_2AA;
				}
				finally
				{
					((IDisposable)enumerator3).Dispose();
				}
			}
			List<SheetAndNamedRange> list2 = \u001B\u0009\u0004.\u000A();
			SheetAndNamedRange sheetAndNamedRange2 = \u0018\u0008\u0004.\u000A();
			\u0019\u0008\u0004.\u000A(sheetAndNamedRange2, "N/A");
			\u001D\u0008\u0004.\u000A(sheetAndNamedRange2, \u0005\u001E\u001D.\u000A());
			object u001F3 = \u001D\u001B\u0004.\u000A(sheetAndNamedRange2);
			NamedRangeInfo namedRangeInfo2 = \u001F\u001E\u001D.\u000A();
			\u0009\u0011\u001D.\u000A(namedRangeInfo2, "N/A");
			\u000C\u0011\u001D.\u000A(u001F3, namedRangeInfo2);
			\u0008\u0009\u0004.\u000A(list2, sheetAndNamedRange2);
			\u001E\u001B\u0004.\u001D(selectedExcel, list2);
			\u001B\u001B\u0004.\u001D(selectedExcel, "N/A");
			\u001F\u001B\u0004.\u001D(selectedExcel, \u0015\u000E\u0004.\u000A(\u001D\u001B\u0004.\u000A(sheetAndNamedRange2), 0));
			IL_2AA:
			\u000C\u0011\u0004.\u001D(selectedExcel, \u000D\u0009\u0004.\u000A(this));
			try
			{
				\u001E\u0008\u0004.\u001D(selectedExcel, \u0020\u0008\u0004.\u001D(selectedExcel, \u0011\u0020\u001D.\u0007(selectedExcel), \u0019\u000E\u0004.\u000A(\u0005\u001A\u000A.\u0007(\u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>())))));
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\Add\\AddBaseViewModel.cs", "GetNewExcelInfo");
			}
			\u0012\u001B\u0004.\u001D(selectedExcel, \u000E\u0009\u0004.\u000A(this));
			return selectedExcel;
		}

		// Token: 0x06000C1C RID: 3100 RVA: 0x0004D008 File Offset: 0x0004B208
		protected virtual void DataValidation(string propertyName)
		{
			if (\u0008\u0013\u000A.\u000A(propertyName, "ViewScale"))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.DataValidation(string)).MethodHandle;
				}
				if (\u000E\u0009\u0004.\u000A(this) > 24000)
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
					\u0009\u0009\u0004.\u000A(this, propertyName, \u0017\u0006\u0007.\u000A(\u000A\u001F\u0019.\u000A(), 24000));
					return;
				}
			}
			if (\u0008\u0013\u000A.\u000A(propertyName, "SelectedPages"))
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
				if (\u000D\u001B\u001D.\u0007(\u001C\u0009\u0004.\u000A(this)) == 1)
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
					if (\u001E\u000B\u001D.\u000A(\u0013\u0016.\u001F(\u0003\u0009\u0004.\u000A(this))) == 0)
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
						\u0009\u0009\u0004.\u000A(this, propertyName, \u001C\u0015\u001D.\u000A(\u001F\u001F\u0019.\u000A(), Array.Empty<object>()));
						return;
					}
				}
			}
			\u0009\u0009\u0004.\u000A(this, propertyName, "");
		}

		// Token: 0x06000C1D RID: 3101 RVA: 0x0004D0F0 File Offset: 0x0004B2F0
		protected void DataValidation(string propertyName, string errorMessage)
		{
			if (!\u0005\u001F\u0019.\u000A(\u0004\u001F\u0019.\u000A(this), propertyName))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.DataValidation(string, string)).MethodHandle;
				}
				\u0018\u001F\u0019.\u000A(\u0004\u001F\u0019.\u000A(this), propertyName, \u0014\u000D\u0007.\u000A());
			}
			\u0019\u001F\u0019.\u000A(\u001D\u001F\u0019.\u000A(\u0004\u001F\u0019.\u000A(this), propertyName));
			if (!\u001A\u0006\u0007.\u000A(errorMessage))
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
				\u001A\u0008\u0007.\u000A(\u001D\u001F\u0019.\u000A(\u0004\u001F\u0019.\u000A(this), propertyName), errorMessage);
			}
			\u0007\u001F\u0019.\u000A(this, propertyName);
		}

		// Token: 0x06000C1E RID: 3102 RVA: 0x0004D180 File Offset: 0x0004B380
		[BindableMethod("NumberValidationOnPreviewTextInput")]
		public void NumberValidationOnPreviewTextInput(TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[^0-9]+");
			\u0019\u0013\u000A.\u000A(e, \u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x06000C1F RID: 3103 RVA: 0x0004D1B0 File Offset: 0x0004B3B0
		[BindableMethod("OnSelectedPagesPreviewText")]
		public void OnSelectedPagesPreviewText(TextCompositionEventArgs e)
		{
			Regex u001F = \u0015\u000F\u0007.\u000A("[\\d,\\s-]");
			\u0019\u0013\u000A.\u000A(e, !\u000C\u000F\u0007.\u001D(u001F, \u0001\u0015\u0007.\u000A(e)));
		}

		// Token: 0x06000C20 RID: 3104 RVA: 0x0004D1E4 File Offset: 0x0004B3E4
		private void LNR()
		{
			if (\u000D\u001B\u001D.\u0007(\u0018\u0009\u0004.\u000A(this)) != 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.LNR()).MethodHandle;
				}
				\u0010\u0001\u0004.\u000A(this, \u0016\u0008\u0004.\u000A(\u000E\u0001\u0004.\u000A(this), 1));
				IEnumerable<EnumInfo> enumerable = \u000E\u0001\u0004.\u000A(this);
				Func<EnumInfo, bool> func;
				if ((func = AddBaseViewModel.<>c.\u0007) == null)
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
					func = (AddBaseViewModel.<>c.\u0007 = new Func<EnumInfo, bool>(AddBaseViewModel.<>c.\u001F.\u0005));
				}
				\u000B\u001F\u0019.\u000A(Enumerable.First<EnumInfo>(enumerable, func), true);
				return;
			}
			object u001F = \u000E\u0001\u0004.\u000A(this);
			Action<EnumInfo> u000A;
			if ((u000A = AddBaseViewModel.<>c.\u001D) == null)
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
				u000A = (AddBaseViewModel.<>c.\u001D = new Action<EnumInfo>(AddBaseViewModel.<>c.\u001F.\u0016));
			}
			\u0016\u001F\u0019.\u000A(u001F, u000A);
		}

		// Token: 0x06000C21 RID: 3105 RVA: 0x0004D2A0 File Offset: 0x0004B4A0
		private void SNR()
		{
			if (\u000D\u001B\u001D.\u0007(\u0015\u0009\u0004.\u000A(this)) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.SNR()).MethodHandle;
				}
				if (\u000D\u001B\u001D.\u0007(\u001D\u0009\u0004.\u000A(this)) == 5)
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
					\u0011\u0001\u0004.\u000A(this, \u0016\u0008\u0004.\u000A(\u001E\u0001\u0004.\u000A(this), 0));
				}
				IEnumerable<EnumInfo> enumerable = \u001E\u0001\u0004.\u000A(this);
				Func<EnumInfo, bool> func;
				if ((func = AddBaseViewModel.<>c.\u0004) == null)
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
					func = (AddBaseViewModel.<>c.\u0004 = new Func<EnumInfo, bool>(AddBaseViewModel.<>c.\u001F.\u000B));
				}
				\u000B\u001F\u0019.\u000A(Enumerable.First<EnumInfo>(enumerable, func), true);
				return;
			}
			object u001F = \u001E\u0001\u0004.\u000A(this);
			Action<EnumInfo> u000A;
			if ((u000A = AddBaseViewModel.<>c.\u0019) == null)
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
				u000A = (AddBaseViewModel.<>c.\u0019 = new Action<EnumInfo>(AddBaseViewModel.<>c.\u001F.\u0002));
			}
			\u0016\u001F\u0019.\u000A(u001F, u000A);
		}

		// Token: 0x06000C22 RID: 3106 RVA: 0x0004D37C File Offset: 0x0004B57C
		private void BNR(Window F)
		{
			\u0019\u000B\u0007.\u001D(F);
		}

		// Token: 0x040004BE RID: 1214
		private string HL;

		// Token: 0x040004BF RID: 1215
		private string YL;

		// Token: 0x040004C0 RID: 1216
		private EnumInfo CL;

		// Token: 0x040004C1 RID: 1217
		private EnumInfo LL;

		// Token: 0x040004C2 RID: 1218
		private EnumInfo SL;

		// Token: 0x040004C3 RID: 1219
		private List<WorkSheetNamedRegion> BL;

		// Token: 0x040004C4 RID: 1220
		private WorkSheetNamedRegion UL;

		// Token: 0x040004C5 RID: 1221
		private NamedRangeInfo WL;

		// Token: 0x040004C6 RID: 1222
		private int KL = 1;

		// Token: 0x040004C7 RID: 1223
		protected List<SelectedExcel> _existingTables;

		// Token: 0x040004C8 RID: 1224
		private bool JL = true;

		// Token: 0x040004C9 RID: 1225
		private int EL = 300;

		// Token: 0x040004CA RID: 1226
		private EnumInfo NL;

		// Token: 0x040004CB RID: 1227
		private string ML;

		// Token: 0x040004CC RID: 1228
		[CompilerGenerated]
		private List<EnumInfo> VL;

		// Token: 0x040004CD RID: 1229
		[CompilerGenerated]
		private List<EnumInfo> ZL;

		// Token: 0x040004CE RID: 1230
		[CompilerGenerated]
		private List<EnumInfo> XL;

		// Token: 0x040004CF RID: 1231
		[CompilerGenerated]
		private List<int> PL;

		// Token: 0x040004D0 RID: 1232
		[CompilerGenerated]
		private List<EnumInfo> OL;

		// Token: 0x040004D2 RID: 1234
		[CompilerGenerated]
		private bool TL;

		// Token: 0x040004D3 RID: 1235
		[CompilerGenerated]
		private bool IL;

		// Token: 0x040004D4 RID: 1236
		[CompilerGenerated]
		private bool QL;

		// Token: 0x02000821 RID: 2081
		[CompilerGenerated]
		private sealed class \u001A\u0016
		{
			// Token: 0x06004DD7 RID: 19927 RVA: 0x001DF234 File Offset: 0x001DD434
			internal bool \u0007(SelectedExcel \u001F)
			{
				if (\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u001F)) == \u000D\u001B\u001D.\u0007(\u001D\u0009\u0004.\u000A(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(AddBaseViewModel.\u001A\u0016.\u0007(SelectedExcel)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0014\u0005\u0004.\u0007(\u001F), this.\u000A);
				}
				return false;
			}

			// Token: 0x04002088 RID: 8328
			public AddBaseViewModel \u001F;

			// Token: 0x04002089 RID: 8329
			public string \u000A;
		}
	}
}
