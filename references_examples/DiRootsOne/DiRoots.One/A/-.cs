using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000002 RID: 2
	[CompilerGenerated]
	internal sealed class \u001F<\u001F, \u000A>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		[DebuggerHidden]
		public \u001F(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002074 File Offset: 0x00000274
		public \u001F Name
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002088 File Offset: 0x00000288
		public \u000A Id
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000209C File Offset: 0x0000029C
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u001F<\u001F, \u000A> u001F = value as \u001F<\u001F, \u000A>;
			if (this != u001F)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F.Equals(object)).MethodHandle;
				}
				if (u001F != null)
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
					if (EqualityComparer<\u001F>.Default.Equals(this.\u001F, u001F.\u001F))
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
						return EqualityComparer<\u000A>.Default.Equals(this.\u000A, u001F.\u000A);
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002118 File Offset: 0x00000318
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (-1111635620 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002160 File Offset: 0x00000360
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Name = {0}, Id = {1} }}";
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F.ToString()).MethodHandle;
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
					switch (4)
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

		// Token: 0x04000001 RID: 1
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000002 RID: 2
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
