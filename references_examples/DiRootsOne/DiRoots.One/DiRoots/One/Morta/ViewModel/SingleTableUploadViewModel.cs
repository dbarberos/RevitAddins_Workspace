using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Windows;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.Morta.Interfaces;
using DiRoots.One.Morta.Model;
using DiRoots.One.Morta.Model.CustomTable;
using DiRoots.One.Morta.UI.Windows;

namespace DiRoots.One.Morta.ViewModel
{
	// Token: 0x020001AE RID: 430
	public class SingleTableUploadViewModel : ViewModelBase
	{
		// Token: 0x06000FE4 RID: 4068 RVA: 0x00065374 File Offset: 0x00063574
		internal SingleTableUploadViewModel(\u0013\u0006 F, IDataFactory R)
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\ViewModel\\SingleTableUploadViewModel.cs", ".ctor");
			\u0001\u000A\u0018.\u000A(this, new AddComboxModel());
			\u0015\u000A\u0018.\u000A(this, R);
			\u000C\u000A\u0018.\u000A(this, F);
			\u001A\u000A\u0018.\u000A(this);
			\u0013\u000A\u0018.\u000A(this, new CommandBase(new Action(this.OnProjectSelectionChanged), \u0002\u0015\u0010.\u001F));
			IDataFactory dataFactory = \u0014\u000A\u0018.\u000A(this);
			TableInfo ku;
			if (dataFactory == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel..ctor(\u0013\u0006, IDataFactory)).MethodHandle;
				}
				ku = \u001C\u0016\u000E.\u001F;
			}
			else
			{
				ku = \u0017\u000A\u0018.\u000A(dataFactory);
			}
			this.KU = ku;
			TableInfo ku2 = this.KU;
			string u000A;
			if (ku2 == null)
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
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = \u0003\u000A\u0018.\u001D(ku2);
			}
			\u0009\u001F\u0018.\u000A(this, u000A);
			this.WVR();
			\u0001\u001F\u0018.\u000A(this, new CommandBase(new Action(this.UpdateTable), \u0002\u0015\u0010.\u001F));
			\u0020\u000A\u0018.\u000A(this, new CommandBase(new Action(this.OnProjectSearchTextChanged), \u0002\u0015\u0010.\u001F));
			\u001E\u000A\u0018.\u000A(this, new CommandBase(new Action(this.OnTableSearchTextChanged), \u0002\u0015\u0010.\u001F));
			\u0011\u000A\u0018.\u000A(this, new CommandBase(new Action(this.KVR), \u0002\u0015\u0010.\u001F));
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\ViewModel\\SingleTableUploadViewModel.cs", ".ctor");
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x06000FE5 RID: 4069 RVA: 0x000654DC File Offset: 0x000636DC
		// (set) Token: 0x06000FE6 RID: 4070 RVA: 0x000654F0 File Offset: 0x000636F0
		public AddComboxModel AddComboxModelInstance { get; set; }

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x06000FE7 RID: 4071 RVA: 0x00065504 File Offset: 0x00063704
		// (set) Token: 0x06000FE8 RID: 4072 RVA: 0x00065518 File Offset: 0x00063718
		public List<ProjectData> Projects
		{
			get
			{
				return this.DU;
			}
			set
			{
				this.DU = value;
				\u000D\u0020\u000A.\u000A(this, "Projects");
			}
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x00065538 File Offset: 0x00063738
		// (set) Token: 0x06000FEA RID: 4074 RVA: 0x0006554C File Offset: 0x0006374C
		public ProjectData SelectedProject
		{
			get
			{
				return this.HU;
			}
			set
			{
				this.HU = value;
				\u000D\u0020\u000A.\u000A(this, "SelectedProject");
			}
		}

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x06000FEB RID: 4075 RVA: 0x0006556C File Offset: 0x0006376C
		// (set) Token: 0x06000FEC RID: 4076 RVA: 0x00065580 File Offset: 0x00063780
		public List<TableInfo> Tables
		{
			get
			{
				return this.YU;
			}
			set
			{
				this.YU = value;
				\u000D\u0020\u000A.\u000A(this, "Tables");
			}
		}

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x06000FED RID: 4077 RVA: 0x000655A0 File Offset: 0x000637A0
		// (set) Token: 0x06000FEE RID: 4078 RVA: 0x000655B4 File Offset: 0x000637B4
		public TableInfo SelectedTable
		{
			get
			{
				return this.CU;
			}
			set
			{
				this.CU = value;
				\u0019\u000A\u0018.\u001D(this);
				\u000D\u0020\u000A.\u000A(this, "SelectedTable");
			}
		}

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x06000FEF RID: 4079 RVA: 0x000655DC File Offset: 0x000637DC
		// (set) Token: 0x06000FF0 RID: 4080 RVA: 0x000655F0 File Offset: 0x000637F0
		public string SearchProjectName
		{
			get
			{
				return this.LU;
			}
			set
			{
				this.LU = value;
				\u000D\u0020\u000A.\u000A(this, "SearchProjectName");
			}
		}

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x06000FF1 RID: 4081 RVA: 0x00065610 File Offset: 0x00063810
		// (set) Token: 0x06000FF2 RID: 4082 RVA: 0x00065624 File Offset: 0x00063824
		public string SearchTableName
		{
			get
			{
				return this.SU;
			}
			set
			{
				this.SU = value;
				\u000D\u0020\u000A.\u000A(this, "SearchTableName");
			}
		}

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x00065644 File Offset: 0x00063844
		// (set) Token: 0x06000FF4 RID: 4084 RVA: 0x00065658 File Offset: 0x00063858
		public string TableName
		{
			get
			{
				return this.BU;
			}
			set
			{
				this.BU = value;
				\u000D\u0020\u000A.\u000A(this, "TableName");
			}
		}

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x00065678 File Offset: 0x00063878
		// (set) Token: 0x06000FF6 RID: 4086 RVA: 0x0006568C File Offset: 0x0006388C
		public string SingButtonContent
		{
			get
			{
				return this.UU;
			}
			set
			{
				this.UU = value;
				\u000D\u0020\u000A.\u000A(this, "SingButtonContent");
			}
		}

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x000656AC File Offset: 0x000638AC
		// (set) Token: 0x06000FF8 RID: 4088 RVA: 0x000656C0 File Offset: 0x000638C0
		public bool IsEnableControl
		{
			get
			{
				return this.WU;
			}
			set
			{
				this.WU = value;
				\u000D\u0020\u000A.\u000A(this, "IsEnableControl");
			}
		}

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06000FF9 RID: 4089 RVA: 0x000656E0 File Offset: 0x000638E0
		// (set) Token: 0x06000FFA RID: 4090 RVA: 0x000656F4 File Offset: 0x000638F4
		public IDataFactory DataFactoryInstance { get; set; }

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06000FFB RID: 4091 RVA: 0x00065708 File Offset: 0x00063908
		// (set) Token: 0x06000FFC RID: 4092 RVA: 0x0006571C File Offset: 0x0006391C
		internal \u0013\u0006 MortaInstance { get; set; }

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06000FFD RID: 4093 RVA: 0x00065730 File Offset: 0x00063930
		// (set) Token: 0x06000FFE RID: 4094 RVA: 0x00065744 File Offset: 0x00063944
		public ICommand ProjectSelectionChangedCommand { get; set; }

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06000FFF RID: 4095 RVA: 0x00065758 File Offset: 0x00063958
		// (set) Token: 0x06001000 RID: 4096 RVA: 0x0006576C File Offset: 0x0006396C
		public ICommand UploadOrImportCommand { get; set; }

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06001001 RID: 4097 RVA: 0x00065780 File Offset: 0x00063980
		// (set) Token: 0x06001002 RID: 4098 RVA: 0x00065794 File Offset: 0x00063994
		public ICommand ProjectSearchTextChangedCommand { get; set; }

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06001003 RID: 4099 RVA: 0x000657A8 File Offset: 0x000639A8
		// (set) Token: 0x06001004 RID: 4100 RVA: 0x000657BC File Offset: 0x000639BC
		public ICommand TableSearchTextChangedCommand { get; set; }

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06001005 RID: 4101 RVA: 0x000657D0 File Offset: 0x000639D0
		// (set) Token: 0x06001006 RID: 4102 RVA: 0x000657E4 File Offset: 0x000639E4
		public ICommand SignButtonCommand { get; set; }

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06001007 RID: 4103 RVA: 0x000657F8 File Offset: 0x000639F8
		// (set) Token: 0x06001008 RID: 4104 RVA: 0x0006580C File Offset: 0x00063A0C
		public bool IsUpload { get; set; } = true;

		// Token: 0x06001009 RID: 4105 RVA: 0x00065820 File Offset: 0x00063A20
		public void Init()
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\ViewModel\\SingleTableUploadViewModel.cs", "Init");
			List<ProjectData> list = \u0007\u0007\u0018.\u000A(this).\u0007();
			\u000A\u0007\u0018.\u000A(list, new \u000C\u0006(true));
			\u001F\u0007\u0018.\u000A(this, list);
			\u0005\u0008\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u0009\u000A\u0018.\u000A(this)), new Predicate<object>(this.BVR));
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\ViewModel\\SingleTableUploadViewModel.cs", "Init");
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x0006589C File Offset: 0x00063A9C
		public void OnProjectSelectionChanged()
		{
			if (\u0019\u0007\u0018.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.OnProjectSelectionChanged()).MethodHandle;
				}
				List<TableInfo> list = \u0007\u0007\u0018.\u000A(this).\u0002(\u0004\u0007\u0018.\u000A(\u0019\u0007\u0018.\u000A(this)));
				\u0016\u0007\u0018.\u000A(list, new \u000C\u0006(true));
				\u0005\u0007\u0018.\u000A(this, list);
				\u0005\u0008\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u0018\u0007\u0018.\u000A(this)), new Predicate<object>(this.UVR));
				List<TableTypeInfo> u000A = \u0007\u0007\u0018.\u000A(this).\u000B(\u0004\u0007\u0018.\u000A(\u0019\u0007\u0018.\u000A(this)));
				\u001D\u0007\u0018.\u0007(\u001D\u000A\u0018.\u000A(this), u000A);
			}
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x00065948 File Offset: 0x00063B48
		public void OnProjectSearchTextChanged()
		{
			\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u0009\u000A\u0018.\u000A(this)));
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x0006596C File Offset: 0x00063B6C
		private bool BVR(object F)
		{
			if (\u0010\u0010\u001D.\u000A(\u000B\u0007\u0018.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.BVR(object)).MethodHandle;
				}
				return true;
			}
			ProjectData projectData = \u000E\u0016\u000E.\u001F(F);
			if (projectData != null)
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
				return \u000D\u0008\u000A.\u001F(\u0003\u000A\u0018.\u0007(projectData), \u000B\u0007\u0018.\u000A(this));
			}
			return false;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x000659D0 File Offset: 0x00063BD0
		public void OnTableSearchTextChanged()
		{
			if (\u0018\u0007\u0018.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.OnTableSearchTextChanged()).MethodHandle;
				}
				\u0014\u0003\u0007.\u000A(\u0011\u0009\u000A.\u000A(\u0018\u0007\u0018.\u000A(this)));
			}
		}

		// Token: 0x0600100E RID: 4110 RVA: 0x00065A10 File Offset: 0x00063C10
		private bool UVR(object F)
		{
			if (\u0010\u0010\u001D.\u000A(\u0002\u0007\u0018.\u000A(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.UVR(object)).MethodHandle;
				}
				return true;
			}
			TableInfo tableInfo = \u0010\u0016\u000E.\u001F(F);
			if (tableInfo != null)
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
				return \u000D\u0008\u000A.\u001F(\u0003\u000A\u0018.\u0007(tableInfo), \u0002\u0007\u0018.\u000A(this));
			}
			return false;
		}

		// Token: 0x0600100F RID: 4111 RVA: 0x00065A74 File Offset: 0x00063C74
		public Task CreateNewTable(TableInfo tableInfo)
		{
			SingleTableUploadViewModel.\u0018\u0006 u0018_u;
			u0018_u.\u000A = \u0008\u0011\u000A.\u000A();
			u0018_u.\u0007 = this;
			u0018_u.\u001D = tableInfo;
			u0018_u.\u001F = -1;
			u0018_u.\u000A.Start<SingleTableUploadViewModel.\u0018\u0006>(ref u0018_u);
			return \u000E\u0011\u000A.\u000A(ref u0018_u.\u000A);
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x00065AC4 File Offset: 0x00063CC4
		public Task CreateTableAndAppendRow(TableInfo tableInfo)
		{
			SingleTableUploadViewModel.\u0005\u0006 u0005_u;
			u0005_u.\u000A = \u0008\u0011\u000A.\u000A();
			u0005_u.\u0007 = this;
			u0005_u.\u001D = tableInfo;
			u0005_u.\u001F = -1;
			u0005_u.\u000A.Start<SingleTableUploadViewModel.\u0005\u0006>(ref u0005_u);
			return \u000E\u0011\u000A.\u000A(ref u0005_u.\u000A);
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x00065B14 File Offset: 0x00063D14
		protected virtual void OnSelectedTableChanged()
		{
			if (\u0004\u000A\u0018.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.OnSelectedTableChanged()).MethodHandle;
				}
				\u0009\u001F\u0018.\u000A(this, \u0003\u000A\u0018.\u0007(\u0004\u000A\u0018.\u000A(this)));
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x00065B54 File Offset: 0x00063D54
		public void UpdateTable()
		{
			if (\u0019\u0007\u0018.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.UpdateTable()).MethodHandle;
				}
				if (!\u001A\u0006\u0007.\u000A(\u001C\u0007\u0018.\u000A(this)))
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
					TableInfo tableInfo = \u0004\u000A\u0018.\u000A(this);
					string u001F;
					if (tableInfo == null)
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
						u001F = null;
					}
					else
					{
						u001F = \u0003\u000A\u0018.\u001D(tableInfo);
					}
					if (\u001D\u0017\u000A.\u000A(u001F, \u001C\u0007\u0018.\u000A(this)))
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
						tableInfo = Enumerable.FirstOrDefault<TableInfo>(\u0018\u0007\u0018.\u000A(this), new Func<TableInfo, bool>(this.JVR));
					}
					if (tableInfo != null)
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
						if (\u0008\u0013\u000A.\u000A(\u0003\u000A\u0018.\u0007(tableInfo), \u001C\u0007\u0018.\u000A(this)))
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
							if (\u001E\u000E\u0007.\u000A(\u001F\u000F.\u0005, \u0018\u000B\u0007.\u0007(this), 200.0, MessageBoxButtons.YesNo))
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
								\u0012\u0007\u0018.\u000A(this.KU, \u0003\u0007\u0018.\u0007(tableInfo));
								\u000F\u0007\u0018.\u000A(this);
								return;
							}
							return;
						}
					}
					\u0012\u0007\u0018.\u000A(this.KU, \u000F\u0015\u0010.\u001F);
					\u000F\u0007\u0018.\u000A(this);
					return;
				}
				\u0006\u0007\u0018.\u000A(this, \u001F\u000F.\u0016);
				return;
			}
			else
			{
				\u0006\u0007\u0018.\u000A(this, \u001F\u000F.\u0018);
			}
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x00065CA0 File Offset: 0x00063EA0
		protected void UpdateTableOnMorta()
		{
			\u000E\u0007\u0018.\u000A(this, false);
			\u0010\u0007\u0018.\u0007(this.KU, \u001C\u0007\u0018.\u000A(this));
			\u000E\u000A\u0018.\u000A(this.KU, \u0008\u000A\u0018.\u000A(\u001D\u000A\u0018.\u000A(this)));
			\u000D\u0007\u0018.\u000A(this, this.KU);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x00065CF0 File Offset: 0x00063EF0
		protected void ShowReportWindow()
		{
			if (\u001B\u0007\u0018.\u000A(this.reports) > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.ShowReportWindow()).MethodHandle;
				}
				ReportsWindow u001F = \u0003\u0018\u001D.\u000A(\u0008\u0007\u0018.\u000A(Enumerable.ToList<Report>(Enumerable.Cast<Report>(this.reports)), \u001E\u0011\u000A.\u000A(\u000D\u0016\u000E.\u001F()), 1005), false);
				\u0007\u0010\u001D.\u0007(u001F, \u001F\u000F.\u0012);
				\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
				\u0018\u0020\u000A.\u0007(u001F);
			}
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x00065D7C File Offset: 0x00063F7C
		private void WVR()
		{
			string u000A;
			if (!\u0008\u0013\u000A.\u000A(\u001E\u0007\u0018.\u000A(this), \u001F\u000F.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.WVR()).MethodHandle;
				}
				u000A = \u001F\u000F.\u001F;
			}
			else
			{
				u000A = \u001F\u000F.\u000A;
			}
			\u0011\u0007\u0018.\u000A(this, u000A);
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x00065DCC File Offset: 0x00063FCC
		private void KVR()
		{
			\u0008\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\ViewModel\\SingleTableUploadViewModel.cs", "ButtonSignCommand");
			if (\u0008\u0013\u000A.\u000A(\u001E\u0007\u0018.\u000A(this), \u001F\u000F.\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.KVR()).MethodHandle;
				}
				\u001A\u0007\u0018.\u000A(\u0017\u0007\u0018.\u0007(\u0007\u0007\u0018.\u000A(this)));
				this.WVR();
				\u001F\u0007\u0018.\u000A(this, \u0013\u0007\u0018.\u000A());
				\u0005\u0007\u0018.\u000A(this, \u0014\u0007\u0018.\u000A());
			}
			else
			{
				ConnectToMorta u001F = \u0020\u0007\u0018.\u000A(\u0017\u0007\u0018.\u0007(\u0007\u0007\u0018.\u000A(this)));
				\u000C\u000E\u0007.\u0007(u001F, \u0018\u000B\u0007.\u0007(this));
				bool? flag = \u0018\u0020\u000A.\u0007(u001F);
				if (\u0012\u0015\u000A.\u000A(ref flag))
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
					this.WVR();
					\u001A\u000A\u0018.\u000A(this);
				}
			}
			\u0005\u000E\u001D.\u000A(\u001B\u000A\u0018.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\Morta\\ViewModel\\SingleTableUploadViewModel.cs", "ButtonSignCommand");
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x00065EB8 File Offset: 0x000640B8
		protected void IsCancelled()
		{
			if (!\u0015\u0007\u0018.\u000A(\u0018\u000B\u0007.\u0007(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.IsCancelled()).MethodHandle;
				}
				throw \u000C\u0007\u0018.\u000A();
			}
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x00065EF4 File Offset: 0x000640F4
		protected void ShowWarningWindow(string message)
		{
			if (\u0015\u0007\u0018.\u000A(\u0018\u000B\u0007.\u0007(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SingleTableUploadViewModel.ShowWarningWindow(string)).MethodHandle;
				}
				\u000C\u000D\u001D.\u000A(message, \u0018\u000B\u0007.\u0007(this));
			}
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x00065F38 File Offset: 0x00064138
		[CompilerGenerated]
		private bool JVR(TableInfo F)
		{
			return \u0008\u0013\u000A.\u000A(\u0003\u000A\u0018.\u0007(F), \u001C\u0007\u0018.\u000A(this));
		}

		// Token: 0x04000653 RID: 1619
		private List<ProjectData> DU;

		// Token: 0x04000654 RID: 1620
		private ProjectData HU;

		// Token: 0x04000655 RID: 1621
		private List<TableInfo> YU;

		// Token: 0x04000656 RID: 1622
		private TableInfo CU;

		// Token: 0x04000657 RID: 1623
		private string LU;

		// Token: 0x04000658 RID: 1624
		private string SU;

		// Token: 0x04000659 RID: 1625
		private string BU;

		// Token: 0x0400065A RID: 1626
		private string UU = \u001F\u000F.\u001F;

		// Token: 0x0400065B RID: 1627
		private bool WU = true;

		// Token: 0x0400065C RID: 1628
		private readonly TableInfo KU;

		// Token: 0x0400065D RID: 1629
		protected List<ReportInfo> reports;

		// Token: 0x0400065E RID: 1630
		[CompilerGenerated]
		private AddComboxModel JU;

		// Token: 0x0400065F RID: 1631
		[CompilerGenerated]
		private IDataFactory EU;

		// Token: 0x04000660 RID: 1632
		[CompilerGenerated]
		private \u0013\u0006 NU;

		// Token: 0x04000661 RID: 1633
		[CompilerGenerated]
		private ICommand MU;

		// Token: 0x04000662 RID: 1634
		[CompilerGenerated]
		private ICommand VU;

		// Token: 0x04000663 RID: 1635
		[CompilerGenerated]
		private ICommand ZU;

		// Token: 0x04000664 RID: 1636
		[CompilerGenerated]
		private ICommand XU;

		// Token: 0x04000665 RID: 1637
		[CompilerGenerated]
		private ICommand PU;

		// Token: 0x04000666 RID: 1638
		[CompilerGenerated]
		private bool OU;
	}
}
