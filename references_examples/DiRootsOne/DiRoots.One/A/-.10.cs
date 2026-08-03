using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200000E RID: 14
	[CompilerGenerated]
	internal sealed class \u0006<\u001F, \u000A, \u0007, \u001D>
	{
		// Token: 0x0600004B RID: 75 RVA: 0x00003690 File Offset: 0x00001890
		[DebuggerHidden]
		public \u0006(\u001F \u001F, \u000A \u000A, \u0007 \u0007, \u001D \u001D)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			this.\u0007 = \u0007;
			this.\u001D = \u001D;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004C RID: 76 RVA: 0x000036C0 File Offset: 0x000018C0
		public \u001F Style
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004D RID: 77 RVA: 0x000036D4 File Offset: 0x000018D4
		public \u000A GroupPriority
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600004E RID: 78 RVA: 0x000036E8 File Offset: 0x000018E8
		public \u0007 ColorBucket
		{
			get
			{
				return this.\u0007;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600004F RID: 79 RVA: 0x000036FC File Offset: 0x000018FC
		public \u001D ColorPrimary
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003710 File Offset: 0x00001910
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0006<\u001F, \u000A, \u0007, \u001D> u = value as \u0006<\u001F, \u000A, \u0007, \u001D>;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0006.Equals(object)).MethodHandle;
				}
				if (u != null)
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
						if (EqualityComparer<\u000A>.Default.Equals(this.\u000A, u.\u000A))
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
							if (EqualityComparer<\u0007>.Default.Equals(this.\u0007, u.\u0007))
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
								return EqualityComparer<\u001D>.Default.Equals(this.\u001D, u.\u001D);
							}
						}
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000037E0 File Offset: 0x000019E0
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (((1959622074 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A)) * -1521134295 + EqualityComparer<\u0007>.Default.GetHashCode(this.\u0007)) * -1521134295 + EqualityComparer<\u001D>.Default.GetHashCode(this.\u001D);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003860 File Offset: 0x00001A60
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Style = {0}, GroupPriority = {1}, ColorBucket = {2}, ColorPrimary = {3} }}";
			object[] array = \u0004\u0015\u0010.\u001F(4);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0006.ToString()).MethodHandle;
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
			int num3 = 2;
			\u0007 u = this.\u0007;
			object obj3;
			if (u == null)
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
				obj3 = null;
			}
			else
			{
				obj3 = u.ToString();
			}
			array[num3] = obj3;
			int num4 = 3;
			\u001D u001D = this.\u001D;
			object obj4;
			if (u001D == null)
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
				obj4 = null;
			}
			else
			{
				obj4 = u001D.ToString();
			}
			array[num4] = obj4;
			return \u0007\u0011\u000A.\u000A(u001F, u000A, array);
		}

		// Token: 0x0400001E RID: 30
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x0400001F RID: 31
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;

		// Token: 0x04000020 RID: 32
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0007 \u0007;

		// Token: 0x04000021 RID: 33
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001D \u001D;
	}
}
