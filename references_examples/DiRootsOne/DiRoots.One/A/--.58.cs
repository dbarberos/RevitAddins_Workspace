using System;
using System.Runtime.CompilerServices;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x020000F9 RID: 249
	internal readonly struct \u001D\u0005 : IEquatable<\u001D\u0005>
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x0003DFB4 File Offset: 0x0003C1B4
		public \u001D\u0005(string \u001F, string \u000A, string \u0007, RangeTypes \u001D, string \u0004, long \u0019)
		{
			string text = \u001F;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0005..ctor(string, string, string, RangeTypes, string, long)).MethodHandle;
				}
				text = string.Empty;
			}
			this.FilePath = text;
			string text2 = \u000A;
			if (\u000A == null)
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
				text2 = string.Empty;
			}
			this.Sheet = text2;
			string text3 = \u0007;
			if (\u0007 == null)
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
				text3 = string.Empty;
			}
			this.Region = text3;
			this.RangeType = \u001D;
			string text4 = \u0004;
			if (\u0004 == null)
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
				text4 = string.Empty;
			}
			this.PrintRange = text4;
			this.WriteTimeTicks = \u0019;
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000902 RID: 2306 RVA: 0x0003E044 File Offset: 0x0003C244
		public string FilePath { get; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000903 RID: 2307 RVA: 0x0003E058 File Offset: 0x0003C258
		public string Sheet { get; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x0003E06C File Offset: 0x0003C26C
		public string Region { get; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x0003E080 File Offset: 0x0003C280
		public RangeTypes RangeType { get; }

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x0003E094 File Offset: 0x0003C294
		public string PrintRange { get; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x0003E0A8 File Offset: 0x0003C2A8
		public long WriteTimeTicks { get; }

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000908 RID: 2312 RVA: 0x0003E0BC File Offset: 0x0003C2BC
		public \u0004\u0005 \u0018
		{
			get
			{
				string text = \u0010\u0003\u0004.\u000A(ref this);
				string text2;
				if (text == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0005.get_\u0018()).MethodHandle;
					}
					text2 = null;
				}
				else
				{
					text2 = \u000D\u0003\u0004.\u0007(text);
				}
				string u001F;
				if ((u001F = text2) == null)
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
					u001F = string.Empty;
				}
				return new \u0004\u0005(u001F, \u001C\u0003\u0004.\u000A(ref this), \u0003\u0003\u0004.\u000A(ref this), \u0012\u0003\u0004.\u000A(ref this), \u000F\u0003\u0004.\u000A(ref this));
			}
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0003E12C File Offset: 0x0003C32C
		public static \u001D\u0005 \u0005(SelectedExcel \u001F)
		{
			string text;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0005.\u0005(SelectedExcel)).MethodHandle;
				}
				text = null;
			}
			else
			{
				text = \u0011\u0020\u001D.\u001D(\u001F);
			}
			string text2;
			if ((text2 = text) == null)
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
				text2 = string.Empty;
			}
			string text3 = text2;
			long u = 0L;
			if (!\u001A\u0006\u0007.\u000A(text3))
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
				try
				{
					if (\u0010\u0002\u001D.\u000A(text3))
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
						DateTime dateTime = \u0008\u0003\u0004.\u000A(text3);
						u = \u000E\u0003\u0004.\u000A(ref dateTime);
					}
				}
				catch (Exception u000A)
				{
					\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGRevitHelper\\StyleMapping\\ExcelStylesAggregator.cs", "From");
				}
			}
			NamedRangeInfo namedRangeInfo;
			if (\u001F == null)
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
				namedRangeInfo = \u0010\u0019\u000E.\u001F;
			}
			else
			{
				namedRangeInfo = \u0014\u0020\u001D.\u001D(\u001F);
			}
			NamedRangeInfo namedRangeInfo2 = namedRangeInfo;
			string u001F = text3;
			string text4;
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
				text4 = null;
			}
			else
			{
				text4 = \u0020\u0020\u001D.\u001D(\u001F);
			}
			string u000A2;
			if ((u000A2 = text4) == null)
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
				u000A2 = string.Empty;
			}
			string text5;
			if (namedRangeInfo2 == null)
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
				text5 = null;
			}
			else
			{
				text5 = \u0017\u0020\u001D.\u001D(namedRangeInfo2);
			}
			string u2;
			if ((u2 = text5) == null)
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
				u2 = string.Empty;
			}
			RangeTypes u001D;
			if (namedRangeInfo2 == null)
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
				u001D = RangeTypes.Normal;
			}
			else
			{
				u001D = \u0013\u0020\u001D.\u001D(namedRangeInfo2);
			}
			string u3;
			if (namedRangeInfo2 != null)
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
				if (\u0013\u0020\u001D.\u001D(namedRangeInfo2) == RangeTypes.PrintRange)
				{
					u3 = \u001F\u000F\u0004.\u000A(namedRangeInfo2);
					goto IL_14E;
				}
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			u3 = string.Empty;
			IL_14E:
			return new \u001D\u0005(u001F, u000A2, u2, u001D, u3, u);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x0003E2A0 File Offset: 0x0003C4A0
		public bool Equals(\u001D\u0005 other)
		{
			if (\u001B\u0003\u0004.\u000A(\u0010\u0003\u0004.\u000A(ref this), \u0010\u0003\u0004.\u000A(ref other), StringComparison.OrdinalIgnoreCase))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0005.Equals(\u001D\u0005)).MethodHandle;
				}
				if (\u001B\u0003\u0004.\u000A(\u001C\u0003\u0004.\u000A(ref this), \u001C\u0003\u0004.\u000A(ref other), StringComparison.Ordinal))
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
					if (\u001B\u0003\u0004.\u000A(\u0003\u0003\u0004.\u000A(ref this), \u0003\u0003\u0004.\u000A(ref other), StringComparison.Ordinal))
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
						if (\u0012\u0003\u0004.\u000A(ref this) == \u0012\u0003\u0004.\u000A(ref other))
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
							if (\u001B\u0003\u0004.\u000A(\u000F\u0003\u0004.\u000A(ref this), \u000F\u0003\u0004.\u000A(ref other), StringComparison.Ordinal))
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
								return \u000D\u000F\u0004.\u000A(ref this) == \u000D\u000F\u0004.\u000A(ref other);
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x0003E384 File Offset: 0x0003C584
		public override bool Equals(object obj)
		{
			if (\u001C\u0019\u000E.\u001F(obj) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0005.Equals(object)).MethodHandle;
				}
				\u001D\u0005 u000A = \u000D\u0019\u000E.\u001F(obj);
				return \u0011\u0003\u0004.\u000A(ref this, u000A);
			}
			return false;
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0003E3C4 File Offset: 0x0003C5C4
		public override int GetHashCode()
		{
			int num = 17 * 31;
			string text = \u0010\u0003\u0004.\u000A(ref this);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u0005.GetHashCode()).MethodHandle;
				}
				num2 = 0;
			}
			else
			{
				num2 = \u001B\u0013\u000A.\u000A(\u000D\u0003\u0004.\u0007(text));
			}
			int num3 = (num + num2) * 31;
			string text2 = \u001C\u0003\u0004.\u000A(ref this);
			int num4;
			if (text2 == null)
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
				num4 = 0;
			}
			else
			{
				num4 = \u001B\u0013\u000A.\u000A(text2);
			}
			int num5 = (num3 + num4) * 31;
			string text3 = \u0003\u0003\u0004.\u000A(ref this);
			int num6;
			if (text3 == null)
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
				num6 = 0;
			}
			else
			{
				num6 = \u001B\u0013\u000A.\u000A(text3);
			}
			int num7 = ((num5 + num6) * 31 + \u0012\u0003\u0004.\u000A(ref this).GetHashCode()) * 31;
			string text4 = \u000F\u0003\u0004.\u000A(ref this);
			int num8;
			if (text4 == null)
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
				num8 = 0;
			}
			else
			{
				num8 = \u001B\u0013\u000A.\u000A(text4);
			}
			int num9 = (num7 + num8) * 31;
			long num10 = \u000D\u000F\u0004.\u000A(ref this);
			return num9 + \u0007\u000A\u001D.\u000A(ref num10);
		}

		// Token: 0x0400036F RID: 879
		[CompilerGenerated]
		private readonly string \u001F;

		// Token: 0x04000370 RID: 880
		[CompilerGenerated]
		private readonly string \u000A;

		// Token: 0x04000371 RID: 881
		[CompilerGenerated]
		private readonly string \u0007;

		// Token: 0x04000372 RID: 882
		[CompilerGenerated]
		private readonly RangeTypes \u001D;

		// Token: 0x04000373 RID: 883
		[CompilerGenerated]
		private readonly string \u0004;

		// Token: 0x04000374 RID: 884
		[CompilerGenerated]
		private readonly long \u0019;
	}
}
