using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000008 RID: 8
	[CompilerGenerated]
	internal sealed class \u0019<\u001F, \u000A>
	{
		// Token: 0x06000020 RID: 32 RVA: 0x00002898 File Offset: 0x00000A98
		[DebuggerHidden]
		public \u0019(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000021 RID: 33 RVA: 0x000028BC File Offset: 0x00000ABC
		public \u001F SheetId
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000022 RID: 34 RVA: 0x000028D0 File Offset: 0x00000AD0
		public \u000A Index
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000028E4 File Offset: 0x00000AE4
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0019<\u001F, \u000A> u = value as \u0019<\u001F, \u000A>;
			if (this != u)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019.Equals(object)).MethodHandle;
				}
				if (u != null)
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
					if (EqualityComparer<\u001F>.Default.Equals(this.\u001F, u.\u001F))
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
						return EqualityComparer<\u000A>.Default.Equals(this.\u000A, u.\u000A);
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002960 File Offset: 0x00000B60
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (-1245943950 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000029A8 File Offset: 0x00000BA8
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ SheetId = {0}, Index = {1} }}";
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019.ToString()).MethodHandle;
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

		// Token: 0x0400000B RID: 11
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x0400000C RID: 12
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
