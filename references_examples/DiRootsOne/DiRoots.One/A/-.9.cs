using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200000D RID: 13
	[CompilerGenerated]
	internal sealed class \u0002<\u001F>
	{
		// Token: 0x06000046 RID: 70 RVA: 0x00003578 File Offset: 0x00001778
		[DebuggerHidden]
		public \u0002(\u001F \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00003594 File Offset: 0x00001794
		public \u001F description
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000035A8 File Offset: 0x000017A8
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0002<\u001F> u = value as \u0002<\u001F>;
			if (this == u)
			{
				return true;
			}
			for (;;)
			{
				switch (3)
				{
				case 0:
					continue;
				}
				break;
			}
			if (!true)
			{
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002.Equals(object)).MethodHandle;
			}
			if (u != null)
			{
				for (;;)
				{
					switch (7)
					{
					case 0:
						continue;
					}
					break;
				}
				return EqualityComparer<\u001F>.Default.Equals(this.\u001F, u.\u001F);
			}
			return false;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003600 File Offset: 0x00001800
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return 711378856 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003630 File Offset: 0x00001830
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ description = {0} }}";
			object[] array = \u0004\u0015\u0010.\u001F(1);
			int num = 0;
			\u001F u001F2 = this.\u001F;
			object obj;
			if (u001F2 == null)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002.ToString()).MethodHandle;
				}
				obj = null;
			}
			else
			{
				obj = u001F2.ToString();
			}
			array[num] = obj;
			return \u0007\u0011\u000A.\u000A(u001F, u000A, array);
		}

		// Token: 0x0400001D RID: 29
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;
	}
}
