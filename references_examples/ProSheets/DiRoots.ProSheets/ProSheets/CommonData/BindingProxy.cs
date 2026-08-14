using System;
using System.Windows;
using A;

namespace ProSheets.CommonData
{
	// Token: 0x0200009B RID: 155
	public class BindingProxy : Freezable
	{
		// Token: 0x0600094D RID: 2381 RVA: 0x0003996C File Offset: 0x00037B6C
		protected override Freezable CreateInstanceCore()
		{
			return \u0003\u0005\u0003.\u0018();
		}

		// Token: 0x17000345 RID: 837
		// (get) Token: 0x0600094E RID: 2382 RVA: 0x00039980 File Offset: 0x00037B80
		// (set) Token: 0x0600094F RID: 2383 RVA: 0x0003999C File Offset: 0x00037B9C
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

		// Token: 0x04000460 RID: 1120
		public static readonly DependencyProperty DataProperty = \u001D\u001A\u0018.\u0018("Data", \u000A\u001D\u0018.\u0018(\u0002\u0004\u000F.\u000C()), \u000A\u001D\u0018.\u0018(\u0017\u0007\u000F.\u000C()), \u001F\u0006\u0018.\u0018(\u001D\u0004\u000F.\u000C));
	}
}
