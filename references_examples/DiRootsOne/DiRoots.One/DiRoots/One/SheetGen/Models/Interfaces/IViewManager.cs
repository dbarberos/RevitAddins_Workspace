using System;
using System.Windows;

namespace DiRoots.One.SheetGen.Models.Interfaces
{
	// Token: 0x02000383 RID: 899
	public interface IViewManager
	{
		// Token: 0x060024B4 RID: 9396
		void Show();

		// Token: 0x060024B5 RID: 9397
		bool Focus();

		// Token: 0x14000038 RID: 56
		// (add) Token: 0x060024B6 RID: 9398
		// (remove) Token: 0x060024B7 RID: 9399
		event EventHandler Closed;

		// Token: 0x17000A63 RID: 2659
		// (get) Token: 0x060024B8 RID: 9400
		// (set) Token: 0x060024B9 RID: 9401
		Window Owner { get; set; }

		// Token: 0x17000A64 RID: 2660
		// (get) Token: 0x060024BA RID: 9402
		// (set) Token: 0x060024BB RID: 9403
		bool IsOpenedFromSheetGen { get; set; }

		// Token: 0x17000A65 RID: 2661
		// (get) Token: 0x060024BC RID: 9404
		// (set) Token: 0x060024BD RID: 9405
		bool IsSheetGenOpen { get; set; }

		// Token: 0x17000A66 RID: 2662
		// (get) Token: 0x060024BE RID: 9406
		// (set) Token: 0x060024BF RID: 9407
		WindowState WindowState { get; set; }
	}
}
