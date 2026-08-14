using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using A;

namespace DiRoots.RoomPro.UI.Controls
{
	// Token: 0x02000070 RID: 112
	public class SettingsTab : UserControl
	{
		// Token: 0x060004DB RID: 1243 RVA: 0x0001E914 File Offset: 0x0001CB14
		public SettingsTab()
		{
			\u0011\u000C\u000A.\u001D(this, new RoutedEventHandler(this.SettingTab_Loaded));
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x0001E93C File Offset: 0x0001CB3C
		private void SettingTab_Loaded(object sender, RoutedEventArgs e)
		{
			\u001A\u0001\u0007.\u000A(\u0018\u0007\u000E.\u001F(\u0007\u000C\u000A.\u001D(this)), this);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x0001E960 File Offset: 0x0001CB60
		public bool CanApplyChanges()
		{
			return \u000C\u0001\u0007.\u000A(this, this);
		}

		// Token: 0x060004DE RID: 1246 RVA: 0x0001E978 File Offset: 0x0001CB78
		public virtual bool IsValid(DependencyObject obj)
		{
			if (!\u0001\u0001\u0007.\u000A(obj))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SettingsTab.IsValid(DependencyObject)).MethodHandle;
				}
				return Enumerable.All<DependencyObject>(Enumerable.OfType<DependencyObject>(\u0015\u0001\u0007.\u000A(obj)), new Func<DependencyObject, bool>(this.IsValid));
			}
			return false;
		}
	}
}
