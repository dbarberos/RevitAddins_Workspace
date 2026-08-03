using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200000F RID: 15
	[CompilerGenerated]
	internal sealed class \u000F<\u001F, \u000A, \u0007, \u001D>
	{
		// Token: 0x06000053 RID: 83 RVA: 0x0000395C File Offset: 0x00001B5C
		[DebuggerHidden]
		public \u000F(\u001F \u001F, \u000A \u000A, \u0007 \u0007, \u001D \u001D)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			this.\u0007 = \u0007;
			this.\u001D = \u001D;
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000054 RID: 84 RVA: 0x0000398C File Offset: 0x00001B8C
		public \u001F Style
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000039A0 File Offset: 0x00001BA0
		public \u000A PatternMatches
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000056 RID: 86 RVA: 0x000039B4 File Offset: 0x00001BB4
		public \u0007 ColorDist
		{
			get
			{
				return this.\u0007;
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000039C8 File Offset: 0x00001BC8
		public \u001D SizeDelta
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x000039DC File Offset: 0x00001BDC
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u000F<\u001F, \u000A, \u0007, \u001D> u000F = value as \u000F<\u001F, \u000A, \u0007, \u001D>;
			if (this != u000F)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F.Equals(object)).MethodHandle;
				}
				if (u000F != null)
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
					if (EqualityComparer<\u001F>.Default.Equals(this.\u001F, u000F.\u001F))
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
						if (EqualityComparer<\u000A>.Default.Equals(this.\u000A, u000F.\u000A))
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
							if (EqualityComparer<\u0007>.Default.Equals(this.\u0007, u000F.\u0007))
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
								return EqualityComparer<\u001D>.Default.Equals(this.\u001D, u000F.\u001D);
							}
						}
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003AAC File Offset: 0x00001CAC
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (((1833308070 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A)) * -1521134295 + EqualityComparer<\u0007>.Default.GetHashCode(this.\u0007)) * -1521134295 + EqualityComparer<\u001D>.Default.GetHashCode(this.\u001D);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003B2C File Offset: 0x00001D2C
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Style = {0}, PatternMatches = {1}, ColorDist = {2}, SizeDelta = {3} }}";
			object[] array = \u0004\u0015\u0010.\u001F(4);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u000F.ToString()).MethodHandle;
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
					switch (6)
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
					switch (1)
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

		// Token: 0x04000022 RID: 34
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000023 RID: 35
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;

		// Token: 0x04000024 RID: 36
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0007 \u0007;

		// Token: 0x04000025 RID: 37
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001D \u001D;
	}
}
