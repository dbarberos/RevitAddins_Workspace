using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000005 RID: 5
	[CompilerGenerated]
	internal sealed class \u0007<\u001F, \u000A>
	{
		// Token: 0x0600000E RID: 14 RVA: 0x000023AC File Offset: 0x000005AC
		[DebuggerHidden]
		public \u0007(\u001F \u001F, \u000A \u000A)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000023D0 File Offset: 0x000005D0
		public \u001F v
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000023E4 File Offset: 0x000005E4
		public \u000A idList
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000023F8 File Offset: 0x000005F8
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0007<\u001F, \u000A> u = value as \u0007<\u001F, \u000A>;
			if (this != u)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007.Equals(object)).MethodHandle;
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
							switch (1)
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

		// Token: 0x06000012 RID: 18 RVA: 0x00002474 File Offset: 0x00000674
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (534739399 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000024BC File Offset: 0x000006BC
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ v = {0}, idList = {1} }}";
			object[] array = \u0004\u0015\u0010.\u001F(2);
			int num = 0;
			\u001F u001F2 = this.\u001F;
			object obj;
			if (u001F2 == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0007.ToString()).MethodHandle;
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
					switch (2)
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

		// Token: 0x04000005 RID: 5
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000006 RID: 6
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;
	}
}
