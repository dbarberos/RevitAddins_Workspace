using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000006 RID: 6
	[CompilerGenerated]
	internal sealed class \u001D<\u001F, \u000A>
	{
		// Token: 0x06000014 RID: 20 RVA: 0x00002550 File Offset: 0x00000750
		[DebuggerHidden]
		public \u001D(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002574 File Offset: 0x00000774
		public \u001F Cat
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002588 File Offset: 0x00000788
		public \u000A BuiltInCategory
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000259C File Offset: 0x0000079C
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u001D<\u001F, \u000A> u001D = value as \u001D<\u001F, \u000A>;
			if (this != u001D)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D.Equals(object)).MethodHandle;
				}
				if (u001D != null)
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
					if (EqualityComparer<\u001F>.Default.Equals(this.\u001F, u001D.\u001F))
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
						return EqualityComparer<\u000A>.Default.Equals(this.\u000A, u001D.\u000A);
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002618 File Offset: 0x00000818
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (-236446847 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002660 File Offset: 0x00000860
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Cat = {0}, BuiltInCategory = {1} }}";
			object[] array = \u0004\u0015\u0010.\u001F(2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D.ToString()).MethodHandle;
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

		// Token: 0x04000007 RID: 7
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000008 RID: 8
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
