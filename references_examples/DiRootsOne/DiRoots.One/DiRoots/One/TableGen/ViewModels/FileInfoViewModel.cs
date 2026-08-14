using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.ViewModels;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.ViewModels
{
	// Token: 0x0200014D RID: 333
	public class FileInfoViewModel : ViewModelBase, IFileInfoViewModel
	{
		// Token: 0x06000C58 RID: 3160 RVA: 0x0004E28C File Offset: 0x0004C48C
		public FileInfoViewModel(string filePath)
		{
			\u001B\u000A\u0019.\u000A(this, \u0012\u0015\u001D.\u000A(filePath));
			\u0008\u000A\u0019.\u000A(this, filePath);
			\u000E\u000A\u0019.\u000A(this, filePath);
			\u0010\u000A\u0019.\u0007(this, FileInfoViewModel.TNR(filePath));
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000C59 RID: 3161 RVA: 0x0004E2D4 File Offset: 0x0004C4D4
		// (set) Token: 0x06000C5A RID: 3162 RVA: 0x0004E2E8 File Offset: 0x0004C4E8
		public string Name { get; set; }

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000C5B RID: 3163 RVA: 0x0004E2FC File Offset: 0x0004C4FC
		// (set) Token: 0x06000C5C RID: 3164 RVA: 0x0004E310 File Offset: 0x0004C510
		public string Path { get; set; }

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x0004E324 File Offset: 0x0004C524
		// (set) Token: 0x06000C5E RID: 3166 RVA: 0x0004E338 File Offset: 0x0004C538
		public string RelativePath { get; set; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06000C5F RID: 3167 RVA: 0x0004E34C File Offset: 0x0004C54C
		// (set) Token: 0x06000C60 RID: 3168 RVA: 0x0004E360 File Offset: 0x0004C560
		public bool ShowRelativePath { get; set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06000C61 RID: 3169 RVA: 0x0004E374 File Offset: 0x0004C574
		// (set) Token: 0x06000C62 RID: 3170 RVA: 0x0004E388 File Offset: 0x0004C588
		public string DisplayPath { get; set; }

		// Token: 0x17000375 RID: 885
		// (get) Token: 0x06000C63 RID: 3171 RVA: 0x0004E39C File Offset: 0x0004C59C
		// (set) Token: 0x06000C64 RID: 3172 RVA: 0x0004E3B0 File Offset: 0x0004C5B0
		public bool HasItems { get; set; }

		// Token: 0x17000376 RID: 886
		// (get) Token: 0x06000C65 RID: 3173 RVA: 0x0004E3C4 File Offset: 0x0004C5C4
		// (set) Token: 0x06000C66 RID: 3174 RVA: 0x0004E3D8 File Offset: 0x0004C5D8
		public int ViewsCount { get; set; } = 1;

		// Token: 0x17000377 RID: 887
		// (get) Token: 0x06000C67 RID: 3175 RVA: 0x0004E3EC File Offset: 0x0004C5EC
		// (set) Token: 0x06000C68 RID: 3176 RVA: 0x0004E400 File Offset: 0x0004C600
		public SourceTypes SourceType { get; set; }

		// Token: 0x06000C69 RID: 3177 RVA: 0x0004E414 File Offset: 0x0004C614
		public void UpdateDisplayPath()
		{
			string u000A;
			if (!\u0020\u000A\u0019.\u000A(this))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoViewModel.UpdateDisplayPath()).MethodHandle;
				}
				u000A = \u001E\u000A\u0019.\u0007(this);
			}
			else
			{
				u000A = \u0011\u000A\u0019.\u000A(this);
			}
			\u0008\u000A\u0019.\u000A(this, u000A);
			\u000D\u0020\u000A.\u000A(this, "DisplayPath");
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x0004E464 File Offset: 0x0004C664
		private static SourceTypes TNR(string F)
		{
			if (\u000C\u0019.\u0016(F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoViewModel.TNR(string)).MethodHandle;
				}
				return SourceTypes.Excel;
			}
			if (!FilePathHelper.\u001D(F))
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
				return SourceTypes.Word;
			}
			return SourceTypes.Pdf;
		}

		// Token: 0x040004DF RID: 1247
		[CompilerGenerated]
		private string SS;

		// Token: 0x040004E0 RID: 1248
		[CompilerGenerated]
		private string BS;

		// Token: 0x040004E1 RID: 1249
		[CompilerGenerated]
		private string US;

		// Token: 0x040004E2 RID: 1250
		[CompilerGenerated]
		private bool WS;

		// Token: 0x040004E3 RID: 1251
		[CompilerGenerated]
		private string KS;

		// Token: 0x040004E4 RID: 1252
		[CompilerGenerated]
		private bool JS;

		// Token: 0x040004E5 RID: 1253
		[CompilerGenerated]
		private int ES;

		// Token: 0x040004E6 RID: 1254
		[CompilerGenerated]
		private SourceTypes NS;
	}
}
