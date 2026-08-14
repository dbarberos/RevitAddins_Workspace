using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace A
{
	// Token: 0x0200000A RID: 10
	[CompilerGenerated]
	internal sealed class \u0005<\u001F, \u000A, \u0007, \u001D, \u0004, \u0019, \u0018>
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00002E30 File Offset: 0x00001030
		[DebuggerHidden]
		public \u0005(\u001F \u001F, \u000A \u000A, \u0007 \u0007, \u001D \u001D, \u0004 \u0004, \u0019 \u0019, \u0018 \u0018)
		{
			this.\u001F = \u001F;
			this.\u000A = \u000A;
			this.\u0007 = \u0007;
			this.\u001D = \u001D;
			this.\u0004 = \u0004;
			this.\u0019 = \u0019;
			this.\u0018 = \u0018;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002E78 File Offset: 0x00001078
		public \u001F name
		{
			get
			{
				return this.\u001F;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002E8C File Offset: 0x0000108C
		public \u000A kind
		{
			get
			{
				return this.\u000A;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002EA0 File Offset: 0x000010A0
		public \u0007 width
		{
			get
			{
				return this.\u0007;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002EB4 File Offset: 0x000010B4
		public \u001D sortOrder
		{
			get
			{
				return this.\u001D;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002EC8 File Offset: 0x000010C8
		public \u0004 locked
		{
			get
			{
				return this.\u0004;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002EDC File Offset: 0x000010DC
		public \u0019 required
		{
			get
			{
				return this.\u0019;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00002EF0 File Offset: 0x000010F0
		public \u0018 description
		{
			get
			{
				return this.\u0018;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002F04 File Offset: 0x00001104
		[DebuggerHidden]
		public override bool Equals(object value)
		{
			\u0005<\u001F, \u000A, \u0007, \u001D, \u0004, \u0019, \u0018> u = value as \u0005<\u001F, \u000A, \u0007, \u001D, \u0004, \u0019, \u0018>;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005.Equals(object)).MethodHandle;
				}
				if (u != null)
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
								switch (3)
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
									switch (1)
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
										switch (7)
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
											switch (7)
											{
											case 0:
												continue;
											}
											break;
										}
										if (EqualityComparer<\u0019>.Default.Equals(this.\u0019, u.\u0019))
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
											return EqualityComparer<\u0018>.Default.Equals(this.\u0018, u.\u0018);
										}
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

		// Token: 0x06000039 RID: 57 RVA: 0x00003050 File Offset: 0x00001250
		[DebuggerHidden]
		public override int GetHashCode()
		{
			return ((((((-648732800 * -1521134295 + EqualityComparer<\u001F>.Default.GetHashCode(this.\u001F)) * -1521134295 + EqualityComparer<\u000A>.Default.GetHashCode(this.\u000A)) * -1521134295 + EqualityComparer<\u0007>.Default.GetHashCode(this.\u0007)) * -1521134295 + EqualityComparer<\u001D>.Default.GetHashCode(this.\u001D)) * -1521134295 + EqualityComparer<\u0004>.Default.GetHashCode(this.\u0004)) * -1521134295 + EqualityComparer<\u0019>.Default.GetHashCode(this.\u0019)) * -1521134295 + EqualityComparer<\u0018>.Default.GetHashCode(this.\u0018);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00003120 File Offset: 0x00001320
		[DebuggerHidden]
		[return: \u0008(1)]
		public override string ToString()
		{
			IFormatProvider u001F = null;
			string u000A = "{{ name = {0}, kind = {1}, width = {2}, sortOrder = {3}, locked = {4}, required = {5}, description = {6} }}";
			object[] array = \u0004\u0015\u0010.\u001F(7);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005.ToString()).MethodHandle;
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
					switch (3)
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
			int num5 = 4;
			\u0004 u2 = this.\u0004;
			object obj5;
			if (u2 == null)
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
					switch (2)
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
			int num7 = 6;
			\u0018 u4 = this.\u0018;
			object obj7;
			if (u4 == null)
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
				obj7 = null;
			}
			else
			{
				obj7 = u4.ToString();
			}
			array[num7] = obj7;
			return \u0007\u0011\u000A.\u000A(u001F, u000A, array);
		}

		// Token: 0x04000013 RID: 19
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001F \u001F;

		// Token: 0x04000014 RID: 20
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u000A \u000A;

		// Token: 0x04000015 RID: 21
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0007 \u0007;

		// Token: 0x04000016 RID: 22
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u001D \u001D;

		// Token: 0x04000017 RID: 23
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0004 \u0004;

		// Token: 0x04000018 RID: 24
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0019 \u0019;

		// Token: 0x04000019 RID: 25
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private readonly \u0018 \u0018;
	}
}
