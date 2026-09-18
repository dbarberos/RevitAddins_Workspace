using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.TableGen.ViewModels;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x02000168 RID: 360
	public class FileInfoExtractionService : IFileInfoExtractionService
	{
		// Token: 0x06000D68 RID: 3432 RVA: 0x000566B4 File Offset: 0x000548B4
		public FileInfoExtractionService()
		{
			this.\u0019 = \u0016\u0010\u001D.\u000A(\u0007\u0018.\u0007<DocumentContext>());
		}

		// Token: 0x06000D69 RID: 3433 RVA: 0x000566F4 File Offset: 0x000548F4
		public void Initialize(long importTypes, long viewTypeId, int viewScale)
		{
			this.\u001F = \u0008\u0006\u0019.\u000A();
			this.\u000A = \u0008\u0006\u0019.\u000A();
			this.\u001D = viewTypeId;
			this.\u0007 = (ImportTypes)importTypes;
			this.\u0004 = viewScale;
		}

		// Token: 0x06000D6A RID: 3434 RVA: 0x00056734 File Offset: 0x00054934
		public SelectedExcel ExtractFromFile(string filePath)
		{
			long num = this.\u001D;
			SelectedExcel selectedExcel;
			if (\u000C\u0019.\u0016(filePath))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.ExtractFromFile(string)).MethodHandle;
				}
				selectedExcel = this.\u0005(filePath, true);
			}
			else
			{
				long num2;
				if (this.\u001D != 5L)
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
					num2 = this.\u001D;
				}
				else
				{
					num2 = (long)\u000D\u001B\u001D.\u0007(\u0016\u0008\u0004.\u000A(\u001D\u0016.\u001D(), 0));
				}
				num = num2;
				selectedExcel = this.\u0018(filePath, num);
			}
			\u001B\u0006\u0019.\u000A(this.\u0012(num), \u0014\u0005\u0004.\u0007(selectedExcel));
			return selectedExcel;
		}

		// Token: 0x06000D6B RID: 3435 RVA: 0x000567CC File Offset: 0x000549CC
		public List<SelectedExcel> ExtractFromFileViewModel(IFileInfoViewModel fileInfoViewModel)
		{
			List<SelectedExcel> list = \u0003\u000B\u0004.\u000A();
			ExcelFileInfoViewModel excelFileInfoViewModel = \u0002\u0005\u000E.\u001F(fileInfoViewModel);
			if (excelFileInfoViewModel != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.ExtractFromFileViewModel(IFileInfoViewModel)).MethodHandle;
				}
				\u0001\u0007\u0019.\u000A(list, this.\u0016(excelFileInfoViewModel));
			}
			else
			{
				\u0001\u0007\u0019.\u000A(list, this.\u000B(fileInfoViewModel));
			}
			return list;
		}

		// Token: 0x06000D6C RID: 3436 RVA: 0x00056824 File Offset: 0x00054A24
		private SelectedExcel \u0018(string \u001F, long \u000A)
		{
			SelectedExcel selectedExcel = this.\u001C(\u001F, \u000A, ImportTypes.Image);
			List<SheetAndNamedRange> list = \u001E\u0006\u0019.\u000A(1);
			\u0008\u0009\u0004.\u000A(list, \u0011\u0006\u0019.\u000A());
			\u001E\u001B\u0004.\u001D(selectedExcel, list);
			\u001B\u001B\u0004.\u001D(selectedExcel, "N/A");
			\u001F\u001B\u0004.\u001D(selectedExcel, \u0015\u000E\u0004.\u000A(\u001D\u001B\u0004.\u000A(\u0004\u001B\u0004.\u000A(\u0018\u001B\u0004.\u001D(selectedExcel), 0)), 0));
			EnumInfo u000A;
			if (!FilePathHelper.\u001D(\u0011\u0020\u001D.\u0007(selectedExcel)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u0018(string, long)).MethodHandle;
				}
				u000A = \u000B\u0008\u0004.\u000A(SourceTypes.Word);
			}
			else
			{
				u000A = \u000B\u0008\u0004.\u000A(SourceTypes.Pdf);
			}
			\u000D\u0020\u0004.\u000A(selectedExcel, u000A);
			\u0004\u0017\u0004.\u000A(selectedExcel, this.\u0006(\u0012\u0015\u001D.\u000A(\u001F), \u000A));
			return selectedExcel;
		}

		// Token: 0x06000D6D RID: 3437 RVA: 0x000568E4 File Offset: 0x00054AE4
		private SelectedExcel \u0005(string \u001F, bool \u000A)
		{
			SelectedExcel selectedExcel = this.\u001C(\u001F, this.\u001D, this.\u0007);
			\u000D\u0020\u0004.\u000A(selectedExcel, \u000B\u0008\u0004.\u000A(SourceTypes.Excel));
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u0005(string, bool)).MethodHandle;
				}
				this.\u0002(selectedExcel);
			}
			return selectedExcel;
		}

		// Token: 0x06000D6E RID: 3438 RVA: 0x00056938 File Offset: 0x00054B38
		private IEnumerable<SelectedExcel> \u0016(ExcelFileInfoViewModel \u001F)
		{
			FileInfoExtractionService.\u0008\u000B u0008_u000B = new FileInfoExtractionService.\u0008\u000B(-2);
			u0008_u000B.\u0019 = this;
			u0008_u000B.\u0004 = \u001F;
			return u0008_u000B;
		}

		// Token: 0x06000D6F RID: 3439 RVA: 0x0005695C File Offset: 0x00054B5C
		private IEnumerable<SelectedExcel> \u000B(IFileInfoViewModel \u001F)
		{
			FileInfoExtractionService.\u001B\u000B u001B_u000B = new FileInfoExtractionService.\u001B\u000B(-2);
			u001B_u000B.\u001D = this;
			u001B_u000B.\u0019 = \u001F;
			return u001B_u000B;
		}

		// Token: 0x06000D70 RID: 3440 RVA: 0x00056980 File Offset: 0x00054B80
		private void \u0002(SelectedExcel \u001F)
		{
			\u001E\u001B\u0004.\u001D(\u001F, FileInfoExtractionService.\u0003(\u0011\u0020\u001D.\u0007(\u001F)));
			List<string> list = \u0011\u001B\u0004.\u001D(\u001F);
			string u000A;
			if (list == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u0002(SelectedExcel)).MethodHandle;
				}
				u000A = \u000F\u0015\u0010.\u001F;
			}
			else
			{
				u000A = Enumerable.FirstOrDefault<string>(list);
			}
			\u001B\u001B\u0004.\u001D(\u001F, u000A);
			\u001F\u001B\u0004.\u001D(\u001F, NamedRangeInfo.\u000A(\u000A\u001B\u0004.\u001D(\u001F)));
			\u0004\u0017\u0004.\u000A(\u001F, this.\u0006(\u0020\u0020\u001D.\u0007(\u001F), (long)\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u001F))));
		}

		// Token: 0x06000D71 RID: 3441 RVA: 0x00056A10 File Offset: 0x00054C10
		private string \u0006(string \u001F, long \u000A)
		{
			string text = \u0003\u000B\u001D.\u0007(\u0017\u0006\u0019.\u000A(\u001F));
			int num = 1;
			string text2 = text;
			HashSet<string> u001F = \u0020\u0006\u0019.\u000A(Enumerable.Union<string>(this.\u000F(\u000A), this.\u0012(\u000A)));
			while (\u0017\u0018\u0019.\u000A(u001F, text2))
			{
				text2 = \u0018\u000E\u0007.\u000A("{0} {1:D3}", text, num);
				num++;
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
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u0006(string, long)).MethodHandle;
			}
			return text2;
		}

		// Token: 0x06000D72 RID: 3442 RVA: 0x00056A8C File Offset: 0x00054C8C
		private HashSet<string> \u000F(long \u001F)
		{
			if (!\u0001\u0006\u0019.\u000A(this.\u001F, \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u000F(long)).MethodHandle;
				}
				Dictionary<long, HashSet<string>> u001F = this.\u001F;
				HashSet<string> hashSet = \u0015\u0006\u0019.\u000A();
				IEnumerable<View> enumerable = \u0015\u0018.\u001D(this.\u0019, (int)\u001F);
				Func<View, string> func;
				if ((func = FileInfoExtractionService.<>c.\u0007) == null)
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
					func = (FileInfoExtractionService.<>c.\u0007 = new Func<View, string>(FileInfoExtractionService.<>c.\u001F.\u0018));
				}
				IEnumerator<string> enumerator = \u000C\u0006\u0019.\u000A(Enumerable.Select<View, string>(enumerable, func));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						string u000A = \u001A\u0006\u0019.\u000A(enumerator);
						\u001B\u0006\u0019.\u000A(hashSet, u000A);
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				\u0013\u0006\u0019.\u000A(u001F, \u001F, hashSet);
			}
			return \u0014\u0006\u0019.\u000A(this.\u001F, \u001F);
		}

		// Token: 0x06000D73 RID: 3443 RVA: 0x00056B80 File Offset: 0x00054D80
		private HashSet<string> \u0012(long \u001F)
		{
			FileInfoExtractionService.\u0010\u000B u0010_u000B = new FileInfoExtractionService.\u0010\u000B();
			u0010_u000B.\u001F = \u001F;
			if (!\u0001\u0006\u0019.\u000A(this.\u000A, u0010_u000B.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u0012(long)).MethodHandle;
				}
				Dictionary<long, HashSet<string>> u000A = this.\u000A;
				long u001F = u0010_u000B.\u001F;
				HashSet<string> hashSet = \u0015\u0006\u0019.\u000A();
				IEnumerable<SelectedExcel> enumerable = Enumerable.Where<SelectedExcel>(\u001C\u001B\u0004.\u000A(), new Func<SelectedExcel, bool>(u0010_u000B.\u000A));
				Func<SelectedExcel, string> func;
				if ((func = FileInfoExtractionService.<>c.\u001D) == null)
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
					func = (FileInfoExtractionService.<>c.\u001D = new Func<SelectedExcel, string>(FileInfoExtractionService.<>c.\u001F.\u0005));
				}
				IEnumerator<string> enumerator = \u000C\u0006\u0019.\u000A(Enumerable.Select<SelectedExcel, string>(enumerable, func));
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						string u000A2 = \u001A\u0006\u0019.\u000A(enumerator);
						\u001B\u0006\u0019.\u000A(hashSet, u000A2);
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
				\u0013\u0006\u0019.\u000A(u000A, u001F, hashSet);
			}
			return \u0014\u0006\u0019.\u000A(this.\u000A, u0010_u000B.\u001F);
		}

		// Token: 0x06000D74 RID: 3444 RVA: 0x00056CA0 File Offset: 0x00054EA0
		private static List<SheetAndNamedRange> \u0003(string \u001F)
		{
			IEnumerable<KeyValuePair<string, List<NamedRangeInfo>>> enumerable = \u0013\u0019.\u001F(\u001F);
			Func<KeyValuePair<string, List<NamedRangeInfo>>, SheetAndNamedRange> func;
			if ((func = FileInfoExtractionService.<>c.\u0004) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u0003(string)).MethodHandle;
				}
				func = (FileInfoExtractionService.<>c.\u0004 = new Func<KeyValuePair<string, List<NamedRangeInfo>>, SheetAndNamedRange>(FileInfoExtractionService.<>c.\u001F.\u0016));
			}
			return Enumerable.ToList<SheetAndNamedRange>(Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, SheetAndNamedRange>(enumerable, func));
		}

		// Token: 0x06000D75 RID: 3445 RVA: 0x00056CF8 File Offset: 0x00054EF8
		private SelectedExcel \u001C(string \u001F, long \u000A, ImportTypes \u0007)
		{
			FileInfoExtractionService.\u000E\u000B u000E_u000B = new FileInfoExtractionService.\u000E\u000B();
			u000E_u000B.\u001F = \u000A;
			SelectedExcel selectedExcel = \u0001\u0009\u0004.\u000A(Enumerable.FirstOrDefault<EnumInfo>(\u001D\u0016.\u001D(), new Func<EnumInfo, bool>(u000E_u000B.\u000A)));
			\u000D\u0016\u0004.\u0007(selectedExcel, UpdateStates.ToAdd);
			\u000C\u0011\u0004.\u001D(selectedExcel, \u001F);
			DateTime dateTime = \u0017\u0016\u0004.\u000A();
			\u001E\u0016\u0004.\u000A(selectedExcel, \u0020\u0016\u0004.\u000A(ref dateTime, "MM/dd/yyyy HH:mm:ss"));
			\u0007\u001E\u0004.\u000A(selectedExcel, \u000B\u0008\u0004.\u000A(PageOptions.All));
			\u001B\u0020\u0004.\u000A(selectedExcel, string.Empty);
			\u000A\u001E\u0004.\u000A(selectedExcel, 300);
			\u0009\u001B\u0004.\u000A(selectedExcel, \u000B\u0008\u0004.\u000A(\u0007));
			\u001B\u0011\u0004.\u000A(\u001D\u0011\u0004.\u001D(selectedExcel), (int)\u0007);
			int u000A;
			if (!\u000C\u0008\u0004.\u000A(\u0006\u0020\u001D.\u0007(selectedExcel), 5))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u001C(string, long, ImportTypes)).MethodHandle;
				}
				u000A = this.\u0004;
			}
			else
			{
				u000A = 1;
			}
			\u0012\u001B\u0004.\u001D(selectedExcel, u000A);
			return selectedExcel;
		}

		// Token: 0x0400054E RID: 1358
		private Dictionary<long, HashSet<string>> \u001F = new Dictionary<long, HashSet<string>>();

		// Token: 0x0400054F RID: 1359
		private Dictionary<long, HashSet<string>> \u000A = new Dictionary<long, HashSet<string>>();

		// Token: 0x04000550 RID: 1360
		private ImportTypes \u0007;

		// Token: 0x04000551 RID: 1361
		private long \u001D;

		// Token: 0x04000552 RID: 1362
		private int \u0004;

		// Token: 0x04000553 RID: 1363
		private readonly Document \u0019;

		// Token: 0x0200083F RID: 2111
		[CompilerGenerated]
		private sealed class \u000D\u000B
		{
			// Token: 0x06004E3A RID: 20026 RVA: 0x001E0144 File Offset: 0x001DE344
			internal bool \u000A(string \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u001F, \u0005\u0007\u0010.\u000A(this.\u001F));
			}

			// Token: 0x06004E3B RID: 20027 RVA: 0x001E0168 File Offset: 0x001DE368
			internal bool \u0007(NamedRangeInfo \u001F)
			{
				string u001F = \u001B\u0012\u0004.\u001D(\u001F);
				SheetRegionViewModel sheetRegionViewModel = \u0016\u0007\u0010.\u000A(this.\u001F);
				string u000A;
				if (sheetRegionViewModel == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoExtractionService.\u000D\u000B.\u0007(NamedRangeInfo)).MethodHandle;
					}
					u000A = \u000F\u0015\u0010.\u001F;
				}
				else
				{
					u000A = \u0014\u000A\u0019.\u0007(sheetRegionViewModel);
				}
				return \u0008\u0013\u000A.\u000A(u001F, u000A);
			}

			// Token: 0x040020E5 RID: 8421
			public WorksheetViewModel \u001F;
		}

		// Token: 0x02000840 RID: 2112
		[CompilerGenerated]
		private sealed class \u0010\u000B
		{
			// Token: 0x06004E3D RID: 20029 RVA: 0x001E01CC File Offset: 0x001DE3CC
			internal bool \u000A(SelectedExcel \u001F)
			{
				return (long)\u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(\u001F)) == this.\u001F;
			}

			// Token: 0x040020E6 RID: 8422
			public long \u001F;
		}

		// Token: 0x02000841 RID: 2113
		[CompilerGenerated]
		private sealed class \u000E\u000B
		{
			// Token: 0x06004E3F RID: 20031 RVA: 0x001E0208 File Offset: 0x001DE408
			internal bool \u000A(EnumInfo \u001F)
			{
				return (long)\u000D\u001B\u001D.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x040020E7 RID: 8423
			public long \u001F;
		}
	}
}
