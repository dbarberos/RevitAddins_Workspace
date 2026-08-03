using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200000C RID: 12
	[CompilerGenerated]
	internal sealed class \u000B<\u001F>
	{
		// Token: 0x06000041 RID: 65 RVA: 0x00003460 File Offset: 0x00001660
		[DebuggerHidden]
		public \u000B(\u001F \u001F)
		{
			this.\u001F = \u001F;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000042 RID: 66 RVA: 0x0000347C File Offset: 0x0000167C
		public \u001F name
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00003490 File Offset: 0x00001690
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u000B<\u001F> u000B = value as \u000B<\u001F>;
			if (this == u000B)
			{
				return true;
			}
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
				RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B.Equals(object)).MethodHandle;
			}
			if (u000B != null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				return EqualityComparer<\u001F>.Default.Equals(this.\u001F, u000B.\u001F);
			}
			return false;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000034E8 File Offset: 0x000016E8
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return 1648537049 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F);
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003518 File Offset: 0x00001718
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ name = {0} }}";
			object[] array = \u0004\u0015\u0010.\u001F(1);
			int num = 0;
			\u001F u001F2 = this.\u001F;
			object obj;
			if (u001F2 == null)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000B.ToString()).MethodHandle;
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

		// Token: 0x0400001C RID: 28
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;
	}
}
