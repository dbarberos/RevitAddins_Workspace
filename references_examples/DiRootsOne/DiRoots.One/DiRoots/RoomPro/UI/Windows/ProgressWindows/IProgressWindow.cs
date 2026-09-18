using System;

namespace DiRoots.RoomPro.UI.Windows.ProgressWindows
{
	// Token: 0x02000069 RID: 105
	public interface IProgressWindow
	{
		// Token: 0x060004A8 RID: 1192
		void PropagateProgressToView(double percent, string text = null, string infoText = "");

		// Token: 0x060004A9 RID: 1193
		void TrackProgress(double percent, string text = null, string inforText = "");
	}
}
