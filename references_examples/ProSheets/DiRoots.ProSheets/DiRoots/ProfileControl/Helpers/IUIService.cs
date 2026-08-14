using System;
using System.Windows;

namespace DiRoots.ProfileControl.Helpers
{
	// Token: 0x02000016 RID: 22
	public interface IUIService<ViewModel>
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B0 RID: 176
		// (set) Token: 0x060000B1 RID: 177
		object DataContext { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B2 RID: 178
		// (set) Token: 0x060000B3 RID: 179
		Window Owner { get; set; }

		// Token: 0x060000B4 RID: 180
		void SetViewModel(ViewModel vm);

		// Token: 0x060000B5 RID: 181
		bool? ShowDialog();

		// Token: 0x060000B6 RID: 182
		bool Focus();

		// Token: 0x060000B7 RID: 183
		void Show();

		// Token: 0x060000B8 RID: 184
		void Hide();

		// Token: 0x060000B9 RID: 185
		void Close();

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x060000BA RID: 186
		// (remove) Token: 0x060000BB RID: 187
		event EventHandler Closed;

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000BC RID: 188
		// (set) Token: 0x060000BD RID: 189
		WindowStartupLocation WindowStartupLocation { get; set; }
	}
}
