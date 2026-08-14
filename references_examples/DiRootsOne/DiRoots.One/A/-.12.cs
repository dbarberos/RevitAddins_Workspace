using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000010 RID: 16
	[CompilerGenerated]
	internal sealed class \u0012<\u001F, \u000A, \u0007, \u001D>
	{
		// Token: 0x0600005B RID: 91 RVA: 0x00003C28 File Offset: 0x00001E28
		[DebuggerHidden]
		public \u0012(\u001F \u001F, \u000A \u000A, \u0007 \u0007, \u001D \u001D)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			this.\u0007 = \u0007;
			this.\u001D = \u001D;
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003C58 File Offset: 0x00001E58
		public \u001F Style
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00003C6C File Offset: 0x00001E6C
		public \u000A ColorBucket
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003C80 File Offset: 0x00001E80
		public \u0007 ColorPrimary
		{
			get
			{
				return this.\u0007;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003C94 File Offset: 0x00001E94
		public \u001D VariantRank
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003CA8 File Offset: 0x00001EA8
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0012<\u001F, \u000A, \u0007, \u001D> u = value as \u0012<\u001F, \u000A, \u0007, \u001D>;
			if (this != u)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012.Equals(object)).MethodHandle;
				}
				if (u != null)
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
						if (EqualityComparer<\u000A>.Default.Equals(this.\u000A, u.\u000A))
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

		// Token: 0x06000061 RID: 97 RVA: 0x00003D78 File Offset: 0x00001F78
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (((-878158602 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A)) * -1521134295 + EqualityComparer<\u0007>.Default.GetHashCode(this.\u0007)) * -1521134295 + EqualityComparer<\u001D>.Default.GetHashCode(this.\u001D);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003DF8 File Offset: 0x00001FF8
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ Style = {0}, ColorBucket = {1}, ColorPrimary = {2}, VariantRank = {3} }}";
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012.ToString()).MethodHandle;
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
			int num3 = 2;
			\u0007 u = this.\u0007;
			object obj3;
			if (u == null)
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
					switch (6)
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

		// Token: 0x04000026 RID: 38
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000027 RID: 39
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;

		// Token: 0x04000028 RID: 40
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0007 \u0007;

		// Token: 0x04000029 RID: 41
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001D \u001D;
	}
}
