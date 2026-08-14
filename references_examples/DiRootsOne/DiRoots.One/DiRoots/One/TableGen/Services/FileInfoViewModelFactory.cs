using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.TableGen.ViewModels;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x0200016A RID: 362
	public class FileInfoViewModelFactory : IFileInfoViewModelFactory
	{
		// Token: 0x06000D78 RID: 3448 RVA: 0x00056DF4 File Offset: 0x00054FF4
		public IFileInfoViewModel Create(string filePath)
		{
			if (\u000C\u0019.\u0016(filePath))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoViewModelFactory.Create(string)).MethodHandle;
				}
				return \u001F\u000F\u0019.\u000A(filePath, FileInfoViewModelFactory.\u001F(filePath));
			}
			return \u0009\u0006\u0019.\u000A(filePath);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x00056E38 File Offset: 0x00055038
		private static List<WorksheetViewModel> \u001F(string \u001F)
		{
			IEnumerable<KeyValuePair<string, List<NamedRangeInfo>>> enumerable = \u0013\u0019.\u001F(\u001F);
			Func<KeyValuePair<string, List<NamedRangeInfo>>, WorksheetViewModel> func;
			if ((func = FileInfoViewModelFactory.<>c.\u0007) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(FileInfoViewModelFactory.\u001F(string)).MethodHandle;
				}
				func = (FileInfoViewModelFactory.<>c.\u0007 = new Func<KeyValuePair<string, List<NamedRangeInfo>>, WorksheetViewModel>(FileInfoViewModelFactory.<>c.\u001F.\u0004));
			}
			IEnumerable<WorksheetViewModel> enumerable2 = Enumerable.Select<KeyValuePair<string, List<NamedRangeInfo>>, WorksheetViewModel>(enumerable, func);
			Func<WorksheetViewModel, bool> func2;
			if ((func2 = FileInfoViewModelFactory.<>c.\u001D) == null)
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
				func2 = (FileInfoViewModelFactory.<>c.\u001D = new Func<WorksheetViewModel, bool>(FileInfoViewModelFactory.<>c.\u001F.\u0018));
			}
			return Enumerable.ToList<WorksheetViewModel>(Enumerable.Where<WorksheetViewModel>(enumerable2, func2));
		}

		// Token: 0x02000845 RID: 2117
		[CompilerGenerated]
		private sealed class \u0011\u000B
		{
			// Token: 0x06004E57 RID: 20055 RVA: 0x001E0994 File Offset: 0x001DEB94
			internal bool \u000A(SheetRegionViewModel \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0014\u000A\u0019.\u001D(\u001F), \u0017\u0020\u001D.\u0007(this.\u001F));
			}

			// Token: 0x040020FC RID: 8444
			public NamedRangeInfo \u001F;
		}
	}
}
