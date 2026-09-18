using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.Models;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x0200014B RID: 331
	public class ExcelFileInfoViewModel : FileInfoViewModel
	{
		// Token: 0x06000C3F RID: 3135 RVA: 0x0004E024 File Offset: 0x0004C224
		public ExcelFileInfoViewModel(string filePath, IList<WorksheetViewModel> worksheets) : base(filePath)
		{
			\u0003\u000A\u0019.\u000A(this, true);
			\u0012\u000A\u0019.\u000A(this, Enumerable.ToList<WorksheetViewModel>(worksheets));
			\u0002\u000A\u0019.\u000A(this, \u0006\u000A\u0019.\u000A(\u000F\u000A\u0019.\u0007(this)));
			\u000B\u000A\u0019.\u000A(this, new CommandBase(new Action(this.XNR), \u0002\u0015\u0010.\u001F));
			\u0016\u000A\u0019.\u000A(this, new CommandBase<bool>(new Action<bool>(this.PNR), null));
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06000C40 RID: 3136 RVA: 0x0004E0A4 File Offset: 0x0004C2A4
		// (set) Token: 0x06000C41 RID: 3137 RVA: 0x0004E0B8 File Offset: 0x0004C2B8
		public bool? AllSheetsChecked
		{
			get
			{
				return this.DS;
			}
			set
			{
				base.SetProperty<bool?>(ref this.DS, value, null, "AllSheetsChecked");
			}
		}

		// Token: 0x17000364 RID: 868
		// (get) Token: 0x06000C42 RID: 3138 RVA: 0x0004E0DC File Offset: 0x0004C2DC
		// (set) Token: 0x06000C43 RID: 3139 RVA: 0x0004E0F0 File Offset: 0x0004C2F0
		public bool IsExpanded
		{
			get
			{
				return this.HS;
			}
			set
			{
				base.SetProperty<bool>(ref this.HS, value, null, "IsExpanded");
			}
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x06000C44 RID: 3140 RVA: 0x0004E114 File Offset: 0x0004C314
		// (set) Token: 0x06000C45 RID: 3141 RVA: 0x0004E128 File Offset: 0x0004C328
		public List<WorksheetViewModel> Worksheets { get; set; }

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x06000C46 RID: 3142 RVA: 0x0004E13C File Offset: 0x0004C33C
		// (set) Token: 0x06000C47 RID: 3143 RVA: 0x0004E150 File Offset: 0x0004C350
		public ICommand WorksheetCheckedCmd { get; set; }

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x06000C48 RID: 3144 RVA: 0x0004E164 File Offset: 0x0004C364
		// (set) Token: 0x06000C49 RID: 3145 RVA: 0x0004E178 File Offset: 0x0004C378
		public ICommand CheckAllWorksheetsCmd { get; set; }

		// Token: 0x06000C4A RID: 3146 RVA: 0x0004E18C File Offset: 0x0004C38C
		private void XNR()
		{
			this.ONR();
		}

		// Token: 0x06000C4B RID: 3147 RVA: 0x0004E1A0 File Offset: 0x0004C3A0
		private void PNR(bool F)
		{
			ExcelFileInfoViewModel.\u000C\u0016 u000C_u = new ExcelFileInfoViewModel.\u000C\u0016();
			u000C_u.\u001F = F;
			\u001C\u000A\u0019.\u000A(\u000F\u000A\u0019.\u0007(this), new Action<WorksheetViewModel>(u000C_u.\u000A));
			this.ONR();
		}

		// Token: 0x06000C4C RID: 3148 RVA: 0x0004E1DC File Offset: 0x0004C3DC
		private void ONR()
		{
			IEnumerable<WorksheetViewModel> enumerable = \u000F\u000A\u0019.\u0007(this);
			Func<WorksheetViewModel, bool> func;
			if ((func = ExcelFileInfoViewModel.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(ExcelFileInfoViewModel.ONR()).MethodHandle;
				}
				func = (ExcelFileInfoViewModel.<>c.\u000A = new Func<WorksheetViewModel, bool>(ExcelFileInfoViewModel.<>c.\u001F.\u0007));
			}
			int num = Enumerable.Count<WorksheetViewModel>(enumerable, func);
			if (num != 0)
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
				bool? u000A;
				if (num != \u0006\u000A\u0019.\u000A(\u000F\u000A\u0019.\u0007(this)))
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
					bool? flag;
					\u001B\u000A\u000E.\u001F(ref flag);
					u000A = flag;
				}
				else
				{
					u000A = new bool?(true);
				}
				\u000D\u000A\u0019.\u000A(this, u000A);
			}
			else
			{
				\u000D\u000A\u0019.\u000A(this, new bool?(false));
			}
			\u0002\u000A\u0019.\u000A(this, num);
			\u000D\u0020\u000A.\u000A(this, "ViewsCount");
		}

		// Token: 0x040004DA RID: 1242
		private bool? DS = new bool?(true);

		// Token: 0x040004DB RID: 1243
		private bool HS;

		// Token: 0x040004DC RID: 1244
		[CompilerGenerated]
		private List<WorksheetViewModel> YS;

		// Token: 0x040004DD RID: 1245
		[CompilerGenerated]
		private ICommand CS;

		// Token: 0x040004DE RID: 1246
		[CompilerGenerated]
		private ICommand LS;

		// Token: 0x02000826 RID: 2086
		[CompilerGenerated]
		private sealed class \u000C\u0016
		{
			// Token: 0x06004DE7 RID: 19943 RVA: 0x001DF3D4 File Offset: 0x001DD5D4
			internal void \u000A(WorksheetViewModel \u001F)
			{
				\u0003\u000A\u0010.\u000A(\u001F, this.\u001F);
			}

			// Token: 0x04002091 RID: 8337
			public bool \u001F;
		}
	}
}
