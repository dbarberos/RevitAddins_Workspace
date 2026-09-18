using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200000B RID: 11
	[CompilerGenerated]
	internal sealed class \u0016<\u001F, \u000A>
	{
		// Token: 0x0600003B RID: 59 RVA: 0x000032BC File Offset: 0x000014BC
		[DebuggerHidden]
		public \u0016(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600003C RID: 60 RVA: 0x000032E0 File Offset: 0x000014E0
		public \u001F name
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000032F4 File Offset: 0x000014F4
		public \u000A description
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003308 File Offset: 0x00001508
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0016<\u001F, \u000A> u = value as \u0016<\u001F, \u000A>;
			if (this != u)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016.Equals(object)).MethodHandle;
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
					if (EqualityComparer<\u001F>.Default.Equals(this.\u001F, u.\u001F))
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
						return EqualityComparer<\u000A>.Default.Equals(this.\u000A, u.\u000A);
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003384 File Offset: 0x00001584
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (-1596281751 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000033CC File Offset: 0x000015CC
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ name = {0}, description = {1} }}";
			object[] array = \u0004\u0015\u0010.\u001F(2);
			int num = 0;
			\u001F u001F2 = this.\u001F;
			object obj;
			if (u001F2 == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016.ToString()).MethodHandle;
				}
				obj = null;
			}
			else
			{
				obj = u001F2.ToString();
			}
			array[num] = obj;
			int num2 = 1;
			\u000A u000A2 = this.\u000A;
			object obj2;
			if (u000A2 == null)
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
				obj2 = null;
			}
			else
			{
				obj2 = u000A2.ToString();
			}
			array[num2] = obj2;
			return \u0007\u0011\u000A.\u000A(u001F, u000A, array);
		}

		// Token: 0x0400001A RID: 26
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x0400001B RID: 27
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
