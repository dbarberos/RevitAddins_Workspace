using System;
using A;
using DiRoots.One.Commons.Container;

namespace DiRoots.ProfileControl.Helpers
{
	// Token: 0x02000018 RID: 24
	public class IoC : IoC
	{
		// Token: 0x060000CA RID: 202 RVA: 0x00006190 File Offset: 0x00004390
		private IoC()
		{
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000CC RID: 204 RVA: 0x000061C0 File Offset: 0x000043C0
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00006230 File Offset: 0x00004430
		public static IoC Default
		{
			get
			{
				object u = IoC.\u0014;
				bool flag = false;
				IoC u2;
				try
				{
					\u000D\u0010\u0018.\u0018(u, ref flag);
					if (IoC.\u0018 == null)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(IoC.get_Default()).MethodHandle;
						}
						IoC.\u0018 = \u0012\u0010\u0018.\u0018();
					}
					u2 = IoC.\u0018;
				}
				finally
				{
					if (flag)
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
						\u000F\u0010\u0018.\u0018(u);
					}
				}
				return u2;
			}
			set
			{
				IoC.\u0018 = value;
			}
		}

		// Token: 0x0400004E RID: 78
		private static IoC \u0018;

		// Token: 0x0400004F RID: 79
		private static readonly object \u0014 = \u0016\u0010\u0018.\u0018();
	}
}
