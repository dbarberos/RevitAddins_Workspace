using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000047 RID: 71
	internal class \u0010\u000A
	{
		// Token: 0x0600024A RID: 586 RVA: 0x0000BB40 File Offset: 0x00009D40
		public \u0010\u000A(List<XYZ> \u001F)
		{
			this.\u001F = new List<UV>();
			List<XYZ>.Enumerator enumerator = \u0004\u0007\u0007.\u000A(\u001F);
			try
			{
				while (\u000A\u0007\u0007.\u000A(ref enumerator))
				{
					XYZ u001F = \u001D\u0007\u0007.\u000A(ref enumerator);
					\u0007\u0007\u0007.\u000A(this.\u001F, u001F.\u000A());
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0010\u000A..ctor(List<XYZ>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000BBC4 File Offset: 0x00009DC4
		public UV \u000A(int \u001F)
		{
			return \u0019\u0007\u0007.\u000A(this.\u001F, \u001F);
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000BBE0 File Offset: 0x00009DE0
		public int \u0007
		{
			get
			{
				return \u0018\u0007\u0007.\u000A(this.\u001F);
			}
		}

		// Token: 0x040000FD RID: 253
		private readonly List<UV> \u001F;
	}
}
