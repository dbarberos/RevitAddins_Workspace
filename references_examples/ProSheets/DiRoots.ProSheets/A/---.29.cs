using System;
using System.Windows;
using System.Windows.Data;

namespace A
{
	// Token: 0x020000DE RID: 222
	internal static class \u0007\u001F\u0018
	{
		// Token: 0x06000B7A RID: 2938 RVA: 0x000460B8 File Offset: 0x000442B8
		public static object \u000C(PropertyPath \u000C, object \u0018)
		{
			\u0007\u001F\u0018.\u0019\u001F\u0018 u0019_u001F_u = new \u0007\u001F\u0018.\u0019\u001F\u0018();
			Binding binding = \u0009\u0011\u0016.\u0018();
			\u0013\u0011\u0016.\u0018(binding, \u000C);
			\u001C\u0011\u0016.\u0018(binding, \u0018);
			\u000D\u0011\u0016.\u0018(binding, BindingMode.OneTime);
			Binding u = binding;
			\u0007\u0001\u0018.\u0018(u0019_u001F_u, \u0007\u001F\u0018.\u0019\u001F\u0018.\u000C, u);
			return u0019_u001F_u.\u0018;
		}

		// Token: 0x020001DD RID: 477
		private class \u0019\u001F\u0018 : DependencyObject
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06001224 RID: 4644 RVA: 0x0005E524 File Offset: 0x0005C724
			// (set) Token: 0x06001225 RID: 4645 RVA: 0x0005E540 File Offset: 0x0005C740
			public object \u0018
			{
				get
				{
					return \u0019\u001A\u0018.\u0014(this, \u0007\u001F\u0018.\u0019\u001F\u0018.\u000C);
				}
				set
				{
					\u0007\u001A\u0018.\u0014(this, \u0007\u001F\u0018.\u0019\u001F\u0018.\u000C, value);
				}
			}

			// Token: 0x040008A8 RID: 2216
			public static readonly DependencyProperty \u000C = \u0017\u000F\u0014.\u0018("Value", \u000A\u001D\u0018.\u0018(\u0002\u0004\u000F.\u000C()), \u000A\u001D\u0018.\u0018(typeof(\u0007\u001F\u0018.\u0019\u001F\u0018).TypeHandle));
		}
	}
}
