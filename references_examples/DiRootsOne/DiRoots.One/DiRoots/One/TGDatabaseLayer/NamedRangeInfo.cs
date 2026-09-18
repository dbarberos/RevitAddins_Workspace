using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using DiRoots.One.Commons.Interfaces;
using Syncfusion.XlsIO;

namespace DiRoots.One.TGDatabaseLayer
{
	// Token: 0x02000117 RID: 279
	[Serializable]
	public class NamedRangeInfo
	{
		// Token: 0x060009F9 RID: 2553 RVA: 0x00042684 File Offset: 0x00040884
		public NamedRangeInfo()
		{
			\u0014\u000E\u0004.\u000A(this, "_xlnm.");
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060009FA RID: 2554 RVA: 0x000426AC File Offset: 0x000408AC
		// (set) Token: 0x060009FB RID: 2555 RVA: 0x000426C0 File Offset: 0x000408C0
		public bool IsBuiltIn { get; set; }

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060009FC RID: 2556 RVA: 0x000426D4 File Offset: 0x000408D4
		// (set) Token: 0x060009FD RID: 2557 RVA: 0x000426E8 File Offset: 0x000408E8
		public bool IsScopeWorkbook { get; set; }

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060009FE RID: 2558 RVA: 0x000426FC File Offset: 0x000408FC
		// (set) Token: 0x060009FF RID: 2559 RVA: 0x00042710 File Offset: 0x00040910
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
			set
			{
				if (\u0013\u000E\u0004.\u000A(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.set_DisplayName(string)).MethodHandle;
					}
					this._displayName = \u001C\u000B\u001D.\u0007(value, \u0013\u001E\u001D.\u001D(this), "");
					return;
				}
				this._displayName = value;
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000A00 RID: 2560 RVA: 0x00042760 File Offset: 0x00040960
		public string Name
		{
			get
			{
				string result = \u001B\u0012\u0004.\u0007(this);
				if (\u0013\u000E\u0004.\u000A(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.get_Name()).MethodHandle;
					}
					result = \u0004\u001E\u000A.\u000A(\u0013\u001E\u001D.\u001D(this), \u001B\u0012\u0004.\u0007(this));
				}
				return result;
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06000A01 RID: 2561 RVA: 0x000427AC File Offset: 0x000409AC
		// (set) Token: 0x06000A02 RID: 2562 RVA: 0x000427C0 File Offset: 0x000409C0
		public string Extension { get; set; }

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x000427D4 File Offset: 0x000409D4
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x000427E8 File Offset: 0x000409E8
		public bool HasBigRange { get; set; }

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x000427FC File Offset: 0x000409FC
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x00042810 File Offset: 0x00040A10
		public int Rows { get; set; }

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000A07 RID: 2567 RVA: 0x00042824 File Offset: 0x00040A24
		// (set) Token: 0x06000A08 RID: 2568 RVA: 0x00042838 File Offset: 0x00040A38
		public int Columns { get; set; }

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000A09 RID: 2569 RVA: 0x0004284C File Offset: 0x00040A4C
		// (set) Token: 0x06000A0A RID: 2570 RVA: 0x00042860 File Offset: 0x00040A60
		public RangeTypes RangeType { get; set; }

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00042874 File Offset: 0x00040A74
		// (set) Token: 0x06000A0C RID: 2572 RVA: 0x00042888 File Offset: 0x00040A88
		public bool IsEnabled { get; set; } = true;

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x06000A0D RID: 2573 RVA: 0x0004289C File Offset: 0x00040A9C
		// (set) Token: 0x06000A0E RID: 2574 RVA: 0x000428B0 File Offset: 0x00040AB0
		public int PrintRangeIndex { get; set; }

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000A0F RID: 2575 RVA: 0x000428C4 File Offset: 0x00040AC4
		// (set) Token: 0x06000A10 RID: 2576 RVA: 0x000428D8 File Offset: 0x00040AD8
		public string PrintRange { get; set; }

		// Token: 0x06000A11 RID: 2577 RVA: 0x000428EC File Offset: 0x00040AEC
		public override bool Equals(object obj)
		{
			if (obj != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.Equals(object)).MethodHandle;
				}
				if (\u0001\u001F\u001D.\u000A(\u0003\u0011\u000A.\u001D(this), \u0003\u0011\u000A.\u0007(obj)))
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
				}
				else
				{
					NamedRangeInfo u001F = \u0015\u0019\u000E.\u001F(obj);
					if (\u0013\u0020\u001D.\u001D(this) == RangeTypes.UsedRange)
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
						return \u0013\u0020\u001D.\u001D(this) == \u0013\u0020\u001D.\u0007(u001F);
					}
					if (\u0013\u0020\u001D.\u001D(this) == RangeTypes.PrintRange)
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
						return \u001A\u000E\u0004.\u001D(this) == \u001A\u000E\u0004.\u0007(u001F);
					}
					return \u0008\u0013\u000A.\u000A(\u001B\u0012\u0004.\u0007(this), \u001B\u0012\u0004.\u001D(u001F));
				}
			}
			return false;
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x000429A4 File Offset: 0x00040BA4
		public override int GetHashCode()
		{
			try
			{
				if (\u001B\u0012\u0004.\u0007(this) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.GetHashCode()).MethodHandle;
					}
					return \u001B\u0013\u000A.\u000A(\u001B\u0012\u0004.\u0007(this));
				}
			}
			catch (Exception u000A)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\NamedRangeInfo.cs", "GetHashCode");
			}
			return 0;
		}

		// Token: 0x06000A13 RID: 2579 RVA: 0x00042A10 File Offset: 0x00040C10
		public NamedRangeInfo CompareInfo(List<NamedRangeInfo> namedRanges)
		{
			NamedRangeInfo namedRangeInfo = \u0010\u0019\u000E.\u001F;
			if (\u0013\u0020\u001D.\u001D(this) == RangeTypes.UsedRange)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.CompareInfo(List<NamedRangeInfo>)).MethodHandle;
				}
				Func<NamedRangeInfo, bool> func;
				if ((func = NamedRangeInfo.<>c.\u000A) == null)
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
					func = (NamedRangeInfo.<>c.\u000A = new Func<NamedRangeInfo, bool>(NamedRangeInfo.<>c.\u001F.\u0018));
				}
				namedRangeInfo = Enumerable.FirstOrDefault<NamedRangeInfo>(namedRanges, func);
			}
			else if (\u0013\u0020\u001D.\u001D(this) == RangeTypes.PrintRange)
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
				Func<NamedRangeInfo, bool> func2;
				if ((func2 = NamedRangeInfo.<>c.\u0007) == null)
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
					func2 = (NamedRangeInfo.<>c.\u0007 = new Func<NamedRangeInfo, bool>(NamedRangeInfo.<>c.\u001F.\u0005));
				}
				IEnumerable<NamedRangeInfo> enumerable = Enumerable.Where<NamedRangeInfo>(namedRanges, func2);
				if (Enumerable.Any<NamedRangeInfo>(enumerable))
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
					NamedRangeInfo namedRangeInfo2;
					if ((namedRangeInfo2 = Enumerable.FirstOrDefault<NamedRangeInfo>(enumerable, new Func<NamedRangeInfo, bool>(this.\u0007))) == null)
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
						namedRangeInfo2 = Enumerable.FirstOrDefault<NamedRangeInfo>(enumerable);
					}
					namedRangeInfo = namedRangeInfo2;
				}
			}
			else if (\u0013\u0020\u001D.\u001D(this) == RangeTypes.Normal)
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
				Func<NamedRangeInfo, bool> func3;
				if ((func3 = NamedRangeInfo.<>c.\u001D) == null)
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
					func3 = (NamedRangeInfo.<>c.\u001D = new Func<NamedRangeInfo, bool>(NamedRangeInfo.<>c.\u001F.\u0016));
				}
				namedRangeInfo = Enumerable.FirstOrDefault<NamedRangeInfo>(Enumerable.Where<NamedRangeInfo>(namedRanges, func3), new Func<NamedRangeInfo, bool>(this.\u001D));
			}
			if (namedRangeInfo == null)
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
				return NamedRangeInfo.\u000A(namedRanges);
			}
			return namedRangeInfo;
		}

		// Token: 0x06000A14 RID: 2580 RVA: 0x00042B78 File Offset: 0x00040D78
		public static NamedRangeInfo GetUsedRange(IRange range, ICustomLogger lgger)
		{
			NamedRangeInfo namedRangeInfo = \u001F\u001E\u001D.\u000A();
			\u0009\u0011\u001D.\u000A(namedRangeInfo, \u0002\u0013\u000A.\u000A("<", \u000C\u000E\u0004.\u000A(), ">"));
			\u0001\u0011\u001D.\u000A(namedRangeInfo, RangeTypes.UsedRange);
			\u0020\u001E\u001D.\u000A(namedRangeInfo, range, lgger);
			return namedRangeInfo;
		}

		// Token: 0x06000A15 RID: 2581 RVA: 0x00042BBC File Offset: 0x00040DBC
		internal static NamedRangeInfo \u000A(List<NamedRangeInfo> \u001F)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.\u000A(List<NamedRangeInfo>)).MethodHandle;
				}
				if (\u000A\u001E\u001D.\u000A(\u001F) != 0)
				{
					Func<NamedRangeInfo, bool> func;
					if ((func = NamedRangeInfo.<>c.\u0004) == null)
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
						func = (NamedRangeInfo.<>c.\u0004 = new Func<NamedRangeInfo, bool>(NamedRangeInfo.<>c.\u001F.\u000B));
					}
					NamedRangeInfo result;
					if ((result = Enumerable.FirstOrDefault<NamedRangeInfo>(\u001F, func)) == null)
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
						Func<NamedRangeInfo, bool> func2;
						if ((func2 = NamedRangeInfo.<>c.\u0019) == null)
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
							func2 = (NamedRangeInfo.<>c.\u0019 = new Func<NamedRangeInfo, bool>(NamedRangeInfo.<>c.\u001F.\u0002));
						}
						if ((result = Enumerable.FirstOrDefault<NamedRangeInfo>(\u001F, func2)) == null)
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
							result = \u0015\u000E\u0004.\u000A(\u001F, 0);
						}
					}
					return result;
				}
				for (;;)
				{
					switch (6)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			return null;
		}

		// Token: 0x06000A16 RID: 2582 RVA: 0x00042C7C File Offset: 0x00040E7C
		public void SetRangeSize(IRange range, ICustomLogger lgger)
		{
			try
			{
				\u0007\u0008\u0004.\u000A(this, \u000B\u0013\u001D.\u000A(range) - \u0009\u0020\u001D.\u000A(range) + 1);
				\u000A\u0008\u0004.\u000A(this, \u0016\u0013\u001D.\u000A(range) - \u0001\u0020\u001D.\u000A(range) + 1);
				bool u000A;
				if (\u001F\u0008\u0004.\u0007(this) < 10000)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(NamedRangeInfo.SetRangeSize(IRange, ICustomLogger)).MethodHandle;
					}
					u000A = (\u0009\u000E\u0004.\u0007(this) >= 10000);
				}
				else
				{
					u000A = true;
				}
				\u0001\u000E\u0004.\u000A(this, u000A);
			}
			catch (Exception u000A2)
			{
				\u000F\u000E\u001D.\u000A(lgger, u000A2, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TGDatabaseLayer\\NamedRangeInfo.cs", "SetRangeSize");
			}
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x00042D20 File Offset: 0x00040F20
		[CompilerGenerated]
		private bool \u0007(NamedRangeInfo \u001F)
		{
			return \u001A\u000E\u0004.\u0007(\u001F) == \u001A\u000E\u0004.\u001D(this);
		}

		// Token: 0x06000A18 RID: 2584 RVA: 0x00042D40 File Offset: 0x00040F40
		[CompilerGenerated]
		private bool \u001D(NamedRangeInfo \u001F)
		{
			return \u0008\u0013\u000A.\u000A(\u001B\u0012\u0004.\u001D(\u001F), \u001B\u0012\u0004.\u0007(this));
		}

		// Token: 0x04000411 RID: 1041
		private static int \u001F;

		// Token: 0x04000414 RID: 1044
		private string _displayName;
	}
}
