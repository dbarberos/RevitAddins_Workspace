using System;
using System.Windows;
using A;

namespace DiRoots.ProfileControl.BindingExtensions
{
	// Token: 0x0200001D RID: 29
	public class BindingProxy : Freezable
	{
		// Token: 0x0600010A RID: 266 RVA: 0x000070A4 File Offset: 0x000052A4
		protected override Freezable CreateInstanceCore()
		{
			return \u0011\u0006\u0018.\u0018();
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000070B8 File Offset: 0x000052B8
		// (set) Token: 0x0600010C RID: 268 RVA: 0x000070D4 File Offset: 0x000052D4
		public object Data
		{
			get
			{
				return \u0019\u001A\u0018.\u0014(this, BindingProxy.DataProperty);
			}
			set
			{
				\u0007\u001A\u0018.\u0014(this, BindingProxy.DataProperty, value);
			}
		}

		// Token: 0x04000068 RID: 104
		public static readonly DependencyProperty DataProperty = \u001D\u001A\u0018.\u0018("Data", \u000A\u001D\u0018.\u0018(\u0002\u0004\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0004\u0004\u000F.\u000C()), \u001F\u0006\u0018.\u0018(\u001D\u0004\u000F.\u000C));
	}
}
