using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000007 RID: 7
	[CompilerGenerated]
	internal sealed class \u0004<\u001F, \u000A>
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000026F4 File Offset: 0x000008F4
		[DebuggerHidden]
		public \u0004(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x00002718 File Offset: 0x00000918
		public \u001F Index
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001C RID: 28 RVA: 0x0000272C File Offset: 0x0000092C
		public \u000A View
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002740 File Offset: 0x00000940
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0004<\u001F, \u000A> u = value as \u0004<\u001F, \u000A>;
			if (this != u)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004.Equals(object)).MethodHandle;
				}
				if (u != null)
				{
					for (;;)
					{
						switch (4)
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

		// Token: 0x0600001E RID: 30 RVA: 0x000027BC File Offset: 0x000009BC
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (-1183561847 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002804 File Offset: 0x00000A04
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Index = {0}, View = {1} }}";
			object[] array = \u0004\u0015\u0010.\u001F(2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004.ToString()).MethodHandle;
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
					switch (1)
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

		// Token: 0x04000009 RID: 9
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x0400000A RID: 10
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
