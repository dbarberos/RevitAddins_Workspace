using System;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Enums;

namespace DiRoots.One.SheetGen.Models
{
	// Token: 0x02000374 RID: 884
	public sealed class SheetDeletionResult
	{
		// Token: 0x17000A3C RID: 2620
		// (get) Token: 0x06002451 RID: 9297 RVA: 0x000DEB5C File Offset: 0x000DCD5C
		// (set) Token: 0x06002452 RID: 9298 RVA: 0x000DEB70 File Offset: 0x000DCD70
		public ISheetModel Sheet { get; set; }

		// Token: 0x17000A3D RID: 2621
		// (get) Token: 0x06002453 RID: 9299 RVA: 0x000DEB84 File Offset: 0x000DCD84
		// (set) Token: 0x06002454 RID: 9300 RVA: 0x000DEB98 File Offset: 0x000DCD98
		public bool Success { get; set; }

		// Token: 0x17000A3E RID: 2622
		// (get) Token: 0x06002455 RID: 9301 RVA: 0x000DEBAC File Offset: 0x000DCDAC
		// (set) Token: 0x06002456 RID: 9302 RVA: 0x000DEBC0 File Offset: 0x000DCDC0
		public string Error { get; set; }

		// Token: 0x17000A3F RID: 2623
		// (get) Token: 0x06002457 RID: 9303 RVA: 0x000DEBD4 File Offset: 0x000DCDD4
		// (set) Token: 0x06002458 RID: 9304 RVA: 0x000DEBE8 File Offset: 0x000DCDE8
		public ReportStates State { get; set; }

		// Token: 0x06002459 RID: 9305 RVA: 0x000DEBFC File Offset: 0x000DCDFC
		public static SheetDeletionResult Failed(ISheetModel sheet, string error, ReportStates state = ReportStates.Error)
		{
			SheetDeletionResult sheetDeletionResult = \u0013\u0015\u000B.\u000A();
			\u0014\u0015\u000B.\u000A(sheetDeletionResult, sheet);
			\u0017\u0015\u000B.\u000A(sheetDeletionResult, false);
			\u0020\u0015\u000B.\u000A(sheetDeletionResult, error);
			\u001E\u0015\u000B.\u000A(sheetDeletionResult, state);
			return sheetDeletionResult;
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x000DEC2C File Offset: 0x000DCE2C
		public static SheetDeletionResult Ok(ISheetModel sheet)
		{
			SheetDeletionResult sheetDeletionResult = \u0013\u0015\u000B.\u000A();
			\u0014\u0015\u000B.\u000A(sheetDeletionResult, sheet);
			\u0017\u0015\u000B.\u000A(sheetDeletionResult, true);
			\u001E\u0015\u000B.\u000A(sheetDeletionResult, ReportStates.Successful);
			return sheetDeletionResult;
		}

		// Token: 0x04000E65 RID: 3685
		[CompilerGenerated]
		private ISheetModel \u001F;

		// Token: 0x04000E66 RID: 3686
		[CompilerGenerated]
		private bool \u000A;

		// Token: 0x04000E67 RID: 3687
		[CompilerGenerated]
		private string \u0007;

		// Token: 0x04000E68 RID: 3688
		[CompilerGenerated]
		private ReportStates \u001D;
	}
}
