using System;
using System.Windows;

namespace DiRoots.One.SheetGen.Models.Interfaces
{
	// Token: 0x02000381 RID: 897
	public interface IMainWindow
	{
		// Token: 0x060024AB RID: 9387
		void Show();

		// Token: 0x060024AC RID: 9388
		bool Focus();

		// Token: 0x14000037 RID: 55
		// (add) Token: 0x060024AD RID: 9389
		// (remove) Token: 0x060024AE RID: 9390
		event EventHandler Closed;

		// Token: 0x17000A61 RID: 2657
		// (get) Token: 0x060024AF RID: 9391
		// (set) Token: 0x060024B0 RID: 9392
		Window Owner { get; set; }

		// Token: 0x17000A62 RID: 2658
		// (get) Token: 0x060024B1 RID: 9393
		// (set) Token: 0x060024B2 RID: 9394
		WindowState WindowState { get; set; }
	}
}
