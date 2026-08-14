using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x02000009 RID: 9
	[CompilerGenerated]
	internal sealed class \u0018<\u001F, \u000A, \u0007, \u001D, \u0004, \u0019>
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00002A3C File Offset: 0x00000C3C
		[DebuggerHidden]
		public \u0018(\u001F \u001F, \u000A \u000A, \u0007 \u0007, \u001D \u001D, \u0004 \u0004, \u0019 \u0019)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			this.\u0007 = \u0007;
			this.\u001D = \u001D;
			this.\u0004 = \u0004;
			this.\u0019 = \u0019;
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002A7C File Offset: 0x00000C7C
		public \u001F name
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002A90 File Offset: 0x00000C90
		public \u000A kind
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002AA4 File Offset: 0x00000CA4
		public \u0007 width
		{
			get
			{
				return this.\u0007;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public \u001D sortOrder
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002ACC File Offset: 0x00000CCC
		public \u0004 locked
		{
			get
			{
				return this.\u0004;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002AE0 File Offset: 0x00000CE0
		public \u0019 required
		{
			get
			{
				return this.\u0019;
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002AF4 File Offset: 0x00000CF4
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0018<\u001F, \u000A, \u0007, \u001D, \u0004, \u0019> u = value as \u0018<\u001F, \u000A, \u0007, \u001D, \u0004, \u0019>;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018.Equals(object)).MethodHandle;
				}
				if (u != null)
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
								switch (6)
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
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								if (EqualityComparer<\u001D>.Default.Equals(this.\u001D, u.\u001D))
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
									if (EqualityComparer<\u0004>.Default.Equals(this.\u0004, u.\u0004))
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
										return EqualityComparer<\u0019>.Default.Equals(this.\u0019, u.\u0019);
									}
								}
							}
						}
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002C14 File Offset: 0x00000E14
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return (((((-276104168 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A)) * -1521134295 + EqualityComparer<\u0007>.Default.GetHashCode(this.\u0007)) * -1521134295 + EqualityComparer<\u001D>.Default.GetHashCode(this.\u001D)) * -1521134295 + EqualityComparer<\u0004>.Default.GetHashCode(this.\u0004)) * -1521134295 + EqualityComparer<\u0019>.Default.GetHashCode(this.\u0019);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002CC8 File Offset: 0x00000EC8
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ name = {0}, kind = {1}, width = {2}, sortOrder = {3}, locked = {4}, required = {5} }}";
			object[] array = \u0004\u0015\u0010.\u001F(6);
			int num = 0;
			\u001F u001F2 = this.\u001F;
			object obj;
			if (u001F2 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018.ToString()).MethodHandle;
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
					switch (3)
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
					switch (2)
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
			int num5 = 4;
			\u0004 u2 = this.\u0004;
			object obj5;
			if (u2 == null)
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
				obj5 = null;
			}
			else
			{
				obj5 = u2.ToString();
			}
			array[num5] = obj5;
			int num6 = 5;
			\u0019 u3 = this.\u0019;
			object obj6;
			if (u3 == null)
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
				obj6 = null;
			}
			else
			{
				obj6 = u3.ToString();
			}
			array[num6] = obj6;
			return \u0007\u0011\u000A.\u000A(u001F, u000A, array);
		}

		// Token: 0x0400000D RID: 13
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x0400000E RID: 14
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;

		// Token: 0x0400000F RID: 15
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0007 \u0007;

		// Token: 0x04000010 RID: 16
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001D \u001D;

		// Token: 0x04000011 RID: 17
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0004 \u0004;

		// Token: 0x04000012 RID: 18
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0019 \u0019;
	}
}
