using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000004 RID: 4
	[CompilerGenerated]
	internal sealed class \u000A<\u001F, \u000A>
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002208 File Offset: 0x00000408
		[DebuggerHidden]
		public \u000A(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000009 RID: 9 RVA: 0x0000222C File Offset: 0x0000042C
		public \u001F Name
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002240 File Offset: 0x00000440
		public \u000A Element
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002254 File Offset: 0x00000454
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u000A<\u001F, \u000A> u000A = value as \u000A<\u001F, \u000A>;
			if (this != u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A.Equals(object)).MethodHandle;
				}
				if (u000A != null)
				{
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
					if (EqualityComparer<\u001F>.Default.Equals(this.\u001F, u000A.\u001F))
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
						return EqualityComparer<\u000A>.Default.Equals(this.\u000A, u000A.\u000A);
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000022D0 File Offset: 0x000004D0
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (1108553971 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002318 File Offset: 0x00000518
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Name = {0}, Element = {1} }}";
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000A.ToString()).MethodHandle;
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
					switch (7)
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

		// Token: 0x04000003 RID: 3
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000004 RID: 4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
