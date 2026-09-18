using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using A;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Progress;
using DiRoots.One.TableGen.Models;
using DiRoots.One.TableGen.TableGen.Models;
using DiRoots.One.TableGen.UI;
using DiRoots.One.TableGen.ViewModels;
using DiRoots.One.TGDatabaseLayer;

namespace DiRoots.One.TableGen.Services
{
	// Token: 0x0200016E RID: 366
	public class WorksheetSelectionWindowService : IWorksheetSelectionWindowService
	{
		// Token: 0x06000D80 RID: 3456 RVA: 0x00056F40 File Offset: 0x00055140
		public WorksheetSelectionWindowService(ProgressWindowService progressWindowService, IFileInfoExtractionService fileInfoExtractionService, IFileInfoViewModelFactory fileInfoViewModelFactory, IReportWindowService reportWindowService, Func<Window> ownerWindowProvider)
		{
			this.\u001F = progressWindowService;
			this.\u0007 = fileInfoExtractionService;
			this.\u001D = fileInfoViewModelFactory;
			this.\u0004 = reportWindowService;
			this.\u0019 = ownerWindowProvider;
		}

		// Token: 0x06000D81 RID: 3457 RVA: 0x00056F84 File Offset: 0x00055184
		// Note: this type is marked as 'beforefieldinit'.
		static WorksheetSelectionWindowService()
		{
			HashSet<string> hashSet = \u0015\u0006\u0019.\u000A();
			\u001B\u0006\u0019.\u000A(hashSet, ".xlsx");
			\u001B\u0006\u0019.\u000A(hashSet, ".xlsm");
			\u001B\u0006\u0019.\u000A(hashSet, ".docx");
			\u001B\u0006\u0019.\u000A(hashSet, ".pdf");
			WorksheetSelectionWindowService.\u0005 = hashSet;
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06000D82 RID: 3458 RVA: 0x00056FD8 File Offset: 0x000551D8
		// (set) Token: 0x06000D83 RID: 3459 RVA: 0x00056FEC File Offset: 0x000551EC
		public static WorksheetSelectionDto WorksheetSelectionDto { get; set; }

		// Token: 0x06000D84 RID: 3460 RVA: 0x00057000 File Offset: 0x00055200
		public bool? ShowSelectionWindow(List<string> filePaths)
		{
			WorksheetSelectionWindowService.\u0020\u000B u0020_u000B = new WorksheetSelectionWindowService.\u0020\u000B();
			u0020_u000B.\u001F = this;
			u0020_u000B.\u000A = filePaths;
			u0020_u000B.\u0007 = \u0018\u000F\u0019.\u000A();
			Func<Window> u = this.\u0019;
			Window window;
			if (u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.ShowSelectionWindow(List<string>)).MethodHandle;
				}
				window = \u000D\u0018\u000E.\u001F;
			}
			else
			{
				window = \u0019\u000F\u0019.\u000A(u);
			}
			Window window2 = window;
			this.\u000B();
			\u0004\u000F\u0019.\u000A(u0020_u000B.\u000A);
			List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(Enumerable.ToList<string>(u0020_u000B.\u000A));
			try
			{
				while (\u0017\u0008\u0007.\u000A(ref enumerator))
				{
					string text = \u0014\u0008\u0007.\u000A(ref enumerator);
					if (!WorksheetSelectionWindowService.\u001C(text))
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
						\u001D\u000F\u0019.\u0007(u0020_u000B.\u0007, WorksheetSelectionWindowService.\u000D(text));
						\u000F\u0010\u0007.\u000A(u0020_u000B.\u000A, text);
					}
				}
				for (;;)
				{
					switch (2)
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
			if (\u0015\u0007\u0019.\u000A(u0020_u000B.\u000A) == 0)
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
				this.\u0003(u0020_u000B.\u0007, window2);
				return new bool?(false);
			}
			\u000B\u0008\u001D.\u000A(this.\u001F, window2);
			\u001D\u001D\u0019.\u000A(this.\u001F, new ContentRenderedDelegate(u0020_u000B.\u001D));
			\u000A\u001D\u0019.\u000A(this.\u001F, \u0007\u000F\u0019.\u000A(), \u0015\u0007\u0019.\u000A(u0020_u000B.\u000A));
			if (\u000A\u000F\u0019.\u000A(this.\u0018) == 0)
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
				this.\u0003(u0020_u000B.\u0007, window2);
				return new bool?(false);
			}
			this.\u0003(u0020_u000B.\u0007, window2);
			return \u0018\u0020\u000A.\u0007(this.\u0002(window2));
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x000571B0 File Offset: 0x000553B0
		public bool? ShowSelectionWindow(string filePath)
		{
			Func<Window> u = this.\u0019;
			Window window;
			if (u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.ShowSelectionWindow(string)).MethodHandle;
				}
				window = \u000D\u0018\u000E.\u001F;
			}
			else
			{
				window = \u0019\u000F\u0019.\u000A(u);
			}
			Window window2 = window;
			this.\u000B();
			if (!WorksheetSelectionWindowService.\u001C(filePath))
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
				this.\u0003(new \u0010<Report>(WorksheetSelectionWindowService.\u000D(filePath)), window2);
				return new bool?(false);
			}
			DragReportInfo u001F;
			IFileInfoViewModel fileInfoViewModel = this.\u0012(filePath, out u001F);
			if (fileInfoViewModel == null)
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
				this.\u0003(new \u0010<Report>(u001F), window2);
				return new bool?(false);
			}
			List<IFileInfoViewModel> list = \u0005\u000F\u0019.\u000A(1);
			\u000A\u0004\u0019.\u000A(list, fileInfoViewModel);
			this.\u0018 = list;
			return \u0018\u0020\u000A.\u0007(this.\u0002(window2));
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00057270 File Offset: 0x00055470
		public List<SelectedExcel> GetSelectedItems()
		{
			\u000B\u000F\u0019.\u000A(this.\u0007, (long)\u000D\u001B\u001D.\u0007(\u000E\u0004\u0019.\u001D(this.\u000A)), (long)\u000D\u001B\u001D.\u0007(\u0010\u0004\u0019.\u001D(this.\u000A)), \u0002\u000F\u0019.\u000A(this.\u000A));
			List<SelectedExcel> list = Enumerable.ToList<SelectedExcel>(Enumerable.SelectMany<IFileInfoViewModel, SelectedExcel>(this.\u0018, new Func<IFileInfoViewModel, IEnumerable<SelectedExcel>>(this.\u0007.ExtractFromFileViewModel)));
			if (\u0016\u000F\u0019.\u000A(this.\u000A))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.GetSelectedItems()).MethodHandle;
				}
				List<SelectedExcel>.Enumerator enumerator = \u000A\u0016\u0004.\u000A(list);
				try
				{
					while (\u0001\u0005\u0004.\u000A(ref enumerator))
					{
						SelectedExcel u001F = \u001F\u0016\u0004.\u000A(ref enumerator);
						\u001A\u0008\u0004.\u000A(\u000A\u000B\u0004.\u0007(u001F), \u000C\u0008\u0004.\u000A(\u0015\u0016\u0004.\u0007(u001F), ImportTypes.Table));
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
					((IDisposable)enumerator).Dispose();
				}
			}
			return list;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00057378 File Offset: 0x00055578
		private void \u000B()
		{
			this.\u0018 = \u0006\u000F\u0019.\u000A();
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00057394 File Offset: 0x00055594
		private WorksheetSelectionWindow \u0002(Window \u001F)
		{
			this.\u000A = \u0008\u000F\u0019.\u000A(this.\u0018, \u0003\u000F\u0019.\u000A());
			WorksheetSelectionWindow worksheetSelectionWindow = \u000E\u000F\u0019.\u000A();
			\u0017\u001A\u000A.\u001D(worksheetSelectionWindow, this.\u000A);
			\u000C\u000E\u0007.\u0007(worksheetSelectionWindow, \u001F);
			\u0020\u0014\u000A.\u0007(worksheetSelectionWindow, WindowStartupLocation.CenterOwner);
			WorksheetSelectionWindow worksheetSelectionWindow2 = worksheetSelectionWindow;
			\u0016\u0015\u0007.\u0007(worksheetSelectionWindow2, new EventHandler(this.\u0006));
			if (\u0003\u000F\u0019.\u000A() != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.\u0002(Window)).MethodHandle;
				}
				object u001F = worksheetSelectionWindow2;
				double u000A;
				if (\u000D\u000F\u0019.\u000A(\u0003\u000F\u0019.\u000A()) <= 0.0)
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
					u000A = \u0010\u000F\u0019.\u0007(worksheetSelectionWindow2);
				}
				else
				{
					u000A = \u000D\u000F\u0019.\u000A(\u0003\u000F\u0019.\u000A());
				}
				\u0007\u000C\u0007.\u001D(u001F, u000A);
				object u001F2 = worksheetSelectionWindow2;
				double u000A2;
				if (\u0012\u000F\u0019.\u000A(\u0003\u000F\u0019.\u000A()) <= 0.0)
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
					u000A2 = \u001C\u000F\u0019.\u0007(worksheetSelectionWindow2);
				}
				else
				{
					u000A2 = \u0012\u000F\u0019.\u000A(\u0003\u000F\u0019.\u000A());
				}
				\u000F\u000F\u0019.\u0007(u001F2, u000A2);
			}
			return worksheetSelectionWindow2;
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00057494 File Offset: 0x00055694
		private void \u0006(object \u001F, EventArgs \u000A)
		{
			WorksheetSelectionDto u001F = \u0015\u000F\u0019.\u000A();
			EnumInfo enumInfo = \u000E\u0004\u0019.\u001D(this.\u000A);
			int u000A;
			if (enumInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.\u0006(object, EventArgs)).MethodHandle;
				}
				u000A = 0;
			}
			else
			{
				u000A = \u000D\u001B\u001D.\u001D(enumInfo);
			}
			\u000C\u000F\u0019.\u000A(u001F, u000A);
			EnumInfo enumInfo2 = \u0010\u0004\u0019.\u001D(this.\u000A);
			int u000A2;
			if (enumInfo2 == null)
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
				u000A2 = 0;
			}
			else
			{
				u000A2 = \u000D\u001B\u001D.\u001D(enumInfo2);
			}
			\u001A\u000F\u0019.\u000A(u001F, u000A2);
			\u0013\u000F\u0019.\u000A(u001F, \u0002\u000F\u0019.\u000A(this.\u000A));
			\u0014\u000F\u0019.\u000A(u001F, \u0016\u000F\u0019.\u000A(this.\u000A));
			Window window = \u0012\u0005\u000E.\u001F(\u001F);
			double u000A3;
			if (window == null)
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
				u000A3 = 0.0;
			}
			else
			{
				u000A3 = \u0017\u000F\u0019.\u000A(window);
			}
			\u0020\u000F\u0019.\u000A(u001F, u000A3);
			Window window2 = \u0012\u0005\u000E.\u001F(\u001F);
			double u000A4;
			if (window2 == null)
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
				u000A4 = 0.0;
			}
			else
			{
				u000A4 = \u001E\u000F\u0019.\u0007(window2);
			}
			\u0011\u000F\u0019.\u000A(u001F, u000A4);
			\u001B\u000F\u0019.\u000A(u001F);
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00057590 File Offset: 0x00055790
		private List<IFileInfoViewModel> \u000F(List<string> \u001F, List<DragReportInfo> \u000A)
		{
			List<IFileInfoViewModel> list = \u0006\u000F\u0019.\u000A();
			int num = 1;
			List<string>.Enumerator enumerator = \u0013\u0008\u0007.\u000A(\u001F);
			try
			{
				while (\u0017\u0008\u0007.\u000A(ref enumerator))
				{
					string text = \u0014\u0008\u0007.\u000A(ref enumerator);
					ProgressWindowService u001F = this.\u001F;
					bool flag;
					if (u001F == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.\u000F(List<string>, List<DragReportInfo>)).MethodHandle;
						}
						flag = false;
					}
					else
					{
						CancellationTokenSource cancellationTokenSource = \u000D\u001D\u0019.\u001D(u001F);
						bool? flag2;
						bool? flag3;
						if (cancellationTokenSource == null)
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
							\u001B\u000A\u000E.\u001F(ref flag2);
							flag3 = flag2;
						}
						else
						{
							flag3 = new bool?(\u0004\u0013\u001D.\u001D(cancellationTokenSource));
						}
						flag2 = flag3;
						flag = \u0012\u0015\u000A.\u000A(ref flag2);
					}
					if (flag)
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
						\u001F\u0012\u0019.\u000A(list);
						if (\u000A == null)
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
							goto IL_16E;
						}
						\u0009\u000F\u0019.\u000A(\u000A);
						goto IL_16E;
					}
					else
					{
						try
						{
							\u000A\u0004\u0019.\u000A(list, \u0001\u000F\u0019.\u000A(this.\u001D, text));
							ProgressWindowService u001F2 = this.\u001F;
							if (u001F2 == null)
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
							}
							else
							{
								\u0012\u001D\u0019.\u001D(u001F2, num, \u001E\u0007\u0007.\u000A("[{0}/{1}] {2}", num, \u0015\u0007\u0019.\u000A(\u001F), \u000F\u000B\u001D.\u000A(text)));
							}
							num++;
						}
						catch (Exception ex)
						{
							if (\u000A != null)
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
								\u001D\u000F\u0019.\u001D(\u000A, WorksheetSelectionWindowService.\u0010(text, \u0003\u001A\u000A.\u000A(ex)));
							}
							\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Services\\WorksheetSelectionWindowService.cs", "ExtractFileInfoViewModels");
						}
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
				((IDisposable)enumerator).Dispose();
			}
			IL_16E:
			ProgressWindowService u001F3 = this.\u001F;
			if (u001F3 == null)
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
				\u0002\u001D\u0019.\u001D(u001F3);
			}
			return list;
		}

		// Token: 0x06000D8B RID: 3467 RVA: 0x0005775C File Offset: 0x0005595C
		private IFileInfoViewModel \u0012(string \u001F, out DragReportInfo \u000A)
		{
			\u000A = null;
			IFileInfoViewModel result;
			try
			{
				result = \u0001\u000F\u0019.\u000A(this.\u001D, \u001F);
			}
			catch (Exception ex)
			{
				\u000A = WorksheetSelectionWindowService.\u0010(\u001F, \u0003\u001A\u000A.\u000A(ex));
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\Services\\WorksheetSelectionWindowService.cs", "TryCreateFileViewModel");
				result = \u000F\u0005\u000E.\u001F;
			}
			return result;
		}

		// Token: 0x06000D8C RID: 3468 RVA: 0x000577C0 File Offset: 0x000559C0
		private void \u0003(IEnumerable<Report> \u001F, Window \u000A)
		{
			if (Enumerable.Any<Report>(\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(WorksheetSelectionWindowService.\u0003(IEnumerable<Report>, Window)).MethodHandle;
				}
				\u000B\u001D\u0019.\u000A(this.\u0004, \u001F, \u001E\u0011\u000A.\u000A(\u0006\u0005\u000E.\u001F()), \u000A);
			}
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00057808 File Offset: 0x00055A08
		private static bool \u001C(string \u001F)
		{
			return \u0017\u0018\u0019.\u000A(WorksheetSelectionWindowService.\u0005, \u001B\u0002\u001D.\u000A(\u001F));
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x0005782C File Offset: 0x00055A2C
		private static DragReportInfo \u000D(string \u001F)
		{
			DragReportInfo dragReportInfo = \u0004\u0012\u0019.\u000A();
			\u001D\u0012\u0019.\u000A(dragReportInfo, \u001F);
			\u000A\u0012\u0019.\u000A(dragReportInfo, \u0007\u0012\u0019.\u000A());
			\u0020\u0014\u0007.\u000A(dragReportInfo, ReportStates.Error);
			return dragReportInfo;
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x0005785C File Offset: 0x00055A5C
		private static DragReportInfo \u0010(string \u001F, string \u000A)
		{
			DragReportInfo dragReportInfo = \u0004\u0012\u0019.\u000A();
			\u001D\u0012\u0019.\u000A(dragReportInfo, \u001F);
			\u000A\u0012\u0019.\u000A(dragReportInfo, \u000A);
			\u0020\u0014\u0007.\u000A(dragReportInfo, ReportStates.Error);
			return dragReportInfo;
		}

		// Token: 0x04000554 RID: 1364
		private readonly ProgressWindowService \u001F;

		// Token: 0x04000555 RID: 1365
		private WorksheetSelectWindowViewModel \u000A;

		// Token: 0x04000556 RID: 1366
		private readonly IFileInfoExtractionService \u0007;

		// Token: 0x04000557 RID: 1367
		private readonly IFileInfoViewModelFactory \u001D;

		// Token: 0x04000558 RID: 1368
		private readonly IReportWindowService \u0004;

		// Token: 0x04000559 RID: 1369
		private readonly Func<Window> \u0019;

		// Token: 0x0400055A RID: 1370
		private List<IFileInfoViewModel> \u0018 = new List<IFileInfoViewModel>();

		// Token: 0x0400055B RID: 1371
		private static readonly HashSet<string> \u0005;

		// Token: 0x0400055C RID: 1372
		[CompilerGenerated]
		private static WorksheetSelectionDto \u0016;

		// Token: 0x02000846 RID: 2118
		[CompilerGenerated]
		private sealed class \u0020\u000B
		{
			// Token: 0x06004E59 RID: 20057 RVA: 0x001E09D4 File Offset: 0x001DEBD4
			internal void \u001D()
			{
				this.\u001F.\u0018 = this.\u001F.\u000F(this.\u000A, this.\u0007);
			}

			// Token: 0x040020FD RID: 8445
			public WorksheetSelectionWindowService \u001F;

			// Token: 0x040020FE RID: 8446
			public List<string> \u000A;

			// Token: 0x040020FF RID: 8447
			public List<DragReportInfo> \u0007;
		}
	}
}
