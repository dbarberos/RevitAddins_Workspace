using System;
using System.Runtime.CompilerServices;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x020000FA RID: 250
	internal readonly struct \u0004\u0005 : IEquatable<\u0004\u0005>
	{
		// Token: 0x0600090D RID: 2317 RVA: 0x0003E4A8 File Offset: 0x0003C6A8
		public \u0004\u0005(string \u001F, string \u000A, string \u0007, RangeTypes \u001D, string \u0004)
		{
			string text = \u001F;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0005..ctor(string, string, string, RangeTypes, string)).MethodHandle;
				}
				text = string.Empty;
			}
			this.FilePath = text;
			string text2 = \u000A;
			if (\u000A == null)
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
				text2 = string.Empty;
			}
			this.Sheet = text2;
			string text3 = \u0007;
			if (\u0007 == null)
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
				text3 = string.Empty;
			}
			this.Region = text3;
			this.RangeType = \u001D;
			string text4 = \u0004;
			if (\u0004 == null)
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
				text4 = string.Empty;
			}
			this.PrintRange = text4;
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x0600090E RID: 2318 RVA: 0x0003E530 File Offset: 0x0003C730
		public string FilePath { get; }

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x0600090F RID: 2319 RVA: 0x0003E544 File Offset: 0x0003C744
		public string Sheet { get; }

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06000910 RID: 2320 RVA: 0x0003E558 File Offset: 0x0003C758
		public string Region { get; }

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06000911 RID: 2321 RVA: 0x0003E56C File Offset: 0x0003C76C
		public RangeTypes RangeType { get; }

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06000912 RID: 2322 RVA: 0x0003E580 File Offset: 0x0003C780
		public string PrintRange { get; }

		// Token: 0x06000913 RID: 2323 RVA: 0x0003E594 File Offset: 0x0003C794
		public bool Equals(\u0004\u0005 other)
		{
			if (\u001B\u0003\u0004.\u000A(\u0013\u0003\u0004.\u000A(ref this), \u0013\u0003\u0004.\u000A(ref other), StringComparison.Ordinal))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0005.Equals(\u0004\u0005)).MethodHandle;
				}
				if (\u001B\u0003\u0004.\u000A(\u0014\u0003\u0004.\u000A(ref this), \u0014\u0003\u0004.\u000A(ref other), StringComparison.Ordinal))
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
					if (\u001B\u0003\u0004.\u000A(\u0017\u0003\u0004.\u000A(ref this), \u0017\u0003\u0004.\u000A(ref other), StringComparison.Ordinal))
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
						if (\u0020\u0003\u0004.\u000A(ref this) == \u0020\u0003\u0004.\u000A(ref other))
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
							return \u001B\u0003\u0004.\u000A(\u001E\u0003\u0004.\u000A(ref this), \u001E\u0003\u0004.\u000A(ref other), StringComparison.Ordinal);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x0003E654 File Offset: 0x0003C854
		public override bool Equals(object obj)
		{
			if (\u000E\u0019\u000E.\u001F(obj) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0005.Equals(object)).MethodHandle;
				}
				\u0004\u0005 u000A = \u0008\u0019\u000E.\u001F(obj);
				return \u001A\u0003\u0004.\u000A(ref this, u000A);
			}
			return false;
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x0003E694 File Offset: 0x0003C894
		public override int GetHashCode()
		{
			int num = 17 * 31;
			string text = \u0013\u0003\u0004.\u000A(ref this);
			int num2;
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u0005.GetHashCode()).MethodHandle;
				}
				num2 = 0;
			}
			else
			{
				num2 = \u001B\u0013\u000A.\u000A(text);
			}
			int num3 = (num + num2) * 31;
			string text2 = \u0014\u0003\u0004.\u000A(ref this);
			int num4;
			if (text2 == null)
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
				num4 = 0;
			}
			else
			{
				num4 = \u001B\u0013\u000A.\u000A(text2);
			}
			int num5 = (num3 + num4) * 31;
			string text3 = \u0017\u0003\u0004.\u000A(ref this);
			int num6;
			if (text3 == null)
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
				num6 = 0;
			}
			else
			{
				num6 = \u001B\u0013\u000A.\u000A(text3);
			}
			int num7 = ((num5 + num6) * 31 + \u0020\u0003\u0004.\u000A(ref this).GetHashCode()) * 31;
			string text4 = \u001E\u0003\u0004.\u000A(ref this);
			int num8;
			if (text4 == null)
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
				num8 = 0;
			}
			else
			{
				num8 = \u001B\u0013\u000A.\u000A(text4);
			}
			return num7 + num8;
		}

		// Token: 0x04000375 RID: 885
		[CompilerGenerated]
		private readonly string \u001F;

		// Token: 0x04000376 RID: 886
		[CompilerGenerated]
		private readonly string \u000A;

		// Token: 0x04000377 RID: 887
		[CompilerGenerated]
		private readonly string \u0007;

		// Token: 0x04000378 RID: 888
		[CompilerGenerated]
		private readonly RangeTypes \u001D;

		// Token: 0x04000379 RID: 889
		[CompilerGenerated]
		private readonly string \u0004;
	}
}
