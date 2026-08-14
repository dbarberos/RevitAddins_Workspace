using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000002 RID: 2
	[CompilerGenerated]
	internal sealed class \u0017\u0013\u0018<\u000C, \u0018>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		[DebuggerHidden]
		public \u0017\u0013\u0018(\u000C \u000C, \u0018 \u0018)
		{
			this.\u000C = \u000C;
			this.\u0018 = \u0018;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x00002074 File Offset: 0x00000274
		public \u000C subjectId
		{
			get
			{
				return this.\u000C;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002088 File Offset: 0x00000288
		public \u0018 numberOfExports
		{
			get
			{
				return this.\u0018;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000209C File Offset: 0x0000029C
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0017\u0013\u0018<\u000C, \u0018> u0017_u0013_u = value as \u0017\u0013\u0018<\u000C, \u0018>;
			if (this != u0017_u0013_u)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0013\u0018.Equals(object)).MethodHandle;
				}
				if (u0017_u0013_u != null)
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
					if (EqualityComparer<\u000C>.Default.Equals(this.\u000C, u0017_u0013_u.\u000C))
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
						return EqualityComparer<\u0018>.Default.Equals(this.\u0018, u0017_u0013_u.\u0018);
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
			return (-1035112952 * -1521134295 + EqualityComparer<\u000C>.Default.GetHashCode(this.\u000C)) * -1521134295 + EqualityComparer<\u0018>.Default.GetHashCode(this.\u0018);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002160 File Offset: 0x00000360
		[DebuggerHidden]
		public override string ToString()
		{
			IFormatProvider u000C = null;
			string u = "{{ subjectId = {0}, numberOfExports = {1} }}";
			object[] array = \u0008\u001E\u000F.\u000C(2);
			int num = 0;
			\u000C u000C2 = this.\u000C;
			object obj;
			if (u000C2 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0017\u0013\u0018.ToString()).MethodHandle;
				}
				obj = null;
			}
			else
			{
				obj = u000C2.ToString();
			}
			array[num] = obj;
			int num2 = 1;
			\u0018 u2 = this.\u0018;
			object obj2;
			if (u2 == null)
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
				obj2 = null;
			}
			else
			{
				obj2 = u2.ToString();
			}
			array[num2] = obj2;
			return \u0011\u0017\u0018.\u0018(u000C, u, array);
		}

		// Token: 0x04000001 RID: 1
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000C \u000C;

		// Token: 0x04000002 RID: 2
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0018 \u0018;
	}
}
